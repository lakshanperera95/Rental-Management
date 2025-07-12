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
    public partial class frmStaff : Form
    {
        public frmStaff()
        {
            InitializeComponent();
        }

        private static frmStaff Staff;
        frmSearch search = new frmSearch();
        private clsManufacturer man = new clsManufacturer();
        clsCommon common = new clsCommon();

        private int Err = 0;

        public static frmStaff GetStaff
        {
            get
            {
                return Staff;
            }
            set
            {
                Staff = value;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                man.SqlString = "SELECT Staff_Code AS [Code],Staff_Name AS [Name] FROM [tb_Staff]";
                man.RetrieveFields_ManCode();
                search.dgSearch.DataSource = man.GetDataset1.Tables["dsManCode"];
                search.prop_Focus = txtCode;
                search.Show();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCode.Text = search.Code.Trim();
                    txtDescript.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #region ToolStrip Buttons 
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Err = 0;

                if (cmbDepartment.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Department not found", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDepartment.Focus();
                    return;
                }

                if (cmbDesignation.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Designation not found", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDesignation.Focus();
                    return;
                }

                if ((txtDescript.Text == string.Empty))
                {
                    MessageBox.Show("Staff Details not found", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Err++;
                    return;
                }

                common.Recordfind("SELECT * FROM dbo.tb_Staff WHERE Department='" + cmbDepartment.Text.Trim() + "' AND Staff_Code<>'" + txtCode.Text.Trim() + "' AND Staff_Name='" + txtDescript.Text.Trim() + "'");
                if (common.RecRead)
                {
                    MessageBox.Show("Staff name allready exsists...", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCode.Focus();
                    btnSearch.PerformClick();
                    return;
                }

                this.validator(grpMain);

                if (Err == 0)
                {
                    man.ErrorCode = 0;
                    man.Code = txtCode.Text.Trim().ToUpper();
                    man.Descript = txtDescript.Text.Trim().ToUpper();
                    man.Address1 = txtAdd1.Text.Trim().ToUpper();
                    man.Address2 = txtAdd2.Text.Trim().ToUpper();
                    man.Address3 = txtAdd3.Text.Trim().ToUpper();
                    man.City = txtCity.Text.Trim().ToUpper();
                    man.Country = txtCountry.Text.Trim().ToUpper();
                    man.Tel = txtTel.Text.Trim().ToUpper();
                    man.Fax = txtFax.Text.Trim().ToUpper();
                    man.Email = txtEmail.Text.Trim();
                    man.Status = chkStatus.Checked;
                    //-----------------------------------
                    man.Department = cmbDepartment.Text;
                    man.Designation = cmbDesignation.Text;
                    man.NIC = txtNIC.Text;
                    //------------------------------------

                    //clear all the properties used in search form
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                    search.prop_Focus = null;
                    search.prop_Name = string.Empty;

                    man.UpdateStaffData();
                    cmbDepartment.SelectedIndex = cmbDesignation.SelectedIndex = -1;
                    clsClear.getclear().clearfeilds(grpMain, txtCode);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text != string.Empty)
                {

                    //if (MessageBox.Show("Do you really want to delete the record ?  " + txtCode.Text + "", "Manufacturer Details",
                    //MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    //== DialogResult.Yes)
                    //{
                    //    man.Code = txtCode.Text.ToUpper().Trim();
                    //    man.DeleteData();
                    //    clsClear.getclear().clearfeilds(grpMain, txtCode);
                    //}
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                cmbDepartment.SelectedIndex = cmbDesignation.SelectedIndex = -1;
                clsClear.getclear().clearfeilds(grpMain, txtCode);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                this.Close();
                this.Dispose();
                Staff = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        #endregion

        private void frmStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Staff = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #region Validate whether textfeilds contains ' character
        public void validator(Control cnt)
        {
            try
            {
                for (int i = 0; i < cnt.Controls.Count; i++)
                {
                    if ((cnt.Controls[i].GetType() == typeof(TextBox)) && (cnt.Controls[i].Text.Contains("'")))
                    {
                        MessageBox.Show("Invalid characters in Textfeilds Please check the characters entered.", "Invalid character (') found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cnt.Controls[i].Text = string.Empty;
                        cnt.Controls[i].Focus();

                        Err++;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #endregion 

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCode.Text != string.Empty)
                    {
                        man.SqlString = "SELECT Staff_Name,Address1,Address2,Address3,City,Tel,Email,[Disable],Country,Fax,Designation,Department,NIC FROM tb_Staff WHERE Staff_Code = '" + txtCode.Text + "'";
                        man.RetrieveFields_CustomerDetails();
                        if (man.GetDataset1.Tables["dsManDetails"].Rows.Count > 0)
                        {
                            txtDescript.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][0].ToString();
                            txtAdd1.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][1].ToString();
                            txtAdd2.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][2].ToString();
                            txtAdd3.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][3].ToString();
                            txtCity.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][4].ToString();
                            txtTel.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][5].ToString();
                            txtEmail.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][6].ToString();
                            chkStatus.Checked = Convert.ToBoolean(man.GetDataset1.Tables["dsManDetails"].Rows[0][7]);
                            txtCountry.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][8].ToString();
                            txtFax.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][9].ToString();
                            cmbDesignation.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][10].ToString();
                            cmbDepartment.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][11].ToString();
                            txtNIC.Text = man.GetDataset1.Tables["dsManDetails"].Rows[0][12].ToString();

                            txtDescript.Focus();

                        }

                    }
                    txtDescript.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDescript_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAdd1.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtAdd2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAdd3.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtAdd3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtAdd1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAdd2.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTel.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTel.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmail.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNIC.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNIC.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStaff_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.D)
                        {
                            this.btnDelete.PerformClick();
                        }
                        else
                        {
                            if (e.KeyCode == Keys.L)
                            {
                                this.btnClear.PerformClick();
                            }
                            else
                            {
                                if (e.KeyCode == Keys.E)
                                {
                                    this.btnExit.PerformClick();
                                }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 019.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStaff_Load(object sender, EventArgs e)
        {
            try
            {
                //common.Reading("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'ESMST' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                //if (!common.RecordFound)
                //{
                //    btnSave.Enabled = false;
                //    btnDelete.Enabled = false;
                //}


                common.SqlStatement = "SELECT Descr FROM dbo.tb_FormSettings WHERE FType='EMDEPT' ORDER BY Code; SELECT Descr FROM dbo.tb_FormSettings WHERE FType='EMDESGN' ORDER BY Code";
                common.getDataSet(common.SqlStatement, "ds");             

                cmbDepartment.DataSource = common.Ads.Tables[0];
                cmbDepartment.DisplayMember = "Descr";
                cmbDepartment.SelectedIndex = -1;

                cmbDesignation.DataSource = common.Ads.Tables[1];
                cmbDesignation.DisplayMember = "Descr";
                cmbDesignation.SelectedIndex = -1;



            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmManufacture 019.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDesignation.Focus();
            }
        }

        private void cmbDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Select();
            }
        }
    }

}