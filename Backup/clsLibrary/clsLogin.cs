using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using DbConnection;

namespace clsLibrary
{
    public class clsLogin
    {

        static DataSet ds = null;
        static SqlDataAdapter adapter = null;

        public static string PasswordValidator(string query)
        {
            if (dbcon.connection.State != ConnectionState.Open)
            {
                dbcon.OpenConnection();
            }
                //dbcon.connection.Open();
                adapter = new SqlDataAdapter(query, dbcon.connection);
                ds = new DataSet();
                adapter.Fill(ds, "Table");
                if (ds.Tables["Table"].Rows.Count != 0)
                {
                    return ds.Tables["Table"].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }

                dbcon.connection.Close();
        }
    }
}

