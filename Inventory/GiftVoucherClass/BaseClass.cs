using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DbConnection;

namespace Inventory
{
    public class BaseClass
    {
        private SqlDataReader sqDataReader;

        private DataSet dsGetDataSet;

        private decimal deAmount;

        private int _Error_ex;

        private Boolean blRecordFound;

        private string strExpireDate;
        private string strUserName = "Amila";
        private static string strLocaCode;
        private string strGi_Code;
        private string strLocation;
        private string strCreateUser;
        private string strCreateDate;
        private string strSqlString;
        private static string strLoginUser;
        private string strPassword;
        private string strCode_Min;
        private string strCode_Max;
        private string strVoucherType;
        private string strDataSetName;

         

        public string DataSetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }
        
        public string VoucherType
        {
            get { return strVoucherType; }
            set { strVoucherType = value; }
        }
        
        public string  CodeMin
        {
            get { return strCode_Min; }
            set { strCode_Min = value; }
        }

        public string CodeMax
        {
            get { return strCode_Max; }
            set
            {
                if (value=="")
                {
                    RecordFound = false;
                } strCode_Max = value;
            }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }
        
        public static string LoginUser
        {
            get { return strLoginUser; }
            set { strLoginUser = value; }
        }

        public int ErrorCall
        {
            get { return _Error_ex; }
            set { _Error_ex = value; }
        }

        public DataSet GetDataSet
        {
            get { return dsGetDataSet; }
            set { dsGetDataSet = value; }
        }

        public string ExpireDate
        {
            get { return strExpireDate; }
            set { strExpireDate = value; }
        }

        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        public static string LocaCode
        {
            get { return strLocaCode; }
            set { strLocaCode = value; }
        }

        public SqlDataReader DataReader
        {
            get { return sqDataReader; }
            set { sqDataReader = value; }
        }

        public decimal Amount
        {
            get { return deAmount; }
            set { deAmount = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public string Gi_Code
        {
            get { return strGi_Code; }
            set { strGi_Code = value; }
        }
     
        public string Location
        {
            get { return strLocation; }
            set { strLocation = value; }
        }

        public string CreateUser
        {
            get { return strCreateUser; }
            set { strCreateUser = value; }
        }

        public string CreateDate
        {
            get { return strCreateDate; }
            set { strCreateDate = value; }
        }

        public string SqlString
        {
            get { return strSqlString; }
            set { strSqlString = value; }
        }

        private string strBookNo;
        public string BookNo
        {
            get { return strBookNo; }
            set { strBookNo = value; }
        }
        private string  strVisibleCode;
        public string  VisibleCode
        {
            get { return strVisibleCode; }
            set { strVisibleCode = value; }
        }

        private string strTr_Date;
        public string Tr_Date
        {
            get { return strTr_Date; }
            set { strTr_Date = value; }
        }

        private string strCharacter;

        public string Character
        {
            get { return strCharacter; }
            set { strCharacter = value; }
        }
        private string strDateFrom;

        public string DateFrom
        {
            get { return strDateFrom; }
            set { strDateFrom = value; }
        }

        private string strDateTo;

        public string DateTo
        {
            get { return strDateTo; }
            set { strDateTo = value; }
        }

        private string strCodeFrom;

        public string CodeFrom
        {
            get { return strCodeFrom; }
            set { strCodeFrom = value; }
        }

        private string strCodeTo;

        public string CodeTo
        {
            get { return strCodeTo; }
            set { strCodeTo = value; }
        }

        private string strLocaDescrip;

        public string LocaDescrip
        {
            get { return strLocaDescrip; }
            set { strLocaDescrip = value; }
        }
        
      //  public decimal decQty { get; set; }
       // public string strCharecter { get; set; }
       // public string strVoucherId { get; set; }
      //  public int decId { get; set; }

     //   public string strIid { get; set; }

        #region _User Access

        private Boolean _BillwiseDiscountCard;
        private Boolean _BillwiseGiftVoucher;
        private Boolean _DiscountCard;
        private Boolean _DiscountCardReport;        
        private Boolean _DiscountCardSummery;        
        private Boolean _GiftVoucher;        
        private Boolean _GiftVoucherReport;        
        private Boolean _GiftVoucherIssuedReceivedSummery;        
        private Boolean _GiftVoucherAnalyze;        
        private Boolean _IssuedGiftVoicher;        
        private Boolean _LocationDetails;        
        private Boolean _LockedDiscountCard;        
        private Boolean _LockedGiftVoucher;        
        private Boolean _MainMenu;        
        private Boolean _PrintBarcode;        
        private Boolean _PrintDiscountCard;        
        private Boolean _PrintGiftVoucher;        
        private Boolean _PrintedGiftVoucher;        
        private Boolean _PendingGiftVoucher;        
        private Boolean _PrintedDiscountCard;        
        private Boolean _Report;        
        private Boolean _ReceivedGiftVoucher;        
        private Boolean _RedeemDiscountCard;
        private Boolean _UserProfile;
        private static Boolean _UserProfileApply;

        public static Boolean UserProfileApply
        {
            get { return _UserProfileApply; }
            set { _UserProfileApply = value; }
        }

        public Boolean DiscountCardReport //D02
        {
            get { return _DiscountCardReport; }
            set { _DiscountCardReport = value; }
        }

        public Boolean DiscountCardSummery //D03
        {
            get { return _DiscountCardSummery; }
            set { _DiscountCardSummery = value; }
        }

        public Boolean GiftVoucher //G01
        {
            get { return _GiftVoucher; }
            set { _GiftVoucher = value; }
        }

        public Boolean GiftVoucherReport //G02
        {
            get { return _GiftVoucherReport; }
            set { _GiftVoucherReport = value; }
        }

        public Boolean GiftVoucherIssuedReceivedSummery //G03
        {
            get { return _GiftVoucherIssuedReceivedSummery; }
            set { _GiftVoucherIssuedReceivedSummery = value; }
        }

        public Boolean GiftVoucherAnalyze //G04
        {
            get { return _GiftVoucherAnalyze; }
            set { _GiftVoucherAnalyze = value; }
        }

        public Boolean IssuedGiftVoicher //I01
        {
            get { return _IssuedGiftVoicher; }
            set { _IssuedGiftVoicher = value; }
        }

        public Boolean LocationDetails //L01
        {
            get { return _LocationDetails; }
            set { _LocationDetails = value; }
        }

        public Boolean LockedDiscountCard //L02
        {
            get { return _LockedDiscountCard; }
            set { _LockedDiscountCard = value; }
        }

        public Boolean LockedGiftVoucher //L03
        {
            get { return _LockedGiftVoucher; }
            set { _LockedGiftVoucher = value; }
        }

        public Boolean MainMenu //M01
        {
            get { return _MainMenu; }
            set { _MainMenu = value; }
        }

        public Boolean PrintBarcode //P01
        {
            get { return _PrintBarcode; }
            set { _PrintBarcode = value; }
        }

        public Boolean PrintDiscountCard //P02
        {
            get { return _PrintDiscountCard; }
            set { _PrintDiscountCard = value; }
        }

        public Boolean PrintGiftVoucher //P03
        {
            get { return _PrintGiftVoucher; }
            set { _PrintGiftVoucher = value; }
        }

        public Boolean PrintedGiftVoucher //P04
        {
            get { return _PrintedGiftVoucher; }
            set { _PrintedGiftVoucher = value; }
        }

        public Boolean PendingGiftVoucher //P05
        {
            get { return _PendingGiftVoucher; }
            set { _PendingGiftVoucher = value; }
        }

        public Boolean PrintedDiscountCard //P06
        {
            get { return _PrintedDiscountCard; }
            set { _PrintedDiscountCard = value; }
        }

        public Boolean Report //R01
        {
            get { return _Report; }
            set { _Report = value; }
        }

        public Boolean ReceivedGiftVoucher //R02
        {
            get { return _ReceivedGiftVoucher; }
            set { _ReceivedGiftVoucher = value; }
        }

        public Boolean RedeemDiscountCard //R03
        {
            get { return _RedeemDiscountCard; }
            set { _RedeemDiscountCard = value; }
        }

        public Boolean UserProfile //U01
        {
            get { return _UserProfile; }
            set { _UserProfile = value; }
        }

        public Boolean BillwiseGiftVoucher //B02
        {
            get { return _BillwiseGiftVoucher; }
            set { _BillwiseGiftVoucher = value; }
        }

        public Boolean DiscountCard //D01
        {
            get { return _DiscountCard; }
            set { _DiscountCard = value; }
        }

        public Boolean BillwiseDiscountCard //B01
        {
            get { return _BillwiseDiscountCard; }
            set { _BillwiseDiscountCard = value; }
        }

        private Boolean _toolStrip;

        public Boolean ToolStrip
        {
            get { return _toolStrip; }
            set { _toolStrip = value; }
        }

        private SqlDataReader Reader;
        public SqlDataReader GetReader
        {
            get { return Reader; }
            set { Reader = value; }
        }



        #endregion

        public static void ErrorFound(string ErrorMessage,string errorLocation)
        {
            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\GiftVoucher_ErrorLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'" + errorLocation + ". Error Description:- << " + ErrorMessage + " >> " + " 'User Name :' " + LoginUser.Trim() + " '");
                // read from file or write to file
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }
            MessageBox.Show(ErrorMessage, "CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

       
    }
}