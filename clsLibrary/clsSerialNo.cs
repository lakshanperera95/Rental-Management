using clsLibrary;
using DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public class clsSerialNo : clsPublic
    {
        //propoties
        private string strSqlStatement;
        private SqlDataReader DataReader;
        private string strTempDocumentNo; 
        private int intErrCode;
        private DataSet dsTempSerialNo;
        private Boolean blRecordFound;

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

        public string TempDocNo
        {
            get { return strTempDocumentNo; }
            set { strTempDocumentNo = value; }
        }
        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }
        private string strProdCode;
        public string ProdCode
        {
            get { return strProdCode; }
            set { strProdCode = value; }
        }
        private string stserialNo;
        public string SerialNo
        {
            get { return stserialNo; }
            set { stserialNo = value; }
        }
       private decimal decQty;
        public decimal Qty
        {
            get { return decQty; }
            set { decQty = value; }
        }

        public DataSet TempSerialNo
        {
            get { return dsTempSerialNo; }
            set { dsTempSerialNo = value; }
        }
        private DataSet ds;
        public DataSet Ads
        {
            get { return ds; }
            set { ds = value; }
        }

        public void GetSerialNo()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SerialNumberAdd";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TempDocNo));
                command.Parameters.Add(new SqlParameter("@SerialNo", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SerialNo));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ProdCode));
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));           
   
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsTransferGoodNote 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetTempDataset()
        {
            try
            {
                //get Temporary DataSet For serial number
                dsTempSerialNo = dbcon.getDataset("select SerialNo from TempSerialNo where DocNo ='"+TempDocNo.Trim()+ "' AND ProdCode ='"+ProdCode.Trim()+"'", "dsSerialNo");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsTransferGoodNote 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        public void GetDs()
        {
            try
            {
                ds = dbcon.getDatasetOt(strSqlStatement, "dsSerialNo");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsTransferGoodNote 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        public void ReadTempDetail()
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsTransferGoodNote 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        public void GetSRNtempDataset()
        {
            try
            {
                //get Temporary DataSet For serial number
                dsTempSerialNo = dbcon.getDataset("SELECT SerialNo FROM SerialNo_Apply WHERE DocNo ='"+TempDocNo.Trim()+"' AND ProdCode ='"+ProdCode.Trim()+"' AND Loca='"+LoginManager.LocaCode+ "' AND Qty<>0", "dsSerialNo");
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsTransferGoodNote 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
    }
    

}
