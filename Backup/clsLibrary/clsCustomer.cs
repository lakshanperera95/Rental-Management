using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DbConnection;

namespace clsLibrary
{
    public class clsCustomer
    {

        #region // Genaral Declarations
        private string strCode;
        private string strDescription;
        private string strAddress1;
        private string strAddress2;
        private string strAddress3;
        private string strCity;
        private string strCountry;
        private string strContPrsn;
        private string strTelephone;
        private string strFax;
        private string strEmail;
        private string strBankDraft;
        private string strPeriod;
        private string strCredit;
        private string strRemindDate;
        private string strNic;
        private string strSqlString;
        private int intErrCode;
        private string strMessage;
        private string strDatasetName;

        private Boolean blRecordFound;

        private SqlDataAdapter adapter = new SqlDataAdapter();

        private DataSet ds1 = new DataSet();
        private DataSet ds2 = new DataSet();
        #endregion

        #region  // Properties

        public string SqlString
        {
            get { return strSqlString; }
            set { strSqlString = value; }

        }

        public DataSet GetDataSet
        {
            get { return ds1; }
            set { ds1 = value; }
        }

        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        public string Address1
        {
            get { return strAddress1; }
            set { strAddress1 = value; }
        }

        public string Address2
        {
            get { return strAddress2; }
            set { strAddress2 = value; }
        }

        public string Address3
        {
            get { return strAddress3; }
            set { strAddress3 = value; }
        }

        public string City
        {
            get { return strCity; }
            set { strCity = value; }
        }

        public string Country
        {
            get { return strCountry; }
            set { strCountry = value; }
        }

        public string ContPrsn
        {
            get { return strContPrsn; }
            set { strContPrsn = value; }
        }

        public string Telephone
        {
            get { return strTelephone; }
            set { strTelephone = value; }
        }

        public string Fax
        {
            get { return strFax; }
            set { strFax = value; }
        }

        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        public string BankDraft
        {
            get { return strBankDraft; }
            set { strBankDraft = value; }
        }

        public string Period
        {
            get { return strPeriod; }
            set { strPeriod = value; }
        }

        public string Credit
        {
            get { return strCredit; }
            set { strCredit = value; }
        }

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string RemindDate
        {
            get { return strRemindDate; }
            set { strRemindDate = value; }
        }

        public string NIC
        {
            get { return strNic; }
            set { strNic = value; }
        }

        public string DatasetName
        {
            get { return strDatasetName; }
            set { strDatasetName = value; }

        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }
        #endregion

        #region //Retrive Customer CODE
        public void RetrieveFields_CustomerNo()
        {
            try
            {
                ds1 = dbcon.getDataset(strSqlString, strDatasetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomer 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        #endregion

        #region //Retrive Customer Details
        public void retrive_customer_details(string query)
        {
            try
            {
                blRecordFound = false;
                SqlDataReader reader = dbcon.GetReader(query);
                if (reader.Read())
                {
                    strCode = reader["Cust_Code"].ToString().Trim();
                    strDescription = reader["Cust_Name"].ToString().Trim();
                    strAddress1 = reader["Address1"].ToString().Trim();
                    strAddress2 = reader["Address2"].ToString().Trim();
                    strAddress3 = reader["Address3"].ToString().Trim();
                    strCity = reader["Address4"].ToString().Trim();
                    strCountry = reader["Country"].ToString().Trim();
                    strTelephone = reader["Tel"].ToString().Trim();
                    strFax = reader["Fax"].ToString().Trim();
                    strEmail = reader["Email"].ToString().Trim();
                    // strContPrsn = reader["Contact_Prsn"].ToString();
                    strCredit = reader["Credit_Limit"].ToString().Trim();
                    strRemindDate = reader["RemindDate"].ToString().Trim();
                    strNic = reader["NIC"].ToString().Trim();
                    //strPeriod = reader["Period"].ToString();
                    // strBankDraft = reader["BankDraft"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    strCode = string.Empty;
                    strDescription = string.Empty;
                    strAddress1 = string.Empty;
                    strAddress2 = string.Empty;
                    strAddress3 = string.Empty;
                    strCity = string.Empty;
                    strCountry = string.Empty;
                    strTelephone = string.Empty;
                    strFax = string.Empty;
                    strEmail = string.Empty;
                    strCredit = string.Empty;
                    strRemindDate = string.Empty;
                    strNic = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomer 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            }
        }
        #endregion

        #region // Method for INSERT & UPDATE
        public void UpdateData()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CustomerFileUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@Cust_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDescription));
                command.Parameters.Add(new SqlParameter("@Add1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@Add2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@Add3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@Add4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCity));
                command.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCountry));
                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTelephone));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strFax));
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strEmail));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Credit_Limit", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCredit));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "N/A"));
                command.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strNic));
                command.Parameters.Add(new SqlParameter("@Age", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 1));
                command.Parameters.Add(new SqlParameter("@RemindDate", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemindDate));


                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                dbcon.connection.Close();
                if (intErrCode == 0)
                {
                    MessageBox.Show("Record updated successfully", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // clear used fields & focus to txtDepartment
                    //Department = string.Empty;
                    //Category = string.Empty;
                    //CatDescript = string.Empty;

                }
                else
                {
                    MessageBox.Show("Error in Transaction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomer 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        #endregion

        #region //Method for DELETE
        public void DeleteData()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CustomerFileDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                strMessage = (string)(command.Parameters["@getMessage"].Value);
                dbcon.connection.Close();
                if (intErrCode != 0)
                {
                    MessageBox.Show("an internal error has occurred while deleting the current record", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCustomer 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            MessageBox.Show(strMessage.ToString(), "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

       
    }
}
