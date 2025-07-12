using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbConnection;
using System.Windows.Forms;

namespace clsLibrary
{
    public class clsBulkProductCombination : clsMain
    {

        public void GetItemDetails(string datasetName)
        {
            dataset = dbcon.getDataset(SqlStatement, datasetName);
        }

        public void RetProduct(string query)
        {
            Reader = dbcon.GetReader(query);
            if (Reader.Read())
            {
                ProdCode = Reader["Prod_Code"].ToString();
                ProdName = Reader["Prod_Name"].ToString();
            }
            else
            {
                ProdCode = ProdName = string.Empty;
            }
        }

        public void ProdDown()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempCombiProdDown";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                command.Parameters.Add(new SqlParameter("@MainProdCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainProdCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                command.Parameters.Add(new SqlParameter("@ReturnMSG", SqlDbType.NVarChar, 1000, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@FocusCont", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@MsgTital", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    ProdCode = Reader["Prod_Code"].ToString();
                    ProdName = Reader["Prod_Name"].ToString();
                    Qty = decimal.Parse(Reader["Qty"].ToString());
                    PurchasePrice = (decimal)Reader["Purchase_price"];
                    SellingPrice = (decimal)Reader["Selling_Price"];
                }
                else
                {
                    ProdCode = ProdName = string.Empty;
                    Qty = 0;

                }
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ReturnMSG = (string)(command.Parameters["@ReturnMSG"].Value);
                FocusCont = (string)(command.Parameters["@FocusCont"].Value);
                MsgTital = (string)(command.Parameters["@MsgTital"].Value);

            }
            finally
            {
                dbcon.CloseConnection();
            }
        }

        public void AddTempCombinationProduct()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempCombinationProduct";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@SubProd_Code", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                command.Parameters.Add(new SqlParameter("@MainProdCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainProdCode));
                command.Parameters.Add(new SqlParameter("@MainProdName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainProdName));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.ToString()));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Qty));
                command.Parameters.Add(new SqlParameter("@ReturnMSG", SqlDbType.NVarChar, 1000, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@FocusCont", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@MsgTital", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataset = new DataSet(), "dsProductMoving");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ReturnMSG = (string)(command.Parameters["@ReturnMSG"].Value);
                FocusCont = (string)(command.Parameters["@FocusCont"].Value);
                MsgTital = (string)(command.Parameters["@MsgTital"].Value);
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }

        public void DeleteTempCombinationProduct()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempCombinationDelte";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@SubProd_Code", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                command.Parameters.Add(new SqlParameter("@MainProdCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainProdCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode.ToString()));
                command.Parameters.Add(new SqlParameter("@ReturnMSG", SqlDbType.NVarChar, 1000, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@FocusCont", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@MsgTital", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataset = new DataSet(), "dsProductMoving");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ReturnMSG = (string)(command.Parameters["@ReturnMSG"].Value);
                FocusCont = (string)(command.Parameters["@FocusCont"].Value);
                MsgTital = (string)(command.Parameters["@MsgTital"].Value);
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }

        public bool Reder(string SqlStm)
        {
            Reader = dbcon.GetReader(SqlStm);
            if (Reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Temp_BulkIsse(string ProdCode, string ProdName, string PostDate, string DocNo, string MainPro, string MainProdName, decimal PurchPrice, decimal Qty, decimal NoPack)
        {
            try
            {

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBulkComb";
                command.CommandTimeout = 5000;
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocNo));
                command.Parameters.Add(new SqlParameter("@Post_Date", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PostDate));
                command.Parameters.Add(new SqlParameter("@Main_Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainPro));
                command.Parameters.Add(new SqlParameter("@Main_Prod_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainProdName));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdName));
                command.Parameters.Add(new SqlParameter("@Purchase_price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PurchPrice));
                command.Parameters.Add(new SqlParameter("@Packet_Qty", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Qty));
                command.Parameters.Add(new SqlParameter("@No_Of_Packets", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NoPack));
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(dataset = new DataSet(), "dsTempPacketProduct");
            }
            finally
            {
                dbcon.CloseConnection();
            }

        }

        public void Temp_BulkDelte(string ProdCode, string DocNo, string MainPro)
        {
            try
            {

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempBulkDelete";
                command.CommandTimeout = 5000;
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocNo));
                command.Parameters.Add(new SqlParameter("@Main_Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, MainPro));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(dataset = new DataSet(), "dsTempPacketProduct");

            }
            finally
            {
                dbcon.CloseConnection();
            }
        }

        public void BulkIssueApply(string PostDate, string DocNo)
        {
            try
            {

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_BulkIssueApply";
                command.CommandTimeout = 5000;
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@DocNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DocNo));
                command.Parameters.Add(new SqlParameter("@PostDate", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PostDate));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(dataset = new DataSet(), "dsBulkIssue");
            }
            finally
            {
                dbcon.CloseConnection();
            }
        }
    }
}