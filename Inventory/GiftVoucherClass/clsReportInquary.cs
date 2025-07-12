using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DbConnection;


namespace Inventory
{
    public class clsReportInquary
    {
        private string strCodeFrom;
        public string CodeFrom
        {
            get { return strCodeFrom; }
            set { strCodeFrom = value; }
        }

        private string strNameFrom;
        public string NameFrom
        {
            get { return strNameFrom; }
            set { strNameFrom = value; }
        }

        private string  strCodeTo;
        public string  CodeTo
        {
            get { return strCodeTo; }
            set { strCodeTo = value; }
        }

        private string strNameTo;
        public string NameTo
        {
            get { return strNameTo; }
            set { strNameTo = value; }
        }

        private string strSqlStatement;
        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        private string strDataSetName;
        public string DataSetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        private DataSet dsResultSet;
        public DataSet ResultSet
        {
            get { return dsResultSet; }
            set { dsResultSet = value; }
        }


        public void RetreiveData()
        {
            dsResultSet = dbConn.getDataset(strSqlStatement, strDataSetName);
        }

        public void CloseConnection()
        {
            dbConn.CloseConn();
            dbConn.CloseReader();
        }
    }
}
