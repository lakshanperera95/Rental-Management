using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmSupplierPayment : Form
    {
        private DataSet dsBankName;
        private decimal decBalanceAmount;
        private decimal decSelectAmount;

        clsSupplierPayment objSupplierPayment = new clsSupplierPayment();

        public frmSupplierPayment()
        {
            InitializeComponent();
        }

        private static frmSupplierPayment SupplierPayment;

        private frmSearch search = new frmSearch();

        public static frmSupplierPayment GetSupplierPayment
        {
            get
            {
                return SupplierPayment;
            }
            set
            {
                SupplierPayment = value;
            }
        }

        private void frmSupplierPayment_Load(object sender, EventArgs e)
        {
            try
            {
                objSupplierPayment.SqlStatement = "SELECT Temp_Payment FROM DocumentNoDetails WHERE Loca = ";
                objSupplierPayment.GetTempDocumentNo();
                lblTempDocNo.Text = objSupplierPayment.TempDocNo;

                //Refreshing DataGrid View
                dataGridViewPendingPayments.DataSource = objSupplierPayment.GetPendingPayment.Tables["PendingPayments"];
                dataGridViewPendingPayments.Refresh();
                dataGridViewSelectedPayments.DataSource = objSupplierPayment.SelectedPayment.Tables["SelectedPayment"];
                dataGridViewSelectedPayments.Refresh();
                dataGridViewPayments.DataSource = objSupplierPayment.Payments.Tables["Payments"];
                dataGridViewPayments.Refresh();
 
                objSupplierPayment.GetBankDetails();
                dsBankName = objSupplierPayment.BankName;
                cmbBankName.DataSource = dsBankName.Tables["BankDetails"];
                cmbBankName.DisplayMember = "Bank_Name";

                cmbPaymentMode.DataSource = dsBankName.Tables[1];
                cmbPaymentMode.DisplayMember = "Name";

                lblDate.Text = objSupplierPayment.PostDate;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSupplierPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SupplierPayment = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSupplierPayment_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() == string.Empty)
                {
                    objSupplierPayment.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objSupplierPayment.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code ASC";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            objSupplierPayment.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                        }
                        else
                        {
                            objSupplierPayment.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                        }
                    }
                }
                objSupplierPayment.DataetName = "dsSupplier";
                objSupplierPayment.GetSupplierDetails();
                search.dgSearch.DataSource = objSupplierPayment.GetSupplierDataset.Tables["dsSupplier"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                SupplierPayment = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objSupplierPayment.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objSupplierPayment.SqlStatement = "SELECT Supp_Code, Supp_Name FROM Supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objSupplierPayment.ReadSupplierDetails();
                    if (objSupplierPayment.RecordFound == true)
                    {
                        txtSuppCode.Text = objSupplierPayment.SuppCode;
                        txtSuppName.Text = objSupplierPayment.SuppName;
                        //txtSuppName.Focus();
                        if (MessageBox.Show("Are You Sure You want to Load Supplier Transaction ", "Supplier Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            objSupplierPayment.LoadSupplierTransaction();
                            objSupplierPayment.GetTempDataset();
                            //Refreshing DataGrid View
                            dataGridViewPendingPayments.DataSource = objSupplierPayment.GetPendingPayment.Tables["PendingPayments"];
                            dataGridViewPendingPayments.Refresh();
                            dataGridViewSelectedPayments.DataSource = objSupplierPayment.SelectedPayment.Tables["SelectedPayment"];
                            dataGridViewSelectedPayments.Refresh();
                            dataGridViewPayments.DataSource = objSupplierPayment.Payments.Tables["Payments"];
                            dataGridViewPayments.Refresh();

                            objSupplierPayment.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments WHERE Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                            objSupplierPayment.ReadPendingTotalAmounts();
                            lblTotalOutstanding.Text = objSupplierPayment.PendingPayTotalAmt.ToString();
                            dataGridViewPendingPayments.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSuppCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    lblPendingDocumentAmount.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[2].Value.ToString();
                    txtPendingPaymentAmount.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[3].Value.ToString();
                    decSelectAmount = decimal.Parse(dataGridViewPendingPayments.SelectedRows[0].Cells[3].Value.ToString());
                    txtPendingPaymentAmount.Select(0, txtPendingPaymentAmount.Text.Trim().Length);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && lblPendingDocNo.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPendingPaymentAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPendingPaymentAmount.Text) > 0 && decimal.Parse(txtPendingPaymentAmount.Text) <= decimal.Parse(lblPendingDocumentAmount.Text) && dataGridViewPayments.RowCount==0)
                {
                    if (MessageBox.Show("Do You Want Add to Payment List ? ", "Supplier Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (decSelectAmount < decimal.Parse(txtPendingPaymentAmount.Text.ToString()))
                        {
                            MessageBox.Show("Invalid Amount. Please Enter Valid Amount. ", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPendingPaymentAmount.Text = decSelectAmount.ToString();
                            return;
                        }

                        objSupplierPayment.TempDocNo = lblTempDocNo.Text.Trim();
                        objSupplierPayment.PendingDocNo = lblPendingDocNo.Text.Trim();
                        objSupplierPayment.PendingPayAmount = decimal.Parse(txtPendingPaymentAmount.Text.ToString());
                        objSupplierPayment.AddToPaymentList();
                        //Refreshing DataGrid View
                        objSupplierPayment.GetTempDataset();
                        dataGridViewSelectedPayments.DataSource = objSupplierPayment.SelectedPayment.Tables["SelectedPayment"];
                        dataGridViewSelectedPayments.Refresh();

                        objSupplierPayment.SqlStatement = "select ISNULL(SUM(Paid_Amount),0) SelTotalAmount from tbSelectedPayments WHERE Iid = 'PMT' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        objSupplierPayment.ReadSelTotalAmount();
                        lblTotalSelectedValue.Text = objSupplierPayment.SelTotalAmount.ToString();
                        txtPaymentModeAmount.Text = objSupplierPayment.SelTotalAmount.ToString();
                        lblBalance.Text = objSupplierPayment.SelTotalAmount.ToString();

                        lblPendingDocNo.Text = string.Empty;
                        lblPendingDocumentDate.Text = string.Empty;
                        lblPendingDocumentAmount.Text = string.Empty;
                        txtPendingPaymentAmount.Text = string.Empty;
                        txtSuppCode.Enabled = false;
                        txtSuppName.Enabled = false;
                        btnSupplierSearch.Enabled = false;
                        dataGridViewPendingPayments.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.F2 && dataGridViewSelectedPayments.SelectedRows[0].Cells[0].Value.ToString() != string.Empty && dataGridViewPayments.RowCount==0)
                {
                    if (MessageBox.Show("Are You Sure You want to Remove From Payment List ?. ", "Supplier Payments", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objSupplierPayment.TempDocNo = lblTempDocNo.Text.Trim();
                        objSupplierPayment.PendingDocNo = dataGridViewSelectedPayments.SelectedRows[0].Cells[0].Value.ToString();
                        objSupplierPayment.PendingPayAmount = 0;
                        objSupplierPayment.DeleteFromPaymentList();

                        objSupplierPayment.GetTempDataset();
                        dataGridViewSelectedPayments.DataSource = objSupplierPayment.SelectedPayment.Tables["SelectedPayment"];
                        dataGridViewSelectedPayments.Refresh();

                        objSupplierPayment.SqlStatement = "select ISNULL(SUM(Paid_Amount),0) SelTotalAmount from tbSelectedPayments WHERE Iid = 'PMT' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        objSupplierPayment.ReadSelTotalAmount();
                        lblTotalSelectedValue.Text = objSupplierPayment.SelTotalAmount.ToString();
                        txtPaymentModeAmount.Text = objSupplierPayment.SelTotalAmount.ToString();
                        lblBalance.Text = objSupplierPayment.SelTotalAmount.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPaymentMode_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaymentMode.Text.Trim() == "CHEQUE")
                {
                    cmbBankName.Enabled = true;
                    txtChequeNo.Enabled = true;
                    dtpChequeDate.Enabled = true;
                    txtBranchName.Enabled = true;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPaymentModeAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && txtPaymentModeAmount.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPaymentModeAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPaymentModeAmount.Text.ToString()) > 0 && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblTotalSelectedValue.Text.ToString()) && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblBalance.Text.ToString()))
                if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && txtPaymentModeAmount.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPaymentModeAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPaymentModeAmount.Text.ToString()) > 0 && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblTotalSelectedValue.Text.ToString()) && decimal.Parse(txtPaymentModeAmount.Text.ToString()) <= decimal.Parse(lblBalance.Text.ToString()))
                {
                    if (MessageBox.Show("Do You Want Add to Payment Mode List ? ", "Supplier Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (cmbPaymentMode.Text.Trim() == "CHEQUE" && cmbBankName.Text.Trim() != string.Empty && txtBranchName.Text.Trim() != string.Empty && txtChequeNo.Text.Trim() != string.Empty)
                        {
                            objSupplierPayment.TempDocNo = lblTempDocNo.Text.Trim();
                            objSupplierPayment.Pay_Type = cmbPaymentMode.Text.Trim();
                            objSupplierPayment.ChequeNo = txtChequeNo.Text.Trim();
                            objSupplierPayment.SelectBankName = cmbBankName.Text.Trim().ToUpper();
                            objSupplierPayment.BranchName = txtBranchName.Text.Trim().ToUpper();
                            objSupplierPayment.ChequeDate = dtpChequeDate.Text;
                            objSupplierPayment.Amount = decimal.Parse(txtPaymentModeAmount.Text.ToString());
                            objSupplierPayment.AddToPaymentMode();
                        }
                        else
                        {
                            if (cmbPaymentMode.Text.Trim() == "CASH")
                            {
                                objSupplierPayment.TempDocNo = lblTempDocNo.Text.Trim();
                                objSupplierPayment.Pay_Type = cmbPaymentMode.Text.Trim();
                                objSupplierPayment.ChequeNo = "";
                                objSupplierPayment.SelectBankName = "";
                                objSupplierPayment.BranchName = "";
                                objSupplierPayment.ChequeDate = "";
                                objSupplierPayment.Amount = decimal.Parse(txtPaymentModeAmount.Text.ToString());
                                objSupplierPayment.AddToPaymentMode();
                            }
                        }
                        objSupplierPayment.GetTempDataset();
                        dataGridViewPayments.DataSource = objSupplierPayment.Payments.Tables["Payments"];
                        dataGridViewPayments.Refresh();

                        objSupplierPayment.SqlStatement = "select ISNULL(SUM(Amount), 0) decTotalPayment from tbPaymentDetails WHERE Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        objSupplierPayment.ReadTotalPayment();
                        lblTotalPayment.Text = objSupplierPayment.TotalPayment.ToString();
                        decBalanceAmount = decimal.Parse(lblTotalSelectedValue.Text.ToString()) - decimal.Parse(lblTotalPayment.Text.ToString());
                        lblBalance.Text = decBalanceAmount.ToString();
                        txtPaymentModeAmount.Text = decBalanceAmount.ToString();
                        cmbPaymentMode.Text = "";
                        //                    txtPaymentModeAmount.Text = "";
                        txtChequeNo.Text = "";
                        cmbBankName.Text = "";
                        txtBranchName.Text = "";
                        txtChequeNo.Enabled = false;
                        cmbBankName.Enabled = false;
                        txtBranchName.Enabled = false;

                        cmbPaymentMode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (e.KeyCode == Keys.Enter && cmbPaymentMode.Text.Trim() != string.Empty && cmbPaymentMode.Text.Trim() == "CHEQUE")
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    txtBranchName.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objSupplierPayment.SqlStatement = "SELECT * from tbPendingPayments WHERE tbPendingPayments.IId = 'PMT' AND tbPendingPayments.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbPendingPayments.Loca = " + LoginManager.LocaCode;
                objSupplierPayment.ReadTempTransDetails();
                if (objSupplierPayment.RecordFound != true)
                {
                    MessageBox.Show("Pending Payment Details Not Found.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objSupplierPayment.SqlStatement = "SELECT * from tbSelectedPayments WHERE tbSelectedPayments.IId = 'PMT' AND tbSelectedPayments.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbSelectedPayments.Loca = " + LoginManager.LocaCode;
                objSupplierPayment.ReadTempTransDetails();
                if (objSupplierPayment.RecordFound != true)
                {
                    MessageBox.Show("Selected Payment Details Not Found.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objSupplierPayment.SqlStatement = "SELECT * from tbPaymentDetails WHERE tbPaymentDetails.IId = 'PMT' AND tbPaymentDetails.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbPaymentDetails.Loca = " + LoginManager.LocaCode;
                objSupplierPayment.ReadTempTransDetails();
                if (objSupplierPayment.RecordFound != true)
                {
                    MessageBox.Show("Selected Payment Mode Details Not Found.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Payment Apply
                if (MessageBox.Show("Do You want to Apply This Supplier Payment. ", "Supplier Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    DataSet dsDataForSubReport = new DataSet();

                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;

                    objSupplierPayment.SupplierPaymentApply();
                    MessageBox.Show("Supplier Payment Successfully Applied as Document No. " + objSupplierPayment.OrgDocNo, "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objSupplierPayment.GetDataSetForReport();
                    dsDataForReport = objSupplierPayment.GetReportDataset;
                    objSupplierPayment.GetReportDataset.Tables["tbPaidPaymentSummary1"].TableName = "CompanyProfile";
                    dsDataForSubReport = objSupplierPayment.GetSubReportDataset;

                    if (File.Exists(@"..\DirectReports\rptSupplierPayment.rpt"))
                    {
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptSupplierPayment.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                        objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForSubReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        objRepViewer.Show();
                    }
                    else
                    {
                        rptSupplierPayment rptPayment = new rptSupplierPayment();
                        rptPayment.SetDataSource(dsDataForReport);
                        rptPayment.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForSubReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptPayment;
                        objRepViewer.WindowState = FormWindowState.Maximized;
                        objRepViewer.Show();
                    }

                    

                    this.Close();
                    this.Dispose();
                    SupplierPayment = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSupplierPayment_KeyDown(object sender, KeyEventArgs e)
        {
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 019.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
}
    
