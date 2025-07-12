using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace DbConnection
{

    public class clsCommonApi
    {
        

        public clsCommonApiResponse HttpGet(string BaseUrl, string Controller, string Action, NameValueCollection QueryStringParameters=null, string routeData="")
        {
            clsCommonApi objApi = new clsCommonApi();
            clsCommonApiRequest objRequest = new clsCommonApiRequest();
            clsCommonApiResponse objResponse = new clsCommonApiResponse();
           
            try
            {

                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                using (WebClient client = new WebClient())
                {
                    RetriveAuthenticateToken();
                    var url = BaseUrl + Controller + '/' + Action;
                    if (QueryStringParameters != null)
                    {
                        if (QueryStringParameters.Count > 0)
                        {
                            foreach (string parm in QueryStringParameters.AllKeys)
                                client.QueryString.Add(parm, QueryStringParameters[parm]);
                        }
                    }
                    if (routeData!="")
                    {
                        url = url + routeData;
                    }
                    client.Headers.Add("Authorization", "Bearer " + LoginSys.Token);
                    byte[] responseArray = client.DownloadData(url);
                    objResponse.objDynamicResult = Encoding.ASCII.GetString(responseArray);
                    var xx = client.ResponseHeaders;
                    string x = Encoding.ASCII.GetString(responseArray);

                    FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (responseField != null)
                    {
                        HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                        if (response != null)
                        {
                            objResponse.StatusCode = response.StatusDescription;
                            objResponse.StatusDescription = (int)response.StatusCode;
                        }
                    }

                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    objResponse.ErrResponse = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                }
                else if (ex != null)
                {
                    objResponse.ErrResponse = ex.Message;
                }

                throw ex;
            }
            return objResponse;
        }

        public clsCommonApiResponse HttpPost(string BaseUrl, string Data, string Controller, string Action)
        {
            clsCommonApiResponse objResponse = new clsCommonApiResponse();
            try
            {


                using (WebClient client = new WebClient())
                {
                    var json_serializer = new JavaScriptSerializer();

                    json_serializer.MaxJsonLength = Int32.MaxValue;
                    RetriveAuthenticateToken();
                    string url = BaseUrl + Controller + "/" + Action;
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", "Bearer "+ LoginSys.Token);
                    byte[] byteArray = Encoding.ASCII.GetBytes(Data);
                    byte[] responseArray = client.UploadData(url, "POST", byteArray);
                    objResponse.objDynamicResult = Encoding.ASCII.GetString(responseArray);

                    FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (responseField != null)
                    {
                        HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                        if (response != null)
                        {
                            objResponse.StatusCode = response.StatusDescription;
                            objResponse.StatusDescription = (int)response.StatusCode;
                        }
                    }

                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    objResponse.ErrResponse = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                }
                else if (ex != null)
                {
                    objResponse.ErrResponse = ex.Message;
                }

            }
            return objResponse;
        }

        public List<CommonParameters> convertSqlParaToCommonPara(SqlCommand command)
        {
            List<CommonParameters> retPara = new List<CommonParameters>();
            try
            {

                foreach (SqlParameter item in command.Parameters)
                {
                    CommonParameters cPara = new CommonParameters();
                    cPara.Para_Name = item.ParameterName;
                    cPara.Para_Type = item.SqlDbType.ToString();
                    cPara.Para_Direction = item.Direction.ToString();
                    cPara.Para_Data = item.Value;
                    cPara.Para_Lenth = item.Size;

                    retPara.Add(cPara);
                }
            }
            catch (Exception ex)
            {
                retPara.Clear();
                throw ex;
            }
            return retPara;
        }

        public SqlCommand convertCommonParaToSqlPara(List<CommonParameters> Paras)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                foreach (var x in Paras)
                {

                    string ParaName = x.Para_Name;
                    SqlDbType Paratype = (SqlDbType)Enum.Parse(typeof(SqlDbType), x.Para_Type.ToString(), true);
                    ParameterDirection ParaDirection = (ParameterDirection)Enum.Parse(typeof(ParameterDirection), x.Para_Direction.ToString(), true);
                    int ParaLenth = x.Para_Lenth;
                    object ParaValue = x.Para_Data;

                    SqlParameter p = new SqlParameter(ParaName, Paratype, ParaLenth, ParaDirection, false, 0, 0, "", DataRowVersion.Default, ParaValue);
                    cmd.Parameters.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cmd;
        }

        public string RetriveTokenFromServer()
        {
            try
            {
                if (LoginSys.UserName == null || LoginSys.Password == null || LoginSys.LocaCode==null)
                {
                    LoginSys.Token = "";
                    return "";
                }
                clsCommonApi objApi = new clsCommonApi();
                clsTokenRequest objRequest = new clsTokenRequest();

                objRequest.username = LoginSys.UserName;
                objRequest.password = LoginSys.Password;
                objRequest.loca = LoginSys.LocaCode;

                JavaScriptSerializer j = new JavaScriptSerializer();
                j.MaxJsonLength = Int32.MaxValue;
                string postData = j.Serialize(objRequest);

                clsTokenResponse objResponse = new clsTokenResponse();

                using (WebClient client = new WebClient())
                {
                    string url = LoginSys.baseURL + "Users/Authenticate";
                    client.Headers.Add("Content-Type", "application/json-patch+json");
                    byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                    byte[] responseArray = client.UploadData(url, "POST", byteArray);
                    objResponse = j.Deserialize<clsTokenResponse>(Encoding.ASCII.GetString(responseArray));

                    FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (responseField != null)
                    {
                        HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                        if (response != null && response.StatusDescription == "OK")
                        {
                            LoginSys.Token = objResponse.Token;
                            SetExpired(LoginSys.Token);
                           
                        }
                        else
                        {
                            LoginSys.Token = "";
                        }
                    }
                }
                return LoginSys.Token;
            }
            catch (Exception ex)
            {
                return "";
               
            }
        }

        public string RetriveAuthenticateToken()
        {
            try
            {
                if (LoginSys.Token == null || LoginSys.Token == "")
                {
                    return RetriveTokenFromServer();

                }
                else if (DateTime.Now > LoginSys.ApiExpirationTime)
                {
                    return RetriveTokenFromServer();
                }
                else
                {
                    return LoginSys.Token;
                }
            }
            catch (Exception ex)
            {
                return "";
                throw;

            }
        }

        public void SetExpired(String token)
        {
            if (token == null || ("").Equals(token))
            {
                LoginSys.ApiExpirationTime = DateTime.Now;
            }

            /***
             * Make string valid for FromBase64String
             * FromBase64String cannot accept '.' characters and only accepts stringth whose length is a multitude of 4
             * If the string doesn't have the correct length trailing padding '=' characters should be added.
             */
            int indexOfFirstPoint = token.IndexOf('.') + 1;
            String toDecode = token.Substring(indexOfFirstPoint, token.LastIndexOf('.') - indexOfFirstPoint);
            while (toDecode.Length % 4 != 0)
            {
                toDecode += '=';
            }

            //Decode the string
            string decodedString = Encoding.ASCII.GetString(Convert.FromBase64String(toDecode));

            JavaScriptSerializer j = new JavaScriptSerializer();
            j.MaxJsonLength = Int32.MaxValue;
            clsTokenDetails objResponse = new clsTokenDetails();
            objResponse = j.Deserialize<clsTokenDetails>(decodedString);

            int Expire = objResponse.exp;
           
            
            LoginSys.ApiExpirationTime=  DateTimeOffset.FromUnixTimeSeconds(Expire).DateTime;


        }


        string key = "1prt56";
        public string Encryptword(string Encryptval)
        {
            try
            {
                byte[] SrctArray;
                byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(Encryptval);
                SrctArray = UTF8Encoding.UTF8.GetBytes(key);
                TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
                SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                objcrpt.Clear();
                objt.Key = SrctArray;
                objt.Mode = CipherMode.ECB;
                objt.Padding = PaddingMode.PKCS7;
                ICryptoTransform crptotrns = objt.CreateEncryptor();
                byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);
                objt.Clear();
                return Convert.ToBase64String(resArray, 0, resArray.Length);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public string Decryptword(string DecryptText)
        {
            try
            {
                byte[] SrctArray;
                byte[] DrctArray = Convert.FromBase64String(DecryptText);
                SrctArray = UTF8Encoding.UTF8.GetBytes(key);
                TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();
                SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                objmdcript.Clear();
                objt.Key = SrctArray;
                objt.Mode = CipherMode.ECB;
                objt.Padding = PaddingMode.PKCS7;
                ICryptoTransform crptotrns = objt.CreateDecryptor();
                byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);
                objt.Clear();
                return UTF8Encoding.UTF8.GetString(resArray);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
