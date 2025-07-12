using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DbConnection;

namespace clsLibrary
{
    public class clsGiftVoucher :BaseClass
    {
        private string _Gif_Number;

        public string Gif_Number
        {
            get { return _Gif_Number; }
            set { _Gif_Number = value; }
        }

        public void ReadGiftVoucherDetails()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {
                    RecordFound = true;
                    Amount = (decimal)DataReader["Amount"];
                    Location = DataReader["Loca_Descrip"].ToString();
                    CreateDate = DataReader["InsertDate"].ToString();
                    CreateUser = DataReader["CreateUser"].ToString();
                    ExpireDate = DataReader["ExpireDate"].ToString();
                    BookNo = DataReader["BookNo"].ToString();
                }
                else
                {
                    RecordFound = false;
                    Amount = 0;
                    Location = string.Empty;
                    CreateDate = string.Empty;
                    CreateUser = string.Empty;
                    ExpireDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    BookNo = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
            finally
            {
                dbcon.CloseReader();
            }


        }

        //Insert GiftVoucher
        public void UpdateGiftVoucherDetails()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "gif_sp_UpdateVoucherDetails";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ErrorCall));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "GV"));
                command.Parameters.Add(new SqlParameter("@Gi_Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Gi_Code));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Amount));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@ExpireDate", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ExpireDate));
                command.Parameters.Add(new SqlParameter("@CreateUser", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@BookNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, BookNo));
                command.Parameters.Add(new SqlParameter("@BookPages", SqlDbType.Float, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decQty));
                command.Parameters.Add(new SqlParameter("@Voucher_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strVoucherId));
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decId));


                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;

                // MessageBox.Show("Success !", "Onimta GiftVoucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                throw;
            }
            finally
            {
               
                dbcon.CloseConnection();
                dbcon.CloseReader();
            }
        }

        public void GetData()
        {
            try
            {
                dbcon.CloseConnection();
                GetDataSet = dbcon.getDataset(SqlString, "Table");
            }
            catch (Exception ex)
            {

                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public void SelectMaxRecord()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {
                    RecordFound = true;
                    Gi_Code = DataReader["Gi_Code"].ToString();
                   
                }
                else
                {
                    RecordFound = false;
                    Gi_Code = string.Empty;
                }
            }
            catch (Exception ex)
            {

                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.CloseReader();
            }
        }

        public void GifMaxRecord()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {
                    RecordFound = true;
                    _Gif_Number = DataReader["GifNumber"].ToString();

                }
                else
                {
                    RecordFound = false;
                    _Gif_Number = string.Empty;
                }
            }
            catch (Exception ex)
            {

                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.CloseReader();
            }
        }

        public void BookQty()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {
                    
                    decQty = decimal.Parse(DataReader["Qty"].ToString());
                    RecordFound = true;

                }
                else
                {                    
                    decQty = 0;
                    RecordFound = false;
                }
            }
            catch (Exception ex)
            {

                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.CloseReader();
            }
        }

        public void Charecter()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {

                   strCharecter = DataReader["Characters"].ToString();
                   RecordFound = true;

                }
                else
                {
                    strCharecter = string.Empty;
                    RecordFound = false;
                }
            }
            catch (Exception ex)
            {
                
                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                RecordFound = false;
            }
            finally
            {
                dbcon.CloseReader();
            }
        }
        public void SelectRang()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {
                    RecordFound = true;
                    CodeMin = DataReader["Code_Min"].ToString();
                    CodeMax = DataReader["Code_Max"].ToString();
                }
                else
                {
                    RecordFound = false;
                    Gi_Code = string.Empty;
                }
            }
            catch (Exception ex)
            {

                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.CloseReader();
            }
        }
        public void GetDataReader(string SqlStatement)
        {
            GetReader = dbcon.GetReader(SqlStatement);
        }
        public void CloseConnectionection()
        {
            dbcon.CloseConnection();
            dbcon.CloseReader();
        }

        public void SelectCharacter()
        {
            try
            {
                RecordFound = false;
                DataReader = dbcon.GetReader(SqlString);
                if (DataReader.Read())
                {
                    RecordFound = true;
                    Character = DataReader["Characters"].ToString();

                }
                else
                {
                    RecordFound = false;
                    Character = string.Empty;
                }
            }
            catch (Exception ex)
            {

                ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.CloseReader();
            }
        }

        //Insert GiftVoucher
        public void ReadGiftSPDetails( string SP)
        {
            try
            {
                dbcon.CloseConnection();
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ErrorCall));
                command.Parameters.Add(new SqlParameter("@LocaFrom", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CodeFrom));
                command.Parameters.Add(new SqlParameter("@LocaTo", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CodeTo));
                command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateFrom));
                command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTo));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;

                // MessageBox.Show("Success !", "Onimta GiftVoucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            finally
            {

                dbcon.CloseConnection();
                dbcon.CloseReader();
            }
        }

        public void ReadBinCard(string SP)
        {
            try
            {
                dbcon.CloseConnection();
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ErrorCall));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Amount));
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strIid));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters; 
            }

            finally
            {

                dbcon.CloseConnection();
                dbcon.CloseReader();
            }
        }
    }
}
