using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DbConnection;
using System.IO;
namespace clsLibrary
{
    public class clsSupplier
    {
        #region General Declaration
        private int intErrCode;
        int intCredit_Period;

        private string strCust_Code;
        private string strCust_Name;
        private string strCusArea_Code;
        private string strCusAddress1;
        private string strCusAddress2;
        private string strCusAddress3;
        private string strCusAddress4;
        private string strCusCountry;
        private string strCusTel;
        private string strCusFax;
        private string strCusEmail;
        private string strCusDateOfBirth;
        private string strCusNIC;
        private string strCusContact_Prsn;
        private int intCusCredit_Period;

        private string strSupp_Code;
        private string strSupp_Name;
        private string strSuppAddress1;
        private string strSuppAddress2;
        private string strSuppAddress3;
        private string strSuppAddress4;
        private string strSuppTel;
        private string strSuppFax;
        private string strSuppEmail;
        private string strSuppContact_Prsn;
        private string strCustIid;

        private int intSuppCredit_Period;

        private string strSqlStatement;
        private string strDataSetName;

        private decimal decCusCredit_Limit;
        private decimal decDiscount;

        private DataSet dsSupplierDataSet;
        private DataSet dsCustomerDataSet;

        private Boolean blRecordFound;

        private SqlDataReader DataReader;
        #endregion

    #region Properties


        #region Update 24.11.2009 Amila
        private string strAccountNumber;
        private string strBank;
        private string strBranch;

        public string AccountNumber
        {
            get { return strAccountNumber; }
            set { strAccountNumber = value; }
        }

        public string Bank
        {
            get { return strBank; }
            set { strBank = value; }
        }

        public string Branch
        {
            get { return strBranch; }
            set { strBranch = value; }
        } 
        #endregion

        public string Cust_Code
        {
            get { return strCust_Code; }
            set { strCust_Code = value; }
        }

        public string Cust_Name
        {
            get { return strCust_Name; }
            set { strCust_Name = value; }
        }

        public string CusArea_Code
        {
            get { return strCusArea_Code; }
            set { strCusArea_Code = value; }
        }

        public string CusAddress1
        {
            get { return strCusAddress1; }
            set { strCusAddress1 = value; }
        }

        public string CusAddress2
        {
            get { return strCusAddress2; }
            set { strCusAddress2 = value; }
        }

        public string CusAddress3
        {
            get { return strCusAddress3; }
            set { strCusAddress3 = value; }
        }

        public string CusAddress4
        {
            get { return strCusAddress4; }
            set { strCusAddress4 = value; }
        }

        public string CusCountry
        {
            get { return strCusCountry; }
            set { strCusCountry = value; }
        }

        public string CusTel
        {
            get { return strCusTel; }
            set { strCusTel = value; }
        }

        public string CusFax
        {
            get { return strCusFax; }
            set { strCusFax = value; }
        }

        public string CusEmail
        {
            get { return strCusEmail; }
            set { strCusEmail = value; }
        }

        public string CusDateOfBirth
        {
            get { return strCusDateOfBirth; }
            set { strCusDateOfBirth = value; }
        }

        public string CusNIC
        {
            get { return strCusNIC; }
            set { strCusNIC = value; }
        }

        public decimal CusCredit_Limit
        {
            get { return decCusCredit_Limit; }
            set { decCusCredit_Limit = value; }
        }

        public string CusContact_Prsn
        {
            get { return strCusContact_Prsn; }
            set { strCusContact_Prsn = value; }
        }

        public string DataSetName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
        }

        public int CusCredit_Period
        {
            get { return intCusCredit_Period; }
            set { intCusCredit_Period = value; }
        }

        public decimal CusDiscount
        {
            get { return decDiscount; }
            set { decDiscount = value; }
        }

        public string Supp_Code
        {
            get { return strSupp_Code; }
            set { strSupp_Code = value; }
        }

        public string Supp_Name
        {
            get { return strSupp_Name; }
            set { strSupp_Name = value; }
        }

        public string SuppAddress1
        {
            get { return strSuppAddress1; }
            set { strSuppAddress1 = value; }
        }

        public string SuppAddress2
        {
            get { return strSuppAddress2; }
            set { strSuppAddress2 = value; }
        }

        public string SuppAddress3
        {
            get { return strSuppAddress3; }
            set { strSuppAddress3 = value; }
        }

        public string SuppAddress4
        {
            get { return strSuppAddress4; }
            set { strSuppAddress4 = value; }
        }

        public string SuppTel
        {
            get { return strSuppTel; }
            set { strSuppTel = value; }
        }

        public string SuppFax
        {
            get { return strSuppFax; }
            set { strSuppFax = value; }
        }

        public string SuppEmail
        {
            get { return strSuppEmail; }
            set { strSuppEmail = value; }
        }

        public string SuppContact_Prsn
        {
            get { return strSuppContact_Prsn; }
            set { strSuppContact_Prsn = value; }
        }

        public int SuppCredit_Period
        {
            get { return intSuppCredit_Period; }
            set { intSuppCredit_Period = value; }
        }

        public int ErrorCode
        {
            get { return intErrCode; }
            set { intErrCode = value; }
        }

        public string SqlStatement
        {
            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }

        public string CustIid
        {
            get { return strCustIid; }
            set { strCustIid = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public DataSet GetCustomerDataset
        {
            get { return dsCustomerDataSet; }
            set { dsCustomerDataSet = value; }
        }

        public DataSet GetSupplierDataset
        {
            get { return dsSupplierDataSet; }
            set { dsSupplierDataSet = value; }
        }

        private string strCustCode;
        public string GetCustCode
        {
            get { return strCustCode; }
            set { strCustCode = value; }
        }

        private string strOccupation;
        public string GetOccupation
        {
            get { return strOccupation; }
            set { strOccupation = value; }
        }

        private string strAddress1;
        public string GetAddress1
        {
            get { return strAddress1; }
            set { strAddress1 = value; }
        }

        private string strAddress2;
        public string GetAddress2
        {
            get { return strAddress2; }
            set { strAddress2 = value; }
        }

        private string strAddress3;
        public string GetAddress3
        {
            get { return strAddress3; }
            set { strAddress3 = value; }
        }

        private string strPhone;
        public string GetPhone
        {
            get { return strPhone; }
            set { strPhone = value; }
        }

        private decimal strMonIncome;
        public decimal GetMonIncome
        {
            get { return strMonIncome; }
            set { strMonIncome = value; }
        }

        private string strSpouseName;
        public string GetSpouseName
        {
            get { return strSpouseName; }
            set { strSpouseName = value; }
        }

        private string strSpOccupation;
        public string GetSpOccupation
        {
            get { return strSpOccupation; }
            set { strSpOccupation = value; }
        }

        private string strSpAddress;
        public string GetSpAddress
        {
            get { return strSpAddress; }
            set { strSpAddress = value; }
        }

        private string strSpAddress2;
        public string GetSpAddress2
        {
            get { return strSpAddress2; }
            set { strSpAddress2 = value; }
        }

        private string strSpAddress3;
        public string GetSpAddress3
        {
            get { return strSpAddress3; }
            set { strSpAddress3 = value; }
        }

        private string strSpPhone;
        public string GetSpPhone
        {
            get { return strSpPhone; }
            set { strSpPhone = value; }
        }

        private decimal strSpMonIncome;
        public decimal GetSpMonIncome
        {
            get { return strSpMonIncome; }
            set { strSpMonIncome = value; }
        }

        private string strComName;
        public string GetComName
        {
            get { return strComName; }
            set { strComName = value; }
        }

        private string strComAddress1;
        public string GetComAddress1
        {
            get { return strComAddress1; }
            set { strComAddress1 = value; }
        }

        private string strComAddress2;
        public string GetComAddress2
        {
            get { return strComAddress2; }
            set { strComAddress2 = value; }
        }

        private string strComAddress3;
        public string GetComAddress3
        {
            get { return strComAddress3; }
            set { strComAddress3 = value; }
        }

        private string strComPhone;
        public string GetComPhone
        {
            get { return strComPhone; }
            set { strComPhone = value; }
        }

        private string strRefName;
        public string GetRefName
        {
            get { return strRefName; }
            set { strRefName = value; }
        }

        private DateTime strRefBirthday;
        public DateTime GetRefBirthday
        {
            get { return strRefBirthday; }
            set { strRefBirthday = value; }
        }

        private string strRefNIC;
        public string GetRefNIC
        {
            get { return strRefNIC; }
            set { strRefNIC = value; }
        }

        private string strRefOccupation;
        public string GetRefOccupation
        {
            get { return strRefOccupation; }
            set { strRefOccupation = value; }
        }

        private string strClass;
        public string GetClass      
        {
            get { return strClass; }
            set { strClass = value; }
        }

        private DataSet ds;
        public DataSet Getds
        {
            get { return ds; }
            set { ds = value; }
        }

        private bool _Disable;

        public bool Disable
        {
            get { return _Disable; }
            set { _Disable = value; }
        }

        private string PayType;
        public string _PayType
        {
            get { return PayType; }
            set { PayType = value; }
        }

        private string strLinkCust;
        public string _strLinkCust
        {
            get { return strLinkCust; }
            set { strLinkCust = value; }
        }

        private string strLinkSupp;
        public string _strLinkSupp
        {
            get { return strLinkSupp; }
            set { strLinkSupp = value; }
        }
        private string strVatNo;
        public string _strVatNo
        {
            get { return strVatNo; }
            set { strVatNo = value; }
        }
        private bool blIsVat;
        public bool _blIsVat
        {
            get { return blIsVat; }
            set { blIsVat = value; }
        }


        
    #endregion

        public void ReadCustomerDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strCust_Code = DataReader["Cust_Code"].ToString();
                    strCust_Name = DataReader["Cust_Name"].ToString();
                    strCusArea_Code = DataReader["Area_Code"].ToString();
                    strCusAddress1 = DataReader["Address1"].ToString();
                    strCusAddress2 = DataReader["Address2"].ToString();
                    strCusAddress3 = DataReader["Address3"].ToString();
                    strCusAddress4 = DataReader["Address4"].ToString();
                    strCusCountry = DataReader["Country"].ToString();
                    strCusTel = DataReader["Tel"].ToString();
                    strCusFax = DataReader["Fax"].ToString();
                    strCusEmail = DataReader["Email"].ToString();
                    strCusDateOfBirth = DataReader["DateOfBirth"].ToString();
                    strCusNIC = DataReader["NIC"].ToString();
                    strCustIid = DataReader["Iid"].ToString();
                    strCusContact_Prsn = DataReader["Contact_Prsn"].ToString();

                    intCusCredit_Period = int.Parse(DataReader["Credit_Period"].ToString());
                    decCusCredit_Limit = decimal.Parse(DataReader["Credit_Limit"].ToString());
                    decDiscount = decimal.Parse(DataReader["Discount"].ToString());
                    Disable = (bool)DataReader["Inactive"];
                    PayType = DataReader["paymentType"].ToString();

                    _blIsVat = (bool)DataReader["VAT"];
                    _strVatNo = DataReader["VatNO"].ToString();


                    blRecordFound = true;
                }
                else
                {
                    strCust_Code = string.Empty;
                    strCust_Name = string.Empty;
                    strCusArea_Code = string.Empty;
                    strCusAddress1 = string.Empty;
                    strCusAddress2 = string.Empty;
                    strCusAddress3 = string.Empty;
                    strCusAddress4 = string.Empty;
                    strCusCountry = string.Empty;
                    strCusTel = string.Empty;
                    strCusFax = string.Empty;
                    strCusEmail = string.Empty;
                    strCusDateOfBirth = string.Empty;
                    strCusNIC = string.Empty;
                    strCusContact_Prsn = string.Empty;

                    _blIsVat = false;
                    _strVatNo = string.Empty;
                    intCusCredit_Period = 0;
                    decCusCredit_Limit = 0;
                    decDiscount = 0;
                    PayType = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetCustomerDetails()
        {
            try
            {
                dsCustomerDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void GetSupplierDetails()
        {
            try
            {
                dsSupplierDataSet = dbcon.getDataset(strSqlStatement, strDataSetName);
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void CustomerUpdate()
        {
            try
            {
                intErrCode = 0;

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandText = "sp_CustomerFileUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCust_Code));
                command.Parameters.Add(new SqlParameter("@Cust_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCust_Name));
                command.Parameters.Add(new SqlParameter("@Add1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusAddress1));
                command.Parameters.Add(new SqlParameter("@Add2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusAddress2));
                command.Parameters.Add(new SqlParameter("@Add3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusAddress3));
                command.Parameters.Add(new SqlParameter("@Add4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusAddress4));
                command.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusCountry));
                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusTel));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusFax));
                //command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusEmail));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Credit_Limit", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decCusCredit_Limit));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "N/A"));
                command.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusNIC));
                //command.Parameters.Add(new SqlParameter("@Contact_Prsn", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCusContact_Prsn));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decDiscount));
                command.Parameters.Add(new SqlParameter("@Credit_Period", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, intCusCredit_Period));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustIid));
                command.Parameters.Add(new SqlParameter("@Inactive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Disable));
                command.Parameters.Add(new SqlParameter("@CustPaymentType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PayType));
                command.Parameters.Add(new SqlParameter("@LinkSupp", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLinkSupp));
                command.Parameters.Add(new SqlParameter("@IsVat", blIsVat));
                command.Parameters.Add(new SqlParameter("@VatNo", strVatNo));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
                //Cust_Name = command.Parameters["@Cust_Name"].Value.ToString();
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void CustomerDelete()
        {

            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CustomerFileDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;

                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Cust_Code", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCust_Code));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        //Supplier
        public void ReadSupplierDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strSupp_Code = DataReader["Supp_Code"].ToString();
                    strSupp_Name = DataReader["Supp_Name"].ToString();
                    strSuppAddress1 = DataReader["Address1"].ToString();
                    strSuppAddress2 = DataReader["Address2"].ToString();
                    strSuppAddress3 = DataReader["Address3"].ToString();
                    strSuppAddress4 = DataReader["Address4"].ToString();
                    strSuppTel = DataReader["Tel"].ToString();
                    strSuppFax = DataReader["Fax"].ToString();
                    strSuppEmail = DataReader["Email"].ToString();
                    strSuppContact_Prsn = DataReader["Contact_Prsn"].ToString();
                    intSuppCredit_Period = int.Parse(DataReader["Credit_Period"].ToString());
                    AccountNumber = DataReader["AccountNo"].ToString();
                    Bank = DataReader["Bank"].ToString();
                    Branch = DataReader["Branch"].ToString();
                    Disable = (bool)DataReader["Inactive"];

                    blIsVat = (bool)DataReader["VAT"];
                    strVatNo = DataReader["VatNO"].ToString();

                    blRecordFound = true;
                }
                else
                {
                    strSupp_Code = string.Empty;
                    strSupp_Name = string.Empty;
                    strSuppAddress1 = string.Empty;
                    strSuppAddress2 = string.Empty;
                    strSuppAddress3 = string.Empty;
                    strSuppAddress4 = string.Empty;
                    strSuppTel = string.Empty;
                    strSuppFax = string.Empty;
                    strSuppEmail = string.Empty;
                    strSuppContact_Prsn = string.Empty;

                    blIsVat = false;
                    strVatNo = string.Empty; ;
                    intSuppCredit_Period = 0;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SupplierUpdate()
        {
            try
            {
                intErrCode = 0;

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SupplierFileUpdate";
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSupp_Code));
                command.Parameters.Add(new SqlParameter("@Supp_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSupp_Name));
                command.Parameters.Add(new SqlParameter("@Add1", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppAddress1));
                command.Parameters.Add(new SqlParameter("@Add2", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppAddress2));
                command.Parameters.Add(new SqlParameter("@Add3", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppAddress3));
                command.Parameters.Add(new SqlParameter("@Add4", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppAddress4));
                command.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppTel));
                command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppFax));
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppEmail));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Credit_Period", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, intSuppCredit_Period));
                command.Parameters.Add(new SqlParameter("@Contact_Prsn", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSuppContact_Prsn));
                command.Parameters.Add(new SqlParameter("@AccountNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, AccountNumber));
                command.Parameters.Add(new SqlParameter("@Bank", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Bank));
                command.Parameters.Add(new SqlParameter("@Branch", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Branch));
                command.Parameters.Add(new SqlParameter("@Inactive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Disable));
                command.Parameters.Add(new SqlParameter("@LinkCust", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLinkCust));
                command.Parameters.Add(new SqlParameter("@IsVat", blIsVat));
                command.Parameters.Add(new SqlParameter("@VatNo", strVatNo));


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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 007. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SupplierDelete()
        {
            try
            {
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_SupplierFileDelete";
                command.CommandTimeout = LoginSys.dbocommTimeOut;

                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Supp_Code", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSupp_Code));
                command.Parameters.Add(new SqlParameter("@User_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@getMessage", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, "10"));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 008. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadSupplierRelatedDetails()
        {
            try
            {
                //Find Products For This Department
                DataReader = dbcon.GetReader("SELECT Prod_Code FROM Product WHERE Supplier_Id = '" + strSupp_Code + "'");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsAccount 009. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        //sp_TempCustDetail_Save
        public void tempInsertCutDetail()
        {
            try
            {
                intErrCode = 0;

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_TempCustDetail_Save";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@RefName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefName));
                command.Parameters.Add(new SqlParameter("@RefBirthday", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefBirthday));
                command.Parameters.Add(new SqlParameter("@RefNIC", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefNIC));
                command.Parameters.Add(new SqlParameter("@RefOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefOccupation));
                command.Parameters.Add(new SqlParameter("@Class", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strClass));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadDuplicateNIC()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strCustCode = DataReader["CustomerCode"].ToString();
                    strCust_Name = DataReader["Cust_Name"].ToString();
                    strCusNIC = DataReader["RefNIC"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    strCustCode = string.Empty;
                    strCust_Name = string.Empty;
                    strCusNIC = string.Empty;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


        public void InsertCutDetail()
        {
            try
            {
                intErrCode = 0;

                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CustDetail_Save";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCustCode));
                command.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strOccupation));
                command.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress1));
                command.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress2));
                command.Parameters.Add(new SqlParameter("@Address3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAddress3));
                command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPhone));
                command.Parameters.Add(new SqlParameter("@MonIncome", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMonIncome));
                command.Parameters.Add(new SqlParameter("@SpouseName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpouseName));
                command.Parameters.Add(new SqlParameter("@SpOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpOccupation));
                command.Parameters.Add(new SqlParameter("@SpAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpAddress));
                command.Parameters.Add(new SqlParameter("@SpAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpAddress2));
                command.Parameters.Add(new SqlParameter("@SpAddress3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpAddress3));
                command.Parameters.Add(new SqlParameter("@SpPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpPhone));
                command.Parameters.Add(new SqlParameter("@SpMonIncome", SqlDbType.Money, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSpMonIncome));
                command.Parameters.Add(new SqlParameter("@ComName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComName));
                command.Parameters.Add(new SqlParameter("@ComAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComAddress1));
                command.Parameters.Add(new SqlParameter("@ComAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComAddress2));
                command.Parameters.Add(new SqlParameter("@ComAddress3", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComAddress3));
                command.Parameters.Add(new SqlParameter("@ComPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strComPhone));
                //command.Parameters.Add(new SqlParameter("@RefName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefName));
                //command.Parameters.Add(new SqlParameter("@RefBirthday", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefBirthday));
                //command.Parameters.Add(new SqlParameter("@RefNIC", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefNIC));
                //command.Parameters.Add(new SqlParameter("@RefOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRefOccupation));
                //command.Parameters.Add(new SqlParameter("@Class", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strClass));

                command.ExecuteNonQuery();
                MessageBox.Show("Saveed Succsessfully", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsAccount 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                dbcon.CloseConnection();
            }

           
        }

        public void ReadDetails()
        {
            try
            {
                //Find Products For This Department
                DataReader = dbcon.GetReader(SqlStatement);
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
                clsClear.ErrMessage(e.Message, e.StackTrace);
            }
            finally
            {
                dbcon.CloseReader();
                DataReader.Dispose();
            }
        }
        private string strCusCode;
        public string CusCode
        {
            get { return strCusCode; }
            set { strCusCode = value; }
        }
        public void GetSuppCode()
        {
            try
            {

                SqlStatement = "SELECT Supp FROM dbo.CodeGenarator	 ";

                int Code = 0;
                DataReader = dbcon.GetReader(SqlStatement);
                if (DataReader.Read())
                {
                    Code = (int)DataReader[0];
                }
                strCusCode = string.Format("{0:000}", Code);
                strCusCode = "S" + strCusCode;


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

        public void GetCusCode(string Custype)
        {
            try
            {
                if (Custype == "WC")
                {
                    SqlStatement = "SELECT WCust FROM dbo.CodeGenarator	 ";
                }
                else if (Custype == "RC")
                {
                    SqlStatement = "SELECT RCust FROM dbo.CodeGenarator	 ";

                }
                int Code = 0;
                DataReader = dbcon.GetReader(SqlStatement);
                if (DataReader.Read())
                {
                    Code = (int)DataReader[0];
                }
                strCusCode = string.Format("{0:000}", Code);
                strCusCode = Custype.ToUpper() + strCusCode;


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
}

}
