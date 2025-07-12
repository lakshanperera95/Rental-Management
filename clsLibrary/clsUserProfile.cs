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
    public class clsUserProfile :clsPublic
    {
        private int intErrCode;
        private string strUserName;
        private string strPassword;
        private string strLoca;
        private decimal decUserRole_Id;
        private string strAcc_Desable;
        private string strUserCannotChgPwd;
        private string strChgPwdNxtLogin;
        //private string strUserRole_Id;
        private string strUserRole_Description;
        private string strMSTDT;
        private string strMSTDTREP;
        private string strLocaMaster;
        private string strTRAN;
        private string strPUR;
        private string strPUROR;
        private string strPURORDET;
        private string strGRN;
        private string strGRNDET;
        private string strSRN;
        private string strSRNDET;
        private string strTOG;
        private string strTOGDET;
        private string strSALE;
        private string strWSALE;
        private string strWSALEDET;
        private string strCUSRET;
        private string strCUSRETDET;
        private string strPMT;
        private string strPAYMENT;
        private string strPMTDET;
        private string strRECEIPT;
        private string strRECDET;
        private string strSTAD;
        private string strSTADJ;
        private string strSTADDET;
        private string strSTOVER;
        private string strSTOVRDET;
        private string strCHQRECON;
        private string strCHQRECDET;
        private string strPRCHG;
        private string strPRCHGDET;
        private string strREPSTBAL;
        private string strREPSTVAL;
        private string strREPSAL;
        private string strREPPUR;
        private string strREPGP;
        private string strREPANY;
        private string strSYSTL;
        private string strUSER;
        private string strJournal;
        private string strCostCodeText;

        private string strSqlStatement;
        private string strDataSetName;

        private SqlDataReader DataReader;
        private DataSet dsResultSet;
        private Boolean blRecordFound;

        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public decimal UserRole_Id
        {
            get { return decUserRole_Id; }
            set { decUserRole_Id = value; }
        }

        public string Acc_Desable
        {
            get { return strAcc_Desable; }
            set { strAcc_Desable = value; }
        }
        public string TransCan { get; set; }
        public string UserCannotChgPwd
        {
            get { return strUserCannotChgPwd; }
            set { strUserCannotChgPwd = value; }
        }

        public string ChgPwdNxtLogin
        {
            get { return strChgPwdNxtLogin; }
            set { strChgPwdNxtLogin = value; }
        }

        public string Loca
        {
            get { return strLoca; }
            set { strLoca = value; }
        }

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }

        public DataSet ResultSet
        {
            get { return dsResultSet; }
            set { dsResultSet = value; }
        }

        public string dsName
        {
            get { return strDataSetName; }
            set { strDataSetName = value; }
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

        public string UserRole_Description
        {
            get { return strUserRole_Description; }
            set { strUserRole_Description = value; }
        }

        public string MSTDT
        {
            get { return strMSTDT; }
            set { strMSTDT = value; }
        }

        public string MSTDTREP
        {
            get { return strMSTDTREP; }
            set { strMSTDTREP = value; }
        }

        public string LocaMaster
        {
            get { return strLocaMaster; }
            set { strLocaMaster = value; }
        }

        public string USER
        {
            get { return strUSER; }
            set { strUSER = value; }
        }

        public string TRAN
        {
            get { return strTRAN; }
            set { strTRAN = value; }
        }

        public string PUR
        {
            get { return strPUR; }
            set { strPUR = value; }
        }

        public string PUROR
        {
            get { return strPUROR; }
            set { strPUROR = value; }
        }

        public string PURORDET
        {
            get { return strPURORDET; }
            set { strPURORDET = value; }
        }

        public string GRN
        {
            get { return strGRN; }
            set { strGRN = value; }
        }

        public string GRNDET
        {
            get { return strGRNDET; }
            set { strGRNDET = value; }
        }

        public string SRN
        {
            get { return strSRN; }
            set { strSRN = value; }
        }

        public string SRNDET
        {
            get { return strSRNDET; }
            set { strSRNDET = value; }
        }

        public string TOG
        {
            get { return strTOG; }
            set { strTOG = value; }
        }

        public string TOGDET
        {
            get { return strTOGDET; }
            set { strTOGDET = value; }
        }

        public string SALE
        {
            get { return strSALE; }
            set { strSALE = value; }
        }

        public string WSALE
        {
            get { return strWSALE; }
            set { strWSALE = value; }
        }

        public string WSALEDET
        {
            get { return strWSALEDET; }
            set { strWSALEDET = value; }
        }

        public string CUSRET
        {
            get { return strCUSRET; }
            set { strCUSRET = value; }
        }

        public string CUSRETDET
        {
            get { return strCUSRETDET; }
            set { strCUSRETDET = value; }
        }

        public string PMT
        {
            get { return strPMT; }
            set { strPMT = value; }
        }

        public string PAYMENT
        {
            get { return strPAYMENT; }
            set { strPAYMENT = value; }
        }

        public string PMTDET
        {
            get { return strPMTDET; }
            set { strPMTDET = value; }
        }

        public string RECEIPT
        {
            get { return strRECEIPT; }
            set { strRECEIPT = value; }
        }

        public string RECDET
        {
            get { return strRECDET; }
            set { strRECDET = value; }
        }

        public string STAD
        {
            get { return strSTAD; }
            set { strSTAD = value; }
        }

        public string STADJ
        {
            get { return strSTADJ; }
            set { strSTADJ = value; }
        }

        public string STADDET
        {
            get { return strSTADDET; }
            set { strSTADDET = value; }
        }

        public string STOVER
        {
            get { return strSTOVER; }
            set { strSTOVER = value; }
        }

        public string STVRDET
        {
            get { return strSTOVRDET; }
            set { strSTOVRDET = value; }
        }

        public string REPSTBAL
        {
            get { return strREPSTBAL; }
            set { strREPSTBAL = value; }
        }

        public string REPSTVAL
        {
            get { return strREPSTVAL; }
            set { strREPSTVAL = value; }
        }

        public string REPSAL
        {
            get { return strREPSAL; }
            set { strREPSAL = value; }
        }

        public string REPPUR
        {
            get { return strREPPUR; }
            set { strREPPUR = value; }
        }

        public string REPGP
        {
            get { return strREPGP; }
            set { strREPGP = value; }
        }

        public string REPANY
        {
            get { return strREPANY; }
            set { strREPANY = value; }
        }

        public string CHQRECDET
        {
            get { return strCHQRECDET; }
            set { strCHQRECDET = value; }
        }

        public string CHQRECON
        {
            get { return strCHQRECON; }
            set { strCHQRECON = value; }
        }

        public string PRCHG
        {
            get { return strPRCHG; }
            set { strPRCHG = value; }
        }

        public string PRCHGDET
        {
            get { return strPRCHGDET; }
            set { strPRCHGDET = value; }
        }

        public string SYSTL
        {
            get { return strSYSTL; }
            set { strSYSTL = value; }
        }

        public string CostCodeText
        {
            get { return strCostCodeText; }
            set { strCostCodeText = value; }
        }

        public string Journal
        {
            get { return strJournal; }
            set { strJournal = value; }
        }

        private DateTime dtExpDate;
        public DateTime ExpDate
        {
            get { return dtExpDate; }
            set { dtExpDate = value; }
        }

        private string _FExpDate;
        public string FExpDate
        {
            get { return _FExpDate; }
            set { _FExpDate = value; }
        }

        private string _Cr;
        public string Cr
        {
            get { return _Cr; }
            set { _Cr = value; }
        }

        private string _Dr;
        public string Dr
        {
            get { return _Dr; }
            set { _Dr = value; }
        }


        private string _Profit;
        public string Profit
        {
            get { return _Profit; }
            set { _Profit = value; }
        }

        private string _SaleMoving;
        public string SaleMoving
        {
            get { return _SaleMoving; }
            set { _SaleMoving = value; }
        }

        private string _OrderLevel;
        public string OrderLevel
        {
            get { return _OrderLevel; }
            set { _OrderLevel = value; }
        }

        private string _Bin;
        public string Bin
        {
            get { return _Bin; }
            set { _Bin = value; }
        }

        private string _Cashier;
        public string Cashier
        {
            get { return _Cashier; }
            set { _Cashier = value; }
        }

        private string _StaticIpStock;
        public string StaticIpStock
        {
            get { return _StaticIpStock; }
            set { _StaticIpStock = value; }
        }

        private string _AllPriceShow;
        public string AllPriceShow
        {
            get { return _AllPriceShow; }
            set { _AllPriceShow = value; }
        }

        private string _CashFlow;
        public string CashFlow
        {
            get { return _CashFlow; }
            set { _CashFlow = value; }
        }
        private string _ROA;
        public string ROA
        {
            get { return _ROA; }
            set { _ROA = value; }
        }
        private string _ROADET;
        public string ROADET
        {
            get { return _ROADET; }
            set { _ROADET = value; }
        }
        private string _CDNM;
        public string CDNM
        {
            get { return _CDNM; }
            set { _CDNM = value; }
        }
        private string _CDNMDET;
        public string CDNMDET
        {
            get { return _CDNMDET; }
            set { _CDNMDET = value; }
        }




        # region //Select Dataset
        public void RetriveData()
        {
            dsResultSet = dbcon.getDataset(strSqlStatement, strDataSetName);
        }
        # endregion

        public void FExpDates()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                if (DataReader.Read())
                {
                    MessageBox.Show("Your account will be expired within next " + DataReader["EXPDate"].ToString() + " day(s)", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadUserName()
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadUserRoleID()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    decUserRole_Id = (decimal)DataReader["UserRole_Id"];
                    blRecordFound = true;
                }
                else
                {
                    decUserRole_Id = 0;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 002. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void CreateUser()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UserProfile";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Emp_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUserName));
                command.Parameters.Add(new SqlParameter("@Pass_Word", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPassword.ToUpper()));
                command.Parameters.Add(new SqlParameter("@Create_User", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));
                command.Parameters.Add(new SqlParameter("@UserRole_Id", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, decUserRole_Id));
                command.Parameters.Add(new SqlParameter("@Acc_Desable", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strAcc_Desable));
                command.Parameters.Add(new SqlParameter("@UserCannotChgPwd", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUserCannotChgPwd));
                command.Parameters.Add(new SqlParameter("@chgPwdNxtLogin", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strChgPwdNxtLogin));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@EXPDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ExpDate));
                command.Parameters.Add(new SqlParameter("@TransCan", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TransCan));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 003. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        //Change Password
        public void ChangePassword()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UserUpdate";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@Emp_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUserName));
                command.Parameters.Add(new SqlParameter("@Pass_Word", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPassword.ToUpper()));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 004. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadProfileDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);

                if (DataReader.Read())
                {
                    do
                    {
                        switch (DataReader["Option_Id"].ToString().Trim())
                        {
                            case "MSTDT":
                                strMSTDT = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "MSTDTREP":
                                strMSTDTREP = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "LOCA":
                                strLocaMaster = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "USER":
                                strUSER = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "TRAN":
                                strTRAN = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PUR":
                                strPUR = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PUROR":
                                strPUROR = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PURORDET":
                                strPURORDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "GRN":
                                strGRN = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "GRNDET":
                                strGRNDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SRN":
                                strSRN = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SRNDET":
                                strSRNDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "TOG":
                                strTOG = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "TOGDET":
                                strTOGDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SALE":
                                strSALE = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "WSALE":
                                strWSALE = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "WSALEDET":
                                strWSALEDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PMT":
                                strPMT = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PAYMENT":
                                strPAYMENT = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PMTDET":
                                strPMTDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "RECEIPT":
                                strRECEIPT = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "RECDET":
                                strRECDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "STADJ":
                                strSTADJ = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "STAD":
                                strSTAD = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "STOVER":
                                strSTOVER = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "STOVRDET":
                                strSTOVRDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "STADDET":
                                strSTADDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "REPSTBAL":
                                strREPSTBAL = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "REPSTVAL":
                                strREPSTVAL = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "REPSAL":
                                strREPSAL = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "REPPUR":
                                strREPPUR = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "REPGP":
                                strREPGP = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "REPANY":
                                strREPANY = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SYSTL":
                                strSYSTL = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CUSRET":
                                strCUSRET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CUSRETDET":
                                strCUSRETDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CHQRECON":
                                strCHQRECON = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CHQRECDET":
                                strCHQRECDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PRCHG":
                                strPRCHG = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CR":
                                _Cr = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "DR":
                                _Dr = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "PROF":
                                _Profit = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SLMOVE":
                                _SaleMoving = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "OLEVL":
                                _OrderLevel = DataReader["Allow_Option"].ToString().Trim();
                                break;

                            case "JOURNAL":
                                strJournal = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "LSSRD":
                                LocationReports = DataReader["Allow_Option"].ToString().Trim();
                                break;

                            case "GRNAPP":
                                GRNAPP = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "POAPP":
                                POAPP = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SRNAPP":
                                SRNAPP = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "TOGAPP":
                                TOGAPP = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "DECRPAS":
                                DebCreOpBalPassword = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CASHIER":
                                _Cashier = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "BIN":
                                _Bin = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "ALLPRSH":
                                _AllPriceShow = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "SIPSTOCK":
                                _StaticIpStock = DataReader["Allow_Option"].ToString().Trim();
                                break;

                            case "CASHFLOW":
                                _CashFlow = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "ROA":
                                _ROA = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "ROADET":
                                _ROADET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CDNM":
                                _CDNM = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            case "CDNMDET":
                                _CDNMDET = DataReader["Allow_Option"].ToString().Trim();
                                break;
                            default:
                                break;
                        }
                    } while (DataReader.Read());
                }
                else
                {
                    strMSTDT = "F";
                    strMSTDTREP = "F";
                    strLocaMaster = "F";
                    strUSER = "F";
                    strTRAN = "F";
                    strPUR = "F";
                    strPUROR = "F";
                    strPURORDET = "F";
                    strGRN = "F";
                    strGRNDET = "F";
                    strSRN = "F";
                    strSRNDET = "F";
                    strTOG = "F";
                    strTOGDET = "F";
                    strSALE = "F";
                    strWSALE = "F";
                    strWSALEDET = "F";
                    strPMT = "F";
                    strPAYMENT = "F";
                    strPMTDET = "F";
                    strRECEIPT = "F";
                    strRECDET = "F";
                    strSTADJ = "F";
                    strSTAD = "F";
                    strSTOVER = "F";
                    strSTOVRDET = "F";
                    strSTADDET = "F";
                    strREPSTBAL = "F";
                    strREPSTVAL = "F";
                    strREPSAL = "F";
                    strREPPUR = "F";
                    strREPGP = "F";
                    strREPANY = "F";
                    strSYSTL = "F";
                    strCUSRET = "F";
                    strCUSRETDET = "F";
                    strCHQRECON = "F";
                    strCHQRECDET = "F";
                    strPRCHG = "F";
                    strPRCHGDET = "F";
                    LocationReports = "F";
                    GRNAPP = "F";
                    SRNAPP = "F";
                    POAPP = "F";
                    TOGAPP = "F";
                    _Bin = "F";
                    _AllPriceShow = "F";
                    _StaticIpStock = "F";
                    _CashFlow = "F";
                    _ROA = "F";
                    _ROADET = "F";
                    _CDNMDET = "F";
                    _CDNM = "F";
                  
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void SaveUserRoleDetails()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UserRoleDetails";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, intErrCode));
                command.Parameters.Add(new SqlParameter("@UserRole_Description", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUserRole_Description));
                command.Parameters.Add(new SqlParameter("@MSTDT", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMSTDT.ToUpper()));
                command.Parameters.Add(new SqlParameter("@TRAN", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTRAN.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PUR", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPUR.ToUpper()));
                command.Parameters.Add(new SqlParameter("@SALE", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSALE.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PMT", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPMT.ToUpper()));
                command.Parameters.Add(new SqlParameter("@STADJ", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSTADJ.ToUpper()));
                command.Parameters.Add(new SqlParameter("@REPSTBAL", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strREPSTBAL.ToUpper()));
                command.Parameters.Add(new SqlParameter("@REPSTVAL", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strREPSTVAL.ToUpper()));
                command.Parameters.Add(new SqlParameter("@REPSAL", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strREPSAL.ToUpper()));
                command.Parameters.Add(new SqlParameter("@REPPUR", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strREPPUR.ToUpper()));
                command.Parameters.Add(new SqlParameter("@REPGP", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strREPGP.ToUpper()));
                command.Parameters.Add(new SqlParameter("@REPANY", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strREPANY.ToUpper()));
                command.Parameters.Add(new SqlParameter("@SYSTL", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSYSTL.ToUpper()));
                command.Parameters.Add(new SqlParameter("@USER", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUSER.ToUpper()));
                command.Parameters.Add(new SqlParameter("@MSTDTREP", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strMSTDTREP.ToUpper()));
                command.Parameters.Add(new SqlParameter("@LOCA", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strLocaMaster.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PUROR", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPUROR.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PURORDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPURORDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@GRN", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strGRN.ToUpper()));
                command.Parameters.Add(new SqlParameter("@GRNDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strGRNDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@SRN", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSRN.ToUpper()));
                command.Parameters.Add(new SqlParameter("@SRNDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSRNDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@TOG", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTOG.ToUpper()));
                command.Parameters.Add(new SqlParameter("@TOGDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strTOGDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@WSALE", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strWSALE.ToUpper()));
                {
                    command.Parameters.Add(new SqlParameter("@ALLPRSH", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _AllPriceShow.ToUpper()));
                    command.Parameters.Add(new SqlParameter("@SIPSTOCK", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _StaticIpStock.ToUpper()));
                }
                command.Parameters.Add(new SqlParameter("@WSALEDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strWSALEDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@CUSRET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCUSRET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@CUSRETDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCUSRETDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PAYMENT", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPAYMENT.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PMTDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPMTDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@RECEIPT", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRECEIPT.ToUpper()));
                command.Parameters.Add(new SqlParameter("@RECDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strRECDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@STAD", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSTAD.ToUpper()));
                command.Parameters.Add(new SqlParameter("@STOVER", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSTOVER.ToUpper()));
                command.Parameters.Add(new SqlParameter("@STOVRDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSTOVRDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@STADDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strSTADDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@CHQRECON", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCHQRECON.ToUpper()));
                command.Parameters.Add(new SqlParameter("@CHQRECDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strCHQRECDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@PRCHG", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPRCHG.ToUpper()));
                //command.Parameters.Add(new SqlParameter("@PRCHGDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strPRCHGDET.ToUpper()));
                command.Parameters.Add(new SqlParameter("@JOURNAL", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Journal.ToUpper()));
                command.Parameters.Add(new SqlParameter("@LSSRD", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LocationReports));
                command.Parameters.Add(new SqlParameter("@GRNAPP", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, GRNAPP));
                command.Parameters.Add(new SqlParameter("@POAPP", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, POAPP));
                command.Parameters.Add(new SqlParameter("@SRNAPP", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SRNAPP));
                command.Parameters.Add(new SqlParameter("@TOGAPP", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TOGAPP));
                command.Parameters.Add(new SqlParameter("@DebCreOpBalPassword", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DebCreOpBalPassword));
                command.Parameters.Add(new SqlParameter("@Create_User", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName.Trim().ToUpper()));

                command.Parameters.Add(new SqlParameter("@Cr", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _Cr.ToUpper()));
                command.Parameters.Add(new SqlParameter("@Dr", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Dr.ToUpper()));
                command.Parameters.Add(new SqlParameter("@Profit", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _Profit.ToUpper()));
                command.Parameters.Add(new SqlParameter("@SaleMoving", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _SaleMoving.ToUpper()));
                command.Parameters.Add(new SqlParameter("@OrLevl", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _OrderLevel.ToUpper()));
                command.Parameters.Add(new SqlParameter("@Bin", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Bin.ToUpper()));
                command.Parameters.Add(new SqlParameter("@Cashier", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Cashier));

                command.Parameters.Add(new SqlParameter("@CashFlow", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _CashFlow));
                command.Parameters.Add(new SqlParameter("@ROA", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _ROA));
                command.Parameters.Add(new SqlParameter("@ROADET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _ROADET));
                command.Parameters.Add(new SqlParameter("@CDNM", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _CDNM));
                command.Parameters.Add(new SqlParameter("@CDNMDET", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, _CDNMDET));

                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ErrorCode = (int)(command.Parameters["@Err_x"].Value);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void ReadUserDetails()
        {
            try
            {
                DataReader = dbcon.GetReader(strSqlStatement);
                blRecordFound = false;
                if (DataReader.Read())
                {
                    decUserRole_Id = (decimal)DataReader["UserRole_Id"];
                    strUserRole_Description = DataReader["UserRole_Description"].ToString().Trim();
                    strAcc_Desable = DataReader["Acc_Desable"].ToString().Trim();
                    strUserCannotChgPwd = DataReader["UserCannotChgPwd"].ToString().Trim();
                    dtExpDate = (DateTime)DataReader["ExpDate"];
                    Password = DataReader["Pass_Word"].ToString(); 
                    TransCan = DataReader["Trans_Cancel"].ToString();
                    blRecordFound = true;
                }
                else
                {
                    decUserRole_Id = 0;
                    strUserRole_Description = string.Empty;
                    strAcc_Desable = string.Empty;
                    strUserCannotChgPwd = string.Empty;
                    blRecordFound = false;
                    dtExpDate = DateTime.Now.AddDays(15);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 005. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void ReadCostCodeText()
        {
            try
            {
                DataReader = dbcon.GetReader("select * from tbCostCodeInfo");
                blRecordFound = false;
                if (DataReader.Read())
                {
                    strCostCodeText = DataReader["Cost_Code_Text"].ToString().Trim();
                    blRecordFound = true;
                }
                else
                {
                    strCostCodeText = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsUserProfile 006. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void DeleteEmployee()
        {
            try
            {
                intErrCode = 0;
                dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = LoginSys.dbocommTimeOut;
                command.Connection = dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_EmployeeDelete";
                command.Parameters.Clear();
                
                command.Parameters.Add(new SqlParameter("@Emp_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, strUserName));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                command.Parameters.Add(new SqlParameter("@ReturnMSG", SqlDbType.NVarChar, 1000, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@FocusCont", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@MsgTital", SqlDbType.NVarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ReturnMSG = (string)(command.Parameters["@ReturnMSG"].Value.ToString());
                FocusCont = (string)(command.Parameters["@FocusCont"].Value.ToString());
                MsgTital = (string)(command.Parameters["@MsgTital"].Value.ToString());

            }
            finally
            {
                dbcon.connection.Close();
                if (!string.IsNullOrEmpty(ReturnMSG))
                {
                    MessageBox.Show(ReturnMSG, MsgTital, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }
    }
}
