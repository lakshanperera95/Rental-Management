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
    public class clsMasterDetailsInquary
    {
        # region //General Declartion
        private string strCodeFrom;
        private string strCodeTo;
        private string strSqlStatement;
        private string strDataSetName;
        private DataSet dsResultSet;
        #endregion

        #region //properties"
        public string CodeFrom
        {
            get
            {
                return strCodeFrom;
            }

            set
            {
                strCodeFrom = value;
            }
        }

        public string CodeTo
        {
            get
            {
                return strCodeTo;
            }
            set
            {
                strCodeTo = value;
            }
        }
        public DataSet ResultSet
        {
            get
            {
                return dsResultSet;
            }
            set
            {
                dsResultSet = value;
            }
        }

        public string dsName
        {
            get
            {
                return strDataSetName;
            }
            set
            {
                strDataSetName = value;
            }
        }

        public string SqlStatement
        {
            get
            {
                return strSqlStatement;
            }
            set
            {
                strSqlStatement = value;
            }
        }

        #endregion

        # region //Select Dataset
        public void RetriveData()
        {
            try
            {
                dsResultSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsMasterDetailsInquary 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        # endregion
    }
}
