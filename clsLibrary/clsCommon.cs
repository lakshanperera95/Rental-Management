using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using DbConnection; 
using System.IO.Ports;

namespace clsLibrary
{
    public class clsCommon : clsValidation
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
        public DataSet getData(string sqlStatement)
        {
            return ds = dbcon.getDataset(sqlStatement, "ds");
        }

        public void closeConnection()
        {
            dbcon.CloseConnection();
            dbcon.CloseReader();
        }

        public void SetConnection(string server, string db, string userName, string Pass)
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
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdCode));
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

        //public void POSPrint(CrystalDecisions.CrystalReports.Engine.ReportDocument PrintingReport)
        //{
        //    int i = 0;
        //    string[] pp = new string[10];
        //    foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
        //    {
        //        pp[i] = sPrinters;
        //        i++;
        //    }

        //    if (MessageBox.Show("Do you want to Print This Document. ", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {

        //        PrintingReport.PrintOptions.PrinterName = "BIXOLON SRP-350II";
        //        PrintingReport.PrintToPrinter(1, false, 0, 0);
        //    }
        //}

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

        public DataTable Get_BatchList(string ProdCode, bool Return)
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
        public DataSet GetCardDetails(string CardNo, string PayType)
        {
            try
            {
                strSqlStatement = "EXEC dbo.Sp_RecallRedeemdetails  @PayType = @PayType,@Loca = @Loca,@Cardno = @Cardno ";
                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@PayType", PayType));
                lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                lstPrm.Add(new SqlParameter("@Cardno", CardNo));

                return ds = dbcon.GetDataSet(strSqlStatement, lstPrm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CheckStock(string docNo, string Iid)
        {
            try
            {
                //get Temporary DataSet For Grn
                ds = dbcon.getDataset("select  ST.Prod_Code,ST.Stock,(T.Qty+T.FreeQty)[Qty] FROM TransactionTemp_Details T JOIN dbo.Stock_Master_Batch ST ON ST.BatchNo = T.BatchNo AND ST.Prod_Code = T.Prod_Code AND ST.Loca = T.Loca JOIN dbo.Stock_Master S ON S.Loca = ST.Loca AND S.Prod_Code = ST.Prod_Code WHERE Doc_No = '" + docNo + "' AND S.MinusAllow=0 AND IId = '" + Iid + "' AND T.Loca  = " + LoginManager.LocaCode + " Order by Ln", "Invoice");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }


        public DataSet CheckUnit()
        {
            try
            {
                strSqlStatement = "SELECT UnitNo FROM dbo.tbUnitDetails WHERE MacAddress='" + System.Environment.MachineName.ToString() + "' AND Loca='" + LoginManager.LocaCode + "' and Flag=1";
                return ds = dbcon.getDataset(strSqlStatement, "dsd");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string Mes { get; set; }
        public void CheckCancelDt(string Iid, string docno)
        {
            //DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CanceleationCheck";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@IId", Iid));
                command.Parameters.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@DocNo", docno));
                command.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 1));
                command.Parameters.Add(new SqlParameter("@Msg", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ""));


                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;

                intErrCode = (Int32)(command.Parameters["@ErrCode"].Value);
                Mes = (string)(command.Parameters["@Msg"].Value);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }
        public static string CostCodeGenrate(decimal PurchasePrice)
        {
            try
            {

                string XCode = "", Dup = "", Dup2 = "";
                decimal AD = PurchasePrice + (decimal)0.01;
                //decimal AD = (decimal.Parse(txtPurchPrice.Text.Trim()) + (decimal)0.01);
                string AC = AD.ToString();
                string Cost = AC.Substring(0, AC.IndexOf('.', 0));
                string A = "", B = "", C = "", D = "", E = "", F = "", G = "", H = "", I = "";
                costCode("EXEC sp_CostCode '" + Cost + "'", ref A, ref B, ref C, ref D, ref E, ref F, ref G, ref H, ref I);
                GetXCode(ref XCode, " SELECT xCode FROM tbCostCodeInfo");

                string CostCode = A + B + C + D + E + F + G + H + I;

                string Costs = "";
                for (int i = 0; i < CostCode.Length; i++)
                {
                    Dup = CostCode.Substring(i, 1);
                    if (Dup == Dup2 && Costs.Substring(Costs.Length - 1, 1) != "X")
                    {

                        Costs = Costs + XCode;
                    }
                    else
                    {
                        Dup2 = Dup;
                        Costs += Dup;
                    }
                }

                return Costs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void costCode(string Value, ref string a1, ref string a2, ref string a3, ref string a4, ref string a5, ref string a6, ref string a7, ref string a8, ref string a9)
        {
            try
            {

                SqlDataReader dr = dbcon.GetReader(Value);
                if (dr.Read())
                {

                    a1 = dr["Val1"].ToString();
                    a2 = dr["Val2"].ToString();
                    a3 = dr["Val3"].ToString();
                    a4 = dr["Val4"].ToString();
                    a5 = dr["Val5"].ToString();
                    a6 = dr["Val6"].ToString();
                    a7 = dr["Val7"].ToString();
                    a8 = dr["Val8"].ToString();
                    a9 = dr["Val9"].ToString();

                }

            }
            catch (Exception e)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        public static void GetXCode(ref string XCode, string Sqlstatement)
        {
            try
            {
                SqlDataReader dr = dbcon.GetReader(Sqlstatement);
                if (dr.Read())
                {
                    XCode = dr["XCode"].ToString();
                }


            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        

    }
}
