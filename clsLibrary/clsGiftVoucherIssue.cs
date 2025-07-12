using System;
using System.Collections.Generic;
using System.Text;
using DbConnection;
using System.Data.SqlClient;
using System.Data;


namespace clsLibrary
{
    public class clsGiftVoucherIssue
    {

        #region
        int intTempDocNo=0;
        private string strTempDocumentNo;
        public string TempDocNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }

       DataSet  _Ds;
        public DataSet Ds
        {
            get { return _Ds; }
            set { _Ds = value; }
        }
        SqlDataReader DataReader;
        string Sqlst;
        #endregion 
        public void GetTempDocumentNo(string Iid)
        {
            try
            {
                 Sqlst = "SELECT Temp_GVI FROM dbo.DocumentNoDetails WHERE Loca='"+LoginManager.LocaCode+"';UPDATE dbo.DocumentNoDetails SET Temp_GVI=Temp_GVI+1 WHERE Loca='"+LoginManager.LocaCode+"'";
                DataReader = dbcon.GetReader(Sqlst);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo = Iid + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;

                }
            }
            catch
            {
                throw;
            }
        }


        public DataSet GetDs(string SqlSt)
        {
            try
            {
               return _Ds = dbcon.getDataset(SqlSt, "ds");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void UpdateGIIssue(string DocNo, string Code,decimal amount,string Type)
        {
            try
            {
                Sqlst = "EXEC dbo.gif_sp_VoucherIssueTEmpUpdate  @DocNO = @DocNO,@GiftNo = @GiftNo,@Loca = @Loca, @Iid = @Iid,@Amount=@Amount,@Type=@Type";
                 List<SqlParameter> lstPrm = new List<SqlParameter>();
                 lstPrm.Add(new SqlParameter("@DocNO", DocNo));
                 lstPrm.Add(new SqlParameter("@GiftNo", Code));
                 lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                 lstPrm.Add(new SqlParameter("@Iid", "GVI"));
                 lstPrm.Add(new SqlParameter("@Amount", amount));
                 lstPrm.Add(new SqlParameter("@Type", Type));

                dbcon.GetReader(Sqlst, lstPrm);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataSet LoadData(string DocNo)
        {
            try
            {
                Sqlst = "SELECT   ISNULL(G.BookNo,'Manual')[Doc_no],Code,CAST(TD.Amount AS DECIMAL(18,2))[Amount] FROM dbo.TransactionTemp_Details TD LEFT  JOIN dbo.gif_Voucher G ON G.VisibleCode=TD.Code WHERE TD.Doc_No=@DocNO AND TD.Loca=@Loca AND TD.Iid=@Iid;SELECT CAST( ISNULL(SUM(Amount),0) AS DECIMAL(18,2)) FROM dbo.TransactionTemp_Details WHERE Doc_No=@DocNO AND Loca=@Loca AND Iid=@Iid;";
                 List<SqlParameter> lstPrm = new List<SqlParameter>();
                 lstPrm.Add(new SqlParameter("@DocNO", DocNo));
                 lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                 lstPrm.Add(new SqlParameter("@Iid", "GVI"));

                return _Ds= dbcon.GetDataSet(Sqlst, lstPrm);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void DeleteData(string DocNo, string Code)
        {
            try
            {
                Sqlst = "DELETE FROM dbo.TransactionTemp_Details WHERE Doc_No=@DocNO AND Loca=@Loca AND Iid=@Iid and Code=@Code";

                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@DocNO", DocNo));
                lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                lstPrm.Add(new SqlParameter("@Iid", "GVI"));
                lstPrm.Add(new SqlParameter("@Code", Code));

                 dbcon.GetDataSet(Sqlst, lstPrm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet   ApplyData(string DocNo,string Date,string CustCode,string Type)
        {
            try
            {
                Sqlst = "EXEC gif_sp_VoucherIssueApply @DocNo=@DocNO, @Loca=@Loca, @Iid=@Iid,@Date=@Date,@CustCode=@CustCode,@CreateUser=@CreateUser,@Type=@Type ;";
                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@DocNO", DocNo));
                lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                lstPrm.Add(new SqlParameter("@Iid", "GVI"));
                lstPrm.Add(new SqlParameter("@Date",Date));
                lstPrm.Add(new SqlParameter("@CustCode", CustCode));
                lstPrm.Add(new SqlParameter("@CreateUser", LoginManager.UserName));
                lstPrm.Add(new SqlParameter("@Type",Type));

                return _Ds= dbcon.GetDataSet(Sqlst, lstPrm);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet RecallTopUpCard(string CardNo)
        {
            try
            {
                Sqlst = "EXEC Sp_TopUpCardRecall @CardNo=@CardNo, @Loca=@Loca";
                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@CardNo", CardNo));
                lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));

                return _Ds = dbcon.GetDataSet(Sqlst, lstPrm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ApplyTopUpCard(string DocNo,string CardNo,decimal Amount)
        {
            try
            {
                Sqlst = "EXEC Sp_TopUpCardApply @DocNO=@DocNO,@CardNo=@CardNo, @Loca=@Loca,@CreateUser=@CreateUser,@Amount=@Amount";
                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@DocNO", DocNo));
                lstPrm.Add(new SqlParameter("@CardNo", CardNo));
                lstPrm.Add(new SqlParameter("@Amount", Amount));
                lstPrm.Add(new SqlParameter("@Loca", LoginManager.LocaCode));
                lstPrm.Add(new SqlParameter("@CreateUser", LoginManager.UserName));

                return _Ds = dbcon.GetDataSet(Sqlst, lstPrm);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
