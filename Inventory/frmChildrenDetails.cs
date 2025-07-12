using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmChildrenDetails : Form
    {
        private static frmChildrenDetails _ChildrenDetails;

        clsCRMCustomer ObjCustomer = new clsCRMCustomer();

        public static frmChildrenDetails GetChildrenDetails
        {
            get { return _ChildrenDetails; }
            set { _ChildrenDetails = value; }
        }

        public frmChildrenDetails()
        {
            InitializeComponent();
        }

        private void frmChildrenDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ChildrenDetails = null;
        }

        private void txtChildName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtChildName.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter name", "CRM Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtChildName.Focus();
                    }
                    else
                    {
                        cmbChildSex.SelectAll();
                        cmbChildSex.Focus();
                    }
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
            }
        }

        private void cmbChildSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpChildBirthday.Focus();
            }
        }

        private void dtpChildBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtChildName.Text == string.Empty)
                {
                    MessageBox.Show("Children Name is Empty !", "CRM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtChildName.Focus();
                }
                else if (cmbChildSex.Text == string.Empty)
                {
                    MessageBox.Show("Children Sex is Empty !", "CRM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbChildSex.Focus();
                }
                else
                {
                    try
                    {
                        ObjCustomer.ChildName = txtChildName.Text.Trim();
                        ObjCustomer.ChildSex = cmbChildSex.Text.Trim();
                        ObjCustomer.ChildBirthday = dtpChildBirthday.Text.Trim();
                        ObjCustomer.CusCode = lblCustCode.Text.Trim();
                        ObjCustomer.ChildrenUpdate();
                        dgChildren.DataSource = ObjCustomer.dataset.Tables["dsChildrenDetails"];
                        dgChildren.Refresh();

                        if (dgChildren.RowCount == 5)
                        {
                            txtChildName.Enabled = false;
                            cmbChildSex.Enabled = false;
                            dtpChildBirthday.Enabled = false;
                            btnSave.Focus();

                        }
                        txtChildName.SelectAll();
                        txtChildName.Focus();
                    }
                    catch (Exception ex)
                    {
                        clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                    finally
                    {
                        txtChildName.Text = string.Empty;
                        cmbChildSex.Text = string.Empty;
                    }
                }
            }
        }

        private void frmChildrenDetails_Load(object sender, EventArgs e)
        {
            try
            {
                ObjCustomer.dataset = ObjCustomer.getDataSet("SELECT Name,Sex,CONVERT(VARCHAR,Birthday,103) AS [Birthday] FROM crm_ChildrenDetails WHERE EmpCode='" + lblCustCode.Text.Trim() + "' ORDER BY Name", "dsChildrenDetails");
                dgChildren.DataSource = ObjCustomer.dataset.Tables["dsChildrenDetails"];
                dgChildren.Refresh();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgChildren_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtChildName.Text = dgChildren.SelectedRows[0].Cells[0].Value.ToString();
                cmbChildSex.Text = dgChildren.SelectedRows[0].Cells[1].Value.ToString();
                dtpChildBirthday.Text = dgChildren.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgChildren_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmChildrenDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void dgChildren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (MessageBox.Show("Are you sure, You want to delele this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ObjCustomer.CusCode = lblCustCode.Text.Trim();
                        ObjCustomer.ChildName = dgChildren.SelectedRows[0].Cells[0].Value.ToString();
                        ObjCustomer.ChildSex = dgChildren.SelectedRows[0].Cells[1].Value.ToString();
                        ObjCustomer.ChildDelete();
                        ObjCustomer.getDataset("SELECT [Name], Sex, Birthday FROM CRM_ChildrenDetails WHERE EmpCode='" + lblCustCode.Text.Trim() + "'", "dsChildrenDetails"); 
                        dgChildren.DataSource = ObjCustomer.dataset.Tables["dsChildrenDetails"];
                        dgChildren.Refresh();
                    }
                    catch (Exception ex)
                    {
                        clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                }
            }
        }
    }
}