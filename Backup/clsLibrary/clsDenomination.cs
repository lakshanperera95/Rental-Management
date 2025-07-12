using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DbConnection;

namespace clsLibrary
{
    public class clsDenomination
    {
        private SqlDataReader DataReader;
        private Boolean blRecordFound;

        private string strSqlString;
        public string SqlString
        {
            get { return strSqlString; }
            set { strSqlString = value; }
        }

        private string strSqlStatement;
        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        private string strDataSetName;
        public string dsName
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

        private string StrCashDenoDoc;
        public string _StrCashDenoDoc
        {
            get { return StrCashDenoDoc; }
            set { StrCashDenoDoc = value; }
        }

        private decimal strCash;
        public decimal Cash
        {
            get { return strCash; }
            set { strCash = value; }
        }

        private decimal strRefundTotal;
        public decimal RefundTotal
        {
            get { return strRefundTotal; }
            set { strRefundTotal = value; }
        }

        private decimal strDiscountTotal;
        public decimal DiscountTotal
        {
            get { return strDiscountTotal; }
            set { strDiscountTotal = value; }
        }

        private decimal strAdvance;
        public decimal Advance
        {
            get { return strAdvance; }
            set { strAdvance = value; }
        }

      

        private string strUserName;
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }
        

        private decimal strCreditCard;
        public decimal CreditCard
        {
            get { return strCreditCard; }
            set { strCreditCard = value; }
        }

        private decimal strCredit;
        public decimal Credit
        {
            get { return strCredit; }
            set { strCredit = value; }
        }

        private decimal strCDM;
        public decimal CDM
        {
            get { return strCDM; }
            set { strCDM = value; }
        }

        private decimal strROA;
        public decimal ROA
        {
            get { return strROA; }
            set { strROA = value; }
        }

        private decimal strCashOut;
        public decimal CashOut
        {
            get { return strCashOut; }
            set { strCashOut = value; }
        }

        private decimal strAdvanceRedeem;
        public decimal AdvanceRedeem
        {
            get { return strAdvanceRedeem; }
            set { strAdvanceRedeem = value; }
        }

        private string strDateTo;
        public string DateTo
        {
            get { return strDateTo; }
            set { strDateTo = value; }
        }

        private string strIid;
        public string Iid
        {
            get { return strIid; }
            set { strIid = value; }
        }

        private decimal decAmount;
        public decimal declareAmount
        {
            get { return decAmount; }
            set { decAmount = value; }
        }

        private string strDateFrom;
        public string DateFrom
        {
            get { return strDateFrom; }
            set { strDateFrom = value; }
        }

        private string strPost_Date;
        public string Post_Date
        {
            get { return strPost_Date; }
            set { strPost_Date = value; }
        }

        private string strLoca;
        public string Loca
        {
            get { return strLoca; }
            set { strLoca = value; }
        }

        private decimal N5000;
        public decimal _N5000
        {
            get { return N5000; }
            set { N5000 = value; }
        }

        private decimal N2000;
        public decimal _N2000
        {
            get { return N2000; }
            set { N2000 = value; }
        }

        private decimal N1000;
        public decimal _N1000
        {
            get { return N1000; }
            set { N1000 = value; }
        }

        private decimal N500;
        public decimal _N500
        {
            get { return N500; }
            set { N500 = value; }
        }

        private decimal N200;
        public decimal _N200
        {
            get { return N200; }
            set { N200 = value; }
        }

        private decimal N100;
        public decimal _N100
        {
            get { return N100; }
            set { N100 = value; }
        }

        private decimal N50;
        public decimal _N50
        {
            get { return N50; }
            set { N50 = value; }
        }

        private decimal N20;
        public decimal _N20
        {
            get { return N20; }
            set { N20 = value; }
        }

        private decimal N10;
        public decimal _N10
        {
            get { return N10; }
            set { N10 = value; }
        }

        private decimal N5;
        public decimal _N5
        {
            get { return N5; }
            set { N5 = value; }
        }

        private decimal N2;
        public decimal _N2
        {
            get { return N2; }
            set { N2 = value; }
        }

        private decimal N1;
        public decimal _N1
        {
            get { return N1; }
            set { N1 = value; }
        }

        private decimal NS5;
        public decimal _NS5
        {
            get { return NS5; }
            set { NS5 = value; }
        }

        private decimal NS25;
        public decimal _NS25
        {
            get { return NS25; }
            set { NS25 = value; }
        }

        private string strCashier;
        public string Cashier
        {
            get { return strCashier; }
            set { strCashier = value; }
        }

        public void RetriveData()
        {
            dsResultSet = dbcon.getDataset(strSqlStatement, strDataSetName);
        }

        //private string StrCashDenoDoc;
        //public string _StrCashDenoDoc
        //{
        //    get { return StrCashDenoDoc; }
        //    set { StrCashDenoDoc = value; }
        //}


 
        public DataSet GetDsFor_CashDeno(string DocNo)
        {
            try
            {
                string sqlStatement = "";
                sqlStatement = "select Location.Loca+'-'+Location.Loca_Descrip,tb_Manual_Day_End.* from tb_Manual_Day_End Inner Join Location On tb_Manual_Day_End.loca=Location.Loca WHERE DocNo='" + DocNo + "'; SELECT * FROM CompanyProfile ";


                return dbcon.getDataset(sqlStatement, "dsDailyCollection");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                return null;
            }
        }

        public void Cash_Deno_Apply()
        {
            SqlDataReader dr = null;
            StrCashDenoDoc = string.Empty;
            try
            {

                SqlParameter[] parameter = {
                    new SqlParameter("@Loca", LoginManager.LocaCode),
                    new SqlParameter("@Iid", strIid),
                    new SqlParameter("@Post_Date", Post_Date),
                    new SqlParameter("@UserName",LoginManager.UserName.Trim()),
                    
                    new SqlParameter("@Amount", decAmount),
                    new SqlParameter("@N5000", N5000),
                    new SqlParameter("@N2000", N2000),
                    new SqlParameter("@N1000", N1000),
                    new SqlParameter("@N500", N500),
                    new SqlParameter("@N100", N100),
                    new SqlParameter("@N50", N50),
                    new SqlParameter("@N20", N20),
                    new SqlParameter("@N10", N10),
                    new SqlParameter("@N5", N5),
                    new SqlParameter("@N2", N2),
                    new SqlParameter("@N1", N1),
                    
                };

                dsResultSet = dbcon.GetDataSet("sp_CashDenominationApply", parameter);
                dsResultSet.Tables[0].TableName = "dsCashDeno";
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.CloseConnection();
                dbcon.CloseReader();

                if (dr != null)
                {
                    dr.Close();
                }
            }
        }
    }
}
