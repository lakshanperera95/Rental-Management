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
    public class clsQuotaion
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
        private string strDataSetName;
        private string strPostDate;
        private string strReference;
        private string strRemark;
        private string strOrgDocNo;
        private string strSavedDocNo;
        private string strRecallSaveDocNo;
        private string strDisc;
        private string strPoNo;
        private string strPay_Type;
        private string strUnit;
        private string strComments;

        private decimal fltQty;
        private decimal fltCurrentQty;
        private decimal fltFreeQty;
        private decimal fltTotalQty;

        private decimal decPurchasePrice;
        private decimal decWholePrice;
        private decimal decDiscount;
        private decimal decGrossAmount;
        private decimal decAmount;
        private decimal decTotalAmount;
        private decimal decTax;

        private DataSet dsItemDataSet;
        private DataSet dsCustomerDataSet;
        private DataSet dsTempInvoice;
        private DataSet dsForReport;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion

        #region Properties
        public string TempDocNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
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

        public string OrgDocNo
        {
            get { return strOrgDocNo; }
            set { strOrgDocNo = value; }
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

        public string Pay_Type
        {
            get { return strPay_Type; }
            set { strPay_Type = value; }
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

        public decimal SellingPrice
        {
            get { return decWholePrice; }
            set { decWholePrice = value; }
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

        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
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
                    //String.Format("{0:00000}", 15); 
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo = "STM" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "QUO"));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                GetTempDataset();
            }
        }

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Grn
                dsTempInvoice = dbcon.getDataset("select Prod_Code, Prod_Name, Unit, Purchase_Price, Selling_Price, Qty, FreeQty, Discount,Amount FROM TransactionTemp_Details WHERE Doc_No = '" + strTempDocumentNo + "' AND IId = 'QUO' AND Loca = " + LoginManager.LocaCode + " Order by Ln", "Invoice");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetDataSetForReport()
        {
            try
            {
                dsForReport = dbcon.getDataset("SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code,Transaction_Header.To_LocaDesc Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.Code PayRemark1, Transaction_Header.PayRemark1 Address1, Transaction_Header.PayRemark2 Address2, Transaction_Header.PayRemark3 Address3, '' Address4, Location.Loca_Descrip, Location.Address1 Loca_Address2, Location.Address2 Loca_Address2, Location.Address3 Loca_Address3, Location.Tel Loca_Tel, Location.Fax Loca_Fax, Location.EMail Loca_EMail, Location.TaxReg Loca_TaxReg, Location.Web_Address Loca_Web_Address, 'Original' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.Doc_No = '" + strOrgDocNo + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'QUO' ORDER BY Ln;SELECT * FROM CompanyProfile", "dsInvoiceDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetDataSetForPreview()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);
                dsForReport = dbcon.getDataset("SELECT '" + strTempDocumentNo + "' Doc_no, '" + strCustCode + "' Cust_code,'" + strCustName + "' Cust_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date,  '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + strPay_Type + "' Pay_Type, " + decTax + " Tax, '" + strSalesAssistant + "' Sales_Assist,TransactionTemp_Details.Prod_code, TransactionTemp_Details.Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.FreeQty, TransactionTemp_Details.Purchase_Price, TransactionTemp_Details.Selling_Price, TransactionTemp_Details.Discount, TransactionTemp_Details.Amount, TransactionTemp_Details.Ln, 'Temporary' Status, '" + strComments + "' PayRemark1, '" + strAddress1 + "' Address1, '" + strAddress2 + "' Address2,'" + strAddress3 + "' Address3, '' Address4, Location.Loca_Descrip, Location.Address1 Loca_Address2, Location.Address2 Loca_Address2, Location.Address3 Loca_Address3, Location.Tel Loca_Tel, Location.Fax Loca_Fax, Location.EMail Loca_EMail, Location.TaxReg Loca_TaxReg, Location.Web_Address Loca_Web_Address, 'Temporary' Status  FROM TransactionTemp_Details INNER JOIN Location ON TransactionTemp_Details.Loca = Location.Loca WHERE TransactionTemp_Details.Doc_No = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = 'QUO' ORDER BY Ln", "dsInvoiceDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetItemDetails()
        {
            try
            {
                dsItemDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    strCustName = DataReader["To_LocaDesc"].ToString().Trim();
                    strAddress1 = DataReader["PayRemark1"].ToString().Trim();
                    strAddress2 = DataReader["PayRemark2"].ToString().Trim();
                    strAddress3 = DataReader["PayRemark3"].ToString().Trim();
                    strPay_Type = DataReader["Pay_Type"].ToString().Trim();
                    strRemark = DataReader["Remarks"].ToString().Trim();
                    strReference = DataReader["Reference"].ToString().Trim();
                    strComments = DataReader["Code"].ToString().Trim();
                    strSalesAssistant = DataReader["Ref_Name"].ToString().Trim();
                    decTax = (decimal)DataReader["Tax"];
                    decDiscount = (decimal)DataReader["Discount"];

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
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "QUO"));

                    command.ExecuteNonQuery();
                    command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                }
                catch (Exception e)
                {
                    //Write to Log
                    DateTime dtCurrentDate = DateTime.Now;
                    FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            //***
        }

        public void GetTotalValues()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select isnull(sum(Amount),0) from TransactionTemp_Details WHERE Iid = 'QUO' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
                dbcon.OpenConnection();
                decTotalAmount = decimal.Parse(command.ExecuteScalar().ToString());
                command.CommandText = "select isnull(sum(Qty),0) from TransactionTemp_Details WHERE Iid = 'QUO' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
                fltTotalQty = decimal.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetCustomerDetails()
        {
            try
            {
                dsCustomerDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 011. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    decPurchasePrice = (decimal)DataReader["Purchase_price"];
                    decWholePrice = (decimal)DataReader["Whole_Price"];
                    strUnit = DataReader["Unit"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decWholePrice = 0;
                    strUnit = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdateInvoiceTempDataSet()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_QuotationTemp_Update";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "QUO"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@FreeQty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltFreeQty));
                command.Parameters.Add(new SqlParameter("@Whole_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decWholePrice));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUnit));
                command.Parameters.Add(new SqlParameter("@Pack_Size", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, intPackSize));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 014. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 015. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetOrgDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader("select Quot from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);

                    strOrgDocNo = "STM" + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo; ;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void InvoiceApply()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                GetOrgDocumentNo();
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_QuotationApply";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@Cust_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustName));
                command.Parameters.Add(new SqlParameter("@PayRemark1", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@PayRemark2", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@PayRemark3", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@SalesAssist", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSalesAssistant));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "QUO"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@GrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decGrossAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Tax", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTax));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComments));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.CommandText = "sp_QuotationSave";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@PoNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@Cust_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustName));
                command.Parameters.Add(new SqlParameter("@PayRemark1", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@PayRemark2", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@PayRemark3", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@SalesAssist", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSalesAssistant));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "QUO"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@GrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decGrossAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Tax", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTax));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComments));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 018. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteProductDetaile()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GrnTemp_Delete";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "QUO"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsWholeSaleInvoice 019. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
    }
}
