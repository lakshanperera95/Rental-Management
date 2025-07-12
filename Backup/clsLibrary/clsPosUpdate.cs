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
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPosUpdate 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetPosTerminal()
        {
            try
            {
                //get Temporary DataSet For Pos Details
                dsPosTerminal = dbcon.getDataset("SELECT Terminal_No, Terminal_Name, Terminal_Status, Terminal_Password, DatabaseName FROM tbPosTerminalDetails WHERE Terminal_Status = 'T' ORDER BY Terminal_No", "dsTerminalDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPosUpdate 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

    }
}
