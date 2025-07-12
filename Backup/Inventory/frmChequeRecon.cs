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
    public partial class frmChequeRecon : Form
    {
        public frmChequeRecon()
        {
            InitializeComponent();
        }

        clsChequeRecon objChequeRecon = new clsChequeRecon();

        private static frmChequeRecon ChequeRecon;

        private frmSearch search = new frmSearch();

        public static frmChequeRecon GetChequeRecon
        {
            get
            {
                return ChequeRecon;
            }
            set
            {
                ChequeRecon = value;
            }
        }

        private void frmChequeRecon_Load(object sender, EventArgs e)
        {
            try
            {
                objChequeRecon.SqlStatement = "SELECT Cheque_Recon_Temp FROM DocumentNoDetails WHERE Loca = ";
                objChequeRecon.GetTempDocumentNo();
                lblTempDocNo.Text = objChequeRecon.TempDocNo;
                dataGridViewChequeRecon.DataSource = objChequeRecon.TempChequeDeatils;
                dataGridViewChequeRecon.Refresh();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmChequeRecon_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmChequeRecon_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ChequeRecon = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                ChequeRecon = null;
            }
                        catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonCustomerReceipt_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtSuppCode.Text = string.Empty;
                txtSuppName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonSupplierPayment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtSuppCode.Text = string.Empty;
                txtSuppName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (radioButtonSupplierPayment.Checked == true)
                {
                    if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objChequeRecon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                        {
                            objChequeRecon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%'";
                        }
                        else
                        {
                            if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                            {
                                objChequeRecon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%'";
                            }
                        }
                    }
                }
                if (radioButtonCustomerReceipt.Checked == true)
                {
                    if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objChequeRecon.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                        {
                            objChequeRecon.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtSuppCode.Text.Trim() + "%'";
                        }
                        else
                        {
                            if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                            {
                                objChequeRecon.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtSuppName.Text.Trim() + "%'";
                            }
                        }
                    }
                }
                objChequeRecon.DataetName = "dsSupplier";
                objChequeRecon.GetSupplierDetails();
                search.dgSearch.DataSource = objChequeRecon.GetSupplierDataset.Tables["dsSupplier"];
                search.prop_Focus = txtSuppCode;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSuppCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtSuppCode.Text = search.Code.Trim();
                    txtSuppName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSuppCode.Text.Trim() != "")
                {
                    objChequeRecon.SuppCode = txtSuppCode.Text.ToString().Trim();
                    if (radioButtonSupplierPayment.Checked == true)
                    {
                        objChequeRecon.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                        objChequeRecon.Iid = "SUP";
                    }
                    else
                    {
                        objChequeRecon.SqlStatement = "SELECT Cust_Code Supp_Code, Cust_Name Supp_Name FROM Customer WHERE Cust_Code = '" + txtSuppCode.Text.Trim() + "'";
                        objChequeRecon.Iid = "CUS";
                    }
                    objChequeRecon.ReadSupplierDetails();
                    if (objChequeRecon.RecordFound == true)
                    {
                        txtSuppCode.Text = objChequeRecon.SuppCode;
                        txtSuppName.Text = objChequeRecon.SuppName;
                        txtSuppName.Focus();
                    }
                    else
                    {
                        if (radioButtonSupplierPayment.Checked == true)
                        {
                            MessageBox.Show("Supplier Code Not Found.", "Cheque Reconciliation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Customer Code Not Found.", "Cheque Reconciliation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return;
                    }

                    //Load Cheque Details
                    if (MessageBox.Show("Are You Sure You want to Load Transaction ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objChequeRecon.LoadSupplierTransaction();
                        objChequeRecon.GetTempDataset();
                        //Refreshing DataGrid View
                        dataGridViewChequeRecon.DataSource = objChequeRecon.TempChequeDeatils.Tables["dsChequeRecon"];
                        dataGridViewChequeRecon.Refresh();
                        txtSuppCode.Enabled = false;
                        txtSuppName.Enabled = false;
                        radioButtonSupplierPayment.Enabled = false;
                        radioButtonCustomerReceipt.Enabled = false;
                        btnSupplierSearch.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewChequeRecon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewChequeRecon.SelectedRows.Count <= 0 || dataGridViewChequeRecon.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Are You Sure You want to Set Realized Status. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        lblChequeDate.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[0].Value.ToString();
                        lblChequeNo.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[1].Value.ToString();
                        lblBankName.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[2].Value.ToString();
                        lblBranch.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[3].Value.ToString();
                        lblAmount.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[4].Value.ToString();
                        txtRemark.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[5].Value.ToString();
                        lblRealized.Text = dataGridViewChequeRecon.SelectedRows[0].Cells[6].Value.ToString();
                        txtRemark.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSuppCode.Text.Trim() != "")
                    {
                        objChequeRecon.Cheque_Date = lblChequeDate.Text.Trim();
                        objChequeRecon.Cheque_No = lblChequeNo.Text.Trim();
                        objChequeRecon.Bank_Name = lblBankName.Text.Trim();
                        objChequeRecon.Cheque_Realized = lblRealized.Text.Trim();
                        objChequeRecon.Remark = txtRemark.Text.Trim();

                        objChequeRecon.SetChequeStatus();
                        objChequeRecon.GetTempDataset();
                        //Refreshing DataGrid View
                        dataGridViewChequeRecon.DataSource = objChequeRecon.TempChequeDeatils.Tables["dsChequeRecon"];
                        dataGridViewChequeRecon.Refresh();

                        lblChequeDate.Text = string.Empty;
                        lblChequeNo.Text = string.Empty;
                        lblBankName.Text = string.Empty;
                        lblBranch.Text = string.Empty;
                        lblAmount.Text = string.Empty;
                        txtRemark.Text = string.Empty;
                        lblRealized.Text = string.Empty;
                        btnApply.Enabled = true;
                        txtRemark.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Remark", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (radioButtonSupplierPayment.Checked == true)
                {
                    objChequeRecon.Iid = "SUP";
                }
                else
                {
                    objChequeRecon.Iid = "CUS";
                }

                objChequeRecon.ChequeReconApply();
                MessageBox.Show("Cheque Reconciliation Applied as Document No. " + objChequeRecon.OrgDocNo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Dispose();
                ChequeRecon = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmChequeRecon_KeyDown(object sender, KeyEventArgs e)
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
                        if (e.KeyCode == Keys.E)
                        {
                            this.btnClose.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmChequeRecon 012.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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