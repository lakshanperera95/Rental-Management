using clsLibrary;
using DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public class clsJob : clsPublic
    {
        private string strSqlStatement;
        private string strTempDocumentNo;

        private string strDataSetName = "ds";
        private DataSet dsCustomerDataSet;
        private DataSet dsTempDataSet;
        private string strCustCode;
        private Boolean blRecordFound;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds1 = new DataSet();
        private SqlDataReader DataReader;

        public DataTableReader objdtReader { get; set; }
        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        public string TempDocumentNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }

        public string DatasetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }
        public DataSet GetCustomerDataSet
        {
            get { return dsCustomerDataSet; }
            set { dsCustomerDataSet = value; }
        }
        public DataSet GetTemDataset
        {
            get { return dsTempDataSet; }
            set { dsTempDataSet = value; }
        }
        public string CustCode
        {
            get { return strCustCode; }
            set { strCustCode = value; }
        }
        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }
        private string strCustName;
        public string CustName
        {
            get { return strCustName; }
            set { strCustName = value; }
        }
        private string strMobile;
        public string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
        }
        private string strBrandCode;
        public string BrandCode
        {
            get { return strBrandCode; }
            set { strBrandCode = value; }
        }
        private string strBrandName;
        public string BrandName
        {
            get { return strBrandName; }
            set { strBrandName = value; }
        }
        private string strProdCode;
        public string ProdCode
        {
            get { return strProdCode; }
            set { strProdCode = value; }
        }
        private string strProdName;
        public string ProdName
        {
            get { return strProdName; }
            set { strProdName = value; }
        }
        public DataSet GetDataset1
        {
            get { return ds1; }
            set { ds1 = value; }
        }
        public string AppType { get; set; }
        public string Remark { get; set; }
        public string Reference { get; set; }
        public string Date { get; set; }
        public bool WarrntyAllow { get; set; } = false;
        public DataSet GetDataset { get; set; }
        public int Error { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Qty { get; set; }
        public DataSet TempAddItem { get; set; }
        public string HandOverBy { get; set; }
        public string  HandDate { get; set; }
        public string FinishDate { get; set; }
        public string FinishBy { get; set; }
        public string JobState { get; set; }
        public decimal ServiceCharge { get; set; }
        public string FinishRemark { get; set; }
        public bool UnderCost { get; set; }



        public void GetCustomer()
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
                        MobNo = objdtReader["Tel"].ToString().Trim();
                    }
                    catch (Exception)
                    { }

                    strCustCode = objdtReader["Cust_Code"].ToString().Trim();
                    strCustName = objdtReader["Cust_Name"].ToString().Trim();
                    strMobile = MobNo;
                    blRecordFound = true;
                }
                else
                {
                    strCustCode = string.Empty;
                    strCustName = string.Empty;
                    strMobile = string.Empty;
                    blRecordFound = false;
                }

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void RetrieveBrand()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = SqlStatement;
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

        public void BrandRead()
        {
            try
            {
                blRecordFound = false;
                DataReader = dbcon.GetReader(strSqlStatement);
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


        public void ProdRead()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                if (DataReader.Read())
                {
                    strProdCode = DataReader["Product Code"].ToString().Trim();
                    strProdName = DataReader["Product Name"].ToString().Trim();
                }
                else
                {
                    strProdCode = string.Empty;
                    strProdName = string.Empty;
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
        public DataSet GetData()
        {
            try
            {
                return dsTempDataSet = dbconApi.getDataset(strSqlStatement, strDataSetName);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void JobApply()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_JobRegApply", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@CusCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@Contact", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMobile));
                command.Parameters.Add(new SqlParameter("@ApplyType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AppType));
                command.Parameters.Add(new SqlParameter("@Brand_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strBrandCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdName));
                command.Parameters.Add(new SqlParameter("@Remark", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Reference));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Date));
                command.Parameters.Add(new SqlParameter("@WarrentyAllow", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, WarrntyAllow));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(GetDataset = new DataSet(), "dsJobApply");
                GetDataset.Tables[1].TableName = "JobDetail";
                GetDataset.Tables[2].TableName = "CompanyProfile";
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                Error = (int)(command.Parameters["@Error"].Value);


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
        public void GetDataReader()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
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
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbcon.CloseConnection();
                dbcon.CloseReader();
            }
        }
        public void ReadJobDoc()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strCustCode = DataReader["CustCode"].ToString().Trim();
                    strCustName = DataReader["Cust_Name"].ToString().Trim();
                    strMobile = DataReader["Cont_No"].ToString().Trim();
                    AppType = DataReader["ApplyType"].ToString().Trim();
                    strBrandCode = DataReader["BrandCode"].ToString().Trim();
                    strBrandName = DataReader["Brand_Name"].ToString().Trim();
                    strProdCode = DataReader["ProdCode"].ToString().Trim();
                    strProdName = DataReader["ProdName"].ToString().Trim();
                    Remark = DataReader["Remark"].ToString().Trim();
                    Reference = DataReader["Reference"].ToString().Trim();
                    WarrntyAllow = (bool)DataReader["WarrantyAllow"];
                    blRecordFound = true;
                }
                else
                {
                    strCustCode = string.Empty;
                    strCustName = string.Empty;
                    strMobile = string.Empty;
                    AppType = string.Empty;
                    strBrandCode = string.Empty;
                    strBrandName = string.Empty;
                    strProdCode = string.Empty;
                    strProdName = string.Empty;
                    Remark = string.Empty;
                    Reference = string.Empty;
                    WarrntyAllow = false;
                    blRecordFound = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbcon.CloseConnection();
                dbcon.CloseReader();
            }
        }
        public void ReadProductDetail()
        {            

            try
            {
         
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {                   
                    try
                    {
                        UnderCost = (bool)DataReader["UnderCost"];
                    }
                    catch (Exception)
                    {   }
                    strProdCode = DataReader["Prod_Code"].ToString().Trim();
                    strProdName = DataReader["Prod_Name"].ToString().Trim();
                    PurchasePrice = (decimal)DataReader["Purchase_price"];
                    SellingPrice = (decimal)DataReader["Selling_Price"];                    
                    blRecordFound = true;
                }

                else
                {
                    strProdCode = string.Empty;
                    strProdName = string.Empty;
                    SellingPrice = 0;
                    PurchasePrice = 0;
                    blRecordFound = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbcon.CloseConnection();
                dbcon.CloseReader();
            }
        }
        public void AddItemTemp_Update()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_AddItemTemp_Update", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "JOB"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdName));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,Qty));
                command.Parameters.Add(new SqlParameter("@Selling_Price", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SellingPrice));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Date));            
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(TempAddItem = new DataSet(), "Product");               
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                Error = (int)(command.Parameters["@Err_x"].Value);


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
        public void DeleteAddItem()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteItem", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocumentNo));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "JOB"));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strProdCode));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(TempAddItem = new DataSet(), "Product");
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                Error = (int)(command.Parameters["@Err_x"].Value);
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

        public void JobFinshedApply()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_JobFinshedApply", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@DocNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocumentNo));
                command.Parameters.Add(new SqlParameter("@HandOverBy", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HandOverBy));
                command.Parameters.Add(new SqlParameter("@HandOverDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, HandDate));
                command.Parameters.Add(new SqlParameter("@FinishedDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, FinishDate));
                command.Parameters.Add(new SqlParameter("@FinishedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, FinishBy));
                command.Parameters.Add(new SqlParameter("@JobState", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, JobState));
                command.Parameters.Add(new SqlParameter("@ServiceCharge", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ServiceCharge));
                command.Parameters.Add(new SqlParameter("@FinishRemark", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, FinishRemark));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Date));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(GetDataset = new DataSet(), "dsJobApply");       
                GetDataset.Tables[1].TableName = "JobDetail";
                GetDataset.Tables[2].TableName = "CompanyProfile";
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                Error = (int)(command.Parameters["@Error"].Value);           
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

        
    }

}
