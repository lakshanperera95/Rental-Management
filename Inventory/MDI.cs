using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
//using WindowsApplication1;
using System.IO;
using Inventory.Properties;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Threading;
using System.Data.SqlClient;

namespace Inventory
{
    public partial class MDI : Form
    {

        // clsMenuControler mnucont = new clsMenuControler();
        public static frmLogin login = null;
        clsPosDisplay ObjDis = new clsPosDisplay();
        public static int InvPaperType = 0;

        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsPosDisplay.PrintCounterClosedDisplay();

            Application.Exit();
        }
        public Image SnapImage = null;
        private void MDI_Load(object sender, EventArgs e)
        {

            try
            {
                //   this.BackgroundImage = Image.FromFile(@"..\Wallpaper.JPG");
                this.BackgroundImage = Image.FromFile(@"..\Wallpaper\" + Settings.Default.Back_Image + ".jpg");
                BackgroundImageLayout = ImageLayout.Stretch;
                this.Refresh();

            }
            catch
            {
                this.BackgroundImage = global::Inventory.Properties.Resources.Super_Seller_1;
                BackgroundImageLayout = ImageLayout.Stretch;

            }

            //set Visible false all menu Item
            MainClass.mdi.mnuMain.Items["masterFileToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["masterDetailsToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["transactionToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["stockReportsToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["locationReportsToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["salesReportToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["purchasingReportToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["grossProfitReportToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["analyseReportToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["systemToolsToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["giftVoucherToolStripMenuItem1"].Visible = false;
            MainClass.mdi.mnuMain.Items["cRMToolStripMenuItem"].Visible = false;
            MainClass.mdi.mnuMain.Items["systemToolsToolStripMenuItem"].Visible = false;



            MainClass.mdi.toolStrip1.Visible = false;

            MainClass.ShowLogin();

            clsPosDisplay.PrintWelcomeDisplay();

            login = new frmLogin();
            login.MdiParent = this;
            login.Show();


        }
        #region MenuList Enter
        public void MenuFromSettins()
        {
            try
            {



                //Remove unwanted Toottrips
                // By chathuka 11/08/2020 Added for remove and add Menu list from Settings
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Mid");
                dt.Columns.Add("Flag");
                DataRow dtraw = dt.NewRow();

                
                //Enable CRM Settings
                if (Settings.Default.CRM == true)
                {
                    cRMToolStripMenuItem.Visible = true;
                    dt.Rows.Add(cRMToolStripMenuItem.Name.ToString(), "TRUE");
                }
                else
                {
                    cRMToolStripMenuItem.Visible = false;
                    dt.Rows.Add(cRMToolStripMenuItem.Name.ToString(), "FALSE");
                }

                //Enable Gift voucher Settings
                if (Settings.Default.GIFT == true)
                {
                    giftVoucherToolStripMenuItem1.Visible = true;
                    dt.Rows.Add(giftVoucherToolStripMenuItem1.Name.ToString(), "TRUE");
                }
                else
                {
                    giftVoucherToolStripMenuItem1.Visible = false;
                    dt.Rows.Add(giftVoucherToolStripMenuItem1.Name.ToString(), "FALSE");
                }
                //Enablr Expense Details
                if (Settings.Default.Expenses == true)
                {
                    expensesToolStripMenuItem.Visible = true;
                    dt.Rows.Add(expensesToolStripMenuItem.Name.ToString(), "TRUE");
                    expenseToolStripMenuItem1.Visible = true;
                    dt.Rows.Add(expenseToolStripMenuItem1.Name.ToString(), "TRUE");

                }
                else
                {
                    expensesToolStripMenuItem.Visible = false;
                    dt.Rows.Add(expensesToolStripMenuItem.Name.ToString(), "FALSE");
                    expenseToolStripMenuItem1.Visible = false;
                    dt.Rows.Add(expenseToolStripMenuItem1.Name.ToString(), "FALSE");
                }

                //Enablr Supplier Payment  Details
                if (Settings.Default.SuppPayments == true)
                {
                    paymentsToolStripMenuItem.Visible = true;
                    dt.Rows.Add(paymentsToolStripMenuItem.Name.ToString(), "TRUE");
                    paymentsDetailsToolStripMenuItem.Visible = true;
                    dt.Rows.Add(paymentsDetailsToolStripMenuItem.Name.ToString(), "TRUE");
                    creditorToolStripMenuItem.Visible = true;
                    dt.Rows.Add(creditorToolStripMenuItem.Name.ToString(), "TRUE");


                }
                else
                {
                    paymentsToolStripMenuItem.Visible = false;
                    dt.Rows.Add(paymentsToolStripMenuItem.Name.ToString(), "FALSE");
                    paymentsDetailsToolStripMenuItem.Visible = false;
                    dt.Rows.Add(paymentsDetailsToolStripMenuItem.Name.ToString(), "FALSE");
                    creditorToolStripMenuItem.Visible = false;
                    dt.Rows.Add(creditorToolStripMenuItem.Name.ToString(), "FALSE");
                }

                ////Enablr Internal Transactions

                if (Settings.Default.InternalTransactions == true)
                {
                    bundlingRegistreToolStripMenuItem.Visible = true;
                    dt.Rows.Add(bundlingRegistreToolStripMenuItem.Name.ToString(), "TRUE");
                    abstractRegisterToolStripMenuItem.Visible = true;
                    dt.Rows.Add(abstractRegisterToolStripMenuItem.Name.ToString(), "TRUE");
                    //packetingProductToolStripMenuItem.Visible = true;
                    //dt.Rows.Add(packetingProductToolStripMenuItem.Name.ToString(), "TRUE");

                    toolStripMenuItem23.Visible = true;
                    dt.Rows.Add(toolStripMenuItem23.Name.ToString(), "TRUE");
                    //toolStripMenuItem22.Visible = true;
                    //dt.Rows.Add(toolStripMenuItem22.Name.ToString(), "TRUE");
                    productAbstractingDetailReportToolStripMenuItem.Visible = true;
                    dt.Rows.Add(productAbstractingDetailReportToolStripMenuItem.Name.ToString(), "TRUE");

                    internalTransactionsToolStripMenuItem.Visible = true;
                    dt.Rows.Add(internalTransactionsToolStripMenuItem.Name.ToString(), "TRUE");
                    internalTransactionToolStripMenuItem.Visible = true;
                    dt.Rows.Add(internalTransactionToolStripMenuItem.Name.ToString(), "TRUE");
                }
                else
                {
                    bundlingRegistreToolStripMenuItem.Visible = false;
                    dt.Rows.Add(bundlingRegistreToolStripMenuItem.Name.ToString(), "FALSE");
                    abstractRegisterToolStripMenuItem.Visible = false;
                    dt.Rows.Add(abstractRegisterToolStripMenuItem.Name.ToString(), "FALSE");
                    //packetingProductToolStripMenuItem.Visible = false;
                    //dt.Rows.Add(packetingProductToolStripMenuItem.Name.ToString(), "FALSE");

                    toolStripMenuItem23.Visible = false;
                    dt.Rows.Add(toolStripMenuItem23.Name.ToString(), "FALSE");
                    //toolStripMenuItem22.Visible = false;
                    //dt.Rows.Add(toolStripMenuItem22.Name.ToString(), "FALSE");
                    productAbstractingDetailReportToolStripMenuItem.Visible = false;
                    dt.Rows.Add(productAbstractingDetailReportToolStripMenuItem.Name.ToString(), "FALSE");

                    internalTransactionsToolStripMenuItem.Visible = false;
                    dt.Rows.Add(internalTransactionsToolStripMenuItem.Name.ToString(), "FALSE");
                    internalTransactionToolStripMenuItem.Visible = false;
                    dt.Rows.Add(internalTransactionToolStripMenuItem.Name.ToString(), "FALSE");
                }

                if (Settings.Default.PosBilling == true)
                {
                    posSalesAnalyseReportToolStripMenuItem.Visible = true;
                    dt.Rows.Add(posSalesAnalyseReportToolStripMenuItem.Name.ToString(), "TRUE");
                    currentSalesAnalyseToolStripMenuItem.Visible = true;
                    dt.Rows.Add(currentSalesAnalyseToolStripMenuItem.Name.ToString(), "TRUE");
                    dayEndProcessToolStripMenuItem.Visible = true;
                    dt.Rows.Add(dayEndProcessToolStripMenuItem.Name.ToString(), "TRUE");
                    dataUpdateToPosTerminalToolStripMenuItem.Visible = true;
                    dt.Rows.Add(dataUpdateToPosTerminalToolStripMenuItem.Name.ToString(), "TRUE");
                    posReceiptDisplayToolStripMenuItem.Visible = true;
                    dt.Rows.Add(posReceiptDisplayToolStripMenuItem.Name.ToString(), "TRUE");
                }
                else
                {
                    posSalesAnalyseReportToolStripMenuItem.Visible = false;
                    dt.Rows.Add(posSalesAnalyseReportToolStripMenuItem.Name.ToString(), "FALSE");
                    currentSalesAnalyseToolStripMenuItem.Visible = false;
                    dt.Rows.Add(currentSalesAnalyseToolStripMenuItem.Name.ToString(), "FALSE");
                    dayEndProcessToolStripMenuItem.Visible = false;
                    dt.Rows.Add(dayEndProcessToolStripMenuItem.Name.ToString(), "FALSE");
                    dataUpdateToPosTerminalToolStripMenuItem.Visible = false;
                    dt.Rows.Add(dataUpdateToPosTerminalToolStripMenuItem.Name.ToString(), "FALSE");
                    posReceiptDisplayToolStripMenuItem.Visible = false;
                    dt.Rows.Add(posReceiptDisplayToolStripMenuItem.Name.ToString(), "FALSE");
                }

                DbConnection.dbcon.OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandTimeout = DbConnection.LoginSys.dbocommTimeOut;
                command.Connection = DbConnection.dbcon.connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_MenuBlock";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@tb", dt));


                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }

        }
        clsCommon ObjComm = new clsCommon();
        public void InsertMenus()
        {
            try
            {

                foreach (ToolStripMenuItem mnui in mnuMain.Items)
                {
                    recursiveLoop(mnui);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }

        }
        #endregion
        /*  private void recursiveLoop(ToolStripMenuItem item)
          {
              try
              {
                  if (item.Tag != null)
                  {


                      string ParentNode = "";
                      string GroupID = "";
                      ToolStripItem x = item.OwnerItem;

                      if (x == null)
                      {
                          //ToolStrip y = item.Owner;
                          ParentNode = "0";
                      }
                      else
                      {
                          ParentNode = x.Tag.ToString();


                      }

                      string Node = item.Tag.ToString();

                      string MenuID = Node;
                      string MenuName = item.Text;
                      string ParentMenuID = ParentNode;
                      string GruopMenuId = GroupID.Trim();
                      if (item.AccessibleName != null)
                      {
                          GroupID = item.AccessibleName.ToString();
                      }

                      // clsDBTrans temp = new clsDBTrans();

                      clsCommon ObjComm = new clsCommon();
                      string sqlStatement = "EXEC sp_MenuItem_Save @MenuID='" + MenuID + "', @MenuName='" + MenuName + "', @ParentMenuID='" + ParentMenuID + "',@GroupID='" + GroupID + "'  ";
                      ObjComm.getDataReader(sqlStatement);


                  }


                  if (item.Tag != null)
                  {
                      for (int a = 0; a < item.DropDownItems.Count; a++)
                          if (item.DropDownItems[a] is ToolStripMenuItem)
                          {
                              recursiveLoop(item.DropDownItems[a] as ToolStripMenuItem);
                          }
                  }
              }
              catch (Exception ex)
              {

                  clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
              }

          }
        */
        private void recursiveLoop(ToolStripMenuItem item)
        {
            try
            {


                string ParentNode = "";
                string GroupID = "";
                ToolStripItem x = item.OwnerItem;

                if (x == null)
                {
                    //ToolStrip y = item.Owner;
                    ParentNode = "0";
                }
                else
                {
                    ParentNode = x.Name.ToString();
                }

                string Node = item.Name.ToString();

                string MenuID = Node;
                string MenuName = item.Text;
                string Tag = "";
                if (item.Tag != null)
                {
                    Tag = item.Tag.ToString();
                }
                string ParentMenuID = ParentNode;
                string GruopMenuId = GroupID.Trim();
                if (item.AccessibleName != null)
                {
                    GroupID = item.AccessibleName.ToString();
                }

                // clsDBTrans temp = new clsDBTrans();

                clsCommon ObjComm = new clsCommon(); 
                string sqlStatement = "EXEC sp_MenuItem_Save @MenuID='" + MenuID + "', @MenuName='" + MenuName + "', @ParentMenuID='" + ParentMenuID + "',@GroupID='" + GroupID + "',@Tag='" + Tag + "'  ";
                ObjComm.getData(sqlStatement);


                for (int a = 0; a < item.DropDownItems.Count; a++)
                    if (item.DropDownItems[a] is ToolStripMenuItem)
                    {
                        recursiveLoop(item.DropDownItems[a] as ToolStripMenuItem);
                    }

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }

        }


        private void recursiveLoop1(ToolStripMenuItem item)
        {
            try
            {

                string ParentNode = "";
                string GroupID = "";
                ToolStripItem x = item.OwnerItem;

                if (x == null)
                {
                    //ToolStrip y = item.Owner;
                    ParentNode = "0";
                }
                else
                {
                    ParentNode = x.Name.ToString();


                }

                string Node = item.Name.ToString();

                string MenuID = Node;
                string MenuName = item.Text;
                string ParentMenuID = ParentNode;
                string GruopMenuId = GroupID.Trim();
                if (item.AccessibleName != null)
                {
                    GroupID = item.AccessibleName.ToString();
                }

                // clsDBTrans temp = new clsDBTrans();

                clsCommon ObjComm = new clsCommon();
                string sqlStatement = "EXEC sp_MenuItem_Save @MenuID='" + MenuID + "', @MenuName='" + MenuName + "', @ParentMenuID='" + ParentMenuID + "',@GroupID='" + GroupID + "'  ";
                ObjComm.getDataReader(sqlStatement);



                for (int a = 0; a < item.DropDownItems.Count; a++)
                    if (item.DropDownItems[a] is ToolStripMenuItem)
                    {
                        recursiveLoop(item.DropDownItems[a] as ToolStripMenuItem);
                    }

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }

        }


        private void label1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Filter = "All Picture files (*.bmp)|*.bmp|JPG (*.JPG)|*.JPG|JPEG (*.JPEG)|*.JPEG|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    // Insert code to read the stream here.

                    myStream.Close();
                    this.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                    Settings.Default.Back_Image = openFileDialog1.FileName;
                    Settings.Default.Save();
                }
            }
        }

        private void mnuLocationDetails_Click(object sender, EventArgs e)
        {
            // frmLocation l = new frmLocation();

            if (frmLocation.GetLocation == null)
            {
                frmLocation.GetLocation = new frmLocation();
                frmLocation.GetLocation.MdiParent = this;
                frmLocation.GetLocation.Show();

            }
            else
            {
                frmLocation.GetLocation.Focus();
            }
        }

        private void mnuDepartment_Click(object sender, EventArgs e)
        {
            if (frmDepartment.GetDepartment == null)
            {
                frmDepartment.GetDepartment = new frmDepartment();
                frmDepartment.GetDepartment.MdiParent = this;
                frmDepartment.GetDepartment.Show();
            }
            else
            {
                frmDepartment.GetDepartment.Focus();
            }
        }

        private void mnuSupplier_Click_1(object sender, EventArgs e)
        {
            if (frmSupplier.GetAccount == null)
            {
                frmSupplier.GetAccount = new frmSupplier();
                frmSupplier.GetAccount.MdiParent = this;
                frmSupplier.GetAccount.Show();
            }
            else
            {
                frmDepartment.GetDepartment.Focus();
            }
        }

        private void mnuCategory_Click(object sender, EventArgs e)
        {
            if (frmCategory.GetCategory == null)
            {
                frmCategory.GetCategory = new frmCategory();
                frmCategory.GetCategory.MdiParent = this;
                frmCategory.GetCategory.Show();
            }
            else
            {
                frmCategory.GetCategory.Focus();
            }
        }

        private void mnuBrand_Click(object sender, EventArgs e)
        {
            if (frmBrand.GetBrand == null)
            {
                frmBrand.GetBrand = new frmBrand();
                frmBrand.GetBrand.MdiParent = this;
                frmBrand.GetBrand.Show();
            }
            else
            {
                frmBrand.GetBrand.Focus();
            }
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {

        }

        private void mnuManufact_Click(object sender, EventArgs e)
        {
            if (frmManufacturer.GetManufacturer == null)
            {
                frmManufacturer.GetManufacturer = new frmManufacturer();
                frmManufacturer.GetManufacturer.MdiParent = this;
                frmManufacturer.GetManufacturer.Show();

            }
            else
            {
                frmManufacturer.GetManufacturer.Focus();
            }
        }

        private void departmentDeatilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Department Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 1;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void categoryDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Category Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 2;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void goodReceivedNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmGrn.GetGrn == null)
            {
                frmGrn.GetGrn = new frmGrn();
                frmGrn.GetGrn.MdiParent = this;
                frmGrn.GetGrn.Show();
            }
            else
            {
                frmGrn.GetGrn.Focus();
            }
        }

        private void stockAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transferOfGoodsNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransferGoodNote.GetTransferNote == null)
            {
                frmTransferGoodNote.GetTransferNote = new frmTransferGoodNote();
                frmTransferGoodNote.GetTransferNote.MdiParent = this;
                frmTransferGoodNote.GetTransferNote.Show();
            }
            else
            {
                frmTransferGoodNote.GetTransferNote.Focus();
            }
        }

        private void transferOfGoodsNoteDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stockAdjustmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goodReceivedNoteDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuProductDetails_Click(object sender, EventArgs e)
        {

        }

        private void purchaseOrderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuCustomerDetails_Click(object sender, EventArgs e)
        {

        }

        private void mnuSupplierDetails_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Supplier Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 5;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void wholeSaleInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmWholeSaleInvoice.GetInvoice == null)
            {
                frmWholeSaleInvoice.GetInvoice = new frmWholeSaleInvoice();
                frmWholeSaleInvoice.GetInvoice.MdiParent = this;
                frmWholeSaleInvoice.GetInvoice.Show();
            }
            else
            {
                frmWholeSaleInvoice.GetInvoice.Focus();
            }
        }

        private void mnuProductWise_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product-Wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 50;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void supplierPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDeptWise_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Department Wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 51;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void mnuCatgrywise_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Category Wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 52;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void mnuManufacturerwise_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Brand Wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 53;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void mnuSupplierwise_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Supplier Wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 54;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void supplierPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wholeSaleInvoiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSupplierReturn.GetSupplierReturn == null)
            {
                frmSupplierReturn.GetSupplierReturn = new frmSupplierReturn();
                frmSupplierReturn.GetSupplierReturn.MdiParent = this;
                frmSupplierReturn.GetSupplierReturn.Show();
            }
            else
            {
                frmSupplierReturn.GetSupplierReturn.Focus();
            }
        }

        private void customerPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCustomerPayment.GetCustomerPayment == null)
            {
                frmCustomerPayment.GetCustomerPayment = new frmCustomerPayment("");
                frmCustomerPayment.GetCustomerPayment.MdiParent = this;
                frmCustomerPayment.GetCustomerPayment.Show();
            }
            else
            {
                frmCustomerPayment.GetCustomerPayment.Focus();
            }
        }

        private void receiptDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerReturnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wholeSaleInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void customerReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseOrderNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void goodReceivedNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void stockAdjustmentNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Stock Adjustment Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 203;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void transferOfGoodNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void supplierPaymentNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void receiptNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierPaymentSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void receiptSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void invoiceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerReturnSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseOrderSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goodReceivedSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockAdjustmentSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Stock Adjustment Note Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 214;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void transferOfGoodNoteSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void departmentwiseProductWiseStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Department Wise Item wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 55;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void categorywiseProductWiseStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Category Wise Product wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 56;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void manufacturerwiseProductWiseStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Brand Wise Item wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 57;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void supplierwiseProductWiseStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Supplier Wise Item wise Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 58;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void mnuStockOverwrite_Click(object sender, EventArgs e)
        {

        }

        private void productwiseStockValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Wise Stock Valuation";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 59;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void departmentwiseProductWiseValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Department Wise Product wise Stock Valuation";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 60;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void categoryWiseProductWiseValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Category Wise Product wise Stock Valuation";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 61;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void supplierwiseProductWiseValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Supplier Wise Product wise Stock Valuation";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 62;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void manufacturerwiseWiseProductWiseValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Brand Wise Product wise Stock Valuation";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 63;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void departmentWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manufacturerWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailySalesSummaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productWiseSalesAnalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void salesAnalyseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseAnalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAnalyse.GetAnalyse == null)
            {
                frmAnalyse.GetAnalyse = new frmAnalyse();
                frmAnalyse.GetAnalyse.MdiParent = this;
                frmAnalyse.GetAnalyse.Text = "Purchase Analyse";
                frmAnalyse.GetAnalyse.intRepOption = 1100;
                frmAnalyse.GetAnalyse.Show();
            }
            else
            {
                frmAnalyse.GetAnalyse.Focus();
            }
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse Report 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Purchasing Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 200;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentWisePurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Department wise Purchasing Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 201;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void categoryWisePurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Category wise Purchasing Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 202;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWisePurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Purchasing Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 203;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void manufacturerWisePurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Brand wise Purchasing Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 204;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void monthlyPurchaseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Monthly Purchasing Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 205;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productWiseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 300;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentWiseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Department wise Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 301;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void categoryWiseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Category wise Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 302;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 303;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void manufactureWiseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Brand wise Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 304;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void monthlyProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Monthly Profit Summary Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 305;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dailyProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Daily Profit Summary Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 306;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void profitAnalyseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAnalyse.GetAnalyse == null)
            {
                frmAnalyse.GetAnalyse = new frmAnalyse();
                frmAnalyse.GetAnalyse.MdiParent = this;
                frmAnalyse.GetAnalyse.Text = "Profit Analyse";
                frmAnalyse.GetAnalyse.intRepOption = 1200;
                frmAnalyse.GetAnalyse.Show();
            }
            else
            {
                frmAnalyse.GetAnalyse.Focus();
            }
        }

        private void salesPurchaseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categorySalesPurchaseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierSalesPurchaseProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseOrderNoteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmPurchaseOrder.GetPon == null)
            {
                frmPurchaseOrder.GetPon = new frmPurchaseOrder();
                frmPurchaseOrder.GetPon.MdiParent = this;
                frmPurchaseOrder.GetPon.Show();
            }
            else
            {
                frmPurchaseOrder.GetPon.Focus();
            }
        }

        private void goodReceivedNoteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmGrn.GetGrn == null)
            {
                frmGrn.GetGrn = new frmGrn();
                frmGrn.GetGrn.MdiParent = this;
                frmGrn.GetGrn.Show();
            }
            else
            {
                frmGrn.GetGrn.Focus();
            }
        }

        private void iffrmSupplierReturnGetSupplierReturnNullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSupplierReturn.GetSupplierReturn == null)
            {
                frmSupplierReturn.GetSupplierReturn = new frmSupplierReturn();
                frmSupplierReturn.GetSupplierReturn.MdiParent = this;
                frmSupplierReturn.GetSupplierReturn.Show();
            }
            else
            {
                frmSupplierReturn.GetSupplierReturn.Focus();
            }
        }

        private void transferOfGoodsNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransferGoodNote.GetTransferNote == null)
            {
                frmTransferGoodNote.GetTransferNote = new frmTransferGoodNote();
                frmTransferGoodNote.GetTransferNote.MdiParent = this;
                frmTransferGoodNote.GetTransferNote.Show();
            }
            else
            {
                frmTransferGoodNote.GetTransferNote.Focus();
            }
        }

        private void wholeSaleInvoiceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmWholeSaleInvoice.GetInvoice == null)
            {
                frmWholeSaleInvoice.GetInvoice = new frmWholeSaleInvoice();
                frmWholeSaleInvoice.GetInvoice.MdiParent = this;
                frmWholeSaleInvoice.GetInvoice.Show();
            }
            else
            {
                frmWholeSaleInvoice.GetInvoice.Focus();
            }
        }

        private void customerReturnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Please Use Invoice Form To Customer Return !", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (frmCustomerReturn.GetCustomerReturn == null)
            {
                frmCustomerReturn.GetCustomerReturn = new frmCustomerReturn();
                frmCustomerReturn.GetCustomerReturn.MdiParent = this;
                frmCustomerReturn.GetCustomerReturn.Show();
            }
            else
            {
                frmCustomerReturn.GetCustomerReturn.Focus();
            }
        }

        private void supplierPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSupplierPayment.GetSupplierPayment == null)
            {
                frmSupplierPayment.GetSupplierPayment = new frmSupplierPayment();
                frmSupplierPayment.GetSupplierPayment.MdiParent = this;
                frmSupplierPayment.GetSupplierPayment.Show();
            }
            else
            {
                frmSupplierPayment.GetSupplierPayment.Focus();
            }
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmCustomerPayment.GetCustomerPayment == null)
            //{
            //    frmCustomerPayment.GetCustomerPayment = new frmCustomerPayment();
            //    frmCustomerPayment.GetCustomerPayment.MdiParent = this;
            //    frmCustomerPayment.GetCustomerPayment.Show();
            //}
            //else
            //{
            //    frmCustomerPayment.GetCustomerPayment.Focus();
            //}

        }

        private void stockAdjustmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmStockAdjustment.GetStockAdjust == null)
            {
                frmStockAdjustment.GetStockAdjust = new frmStockAdjustment();
                frmStockAdjustment.GetStockAdjust.MdiParent = this;
                frmStockAdjustment.GetStockAdjust.Show();
            }
            else
            {
                frmStockAdjustment.GetStockAdjust.Focus();
            }
        }

        private void stockOverwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmStockOverwrite.GetStockOverwrite == null)
            {

                frmStockOverwrite.GetStockOverwrite = new frmStockOverwrite();
                frmStockOverwrite.GetStockOverwrite.MdiParent = this;
                frmStockOverwrite.GetStockOverwrite.Show();
            }
            else
            {
                frmStockOverwrite.GetStockOverwrite.Focus();
            }
        }

        private void wholeSaleInvoiceNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Whole Sale Invoice Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 200;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void invoiceSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Invoice Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 210;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerReturnNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Return Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 207;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerReturnSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Return Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 211;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void purchaseOrderNoteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Purchase Order Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 201;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void purchaseOrderSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Purchase Order Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 212;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void goodReceivedNoteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Goods Received Note Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 202;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void goodReceivedSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Good Received Note Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 213;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void transferOfGoodNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Transfer Of Goods Note Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 204;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void transferOfGoodNoteSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Transfer Of Goods Note Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 215;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierPaymentNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Payment Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 205;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierPaymentSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Payment Summary Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 208;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void receiptNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void receiptSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void productBinCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUserProfile.GetUserProfile == null)
            {
                frmUserProfile.GetUserProfile = new frmUserProfile();
                frmUserProfile.GetUserProfile.MdiParent = this;
                frmUserProfile.GetUserProfile.Show();
            }
            else
            {
                frmUserProfile.GetUserProfile.Focus();
            }
        }

        private void supplierReturnNoteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Return Note Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 216;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierReturnSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Return Note Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 217;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChangePassword.GetChangePassword == null)
            {
                frmChangePassword.GetChangePassword = new frmChangePassword();
                frmChangePassword.GetChangePassword.MdiParent = this;
                frmChangePassword.GetChangePassword.Show();
            }
            else
            {
                frmChangePassword.GetChangePassword.Focus();
            }
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure You want to Log Off. All Open Dialog Boxes are will Close without Save.", "Log Off", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    foreach (Form f in this.MdiChildren)
            //    {
            //        f.Close();
            //    }
            //    MainClass.mdi.mnuMain.Items["masterFileToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["masterDetailsToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["transactionToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["StockBalanceToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["stockValuationReportToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["salesReportToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["purchasingReportToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["grossProfitReportToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["analyseReportToolStripMenuItem"].Visible = false;
            //    MainClass.mdi.mnuMain.Items["systemToolsToolStripMenuItem"].Visible = false;

            //    MainClass.mdi.toolStrip1.Visible = false;
            //    MainClass.mdi.mnuMain.Enabled = false;
            //    MainClass.mdi.Text = "Inventory System";
            //    login = new frmLogin();
            //    login.MdiParent = this;
            //    login.Show();
            //}
            //else
            //{
            //    return;
            //}
            toolStripButtonLogOff.PerformClick();
        }

        private void barcodePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBarcode.GetBarcode == null)
            {
                frmBarcode.GetBarcode = new frmBarcode();
                frmBarcode.GetBarcode.MdiParent = this;
                frmBarcode.GetBarcode.Show();
            }
            else
            {
                frmBarcode.GetBarcode.Focus();
            }
        }

        private void dayEndProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDayEndProcess.GetDayEndProcess == null)
            {
                frmDayEndProcess.GetDayEndProcess = new frmDayEndProcess();
                frmDayEndProcess.GetDayEndProcess.MdiParent = this;
                frmDayEndProcess.GetDayEndProcess.Show();
            }
            else
            {
                frmDayEndProcess.GetDayEndProcess.Focus();
            }
        }

        private void dataUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDataUploading.GetDataUpload == null)
            {
                frmDataUploading.GetDataUpload = new frmDataUploading();
                frmDataUploading.GetDataUpload.MdiParent = this;
                frmDataUploading.GetDataUpload.Show();
            }
            else
            {
                frmDataUploading.GetDataUpload.Focus();
            }
        }

        private void toolStripFile_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void creditorStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Creditor Statement";
                frmSalesInquary.GetSalesInquary.intRepOption = 405;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void debtorStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Debtor Statement";
                frmSalesInquary.GetSalesInquary.intRepOption = 406;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void creditorBalanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Creditor Balance Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 407;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void debtorsBalanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Debtors Balance Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 408;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void chequeReconsiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChequeRecon.GetChequeRecon == null)
            {
                frmChequeRecon.GetChequeRecon = new frmChequeRecon();
                frmChequeRecon.GetChequeRecon.MdiParent = this;
                frmChequeRecon.GetChequeRecon.Show();
            }
            else
            {
                frmChequeRecon.GetChequeRecon.Focus();
            }
        }

        private void chequeReconciliationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productWiseReOrderLevelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierWiseReOrderLevelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creditorAccountAnalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAccountAnalyse.GetAccountAnalyse == null)
            {
                frmAccountAnalyse.GetAccountAnalyse = new frmAccountAnalyse();
                frmAccountAnalyse.GetAccountAnalyse.MdiParent = this;
                frmAccountAnalyse.GetAccountAnalyse.Text = "Creditor Account Analyse";
                frmAccountAnalyse.GetAccountAnalyse.intRepOption = 412;
                frmAccountAnalyse.GetAccountAnalyse.Show();
            }
            else
            {
                frmAccountAnalyse.GetAccountAnalyse.Focus();
            }
        }

        private void debtorAccountAnalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAccountAnalyse.GetAccountAnalyse == null)
            {
                frmAccountAnalyse.GetAccountAnalyse = new frmAccountAnalyse();
                frmAccountAnalyse.GetAccountAnalyse.MdiParent = this;
                frmAccountAnalyse.GetAccountAnalyse.Text = "Debtor Account Analyse";
                frmAccountAnalyse.GetAccountAnalyse.intRepOption = 413;
                frmAccountAnalyse.GetAccountAnalyse.Show();
            }
            else
            {
                frmAccountAnalyse.GetAccountAnalyse.Focus();
            }
        }

        private void manufacturerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Brand Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 6;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void profitableMovingProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fastMovingProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fastMovingProductReportSupplierWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SalescomparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productDetailsChangeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Details Change Report(Date wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 414;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productDetailsChangeReportProductWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void packetingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productPacketingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productPacketingNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void packetingProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Packeting Product Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 7;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void posSalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exchangeProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void salesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesman.GetSalesman == null)
            {
                frmSalesman.GetSalesman = new frmSalesman();
                frmSalesman.GetSalesman.MdiParent = this;
                frmSalesman.GetSalesman.Show();
            }
            else
            {
                frmSalesman.GetSalesman.Focus();
            }
        }

        private void salesmanWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesmanDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Salesman Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 8;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void cashierDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUserProfile.GetUserProfile == null)
            {
                frmCashierDetails.GetCashierDetails = new frmCashierDetails();
                frmCashierDetails.GetCashierDetails.MdiParent = this;
                frmCashierDetails.GetCashierDetails.Show();
            }
            else
            {
                frmCashierDetails.GetCashierDetails.Focus();
            }
        }

        private void supplierWiseNonMovingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonDept_Click(object sender, EventArgs e)
        {
            if (frmDepartment.GetDepartment == null)
            {
                frmDepartment.GetDepartment = new frmDepartment();
                frmDepartment.GetDepartment.MdiParent = this;
                frmDepartment.GetDepartment.Show();
            }
            else
            {
                frmDepartment.GetDepartment.Focus();
            }
        }

        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You want to Log Off. All Open Forms will be Closed without Saving.", "Log Off", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }
                MainClass.mdi.mnuMain.Items["masterFileToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["masterDetailsToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["transactionToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["stockReportsToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["locationReportsToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["salesReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["purchasingReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["grossProfitReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["analyseReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["systemToolsToolStripMenuItem"].Visible = false;
                MainClass.mdi.toolStrip1.Visible = false;
                MainClass.mdi.mnuMain.Enabled = false;
                MainClass.mdi.Text = "Merit Plus Super Seller";

                MainClass.mdi.backgroundWorker1.CancelAsync();
                //MainClass.mdi.backgroundWorker1.Dispose();
                //MainClass.mdi.backgroundWorker1 = null;

                MainClass.mdi.timer1.Stop();
                login = new frmLogin();
                login.MdiParent = this;

                //DisplayText
                clsPosDisplay.PrintCounterClosedDisplay();
                login.Show();
            }
            else
            {
                return;
            }
        }

        private void toolStripCategory_Click(object sender, EventArgs e)
        {
            if (frmCategory.GetCategory == null)
            {
                frmCategory.GetCategory = new frmCategory();
                frmCategory.GetCategory.MdiParent = this;
                frmCategory.GetCategory.Show();
            }
            else
            {
                frmCategory.GetCategory.Focus();
            }
        }

        private void toolStripSupplier_Click(object sender, EventArgs e)
        {
            if (frmSupplier.GetAccount == null)
            {
                frmSupplier.GetAccount = new frmSupplier();
                frmSupplier.GetAccount.MdiParent = this;
                frmSupplier.GetAccount.Show();
            }
            else
            {
                frmSupplier.GetAccount.Focus();
            }
        }

        private void toolStripProduct_Click(object sender, EventArgs e)
        {
            if (frmProduct.GetProduct == null)
            {
                frmProduct.GetProduct = new frmProduct(null);
                frmProduct.GetProduct.MdiParent = this;
                frmProduct.GetProduct.Show();
            }
            else
            {
                frmProduct.GetProduct.Focus();
            }
        }

        private void toolStripButtonPurchaseOrder_Click(object sender, EventArgs e)
        {
            if (frmPurchaseOrder.GetPon == null)
            {
                frmPurchaseOrder.GetPon = new frmPurchaseOrder();
                frmPurchaseOrder.GetPon.MdiParent = this;
                frmPurchaseOrder.GetPon.Show();
            }
            else
            {
                frmPurchaseOrder.GetPon.Focus();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmTransferGoodNote.GetTransferNote == null)
            {
                frmTransferGoodNote.GetTransferNote = new frmTransferGoodNote();
                frmTransferGoodNote.GetTransferNote.MdiParent = this;
                frmTransferGoodNote.GetTransferNote.Show();
            }
            else
            {
                frmTransferGoodNote.GetTransferNote.Focus();
            }
        }

        private void toolStripButtonInvoice_Click(object sender, EventArgs e)
        {
            if (frmWholeSaleInvoice.GetInvoice == null)
            {
                frmWholeSaleInvoice.GetInvoice = new frmWholeSaleInvoice();
                if (Settings.Default.InvFullScrn == false)
                {
                    frmWholeSaleInvoice.GetInvoice.MdiParent = this;
                }
                else
                {
                    frmWholeSaleInvoice.GetInvoice.MdiParent = this;
                    frmWholeSaleInvoice.GetInvoice.Height = this.Height-(mnuMain.Height+20);
                    this.toolStrip1.Visible = false;
                }
                if (Settings.Default.ProdImage == false)
                {
                    frmWholeSaleInvoice.GetInvoice.StartPosition = FormStartPosition.CenterScreen;
                }
                frmWholeSaleInvoice.GetInvoice.Show();
            }
            else
            {
                frmWholeSaleInvoice.GetInvoice.Focus();
            }
        }

        private void toolStripButtonReceipt_Click(object sender, EventArgs e)
        {
            if (Settings.Default.RecAmtFirst == true) // If Amount First 
            {
                if (frmInvoiceCustomerPayment.GetCustomerPayment == null)
                {
                    frmInvoiceCustomerPayment.GetCustomerPayment = new frmInvoiceCustomerPayment("");
                    frmInvoiceCustomerPayment.GetCustomerPayment.MdiParent = this;
                    frmInvoiceCustomerPayment.GetCustomerPayment.Show();
                }
                else
                {
                    frmInvoiceCustomerPayment.GetCustomerPayment.Focus();
                }
            }
            else
            {
                if (frmCustomerPayment.GetCustomerPayment == null)
                {
                    frmCustomerPayment.GetCustomerPayment = new frmCustomerPayment("");
                    frmCustomerPayment.GetCustomerPayment.MdiParent = this;
                    frmCustomerPayment.GetCustomerPayment.Show();
                }
                else
                {
                    frmCustomerPayment.GetCustomerPayment.Focus();
                }
            }

        }

        private void toolStripButtonCustRet_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Please Use Invoice Form To Customer Return !", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (frmCustomerReturn.GetCustomerReturn == null)
            //{
            //    frmCustomerReturn.GetCustomerReturn = new frmCustomerReturn();
            //    frmCustomerReturn.GetCustomerReturn.MdiParent = this;
            //    frmCustomerReturn.GetCustomerReturn.Show();
            //}
            //else
            //{
            //    frmCustomerReturn.GetCustomerReturn.Focus();
            //}
        }

        private void toolStripButtonPayment_Click(object sender, EventArgs e)
        {
            if (frmSupplierPayment.GetSupplierPayment == null)
            {
                frmSupplierPayment.GetSupplierPayment = new frmSupplierPayment();
                frmSupplierPayment.GetSupplierPayment.MdiParent = this;
                frmSupplierPayment.GetSupplierPayment.Show();
            }
            else
            {
                frmSupplierPayment.GetSupplierPayment.Focus();
            }
        }

        private void toolStripButtonCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void toolStripButtonSuppReturn_Click(object sender, EventArgs e)
        {
            if (frmSupplierReturn.GetSupplierReturn == null)
            {
                frmSupplierReturn.GetSupplierReturn = new frmSupplierReturn();
                frmSupplierReturn.GetSupplierReturn.MdiParent = this;
                frmSupplierReturn.GetSupplierReturn.Show();
            }
            else
            {
                frmSupplierReturn.GetSupplierReturn.Focus();
            }
        }

        private void toolStripGrn_Click(object sender, EventArgs e)
        {
            if (frmGrn.GetGrn == null)
            {
                frmGrn.GetGrn = new frmGrn();
                frmGrn.GetGrn.MdiParent = this;
                frmGrn.GetGrn.Show();
            }
            else
            {
                frmGrn.GetGrn.Focus();
            }
        }

        private void aboutOnimtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AboutBox.GetAboutBox == null)
            {
                AboutBox.GetAboutBox = new AboutBox();
                AboutBox.GetAboutBox.MdiParent = this;
                AboutBox.GetAboutBox.Show();
            }
            else
            {
                AboutBox.GetAboutBox.Focus();
            }
        }

        private void currentSalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void slowMovingProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentHourlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hourlySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateProductOnPosTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (frmBarcode.GetBarcode == null)
            {
                frmBarcode.GetBarcode = new frmBarcode();
                frmBarcode.GetBarcode.MdiParent = this;
                frmBarcode.GetBarcode.Show();
            }
            else
            {
                frmBarcode.GetBarcode.Focus();
            }
        }

        private void collectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void receiptWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void posTerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPosTerminal.GetPosTerminal == null)
            {
                frmPosTerminal.GetPosTerminal = new frmPosTerminal();
                frmPosTerminal.GetPosTerminal.MdiParent = this;
                frmPosTerminal.GetPosTerminal.Show();
            }
            else
            {
                frmPosTerminal.GetPosTerminal.Focus();
            }
        }

        private void zeroStockProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product-Wise Zero Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 64;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void minusStockProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product-Wise Minus Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 65;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void openingStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product-Wise Opening Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 66;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void salesmanWiseProductSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productWisePurchaseSalesStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void departmentWisePurchaseSalesStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productwiseStockDetailsGivenDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product-wise Stock Details(Given Date)";
                frmSalesInquary.GetSalesInquary.intRepOption = 420;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void minusStockProductDetailsSupplierWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product-Wise Minus Stock Details (Supplier wise)";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 67;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productToBeReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductToBeReturn.GetProductToBeReturn == null)
            {
                frmProductToBeReturn.GetProductToBeReturn = new frmProductToBeReturn();
                frmProductToBeReturn.GetProductToBeReturn.MdiParent = this;
                frmProductToBeReturn.GetProductToBeReturn.opt = "TOR";
                frmProductToBeReturn.GetProductToBeReturn.Show();
            }
            else
            {
                frmProductToBeReturn.GetProductToBeReturn.Focus();
            }
        }

        private void productToBeReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product To Be Return Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 220;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void productToBeReturnDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Prouct To Be Return Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 68;
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productToBeReturnDetailsSupplierWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            //{
            //    frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
            //    frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
            //    frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Prouct To Be Return Details (Supplier Wise)";
            //    frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            //    frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 69;
            //}
            //else
            //{
            //    frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            //}

            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product To Be Return Details (Supplier Wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 430;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentwiseStockValuationGivenDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Department-wise Stock Valuation(Given Date)";
                frmSalesInquary.GetSalesInquary.intRepOption = 421;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWisePurchaseSalesStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showroomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Showroom Product Request Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 70;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void zeroStockProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product-Wise Zero Stock Details (Supplier wise)";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 71;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productWiseDiscountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierPaymentSetOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPaymentSetOff.GetPaymentSetOff == null)
            {
                frmPaymentSetOff.GetPaymentSetOff = new frmPaymentSetOff("SUP");
                frmPaymentSetOff.GetPaymentSetOff.MdiParent = this;
                frmPaymentSetOff.GetPaymentSetOff.Show();
            }
            else
            {
                frmPaymentSetOff.GetPaymentSetOff.Focus();
            }
        }

        private void supplierPaymentSetOffNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Payment Set Off Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 221;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierPaymentSetOffSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Payment Set Off Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 222;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerInvoiceSetOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierPaymentSetOffGRNNoWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Payment Set Off (GRN No wise)";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 223;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerPaymentSetOffNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerInvoiceSetOffSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerInvoiceSetOffINVNoWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void systemLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "System Log Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 307;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void issuedPostDatedChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Issued Post Dated Cheques";
                frmSalesInquary.GetSalesInquary.intRepOption = 308;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void receivedPostDatedChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Received Post Dated Cheques";
                frmSalesInquary.GetSalesInquary.intRepOption = 309;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void quotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmQuotation.GetQuotation == null)
            {
                frmQuotation.GetQuotation = new frmQuotation();
                frmQuotation.GetQuotation.MdiParent = this;
                frmQuotation.GetQuotation.Show();
            }
            else
            {
                frmQuotation.GetQuotation.Focus();
            }
        }

        private void quotationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Quotation";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 227;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierWiseGoodReceivedNoteSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Supplier wise Good Received Note Summary";
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 72;
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }

        }

        private void salesmanWiseSalesPerformanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jurnalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 Journal = new Form1();
            ////if (frmJurnal.GetJurnal == null)
            ////{
            ////    frmJurnal.GetJurnal = new frmJurnal();
            ////    frmJurnal.GetJurnal.MdiParent = this;
            ////    frmJurnal.GetJurnal.Show();
            ////}
            ////else
            ////{
            ////    frmJurnal.GetJurnal.Focus();
            ////}
            //Journal.MdiParent = this;
            //Journal.Show();
        }

        private void productPriceMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductPriceMaster.GetProductPriceMaster == null)
            {
                frmProductPriceMaster.GetProductPriceMaster = new frmProductPriceMaster("", "");
                frmProductPriceMaster.GetProductPriceMaster.MdiParent = this;
                frmProductPriceMaster.GetProductPriceMaster.Show();
                frmProductPriceMaster.GetProductPriceMaster.txtProductCode.Focus();
            }
            else
            {
                frmProductPriceMaster.GetProductPriceMaster.Focus();
            }
        }

        private void productPriceMaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Price Master Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 9;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void salesDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesDownload.GetSalesDownload == null)
            {
                frmSalesDownload.GetSalesDownload = new frmSalesDownload();
                frmSalesDownload.GetSalesDownload.MdiParent = this;
                frmSalesDownload.GetSalesDownload.Show();
            }
            else
            {
                frmSalesDownload.GetSalesDownload.Focus();
            }
        }

        private void customerDetailsRegularToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerWiseProductSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creditorStatementGivenDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Creditor Statement (Given Date)";
                frmSalesInquary.GetSalesInquary.intRepOption = 423;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void debtorStatementGivenDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Debtor Statement (Given Date)";
                frmSalesInquary.GetSalesInquary.intRepOption = 424;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void debtorBalanceReportRegularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Debtors Balance Report (Regular)";
                frmSalesInquary.GetSalesInquary.intRepOption = 425;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void packetingProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void productLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductLink.GetProductLink == null)
            {
                frmProductLink.GetProductLink = new frmProductLink();
                frmProductLink.GetProductLink.MdiParent = this;
                frmProductLink.GetProductLink.Show();
            }
            else
            {
                frmProductLink.GetProductLink.Focus();
            }
        }

        private void linkedProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Linked Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 11;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void priceChangeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allowProductDetailsChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You want Modify Product Details. ", "Product Details", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsLibrary.LoginManager.ProductDetChange = true;

                FileStream fileStream = new FileStream(@"..\LoginInfo.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("'Product Details Change'" + "'Location :' " + LoginManager.Location + " 'User Name :' " + LoginManager.UserName + " 'Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now));
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
            }

        }

        private void creditCustmerSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void temporaryCustomerSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSettings.GetSettings == null)
            {
                frmSettings.GetSettings = new frmSettings();
                frmSettings.GetSettings.MdiParent = this;
                frmSettings.GetSettings.Show();
            }
            else
            {
                frmSettings.GetSettings.Focus();
            }
        }

        private void MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are sure you want to Exit the System?", "Onimta Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                clsPosDisplay.PrintCounterClosedDisplay();
                e.Cancel = true;
            }
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBackupRestore.GetBackupRestore == null)
            {
                frmBackupRestore.GetBackupRestore = new frmBackupRestore();
                frmBackupRestore.GetBackupRestore.MdiParent = this;
                frmBackupRestore.GetBackupRestore.Show();
            }
            else
            {
                frmBackupRestore.GetBackupRestore.Focus();
            }
        }

        private void purchaseScheduleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Purchase Schedule Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 429;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void debtorOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDebtorBalance.AfrmobjDebtors == null)
            {
                frmDebtorBalance.AfrmobjDebtors = new frmDebtorBalance();
                frmDebtorBalance.AfrmobjDebtors.MdiParent = this;
                frmDebtorBalance.AfrmobjDebtors.Iid = "CUR";
                frmDebtorBalance.AfrmobjDebtors.Show();
            }
            else
            {
                frmDebtorBalance.AfrmobjDebtors.Focus();
            }
        }

        private void lockedProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmProductToBeReturn.GetProductToBeReturn == null)
                {
                    frmProductToBeReturn.GetProductToBeReturn = new frmProductToBeReturn();
                    frmProductToBeReturn.GetProductToBeReturn.MdiParent = this;
                    frmProductToBeReturn.GetProductToBeReturn.Text = "Opening Stock Add";
                    frmProductToBeReturn.GetProductToBeReturn.opt = "OPS";
                    frmProductToBeReturn.GetProductToBeReturn.Show();
                }
                else
                {
                    frmProductToBeReturn.GetProductToBeReturn.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void locationWiseStockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Location Wise Product Stock Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 74;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void locationWiseDepartmentStockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Location Wise Department Stock Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 75;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void locationWiseCategoryStockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Location Wise Category Stock Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 76;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void locationWiseSupplierStockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Location Wise Supplier Stock Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 77;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location Wise Product Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 431;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location Wise Department Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 432;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void categoryWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location Wise Category Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 433;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location Wise Supplier Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 434;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productCombinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBulkProductCombination.GetBulkProductCombination == null)
            {
                frmBulkProductCombination.GetBulkProductCombination = new frmBulkProductCombination();
                frmBulkProductCombination.GetBulkProductCombination.MdiParent = this;
                frmBulkProductCombination.GetBulkProductCombination.Show();
            }
            else
            {
                frmBulkProductCombination.GetBulkProductCombination.Focus();
            }
        }

        private void creditorOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDebtorBalance.AfrmobjDebtors == null)
            {
                frmDebtorBalance.AfrmobjDebtors = new frmDebtorBalance();
                frmDebtorBalance.AfrmobjDebtors.MdiParent = this;
                frmDebtorBalance.AfrmobjDebtors.Iid = "SUP";
                frmDebtorBalance.AfrmobjDebtors.Text = "Creditor Opening Balance";
                frmDebtorBalance.AfrmobjDebtors.Show();
            }
            else
            {
                frmDebtorBalance.AfrmobjDebtors.Focus();
            }
        }

        private void supplierWiseLocationStockAndSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSalesInquary.GetSalesInquary == null)
                {
                    frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                    frmSalesInquary.GetSalesInquary.MdiParent = this;
                    frmSalesInquary.GetSalesInquary.Text = "Supplier wise Location Stock and  Sales";
                    frmSalesInquary.GetSalesInquary.intRepOption = 435;
                    frmSalesInquary.GetSalesInquary.Show();
                }
                else
                {
                    frmSalesInquary.GetSalesInquary.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void productPurchaseSalesProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Purchase/Sales/Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 400;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentPurchaseSalesProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Department Purchase/Sales/Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 401;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void categoryPurchaseSalesProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Category Purchase/Sales/Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 402;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierPurchaseSalesProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier Purchase/Sales/Profit Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 403;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productWisePurchaseSalesStockReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Purchase/Sales/Stock Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 418;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentWisePurchaseSalesStockReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Department wise Purchase/Sales/Stock Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 419;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWisePurchaseSalesStockReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Purchase/Sales/Stock Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 422;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productBinCardToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void profitableMovingProductsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption 409 Profitable Moving Product
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Moving Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 409;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void fastMovingProductReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption 412 Fast Moving Product
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Fast Moving Product Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 412;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void fastMovingProductReportSupplierWiseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption 412 Fast Moving Product
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Fast Moving Product Report (Supplier wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 413;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void slowMovingProductReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Slow Moving Product Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 417;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWiseNonMovingReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Non Moving Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 416;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productWiseReOrderLevelReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Wise Re-Order Level Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 410;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWiseReOrderLevelReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier Wise Re-Order Level Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 411;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productDetailsChangeReportDateWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (frmAnalyse.GetAnalyse == null)
            {
                frmAnalyse.GetAnalyse = new frmAnalyse();
                frmAnalyse.GetAnalyse.MdiParent = this;
                frmAnalyse.GetAnalyse.Text = "Sales Comparison Report";
                frmAnalyse.GetAnalyse.intRepOption = 1300;
                frmAnalyse.GetAnalyse.Show();
            }
            else
            {
                frmAnalyse.GetAnalyse.Focus();
            }
             * */
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Details Change Report(Date wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 414;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }


        private void productDetailsChangeReportProductWiseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Details Change Report(Product wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 415;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void priceChangeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Price Change Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 426;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void advanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void openingStockDetailsNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = MainClass.mdi;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 232;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmChangePassword.GetChangePassword == null)
            {
                frmChangePassword.GetChangePassword = new frmChangePassword();
                frmChangePassword.GetChangePassword.MdiParent = this;
                frmChangePassword.GetChangePassword.Show();
            }
            else
            {
                frmChangePassword.GetChangePassword.Focus();
            }
        }

        private void productWiseSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 100;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void departmentWiseSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Department wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 101;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void categoryWiseSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Category wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 102;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWiseSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 103;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void brandWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Brand wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 104;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void salesmanWiseSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Salesman wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 110;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void salesmanWiseProductSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Salesman wise Product Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 116;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void salesmanWiseSalesPerformanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Salesman wise Sales Performance";
                frmSalesInquary.GetSalesInquary.intRepOption = 118;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void customerWiseProductSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Customer wise Product Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 119;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void creditCustmerSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Credit Customer Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 427;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void temporaryCustomerSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Temporary Customer Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 428;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dailySalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Daily Sales Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 106;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void monthlySalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Monthly Sales Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 105;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void hourlySalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Hourly Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 113;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void salesAnalyseReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmAnalyse.GetAnalyse == null)
            {
                frmAnalyse.GetAnalyse = new frmAnalyse();
                frmAnalyse.GetAnalyse.MdiParent = this;
                frmAnalyse.GetAnalyse.Text = "Sales Analyse";
                frmAnalyse.GetAnalyse.intRepOption = 1000;
                frmAnalyse.GetAnalyse.Show();
            }
            else
            {
                frmAnalyse.GetAnalyse.Focus();
            }
        }

        private void salesComparisonReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAnalyse.GetAnalyse == null)
            {
                frmAnalyse.GetAnalyse = new frmAnalyse();
                frmAnalyse.GetAnalyse.MdiParent = this;
                frmAnalyse.GetAnalyse.Text = "Sales Comparison Report";
                frmAnalyse.GetAnalyse.intRepOption = 1300;
                frmAnalyse.GetAnalyse.Show();
            }
            else
            {
                frmAnalyse.GetAnalyse.Focus();
            }
        }

        private void posSalesSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Pos Sales Summary Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 108;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dailyCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Daily Collection Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 114;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void receiptWiseSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Receipt wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 115;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void exchangeProductReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Exchange Product Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 109;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productWiseDiscountReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300, Analyse 400
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Discount Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 117;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentSalesSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Sales Summary Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 111;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentHourlySalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Hourly Sales";
                frmSalesInquary.GetSalesInquary.intRepOption = 112;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void allTransactionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "All Transaction Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 444;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void realTimeStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Real Time Products' Stock Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 445;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productDiscardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductDiscard.ProductDiscard == null)
            {
                frmProductDiscard.ProductDiscard = new frmProductDiscard();
                frmProductDiscard.ProductDiscard.MdiParent = this;
                frmProductDiscard.ProductDiscard.Show();
            }
            else
            {
                frmProductDiscard.ProductDiscard.Focus();
            }
        }

        private void dfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Cheque Reconciliation Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 218;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void chequeReconcilationSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Cheque Reconciliation Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 228;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Customer wise Return Cheque Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 442;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void supplierWiseReturnChequeDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Return Cheque Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 441;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productDicardNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Discard Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 229;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void productDicardSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Discard Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 230;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierWiseProductDicardDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier wise Product Discard Detail Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 443;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void locationWiseDepartmentSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location wise Department wise Sale Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 436;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void locationWiseDepartmentWiseSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location wise Category wise Sale Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 437;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void locationWiseSupplierWiseSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location Supplier wise Sale Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 438;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productWiseSpecialDiscountDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productWiseSpecialDiscountDetailReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Special Discount Details Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 446;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void freeIssuedProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Free Issued Product Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 439;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productBinCardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption 404 Bin card
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Bin Card";
                frmSalesInquary.GetSalesInquary.intRepOption = 404;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void productCombinationDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Combination Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 79;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void pToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Supplier Purchase Schedule";
                frmSalesInquary.GetSalesInquary.intRepOption = 447;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Show();
            }
        }

        private void locationWiseProductOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Location Wise Product Order Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 448;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void goodReceivedNoteWithInvoiceToolStrip_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Goods Received Note Details (With Invoice No)";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 2020;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void productAbstractingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void abstractRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productAbstractingToolStripMenuItem2_Click(object sender, EventArgs e)
        {


        }

        private void abstractedProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Abstract Product Stock";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 82;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void purchasingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmPurchase.Purchase == null)
            {
                frmPurchase.Purchase = new frmPurchase();
                frmPurchase.Purchase.MdiParent = this;
                frmPurchase.Purchase.Text = "Puchasing";
                frmPurchase.Purchase.Show();
            }
            else
            {
                frmPurchase.Purchase.Focus();
            }
        }

        private void puchasingBillDetialsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Purchasing Bill Detials Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 449;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void toBeDoenGRNSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "To Be Finalized GRN Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 450;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void walpaper1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walpaper("Wal1");
        }

        private void walpaper2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walpaper("Wal2");
        }

        private void walpaper3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walpaper("Wal3");
        }

        void walpaper(string setwal)
        {
            Inventory.Properties.Settings.Default.Back_Image = setwal;
            Inventory.Properties.Settings.Default.Save();
            // loop will be used in the future :-)
            try
            {
                #region Old
                //if (setwal == "Wal1")
                //{
                //    this.BackgroundImage = global::Inventory.Properties.Resources.Wal1;
                //}
                //else if (setwal == "Wal2")
                //{
                //    this.BackgroundImage = global::Inventory.Properties.Resources.Wal2;
                //}
                //else if (setwal == "Wal3")
                //{
                //    this.BackgroundImage = global::Inventory.Properties.Resources.Wal3;
                //}
                //else if (setwal == "Wal4")
                //{
                //    this.BackgroundImage = global::Inventory.Properties.Resources.Wal4;
                //}
                //else if (setwal == "Wal5")
                //{
                //    this.BackgroundImage = global::Inventory.Properties.Resources.Wal15;
                //}
                #endregion

                if (setwal == "Wal1")
                {
                    this.BackgroundImage = Image.FromFile(@"..\Wallpaper\Wal1.jpg");
                }
                else if (setwal == "Wal2")
                {
                    this.BackgroundImage = Image.FromFile(@"..\Wallpaper\Wal2.jpg");
                }
                else if (setwal == "Wal3")
                {
                    this.BackgroundImage = Image.FromFile(@"..\Wallpaper\Wal3.jpg");
                }
                else if (setwal == "Wal4")
                {
                    this.BackgroundImage = Image.FromFile(@"..\Wallpaper\Wal4.jpg");
                }
                else if (setwal == "Wal5")
                {
                    this.BackgroundImage = Image.FromFile(@"..\Wallpaper\Wal5.jpg");
                }
                BackgroundImageLayout = ImageLayout.Stretch;
                this.Refresh();
            }
            catch
            {
                this.BackgroundImage = global::Inventory.Properties.Resources.blueswirly;
            }
        }

        private void walpaper4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walpaper("Wal4");
        }

        private void walpaper5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walpaper("Wal5");
        }

        private void scaleDataUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmScaleUpdate.frmObjScaleUp == null)
            {
                frmScaleUpdate.frmObjScaleUp = new frmScaleUpdate();
                frmScaleUpdate.frmObjScaleUp.MdiParent = this;
                frmScaleUpdate.frmObjScaleUp.Show();
            }
            else
            {
                frmScaleUpdate.frmObjScaleUp.Focus();
            }
        }

        private void uploadDataToAccountSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAccountUplaod.AccountUp == null)
            {
                frmAccountUplaod.AccountUp = new frmAccountUplaod();
                frmAccountUplaod.AccountUp.MdiParent = this;
                frmAccountUplaod.AccountUp.Show();
            }
            else
            {
                frmAccountUplaod.AccountUp.Focus();
            }
        }

        private void specialPromotionSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.intRepOption = 451;
                frmSalesInquary.GetSalesInquary.Text = "Special Promotion Sales Report";
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void systemToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void locationWiseOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Location wise Order Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 83;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void supplierWiseLocationWiseOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Supplier wise Location wise Order Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 84;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void displayReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDisplayReceipt.GetDisplayReceipt == null)
            {
                frmDisplayReceipt.GetDisplayReceipt = new frmDisplayReceipt();
                frmDisplayReceipt.GetDisplayReceipt.MdiParent = this;
                frmDisplayReceipt.GetDisplayReceipt.Show();
            }
            else
            {
                frmDisplayReceipt.GetDisplayReceipt.Focus();
            }
        }

        private void productPriceLevelDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductPriceLevelDetails._getFrmPriceLevelDet == null)
            {
                frmProductPriceLevelDetails._getFrmPriceLevelDet = new frmProductPriceLevelDetails("", "");
                frmProductPriceLevelDetails._getFrmPriceLevelDet.MdiParent = this;
                frmProductPriceLevelDetails._getFrmPriceLevelDet.Show();
            }
            else
            {
                frmProductPriceLevelDetails._getFrmPriceLevelDet.Focus();
            }
        }

        private void specialDiscountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailySalesSummaryDetailWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCustomerReturnCASH.GetCashReturn == null)
            {
                frmCustomerReturnCASH.GetCashReturn = new frmCustomerReturnCASH();
                frmCustomerReturnCASH.GetCashReturn.MdiParent = this;
                frmCustomerReturnCASH.GetCashReturn.Show();
            }
            else
            {
                frmCustomerReturnCASH.GetCashReturn.Focus();
            }
        }

        private void cashReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Cash Refund Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 235;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void cashReturnSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Cash Refund Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 236;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void cashRefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCashRefund._getCashRefund == null)
            {
                frmCashRefund._getCashRefund = new frmCashRefund();
                frmCashRefund._getCashRefund.MdiParent = this;
                frmCashRefund._getCashRefund.Show();
            }
            else
            {
                frmCashRefund._getCashRefund.Focus();
            }
        }

        private void dailyColloectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void specialDiscountReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }



        private void cashINOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashINOUTNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashINOUTSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerWiseDailyBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Customer wise daily balance";
                frmSalesInquary.GetSalesInquary.intRepOption = 454;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dailyCollectionSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Daily Collection Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 453;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }


        }

        private void dataDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDataDownload.GetSalesDownload == null)
            {
                frmDataDownload.GetSalesDownload = new frmDataDownload();
                frmDataDownload.GetSalesDownload.MdiParent = this;
                frmDataDownload.GetSalesDownload.Show();
            }
            else
            {
                frmDataDownload.GetSalesDownload.Focus();
            }
        }

        private void expancesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expencesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expencesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bankDepositWithdrowalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expenseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expenceStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void depositDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void withdrawalsDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dayBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierCustomerSetOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDebCredSetOff.GetPaymentSetOff == null)
            {
                frmDebCredSetOff.GetPaymentSetOff = new frmDebCredSetOff();
                frmDebCredSetOff.GetPaymentSetOff.MdiParent = this;
                frmDebCredSetOff.GetPaymentSetOff.Show();
            }
            else
            {
                frmDebCredSetOff.GetPaymentSetOff.Focus();
            }
        }

        private void supplierCustomerSetOffNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier/Customer Set Off Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 241;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void ledgerBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shipmentRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmShipment._objShip == null)    //intRepOption Creditor
            {
                frmShipment._objShip = new frmShipment();
                frmShipment._objShip.MdiParent = this;
                frmShipment._objShip.Show();
            }
            else
            {
                frmShipment._objShip.Focus();
            }
        }

        private void batchPriceMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBatchPriceChange._objBatchPriceChange == null)
            {
                frmBatchPriceChange._objBatchPriceChange = new frmBatchPriceChange("", "");
                frmBatchPriceChange._objBatchPriceChange.MdiParent = this;
                frmBatchPriceChange._objBatchPriceChange.Show();
                frmBatchPriceChange._objBatchPriceChange.txtProductCode.Focus();
            }
            else
            {
                frmBatchPriceChange._objBatchPriceChange.Focus();
            }
        }

        private void batchWiseStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product- Wise Batch Wise Stock Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 85;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void batchWiseExpireDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Batch Wise Expire Details";
                frmSalesInquary.GetSalesInquary.intRepOption = 459;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void debtorReminderLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Debtor Remind Letter";
                frmSalesInquary.GetSalesInquary.intRepOption = 460;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }


        public void CustomPaperPrint(CrystalDecisions.CrystalReports.Engine.ReportDocument VReport, string strPrinter, string strCustomPaper, int NoOfCopies)
        {
            try
            {
                //Onimta Set Paper size INV.................. 
                PrinterSettings settings = new PrinterSettings();
                PrintDocument printDoc = new PrintDocument();
                System.Drawing.Printing.PaperSize pkSize = new System.Drawing.Printing.PaperSize();

                int rawKind = 0;
                if (strCustomPaper != "" && strCustomPaper != "NO")
                {

                    printDoc.PrinterSettings.PrinterName = strPrinter;
                    if (MDI.InvPaperType == 0)
                    {
                        for (int a = 0; a < printDoc.PrinterSettings.PaperSizes.Count; a++)
                        {
                            if (printDoc.PrinterSettings.PaperSizes[a].PaperName == strCustomPaper)
                            {
                                rawKind = (int)printDoc.PrinterSettings.PaperSizes[a].GetType().GetField("kind", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(printDoc.PrinterSettings.PaperSizes[a]);
                                MDI.InvPaperType = rawKind;
                            }
                        }
                    }
                    else
                    {
                        rawKind = MDI.InvPaperType;
                    }
                }



                if (VReport != null)
                {
                    if (strPrinter != "")
                    {
                        VReport.PrintOptions.PrinterName = strPrinter;
                        VReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                    }
                    else
                    {
                        VReport.PrintOptions.PrinterName = settings.PrinterName;
                    }


                    //............................................

                    for (int i = 0; i < NoOfCopies; i++) // print bill copies according to settings
                    {
                        VReport.PrintToPrinter(1, false, 0, 0);
                    }


                }


                VReport.Dispose();
                VReport = null;

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                //If Error Occured Print In Default Printer
                DefaultPrint(VReport);
            }
        }

        public void DefaultPrint(CrystalDecisions.CrystalReports.Engine.ReportDocument VReport)
        {
            try
            {
                //Onimta Set Paper size INV.................. 
                PrinterSettings settings = new PrinterSettings();
                PrintDocument printDoc = new PrintDocument();

                if (VReport != null)
                {
                    VReport.PrintOptions.PrinterName = settings.PrinterName;
                    //VReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                    //............................................

                    VReport.PrintToPrinter(1, false, 0, 0);

                }

                VReport.Dispose();
                VReport = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void printerSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPrinterSettings._Obj_PrinterSettings == null)
            {
                frmPrinterSettings._Obj_PrinterSettings = new frmPrinterSettings();
                frmPrinterSettings._Obj_PrinterSettings.MdiParent = MainClass.mdi;
                frmPrinterSettings._Obj_PrinterSettings.Show();
            }
            else
            { frmPrinterSettings._Obj_PrinterSettings.Focus(); }
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProduct.GetProduct == null)
            {
                frmProduct.GetProduct = new frmProduct(null);
                frmProduct.GetProduct.MdiParent = this;
                frmProduct.GetProduct.Show();
            }
            else
            {
                frmProduct.GetProduct.Focus();
            }
        }

        private void abstractRegistreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBulkProductCombination.GetBulkProductCombination == null)
            {
                frmBulkProductCombination.GetBulkProductCombination = new frmBulkProductCombination();
                frmBulkProductCombination.GetBulkProductCombination.MdiParent = this;
                frmBulkProductCombination.GetBulkProductCombination.Text = "Product Abstracting Register";
                frmBulkProductCombination.GetBulkProductCombination.Show();
            }
            else
            {
                frmBulkProductCombination.GetBulkProductCombination.Focus();
            }
        }

        private void bundlingRegistreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductPacketReg.GetPacketingItemSelect == null)
            {
                frmProductPacketReg.GetPacketingItemSelect = new frmProductPacketReg();
                frmProductPacketReg.GetPacketingItemSelect.MdiParent = this;
                frmProductPacketReg.GetPacketingItemSelect.Show();
            }
            else
            {
                frmProductPacketReg.GetPacketingItemSelect.Focus();
            }
        }

        private void productAbstractToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bundlingRegistreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmProductBundle.ProductBundle == null)
            {
                frmProductBundle.ProductBundle = new frmProductBundle();
                frmProductBundle.ProductBundle.MdiParent = this;
                frmProductBundle.ProductBundle.Show();
            }
            else
            {
                frmProductBundle.ProductBundle.Focus();
            }
        }

        private void pToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void productBundlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductBundleIssue.GetBundleIssue == null)
            {
                frmProductBundleIssue.GetBundleIssue = new frmProductBundleIssue();
                frmProductBundleIssue.GetBundleIssue.MdiParent = this;
                frmProductBundleIssue.GetBundleIssue.Show();
            }
            else
            {
                frmProductBundleIssue.GetBundleIssue.Focus();
            }
        }

        private void productAbstractToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmBulkProdIssue.BulkProdIssue == null)
            {
                frmBulkProdIssue.BulkProdIssue = new frmBulkProdIssue();
                frmBulkProdIssue.BulkProdIssue.MdiParent = this;
                frmBulkProdIssue.BulkProdIssue.Show();
            }
            else
            {
                frmBulkProdIssue.BulkProdIssue.Focus();
            }
        }

        private void productPacketingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmProductPacketing.GetPacketingProduct == null)
            {
                frmProductPacketing.GetPacketingProduct = new frmProductPacketing();
                frmProductPacketing.GetPacketingProduct.MdiParent = this;
                frmProductPacketing.GetPacketingProduct.Show();
            }
            else
            {
                frmProductPacketing.GetPacketingProduct.Focus();
            }
        }

        private void cashINOUTToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmGiftVoucher.GetGiftVoucher == null)
            {
                frmGiftVoucher.GetGiftVoucher = new frmGiftVoucher();
                frmGiftVoucher.GetGiftVoucher.MdiParent = this;
                frmGiftVoucher.GetGiftVoucher.Show();
            }
            else
            {
                frmGiftVoucher.GetGiftVoucher.Focus();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmGiftVoucherPrint.GetBarcode == null)
            {
                frmGiftVoucherPrint.GetBarcode = new frmGiftVoucherPrint();
                frmGiftVoucherPrint.GetBarcode.MdiParent = this;
                frmGiftVoucherPrint.GetBarcode.Show();
            }
            else
            {
                frmGiftVoucherPrint.GetBarcode.Focus();
            }
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmGiftVoucherIssue.GetForm == null)
            {
                frmGiftVoucherIssue.GetForm = new frmGiftVoucherIssue();
                frmGiftVoucherIssue.GetForm.MdiParent = this;
                frmGiftVoucherIssue.GetForm.Show();
            }
            else
            {
                frmGiftVoucherIssue.GetForm.Focus();
            }
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSMS.GetSMS == null)
            {
                frmSMS.GetSMS = new frmSMS();
                frmSMS.GetSMS.MdiParent = this;
                frmSMS.GetSMS.Show();
            }
            else
            {
                frmSMS.GetSMS.Focus();
            }
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCustomer.GetCustomer == null)
            {
                frmCustomer.GetCustomer = new frmCustomer();
                frmCustomer.GetCustomer.MdiParent = this;
                frmCustomer.GetCustomer.Show();
            }
            else
            {
                frmCustomer.GetCustomer.Focus();
            }
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripCustomer_Click(object sender, EventArgs e)
        {
            if (Settings.Default.CRM)
            {
                if (frmCustomer.GetCustomer == null)
                {
                    frmCustomer.GetCustomer = new frmCustomer();
                    frmCustomer.GetCustomer.MdiParent = this;
                    frmCustomer.GetCustomer.Show();
                }
                else
                { frmCustomer.GetCustomer.Focus(); }
            }
            else
            {
                if (frmAccounts.GetAccount == null)
                {
                    frmAccounts.GetAccount = new frmAccounts();
                    frmAccounts.GetAccount.MdiParent = this;
                    frmAccounts.GetAccount.Show();
                }
                else
                { frmAccounts.GetAccount.Focus(); }
            }
        }

        private void topUpCardRechargeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerVisitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                //clsInvApiUpload ObjUpload = new clsInvApiUpload();
                //ObjUpload.UpdateInvToApi(false);

                ////Customer Point Redeem SMS-----------
                //if (Settings.Default.CRMMSg == true)
                //{
                //    clsCommon ObjComman = new clsCommon();
                //    ObjComman.SqlStatement = "SELECT Receipt_No FROM dbo.Pos_CustomerPoints WHERE   Loca='" + LoginManager.LocaCode + "' AND MSG=0";
                //    ObjComman.GetDsApi();
                //    DataSet Ds = new DataSet();
                //    Ds = ObjComman.Ads;
                //    frmWholeSaleInvoice Inv = new frmWholeSaleInvoice();
                //    if (Ds.Tables[0].Rows.Count > 0)
                //    {
                //        foreach (DataRow row in Ds.Tables[0].Rows)
                //        {
                //            Inv.SendLoyalityMSG(row[0].ToString());
                //        }
                //    }
                //}
                //-----------------------
            }
            catch (Exception ex)
            {
                // clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (!backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.RunWorkerAsync(100);
            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void stockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void discountReportItemwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void receivedOnAccToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashDenominationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void noteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cDMNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sueryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cDMSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonROA_Click(object sender, EventArgs e)
        {
            if (frmDenomination.GetDenomination == null)
            {
                frmDenomination.GetDenomination = new frmDenomination();
                frmDenomination.GetDenomination.Text = "Received On Account";
                frmDenomination.GetDenomination.MdiParent = MainClass.mdi;
                frmDenomination.GetDenomination.Show();

            }
            else
            {
                frmDenomination.GetDenomination.Focus();
            }
        }

        private void toolStripButtonCDNM_Click(object sender, EventArgs e)
        {
            if (frmDenomination.GetDenomination == null)
            {
                frmDenomination.GetDenomination = new frmDenomination();
                frmDenomination.GetDenomination.Text = "Cash Denomination";
                frmDenomination.GetDenomination.MdiParent = MainClass.mdi;
                frmDenomination.GetDenomination.Show();

            }
            else
            {
                frmDenomination.GetDenomination.Focus();
            }
        }

        private void expenseTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expenseTypesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmExpense.getExpense == null)
            {
                frmExpense.getExpense = new frmExpense();
                frmExpense.getExpense.MdiParent = this;
                frmExpense.getExpense.Text = "Expenses";
                frmExpense.getExpense.Show();
            }
            else
            {
                frmExpense.getExpense.Focus();
            }
        }

        private void expenseSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption 404 Expences Summary
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Expenses Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 455;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void expenceStatementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption 404 Expences Summary
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Expenses Statement";
                frmSalesInquary.GetSalesInquary.intRepOption = 456;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void expenseEnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmEnterBill.getEnterBill == null)
            {
                frmEnterBill.getEnterBill = new frmEnterBill();
                frmEnterBill.getEnterBill.MdiParent = this;
                frmEnterBill.getEnterBill.Show();
            }
            else
            {
                frmEnterBill.getEnterBill.Focus();
            }
        }

        private void expenseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmExpenseReturn.getEnterBill == null)
            {
                frmExpenseReturn.getEnterBill = new frmExpenseReturn();
                frmExpenseReturn.getEnterBill.MdiParent = this;
                frmExpenseReturn.getEnterBill.Show();
            }
            else
            {
                frmExpenseReturn.getEnterBill.Focus();
            }
        }

        private void receiptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.Default.RecAmtFirst == true) // If Amount First 
            {
                if (frmInvoiceCustomerPayment.GetCustomerPayment == null)
                {
                    frmInvoiceCustomerPayment.GetCustomerPayment = new frmInvoiceCustomerPayment("");
                    frmInvoiceCustomerPayment.GetCustomerPayment.MdiParent = this;
                    frmInvoiceCustomerPayment.GetCustomerPayment.Show();
                }
                else
                {
                    frmInvoiceCustomerPayment.GetCustomerPayment.Focus();
                }
            }
            else
            {
                if (frmCustomerPayment.GetCustomerPayment == null)
                {
                    frmCustomerPayment.GetCustomerPayment = new frmCustomerPayment("");
                    frmCustomerPayment.GetCustomerPayment.MdiParent = this;
                    frmCustomerPayment.GetCustomerPayment.Show();
                }
                else
                {
                    frmCustomerPayment.GetCustomerPayment.Focus();
                }
            }
        }

        private void customerInvoiceSetOffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmPaymentSetOff.GetPaymentSetOff == null)
            {
                frmPaymentSetOff.GetPaymentSetOff = new frmPaymentSetOff("CUS");
                frmPaymentSetOff.GetPaymentSetOff.MdiParent = this;
                frmPaymentSetOff.GetPaymentSetOff.Show();
            }
            else
            {
                frmPaymentSetOff.GetPaymentSetOff.Focus();
            }
        }

        private void advanceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmAdvance.AobjAdvance != null)
            {
                frmAdvance.AobjAdvance.Close();
            }
            frmAdvance.AobjAdvance = new frmAdvance("", "CUS");
            frmAdvance.AobjAdvance.MdiParent = this;
            frmAdvance.AobjAdvance.Text = "Advance";
            frmAdvance.AobjAdvance.Show();
        }

        private void bankDepositWithdrowalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmBankDeposit.getBankDiposit == null)
            {
                frmBankDeposit.getBankDiposit = new frmBankDeposit();
                frmBankDeposit.getBankDiposit.MdiParent = this;
                frmBankDeposit.getBankDiposit.Text = "Bank Deposit";
                frmBankDeposit.getBankDiposit.Show();
            }
            else
            {
                frmBankDeposit.getBankDiposit.Focus();
            }
        }

        private void cashINOUTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmCashOut.GetCashOut == null)
            {
                frmCashOut.GetCashOut = new frmCashOut();
                frmCashOut.GetCashOut.MdiParent = this;
                frmCashOut.GetCashOut.Text = "Cash IN/OUT Details";
                frmCashOut.GetCashOut.Show();
            }
            else
            {
                frmCashOut.GetCashOut.Focus();
            }
        }

        private void topUpCardRechargeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmCardTopup.GetForm == null)
            {
                frmCardTopup.GetForm = new frmCardTopup();
                frmCardTopup.GetForm.MdiParent = this;
                frmCardTopup.GetForm.Show();
            }
            else
            {
                frmCardTopup.GetForm.Focus();
            }
        }

        private void receivedOnAccToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmDenomination.GetDenomination == null)
            {
                frmDenomination.GetDenomination = new frmDenomination();
                frmDenomination.GetDenomination.Text = "Received On Account";
                frmDenomination.GetDenomination.MdiParent = MainClass.mdi;
                frmDenomination.GetDenomination.Show();

            }
            else
            {
                frmDenomination.GetDenomination.Focus();
            }
        }

        private void cashDenominationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmDenomination.GetDenomination == null)
            {
                frmDenomination.GetDenomination = new frmDenomination();
                frmDenomination.GetDenomination.Text = "Cash Denomination";
                frmDenomination.GetDenomination.MdiParent = MainClass.mdi;
                frmDenomination.GetDenomination.Show();

            }
            else
            {
                frmDenomination.GetDenomination.Focus();
            }
        }

        private void productPacketingNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Packeting Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 219;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void abstractedProductNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Abstract Product Report";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 233;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void receiptNoteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Receipt Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 206;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void receiptSummaryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Receipt Summary Details";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 209;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void advanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void depositDetailsReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.Text = "Deposit Details Report";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 239;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void withdrawalsDetailsReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.Text = "Withdrawals Details Report";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 240;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void rOANoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Received On Account Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 243;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void rOASummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Received on Account Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 244;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void cDMNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Cash Denomination Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 245;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void cDMSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Cash Denomination Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 246;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void cashINOUTNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.Text = "Cash IN/OUT Note";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 237;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void cashINOUTSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.Text = "Cash IN/OUT Summary";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 238;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerInvoiceSetOffNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Invoice Set Off Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 224;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerInvoiceSetOffSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Invoice Set Off Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 225;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void customerInvoiceSetOffINVNoWiseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Invoice Set Off (INV No wise)";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 226;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void discountReportItemWiseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Special Discount Report(Itemwise)";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 242;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void discountReportInvoiceWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Special Discount Report";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 234;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void dailySalesCollectionSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Daily Sales Summary - Collection";
                frmSalesInquary.GetSalesInquary.intRepOption = 452;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dayBookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Day Book";
                frmSalesInquary.GetSalesInquary.intRepOption = 457;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void ledgerBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Ledger Book";
                frmSalesInquary.GetSalesInquary.intRepOption = 458;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void customerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Settings.Default.CRM)
            {
                if (frmCustomer.GetCustomer == null)
                {
                    frmCustomer.GetCustomer = new frmCustomer();
                    frmCustomer.GetCustomer.MdiParent = this;
                    frmCustomer.GetCustomer.Show();
                }
                else
                { frmCustomer.GetCustomer.Focus(); }
            }
            else
            {
                if (frmAccounts.GetAccount == null)
                {
                    frmAccounts.GetAccount = new frmAccounts();
                    frmAccounts.GetAccount.MdiParent = this;
                    frmAccounts.GetAccount.Show();
                }
                else
                { frmAccounts.GetAccount.Focus(); }
            }
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSupplier.GetAccount == null)
            {
                frmSupplier.GetAccount = new frmSupplier();
                frmSupplier.GetAccount.MdiParent = this;
                frmSupplier.GetAccount.Show();
            }
            else
            {
                frmSupplier.GetAccount.Focus();
            }
        }

        private void saleUpoadSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary != null)
            {
                frmTransactionInquary.GetTransactionInquary.Close();
            }
            frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
            frmTransactionInquary.GetTransactionInquary.Text = "Sales Upload Summary";
            frmTransactionInquary.GetTransactionInquary.MdiParent = this;
            frmTransactionInquary.GetTransactionInquary.intRepOption = 247;
            frmTransactionInquary.GetTransactionInquary.Show();
        }

        private void customerAginReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerPointReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerStateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerWiseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void giftVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Issued Gift Vouchers";
                frmSalesInquary.GetSalesInquary.intRepOption = 463;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void receivedGiftVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Received Gift Vouchers";
                frmSalesInquary.GetSalesInquary.intRepOption = 464;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void issuedAndReceivedSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printedGiftVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Printed Gift Vouchers";
                frmSalesInquary.GetSalesInquary.intRepOption = 466;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void pendingGiftVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Pending Gift Vouchers";
                frmSalesInquary.GetSalesInquary.intRepOption = 465;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void pointEarnAndRedeemReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openingStockDetailsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Opening Stock Note Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 248;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void expenseNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expenseNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Expense Details Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 249;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void expenseReturnNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Expense Return Details Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 250;
                frmTransactionInquary.GetTransactionInquary.Show();

            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Customer Detail Report Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 461;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCustomerVisiting.GetCustomerVisiting == null)
                {
                    frmCustomerVisiting.GetCustomerVisiting = new frmCustomerVisiting();
                    frmCustomerVisiting.GetCustomerVisiting.MdiParent = this;
                    frmCustomerVisiting.GetCustomerVisiting.Text = "Customer Visiting Report";
                    frmCustomerVisiting.GetCustomerVisiting.ReportNumber = 2;
                    frmCustomerVisiting.GetCustomerVisiting.Show();
                }
                else if (frmCustomerVisiting.GetCustomerVisiting != null && frmCustomerVisiting.GetCustomerVisiting.Text != "Customer Visiting Report")
                {
                    frmCustomerVisiting.GetCustomerVisiting = new frmCustomerVisiting();
                    frmCustomerVisiting.GetCustomerVisiting.MdiParent = this;
                    frmCustomerVisiting.GetCustomerVisiting.Text = "Customer Visiting Report";
                    frmCustomerVisiting.GetCustomerVisiting.ReportNumber = 2;
                    frmCustomerVisiting.GetCustomerVisiting.Show();
                }
                else
                {
                    frmCustomerVisiting.GetCustomerVisiting.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (frmCustomerAging.GetCustomerAging == null)
            {
                frmCustomerAging.GetCustomerAging = new frmCustomerAging();
                frmCustomerAging.GetCustomerAging.MdiParent = this;
                frmCustomerAging.GetCustomerAging.Text = "Customer Aging";
                frmCustomerAging.GetCustomerAging.ReportNumber = 7;
                frmCustomerAging.GetCustomerAging.Show();
            }
            else if (frmCustomerAging.GetCustomerAging != null && frmCustomerAging.GetCustomerAging.Text != "Customer Aging")
            {
                frmCustomerAging.GetCustomerAging = new frmCustomerAging();
                frmCustomerAging.GetCustomerAging.MdiParent = this;
                frmCustomerAging.GetCustomerAging.Text = "Customer Aging";
                frmCustomerAging.GetCustomerAging.ReportNumber = 7;
                frmCustomerAging.GetCustomerAging.Show();
            }
            else
            {
                frmCustomerAging.GetCustomerAging.Focus();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Sales Report Start 100,  Purchasing Report start 200,    Gross Profit Report 300
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Customer Point Statement";
                frmSalesInquary.GetSalesInquary.intRepOption = 462;
                frmSalesInquary.GetSalesInquary.Show();

            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCustomReport.GetCustomReport == null)
                {
                    frmCustomReport.GetCustomReport = new frmCustomReport();
                    frmCustomReport.GetCustomReport.MdiParent = this;
                    frmCustomReport.GetCustomReport.Text = "Customer Point Report";
                    frmCustomReport.GetCustomReport.ReportNumber = 10;
                    frmCustomReport.GetCustomReport.Show();
                }
                else if (frmCustomReport.GetCustomReport != null && frmCustomReport.GetCustomReport.Text != "Customer Point Report")
                {
                    frmCustomReport.GetCustomReport = new frmCustomReport();
                    frmCustomReport.GetCustomReport.MdiParent = this;
                    frmCustomReport.GetCustomReport.Text = "Customer Point Report";
                    frmCustomReport.GetCustomReport.ReportNumber = 10;
                    frmCustomReport.GetCustomReport.Show();
                }
                else
                {
                    frmCustomReport.GetCustomReport.Text = "Customer Point Report";
                    frmCustomReport.GetCustomReport.ReportNumber = 1;
                    frmCustomReport.GetCustomReport.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                //if (frmCustomReport.GetCustomReport == null)
                //{
                //    frmCustomReport.GetCustomReport = new frmCustomReport();
                //    frmCustomReport.GetCustomReport.MdiParent = this;
                //    frmCustomReport.GetCustomReport.Text = "Customer Point Earned Redeemed Report";
                //    frmCustomReport.GetCustomReport.ReportNumber = 1;
                //    frmCustomReport.GetCustomReport.Show();
                //}
                //else if (frmCustomReport.GetCustomReport != null && frmCustomReport.GetCustomReport.Text != "Customer Point Earned Redeemed Report")
                //{
                //    frmCustomReport.GetCustomReport = new frmCustomReport();
                //    frmCustomReport.GetCustomReport.MdiParent = this;
                //    frmCustomReport.GetCustomReport.Text = "Customer Point Earned Redeemed Report";
                //    frmCustomReport.GetCustomReport.ReportNumber = 1;
                //    frmCustomReport.GetCustomReport.Show();
                //}
                //else
                //{
                //    frmCustomReport.GetCustomReport.Focus();
                //}

                if (frmReportOption.GetReportOption == null)
                {
                    frmReportOption.GetReportOption = new frmReportOption();
                    frmReportOption.GetReportOption.MdiParent = this;
                    frmReportOption.GetReportOption.Text = "Customer Point Earned/Redeemed Report";
                    frmReportOption.GetReportOption.switchs = 10;
                    frmReportOption.GetReportOption.Show();
                }
                else if (frmReportOption.GetReportOption != null && frmReportOption.GetReportOption.Text != "Customer Point Earned/Redeemed Report")
                {
                    frmReportOption.GetReportOption = new frmReportOption();
                    frmReportOption.GetReportOption.MdiParent = this;
                    frmReportOption.GetReportOption.Text = "Customer Point Earned/Redeemed Report";
                    frmReportOption.GetReportOption.switchs = 10;
                    frmReportOption.GetReportOption.Show();
                }
                else
                {
                    frmReportOption.GetReportOption.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmReportOption.GetReportOption == null)
                {
                    frmReportOption.GetReportOption = new frmReportOption();
                    frmReportOption.GetReportOption.MdiParent = this;
                    frmReportOption.GetReportOption.Text = "Customer Point Earned/Redeemed And Purchase Analyse Report";
                    frmReportOption.GetReportOption.switchs = 15;
                    frmReportOption.GetReportOption.Show();
                }
                else
                {
                    frmReportOption.GetReportOption.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Customer Details (Regular)";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 10;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Customer Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 4;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 3;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Locked Product Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 73;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void debtorOpenBalanceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void debtorOpenBalnceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Debtor Open Balance Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 251;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Creditor Open Balance Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 252;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void exchangeProductReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product Exchange Detail Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 109;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "User Detail Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 469;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFromSettins();

                InsertMenus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mnuLocationDetails.Visible.ToString());
        }

        private void fssgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mnuLocationDetails.Visible.ToString());
        }

        private void MDI_Shown(object sender, EventArgs e)
        {

        }

        private void productAbstractingDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Abstract Product Details";
                frmSalesInquary.GetSalesInquary.intRepOption = 470;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productAbstractNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Abstract Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 233;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void productAbstractSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Abstract Summary ";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 253;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Bundle Product Details";
                frmSalesInquary.GetSalesInquary.intRepOption = 471;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void productBundlingNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Bundle Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 254;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void productBundlingSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Product Bundle Summary ";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 255;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void advanceNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = MainClass.mdi;
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Advance Note";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 231;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void advanceNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Advance Note";
                frmTransactionInquary.GetTransactionInquary.MdiParent = MainClass.mdi;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 256;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void advanceSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = MainClass.mdi;
                frmTransactionInquary.GetTransactionInquary.Text = "Supplier Advance Summary";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 258;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void advanceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = MainClass.mdi;
                frmTransactionInquary.GetTransactionInquary.Text = "Customer Advance Summary";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 257;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void supplierAdvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAdvance.AobjAdvance != null)
            {
                frmAdvance.AobjAdvance.Close();
            }
            frmAdvance.AobjAdvance = new frmAdvance("", "SUP");
            frmAdvance.AobjAdvance.MdiParent = this;
            frmAdvance.AobjAdvance.Text = "Advance";
            frmAdvance.AobjAdvance.Show();
        }

        private void productLinkToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmProductLink.GetProductLink == null)
            {
                frmProductLink.GetProductLink = new frmProductLink();
                frmProductLink.GetProductLink.MdiParent = MainClass.mdi;
                frmProductLink.GetProductLink.Show();
            }
            else
            {
                frmProductLink.GetProductLink.Focus();
            }
        }

        private void productWiseInvoiceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Invoice Summary(Product wise)";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 259;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void salesmanWiseInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Salesman wise Invoice Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 120;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Payment Collection Summary";
                frmSalesInquary.GetSalesInquary.intRepOption = 472;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void technicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTechnician.GetForm == null)
            {
                frmTechnician.GetForm = new frmTechnician();
                frmTechnician.GetForm.MdiParent = this;
                frmTechnician.GetForm.Show();
                frmTechnician.GetForm.Text = Settings.Default.Person;
            }
            else
            {
                frmTechnician.GetForm.Focus();
            }
        }

        private void technicianDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Technician Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 86;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void technicianChargeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void invoiceDetailSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Invoice Detail Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 260;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void MDI_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F8)
            {

                string Sqlst = " SELECT CASE TaxLoca WHEN 0 THEN 1 ELSE 0 END[TaxLoca],TaxLocaCode FROM dbo.Location WHERE Loca ='"+LoginManager.LocaCode+"'";
                ObjComm.getDataSet(Sqlst, "ds");

                if(ObjComm.Ads.Tables[0].Rows.Count==0)
                {
                    return;
                }
                bool SwTaxLoca = Convert.ToBoolean(ObjComm.Ads.Tables[0].Rows[0][0]);
                string SwLoca = ObjComm.Ads.Tables[0].Rows[0][1].ToString();            
                if (SwLoca=="")
                {
                    return;
                }

                Sqlst = " SELECT Loca,Loca_Descrip FROM dbo.Location WHERE Loca ='" + SwLoca + "'";
                ObjComm.getDataSet(Sqlst, "ds");

                string strLoca = ObjComm.Ads.Tables[0].Rows[0][0].ToString();
                string strLocaName = ObjComm.Ads.Tables[0].Rows[0][1].ToString();

                #region Close Forms
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }
                MainClass.mdi.mnuMain.Items["masterFileToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["masterDetailsToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["transactionToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["stockReportsToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["locationReportsToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["salesReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["purchasingReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["grossProfitReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["analyseReportToolStripMenuItem"].Visible = false;
                MainClass.mdi.mnuMain.Items["systemToolsToolStripMenuItem"].Visible = false;
                MainClass.mdi.toolStrip1.Visible = false;
                MainClass.mdi.mnuMain.Enabled = false;
                MainClass.mdi.Text = "Merit Plus Super Seller";

                MainClass.mdi.backgroundWorker1.CancelAsync();
                //MainClass.mdi.backgroundWorker1.Dispose();
                //MainClass.mdi.backgroundWorker1 = null;

                MainClass.mdi.timer1.Stop();
                #endregion
                 
                MainClass.mdi.timer1.Start();
                 
                LoginManager.TaxLocaLogin = SwTaxLoca;

                LoginManager.TaxLocaLogin = false;
                LoginManager.Location = strLocaName;
                LoginManager.LocaCode = strLoca;
                MainClass.mdi.Text = LoginManager.UserName.ToUpper() + " Logged On to : " + LoginManager.Location + " at : " + DateTime.Now;


                try
                {
                    if (SwTaxLoca == false)
                    {
                        this.BackgroundImage = Image.FromFile(@"..\Wallpaper\" + Settings.Default.Back_Image + ".jpg");
                    }
                    else
                    {
                        this.BackgroundImage = Image.FromFile(@"..\Wallpaper\" + Settings.Default.Back_Image + "tax.jpg");

                    }
                }
                catch
                {
                    this.BackgroundImage = global::Inventory.Properties.Resources.Super_Seller_1;
                }

                MainClass.mdi.systemToolsToolStripMenuItem.Visible = true;
                MainClass.mdi.mnuMain.Enabled = true;
                MainClass.mdi.toolStrip1.Visible = true;
                if (LoginManager.UserName.ToUpper() == "ONIMTA")
                {
                    MainClass.mdi.settingsToolStripMenuItem.Visible = true;
                }
                else
                {
                    MainClass.mdi.settingsToolStripMenuItem.Visible = false;

                }
                new frmLogin().LoadMenus();
                MainClass.mdi.MenuFromSettins();
                MainClass.mdi.Refresh();                 
                MainClass.mdi.timer1.Start();

            }

        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTaxTransfer.getPurchaseTransfer != null)
                frmTaxTransfer.getPurchaseTransfer.Close();

            frmTaxTransfer.getPurchaseTransfer = new frmTaxTransfer();
            frmTaxTransfer.getPurchaseTransfer.MdiParent = this;
            frmTaxTransfer.getPurchaseTransfer.Show();
        }

        private void appointmentBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCustomerAppointment.GetForm == null)
            {
                frmCustomerAppointment.GetForm = new frmCustomerAppointment();
                frmCustomerAppointment.GetForm.MdiParent = this;
                frmCustomerAppointment.GetForm.Show();
            }
            else
            {
                frmCustomerAppointment.GetForm.Focus();
            }
        }

        private void staffDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmStaff.GetStaff == null)
            {
                frmStaff.GetStaff = new frmStaff();
                frmStaff.GetStaff.MdiParent = this;
                frmStaff.GetStaff.Show();
            }
            else
            {
                frmStaff.GetStaff.Focus();
            }
        }

        private void cancelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCancellation.AobjCancellation == null)
            {
                frmCancellation.AobjCancellation = new frmCancellation();
                frmCancellation.AobjCancellation.MdiParent = this;
                frmCancellation.AobjCancellation.Show();
            }
            else
            {
                frmCancellation.AobjCancellation.Focus();
            }
        }

        private void invoiceProfictReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.Text = "Invoice Profit Summary";
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.intRepOption = 261;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void technicianChargeReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Technician Charge Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 473;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void technicianWiseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Technician wise Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 474;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void technicianWiseProductSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Technician wise Product Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 475;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void technicianWiseInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Technician wise Invoice Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 476;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void technicianWiseSalesPerformanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Technician wise Sales Performance Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 477;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (frmQuotation.GetQuotation == null)
            {
                frmQuotation.GetQuotation = new frmQuotation();
                frmQuotation.GetQuotation.MdiParent = this;
                frmQuotation.GetQuotation.Show();
            }
            else
            {
                frmQuotation.GetQuotation.Focus();
            }
        }

        private void productSerialStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Serial Stock Details";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 87;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
        }

        private void jobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmJob.GetJob == null)
            {
                frmJob.GetJob = new frmJob();
                frmJob.GetJob.MdiParent = this;
                frmJob.GetJob.Show();
            }
            else
            {
                frmJob.GetJob.Focus();
            }
        }

        private void jobRegistrationDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmTransactionInquary.GetTransactionInquary == null)
            {
                frmTransactionInquary.GetTransactionInquary = new frmTransactionInquary();
                frmTransactionInquary.GetTransactionInquary.MdiParent = this;
                frmTransactionInquary.GetTransactionInquary.Text = "Job Registration Detail Report";
                frmTransactionInquary.GetTransactionInquary.intRepOption = 262;
                frmTransactionInquary.GetTransactionInquary.Show();
            }
            else
            {
                frmTransactionInquary.GetTransactionInquary.Focus();
            }
        }

        private void productWiseSaleReportWithSerialNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption serial no Sales Report Start
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Product wise Sale Report With Serial Number";
                frmSalesInquary.GetSalesInquary.intRepOption = 479;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void toolStripCASHINOUT_Click(object sender, EventArgs e)
        {

            if (frmCashOut.GetCashOut == null)
            {
                frmCashOut.GetCashOut = new frmCashOut();              
                frmCashOut.GetCashOut.Text = "Cash IN/OUT Details";
                frmCashOut.GetCashOut.MdiParent = MainClass.mdi;
                frmCashOut.GetCashOut.Show();
            }
            else
            {
                frmCashOut.GetCashOut.Focus();
            }
           
        }

        private void toolStripdailySalesSummary_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Daily Sales Summary - Collection";
                frmSalesInquary.GetSalesInquary.intRepOption = 452;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void DebtorsDocumentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption Creditor
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Debtors Document Details";
                frmSalesInquary.GetSalesInquary.intRepOption = 528;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void categoryWiseProductWiseDistoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Category Wise Product wise Stock Valuation (Distribution Price)";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 88;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();

            }
            else
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary.Focus();
            }
        }

        private void ProductWisePurchaseWithSerialNumberStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)    //intRepOption serial no Purchase Report
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Serial Numbers Wise Purchase Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 480;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void posSalesSummaryReportWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Pos Sales Summary - Report Wise";
                frmSalesInquary.GetSalesInquary.intRepOption = 490;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void CasheirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmCashierDetails.GetCashierDetails == null)
            {
                frmCashierDetails.GetCashierDetails = new frmCashierDetails();
                frmCashierDetails.GetCashierDetails.MdiParent = this;
                frmCashierDetails.GetCashierDetails.Show();
            }
            else
            {
                frmCashierDetails.GetCashierDetails.Focus();
            }
        }

        private void unitWisePOSSalesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Unit Wise Pos Sales Summary Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 481;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentProductSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Product Sales Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 482;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentSalesReportSupplierWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Product Sales Report (Supplier Wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 483;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentSalesReportDepartmentWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Product Sales Report (Department Wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 484;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentExchangeProductReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Product Exchange Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 485;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void currentSpecialDiscountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Current Special Discount Details Report";
                frmSalesInquary.GetSalesInquary.intRepOption = 486;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dayEndProcessToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmDayEndProcessNew.GetDayEndProcess == null)
            {
                frmDayEndProcessNew.GetDayEndProcess = new frmDayEndProcessNew();
                frmDayEndProcessNew.GetDayEndProcess.MdiParent = this;
                frmDayEndProcessNew.GetDayEndProcess.Show();
            }
            else
            {
                frmDayEndProcessNew.GetDayEndProcess.Focus();
            }
        }

        private void cashierWiseDailySalesSummaryToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Cashier Wise Daily Sales Summary";
                frmSalesInquary.GetSalesInquary.lblCodeFrom.Text = "Cashier From";
                frmSalesInquary.GetSalesInquary.lblCodeTo.Text = "Cashier To";
                frmSalesInquary.GetSalesInquary.intRepOption = 487;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

     

        private void creditCardWiseSalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Credit Card Wise Sales";
                frmSalesInquary.GetSalesInquary.intRepOption = 488;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void creditCardWiseSalesDateWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSalesInquary.GetSalesInquary == null)
            {
                frmSalesInquary.GetSalesInquary = new frmSalesInquary();
                frmSalesInquary.GetSalesInquary.MdiParent = this;
                frmSalesInquary.GetSalesInquary.Text = "Credit Card Wise Sales(Date Wise)";
                frmSalesInquary.GetSalesInquary.intRepOption = 489;
                frmSalesInquary.GetSalesInquary.Show();
            }
            else
            {
                frmSalesInquary.GetSalesInquary.Focus();
            }
        }

        private void dataUpdateToPosTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPosUpdate.GetPosUpdate == null)
            {
                frmPosUpdate.GetPosUpdate = new frmPosUpdate();
                frmPosUpdate.GetPosUpdate.MdiParent = this;
                frmPosUpdate.GetPosUpdate.Show();
            }
            else
            {
                frmPosUpdate.GetPosUpdate.Focus();
            }
        }

        private void displayReceiptToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(frmDisplayReceipt.GetDisplayReceipt == null)
            {
                frmDisplayReceipt.GetDisplayReceipt = new frmDisplayReceipt();
                frmDisplayReceipt.GetDisplayReceipt.MdiParent = this;
                frmDisplayReceipt.GetDisplayReceipt.Show();
            }
            else
            {
                frmDisplayReceipt.GetDisplayReceipt.Focus();
            }
        }

        private void productStockIssueRecievedDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMasterDetailsInquary.GetMasterDetailsInquary == null)
            {
                frmMasterDetailsInquary.GetMasterDetailsInquary = new frmMasterDetailsInquary();
                frmMasterDetailsInquary.GetMasterDetailsInquary.MdiParent = this;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Text = "Product Serial Stock Issue & Receieved Detail Report";
                frmMasterDetailsInquary.GetMasterDetailsInquary.intRepOption = 89;
                frmMasterDetailsInquary.GetMasterDetailsInquary.Show();
            }
        }

        private void spaVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSpaVoucher.GetGiftVoucher == null)
            {
                frmSpaVoucher.GetGiftVoucher = new frmSpaVoucher();
                frmSpaVoucher.GetGiftVoucher.MdiParent = this;
                frmSpaVoucher.GetGiftVoucher.Show();
            }
            else
            {
                frmSpaVoucher.GetGiftVoucher.Focus();
            }
        }

        private void CheqPrintToolStripMenuItemTool_Click(object sender, EventArgs e)
        {
            if (frmChequePrint._objCP == null)
            {
                frmChequePrint._objCP = new frmChequePrint();
                frmChequePrint._objCP.MdiParent = this;
                frmChequePrint._objCP.Show();
            }
            else
            {
                frmSpaVoucher.GetGiftVoucher.Focus();
            }
        }

        private void RentToolStripMenuItemTool_Click(object sender, EventArgs e)
        {
            if (frmRental.GetRent == null)
            {
                frmRental.GetRent = new frmRental();
                frmRental.GetRent.MdiParent = this;
                frmRental.GetRent.Show();
            }
            else
            {
                frmSpaVoucher.GetGiftVoucher.Focus();
            }

        }

        //private void specialPromotionSalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    if (frmSalesInquary.GetSalesInquary == null)
        //    {
        //        frmSalesInquary.GetSalesInquary = new frmSalesInquary();
        //        frmSalesInquary.GetSalesInquary.MdiParent = this;
        //        frmSalesInquary.GetSalesInquary.Text = "Special Promotion Sales Report";
        //        frmSalesInquary.GetSalesInquary.intRepOption = 478;
        //        frmSalesInquary.GetSalesInquary.Show();
        //    }
        //    else
        //    {
        //        frmSalesInquary.GetSalesInquary.Focus();
        //    }
        //}
    }
}