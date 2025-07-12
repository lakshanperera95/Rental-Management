using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DbConnection;


namespace clsLibrary
{
    public class clsLocation
    {
        static clsLocation location = new clsLocation();

        public static  clsLocation getlocation() {

            return location;
        }

        string strTitl = ("Location Master File");
        string strAct;


        SqlDataAdapter adapter2;

        DataSet CompDataSet1;
        DataSet CompDataSet2;
        int intErrorCode;
        int intErrorCode2;
        string strSql;
        string strMessage;


#region variable declaration for use of property
        
        string strlocationCode;
        string strlocationName;
        string strAddress1;
        string strAddress2;
        string strAddress3;
        string strTelephone;
        string strFax;
        string strEmail;
        string strTaxRegion;
        string strWebAddress;
        

        #endregion

        #region Properties for Location
        public string LocationCode {
            get {
                return strlocationCode;
            }
            set {
                clsValidation validate = new clsValidation();
                validate.FeildLength = 10;
                validate.TextString = value;
                validate.FieldType = "CHR";
                validate.IsBlank = true;
                validate.Namefield = "Location Code";
                
                strlocationCode = value;
            }
        
        }

        public string LocationName {
            get             {                return strlocationName;            }
            set             {                strlocationName = value;             }
        }

        public int ErrorCode
        {
            get            {                return intErrorCode;            }
            set            {                intErrorCode =value;            }
        }

        public int ErrorCode2
        {
            get            {                return intErrorCode2;            }
            set            {                intErrorCode2 = value;            }
        }

        public string Address1
        {
            get            {                return strAddress1;            }
            set            {                strAddress1 = value;            }
        }

        public string Address2
        {
            get            {                return strAddress2;            }
            set            {                strAddress2 = value;            }
        }

        public string Address3
        {
            get            {                return strAddress3;            }
            set            {                strAddress3 = value;            }
        }

        public string Telephone
        {
            get            {                return strTelephone;            }
            set            {                strTelephone = value;            }
        }

        public string Fax
        {
            get            {                return strFax;            }
            set            {                strFax = value;            }
        }

        public string Email
        {
            get            {                return strEmail;            }
            set            {                strEmail = value;            }
        }

        public string Tax
        {
            get            {                return strTaxRegion;            }
            set            {                strTaxRegion = value;            }
        }

        public string WebAddress
        {
            get { return strWebAddress; }
            set { strWebAddress = value; }
        }
#endregion

#region "Passing SQL Statement for Retrieving"
        public string SqlString {
            get {
                return strSql;
            }
            set {
                strSql = value;
            }
        }
#endregion

        public string GetAction
        {
            get
            {
                return strAct;
            }
            set
            {
                strAct = value;
            }
        }

        public string GetTitle
        {
            get
            {
                return strTitl;
            }
            set
            {
                strTitl = value;
            }
        }

        public DataSet GetDataset1
        {
            get
            {
                return CompDataSet1;
            }
            set
            {
                CompDataSet1 = value;
            }
        }

        public DataSet GetDataset2
        {
            get
            {
                return CompDataSet2;
            }
            set
            {
                CompDataSet2 = value;
            }
        }

        public bool OGF { get; set; }

        public void UpdateData(Control clearControl,Control focusControl)
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_LocationFileUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrorCode));
                command.Parameters.Add(new SqlParameter("@Loca_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strlocationCode));
                command.Parameters.Add(new SqlParameter("@Loca_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strlocationName));
                command.Parameters.Add(new SqlParameter("@Add1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@Add2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@Add3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTelephone));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strFax));
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strEmail));
                command.Parameters.Add(new SqlParameter("@TaxReg", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTaxRegion));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Curr_Loca", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@WebAddress", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strWebAddress));
                command.Parameters.Add(new SqlParameter("@OGF", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OGF));
              

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                dbcon.connection.Close();
                if (intErrorCode == 0)
                {
                    MessageBox.Show("Record updated successfully", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // clear used fields & focus to TxtLocaCode


                    LocationName = string.Empty;
                    LocationCode = string.Empty;
                    Address1 = string.Empty;
                    Address2 = string.Empty;
                    Address3 = string.Empty;
                    Telephone = string.Empty;
                    Fax = string.Empty;
                    Email = string.Empty;
                    Tax = string.Empty;
                    OGF = false;



                    clsClear.getclear().clearfeilds(clearControl, focusControl);
                }
                else
                {
                    MessageBox.Show("Error in Transaction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsLocation 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                dbcon.connection.Close();
            }
        
        }

        public void DeleteData(string del,Control clear,Control focus) {
            try {
            dbcon.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = dbcon.connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_LocationFileDelete";
            command.CommandTimeout = LoginSys.dbocommTimeOut;
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrorCode2));
            command.Parameters.Add(new SqlParameter("@Loca_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,del));
            command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "Saga"));
            command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

            command.ExecuteNonQuery();
            command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            ErrorCode2 = (int)(command.Parameters["@Err_x"].Value);
            strMessage = (string)(command.Parameters["@getMessage"].Value);
            dbcon.connection.Close();
            if (intErrorCode2 != 0)
            {
                MessageBox.Show("an internal error has occurred while deleting the current record", "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else { 
            clsClear .getclear().clearfeilds(clear,focus);
            
            }            

            }catch (
                SqlException ex){
                MessageBox.Show(ex.Message .ToString (),"Location Details",MessageBoxButtons .OK ,MessageBoxIcon.Error);
            
            }finally {
                dbcon .connection .Close ();}
                MessageBox.Show(strMessage.ToString(), "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Information );

        }

        public DataSet RetriveData(string query)
        {
            try
            {
                dbcon.connection.Open();
                adapter2 = new SqlDataAdapter(query, dbcon.connection);
                GetDataset2 = new DataSet();
                adapter2.Fill(GetDataset2, "Table");
                return GetDataset2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return new DataSet();
            }
            finally
            {
                dbcon.connection.Close();
            }
        }
        public static DataTable getLocationsForLogging(string Qry)
        {
            try
            {
                DataTable tempdt = new DataTable();
                string dsName = "dtLocations";
                tempdt = dbcon.getDataset(Qry, "dtLocations").Tables[0];
                
                return tempdt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataTable getLocationDetailsForLogging(string LocaCode)
        {
            try
            {
                DataTable tempdt = new DataTable();
                tempdt = dbcon.getDataset("SELECT Loca AS Code, Loca_Descrip AS Description FROM Location WHERE  Loca LIKE '%" +LocaCode+ "%' " +
                    "and Loca<>'" + LoginManager.ExtLoca + "' and TaxLoca=0 ORDER BY Loca", "dtLocations").Tables[0];
                return tempdt;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
   
}
