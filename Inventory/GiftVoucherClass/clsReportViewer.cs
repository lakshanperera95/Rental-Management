using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbConnection;

namespace Inventory
{
    public class clsReportViewer:BaseClass
    {
        private DataSet dsTempDataSet;

        public DataSet TempDataSet
        {
            get { return dsTempDataSet; }
            set { dsTempDataSet = value; }
        }

        public void RetrieveData()
        {
            try
            {
                TempDataSet = dbcon.getDataset(SqlString, DataSetName);
            }
            catch (Exception ex)
            {
                BaseClass.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.CloseReader();
            }
        }
       
        public void SearchCodeNew(string query, string dataset)
        {
            try
            {
                GetDataSet = dbcon.getDataset(query, dataset);
            }
            catch (Exception ex)
            {
                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

    }
}
