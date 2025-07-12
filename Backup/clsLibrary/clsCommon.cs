using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using DbConnection;
using CrystalDecisions.Shared;
using System.IO.Ports;

namespace clsLibrary
{
    public class clsCommon:clsValidation
    {
        private SqlDataReader dr;
        public SqlDataReader Adr
        {
            get { return dr; }
            set { dr = value; }
        }

        private DataSet ds;
        public DataSet Ads
        {
            get { return ds; }
            set { ds = value; }
        }

        private int _Cases;
        public int Cases
        {
            get { return _Cases; }
            set { _Cases = value; }
        }

        private bool _RecRead;
        public bool RecRead
        {
            get { return _RecRead; }
            set { _RecRead = value; }
        }

        private bool _RecordFind;
        public bool RecordFind
        {
            get { return _RecordFind; }
            set { _RecordFind = value; }
        }

        public void getDataReader(string sqlStatement)
        {
            dr = dbcon.GetReader(sqlStatement);
        }

        public void getDataSet(string sqlStatement, string dsName)
        {
            ds = dbcon.getDataset(sqlStatement, dsName);
        }

        public void closeConnection()
        {
            dbcon.CloseConnection();
            dbcon.CloseReader();
        }

        public void SetConnection(string server, string db,string userName, string Pass)
        {
            closeConnection();
            dbcon.SetConnectionString(server, db, userName, Pass);
        }

        private int intErrCode;
        public int ErrCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }


        private string strProdCode;
        public string ProdCode
        {
            get { return strProdCode; }
            set { strProdCode = value; }
        }

        private string strProdName;
        public string ProdName
        {
            get { return strProdName; }
            set { strProdName = value; }
        }
        private string strSqlStatement;
        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }
        private decimal decQty;
        public decimal Qty
        {
            get { return decQty; }
            set { decQty = value; }
        }

        private DataSet dsTempBarcoderint;
        public DataSet TempBarcodePrint
        {
            get { return dsTempBarcoderint; }
            set { dsTempBarcoderint = value; }
        }

        private string[] Printers;
        public string[] _Printers
        {
            get { return Printers; }
            set { Printers = value; }
        }


        public void UpdateTempBarcodePrint()
        {
            try
            {
                closeConnection();
                intErrCode = 0;
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBarcodePrint";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,strProdCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Float, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decQty));
              
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsBarcode 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Barcode
                dsTempBarcoderint = dbcon.getDataset("SELECT Prod_Code [Product Code], Prod_Name [Product Name], Qty FROM tb_TempBarcodePrint ", "dsTempBarcodePrint");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsBarcode 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void POSPrint(CrystalDecisions.CrystalReports.Engine.ReportDocument PrintingReport)
        {
            int i=0;
            string[] pp= new string[10];  
            foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                pp[i] = sPrinters;
                i++;
            }

            if (MessageBox.Show("Do you want to Print This Document. ", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                PrintingReport.PrintOptions.PrinterName = "BIXOLON SRP-350II";
                PrintingReport.PrintToPrinter(1, false, 0, 0);
            }
        }

        public void CheckNumeric(KeyPressEventArgs e, string txtValue)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                decimal value;
                e.Handled = !decimal.TryParse(txtValue + e.KeyChar, out value);
            }
        }

        public void Recordfind(string SQL)
        {
            try
            {
                dr = dbcon.GetReader(SQL);
                RecordFind = false;
                if (dr.Read())
                {
                    RecordFind = true;
                }
                else
                {
                    RecordFind = false;
                }
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }
            finally
            {
                dbcon.CloseConnection();
                dr.Dispose();
            }
        }

        public bool ProductExpireHave(string ProdCode)
        {
            try
            {
                dr = dbcon.GetReader("SELECT Prod_Code From Product WHERE ExpireItem=1 AND Prod_Code='" + ProdCode + "'");
                RecordFind = false;
                if (dr.Read())
                {
                    RecordFind = true;
                }
                else
                {
                    RecordFind = false;
                }
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
                RecordFind = false;
            }
            finally
            {
                dbcon.CloseConnection();
                dr.Dispose();
            }
            return RecordFind;
        }

        public DataTable Get_BatchList(string ProdCode,bool Return)
        {
            DataTable dt;
            try
            {
                if (Return == true)
                {
                    dt = dbcon.getDataset("select BatchNo from Stock_Master_Batch WHERE Loca='" + LoginManager.LocaCode + "' and Prod_Code='" + ProdCode + "' ORDER BY BatchNo ", "dtBatch").Tables[0];
                }
                else
                {
                    dt = dbcon.getDataset("select BatchNo from Stock_Master_Batch WHERE Loca='" + LoginManager.LocaCode + "' and Prod_Code='" + ProdCode + "' and   Stock>0 ORDER BY BatchNo ", "dtBatch").Tables[0];

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                dt = null;
            }
            finally
            {
                dbcon.CloseConnection();
            }
            return dt;
        }
          

        public DataTable Get_BatchDetails(string ProdCode, string BatchNo)
        {
            DataTable dt;
            try
            {
                dt = dbcon.getDataset("select Prod_Code, BatchNo, Exp_Date, Shipment, Stock, Purchase_Price, Ws_Price, Ret_Price, Distr_Price, ModMkt_Price from Stock_Master_Batch WHERE Loca='" + LoginManager.LocaCode + "' and Prod_Code='" + ProdCode + "' and BatchNo='" + BatchNo + "' ", "dtBatch").Tables[0];
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                dt = null;
            }
            finally 
            {
                dbcon.CloseConnection();
            }
            return dt;
        }
        public void GetDs()
        {
            try
            {
                ds = dbcon.getDataset(strSqlStatement, "Ds");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetDsApi()
        {
            try
            {
                ds = dbcon.getDatasetOt(strSqlStatement, "Ds");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet  GetCardDetails(string CardNo,string PayType)
        {
            try
            {
                strSqlStatement = "EXEC dbo.Sp_RecallRedeemdetails  @PayType = @PayType,@Loca = @Loca,@Cardno = @Cardno ";
                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@PayType", PayType));
                lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                lstPrm.Add(new SqlParameter("@Cardno", CardNo));

                return  ds = dbcon.GetDataSet(strSqlStatement, lstPrm);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
