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
    public class clsWholeSaleInvoice:clsPublic
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

        private decimal decPurchasePrice;
        private decimal decMarkedPrice;
        private decimal decWholePrice;
        private decimal deSellingPrice1;
        private decimal decDiscount;
        private decimal decGrossAmount;
        private decimal decAmount;
        private decimal decTotalAmount;
        private decimal decTax;

        private DataSet dsItemDataSet;
        private DataSet dsCustomerDataSet;
        private DataSet dsTempInvoice;
        private DataSet dsForReport;
        private DataSet dsProductPriceLevel;
        
        private Boolean blPPLRecoudFound;
        private Boolean blRecordFound;
        private Boolean blVatCus;
        private string strvatNo;
        private SqlDataReader DataReader;
        #endregion

        #region Properties
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
        public string  vatNo
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

        public DataSet GetCustomerDataSet
        {
            get { return dsCustomerDataSet; }
            set { dsCustomerDataSet = value; }
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






        #endregion


        //Get Tempory Document No
        public void GetTempDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);                   
                    strTempDocumentNo = "INV" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo; ;

                    intTempDocNo = (int)DataReader.GetSqlInt32(1);
                    strOrgDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strOrgDocumentNo = "INV" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocumentNo; ;
                   

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.CloseReader();
                DataReader.Dispose();
            }

            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UpdateTempDocNo";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.connection.Close();

                GetTempDataset();
            }
        }

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsTempInvoice = dbcon.getDataset("select Prod_Code, Prod_Name, Unit, Purchase_Price, Selling_Price, Qty, FreeQty, Discount,Amount, Ln, ExpDate, BatchNo,0[VAT] FROM TransactionTemp_Details WHERE Doc_No = '" + strTempDocumentNo + "' AND IId = 'INV' AND Loca = " + LoginManager.LocaCode + " Order by Ln", "Invoice");
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
                dsForReport = dbcon.getDataset("SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Original' Status, Transaction_Details.Marked_Price, '" + LoginManager.CompanyName + "' AS [CompanyName], '" + LoginManager.CompanyAddress + "' AS [CompanyAddress], '" + LoginManager.CompanyTelephone + "' AS [CompanyTelephone], '" + LoginManager.CompanyEmail + "' AS [CompanyEmail] FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Header.Doc_No = '" + strOrgDocNo + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'INV' ORDER BY Ln", "dsInvoiceDetails");
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
                if (sinhala)
                {
                    dsForReport = dbcon.getDataset("SELECT '" + strTempDocumentNo + "' Doc_no, '" + strCustCode + "' Cust_code,'" + strCustName + "' Cust_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date,  '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + payType + "' Pay_Type, " + decTax + " Tax, '" + strSalesAssistant + "' Sales_Assist, TransactionTemp_Details.Prod_code, product.singhala AS Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.FreeQty, TransactionTemp_Details.Purchase_Price, TransactionTemp_Details.Selling_Price, TransactionTemp_Details.Discount, TransactionTemp_Details.Amount, TransactionTemp_Details.Ln, 'Temporary' Status,TransactionTemp_Details.Marked_Price, '" + strComments + "' PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, TransactionTemp_Details.Marked_Price, 'Temporary' Status , TransactionTemp_Details.Unit, TransactionTemp_Details.ExpDate, TransactionTemp_Details.BatchNo  FROM TransactionTemp_Details INNER JOIN Customer On Customer.Cust_Code = '" + strCustCode + "' INNER JOIN Product ON Product.prod_Code=TransactionTemp_Details.prod_Code  WHERE TransactionTemp_Details.Doc_No = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = 'INV' ORDER BY Ln; SELECT * from CompanyProfileSinhala ", "dsInvoiceDetails");
                }
                else
                {
                    dsForReport = dbcon.getDataset("SELECT '" + strTempDocumentNo + "' Doc_no, '" + strCustCode + "' Cust_code,'" + strCustName + "' Cust_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date,  '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + payType + "' Pay_Type, " + decTax + " Tax, '" + strSalesAssistant + "' Sales_Assist,TransactionTemp_Details.Prod_code, TransactionTemp_Details.Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.FreeQty, TransactionTemp_Details.Purchase_Price, TransactionTemp_Details.Selling_Price, TransactionTemp_Details.Discount, TransactionTemp_Details.Amount, TransactionTemp_Details.Ln, 'Temporary' Status,TransactionTemp_Details.Marked_Price, '" + strComments + "' PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, TransactionTemp_Details.Marked_Price, 'Temporary' Status , TransactionTemp_Details.Unit, TransactionTemp_Details.ExpDate, TransactionTemp_Details.BatchNo  FROM TransactionTemp_Details INNER JOIN Customer On Customer.Cust_Code = '" + strCustCode + "' WHERE TransactionTemp_Details.Doc_No = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = 'INV' ORDER BY Ln; SELECT * from CompanyProfile", "dsInvoiceDetails");
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
                dsItemDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
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
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strTempDocumentNo = strRecallSaveDocNo;
                    strCustCode = DataReader["Supplier_Id"].ToString().Trim();
                    strCustName = DataReader["Cust_Name"].ToString().Trim();
                    strAddress1 = DataReader["Address1"].ToString().Trim();
                    strAddress2 = DataReader["Address2"].ToString().Trim();
                    strAddress3 = DataReader["Address3"].ToString().Trim();
                    strPoNo = DataReader["Porder_No"].ToString().Trim();
                    payType = DataReader["Pay_Type"].ToString().Trim();
                    strRemark = DataReader["Remarks"].ToString().Trim();
                    strReference = DataReader["Reference"].ToString().Trim();
                    strComments = DataReader["PayRemark1"].ToString().Trim();
                    strSalesAssistant = DataReader["Ref_Name"].ToString().Trim();
                    decTax = (decimal)DataReader["Tax"];
                    decDiscount = (decimal)DataReader["Discount"];
                    InvTypeRW = DataReader["To_Loca"].ToString();

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
                dbcon.CloseReader();
                DataReader.Dispose();
            }

            //Reload Saved Items to the Tempory
            if (blRecordFound == true)
            {
                try
                {
                    dbcon.OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.Connection = dbcon.connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InvoiceRecall";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRecallSaveDocNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));

                    command.ExecuteNonQuery();
                    command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                finally
                {
                    dbcon.connection.Close();
                }
            }
            //***
        }
        public void RecallForReturn()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                   // strTempDocumentNo = strRecallSaveDocNo;
                    strCustCode = DataReader["Supplier_Id"].ToString().Trim();
                    strCustName = DataReader["Cust_Name"].ToString().Trim();
                    strAddress1 = DataReader["Address1"].ToString().Trim();
                    strAddress2 = DataReader["Address2"].ToString().Trim();
                    strAddress3 = DataReader["Address3"].ToString().Trim();
                    strPoNo = DataReader["Porder_No"].ToString().Trim();
                    payType = DataReader["Pay_Type"].ToString().Trim();
                    strRemark = DataReader["Remarks"].ToString().Trim();
                    strReference = DataReader["Reference"].ToString().Trim();
                    strComments = DataReader["PayRemark1"].ToString().Trim();
                    strSalesAssistant = DataReader["Ref_Name"].ToString().Trim();
                    decTax = (decimal)DataReader["Tax"];
                    decDiscount = (decimal)DataReader["Discount"];
                    InvTypeRW = DataReader["To_Loca"].ToString();

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
                dbcon.CloseReader();
                DataReader.Dispose();
            }

            //Reload Saved Items to the Tempory
            if (blRecordFound == true)
            {
                try
                {
                    dbcon.OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.Connection = dbcon.connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InvoiceRecallToReturn";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                    command.Parameters.Add(new SqlParameter("@DocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRecallSaveDocNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));

                    command.ExecuteNonQuery();
                    command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                finally
                {
                    dbcon.connection.Close();
                }
            }
            //***
        }
        public void GetTotalWithoutDiscNotAllow()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select isnull(sum(Amount),0) from TransactionTemp_Details INNER JOIN Product On product.prod_code=TransactionTemp_Details.prod_code WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "' AND product.discountNotAllow = 'F' ";
                dbcon.OpenConnection();
                TotAmountForDiscLevel = decimal.Parse(command.ExecuteScalar().ToString());
                

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }

        public void GetMaxPriceBatch()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select ISNULL(max(priceBatch),1) from tbProductPriceLevel WHERE Prod_Code = '" + ProductCode + "' AND " + QtyColoumnName + " <= '" + Qty + "'";
                dbcon.OpenConnection();
                priceBatch = int.Parse(command.ExecuteScalar().ToString());
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }

        public void GetTotalValues()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select isnull(sum(Amount),0) from TransactionTemp_Details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
                dbcon.OpenConnection();
                decTotalAmount = decimal.Parse(command.ExecuteScalar().ToString());
                command.CommandText = "select isnull(sum(Qty),0) from TransactionTemp_Details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
                fltTotalQty = decimal.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }



        public void GetCustomerDetails()
        {
            try
            {
                dsCustomerDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void ReadCustomerDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strCustCode = DataReader["Cust_Code"].ToString().Trim();
                    strCustName = DataReader["Cust_Name"].ToString().Trim();
                    strAddress1 = DataReader["Address1"].ToString().Trim();
                    strAddress2 = DataReader["Address2"].ToString().Trim();
                    strAddress3 = DataReader["Address3"].ToString().Trim();
                    blVatCus =(Boolean) DataReader["VAT"];
                    strvatNo = DataReader["VatNo"].ToString().Trim();
                    //_Balance = (decimal)DataReader["Balance_Amount"];
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void ReadCustomerBalanceDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
            
                    _Balance = (decimal)DataReader["Balance_Amount"];
                    InvCount = (int)DataReader["Qty"];
                    UnSetReturn = (decimal)DataReader["Unsettled_Refund"];
                    Cheque_InHand = (decimal)DataReader["Cheque_InHand"];
                    blRecordFound = true;
                }
                else
                {
                    _Balance =0;
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void ReadProductDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strProductCode = DataReader["Prod_Code"].ToString().Trim();
                    strProductName = DataReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(5);
                    intPackSize = (int)DataReader.GetSqlInt16(6);
                    MarkedPrice = (decimal)DataReader["Marked_Price"];
                    decPurchasePrice = (decimal)DataReader["Purchase_price"];
                    decWholePrice = (decimal)DataReader["Whole_Price"];
                    SellingPrice1 = (decimal)DataReader["Selling_Price"];
                    strUnit = DataReader["Unit"].ToString().Trim();
                    blUnderCost = (bool)DataReader["UnderCost"];

                    dec_WPrice = (decimal)DataReader["Whole_Price"];
                    dec_RPrice = (decimal)DataReader["Selling_Price"];
                    dec_DPrice = (decimal)DataReader["Disc_Price"];
                    dec_MMPrice = (decimal)DataReader["Marked_Price"];

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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }
        public void ReadProductDetailsInv()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strProductCode = DataReader["Prod_Code"].ToString().Trim();
                    strProductName = DataReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(5);
                    intPackSize = (int)DataReader.GetSqlInt16(6);
                    MarkedPrice = (decimal)DataReader["Marked_Price"];
                    decPurchasePrice = (decimal)DataReader["Purchase_price"];
                    decWholePrice = (decimal)DataReader["Whole_Price"];
                    SellingPrice1 = (decimal)DataReader["Selling_Price"];
                    strUnit = DataReader["Unit"].ToString().Trim();
                    blUnderCost = (bool)DataReader["UnderCost"];

                    dec_WPrice = (decimal)DataReader["Whole_Price"];
                    dec_RPrice = (decimal)DataReader["Selling_Price"];
                    dec_DPrice = (decimal)DataReader["Disc_Price"];
                    dec_MMPrice = (decimal)DataReader["Marked_Price"];

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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }
        public void ReadExsistProductDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    fltQty = (decimal)DataReader.GetSqlDecimal(0);
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void UpdateInvoiceTempDataSet(bool Continuesly)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
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
                command.Parameters.Add(new SqlParameter("@PayType", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, payType));
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
                command.Parameters.Add(new SqlParameter("@BatchNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBatchNo));
                command.Parameters.Add(new SqlParameter("@AutoSelect", SqlDbType.Bit , 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AutoSelect));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void ReadTempTransDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void GetOrgDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader("select Inv from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void InvoiceApply(bool sinhala)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                ///GetOrgDocumentNo();
             //   strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
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
                command.Parameters.Add(new SqlParameter("@UnitNo", LoginManager.MachinName));
                command.Parameters.Add(new SqlParameter("@TransNo", _TransNo));
                command.Parameters.Add(new SqlParameter("@OtherCharge", _OtherCharges));
               
             
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsForReport = new DataSet(), "dsInvoiceDetails");
                if (sinhala)
                {
                    dsForReport.Tables["dsInvoiceDetails1"].TableName = "dsCompanyLogo";
                }
                else
                {
                    dsForReport.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                }
                dsForReport.Tables[2].TableName = "tbPaidPaymentMode";

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                OrgDocNo = (string)(command.Parameters["@OrgDoc_No"].Value.ToString());
            }
            finally
            {
                dbcon.connection.Close();
               
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

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
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


                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void DeleteProductDetaile(bool Continuesly)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
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
                    command.Parameters.Add(new SqlParameter("@BatchNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBatchNo));
                }
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@SellingPrice", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SellingPrice));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void ReadProductPriceLevel()
        {
            try
            {
                DataReader = dbcon.GetReader(SqlStatement);
                if (DataReader.Read())
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void GetPriceLevel()
        {
            try
            {
                ProductPriceLevel = dbcon.getDataset(SqlStatement, DataetName);
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
                dsDiscountLevel = dbcon.getDataset(SqlStatement, DataetName);
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
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    MarkedPrice = (decimal)DataReader["Marked_Price"];
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
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }


        public void GetProductPriceLevelBatchWise()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductPriceLevel";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Sate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, State));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Qty));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsProductPriceLevel = new DataSet(), "dsProduct");
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void SIP_Stock(string strServerName, string strDbName, string strUserName, string strPassword)
        {
            try
            {
                Ds = dbcon.get_SIP_Dataset(SqlStatement, DataetName, strServerName, strDbName, strUserName, strPassword);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void Get_Sale_Stock()
        {
            try
            {
                Ds = dbcon.getDataset(SqlStatement, DataetName);
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
        public string Pay_Type
        {
            get { return strPay_Type; }
            set { strPay_Type = value; }
        }
        public void AddToPaymentModeForRpt()
        {
            try
            {
                //UpDate Record No
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
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

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                dbcon.connection.Close();
            }

        }
    }
}
