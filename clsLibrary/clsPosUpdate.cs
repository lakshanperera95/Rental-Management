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
    public class clsPosUpdate
    {
        #region General Declaration
        private string strTerminal;
        private string strTerminalPwd;
        private string strDatabaseName;

        private int intErrCode;

        private Boolean blTerminalUpdate;
        private DataSet dsPosTerminal;
        #endregion

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string Terminal
        {
            get { return strTerminal; }
            set { strTerminal = value; }
        }

        public string TerminalPwd
        {
            get { return strTerminalPwd; }
            set { strTerminalPwd = value; }
        }

        public string DatabaseName
        {
            get { return strDatabaseName; }
            set { strDatabaseName = value; }
        }

        public Boolean TerminalUpdate
        {
            get { return blTerminalUpdate; }
            set { blTerminalUpdate = value; }
        }

        public DataSet PosTerminal
        {
            get { return dsPosTerminal; }
            set { dsPosTerminal = value; }
        }

         public void TerminalReload()
            {
                try
                {
                    intErrCode = 0;
                    blTerminalUpdate = false;
                    dbcon.CheckPosConn(strTerminal, strTerminalPwd, strDatabaseName);

                    if (dbcon.blPosStatus == true)
                    {
                        dbcon.ReloadPos(strTerminal, strTerminalPwd, strDatabaseName);
                    }
                    blTerminalUpdate = dbcon.blPosStatus;
                }
                catch (Exception ex)
                {

                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                finally
                {
                    dbcon.CloseConnection();
                }
            }

        public void Execute_Query(string sqlStatement)
        {
            dbcon.OpenConnection();
            try
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }
        public void OpenConnection()
        {
            dbcon.OpenConnection();
        }
        public void CloseConnection()
        {
            dbcon.CloseConnection();
        }
        public void GetPosTerminal()
        {
            try
            {
                //get Temporary DataSet For Pos Details
                dsPosTerminal = dbcon.getDataset("SELECT Terminal_No, Terminal_Name, Terminal_Status, Terminal_Password, DatabaseName FROM tbPosTerminalDetails WHERE Terminal_Status = 'T' ORDER BY Terminal_No", "dsTerminalDetails");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
        }
        //adding by kalani
        public SqlConnection connection = new SqlConnection();
        public SqlConnection ReturnConn()
        {
            return connection = dbcon.connection;
        }

        public DataTable GetTerminals()
        {
            try
            {
                return dbcon.getDataset("SELECT Terminal_No,Terminal_Name FROM dbo.tbPosTerminalDetails ORDER BY Terminal_No", "ds").Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
