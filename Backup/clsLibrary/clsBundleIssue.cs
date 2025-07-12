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
    public class clsBundleIssue
    {
        #region General Declaration
        private int intErrCode;
        private int intTempDocNo;
        private int intPackSize;

        private string strPostDate;
        private string strProductCode;
        private string strProductName;
        private string strMainProductCode;
        private string strMainProductName;
        private string strSqlStatement;
        private string strOrgDocNo;
        private string strDataSetName;
        private string strUnit;

        private decimal fltQty;
        private decimal fltCurrentQty;
        private decimal fltPacketQty;
        private decimal fltNo_Of_Packets;

        private decimal decPurchasePrice;
        private decimal decMainPurchasePrice;

        private DataSet dsProductDataSet;
        private DataSet dsTempSelectedItem;
        private DataSet dsForReport;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion

        #region Properties
        private string strTempDocumentNo;
        public string TempDocumentNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }


        public int ErrorCode
        {
            get
            {
                return intErrCode;
            }
            set
            {
                intErrCode = value;
            }
        }

        public int PackSize
        {
            get
            {
                return intPackSize;
            }
            set
            {
                intPackSize = value;
            }
        }

        public string ProductCode
        {
            get
            {
                return strProductCode;
            }
            set
            {
                strProductCode = value;
            }
        }

        public string PostDate
        {
            get
            {
                return strPostDate;
            }
            set
            {
                strPostDate = value;
            }
        }

        public string ProductName
        {
            get
            {
                return strProductName;
            }
            set
            {
                strProductName = value;
            }
        }

        public string MainProductCode
        {
            get
            {
                return strMainProductCode;
            }
            set
            {
                strMainProductCode = value;
            }
        }

        public string MainProductName
        {
            get
            {
                return strMainProductName;
            }
            set
            {
                strMainProductName = value;
            }
        }

        public string Unit
        {
            get
            {
                return strUnit;
            }
            set
            {
                strUnit = value;
            }
        }

        public decimal No_Of_Packets
        {
            get
            {
                return fltNo_Of_Packets;
            }
            set
            {
                fltNo_Of_Packets = value;
            }
        }

        public decimal Qty
        {
            get
            {
                return fltQty;
            }
            set
            {
                fltQty = value;
            }
        }

        public decimal PacketQty
        {
            get
            {
                return fltPacketQty;
            }
            set
            {
                fltPacketQty = value;
            }
        }

        public decimal CurrentQty
        {
            get
            {
                return fltCurrentQty;
            }
            set
            {
                fltCurrentQty = value;
            }
        }

        public decimal PurchasePrice
        {
            get
            {
                return decPurchasePrice;
            }
            set
            {
                decPurchasePrice = value;
            }
        }
        private decimal decSellingPrice;
        public decimal SellingPrice
        {
            get
            {
                return decSellingPrice;
            }
            set
            {
                decSellingPrice = value;
            }
        }

        public decimal MainPurchasePrice
        {
            get
            {
                return decMainPurchasePrice;
            }
            set
            {
                decMainPurchasePrice = value;
            }
        }

        public string SqlStatement
        {
            get
            {
                return strSqlStatement;
            }
            set
            {
                strSqlStatement = value;
            }
        }

        public string DataetName
        {
            get
            {
                return strDataSetName;
            }
            set
            {
                strDataSetName = value;
            }
        }

        public string OrgDocNo
        {
            get
            {
                return strOrgDocNo;
            }
            set
            {
                strOrgDocNo = value;
            }
        }

        public DataSet TempSelectedItem
        {
            get
            {
                return dsTempSelectedItem;
            }
            set
            {
                dsTempSelectedItem = value;
            }
        }

        public DataSet GetReportDataset
        {
            get
            {
                return dsForReport;
            }
            set
            {
                dsForReport = value;
            }
        }

        public Boolean RecordFound
        {
            get
            {
                return blRecordFound;
            }
            set
            {
                blRecordFound = value;
            }
        }

        public DataSet GetProductDataset
        {
            get
            {
                return dsProductDataSet;
            }
            set
            {
                dsProductDataSet = value;
            }
        }

        #endregion

        public void GetItemDetails()
        {
            try
            {
                dsProductDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }
        }

        public void ReadProductDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {

                    strMainProductCode = DataReader["Prod_Code"].ToString().Trim();
                    strMainProductName = DataReader["Prod_Name"].ToString().Trim();
                    fltCurrentQty = (decimal)DataReader.GetSqlDecimal(3);
                    fltPacketQty = (decimal)DataReader.GetSqlDecimal(4);
                    decMainPurchasePrice = (decimal)DataReader["Purchase_price"];
                    blRecordFound = true;
                }
                else
                {

                    strMainProductCode = string.Empty;
                    strMainProductName = string.Empty;
                    fltCurrentQty = 0;
                    fltPacketQty = 0;
                    decMainPurchasePrice = 0;
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

        

        public void UpdateTempBundlingIssuePacketing()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBundleIssueProduct";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMainProductCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMainProductName));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decMainPurchasePrice));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@No_Of_Packets", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltNo_Of_Packets));
                command.Parameters.Add(new SqlParameter("@Temp_DocNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocumentNo));

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

        public void RecallTempBundlingIssue()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_bundleIssueRecall";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMainProductCode));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, fltQty));
                command.Parameters.Add(new SqlParameter("@DocNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsTempSelectedItem = new DataSet(), "Ds");
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
        
        public void GetTempBulkIssueDataset(string DocNo)
        {
            try
            {
                //get Temporary DataSet For Grn
                dsTempSelectedItem = dbcon.getDataset("SELECT TM.Prod_Code[Main_Prod_Code],P.Prod_Name[Main_Prod_Name],CAST( TM.Purchase_price AS DECIMAL(18,2))Purchase_price,CAST(TM.No_Of_Packets AS DECIMAL(18,2))No_Of_Packets,CAST( TM.Purchase_price*TM.No_Of_Packets AS DECIMAL(18,2))[Packet_Qty] FROM dbo.tbTempBundlingIssueProduct TM JOIN dbo.Product P ON TM.Prod_Code=P.Prod_Code WHERE TempDocNo='" + DocNo + "';SELECT  CAST( SUM(TM.Purchase_price*TM.No_Of_Packets) AS DECIMAL(18,2)) , CAST( (SUM((TM.Purchase_price*TM.No_Of_Packets)) / @Qty) AS DECIMAL(18,2))  , CAST( P.Selling_Price AS DECIMAL(18,2)) FROM dbo.tbTempBundlingIssueProduct TM JOIN dbo.Product P ON TM.Main_Prod_Code=P.Prod_Code WHERE TM.TempDocNo='" + DocNo + "' GROUP BY  P.Selling_Price", "dsTempPacketProduct");
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }

        }


        public void DeleteTempBundling(string Sp, string DocNo)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sp;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@DocNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocNo));

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



       

        public void DeleteTempBundlingProduct(string ProdCode, string DocNo)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBundleDeleteProduct";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocNo));
                

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

        public void GetOrgDocumentNo(string IID)
        {
            try
            {
                
                DataReader = dbcon.GetReader("select BDL from DocumentNoDetails WHERE Loca = " + LoginManager.LocaCode);
                
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strOrgDocNo = string.Format("{0:000000}", intTempDocNo);
                    strOrgDocNo = IID + LoginManager.LocaCode.Trim().Substring(0, 2) + strOrgDocNo;
                    
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

        

        public void IssuingBunlingProductApply()
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                intErrCode = 0;
                //Get Orginal Document No
               /* GetOrgDocumentNo("BDL");
                strPostDate = string.Format("{0:dd/MM/yyyy}", PostDate);*/

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_BundleProductIssueApply";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@TempDoc_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPostDate));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@CostPrice" ,decPurchasePrice));
                command.Parameters.Add(new SqlParameter("@SellingPrice",decSellingPrice ));

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

        

        public void GetDataSetForBundlingReport()
        {
            try
            {
                dsForReport = dbcon.getDataset("SELECT tbBudleProductIssueDetails.Doc_No, tbBudleProductIssueDetails.Post_Date, tbBudleProductIssueDetails.Main_Prod_Code Prod_Code, tbBudleProductIssueDetails.Main_Prod_Name Prod_Name, tbBudleProductIssueDetails.Purchase_price, tbBudleProductIssueDetails.Packet_Qty, tbBudleProductIssueDetails.No_Of_Packets, tbBudleProductIssueDetails.Loca, Location.Loca_Descrip, 'Original' Status FROM tbBudleProductIssueDetails INNER JOIN Location ON tbBudleProductIssueDetails.Loca = Location.Loca WHERE tbBudleProductIssueDetails.Doc_No = '" + strOrgDocNo + "' AND tbBudleProductIssueDetails.Loca = '" + LoginManager.LocaCode + "'", "dsPacketingProductNote");
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }
        }

        public void GetTempDocumentNo()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                if (DataReader.Read())
                {
                    intTempDocNo = (int)DataReader.GetSqlInt32(0);
                    //String.Format("{0:00000}", 15); 
                    strTempDocumentNo = string.Format("{0:000000}", intTempDocNo);
                    strTempDocumentNo = "BDL" + LoginManager.LocaCode.Trim().Substring(0, 2) + strTempDocumentNo;
                    
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


        public void GetDataset(string query, string datasetName)
        {
            try
            {

                dsProductDataSet = dbcon.getDataset(query, datasetName);
            }
            catch (Exception e)
            {
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }

        }
    }
}
