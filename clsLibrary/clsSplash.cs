using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DbConnection;
using System.IO;
namespace clsLibrary
{
    public class clsSplash
    {
        private string strReadServerName =string.Empty ;
        private string strReadDBName = string.Empty;
        private string strReadUserName = string.Empty;
        private string strReadPassword = string.Empty;
        private int dblReadCommTimeOut = 0;
        private string strExtLoca=string.Empty ;
        private string strExtLocaDescription=string.Empty;
        private string strExtUserName=string.Empty ;
        private string strExtPassword=string.Empty ;
        private string strReadLoca = string.Empty;

        public string ExtLoca
        {
            get { return strExtLoca; }
        }

        public string ExtLocaDescription
        {
            get { return strExtLocaDescription; }
        }

        public string ExtUserName
        {
            get { return strExtUserName; }
        }

        public string ExtPassword
        {
            get { return strExtPassword; }
        }

        public int checkCon()
        {
            if (dbcon.ConnFound == false)
            {
                this.GetDataBaseAuthontication();
                LoginSys.strInvServerName = strReadServerName;
                LoginSys.strInvDataBase = strReadDBName;
                LoginSys.strInvUserName = strReadUserName;
                LoginSys.strInvPassword = strReadPassword;
                LoginSys.dbocommTimeOut = dblReadCommTimeOut;
                LoginSys.backEndStatus = LoginManager.backEndStatus;
                LoginSys.baseURL = LoginManager.baseURL;

                dbcon.SetConnectionString(strReadServerName, strReadDBName, strReadUserName, strReadPassword);
                dbconApi.SetConnectionString(strReadServerName, strReadDBName, strReadUserName, strReadPassword);
                return dbcon.checkCon();
            }
            else
            {
                return dbcon.checkCon();
            }
        }

        public static void ApplicationReset()
        {
            try
            {
                dbcon.GetReader("SELECT Prod_Code FROM Product");
            }
            catch (Exception ex)
            {

            }
                      //dbcon.CloseConnection();

            //dbcon.SetConnectionString(LoginSys.strInvServerName,LoginSys.strInvDataBase, LoginSys.strInvUserName, LoginSys.strInvPassword);
            
        }

        public void GetDataBaseAuthontication()
        {
            try
            {
                //************************************************************************************
                //  Get Database Authontication From Text File in Inventory\bin\Auth.txt
                //************************************************************************************
                //FileStream fileStream = new FileStream(@"..\Auth.txt", FileMode.Open);
                StreamReader m_streamReader = File.OpenText(@"..\Auth.txt");
                string input = null;

                try
                {
                    while ((input = m_streamReader.ReadLine()) != null)
                    {
                        // read from file
                        //Set Server Name
                        if (input.Trim().Substring(0, 1) == "1")
                        {
                            strReadServerName = clsSecurity.Decrypt(input.Trim().Substring(2, input.Trim().Length - 2));
                            LoginManager.ServerName = strReadServerName;
                        }
                        //Set Database Name
                        if (input.Trim().Substring(0, 1) == "2")
                        {
                            strReadDBName = input.Trim().Substring(2, input.Trim().Length - 2);
                            LoginManager.DatabaseName = strReadDBName;
                        }
                        //Set User Name
                        if (input.Trim().Substring(0, 1) == "3")
                        {
                            strReadUserName = input.Trim().Substring(2, input.Trim().Length - 2);
                            LoginManager.User = strReadUserName;
                        }
                        //Set User Name
                        if (input.Trim().Substring(0, 1) == "4")
                        {
                            strReadPassword = clsSecurity.Decrypt(input.Trim().Substring(2, input.Trim().Length - 2));
                            LoginManager.Password = strReadPassword;    
                        }
                        if (input.Trim().Substring(0,1)=="5")
                        {
                            dblReadCommTimeOut = int.Parse(input.Trim().Substring(2, input.Trim().Length - 2));
                        }
                        //Set Extension Location 
                        if (input.Trim().Substring(0, 1) == "6")
                        {
                            strExtLoca = input.Trim().Substring(2, input.Trim().Length - 2);
                            LoginManager.ExtLoca = strExtLoca;
                        }
                        //Set Extension Location Description
                        if (input.Trim().Substring(0, 1) == "7")
                        {
                            strExtLocaDescription = input.Trim().Substring(2, input.Trim().Length - 2);
                            LoginManager.ExtLocaDescription = strExtLocaDescription;
                        }
                        //Set Extension Password 
                        if (input.Trim().Substring(0, 1) == "8")
                        {
                            strExtUserName = input.Trim().Substring(2, input.Trim().Length - 2);
                            LoginManager.ExtUserName = strExtUserName;
                        }
                        //Set Extension Password 
                        if (input.Trim().Substring(0, 1) == "9")
                        {
                            strExtPassword = input.Trim().Substring(2, input.Trim().Length - 2);
                            LoginManager.ExtPassword = strExtPassword;
                        }
                        if (input.Trim().Substring(0, 1) == "A")
                        {
                            LoginManager.ExtLoca2 = input.Trim().Substring(2, input.Trim().Length - 2);

                        }
                        if (input.Trim().Substring(0, 1) == "B")
                        {
                            LoginManager.ExtLocaDescription2= input.Trim().Substring(2, input.Trim().Length - 2);
                          
                        }
                        if (input.Trim().Substring(0, 1) == "C")
                        {
                            LoginManager.ExtUserName2 = input.Trim().Substring(2, input.Trim().Length - 2);
                        }
                        if (input.Trim().Substring(0, 1) == "D")
                        {
                            LoginManager.ExtPassword2 = input.Trim().Substring(2, input.Trim().Length - 2);
                        }
                        if (input.Trim().Substring(0, 1) == "E")
                        {
                            LoginManager.PrinterCom = input.Trim().Substring(2, input.Trim().Length - 2);
                        }
                        if (input.Trim().Substring(0, 1) == "F")
                        {
                            LoginManager.backEndStatus = input.Trim().Substring(2, input.Trim().Length - 2);
                        }
                        if (input.Trim().Substring(0, 1) == "G")
                        {
                            LoginManager.baseURL = input.Trim().Substring(2, input.Trim().Length - 2);
                        }
                        if (input.Trim().Substring(0, 1) == "H")
                        {
                           strReadLoca = input.Trim().Substring(2, input.Trim().Length - 2);
                           LoginManager.ReadLocaN = strReadLoca;
                        }
                        if (input.Trim().Substring(0, 1) == "I")
                        { 
                            LoginManager.TimeOut = LoginManager.StatTimeOut = Convert.ToInt32(input.Trim().Substring(2, input.Trim().Length - 2));
                        }
                        if (input.Trim().Substring(0, 1) == "J")
                        {
                             LoginManager.CustComPort = input.Trim().Substring(2, input.Trim().Length - 2);
                        }
                        Console.WriteLine(input);
                    }
                }
                finally
                {
                    m_streamReader.Close();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' clsSplash 002. Error Read On Auth.txt Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
