using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DbConnection;

namespace clsLibrary
{
    public class clsPublic:clsValidation
    {
        private string _ReturnMSG;
        private string _FocusCont;
        private string _MsgTital;
        private string _AddNewCashier;        
        
        public string ReturnMSG
        {
            get { return _ReturnMSG; }
            set { _ReturnMSG = value; }
        }

        public string FocusCont
        {
            get { return _FocusCont; }
            set { _FocusCont = value; }
        }

        public string MsgTital
        {
            get { return _MsgTital; }
            set { _MsgTital = value; }
        }

        public string AddNewCashier
        {
            get { return _AddNewCashier; }
            set { _AddNewCashier = value; }
        }

        private string strLocationReports;
        public string LocationReports
        {
            get { return strLocationReports; }
            set { strLocationReports = value; }
        }

        private string strGRNAPP;
        public string GRNAPP
        {
            get { return strGRNAPP; }
            set { strGRNAPP = value; }
        }

        private string strPOAPP;
        public string POAPP
        {
            get { return strPOAPP; }
            set { strPOAPP = value; }
        }

        private string strSRNAPP;
        public string SRNAPP
        {
            get { return strSRNAPP; }
            set { strSRNAPP = value; }
        }

        private string strTOGAPP;
        public string TOGAPP
        {
            get { return strTOGAPP; }
            set { strTOGAPP = value; }
        }

        private string strDebCreOpBalPassword;
        public string DebCreOpBalPassword
        {
            get { return strDebCreOpBalPassword; }
            set { strDebCreOpBalPassword = value; }
        }

        private string strAuthonticateUser;
        public string AuthonticateUser
        {
            get { return strAuthonticateUser; }
            set { strAuthonticateUser = value; }
        }

        private string strAuthonticatePassword;
        public string AuthonticatePassword
        {
            get { return strAuthonticatePassword; }
            set { strAuthonticatePassword = value; }
        }

       


        private bool _AccessStatus;
        public bool AccessStatus
        {
            get { return _AccessStatus; }
            set { _AccessStatus = value; }
        }

        private SqlDataReader DataReader;

        public void CheckedPasswordValid(string query)
        {
            try
            {
                DataReader = dbcon.GetReader(query);
                _AccessStatus = false;
                if (DataReader.Read())
                {
                    strAuthonticateUser = DataReader["Emp_Name"].ToString();
                    strAuthonticatePassword = DataReader["Pass_Word"].ToString();
                    _AccessStatus = true;
                }
                else
                {
                    strAuthonticateUser = strAuthonticatePassword = string.Empty;
                    _AccessStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }


    }
}
