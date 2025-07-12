using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient ;
using System.Data;
using System.Windows.Forms;
using DbConnection;

namespace clsLibrary
{
    public class clsRetriveGenaral
    {
        static DataSet ds = null;
        static SqlDataAdapter adapter = null;


        public DataSet dataset
        {
            get { return ds; }
            set { ds = value; }
        }

        public static DataSet combofill1(string query)
        {

            try
            {
                //if (dbcon.connection.State != ConnectionState.Open)
                //{
                dbcon.OpenConnection();
                // dbcon.connection.Open();
                //}

                adapter = new SqlDataAdapter(query, dbcon.connection);
                ds = new DataSet();
                adapter.Fill(ds, "Table");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return new DataSet();
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

       
        
        
    }
}
