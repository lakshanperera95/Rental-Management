using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;


namespace DbConnection
{
    public class dbcon
    {
        //************************************************************************************
        //**   SuperMarket Inventory System                                                 **
        //**   Installed On 03/02/2009                                                      **
        //**   Last Modified On 05/06/2009  GIHAN   Database Version DBSM 10.10             **
        //**   Last Modified On 17/08/2009  THARINDU   Database Version DBSM 10.10.2        **
        //**   Last Modification in Brief                                                   **
        //**   Change Connection String                                                     **
        //************************************************************************************


        private static string UserName=string.Empty ;
        private static string PassWord = string.Empty;

        public static string ConnectionString;
        public static string SIP_ConnectionString;
        private static string strPosConnString;
        public static bool ConnFound = false;

        public static Boolean blPosStatus; //Available True, Not Available False

        public static SqlConnection connection = new SqlConnection();
        public static SqlConnection connectionOther = new SqlConnection();
        public static SqlConnection SIP_connection = new SqlConnection();
        public static SqlConnection PosConnection = new SqlConnection();
        public static SqlCommand command;
        public static SqlDataReader reader;

        public static void SetConnectionString(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            ConnectionString = "data source=" + LoginSys.strInvServerName + ";initial catalog=" + LoginSys.strInvDataBase + ";persist security info=False;user id=" + LoginSys.strInvUserName + " ; password=" + LoginSys.strInvPassword + "  ;workstation id=" + LoginSys.strInvServerName + ";packet size=4096;Min pool size=2;Connection Timeout=60";
            connection.ConnectionString = ConnectionString;
            connectionOther.ConnectionString = ConnectionString;
        }

        public static void Set_StaticIp_ConnectionString(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            SIP_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2;Connection Timeout=60";
            SIP_connection.ConnectionString = SIP_ConnectionString;
        }

        public static string getstr()
        {
            return ConnectionString;
        }

        #region open main connection
        public static void OpenConnection()
        {
            try
            {

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    SqlConnection.ClearPool(connection);
                }
                ConnectionString = "data source=" + LoginSys.strInvServerName + ";initial catalog=" + LoginSys.strInvDataBase + ";persist security info=False;user id=" + LoginSys.strInvUserName + " ; password=" + LoginSys.strInvPassword + "  ;workstation id=" + LoginSys.strInvServerName + ";packet size=4096;Min pool size=2";
                connection.ConnectionString = ConnectionString;
                //connection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                connection.Open();
             

            }
            catch (SqlException ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }

                MessageBox.Show(ex.Message.ToString(), "Error in Opening Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                
                MessageBox.Show(ex.Message.ToString(), "Error in Opening Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region close main connection
        public static void CloseConnection()
        {
            try
            {
               if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    SqlConnection.ClearPool(connection);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error in Closing Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error in Closing Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        # region Get dataset

        public static DataSet getDataset(string query, string strName)
        {
                DataSet tempds = new DataSet();
                SqlDataAdapter tempadapter;
                connection.Close();
                SqlConnection.ClearPool(connection);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new SqlCommand(query, connection);
                command.CommandTimeout = 1000000;
                tempadapter = new SqlDataAdapter(command);
                tempadapter.Fill(tempds, strName);
                CloseConnection();
                CloseReader();
                tempds.Dispose();
                return tempds;
        }

        public static DataSet getDatasetOt(string query, string strName)
        {
            DataSet tempds = new DataSet();
            SqlDataAdapter tempadapter;
            connectionOther.Close();
            SqlConnection.ClearPool(connectionOther);

            if (connectionOther.State != ConnectionState.Open)
            {
                connectionOther.Open();
            }

            command = new SqlCommand(query, connectionOther);
            command.CommandTimeout = 1000000;
            tempadapter = new SqlDataAdapter(command);
            tempadapter.Fill(tempds, strName);

            if (connectionOther.State == ConnectionState.Open)
            {
                connectionOther.Close();
                SqlConnection.ClearPool(connectionOther);
            }

            tempds.Dispose();
            return tempds;
        }

        # endregion



        public static SqlDataReader GetReader(string query)
        {
                command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                OpenConnection();
                reader = command.ExecuteReader();
                return reader;
        }

        public static SqlDataReader GetReader(string spName, SqlParameter[] paramCollection)
        {
            //SqlDataReader reader = null;
            OpenConnection();
            try
            {
                SqlCommand command = new SqlCommand(spName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (paramCollection != null)
                    CreateParameter(paramCollection, command);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            //return null;
        }

        public static SqlDataReader GetReader(string sqlStatement, List<SqlParameter> lstPrm)
        {
            //SqlDataReader reader = null;
            OpenConnection();
            try
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                if (lstPrm != null)
                    command.Parameters.AddRange(lstPrm.ToArray());
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstPrm.Clear();


            }
        }

        private static void CreateParameter(SqlParameter[] paramCollection, SqlCommand command)
        {
            foreach (SqlParameter param in paramCollection)
            {
                command.Parameters.Add(param);
            }
        }
        public static void CloseReader()
        {
            if(reader!=null)
            reader.Close();
            CloseConnection();
        }

        public static byte checkCon(){
            try
            {
                dbcon.connection.Open();
                ConnFound = true;
                dbcon.connection.Close();
                SqlConnection.ClearPool(connection);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return 1;
            }
            return 0;
        }

        public static byte CheckPosConn(string strPosUnit, string strTerminalPassword, string PosDatabase)
        {
            blPosStatus = false;
            strPosConnString = "data source=" + strPosUnit + ";initial catalog=" + PosDatabase + ";persist security info=False;user id=sa ; password=" + strTerminalPassword + "  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            try
            {
                PosConnection.ConnectionString = strPosConnString;
               // dbcon.PosConnection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                dbcon.PosConnection.Open();
                blPosStatus = true;
                dbcon.PosConnection.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return 1;
            }
            return 0;
        }

        public static byte ReloadPos(string strPosUnit, string strTerminalPassword, string PosDatabase)
        {
            blPosStatus = false;
            strPosConnString = "data source=" + strPosUnit + ";initial catalog=" + PosDatabase + ";persist security info=False;user id=sa ; password=" + strTerminalPassword + "  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            try
            {
                PosConnection.ConnectionString = strPosConnString;
                // dbcon.PosConnection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                dbcon.PosConnection.Open();
                //Reload Pos
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.PosConnection;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_PosReloadUpdate";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ReloadMsg", SqlDbType.NVarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, " "));
                command.ExecuteNonQuery();
                blPosStatus = true;
                dbcon.PosConnection.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return 1;
            }
            finally
            {
                dbcon.PosConnection.Close();
            }
            return 0;
        }

        public static byte UpdatePosSettings(string strPosUnit, string strSQLUpdateSettind, string strTerminalPassword)
        {
            blPosStatus = false;
            strPosConnString = "data source=" + strPosUnit + ";initial catalog=Pos;persist security info=False;user id=" + UserName + " ; password=" + strTerminalPassword + "  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            try
            {
                PosConnection.ConnectionString = strPosConnString;
               // dbcon.PosConnection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                dbcon.PosConnection.Open();
                //Reload Pos
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.PosConnection;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandType = CommandType.Text ;
                command.CommandText = strSQLUpdateSettind;

                command.ExecuteNonQuery();
                blPosStatus = true;
                dbcon.PosConnection.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return 1;
            }
            return 0;
        }

        public static byte CheckPosConnForSalesDownload(string strPosUnit)
        {
            blPosStatus = false;
            strPosConnString = "data source=" + strPosUnit + ";initial catalog=NewINV;persist security info=False;user id=sa ; password=itonimta  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            //strPosConnString = "data source=" + strPosUnit + ";initial catalog=Pos;persist security info=False;user id=sa ; password=sa  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            try
            {
                PosConnection.ConnectionString = strPosConnString;
               // dbcon.PosConnection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                dbcon.PosConnection.Open();
                blPosStatus = true;
                dbcon.PosConnection.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return 1;
            }
            return 0;
        }

        public static byte SalesUpload(string strPosUnit)
        {
            blPosStatus = false;
            strPosConnString = "data source=" + strPosUnit + ";initial catalog=NewINV;persist security info=False;user id=sa ; password=itonimta  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            //strPosConnString = "data source=" + strPosUnit + ";initial catalog=Pos;persist security info=False;user id=sa ; password=sa  ;workstation id=" + strPosUnit + ";packet size=4096;Min pool size=2";
            try
            {
                PosConnection.ConnectionString = strPosConnString;
               // dbcon.PosConnection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                dbcon.PosConnection.Open();
                //Reload Pos
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.PosConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = "sp_SalesUploadUpdate";
                command.Parameters.Clear();
                command.ExecuteNonQuery();
                blPosStatus = true;
                dbcon.PosConnection.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return 1;
            }
            return 0;
        }


        public static DataSet GetDataSet(string sqlStatement, List<SqlParameter> lstPrm)
        {
            SqlDataAdapter adp = null;
            DataSet ds = new DataSet();
            OpenConnection();
            try
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                if (lstPrm != null)
                    command.Parameters.AddRange(lstPrm.ToArray());

                adp = new SqlDataAdapter(command);
                adp.Fill(ds, "Table");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }

        public static DataSet GetDataSet(string sqlStatement, List<SqlParameter> lstPrm, string tableName)
        {

            SqlDataAdapter adp = null;
            DataSet ds = new DataSet();
            OpenConnection();
            try
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                if (lstPrm != null)
                    command.Parameters.AddRange(lstPrm.ToArray());

                adp = new SqlDataAdapter(command);
                adp.Fill(ds, tableName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }

        //private void CreateParameter(SqlParameter[] paramCollection, SqlCommand command)
        //{
        //    foreach (SqlParameter param in paramCollection)
        //    {
        //        command.Parameters.Add(param);
        //    }
        //}
        public  static DataSet GetDataSet(string spName, SqlParameter[] paramCollection)
        {
            SqlDataAdapter adp = null;
            DataSet ds = new DataSet();
            OpenConnection();
            try
            {
                SqlCommand command = new SqlCommand(spName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (paramCollection != null)
                    CreateParameter(paramCollection, command);

                adp = new SqlDataAdapter(command);
                adp.Fill(ds, "Table");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
        //on open SIP connection
        public static void Open_SIP_Connection(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            try
            {

                if (SIP_connection.State == ConnectionState.Open)
                {
                    SIP_connection.Close();
                    SqlConnection.ClearPool(SIP_connection);
                }
                SIP_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2";
                SIP_connection.ConnectionString = SIP_ConnectionString;
                //SIP_ConnectionString.ConnectionTimeout = LoginSys.dbocommTimeOut;
                SIP_connection.Open();


            }
            catch (SqlException ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }

                MessageBox.Show(ex.Message.ToString(), "Error in Opening Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }

                MessageBox.Show(ex.Message.ToString(), "Error in Opening Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        
        #region close SIP connection
        public static void Close_SIP_Connection()
        {
            try
            {
                if (SIP_connection.State == ConnectionState.Open)
                {
                    SIP_connection.Close();
                    SqlConnection.ClearPool(SIP_connection);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error in Closing Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error in Closing Database Connection. ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        # region Get SIP dataset

        public static DataSet get_SIP_Dataset(string query, string strName, string strServerName, string strDbName, string strUserName, string strPassword)
        {
            DataSet tempds = new DataSet();
            SqlDataAdapter tempadapter;
            Close_SIP_Connection();
            SqlConnection.ClearPool(SIP_connection);
            if (SIP_connection.State != ConnectionState.Open)
            {
                Open_SIP_Connection(strServerName, strDbName, strUserName, strPassword);
            }
            command = new SqlCommand(query, SIP_connection);
            command.CommandTimeout = 1000000;
            tempadapter = new SqlDataAdapter(command);
            tempadapter.Fill(tempds, strName);
            Close_SIP_Connection();
            tempds.Dispose();
            return tempds;
        }

        # endregion
    }
}
