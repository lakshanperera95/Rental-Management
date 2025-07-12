using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using Inventory.Properties;
using System.Runtime.InteropServices;
namespace Inventory
{
    public partial class frmInvoiceCustomerPayment : Form
    {
        private DataSet dsBankName;
        private decimal decBalanceAmount;
        private decimal decSelectAmount;
        bool OpenFromINV = false;

        clsCustomerPayment objCustomerPayment = new clsCustomerPayment();

        public frmInvoiceCustomerPayment(string Code)
        {
            InitializeComponent();
            OpenFromINV = false;
            if (Code != "")
            {
                txtCustCode.Text = Code;
               
            }
        }
        public frmInvoiceCustomerPayment(bool FromInvoice)
        {
            InitializeComponent();
            OpenFromINV = FromInvoice;
        }

        private static frmInvoiceCustomerPayment CustomerPayment;

        private frmSearch search = new frmSearch();

        public static frmInvoiceCustomerPayment GetCustomerPayment
        {
            get
            {
                return CustomerPayment;
            }
            set
            {
                CustomerPayment = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                CustomerPayment = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CustomerPayment = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerPayment_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        bool CusSearching = true;
        private void frmCustomerPayment_Load(object sender, EventArgs e)
        {
            try
            {
                objCustomerPayment.SqlStatement = "SELECT Temp_Receipt FROM DocumentNoDetails WHERE Loca = ";
                objCustomerPayment.GetTempDocumentNo();
                lblTempDocNo.Text = objCustomerPayment.TempDocNo;

                //Refreshing DataGrid View
                dataGridViewPendingPayments.DataSource = objCustomerPayment.GetPendingPayment.Tables["PendingPayments"];
                dataGridViewPendingPayments.Refresh();
                dataGridViewSelectedPayments.DataSource = objCustomerPayment.SelectedPayment.Tables["SelectedPayment"];
                dataGridViewSelectedPayments.Refresh();
                dataGridViewPayments.DataSource = objCustomerPayment.Payments.Tables["Payments"];
                dataGridViewPayments.Refresh();
 

                objCustomerPayment.GetBankDetails();
                dsBankName = objCustomerPayment.BankName;
                cmbBankName.DataSource = dsBankName.Tables["BankDetails"];
                cmbBankName.DisplayMember = "Bank_Name";
                cmbBankName.Text = "";


                cmbPaymentMode.DataSource = dsBankName.Tables[1];
                cmbPaymentMode.DisplayMember = "Name";
                cmbPaymentMode.ValueMember = "Ctype";

                  cmbCardType.DataSource = dsBankName.Tables[2];
                cmbCardType.DisplayMember = "Name";
                //lblDate.Text = objCustomerPayment.PostDate;

                CusSearching = true;
                txtCustCode.BackColor = Color.MediumAquamarine;
                txtCustName.BackColor = Color.MediumAquamarine;
                if (txtCustCode.Text.Trim() != string.Empty)
                {
                    txtCustCode_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    txtCustName.Text = txtCustCode.Text = string.Empty;
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;

                    search.Focus();

                }

                if (search.dgSearch.Rows.Count > 0 && search.Visible)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        search.selectRow();

                    }
                    int select = search.dgSearch.SelectedRows[0].Index;
                    if (e.KeyCode == Keys.Down && search.dgSearch.SelectedRows[0].Index != search.dgSearch.Rows.Count - 1)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select + 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select + 1].Cells[0];

                    }
                    if (e.KeyCode == Keys.Up && search.dgSearch.SelectedRows[0].Index != 0)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select - 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select - 1].Cells[0];

                    }
                }
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "")
                {
                    objCustomerPayment.CustCode = txtCustCode.Text.ToString().Trim();
                    objCustomerPayment.SqlStatement = "SELECT Cust_Code, Cust_Name FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "'";
                    objCustomerPayment.ReadCustomerDetails();
                    if (objCustomerPayment.RecordFound == true)
                    {
                        txtCustCode.Text = objCustomerPayment.CustCode;
                        txtCustName.Text = objCustomerPayment.CustName;

                        //if (MessageBox.Show("Are You Sure You want to Load Customer Transaction ", "Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        //{
                            objCustomerPayment.LoadCustomerTransaction();
                            objCustomerPayment.GetTempDataset();
                            //Refreshing DataGrid View
                            dataGridViewPendingPayments.DataSource = objCustomerPayment.GetPendingPayment.Tables["PendingPayments"];
                            dataGridViewPendingPayments.Refresh();
                            dataGridViewSelectedPayments.DataSource = objCustomerPayment.SelectedPayment.Tables["SelectedPayment"];
                            dataGridViewSelectedPayments.Refresh();
                            dataGridViewPayments.DataSource = objCustomerPayment.Payments.Tables["Payments"];
                            dataGridViewPayments.Refresh();

                            objCustomerPayment.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments WHERE Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                            objCustomerPayment.ReadPendingTotalAmounts();
                            lblTotalOutstanding.Text = objCustomerPayment.PendingPayTotalAmt.ToString("N2");
                            dataGridViewPendingPayments.Focus();
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCustCode.Focus();
                    }
                    cmbPaymentMode.Enabled = true;                    
                    cmbPaymentMode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCustCode.Text = search.Code.Trim();
                    txtCustName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                {
                    objCustomerPayment.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE (Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' OR Mobile LIKE '%" + txtCustCode.Text.Trim() + "%'  ) AND dbo.CRM_Customer.Inactive=0 ORDER BY Cust_Code";
                }
                else
                {
                    if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                    {
                        objCustomerPayment.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE  (Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%'  Or Mobile LIKE '%" + txtCustName.Text.Trim() + "%' ) AND dbo.CRM_Customer.Inactive=0 ORDER BY Cust_Name";
                    }
                    else
                    {
                        objCustomerPayment.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer  JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE  dbo.CRM_Customer.Inactive=0 ORDER BY Cust_Code";
                    }
                }

                objCustomerPayment.DataetName = "dsCustomer";
                objCustomerPayment.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomerPayment.GetCustomerDataset.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y + 100);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewPendingPayments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPendingPayments.SelectedRows.Count <= 0 || dataGridViewPendingPayments.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblPendingDocNo.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[0].Value.ToString();
                    lblPendingDocumentDate.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[1].Value.ToString();
                    lblPendingDocumentAmount.Text = Convert.ToDecimal(dataGridViewPendingPayments.SelectedRows[0].Cells[2].Value).ToString("N2");
                    txtPendingPaymentAmount.Text = Convert.ToDecimal(dataGridViewPendingPayments.SelectedRows[0].Cells[3].Value).ToString("N2");
                    txtPendingPaymentAmount.Select(0, txtPendingPaymentAmount.Text.Trim().Length);
                    decSelectAmount = decimal.Parse(dataGridViewPendingPayments.SelectedRows[0].Cells[3].Value.ToString());
                    txtPendingPaymentAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewPendingPayments_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && lblPendingDocNo.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPendingPaymentAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPendingPaymentAmount.Text) > 0 && decimal.Parse(txtPendingPaymentAmount.Text) <= decimal.Parse(lblPendingDocumentAmount.Text))
                {
                    if (MessageBox.Show("Do You Want Add to Payment List ? ", "Customer Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objCustomerPayment.TempDocNo = lblTempDocNo.Text.Trim();
                        objCustomerPayment.PendingDocNo = lblPendingDocNo.Text.Trim();
                        objCustomerPayment.PendingPayAmount = decimal.Parse(txtPendingPaymentAmount.Text.ToString());
                        objCustomerPayment.AddToPaymentList();
                        //Refreshing DataGrid View
                        objCustomerPayment.GetTempDataset();
                        dataGridViewSelectedPayments.DataSource = objCustomerPayment.SelectedPayment.Tables["SelectedPayment"];
                        dataGridViewSelectedPayments.Refresh();

                        objCustomerPayment.SqlStatement = "select ISNULL(SUM(Paid_Amount),0) SelTotalAmount from tbSelectedPayments WHERE Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        objCustomerPayment.ReadSelTotalAmount();
                        lblTotalSelectedValue.Text = objCustomerPayment.SelTotalAmount.ToString();
                        txtPaymentModeAmount.Text = objCustomerPayment.SelTotalAmount.ToString();
                        lblBalance.Text = objCustomerPayment.SelTotalAmount.ToString();

                        lblPendingDocNo.Text = string.Empty;
                        lblPendingDocumentDate.Text = string.Empty;
                        lblPendingDocumentAmount.Text = string.Empty;
                        txtPendingPaymentAmount.Text = string.Empty;
                        txtCustCode.Enabled = false;
                        txtCustName.Enabled = false;
                        btnCustomerSearch.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewSelectedPayments_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewSelectedPayments.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (dataGridViewPayments.RowCount == 1)
                    {


                        if (MessageBox.Show("Are You Sure You want to Remove From Payment List ?. ", "Supplier Payments", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            objCustomerPayment.TempDocNo = lblTempDocNo.Text.Trim();
                            objCustomerPayment.PendingDocNo = dataGridViewSelectedPayments.SelectedRows[0].Cells[0].Value.ToString();
                            objCustomerPayment.PendingPayAmount = 0;
                            objCustomerPayment.DeleteFromPaymentList();

                            objCustomerPayment.GetTempDataset();
                            dataGridViewSelectedPayments.DataSource = objCustomerPayment.SelectedPayment.Tables["SelectedPayment"];
                            dataGridViewSelectedPayments.Refresh();

                            objCustomerPayment.SqlStatement = "select ISNULL(SUM(Paid_Amount),0) SelTotalAmount from tbSelectedPayments WHERE Iid = 'REC' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                            objCustomerPayment.ReadSelTotalAmount();
                            lblTotalSelectedValue.Text = objCustomerPayment.SelTotalAmount.ToString();
                            decimal Balance = Convert.ToDecimal(lblTotalPayment.Text.Trim()) - Convert.ToDecimal(lblTotalSelectedValue.Text.Trim());
                            lblBalance.Text = Balance.ToString("N2");
                            //txtPaymentModeAmount.Text = objCustomerPayment.SelTotalAmount.ToString();
                            //lblBalance.Text = objCustomerPayment.SelTotalAmount.ToString();

                           
                            //txtPaymentModeAmount.Text = objCustomerPayment.SelTotalAmount.ToString();
                            //lblBalance.Text = objCustomerPayment.SelTotalAmount.ToString();

                            
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaymentMode.Text.Trim() != "CASH")
                {
                    cmbBankName.Enabled = true;
                    txtChequeNo.Enabled = true;
                    dtpChequeDate.Enabled = true;
                    txtBranchName.Enabled = true;
                    cmbCardType.Enabled = true;

                }
                else
                {
                    cmbBankName.Text = string.Empty;
                    txtChequeNo.Text = string.Empty;
                    txtChequeNo.Text = string.Empty;
                    dtpChequeDate.Enabled = false;

                    cmbBankName.Enabled = false;
                    txtChequeNo.Enabled = false;
                    dtpChequeDate.Enabled = false;
                    txtBranchName.Enabled = false;
                    cmbCardType.Enabled = false;
                }

                txtPaymentModeAmount.Enabled = true;

                if (cmbPaymentMode.SelectedIndex != -1 && cmbPaymentMode.Text != "System.Data.DataRowView" && cmbPaymentMode.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    bool CardType = Convert.ToBoolean(cmbPaymentMode.SelectedValue.ToString());
                    if (CardType == true)
                    {
                        label15.Text = "Card ";
                        label13.Text = "Card No";
                        txtBranchName.Visible = false;
                        cmbCardType.Visible = true;
                    }
                    else
                    {
                        label13.Text = "Cheque No";
                        label15.Text = "Branch ";
                        txtBranchName.Visible = true;
                        cmbCardType.Visible = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void txtPaymentModeAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && txtPaymentModeAmount.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPaymentModeAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPaymentModeAmount.Text.ToString()) > 0 && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblTotalSelectedValue.Text.ToString()) && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblBalance.Text.ToString()))
                if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && txtPaymentModeAmount.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPaymentModeAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPaymentModeAmount.Text.ToString()) > 0 /*&& decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblTotalSelectedValue.Text.ToString()) && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblBalance.Text.ToString())*/)
                {
                    if (cmbCardType.Visible == true)
                    {
                        txtBranchName.Text = cmbCardType.Text;
                    }

                    if (MessageBox.Show("Do You Want Add to Payment Mode List ? ", "Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (cmbPaymentMode.Text.Trim() != "CASH" && cmbBankName.Text.Trim() != string.Empty && txtBranchName.Text.Trim() != string.Empty && txtChequeNo.Text.Trim() != string.Empty)
                        {
                            objCustomerPayment.TempDocNo = lblTempDocNo.Text.Trim();
                            objCustomerPayment.Pay_Type = cmbPaymentMode.Text.Trim();
                            objCustomerPayment.ChequeNo = txtChequeNo.Text.Trim();
                            objCustomerPayment.SelectBankName = cmbBankName.Text.Trim().ToUpper();
                            objCustomerPayment.BranchName = txtBranchName.Text.Trim().ToUpper();
                            objCustomerPayment.ChequeDate = dtpChequeDate.Text;
                            objCustomerPayment.Amount = decimal.Parse(txtPaymentModeAmount.Text.ToString());
                            objCustomerPayment.AddToPaymentMode();
                        }
                        else
                        {
                            if (cmbPaymentMode.Text.Trim() == "CASH")
                            {
                                objCustomerPayment.TempDocNo = lblTempDocNo.Text.Trim();
                                objCustomerPayment.Pay_Type = cmbPaymentMode.Text.Trim();
                                objCustomerPayment.ChequeNo = "";
                                objCustomerPayment.SelectBankName = "";
                                objCustomerPayment.BranchName = "";
                                objCustomerPayment.ChequeDate = "";
                                objCustomerPayment.Amount = decimal.Parse(txtPaymentModeAmount.Text.ToString());
                                objCustomerPayment.AddToPaymentMode();
                            }
                        }
                        objCustomerPayment.GetTempDataset();
                        dataGridViewPayments.DataSource = objCustomerPayment.Payments.Tables["Payments"];
                        dataGridViewPayments.Refresh();

                        objCustomerPayment.SqlStatement = "select ISNULL(SUM(Amount), 0) decTotalPayment from tbPaymentDetails WHERE Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        objCustomerPayment.ReadTotalPayment();
                        lblTotalPayment.Text = objCustomerPayment.TotalPayment.ToString("N2");
                        //decBalanceAmount = decimal.Parse(lblTotalSelectedValue.Text.ToString()) - decimal.Parse(lblTotalPayment.Text.ToString());
                        //lblBalance.Text = decBalanceAmount.ToString();
                        lblBalance.Text = Convert.ToDecimal(lblTotalPayment.Text.Trim()).ToString("N2");
                        txtPaymentModeAmount.Text = decBalanceAmount.ToString();
                        //cmbPaymentMode.Text = "";
                        //txtPaymentModeAmount.Text = "";
                        txtChequeNo.Text = "";
                        cmbBankName.Text = "";
                        txtBranchName.Text = "";
                        txtChequeNo.Enabled = false;
                        cmbBankName.Enabled = false;
                        txtBranchName.Enabled = false;

                        txtPendingPaymentAmount.Focus();
                        txtPendingPaymentAmount.SelectAll();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && cmbPaymentMode.Text.Trim() == "CASH")
                {
                    txtPaymentModeAmount.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && cmbPaymentMode.Text.Trim() != "CASH")
                    {
                        cmbBankName.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbBankName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && cmbBankName.Text.Trim() != string.Empty)
                {
                    if (cmbCardType.Visible == true)
                    {
                        cmbCardType.Focus();
                    }
                    else
                    {
                        txtBranchName.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtBranchName.Text.Trim() != string.Empty)
                {
                    txtChequeNo.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtChequeNo.Text.Trim() != string.Empty)
                {
                    dtpChequeDate.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dtpChequeDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPaymentModeAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPendingPaymentAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && lblPendingDocNo.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPendingPaymentAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPendingPaymentAmount.Text) > 0 && decimal.Parse(txtPendingPaymentAmount.Text) <= decimal.Parse(lblPendingDocumentAmount.Text)/*&& dataGridViewPayments.RowCount==0*/)
                {
                    if (MessageBox.Show("Do You Want Add to Payment List ? ", "Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (decSelectAmount < decimal.Parse(txtPendingPaymentAmount.Text.ToString()))
                        {
                            MessageBox.Show("Invalid Amount. Please Enter Valid Amount. ", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPendingPaymentAmount.Text = decSelectAmount.ToString();
                            return;
                        }
                        if (cmbPaymentMode.Text.Trim() != string.Empty && txtPaymentModeAmount.Text.Trim() != string.Empty)
                        {
                            if (Convert.ToDecimal(txtPendingPaymentAmount.Text.Trim()) <= Convert.ToDecimal(lblBalance.Text.Trim()))
                            {
                                objCustomerPayment.TempDocNo = lblTempDocNo.Text.Trim();
                                objCustomerPayment.PendingDocNo = lblPendingDocNo.Text.Trim();
                                objCustomerPayment.PendingPayAmount = decimal.Parse(txtPendingPaymentAmount.Text.ToString());
                                objCustomerPayment.AddToPaymentList();
                                //Refreshing DataGrid View
                                objCustomerPayment.GetTempDataset();
                                dataGridViewSelectedPayments.DataSource = objCustomerPayment.SelectedPayment.Tables["SelectedPayment"];
                                dataGridViewSelectedPayments.Refresh();

                                objCustomerPayment.SqlStatement = "SELECT ISNULL(SUM(Paid_Amount),0) SelTotalAmount from tbSelectedPayments WHERE Iid = 'REC' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                                objCustomerPayment.ReadSelTotalAmount();
                                lblTotalSelectedValue.Text = objCustomerPayment.SelTotalAmount.ToString();
                                //txtPaymentModeAmount.Text = objCustomerPayment.SelTotalAmount.ToString();
                                //lblBalance.Text = objCustomerPayment.SelTotalAmount.ToString();

                                decimal Balance = Convert.ToDecimal(lblTotalPayment.Text.Trim()) - Convert.ToDecimal(lblTotalSelectedValue.Text.Trim());
                                lblBalance.Text = Balance.ToString("N2");

                                lblPendingDocNo.Text = string.Empty;
                                lblPendingDocumentDate.Text = string.Empty;
                                lblPendingDocumentAmount.Text = string.Empty;
                                txtPendingPaymentAmount.Text = string.Empty;
                                txtCustCode.Enabled = false;
                                txtCustName.Enabled = false;
                                btnCustomerSearch.Enabled = false;

                                cmbPaymentMode.Enabled = false;
                                txtPaymentModeAmount.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("You cannot add more than Rs. " + lblBalance.Text.Trim(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPendingPaymentAmount.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select a Payment Mode and Enter the Amount.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cmbPaymentMode.Focus();
                            return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //if (txtSalesmanCode.Text.Trim() == string.Empty || txtSalesmanName.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Salesman Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    txtSalesmanCode.Focus();
                //    return;
                //}

                objCustomerPayment.SqlStatement = "SELECT * from tbPendingPayments WHERE tbPendingPayments.IId = 'REC' AND tbPendingPayments.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbPendingPayments.Loca = " + LoginManager.LocaCode;
                objCustomerPayment.ReadTempTransDetails();
                if (objCustomerPayment.RecordFound != true)
                {
                    MessageBox.Show("Pending Payment Details Not Found.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objCustomerPayment.SqlStatement = "SELECT * from tbSelectedPayments WHERE tbSelectedPayments.IId = 'REC' AND tbSelectedPayments.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbSelectedPayments.Loca = " + LoginManager.LocaCode;
                objCustomerPayment.ReadTempTransDetails();
                if (objCustomerPayment.RecordFound != true)
                {
                    MessageBox.Show("Selected Payment Details Not Found.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objCustomerPayment.SqlStatement = "SELECT * from tbPaymentDetails WHERE tbPaymentDetails.IId = 'REC' AND tbPaymentDetails.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbPaymentDetails.Loca = " + LoginManager.LocaCode;
                objCustomerPayment.ReadTempTransDetails();
                if (objCustomerPayment.RecordFound != true)
                {
                    MessageBox.Show("Selected Payment Mode details not found.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Payment Apply
                if (MessageBox.Show("Are You Sure You want to Apply This Receipt? ", "Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    DataSet dsDataForSubReport = new DataSet();

                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;

                    //objCustomerPayment.SalesmanCode = txtSalesmanCode.Text.Trim();
                    objCustomerPayment.PostDate = dtpDate.Text.Trim();
                    objCustomerPayment.CustomerPaymentApply();
                    MessageBox.Show("Receipt Successfully Applied as Document No. " + objCustomerPayment.OrgDocNo, "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //objCustomerPayment.GetDataSetForReport();
                    //objCustomerPayment.GetReportDataset.Tables["tbPaidPaymentSummary1"].TableName = "CompanyProfile";
                    //dsDataForReport = objCustomerPayment.GetReportDataset;
                    //dsDataForSubReport = objCustomerPayment.GetSubReportDataset;

                    //rptCustomerPayment rptReceipt = new rptCustomerPayment();

                    //rptReceipt.SetDataSource(dsDataForReport);
                    //rptReceipt.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForSubReport);
                    //objRepViewer.crystalReportViewer1.ReportSource = rptReceipt;
                    objCustomerPayment.GetDataSetForReport(Settings.Default.Shinghala);

                    if (Settings.Default.Shinghala)
                    {
                        objCustomerPayment.GetReportDataset.Tables["tbPaidPaymentSummary1"].TableName = "dsCompanyLogo";
                        dsDataForReport = objCustomerPayment.GetReportDataset;
                        dsDataForSubReport = objCustomerPayment.GetSubReportDataset;
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerPayment.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                        objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForSubReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    }
                    else
                    {
                        objCustomerPayment.GetReportDataset.Tables["tbPaidPaymentSummary1"].TableName = "CompanyProfile";
                        dsDataForReport = objCustomerPayment.GetReportDataset;
                        dsDataForSubReport = objCustomerPayment.GetSubReportDataset;
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerPayment_eng.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                        objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForSubReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    }

                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();

                    //cash drawer open
                    if (Settings.Default.CashDrawerOpen==true)
                    {
                        bool CashPaymentHave = false;
                        foreach (DataGridViewRow row in dataGridViewPayments.Rows)
                        {
                            if (row.Cells[0].Value.ToString().ToUpper()=="CASH")
                            {
                                CashPaymentHave = true;
                            }
                        }

                        if (CashPaymentHave)
                        {
                            clsCashDrawerClass cashDrawer = new clsCashDrawerClass();
                            cashDrawer.CashDrawer_Open();
                        }
                    }
                    //End Cash Drawer Open

                    this.Close();
                    this.Dispose();
                    CustomerPayment = null;

                    if (frmWholeSaleInvoice.GetInvoice == null)
                    {
                        frmWholeSaleInvoice.GetInvoice = new frmWholeSaleInvoice();
                        frmWholeSaleInvoice.GetInvoice.MdiParent = MainClass.mdi;
                        frmWholeSaleInvoice.GetInvoice.Show();
                    }
                    else
                    {
                        frmWholeSaleInvoice.GetInvoice.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerPayment_KeyDown(object sender, KeyEventArgs e)
        {
            {
                try
                {
                    if (e.KeyCode == Keys.F1 && (txtCustCode.Focused || txtCustName.Focused))
                    {
                        btnCustomerSearch.PerformClick();
                    }
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 020.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSalesmanSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtSalesmanCode.Text.Trim() == string.Empty && txtSalesmanName.Text.Trim() == string.Empty)
                {
                    objCustomerPayment.SqlStatement = "SELECT Sale_Code [Salesman Code], Sale_Name [Salesman Name] FROM tb_Salesman ORDER BY Sale_Code";
                }
                else
                {
                    if (txtSalesmanCode.Text.Trim() != string.Empty && txtSalesmanName.Text.Trim() == string.Empty)
                    {
                        objCustomerPayment.SqlStatement = "SELECT Sale_Code [Salesman Code], Sale_Name [Salesman Name] FROM tb_Salesman WHERE Sale_Code LIKE '%" + txtSalesmanCode.Text.Trim() + "%' ORDER BY Sale_Code";
                    }
                    else
                    {
                        if (txtSalesmanCode.Text.Trim() == string.Empty && txtSalesmanName.Text.Trim() != string.Empty)
                        {
                            objCustomerPayment.SqlStatement = "SELECT Sale_Code [Salesman Code], Sale_Name [Salesman Name] FROM tb_Salesman WHERE Sale_Name LIKE '%" + txtSalesmanName.Text.Trim() + "%' ORDER BY Sale_Name";
                        }
                        else
                        {
                            objCustomerPayment.SqlStatement = "SELECT Sale_Code [Salesman Code], Sale_Name [Salesman Name] FROM tb_Salesman ORDER BY Sale_Code";
                        }
                    }
                }
                objCustomerPayment.DataetName = "dsSalesman";
                objCustomerPayment.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomerPayment.GetCustomerDataset.Tables["dsSalesman"];
                search.prop_Focus = txtSalesmanCode;
                search.Cont_Descript = txtSalesmanName;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerPayment 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
                {
                    cmbPaymentMode.Focus();
                }
                if (e.KeyCode == Keys.F5)
                {
                    if (CusSearching == true)
                    {
                        CusSearching = false;
                        txtCustName.BackColor = Color.Empty;
                        txtCustCode.BackColor = Color.Empty;
                        frmSearch.GetSearch.Hide();

                    }
                    else
                    {
                        CusSearching = true;
                        txtCustCode.BackColor = Color.MediumAquamarine;
                        txtCustName.BackColor = Color.MediumAquamarine;
                    }
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;

                    search.Focus();

                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtCustName.Text = txtCustCode.Text = string.Empty;
                }
                if (search.dgSearch.Rows.Count > 0 && search.Visible)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        search.selectRow();

                    }
                    int select = search.dgSearch.SelectedRows[0].Index;
                    if (e.KeyCode == Keys.Down && search.dgSearch.SelectedRows[0].Index != search.dgSearch.Rows.Count - 1)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select + 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select + 1].Cells[0];

                    }
                    if (e.KeyCode == Keys.Up && search.dgSearch.SelectedRows[0].Index != 0)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select - 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select - 1].Cells[0];

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustCode.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
                txtCustCode.Focus();
            }
        }

        private void txtCustName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
                txtCustName.Focus();
            }
        }

        private void cmbCardType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbBankName.Text.Trim() != string.Empty)
            {
                txtChequeNo.Focus();

            }
        }
    }
}