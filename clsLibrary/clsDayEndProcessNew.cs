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
    public class clsDayEndProcessNew
    {

        private int intErrCode;

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

        private DataSet ResultSet;
        public DataSet dsResultSet
        {
            get { return ResultSet; }
            set { ResultSet = value; }
        }



        public void checkNumeric(KeyPressEventArgs e, string txtvalue)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                else
                {
                    decimal value;
                    e.Handled = !decimal.TryParse(txtvalue + e.KeyChar, out value);
                }
            }
            catch (Exception ex)
            {
                
               clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            
        }

        public void PosSalesSummary(string strLoca, string strDateFrom, string strDateTo)
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 10000;
                command.CommandText = "sp_PosSalesSummaryReport";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLoca));
                command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDateFrom));
                command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strDateTo));

                command.ExecuteNonQuery();
                
           
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@ErrorCode"].Value);
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = command;
                //da.Fill(dsResultSet = new DataSet(), "dsPosSalesSummary"); 
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

        public void SMSSendingData()
        {
            dbcon.CloseConnection();
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SMSSendingData";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@User", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
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
                dbcon.CloseConnection();
            }
        }


        public void DayEndProcess()
        {
            try
            {
                intErrCode = 1;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = "sp_DayEndProcess";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
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
                dbcon.CloseConnection();
            }
        }

        public void DuplicateCheck()
        {
            dbcon.CloseConnection();
            try
            {
                ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = "sp_DayEndProcess_DuplicateCheck";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ResultSet = new DataSet(), "dsDuplicateCheck");

              
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
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

        public void DuplicateRemove()
        {
            dbcon.CloseConnection();
            try
            {
                ErrorCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandText = "sp_DayEndProcess_RemoveDuplicate";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ResultSet = new DataSet(), "dsDuplicateCheck");
              

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
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


    }
}
