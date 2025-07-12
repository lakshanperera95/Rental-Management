using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DbConnection
{
    public class dbconApi
    {
        //************************************************************************************
        //**   SuperMarket Inventory System                                                 **
        //**   Installed On 03/02/2009                                                      **
        //**   Last Modified On 05/06/2009  GIHAN   Database Version DBSM 10.10             **
        //**   Last Modified On 17/08/2009  THARINDU   Database Version DBSM 10.10.2        **
        //**   Last Modification in Brief                                                   **
        //**   Change Connection String                                                     **
        //************************************************************************************


        private static string UserName = string.Empty;
        private static string PassWord = string.Empty;

        public static string ConnectionString;
        public static string SR1_ConnectionString;
        public static string SR2_ConnectionString;
        public static string SR3_ConnectionString;

        private static string strPosConnString;
        public static bool ConnFound = false;
        public static bool SR1_ConnFound = false;
        public static bool SR2_ConnFound = false;
        public static bool SR3_ConnFound = false;

        public static Boolean blPosStatus; //Available True, Not Available False

        public static SqlConnection connection = new SqlConnection();
        public static SqlConnection SR1_connection = new SqlConnection();
        public static SqlConnection SR2_connection = new SqlConnection();
        public static SqlConnection SR3_connection = new SqlConnection();

        public static SqlConnection PosConnection = new SqlConnection();
        public static SqlCommand command;
        public static SqlDataReader reader;


        public static void SetConnectionString(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            ConnectionString = "data source=" + LoginSys.strInvServerName + ";initial catalog=" + LoginSys.strInvDataBase + ";persist security info=False;user id=" + LoginSys.strInvUserName + " ; password=" + LoginSys.strInvPassword + "  ;workstation id=" + LoginSys.strInvServerName + ";packet size=4096;Min pool size=2;Connection Timeout=60";
            connection.ConnectionString = ConnectionString;
        }

        public static void Set_SR1_ConnectionString(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            SR1_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2;Connection Timeout=60";
            SR1_connection.ConnectionString = SR1_ConnectionString;
        }
        public static void Set_SR2_ConnectionString(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            SR2_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2;Connection Timeout=60";
            SR2_connection.ConnectionString = SR2_ConnectionString;
        }
        public static void Set_SR3_ConnectionString(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            SR3_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2;Connection Timeout=60";
            SR3_connection.ConnectionString = SR3_ConnectionString;
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
                if (LoginSys.backEndStatus == "MSSQL")
                {
                    if (connection.State == ConnectionState.Connecting)
                    {
                        while (connection.State == ConnectionState.Connecting)
                        {
                            connection.Close();
                        }
                    }
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

        }
        #endregion


        public static void Open_SR1_Connection(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            try
            {

                if (SR1_connection.State == ConnectionState.Open)
                {
                    SR1_connection.Close();
                }
                SR1_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2";
                SR1_connection.ConnectionString = SR1_ConnectionString;
                //connection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                SR1_connection.Open();


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

        public static void Open_SR2_Connection(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            try
            {

                if (SR2_connection.State == ConnectionState.Open)
                {
                    SR2_connection.Close();
                }
                SR2_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2";
                SR2_connection.ConnectionString = SR2_ConnectionString;
                //connection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                SR2_connection.Open();


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
        }

        public static void Open_SR3_Connection(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            try
            {

                if (SR3_connection.State == ConnectionState.Open)
                {
                    SR3_connection.Close();
                }
                SR3_ConnectionString = "data source=" + strServerName + ";initial catalog=" + strDbName + ";persist security info=False;user id=" + strUserName + " ; password=" + strPassword + "  ;workstation id=" + strServerName + ";packet size=4096;Min pool size=2";
                SR3_connection.ConnectionString = SR3_ConnectionString;
                //connection.ConnectionTimeout = LoginSys.dbocommTimeOut;
                SR3_connection.Open();


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
        }


        #region close main connection

        public static void CloseConnection()
        {
            try
            {
                if (LoginSys.backEndStatus == "MSSQL")
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        SqlConnection.ClearPool(connection);
                    }
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

        public static void Close_SR1_Connection()
        {
            try
            {
                if (SR1_connection.State == ConnectionState.Open)
                {
                    SR1_connection.Close();
                    SqlConnection.ClearPool(SR1_connection);
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

        public static void Close_SR2_Connection()
        {
            try
            {
                if (SR2_connection.State == ConnectionState.Open)
                {
                    SR2_connection.Close();
                    SqlConnection.ClearPool(SR2_connection);
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

        public static void Close_SR3_Connection()
        {
            try
            {
                if (SR3_connection.State == ConnectionState.Open)
                {
                    SR3_connection.Close();
                    SqlConnection.ClearPool(SR3_connection);
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


        public static DataSet getDataset(string query, string strName, string ControllerName="Common")
        {
            DataSet tempds = new DataSet();

            try
            {
                if (LoginSys.backEndStatus == "MSSQL")
                {
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
                    //tempds.Dispose();
                }
                else if (LoginSys.backEndStatus == "MSSQL-API")
                {
                    clsCommonApi objApi = new clsCommonApi();
                    clsCommonApiRequest objRequest = new clsCommonApiRequest();
                    clsCommonApiResponse objResponse = new clsCommonApiResponse();
                    objRequest.sqltext = query;
                    objRequest.dsName = strName;
                    JavaScriptSerializer j = new JavaScriptSerializer();
                    j.MaxJsonLength = Int32.MaxValue;
                    string postData = j.Serialize(objRequest);

                    if (ControllerName == string.Empty)
                    {
                        ControllerName = "Auth";
                    }
                    objResponse = objApi.HttpPost(LoginSys.baseURL, postData, ControllerName, "GetDataset");

                    if (objResponse.StatusCode == "OK")
                    {

                        var obj = (IDictionary<string, object>)j.DeserializeObject(objResponse.objDynamicResult);
                        string Y = j.Serialize(obj);


                        tempds = (DataSet)JsonConvert.DeserializeObject(Y, (typeof(DataSet)));
                        tempds = RemoveNullRawDataset(ref tempds);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
                CloseReader();
            }

            return tempds;
        }

        public static DataSet RemoveNullRawDataset(ref DataSet ds)
        {
            try
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt.Columns.Contains("NULLROW") && dt.Rows[0]["NULLROW"].ToString() == "NULLROW")
                    {
                        dt.Columns.Remove("NULLROW");
                        dt.Rows.Clear();
                    }
                }
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable RemoveNullRawDatatable(ref DataTable dt)
        {
            try
            {

                if (dt.Columns.Contains("NULLROW") && dt.Rows[0]["NULLROW"].ToString() == "NULLROW")
                {
                    dt.Columns.Remove("NULLROW");
                    dt.Rows.Clear();
                }

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static DataTable getDataTable(string query, string tableName, string ControllerName)
        {

            DataTable tempdt = new DataTable();

            if (LoginSys.backEndStatus == "MSSQL")
            {
                SqlDataAdapter tempadapter;
                connection.Close();
                SqlConnection.ClearPool(connection);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new SqlCommand(query, connection);
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                tempadapter = new SqlDataAdapter(command);
                tempadapter.Fill(tempdt);
                tempdt.TableName = tableName;
                CloseConnection();
                CloseReader();
                tempdt.Dispose();
            }
            else if (LoginSys.backEndStatus == "MSSQL-API")
            {
                clsCommonApi objApi = new clsCommonApi();
                clsCommonApiRequest objRequest = new clsCommonApiRequest();
                clsCommonApiResponse objResponse = new clsCommonApiResponse();
                objRequest.sqltext = query;
                objRequest.dsName = tableName;
                JavaScriptSerializer j = new JavaScriptSerializer();
                j.MaxJsonLength = Int32.MaxValue;
                string postData = j.Serialize(objRequest);

                if (ControllerName == string.Empty)
                {
                    ControllerName = "Auth";
                }
                objResponse = objApi.HttpPost(LoginSys.baseURL, postData, ControllerName, "GetDataTable");

                if (objResponse.StatusCode == "OK")
                {

                    var dynamicEdited = "{\"" + objRequest.dsName + "\":" + objResponse.objDynamicResult + "}";
                    var obj = (IDictionary<string, object>)j.DeserializeObject(dynamicEdited);
                    string Y = j.Serialize(obj);

                    DataSet ds = (DataSet)JsonConvert.DeserializeObject(Y, (typeof(DataSet)));
                    tempdt = ds.Tables[0];

                }
            }
            tempdt = RemoveNullRawDatatable(ref tempdt);
            return tempdt;
        }

        public static DataTableReader GetDataTableReader(string query, string ControllerName= "Common")
        {
            DataTableReader dtReader;
            try
            {
                if (LoginSys.backEndStatus == "MSSQL")
                {
                    SqlConnection.ClearPool(connection);
                    command = connection.CreateCommand();
                    command.CommandText = query;
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    OpenConnection();
                    DataTable dt = new DataTable();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    dtReader = dt.CreateDataReader();
                }
                else if (LoginSys.backEndStatus == "MSSQL-API")
                {
                    clsCommonApi objApi = new clsCommonApi();
                    clsCommonApiRequest objRequest = new clsCommonApiRequest();
                    clsCommonApiResponse objResponse = new clsCommonApiResponse();
                    objRequest.sqltext = query;
                    objRequest.dsName = "table";
                    JavaScriptSerializer j = new JavaScriptSerializer();
                    j.MaxJsonLength = Int32.MaxValue;
                    string postData = j.Serialize(objRequest);

                    if (ControllerName == string.Empty)
                    {
                        ControllerName = "Auth";
                    }
                    objResponse = objApi.HttpPost(LoginSys.baseURL, postData, ControllerName, "GetDataTable");

                    if (objResponse.StatusCode == "OK")
                    {
                        var dynamicEdited = "{\"" + objRequest.dsName + "\":" + objResponse.objDynamicResult + "}";
                        var obj = (IDictionary<string, object>)j.DeserializeObject(dynamicEdited);
                        string Y = j.Serialize(obj);

                        DataSet ds = (DataSet)JsonConvert.DeserializeObject(Y, (typeof(DataSet)));
                        DataTable dt = ds.Tables[0];
                        dt = RemoveNullRawDatatable(ref dt);
                        dtReader = dt.CreateDataReader();
                    }
                    else
                    {
                        dtReader = null;
                    }

                }
                else
                {
                    dtReader = null;
                }
                return dtReader;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public static object getObject(string query, string ControllerName)
        {
            object retObj;
            retObj = null;
            try
            {
                if (LoginSys.backEndStatus == "MSSQL")
                {
                    SqlConnection.ClearPool(connection);
                    command = connection.CreateCommand();
                    command.CommandText = query;
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    OpenConnection();
                    retObj = command.ExecuteScalar();
                }
                else if (LoginSys.backEndStatus == "MSSQL-API")
                {
                    clsCommonApi objApi = new clsCommonApi();
                    clsCommonApiRequest objRequest = new clsCommonApiRequest();
                    clsCommonApiResponse objResponse = new clsCommonApiResponse();
                    DataTableReader dtReader;
                    objRequest.sqltext = query;
                    objRequest.dsName = "table";
                    JavaScriptSerializer j = new JavaScriptSerializer();
                    j.MaxJsonLength = Int32.MaxValue;
                    string postData = j.Serialize(objRequest);

                    if (ControllerName == string.Empty)
                    {
                        ControllerName = "Auth";
                    }
                    objResponse = objApi.HttpPost(LoginSys.baseURL, postData, ControllerName, "GetDataTable");

                    if (objResponse.StatusCode == "OK")
                    {
                        var dynamicEdited = "{\"" + objRequest.dsName + "\":" + objResponse.objDynamicResult + "}";
                        var obj = (IDictionary<string, object>)j.DeserializeObject(dynamicEdited);
                        string Y = j.Serialize(obj);

                        DataSet ds = (DataSet)JsonConvert.DeserializeObject(Y, (typeof(DataSet)));
                        DataTable dt = ds.Tables[0];
                        dt = RemoveNullRawDatatable(ref dt);
                        dtReader = dt.CreateDataReader();
                        while (dtReader.Read())
                        {
                            retObj = dtReader[0];
                        }

                    }
                    else
                    {
                        retObj = null;
                    }

                }
                else
                {
                    retObj = null;
                }
                return retObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static object returnObject { get; set; }
        public enum sqlCommandExecuteTypes
        {
            ExecuteSp_WithoutResult,
            ExecuteSp_AndGetReader,
            ExecuteSp_AndGetDataset
        }
        public static void executeStoredProcedure(ref SqlCommand cmd, sqlCommandExecuteTypes executeType, ref DataSet dsSpData, string SpDataSetName, ref DataTableReader dtrSpData, string ControllerName)
        {
            try
            {
                if (LoginSys.backEndStatus == "MSSQL")
                {
                    switch (executeType)
                    {
                        case sqlCommandExecuteTypes.ExecuteSp_WithoutResult:
                            cmd.ExecuteNonQuery();
                            cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                            break;

                        case sqlCommandExecuteTypes.ExecuteSp_AndGetDataset:

                            if (dsSpData == null)
                            {
                                dsSpData = new DataSet();
                            }
                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                adapter.Fill(dsSpData, SpDataSetName);
                            }

                            cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                            break;

                        case sqlCommandExecuteTypes.ExecuteSp_AndGetReader:
                            DataSet ds = new DataSet();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                adapter.Fill(ds);
                            }

                            dtrSpData = ds.CreateDataReader();
                            cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                            break;

                        default:
                            break;
                    }
                }
                else if (LoginSys.backEndStatus == "MSSQL-API")
                {
                    clsCommonApi objApi = new clsCommonApi();
                    clsCommonApiRequest objRequest = new clsCommonApiRequest();
                    clsCommonApiResponse objResponse = new clsCommonApiResponse();
                    objRequest.SpName = cmd.CommandText;
                    objRequest.HasReturnData = executeType == sqlCommandExecuteTypes.ExecuteSp_WithoutResult ? "F" : "T";
                    objRequest.Parameters = objApi.convertSqlParaToCommonPara(cmd);

                    JavaScriptSerializer j = new JavaScriptSerializer();
                    j.MaxJsonLength = Int32.MaxValue;
                    string postData = j.Serialize(objRequest);

                    if (ControllerName == string.Empty)
                    {
                        ControllerName = "Auth";
                    }
                    objResponse = objApi.HttpPost(LoginSys.baseURL, postData, ControllerName, "ExecuteSp");



                    if (objResponse.StatusCode == "OK")
                    {

                        var obj = (IDictionary<string, object>)j.DeserializeObject(objResponse.objDynamicResult);
                        var resultset = (IDictionary<string, object>)obj["Result"];
                        var Parameters = resultset["Parameters"];
                        var dsResponse = resultset["dsResponse"];
                        if (Parameters != null)
                        {
                            objResponse.commonParas = j.Deserialize<List<CommonParameters>>(j.Serialize(Parameters));
                            cmd = objApi.convertCommonParaToSqlPara(objResponse.commonParas);
                        }


                        switch (executeType)
                        {
                            case sqlCommandExecuteTypes.ExecuteSp_WithoutResult:
                                break;
                            case sqlCommandExecuteTypes.ExecuteSp_AndGetDataset:
                                if (dsResponse != null)
                                {
                                    try
                                    {
                                        var xx = j.Serialize(dsResponse);
                                        dsSpData = (DataSet)JsonConvert.DeserializeObject(xx, (typeof(DataSet)));

                                        for (int i = 0; i < dsSpData.Tables.Count; i++)
                                        {
                                            if (i == 0)
                                            {
                                                dsSpData.Tables[i].TableName = SpDataSetName;
                                            }
                                            else
                                            {
                                                dsSpData.Tables[i].TableName = SpDataSetName + i.ToString();
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        dsSpData = null;
                                    }
                                    dsSpData = RemoveNullRawDataset(ref dsSpData);
                                }
                                break;

                            case sqlCommandExecuteTypes.ExecuteSp_AndGetReader:
                                if (dsResponse != null)
                                {
                                    try
                                    {
                                        var xx = j.Serialize(dsResponse);
                                        DataSet tempds = (DataSet)JsonConvert.DeserializeObject(xx, (typeof(DataSet)));
                                        tempds = RemoveNullRawDataset(ref tempds);
                                        dtrSpData = tempds.CreateDataReader();
                                    }
                                    catch
                                    {
                                        dtrSpData = null;
                                    }

                                }
                                break;
                            default:
                                break;
                        }



                    }
                    else if (objResponse.ErrResponse != string.Empty)
                    {
                        throw new WebException(objResponse.ErrResponse);
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //public static SqlDataReader GetReader(string query)
        //{

        //    try
        //    {
        //        if (LoginSys.backEndStatus == "MSSQL")
        //        {
        //            SqlConnection.ClearPool(connection);
        //            command = connection.CreateCommand();
        //            command.CommandText = query;
        //            command.CommandTimeout = LoginSys.dbocommTimeOut;
        //            OpenConnection();
        //            reader = command.ExecuteReader();
        //        }
        //        else
        //        {
        //            throw new NotImplementedException();
        //        }
        //        return reader;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public static void CloseReader()
        {
            if (LoginSys.backEndStatus == "MSSQL")
            {
                if (reader != null)
                {
                    reader.Close();
                }

                CloseConnection();
                SqlConnection.ClearPool(connection);
            }
            else if (LoginSys.backEndStatus == "MSSQL-API")
            {

            }
        }


        public static SqlDataReader Get_SR1_Reader(string query, string strServerName, string strDbName, string strUserName, string strPassword)
        {

            SqlConnection.ClearPool(SR1_connection);
            command = SR1_connection.CreateCommand();
            command.CommandText = query;
            command.CommandTimeout = LoginSys.dbocommTimeOut;
            Open_SR1_Connection(strServerName, strDbName, strUserName, strPassword);
            reader = command.ExecuteReader();
            return reader;
        }

        public static SqlDataReader Get_SR2_Reader(string query, string strServerName, string strDbName, string strUserName, string strPassword)
        {

            SqlConnection.ClearPool(SR2_connection);
            command = SR2_connection.CreateCommand();
            command.CommandText = query;
            command.CommandTimeout = LoginSys.dbocommTimeOut;
            Open_SR2_Connection(strServerName, strDbName, strUserName, strPassword);
            reader = command.ExecuteReader();
            return reader;
        }

        public static SqlDataReader Get_SR3_Reader(string query, string strServerName, string strDbName, string strUserName, string strPassword)
        {

            SqlConnection.ClearPool(SR3_connection);
            command = SR3_connection.CreateCommand();
            command.CommandText = query;
            command.CommandTimeout = LoginSys.dbocommTimeOut;
            Open_SR3_Connection(strServerName, strDbName, strUserName, strPassword);
            reader = command.ExecuteReader();
            return reader;
        }




        public static byte checkCon()
        {
            try
            {

                if (LoginSys.backEndStatus == "MSSQL")
                {
                    if (dbcon.connection.State != ConnectionState.Closed)
                    {
                        dbcon.connection.Close();
                    }
                    if (dbcon.connection.State == ConnectionState.Closed)
                    {
                        dbcon.connection.Open();
                    }
                    ConnFound = true;
                    if (dbcon.connection.State == ConnectionState.Open)
                    {
                        dbcon.connection.Close();
                    }
                }
                else if (LoginSys.backEndStatus == "MSSQL-API")
                {
                    if (!ConnFound)
                    {
                        clsCommonApi objApi = new clsCommonApi();
                        clsCommonApiResponse objResponse = new clsCommonApiResponse();
                        objResponse = objApi.HttpGet(LoginSys.baseURL, "Users", "CheckConnection");
                        if (objResponse.StatusCode == "OK" || objResponse.StatusDescription == 200)
                        {
                            ConnFound = true;
                        }
                    }

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
                    m_streamWriter.WriteLine("'1. Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
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

 
    
        public static bool UpdateImage(string Code, byte[] image)
        {
            try
            {
                clsCommonApi objApi = new clsCommonApi();
                clsImageUpdate objRequest = new clsImageUpdate();
                clsCommonApiResponse objResponse = new clsCommonApiResponse();

                objRequest.Prod_Code = Code;
                objRequest.Prod_Image = image;
                JavaScriptSerializer j = new JavaScriptSerializer();
                j.MaxJsonLength = Int32.MaxValue;
                string postData = j.Serialize(objRequest);

                objResponse = objApi.HttpPost(LoginSys.baseURL, postData, "Product", "UpdateImage");

                if (objResponse.StatusCode == "OK")
                {
                    return true;

                }
                else
                {

                    return false;
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
                    m_streamWriter.WriteLine("'Connection Open Failier. Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + " Error Description " + ex.Message);
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                return false;
            }
        }



    }
}
