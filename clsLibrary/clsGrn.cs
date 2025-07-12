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
    public class clsGrn : clsPublic
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;
        private int intPackSize;

        private string strLocaCode;
        private string strLocaName;
        private string strSuppCode;
        private string strSuppName;
        private string strProductCode;
        private string strProductName;
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
        private string strInvNo;
        private string strPoNo;
        private string strPay_Type;
        private string strUnit;

        private decimal fltQty;
        private decimal fltCurrentQty;
        private decimal fltFreeQty;
        private decimal fltTotalQty;

        private decimal decPurchasePrice;
        private decimal decSellingPrice;
        private decimal decDiscount;
        private decimal decGrossAmount;
        private decimal decAmount;
        private decimal decTotalAmount;
        private decimal decInvAmount;
        private decimal decTax;

        private DataSet dsItemDataSet;
        private DataSet dsSupplierDataSet;
        private DataSet dsTempGrn;
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
        private string strInvDate;
        public string InvDate
        {
            get { return strInvDate; }
            set { strInvDate = value; }
        }

        public string RecallSaveDocNo
        {
            get { return strRecallSaveDocNo; }
            set { strRecallSaveDocNo = value; }
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

        public string SuppCode
        {
            get { return strSuppCode; }
            set { strSuppCode = value; }
        }

        public string SuppName
        {
            get { return strSuppName; }
            set { strSuppName = value; }
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

        public string InvNo
        {
            get { return strInvNo; }
            set { strInvNo = value; }
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
            get { return decSellingPrice; }
            set { decSellingPrice = value; }
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

        public decimal InvAmount
        {
            get { return decInvAmount; }
            set { decInvAmount = value; }
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

        public DataSet GetSupplierDataset
        {
            get { return dsSupplierDataSet; }
            set { dsSupplierDataSet = value; }
        }

        public DataSet GetReportDataset
        {
            get { return dsForReport; }
            set { dsForReport = value; }
        }

        public DataSet TempGrn
        {
            get { return dsTempGrn; }
            set { dsTempGrn = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        private decimal _MarkedPrice;

        public decimal MarkedPrice
        {
            get { return _MarkedPrice; }
            set { _MarkedPrice = value; }
        }

        private decimal _WholePrice;

        public decimal WholePrice
        {
            get { return _WholePrice; }
            set { _WholePrice = value; }
        }
        private decimal decVatAmount;

        public decimal VatAmount
        {
            get { return decVatAmount; }
            set { decVatAmount = value; }
        }

        private string _PostDate;

        public string PostDate
        {
            get { return _PostDate; }
            set { _PostDate = value; }
        }

        private SqlDataReader _Dr;
        public SqlDataReader Dr
        {
            get { return _Dr; }
            set { _Dr = value; }
        }

        private int lnNo;
        public int _lnNo
        {
            get { return lnNo; }
            set { lnNo = value; }
        }

        private string strShipment;
        public string _strShipment
        {
            get { return strShipment; }
            set { strShipment = value; }
        }

        private string expDate;
        public string _expDate
        {
            get { return expDate; }
            set { expDate = value; }
        }

        private bool blVatProd;
        public bool VatProd
        {
            get { return blVatProd; }
            set { blVatProd = value; }
        }

        private bool blVat;
        public bool VAT
        {
            get { return blVat; }
            set { blVat = value; }
        }
        private string strVatRegNo;
        public string VatRegNo
        {
            get { return strVatRegNo; }
            set { strVatRegNo = value; }
        }
        #endregion

        //Get Tempory Document No
        public void GetTempDocumentNo(string Iid)
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo = Iid + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrn 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UpdateTempDocNo";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Iid));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrn 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dsTempGrn = dbcon.getDataset("SELECT Prod_Code, Prod_Name, Unit, Purchase_Price, Selling_Price, Qty, FreeQty, Discount,Amount, ((Selling_Price*Qty)- (Purchase_Price*Qty))/(Purchase_Price*case Qty when 0 then 1 else Qty end)*100  [Margin] FROM TransactionTemp_Details WHERE Doc_No = '"+TempDocNo+"' AND IId = 'GRN' AND Loca = '"+LoginManager.LocaCode+"' Order by Ln", "GoodReceivedNote");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrn 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrn 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseReader();
            }
        }

        public void GetSupplierDetails()
        {
            try
            {
                dsSupplierDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrn 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(4);
                    intPackSize = (int)DataReader.GetSqlInt16(5);
                    decPurchasePrice = (decimal)DataReader["Purchase_price"];
                    decSellingPrice = (decimal)DataReader["Selling_Price"];
                    strUnit = DataReader["Unit"].ToString().Trim();
                    _MarkedPrice = (decimal)DataReader["Marked_Price"];
                    _WholePrice = (decimal)DataReader["Whole_Price"];
                    blVatProd = (bool)DataReader["VatProd"];
                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decSellingPrice = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrn 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadSupplierDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strSuppCode = DataReader["Supp_Code"].ToString().Trim();
                    strSuppName = DataReader["Supp_Name"].ToString().Trim();
                    try
                    {
                        strVatRegNo = DataReader["VAtNo"].ToString().Trim();
                        blVat = (bool)DataReader["VAT"];
                    }
                    catch (Exception)
                    {   }
                    blRecordFound = true;
                }
                else
                {
                    strSuppCode = string.Empty;
                    strSuppName = string.Empty;
                    strVatRegNo = string.Empty;
                    blRecordFound = false;
                    blVat = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdateGrnTempDataSet(bool ContinueslyEnter)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                if (ContinueslyEnter)
                {
                    command.CommandText = "sp_GrnTemp_Update_Con";
                }
                else
                {
                    command.CommandText = "sp_GrnTemp_Update";
                }
                
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@FreeQty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltFreeQty));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Selling_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decSellingPrice));
                command.Parameters.Add(new SqlParameter("@Unit", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUnit));
                command.Parameters.Add(new SqlParameter("@Pack_Size", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, intPackSize));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));
                command.Parameters.Add(new SqlParameter("@MarkedPrice", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _MarkedPrice));
                command.Parameters.Add(new SqlParameter("@WholePrice", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _WholePrice));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.ToString()));
                command.Parameters.Add(new SqlParameter("@expDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, expDate));
                command.Parameters.Add(new SqlParameter("@vatProd", blVatProd));


                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsTempGrn = new DataSet(), "GoodReceivedNote");
                //command.ExecuteNonQuery();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdatePDNTempDataSet()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_PDNTemp_Update";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "PDN"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.ToString()));


                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsTempGrn = new DataSet(), "GoodReceivedNote");
                //command.ExecuteNonQuery();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTotalValues(string IID)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select isnull(sum(Amount),0) from TransactionTemp_Details WHERE Iid = '"+IID+"' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
                dbcon.OpenConnection();
                decTotalAmount = decimal.Parse(command.ExecuteScalar().ToString());
                command.CommandText = "select isnull(sum(Qty + FreeQty),0) from TransactionTemp_Details WHERE Iid = '"+IID+"' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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



        public void GetOrgDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader("select Grn from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
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

            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 011. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GoodReceivedNoteApply()
        {
            //DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                //GetOrgDocumentNo();
            
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GoodReceivedNoteApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@PoNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPoNo));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode));
                command.Parameters.Add(new SqlParameter("@Inv_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvNo));
                command.Parameters.Add(new SqlParameter("@Inv_Amt", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decInvAmount));
                command.Parameters.Add(new SqlParameter("@Pay_Type", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPay_Type));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _PostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@GrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decGrossAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Tax", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTax));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@AccessUser", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AuthonticateUser));
                command.Parameters.Add(new SqlParameter("@Shipment", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strShipment));

                command.Parameters.Add(new SqlParameter("@VATPerProd", VAT));
                command.Parameters.Add(new SqlParameter("@VAT",  VatProd));
                command.Parameters.Add(new SqlParameter("@TaxAmount", VatAmount));
                command.Parameters.Add(new SqlParameter("@InvDate", strInvDate));

                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(GetReportDataset = new DataSet(), "dsGRNDetailsForRep");
                GetReportDataset.Tables["dsGRNDetailsForRep1"].TableName = "CompanyProfile";
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                OrgDocNo = (string)(command.Parameters["@OrgDoc_No"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void PDNoteApply()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                //GetOrgDocumentNo();
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_PDNoteApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "PDN"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                
                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(GetReportDataset = new DataSet(), "dsProductDiscard");
                GetReportDataset.Tables["dsProductDiscard1"].TableName = "CompanyProfile";
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                OrgDocNo = (string)(command.Parameters["@OrgDoc_No"].Value);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetDataSetForReport()
        {
            try
            {
                dsForReport = dbcon.getDataset("SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id ,Supplier.Supp_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, 'Original' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN supplier ON Transaction_Header.Supplier_Id = supplier.supp_code WHERE Transaction_Header.Doc_No = '" + strOrgDocNo + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'GRN' ORDER BY Ln", "dsGRNDetailsForRep");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetDataSetForReportPDN()
        {
            try
            {
                dsForReport = dbcon.getDataset("SELECT Supp_Code + ' - ' + Supp_Name [Supplier], Transaction_Header.Doc_No, Transaction_Header.Post_Date, Transaction_Header.Loca + ' - ' + Loca_Descrip [Loca], Transaction_Header.Net_Amount, Transaction_Header.Amount [Gross_Amount], Transaction_Details.Amount, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Purchase_Price, Transaction_Details.Qty, Remarks   FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.Iid='PDN' AND Transaction_Header.Doc_No ='" + OrgDocNo + "' AND Transaction_Header.Loca='" + LoginManager.LocaCode + "'", "dsProductDiscard");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


        public void DeleteProductDetaile(bool Continuesly)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                if (Continuesly)
                {
                    command.CommandText = "sp_GrnTemp_Delete_Con";
                    command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                    command.Parameters.Add(new SqlParameter("@Ln", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, lnNo));
                }
                else
                {
                    command.CommandText = "sp_GrnTemp_Delete";
                }
                
                
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsTempGrn = new DataSet(), "GoodReceivedNote");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 014. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GoodReceivedNoteSave()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                //GetSaveDocumentNo();
                //Document Save with the Temorary Document No
                strOrgDocNo = strTempDocumentNo;

                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GoodReceivedNoteSave";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@PoNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPoNo));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppCode));
                command.Parameters.Add(new SqlParameter("@Inv_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strInvNo));
                command.Parameters.Add(new SqlParameter("@Inv_Amt", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decInvAmount));
                command.Parameters.Add(new SqlParameter("@Pay_Type", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPay_Type));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@GrossAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decGrossAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDisc));
                command.Parameters.Add(new SqlParameter("@Tax", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTax));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@Shipment", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strShipment));
                command.Parameters.Add(new SqlParameter("@VAT", blVat));
                command.Parameters.Add(new SqlParameter("@VATPerProd", blVatProd));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 015. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadSavedDocument()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strTempDocumentNo = strRecallSaveDocNo;
                    strSuppCode = DataReader["Supplier_Id"].ToString().Trim();
                    strSuppName = DataReader["Supp_Name"].ToString().Trim();
                    strPoNo = DataReader["Porder_No"].ToString().Trim();
                    strPay_Type = DataReader["Pay_Type"].ToString().Trim();
                    decInvAmount = (decimal)DataReader["Inv_Amt"];
                    strInvNo = DataReader["Inv_No"].ToString().Trim();
                    strRemark = DataReader["Remarks"].ToString().Trim();
                    strReference = DataReader["Reference"].ToString().Trim();
                    decTax = (decimal)DataReader["Tax"];
                    decDiscount = (decimal)DataReader["Discount"];
                    blVat = (bool)DataReader["VAT"];
                    blVatProd = (bool)DataReader["VATPerProd"];
                    strShipment = DataReader["AddRemarks"].ToString().Trim();

                    blRecordFound = true;
                }
                else
                {
                    strSuppCode = string.Empty;
                    strSuppName = string.Empty;
                    strPoNo = string.Empty;
                    strPay_Type = string.Empty;
                    strInvNo = string.Empty;
                    strRemark = string.Empty;
                    strReference = string.Empty;
                    strShipment = string.Empty;
                    decInvAmount = 0;
                    decTax = 0;
                    decDiscount = 0;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    command.Connection = dbcon.connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_GoodReceivedNoteRecall";
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRecallSaveDocNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));

                    //command.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dsTempGrn = new DataSet(), "GoodReceivedNote");
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void RecallProductItems(string GrnDate,string SuppCode)
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GoodReceivedNote_RecallFromProduct";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));
                command.Parameters.Add(new SqlParameter("@Date", GrnDate));
                command.Parameters.Add(new SqlParameter("@UserName", LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@SuppCode", SuppCode));

                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsTempGrn = new DataSet(), "GoodReceivedNote");
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

        public void ReadPurchaseOrderDocument()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strSuppCode = DataReader["Supplier_Id"].ToString().Trim();
                    strSuppName = DataReader["Supp_Name"].ToString().Trim();
                    strPoNo = DataReader["Doc_No"].ToString().Trim();
                    strPay_Type = DataReader["Pay_Type"].ToString().Trim();
                    decInvAmount = (decimal)DataReader["Net_Amount"];
                    strInvNo = string.Empty;
                    strRemark = DataReader["Remarks"].ToString().Trim();
                    strReference = string.Empty;
                    decTax = (decimal)DataReader["Tax"];
                    decDiscount = 0;
                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    strPoNo = string.Empty;
                    strPay_Type = string.Empty;
                    decInvAmount = 0;
                    strInvNo = string.Empty;
                    strRemark = string.Empty;
                    strReference = string.Empty;
                    decTax = 0;
                    decDiscount = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 018. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


            //Reload Purchase Order Items to the Tempory
            if (blRecordFound == true)
            {
                try
                {
                    dbcon.OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.Connection = dbcon.connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_POToGrnRecall";
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                    command.Parameters.Add(new SqlParameter("@PoNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPoNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "PON"));

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dsTempGrn = new DataSet(), "GoodReceivedNote");
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 019. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 020. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void Reader()
        {
            try
            {
                _Dr = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (_Dr.Read())
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 020. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //dsForReport = dbcon.getDataset("SELECT '" + strTempDocumentNo + "' Doc_no, '" + strSuppCode + "' Supplier_Id,'" + strSuppName + "' Supp_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date, '" + strInvNo + "' inv_no,'" + decInvAmount + "' Inv_Amt, '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + strPay_Type + "' Pay_Type, " + decTax + " Tax,TransactionTemp_Details.Prod_code, TransactionTemp_Details.Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.FreeQty, TransactionTemp_Details.Purchase_Price, TransactionTemp_Details.Selling_Price, TransactionTemp_Details.Discount, TransactionTemp_Details.Amount, TransactionTemp_Details.Ln, 'Temporary' Status FROM TransactionTemp_Details WHERE TransactionTemp_Details.Doc_No = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = 'GRN' ORDER BY Ln", "dsGRNDetailsForRep");
                dsForReport = dbcon.getDataset(" SELECT '" + strTempDocumentNo + "' Doc_no, '" + strSuppCode + "' Supplier_Id,'" + strSuppName + "' Supp_Name, '" + LoginManager.LocaCode + "' Loca,'" + LoginManager.Location + "' Loca_Descrip, '" + strPostDate + "' Post_Date, '" + strInvNo + "' inv_no, '" + strPoNo + "' Porder_no, " + decAmount + " Net_Amount, " + decGrossAmount + " Gross_Amount ," + decDiscount + " Sub_Discount, '" + strDisc + "' Disc, '" + strRemark + "' Remarks, '" + strReference + "' Reference, '" + strPay_Type + "' Pay_Type, " + decTax + " Tax,TD.Prod_code, TD.Prod_Name,SN.SerialNo[Serial_No], TD.Qty, TD.FreeQty, TD.Purchase_Price, TD.Selling_Price, TD.Discount, TD.Amount, TD.Ln, 'Temporary' Status, ((TD.Selling_Price*Qty)- (TD.Purchase_Price*Qty))/(TD.Purchase_Price * CASE Qty WHEN 0 THEN 1 ELSE QTY END)*100 Inv_Amt, TD.Whole_Price,  ((TD.Whole_Price*Qty)- (TD.Purchase_Price*Qty))/(TD.Purchase_Price* (case Qty when 0 then 1 else qty end))*100 Wh_Per,P.Barcode FROM dbo.TransactionTemp_Details TD JOIN dbo.Product P ON P.Prod_Code = TD.Prod_Code   LEFT JOIN TempSerialNo SN ON SN.DocNo = TD.Doc_No  AND SN.ProdCode = TD.Prod_Code  WHERE TD.Doc_No = '" + strTempDocumentNo + "' AND TD.Loca = '" + LoginManager.LocaCode + "' AND TD.Iid = 'GRN' ORDER BY Ln;SELECT * FROM dbo.CompanyProfile", "dsGRNDetailsForRep");
                dsForReport.Tables[1].TableName = "CompanyProfile";
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 021. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void RefershTempGRNProduct()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_RefrshTempGRNProduct";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GRN"));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsGrg 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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