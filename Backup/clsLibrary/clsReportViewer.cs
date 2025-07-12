using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data ;
using System.Data.SqlClient;
using DbConnection;

namespace clsLibrary
{
    public class clsReportViewer
    {
        # region //General Declartion
        private string strSqlSatemet;
        private string strDatasetName;
        private DataSet dsTempResult;
        # endregion

        public string SqlStatement
        {
            get { return strSqlSatemet; }
            set { strSqlSatemet = value; }
        }

        public string DataSetName
        {
            get { return strDatasetName; }
            set { strDatasetName = value; }
        }

        public DataSet TempResultSet
        {
            get { return dsTempResult; }
            set { dsTempResult = value; }
        }


        private string _strDs;
        public string strDs
        {
            get { return _strDs; }
            set { _strDs = value; }
        }

        private DataSet _Ds;
        public DataSet Ds
        {
            get { return _Ds; }
            set { _Ds = value; }
        }

        private string _Query;
        public string Query
        {
            get { return _Query; }
            set { _Query = value; }
        }

        public void RetrieveData()
        {
            try
            {
                TempResultSet = dbcon.getDataset(strSqlSatemet, strDatasetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsReportViewer 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SubRetrieveData()
        {
            try
            {

                Ds = dbcon.getDataset(_Query, _strDs);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsReportViewer 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
