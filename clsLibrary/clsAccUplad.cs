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
   public class clsAccUplad:clsCommon
    {
        private string _TempDocNo;
        public string TempDocNo
        {
            get { return _TempDocNo; }
            set { _TempDocNo = value; }
        }

        private string _TransType;
        public string TransType
        {
            get { return _TransType; }
            set { _TransType = value; }
        }

        private SqlDataReader _Dr;
        public SqlDataReader Dr
        {
            get { return _Dr; }
            set { _Dr = value; }
        }

        private DataSet _Ds;
        public DataSet Ds
        {
            get { return _Ds; }
            set { _Ds = value; }
        }

        private DataSet _Ds1;
        public DataSet Ds1
        {
            get { return _Ds1; }
            set { _Ds1 = value; }
        }

        private string _DateFrom;
        public string DateFrom
        {
            get { return _DateFrom; }
            set { _DateFrom = value; }
        }

        private string _DateTo;
        public string DateTo
        {
            get { return _DateTo; }
            set { _DateTo = value; }
        }

        private int _ErrorCode;
        public int ErrorCode
        {
            get { return _ErrorCode; }
            set { _ErrorCode = value; }
        }

        private string _SqlQuery;
        public string SqlQuery
        {
            get { return _SqlQuery; }
            set { _SqlQuery = value; }
        }

        private string _Dataset;
        public string Dataset
        {
            get { return _Dataset; }
            set { _Dataset = value; }
        }

        private string _Loca;
        public string Loca
        {
            get { return _Loca; }
            set { _Loca = value; }
        }


       public void UpdateData()
       {
           try
           {
               _ErrorCode = 0;
               dbcon.OpenConnection();
               SqlCommand command = new SqlCommand();
               command.Connection = dbcon.connection;
               command.CommandType = CommandType.StoredProcedure;
               command.CommandText = "sp_LoadAcc";
               command.CommandTimeout = LoginSys.dbocommTimeOut;
               //command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, _ErrorCode));
               command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _TempDocNo));
               command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Loca));
               command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _DateFrom));
               command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _DateTo));
               command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
               command.Parameters.Add(new SqlParameter("@TransType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _TransType));
               

               SqlDataAdapter SDA = new SqlDataAdapter(command);
               SqlDataAdapter SDA1 = new SqlDataAdapter(command);
               SDA.Fill(_Ds = new DataSet(), "DsInvoiceDetails");
               SDA1.Fill(_Ds1 = new DataSet(), "PaymentDetails");
               command.UpdatedRowSource = UpdateRowSource.OutputParameters;
              // ErrorCode = (int)(command.Parameters["@Err_x"].Value);
              

           }
           catch (Exception e)
           {
               Errormsg(e, "clsAccUplad");

           }
           finally
           {
               dbcon.connection.Close();
           }
       }

       public void GetTempDocumentNo()
       {
           try
           {
               _Dr = dbcon.GetReader(_SqlQuery + LoginManager.LocaCode);
               if (_Dr.Read())
               {
                   int intTempDocNo = (int)_Dr.GetSqlInt32(0);
                   //String.Format("{0:00000}", 15); 
                   _TempDocNo = string.Format("{0:000000}", intTempDocNo);
                   if (LoginManager.UserName.Trim().Length >= 2)
                   {
                       _TempDocNo = LoginManager.UserName.Trim().Substring(0, 2).ToUpper() + LoginManager.LocaCode.Trim().Substring(0, 2) + _TempDocNo; 
                   }
                   else
                   {
                       _TempDocNo = LoginManager.UserName.Trim().ToUpper() + "0" + LoginManager.LocaCode.Trim().Substring(0, 2) + _TempDocNo;
                   }
               }
           }
           catch (Exception e)
           {
               Errormsg(e, "clsAccUplad");

           }
           finally
           {
               dbcon.CloseReader();
               _Dr.Dispose();
           }

           try
           {
               //UpDate Record No
               _ErrorCode = 0;
               dbcon.OpenConnection();
               SqlCommand command = new SqlCommand();
               command.Connection = dbcon.connection;
               command.CommandType = CommandType.StoredProcedure;
               command.CommandText = "sp_UpdateTempDocNo";
               command.CommandTimeout = LoginSys.dbocommTimeOut;
               command.Parameters.Clear();
               command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, _ErrorCode));
               command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "ACC"));
               command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

               command.ExecuteNonQuery();
               command.UpdatedRowSource = UpdateRowSource.OutputParameters;
               ErrorCode = (int)(command.Parameters["@Err_x"].Value);
           }
           catch (Exception e)
           {
               Errormsg(e, "clsAccUplad");

           }
           finally
           {
               dbcon.connection.Close();
               
           }
       }

       public void SetDataset()
       {
           _Ds = dbcon.getDataset(SqlQuery, Dataset);
       }

       public void AccountUplad()
       {
           try
           {
               _ErrorCode = 0;
               dbcon.OpenConnection();
               SqlCommand command = new SqlCommand();
               command.Connection = dbcon.connection;
               command.CommandType = CommandType.StoredProcedure;
               command.CommandText = "sp_AccUpload";
               command.CommandTimeout = LoginSys.dbocommTimeOut;
               //command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, _ErrorCode));
               command.Parameters.Add(new SqlParameter("@TempDocNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _TempDocNo));
               command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Loca));
               command.Parameters.Add(new SqlParameter("@LocaForDocNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
               command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _DateFrom));
               command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _DateTo));
               command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
               command.Parameters.Add(new SqlParameter("@TransType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _TransType));

               command.ExecuteNonQuery();
              // command.UpdatedRowSource = UpdateRowSource.OutputParameters;
               //ErrorCode = (int)(command.Parameters["@Err_x"].Value);


           }
           catch (Exception e)
           {
               Errormsg(e, "clsAccUplad");

           }
           finally
           {
               dbcon.connection.Close();
           }
       }
    }
}
