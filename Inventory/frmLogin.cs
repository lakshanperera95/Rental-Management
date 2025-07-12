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
using System.Data.SqlClient;
using System.Threading.Tasks;

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

                selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location WHERE  Loca LIKE '%" + LoginManager.ReadLocaN + "%' " +
                    "and Loca<>'" + LoginManager.ExtLoca + "' and TaxLoca=0 ORDER BY Loca";
               // "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location WHERE Loca<>'" + LoginManager.ExtLoca + "' AND Loca<>'" + LoginManager.ExtLoca + "' ORDER BY Loca";
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
               
                //txtLocation.Text = grdLoca.SelectedRows[0].Cells[1].Value.ToString();
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

                string query = "SELECT Id_No, UserRole_Id,TaxUser FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "')  AND Acc_Desable = 'F'";
                string AA = "TAX";
                clsLogin.CheckTaxUser(query, ref AA);

                if (clsLogin.blTaxUser == false)
                {
                    query = "SELECT Id_No, UserRole_Id,TaxUser FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" + grdLoca.SelectedRows[0].Cells[0].Value.ToString() + "') AND Acc_Desable = 'F'";
                    AA = clsLogin.PasswordValidator(query, search.Code);
                }

                if (AA != "")
                {
                    username = txtUsername.Text;
                    MainClass.mdi.timer1.Start();
                    //UserRole Saving
                    //LoginManager.UserRole = int.Parse(AA);
                    LoginManager.UserName = txtUsername.Text;
                    LoginManager.LogTimeOut = LoginManager.StatTimeOut;

                    if (clsLogin.blTaxUser == false)
                    {
                        LoginManager.TaxLocaLogin = false;
                        location = txtLocation.Text;
                        LoginManager.Location = txtLocation.Text;
                        LoginManager.LocaCode = search.Code;
                        MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + txtLocation.Text.ToUpper() + " at : " + DateTime.Now;
                    }
                    else
                    {
                        query = "SELECT tx.Loca,tx.Loca_Descrip FROM dbo.Location L JOIN dbo.Location TX ON tx.Loca=L.TaxLocaCode JOIN dbo.Employee E ON tx.Loca=E.Loca WHERE E.Emp_Name='" + txtUsername.Text.Trim() + "' AND E.Pass_Word='" + txtPassword.Text.Trim() + "' AND E.TaxUser=1";
                        string loca = "";
                        string locaName = "";
                        clsLogin.GetTaxLoca(query, ref loca, ref locaName);

                        location = locaName;
                        LoginManager.Location = locaName;
                        LoginManager.LocaCode = loca;

                        if (LoginManager.LocaCode == "")
                        {
                            MessageBox.Show("Invalid User Name.. Contact System Provider !", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + LoginManager.Location + " at : " + DateTime.Now;

                        LoginManager.TaxLocaLogin = true;

                        try
                        {
                            MainClass.mdi.BackgroundImage = Image.FromFile(@"..\Wallpaper\" + Settings.Default.Back_Image + "tax.jpg");

                        }
                        catch
                        {
                            MainClass.mdi.BackgroundImage = global::Inventory.Properties.Resources.Super_Seller_1;
                        }
                    }



                    ObjLoginmanager.CompanyDetails("SELECT CompanyName, CompanyAddress, CompanyTelephone, CompanyEmail FROM CompanyProfile");
                    // LoginManager.
                    // "SELECT CompanyName, CompanyAddress, CompanyTelephone, CompanyEmail FROM CompanyProfile"
                    //  location = txtLocation.Text;

                    //  LoginManager.UserName = txtUsername.Text;
                    //  LoginManager.Location = txtLocation.Text;
                    //  LoginManager.LocaCode = search.Code;

                    //MDI pf = ParentForm as MDI;
                    MainClass.mdi.systemToolsToolStripMenuItem.Visible = true;
                    MainClass.mdi.mnuMain.Enabled = true;
                    MainClass.mdi.toolStrip1.Visible = true;
                    if (LoginManager.UserName.ToUpper() == "ONIMTA" && txtPassword.Text == "2302")
                    {
                        MainClass.mdi.settingsToolStripMenuItem.Visible = true;

                    }
                    else
                    {
                        MainClass.mdi.settingsToolStripMenuItem.Visible = false;

                    }


                    if (Settings.Default.NewInvSrchMode == true)
                    {
                        Task.Run(() => MainClass.LoadItemData());
                        Task.Run(() => MainClass.StartListening());
                    }
                    //menu visible true for user

                    //if(MessageBox.Show("Suew",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    //{
                    LoadMenus();
                    //MainClass.mdi.MenuFromSettins();
                    //}
                    //else
                    //{
                    //    this.MenuVisibleTrueFalse();
                    //}

                    //

                    //MainClass.mdi.Text = txtUsername.Text.ToUpper() + " Logged On to : " + txtLocation.Text.ToUpper() + " at : " + DateTime.Now;
                    if (chkRemember.Checked)
                    {
                        Settings.Default.LoggedLoca = LoginManager.LocaCode;
                        Settings.Default.LoggedUser = txtUsername.Text;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Settings.Default.LoggedLoca = string.Empty;
                        Settings.Default.LoggedUser = string.Empty;
                        Settings.Default.Save();
                    }

                    if (Settings.Default.ShowLoginRep == true)
                    {
                        frmReportViewer objRepViewer = new frmReportViewer();
                        clsReportViewer objRepView = new clsReportViewer();
                        objRepView.SqlStatement = "EXEC dbo.Sp_GetReport @Report = '410', @Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsReOrderLevelDetails";
                        objRepView.RetrieveData();
                        DataSet dsDataForReport = objRepView.TempResultSet;

                        if (dsDataForReport.Tables[0].Rows.Count > 0 && MessageBox.Show("Reorder Items Found Do You want view Report?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rptReOrderLevelReport ReOrderLevel = new rptReOrderLevelReport();
                            ReOrderLevel.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ReOrderLevel;
                            objRepViewer.WindowState = FormWindowState.Maximized;
                            MainClass.mdi.Cursor = Cursors.Default;
                            objRepViewer.Refresh();
                            objRepViewer.Show();
                        }

                      

                    }
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

        public void LoadMenus()
        {
            try
            {

                string sqlStatement = "SELECT MenuId, Allow FROM tb_UserRoleDetails TS JOIN dbo.Employee E ON E.UserRole_Id=ts.UserRoleId WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='"+LoginManager.LocaCode+"' ORDER BY MenuId";
                DataSet R =objclsSettings.getData(sqlStatement);
                foreach (DataRow dr in R.Tables[0].Rows )
                {
                     
                        string MenuId = dr["MenuId"].ToString();
                        bool Allow = Convert.ToBoolean(dr["Allow"]);

                        setVisibility(MainClass.mdi.mnuMain.Items, MenuId, Allow);
                        setVisibilityToolTip(MainClass.mdi.toolStrip1.Items, MenuId, Allow);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void setVisibility(ToolStripItemCollection tsic, string MenuId, bool Allow)
        {
            //foreach (ToolStripItem item in tsic)
            //{
            //    ToolStripMenuItem menuItem = item as ToolStripMenuItem;
            //    if (menuItem == null)
            //    {

            //        continue;
            //    }

            //    if (menuItem is ToolStripMenuItem)
            //    {
            //        menuItem.Visible = false;

            //    }
            //}


            foreach (ToolStripItem item in tsic)
            {
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                if (menuItem == null)
                {

                    continue;
                }

                if (menuItem is ToolStripMenuItem)
                {

                    if (menuItem.Name.ToString() == "paymentsToolStripMenuItem" 
                        && MenuId.ToString() == "paymentsToolStripMenuItem")
                    {
                        string cc = "";
                    }
                    if (menuItem.Name.ToString() == MenuId)
                    {
                        menuItem.Visible = Allow;

                    }
                    else
                    {
                        if (menuItem.DropDownItems.Count > 0)
                        {
                            setVisibility(menuItem.DropDownItems, MenuId, Allow);
                        }
                    }

                }
            }

            /*
            foreach (ToolStripItem item in tsic)
            {
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                if (menuItem == null)
                {

                    continue;
                }

                if (menuItem is ToolStripMenuItem && menuItem.Tag != null && menuItem.Tag.ToString() != "NO")
                {
                    if (menuItem.Tag != null && menuItem.Tag.ToString() != "NO")
                    {
                        if (menuItem.Tag.ToString() == MenuId)
                        {
                            menuItem.Visible = Allow;

                        }
                        else
                        {
                            if (menuItem.DropDownItems.Count > 0 && item.Tag.ToString() != "NO")
                            {
                                setVisibility(menuItem.DropDownItems, MenuId, Allow);
                            }
                        }
                    }
                    else
                    {
                        menuItem.Visible = false;
                    }
                }
            }

            */
            /* foreach (ToolStripSeparator item in tsic)
              {
                  //if (item is ToolStripMenuItem  && item.Tag != null && item.Tag.ToString() != "NO")
                  //{
                  //   if (item.Tag != null && item.Tag.ToString()!="NO")
                  //    {
                  //        if (item.Tag.ToString() == MenuId)
                  //        {
                  //            item.Visible = Allow;

                  //        }
                  //        else
                  //        {
                  //            if (item.DropDownItems.Count > 0 && item.Tag.ToString() != "NO")
                  //            {
                  //                setVisibility(item.DropDownItems, MenuId, Allow);
                  //            }
                  //        }
                  //    }
                  //    else
                  //    {
                  //        item.Visible = false;
                  //    }
                  //}


              }*/
        }
        private void setVisibilityToolTip(ToolStripItemCollection tsic, string MenuId, bool Allow)
        {

            //foreach (ToolStripItem item in tsic)
            //{
            //    ToolStripButton menuItem = item as ToolStripButton;
            //    if (menuItem == null)
            //    {
            //        continue;
            //    }

            //    if (menuItem is ToolStripButton && menuItem.Tag != null && menuItem.Tag.ToString() != "NO")
            //    {
            //        if (menuItem.Tag != null)
            //        {
            //            if (menuItem.Tag.ToString() == MenuId)
            //            {
            //                menuItem.Visible = Allow;

            //            }

            //        }
            //        else
            //        {
            //            menuItem.Visible = false;
            //        }
            //    }
            //}

            foreach (ToolStripItem item in tsic)
            {
                ToolStripButton menuItem = item as ToolStripButton;
                if (menuItem == null)
                {

                    continue;
                }

                if (menuItem is ToolStripButton)
                {
                    if (menuItem.Name.ToString() == MenuId + "Tool")
                    {
                        menuItem.Visible = Allow;
                    }
                }
            }

            if (
                MainClass.mdi.purchaseOrderNoteToolStripMenuItem2Tool.Visible == false &&
                MainClass.mdi.goodReceivedNoteToolStripMenuItem2Tool.Visible == false &&
                MainClass.mdi.SupplierReturnToolStripMenuItemTool.Visible == false &&
                MainClass.mdi.transferOfGoodsNoteToolStripMenuItem1Tool.Visible == false

                )
            {
                MainClass.mdi.toolStripSeparator2.Visible = false;
            }
            else
            {
                MainClass.mdi.toolStripSeparator2.Visible = true;
            }

            if (
           MainClass.mdi.wholeSaleInvoiceToolStripMenuItem2Tool.Visible == false &&
           MainClass.mdi.quotationToolStripMenuItem.Visible == false 

           )
            {
                MainClass.mdi.toolStripSeparator3.Visible = false;
            }
            else
            {
                MainClass.mdi.toolStripSeparator3.Visible = true;
            }
            if (
       MainClass.mdi.receiptToolStripMenuItem1Tool.Visible == false &&
       MainClass.mdi.supplierPaymentToolStripMenuItem1Tool.Visible == false

       )
            {
                MainClass.mdi.toolStripSeparator4.Visible = false;
            }
            else
            {
                MainClass.mdi.toolStripSeparator4.Visible = false;
            }


    //        if (
    //MainClass.mdi.receivedOnAccToolStripMenuItem1Tool.Visible == false &&
    //MainClass.mdi.cashDenominationToolStripMenuItem2Tool.Visible == false

    //)
    //        {
    //            MainClass.mdi.toolStripSeparator14.Visible = false;
    //        }
    //        else
    //        {
    //            MainClass.mdi.toolStripSeparator14.Visible = true;
    //        }


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
                else if (e.KeyCode == Keys.F5)
                {
                    btnLocation.PerformClick();
                }

                if (e.KeyCode == Keys.Enter)
                {
                    txtUsername.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {

                    DataTable dt = clsLocation.getLocationDetailsForLogging(txtLocation.Text.Trim().ToUpper());
                    if (dt.Rows.Count > 0)
                    {
                        search.Descript = txtLocation.Text = dt.Rows[0]["Description"].ToString();
                        search.Code = dt.Rows[0]["Code"].ToString();
                    }
                    txtUsername.Focus();
                }
                //if (e.KeyCode == Keys.Escape)
                //{
                //    Application.Exit();
                //}
                //if (e.KeyCode==Keys.Enter && txtLocation.Text != "")
                //{
                //    txtUsername.SelectAll();
                //    txtUsername.Focus();
                //}
                //if (e.KeyCode==Keys.F1)
                //{
                //    btnLocation.PerformClick();
                //}
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

                selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location WHERE  Loca LIKE '%" + LoginManager.ReadLocaN + "%' " +
                    "and Loca<>'" + LoginManager.ExtLoca + "' and TaxLoca=0 ORDER BY Loca";
                grdLoca.DataSource = clsLocation.getLocationsForLogging(selectquery);


                if (Settings.Default.LoggedUser != string.Empty)
                {
                    txtLocation.Text = Settings.Default.LoggedLoca;
                    txtLocation_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                    txtUsername.Text = Settings.Default.LoggedUser;
                    chkRemember.Checked = true;
                    txtPassword.Focus();
                }
                else
                {
                    chkRemember.Checked = false;
                }
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
                    mdi.mnuDepartmentTool.Visible = true;
                    mdi.mnuCategoryTool.Visible = true;
                    mdi.supplierToolStripMenuItem1Tool.Visible = true;
                    mdi.productToolStripMenuItemTool.Visible = true;
                }
                else
                {
                    mdi.masterFileToolStripMenuItem.Visible = false;
                    mdi.mnuDepartmentTool.Visible = false;
                    mdi.mnuCategoryTool.Visible = false;
                    mdi.supplierToolStripMenuItem1Tool.Visible = false;
                    mdi.productToolStripMenuItemTool.Visible = false;
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
                    mdi.purchaseOrderNoteToolStripMenuItem2Tool.Visible = true;
                }
                else
                {
                    mdi.purchaseOrderNoteToolStripMenuItem2.Visible = false;
                    mdi.purchaseOrderNoteToolStripMenuItem2Tool.Visible = false;
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
                    mdi.goodReceivedNoteToolStripMenuItem2Tool.Visible = true;
                }
                else
                {
                    mdi.goodReceivedNoteToolStripMenuItem2.Visible = false;
                    mdi.goodReceivedNoteToolStripMenuItem2Tool.Visible = false;
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
                    mdi.SupplierReturnToolStripMenuItem.Visible = true;
                    mdi.SupplierReturnToolStripMenuItemTool.Visible = true;
                }
                else
                {
                    mdi.SupplierReturnToolStripMenuItem.Visible = false;
                    mdi.SupplierReturnToolStripMenuItemTool.Visible = false;
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
                    mdi.transferOfGoodsNoteToolStripMenuItem1Tool.Visible = true;
                }
                else
                {
                    mdi.transferOfGoodsNoteToolStripMenuItem1.Visible = false;
                    mdi.transferOfGoodsNoteToolStripMenuItem1Tool.Visible = false;
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
                    mdi.wholeSaleInvoiceToolStripMenuItem2Tool.Visible = true;
                    mdi.quotationToolStripMenuItem.Visible = true;
                }
                else
                {
                    mdi.wholeSaleInvoiceToolStripMenuItem2.Visible = false;
                    mdi.wholeSaleInvoiceToolStripMenuItem2Tool.Visible = false;
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
                    mdi.supplierPaymentToolStripMenuItem1Tool.Visible = true;
                }
                else
                {
                    mdi.supplierPaymentToolStripMenuItem1.Visible = false;
                    mdi.supplierPaymentToolStripMenuItem1Tool.Visible = false;
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
                    mdi.receiptToolStripMenuItem1Tool.Visible = true;
                }
                else
                {
                    mdi.receiptToolStripMenuItem1.Visible = false;
                    mdi.receiptToolStripMenuItem1Tool.Visible = false;
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
                         mdi.mnuProduct.Visible = false;
                        //productPriceMasterToolStripMenuItem
                        mdi.salesmanToolStripMenuItem.Visible = false;
                     //   mdi.packetingProductToolStripMenuItem.Visible = false;
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
                    mdi.receivedOnAccToolStripMenuItem1Tool.Visible = true;
                }
                else
                {
                    mdi.receivedOnAccToolStripMenuItem1.Visible = false;
                    mdi.receivedOnAccToolStripMenuItem1Tool.Visible = false;
                }
                if (objUserProfile.CDNM == "T")
                {
                    mdi.cashDenominationToolStripMenuItem2.Visible = true;
                    mdi.cashDenominationToolStripMenuItem2Tool.Visible = true;
                }
                else
                {
                    mdi.cashDenominationToolStripMenuItem2.Visible = false;
                    mdi.cashDenominationToolStripMenuItem2Tool.Visible = false;
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

                //first time logging get token
                //if (LoginSys.backEndStatus == "MSSQL-API")
                //{
                //    if (LoginSys.Token == "" || LoginSys.Token == null)
                //    {
                //        clsCommonApi api = new clsCommonApi();
                //        string locaForToken = search.Code;
                //        //For Extension Location
                //        if (txtUsername.Text.Trim().ToUpper() == LoginManager.ExtUserName.ToUpper() && txtPassword.Text.Trim().ToUpper() == LoginManager.ExtPassword.ToUpper())
                //        {
                //            locaForToken = LoginManager.ExtLoca;
                //        }
                //        else if (txtUsername.Text.Trim().ToUpper() == LoginManager.ExtUserName2.ToUpper() && txtPassword.Text.Trim().ToUpper() == LoginManager.ExtPassword2.ToUpper())
                //        {
                //            locaForToken = LoginManager.ExtLoca2;
                //        }
                //        //**********************
                //        ///For Token
                //        LoginSys.UserName = txtUsername.Text.Trim();
                //        LoginSys.Password = txtPassword.Text.Trim();
                //        LoginSys.LocaCode = locaForToken;
                //        api.RetriveTokenFromServer();
                //        if (LoginSys.Token == "" || LoginSys.Token == null)
                //        {
                //            MessageBox.Show("User Credentials Wrong For Get Token!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return;
                //        }
                        
                //    }

                //}


                try
                {

                    frmSettings frmsettings = new frmSettings();
                    frmSettings.GetSettings = new frmSettings();
                    frmSettings.GetSettings.frmSettings_Load(sender, e);
                    frmSettings.GetSettings = null;

                    MDI mdi = ParentForm as MDI;
                    if (Settings.Default.Person != string.Empty)
                    {
                        mdi.technicianToolStripMenuItem.Text = Settings.Default.Person;
                        mdi.technicianSalesAnalyseToolStripMenuItem.Text = Settings.Default.Person + " Sales Analyse";
                        mdi.technicianWiseSalesReportToolStripMenuItem.Text = Settings.Default.Person + " Wise Sales Report";
                        mdi.technicianWiseProductSalesReportToolStripMenuItem.Text = Settings.Default.Person + " Wise Product Sales Report";
                        mdi.technicianWiseInvoiceReportToolStripMenuItem.Text = Settings.Default.Person + " Wise Invoice Report";
                        mdi.technicianWiseSalesPerformanceToolStripMenuItem.Text = Settings.Default.Person + " Wise Sales Performance";
                        mdi.technicianChargeReportToolStripMenuItem1.Text = Settings.Default.Person + " Charge Report";

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Settings File Error!"+ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                    //clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }



                objUserProfile.SqlStatement = "SELECT Id_No, UserRole_Id FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" +search.Code+ "') AND Acc_Desable = 'T'";
                objUserProfile.ReadUserName();
                if (objUserProfile.RecordFound == true)
                {
                    MessageBox.Show("Your password is currently disabled.\n\rPlease contact system administrator","Login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                objUserProfile.SqlStatement = "SELECT UserRole_Id, EXPDate FROM Employee WHERE(Emp_Name = '" + txtUsername.Text + "') AND (Pass_Word = '" + txtPassword.Text + "') AND (Loca = '" +search.Code+ "') AND EXPDate < GETDATE()";
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void grdLoca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (grdLoca.SelectedRows.Count <= 0 || grdLoca.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtLocation.Text = grdLoca.SelectedRows[0].Cells[0].Value.ToString();
                    txtLocation_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                    if (txtUsername.Text.Trim() != string.Empty)
                    {
                        txtPassword.Focus();
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