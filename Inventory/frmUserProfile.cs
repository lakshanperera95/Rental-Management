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
    public partial class frmUserProfile : Form
    {
        public frmUserProfile()
        {
            InitializeComponent();
            txtPassword.PasswordChar = (char)0x25CF;
            txtConfirmPassword.PasswordChar = (char)0x25CF;
        }

        frmSearch search = new frmSearch();
        clsUserProfile objUserProfile = new clsUserProfile();

        private string strQuery;

        private static frmUserProfile UserProfile;
        public static frmUserProfile GetUserProfile
        {
            get
            {
                return UserProfile;
            }
            set
            {
                UserProfile = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                UserProfile = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            
        private void frmUserProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                UserProfile = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmUserProfile_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void UserLoad()
        {
            try
            {
                objUserProfile.dsName = "dsUserRoleMaster";
                objUserProfile.SqlStatement = "select UserRole_Description from tbUserRoleMaster";
                objUserProfile.RetriveData();
                cmbMemberOf.Items.Clear();
                foreach (DataRow row in objUserProfile.ResultSet.Tables["dsUserRoleMaster"].Rows)
                {
                    cmbMemberOf.Items.Add(row["UserRole_Description"]);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            UserLoad();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Trim() != string.Empty)
                {
                    txtPassword.Enabled = true;
                    txtConfirmPassword.Enabled = true;
                    chkAccountDesable.Enabled = true;
                    chkUserCannotchangepwd.Enabled = true;
                    chkUserMustChangePwd.Enabled = true;
                    btnAdvance.Enabled = true;
                    btnCreate.Enabled = true;
                    cmbMemberOf.Enabled = true;
                }
                else
                {
                    txtPassword.Enabled = false;
                    txtConfirmPassword.Enabled = false;
                    chkAccountDesable.Enabled = false;
                    chkUserCannotchangepwd.Enabled = false;
                    chkUserMustChangePwd.Enabled = false;
                    btnAdvance.Enabled = false;
                    btnCreate.Enabled = false;
                    cmbMemberOf.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSearchCodeFrom_Click(object sender, EventArgs e)
        {
            MainClass.mdi.Cursor = Cursors.WaitCursor;
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                strQuery = "SELECT Emp_Name AS [User Name], Loca [Loca] from employee WHERE Loca = '" + LoginManager.LocaCode + "' ORDER BY [User Name]";

                objUserProfile.SqlStatement = strQuery;
                objUserProfile.dsName = "Table";
                objUserProfile.RetriveData();

                search.dgSearch.DataSource = objUserProfile.ResultSet.Tables["Table"];
                search.Show();

                search.prop_Focus = txtUserName;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                objUserProfile.SqlStatement = "SELECT Emp_Name, Loca FROM Employee WHERE Emp_Name = '" + txtUserName.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode + "'";
                objUserProfile.ReadUserName();
                if (objUserProfile.RecordFound == true && btnCreate.Text == "&Create")
                {
                    MessageBox.Show("The User Name Already Exists. Please Use Another User Name", "User Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    if (cmbMemberOf.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please Select Member Of.", "User Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMemberOf.Focus();
                        return;
                    }

                    if (txtPassword.Text.Trim().ToUpper() != txtConfirmPassword.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("The Password was Not Correctly Confirmed. Please Check Password and Confirmed Password are Match exactly.", "User Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        return;
                    }

                    objUserProfile.UserName = txtUserName.Text.Trim();
                    objUserProfile.Password = txtPassword.Text.Trim();
                    objUserProfile.ExpDate = dtExpDate.Value;
                    objUserProfile.ChgPwdNxtLogin = (chkUserMustChangePwd.Checked) ? "T" : "F";
                    objUserProfile.UserCannotChgPwd = (chkUserCannotchangepwd.Checked) ? "T" : "F";
                    objUserProfile.Acc_Desable = (chkAccountDesable.Checked) ? "T" : "F";
                    objUserProfile.TransCan = (chkTransCancel.Checked) ? "T" : "F";


                    objUserProfile.SqlStatement = "select convert(decimal,UserRole_Id) UserRole_Id from tbUserRoleMaster where UserRole_Description = '" + cmbMemberOf.Text.Trim() + "'";
                    objUserProfile.ReadUserRoleID();
                    if (objUserProfile.RecordFound == false)
                    {
                        MessageBox.Show("Invalid Member. Please Select Member Of.", "User Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMemberOf.Focus();
                        return;
                    }

                    objUserProfile.CreateUser();
                    MessageBox.Show("User Created Successfully.", "User Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    dtExpDate.Value = DateTime.Now.AddDays(15);
                    txtConfirmPassword.Text = string.Empty;
                    chkAccountDesable.Checked = false;
                    chkUserCannotchangepwd.Checked = false;
                    chkUserMustChangePwd.Checked = false;
                    cmbMemberOf.Text = string.Empty;

                    txtUserName.Focus();
                    return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtUserName.Text.Trim() != "")
                {
                    objUserProfile.SqlStatement = "SELECT CONVERT(DECIMAL,tbUserRoleMaster.UserRole_Id) UserRole_Id, tbUserRoleMaster.UserRole_Description, Acc_Desable, UserCannotChgPwd, ExpDate, Employee.Pass_Word,Trans_Cancel FROM Employee INNER JOIN tbUserRoleMaster ON tbUserRoleMaster.UserRole_Id = Employee.UserRole_Id WHERE Employee.Emp_Name = '" + txtUserName.Text.Trim() + "' AND Employee.Loca = '" + LoginManager.LocaCode + "'";
                    objUserProfile.ReadUserDetails();
                    if (objUserProfile.RecordFound == true)
                    {
                        cmbMemberOf.Text = objUserProfile.UserRole_Description.ToString();
                        txtConfirmPassword.Text = txtPassword.Text = objUserProfile.Password.ToString();
                        dtExpDate.Value = objUserProfile.ExpDate;
                        if (objUserProfile.Acc_Desable.ToString() == "F")
                        {
                            chkAccountDesable.Checked = false;
                        }
                        else
                        {
                            chkAccountDesable.Checked = true;
                        }
                        if (objUserProfile.UserCannotChgPwd.ToString() == "F")
                        {
                            chkUserCannotchangepwd.Checked = false;
                        }
                        else
                        {
                            chkUserCannotchangepwd.Checked = true;
                        }
                        if (objUserProfile.TransCan.ToString() == "F")
                        {
                            chkTransCancel.Checked = false;
                        }
                        else
                        {
                            chkTransCancel.Checked = true;
                        }
                        txtPassword.Focus();
                        btnDelete.Enabled = true;
                    }
                    else
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && txtPassword.Text.Trim() != "")
                {
                    txtConfirmPassword.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtPassword.Text.Trim() != "")
                {
                    if (txtPassword.Text.Trim().ToUpper() != txtConfirmPassword.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("The Password was Not Correctly Confirmed. Please Check Password and Confirmed Password are Match exactly.", "User Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        return;
                    }
                    else
                    {
                        cmbMemberOf.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmUserProfile 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            MDI mdi = ParentForm as MDI;
            /*if (frmUserRoleMaster.GetUserRoleMaster == null)
            {
                frmUserRoleMaster.GetUserRoleMaster = new frmUserRoleMaster();
                frmUserRoleMaster.GetUserRoleMaster.MdiParent = mdi;
                frmUserRoleMaster.GetUserRoleMaster.Show();
            }
            else
            {
                frmUserRoleMaster.GetUserRoleMaster.Focus();
            }*/

            if (frmUserRole.AobjUserRole == null)
            {
                frmUserRole.AobjUserRole = new frmUserRole();
                frmUserRole.AobjUserRole.MdiParent = MainClass.mdi;
                frmUserRole.AobjUserRole.UserRole = cmbMemberOf.Text;
                frmUserRole.AobjUserRole.Show();
            }
            else
            {
                frmUserRole.AobjUserRole.Focus();
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                objUserProfile.SqlStatement = "SELECT Emp_Name, Loca FROM Employee WHERE Emp_Name = '" + txtUserName.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode + "'";
                objUserProfile.ReadUserName();
                if (objUserProfile.RecordFound == true)
                {
                    btnCreate.Text = "E&dit";
                }
                else
                {
                    btnCreate.Text = "&Create";
                }
            }
            finally
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objUserProfile.UserName = txtUserName.Text.Trim();
                objUserProfile.DeleteEmployee();

                if (objUserProfile.FocusCont != "")
                {
                    this.Controls.Find(objUserProfile.FocusCont, true)[0].Focus();
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

    }
}