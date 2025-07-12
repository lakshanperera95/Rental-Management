using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DbConnection;

namespace clsLibrary
{
    public class clsSalesTransfer:clsValidation
    {
        #region General Declaration
        private string strUnit;
        private string strReceipt;
        private decimal decNetSales;
        private decimal decCredit;
        private decimal decCash;
        private string strSqlStatement;
        private DataSet ds1;
      
        #endregion

        #region General Declaration
  





        public DataSet getds1
        {
            get { return ds1; }
            set { ds1 = value; }
        }


        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }
	

        public decimal Cash
        {
            get { return decCash; }
            set { decCash = value; }
        }
	

        public decimal Credit
        {
            get { return decCredit; }
            set { decCredit = value; }
        }
	

        public decimal NetSales
        {
            get { return decNetSales; }
            set { decNetSales = value; }
        }
	

        public string Receipt
        {
            get { return strReceipt; }
            set { strReceipt = value; }
        }
	
       
        public string Unit
        {
            get { return strUnit; }
            set { strUnit = value; }
        }
        private decimal _Amount;
            
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
	

        private int _ErrorCode;
        public int ErrorCode
        {
            get { return _ErrorCode; }
            set { _ErrorCode = value; }
        }

        public bool blRecordFound { get;  set; }
        public SqlDataReader dtReader { get;  set; }
        public string TempDocumentNo { get; set; }
        public string Selected_Loca { get; set; }
        public string iid { get; set; }
        public int intErrCode { get;  set; }
        public string strPostDate { get;  set; }
        public int intTempDocNo { get;  set; }
        public string strTempDocumentNo { get;  set; }
        public string Code { get;  set; }
        public string Descript { get;  set; }
        public string Short_Description { get;  set; }

        private string strReportID;

        public string ReportID
        {
            get { return strReportID; }
            set { strReportID = value; }
        }

        private string strBilldate;

        public string Billdate
        {
            get { return strBilldate; }
            set { strBilldate = value; }
        }

        public string TaxLoca_Code { get; set; }

        #endregion
        public void Reading(string Query)
        {
            try
            {
                blRecordFound = false;
                using (SqlDataReader reader = dbcon.GetReader(Query))
                {
                    if (reader.Read())
                    {
                        blRecordFound = true;
                    }
                    else
                    {
                        blRecordFound = false;
                    }
                }


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
            finally
            {
                dbcon.CloseReader();
            }
        }

        public void ReadingLocaDetails(string Query)
        {
            try
            {
                blRecordFound = false;

                dtReader = dbcon.GetReader(Query);
                if (dtReader.Read())
                {
                    Code = dtReader["Loca"].ToString().Trim();
                    Descript = dtReader["Loca_Descrip"].ToString().Trim(); 
                    blRecordFound = true;
                }
                else
                {
                    Code = string.Empty;
                    Descript = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.CloseReader();
                dtReader.Dispose();
            }
        }

        public void PosTaxSalesTransfer(string DateFrom, string Unit, decimal Amount, string Receipt, bool crdtrenable, decimal crdAmount, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Unit));
                command.Parameters.Add(new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Receipt));
                command.Parameters.Add(new SqlParameter("@SelAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Amount));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName)); 
                command.Parameters.Add(new SqlParameter("@CrdTrEnable", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, crdtrenable));
                command.Parameters.Add(new SqlParameter("@CrdAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, crdAmount));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@ErrorCode"].Value);
            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }


        }

        public void GetTempDocumentNo(string strSqlStatement)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                //DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                dtReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (dtReader.Read())
                {
                    //intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    intTempDocNo = int.Parse(dtReader[0].ToString());
                    //String.Format("{0:00000}", 15); 
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo = "PTX" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;

                }
                dbcon.CloseReader();
                dtReader.Dispose();

                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UpdateTempDocNo";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "PTX"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();
        

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
            finally
            {
                dbcon.CloseConnection(); 
            }
        }
  
        public void TransactionTransfer(string Loca, string To_Loca, string Temp_Doc_no, string DateFrom, string DateTo, string Iid, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@To_Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, To_Loca));
                command.Parameters.Add(new SqlParameter("@Temp_Doc_no", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Temp_Doc_no));
                command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTo));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Iid));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                 
            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }

        }

        public void CheckPurchaseTr(string DateFrom, string DateTo, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection; 
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;

                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Selected_Loca));
                command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTo));
                command.Parameters.Add(new SqlParameter("@Machine_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, System.Environment.MachineName.ToString().Trim()));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, iid));
                command.Parameters.Add(new SqlParameter("@Selected_Loca", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Selected_Loca));

                SqlDataAdapter SDA = new SqlDataAdapter(command);
                SDA.Fill(getds1 = new DataSet(), "dsTrPurchAmount");
               // command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }

        }

        public void PosSales(string DateFrom, string Unit, string Receipt, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TaxLoca_Code));
                command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Unit));
                command.Parameters.Add(new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Receipt));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                SDA.Fill(getds1 = new DataSet(), "DSQuery");



            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosSales");
            }
            finally
            {
                dbcon.CloseConnection();
            }
           

        }



        public void PosTaxSalesTransferfroreport(string DateFrom, string Unit, decimal Amount, string Receipt, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TaxLoca_Code));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Unit));
                command.Parameters.Add(new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Receipt));
                command.Parameters.Add(new SqlParameter("@SelAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Amount));
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                SDA.Fill(getds1 = new DataSet(), "DSQuery");


            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer2-PosTaxSalesTransferfroreport");
            }
            finally
            {
                dbcon.CloseConnection();
            }

        }

        public void PosTaxSalesTransferfroreportBillWise(string DateFrom, string Unit, decimal Amount, string Receipt, bool crdtrenable, decimal crdAmount, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Unit));
                command.Parameters.Add(new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Receipt));
                command.Parameters.Add(new SqlParameter("@SelAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Amount));
                command.Parameters.Add(new SqlParameter("@CrdTrEnable", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, crdtrenable));
                command.Parameters.Add(new SqlParameter("@CrdAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, crdAmount));
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                SDA.Fill(getds1 = new DataSet(), "DSQuery");
 
            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer2-PosTaxSalesTransferfroreport");
            }
            finally
            {
                dbcon.CloseConnection();
            }

        }
        public void PosTaxSalesTransfer(string DateFrom, string Unit, decimal Amount, string Receipt, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TaxLoca_Code));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Unit));
                command.Parameters.Add(new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Receipt));
                command.Parameters.Add(new SqlParameter("@SelAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Amount));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@TrLoca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.ExtLoca));

                command.ExecuteNonQuery();
               
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@ErrorCode"].Value);
            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }


        }

        public void DeletePosTaxSalesTransfer(string DateFrom, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@TrLoca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.ExtLoca));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();

           
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@ErrorCode"].Value);
            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }


        }

        public void CheckTransfer(string DateFrom, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.ExtLoca));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                SDA.Fill(getds1 = new DataSet(), "DSTrQuary");
                command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }


        }

        public void Dataset(string sql)
        {
            ds1 = dbcon.getDataset(sql,"dscombo");
            dbcon.CloseConnection();
        }

        public void DataReader(string sql)
        {
            dtReader = dbcon.GetReader(sql);
            dbcon.CloseConnection();
        }

        public void DataReaderTax(string sql,string dsName)
        {
            ds1 = dbcon.getDataset(sql, dsName);
            dbcon.CloseConnection();
        }
        public void DatasetTr(string sql)
        {
            ds1 = dbcon.getDataset(sql, "dsTrAmounts");
            dbcon.CloseConnection();
        }

        public void CheckPurchaseTr(string DateFrom, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.CloseConnection();
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@dtpDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                SqlDataAdapter SDA = new SqlDataAdapter(command);
                SDA.Fill(getds1 = new DataSet(), "dsTrPurchAmount");
                //command.ExecuteNonQuery();
                //ds1 = new DataSet();
                //DataTableReader emtyDTR = null;
                //dbcon.executeStoredProcedure(ref command, dbcon.sqlCommandExecuteTypes.ExecuteSp_AndGetDataset, ref ds1, "dsTrPurchAmount", ref emtyDTR, "SalesDetailsReport");


            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }


        }

        public void PurchaseTr(string DateFrom, string SP)
        {
            try
            {
                _ErrorCode = 0;
                dbcon.CloseConnection();
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.CommandTimeout = 5000;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@ToLoca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.ExtLoca));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.ExecuteNonQuery();
                //DataSet emptyDs = null;
                //DataTableReader emtyDTR = null;
                //dbcon.executeStoredProcedure(ref command, dbcon.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "SalesDetailsReport");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                Errormsg(ex, "clsSalesTransfer-PosTaxSalesTransfer");
            }
            finally
            {
                dbcon.CloseConnection();
            }


        }
 

    }
}
