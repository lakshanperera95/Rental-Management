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
                Settings.Default.InvFocusToBatch = Convert.ToBoolean(chkFocusToBatch.Checked);
                Settings.Default.ImageFromServer = Convert.ToBoolean(chkImageFile.Checked);
                Settings.Default.ImageFileServer = txtImageFilePath.Text.Trim();
                Settings.Default.InvRemarkText = txtInvRemarkText.Text.Trim();
                Settings.Default.SerialNo = Convert.ToBoolean(chkSerialAuto.Checked);
                Settings.Default.InvFullScrn = Convert.ToBoolean(chkINVFulScrn.Checked);
                Settings.Default.MinimumPrice = Convert.ToBoolean(chkMinimumPrice.Checked);
                Settings.Default.PurchasePrice = Convert.ToBoolean(chkShowPurchasePrice.Checked);
                Settings.Default.SingleBatch = Convert.ToBoolean(chkSingleBatch.Checked);


                Settings.Default.CodeGen = CodeGen;
                Settings.Default.AllowCreditbill = chkAllowCredit.Checked;
                Settings.Default.CRM = chkCRM.Checked;
                Settings.Default.GIFT = chkGift.Checked;

                Settings.Default.OtherCharge = chkOtherCharge.Checked;
                Settings.Default.VatBill = chkVatBill.Checked;

                Settings.Default.Expenses = chkExpenses.Checked;
                Settings.Default.SuppPayments = chkSuppPay.Checked;
                Settings.Default.InternalTransactions = chkInterTransactions.Checked;
                Settings.Default.AdvanceUserSet = chkAdvancUseer.Checked;
                Settings.Default.InvMultiLan = chkMultiLan.Checked;
                Settings.Default.InvLan = cmbPrintType.Text;
                Settings.Default.SaleDateEna = chkSaleDtEna.Checked;
                Settings.Default.ProdMargine = chkMargine.Checked;
                Settings.Default.ATGN = chkAtgn.Checked;
                Settings.Default.MultiCus = chkMultiCus.Checked;
                Settings.Default.OgfSys = chkOgfSys.Checked;
                Settings.Default.ShowTechnician = chkShowTechnicians.Checked;
                Settings.Default.TaxSys = chkTaxSys.Checked;
                Settings.Default.ShowBookings = chkShowBookings.Checked;
                Settings.Default.Person = txt3rdPartyPerson.Text;

                Settings.Default.ShowLoginRep = chkShowRepOnLog.Checked;
                Settings.Default.LoadInvDisc = chkLoadDisc.Checked;
                Settings.Default.InvGridFonts = (Int32)nmInvGridFSize.Value;
                Settings.Default.LastPriceName = txtLastPriceName.Text;
                Settings.Default.NewInvSrchMode = chkNSrchMode.Checked;
                Settings.Default.SerialAllow = chkSerialAllow.Checked;
               

                Settings.Default.PosBilling = chkPosBillings.Checked;
                Settings.Default.InvType = chkinvtypeallow.Checked;

                Settings.Default.Save();

                btnApply.Enabled = false;
                try
                {
                    string sqlStatement = @"DELETE FROM tb_Settings; INSERT INTO tb_Settings (CodeLength,CodeGenOrder,  NoOfTerminal,GRN_S,GRN_P,SRN_S,SRN_P,PO_S,BackupPath, PRN_S, PRN_P, Singhala, INV_S, CUR_S,  SIP_St_Show, StaticIp, DB_Name, TrInCon, InvAllowReduce, GrnAllowReduce , RecAmtFirst, InvLineDisc, InvSbttDisc_Manual, CashDrawerOpen,VatPrecentage,VatAllow,Margin,RptItemImage,CRMMSG,CodeGen,AutoGenCusCode,CashBill,ImageFromServer,ImageFileServer,creditBill,CRM,GIFT,OtherCharges,VatBill,Expenses,SupplierPayments,InternalTransactions,AdvanceUser,SingleBatch,InvMultiLan,InvPrintLan,SaleDateEn,ProdMargine,ATGN,MultiCus,InvFocusBatch,OgfSys,ShowTechnician,TaxSys,InvRemarkText,ShowBookings,Person,LoadInvDisc,ShowLoginRep,SerialNo,InvFullScrn,InvGridFont,MinimumPrice,ShowPurchasePrice,LastPriceName,NewInvSrchMode,SerialAllow,PosBilling,InvType) "
                    + "VALUES (" + numProdCodeLen.Value + ",1," + Convert.ToInt32(numTerminal.Value) + "," + Convert.ToInt16(chkGRNEditSelling.Checked) + "," + Convert.ToInt16(chkGRNEditPurchase.Checked) + "," + Convert.ToInt16(chkSRNEditSelling.Checked) + "," + Convert.ToInt16(chkSRNEditPurchase.Checked) + "," + Convert.ToInt16(chkPOEditPurchase.Checked) + ",'" + txtPath.Text.Trim() + "','" + Convert.ToInt16(chkPRNEditSelling.Checked) + "','" + Convert.ToInt16(chkPRNEditPurchase.Checked) + "','" + Convert.ToInt16(chkSinghala.Checked) + "', " + Convert.ToInt16(chkINVEditSellingPrice.Checked) + ", " + Convert.ToInt16(chkCUREditSellingPrice.Checked) + ", " + Convert.ToInt16(ChkStckShow.Checked) + ", '" + Settings.Default.StaticIp + "', '" + Settings.Default.DB_Name + "', " + Convert.ToInt16(chkInsertContinuesly.Checked) + ", " + Convert.ToInt16(chkInvAllowReduce.Checked) + "," + Convert.ToInt16(chkGRNAllowReduce.Checked) + ", " + Convert.ToInt16(chkRecAmtFirst.Checked) + ", " + Convert.ToInt16(chkInvLineDisc.Checked) + ", " + Convert.ToInt16(chkInvSbtDisc_Manual.Checked) + ", " + Convert.ToInt16(chkCashDrawerOpen.Checked) + " ," + decimal.Parse(txtVatItem.Text.Trim()) + "," + Convert.ToInt16(chkTaxCustomer.Checked) + " ," + Convert.ToDecimal(txtMargin.Text.Trim()) + ",'" + chkItemImage.Checked + "','" + chkMsgSend.Checked + "','" + CodeGen + "','" + chkCusCodeAuto.Checked + "','" + chkCashbill.Checked + "','" + chkImageFile.Checked + "','" + txtImageFilePath.Text + "','" + chkAllowCredit.Checked + "','" + chkCRM.Checked + "','" + chkGift.Checked + "','" + chkOtherCharge.Checked + "','" + chkVatBill.Checked + "','"+chkExpenses.Checked+"','"+chkSuppPay.Checked+ "','" + chkInterTransactions.Checked + "','"+chkAdvancUseer.Checked+"','"+chkSingleBatch.Checked+"','"+chkMultiLan.Checked+"','"+cmbPrintType.Text+"','"+chkSaleDtEna.Checked+"','"+chkMargine.Checked+ "','"+chkAtgn.Checked+"', '"+chkMultiCus.Checked+ "', '" + chkFocusToBatch.Checked + "', '" + chkOgfSys.Checked + "', '" + chkShowTechnicians.Checked + "', '" + chkTaxSys.Checked + "','"+txtInvRemarkText.Text+"','"+chkShowBookings.Checked+ "','" + txt3rdPartyPerson.Text + "','"+chkLoadDisc.Checked+"','"+chkShowRepOnLog.Checked+"','"+chkSerialAuto.Checked+ "','" + chkINVFulScrn.Checked + "','" + nmInvGridFSize.Value + "'/*,'" + nmInvGridFSize.Value + "'*/,'"+Convert.ToBoolean(chkMinimumPrice.Checked)+"','"+Convert.ToBoolean(chkShowPurchasePrice.Checked)+"','"+txtLastPriceName.Text.Trim()+ "','" + chkNSrchMode.Checked + "','" + chkSerialAllow.Checked + "','"+chkPosBillings.Checked+ "','" + chkinvtypeallow.Checked + "' )";
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

        public void frmSettings_Load(object sender, EventArgs e)
        {
            try
            {

                objclsSettings.getDataReader("SELECT CodeLength,CodeGenOrder, NoOfTerminal,GRN_S,GRN_P, SRN_P, SRN_S, PRN_S, PRN_P, PO_S, BackupPath, Singhala, INV_S, CUR_S,  SIP_St_Show, StaticIp, DB_Name,TrInCon, InvAllowReduce, GrnAllowReduce, RecAmtFirst, InvLineDisc, InvSbttDisc_Manual, CashDrawerOpen,VatAllow,VatPrecentage,Margin,RptItemImage,CRMMSg,CodeGen ,AutoGenCusCode,CashBill,ImageFromServer,ImageFileServer,CreditBill,CRM,GIFT,OtherCharges,vatbill,Expenses,SupplierPayments,InternalTransactions,SingleBatch,AdvanceUser,InvMultiLan,InvPrintLan,SaleDateEn,ProdMargine,ATGN,MultiCus,InvFocusBatch,OgfSys,ShowTechnician,TaxSys,InvRemarkText,ShowBookings,Person,ShowLoginRep,LoadInvDisc,SerialNo,InvFullScrn,InvGridFont,MinimumPrice,ShowPurchasePrice,LastPriceName,NewInvSrchMode,SerialAllow,PosBilling,InvType FROM tb_Settings");
                if (objclsSettings.Adr.Read())
                {
                    Settings.Default.ProdCodeLength = Convert.ToInt32(objclsSettings.Adr["CodeLength"]);
                    Settings.Default.NoOfTerminal =  Convert.ToInt32(objclsSettings.Adr["NoOfTerminal"]);
                    Settings.Default.GRNSellingEdit = Convert.ToBoolean(objclsSettings.Adr["GRN_S"]);
                    Settings.Default.GRNCostEdit = Convert.ToBoolean(objclsSettings.Adr["GRN_P"]);
                    Settings.Default.SRNCostEdit = Convert.ToBoolean(objclsSettings.Adr["SRN_P"]);
                    Settings.Default.SRNSellingEdit = Convert.ToBoolean(objclsSettings.Adr["SRN_S"]);
                    Settings.Default.PRNSellingEdit = Convert.ToBoolean(objclsSettings.Adr["PRN_S"]);
                    Settings.Default.PRNCostEdit = Convert.ToBoolean(objclsSettings.Adr["PRN_P"]);
                    Settings.Default.POCostEdit = Convert.ToBoolean(objclsSettings.Adr["PO_S"]);
                    Settings.Default.BackupPath = objclsSettings.Adr["BackupPath"].ToString();
                    Settings.Default.Shinghala = Convert.ToBoolean(objclsSettings.Adr["Singhala"]);
                    Settings.Default.INVSellingEdit = Convert.ToBoolean(objclsSettings.Adr["INV_S"]);
                    Settings.Default.CURSellingEdit = Convert.ToBoolean(objclsSettings.Adr["CUR_S"]);
                    Settings.Default.SIP_St_Show = Convert.ToBoolean(objclsSettings.Adr["SIP_St_Show"]);
                    Settings.Default.StaticIp = objclsSettings.Adr["StaticIp"].ToString();
                    Settings.Default.DB_Name = objclsSettings.Adr["DB_Name"].ToString();
                    Settings.Default.TrInCon = Convert.ToBoolean(objclsSettings.Adr["TrInCon"]);
                    Settings.Default.InvAllowReduce = Convert.ToBoolean(objclsSettings.Adr["InvAllowReduce"]);
                    Settings.Default.GrnAllowReduce = Convert.ToBoolean(objclsSettings.Adr["GrnAllowReduce"]);
                    Settings.Default.RecAmtFirst = Convert.ToBoolean(objclsSettings.Adr["RecAmtFirst"]);
                    Settings.Default.InvLineDisc = Convert.ToBoolean(objclsSettings.Adr["InvLineDisc"]);
                    Settings.Default.InvSbttDisc_Manual = Convert.ToBoolean(objclsSettings.Adr["InvSbttDisc_Manual"]);
                    Settings.Default.CashDrawerOpen = Convert.ToBoolean(objclsSettings.Adr["CashDrawerOpen"]);
                    Settings.Default.VatPrecentage = Convert.ToDecimal(objclsSettings.Adr["VatPrecentage"]);
                    Settings.Default.Margin = Convert.ToDecimal(objclsSettings.Adr["Margin"]);
                    Settings.Default.VatAllow = Convert.ToBoolean(objclsSettings.Adr["VatAllow"]);
                    Settings.Default.ProdImage = Convert.ToBoolean(objclsSettings.Adr["RptItemImage"]);
                    Settings.Default.CRMMSg = Convert.ToBoolean(objclsSettings.Adr["CRMMSg"]);
                    Settings.Default.CodeGen = objclsSettings.Adr["CodeGen"].ToString();
                    Settings.Default.AutoGenCustCode = Convert.ToBoolean(objclsSettings.Adr["AutoGenCusCode"]);
                    Settings.Default.InvCashType = Convert.ToBoolean(objclsSettings.Adr["CashBill"]);
                    Settings.Default.ImageFromServer = Convert.ToBoolean(objclsSettings.Adr["ImageFromServer"]);
                    Settings.Default.ImageFileServer = objclsSettings.Adr["ImageFileServer"].ToString();
                    Settings.Default.InvRemarkText = objclsSettings.Adr["InvRemarkText"].ToString();

                    Settings.Default.AllowCreditbill = Convert.ToBoolean(objclsSettings.Adr["CreditBill"]);
                    Settings.Default.CRM = Convert.ToBoolean(objclsSettings.Adr["CRM"]);
                    Settings.Default.GIFT = Convert.ToBoolean(objclsSettings.Adr["GIFT"]);

                    Settings.Default.OtherCharge = Convert.ToBoolean(objclsSettings.Adr["OtherCharges"]);
                    Settings.Default.VatBill = Convert.ToBoolean(objclsSettings.Adr["Vatbill"]);

                    Settings.Default.Expenses = Convert.ToBoolean(objclsSettings.Adr["Expenses"]);
                    Settings.Default.SuppPayments = Convert.ToBoolean(objclsSettings.Adr["SupplierPayments"]);
                    Settings.Default.InternalTransactions = Convert.ToBoolean(objclsSettings.Adr["InternalTransactions"]);
                    Settings.Default.AdvanceUserSet = Convert.ToBoolean(objclsSettings.Adr["AdvanceUser"]);
                    Settings.Default.InvMultiLan = Convert.ToBoolean(objclsSettings.Adr["InvMultiLan"]);
                    Settings.Default.InvLan = objclsSettings.Adr["InvPrintLan"].ToString();
                    Settings.Default.SaleDateEna = Convert.ToBoolean(objclsSettings.Adr["SaleDateEn"]);
                    Settings.Default.ProdMargine = Convert.ToBoolean(objclsSettings.Adr["ProdMargine"]);
                    Settings.Default.ATGN = Convert.ToBoolean(objclsSettings.Adr["ATGN"]);
                    Settings.Default.MultiCus = Convert.ToBoolean(objclsSettings.Adr["MultiCus"]);
                    Settings.Default.InvFocusToBatch = Convert.ToBoolean(objclsSettings.Adr["InvFocusBatch"]);
                    Settings.Default.OgfSys = Convert.ToBoolean(objclsSettings.Adr["OgfSys"]);
                    Settings.Default.ShowTechnician = Convert.ToBoolean(objclsSettings.Adr["ShowTechnician"]);
                    Settings.Default.TaxSys = Convert.ToBoolean(objclsSettings.Adr["TaxSys"]);
                    Settings.Default.ShowBookings = Convert.ToBoolean(objclsSettings.Adr["ShowBookings"]);
                    Settings.Default.Person = objclsSettings.Adr["Person"].ToString();
                    Settings.Default.ShowLoginRep = Convert.ToBoolean(objclsSettings.Adr["ShowLoginRep"]);
                    Settings.Default.LoadInvDisc = Convert.ToBoolean(objclsSettings.Adr["LoadInvDisc"]);
                    Settings.Default.SerialNo = Convert.ToBoolean(objclsSettings.Adr["SerialNo"]);
                    Settings.Default.InvFullScrn = Convert.ToBoolean(objclsSettings.Adr["InvFullScrn"]);
                    Settings.Default.InvGridFonts = Convert.ToInt32(objclsSettings.Adr["InvGridFont"]);
                    Settings.Default.MinimumPrice = Convert.ToBoolean(objclsSettings.Adr["MinimumPrice"]);
                    Settings.Default.PurchasePrice = Convert.ToBoolean(objclsSettings.Adr["ShowPurchasePrice"]);
                    Settings.Default.SingleBatch = Convert.ToBoolean(objclsSettings.Adr["SingleBatch"]);
                    Settings.Default.LastPriceName = objclsSettings.Adr["LastPriceName"].ToString();
                    Settings.Default.NewInvSrchMode = Convert.ToBoolean(objclsSettings.Adr["NewInvSrchMode"]);
                    Settings.Default.SerialAllow = Convert.ToBoolean(objclsSettings.Adr["SerialAllow"]);
                    Settings.Default.PosBilling = Convert.ToBoolean(objclsSettings.Adr["PosBilling"]);
                    Settings.Default.InvType = Convert.ToBoolean(objclsSettings.Adr["InvType"]);

                    Settings.Default.Save();


                    chkSingleBatch.Checked = Convert.ToBoolean(objclsSettings.Adr["SingleBatch"]);
  


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
                txtInvRemarkText.Text = Settings.Default.InvRemarkText;
                chkAllowCredit.Checked = Settings.Default.AllowCreditbill;
                chkCRM.Checked = Settings.Default.CRM;
                chkGift.Checked = Settings.Default.GIFT;
                chkOtherCharge.Checked = Settings.Default.OtherCharge;
                chkVatBill.Checked = Settings.Default.VatBill;

                chkInterTransactions.Checked = Settings.Default.InternalTransactions;
                chkExpenses.Checked = Settings.Default.Expenses;
                chkSuppPay.Checked = Settings.Default.SuppPayments;
                chkAdvancUseer.Checked = Settings.Default.AdvanceUserSet;
                chkMultiLan.Checked = Settings.Default.InvMultiLan;
                cmbPrintType.Text = Settings.Default.InvLan;
                chkSaleDtEna.Checked = Settings.Default.SaleDateEna;
                chkMargine.Checked = Settings.Default.ProdMargine;
                chkAtgn.Checked = Settings.Default.ATGN;
                chkMultiCus.Checked = Settings.Default.MultiCus;
                chkFocusToBatch.Checked = Settings.Default.InvFocusToBatch;
                chkOgfSys.Checked = Settings.Default.OgfSys;
                chkShowBookings.Checked = Settings.Default.ShowBookings;
                chkShowTechnicians.Checked = Settings.Default.ShowTechnician;
                txt3rdPartyPerson.Text = Settings.Default.Person;
                chkShowRepOnLog.Checked = Settings.Default.ShowLoginRep;
                chkLoadDisc.Checked = Settings.Default.LoadInvDisc;
                chkSerialAuto.Checked = Settings.Default.SerialNo;
                chkINVFulScrn.Checked = Settings.Default.InvFullScrn;
                nmInvGridFSize.Value = Settings.Default.InvGridFonts;
                chkMinimumPrice.Checked = Settings.Default.MinimumPrice;
                chkShowPurchasePrice.Checked = Settings.Default.PurchasePrice;
                txtLastPriceName.Text = Settings.Default.LastPriceName;
                chkNSrchMode.Checked = Settings.Default.NewInvSrchMode;
                chkSerialAllow.Checked = Settings.Default.SerialAllow;
                chkPosBillings.Checked = Settings.Default.PosBilling;
                chkinvtypeallow.Checked = Settings.Default.InvType;


                if (Settings.Default.CodeGen == "Cat")
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



                txtMacAddress.Text = System.Environment.MachineName;
                LoadUnits();

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        public void LoadUnits()
        {
            try
            {
                objclsSettings.getDataSet("SELECT MacAddress,UnitNo,Flag FROM dbo.tbUnitDetails WHERE loca='" + LoginManager.LocaCode + "'  ;SELECT ISNULL(MAX(UnitNo)+1,1) FROM dbo.tbUnitDetails WHERE loca='" + LoginManager.LocaCode + "' ", "ds");

                dgUnits.DataSource = objclsSettings.Ads.Tables[0];
                cmbUnitNo.Text = objclsSettings.Ads.Tables[1].Rows[0][0].ToString();
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

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            try
            {
                string Sqlst = "EXEC [dbo].[Sp_UnitSave]  @Mac = '"+txtMacAddress.Text.Trim()+"',@Unit = '"+cmbUnitNo.Text+"',@Loca = '"+LoginManager.LocaCode+ "',@State = '"+chkUnitState.Checked+"' ";
                objclsSettings.getDataSet(Sqlst,"ds");


                LoadUnits();
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

        private void chkUnitState_CheckedChanged(object sender, EventArgs e)
        {
            if(chkUnitState.Checked)
            {
                chkUnitState.Text = "Active";
            }
            else
            { chkUnitState.Text = "Inactive"; }
        }

        private void dgUnits_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgUnits.SelectedRows.Count <= 0 || dgUnits.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    txtMacAddress.Text = dgUnits.SelectedRows[0].Cells[0].Value.ToString();
                    cmbUnitNo.Text = dgUnits.SelectedRows[0].Cells[1].Value.ToString();
                    chkUnitState.Checked = (bool) dgUnits.SelectedRows[0].Cells[2].Value;
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btUploadMenus_Click(object sender, EventArgs e)
        {
            try
            {
                clsCommon ObjComm = new clsCommon();
                string sqlStatement = "DELETE FROM dbo.tb_MenuList";
                ObjComm.getDataSet(sqlStatement, "ds");

                MainClass.mdi.InsertMenus();
                MainClass.mdi.MenuFromSettins();
                MessageBox.Show("Updated", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void chkMultiLan_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMultiLan.Checked)
            { cmbPrintType.Enabled = true; }
            else
            { cmbPrintType.Enabled = false; }
        }

        private void chkMultiCus_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}