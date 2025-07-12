using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace clsLibrary
{
     public  class clsInvApiUpload
    {
         clsCommon ObjComman = new clsCommon();


         string Sqlst = "";
         public void UpdateInvToApi(bool ViewError)
         {


             try
             {
                 string Results = "";

                 try
                 {


                     ObjComman.SqlStatement = "EXEC dbo.Sp_GetInvUploadData  @Loca = '" + LoginManager.LocaCode + "',@MacName = '" + LoginManager.MachinName + "',@DocNo = ''";
                     ObjComman.GetDsApi();

                 }
                 catch (Exception Ex)
                 {
                     if (ViewError == true)
                     {
                         MessageBox.Show("Eror In Connection" + Ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }
                 }
                 DataSet Ds = new DataSet();
                 Ds = ObjComman.Ads;
                 if (Ds.Tables[1].Rows.Count == 0)
                 {
                     if (ViewError == true)
                     {
                         MessageBox.Show("NO Data To Upload", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     }
                     Ds = null;
                     return;
                 }
                

                 string ClientId = "";
                 string client_secret = "";
                 string AppCode = "";
                 string PropertyCode = "";
                 string POSInterfaceCode = "";
                 string BatchCode = "";
                 string API = "";
                 string ApiToken = "";


                 ClientId = ObjComman.Ads.Tables[0].Rows[0]["ClientID"].ToString();
                 client_secret = ObjComman.Ads.Tables[0].Rows[0]["ClientSecret"].ToString().Trim();
                 AppCode = ObjComman.Ads.Tables[0].Rows[0]["AppCode"].ToString();
                 PropertyCode = ObjComman.Ads.Tables[0].Rows[0]["PropertyCode"].ToString();
                 POSInterfaceCode = ObjComman.Ads.Tables[0].Rows[0]["POSInterfaceCode"].ToString();
                 BatchCode = ObjComman.Ads.Tables[0].Rows[0]["BatchCode"].ToString();
                 API = ObjComman.Ads.Tables[0].Rows[0]["InvApi"].ToString();
                 ApiToken = ObjComman.Ads.Tables[0].Rows[0]["InvToken"].ToString();


                 foreach (DataRow row in Ds.Tables[1].Rows)
                 {
                     clsApiSalesuploard objsalesup = new clsApiSalesuploard();

                     objsalesup.AppCode = AppCode;
                     objsalesup.PropertyCode = PropertyCode;
                     objsalesup.ClientID = ClientId;
                     objsalesup.ClientSecret = client_secret;
                     objsalesup.POSInterfaceCode = POSInterfaceCode;
                     objsalesup.BatchCode = BatchCode;

                     System.Threading.Thread.Sleep(Convert.ToInt32(2000));
                     ObjComman.SqlStatement = "EXEC GetBatchNo";
                     ObjComman.GetDs();
                     objsalesup.BatchCode = ObjComman.Ads.Tables[0].Rows[0][0].ToString();


                     objsalesup.PosSales = new List<InvData>();
                     InvData invda = new InvData();
                     invda.Items = new List<ItemCls>();
                     invda.PropertyCode = row["PropertyCode"].ToString();
                     invda.POSInterfaceCode = row["POSInterfaceCode"].ToString();
                     invda.ReceiptDate = row["ReceiptDate"].ToString();
                     invda.ReceiptTime = row["ReceiptTime"].ToString();
                     invda.ReceiptNo = row["ReceiptNo"].ToString();
                     invda.POSInterfaceCode = row["POSInterfaceCode"].ToString();
                     invda.NoOfItems = Convert.ToInt32(row["NoOfItems"].ToString());
                     invda.SalesCurrency = row["SalesCurrency"].ToString();
                     invda.TotalSalesAmtB4Tax = Convert.ToDecimal(row["TotalSalesAmtB4Tax"].ToString());
                     invda.TotalSalesAmtAfterTax = Convert.ToDecimal(row["TotalSalesAmtAfterTax"].ToString());
                     invda.SalesTaxRate = Convert.ToDecimal(row["SalesTaxRate"].ToString());
                     invda.ServiceChargeAmt = Convert.ToDecimal(row["ServiceChargeAmt"].ToString());
                     invda.PaymentAmt = Convert.ToDecimal(row["PaymentAmt"].ToString());
                     invda.PaymentCurrency = row["PaymentCurrency"].ToString();
                     invda.PaymentMethod = row["PaymentMethod"].ToString();
                     invda.SalesType = row["SalesType"].ToString();


                     string Docno = row["ReceiptNo"].ToString();

                     ObjComman.SqlStatement = "EXEC dbo.Sp_GetInvUploadData  @Loca = '" + LoginManager.LocaCode + "',@MacName = '" + LoginManager.MachinName + "',@DocNo = '" + Docno + "'";
                     ObjComman.GetDsApi();


                     DataSet Ds2 = new DataSet();
                     Ds2 = ObjComman.Ads;


                     foreach (DataRow row2 in Ds2.Tables[0].Rows)
                     {
                         ItemCls objitm = new ItemCls();
                         objitm.ItemDesc = row2["ItemDesc"].ToString();
                         objitm.ItemAmt = Convert.ToDecimal(row2["ItemAmt"].ToString());
                         objitm.ItemDiscoumtAmt = Convert.ToDecimal(row2["ItemDiscoumtAmt"].ToString());
                         invda.Items.Add(objitm);
                     }
                     Ds2 = null;


                     objsalesup.PosSales.Add(invda);

                     Results = JsonConvert.SerializeObject(objsalesup);
                     string Token = "";
                     using (WebClient client = new WebClient())
                     {

                         try
                         {
                             client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                             string postData = "grant_type=client_credentials&client_id=" + ClientId + "&client_secret=" + System.Web.HttpUtility.UrlEncode(client_secret) + "";
                             //string postData = "grant_type=client_credentials&client_id=CCB1-PS-19-00000023&client_secret=IhPk/ahiVOEeoDEEG8T+OQ==";
                             //postData = System.Web.HttpUtility.UrlEncode(postData);
                             byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                             string baseURL = ApiToken;

                             byte[] responseArray = client.UploadData(baseURL, "POST", byteArray);

                             string x = Encoding.ASCII.GetString(responseArray);

                             JavaScriptSerializer j = new JavaScriptSerializer();
                             clsApiResponse Data = j.Deserialize<clsApiResponse>(x);

                            
                             Token = Data.access_token;
                         }

                         catch (Exception Ex)
                         {
                             MessageBox.Show("Eror In Data Upload Check Network", "UPLOAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             return;

                             if (ViewError == true)
                             {
                                 MessageBox.Show("Eror In Connection" + Ex.ToString(), "TOKEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

                             }
                         }


                         sendData(Token, ClientId, client_secret, Results, API, Docno,ViewError);



                     }

                 }

                 Ds = null;
               
             }
             catch (Exception ex)
             {
                 clsClear.Err(ex.Message, ex.StackTrace);
                 if (ViewError == true)
                 {
                     MessageBox.Show("Eror In Connection" + HttpStatusCode.InternalServerError.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
                 }

             }
                       
         
         }

         public void sendData(string token, string ClientID, string client_secret, string Data, string ApiUrl, string DocNo, bool ViewError)
         {

             try
             {
                 string strAuth = "Bearer " + token;
                 using (WebClient client = new WebClient())
                 {
                     client.Headers.Add("Content-Type", "application/json");
                     client.Headers.Add("Authorization", strAuth);
                     string postData = Data;
                     byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                     string baseURL = ApiUrl;
                     byte[] responseArray = client.UploadData(baseURL, "POST", byteArray);
                     string x = Encoding.ASCII.GetString(responseArray);

                     JavaScriptSerializer j = new JavaScriptSerializer();
                     clsUploardResponse objupres = j.Deserialize<clsUploardResponse>(x);

                     clsClear.ApiRespomse(DocNo + " - " + x);

                     if (ViewError == true)
                     {
                         MessageBox.Show("Upload LAST", "UPLOAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     if (objupres.returnStatus == "SUCCESS")
                     {
                         ObjComman.SqlStatement = "UPDATE dbo.Transaction_Header SET UPloadApi=1 WHERE Loca='" + LoginManager.LocaCode + "' AND UnitName='" + LoginManager.MachinName + "' AND Doc_No='" + DocNo + "'";
                         ObjComman.GetDsApi();

                         if (ViewError == true)
                         {
                             MessageBox.Show("Upload Success", "UPLOAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                     }

                 }
             }
             catch (Exception ex)
             {
                 clsClear.Err(ex.Message, ex.StackTrace);
                 if (ViewError == true)
                 {
                     MessageBox.Show("Eror In Connection" + ex.ToString(), "UPLOAD", MessageBoxButtons.OK, MessageBoxIcon.Error);

                 }

             }
         }

    }
}
