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
    public class clsSalesman
    {
        #region General Declaration
        private int intErrCode;

        private string strSale_Code;
        private string strSale_Name;                                          
        private string strArea_Code;
        private string strAddress1;
        private string strAddress2;
        private string strAddress3;
        private string strAddress4;
        private string strTel;
        private string strFax;
        private string strEmail;
        private string strNIC;
        private string strVehicle_No;
        private string strSqlStatement;
        private string strDataSetName;

        private DataSet dsSalesmanDataSet;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        # endregion

        #region Properties
        public int ErrorCode
        {
            get            {                return intErrCode;            }
            set            {                intErrCode = value;            }
        }

        public string Sale_Code
        {
            get { return strSale_Code; }
            set { strSale_Code = value; }
        }

        public string Sale_Name
        {
            get { return strSale_Name; }
            set { strSale_Name = value; }
        }

        public string Area_Code
        {
            get { return strArea_Code; }
            set { strArea_Code = value; }
        }

        public string Address1
        {
            get { return strAddress1;}
            set { strAddress1=value;}
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

        public string Address4
        {
            get { return strAddress4; }
            set { strAddress4 = value; }
        }

        public string Tel
        {
            get { return strTel; }
            set { strTel = value; }
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

        public string NIC
        {
            get { return strNIC; }
            set { strNIC = value; }
        }

        public string Vehicle_No
        {
            get { return strVehicle_No; }
            set { strVehicle_No = value; }
        }

        public string DataSetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public DataSet GetSalesmanDataset
        {
            get { return dsSalesmanDataSet; }
            set { dsSalesmanDataSet = value; }
        }

        # endregion

        private bool _disable;

        public bool Disable
        {
            get { return _disable; }
            set { _disable = value; }
        }


        public void ReadSalesmanDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strSale_Code = DataReader["Sale_Code"].ToString().Trim();
                    strSale_Name = DataReader["Sale_Name"].ToString().Trim();
                    strAddress1 = DataReader["Address1"].ToString().Trim();
                    strAddress2 = DataReader["Address2"].ToString().Trim();
                    strAddress3 = DataReader["Address3"].ToString().Trim();
                    strAddress4 = DataReader["Address4"].ToString().Trim();
                    strTel = DataReader["Tel"].ToString().Trim();
                    strFax = DataReader["Fax"].ToString().Trim();
                    strEmail = DataReader["Email"].ToString().Trim();
                    strNIC = DataReader["NIC"].ToString().Trim();
                    strVehicle_No = DataReader["Vehicle_No"].ToString().Trim();
                    Disable = (bool)DataReader["Disable"];

                    blRecordFound = true;
                }
                else
                {
                    strSale_Code = string.Empty;
                    strSale_Name = string.Empty;
                    strAddress1 = string.Empty;
                    strAddress2 = string.Empty;
                    strAddress3 = string.Empty;
                    strAddress4 = string.Empty;
                    strTel = string.Empty;
                    strFax = string.Empty;
                    strEmail = string.Empty;
                    strNIC = string.Empty;
                    strVehicle_No = string.Empty;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsSalesman 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetSalesmanDetails()
        {
            try
            {
                dsSalesmanDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsSalesman 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SalesmanUpdate()
        {
            try
            {
                intErrCode = 0;

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandText = "sp_SalesmanFileUpdate";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Sale_Code", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSale_Code));
                command.Parameters.Add(new SqlParameter("@Sale_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSale_Name));
                command.Parameters.Add(new SqlParameter("@Add1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@Add2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@Add3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@Add4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress4));
                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTel));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strFax));
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strEmail));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strNIC ));
                command.Parameters.Add(new SqlParameter("@Vehicle_No", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strVehicle_No));
                command.Parameters.Add(new SqlParameter("@Disable", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Disable));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsSalesman 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SalesmanDelete()
        {

            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SalesmanFileDelete";

                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Sale_Code", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSale_Code));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsSalesman 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


    }
}
