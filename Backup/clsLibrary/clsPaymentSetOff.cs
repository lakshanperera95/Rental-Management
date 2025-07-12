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
    public class clsPaymentSetOff
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;

        private string strTempDocumentNo;
        private string strLocaCode;
        private string strLocaName;
        private string strSuppCode;
        private string strSuppName;
        private string strSqlStatement;
        private string strDataSetName;
        private string strPostDate;
        private string strOrgDocNo;
        private string strPendingDocNo;
        private string strReturnDocNo;

        private decimal decAmount;
        private decimal decTotalAmount;
        private decimal decPendingPayAmount;
        private decimal decReturnPayAmount;
        private decimal decPendingPayTotalAmt;
        private decimal decSelTotalAmount;
        private decimal decTotalPayment;

        private DataSet dsSupplierDataSet;
        private DataSet dsForReport;
        private DataSet dsForSubReport;
        private DataSet dsPendingPayment;
        private DataSet dsSelectedsSetOff;
        private DataSet dsSupplierReturn;

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
            get            {                return strPendingDocNo;            }
            set            {                strPendingDocNo = value;            }
        }

        public string ReturnDocNo
        {
            get { return strReturnDocNo; }
            set { strReturnDocNo = value; }
        }

        public string PostDate
        {
            get            {                return strPostDate;            }
            set            {                strPostDate = value;            }
        }

        public int ErrorCode
        {
            get            {                return intErrCode;            }
            set            {                intErrCode = value;            }
        }

        public string LocaCode
        {
            get            {                return strLocaCode;            }
            set            {                strLocaCode = value;            }
        }

        public string LocaName
        {
            get            {                return strLocaName;            }
            set            {                strLocaName = value;            }
        }

        public string SuppCode
        {
            get            {                return strSuppCode;            }
            set            {                strSuppCode = value;            }
        }

        public string SuppName
        {
            get            {                return strSuppName;            }
            set            {                strSuppName = value;            }
        }

        public decimal TotalAmount
        {
            get            {                return decTotalAmount;            }
            set            {                decTotalAmount = value;            }
        }

        public decimal Amount
        {
            get            {                return decAmount;            }
            set            {                decAmount = value;            }
        }

        public decimal PendingPayAmount
        {
            get            {                return decPendingPayAmount;            }
            set            {                decPendingPayAmount = value;            }
        }

        public decimal ReturnPayAmount
        {
            get { return decReturnPayAmount; }
            set { decReturnPayAmount = value; }
        }

        public decimal PendingPayTotalAmt
        {
            get            {                return decPendingPayTotalAmt;            }
            set            {                decPendingPayTotalAmt = value;            }
        }

        public decimal SelTotalAmount
        {
            get            {                return decSelTotalAmount;            }
            set            {                decSelTotalAmount = value;            }
        }

        public decimal TotalPayment
        {
            get            {                return decTotalPayment;            }
            set            {                decTotalPayment = value;            }
        }

        public string SqlStatement
        {
            get            {                return strSqlStatement;            }
            set            {                strSqlStatement = value;            }
        }

        public string DataetName
        {
            get            {                return strDataSetName;            }
            set            {                strDataSetName = value;            }
        }

        public DataSet GetSupplierDataset
        {
            get            {                return dsSupplierDataSet;            }
            set            {                dsSupplierDataSet = value;            }
        }

        public DataSet GetReportDataset
        {
            get            {                return dsForReport;            }
            set            {                dsForReport = value;            }
        }

        public DataSet GetSubReportDataset
        {
            get            {                return dsForSubReport;            }
            set            {                dsForSubReport = value;            }
        }

        public DataSet GetPendingPayment
        {
            get { return dsPendingPayment; }
            set { dsPendingPayment = value; }
        }

        public DataSet SelectedsSetOff
        {
            get            {                return dsSelectedsSetOff;            }
            set            {                dsSelectedsSetOff = value;            }
        }

        public DataSet SupplierReturn
        {
            get            {                return dsSupplierReturn;            }
            set            {                dsSupplierReturn = value;            }
        }

        public Boolean RecordFound
        {
            get            {                return blRecordFound;            }
            set            {                blRecordFound = value;            }
        }

        #endregion

        //Get Tempory Document No
        public void GetTempDocumentNo(string Iid)
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
                    if (Iid == "SUP")
                    {
                        strTempDocumentNo = "SSO" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;
                    }
                    else
                    {
                        strTempDocumentNo = "CSO" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;
                    }
                    
                   
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


            try
            {
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
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOP"));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsPendingPayment = dbcon.getDataset("SELECT Doc_No, Transaction_Date, Transaction_Amount, Balance_Amount, Temp_DocNo FROM tbPendingPayments WHERE Balance_Amount > 0 AND Temp_DocNo = '" + strTempDocumentNo + "' AND Tr_Type = 'GRN' AND IId = 'SOP' AND Loca = " + LoginManager.LocaCode + "", "PendingPayments");
                dsSupplierReturn = dbcon.getDataset("SELECT Doc_No, Transaction_Date, Transaction_Amount, Balance_Amount, Temp_DocNo FROM tbPendingPayments WHERE Balance_Amount > 0 AND Temp_DocNo = '" + strTempDocumentNo + "' AND (Tr_Type = 'SRN' OR Tr_Type='SADV') AND IId = 'SOP' AND Loca = " + LoginManager.LocaCode + "", "PendingReturns");
                dsSelectedsSetOff = dbcon.getDataset("SELECT Grn_Doc, Grn_Tr_Date, Grn_Tr_Amount, Grn_Balance_Amount, Srn_Doc, Srn_Tr_Date, Srn_Tr_Amount ,Srn_Balance_Amount, Temp_DocNo, Loca FROM tbTempSetoff WHERE Temp_DocNo = '" + strTempDocumentNo + "' AND IId = 'SOP' AND Loca = " + LoginManager.LocaCode + " ", "SelectedSetoff");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTempCustomerDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsPendingPayment = dbcon.getDataset("SELECT Doc_No, Transaction_Date, Transaction_Amount, Balance_Amount, Temp_DocNo FROM tbPendingPayments WHERE Balance_Amount > 0 AND Temp_DocNo = '" + strTempDocumentNo + "' AND Tr_Type = 'INV' AND IId = 'SOR' AND Loca = '" + LoginManager.LocaCode + "'", "PendingPayments");
                dsSupplierReturn = dbcon.getDataset("SELECT Doc_No, Transaction_Date, Transaction_Amount, Balance_Amount, Temp_DocNo FROM tbPendingPayments WHERE Balance_Amount > 0 AND Temp_DocNo = '" + strTempDocumentNo + "' AND (Tr_Type= 'CADV' OR Tr_Type = 'CUR') AND IId = 'SOR' AND Loca = '" + LoginManager.LocaCode + "'", "PendingReturns");
                dsSelectedsSetOff = dbcon.getDataset("SELECT Grn_Doc, Grn_Tr_Date, Grn_Tr_Amount, Grn_Balance_Amount, Srn_Doc, Srn_Tr_Date, Srn_Tr_Amount ,Srn_Balance_Amount, Temp_DocNo, Loca FROM tbTempSetoff WHERE Temp_DocNo = '" + strTempDocumentNo + "' AND IId = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' ", "SelectedSetoff");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetSupplierDetails()
        {
            try
            {
                dsSupplierDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadSupplierDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strSuppCode = DataReader["Supp_Code"].ToString().Trim();
                    strSuppName = DataReader["Supp_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strSuppCode = string.Empty;
                    strSuppName = string.Empty;
                    blRecordFound = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void LoadSupplierTransaction()
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
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOP"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@AccCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode.Trim()));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOR"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@AccCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode.Trim()));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void AddToSetOffList()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SetOffTempUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Grn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPendingDocNo));
                command.Parameters.Add(new SqlParameter("@Grn_Tr_Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPendingPayAmount));
                command.Parameters.Add(new SqlParameter("@Srn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReturnDocNo));
                command.Parameters.Add(new SqlParameter("@Srn_Tr_Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decReturnPayAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOP"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void AddToCustomerSetOffList()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SetOffTempUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Grn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPendingDocNo));
                command.Parameters.Add(new SqlParameter("@Grn_Tr_Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPendingPayAmount));
                command.Parameters.Add(new SqlParameter("@Srn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReturnDocNo));
                command.Parameters.Add(new SqlParameter("@Srn_Tr_Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decReturnPayAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOR"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "PMT"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 011. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteSetOffDetaile()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SetOffTempDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Grn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPendingDocNo));
                command.Parameters.Add(new SqlParameter("@Srn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReturnDocNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOP"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteCustomerSetOffDetaile()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SetOffTempDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Grn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPendingDocNo));
                command.Parameters.Add(new SqlParameter("@Srn_Doc", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReturnDocNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOR"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 014. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 015. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadTempTransDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    blRecordFound = true;
                }
                else
                {
                    blRecordFound = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                DataReader = dbcon.GetReader("select Set_Off from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);
                    strOrgDocNo = "SSO" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 018. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetCustOrgDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader("select Set_Off_Inv from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);                    
                    strOrgDocNo = "CSO" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo;
                  
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 019. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SetOffApply()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                GetOrgDocumentNo();
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SetOffApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Org_Doc_no", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@Acc_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOP"));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 020. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void CustomerSetOffApply()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                GetCustOrgDocumentNo();
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SetOffApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Org_Doc_no", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@Acc_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "SOR"));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 021. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dsForReport = dbcon.getDataset("SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Paid_Amount, PD.Post_Date, PD.SetOff_SR_Doc, PD.Loca, L.Loca_Descrip, PD.Acc_Code, S.Supp_Name, 'Original' Status FROM tbPaidPaymentDetails PD INNER JOIN Location L ON PD.Loca = L.Loca INNER JOIN Supplier S ON PD.Acc_Code = S.Supp_Code WHERE PD.Org_Doc_no = '" + strOrgDocNo + "' AND PD.Loca = '" + LoginManager.LocaCode + "' AND PD.Iid = 'SOP'", "dsPaymentsetOffDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 022. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetCustomerDataSetForReport()
        {
            try
            {
                dsForReport = dbcon.getDataset("SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Paid_Amount, PD.Post_Date, PD.SetOff_SR_Doc, PD.Loca, L.Loca_Descrip, PD.Acc_Code, S.Cust_Name Supp_Name, 'Original' Status FROM tbPaidPaymentDetails PD INNER JOIN Location L ON PD.Loca = L.Loca INNER JOIN Customer S ON PD.Acc_Code = S.Cust_Code WHERE PD.Org_Doc_no = '" + strOrgDocNo + "' AND PD.Loca = '" + LoginManager.LocaCode + "' AND PD.Iid = 'SOR'", "dsPaymentsetOffDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPaymentSetOff 023. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
