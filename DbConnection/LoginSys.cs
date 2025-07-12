using System;
using System.Collections.Generic;
using System.Text;

namespace DbConnection
{
    public class LoginSys
    {
        private static string InvServerName = string.Empty;
        private static string InvDataBase = string.Empty;
        private static string InvUserName = string.Empty;
        private static string InvPassword = string.Empty;
        private static int InvCommTimeOut = 0;

        public static int  dbocommTimeOut
        {
            get { return InvCommTimeOut; }
            set { InvCommTimeOut = value; }

        }
        public static string strInvServerName
        {
            get { return InvServerName; }
            set { InvServerName = value; }
        }
        public static string strInvDataBase
        {
            get { return InvDataBase; }
            set { InvDataBase = value; }
        }

        public static string strInvUserName
        {
            get { return InvUserName; }
            set { InvUserName = value; }
        }

        public static string strInvPassword
        {
            get { return InvPassword; }
            set { InvPassword = value; }
        }

        public static string backEndStatus { get; set; }
        public static string baseURL { get; set; }

        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string LocaCode { get; set; }
        public static string Token { get; set; }
        public static DateTime ApiExpirationTime { get; set; }
    }
}
