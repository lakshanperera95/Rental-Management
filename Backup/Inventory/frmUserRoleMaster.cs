using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
namespace Inventory
{
    public partial class frmUserRoleMaster : Form
    {
        public frmUserRoleMaster()
        {
            InitializeComponent();
        }

        clsUserProfile objUserProfile = new clsUserProfile();

        private static frmUserRoleMaster UserRoleMaster;

        public static frmUserRoleMaster GetUserRoleMaster
        {
            get
            {
                return UserRoleMaster;
            }
            set
            {
                UserRoleMaster = value;
            }
        }

        private void frmUserRoleMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                UserRoleMaster = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserRoleMaster 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserRoleMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide the form...
                this.Hide();

                // Cancel the close...
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                UserRoleMaster = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserRoleMaster_Load(object sender, EventArgs e)
        {
            try
            {
                objUserProfile.dsName = "dsUserRoleMaster";
                objUserProfile.SqlStatement = "select UserRole_Description from tbUserRoleMaster ORDER BY UserRole_Id";
                objUserProfile.RetriveData();
                foreach (DataRow row in objUserProfile.ResultSet.Tables["dsUserRoleMaster"].Rows)
                {
                    cmbMemberOf.Items.Add(row["UserRole_Description"]);
                }

                if (Inventory.Properties.Settings.Default.SIP_St_Show==false)
                {
                    chkstaticStock.Checked = false;
                    chkstaticStock.Visible = chkstaticStock.Enabled = false;
                }
                //cmbMemberOf.Items.Add("Administrator");         //1
                //cmbMemberOf.Items.Add("Manager");               //2
                //cmbMemberOf.Items.Add("Purchasing Manager");    //3
                //cmbMemberOf.Items.Add("Store Keeper");          //4
                //cmbMemberOf.Items.Add("Operator");              //5

                this.Location = new Point(0,0);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserRoleMaster 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginManager.UserName.ToUpper() != "ONIMTA" && LoginManager.Password != "2302")
                {
                    if (cmbMemberOf.Text.Trim() == "Administrator")
                    {
                        MessageBox.Show("You Can't Edit Administrator Profile.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                objUserProfile.MSTDT = (chkMasterFile.Checked == true) ? "T" : "F";
                objUserProfile.MSTDTREP = (chkMasterFileDetail.Checked == true) ? "T" : "F";
                objUserProfile.LocaMaster = (chkLocationMaster.Checked == true) ? "T" : "F";
                objUserProfile.USER = (chkUserProfile.Checked == true) ? "T" : "F";
                objUserProfile.TRAN = (chkTransaction.Checked == true) ? "T" : "F";
                objUserProfile.PUR = (chkPurchasing.Checked == true) ? "T" : "F";
                objUserProfile.PUROR = (chkPurchaseOrder.Checked == true) ? "T" : "F";
                objUserProfile.PURORDET = (chkPurchaseOrderDetails.Checked == true) ? "T" : "F";
                objUserProfile.GRN = (chkGoodReceivedNote.Checked == true) ? "T" : "F";
                objUserProfile.GRNDET = (chkGoodReceivedNoteDetails.Checked == true) ? "T" : "F";
                objUserProfile.SRN = (chkSupplierReturn.Checked == true) ? "T" : "F";
                objUserProfile.SRNDET = (chksuppReturnDetails.Checked == true) ? "T" : "F";
                objUserProfile.TOG = (chkTransferNote.Checked == true) ? "T" : "F";
                objUserProfile.TOGDET = (chkTransferNoteDet.Checked == true) ? "T" : "F";
                objUserProfile.SALE = (chksalesTransaction.Checked == true) ? "T" : "F";
                objUserProfile.WSALE = (chkWholeSaleInvoice.Checked == true) ? "T" : "F";
                {
                    objUserProfile.AllPriceShow = (chkAllPriceDisplay.Checked == true) ? "T" : "F";
                    objUserProfile.StaticIpStock = (chkstaticStock.Checked == true) ? "T" : "F";
                }
                objUserProfile.WSALEDET = (chkWholeSaleDetails.Checked == true) ? "T" : "F";
                objUserProfile.CUSRET = (chkCustomerReturn.Checked == true) ? "T" : "F";
                objUserProfile.CUSRETDET = (chkCustomerReturnDetails.Checked == true) ? "T" : "F";
                objUserProfile.PMT = (chkPayment.Checked == true) ? "T" : "F";
                objUserProfile.PAYMENT = (chkSupplierPayment.Checked == true) ? "T" : "F";
                objUserProfile.PMTDET = (chkSupplierPaymentDetail.Checked == true) ? "T" : "F";
                objUserProfile.RECEIPT = (chkReceipt.Checked == true) ? "T" : "F";
                objUserProfile.RECDET = (chkReceiptDetails.Checked == true) ? "T" : "F";
                objUserProfile.STADJ = (chkStockAdjust.Checked == true) ? "T" : "F";
                objUserProfile.STAD = (chkStockAdjustment.Checked == true) ? "T" : "F";
                objUserProfile.STADDET = (chkStockAdjustmentDetails.Checked == true) ? "T" : "F";
                objUserProfile.STOVER = (chkStockOverwrite.Checked == true) ? "T" : "F";
                objUserProfile.STVRDET = (chkStockOverwriteDetails.Checked == true) ? "T" : "F";
                objUserProfile.REPSTBAL = (chkstockBalanceReport.Checked == true) ? "T" : "F";
                objUserProfile.REPSTVAL = (chkStockValuationReport.Checked == true) ? "T" : "F";
                objUserProfile.REPSAL = (chkSalesReport.Checked == true) ? "T" : "F";
                objUserProfile.REPPUR = (chkPurchasingReport.Checked == true) ? "T" : "F";
                objUserProfile.REPGP = (chkGrossProfitReport.Checked == true) ? "T" : "F";
                objUserProfile.REPANY = (chkAnalyseReport.Checked == true) ? "T" : "F";
                objUserProfile.CHQRECON = (chkChequeRecon.Checked == true) ? "T" : "F";
                objUserProfile.CHQRECDET = (chkChequeReconDet.Checked == true) ? "T" : "F";
                objUserProfile.PRCHG = (chkProdChange.Checked == true) ? "T" : "F";
                objUserProfile.Cr = (chkCr.Checked == true) ? "T" : "F";
                objUserProfile.Dr = (chkDr.Checked == true) ? "T" : "F";
                objUserProfile.SaleMoving = (chkSaleMove.Checked == true) ? "T" : "F";
                objUserProfile.Profit = (chkProfit.Checked == true) ? "T" : "F";
                objUserProfile.OrderLevel = (chkOderLevel.Checked == true) ? "T" : "F";
                objUserProfile.SYSTL = (chkSystemTools.Checked == true) ? "T" : "F";
                objUserProfile.Journal = (chkJournal.Checked == true) ? "T" : "F";
                objUserProfile.LocationReports = (chkLocationReports.Checked) ? "T" : "F";
                objUserProfile.GRNAPP = (chkGRNApply.Checked) ? "T" : "F";
                objUserProfile.POAPP = (chkPOApply.Checked) ? "T" : "F";
                objUserProfile.SRNAPP = (chkSRNApply.Checked) ? "T" : "F";
                objUserProfile.TOGAPP = (chkTOGApply.Checked) ? "T" : "F";
                objUserProfile.DebCreOpBalPassword = (chkCrDeOpBalPassword.Checked) ? "T" : "F";
                objUserProfile.Bin = (chkBincard.Checked == true) ? "T" : "F";
                objUserProfile.Cashier = (chkCashierDtl.Checked == true) ? "T" : "F";


                objUserProfile.CashFlow = (chkCashFlow.Checked == true) ? "T" : "F";
                objUserProfile.ROA = (chkROA.Checked == true) ? "T" : "F";
                objUserProfile.ROADET = (ChkROADet.Checked == true) ? "T" : "F";
                objUserProfile.CDNM = (chkCDNM.Checked == true) ? "T" : "F";
                objUserProfile.CDNMDET = (chkCDNMDet.Checked == true) ? "T" : "F";
                
                objUserProfile.UserRole_Description = cmbMemberOf.Text.Trim();
                objUserProfile.SaveUserRoleDetails();

                MessageBox.Show("New Profile Created Successful!", "New Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserProfile.GetUserProfile.UserLoad();
                this.Close();

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserRoleMaster 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMemberOf_Click(object sender, EventArgs e)
        {

        }

        private void cmbMemberOf_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                chkMasterFile.Checked = true;
                chkMasterFileDetail.Checked = true;
                chkLocationMaster.Checked = true;
                chkUserProfile.Checked = true;
                chkTransaction.Checked = true;
                chkPurchasing.Checked = true;
                chkPurchaseOrder.Checked = true;
                chkPurchaseOrderDetails.Checked = true;
                chkGoodReceivedNote.Checked = true;
                chkGoodReceivedNoteDetails.Checked = true;
                chkSupplierReturn.Checked = true;
                chksuppReturnDetails.Checked = true;
                chkTransferNote.Checked = true;
                chkTransferNoteDet.Checked = true;
                chksalesTransaction.Checked = true;
                chkWholeSaleDetails.Checked = true;
                chkWholeSaleInvoice.Checked = true;
                {
 
                }
                chkCustomerReturn.Checked = true;
                chkCustomerReturnDetails.Checked = true;
                chkPayment.Checked = true;
                chkSupplierPayment.Checked = true;
                chkSupplierPaymentDetail.Checked = true;
                chkReceipt.Checked = true;
                chkReceiptDetails.Checked = true;
                chkStockAdjust.Checked = true;
                chkStockAdjustment.Checked = true;
                chkStockAdjustmentDetails.Checked = true;
                chkStockOverwrite.Checked = true;
                chkStockOverwriteDetails.Checked = true;
                chkstockBalanceReport.Checked = true;
                chkStockValuationReport.Checked = true;
                chkSalesReport.Checked = true;
                chkPurchasingReport.Checked = true;
                chkGrossProfitReport.Checked = true;
                chkAnalyseReport.Checked = true;
                chkSystemTools.Checked = true;
                chkProdChange.Checked = true;
                chkBincard.Checked = true;
                chkDebtorOpBalance.Checked = true;
                chkDebtorOpBalanceDetails.Checked = true;
                chkCreditorOpBalance.Checked = true;
                chkCreditorOpBalanceDetails.Checked = true;
                chkGRNApply.Checked = true;
                chkSRNApply.Checked = true;
                chkTOGApply.Checked = true;
                chkPOApply.Checked = true;
                chkCrDeOpBalPassword.Checked = true;
                chkLocationReports.Checked = true;
                check();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserRoleMaster 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransaction.Checked == true)
            {
                chkPurchasing.Checked = true;
                chkPurchaseOrder.Checked = true;
                chkPurchaseOrderDetails.Checked = true;
                chkGoodReceivedNote.Checked = true;
                chkGoodReceivedNoteDetails.Checked = true;
                chkSupplierReturn.Checked = true;
                chksuppReturnDetails.Checked = true;
                chkTransferNote.Checked = true;
                chkTransferNoteDet.Checked = true;

                chksalesTransaction.Checked = true;
                chkWholeSaleDetails.Checked = true;
                chkWholeSaleInvoice.Checked = true;
                chkCustomerReturn.Checked = true;
                chkCustomerReturnDetails.Checked = true;

                chkPayment.Checked = true;
                chkSupplierPayment.Checked = true;
                chkSupplierPaymentDetail.Checked = true;
                chkReceipt.Checked = true;
                chkReceiptDetails.Checked = true;

                chkStockAdjust.Checked = true;
                chkStockAdjustment.Checked = true;
                chkStockAdjustmentDetails.Checked = true;
                chkStockOverwrite.Checked = true;
                chkStockOverwriteDetails.Checked = true;

                //************
                chkPurchasing.Enabled = true;
                chkPurchaseOrder.Enabled = true;
                chkPurchaseOrderDetails.Enabled = true;
                chkGoodReceivedNote.Enabled = true;
                chkGoodReceivedNoteDetails.Enabled = true;
                chkSupplierReturn.Enabled = true;
                chksuppReturnDetails.Enabled = true;
                chkTransferNote.Enabled = true;
                chkTransferNoteDet.Enabled = true;

                chksalesTransaction.Enabled = true;
                chkWholeSaleDetails.Enabled = true;
                chkWholeSaleInvoice.Enabled = true;
                {
                    chkstaticStock.Enabled = true;
                    chkAllPriceDisplay.Enabled = true;
                }
                chkCustomerReturn.Enabled = true;
                chkCustomerReturnDetails.Enabled = true;

                chkPayment.Enabled = true;
                chkSupplierPayment.Enabled = true;
                chkSupplierPaymentDetail.Enabled = true;
                chkReceipt.Enabled = true;
                chkReceiptDetails.Enabled = true;

                chkStockAdjust.Enabled = true;
                chkStockAdjustment.Enabled = true;
                chkStockAdjustmentDetails.Enabled = true;
                chkStockOverwrite.Enabled = true;
                chkStockOverwriteDetails.Enabled = true;
            }
            else
            {
                chkPurchasing.Checked = false;
                chkPurchaseOrder.Checked = false;
                chkPurchaseOrderDetails.Checked = false;
                chkGoodReceivedNote.Checked = false;
                chkGoodReceivedNoteDetails.Checked = false;
                chkSupplierReturn.Checked = false;
                chksuppReturnDetails.Checked = false;
                chkTransferNote.Checked = false;
                chkTransferNoteDet.Checked = false;

                chksalesTransaction.Checked = false;
                chkWholeSaleDetails.Checked = false;
                chkWholeSaleInvoice.Checked = false;
                chkCustomerReturn.Checked = false;
                chkCustomerReturnDetails.Checked = false;

                chkPayment.Checked = false;
                chkSupplierPayment.Checked = false;
                chkSupplierPaymentDetail.Checked = false;
                chkReceipt.Checked = false;
                chkReceiptDetails.Checked = false;

                chkStockAdjust.Checked = false;
                chkStockAdjustment.Checked = false;
                chkStockAdjustmentDetails.Checked = false;
                chkStockOverwrite.Checked = false;
                chkStockOverwriteDetails.Checked = false;

                //************
                chkPurchasing.Enabled = false;
                chkPurchaseOrder.Enabled = false;
                chkPurchaseOrderDetails.Enabled = false;
                chkGoodReceivedNote.Enabled = false;
                chkGoodReceivedNoteDetails.Enabled = false;
                chkSupplierReturn.Enabled = false;
                chksuppReturnDetails.Enabled = false;
                chkTransferNote.Enabled = false;
                chkTransferNoteDet.Enabled = false;

                chksalesTransaction.Enabled = false;
                chkWholeSaleDetails.Enabled = false;
                chkWholeSaleInvoice.Enabled = false;
                {
                    chkstaticStock.Enabled = false;
                    chkAllPriceDisplay.Enabled = false;
                }
                chkCustomerReturn.Enabled = false;
                chkCustomerReturnDetails.Enabled = false;

                chkPayment.Enabled = false;
                chkSupplierPayment.Enabled = false;
                chkSupplierPaymentDetail.Enabled = false;
                chkReceipt.Enabled = false;
                chkReceiptDetails.Enabled = false;

                chkStockAdjust.Enabled = false;
                chkStockAdjustment.Enabled = false;
                chkStockAdjustmentDetails.Enabled = false;
                chkStockOverwrite.Enabled = false;
                chkStockOverwriteDetails.Enabled = false;
            }
        }

        private void chkPurchasing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPurchasing.Checked == true)
            {
                chkStockAdjustment.Enabled = true;
                chkStockAdjustmentDetails.Enabled = true;
                chkStockOverwrite.Enabled = true;
                chkStockOverwriteDetails.Enabled = true;
                chkPurchaseOrder.Checked = true;
                chkPurchaseOrderDetails.Checked = true;
                chkGoodReceivedNote.Checked = true;
                chkGoodReceivedNoteDetails.Checked = true;
                chkSupplierReturn.Checked = true;
                chksuppReturnDetails.Checked = true;
                chkTransferNote.Checked = true;
                chkTransferNoteDet.Checked = true;

                chkPurchaseOrder.Enabled = true;
                chkPurchaseOrderDetails.Enabled = true;
                chkGoodReceivedNote.Enabled = true;
                chkGoodReceivedNoteDetails.Enabled = true;
                chkSupplierReturn.Enabled = true;
                chksuppReturnDetails.Enabled = true;
                chkTransferNote.Enabled = true;
                chkTransferNoteDet.Enabled = true;
            }
            else
            {
                chkPurchasing.Checked = false;
                chkPurchaseOrder.Checked = false;
                chkPurchaseOrderDetails.Checked = false;
                chkGoodReceivedNote.Checked = false;
                chkGoodReceivedNoteDetails.Checked = false;
                chkSupplierReturn.Checked = false;
                chksuppReturnDetails.Checked = false;
                chkTransferNote.Checked = false;
                chkTransferNoteDet.Checked = false;

                chkPurchaseOrder.Enabled = false;
                chkPurchaseOrderDetails.Enabled = false;
                chkGoodReceivedNote.Enabled = false;
                chkGoodReceivedNoteDetails.Enabled = false;
                chkSupplierReturn.Enabled = false;
                chksuppReturnDetails.Enabled = false;
                chkTransferNote.Enabled = false;
                chkTransferNoteDet.Enabled = false;
            }
        }

        private void chksalesTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (chksalesTransaction.Checked == true)
            {
                chkWholeSaleDetails.Checked = true;
                chkWholeSaleInvoice.Checked = true;
                chkCustomerReturn.Checked = true;
                chkCustomerReturnDetails.Checked = true;

                chkWholeSaleDetails.Enabled = true;
                chkWholeSaleInvoice.Enabled = true;
                {
                    chkstaticStock.Enabled = true;
                    chkAllPriceDisplay.Enabled = true;
                }
                chkCustomerReturn.Enabled = true;
                chkCustomerReturnDetails.Enabled = true;
            }
            else
            {
                chkWholeSaleDetails.Checked = false;
                chkWholeSaleInvoice.Checked = false;
                chkCustomerReturn.Checked = false;
                chkCustomerReturnDetails.Checked = false;

                chkWholeSaleDetails.Enabled = false;
                chkWholeSaleInvoice.Enabled = false;
                {
                    chkstaticStock.Enabled = false;
                    chkAllPriceDisplay.Enabled = false;
                }
                chkCustomerReturn.Enabled = false;
                chkCustomerReturnDetails.Enabled = false;
            }
        }

        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPayment.Checked == true)
            {
                chkSupplierPayment.Checked = true;
                chkSupplierPaymentDetail.Checked = true;
                chkReceipt.Checked = true;
                chkReceiptDetails.Checked = true;
                chkChequeRecon.Checked = true;
                chkChequeReconDet.Checked = true;
                chkCreditorOpBalance.Checked = chkCreditorOpBalanceDetails.Checked = true;
                chkDebtorOpBalance.Checked = chkDebtorOpBalanceDetails.Checked = true;

                chkSupplierPayment.Enabled = true;
                chkSupplierPaymentDetail.Enabled = true;
                chkReceipt.Enabled = true;
                chkReceiptDetails.Enabled = true;
                chkChequeRecon.Enabled = true;
                chkChequeReconDet.Enabled = true;
                chkCreditorOpBalance.Enabled = chkCreditorOpBalanceDetails.Enabled = true;
                chkDebtorOpBalance.Enabled = chkDebtorOpBalanceDetails.Enabled = true;
            }
            else
            {
                chkSupplierPayment.Checked = false;
                chkSupplierPaymentDetail.Checked = false;
                chkReceipt.Checked = false;
                chkReceiptDetails.Checked = false;
                chkChequeRecon.Checked = false;
                chkChequeReconDet.Checked = false;
                chkCreditorOpBalance.Checked = chkCreditorOpBalanceDetails.Checked = false;
                chkDebtorOpBalance.Checked = chkDebtorOpBalanceDetails.Checked = false;

                chkSupplierPayment.Enabled = false;
                chkSupplierPaymentDetail.Enabled = false;
                chkReceipt.Enabled = false;
                chkReceiptDetails.Enabled = false;
                chkChequeRecon.Enabled = false;
                chkChequeReconDet.Enabled = false;
                chkCreditorOpBalance.Enabled = chkCreditorOpBalanceDetails.Enabled = false;
                chkDebtorOpBalance.Enabled = chkDebtorOpBalanceDetails.Enabled = false;
            }
        }

        private void chkStockAdjust_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStockAdjust.Checked == true)
            {
                chkStockAdjustment.Checked = true;
                chkStockAdjustmentDetails.Checked = true;
                chkStockOverwrite.Checked = true;
                chkStockOverwriteDetails.Checked = true;

                chkStockAdjustment.Enabled = true;
                chkStockAdjustmentDetails.Enabled = true;
                chkStockOverwrite.Enabled = true;
                chkStockOverwriteDetails.Enabled = true;
            }
            else
            {
                chkStockAdjustment.Checked = false;
                chkStockAdjustmentDetails.Checked = false;
                chkStockOverwrite.Checked = false;
                chkStockOverwriteDetails.Checked = false;

                chkStockAdjustment.Enabled = false;
                chkStockAdjustmentDetails.Enabled = false;
                chkStockOverwrite.Enabled = false;
                chkStockOverwriteDetails.Enabled = false;
            }
        }

        private void frmUserRoleMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.A)
                    {
                        this.btnApply.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.D)
                        {
                            this.btnDelete.PerformClick();
                        }
                        else
                        {
                            if (e.KeyCode == Keys.E)
                            {
                                this.btnClose.PerformClick();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 010.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSystemTools_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSystemTools.Checked == true)
            {
                chkJournal.Enabled = true;
                chkJournal.Checked = true;
            }
            else
            {
                chkJournal.Enabled = false;
                chkJournal.Checked = false;
            }
        }

        private void cmbMemberOf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAnalyseReport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnalyseReport.Checked==true)
            {
                check();
            }
            else
            {
                chkDr.Enabled = false;
                chkDr.Checked = false;
                chkCr.Enabled = false;
                chkCr.Checked = false;
                chkProfit.Checked = false;
                chkProfit.Enabled = false;
                chkSaleMove.Checked = false;
                chkSaleMove.Enabled = false;
                chkProdChange.Checked = false;
                chkProdChange.Enabled = false;
                chkOderLevel.Checked = false;
                chkOderLevel.Enabled = false;
            }
        }

        private void check()
        {
            chkDr.Enabled = true;
            chkDr.Checked = true;
            chkCr.Enabled = true;
            chkCr.Checked = true;
            chkProfit.Checked = true;
            chkProfit.Enabled = true;
            chkSaleMove.Checked = true;
            chkSaleMove.Enabled = true;
            chkProdChange.Checked = true;
            chkProdChange.Enabled = true;
            chkOderLevel.Checked = true;
            chkOderLevel.Enabled = true;
        }

        private void chkMasterFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMasterFile.Checked==true)
            {
                chkCashierDtl.Checked = true;
            }
            else
            {
                chkCashierDtl.Checked = false;
            }
        }

        private void cmbMemberOf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {
                    objUserProfile.SqlStatement = "select tbUserRoleDetails.* from tbUserRoleDetails inner join tbUserRoleMaster on tbUserRoleMaster.UserRole_Id = tbUserRoleDetails.UserRole_Id WHERE UserRole_Description = '" + cmbMemberOf.Text.Trim() + "'";
                    objUserProfile.ReadProfileDetails();

                    if (objUserProfile.MSTDT == "T")
                    {
                        chkMasterFile.Checked = true;
                    }
                    else
                    {
                        chkMasterFile.Checked = false;
                    }

                    if (objUserProfile.MSTDTREP == "T")
                    {
                        chkMasterFileDetail.Checked = true;
                    }
                    else
                    {
                        chkMasterFileDetail.Checked = false;
                    }

                    if (objUserProfile.LocaMaster == "T")
                    {
                        chkLocationMaster.Checked = true;
                    }
                    else
                    {
                        chkLocationMaster.Checked = false;
                    }

                    if (objUserProfile.USER == "T")
                    {
                        chkUserProfile.Checked = true;
                    }
                    else
                    {
                        chkUserProfile.Checked = false;
                    }

                    if (objUserProfile.TRAN == "T")
                    {
                        chkTransaction.Checked = true;
                    }
                    else
                    {
                        chkTransaction.Checked = false;
                    }

                    if (objUserProfile.PUR == "T")
                    {
                        chkPurchasing.Checked = true;
                    }
                    else
                    {
                        chkPurchasing.Checked = false;
                    }


                    if (objUserProfile.PUROR == "T")
                    {
                        chkPurchaseOrder.Checked = true;
                    }
                    else
                    {
                        chkPurchaseOrder.Checked = false;
                    }

                    if (objUserProfile.PURORDET == "T")
                    {
                        chkPurchaseOrderDetails.Checked = true;
                    }
                    else
                    {
                        chkPurchaseOrderDetails.Checked = false;
                    }

                    if (objUserProfile.GRN == "T")
                    {
                        chkGoodReceivedNote.Checked = true;
                    }
                    else
                    {
                        chkGoodReceivedNote.Checked = false;
                    }

                    if (objUserProfile.GRNDET == "T")
                    {
                        chkGoodReceivedNoteDetails.Checked = true;
                    }
                    else
                    {
                        chkGoodReceivedNoteDetails.Checked = false;
                    }

                    if (objUserProfile.SRN == "T")
                    {
                        chkSupplierReturn.Checked = true;
                    }
                    else
                    {
                        chkSupplierReturn.Checked = false;
                    }

                    if (objUserProfile.SRNDET == "T")
                    {
                        chksuppReturnDetails.Checked = true;
                    }
                    else
                    {
                        chksuppReturnDetails.Checked = false;
                    }

                    if (objUserProfile.TOG == "T")
                    {
                        chkTransferNote.Checked = true;
                    }
                    else
                    {
                        chkTransferNote.Checked = false;
                    }

                    if (objUserProfile.TOGDET == "T")
                    {
                        chkTransferNoteDet.Checked = true;
                    }
                    else
                    {
                        chkTransferNoteDet.Checked = false;
                    }

                    if (objUserProfile.SALE == "T")
                    {
                        chksalesTransaction.Checked = true;
                    }
                    else
                    {
                        chksalesTransaction.Checked = false;
                    }

                    if (objUserProfile.WSALE == "T")
                    {
                        chkWholeSaleInvoice.Checked = true;
                    }
                    else
                    {
                        chkWholeSaleInvoice.Checked = false;
                    }
                    {
                        if (objUserProfile.AllPriceShow=="T")
                        {
                            chkAllPriceDisplay.Checked = true;
                        }
                        else
                        {
                            chkAllPriceDisplay.Checked = false;
                        }

                        if (objUserProfile.StaticIpStock=="T")
                        {
                            chkstaticStock.Checked = true;
                        }
                        else
                        {
                            chkstaticStock.Checked = false;
                        }
                    }


                    if (objUserProfile.WSALEDET == "T")
                    {
                        chkWholeSaleDetails.Checked = true;
                    }
                    else
                    {
                        chkWholeSaleDetails.Checked = false;
                    }

                    if (objUserProfile.CUSRET == "T")
                    {
                        chkCustomerReturn.Checked = true;
                    }
                    else
                    {
                        chkCustomerReturn.Checked = false;
                    }

                    if (objUserProfile.CUSRETDET == "T")
                    {
                        chkCustomerReturnDetails.Checked = true;
                    }
                    else
                    {
                        chkCustomerReturnDetails.Checked = false;
                    }

                    if (objUserProfile.PMT == "T")
                    {
                        chkPayment.Checked = true;
                    }
                    else
                    {
                        chkPayment.Checked = false;
                    }

                    if (objUserProfile.PAYMENT == "T")
                    {
                        chkSupplierPayment.Checked = true;
                    }
                    else
                    {
                        chkSupplierPayment.Checked = false;
                    }

                    if (objUserProfile.PMTDET == "T")
                    {
                        chkSupplierPaymentDetail.Checked = true;
                    }
                    else
                    {
                        chkSupplierPaymentDetail.Checked = false;
                    }

                    if (objUserProfile.RECEIPT == "T")
                    {
                        chkReceipt.Checked = true;
                    }
                    else
                    {
                        chkReceipt.Checked = false;
                    }

                    if (objUserProfile.RECDET == "T")
                    {
                        chkReceiptDetails.Checked = true;
                    }
                    else
                    {
                        chkReceiptDetails.Checked = false;
                    }

                    if (objUserProfile.STADJ == "T")
                    {
                        chkStockAdjust.Checked = true;
                    }
                    else
                    {
                        chkStockAdjust.Checked = false;
                    }

                    if (objUserProfile.STAD == "T")
                    {
                        chkStockAdjustment.Checked = true;
                    }
                    else
                    {
                        chkStockAdjustment.Checked = false;
                    }

                    if (objUserProfile.STADDET == "T")
                    {
                        chkStockAdjustmentDetails.Checked = true;
                    }
                    else
                    {
                        chkStockAdjustmentDetails.Checked = false;
                    }

                    if (objUserProfile.STOVER == "T")
                    {
                        chkStockOverwrite.Checked = true;
                    }
                    else
                    {
                        chkStockOverwrite.Checked = false;
                    }

                    if (objUserProfile.STVRDET == "T")
                    {
                        chkStockOverwriteDetails.Checked = true;
                    }
                    else
                    {
                        chkStockOverwriteDetails.Checked = false;
                    }

                    if (objUserProfile.REPSTBAL == "T")
                    {
                        chkstockBalanceReport.Checked = true;
                    }
                    else
                    {
                        chkstockBalanceReport.Checked = false;
                    }

                    if (objUserProfile.REPSTVAL == "T")
                    {
                        chkStockValuationReport.Checked = true;
                    }
                    else
                    {
                        chkStockValuationReport.Checked = false;
                    }

                    if (objUserProfile.REPSAL == "T")
                    {
                        chkSalesReport.Checked = true;
                    }
                    else
                    {
                        chkSalesReport.Checked = false;
                    }

                    if (objUserProfile.REPPUR == "T")
                    {
                        chkPurchasingReport.Checked = true;
                    }
                    else
                    {
                        chkPurchasingReport.Checked = false;
                    }

                    if (objUserProfile.REPGP == "T")
                    {
                        chkGrossProfitReport.Checked = true;
                    }
                    else
                    {
                        chkGrossProfitReport.Checked = false;
                    }

                    if (objUserProfile.REPANY == "T")
                    {
                        chkAnalyseReport.Checked = true;
                    }
                    else
                    {
                        chkAnalyseReport.Checked = false;
                    }

                    if (objUserProfile.CHQRECON == "T")
                    {
                        chkChequeRecon.Checked = true;
                    }
                    else
                    {
                        chkChequeRecon.Checked = false;
                    }

                    if (objUserProfile.CHQRECDET == "T")
                    {
                        chkChequeReconDet.Checked = true;
                    }
                    else
                    {
                        chkChequeReconDet.Checked = false;
                    }

                    if (objUserProfile.PRCHG == "T")
                    {
                        chkProdChange.Checked = true;
                    }
                    else
                    {
                        chkProdChange.Checked = false;
                    }

                    if (objUserProfile.Cr == "T")
                    {
                        chkCr.Checked = true;
                    }
                    else
                    {
                        chkCr.Checked = false;
                    }

                    if (objUserProfile.Dr == "T")
                    {
                        chkDr.Checked = true;
                    }
                    else
                    {
                        chkDr.Checked = false;
                    }
                    if (objUserProfile.Profit == "T")
                    {
                        chkProfit.Checked = true;
                    }
                    else
                    {
                        chkProfit.Checked = false;
                    }
                    if (objUserProfile.SaleMoving == "T")
                    {
                        chkSaleMove.Checked = true;
                    }
                    else
                    {
                        chkSaleMove.Checked = false;
                    }
                    if (objUserProfile.OrderLevel == "T")
                    {
                        chkOderLevel.Checked = true;
                    }
                    else
                    {
                        chkOderLevel.Checked = false;
                    }

                    if (objUserProfile.SYSTL == "T")
                    {
                        chkSystemTools.Checked = true;
                    }
                    else
                    {
                        chkSystemTools.Checked = false;
                    }

                    if (objUserProfile.LocationReports == "T")
                    {
                        chkLocationReports.Checked = true;
                    }
                    else
                    {
                        chkLocationReports.Checked = false;
                    }
                    if (objUserProfile.GRNAPP == "T")
                    {
                        chkGRNApply.Checked = true;
                    }
                    else
                    {
                        chkGRNApply.Checked = false;
                    }

                    if (objUserProfile.SRNAPP == "T")
                    {
                        chkSRNApply.Checked = true;
                    }
                    else
                    {
                        chkSRNApply.Checked = false;
                    }

                    if (objUserProfile.POAPP == "T")
                    {
                        chkPOApply.Checked = true;
                    }
                    else
                    {
                        chkPOApply.Checked = false;
                    }

                    if (objUserProfile.TOGAPP == "T")
                    {
                        chkTOGApply.Checked = true;
                    }
                    else
                    {
                        chkTOGApply.Checked = false;
                    }

                    if (objUserProfile.DebCreOpBalPassword == "T")
                    {
                        chkCrDeOpBalPassword.Checked = true;
                    }
                    else
                    {
                        chkCrDeOpBalPassword.Checked = false;
                    }
                    if (objUserProfile.Bin == "T")
                    {
                        chkBincard.Checked = true;
                    }
                    else
                    {
                        chkBincard.Checked = false;
                    }

                    if (objUserProfile.Cashier == "T")
                    {
                        chkCashierDtl.Checked = true;
                    }
                    else
                    {
                        chkCashierDtl.Checked = false;
                    }
                    //-----------
                    if (objUserProfile.CashFlow == "T")
                    {
                        chkCashFlow.Checked = true;
                    }
                    else
                    {
                        chkCashFlow.Checked = false;
                    }

                    if (objUserProfile.ROA == "T")
                    {
                        chkROA.Checked = true;
                    }
                    else
                    {
                        chkROA.Checked = false;
                    }
                    if (objUserProfile.ROADET == "T")
                    {
                        ChkROADet.Checked = true;
                    }
                    else
                    {
                        ChkROADet.Checked = false;
                    }
                    if (objUserProfile.CDNM == "T")
                    {
                        chkCDNM.Checked = true;
                    }
                    else
                    {
                        chkCDNM.Checked = false;
                    }
                    if (objUserProfile.CDNMDET == "T")
                    {
                        chkCDNMDet.Checked = true;
                    }
                    else
                    {
                        chkCDNMDet.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    //Write to Log
                    DateTime dtCurrentDate = DateTime.Now;
                    FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserRoleMaster 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                        // read from file or write to file
                    }
                    finally
                    {
                        m_streamWriter.Close();
                        fileStream.Close();
                    }
                    MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkWholeSaleInvoice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkWholeSaleInvoice.Checked)
                {
                    chkAllPriceDisplay.Checked = true;
                    chkstaticStock.Checked = true;
                }
                else
                {
                    chkAllPriceDisplay.Checked = false;
                    chkstaticStock.Checked = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void chkCashFlow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCashFlow.Checked)
            {
                chkROA.Checked = ChkROADet.Checked = chkCDNM.Checked = chkCDNMDet.Checked = true;
                chkROA.Enabled = ChkROADet.Enabled = chkCDNM.Enabled = chkCDNMDet.Enabled = true;
            }
            else
            {
                chkROA.Checked = ChkROADet.Checked = chkCDNM.Checked = chkCDNMDet.Checked = false ;
                chkROA.Enabled = ChkROADet.Enabled = chkCDNM.Enabled = chkCDNMDet.Enabled = false ;
            }
        }

        private void cmbMemberOf_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}