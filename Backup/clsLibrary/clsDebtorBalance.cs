using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DbConnection;
using System.IO;

namespace clsLibrary
{
    public class clsDebtorBalance : clsSupplier
    {
        private int intTempDocNo;
        public int AintTempDocNo
        {
            get { return intTempDocNo; }
            set { intTempDocNo = value; }
        }

        private string _CustCode;
        public string CustCode
        {
            get { return _CustCode; }
            set { _CustCode = value; }
        }

        private string _CustName;
        public string CustName
        {
            get { return _CustName; }
            set { _CustName = value; }
        }

        private string strOrgDocNo;
        public string OrgDocNo
        {
            get { return strOrgDocNo; }
            set { strOrgDocNo = value; }
        }

        private string strCustCode;
        public string ACustCode
        {
            get { return strCustCode; }
            set { strCustCode = value; }
        }

        private decimal decBalanceAmnt;
        public decimal ABalanceAmnt
        {
            get { return decBalanceAmnt; }
            set { decBalanceAmnt = value; }
        }

        private string strCustName;
        public string ACustName
        {
            get { return strCustName; }
            set { strCustName = value; }
        }

        private string strAdd1;
        public string AAdd1
        {
            get { return strAdd1; }
            set { strAdd1 = value; }
        }

        private string strAdd2;
        public string AAdd2
        {
            get { return strAdd2; }
            set { strAdd2 = value; }
        }

        private string strAdd3;
        public string AAdd3
        {
            get { return strAdd3; }
            set { strAdd3 = value; }
        }

        private DataSet Ds;
        public DataSet ADs
        {
            get { return Ds; }
            set { Ds = value; }
        }

        private string strDataSetName;
        public string ADataSetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        private string SqlString;
        public string ASqlString
        {
            get { return SqlString; }
            set { SqlString = value; }
        }

        private SqlDataReader Dr;
        public SqlDataReader ADr
        {
            get { return Dr; }
            set { Dr = value; }
        }

        private Boolean blRecordFound;
        public Boolean AblRecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        private decimal decBalance;
        public decimal ABalance
        {
            get { return decBalance; }
            set { decBalance = value; }
        }

        private decimal blBalanceAmt;
        public decimal ABalanceAmt
        {
            get { return blBalanceAmt; }
            set { blBalanceAmt = value; }
        }

        private string dtDate;
        public string ADate
        {
            get { return dtDate; }
            set { dtDate = value; }
        }

        private int intErrCode;
        public int ErrCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        private string strReference;
        public string AReference
        {
            get { return strReference; }
            set { strReference = value; }
        }

        private string strAuthonticateUser;
        public string AuthonticateUser
        {
            get { return strAuthonticateUser; }
            set { strAuthonticateUser = value; }
        }

        private string strAuthonticatePassword;
        public string AuthonticatePassword
        {
            get { return strAuthonticatePassword; }
            set { strAuthonticatePassword = value; }
        }


        public void GetOrgDocumentNo()
        {
            try
            {
                Dr = dbcon.GetReader("select DebtorBlNo from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (Dr.Read())
                {
                    intTempDocNo = (int)Dr.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:00000000}", intTempDocNo);
                    strOrgDocNo = "DBL" + strOrgDocNo;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                Dr.Dispose();
            }
        }

        public void ReadDebtorsDetails()
        {
            try
            {
                Dr = dbcon.GetReader(SqlString);
                blRecordFound = false;
                if (Dr.Read())
                {
                    strCustCode = Dr["Cust_Code"].ToString();
                    strCustName = Dr["Cust_Name"].ToString();
                    strAdd1 = Dr["Address1"].ToString();
                    strAdd2 = Dr["Address2"].ToString();
                    strAdd3 = Dr["Address3"].ToString();



                    blRecordFound = true;
                }
                else
                {
                    strCustCode = string.Empty;
                    strCustName = string.Empty;
                    strAdd1 = string.Empty;
                    strAdd2 = string.Empty;
                    strAdd3 = string.Empty;


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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                Dr.Dispose();
            }
        }

        public void ReadDebtorsBalance()
        {
            try
            {
                Dr = dbcon.GetReader(SqlString);
                blRecordFound = false;
                if (Dr.Read())
                {
                    decBalanceAmnt = (decimal)Dr["Balance_Amount"];

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                Dr.Dispose();
            }
        }

        public void ReadAvalability()
        {
            try
            {
                Dr = dbcon.GetReader(SqlString);
                blRecordFound = false;
                if (Dr.Read())
                {
                    strCustCode = Dr["Acc_No"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public void GetDebtorDetails()
        {
            try
            {
                Ds = dbcon.getDataset(SqlString, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DebtorBalanceApply(string spName)
        {
            try
            {
                intErrCode = 0;
                //GetOrgDocumentNo();
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandText = spName;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@CustCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OrgDocNo));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ADate));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AReference));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ABalance));
                command.Parameters.Add(new SqlParameter("@PendingBalance", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ABalanceAmt));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@AccessUser", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAuthonticateUser));


                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                //Cust_Name = command.Parameters["@Cust_Name"].Value.ToString();
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void CheckedPasswordValid(string query)
        {
            try
            {
                Dr = dbcon.GetReader(query);
                blRecordFound = false;
                if (Dr.Read())
                {
                    strAuthonticateUser = Dr["Emp_Name"].ToString();
                    strAuthonticatePassword = Dr["Pass_Word"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    strAuthonticateUser = strAuthonticatePassword = string.Empty;

                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}