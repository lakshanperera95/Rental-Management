using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DbConnection;
namespace clsLibrary
{
    public class clsProductPriceMaste
    {
        #region General Declaration
        private string strProductCode;
        private string strProductName;
        private string strSqlStatement;
        private string strDataSetName;

        private int intErrCode;
        private decimal decSellingPrice;
        private decimal decPurchasingPrice;
        private decimal decLastPurchasePrice;
        private decimal decQtyLevelPrice;
        private decimal decMarkedPrice;
        private decimal decSellingPriceLevel;
        private decimal decMarkedPriceLevel;
        private decimal decWholeSalePrice;
        private decimal decWholeSalePriceLevel;
        private decimal decWholeQty;
        private decimal decWholeSaleQtyPriceLevel;

        private DataSet dsResultSet;
        private DataSet dsItemDataSet;
        private DataSet dsTempPriceLevelDet;

        private decimal fltQty;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
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

        public string DataetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public string dsName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public decimal Qty
        {
            get { return fltQty; }
            set { fltQty = value; }
        }

        private decimal QtyCredit;
        public decimal _QtyCredit
        {
            get { return QtyCredit; }
            set { QtyCredit = value; }
        }


        public decimal MarkedPrice
        {
            get { return decMarkedPrice; }
            set { decMarkedPrice = value; }
        }

        public decimal SellingPrice
        {
            get { return decSellingPrice; }
            set { decSellingPrice = value; }
        }

        public decimal MarkedPriceLevel
        {
            get { return decMarkedPriceLevel; }
            set { decMarkedPriceLevel = value; }
        }

        public decimal SellingPriceLevel
        {
            get { return decSellingPriceLevel; }
            set { decSellingPriceLevel = value; }
        }

        public decimal WholeSalePrice
        {
            get { return decWholeSalePrice; }
            set { decWholeSalePrice = value; }
        }

        public decimal WholeSalePriceLevel
        {
            get { return decWholeSalePriceLevel; }
            set { decWholeSalePriceLevel = value; }
        }

        public decimal WholeQty
        {
            get { return decWholeQty; }
            set { decWholeQty = value; }
        }

        private decimal WholeQtyCredit;
        public decimal _WholeQtyCredit
        {
            get { return WholeQtyCredit; }
            set { WholeQtyCredit = value; }
        }


        public decimal WholeSaleQtyPriceLevel
        {
            get { return decWholeSaleQtyPriceLevel; }
            set { decWholeSaleQtyPriceLevel = value; }
        }

        private decimal WholeSaleQtyPriceLevelCredit;
        public decimal _WholeSaleQtyPriceLevelCredit
        {
            get { return WholeSaleQtyPriceLevelCredit; }
            set { WholeSaleQtyPriceLevelCredit = value; }
        }


        public decimal PurchasingPrice
        {
            get { return decPurchasingPrice; }
            set { decPurchasingPrice = value; }
        }

        public decimal LastPurchasePrice
        {
            get { return decLastPurchasePrice; }
            set { decLastPurchasePrice = value; }
        }

        public decimal QtyLevelPrice
        {
            get { return decQtyLevelPrice; }
            set { decQtyLevelPrice = value; }
        }

        private decimal QtyLevelPriceCredit;
        public decimal _QtyLevelPriceCredit
        {
            get { return QtyLevelPriceCredit; }
            set { QtyLevelPriceCredit = value; }
        }

        private int priceBatch;
        public int _priceBatch
        {
            get { return priceBatch; }
            set { priceBatch = value; }
        }



        private decimal decRPrice;
        public decimal _decRPrice
        {
            get { return decRPrice; }
            set { decRPrice = value; }
        }

        private decimal decWPrice;
        public decimal _decWPrice
        {
            get { return decWPrice; }
            set { decWPrice = value; }
        }

        private decimal decDPrice;
        public decimal _decDPrice
        {
            get { return decDPrice; }
            set { decDPrice = value; }
        }

        private decimal decMMPrice;
        public decimal _decMMPrice
        {
            get { return decMMPrice; }
            set { decMMPrice = value; }
        }

       



        public DataSet ResultSet
        {
            get { return dsResultSet; }
            set { dsResultSet = value; }
        }

        public DataSet GetItemDataset
        {
            get { return dsItemDataSet; }
            set { dsItemDataSet = value; }
        }

        public DataSet TempPriceLevelDet
        {
            get { return dsTempPriceLevelDet; }
            set { dsTempPriceLevelDet = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        private int Line;
        public int _Line
        {
            get { return Line; }
            set { Line = value; }
        }

        private DataSet dsBatchWiseColor;
        public DataSet _dsBatchWiseColor
        {
            get { return dsBatchWiseColor; }
            set { dsBatchWiseColor = value; }
        }

        private string currentRowColor;
        public string _currentRowColor
        {
            get { return currentRowColor; }
            set { currentRowColor = value; }
        }

        private string strBatchNo;
        public string _strBatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }

        private string strExpDate;
        public string _strExpDate
        {
            get { return strExpDate; }
            set { strExpDate = value; }
        }




        public void ReadProductDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strProductCode = DataReader["Prod_Code"].ToString().Trim();
                    strProductName = DataReader["Prod_Name"].ToString().Trim();

                    decRPrice = (decimal)DataReader["RetailPrice"];
                    decWPrice = (decimal)DataReader["WholesalePrice"];
                    decDPrice = (decimal)DataReader["DistributionPrice"];
                    decMMPrice = (decimal)DataReader["ModernMarketPrice"];
                    decPurchasingPrice = (decimal)DataReader["Purchaseprice"];

                    blRecordFound = true;
                }
                else
                {
                    strProductCode = string.Empty;
                    strProductName = string.Empty;

                    decRPrice = 0;
                    decWPrice = 0;
                    decDPrice = 0;
                    decMMPrice = 0;
                    decPurchasingPrice = 0;

                    blRecordFound = false;
                }
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }
            finally
            {
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For Price Level
                //dsTempPriceLevelDet = dbcon.getDataset("SELECT Prod_Code, Marked_Price, Selling_Price, Qty, Qty_Credit, Price_Level, Price_Level_Credit, Whole_Price, WholeQty, WholeQty_Credit, WholeQtyPriceLevel AS [WholeQtyPrice], WholeQtyPriceLevel_Credit AS [WholeQtyPrice_Credit], Purchase_Price from tbTempPriceLevel WHERE Prod_Code = '" + strProductCode + "' order by  Marked_Price, Selling_Price, Qty ", "dsPriceMasterDetails");
                dsTempPriceLevelDet = dbcon.getDataset("SELECT priceBatch, Prod_Code, Marked_Price, Selling_Price, Qty, Price_Level, Price_Level_Credit, Whole_Price, WholeQty, WholeQtyPriceLevel AS [WholeQtyPrice], WholeQtyPriceLevel_Credit AS [WholeQtyPrice_Credit], Purchase_Price, Ln from tbTempPriceLevel WHERE Prod_Code = '" + strProductCode + "' order by  priceBatch, Qty ", "dsPriceMasterDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTempDatasetForShowing()
        {
            try
            {
                //get Temporary DataSet For Price Level
                //dsTempPriceLevelDet = dbcon.getDataset("SELECT Prod_Code, Marked_Price, Selling_Price, Qty, Qty_Credit, Price_Level, Price_Level_Credit, Whole_Price, WholeQty, WholeQty_Credit, WholeQtyPriceLevel AS [WholeQtyPrice], WholeQtyPriceLevel_Credit AS [WholeQtyPrice_Credit], Purchase_Price from tbTempPriceLevel WHERE Prod_Code = '" + strProductCode + "' order by  Marked_Price, Selling_Price, Qty ", "dsPriceMasterDetails");
                dsTempPriceLevelDet = dbcon.getDataset("SELECT priceBatch, Prod_Code, Marked_Price, Selling_Price, Qty [RT Qty], Price_Level [RT Price CASH], Price_Level_Credit , Whole_Price , WholeQty, WholeQtyPriceLevel AS [WholeQtyPrice], WholeQtyPriceLevel_Credit AS [WholeQtyPrice_Credit], Purchase_Price, Ln from tbTempPriceLevel WHERE Prod_Code = '" + strProductCode + "' order by  priceBatch, Qty ", "dsPriceMasterDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTempDatasetPriceBatchWise()
        {
            try
            {

                dsTempPriceLevelDet = dbcon.getDataset("SELECT Prod_Code, Selling_Price [RPrice], Whole_Price [WPrice], Price_Level [DPrice], Marked_Price [MMPrice], Purchase_Price,Qty from tbTempPriceLevel WHERE Prod_Code = '" + strProductCode + "'   order by  Ln ", "dsPriceMasterDetails");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UpdatePriceLevelTempDataSet()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductPriceLevel_Update";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));

                command.Parameters.Add(new SqlParameter("@RPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decRPrice));
                command.Parameters.Add(new SqlParameter("@WPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decWPrice));
                command.Parameters.Add(new SqlParameter("@DPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDPrice));
                command.Parameters.Add(new SqlParameter("@MMPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decMMPrice));

                command.Parameters.Add(new SqlParameter("@Purchase_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasingPrice));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Qty));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteAllTempData()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductPriceLevelDeleteAll";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        
        public void LoadPriceLevelTemp()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempPriceLevelLoad";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ProductPriceLevelApply()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductPriceLevelApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);

            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void DeletePriceLevelDetaile()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_ProductPriceLevelDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@RPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decRPrice));
                command.Parameters.Add(new SqlParameter("@WPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decWPrice));
                command.Parameters.Add(new SqlParameter("@DPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDPrice));
                command.Parameters.Add(new SqlParameter("@MMPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decMMPrice));

                command.Parameters.Add(new SqlParameter("@Purchase_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasingPrice));

                
                


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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadProductBatch()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    priceBatch = (int)DataReader["CurrentBatch"];
                    blRecordFound = true;
                }
                else
                {
                    priceBatch = 1;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DataExists(string Qry)
        {
            try
            {
                using (DataReader = dbcon.GetReader(Qry))
                {
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
                
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);

            }
            finally
            {
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }

        public void getDataSetForBatchColor()
        {
            try
            {
                dsBatchWiseColor = dbcon.getDataset(strSqlStatement, "dsBatchColor");

            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetCurrentRowColor(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command = dbcon.connection.CreateCommand();
                command.CommandText = query;
                dbcon.OpenConnection();
                try
                {
                    currentRowColor = command.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    currentRowColor = "AliceBlue";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsProductPriceMaste 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void BatchPrice_Update()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_Batch_PriceUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();

                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProductCode));
                command.Parameters.Add(new SqlParameter("@BatchNo", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBatchNo));
                command.Parameters.Add(new SqlParameter("@ExpDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strExpDate));
                command.Parameters.Add(new SqlParameter("@Purchase_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decPurchasingPrice));
                command.Parameters.Add(new SqlParameter("@Retail_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decRPrice));
                command.Parameters.Add(new SqlParameter("@Ws_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decWPrice));
                command.Parameters.Add(new SqlParameter("@Distributor_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDPrice));
                command.Parameters.Add(new SqlParameter("@ModMkt_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decMMPrice));

                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));

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
    }
}
