using System;
using System.Collections.Generic;
using System.Text;
using DbConnection;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
namespace clsLibrary
{
    public class LoginManager
    {
        private static string username;
        private static string location;
        private static string strLocaCode;
        private static string strPriceChange;
        private static string strCostCodeText;
        private static string strExtLoca;
        private static string strExtLocaDescription;
        private static string strExtUserName;
        private static string strExtPassword;
        private static Boolean strProductDetChange;
        private static string strCompanyName;
        private static string strCompanyAddress;
        private static string strCompanyTelephone;
        private static string strCompanyEmail;
        private static string strExtLocaDescription2;
        private static string strExtLoca2;
        private static string strExtUserName2;
        private static string strExtPassword2;
        private static string strServerName;
        private static string strDatabaseName;
        private static string strUser;
        private static string strPassword;
        private static string strPrinterCom;
        public static string MacAddress;
        public static string CompanyName
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }
        }
        public static string _MachinName;
        public static string MachinName
        {
            get { return _MachinName; }
            set { _MachinName = value; }
        }
        public static string CompanyAddress
        {
            get { return strCompanyAddress; }
            set { strCompanyAddress = value; }
        }

        public static string CompanyTelephone
        {
            get { return strCompanyTelephone; }
            set { strCompanyTelephone = value; }
        }

        public static string CompanyEmail
        {
            get { return strCompanyEmail; }
            set { strCompanyEmail = value; }
        }

        public static Boolean ProductDetChange
        {
            get { return strProductDetChange; }
            set { strProductDetChange = value; }
        }

        public static string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public static string Location
        {
            get { return location; }
            set { location = value; }
        }
        public static string LocaCode
        {
            get { return strLocaCode; }
            set { strLocaCode = value; }
        }
        public static string PriceChange
        {
            get { return strPriceChange; }
            set { strPriceChange = value; }
        }
        public static string CostCodeText
        {
            get { return strCostCodeText; }
            set { strCostCodeText = value; }
        }
        public static string ExtLocaDescription
        {
            get { return strExtLocaDescription; }
            set { strExtLocaDescription = value; }
        }
        public static string ExtLoca
        {
            get { return strExtLoca; }
            set { strExtLoca = value; }
        }
        public static string ExtUserName
        {
            get { return strExtUserName; }
            set { strExtUserName = value; }
        }
        public static string ExtPassword
        {
            get { return strExtPassword; }
            set { strExtPassword = value; }
        }
        
        public static string ExtLocaDescription2
        {
            get { return strExtLocaDescription2; }
            set { strExtLocaDescription2 = value; }
        }

        public static string ExtLoca2
        {
            get { return strExtLoca2; }
            set { strExtLoca2 = value; }
        }
        
        public static string ExtUserName2
        {
            get { return strExtUserName2; }
            set { strExtUserName2 = value; }
        }
      
        public static string ExtPassword2
        {
            get { return strExtPassword2; }
            set { strExtPassword2 = value; }
        }

        public static string ServerName
        {
            get { return strServerName; }
            set { strServerName = value; }
        }

        public static string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public static string  User
        {
            get { return strUser; }
            set { strUser = value; }
        }

        public static string DatabaseName
        {
            get { return strDatabaseName; }
            set { strDatabaseName = value; }
        }

        
        public static string PrinterCom
        {
            get { return strPrinterCom; }
            set { strPrinterCom = value; }
        }

        private static string _AllPriceShow;
        public static string AllPriceShow
        {
            get { return _AllPriceShow; }
            set { _AllPriceShow = value; }
        }

        private static string _SIP_St_Show;
        public static string SIP_St_Show
        {
            get { return _SIP_St_Show; }
            set { _SIP_St_Show = value; }
        }


        private static string _ApiReward;
        public static string ApiReward
        {
            get { return _ApiReward; }
            set { _ApiReward = value; }
        }

        private static string _ApiInv;
        public static string ApiInv
        {
            get { return _ApiInv; }
            set { _ApiInv = value; }
        }
        private static string _PosId;
        public static string PosId
        {
            get { return _PosId; }
            set { _PosId = value; }
        }



         DataSet ds = null;
         SqlDataAdapter adapter = null;

        public void CompanyDetails(string query)
        {
            try
            {
                if (dbcon.connection.State != ConnectionState.Open)
                {
                    dbcon.OpenConnection();
                }
                //dbcon.connection.Open();
                adapter = new SqlDataAdapter(query, dbcon.connection);
                ds = new DataSet();
                adapter.Fill(ds, "Company");
                if (ds.Tables["Company"].Rows.Count != 0)
                {
                    foreach (DataRow row in ds.Tables["Company"].Rows)
                    {
                        strCompanyName = row["CompanyName"].ToString();
                        strCompanyAddress = row["CompanyAddress"].ToString();
                        strCompanyTelephone = row["CompanyTelephone"].ToString();
                        strCompanyEmail = row["CompanyEmail"].ToString();

                    }
                }
               
                
            }
            catch (Exception ex)
            {
                dbcon.connection.Close();
            }
            finally
            {
                dbcon.connection.Close();
            }
        }
    }
}
