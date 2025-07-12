using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DbConnection;

namespace clsLibrary
{
    public class clsInvoiceCustomerPayment
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;

        private string strTempDocumentNo;
        private string strLocaCode;
        private string strLocaName;
        private string strCustCode;
        private string strCustName;
        private string strSqlStatement;
        private string strDataSetName;
        private string strPostDate;
        private string strOrgDocNo;
        private string strPendingDocNo;
        private string strPay_Type;
        private string strBankName;
        private string strChequeNo;
        private string strChequeDate;
        private string strBranchName;

        private decimal decAmount;
        private decimal decTotalAmount;
        private decimal decPendingPayAmount;
        private decimal decPendingPayTotalAmt;
        private decimal decSelTotalAmount;
        private decimal decTotalPayment;

        private DataSet dsCustomerDataSet;
        private DataSet dsForReport;
        private DataSet dsForSubReport;
        private DataSet dsPendingPayment;
        private DataSet dsSelectedPayment;
        private DataSet dsPayments;
        private DataSet dsBankDetails;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion

        #region Properties
        public string TempDocNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }

        public string OrgDocNo
        {
            get { return strOrgDocNo; }
            set { strOrgDocNo = value; }
        }

        public string PendingDocNo
        {
            get { return strPendingDocNo; }
            set { strPendingDocNo = value; }
        }

        public string PostDate
        {
            get { return strPostDate; }
            set { strPostDate = value; }
        }

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string LocaCode
        {
            get { return strLocaCode; }
            set { strLocaCode = value; }
        }

        public string LocaName
        {
            get { return strLocaName; }
            set { strLocaName = value; }
        }

        public string CustCode
        {
            get { return strCustCode; }
            set { strCustCode = value; }
        }

        public string CustName
        {
            get { return strCustName; }
            set { strCustName = value; }
        }

        public string Pay_Type
        {
            get { return strPay_Type; }
            set { strPay_Type = value; }
        }

        public string SelectBankName
        {
            get { return strBankName; }
            set { strBankName = value; }
        }

        public string BranchName
        {
            get { return strBranchName; }
            set { strBranchName = value; }
        }

        public string ChequeNo
        {
            get { return strChequeNo; }
            set { strChequeNo = value; }
        }

        public string ChequeDate
        {
            get { return strChequeDate; }
            set { strChequeDate = value; }
        }

        public decimal TotalAmount
        {
            get { return decTotalAmount; }
            set { decTotalAmount = value; }
        }

        public decimal Amount
        {
            get { return decAmount; }
            set { decAmount = value; }
        }

        public decimal PendingPayAmount
        {
            get { return decPendingPayAmount; }
            set { decPendingPayAmount = value; }
        }

        public decimal PendingPayTotalAmt
        {
            get { return decPendingPayTotalAmt; }
            set { decPendingPayTotalAmt = value; }
        }

        public decimal SelTotalAmount
        {
            get { return decSelTotalAmount; }
            set { decSelTotalAmount = value; }
        }

        public decimal TotalPayment
        {
            get { return decTotalPayment; }
            set { decTotalPayment = value; }
        }

        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        public string DataetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public DataSet GetCustomerDataset
        {
            get { return dsCustomerDataSet; }
            set { dsCustomerDataSet = value; }
        }

        public DataSet GetReportDataset
        {
            get { return dsForReport; }
            set { dsForReport = value; }
        }

        public DataSet GetSubReportDataset
        {
            get { return dsForSubReport; }
            set { dsForSubReport = value; }
        }

        public DataSet GetPendingPayment
        {
            get { return dsPendingPayment; }
            set { dsPendingPayment = value; }
        }

        public DataSet SelectedPayment
        {
            get { return dsSelectedPayment; }
            set { dsSelectedPayment = value; }
        }

        public DataSet Payments
        {
            get { return dsPayments; }
            set { dsPayments = value; }
        }

        public DataSet BankName
        {
            get { return dsBankDetails; }
            set { dsBankDetails = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        private string strSalesmanCode;
        public string SalesmanCode
        {
            get { return strSalesmanCode; }
            set { strSalesmanCode = value; }
        }


        #endregion

        //Get Tempory Document No
        public void GetTempDocumentNo()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo="REC" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;

                }
                dbcon.CloseReader();
                DataReader.Dispose();

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
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                GetTempDataset();
            }
        }

        public void GetBankDetails()
        {
            try
            {
                //get Bank DataSet For Grn
                dsBankDetails = dbcon.getDataset("SELECT * FROM BankDetails ORDER BY Bank_Code", "BankDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsPendingPayment = dbcon.getDataset("select Doc_No, Transaction_Date, Transaction_Amount, Balance_Amount, Temp_DocNo from tbPendingPayments WHERE Temp_DocNo = '" + strTempDocumentNo + "' AND IId = 'REC' AND Loca = " + LoginManager.LocaCode + "", "PendingPayments");
                dsSelectedPayment = dbcon.getDataset("select Doc_No, Transaction_Date, Transaction_Amount, Balance_Amount, Paid_Amount, Temp_DocNo from tbSelectedPayments WHERE Temp_DocNo = '" + strTempDocumentNo + "' AND IId = 'REC' AND Loca = " + LoginManager.LocaCode + " ", "SelectedPayment");
                dsPayments = dbcon.getDataset("select Temp_DocNo, Payment_Mode, Bank_Name, Cheque_No, Branch, Amount from tbPaymentDetails WHERE Temp_DocNo = '" + strTempDocumentNo + "' AND IId = 'REC' AND Loca = " + LoginManager.LocaCode + " ", "Payments");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void LoadCustomerTransaction()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_LoadPendingTransaction";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@AccCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode.Trim()));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetCustomerDetails()
        {
            try
            {
                dsCustomerDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadCustomerDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    CustCode = DataReader["Cust_Code"].ToString().Trim();
                    CustName = DataReader["Cust_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    CustCode = string.Empty;
                    CustName = string.Empty;
                    RecordFound = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void ReadPendingTotalAmounts()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    decPendingPayTotalAmt = (decimal)DataReader["PendingPayTotalAmt"];
                }
                else
                {
                    decPendingPayTotalAmt = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void AddToPaymentList()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_AddToPaymentList";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPendingDocNo));
                command.Parameters.Add(new SqlParameter("@Paid_Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPendingPayAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            dbcon.connection.Close();

        }

        public void AddToPaymentMode()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_AddPaymentMode";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Temp_DocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Payment_Mode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPay_Type));
                command.Parameters.Add(new SqlParameter("@Bank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBankName));
                command.Parameters.Add(new SqlParameter("@Cheque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strChequeNo));
                command.Parameters.Add(new SqlParameter("@Cheque_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strChequeDate));
                command.Parameters.Add(new SqlParameter("@Branch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBranchName));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadSelTotalAmount()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    decSelTotalAmount = (decimal)DataReader["SelTotalAmount"];
                }
                else
                {
                    decSelTotalAmount = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void DeleteFromPaymentList()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_DeleteFromPaymentList";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPendingDocNo));
                command.Parameters.Add(new SqlParameter("@Paid_Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPendingPayAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 011. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadTempTransDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                RecordFound = false;
                if (DataReader.Read())
                {
                    RecordFound = true;
                }
                else
                {
                    RecordFound = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void ReadTotalPayment()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    decTotalPayment = (decimal)DataReader["decTotalPayment"];
                }
                else
                {
                    decTotalPayment = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void GetOrgDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader("select Receipt_No from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);                    
                    strOrgDocNo = "REC" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo;
                    
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 014. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void CustomerPaymentApply()
        {
            //DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                GetOrgDocumentNo();
                //strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_PaymentApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Temp_DocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@Acc_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                //command.Parameters.Add(new SqlParameter("@SalesmanCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSalesmanCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 015. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetDataSetForReport()
        {
            try
            {
                dsForReport = dbcon.getDataset("SELECT tbPaidPaymentDetails.Org_Doc_no, tbPaidPaymentDetails.Post_Date, tbPaidPaymentDetails.Doc_No, tbPaidPaymentDetails.Transaction_Date, tbPaidPaymentDetails.Balance_Amount, tbPaidPaymentDetails.Transaction_Amount, tbPaidPaymentDetails.Paid_Amount, tbPaidPaymentDetails.Loca, Location.Loca_Descrip, tbPaidPaymentDetails.Acc_Code, customer.cust_Name Acc_Name, customer.Address1, customer.Address2, customer.Address3, customer.Address4, tbPaidPaymentDetails.[User_Name], 'Original' Status FROM tbPaidPaymentDetails INNER JOIN customer ON tbPaidPaymentDetails.Acc_Code = Customer.Cust_Code INNER JOIN Location ON tbPaidPaymentDetails.Loca = Location.Loca WHERE tbPaidPaymentDetails.Org_Doc_no = '" + strOrgDocNo + "' AND tbPaidPaymentDetails.Loca = '" + LoginManager.LocaCode + "' AND tbPaidPaymentDetails.Iid = 'REC';SELECT * FROM CompanyProfile", "tbPaidPaymentSummary");
                dsForSubReport = dbcon.getDataset("SELECT Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, Branch, Amount FROM tbPaidPaymentSummary WHERE tbPaidPaymentSummary.Org_Doc_no = '" + strOrgDocNo + "' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND tbPaidPaymentSummary.Iid = 'REC'", "tbPaidPaymentMode");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomerPayment 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
