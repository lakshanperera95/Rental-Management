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
    public class clsDataUploading
    {
        private string strToLocaCode;
        private string strToLocaName;
        private string strSqlStatement;

        private int intErrCode;
        private SqlDataReader DataReader;
        private Boolean blRecordFound;

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string ToLocaCode
        {
            get { return strToLocaCode; }
            set { strToLocaCode = value; }
        }

        public string ToLocaName
        {
            get { return strToLocaName; }
            set { strToLocaName = value; }
        }

        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        private Boolean _Product;
        public Boolean Product
        {
            get { return _Product; }
            set { _Product = value; }
        }

        private Boolean _Department;
        public Boolean Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        private Boolean _Category;
        public Boolean Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        
        private Boolean _Brand;
        public Boolean Brand
        {
            get { return _Brand; }
            set { _Brand = value; }
        }

        private Boolean _AllProduct;
        public Boolean AllProduct
        {
            get { return _AllProduct; }
            set { _AllProduct = value; }
        }

        private Boolean _Supllier;
        public Boolean Supplier
        {
            get { return _Supllier; }
            set { _Supllier = value; }
        }

        private Boolean _Customer;
        public Boolean Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }


        private string _Dates;
        public string Dates
        {
            get { return _Dates; }
            set { _Dates = value; }
        }

        public void DataUploading()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_DataUploading";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strToLocaCode ));
                command.Parameters.Add(new SqlParameter("@Product", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Product));
                command.Parameters.Add(new SqlParameter("@AllProduct", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AllProduct));
                command.Parameters.Add(new SqlParameter("@Department", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Department));
                command.Parameters.Add(new SqlParameter("@Category", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Category));
                command.Parameters.Add(new SqlParameter("@Supplier", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Supplier));
                command.Parameters.Add(new SqlParameter("@Customer", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Customer));
                command.Parameters.Add(new SqlParameter("@Brand", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Brand));
                command.Parameters.Add(new SqlParameter("@Dates", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Dates));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            finally
            {
                dbcon.connection.Close();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsDataUploading 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

    }
}
