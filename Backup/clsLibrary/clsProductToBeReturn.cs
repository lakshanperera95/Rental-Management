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
    public class clsProductToBeReturn
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;
        private int intPackSize;

        private string strLocaCode;
        private string strToLocaCode;
        private string strLocaName;
        private string strToLocaName;
        private string strProductCode;
        private string strProductName;
        private string strSqlStatement;
        private string strTempDocumentNo;
        private string strDataSetName;
        private string strPostDate;
        private string strRemark;
        private string strReference;
        private string strOrgDocNo;
        private string strSavedDocNo;
        private string strRecallSaveDocNo;

        private decimal fltQty;
        private decimal fltCurrentQty;
        private decimal fltTotalQty;

        private decimal decPurchasePrice;
        private decimal decSellingPrice;
        private decimal decAmount;
        private decimal decTotalAmount;

        private DataSet dsItemDataSet;
        private DataSet dsTempTransferNote;
        private DataSet dsForReport;

        private SqlDataReader DataReader;
        private Boolean blRecordFound;
        #endregion

        #region Properties
        public string TempDocNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }

        public string OrgDocNo
        {
            get { return strOrgDocNo; }
            set { strOrgDocNo = value; }
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

        public string ToLocaCode
        {
            get { return strToLocaCode; }
            set { strToLocaCode = value; }
        }

        public string LocaName
        {
            get { return strLocaName; }
            set { strLocaName = value; }
        }

        public string ToLocaName
        {
            get { return strToLocaName; }
            set { strToLocaName = value; }
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

        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }
        }

        public decimal Qty
        {
            get { return fltQty; }
            set { fltQty = value; }
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

        public decimal Amount
        {
            get { return decAmount; }
            set { decAmount = value; }
        }

        public string Reference
        {
            get { return strReference; }
            set { strReference = value; }
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

        public DataSet GetReportDataset
        {
            get { return dsForReport; }
            set { dsForReport = value; }
        }

        public DataSet TempTransferNote
        {
            get { return dsTempTransferNote; }
            set { dsTempTransferNote = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }
        #endregion

        public string Optrion = "TOR";

        public void ReadFromLocationCode()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    strTempDocumentNo = Optrion + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo; ;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Optrion));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                GetTempDataset(ref Optrion);
            }
        }

        public void GetTempDataset(ref string Iid)
        {
            try
            {
                //get Temporary DataSet For Stock Adjustent
                dsTempTransferNote = dbcon.getDataset("SELECT Prod_Code, Prod_Name, Selling_Price, Purchase_price, Pack_Size, Qty, Amount FROM TransactionTemp_Details WHERE Doc_No = '" + strTempDocumentNo + "' AND IId = '"+Iid+"' AND Loca = " + LoginManager.LocaCode + " Order by Ln", "TransferNote");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadToLocationCode()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + strToLocaCode + "'");
                strToLocaName = string.Empty;
                if (DataReader.Read())
                {
                    strToLocaCode = DataReader["Loca"].ToString().Trim();
                    strToLocaName = DataReader["Loca_Descrip"].ToString().Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (DataReader.Read())
                {
                    strProductCode = DataReader["Prod_Code"].ToString().Trim();
                    strProductName = DataReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(4);
                    intPackSize = (int)DataReader.GetSqlInt16(5);
                    decPurchasePrice = (decimal)DataReader["Purchase_price"];
                    decSellingPrice = (decimal)DataReader["Selling_Price"];
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;
                    fltCurrentQty = 0;
                    decPurchasePrice = 0;
                    decSellingPrice = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdateTobeReturnTempDataSet()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ToBeReturnTemp_Update";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Optrion));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Selling_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decSellingPrice));
                command.Parameters.Add(new SqlParameter("@Pack_Size", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, intPackSize));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decAmount));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsTempTransferNote = new DataSet(), "TransferNote");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTotalValues(ref string Iid)
        {
            try
            {
                SqlCommand command = new SqlCommand(); 
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command = dbcon.connection.CreateCommand();
                command.CommandText = "select isnull(sum(Amount),0) from TransactionTemp_Details WHERE Iid = '"+Iid+"' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
                dbcon.OpenConnection();
                decTotalAmount = decimal.Parse(command.ExecuteScalar().ToString());
                command.CommandText = "select isnull(sum(Qty),0) from TransactionTemp_Details WHERE Iid = '" + Iid + "' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No = '" + strTempDocumentNo + "'";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 010. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                DataReader = dbcon.GetReader("select To_Be_Ret from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);
                    strOrgDocNo = Optrion + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo; 

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 011. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void TransferNoteApply()
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
                command.CommandText = (Optrion == "TOR") ? "sp_ToBeReturnApply" : "sp_OpeningStockApply";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Optrion));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsForReport = new DataSet(), "dsTogDetails");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 012. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dsForReport = dbcon.getDataset("SELECT Transaction_Header.doc_no, Transaction_Header.Loca, Location.Loca_Descrip LocaDesc, Transaction_Header.To_Loca, Transaction_Header.To_LocaDesc, Transaction_Header.Post_Date, Transaction_Header.Remarks, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Pack_Size, Transaction_Details.Amount,'Original' Status FROM Transaction_Header INNER join Transaction_Details ON Transaction_Header.doc_no = Transaction_Details.doc_no AND Transaction_Header.iid = Transaction_Details.iid AND Transaction_Header.Loca = Transaction_Details.Loca INNER JOIN Location ON Location.Loca = Transaction_Header.Loca WHERE Transaction_Header.doc_no = '" + strOrgDocNo + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'TOR' ORDER BY Ln", "dsTogDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 013. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                command.CommandText = "sp_ToBeReturnTemp_Delete";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Optrion));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 014. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 015. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetDataSetForPreview(ref string IID)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);
                dsForReport = dbcon.getDataset("SELECT TransactionTemp_Details.doc_no, TransactionTemp_Details.Loca, '" + strLocaName + "' LocaDesc, '" + strToLocaCode + "' To_Loca, '" + strToLocaName + "' To_LocaDesc, '" + strPostDate + "' Post_Date, '" + strRemark + "' Remarks, TransactionTemp_Details.Prod_Code, TransactionTemp_Details.Prod_Name, TransactionTemp_Details.Qty, TransactionTemp_Details.Purchase_Price, TransactionTemp_Details.Selling_Price, TransactionTemp_Details.Pack_Size, TransactionTemp_Details.Amount,'Temporary' Status FROM TransactionTemp_Details WHERE TransactionTemp_Details.doc_no = '" + strTempDocumentNo + "' AND TransactionTemp_Details.Loca = '" + LoginManager.LocaCode + "' AND TransactionTemp_Details.Iid = '"+IID+"' ORDER BY Ln", "dsTogDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 016. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void TransferNoteSave(ref string Iid)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
                //Document Save with the Temorary Document No
                strOrgDocNo = strTempDocumentNo;

                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ToBeReturnSave";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLocaCode));
                command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@OrgDoc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOrgDocNo));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Iid));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decTotalAmount));
                command.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRemark));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strReference));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 017. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadSavedDocument(ref string Iid)
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement + LoginManager.LocaCode);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strTempDocumentNo = strRecallSaveDocNo;
                    strRemark = DataReader["Remarks"].ToString().Trim();
                    strReference = DataReader["Reference"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strRemark = string.Empty;
                    strReference = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 018. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    command.CommandTimeout = LoginSys.dbocommTimeOut;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_ToBeReturnRecall";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                    command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                    command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRecallSaveDocNo));
                    command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Iid));

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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductToBeReturn 019. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

    }
}
