using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DbConnection;

namespace clsLibrary
{
    public class clsMainClass
    {
        #region Propertys



        private string strProd_Code;
        public string Prod_Code
        {
            get { return strProd_Code; }
            set { strProd_Code = value; }
        }

        private string strProd_Name;
        public string Prod_Name
        {
            get { return strProd_Name; }
            set { strProd_Name = value; }
        }

        private string strDepa_Code;
        public string Depa_Code
        {
            get { return strDepa_Code; }
            set { strDepa_Code = value; }
        }

        private string strDepa_Name;
        public string Depa_Name
        {
            get { return strDepa_Name; }
            set { strDepa_Name = value; }
        }

        private string strCat_Code;
        public string Cat_Code
        {
            get { return strCat_Code; }
            set { strCat_Code = value; }
        }

        private string strCat_Name;
        public string Cat_Name
        {
            get { return strCat_Name; }
            set { strCat_Name = value; }
        }

        private string strSup_Code;
        public string Sup_Code
        {
            get { return strSup_Code; }
            set { strSup_Code = value; }
        }

        private string strSup_Name;
        public string Sup_Name
        {
            get { return strSup_Name; }
            set { strSup_Name = value; }
        }

        private string strBrand_Code;
        public string Brand_Code
        {
            get { return strBrand_Code; }
            set { strBrand_Code = value; }
        }

        private string strBrand_Name;
        public string Brand_Name
        {
            get { return strBrand_Name; }
            set { strBrand_Name = value; }
        }

        private string strModle;
        public string Modle
        {
            get { return strModle; }
            set { strModle = value; }
        }

        private string strColor;
        public string Color
        {
            get { return strColor; }
            set { strColor = value; }
        }

        private string strFrameNo;
        public string FrameNo
        {
            get { return strFrameNo; }
            set { strFrameNo = value; }
        }

        private string strFrameSize;
        public string FrameSize
        {
            get { return strFrameSize; }
            set { strFrameSize = value; }
        }

        private string strMeasure;
        public string Measure
        {
            get { return strMeasure; }
            set { strMeasure = value; }
        }

        private int intPack_Size;
        public int Pack_Size
        {
            get { return intPack_Size; }
            set { intPack_Size = value; }
        }

        private bool blInactive;
        public bool Inactive
        {
            get { return blInactive; }
            set { blInactive = value; }
        }

        private bool blNoMobile;
        public bool NoMobile
        {
            get { return blNoMobile; }
            set { blNoMobile = value; }
        }

        private decimal dePurchase_Price;
        public decimal Purchase_Price
        {
            get { return dePurchase_Price; }
            set { dePurchase_Price = value; }
        }

        private decimal deSelling_Price;
        public decimal Selling_Price
        {
            get { return deSelling_Price; }
            set { deSelling_Price = value; }
        }

        private decimal dePointRate;
        public decimal PointRate
        {
            get { return dePointRate; }
            set { dePointRate = value; }
        }


        private byte byImage;
        public byte Image
        {
            get { return byImage; }
            set { byImage = value; }
        }

        private string strInsertUser;
        public string InsertUser
        {
            get { return strInsertUser; }
            set { strInsertUser = value; }
        }

        private string strModUser;
        public string ModUser
        {
            get { return strModUser; }
            set { strModUser = value; }
        }

        private SqlDataReader _reader;
        public SqlDataReader Reader
        {
            get { return _reader; }
            set { _reader = value; }
        }

        private DataSet _dataset;
        public DataSet dataset
        {
            get { return _dataset; }
            set { _dataset = value; }
        }

        private static DataSet dsSearch;
        public static DataSet SearchDataset
        {
            get { return dsSearch; }
            set { dsSearch = value; }
        }

        public void getDataReaderbaseURL(string baseURL)
        {
            try
            {
                _reader = getReader(baseURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static string cntFocus;
        public static string Cnt_Focus
        {
            get { return cntFocus; }
            set { cntFocus = value; }
        }

        private static string cntDescrip;
        public static string Cnt_Descrip
        {
            get { return cntDescrip; }
            set { cntDescrip = value; }
        }

        private byte[] by_ProdImage;
        public byte[] ProdImage
        {
            get { return by_ProdImage; }
            set { by_ProdImage = value; }
        }

        private static int intTimeOut = 500;
        public static int TimeOut
        {
            get { return intTimeOut; }
            set { intTimeOut = value; }
        }

        private string strUserName;
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        private string strCusCode;
        public string CusCode
        {
            get { return strCusCode; }
            set { strCusCode = value; }
        }

        private decimal decCommRate;
        public decimal CommRate
        {
            get { return decCommRate; }
            set { decCommRate = value; }
        }

        private string strCusName;
        public string CusName
        {
            get { return strCusName; }
            set { strCusName = value; }
        }

        private string strAddress1;
        public string Address1
        {
            get { return strAddress1; }
            set { strAddress1 = value; }
        }

        private string strAddress2;
        public string Address2
        {
            get { return strAddress2; }
            set { strAddress2 = value; }
        }

        private string strAddress3;
        public string Address3
        {
            get { return strAddress3; }
            set { strAddress3 = value; }
        }

        private string strAddress4;
        public string Address4
        {
            get { return strAddress4; }
            set { strAddress4 = value; }
        }

        private string strAddress5;
        public string Address5
        {
            get { return strAddress5; }
            set { strAddress5 = value; }
        }

        private string strPhoneNumber;
        public string PhoneNumber
        {
            get { return strPhoneNumber; }
            set { strPhoneNumber = value; }
        }

        private string strFax;
        public string Fax
        {
            get { return strFax; }
            set { strFax = value; }
        }

        private  string strMobile;
        public  string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
        }

        private static string strMobileN;
        public static string MobileN
        {
            get { return strMobileN; }
            set { strMobileN = value; }
        }

        private string strOfficePhone;
        public string OfficePhone
        {
            get { return strOfficePhone; }
            set { strOfficePhone = value; }
        }

        private string strOther;
        public string Other
        {
            get { return strOther; }
            set { strOther = value; }
        }

        private string strContactPersion;
        public string ContactPersion
        {
            get { return strContactPersion; }
            set { strContactPersion = value; }
        }

        private string strEmail;
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        private string strWeb;
        public string Web
        {
            get { return strWeb; }
            set { strWeb = value; }
        }

        private string strNICNumber;
        public string NICNumber
        {
            get { return strNICNumber; }
            set { strNICNumber = value; }
        }

        private string strVatNumber;
        public string VatNumber
        {
            get { return strVatNumber; }
            set { strVatNumber = value; }
        }

        private string intACNo;
        public string ACNo
        {
            get { return intACNo; }
            set { intACNo = value; }
        }

        private string strBank;
        public string Bank
        {
            get { return strBank; }
            set { strBank = value; }
        }

        private string strBranch;
        public string Branch
        {
            get { return strBranch; }
            set { strBranch = value; }
        }

        private string strDoc_No;
        public string Doc_No
        {
            get { return strDoc_No; }
            set { strDoc_No = value; }
        }

        private string strloca;
        public string Loca
        {
            get { return strloca; }
            set { strloca = value; }
        }

        private string strIid;
        public string Iid
        {
            get { return strIid; }
            set { strIid = value; }
        }

        private double dblQty;
        public double Qty
        {
            get { return dblQty; }
            set { dblQty = value; }
        }

        private decimal decDiscount;
        public decimal Discount
        {
            get { return decDiscount; }
            set { decDiscount = value; }
        }

        private string strInvoiceNo;
        public string InvoiceNo
        {
            get { return strInvoiceNo; }
            set { strInvoiceNo = value; }
        }

        private string strPoNo;
        public string PoNo
        {
            get { return strPoNo; }
            set { strPoNo = value; }
        }

        private decimal decInvoiceAmount;
        public decimal InvoiveAmount
        {
            get { return decInvoiceAmount; }
            set { decInvoiceAmount = value; }
        }

        private string strInvoiceDate;
        public string InvoiceDate
        {
            get { return strInvoiceDate; }
            set { strInvoiceDate = value; }
        }

        private string strCostCode;
        public string CostCode
        {
            get { return strCostCode; }
            set { strCostCode = value; }
        }

        private string strReferance;
        public string Referance
        {
            get { return strReferance; }
            set { strReferance = value; }
        }

        private string strRSph;
        public string RSph
        {
            get { return strRSph; }
            set { strRSph = value; }
        }

        private string strRCyl;
        public string RCyl
        {
            get { return strRCyl; }
            set { strRCyl = value; }
        }

        private string strRAxis;
        public string RAxis
        {
            get { return strRAxis; }
            set { strRAxis = value; }
        }

        private string strRV_A;
        public string RV_A
        {
            get { return strRV_A; }
            set { strRV_A = value; }
        }

        private string strRBase;
        public string RBase
        {
            get { return strRBase; }
            set { strRBase = value; }
        }

        private string strPd_Ncd;
        public string Pd_Ncd
        {
            get { return strPd_Ncd; }
            set { strPd_Ncd = value; }
        }

        private string strRDec;
        public string RDec
        {
            get { return strRDec; }
            set { strRDec = value; }
        }

        private string strRHt;
        public string RHt
        {
            get { return strRHt; }
            set { strRHt = value; }
        }

        private string strLSph;
        public string LSph
        {
            get { return strLSph; }
            set { strLSph = value; }
        }

        private string strLCyl;
        public string LCyl
        {
            get { return strLCyl; }
            set { strLCyl = value; }
        }

        private string strLAxis;
        public string LAxis
        {
            get { return strLAxis; }
            set { strLAxis = value; }
        }

        private string strLV_A;
        public string LV_A
        {
            get { return strLV_A; }
            set { strLV_A = value; }
        }

        private string strLBase;
        public string LBase
        {
            get { return strLBase; }
            set { strLBase = value; }
        }

        private string strLDec;
        public string LDec
        {
            get { return strLDec; }
            set { strLDec = value; }
        }
        
        private string strLHt;
        public string LHt
        {
            get { return strLHt; }
            set { strLHt = value; }
        }

        private string strDoctor;
        public string Doctor
        {
            get { return strDoctor; }
            set { strDoctor = value; }
        }

        private string strAdditional;
        public string Additional
        {
            get { return strAdditional; }
            set { strAdditional = value; }
        }

        private string strBirthday;
        public string Birthday
        {
            get { return strBirthday; }
            set { strBirthday = value; }
        }

        private string strCustomerType;
        public string CustomerType
        {
            get { return strCustomerType; }
            set { strCustomerType = value; }
        }

        private decimal decAdvance;
        public decimal Advance
        {
            get { return decAdvance; }
            set { decAdvance = value; }
        }

        private string strCollectDate;
        public string CollectDate
        {
            get { return strCollectDate; }
            set { strCollectDate = value; }
        }

        private string strDueDate;
        public string DueDate
        {
            get { return strDueDate; }
            set { strDueDate = value; }
        }

        private string strLenesColor;
        public string LenesColor
        {
            get { return strLenesColor; }
            set { strLenesColor = value; }
        }

        private string strLocaName;
        public string LocaName
        {
            get { return strLocaName; }
            set { strLocaName = value; }
        }

        private string strTaxId;
        public string TaxId
        {
            get { return strTaxId; }
            set { strTaxId = value; }
        }

        private string steCompanyRegNo;
        public string CompanyRegNo
        {
            get { return steCompanyRegNo; }
            set { steCompanyRegNo = value; }
        }

        private string strCountry;
        public string Country
        {
            get { return strCountry; }
            set { strCountry = value; }
        }

        private string strAge;
        public string Age
        {
            get { return strAge; }
            set { strAge = value; }
        }

        private bool blWesak;
        public bool Wesak
        {
            get { return blWesak; }
            set { blWesak = value; }
        }

        private bool blAbroad;
        public bool Abroad
        {
            get { return blAbroad; }
            set { blAbroad = value; }
        }

        private bool blNewYear;
        public bool NewYear
        {
            get { return blNewYear; }
            set { blNewYear = value; }
        }

        private bool blSendBirthday;
        public bool SendBirthday
        {
            get { return blSendBirthday; }
            set { blSendBirthday = value; }
        }

        private string _Card_No;
        public string Card_No
        {
            get { return _Card_No; }
            set { _Card_No = value; }
        }

        private string _Focuseds;
        public string Focuseds
        {
            get { return _Focuseds; }
            set { _Focuseds = value; }
        }
        private string  _SqlStatement;
        public string  SqlStatement
        {
            get { return _SqlStatement; }
            set { _SqlStatement = value; }
        }

        private Boolean b1RecordFoud;
        public Boolean RecordFound
        {
            get { return b1RecordFoud; }
            set { b1RecordFoud = value; }
        }

        private string strPostDate;
        public string PostDate
        {
            get { return strPostDate; }
            set { strPostDate = value; }
        }

        private string strFirstName;
        public string FirstName
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }

        private string strSecondName;
        public string SecondName
        {
            get { return strSecondName; }
            set { strSecondName = value; }
        }

        private string strOccupation;
        public string Occupation
        {
            get { return strOccupation; }
            set { strOccupation = value; }
        }

        private string strMaritalStatus;
        public string MaritalStatus
        {
            get { return strMaritalStatus; }
            set { strMaritalStatus = value; }
        }

        private string strCardIssueDate;
        public string CardIssueDate
        {
            get { return strCardIssueDate; }
            set { strCardIssueDate = value; }
        }

        private string strSpouseBDay;
        public string SpouseBDay
        {
            get { return strSpouseBDay; }
            set { strSpouseBDay = value; }
        }

        private string strGroupCode;
        public string GroupCode
        {
            get { return strGroupCode; }
            set { strGroupCode = value; }
        }

        private string strGroupName;
        public string GroupName
        {
            get { return strGroupName; }
            set { strGroupName = value; }
        }

        private string strSubGroupCode;
        public string SubGroupCode
        {
            get { return strSubGroupCode; }
            set { strSubGroupCode = value; }
        }

        private string strSubGroupName;
        public string SubGroupName
        {
            get { return strSubGroupName; }
            set { strSubGroupName = value; }
        }

        private string strAnniversary;
        public string Anniversary
        {
            get { return strAnniversary; }
            set { strAnniversary = value; }
        }

        private string strCustCategory;

        public string CustCategory
        {
            get { return strCustCategory; }
            set { strCustCategory = value; }
        }



       

     

        #region Statics

        private static string strLoginLocaCode;
        public static string LoginLocaCode
        {
            get { return strLoginLocaCode; }
            set { strLoginLocaCode = value; }
        }

        private static string strLoginLocaName;
        public static string LoginLocaName
        {
            get { return strLoginLocaName; }
            set { strLoginLocaName = value; }
        }

        private static string strLoginUser;
        public static string LoginUser
        {
            get { return strLoginUser; }
            set { strLoginUser = value; }
        }

        bool _blRecordFound;
        public bool blRecordFound
        {
            get { return _blRecordFound; }
            set { _blRecordFound = value; }
        }
        decimal _decLen;
        public decimal decLen {
            get { return _decLen; }
            set { _decLen = value; } 
        }
        bool _decGenCod;
        public bool decGenCod {
            get { return _decGenCod; }
            set { _decGenCod = value; } 
        
        }



        #endregion

        #endregion

        //private static string strServer;
        //public static string Server
        //{
        //    get { return strServer; }
        //    set { strServer = value; }
        //}

        //private static string strDBName;
        //public static string DBName
        //{
        //    get { return strDBName; }
        //    set { strDBName = value; }
        //}

        //private static string strUser;
        //public static string User
        //{
        //    get { return strUser; }
        //    set { strUser = value; }
        //}

        //private static string strPassword;
        //public static string Password
        //{
        //    get { return strPassword; }
        //    set { strPassword = value; }
        //}

        public SqlCommand command = null;
        public SqlDataReader reader = null;
        public SqlDataAdapter adapter = null;
        public DataSet ds = new DataSet("DailyDetails");

        public SqlDataReader getReader(string query)
        {
            CloseReaderAndConnection();
            SqlCommand comm = new SqlCommand(query, dbcon.connection);
            SqlDataReader reader;
            if (dbcon.connection.State != ConnectionState.Open)
            {
                dbcon.connection.Open();
            }
            reader = comm.ExecuteReader();
            return reader;
        }

        public DataSet getDataSet(string query, string dataSetName)
        {
            CloseReaderAndConnection();
            DataSet ds = new DataSet();
            if (dbcon.connection.State != ConnectionState.Open)
            {
                dbcon.connection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, dbcon.connection);
            da.Fill(ds, dataSetName);
            dbcon.connection.Close();
            ds.Dispose();
            return ds;
        }

        public DataSet getDataSet(string query)
        {
            CloseReaderAndConnection();
            DataSet ds = new DataSet();
            if (dbcon.connection.State != ConnectionState.Open)
            {
                dbcon.connection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, dbcon.connection);
            da.Fill(ds);
            dbcon.connection.Close();
            ds.Dispose();
            return ds;
        }

        public void Retrieve(string query)
        {
            Reader = getReader(query);
        }

        public void GetStoredProcedure(string SpName, object[,] Values, string dsName)
        {
            try
            {
                CloseReaderAndConnection();
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand(SpName, dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();

                for (int i = 0; i < Values.GetLength(0); i++)
                {
                    command.Parameters.Add(new SqlParameter(Values[i, 0].ToString(), Values[i, 1]));
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataset = new DataSet(), dsName);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void GetStoredProcedure(string SpName, object[,] Values)
        {
            try
            {
                CloseReaderAndConnection();
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand(SpName, dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = TimeOut;
                command.Parameters.Clear();
                for (int i = 0; i < Values.GetLength(0); i++)
                {
                    command.Parameters.Add(new SqlParameter(Values[i, 0].ToString(), Values[i, 1]));
                }
                command.ExecuteNonQuery();
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void CloseReaderAndConnection()
        {
            dbcon.connection.Close();
           
            if (Reader != null)
            {
                Reader.Close();
            }
        }

        public static void ErrMessage(string error, string errorLocation)
        {
            for (int i = 0; i < errorLocation.Length; i++)
            {
                int a = errorLocation.IndexOf(" at ");
                if (i != 10 && a >= 0)
                {
                    errorLocation = errorLocation.Remove(0, a + 3);
                    a = -3;
                }
            }

            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
               m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Error Location  : " + errorLocation + ".   Error Description  :" + error.ToString() + " 'Location :'" +LoginManager.LocaCode + "'User Name :'" + LoginManager.UserName+ "'");
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }
            MessageBox.Show(error.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void connection(string Server, string DBName, string User, string Password)
        {
            dbcon.connection = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + DBName + ";User ID=" + User + "; password=" + Password + "");
        }

        public bool CanOpenConnection()
        {
            try
            {
                dbcon.connection.Open();
                dbcon.connection.Close();
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public void Open()
        {
            dbcon.connection.Open();
        }

        public void Cloce()
        {
            dbcon.connection.Close();
        }

        public void CustomerTransaction(string customer)
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_CustomerTransaction", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Cus_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, customer));
                //command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataset = new DataSet(), "PendingOrder");
            }
            finally
            {
                dbcon.connection.Close();
            }

        }

        public void InsertSelected()
        {
            
        }

        public void getDataReader(string SqlStatement)
        {
            try
            { 
                _reader = getReader(SqlStatement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void getDataset(string sqlStatement, string dsName)
        {
            try
            {
                _dataset = getDataSet(sqlStatement, dsName);
            }
            catch (Exception ex)
            {

            }
        }


        //Method for Numeric values only
        public void CheckNumeric(KeyPressEventArgs e, string txtValue)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                decimal Value;
                e.Handled = !decimal.TryParse(txtValue + e.KeyChar, out Value);
            }
        }


        public void ReadCRM()
        {
            try
            {
                _reader = dbcon.GetReader(SqlStatement);
                blRecordFound = false;
                if (_reader.Read())
                {
                    decLen = decimal.Parse(_reader["CodeLength"].ToString());
                    decGenCod = bool.Parse(_reader["GenerateCodeAutomatically"].ToString());
                    blRecordFound = true;
                }
                else
                {
                    decLen = 0;
                    decGenCod = false;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            { 
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsPurchaseOrder 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                   
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbcon.CloseReader();
                _reader.Dispose();
            }
        }


    }
}