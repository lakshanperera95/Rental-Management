using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DbConnection;


namespace clsLibrary
{
    public class clsSupplier2
    {

        #region // Genaral Declarations
        private string strCode;
        private string strDescription;
        private string strAddress1;
        private string strAddress2;
        private string strAddress3;
        private string strCity;
        private string strCountry;
        private string strTelephone;
        private string strFax;
        private string strEmail;

        private string strSqlString;
        private string strDatasetName;
        private int intErrCode;
        private string strMessage;
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
        public DataSet GetDataSet1
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

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string DatasetName
        {
            get { return strDatasetName; }
            set { strDatasetName = value; }
        }

        #endregion

        #region //Retrive Customer CODE
        public void RetrieveFields_CustomerNo()
        {
            ds1 = dbcon.getDataset(strSqlString, strDatasetName);
        }
        #endregion

        #region //Retrive Customer Details
        public void RetrieveFields_CustomerDetails(string query)
        {
            try
            {
                blRecordFound = false;
                SqlDataReader reader = dbcon.GetReader(query);
                if (reader.Read())
                {
                    strCode = reader["Supp_Code"].ToString().Trim();
                    strDescription = reader["Supp_Name"].ToString().Trim();
                    strAddress1 = reader["Address1"].ToString().Trim();
                    strAddress2 = reader["Address2"].ToString().Trim();
                    strAddress3 = reader["Address3"].ToString().Trim();
                    strCity = reader["Address4"].ToString().Trim();
                    strTelephone = reader["Tel"].ToString().Trim();
                    strFax = reader["Fax"].ToString().Trim();
                    strEmail = reader["Email"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strDescription = string.Empty;
                    strAddress1 = string.Empty;
                    strAddress2 = string.Empty;
                    strAddress3 = string.Empty;
                    strCity = string.Empty;
                    strTelephone = string.Empty;
                    strFax = string.Empty;
                    strEmail = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Data Type Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dbcon.CloseReader();
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
                command.CommandText = "sp_SupplierFileUpdate";
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@Supp_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDescription));
                command.Parameters.Add(new SqlParameter("@Add1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@Add2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@Add3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@Add4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCity));

                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTelephone));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strFax));
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strEmail));
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                command.CommandText = "sp_SupplierFileDelete";

                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
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
            catch (
                SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
