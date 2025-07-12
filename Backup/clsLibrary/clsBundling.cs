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
    public class clsBundling : clsValidation
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;
        private int intPackSize;

        private string strProductCode;
        private string strProductName;
        private string strSqlStatement;
        private string strTempDocumentNo;
        private string strDataSetName;
        private string strUnit;

        private decimal fltQty;
        private decimal fltCurrentQty;

        private decimal decPurchasePrice;

        private DataSet dsProductDataSet;
        private DataSet dsTempSelectedItem;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion
        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public int PackSize
        {
            get { return intPackSize; }
            set { intPackSize = value; }
        }

        public string ProductCode
        {
            get { return strProductCode; }
            set { strProductCode = value; }
        }

        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }
        }

        public string Unit
        {
            get { return strUnit; }
            set { strUnit = value; }
        }

        public decimal Qty
        {
            get { return fltQty; }
            set { fltQty = value; }
        }

        public decimal CurrentQty
        {
            get { return fltCurrentQty; }
            set { fltCurrentQty = value; }
        }

        public decimal PurchasePrice
        {
            get { return decPurchasePrice; }
            set { decPurchasePrice = value; }
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

        public DataSet TempSelectedItem
        {
            get { return dsTempSelectedItem; }
            set { dsTempSelectedItem = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public DataSet GetProductDataset
        {
            get { return dsProductDataSet; }
            set { dsProductDataSet = value; }
        }

        #region Properties

        #endregion

        public void GetItemDetails()
        {
            try
            {
                dsProductDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadProductDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strProductCode = DataReader["Prod_Code"].ToString().Trim();
                    strProductName = DataReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(4);
                    intPackSize = (int)DataReader.GetSqlInt16(5);
                    decPurchasePrice = (decimal)DataReader["Purchase_price"];
                    strUnit = DataReader["Unit"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    strUnit = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdateTempPacketing()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempPacketProduct";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "Prod_Code", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Prod_Name", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "Purchase_price", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Packet_Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 3, 0, "Packet_Qty", DataRowVersion.Default, fltQty));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdateTempBundling(bool InsertToShowroom)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBundleProduct";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Packet_Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Default, fltQty));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);

              /*  if (InsertToShowroom)
                {
                    if (LoginManager.SR1_Server != "" && LoginManager.SR1_Server != null)
                    {
                        dbcon.Open_SR1_Connection(LoginManager.SR1_Server, LoginManager.SR1_DatabaseName, LoginManager.SR1_DBUser, LoginManager.SR1_DBPass);
                        command.Connection = dbcon.SR1_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR1_connection.Close();
                    }

                    if (LoginManager.SR2_Server != "" && LoginManager.SR2_Server != null)
                    {
                        dbcon.Open_SR2_Connection(LoginManager.SR2_Server, LoginManager.SR2_DatabaseName, LoginManager.SR2_DBUser, LoginManager.SR2_DBPass);
                        command.Connection = dbcon.SR2_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR2_connection.Close();
                    }

                    if (LoginManager.SR3_Server != "" && LoginManager.SR3_Server != null)
                    {
                        dbcon.Open_SR3_Connection(LoginManager.SR3_Server, LoginManager.SR3_DatabaseName, LoginManager.SR3_DBUser, LoginManager.SR3_DBPass);
                        command.Connection = dbcon.SR3_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR3_connection.Close();
                    }

                }*/
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsTempSelectedItem = dbcon.getDataset("select Prod_Code, Prod_Name, Purchase_price ,Packet_Qty FROM tbTempPacketProduct", "dsTempPacketProduct");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetBundleTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsTempSelectedItem = dbcon.getDataset("select Prod_Code, Prod_Name, Purchase_price ,Packet_Qty FROM tbTempBundleProductDetails", "dsTempPacketProduct");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteTempPacketing()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempPacketDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteTempBundling(bool InsertToShowroom)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBundleDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);

       /*         if (InsertToShowroom)
                {
                    if (LoginManager.SR1_Server != "" && LoginManager.SR1_Server != null)
                    {
                        dbcon.Open_SR1_Connection(LoginManager.SR1_Server, LoginManager.SR1_DatabaseName, LoginManager.SR1_DBUser, LoginManager.SR1_DBPass);
                        command.Connection = dbcon.SR1_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR1_connection.Close();
                    }

                    if (LoginManager.SR2_Server != "" && LoginManager.SR2_Server != null)
                    {
                        dbcon.Open_SR2_Connection(LoginManager.SR2_Server, LoginManager.SR2_DatabaseName, LoginManager.SR2_DBUser, LoginManager.SR2_DBPass);
                        command.Connection = dbcon.SR2_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR2_connection.Close();
                    }

                    if (LoginManager.SR3_Server != "" && LoginManager.SR3_Server != null)
                    {
                        dbcon.Open_SR3_Connection(LoginManager.SR3_Server, LoginManager.SR3_DatabaseName, LoginManager.SR3_DBUser, LoginManager.SR3_DBPass);
                        command.Connection = dbcon.SR3_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR3_connection.Close();
                    }

                }*/
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteTempPacketingProduct(string Sp, bool InsertToShowroom)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sp;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);

           /*     if (InsertToShowroom)
                {
                    if (LoginManager.SR1_Server != "" && LoginManager.SR1_Server != null)
                    {
                        dbcon.Open_SR1_Connection(LoginManager.SR1_Server, LoginManager.SR1_DatabaseName, LoginManager.SR1_DBUser, LoginManager.SR1_DBPass);
                        command.Connection = dbcon.SR1_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR1_connection.Close();
                    }

                    if (LoginManager.SR2_Server != "" && LoginManager.SR2_Server != null)
                    {
                        dbcon.Open_SR2_Connection(LoginManager.SR2_Server, LoginManager.SR2_DatabaseName, LoginManager.SR2_DBUser, LoginManager.SR2_DBPass);
                        command.Connection = dbcon.SR2_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR2_connection.Close();
                    }

                    if (LoginManager.SR3_Server != "" && LoginManager.SR3_Server != null)
                    {
                        dbcon.Open_SR3_Connection(LoginManager.SR3_Server, LoginManager.SR3_DatabaseName, LoginManager.SR3_DBUser, LoginManager.SR3_DBPass);
                        command.Connection = dbcon.SR3_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR3_connection.Close();
                    }

                }*/
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void RetreivePacketingProduct(string Sp, bool InsertToShowroom)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sp;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);

            /*    if (InsertToShowroom)
                {
                    if (LoginManager.SR1_Server != "" && LoginManager.SR1_Server != null)
                    {
                        dbcon.Open_SR1_Connection(LoginManager.SR1_Server, LoginManager.SR1_DatabaseName, LoginManager.SR1_DBUser, LoginManager.SR1_DBPass);
                        command.Connection = dbcon.SR1_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR1_connection.Close();
                    }

                    if (LoginManager.SR2_Server != "" && LoginManager.SR2_Server != null)
                    {
                        dbcon.Open_SR2_Connection(LoginManager.SR2_Server, LoginManager.SR2_DatabaseName, LoginManager.SR2_DBUser, LoginManager.SR2_DBPass);
                        command.Connection = dbcon.SR2_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR2_connection.Close();
                    }

                    if (LoginManager.SR3_Server != "" && LoginManager.SR3_Server != null)
                    {
                        dbcon.Open_SR3_Connection(LoginManager.SR3_Server, LoginManager.SR3_DatabaseName, LoginManager.SR3_DBUser, LoginManager.SR3_DBPass);
                        command.Connection = dbcon.SR3_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR3_connection.Close();
                    }

                }*/
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void PacketingProductApply()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_PacketProductDetailsApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void BundlingProductApply(bool InsertToShowroom)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_BundleProductDetailsApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);

             /*   if (InsertToShowroom)
                {
                    if (LoginManager.SR1_Server != "" && LoginManager.SR1_Server != null)
                    {
                        dbcon.Open_SR1_Connection(LoginManager.SR1_Server, LoginManager.SR1_DatabaseName, LoginManager.SR1_DBUser, LoginManager.SR1_DBPass);
                        command.Connection = dbcon.SR1_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR1_connection.Close();
                    }

                    if (LoginManager.SR2_Server != "" && LoginManager.SR2_Server != null)
                    {
                        dbcon.Open_SR2_Connection(LoginManager.SR2_Server, LoginManager.SR2_DatabaseName, LoginManager.SR2_DBUser, LoginManager.SR2_DBPass);
                        command.Connection = dbcon.SR2_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR2_connection.Close();
                    }

                    if (LoginManager.SR3_Server != "" && LoginManager.SR3_Server != null)
                    {
                        dbcon.Open_SR3_Connection(LoginManager.SR3_Server, LoginManager.SR3_DatabaseName, LoginManager.SR3_DBUser, LoginManager.SR3_DBPass);
                        command.Connection = dbcon.SR3_connection;
                        command.ExecuteNonQuery();
                        dbcon.SR3_connection.Close();
                    }

                }*/
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetPurchasePrice()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select isnull(sum(purchase_price*Packet_Qty),0) from tbTempBundleProductDetails";
                dbcon.OpenConnection();
                decPurchasePrice = decimal.Parse(command.ExecuteScalar().ToString());

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPaketingItemSelect 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseConnection();
            }
        }
    }
}
