using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DbConnection;


namespace clsLibrary
{
    public class clsWholeSaleInvoice : clsPublic
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;
        private int intPackSize;

        private string strLocaCode;
        private string strLocaName;
        private string strCustCode;
        private string strCustName;
        private string strAddress1;
        private string strAddress2;
        private string strAddress3;
        private string strProductCode;
        private string strProductName;
        private string strSalesAssistant;
        private string strSqlStatement;
        private string strTempDocumentNo;
        private string strOrgDocumentNo;
        private string strDataSetName;
        private string strPostDate;
        private string strReference;
        private string strRemark;
        private string strOrgDocNo;
        private string strSavedDocNo;
        private string strRecallSaveDocNo;
        private string strDisc;
        private string strPoNo;       

        private string strUnit;
        private string strComments;

        private decimal fltQty;
        private decimal fltCurrentQty;
        private decimal fltFreeQty;
        private decimal fltTotalQty;
        public int ItemCount { get; set; }
        private decimal decPurchasePrice;
        private decimal decMarkedPrice;
        private decimal decWholePrice;
        private decimal deSellingPrice1;
        private decimal decDiscount;
        private decimal decGrossAmount;
        private decimal decAmount;
        private decimal decTotalAmount;
        private decimal decTax;

        // Added By Nipuni - 2024.03.29
        private string strMobile;
        private string strStaffCode;
        private string strStaffName;
        private string strServiceCode;
        private string strServiceItem;
        private decimal strServiceTime;

        private string strType;
        private string strDate;

        private DataSet dsItemDataSet;        
        private DataSet dsCustomerDataSet;
        private DataSet dsTempInvoice;
        private DataSet dsForReport;
        private DataSet dsProductPriceLevel;
        // Added By Nipuni - 2024.03.29
        private DataSet dsProductDataSet;
        private DataSet dsStaffDataSet;
        private DataSet dsTimeDataSet;
        private DataSet dsResultSet;

        private Boolean blPPLRecoudFound;
        private Boolean blRecordFound;
        private Boolean blVatCus;
        private string strvatNo;
        public DataTableReader objdtReader { get; set; }
        #endregion

        #region Properties
        
        public bool DiscAllow { get; set; }
        public bool FreeAllow { get; set; }
        public bool batchSel { get; set; }
        public string Age { get; set; }
        public string TempDocNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }
        public string OrgDocNo
        {
            get { return strOrgDocumentNo; }
            set { strOrgDocumentNo = value; }
        }
        public Boolean VatCus
        {
            get { return blVatCus; }
            set { blVatCus = value; }
        }
        public string vatNo
        {
            get { return strvatNo; }
            set { strvatNo = value; }
        }
        public string SavedDocNo
        {
            get { return strSavedDocNo; }
            set { strSavedDocNo = value; }
        }

        public string RecallSaveDocNo
        {
            get { return strRecallSaveDocNo; }
            set { strRecallSaveDocNo = value; }
        }

        public string PostDate
        {
            get { return strPostDate; }
            set { strPostDate = value; }
        }



        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public int PackSize
        {
            get { return intPackSize; }
            set { intPackSize = value; }
        }


        public string LocaCode
        {
            get { return strLocaCode; }
            set { strLocaCode = value; }
        }
        public string Time { get; set; }
        public string LocaName
        {
            get { return strLocaName; }
            set { strLocaName = value; }
        }

        public string CustCode
        {
            get { return strCustCode; }
            set { strCustCode = value; }
        }

        public string CustName
        {
            get { return strCustName; }
            set { strCustName = value; }
        }

        public string Address1
        {
            get { return strAddress1; }
            set { strAddress1 = value; }
        }

        public string Address2
        {
            get { return strAddress2; }
            set { strAddress2 = value; }
        }

        public string Address3
        {
            get { return strAddress3; }
            set { strAddress3 = value; }
        }

        public string SalesAssistant
        {
            get { return strSalesAssistant; }
            set { strSalesAssistant = value; }
        }

        public string ProductCode
        {
            get { return strProductCode; }
            set { strProductCode = value; }
        }

        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }
        }

        public string Unit
        {
            get { return strUnit; }
            set { strUnit = value; }
        }

        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }
        }

        public string Reference
        {
            get { return strReference; }
            set { strReference = value; }
        }

        public string PoNo
        {
            get { return strPoNo; }
            set { strPoNo = value; }
        }

        private string strInvNo;
        public string InvNO
        {
            get { return strInvNo; }
            set { strInvNo = value; }
        }

        public string Disc
        {
            get { return strDisc; }
            set { strDisc = value; }
        }

        public decimal Qty
        {
            get { return fltQty; }
            set { fltQty = value; }
        }

        public decimal FreeQty
        {
            get { return fltFreeQty; }
            set { fltFreeQty = value; }
        }

        public decimal CurrentQty
        {
            get { return fltCurrentQty; }
            set { fltCurrentQty = value; }
        }

        public decimal TotalQty
        {
            get { return fltTotalQty; }
            set { fltTotalQty = value; }
        }

        public decimal TotalAmount
        {
            get { return decTotalAmount; }
            set { decTotalAmount = value; }
        }

        public decimal PurchasePrice
        {
            get { return decPurchasePrice; }
            set { decPurchasePrice = value; }
        }

        public decimal MarkedPrice
        {
            get { return decMarkedPrice; }
            set { decMarkedPrice = value; }
        }

        public decimal SellingPrice
        {
            get { return decWholePrice; }
            set { decWholePrice = value; }
        }

        public decimal SellingPrice1
        {
            get { return deSellingPrice1; }
            set { deSellingPrice1 = value; }
        }

        public decimal Discount
        {
            get { return decDiscount; }
            set { decDiscount = value; }
        }
        public decimal DiscountPer
        { get; set; }


        public decimal Amount
        {
            get { return decAmount; }
            set { decAmount = value; }
        }

        public decimal GrossAmount
        {
            get { return decGrossAmount; }
            set { decGrossAmount = value; }
        }

        public decimal Tax
        {
            get { return decTax; }
            set { decTax = value; }
        }        
        public bool TaxBill { get; set; }
        public string ConNo { get; set; }
        public string ConPer { get; set; }
        public string BookNo { get; set; }
        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        public string DataetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public DataSet GetItemDataset
        {
            get { return dsItemDataSet; }
            set { dsItemDataSet = value; }
        }        

        public DataSet GetReportDataset
        {
            get { return dsForReport; }
            set { dsForReport = value; }
        }

        public DataSet TempInvoice
        {
            get { return dsTempInvoice; }
            set { dsTempInvoice = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public DataSet ProductPriceLevel
        {
            get { return dsProductPriceLevel; }
            set { dsProductPriceLevel = value; }
        }

        public Boolean PPLRecoudFound
        {
            get { return blPPLRecoudFound; }
            set { blPPLRecoudFound = value; }
        }


        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
        }

        private string strInvTypeRW;

        public string InvTypeRW
        {
            get { return strInvTypeRW; }
            set { strInvTypeRW = value; }
        }


        private decimal _Balance;
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        private string _TransNo;
        public string TransNo
        {
            get { return _TransNo; }
            set { _TransNo = value; }
        }
        private string payType;
        public string _payType
        {
            get { return payType; }
            set { payType = value; }
        }
        private string LoyalityNo;
        public string _LoyalityNo
        {
            get { return LoyalityNo; }
            set { LoyalityNo = value; }
        }
        private bool AutoSelect;
        public bool _AutoSelect
        {
            get { return AutoSelect; }
            set { AutoSelect = value; }
        }

        private Boolean VATINV;
        public Boolean _VATINV
        {
            get { return VATINV; }
            set { VATINV = value; }
        }

        private int InvCount;
        public int _InvCount
        {
            get { return InvCount; }
            set { InvCount = value; }
        }

        private decimal UnSetReturn;
        public decimal _UnSetReturn
        {
            get { return UnSetReturn; }
            set { UnSetReturn = value; }
        }

        private decimal Cheque_InHand;
        public decimal _Cheque_InHand
        {
            get { return Cheque_InHand; }
            set { Cheque_InHand = value; }
        }
        public decimal CreditLimit { get; set; }
        private decimal CashPayAmount;
        public decimal _CashPayAmount
        {
            get { return CashPayAmount; }
            set { CashPayAmount = value; }
        }

        private int priceBatch;
        public int _priceBatch
        {
            get { return priceBatch; }
            set { priceBatch = value; }
        }

        private string QtyColoumnName;
        public string _QtyColoumnName
        {
            get { return QtyColoumnName; }
            set { QtyColoumnName = value; }
        }

        private string State;
        public string _State
        {
            get { return State; }
            set { State = value; }
        }

        private DataSet dsDiscountLevel;
        public DataSet _dsDiscountLevel
        {
            get { return dsDiscountLevel; }
            set { dsDiscountLevel = value; }
        }

        private decimal TotAmountForDiscLevel;
        public decimal _TotAmountForDiscLevel
        {
            get { return TotAmountForDiscLevel; }
            set { TotAmountForDiscLevel = value; }
        }

        private decimal dcDueBalance;
        public decimal DueBalance
        {
            get { return dcDueBalance; }
            set { dcDueBalance = value; }
        }

        private bool blUnderCost;
        public bool _blUnderCost
        {
            get { return blUnderCost; }
            set { blUnderCost = value; }
        }


        private DataSet Ds;
        public DataSet _Ds
        {
            get { return Ds; }
            set { Ds = value; }
        }

        private int lnNo;
        public int _lnNo
        {
            get { return lnNo; }
            set { lnNo = value; }
        }


        private decimal dec_RPrice;
        public decimal _dec_RPrice
        {
            get { return dec_RPrice; }
            set { dec_RPrice = value; }
        }

        private decimal dec_WPrice;
        public decimal _dec_WPrice
        {
            get { return dec_WPrice; }
            set { dec_WPrice = value; }
        }

        private decimal dec_DPrice;
        public decimal _dec_DPrice
        {
            get { return dec_DPrice; }
            set { dec_DPrice = value; }
        }

        private decimal dec_MMPrice;
        public decimal _dec_MMPrice
        {
            get { return dec_MMPrice; }
            set { dec_MMPrice = value; }
        }
        private decimal _OtherCharges;
        public decimal OtherCharges
        {
            get { return _OtherCharges; }
            set { _OtherCharges = value; }
        }
        private string strBatchNo;
        public string BatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }

        private SqlDataReader DataReader;

        public string Tech1 { get; set; }
        public string Tech2 { get; set; }

        // Added By Nipuni - 2024.03.29
        public DataSet GetProductDataSet
        {
            get { return dsProductDataSet; }
            set { dsProductDataSet = value; }
        }
        public DataSet GetTimeDataSet
        {
            get { return dsTimeDataSet; }
            set { dsTimeDataSet = value; }
        }
        public DataSet GetStaffDataSet
        {
            get { return dsStaffDataSet; }
            set { dsStaffDataSet = value; }
        }

        public DataSet GetCustomerDataSet
        {
            get { return dsCustomerDataSet; }
            set { dsCustomerDataSet = value; }
        }
        public string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
        }
        public string StaffCode
        {
            get { return strStaffCode; }
            set { strStaffCode = value; }
        }

        public string StaffName
        {
            get { return strStaffName; }
            set { strStaffName = value; }
        }
        public string ServiceCode
        {
            get { return strServiceCode; }
            set { strServiceCode = value; }
        }

        public string ServiceItem
        {
            get { return strServiceItem; }
            set { strServiceItem = value; }
        }
        public decimal ServiceTime
        {
            get { return strServiceTime; }
            set { strServiceTime = value; }
        }

        public string Type
        {
            get { return strType; }
            set { strType = value; }
        }
        public string Date
        {
            get { return strDate; }
            set { strDate = value; }
        }
        public DataSet ResultSet
        {
            get { return dsResultSet; }
            set { dsResultSet = value; }
        }
        public decimal MinimumPrice { get; set; }

        #endregion


        //Get Tempory Document No
        public void GetTempDocumentNo(ref DataTable dt)
        {
            try
            {
                strSqlStatement = "SELECT Temp_Inv,Inv FROM DocumentNoDetails WHERE Loca = '" + LoginManager.LocaCode + "';SELECT DISTINCT Disc_Levels FROM tb_DiscPercentage ORDER BY Disc_Levels;EXEC dbo.sp_UPDATETempDocNo  @Err_x =  0,@Iid = N'INV',@Loca = N'" + LoginManager.LocaCode + "'";

                //objdtReader =dbconApi.GetDataTableReader("SELECT Temp_Inv,Inv FROM DocumentNoDetails WHERE Loca = '"+LoginManager.LocaCode+ "';EXEC dbo.sp_UPDATETempDocNo  @Err_x =  0,@Iid = N'INV',@Loca = N'" + LoginManager.LocaCode + "'");

                DataSet Ds = dbconApi.getDataset(strSqlStatement, "ds");
                dt = Ds.Tables[1];
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    intTempDocNo = Convert.ToInt32(Ds.Tables[0].Rows[0][0]);
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo = "INV" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;

                    intTempDocNo = Convert.ToInt32(Ds.Tables[0].Rows[0][1]);
                    strOrgDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strOrgDocumentNo = "INV" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocumentNo;

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseConnection();
            }

            //try
            //{
            ////UpDate Record No
            //intErrCode = 0;
            //dbcon.OpenConnection();
            //SqlCommand command = new SqlCommand();
            //command.CommandTimeout = LoginSys.dbocommTimeOut;
            //command.Connection =dbconApi.connection;
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_UpdateTempDocNo";
            //command.Parameters.Clear();
            //command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
            //command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
            //command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

            //command.ExecuteNonQuery();
            //command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            //ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            //}
            //catch (Exception ex)
            //{
            //    clsClear.ErrMessage(ex.Message, ex.StackTrace);
            //}
            //finally
            //{
            //  dbconApi.pi.connection.Close();

            //    GetTempDataset();
            //}
        }

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsTempInvoice = dbconApi.getDataset("select Prod_Code, Prod_Name, Unit, Purchase_Price, Selling_Price, Qty, FreeQty, Discount,Amount, Ln, ExpDate, BatchNo,0[VAT],To_Loca,Marked_Price,Serial_No[SerialNo] FROM TransactionTemp_Details WHERE Doc_No = '" + strTempDocumentNo + "' AND IId = 'INV' AND Loca = " + LoginManager.LocaCode + " Order by Ln", "Invoice");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }


        public void GetDataSetForReport()
        {
            try
            {
                dsForReport = dbconApi.getDataset("SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Original' Status, Transaction_Details.Marked_Price, '" + LoginManager.CompanyName + "' AS [CompanyName], '" + LoginManager.CompanyAddress + "' AS [CompanyAddress], '" + LoginManager.CompanyTelephone + "' AS [CompanyTelephone], '" + LoginManager.CompanyEmail + "' AS [CompanyEmail] FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Header.Doc_No = '" + strOrgDocNo + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'INV' ORDER BY Ln", "dsInvoiceDetails");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void GetDataSetForPreview(bool sinhala)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);
                //if (sinhala)
                //{
                //    dsForReport =dbconApi.getDataset("SELECT 0 as Inv_Amt,'" + strTempDocumentNo + "' Doc_no, '" + strCustCode + "' Cust_code,'" + strCustName + "' Cust_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date,  '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + payType + "' Pay_Type, " + decTax + " Tax, '" + strSalesAssistant + "' Sales_Assist, TransactionTemp_Details.Prod_code, product.singhala AS Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.FreeQty, TransactionTemp_Details.Purchase_Price, TransactionTemp_Details.Selling_Price, TransactionTemp_Details.Discount, TransactionTemp_Details.Amount, TransactionTemp_Details.Ln, 'Temporary' Status,TransactionTemp_Details.Marked_Price, '" + strComments + "' PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, TransactionTemp_Details.Marked_Price, 'Temporary' Status , TransactionTemp_Details.Unit, TransactionTemp_Details.ExpDate, TransactionTemp_Details.BatchNo  FROM TransactionTemp_Details INNER JOIN Customer On Customer.Cust_Code = '" + strCustCode + "' INNER JOIN Product ON Product.prod_Code=TransactionTemp_Details.prod_Code  WHERE TransactionTemp_Details.Doc_No = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = 'INV' ORDER BY Ln; SELECT * from CompanyProfileSinhala ", "dsInvoiceDetails");
                //}
                //else
                {
                    dsForReport = dbconApi.getDataset("SELECT '"+ConNo+"'[ConNo],'"+ConPer+"'[ConPer], 0 as Inv_Amt,'" + strTempDocumentNo + "' Doc_no, '" + strCustCode + "' Cust_code,'" + strCustName + "' Cust_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date,  '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + payType + "' Pay_Type, " + decTax + " Tax, '" + strSalesAssistant + "' Sales_Assist,TransactionTemp_Details.Prod_code, TransactionTemp_Details.Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.FreeQty, TransactionTemp_Details.Purchase_Price,/* TransactionTemp_Details.Marked_Price as Selling_Price,*/TransactionTemp_Details.Selling_Price,TransactionTemp_Details.Discount		+CASE WHEN TransactionTemp_Details.Marked_Price-TransactionTemp_Details.Selling_Price > 0 THEN (TransactionTemp_Details.Marked_Price-TransactionTemp_Details.Selling_Price)*Qty ELSE 0 END Discount, TransactionTemp_Details.Amount, TransactionTemp_Details.Ln, 'Temporary' Status,TransactionTemp_Details.Marked_Price, '" + strComments + "' PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, TransactionTemp_Details.Marked_Price, 'Temporary' Status , TransactionTemp_Details.Unit, TransactionTemp_Details.ExpDate, TransactionTemp_Details.BatchNo,Serial_No,warrenty  FROM TransactionTemp_Details INNER JOIN Customer On Customer.Cust_Code = '" + strCustCode + "' Join Product P on p.Prod_Code=TransactionTemp_Details.Prod_Code WHERE TransactionTemp_Details.Doc_No = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = 'INV' ORDER BY Ln; SELECT * from CompanyProfile;SELECT * FROM dbo.tbPaymentDetails WHERE Temp_DocNo='" + strTempDocumentNo + "' ", "dsInvoiceDetails");
                }


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void GetItemDetails()
        {
            try
            {
                dsItemDataSet = dbconApi.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void ReadSavedDocument()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    strTempDocumentNo = strRecallSaveDocNo;
                    strCustCode = objdtReader["Supplier_Id"].ToString().Trim();
                    strCustName = objdtReader["Cust_Name"].ToString().Trim();
                    strAddress1 = objdtReader["ConNo"].ToString().Trim();
                    strAddress2 = objdtReader["ConPer"].ToString().Trim();
                    strAddress3 = objdtReader["Address3"].ToString().Trim();
                    strPoNo = objdtReader["Porder_No"].ToString().Trim();
                    payType = objdtReader["Pay_Type"].ToString().Trim();
                    strRemark = objdtReader["Remarks"].ToString().Trim();
                    strReference = objdtReader["Reference"].ToString().Trim();
                    strComments = objdtReader["PayRemark1"].ToString().Trim();
                    Salsmen_Code = objdtReader["Code"].ToString().Trim();
                    strSalesAssistant = objdtReader["Ref_Name"].ToString().Trim();
                    decTax = Convert.ToDecimal(objdtReader["Tax"]);
                    decDiscount = Convert.ToDecimal(objdtReader["Discount"]);
                    InvTypeRW = objdtReader["To_Loca"].ToString();
                    Tech1 = objdtReader["Tech1"].ToString();
                    Tech2 = objdtReader["Tech2"].ToString();
                    BookNo = objdtReader["PayRemark3"].ToString();

                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decWholePrice = 0;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }

            //Reload Saved Items to the Tempory
            if (blRecordFound == true)
            {
                try
                {
                    dbconApi.OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.Connection = dbconApi.connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InvoiceRecall";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRecallSaveDocNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                    command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.MachineUnit));

                    //  command.ExecuteNonQuery();

                    DataSet emptyDs = null;
                    DataTableReader emtyDTR = null;
                    dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");


                    command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                finally
                {
                    dbconApi.connection.Close();
                }
            }
            //***
        }
        public void RecallForReturn(bool LoadItems)
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    // strTempDocumentNo = strRecallSaveDocNo;
                    strCustCode = objdtReader["Supplier_Id"].ToString().Trim();
                    strCustName = objdtReader["Cust_Name"].ToString().Trim();
                    strAddress1 = objdtReader["ConNo"].ToString().Trim();
                    strAddress2 = objdtReader["ConPer"].ToString().Trim();
                    strAddress3 = objdtReader["Address3"].ToString().Trim();
                    strPoNo = objdtReader["Porder_No"].ToString().Trim();
                    payType = objdtReader["Pay_Type"].ToString().Trim();
                    strRemark = objdtReader["Remarks"].ToString().Trim();
                    strReference = objdtReader["Reference"].ToString().Trim();
                    strComments = objdtReader["PayRemark1"].ToString().Trim();
                    strSalesAssistant = objdtReader["Ref_Name"].ToString().Trim();
                    decTax = Convert.ToDecimal(objdtReader["Tax"]);
                    decDiscount = Convert.ToDecimal(objdtReader["Discount"]);
                    DiscountPer = Convert.ToDecimal(objdtReader["Disc"]);
                    InvTypeRW = objdtReader["To_Loca"].ToString();
                   
                    Tech1 = objdtReader["Tech1"].ToString();
                    Tech2 = objdtReader["Tech2"].ToString();
                    ConNo = objdtReader["ConNo"].ToString();
                    ConPer = objdtReader["ConPer"].ToString();

                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decWholePrice = 0;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }

            //Reload Saved Items to the Tempory
            if (blRecordFound == true)
            {
                try
                {
                    dbconApi.OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.Connection = dbconApi.connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InvoiceRecallToReturn";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                    command.Parameters.Add(new SqlParameter("@DocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRecallSaveDocNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                    command.Parameters.Add(new SqlParameter("@LoadItems", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoadItems));

                    //   command.ExecuteNonQuery();
                    DataSet emptyDs = null;
                    DataTableReader emtyDTR = null;
                    dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");


                    command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                finally
                {
                    dbconApi.connection.Close();
                }
            }
            //***
        }
        public void GetTotalWithoutDiscNotAllow()
        {
            try
            {

                strSqlStatement = "select isnull(sum(Amount),0) from TransactionTemp_Details INNER JOIN Product On product.prod_code=TransactionTemp_Details.prod_code WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'  ";

                Ads = dbconApi.getDataset(strSqlStatement, "ds");
                if (Ads.Tables[0].Rows.Count > 0)
                {
                    TotAmountForDiscLevel = Convert.ToDecimal(Ads.Tables[0].Rows[0][0]);
                }
                else
                {
                    TotAmountForDiscLevel = 0;
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseConnection();
            }
        }

        public void GetMaxPriceBatch()
        {
            try
            {

                strSqlStatement = "select ISNULL(max(priceBatch),1) from tbProductPriceLevel WHERE Prod_Code = '" + ProductCode + "' AND " + QtyColoumnName + " <= '" + Qty + "'";

                Ads = dbconApi.getDataset(strSqlStatement, "ds");
                if (Ads.Tables[0].Rows.Count > 0)
                {
                    priceBatch = Convert.ToInt32(Ads.Tables[0].Rows[0][0]);
                }
                else
                {
                    priceBatch = 0;
                }



            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseConnection();
            }
        }

        public void GetTotalValues()
        {
            try
            {

                strSqlStatement = "select isnull(sum(Amount),0) from TransactionTemp_Details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "';" +
                    "select isnull(sum(Qty),0),count(Distinct Prod_Code) from TransactionTemp_Details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";

                Ads = dbconApi.getDataset(strSqlStatement, "ds");
                if (Ads.Tables[0].Rows.Count > 0)
                {
                    decTotalAmount = Convert.ToDecimal(Ads.Tables[0].Rows[0][0]);
                    fltTotalQty = Convert.ToDecimal(Ads.Tables[1].Rows[0][0]);
                    ItemCount = Convert.ToInt32(Ads.Tables[1].Rows[0][1]);
                }
                else
                {
                    decTotalAmount = fltTotalQty = 0;
                }


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseConnection();
            }
        }

        public void GetProductDetails()
        {
            try
            {
                dsProductDataSet = dbconApi.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void GetStaffDetails()
        {
            try
            {
                dsStaffDataSet = dbconApi.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void GetCustomerDetails()
        {
            try
            {
                dsCustomerDataSet = dbconApi.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        public void ReadDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    blRecordFound = true;
                }
                else
                {
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void ReadServiceDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    strServiceCode = objdtReader["Prod_Code"].ToString().Trim();
                    strServiceItem = objdtReader["Prod_Name"].ToString().Trim();
                    strServiceTime = Convert.ToDecimal(objdtReader["ServiceTime"].ToString());
                    blRecordFound = true;
                }
                else
                {
                    strServiceCode = string.Empty;
                    strServiceItem = string.Empty;
                    strServiceTime = 0;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void ReadStaffDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    strStaffCode = objdtReader["Staff_Code"].ToString().Trim();
                    strStaffName = objdtReader["Staff_Name"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strStaffCode = string.Empty;
                    strStaffName = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void ReadCustomerDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    string MobNo = "";
                    try
                    {
                        MobNo =  objdtReader["Tel"].ToString().Trim() ;
                        Age =  objdtReader["Age"].ToString().Trim();
                    }
                    catch (Exception)
                    { }
                    
                    strCustCode = objdtReader["Cust_Code"].ToString().Trim();
                    strCustName = objdtReader["Cust_Name"].ToString().Trim();
                    strMobile = MobNo;
                    strAddress1 = objdtReader["Address1"].ToString().Trim();
                    strAddress2 = objdtReader["Address2"].ToString().Trim();
                    strAddress3 = objdtReader["Address3"].ToString().Trim();
                    blVatCus = Convert.ToBoolean(objdtReader["VAT"]);
                    strvatNo = objdtReader["VatNo"].ToString().Trim();
                    //_Balance = (decimal)objdtReader["Balance_Amount"];
                    

                    blRecordFound = true;
                }
                else
                {
                    strCustCode = string.Empty;
                    strCustName = string.Empty;
                    strAddress1 = string.Empty;
                    strAddress2 = string.Empty;
                    strAddress3 = string.Empty;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void ReadCustomerBalanceDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {

                    _Balance = Convert.ToDecimal(objdtReader["Balance_Amount"]);
                    InvCount = Convert.ToInt32(objdtReader["Qty"]);
                    UnSetReturn = Convert.ToDecimal(objdtReader["Unsettled_Refund"]);
                    Cheque_InHand = Convert.ToDecimal(objdtReader["Cheque_InHand"]);
                    CreditLimit = Convert.ToDecimal(objdtReader["CreditLimit"]);
                    blRecordFound = true;
                }
                else
                {
                    _Balance = 0;
                    InvCount = 0;
                    UnSetReturn = 0;
                    Cheque_InHand = 0;

                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void ReadProductDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    strProductCode = objdtReader["Prod_Code"].ToString().Trim();
                    strProductName = objdtReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = Convert.ToDecimal(objdtReader[5]);
                    intPackSize = Convert.ToInt32(objdtReader[6]);
                    MarkedPrice = Convert.ToDecimal(objdtReader["Marked_Price"]);
                    decPurchasePrice = Convert.ToDecimal(objdtReader["Purchase_price"]);
                    decWholePrice = Convert.ToDecimal(objdtReader["Whole_Price"]);
                    SellingPrice1 = Convert.ToDecimal(objdtReader["Selling_Price"]);
                    strUnit = objdtReader["Unit"].ToString().Trim();
                    blUnderCost = Convert.ToBoolean(objdtReader["UnderCost"]);

                    dec_WPrice = Convert.ToDecimal(objdtReader["Whole_Price"]);
                    dec_RPrice = Convert.ToDecimal(objdtReader["Selling_Price"]);
                    dec_DPrice = Convert.ToDecimal(objdtReader["Disc_Price"]);
                    dec_MMPrice = Convert.ToDecimal(objdtReader["Marked_Price"]);

                    try
                    {
                        MinimumPrice = Convert.ToDecimal(objdtReader["MinimumPrice"]);
                    }
                    catch 
                    {                     
                    }


                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    MarkedPrice = 0;
                    SellingPrice1 = 0;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decWholePrice = 0;
                    strUnit = string.Empty;
                    blUnderCost = false;
                    MinimumPrice = 0;

                    dec_WPrice = 0;
                    dec_RPrice = 0;
                    dec_DPrice = 0;
                    dec_MMPrice = 0;

                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void ReadProductDetailsInv()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    strProductCode = objdtReader["Prod_Code"].ToString().Trim();
                    strProductName = objdtReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = Convert.ToDecimal(objdtReader[5]);
                    intPackSize = Convert.ToInt32(objdtReader[6]);
                    MarkedPrice = Convert.ToDecimal(objdtReader["Marked_Price"]);
                    decPurchasePrice = Convert.ToDecimal(objdtReader["Purchase_price"]);
                    decWholePrice = Convert.ToDecimal(objdtReader["Whole_Price"]);
                    SellingPrice1 = Convert.ToDecimal(objdtReader["Selling_Price"]);
                    strUnit = objdtReader["Unit"].ToString().Trim();
                    blUnderCost = Convert.ToBoolean(objdtReader["UnderCost"]);

                    dec_WPrice = Convert.ToDecimal(objdtReader["Whole_Price"]);
                    dec_RPrice = Convert.ToDecimal(objdtReader["Selling_Price"]);
                    dec_DPrice = Convert.ToDecimal(objdtReader["Disc_Price"]);
                    dec_MMPrice = Convert.ToDecimal(objdtReader["Marked_Price"]);          
                    strDisc = (objdtReader["Disc_Str"]).ToString();
                    MinimumPrice = Convert.ToDecimal(objdtReader["MinimumPrice"]);

                    bool BatchPUpdate = Convert.ToBoolean(objdtReader["BatchPUpdate"]);

                   FreeAllow = Convert.ToBoolean(objdtReader["FreeIssue"]);
                   DiscAllow = Convert.ToBoolean(objdtReader["DiscAllow"]);

                    if (BatchPUpdate==false)
                    {
                        batchSel = true;
                    }
                    else
                    {
                        batchSel = false;
                    }
                   
                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    MarkedPrice = 0;
                    SellingPrice1 = 0;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decWholePrice = 0;
                    strUnit = string.Empty;
                    blUnderCost = false;
                    dec_WPrice = 0;
                    dec_RPrice = 0;
                    dec_DPrice = 0;
                    dec_MMPrice = 0;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }
        public void ReadExsistProductDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement + LoginManager.LocaCode);
                if (objdtReader.Read())
                {
                    fltQty = Convert.ToDecimal(objdtReader[0]);
                }
                else
                {
                    fltQty = 0;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }
        public DataSet Ads { get; set; }
        public DataSet ds { get; set; }
        public DataSet CheckUnit()
        {
            try
            {
                strSqlStatement = "SELECT UnitNo FROM dbo.tbUnitDetails WHERE MacAddress='" + System.Environment.MachineName.ToString() + "' AND Loca='" + LoginManager.LocaCode + "' and Flag=1";

                return Ads = dbconApi.getDataset(strSqlStatement, "dsd");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetCodeFromBatch(string strSqlString)
        {
            try
            {
                string Code = "";
                objdtReader = DbConnection.dbconApi.GetDataTableReader(strSqlString);
                if (objdtReader.Read())
                {
                    Code = objdtReader[0].ToString();
                }
                return Code;
            }
            finally
            {
                DbConnection.dbcon.CloseReader();
            }
        }

        public bool HasRecordF(string strSqlString)
        {
            try
            {
                objdtReader = DbConnection.dbconApi.GetDataTableReader(strSqlString);
                return objdtReader.HasRows;
            }
            finally
            {
                DbConnection.dbcon.CloseReader();
            }
        }

        public DataTable Get_BatchList(string ProdCode, bool Return)
        {
            DataTable dt;
            try
            {
                if (Return == true)
                {
                    dt = dbconApi.getDataset("select BatchNo from Stock_Master_Batch WHERE Loca='" + LoginManager.LocaCode + "' and Prod_Code='" + ProdCode + "' ORDER BY BatchNo ", "dtBatch").Tables[0];
                }
                else
                {
                    dt = dbconApi.getDataset("select BatchNo from Stock_Master_Batch WHERE Loca='" + LoginManager.LocaCode + "' and Prod_Code='" + ProdCode + "' and   Stock>0 ORDER BY BatchNo ", "dtBatch").Tables[0];

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                dt = null;
            }
            finally
            {
                dbconApi.CloseConnection();
            }
            return dt;
        }


        public DataTable Get_BatchDetails(string ProdCode, string BatchNo)
        {
            DataTable dt;
            try
            {
                dt = dbconApi.getDataset("select Prod_Code, BatchNo, Exp_Date, Shipment, Stock, Purchase_Price, Ws_Price, Ret_Price, Distr_Price, ModMkt_Price from Stock_Master_Batch WHERE Loca='" + LoginManager.LocaCode + "' and Prod_Code='" + ProdCode + "' and BatchNo='" + BatchNo + "' ", "dtBatch").Tables[0];
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                dt = null;
            }
            finally
            {
                dbconApi.CloseConnection();
            }
            return dt;
        }
        public void GetDs()
        {
            try
            {
                Ads = dbconApi.getDataset(strSqlStatement, "Ds");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateSmsRes(string DocNo,string State)
        {
            try
            {
                string sqlStatement = "UPDATE dbo.tbLoyalitySmsResponse SET ResPonse=@Res,ReSTime=GETDATE() WHERE DocNo=@DocNo ";
                

                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@Res", State));
                lstPrm.Add(new SqlParameter("@DocNo", DocNo));

                  dbcon.GetDataSet(sqlStatement, lstPrm, "dsArea");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }
        public void UpdateInvoiceTempDataSet(bool Continuesly)
        {
            try
            {
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                if (Continuesly)
                {
                    command.CommandText = "sp_InvoiceTemp_Update_Con";
                }
                else
                {
                    command.CommandText = "sp_InvoiceTemp_Update";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@InvType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InvTypeRW));
                command.Parameters.Add(new SqlParameter("@PayType", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Pay_Type));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@FreeQty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltFreeQty));
                command.Parameters.Add(new SqlParameter("@Whole_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decWholePrice));
                command.Parameters.Add(new SqlParameter("@Marked_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MarkedPrice));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUnit));
                command.Parameters.Add(new SqlParameter("@Pack_Size", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, intPackSize));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));
                command.Parameters.Add(new SqlParameter("@BatchNo", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBatchNo));
                command.Parameters.Add(new SqlParameter("@AutoSelect", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AutoSelect));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, code));
                command.Parameters.Add(new SqlParameter("@Unit_No ", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.MachineUnit));
                command.Parameters.Add(new SqlParameter("@Salsmen_Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,Salsmen_Code));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark));
                command.Parameters.Add(new SqlParameter("@Po_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,Po_Number));
                command.Parameters.Add(new SqlParameter("@Serial_No", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSerialNo));
                command.Parameters.Add(new SqlParameter("@InvTypeFor", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvType));
                command.Parameters.Add(new SqlParameter("@Rdatefrom", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rdate_from));
                command.Parameters.Add(new SqlParameter("@RdateTo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rdate_To));

                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");


                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.connection.Close();
            }
        }

        public void CheckTimePeriod(string Date, DateTime TimeFrom, DateTime TimeTo, string DocCode, string NurseCode, string HelperCode, string BeutCode, string Type)
        {
            try
            {
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_CheckAppointmentExists";

                command.Parameters.Clear();
                //command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Date));
                command.Parameters.Add(new SqlParameter("@TimeFrom", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TimeFrom));
                command.Parameters.Add(new SqlParameter("@TimeTo", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TimeTo));
                command.Parameters.Add(new SqlParameter("@DocCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocCode));
                command.Parameters.Add(new SqlParameter("@BeatyCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BeutCode));
                command.Parameters.Add(new SqlParameter("@NurseCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NurseCode));
                command.Parameters.Add(new SqlParameter("@HelperCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HelperCode));
                command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Type));


                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_AndGetReader, ref emptyDs, null, ref emtyDTR, "Invoice");
                if(emtyDTR.HasRows)
                {
                    RecordFound = true;
                }
                else
                {
                    RecordFound = false;
                }
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                //ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.connection.Close();
            }
        }

        public void Getogf()
        {
            
            try
            {
                Ads = dbconApi.getDataset(strSqlStatement, "Ads");
            }
            catch (Exception)
            {

                throw;
            }
       
    }

        public  static DataSet Getogfst(string Qry)
        {

            try
            {
              return  dbconApi.getDataset(Qry, "Ads");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ReadTempTransDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    blRecordFound = true;
                }
                else
                {
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void GetOrgDocumentNo()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader("select Inv from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (objdtReader.Read())
                {
                    intTempDocNo = Convert.ToInt32(objdtReader[0]);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);
                    if (LoginManager.UserName.Trim().Length >= 2)
                    {
                        strOrgDocNo = LoginManager.UserName.Trim().Substring(0, 2).ToUpper() + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo; ;
                    }
                    else
                    {
                        strOrgDocNo = LoginManager.UserName.Trim().ToUpper() + "0" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo; ;
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void InvoiceApply(bool sinhala)
        {
            //DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                ///GetOrgDocumentNo();
                //   strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_InvoiceApply";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 11, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@PoNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPoNo));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@SalesAssist", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSalesAssistant));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@GrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decGrossAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Tax", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTax));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@PayRemark1", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComments));
                command.Parameters.Add(new SqlParameter("@PayType", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, payType));
                command.Parameters.Add(new SqlParameter("@CashPayAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CashPayAmount));
                command.Parameters.Add(new SqlParameter("@DueBalance", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, dcDueBalance));
                command.Parameters.Add(new SqlParameter("@InvoType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvTypeRW));
                command.Parameters.Add(new SqlParameter("@VATINV", VATINV));
                command.Parameters.Add(new SqlParameter("@INVNO", strInvNo));
                command.Parameters.Add(new SqlParameter("@loyalityNo", LoyalityNo));
                command.Parameters.Add(new SqlParameter("@UnitNo", LoginManager.MachineUnit));
                command.Parameters.Add(new SqlParameter("@TransNo", _TransNo));
                command.Parameters.Add(new SqlParameter("@OtherCharge", _OtherCharges));
                command.Parameters.Add(new SqlParameter("@Tech1", Tech1));
                command.Parameters.Add(new SqlParameter("@Tech2", Tech2));
                command.Parameters.Add(new SqlParameter("@TaxBill", TaxBill));
                command.Parameters.Add(new SqlParameter("@ConNo", ConNo));
                command.Parameters.Add(new SqlParameter("@ConPer", ConPer));
                command.Parameters.Add(new SqlParameter("@BookingNo", BookNo));
                command.Parameters.Add(new SqlParameter("@InvTypeFor", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvType));
                command.Parameters.Add(new SqlParameter("@Rdatefrom", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rdate_from));
                command.Parameters.Add(new SqlParameter("@RdateTo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rdate_To));
                //command.Parameters.Add(new SqlParameter("@Rdatefrom", SqlDbType.NVarChar, 15) { Value = Rdate_from.ToString() });
                //command.Parameters.Add(new SqlParameter("@RdateTo", SqlDbType.NVarChar, 15) { Value = Rdate_To.ToString() });

                //SqlDataAdapter da = new SqlDataAdapter(command);
                //da.Fill(dsForReport = new DataSet(), "dsInvoiceDetails");

                dsForReport = new DataSet();
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_AndGetDataset, ref dsForReport, "dsInvoiceDetails", ref emtyDTR, "Invoice");

                dsForReport.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                dsForReport.Tables[2].TableName = "tbPaidPaymentMode";

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                OrgDocNo = (string)(command.Parameters["@OrgDoc_No"].Value.ToString());
            }
            finally
            {
                dbconApi.connection.Close();

            }
        }

        public void InvoiceSave()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                //GetOrgDocumentNo();
                strOrgDocNo = strTempDocumentNo;
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_InvoiceSave";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@PoNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPoNo));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@SalesAssist", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSalesAssistant));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@GrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decGrossAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Tax", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTax));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@PayRemark1", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComments));
                command.Parameters.Add(new SqlParameter("@PayType", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, payType));
                command.Parameters.Add(new SqlParameter("@INV_Type", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvTypeRW));
                command.Parameters.Add(new SqlParameter("@OtherCharge", _OtherCharges));
                command.Parameters.Add(new SqlParameter("@Tech1", Tech1));
                command.Parameters.Add(new SqlParameter("@Tech2", Tech2));
                command.Parameters.Add(new SqlParameter("@ConNo", ConNo));
                command.Parameters.Add(new SqlParameter("@ConPer", ConPer));
                command.Parameters.Add(new SqlParameter("@BookingNo", BookNo));
                command.Parameters.Add(new SqlParameter("@InvTypeFor", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvType));
                command.Parameters.Add(new SqlParameter("@Rdatefrom", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rdate_from));
                command.Parameters.Add(new SqlParameter("@RdateTo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Rdate_To));

                // command.ExecuteNonQuery();

                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.connection.Close();
            }
        }

        public void DeleteProductDetaile(bool Continuesly)
        {
            try
            {
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                if (Continuesly)
                {
                    command.CommandText = "sp_InvoiceTemp_Delete_Con";
                    command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                    command.Parameters.Add(new SqlParameter("@Ln", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, lnNo));
                }
                else
                {
                    command.CommandText = "sp_InvoiceTemp_Delete";
                    command.Parameters.Add(new SqlParameter("@BatchNo", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBatchNo));
                }
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@SellingPrice", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SellingPrice));
                command.Parameters.Add(new SqlParameter("@SerialNo", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSerialNo));
                //  command.ExecuteNonQuery();

                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.connection.Close();
            }
        }

        public void ReadProductPriceLevel()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(SqlStatement);
                if (objdtReader.Read())
                {
                    PPLRecoudFound = true;
                }
                else
                {
                    PPLRecoudFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void GetPriceLevel()
        {
            try
            {
                ProductPriceLevel = dbconApi.getDataset(SqlStatement, DataetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void GetDiscountLevel()
        {
            try
            {
                dsDiscountLevel = dbconApi.getDataset(SqlStatement, DataetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void GetMarkedPrice()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (objdtReader.Read())
                {
                    MarkedPrice = (decimal)objdtReader["Marked_Price"];
                    blRecordFound = true;
                }
                else
                {
                    MarkedPrice = 0;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }


        public void GetProductPriceLevelBatchWise()
        {
            try
            {
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductPriceLevel";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Sate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, State));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Qty));

                //SqlDataAdapter da = new SqlDataAdapter(command);
                //da.Fill(dsProductPriceLevel = new DataSet(), "dsProduct");

                dsProductPriceLevel = new DataSet();
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_AndGetDataset, ref dsProductPriceLevel, "dsProduct", ref emtyDTR, "Invoice");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.connection.Close();
            }
        }

        //public void SIP_Stock(string strServerName, string strDbName, string strUserName, string strPassword)
        //{
        //    try
        //    {
        //        Ds =dbconApi.get_SIP_Dataset(SqlStatement, DataetName, strServerName, strDbName, strUserName, strPassword);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsClear.ErrMessage(ex.Message, ex.StackTrace);
        //    }
        //}

        public void Get_Sale_Stock()
        {
            try
            {
                Ds = dbconApi.getDataset(SqlStatement, DataetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }


        private string strBankName;
        public string SelectBankName
        {
            get { return strBankName; }
            set { strBankName = value; }
        }

        private string strBranchName;
        public string BranchName
        {
            get { return strBranchName; }
            set { strBranchName = value; }
        }

        private string strChequeNo;
        public string ChequeNo
        {
            get { return strChequeNo; }
            set { strChequeNo = value; }
        }

        private string strChequeDate;
        public string ChequeDate
        {
            get { return strChequeDate; }
            set { strChequeDate = value; }
        }

        public DataSet dsBankDetails;
        public DataSet BankName
        {
            get { return dsBankDetails; }
            set { dsBankDetails = value; }
        }

        public string strPay_Type;
        public object ReadSavedTem;

        public string Pay_Type
        {
            get { return strPay_Type; }
            set { strPay_Type = value; }
        }

        public string code { get; set; }
        public string Unit_no { get; set; }
        public string Salsmen_Code { get; set; }
        public string Po_Number { get; set; }
        public string strSerialNo { get; set; }
        public string strInvType { get; set; }
        public string Rdate_from { get; set; }
        public string Rdate_To { get; set; }
        public void AddToPaymentModeForRpt()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_AddPaymentMode";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Temp_DocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Payment_Mode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPay_Type));
                command.Parameters.Add(new SqlParameter("@Bank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBankName));
                command.Parameters.Add(new SqlParameter("@Cheque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strChequeNo));
                command.Parameters.Add(new SqlParameter("@Cheque_Date", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strChequeDate));
                command.Parameters.Add(new SqlParameter("@Branch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBranchName));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "REC"));

                //command.ExecuteNonQuery();
                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                dbconApi.connection.Close();
            }

        }
        public void CheckStock(string docNo, string Iid)
        {
            try
            {
                //get Temporary DataSet For Grn
                if (Iid == "INV")
                {
                    Ads = dbconApi.getDataset("select  ST.Prod_Code,sum(ST.Stock)[Stock],sum((T.Qty+T.FreeQty))[Qty] FROM TransactionTemp_Details T JOIN dbo.Stock_Master_Batch ST ON ST.BatchNo = T.BatchNo AND ST.Prod_Code = T.Prod_Code AND ST.Loca = T.Loca JOIN dbo.Stock_Master S ON S.Loca = ST.Loca AND S.Prod_Code = ST.Prod_Code WHERE Doc_No = '" + docNo + "' AND S.MinusAllow = 0 AND IId = '" + Iid + "' AND T.Loca = " + LoginManager.LocaCode + " group by ST.Prod_Code  ", "Invoice");
                }
                else
                {
                    Ads = dbconApi.getDataset("select  ST.Prod_Code,ST.Stock,(T.Qty+T.FreeQty)[Qty] FROM TransactionTemp_Details T JOIN dbo.Stock_Master_Batch ST ON ST.BatchNo = T.BatchNo AND ST.Prod_Code = T.Prod_Code AND ST.Loca = T.Loca JOIN dbo.Stock_Master S ON S.Loca = ST.Loca AND S.Prod_Code = ST.Prod_Code WHERE Doc_No = '" + docNo + "' AND S.MinusAllow=0 AND IId = '" + Iid + "' AND T.Loca  = " + LoginManager.LocaCode + " Order by Ln", "Invoice");
                }
            }

               
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        public void getDataSet(string sqlStatement, string dsName)
        {
            Ads = dbconApi.getDataset(sqlStatement, dsName);
        }

        public void ReadSalsmenDetails()
        {
            try
            {
                objdtReader = dbconApi.GetDataTableReader(strSqlStatement);
                blRecordFound = false;
                if (objdtReader.Read())
                {

                    Salsmen_Code = objdtReader["Sale_Code"].ToString().Trim();
                    SalesAssistant = objdtReader["Sale_Name"].ToString().Trim();


                    blRecordFound = true;
                }
                else
                {
                    Salsmen_Code = string.Empty;
                    SalesAssistant = string.Empty;
                   
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbconApi.CloseReader();
                objdtReader.Dispose();
            }
        }

        public void CheckExistSalsmen()
        {
       
            try
            {
                DataReader = dbcon.GetReader(SqlStatement);
                RecordFound = false;
                if (DataReader.Read())
                {
                    RecordFound = true;
                }
                else
                {
                    RecordFound = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbcon.CloseConnection();
               
            }

        }
        public bool CheckRead()
        {
            try
            {

                SqlDataReader dr;
                dr = dbcon.GetReader(SqlStatement);

                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataSet getds()
        {
            try
            {

                return Ds=Ads = dbcon.getDataset(SqlStatement, "ds");


            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AppointmentBooking(string Date,string timefrom,string timeto,string custcode, string Ftype, string Memo, string DocCode, string NurseCode, string HelperCode, string BeaticianCode, string ServiceCode, string DocName, string NurseName, string HelperName, string BeaticianName, string ServiceItem)
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_AppointemntAdd";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@CustCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, custcode));
                command.Parameters.Add(new SqlParameter("@AppType", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Ftype));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Memo));
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Date));
                command.Parameters.Add(new SqlParameter("@TimeFrom", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, timefrom));
                command.Parameters.Add(new SqlParameter("@TimeTo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, timeto));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                // Added By Nipuni - 2024.03.29
                command.Parameters.Add(new SqlParameter("@DocCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocCode));
                command.Parameters.Add(new SqlParameter("@NurseCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NurseCode));
                command.Parameters.Add(new SqlParameter("@HelperCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HelperCode));
                command.Parameters.Add(new SqlParameter("@BeuticianCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BeaticianCode));
                command.Parameters.Add(new SqlParameter("@ServiceCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceCode));
                command.Parameters.Add(new SqlParameter("@DocName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocName));
                command.Parameters.Add(new SqlParameter("@NurseName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NurseName));
                command.Parameters.Add(new SqlParameter("@HelperName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HelperName));
                command.Parameters.Add(new SqlParameter("@BeuticianName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BeaticianName));
                command.Parameters.Add(new SqlParameter("@ServiceItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceItem));

                //command.ExecuteNonQuery();
                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AppointmentDelete(string Date, string timefrom, string custcode, string Ftype, string DocCode, string NurseCode, string HelperCode, string BeaticianCode, string ServiceCode, string DocName, string NurseName, string HelperName, string BeaticianName, string ServiceItem)
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbconApi.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbconApi.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_AppointemntDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@CustCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, custcode));
                command.Parameters.Add(new SqlParameter("@AppType", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Ftype));
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Date));
                command.Parameters.Add(new SqlParameter("@TimeFrom", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, timefrom));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                // Added By Nipuni - 2024.03.29
                command.Parameters.Add(new SqlParameter("@DocCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocCode));
                command.Parameters.Add(new SqlParameter("@NurseCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NurseCode));
                command.Parameters.Add(new SqlParameter("@HelperCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HelperCode));
                command.Parameters.Add(new SqlParameter("@BeaticianCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BeaticianCode));
                command.Parameters.Add(new SqlParameter("@ServiceCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceCode));
                command.Parameters.Add(new SqlParameter("@DocName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocName));
                command.Parameters.Add(new SqlParameter("@NurseName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NurseName));
                command.Parameters.Add(new SqlParameter("@HelperName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HelperName));
                command.Parameters.Add(new SqlParameter("@BeaticianName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BeaticianName));
                command.Parameters.Add(new SqlParameter("@ServiceItem", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceItem));

                //command.ExecuteNonQuery();
                DataSet emptyDs = null;
                DataTableReader emtyDTR = null;
                dbconApi.executeStoredProcedure(ref command, dbconApi.sqlCommandExecuteTypes.ExecuteSp_WithoutResult, ref emptyDs, null, ref emtyDTR, "Invoice");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //add by kalani
        public void CheckSerialStock(string docNo, string Iid)
        {
            try
            {
                
                Ads = dbconApi.getDataset("select Prod_Code, TTD.Qty, SA.Qty[SA_Qty], SA.SerialNo from TransactionTemp_Details TTD LEFT JOIN SerialNo_Apply SA ON SA.ProdCode = TTD.Prod_Code AND SA.Loca = TTD.Loca AND SA.SerialNo = TTD.Serial_No where Doc_No = '"+TempDocNo.Trim()+"'  AND SA.Loca = '"+LoginManager.LocaCode+"'  AND IId = '" + Iid + "' order by TTD.Id_No desc", "Invoice");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
    }
}
