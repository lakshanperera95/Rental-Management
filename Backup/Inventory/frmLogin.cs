using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using Inventory.Properties;
using clsLibrary;


namespace Inventory
{
	public partial class frmLogin : Form
	{
        public static string username;
        public static string location;
        DateTime dtCurrentDate = DateTime.Now ;
        clsUserProfile objUserProfile = new clsUserProfile();
        LoginManager ObjLoginmanager = new LoginManager();

		private string selectquery;
        static frmSearch search = new frmSearch ();
        clsCommon objclsSettings = new clsCommon();
		public frmLogin()
		{
            try
            {
                InitializeComponent();
                txtPassword.PasswordChar = (char)0x25CF;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

		private void btnExit_Click(object sender, EventArgs e)
		{
            try
            {
                //MainClass.login.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (search.Descript != "")
                {
                    txtLocation.Text = search.Descript;
                    search.Hide();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
           
        private void btnLocation_Click_1(object sender, EventArgs e)
        {
            try
            {
                MainClass.getmdi().Cursor = Cursors.WaitCursor;
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location WHERE Loca<>'" + LoginManager.ExtLoca + "' AND Loca<>'" + LoginManager.ExtLoca2 + "' ORDER BY Loca";

                search.dgSearch.DataSource = clsRetriveGenaral.combofill1(selectquery).Tables["Table"];
                search.Show();
                search.prop_Focus = txtLocation;
                txtLocation.Text = search.Descript;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocation_Enter_1(object sender, EventArgs e)
        {
            try
            {
                txtLocation.Text = search.Descript;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.btnLogin.PerformClick();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void mLogin() 
        {
            try
            {
                clsSplash objSplash = new clsSplash();
                Boolean blExtLoca = false;
                Boolean blExtLoca2 = false;

                string query = "SELECT Id_No, UserRole_Id FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + search.Code + "') AND Acc_Desable = 'F'";
                //For Extension Location
                if (txtUsername.Text.Trim().ToUpper() == LoginManager.ExtUserName.ToUpper() && txtPassword.Text.Trim().ToUpper() == LoginManager.ExtPassword.ToUpper())
                {
                    query = "SELECT Id_No, UserRole_Id FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + LoginManager.ExtLoca + "') AND Acc_Desable = 'F'";
                    blExtLoca = true;
                }
                else if (txtUsername.Text.Trim().ToUpper() == LoginManager.ExtUserName2.ToUpper() && txtPassword.Text.Trim().ToUpper() == LoginManager.ExtPassword2.ToUpper())
                {
                    query = "SELECT Id_No, UserRole_Id FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + LoginManager.ExtLoca2 + "') AND Acc_Desable = 'F'";
                    blExtLoca2 = true;
                }
                //**********************

                if ((clsLogin.PasswordValidator(query)) != "")
                {
                    username = txtUsername.Text;
                    if (blExtLoca == true && blExtLoca2 == false)
                    {
                        location = LoginManager.ExtLocaDescription;
                        LoginManager.UserName = txtUsername.Text;
                        LoginManager.Location = LoginManager.ExtLocaDescription;
                        LoginManager.LocaCode = LoginManager.ExtLoca;
                        MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + LoginManager.ExtLocaDescription.ToUpper() + " at : " + DateTime.Now;
                    }
                    else if (blExtLoca == false && blExtLoca2 == true)
                    {
                        location = LoginManager.ExtLocaDescription2;
                        LoginManager.UserName = txtUsername.Text;
                        LoginManager.Location = LoginManager.ExtLocaDescription2;
                        LoginManager.LocaCode = LoginManager.ExtLoca2;
                        MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + LoginManager.ExtLocaDescription2.ToUpper() + " at : " + DateTime.Now;
                    }
                    else
                    {
                        location = txtLocation.Text;
                        LoginManager.UserName = txtUsername.Text;
                        LoginManager.Location = txtLocation.Text;
                        LoginManager.LocaCode = search.Code;
                        MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + txtLocation.Text.ToUpper() + " at : " + DateTime.Now;
                        
                    }
                    ObjLoginmanager.CompanyDetails("SELECT CompanyName, CompanyAddress, CompanyTelephone, CompanyEmail FROM CompanyProfile");
                   // LoginManager.
                    // "SELECT CompanyName, CompanyAddress, CompanyTelephone, CompanyEmail FROM CompanyProfile"
                  //  location = txtLocation.Text;

                  //  LoginManager.UserName = txtUsername.Text;
                  //  LoginManager.Location = txtLocation.Text;
                  //  LoginManager.LocaCode = search.Code;

                    //MDI pf = ParentForm as MDI;
                    MainClass.mdi.mnuMain.Enabled = true;
                    MainClass.mdi.toolStrip1.Visible = true ;
                    if (LoginManager.UserName.ToUpper() == "ONIMTA" && txtPassword.Text == "2302")
                    {
                        MainClass.mdi.settingsToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        MainClass.mdi.settingsToolStripMenuItem.Visible = false;
                    }
                    //menu visible true for user

                    this.MenuVisibleTrueFalse();
                    //

                    MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + txtLocation.Text.ToUpper() + " at : " + DateTime.Now;
                    //Write to Log
                    FileStream fileStream = new FileStream(@"..\LoginInfo.txt", FileMode.Append);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("'Location :' " + txtLocation.Text + " 'User Name :' " + txtUsername.Text + " 'Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate));
                        // read from file or write to file
                    }
                    finally
                    {
                        m_streamWriter.Close();
                        fileStream.Close();
                    }

                    objUserProfile.SqlStatement = "SELECT -DATEDIFF(dd,EXPDate,GETDATE()) [EXPDate], CONVERT(NVARCHAR,EXPDate,106) [Day] FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + search.Code + "') AND DATEDIFF(dd,GETDATE(),EXPDate) < 15";
                    objUserProfile.FExpDates();

                    //

                    if (objUserProfile.ChgPwdNxtLogin == "T")
                    {
                        if (frmChangePassword.GetChangePassword == null)
                        {
                            frmChangePassword.GetChangePassword = new frmChangePassword();
                            //frmChangePassword.GetChangePassword.MdiParent = MDI;
                            frmChangePassword.GetChangePassword.Show();
                        }
                        else
                        {
                            frmChangePassword.GetChangePassword.Focus();
                        }
                    }
                    this.Hide();

                    MainClass.mdi.Refresh();
                  

                    search.Descript = string.Empty;
                    search.Code = string.Empty;
                    search.prop_Focus = null;

                   
                    MainClass.mdi.timer1.Start();

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password or Access Denied !", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.SelectAll();
                    txtPassword.Focus();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmlogin_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtLocation.Focus();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }
                if (e.KeyCode==Keys.Enter && txtLocation.Text != "")
                {
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
                if (e.KeyCode==Keys.F1)
                {
                    btnLocation.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }
                else if (e.KeyCode==Keys.Enter)
                {
                    txtPassword.SelectAll();
                    txtPassword.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
                //this.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmlogin_Load(object sender, EventArgs e)
        {
            try
            {
              
              // frmLogin.ActiveForm.KeyPreview = true;
                
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)27)
                {
                    this.Close();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void MenuVisibleTrueFalse()
        {
            try
            {
                MDI mdi = ParentForm as MDI;
                //mdi.mnuBrand.Visible = false;

                objUserProfile.SqlStatement = "select tbUserRoleDetails.*, Employee.UserCannotChgPwd, Employee.chgPwdNxtLogin from tbUserRoleDetails Inner join Employee on Employee.UserRole_Id = tbUserRoleDetails.UserRole_Id Where Employee.Emp_Name = '" + LoginManager.UserName + "' and Employee.Loca = '" + LoginManager.LocaCode + "'";
                objUserProfile.ReadProfileDetails();

                //Master details
                if (objUserProfile.MSTDT == "T")
                {
                    mdi.masterFileToolStripMenuItem.Visible = true;
                    mdi.toolStripButtonDept.Visible = true;
                    mdi.toolStripCategory.Visible = true;
                    mdi.toolStripSupplier.Visible = true;
                    mdi.toolStripProduct.Visible = true;
                }
                else
                {
                    mdi.masterFileToolStripMenuItem.Visible = false;
                    mdi.toolStripButtonDept.Visible = false;
                    mdi.toolStripCategory.Visible = false;
                    mdi.toolStripSupplier.Visible = false;
                    mdi.toolStripProduct.Visible = false;
                }


                //Master details report
                if (objUserProfile.MSTDTREP == "T")
                {
                    mdi.masterDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.masterDetailsToolStripMenuItem.Visible = false;
                }

                //Cashier Details
                if (objUserProfile.Cashier == "T")
                {
                    mdi.cashierDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.cashierDetailsToolStripMenuItem.Visible = false;

                }
                //Transaction Menu visible
                if (objUserProfile.TRAN == "T")
                {
                    mdi.transactionToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.transactionToolStripMenuItem.Visible = false;
                }

                //Transaction --> Purchasing
                if (objUserProfile.PUR == "T")
                {
                    mdi.purchasingToolStripMenuItem.Visible = true;
                    mdi.purchaseOrderDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.purchasingToolStripMenuItem.Visible = false;
                    mdi.purchaseOrderDetailsToolStripMenuItem.Visible = false;
                }
                //purchase Order
                if (objUserProfile.PUROR == "T")
                {
                    mdi.purchaseOrderNoteToolStripMenuItem2.Visible = true;
                    mdi.toolStripButtonPurchaseOrder.Visible = true;
                }
                else
                {
                    mdi.purchaseOrderNoteToolStripMenuItem2.Visible = false;
                    mdi.toolStripButtonPurchaseOrder.Visible = false;
                }
                //purchase Order details
                if (objUserProfile.PURORDET == "T")
                {
                    mdi.purchasingDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.purchasingDetailsToolStripMenuItem.Visible = false;
                }
                //Good Received Note
                if (objUserProfile.GRN == "T")
                {
                    mdi.goodReceivedNoteToolStripMenuItem2.Visible = true;
                    mdi.toolStripGrn.Visible = true;
                }
                else
                {
                    mdi.goodReceivedNoteToolStripMenuItem2.Visible = false;
                    mdi.toolStripGrn.Visible = false;
                }
                //Good Received Details
                if (objUserProfile.GRNDET == "T")
                {
                    mdi.goodReceivedNoteDetailsToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.goodReceivedNoteDetailsToolStripMenuItem1.Visible = false;
                }

                //Supplier Return Note
                if (objUserProfile.SRN == "T")
                {
                    mdi.iffrmSupplierReturnGetSupplierReturnNullToolStripMenuItem.Visible = true;
                    mdi.toolStripButtonSuppReturn.Visible = true;
                }
                else
                {
                    mdi.iffrmSupplierReturnGetSupplierReturnNullToolStripMenuItem.Visible = false;
                    mdi.toolStripButtonSuppReturn.Visible = false;
                }
                //Supplier Return Note Details
                if (objUserProfile.SRNDET == "T")
                {
                    mdi.supplierReturnNoteDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.supplierReturnNoteDetailsToolStripMenuItem.Visible = false;
                }
                //Transfer Note
                if (objUserProfile.TOG == "T")
                {
                    mdi.transferOfGoodsNoteToolStripMenuItem1.Visible = true;
                    mdi.toolStripButton1.Visible = true;
                }
                else
                {
                    mdi.transferOfGoodsNoteToolStripMenuItem1.Visible = false;
                    mdi.toolStripButton1.Visible = false;
                }
                //Transfer Note Details
                if (objUserProfile.TOGDET == "T")
                {
                    mdi.transferOfGoodsNoteDetailsToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.transferOfGoodsNoteDetailsToolStripMenuItem1.Visible = false;
                }

                //Whole Sale
                if (objUserProfile.SALE == "T")
                {
                    mdi.salesTransactionToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.salesTransactionToolStripMenuItem.Visible = false;
                }
                //Whole Sale
                if (objUserProfile.WSALE == "T")
                {
                    mdi.wholeSaleInvoiceToolStripMenuItem2.Visible = true;
                    mdi.toolStripButtonInvoice.Visible = true;
                    mdi.quotationToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.wholeSaleInvoiceToolStripMenuItem2.Visible = false;
                    mdi.toolStripButtonInvoice.Visible = false;
                    mdi.quotationToolStripMenuItem.Visible = false;
                }
                //Whole Sale Details
                if (objUserProfile.WSALEDET == "T")
                {
                    mdi.wholeSaleInvoiceDetailsToolStripMenuItem.Visible = true;
                    mdi.wholeSaleInvoiceDetailsToolStripMenuItem1.Visible = true;
                    mdi.quotationToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.wholeSaleInvoiceDetailsToolStripMenuItem.Visible = false;
                    mdi.wholeSaleInvoiceDetailsToolStripMenuItem1.Visible = false;
                    mdi.quotationToolStripMenuItem1.Visible = false;
                }

                //Customer Return
                if (objUserProfile.CUSRET == "T")
                {
                    mdi.customerReturnToolStripMenuItem1.Visible = true;
                    mdi.toolStripButtonCustRet.Visible = true;
                }
                else
                {
                    mdi.customerReturnToolStripMenuItem1.Visible = false;
                    mdi.toolStripButtonCustRet.Visible = false;
                }
                //Customer Return
                if (objUserProfile.CUSRETDET == "T")
                {
                    mdi.customerReturnDetailsToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.customerReturnDetailsToolStripMenuItem1.Visible = false;
                }

                //Payemnt
                if (objUserProfile.PMT == "T")
                {
                    mdi.paymentsToolStripMenuItem.Visible = true;
                    mdi.paymentsDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.paymentsToolStripMenuItem.Visible = false;
                    mdi.paymentsDetailsToolStripMenuItem.Visible = false;
                }
                //supplier Payment
                if (objUserProfile.PAYMENT == "T")
                {
                    mdi.supplierPaymentToolStripMenuItem1.Visible = true;
                    mdi.toolStripButtonPayment.Visible = true;
                }
                else
                {
                    mdi.supplierPaymentToolStripMenuItem1.Visible = false;
                    mdi.toolStripButtonPayment.Visible = false;
                }
                //supplier Payment Deatils
                if (objUserProfile.PMTDET == "T")
                {
                    mdi.supplierPaymentDetailsToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.supplierPaymentDetailsToolStripMenuItem1.Visible = false;
                }

                //Customer Receipt
                if (objUserProfile.RECEIPT == "T")
                {
                    mdi.receiptToolStripMenuItem1.Visible = true;
                    mdi.toolStripButtonReceipt.Visible = true;
                }
                else
                {
                    mdi.receiptToolStripMenuItem1.Visible = false;
                    mdi.toolStripButtonReceipt.Visible = false;
                }

                //Customer Receipt Details
                if (objUserProfile.RECDET == "T")
                {
                    mdi.receiptDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.receiptDetailsToolStripMenuItem.Visible = false;
                }

                //Cheque Recon
                if (objUserProfile.CHQRECON == "T")
                {
                    mdi.chequeReconsiToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.chequeReconsiToolStripMenuItem.Visible = false;
                }

                //Cheque Recon Details
                if (objUserProfile.CHQRECDET == "T")
                {
                    mdi.chequeReconciliationToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.chequeReconciliationToolStripMenuItem.Visible = false;
                }

                //Stock Adjustment
                if (objUserProfile.STADJ == "T")
                {
                    mdi.stockAdjustmentToolStripMenuItem.Visible = true;
                    mdi.stockAdjustmentDetailsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.stockAdjustmentToolStripMenuItem.Visible = false;
                    mdi.stockAdjustmentDetailsToolStripMenuItem.Visible = false;
                }

                //Stock Adjustment
                if (objUserProfile.STAD == "T")
                {
                    mdi.stockAdjustmentToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.stockAdjustmentToolStripMenuItem1.Visible = false;
                }

                //Stock Adjustment Details
                if (objUserProfile.STADDET == "T")
                {
                    mdi.stockAdjustmentToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.stockAdjustmentToolStripMenuItem1.Visible = false;
                }
                //Stock Adjustment
                if (objUserProfile.STOVER == "T")
                {
                    mdi.stockOverwriteToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.stockOverwriteToolStripMenuItem.Visible = false;
                }

                //Stock Reports visiblity
                if (objUserProfile.REPSTBAL == "T" || objUserProfile.REPSTVAL == "T")
                {
                    mdi.stockReportsToolStripMenuItem.Visible = true;
                }

                //stock Balance report
                if (objUserProfile.REPSTBAL == "T")
                {
                    mdi.stockBalanceToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.stockBalanceToolStripMenuItem1.Visible = false;
                }

                //Stock Valuation

                if (objUserProfile.REPSTVAL == "T")
                {
                    mdi.stockValuationReportToolStripMenuItem1.Visible = true;
                }
                else
                {
                    mdi.stockValuationReportToolStripMenuItem1.Visible = false;
                }

                //Purchasing Report
                if (objUserProfile.REPPUR == "T")
                {
                    mdi.purchasingReportToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.purchasingReportToolStripMenuItem.Visible = false;
                }

                //Sales Report
                if (objUserProfile.REPSAL == "T")
                {
                    mdi.salesReportToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.salesReportToolStripMenuItem.Visible = false;
                }


                //Grossprofite Report
                if (objUserProfile.REPGP == "T")
                {
                    mdi.grossProfitReportToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.grossProfitReportToolStripMenuItem.Visible = false;
                }

                //analyse Report
                if (objUserProfile.REPANY == "T")
                {
                    mdi.analyseReportToolStripMenuItem.Visible = true;
                    mdi.creditorToolStripMenuItem.Visible = (objUserProfile.Cr == "T") ? true : false;
                    mdi.debtorToolStripMenuItem.Visible = (objUserProfile.Dr == "T") ? true : false;
                    mdi.profitReportToolStripMenuItem.Visible = (objUserProfile.Profit == "T") ? true : false;
                    mdi.salesStockReportToolStripMenuItem.Visible = (objUserProfile.SaleMoving == "T") ? true : false;
                    mdi.orderLevelToolStripMenuItem.Visible = (objUserProfile.OrderLevel == "T") ? true : false;
                    mdi.stockProcessingToolStripMenuItem.Visible = (objUserProfile.PRCHG == "T") ? true : false;
                }
                else
                {
                    mdi.analyseReportToolStripMenuItem.Visible = false;
                }

                //Price Change Report
                if (objUserProfile.SYSTL == "T")
                {
                    //mdi.productDetailsChangeReportToolStripMenuItem.Visible = true;
                    ////mdi.productDetailsChangeReportProductWiseToolStripMenuItem.Visible = true;
                }
                else
                {
                    //// mdi.productDetailsChangeReportToolStripMenuItem.Visible = false;
                    /////mdi.productDetailsChangeReportProductWiseToolStripMenuItem.Visible = true;
                }

                //System Tools

                //User Create
                if (objUserProfile.USER == "T")
                {
                    mdi.userProfileToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.userProfileToolStripMenuItem.Visible = false;
                }

                if (objUserProfile.LocationReports == "T")
                {
                    mdi.locationReportsToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.locationReportsToolStripMenuItem.Visible = false;
                }
                if (objUserProfile.Bin == "T")
                {
                    mdi.productBinCardToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.productBinCardToolStripMenuItem.Visible = false;
                }
                //child menu enable/desable

                //Price Change
                if (objUserProfile.PRCHG == "T")
                {
                    LoginManager.PriceChange = "T";
                    //******
                    if (objUserProfile.MSTDT == "F")
                    {
                        mdi.masterFileToolStripMenuItem.Visible = true;
                        mdi.mnuLocationDetails.Visible = false;
                        mdi.mnuDepartment.Visible = false;
                        mdi.mnuCategory.Visible = false;
                        mdi.customerToolStripMenuItem.Visible = false;
                        mdi.supplierToolStripMenuItem1.Visible = false;
                        mdi.mnuBrand.Visible = false;
                        mdi.mnuManufact.Visible = false;
                        mdi.mnuProduct.Visible = false;
                        //productPriceMasterToolStripMenuItem
                        mdi.salesmanToolStripMenuItem.Visible = false;
                        mdi.packetingProductToolStripMenuItem.Visible = false;
                        mdi.cashierDetailsToolStripMenuItem.Visible = false;
                        mdi.userProfileToolStripMenuItem.Visible = false;
                    }
                    //********
                }
                else
                {
                    LoginManager.PriceChange = "F";
                }

                //------All Price show in invoice
                LoginManager.AllPriceShow = objUserProfile.AllPriceShow;
                //-------------------------------

                //------Static Ip Stock Show
                LoginManager.SIP_St_Show = objUserProfile.StaticIpStock;
                //-------------------------------

                //*****Showroom Product Request
                if (LoginManager.LocaCode != "01")
                {
                    mdi.showroomToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.showroomToolStripMenuItem.Visible = false;
                }
                //******
                objUserProfile.ReadCostCodeText();
                LoginManager.CostCodeText = objUserProfile.CostCodeText;
                //try
                //{
                //    mdi.BackgroundImage = Image.FromFile(Settings.Default.Back_Image);
                //}
                //catch
                //{
                //    mdi.BackgroundImage = global::Inventory.Properties.Resources.blueswirly;
                //}
                //***************


                if (objUserProfile.ROA == "T")
                {
                    mdi.receivedOnAccToolStripMenuItem1.Visible = true;
                    mdi.toolStripButtonROA.Visible = true;
                }
                else
                {
                    mdi.receivedOnAccToolStripMenuItem1.Visible = false;
                    mdi.toolStripButtonROA.Visible = false;
                }
                if (objUserProfile.CDNM == "T")
                {
                    mdi.cashDenominationToolStripMenuItem2.Visible = true;
                    mdi.toolStripButtonCDNM.Visible = true;
                }
                else
                {
                    mdi.cashDenominationToolStripMenuItem2.Visible = false;
                    mdi.toolStripButtonCDNM.Visible = false;
                }

                if (objUserProfile.ROADET == "T")
                {
                    mdi.receivedOnAccountToolStripMenuItem1.Visible = true;

                }
                else
                {
                    mdi.receivedOnAccountToolStripMenuItem1.Visible = false;

                }
                if (objUserProfile.CDNMDET == "T")
                {
                    mdi.cashDenominationToolStripMenuItem3.Visible = true;

                }
                else
                {
                    mdi.cashDenominationToolStripMenuItem3.Visible = false;

                }


                //Remove unwanted Toottrips
                mdi.productPriceMasterToolStripMenuItem.Visible = false;
                mdi.productLinkToolStripMenuItem.Visible = false;
                mdi.cashierDetailsToolStripMenuItem.Visible = false;


                mdi.linkedProductDetailsToolStripMenuItem.Visible = false;
                mdi.productPriceLevelDetailsToolStripMenuItem.Visible = false;

                mdi.productToBeReturnToolStripMenuItem.Visible = false;
                mdi.purchasingToolStripMenuItem1.Visible = false;

                mdi.customerReturnToolStripMenuItem1.Visible = false;
                mdi.cashReturnToolStripMenuItem.Visible = false;

                mdi.shipmentRegisterToolStripMenuItem.Visible = false;
                mdi.productToBeReturnDetailsToolStripMenuItem.Visible = false;
                mdi.puchasingBillDetialsSummaryToolStripMenuItem.Visible = false;

                mdi.toBeDoenGRNSummaryToolStripMenuItem.Visible = false;
                mdi.realTimeStockReportToolStripMenuItem.Visible = false;

                mdi.posSalesAnalyseReportToolStripMenuItem.Visible = false;
                mdi.wholeSaleTransactionReportToolStripMenuItem.Visible = false;
                mdi.currentSalesAnalyseToolStripMenuItem.Visible = false;

                mdi.profitReportToolStripMenuItem.Visible = false;

                mdi.systemToolsToolStripMenuItem.Visible = true ;


                //-----------
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    objclsSettings.getDataReader("SELECT CodeLength,CodeGenOrder, NoOfTerminal,GRN_S,GRN_P, SRN_P, SRN_S, PRN_S, PRN_P, PO_S, BackupPath, Singhala, SIP_St_Show, StaticIp, DB_Name, TrInCon, InvAllowReduce, GrnAllowReduce, RecAmtFirst,InvLineDisc, InvSbttDisc_Manual, CashDrawerOpen,VatAllow,VatPrecentage,Margin,RptItemImage,CRMMSg,CodeGen,AutoGenCusCode,CashBill,ImageFromServer,ImageFileServer,creditBill,CRM,GIFT,OtherCharges,vatbill   FROM tb_Settings");
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
                        Settings.Default.CodeGen = objclsSettings.Adr["CodeGen"].ToString(); ;
                        Settings.Default.AutoGenCustCode = (bool)objclsSettings.Adr["AutoGenCusCode"];
                        Settings.Default.InvCashType = (bool)objclsSettings.Adr["CashBill"];
                        Settings.Default.ImageFromServer = (bool)objclsSettings.Adr["ImageFromServer"];
                        Settings.Default.ImageFileServer = objclsSettings.Adr["ImageFileServer"].ToString();

                        Settings.Default.AllowCreditbill = (bool)objclsSettings.Adr["CreditBill"] ;
                        Settings.Default.CRM = (bool)objclsSettings.Adr["CRM"] ;
                        Settings.Default.GIFT = (bool)objclsSettings.Adr["GIFT"] ;

                        Settings.Default.OtherCharge = (bool)objclsSettings.Adr["OtherCharges"];
                        Settings.Default.VatBill = (bool)objclsSettings.Adr["Vatbill"];


                        Settings.Default.Save();
                    }

                    if (Settings.Default.CRM == true)
                    {
                        MainClass.mdi.cRMToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        MainClass.mdi.cRMToolStripMenuItem.Visible = false;
                    }
                    if (Settings.Default.GIFT == true)
                    {
                        MainClass.mdi.giftVoucherToolStripMenuItem1.Visible = true;
                    }
                    else
                    {
                        MainClass.mdi.giftVoucherToolStripMenuItem1.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Settings File Error!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                    //clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
                objUserProfile.SqlStatement = "SELECT Id_No, UserRole_Id FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + search.Code + "') AND Acc_Desable = 'T'";
                objUserProfile.ReadUserName();
                if (objUserProfile.RecordFound == true)
                {
                    MessageBox.Show("Your password is currently disabled.\n\rPlease contact system administrator","Login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                objUserProfile.SqlStatement = "SELECT UserRole_Id, EXPDate FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + search.Code + "') AND EXPDate < GETDATE()";
                objUserProfile.ReadUserName();
                if (objUserProfile.RecordFound == true)
                {
                    MessageBox.Show("Your account has been expired.\n\rPlease contact system administrator", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.mLogin();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Login 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
}