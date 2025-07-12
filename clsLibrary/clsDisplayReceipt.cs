using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DbConnection;


namespace clsLibrary
{
    
    public class clsDisplayReceipt
    {
       // static SqlDataAdapter adapter = null;

        private string strSqlStatement;
        public string _strSqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        private DataSet dsLocation;
        public DataSet _dsLocation
        {
            get { return dsLocation; }
            set { dsLocation = value; }
        }

        private DataSet dsUnit;
        public DataSet _dsUnit
        {
            get { return dsUnit; }
            set { dsUnit = value; }
        }
         
        public DataSet GetUnit()
        {
            try
            {
                //dbcon.OpenConnection();
                //adapter = new SqlDataAdapter("SELECT DISTINCT Unit FROM DayEnd_Pos_Transaction", dbcon.connection);
                dsUnit = new DataSet();
                //adapter.Fill(dsUnit, "unit");
                dsUnit = dbcon.getDataset("SELECT DISTINCT Unit FROM DayEnd_Pos_Transaction","unit");
                return dsUnit;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                return new DataSet();
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }
        public DataSet GetLocation()
        {
            try
            {
                //dbcon.OpenConnection();
                //adapter = new SqlDataAdapter("SELECT Loca,Loca_Descrip FROM Location", dbcon.connection);
                //dsLocation = new DataSet();
                //adapter.Fill(dsLocation,"Location");
                dsLocation = new DataSet();
                dsLocation = dbcon.getDataset("SELECT Loca,Loca_Descrip FROM Location", "Location");
                return dsLocation;             
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                return new DataSet();
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }


 
    }

    
}
