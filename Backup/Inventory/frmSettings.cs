using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Inventory.Properties;
using clsLibrary;

namespace Inventory
{
    public partial class frmSettings : Form
    {
        private static frmSettings Setting;

        public static frmSettings GetSettings
        {
            get { return Setting; }
            set { Setting = value; }
        }

        public frmSettings()
        {
            InitializeComponent();

        }
        clsCommon objclsSettings = new clsCommon();
        private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Setting = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnApply.Enabled == true)
                {
                    btnApply.PerformClick();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string CodeGen = "";
                if (rbCat.Checked)
                { CodeGen = "Cat"; }
                if (rbDept.Checked)
                { CodeGen = "Dep"; }
                if (rbprodwise.Checked)
                { CodeGen = "Pro"; }
                if (rbNon.Checked)
                { CodeGen = "Non"; }


                Settings.Default.ProdCodeLength = Convert.ToInt32(numProdCodeLen.Value);
                Settings.Default.NoOfTerminal = Convert.ToInt32(numTerminal.Value);
                Settings.Default.BackupPath = txtPath.Text.ToString();
                Settings.Default.Shinghala = Convert.ToBoolean(chkSinghala.Checked);
                Settings.Default.POCostEdit = Convert.ToBoolean(chkPOEditPurchase.Checked);
                Settings.Default.GRNCostEdit = Convert.ToBoolean(chkGRNEditPurchase.Checked);
                Settings.Default.GRNSellingEdit = Convert.ToBoolean(chkGRNEditSelling.Checked);
                Settings.Default.PRNCostEdit = Convert.ToBoolean(chkPRNEditPurchase.Checked);
                Settings.Default.PRNSellingEdit = Convert.ToBoolean(chkPRNEditSelling.Checked);
                Settings.Default.SRNCostEdit = Convert.ToBoolean(chkSRNEditPurchase.Checked);
                Settings.Default.SRNSellingEdit = Convert.ToBoolean(chkSRNEditSelling.Checked);
                Settings.Default.INVSellingEdit = Convert.ToBoolean(chkINVEditSellingPrice.Checked);
                Settings.Default.CURSellingEdit = Convert.ToBoolean(chkCUREditSellingPrice.Checked);
                Settings.Default.SIP_St_Show = Convert.ToBoolean(ChkStckShow.Checked);
                Settings.Default.StaticIp = txtStaticIp.Text.ToString();
                Settings.Default.DB_Name = txtDatabase.Text.ToString();
                Settings.Default.TrInCon = Convert.ToBoolean(chkInsertContinuesly.Checked);
                Settings.Default.InvAllowReduce = Convert.ToBoolean(chkInvAllowReduce.Checked);
                Settings.Default.GrnAllowReduce = Convert.ToBoolean(chkGRNAllowReduce.Checked);
                Settings.Default.RecAmtFirst = Convert.ToBoolean(chkRecAmtFirst.Checked);
                Settings.Default.InvLineDisc = Convert.ToBoolean(chkInvLineDisc.Checked);
                Settings.Default.InvSbttDisc_Manual = Convert.ToBoolean(chkInvSbtDisc_Manual.Checked);
                Settings.Default.CashDrawerOpen = Convert.ToBoolean(chkCashDrawerOpen.Checked);
                Settings.Default.VatPrecentage = decimal.Parse(txtVatItem.Text.ToString());
                Settings.Default.VatAllow = Convert.ToBoolean(chkTaxCustomer.Checked);
                Settings.Default.Margin = Convert.ToDecimal(txtMargin.Text);
                Settings.Default.ProdImage = Convert.ToBoolean(chkItemImage.Checked);
                Settings.Default.CRMMSg = Convert.ToBoolean(chkMsgSend.Checked);
                Settings.Default.AutoGenCustCode = Convert.ToBoolean(chkCusCodeAuto.Checked);
                Settings.Default.InvCashType = Convert.ToBoolean(chkCashbill.Checked);

                Settings.Default.ImageFromServer = Convert.ToBoolean(chkImageFile.Checked);
                Settings.Default.ImageFileServer = txtImageFilePath.Text.Trim();


                Settings.Default.CodeGen = CodeGen;
                Settings.Default.AllowCreditbill = chkAllowCredit.Checked;
                Settings.Default.CRM = chkCRM.Checked;
                Settings.Default.GIFT = chkGift.Checked;

                Settings.Default.OtherCharge = chkOtherCharge.Checked;
                Settings.Default.VatBill = chkVatBill.Checked;

                Settings.Default.Save();

                btnApply.Enabled = false;
                try
                {
                    string sqlStatement = @"DELETE FROM tb_Settings; INSERT INTO tb_Settings (CodeLength,CodeGenOrder,  NoOfTerminal,GRN_S,GRN_P,SRN_S,SRN_P,PO_S,BackupPath, PRN_S, PRN_P, Singhala, INV_S, CUR_S,  SIP_St_Show, StaticIp, DB_Name, TrInCon, InvAllowReduce, GrnAllowReduce , RecAmtFirst, InvLineDisc, InvSbttDisc_Manual, CashDrawerOpen,VatPrecentage,VatAllow,Margin,RptItemImage,CRMMSG,CodeGen,AutoGenCusCode,CashBill,ImageFromServer,ImageFileServer,creditBill,CRM,GIFT,OtherCharges,VatBill ) "
                    + "VALUES (" + numProdCodeLen.Value + ",1," + Convert.ToInt32(numTerminal.Value) + "," + Convert.ToInt16(chkGRNEditSelling.Checked) + "," + Convert.ToInt16(chkGRNEditPurchase.Checked) + "," + Convert.ToInt16(chkSRNEditSelling.Checked) + "," + Convert.ToInt16(chkSRNEditPurchase.Checked) + "," + Convert.ToInt16(chkPOEditPurchase.Checked) + ",'" + txtPath.Text.Trim() + "','" + Convert.ToInt16(chkPRNEditSelling.Checked) + "','" + Convert.ToInt16(chkPRNEditPurchase.Checked) + "','" + Convert.ToInt16(chkSinghala.Checked) + "', " + Convert.ToInt16(chkINVEditSellingPrice.Checked) + ", " + Convert.ToInt16(chkCUREditSellingPrice.Checked) + ", " + Convert.ToInt16(ChkStckShow.Checked) + ", '" + Settings.Default.StaticIp + "', '" + Settings.Default.DB_Name + "', " + Convert.ToInt16(chkInsertContinuesly.Checked) + ", " + Convert.ToInt16(chkInvAllowReduce.Checked) + "," + Convert.ToInt16(chkGRNAllowReduce.Checked) + ", " + Convert.ToInt16(chkRecAmtFirst.Checked) + ", " + Convert.ToInt16(chkInvLineDisc.Checked) + ", " + Convert.ToInt16(chkInvSbtDisc_Manual.Checked) + ", " + Convert.ToInt16(chkCashDrawerOpen.Checked) + " ," + decimal.Parse(txtVatItem.Text.Trim()) + "," + Convert.ToInt16(chkTaxCustomer.Checked) + " ," + Convert.ToDecimal(txtMargin.Text.Trim()) + ",'" + chkItemImage.Checked + "','" + chkMsgSend.Checked + "','" + CodeGen + "','" + chkCusCodeAuto.Checked + "','" + chkCashbill.Checked + "','" + chkImageFile.Checked + "','" + txtImageFilePath.Text + "','" + chkAllowCredit.Checked + "','" + chkCRM.Checked + "','" + chkGift.Checked + "','" + chkOtherCharge.Checked + "','" + chkVatBill.Checked + "')";
                    objclsSettings.getDataReader(sqlStatement);
                    objclsSettings.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            try
            {

                objclsSettings.getDataReader("SELECT CodeLength,CodeGenOrder, NoOfTerminal,GRN_S,GRN_P, SRN_P, SRN_S, PRN_S, PRN_P, PO_S, BackupPath, Singhala, INV_S, CUR_S,  SIP_St_Show, StaticIp, DB_Name,TrInCon, InvAllowReduce, GrnAllowReduce, RecAmtFirst, InvLineDisc, InvSbttDisc_Manual, CashDrawerOpen,VatAllow,VatPrecentage,Margin,RptItemImage,CRMMSg,CodeGen ,AutoGenCusCode,CashBill,ImageFromServer,ImageFileServer,CreditBill,CRM,GIFT,OtherCharges,vatbill  FROM tb_Settings");
                if (objclsSettings.Adr.Read())
                {
                    Settings.Default.ProdCodeLength = (int)objclsSettings.Adr["CodeLength"];
                     Settings.Default.NoOfTerminal = (int)objclsSettings.Adr["NoOfTerminal"];                   
                    Settings.Default.GRNSellingEdit = (bool)objclsSettings.Adr["GRN_S"];
                    Settings.Default.GRNCostEdit = (bool)objclsSettings.Adr["GRN_P"];
                    Settings.Default.SRNCostEdit = (bool)objclsSettings.Adr["SRN_P"];
                    Settings.Default.SRNSellingEdit = (bool)objclsSettings.Adr["SRN_S"];
                    Settings.Default.PRNSellingEdit = (bool)objclsSettings.Adr["PRN_S"];
                    Settings.Default.PRNCostEdit = (bool)objclsSettings.Adr["PRN_P"];
                    Settings.Default.POCostEdit = (bool)objclsSettings.Adr["PO_S"];
                    Settings.Default.BackupPath = objclsSettings.Adr["BackupPath"].ToString();
                    Settings.Default.Shinghala = (bool)objclsSettings.Adr["Singhala"];
                    Settings.Default.INVSellingEdit = (bool)objclsSettings.Adr["INV_S"];
                    Settings.Default.CURSellingEdit = (bool)objclsSettings.Adr["CUR_S"];
                    Settings.Default.SIP_St_Show = (bool)objclsSettings.Adr["SIP_St_Show"];
                    Settings.Default.StaticIp = objclsSettings.Adr["StaticIp"].ToString();
                    Settings.Default.DB_Name = objclsSettings.Adr["DB_Name"].ToString();
                    Settings.Default.TrInCon = (bool)objclsSettings.Adr["TrInCon"];
                    Settings.Default.InvAllowReduce = (bool)objclsSettings.Adr["InvAllowReduce"];
                    Settings.Default.GrnAllowReduce = (bool)objclsSettings.Adr["GrnAllowReduce"];
                    Settings.Default.RecAmtFirst = (bool)objclsSettings.Adr["RecAmtFirst"];
                    Settings.Default.InvLineDisc = (bool)objclsSettings.Adr["InvLineDisc"];
                    Settings.Default.InvSbttDisc_Manual = (bool)objclsSettings.Adr["InvSbttDisc_Manual"];
                    Settings.Default.CashDrawerOpen = (bool)objclsSettings.Adr["CashDrawerOpen"];
                    Settings.Default.VatPrecentage = (decimal)objclsSettings.Adr["VatPrecentage"];
                    Settings.Default.Margin = (decimal)objclsSettings.Adr["Margin"];
                    Settings.Default.VatAllow = (bool)objclsSettings.Adr["VatAllow"];
                    Settings.Default.ProdImage = (bool)objclsSettings.Adr["RptItemImage"];
                    Settings.Default.CRMMSg = (bool)objclsSettings.Adr["CRMMSg"];
                    Settings.Default.CodeGen = objclsSettings.Adr["CodeGen"].ToString();
                    Settings.Default.AutoGenCustCode = (bool)objclsSettings.Adr["AutoGenCusCode"];
                    Settings.Default.InvCashType = (bool)objclsSettings.Adr["CashBill"];
                    Settings.Default.ImageFromServer = (bool)objclsSettings.Adr["ImageFromServer"];
                    Settings.Default.ImageFileServer = objclsSettings.Adr["ImageFileServer"].ToString();

                    Settings.Default.AllowCreditbill = (bool)objclsSettings.Adr["CreditBill"];
                    Settings.Default.CRM = (bool)objclsSettings.Adr["CRM"];
                    Settings.Default.GIFT = (bool)objclsSettings.Adr["GIFT"];

                    Settings.Default.OtherCharge = (bool)objclsSettings.Adr["OtherCharges"];
                    Settings.Default.VatBill = (bool)objclsSettings.Adr["Vatbill"];


                    

                    
                    Settings.Default.Save();



                }
                numProdCodeLen.Value = Convert.ToDecimal(Settings.Default.ProdCodeLength);
                 numTerminal.Value = Convert.ToDecimal(Settings.Default.NoOfTerminal);
                chkSinghala.Checked = Settings.Default.Shinghala;
                txtPath.Text = Settings.Default.BackupPath.ToString();
                chkPOEditPurchase.Checked = Settings.Default.POCostEdit;
                chkGRNEditPurchase.Checked = Settings.Default.GRNCostEdit;
                chkGRNEditSelling.Checked = Settings.Default.GRNSellingEdit;
                chkPRNEditPurchase.Checked = Settings.Default.PRNCostEdit;
                chkPRNEditSelling.Checked = Settings.Default.PRNSellingEdit;
                chkSRNEditPurchase.Checked = Settings.Default.SRNCostEdit;
                chkSRNEditSelling.Checked = Settings.Default.SRNSellingEdit;
                chkINVEditSellingPrice.Checked = Settings.Default.INVSellingEdit;
                chkCUREditSellingPrice.Checked = Settings.Default.CURSellingEdit;
                ChkStckShow.Checked = Settings.Default.SIP_St_Show;
                txtStaticIp.Text = Settings.Default.StaticIp;
                txtDatabase.Text = Settings.Default.DB_Name;
                chkInsertContinuesly.Checked = Settings.Default.TrInCon;
                chkInvAllowReduce.Checked = Settings.Default.InvAllowReduce;
                chkGRNAllowReduce.Checked = Settings.Default.GrnAllowReduce;
                chkRecAmtFirst.Checked = Settings.Default.RecAmtFirst;
                chkInvLineDisc.Checked = Settings.Default.InvLineDisc;
                chkInvSbtDisc_Manual.Checked = Settings.Default.InvSbttDisc_Manual;
                chkCashDrawerOpen.Checked = Settings.Default.CashDrawerOpen;

                txtVatItem.Text = Settings.Default.VatPrecentage.ToString();
                chkTaxCustomer.Checked = Settings.Default.VatAllow;
                txtMargin.Text = Settings.Default.Margin.ToString("N2");
                chkItemImage.Checked = Settings.Default.ProdImage;
                chkMsgSend.Checked = Settings.Default.CRMMSg;
                chkCusCodeAuto.Checked = Settings.Default.AutoGenCustCode;
                chkCashbill.Checked = Settings.Default.InvCashType;
                chkImageFile.Checked = Settings.Default.ImageFromServer;
                txtImageFilePath.Text = Settings.Default.ImageFileServer;
                chkAllowCredit.Checked = Settings.Default.AllowCreditbill;
                chkCRM.Checked = Settings.Default.CRM;
                chkGift.Checked = Settings.Default.GIFT;
                chkOtherCharge.Checked = Settings.Default.OtherCharge;
                chkVatBill.Checked = Settings.Default.VatBill;


                if (Settings.Default.CodeGen=="Cat")
                {
                    rbCat.Checked = true;
                 }
                 if (Settings.Default.CodeGen == "Dep")
                 {
                     rbDept.Checked = true;
                 }
                 if (Settings.Default.CodeGen == "Pro")
                 {
                     rbprodwise.Checked = true;
                 }
                 if (Settings.Default.CodeGen == "Non")
                 {
                     rbNon.Checked = true;
                 }
              

                //cmbPosPrinters.Items.Clear();
                //cmbNorPrinters.Items.Clear();
                //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //{
                //    cmbPosPrinters.Items.Add(printer);
                //    cmbNorPrinters.Items.Add(printer);

                //}
                //cmbPosPrinters.Text = Settings.Default.PosPrinter;
                //cmbNorPrinters.Text = Settings.Default.NorPrinter;


                   string MachineName = System.Environment.MachineName.ToString();
                   txtDevName.Text = MachineName;
                   objclsSettings.getDataReader("SELECT AppCode ,PropertyCode ,ClientId ,ClientSecret,PosInterfaceCode ,InvAPI ,InvToken ,DeviceApi,DeviceApiCon FROM dbo.tb_DeviceSettings WHERE MacName='" + MachineName + "'");
                   if (objclsSettings.Adr.Read())
                   {
                       txtAppCode.Text = objclsSettings.Adr["AppCode"].ToString();
                       txtPropertCode.Text = objclsSettings.Adr["PropertyCode"].ToString();
                       txtClientid.Text = objclsSettings.Adr["ClientId"].ToString();
                       txtClientSecret.Text = objclsSettings.Adr["ClientSecret"].ToString();
                       txtPosIntId.Text = objclsSettings.Adr["PosInterfaceCode"].ToString();
                       txtInvoiceApi.Text = objclsSettings.Adr["InvAPI"].ToString();
                       txtInvToken.Text = objclsSettings.Adr["InvToken"].ToString();
                       txtDeviceApi.Text = objclsSettings.Adr["DeviceApi"].ToString();
                       txtDeviceApiCon.Text = objclsSettings.Adr["DeviceApiCon"].ToString();
                   }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.BackupPath = openDialog.FileName;
                txtPath.Text = Settings.Default.BackupPath.ToString();
            }
        }

        private void grpProduct_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpTerminal_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpBackupRestore_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpPO_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpGRN_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpSRN_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpPRN_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void grpINV_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void ChkStckShow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkStckShow.Checked)
                {
                    groupBox2.Enabled = true;
                }
                else
                {
                    groupBox2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void tabCommon_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void tabCUR_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void chkInsertContinuesly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabRec_Enter(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbNorPrinters.Text.Trim() != string.Empty)
            {
                string Query = "EXEC dbo.Printer_Save  @Mac = '" + LoginManager.MacAddress + "', @PrinterPos = '" + cmbPosPrinters.Text.Trim() + "',@PrinterNor = '" + cmbNorPrinters.Text.Trim() + "' ";

                objclsSettings.getDataReader(Query);

                Settings.Default.PosPrinter = cmbPosPrinters.Text.Trim();
                Settings.Default.NorPrinter = cmbNorPrinters.Text.Trim();
                Settings.Default.Save();
                MessageBox.Show("Save Success!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSaveDeviceDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string MachineName = System.Environment.MachineName.ToString();
                string Query = "EXEC dbo.Sp_SaveDeviceSettings  @MacName ='" + MachineName + "',@AppCode ='" + txtAppCode.Text.Trim() + "',@PropertyCode = '" + txtPropertCode.Text.Trim() + "',@ClientId = '" + txtClientid.Text.Trim() + "',@PosInterfaceCode = '" + txtPosIntId.Text.Trim() + "',@InvAPI = '" + txtInvoiceApi.Text.Trim() + "',@InvToken = '" + txtInvToken.Text.Trim() + "',@DeviceApi = '" + txtDeviceApi.Text.Trim() + "',@ClientSecret = '" + txtClientSecret.Text.Trim() + "',@DeviceApiCon = '" + txtDeviceApiCon.Text.Trim() + "' ";
                objclsSettings.getDataReader(Query);
                MessageBox.Show("Save Success!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                objclsSettings.closeConnection();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            clsInvApiUpload Obj = new clsInvApiUpload();
            Obj.UpdateInvToApi(true);
        }

        private void chkSinghala_CheckedChanged(object sender, EventArgs e)
        {

        }
         
        private void btnPath_Click_1(object sender, EventArgs e)
        {
          
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text  = folderBrowserDialog1.SelectedPath;
            }

        }
    }
}