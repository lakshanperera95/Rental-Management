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
    public class clsPosTerminal : clsPosUpdate
    {
        #region General Declaration
        //private string strTerminal;
        private string strSQLUpdateSetting;
        private string strTail1;
        private string strTail2;
        private string strTail3;
        private string strTail4;
        private string strTail5;
        private string strTail6;
        private string strTail7;
        private string strTail8;
        private string strTail9;
        private string strTail10;
        private string strMessage;
        //private string strTerminalPwd;
        private string strJournalPath;

        private int intErrCode;

        //private Boolean blTerminalUpdate;
        private DataSet dsPosTerminal;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        //public string Terminal
        //{
        //    get { return strTerminal; }
        //    set { strTerminal = value; }
        //}

        public string SQLUpdateSetting
        {
            get { return strSQLUpdateSetting; }
            set { strSQLUpdateSetting = value; }
        }

        public string Tail1
        {
            get { return strTail1; }
            set { strTail1 = value; }
        }

        public string Tail2
        {
            get { return strTail2; }
            set { strTail2 = value; }
        }

        public string Tail3
        {
            get { return strTail3; }
            set { strTail3 = value; }
        }

        public string Tail4
        {
            get { return strTail4; }
            set { strTail4 = value; }
        }

        public string Tail5
        {
            get { return strTail5; }
            set { strTail5 = value; }
        }

        public string Tail6
        {
            get { return strTail6; }
            set { strTail6 = value; }
        }

        public string Tail7
        {
            get { return strTail7; }
            set { strTail7 = value; }
        }

        public string Tail8
        {
            get { return strTail8; }
            set { strTail8 = value; }
        }

        public string Tail9
        {
            get { return strTail9; }
            set { strTail9 = value; }
        }

        public string Tail10
        {
            get { return strTail10; }
            set { strTail10 = value; }
        }

        public string Message
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        public string JournalPath
        {
            get { return strJournalPath; }
            set { strJournalPath = value; }
        }

        public DataSet PosTerminal
        {
            get { return dsPosTerminal; }
            set { dsPosTerminal = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        //public string TerminalPwd
        //{
        //    get { return strTerminalPwd; }
        //    set { strTerminalPwd = value; }
        //}

        public void TerminalUpdateSettings()
        {
            try
            {
                intErrCode = 0;
                TerminalUpdate = false;
                dbcon.CheckPosConn(Terminal, TerminalPwd, Terminal);

                if (dbcon.blPosStatus == true)
                {
                    dbcon.UpdatePosSettings(Terminal, strSQLUpdateSetting, TerminalPwd);
                }
                TerminalUpdate = dbcon.blPosStatus;
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPosTerminal 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPosTerminal 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadDefaultPosSettings()
        {
            try
            {
                DataReader = dbcon.GetReader("SELECT * FROM Pos_SystemFile");
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strTail1 = DataReader["Tail1"].ToString().Trim();
                    strTail2 = DataReader["Tail2"].ToString().Trim();
                    strTail3 = DataReader["Tail3"].ToString().Trim();
                    strTail4 = DataReader["Tail4"].ToString().Trim();
                    strTail5 = DataReader["Tail5"].ToString().Trim();
                    strTail6 = DataReader["Tail6"].ToString().Trim();
                    strTail7 = DataReader["Tail7"].ToString().Trim();
                    strTail8 = DataReader["Tail8"].ToString().Trim();
                    strTail9 = DataReader["Tail9"].ToString().Trim();
                    strTail10 = DataReader["Tail10"].ToString().Trim();
                    strMessage = DataReader["Message"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strTail1 = string.Empty;
                    strTail2 = string.Empty;
                    strTail3 = string.Empty;
                    strTail4 = string.Empty;
                    strTail5 = string.Empty;
                    strTail6 = string.Empty;
                    strTail7 = string.Empty;
                    strTail8 = string.Empty;
                    strTail9 = string.Empty;
                    strTail10 = string.Empty;
                    strMessage = string.Empty;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPosTerminal 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdatePosSettingsLocal()
        {
            try
            {
                intErrCode = 0;
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_PosTerminalSettingUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Tail1", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail1));
                command.Parameters.Add(new SqlParameter("@Tail2", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail2));
                command.Parameters.Add(new SqlParameter("@Tail3", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail3));
                command.Parameters.Add(new SqlParameter("@Tail4", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail4));
                command.Parameters.Add(new SqlParameter("@Tail5", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail5));
                command.Parameters.Add(new SqlParameter("@Tail6", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail6));
                command.Parameters.Add(new SqlParameter("@Tail7", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail7));
                command.Parameters.Add(new SqlParameter("@Tail8", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail8));
                command.Parameters.Add(new SqlParameter("@Tail9", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail9));
                command.Parameters.Add(new SqlParameter("@Tail10", SqlDbType.NVarChar, 42, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTail10));
                command.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMessage));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPosTerminal 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadPosTerminalJournalPath()
        {
            try
            {
                DataReader = dbcon.GetReader("SELECT Journal_Path from tbPosTerminalDetails WHERE Terminal_No = '" + Terminal + "'");
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strJournalPath = DataReader["Journal_Path"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    strJournalPath = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsPosTerminal 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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