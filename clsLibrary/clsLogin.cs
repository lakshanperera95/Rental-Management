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
        private static bool TaxUser = false;
        public static bool blTaxUser
        {
            get { return TaxUser; }
            set { TaxUser = value; }
        }
        //public static string PasswordValidator(string query,string Loca)
        //{
        //    UpdateTaxLoca(Loca);

        //    if (dbcon.connection.State != ConnectionState.Open)
        //    {
        //        dbcon.OpenConnection();
        //    }
        //    //dbcon.connection.Open();
        //    adapter = new SqlDataAdapter(query, dbcon.connection);
        //    ds = new DataSet();
        //    adapter.Fill(ds, "Table");
        //    if (ds.Tables["Table"].Rows.Count != 0)
        //    {
        //        return ds.Tables["Table"].Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
    
        //    dbcon.connection.Close();
        //}

        public static string PasswordValidator(string query,string Loca)
        {
            UpdateTaxLoca(Loca);

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
                TaxUser = (bool)ds.Tables["Table"].Rows[0][2];
                return ds.Tables["Table"].Rows[0][1].ToString();
            }
            else
            {
                return "";
            }

            dbcon.connection.Close();
        }

        public static void CheckTaxUser(string query, ref string userID)
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
                TaxUser = (bool)ds.Tables["Table"].Rows[0][2];
                userID = ds.Tables["Table"].Rows[0][1].ToString();
            }
            else
            {
                TaxUser = false;
                userID = "";
            }

            dbcon.connection.Close();
        }

        public static void UpdateTaxLoca(string Loca)
        {
            try
            {
                DataTable dt = dbcon.getDataset(" SELECT TaxLocaCode FROM dbo.Location WHERE Loca ='"+Loca+"'", "ds").Tables[0];
                LoginManager.TaxLoca = "";
                if (dt.Rows.Count > 0)
                {
                    LoginManager.TaxLoca = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void GetTaxLoca(string query, ref string LocaCode, ref string LocaName)
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
                LocaCode = ds.Tables["Table"].Rows[0][0].ToString();
                LocaName = ds.Tables["Table"].Rows[0][1].ToString();

            }
            else { LocaCode = LocaName = ""; }

            dbcon.connection.Close();
        }
    }
}

