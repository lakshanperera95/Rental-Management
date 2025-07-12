using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DbConnection;

namespace clsLibrary
{
    public class clsGiftVoucherPrint :BaseClass
    {
        public void SearchCodeNew(string query,string dataset)
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
