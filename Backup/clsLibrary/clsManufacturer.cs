using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DbConnection;


namespace clsLibrary
{
    public class clsManufacturer
    {

        private string strCode;
        private string strDescript;
        private string strAddress1;
        private string strAddress2;
        private string strAddress3;
        private string strCity;
        private string strCountry;
        private string strTel;
        private string strFax;
        private string strEmail;

        private int intErrCode;
        private string strMessage;
        private string strSqlString;


        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds1 = new DataSet();


        public string Code{
            get 
            {
                return strCode;
            }
            set 
            {
                strCode = value;
            }
        }

        public string Descript
        {
            get
            {
                return strDescript ;
            }
            set
            {
                strDescript = value;
            }
        }

        public string Address1
        {
            get
            {
                return strAddress1 ;
            }
            set
            {
                strAddress1  = value;
            }
        }

        public string Address2
        {
            get
            {
                return strAddress2;
            }
            set
            {
                strAddress2 = value;
            }
        }

        public string Address3
        {
            get
            {
                return strAddress3;
            }
            set
            {
                strAddress3 = value;
            }
        }

        public string City
        {
            get
            {
                return strCity ;
            }
            set
            {
                strCity  = value;
            }
        }

        public string Country
        {
            get
            {
                return strCountry ;
            }
            set
            {
                strCountry = value;
            }
        }

        public string Tel
        {
            get
            {
                return strTel ;
            }
            set
            {
                strTel  = value;
            }
        }

        public string Fax
        {
            get
            {
                return strFax;
            }
            set
            {
                strFax = value;
            }
        }

        public string Email
        {
            get
            {
                return strEmail ;
            }
            set
            {
                strEmail  = value;
            }
        }

        public string SqlString
        {
            get
            {
                return strSqlString;
            }
            set
            {
                strSqlString = value;
            }

        }

        public int ErrorCode
        {
            get
            {
                return intErrCode;
            }
            set
            {
                intErrCode = value;
            }
        }

        public DataSet GetDataset1
        {
            get
            {
                return ds1;
            }
            set
            {
                ds1 = value;
            }
        }

        #region //Retrive Manufacturer CODE
        public void RetrieveFields_ManCode()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsManCode");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsManufacturer 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #region //Retrive Customer Details
        public void RetrieveFields_CustomerDetails()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsManDetails");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsManufacturer 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.CommandText = "sp_ManufacturerUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Manf_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode ));
                command.Parameters.Add(new SqlParameter("@Manf_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDescript));
                command.Parameters.Add(new SqlParameter("@Address1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@Address2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@Address3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCity));
                command.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCountry));
                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTel));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strFax));
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strEmail ));
                command.Parameters.Add(new SqlParameter("@States", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 1));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));


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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsManufacturer 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.CommandText = "sp_ManufacturerDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Manf_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                strMessage = (string)(command.Parameters["@getMessage"].Value);
                dbcon.connection.Close();
                if (intErrCode != 0)
                {
                    MessageBox.Show("an internal error has occurred while deleting the current record", "Manufacturer Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsManufacturer 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            MessageBox.Show(strMessage.ToString(), "Manufacturer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion


    }
}
