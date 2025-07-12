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
    public class clsCashierDetails
    {
        private int intErrCode;
        private string strCashierName;
        private string strDisplayName;
        private string strPassword;
        private string strCancel;
        private string strRefund;
        private string strCash_Refund;
        private string strCash_Out;
        private string strDiscount_All;
        private string strDept_Allow;
        private string strDayEndRep;
        private string strBillCopy;
        private string strLoca;

        private decimal decDiscount;

        private string strSqlStatement;
        private string strDataSetName;

        private SqlDataReader DataReader;
        private DataSet dsResultSet;
        private Boolean blRecordFound;

        public string CashierName
        {
            get { return strCashierName; }
            set { strCashierName = value; }
        }

        public string DisplayName
        {
            get { return strDisplayName; }
            set { strDisplayName = value; }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public string Cancel
        {
            get { return strCancel; }
            set { strCancel = value; }
        }

        public string Refund
        {
            get { return strRefund; }
            set { strRefund = value; }
        }

        public string Cash_Refund
        {
            get { return strCash_Refund; }
            set { strCash_Refund = value; }
        }

        public string Cash_Out
        {
            get { return strCash_Out; }
            set { strCash_Out = value; }
        }

        public string Discount_All
        {
            get { return strDiscount_All; }
            set { strDiscount_All = value; }
        }

        public decimal Discount
        {
            get { return decDiscount; }
            set { decDiscount = value; }
        }

        public string Dept_Allow
        {
            get { return strDept_Allow; }
            set { strDept_Allow = value; }
        }

        public string DayEndRep
        {
            get { return strDayEndRep; }
            set { strDayEndRep = value; }
        }

        public string BillCopy
        {
            get { return strBillCopy; }
            set { strBillCopy = value; }
        }

        public string Loca
        {
            get { return strLoca; }
            set { strLoca = value; }
        }

        public string dsName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public DataSet ResultSet
        {
            get { return dsResultSet; }
            set { dsResultSet = value; }
        }

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        private bool DisCashier;

        public bool ADisCashier
        {
            get { return DisCashier; }
            set { DisCashier = value; }
        }

        private string secLevel;

        public string AsecLevel
        {
            get { return secLevel; }
            set { secLevel = value; }
        }

        private decimal _RefundLimit;
        public decimal RefundLimit
        {
            get { return _RefundLimit; }
            set { _RefundLimit = value; }
        }


        private string _CrNoteIssue;
        public string CrNoteIssue
        {
            get { return _CrNoteIssue; }
            set { _CrNoteIssue = value; }
        }

        private string _GiftVoucherIssue;
        public string GiftVoucherIssue
        {
            get { return _GiftVoucherIssue; }
            set { _GiftVoucherIssue = value; }
        }

        private string _SalesAmtDiply;
        public string SalesAmtDiply
        {
            get { return _SalesAmtDiply; }
            set { _SalesAmtDiply = value; }
        }


        public void RetriveData()
        {
            try
            {
                dsResultSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCashierDetails 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReadCashierDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strDisplayName = DataReader["Emp_Name"].ToString();
                    strPassword = DataReader["Pass_Word"].ToString();
                    strCancel = DataReader["Cancel"].ToString();
                    strRefund = DataReader["Refund"].ToString();
                    strCash_Refund = DataReader["Cash_Refund"].ToString();
                    strCash_Out = DataReader["Cash_Out"].ToString();
                    strDiscount_All = DataReader["Discount_All"].ToString();
                    strDept_Allow = DataReader["Dept_Allow"].ToString();
                    strDayEndRep = DataReader["DayEndRep"].ToString();
                    strBillCopy = DataReader["BillCopy"].ToString();
                    decDiscount = (decimal)DataReader["Discount"];
                    DisCashier = (bool)DataReader["Disables"];
                    secLevel = DataReader["Member"].ToString();
                    _CrNoteIssue = DataReader["CrNoteIssue"].ToString();
                    _GiftVoucherIssue = DataReader["GiftVoucherIssue"].ToString();
                    _SalesAmtDiply = DataReader["SaleValue"].ToString();
                    _RefundLimit = (decimal)DataReader["RefundLimit"];

                    blRecordFound = true;
                }
                else
                {
                    strDisplayName = string.Empty;
                    strPassword = string.Empty;
                    strCancel = string.Empty;
                    strRefund = string.Empty;
                    strCash_Refund = string.Empty;
                    strCash_Out = string.Empty;
                    strDiscount_All = string.Empty;
                    strDept_Allow = string.Empty;
                    strDayEndRep = string.Empty;
                    strBillCopy = string.Empty;
                    decDiscount = 0;
                    _RefundLimit = 0;

                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCashierDetails 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void UpdateCashierDetails()
        {
            try
            {
                intErrCode = 0;
                dbcon.CloseReader();
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CashierFileUpdate";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Emp_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisplayName));
                command.Parameters.Add(new SqlParameter("@Pass_Word", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPassword));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCashierName));
                command.Parameters.Add(new SqlParameter("@LastModUser", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim()));
                command.Parameters.Add(new SqlParameter("@Cancel", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCancel));
                command.Parameters.Add(new SqlParameter("@Refund", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefund));
                command.Parameters.Add(new SqlParameter("@Cash_Refund", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCash_Refund ));
                command.Parameters.Add(new SqlParameter("@Cash_Out", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCash_Out ));
                command.Parameters.Add(new SqlParameter("@Discount_All", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDiscount_All ));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal,0 , ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount ));
                command.Parameters.Add(new SqlParameter("@Dept_Allow", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDept_Allow));
                command.Parameters.Add(new SqlParameter("@DayEndRep", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDayEndRep));
                command.Parameters.Add(new SqlParameter("@BillCopy", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBillCopy));
                command.Parameters.Add(new SqlParameter("@DisCashier", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DisCashier));
                command.Parameters.Add(new SqlParameter("@SecLevel", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, secLevel));
                command.Parameters.Add(new SqlParameter("@RefundLimit", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _RefundLimit));
                command.Parameters.Add(new SqlParameter("@CrNoteIssue", SqlDbType.NVarChar,1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _CrNoteIssue));
                command.Parameters.Add(new SqlParameter("@GifVoucher", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _GiftVoucherIssue));
                command.Parameters.Add(new SqlParameter("@SalesValue", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _SalesAmtDiply));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCashierDetails 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void DeleteCashierDetails()
        {
            try
            {
                intErrCode = 0;
                dbcon.CloseReader();
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CashierFileDelete";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Emp_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisplayName));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCashierName));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCashierDetails 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void PublicReader(string sqlstatement)
        {
            DataReader = dbcon.GetReader(sqlstatement);
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
    }
}
