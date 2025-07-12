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
    public class clsSubCategory
    {

        private string strDepartment;
        private string strDeptName;
        private string strCategory;
        private string strCatDescript;
        private string strSqlString;
        private string strDatasetName;

        private int intErrCode;
        private string strMessage;
        private SqlDataReader DataReader;
        private Boolean blRecordFound;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        private DataSet ds1 = new DataSet ();
        private DataSet ds2 = new DataSet ();

        public string Department
        {
            get
            {
                return strDepartment;
            }
            set
            {
                strDepartment = value;
            }
        }

        public string DeptName
        {
            get{ return strDeptName;}
            set{ strDeptName = value;}
        }

        public string Category
        {
            get {return strCategory;}
            set {strCategory = value;}
        }

        public string CatDescript
        {
            get
            {
                return strCatDescript;
            }
            set
            {
                strCatDescript = value;
            }
        }

        public Boolean RecordFound
        {
            get
            {
                return blRecordFound;
            }
            set
            {
                blRecordFound = value;
            }
        }

        public string SqlString {
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

        public string DatasetName
        {
            get
            {
                return strDatasetName;
            }
            set
            {
                strDatasetName = value;
            }
        }


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
                command.CommandText = "sp_CategoryFileUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Dept_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDepartment));
                command.Parameters.Add(new SqlParameter("@Cat_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCategory));
                command.Parameters.Add(new SqlParameter("@Cat_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCatDescript));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager .UserName));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                dbcon.connection.Close();
                if (intErrCode == 0)
                {
                    MessageBox.Show("Record updated successfully", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // clear used fields & focus to txtDepartment
                    Department = string.Empty;
                    Category = string.Empty;
                    CatDescript = string.Empty;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCategory 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        public void DeleteData(string DeptCode,string Category)
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CategoryFileDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Dept_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DeptCode));
                command.Parameters.Add(new SqlParameter("@Cat_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Category));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager .UserName));
                command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                strMessage = (string)(command.Parameters["@getMessage"].Value);
                dbcon.connection.Close();
                if (intErrCode != 0)
                {
                    MessageBox.Show("an internal error has occurred while deleting the current record", "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCategory 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            MessageBox.Show(strMessage.ToString(), "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

        #region //Retrive Department Details 
        public void RetrieveFields_Department()
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCategory 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #region //Retrive Category Details
        public void RetrieveFields_Category()
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCategory 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadDepartmentDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlString);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strDepartment = DataReader["Dept_Code"].ToString().Trim();
                    strDeptName = DataReader["Dept_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strDepartment = string.Empty;
                    strDeptName = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCategory 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadCategoryDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlString);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strCategory = DataReader["Cat_Code"].ToString();
                    strCatDescript = DataReader["Cat_Name"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    strCategory = string.Empty;
                    strCatDescript = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsCategory 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadCategoryRelatedDetails()
        {
            try
            {
                //Find Products For This Department
                DataReader = dbcon.GetReader("SELECT Prod_Code FROM Product WHERE Category_Id = '" + strCategory + "'");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsCategory 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
    }
}
