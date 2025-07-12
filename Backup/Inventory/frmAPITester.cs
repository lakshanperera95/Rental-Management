using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using clsLibrary;
using System.Net;
using Newtonsoft.Json;

namespace Inventory
{
    public partial class frmAPITester : Form
    {
        public frmAPITester()
        {
            InitializeComponent();
        }

        clsCommon ObjComman = new clsCommon();
        private static frmAPITester _getApiTester;
        public static frmAPITester GetApiTester
        {
            get { return _getApiTester; }
            set { _getApiTester = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Results = "";


                ObjComman.SqlStatement = "EXEC dbo.Sp_GetInvUploadData  @Loca = '" + LoginManager.LocaCode + "',@MacName = 'DEV-OP-05',@DocNo = ''";
                ObjComman.GetDs();

                DataSet Ds = new DataSet();

                Ds = ObjComman.Ads;

                string ClientId = "";
                string client_secrettkn = "";
                string client_secret = "";
                string AppCode = "";
                string PropertyCode = "";
                string POSInterfaceCode = "";
                string BatchCode = "";
                string API = "";
                string Token = "";


                ClientId = ObjComman.Ads.Tables[0].Rows[0]["ClientID"].ToString();
                client_secret = ObjComman.Ads.Tables[0].Rows[0]["ClientSecret"].ToString().Trim();
                client_secrettkn = ObjComman.Ads.Tables[0].Rows[0]["ClientSecrettkn"].ToString().Trim();
                AppCode = ObjComman.Ads.Tables[0].Rows[0]["AppCode"].ToString();
                PropertyCode = ObjComman.Ads.Tables[0].Rows[0]["PropertyCode"].ToString();
                POSInterfaceCode = ObjComman.Ads.Tables[0].Rows[0]["POSInterfaceCode"].ToString();
                BatchCode = ObjComman.Ads.Tables[0].Rows[0]["BatchCode"].ToString();
                API = ObjComman.Ads.Tables[0].Rows[0]["InvApi"].ToString();
                Token = ObjComman.Ads.Tables[0].Rows[0]["InvToken"].ToString();


                foreach (DataRow row in Ds.Tables[1].Rows)
                {
                    clsApiSalesuploard objsalesup = new clsApiSalesuploard();

                    objsalesup.AppCode = AppCode;
                    objsalesup.PropertyCode = PropertyCode;
                    objsalesup.ClientID = ClientId;
                    objsalesup.ClientSecret = client_secret;
                    objsalesup.POSInterfaceCode = POSInterfaceCode;
                    objsalesup.BatchCode = BatchCode;
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

                    ObjComman.SqlStatement = "EXEC dbo.Sp_GetInvUploadData  @Loca = '" + LoginManager.LocaCode + "',@MacName = 'DEV-OP-05',@DocNo = '" + Docno + "'";
                    ObjComman.GetDs();


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



                    objsalesup.PosSales.Add(invda);

                    Results = JsonConvert.SerializeObject(objsalesup);

                    using (WebClient client = new WebClient())
                    {


                        //client.Headers.Add("Authorization", "Bearer " + Settings.Default.ApiAccessToken + "");

                        client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        string postData = "grant_type=client_credentials&client_id=" + ClientId + "&client_secret=" + client_secrettkn + "";
                        //@"{""Loca"":" + ((char)34) + LoginManager.LocaCode + ((char)34) + "," + ((char)34) + "TempDocNo" + ((char)34) + ":" + ((char)34) + TempDocNo + ((char)34) + "," + ((char)34) + "Iid" + ((char)34) + ":" + ((char)34) + Iid + ((char)34) + "," + ((char)34) + "PostDate" + ((char)34) + ":" + ((char)34) + PostDate + ((char)34) + "," + ((char)34) + "SuppCode" + ((char)34) + ":" + ((char)34) + SuppCode + ((char)34) + "," + ((char)34) + "UserName" + ((char)34) + ":" + ((char)34) + LoginManager.UserName + ((char)34) + "}";

                        byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                        string baseURL = Token;

                        byte[] responseArray = client.UploadData(baseURL, "POST", byteArray);

                        string x = Encoding.ASCII.GetString(responseArray);

                        JavaScriptSerializer j = new JavaScriptSerializer();
                        clsApiResponse Data = j.Deserialize<clsApiResponse>(x);

                        string Tokenn = Data.access_token;



                        sendData(Tokenn, ClientId, client_secret, Results, API, Docno);



                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Eror In Connection" + HttpStatusCode.InternalServerError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
                       

        }

        public void sendData(string token, string ClientID, string client_secret,string Data,string ApiUrl,string DocNo)
        {

            string strAuth="Bearer "+token;
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

                if (objupres.returnStatus == "SUCCESS")
                {
                    ObjComman.SqlStatement = "UPDATE dbo.Transaction_Header SET UPloadApi=1 WHERE Loca='"+LoginManager.LocaCode+"' AND UnitName='"+LoginManager.MachinName+"' AND Doc_No='"+DocNo+"'";
                    ObjComman.GetDs();
                } 

            }
        
        }

        private void frmAPITester_FormClosing(object sender, FormClosingEventArgs e)
        {
            GetApiTester = null;
        }
    }
}