using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmDebtorBalance : Form
    {
        public frmDebtorBalance()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtBalance, System.Globalization.NumberStyles.Currency);
        }

        private string _iid;

        public string Iid
        {
            get { return _iid; }
            set { _iid = value; }
        }

        clsDebtorBalance objdebtorsBl = new clsDebtorBalance();
        private frmSearch search = new frmSearch();

        int A = 0;
        //int B = 0;

        private static frmDebtorBalance frmobjDebtors;
        public static frmDebtorBalance AfrmobjDebtors
        {
            get { return frmobjDebtors; }
            set { frmobjDebtors = value; }
        }

        private void btnProdsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                bool MultiCus = Settings.Default.MultiCus;
                string Loca = "";
                if (MultiCus == true)
                {
                    Loca = " and CLoca ='" + LoginManager.LocaCode + "' ";
                }

                if (Iid == "CUR")
                {
                    if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                        objdebtorsBl.ASqlString = "SELECT Cust_Code AS [Customer Code], Cust_Name AS [Customer Name] FROM Customer WHERE Iid = 'WSL' " + Loca + " ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                        {
                            objdebtorsBl.ASqlString = "SELECT Cust_Code AS [Customer Code], Cust_Name AS [Customer Name] FROM Customer WHERE Iid = 'WSL' AND Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' " + Loca + " ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                            {
                                objdebtorsBl.ASqlString = "SELECT Cust_Code AS [Customer Code], Cust_Name AS [Customer Name] FROM Customer WHERE Iid = 'WSL' AND Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%' " + Loca + " ORDER BY Cust_Name";
                            }
                            else
                            {
                                objdebtorsBl.ASqlString = "SELECT Cust_Code AS [Customer Code], Cust_Name AS [Customer Name] FROM Customer WHERE Iid = 'WSL' " + Loca + " ORDER BY Cust_Code";
                            }
                        }
                    } 
                }
                else
                {
                    if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                        objdebtorsBl.ASqlString = "SELECT Supp_Code [Suppier Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                        {
                            objdebtorsBl.ASqlString = "SELECT Supp_Code [Suppier Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtCustCode.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                            {
                                objdebtorsBl.ASqlString = "SELECT Supp_Code [Suppier Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtCustName.Text.Trim() + "%' ORDER BY Supp_Name";
                            }
                            else
                            {
                                objdebtorsBl.ASqlString = "SELECT Supp_Code [Suppier Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                    } 
                }

                objdebtorsBl.ADataSetName = "dsCustomer";
                objdebtorsBl.GetDebtorDetails();
                search.dgSearch.DataSource = objdebtorsBl.ADs.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Iid == "SUP")
                    {
                        objdebtorsBl.ASqlString = "SELECT Supp_Code [Cust_Code], Supp_Name [Cust_Name], Address1, Address2, Address3 FROM Supplier WHERE Supp_Code = '" + txtCustCode.Text.Trim().ToUpper() + "'";
                    }
                    else
                    {
                        objdebtorsBl.ASqlString = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM customer where Cust_Code = '" + txtCustCode.Text.Trim().ToUpper() + "'";
                    }
                    objdebtorsBl.ReadDebtorsDetails();
                    if (objdebtorsBl.AblRecordFound == true)
                    {
                        txtCustCode.Text = objdebtorsBl.ACustCode;
                        txtCustName.Text = objdebtorsBl.ACustName;
                        txtAddress.Text = objdebtorsBl.AAdd1;
                        txtAddress2.Text = objdebtorsBl.AAdd1;
                        txtAddress3.Text = objdebtorsBl.AAdd3;
                        dtToDate.Focus();


                        if (Iid == "SUP")
                        {
                            objdebtorsBl.ASqlString = "SELECT CAST(ISNULL(SUM(Balance_Amount),0) AS DECIMAL(18,2)) Balance_Amount FROM Payment_Summary  WHERE Acc_No = '" + txtCustCode.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode.ToString() + "'AND Acc_Type = 'SUP'";
                        }
                        else
                        {
                            objdebtorsBl.ASqlString = "SELECT CAST(ISNULL(SUM(Balance_Amount),0) AS DECIMAL(18,2)) Balance_Amount FROM Payment_Summary  WHERE Acc_No = '" + txtCustCode.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode.ToString() + "'AND Tr_Type = 'INV'";
                        }
                        
                        objdebtorsBl.ReadDebtorsBalance();
                        if (objdebtorsBl.AblRecordFound == true)
                        {
                            lblBalanceAmont.Text = objdebtorsBl.ABalanceAmnt.ToString();
                        }
                        else
                        {
                            lblBalanceAmont.Text = "0.00";
                        }
                    }
                    else
                    {
                        txtCustCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 016A. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBalance.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                AfrmobjDebtors = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmDebtorBalance_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                AfrmobjDebtors = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRefernace.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustCode.Text == "")
                {
                    MessageBox.Show("Customer Code Doesn't Exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustCode.Focus();
                    return;
                }
                if (txtCustName.Text == "")
                {
                    MessageBox.Show("Customer Name Doesn't Exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustName.Focus();
                    return;
                }
                if (txtBalance.Text == "")
                {
                    MessageBox.Show("DebtorBalance Doesn't Exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBalance.Focus();
                    return;
                }

                objdebtorsBl.CustCode = txtCustCode.Text.Trim().ToUpper();
                objdebtorsBl.CustName = txtCustName.Text.Trim().ToUpper();
                objdebtorsBl.AAdd1 = txtAddress.Text.Trim().ToUpper();
                objdebtorsBl.AAdd2 = txtAddress2.Text.Trim().ToUpper();
                objdebtorsBl.AAdd3 = txtAddress3.Text.Trim().ToUpper();
                objdebtorsBl.ABalance = decimal.Parse(txtBalance.Text);
                objdebtorsBl.ABalanceAmt = decimal.Parse(lblBalanceAmont.Text.Trim());
                objdebtorsBl.ADate = dtToDate.Text;
                objdebtorsBl.AReference = txtRefernace.Text.Trim();
                objdebtorsBl.ASqlString = "SELECT Acc_No FROM Payment_Summary WHERE KEYS = 'Added' AND Acc_No = '" + txtCustCode.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode + "'";
                objdebtorsBl.ReadAvalability();
                if (A == 0)
                {
                    objdebtorsBl.AuthonticateUser = LoginManager.UserName.ToString();
                    if (objdebtorsBl.AblRecordFound == true)
                    {
                        if (MessageBox.Show("You have Already Enterd Debtor Balance for this Customer" + "\n" + "Do You Want to Enter Another Balance?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtPassword.Text = "";
                            pnlPassword.Visible = true;
                            txtPassword.Focus();
                            return;
                        }
                        else
                        {
                            txtPassword.Text = "";
                            txtCustCode.Focus();
                            pnlPassword.Visible = false;
                            return;
                        }
                    }
                }
                if (Iid == "CUR")
                {
                    objdebtorsBl.DebtorBalanceApply("sp_DebtorBalanceApply");
                }
                else
                {
                    objdebtorsBl.DebtorBalanceApply("sp_CreditorBalanceApply");
                }


                btnClear.PerformClick();
                MessageBox.Show("Data Successfully Saved", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustCode.Focus();
                A = 0;
                pnlPassword.Visible = false;
                txtPassword.Text = "";
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustCode.Text = "";
            txtCustName.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtBalance.Text = "";
            txtRefernace.Text = "";
            lblBalanceAmont.Text = "0.00";
            txtCustCode.Focus();
        }

        private void txtRefernace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            objdebtorsBl.CheckedPasswordValid("SELECT Emp_Name,Pass_Word,GRNAPP,POAPP,SRNAPP,TOGAPP,OPBAPP,PRDAPP,BATCAPP FROM dbo.tb_UserRoleSettings Us JOIN dbo.Employee E ON E.UserRole_Id=Us.UserRoleID WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='" + LoginManager.LocaCode + "' AND Us.OPBAPP=1 And E.Pass_Word='"+txtPassword.Text+"'");
            if (txtPassword.Text.ToUpper() == objdebtorsBl.AuthonticatePassword.ToString())
            {
                pnlPassword.Visible = false;
                A = 1;

                btnSave.PerformClick();
            }
            else
            {
                MessageBox.Show("Invalied Password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                txtPassword.Text = string.Empty;
                return;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlPassword.Visible = false;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void frmDebtorBalance_Load(object sender, EventArgs e)
        {
            try
            {
                if (Iid == "SUP")
                {
                    label1.Text = "Suppier Id :";
                    label2.Text = "Supplier Name :";
                }
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}