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
    public class clsProduct:clsPublic
    {
        #region General Declarations

        private string strCode;
        private string strDescript;
        private string strShort_Description;
        private string strBarcode;
        private string strDepartment;
        private string strDeptName;
        private string strCategory;
        private string strCatName;
        private string strSupplier;
        private string strSuppName;
        private string strManufacturer;
        private string strManufacuturerName;
        private string strBrandCode;
        private string strBrandName;
        private string strPurchasePrice;
        private string strSellingPrice;
        private string strDiscountPrice;
        private string strWholePrice;
        private string strMarkedPrice;
        private string strLastPurchasePrice;
        private string strCurPurPrice;
        private string strAvarage_Cost;
        private string strCostCode;
        private string strReorderLevel;
        private string strUnit;
        private string strPurchaseDate;
        private string strModified_Date;
        private string strLockedItem;
        private string strDisc_Str;
        private string strCreated_User;
        private string strModified_User;
        private string strRack_No;
        private string strNextProductCode;
        private string strMargine;
        private string strProdImagePath;
        private string strLocaCode;
        private string strLocaName;

        private string strPre_Purchase_price;
        private string strPre_Selling_Price;

        private decimal fltReorderQty;
        private decimal fltCurrentQty;
        private decimal fltLast_Purch_Qty;
        private decimal fltLocaROL;
        private decimal fltLocaReQty;

        private int intPackSize;
        private string  strCount_False;

        private SqlDataReader DataReader;

        private int intErrCode;
        private string strMessage;
        private string strSqlString;

        private Boolean blCreditBilling;
        private Boolean blRecordFound;
        private Boolean blPriceLevelFound;

        private byte[] bytProductImage;
        #endregion

        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds1 = new DataSet();
        private DataSet dsLocationROL;

        private bool blMinusAllow;
        private bool blUnderCost;
        private decimal flPackQty;

        public bool MinusAllow
        {
            get { return blMinusAllow; }
            set { blMinusAllow = value; }
        }

        public bool UnderCost
        {
            get { return blUnderCost; }
            set { blUnderCost = value; }
        }

        public decimal PackQty
        {
            get { return flPackQty; }
            set { flPackQty = value; }
        }
        // Added By Nipuni - 2024.03.28
        private bool blPointsAllow;
        public bool PointsAllow
        {
            get { return blPointsAllow; }
            set { blPointsAllow = value; }
        }
        // Added By Nipuni - 2024.03.28
        private decimal nServiceTime;
        public decimal ServiceTime
        {
            get { return nServiceTime; }
            set { nServiceTime = value; }
        }
        public bool SerialAllow { get; set; }
        public bool warrentyAllow { get; set; }
        public bool InstallChargeAllow { get; set; }
        public string WarrentyPeriod { get; set; }
        public decimal InstallChargePer { get; set; }
        public decimal InstallCharge { get; set; }

        #region Properties  
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        public string Descript
        {
            get { return strDescript; }
            set { strDescript = value; }
        }

        public string Short_Description
        {
            get { return strShort_Description; }
            set { strShort_Description = value; }
        }

        public string Barcode
        {
            get { return strBarcode; }
            set { strBarcode = value; }
        }

        public string Department
        {
            get { return strDepartment; }
            set { strDepartment = value; }
        }

        public string DepartmentName
        {
            get { return strDeptName; }
            set { strDeptName = value; }
        }

        public string Category
        {
            get { return strCategory; }
            set { strCategory = value; }
        }

        public string CategoryName
        {
            get { return strCatName; }
            set { strCatName = value; }
        }

        public string Supplier
        {
            get { return strSupplier; }
            set { strSupplier = value; }
        }

        public string SupplierName
        {
            get { return strSuppName; }
            set { strSuppName = value; }
        }

        public string Manufacturer
        {
            get { return strManufacturer; }
            set { strManufacturer = value; }
        }

        public string ManufacturerName
        {
            get { return strManufacuturerName; }
            set { strManufacuturerName = value; }
        }

        public string BrandCode
        {
            get { return strBrandCode; }
            set { strBrandCode = value; }
        }

        public string BrandName
        {
            get { return strBrandName; }
            set { strBrandName = value; }
        }

        public string PurchaseDate
        {
            get { return strPurchaseDate; }
            set { strPurchaseDate = value; }
        }

        public string Modified_Date
        {
            get { return strModified_Date; }
            set { strModified_Date = value; }
        }

        public string Purchaseprice
        {
            get { return strPurchasePrice; }
            set { strPurchasePrice = value; }
        }

        public string MarkedPrice
        {
            get { return strMarkedPrice; }
            set { strMarkedPrice = value; }
        }

        public string LastPurchasePrice
        {
            get { return strLastPurchasePrice; }
            set { strLastPurchasePrice = value; }
        }

        public string DiscountPrice
        {
            get { return strDiscountPrice; }
            set { strDiscountPrice = value; }
        }

        public string WholePrice
        {
            get { return strWholePrice; }
            set { strWholePrice = value; }
        }

        public string Avarage_Cost
        {
            get { return strAvarage_Cost; }
            set { strAvarage_Cost = value; }
        }

        public string SellingPrice
        {
            get { return strSellingPrice; }
            set { strSellingPrice = value; }
        }

        public string CostCode
        {
            get { return strCostCode; }
            set { strCostCode = value; }
        }

        public string Margine
        {
            get { return strMargine; }
            set { strMargine = value; }
        }

        public string Reorderlevel
        {
            get { return strReorderLevel; }
            set { strReorderLevel = value; }
        }

        public string Unit
        {
            get { return strUnit; }
            set { strUnit = value; }
        }

        public string Disc_Str
        {
            get { return strDisc_Str; }
            set { strDisc_Str = value; }
        }

        public decimal ReorderQty
        {
            get { return fltReorderQty; }
            set { fltReorderQty = value; }
        }

        public decimal CurrentQty
        {
            get { return fltCurrentQty; }
            set { fltCurrentQty = value; }
        }

        public decimal Last_Purch_Qty
        {
            get { return fltLast_Purch_Qty; }
            set { fltLast_Purch_Qty = value; }
        }

        public decimal LocaROL
        {
            get { return fltLocaROL; }
            set { fltLocaROL = value; }
        }

        public decimal LocaReQty
        {
            get { return fltLocaReQty; }
            set { fltLocaReQty = value; }
        }

        public int PackSize
        {
            get { return intPackSize; }
            set { intPackSize = value; }
        }

        public string Rack_No
        {
            get { return strRack_No; }
            set { strRack_No = value; }
        }

        public string NextProductCode
        {
            get { return strNextProductCode; }
            set { strNextProductCode = value; }
        }

        public string SqlString
        {
            get { return strSqlString; }
            set { strSqlString = value; }
        }

        public string LocaCode
        {
            get { return strLocaCode; }
            set { strLocaCode = value; }
        }

        public string LocaName
        {
            get { return strLocaName; }
            set { strLocaName = value; }
        }

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public DataSet GetDataset1
        {
            get { return ds1; }
            set { ds1 = value; }
        }

        public DataSet TempLocationROL
        {
            get { return dsLocationROL; }
            set { dsLocationROL = value; }
        }

        public string LockedItem
        {
            get { return strLockedItem; }
            set { strLockedItem = value; }
        }

        public string Created_User
        {
            get { return strCreated_User; }
            set { strCreated_User = value; }
        }

        public string Modified_User
        {
            get { return strModified_User; }
            set { strModified_User = value; }
        }

        public bool RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public bool PriceLevelFound
        {
            get { return blPriceLevelFound; }
            set { blPriceLevelFound = value; }
        }

        public Boolean CreditBilling
        {
            get { return blCreditBilling; }
            set { blCreditBilling = value; }
        }

        public string  ProdImagePath
        {
            get { return strProdImagePath; }
            set { strProdImagePath = value; }
        }

        public byte[] ProductImage
        {
            get { return bytProductImage; }
            set { bytProductImage = value; }
        }

        public string Count_False
        {
            get { return strCount_False; }
            set { strCount_False = value; }
        }

        private string _SinghalaDescription;

        public string SinghalaDescription
        {
            get { return _SinghalaDescription; }
            set { _SinghalaDescription = value; }
        }

        private bool _Abs;
        public bool Abs
        {
            get { return _Abs; }
            set { _Abs = value; }
        }


        private SqlDataReader _Dr;
        public SqlDataReader Dr
        {
            get { return _Dr; }
            set { _Dr = value; }
        }

        private bool _ScaleProd;
        public bool ScaleProd
        {
            get { return _ScaleProd; }
            set { _ScaleProd = value; }
        }

        private string strDisCountNotAllow;

        public string _strDisCountNotAllow
        {
            get { return strDisCountNotAllow; }
            set { strDisCountNotAllow = value; }
        }

        private bool blExpireItem;
        public bool _blExpireItem
        {
            get { return blExpireItem; }
            set { blExpireItem = value; }
        }
        private bool blVatProd;
        public bool _blVatProd
        {
            get { return blVatProd; }
            set { blVatProd = value; }
        }

        private bool blBundleProd;
        public bool _blBundleProd
        {
            get { return blBundleProd; }
            set { blBundleProd = value; }
        }

        private string strGrnDate;
         public string GrnDate
        {
            get { return strGrnDate; }
            set { strGrnDate = value; }
        }

        private decimal DecGrnQty;
        public decimal GrnQty
        {
            get { return DecGrnQty; }
            set { DecGrnQty = value; }
        }
        private bool blRecallGRN;
        public bool RecallGRN
        {
            get { return blRecallGRN; }
            set { blRecallGRN = value; }
        }

        private string strSubCatCode;
        public string  SubCatCode
        {
            get { return strSubCatCode; }
            set { strSubCatCode = value; }
        }

        private bool blPktProd;
        public bool PacketingProd
        {
            get { return blPktProd; }
            set { blPktProd = value; }
        }
        public string MinimumPrice{ get; set; }
        #endregion

        public bool FreeIsue { get; set; }
        public bool OGF { get; set; }
        public bool BatchPUpdate { get; set; }

        private bool blServiceItem;
        private bool blRentitem;
        public bool ServiceItem
        {
            get { return blServiceItem; }
            set { blServiceItem = value; }
        }

        public bool Rentitem
        {
            get { return blRentitem; }
            set { blRentitem = value; }
        }

        public void newReader()
        {
            try
            {
                _Dr = dbcon.GetReader(strSqlString);


            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region // Method for INSERT & UPDATE
        public void UpdateData()
        {
            try
            {
                if (strCurPurPrice != strPurchasePrice && strCurPurPrice != "" && strCurPurPrice != null)
                {
                    strLastPurchasePrice = strCurPurPrice;
                }
                else
                {
                    strLastPurchasePrice = strPurchasePrice;
                }

                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Code));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Descript));
                command.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Short_Description));
                command.Parameters.Add(new SqlParameter("@Barcode", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Barcode));
                command.Parameters.Add(new SqlParameter("@Department_Id", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Department));
                command.Parameters.Add(new SqlParameter("@Category_Id", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Category));
                command.Parameters.Add(new SqlParameter("@Supplier_Id", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Supplier));
                //command.Parameters.Add(new SqlParameter("@Manufacturer_Id", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Manufacturer));
                command.Parameters.Add(new SqlParameter("@BrandCode", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BrandCode));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Purchaseprice));
                command.Parameters.Add(new SqlParameter("@Marked_Price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MarkedPrice));
                command.Parameters.Add(new SqlParameter("@Selling_Price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SellingPrice));
                command.Parameters.Add(new SqlParameter("@Last_Pur_Price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LastPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Disc_Price", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DiscountPrice));
                command.Parameters.Add(new SqlParameter("@Whole_Price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, WholePrice));
                command.Parameters.Add(new SqlParameter("@Reorder_Level", SqlDbType.Decimal, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Reorderlevel));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Unit));
                command.Parameters.Add(new SqlParameter("@Reorder_Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ReorderQty));
                command.Parameters.Add(new SqlParameter("@Rack_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rack_No));
                command.Parameters.Add(new SqlParameter("@Pack_Size", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PackSize));
                command.Parameters.Add(new SqlParameter("@Discontinued", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@LockedItem", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LockedItem));
                command.Parameters.Add(new SqlParameter("@Disc_Str", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Disc_Str));
                command.Parameters.Add(new SqlParameter("@Cost_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CostCode));
                command.Parameters.Add(new SqlParameter("@Margine", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Margine));
                command.Parameters.Add(new SqlParameter("@Prod_Image", SqlDbType.Image, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Default, (object)bytProductImage));
                //command.Parameters.Add(new SqlParameter("@Count_False", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Count_False));
                command.Parameters.Add(new SqlParameter("@CreditBilling", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CreditBilling));
                command.Parameters.Add(new SqlParameter("@MinusAllow", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MinusAllow));
                command.Parameters.Add(new SqlParameter("@UnderCost", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, UnderCost));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                command.Parameters.Add(new SqlParameter("@PackQty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PackQty));
                command.Parameters.Add(new SqlParameter("@Singhala", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SinghalaDescription));
                command.Parameters.Add(new SqlParameter("@PointsAllow", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PointsAllow));
                command.Parameters.Add(new SqlParameter("@Loose", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _Abs));
                command.Parameters.Add(new SqlParameter("@ScaleProd", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _ScaleProd));
                command.Parameters.Add(new SqlParameter("@DiscountNotAllow", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisCountNotAllow));
                command.Parameters.Add(new SqlParameter("@ExpireItem", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, blExpireItem));
                command.Parameters.Add(new SqlParameter("@VatProd", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, blVatProd));
                command.Parameters.Add(new SqlParameter("@Bundle", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, blBundleProd));
                command.Parameters.Add(new SqlParameter("@MinimumPrice", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MinimumPrice));
                
                command.Parameters.Add(new SqlParameter("@GRNQty", DecGrnQty));
                command.Parameters.Add(new SqlParameter("@GRNDate", strGrnDate));
                command.Parameters.Add(new SqlParameter("@GRNRecalled", blRecallGRN));
                command.Parameters.Add(new SqlParameter("@PacketProd", blPktProd));
                command.Parameters.Add(new SqlParameter("@FreeIssue", FreeIsue));
                command.Parameters.Add(new SqlParameter("@OGF", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OGF));
                command.Parameters.Add(new SqlParameter("@BatchPUpdate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BatchPUpdate));

                command.Parameters.Add(new SqlParameter("@WarrentyAllow", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, warrentyAllow));
                command.Parameters.Add(new SqlParameter("@SerialAllow", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SerialAllow));
                command.Parameters.Add(new SqlParameter("@InstallChargeAllow", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InstallChargeAllow));

                command.Parameters.Add(new SqlParameter("@warrenty", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, WarrentyPeriod));
                command.Parameters.Add(new SqlParameter("@InstallCharge", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InstallCharge));
                command.Parameters.Add(new SqlParameter("@InstallChargePer", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InstallChargePer));
                
                // Added By Nipuni - 2024.03.28
                command.Parameters.Add(new SqlParameter("@ServiceItem", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceItem));
                command.Parameters.Add(new SqlParameter("@ServiceTime", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceTime));
                command.Parameters.Add(new SqlParameter("@Rentitem", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,Rentitem));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                dbcon.connection.Close();
                if (intErrCode == 0)
                {
                    MessageBox.Show("Record updated successfully", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error in Transaction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
        public void PriceChange()
        {
            try
            {
                //Insert Record for the Price change table

                if (decimal.Parse(strPre_Purchase_price) != decimal.Parse(strPurchasePrice) || decimal.Parse(strPre_Selling_Price) != decimal.Parse(strSellingPrice))
                {
                    intErrCode = 0;
                    dbcon.OpenConnection();
                    SqlCommand commandX = new SqlCommand();
                    commandX.Connection = dbcon.connection;
                    commandX.CommandType = CommandType.StoredProcedure;
                    commandX.CommandText = "spProductPriceChange";
                    commandX.CommandTimeout = LoginSys.dbocommTimeOut;
                    commandX.Parameters.Clear();
                    commandX.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    commandX.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                    commandX.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDescript));
                    commandX.Parameters.Add(new SqlParameter("@Pre_Purchase_price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPre_Purchase_price));
                    commandX.Parameters.Add(new SqlParameter("@New_Purchase_price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPurchasePrice));
                    commandX.Parameters.Add(new SqlParameter("@Pre_Selling_Price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPre_Selling_Price));
                    commandX.Parameters.Add(new SqlParameter("@New_Selling_Price", SqlDbType.Money, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSellingPrice));
                    commandX.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                    commandX.ExecuteNonQuery();
                    commandX.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    ErrorCode = (int)(commandX.Parameters["@Err_x"].Value);
                    dbcon.connection.Close();
                }
                //****************************************
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
        #endregion  

        #region //Method for DELETE
        public void DeleteData()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                strMessage = (string)(command.Parameters["@getMessage"].Value);
                dbcon.connection.Close();
                if (intErrCode != 0)
                {
                    MessageBox.Show("an internal error has occurred while deleting the current record", "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
            MessageBox.Show(strMessage.ToString(), "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

        #region //Retrive Product CODE
        public void GetProductDetails()
        {
            try
            {
                Byte[] byteBLOBData =  new Byte[0];

                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strCode = DataReader["Prod_Code"].ToString().Trim();
                    strDescript = DataReader["Prod_Name"].ToString().Trim();
                    strShort_Description = DataReader["Short_Description"].ToString().Trim();
                    strBarcode = DataReader["Barcode"].ToString().Trim();
                    strDepartment = DataReader["Department_Id"].ToString().Trim();
                    strCategory = DataReader["Category_Id"].ToString().Trim();
                    strSupplier = DataReader["Supplier_Id"].ToString().Trim();
                    strPurchasePrice = DataReader["Purchase_price"].ToString();
                    strPre_Purchase_price = DataReader["Purchase_price"].ToString();
                    strCurPurPrice = DataReader["Purchase_price"].ToString();
                    strAvarage_Cost = DataReader["Avarage_Cost"].ToString();
                    strMarkedPrice = DataReader["Marked_Price"].ToString();
                    strSellingPrice = DataReader["Selling_Price"].ToString();
                    strPre_Selling_Price = DataReader["Selling_Price"].ToString();
                    strLastPurchasePrice = DataReader["Last_Pur_Price"].ToString();
                    strDiscountPrice = DataReader["Disc_Price"].ToString();
                    strWholePrice = DataReader["Whole_Price"].ToString();
                    strReorderLevel = DataReader["Reorder_Level"].ToString();
                    strPurchaseDate = DataReader["Purchased_Date"].ToString();
                    MinimumPrice = DataReader["MinimumPrice"].ToString();
                    strModified_Date = DataReader["Modified_Date"].ToString();
                    strLockedItem = DataReader["LockedItem"].ToString().Trim();
                    fltLast_Purch_Qty = (decimal)DataReader.GetSqlDecimal(13);
                    strUnit = DataReader["Unit"].ToString();
                    fltReorderQty = (decimal)DataReader.GetSqlDecimal(16);
                    strRack_No = DataReader["Rack_No"].ToString().Trim();
                    intPackSize = (int)DataReader.GetSqlInt16(18);
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(26);
                    strDisc_Str = DataReader["Disc_Str"].ToString().Trim();
                    strCostCode = DataReader["Cost_Code"].ToString().Trim();
                    strCreated_User = DataReader["Created_User"].ToString().Trim();
                    strModified_User = DataReader["Modified_User"].ToString().Trim();
                    strMargine = DataReader["Margine"].ToString().Trim();
                    strBrandCode = DataReader["Brand_Code"].ToString().Trim();
                    strCount_False = DataReader["Count_False"].ToString().Trim();
                    CreditBilling = (bool)DataReader["CreditBilling"];
                    MinusAllow = (bool)DataReader["MinusAllow"];
                    UnderCost = (bool)DataReader["UnderCost"];
                    PackQty = decimal.Parse(DataReader["PackQty"].ToString());
                    _SinghalaDescription = DataReader["Singhala"].ToString();
                    PointsAllow = (bool)DataReader["Disc_App"];
                    _Abs = (bool)DataReader["Loose"];
                    _ScaleProd = (bool)DataReader["Scale"];
                    strDisCountNotAllow = DataReader["discountNotAllow"].ToString().Trim();
                    blExpireItem = (bool)DataReader["ExpireItem"];
                    blVatProd = (bool)DataReader["VatProd"];
                    blBundleProd = (bool)DataReader["Bundle"];

                    DecGrnQty = (decimal)DataReader["GrnQty"];
                    strGrnDate = (string)DataReader["GrnDate"];
                    blRecallGRN = (bool)DataReader["RecallGRN"];
                    blPktProd = (bool)DataReader["Packeting"];
                    FreeIsue = (bool)DataReader["FreeIssue"];
                    OGF = (bool)DataReader["OGF"];
                    BatchPUpdate = (bool)DataReader["BatchPUpdate"];
                     
                    SerialAllow = (bool)DataReader["SerialAllow"];
                    warrentyAllow = (bool)DataReader["WarrentyAllow"];
                    InstallChargeAllow = (bool)DataReader["InstallChargeAllow"];
                    WarrentyPeriod = DataReader["warrenty"].ToString();
                    InstallCharge = (decimal)DataReader["InstallCharge"];
                    InstallChargePer = (decimal)DataReader["InstallChargePer"];
                    
                    // Added by Nipuni - 2024.03.28
                    ServiceItem = (bool)DataReader["ServiceItem"];
                    ServiceTime = decimal.Parse(DataReader["ServiceTime"].ToString());
                    Rentitem = (bool)DataReader["Rentitem"];

                    try
                    {
                        
                        byteBLOBData = (Byte[])(DataReader["Prod_Image"]);
                        //bytProductImage = (Byte[])(DataReader["Prod_Image"]);
                        bytProductImage = byteBLOBData;
                    }
                    catch
                    {
                        //FileStream fsBLOBFile = new FileStream(Application.StartupPath + @"\DefaultImage.JPG", FileMode.Open, FileAccess.Read);
                        //Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
                        //fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                        //fsBLOBFile.Close();
                        //bytProductImage = bytBLOBData;
                        bytProductImage = null;
                    }
                    blRecordFound = true;
                }
                else
                {
                    strCode = string.Empty;
                    strDescript = string.Empty;
                    strShort_Description = string.Empty;
                    strBarcode = string.Empty;
                    strDepartment = string.Empty;
                    strCategory = string.Empty;
                    strSupplier = string.Empty;
                    strManufacturer = string.Empty;
                    strPurchasePrice = string.Empty;
                    strCurPurPrice = string.Empty;
                    strLastPurchasePrice = string.Empty;
                    strAvarage_Cost = string.Empty;
                    strMarkedPrice = string.Empty;
                    strSellingPrice = string.Empty;
                    strDiscountPrice = string.Empty;
                    MinimumPrice = string.Empty;
                    strWholePrice = string.Empty;
                    strReorderLevel = string.Empty;
                    strPurchaseDate = string.Empty;
                    strModified_Date = string.Empty;
                    strLockedItem = string.Empty;
                    fltLast_Purch_Qty = 0;
                    strUnit = string.Empty;
                    fltReorderQty = 0;
                    intPackSize = 0;
                    fltCurrentQty = 0;
                    strDisc_Str = string.Empty;
                    strCostCode = string.Empty;
                    strCreated_User = string.Empty;
                    strModified_User = string.Empty;
                    strMargine = string.Empty;
                    strBrandCode = string.Empty;
                    blRecordFound = false;
                    PointsAllow = false;
                    _ScaleProd = false;
                    strDisCountNotAllow = "F";
                    blExpireItem = false;
                    OGF = false;
                }

                //*Find Price Level
                dbcon.CloseReader();
                DataReader.Dispose();
                blPriceLevelFound = false;
                DataReader = dbcon.GetReader("select * from tbProductPriceLevel WHERE Prod_Code = '" + strCode + "'");
                if (DataReader.Read())
                {
                    blPriceLevelFound = true ;
                }
                else
                {
                    blPriceLevelFound = false;
                }
                //****

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }
        public void ProductRead()
        {
            try
            {
                blRecordFound = false;

                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    Code = DataReader["Prod_Code"].ToString().Trim();
                    Descript = DataReader["Prod_Name"].ToString().Trim();
                    Short_Description = DataReader["Short_Description"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    Code = string.Empty;
                    Descript = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }


        public void DeptRead()
        {
            try
            {
                blRecordFound = false;

                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strDepartment = DataReader["Dept_Code"].ToString().Trim();
                    strDeptName = DataReader["Dept_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strDepartment = string.Empty;
                    strDeptName = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void CategoryRead()
        {
            try
            {
                blRecordFound = false;

                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strCategory = DataReader["Cat_Code"].ToString().Trim();
                    strCatName = DataReader["Cat_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strCategory = string.Empty;
                    strCatName = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void SupplierRead()
        {
            try
            {
                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strSupplier = DataReader["Supp_Code"].ToString().Trim();
                    strSuppName = DataReader["Supp_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strSupplier = string.Empty;
                    strSuppName = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void ManufacturerRead()
        {
            try
            {
                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strManufacturer = DataReader["Manf_Code"].ToString().Trim();
                    strManufacuturerName = DataReader["Manf_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strManufacturer = string.Empty;
                    strManufacuturerName = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void BrandRead()
        {
            try
            {
                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strBrandCode = DataReader["Brand_Code"].ToString().Trim();
                    strBrandName = DataReader["Brand_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strBrandCode = string.Empty;
                    strBrandName = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void BarcodeRead()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strBarcode = DataReader["Barcode"].ToString().Trim();
                    strCode = DataReader["Prod_Code"].ToString().Trim();
                }
                else
                {
                    strBarcode = string.Empty;
                    strCode = string.Empty;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void BarcodeReadForDuplicate()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strBarcode = DataReader["Barcode"].ToString().Trim();
                    strCode = DataReader["Prod_Code"].ToString().Trim();
                }
                else
                {
                    strBarcode = string.Empty;
                    strCode = string.Empty;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }
        public void GetCostPrice()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strPurchasePrice = DataReader["Cost"].ToString().Trim();
                    
                }
                else
                {
                    strPurchasePrice = "";
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void RetrieveFields_ProductNo()
        {
            try
            {
                //dbcon.connection.Open();
                //SqlCommand command = new SqlCommand();
                //command.Connection = dbcon.connection;
                //command.CommandType = CommandType.Text;
                //command.CommandText = SqlString;
                //adapter.SelectCommand = command;
                
                //ds1.Clear();
                //adapter.Fill(ds1, "dsProduct");
                ds1 = dbcon.getDataset(SqlString, "dsProduct");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 011. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
 #endregion

        #region //Retrive Department CODE
        public void RetrieveFields_Department()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsDept");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.CloseConnection();
            }
        }
#endregion

        #region //Retrive Supplier CODE
        public void RetrieveFields_Supplier()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsSupplier");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
#endregion

        #region //Retrive Category CODE
        public void RetrieveFields_Category()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsCategory");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 014. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
        #endregion

        #region //Retrive Manufacturer CODE
        public void RetrieveFields_Manufacturer()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsManufacturer");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 015. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
        #endregion

        public void ReadMaxProductCode()
        {
            try
            {
                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strNextProductCode = DataReader["Prod_Code"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strNextProductCode = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void costCode(string Value, ref string a1, ref string a2, ref string a3, ref string a4, ref string a5, ref string a6, ref string a7, ref string a8, ref string a9)
        {
            try
            {
                Dr = dbcon.GetReader(Value);
                if (Dr.Read())
                {

                    a1 = Dr["Val1"].ToString();
                    a2 = Dr["Val2"].ToString();
                    a3 = Dr["Val3"].ToString();
                    a4 = Dr["Val4"].ToString();
                    a5 = Dr["Val5"].ToString();
                    a6 = Dr["Val6"].ToString();
                    a7 = Dr["Val7"].ToString();
                    a8 = Dr["Val8"].ToString();
                    a9 = Dr["Val9"].ToString();

                }

            }
            catch (Exception e)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*string [] Arr= new string[9];
            Arr.SetValue(Dr[0].ToString(),1);
            Arr.SetValue(Dr[1].ToString(),2);
            Arr.SetValue(Dr[2].ToString(), 3);
            Arr.SetValue(Dr[3].ToString(), 4);
            Arr.SetValue(Dr[4].ToString(), 5);
            Arr.SetValue(Dr[5].ToString(), 6);
            Arr.SetValue(Dr[6].ToString(), 7);
            Arr.SetValue(Dr[7].ToString(), 8);
            Arr.SetValue(Dr[8].ToString(), 9);*/
        }

        public void GetXCode(ref string XCode, string Sqlstatement)
        {
            try
            {
                _Dr = dbcon.GetReader(Sqlstatement);
                if (_Dr.Read())
                {
                    XCode = _Dr["XCode"].ToString();
                }


            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CreateCostCode()
        {
            string strCostPriceText;
            
            decimal decPurchasePrice;
            decimal intPurchasePrice;
            int intPriceLen;
            int intChar;
            try
            {

                if (LoginManager.CostCodeText != string.Empty )
                {
                    if (LoginManager.CostCodeText == null || LoginManager.CostCodeText == string.Empty || LoginManager.CostCodeText.Length < 10)
                    {
                        LoginManager.CostCodeText = "ABCDEFGHIJ";
                    }
                    string[] strCostCodeTextArr = new string[] { LoginManager.CostCodeText.Substring(9, 1), LoginManager.CostCodeText.Substring(0, 1), LoginManager.CostCodeText.Substring(1, 1), LoginManager.CostCodeText.Substring(2, 1), LoginManager.CostCodeText.Substring(3, 1), LoginManager.CostCodeText.Substring(4, 1), LoginManager.CostCodeText.Substring(5, 1), LoginManager.CostCodeText.Substring(6, 1), LoginManager.CostCodeText.Substring(7, 1), LoginManager.CostCodeText.Substring(8, 1) };
//                    intPurchasePrice = int.Parse( strPurchasePrice);
                    decPurchasePrice = decimal.Parse(strPurchasePrice);
                    intPurchasePrice = (decimal)(decPurchasePrice);
                    strCostPriceText = intPurchasePrice.ToString() ;
                    intPriceLen = strCostPriceText.Length;
                    strCostCode = string.Empty;
                    for (int i = 0; i <= (intPriceLen - 1); i++)
                    {
                        //intChar = int.Parse(strCostPriceText.Substring(i,1));
                        //strCostCode = strCostCode + strCostCodeTextArr[intChar];
                        if (strCostPriceText.Substring(i, 1) != ".")
                        {
                            intChar = int.Parse(strCostPriceText.Substring(i, 1));
                            strCostCode = strCostCode + strCostCodeTextArr[intChar];
                        }
                        else
                        {
                            strCostCode = strCostCode + ".";
                        }
                    }
                }

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region //Retrive Brand CODE
        public void RetrieveBrand()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlString;
                adapter.SelectCommand = command;
                ds1.Clear();
                adapter.Fill(ds1, "dsBrand");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProduct 018. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }
        #endregion

        //***** Using Location reload
        public void ReadLocationCode()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlString );
                if (DataReader.Read())
                {
                    strLocaCode = DataReader["Loca"].ToString().Trim();
                    strLocaName = DataReader["Loca_Descrip"].ToString().Trim();
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProduct 019. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

        public void UpdateLocationROL()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_LocationROL";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@ROL", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltLocaROL));
                command.Parameters.Add(new SqlParameter("@RO_Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltLocaReQty));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLocaCode));
                
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsLocationROL = new DataSet(), "dsProdROL");
                if (intErrCode != 0)
                {
                    MessageBox.Show("an internal error has occurred while deleting the current record", "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProduct 020. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Location Re Order Level
                dsLocationROL = dbcon.getDataset("SELECT SM.Prod_Code, SM.ROL, SM.RO_Qty, SM.Loca, L.Loca_Descrip, SM.Qty FROM Location L INNER JOIN Stock_Master SM ON L.Loca = SM.Loca AnD L.TaxLoca='" + LoginManager.TaxLocaLogin + "' WHERE SM.Prod_Code = '" + strCode + "' Order by SM.Loca", "dsProdROL");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProduct 021. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteLocationROLAll()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_LocationROLDeleteAll";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                if (intErrCode != 0)
                {
                    MessageBox.Show("an internal error has occurred while deleting the current record", "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProduct 022. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }

        public void DeleteLocationROL()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_LocationROLDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LocaCode));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsLocationROL = new DataSet(), "dsProdROL");
                if (intErrCode != 0)
                {
                    MessageBox.Show("An internal error has occurred while deleting the current record", "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProduct 023. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                dbcon.connection.Close();
            }
        }

        public void ReadProductCode()
        {
            try
            {
                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    blRecordFound = true;
                }
                else
                {
                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsProduct 024. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
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
                DataReader.Dispose();
            }
        }

    }
}
