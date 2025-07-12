using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using CrystalDecisions.Shared;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmCustomerReturn : Form
    {
        private decimal decDiscountAmount;
        private decimal decAmount;
        private string strDisc;
        private int intPosOfPerc;   // find Percentage mark on percentage
        private decimal fltDiscPer;

        clsCustomerReturn objCustomerReturn = new clsCustomerReturn();
        private frmProductShortCodeDialog prodShortCode = new frmProductShortCodeDialog();

        public frmCustomerReturn()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtSellingPrice, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtDiscount, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtFreeQty, System.Globalization.NumberStyles.Currency);
        }

        private static frmCustomerReturn CustomerReturn;

        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();

        public static frmCustomerReturn GetCustomerReturn
        {
            get
            {
                return CustomerReturn;
            }
            set
            {
                CustomerReturn = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                CustomerReturn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CustomerReturn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerReturn_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerReturn_Load(object sender, EventArgs e)
        {
            try
            {
                objCustomerReturn.SqlStatement = "SELECT Temp_Cur FROM DocumentNoDetails WHERE Loca = ";
                objCustomerReturn.GetTempDocumentNo();
                lblTempDocNo.Text = objCustomerReturn.TempDocNo;
                dataGridTempInvoice.DataSource = objCustomerReturn.TempInvoice;
                dataGridTempInvoice.Refresh();
                txtSellingPrice.Enabled = Settings.Default.CURSellingEdit;
                
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSaveDocSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                objCustomerReturn.SqlStatement = "SELECT Doc_No [Document No], Post_Date + '  ' + Customer.Cust_Name [Customer] FROM Transaction_Save_Header INNER JOIN Customer on Transaction_Save_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Save_Header.Iid = 'CUR' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                objCustomerReturn.DataetName = "Table";
                objCustomerReturn.GetItemDetails();

                search.dgSearch.DataSource = objCustomerReturn.GetItemDataset.Tables["Table"];
                search.Show();

                search.prop_Focus = lblTempDocNo;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSearchInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtCustCode.Text.Trim() != string.Empty)
                {
                    objCustomerReturn.SqlStatement = "SELECT Doc_No [Document No], Transaction_Date + ' ' +  Customer.Cust_Name [Customer] FROM  Payment_Summary INNER JOIN Customer ON Payment_Summary.Acc_No = Customer.Cust_Code WHERE Acc_No = '" + txtCustCode.Text.Trim() + "' AND Tr_Type = 'INV' AND Payment_Summary.Loca = '" + LoginManager.LocaCode + "' AND Balance_Amount > 0 AND Keys <> 'POS' ORDER BY RIGHT(Doc_No,6) DESC";
                }
                else
                {
                    objCustomerReturn.SqlStatement = "SELECT Doc_No [Document No], Transaction_Date + ' ' +  Customer.Cust_Name [Customer] FROM  Payment_Summary INNER JOIN Customer ON Payment_Summary.Acc_No = Customer.Cust_Code WHERE Tr_Type = 'INV' AND Payment_Summary.Loca = '" + LoginManager.LocaCode + "' AND Balance_Amount > 0 AND Keys <> 'POS' ORDER BY RIGHT(Doc_No,6) DESC";
                }
                objCustomerReturn.DataetName = "Table";
                objCustomerReturn.GetItemDetails();

                search.dgSearch.DataSource = objCustomerReturn.GetItemDataset.Tables["Table"];
                search.Show();

                search.prop_Focus = txtInvoiceNo;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void lblTempDocNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if (MessageBox.Show("Are You Sure You want to Load Saved Customer Return Document No :" + search.Code.Trim() + ". ", "Customer Return", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objCustomerReturn.RecallSaveDocNo = search.Code.Trim();
                        objCustomerReturn.SqlStatement = "SELECT Transaction_Save_Header.*, Customer.Cust_Name, Customer.Address1, Customer.Address2, Customer.Address3 FROM Transaction_Save_Header INNER JOIN Customer ON Customer.Cust_code = Transaction_Save_Header.Supplier_Id WHERE Transaction_Save_Header.iid = 'CUR' AND Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
                        objCustomerReturn.ReadSavedDocument();
                        if (objCustomerReturn.RecordFound)
                        {
                            lblTempDocNo.Text = objCustomerReturn.TempDocNo;
                            txtInvoiceNo.Text = objCustomerReturn.InvoiceNo.ToString();
                            txtCustCode.Text = objCustomerReturn.CustCode.ToString();
                            txtCustName.Text = objCustomerReturn.CustName.ToString();
                            lblCustAddress1.Text = objCustomerReturn.Address1.ToString();
                            lblCustAddress2.Text = objCustomerReturn.Address2.ToString();
                            lblCustAddress3.Text = objCustomerReturn.Address3.ToString();
                            txtReference.Text = objCustomerReturn.Reference.ToString();
                            txtRemarks.Text = objCustomerReturn.Remark.ToString();
                            txtSalesAssist.Text = objCustomerReturn.SalesAssistant.ToString();
                            txtComments.Text = objCustomerReturn.Comments.ToString();
                            objCustomerReturn.GetTempDataset();
                            dataGridTempInvoice.DataSource = objCustomerReturn.TempInvoice.Tables["Invoice"];
                            dataGridTempInvoice.Refresh();

                            objCustomerReturn.GetTotalValues();

                            lblTotalQty.Text = string.Format("{0:0.00}", objCustomerReturn.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);
                            txtSubDiscount.Text = "0";
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);
                            txtCustCode.ReadOnly = true;
                            txtCustName.Enabled = false;
                            txtSaleName.Enabled = false;
                            txtSalesAssist.Enabled = false;
                            btnSaleSearch.Enabled = false;
                            dtpDate.Enabled = false;
                           // txtReference.Enabled = false;
                           // txtRemarks.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            //btnCustomerSearch.Enabled = false;
                        }
                    }
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() == string.Empty)
                {
                    objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                }
                else
                {
                    if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                        objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%'";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                        {
                            objCustomerReturn.SqlStatement = "Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%'";
                        }
                        else
                        {
                            objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                        }
                    }
                }
                objCustomerReturn.DataetName = "dsCustomer";
                objCustomerReturn.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomerReturn.GetCustomerDataSet.Tables["dsCustomer"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "")
                {
                    objCustomerReturn.CustCode = txtCustCode.Text.ToString().Trim();
                    objCustomerReturn.SqlStatement = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "' ";
                    objCustomerReturn.ReadCustomerDetails();
                    if (objCustomerReturn.RecordFound == true)
                    {
                        txtCustCode.Text = objCustomerReturn.CustCode;
                        txtCustName.Text = objCustomerReturn.CustName;
                        lblCustAddress1.Text = objCustomerReturn.Address1;
                        lblCustAddress2.Text = objCustomerReturn.Address2;
                        lblCustAddress3.Text = objCustomerReturn.Address3;
                        objCustomerReturn.SqlStatement = "SELECT ISNULL(SUM(Balance_Amount),0)Balance_Amount FROM Payment_Summary  WHERE Acc_No='" + txtCustCode.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Tr_Type='INV'";
                        //((clsWholeSaleInvoice)objCustomerReturn).SqlStatement = "SELECT ISNULL(SUM(Balance_Amount),0)Balance_Amount FROM Payment_Summary  WHERE Acc_No='" + txtCustCode.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Tr_Type='INV'";
                        objCustomerReturn.ReadCustBalanceDetails();
                        if (objCustomerReturn.RecordFound == true)
                        {
                            lblBalance.Text = objCustomerReturn._InvBalance.ToString("N2");
                        }
                        txtCustName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found.", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSalesAssist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSalesAssist.Text.Trim() != string.Empty)
                {
                    txtReference.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtSalesAssist.Text.Trim() == string.Empty)
                    {
                        txtSalesAssist.Text = ".";
                        txtReference.Focus();
                    }
                }
                search.Code = "";
                search.Descript = "";
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtReference_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtReference.Text.Trim() != string.Empty)
                {
                    txtRemarks.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtReference.Text.Trim() == string.Empty)
                    {
                        txtReference.Text = ".";
                        txtRemarks.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtRemarks.Text.Trim() != string.Empty)
                {
                    txtProductCode.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtRemarks.Text.Trim() == string.Empty)
                    {
                        txtRemarks.Text = ".";
                        txtProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        clsCommon Common = new clsCommon();
        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Clear Fields
                if (e.KeyCode == Keys.Escape)
                {
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                }

                //Blocking Cursor Moving
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    ProductSearch.Focus();
                }

                //short code search
                if (e.KeyCode == Keys.F3 && txtProductCode.Text != "")
                {
                  //  shortCodeSearch();
                    if (ProductSearch.Visible)
                    {
                        ProductSearch.Hide();
                    }
                }

                //Serch ON OFF
                if (e.KeyCode == Keys.F5)
                {
                    if (prodSearching == true)
                    {
                        prodSearching = false;
                        txtProductCode.BackColor = Color.Empty;
                        txtProductName.BackColor = Color.Empty;
                        ProductSearch.Hide();
                    }
                    else
                    {
                        prodSearching = true;
                        txtProductCode.BackColor = Color.MediumAquamarine;
                        txtProductName.BackColor = Color.MediumAquamarine;
                        txtProductName.Focus();
                    }
                }

                //Product Serch Selection
                if (ProductSearch.dgSearch.Rows.Count > 0 && ProductSearch.Visible)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        ProductSearch.selectRow();

                    }
                    int select = ProductSearch.dgSearch.SelectedRows[0].Index;
                    if (e.KeyCode == Keys.Down && ProductSearch.dgSearch.SelectedRows[0].Index != ProductSearch.dgSearch.Rows.Count - 1)
                    {
                        ProductSearch.dgSearch.SelectedRows[0].Selected = false;
                        ProductSearch.dgSearch.Rows[select + 1].Selected = true;
                        ProductSearch.dgSearch.CurrentCell = ProductSearch.dgSearch.Rows[select + 1].Cells[0];

                    }
                    if (e.KeyCode == Keys.Up && ProductSearch.dgSearch.SelectedRows[0].Index != 0)
                    {
                        ProductSearch.dgSearch.SelectedRows[0].Selected = false;
                        ProductSearch.dgSearch.Rows[select - 1].Selected = true;
                        ProductSearch.dgSearch.CurrentCell = ProductSearch.dgSearch.Rows[select - 1].Cells[0];

                    }
                }
                
                
                if (e.KeyCode == Keys.Enter)
                {
                    ProductSearch.Close();
                    objCustomerReturn.CustCode = txtCustCode.Text.ToString().Trim();
                    objCustomerReturn.SqlStatement = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "'";
                    objCustomerReturn.ReadCustomerDetails();
                    if (objCustomerReturn.RecordFound == true)
                    {
                        txtCustCode.Text = objCustomerReturn.CustCode;
                        txtCustName.Text = objCustomerReturn.CustName;
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found.", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCustCode.Focus();
                        return;
                    }

                    

                    txtProductCode.Text = txtProductCode.Text.ToUpper();

                    //Short Code Display
                    if (txtProductCode.Text != "")
                    {
                        /*try
                        {
                            if (prodShortCode.IsDisposed)
                            {
                                prodShortCode = new frmProductShortCodeDialog();
                            }
                            objCustomerReturn.SqlStatement = "SELECT Prod_Code, Prod_Name FROM product WHERE (Prod_Code='' OR Barcode='') AND LockedItem='F' ";
                            objCustomerReturn.ReadProductPriceLevel2();
                            if (objCustomerReturn.PPLRecoudFound)
                            {
                                objCustomerReturn.DataetName = "dsProduct";
                                objCustomerReturn.GetPriceLevel2();
                                
                                prodShortCode.dgProductDetails.DataSource = objCustomerReturn.ProductPriceLevel.Tables["dsProduct"];
                                prodShortCode.Width = 500;
                                prodShortCode.dgProductDetails.Width = 500;
                                prodShortCode.prop_Focus = txtProductCode;
                                prodShortCode.Cont_Descript = txtProductName;
                                if (prodShortCode.dgProductDetails.Rows.Count>1)
                                {
                                    prodShortCode.ShowDialog();
                                }

                                cmbBatchNo.DataSource = Common.Get_BatchList(txtProductCode.Text, true);
                                cmbBatchNo.DisplayMember = "BatchNo";
                                cmbBatchNo.ValueMember = "BatchNo";
                                cmbBatchNo.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Item Not Found.", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtCustCode.Focus();
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
                                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice SearchPriceLevel. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                                // read from file or write to file
                            }
                            finally
                            {
                                m_streamWriter.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        */
                        //----------End Short code display

                        objCustomerReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Whole_Price, Stock_Master.Qty, product.Pack_Size, product.Unit, product.Marked_Price FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code LEFT JOIN tbProductLink ON tbProductLink.Prod_Code = Product.Prod_Code AND Stock_Master.Prod_Code = tbProductLink.Prod_Code WHERE LockedItem = 'F' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR product.Barcode='" + txtProductCode.Text.Trim() + "' OR tbProductLink.Barcode= '" + txtProductCode.Text.Trim() + "') AND Stock_Master.Loca = ";
                        objCustomerReturn.ReadProductDetails();
                        if (objCustomerReturn.RecordFound == true)
                        {
                            txtProductName.Text = objCustomerReturn.ProductName;
                            txtProductCode.Text = objCustomerReturn.ProductCode.ToString();
                            txtSellingPrice.Text = (string)objCustomerReturn.SellingPrice.ToString();
                            lblCurrentQty.Text = (string)objCustomerReturn.CurrentQty.ToString();
                            txtFreeQty.Text = "0";
                            txtDiscount.Text = "0";
                            objCustomerReturn.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objCustomerReturn.ProductCode + "' AND Doc_No = '" + objCustomerReturn.TempDocNo + "' AND IId = 'CUR' AND Loca = ";
                            objCustomerReturn.ReadExsistProductDetails();
                            txtQty.Text = (string)objCustomerReturn.Qty.ToString();
                          
                                cmbBatchNo.DataSource = Common.Get_BatchList(txtProductCode.Text, true);
                                cmbBatchNo.DisplayMember = "BatchNo";
                                cmbBatchNo.ValueMember = "BatchNo";
                                cmbBatchNo.Focus();
                               
                        }
                        else
                        {
                            MessageBox.Show("Product Code Not Found Or Locked For Transaction. Please Check Product Code.", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtProductCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtProductCode.Text = search.Code.Trim();
                    txtProductName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductSearch.IsDisposed)
                {
                    ProductSearch = new frmProductSearch();
                }

                if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    objCustomerReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' AND (P.Prod_Code Like '%" + txtProductCode.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductCode.Text.Trim() + "%')  ORDER BY P.Prod_Name ASC";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objCustomerReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' AND (P.Prod_Name Like '%" + txtProductName.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductName.Text.Trim() + "%')  ORDER BY P.Prod_Name ASC";
                    }
                    else
                    {
                        objCustomerReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F'   ORDER BY P.Prod_Name ASC";
                    }
                }

                objCustomerReturn.DataetName = "dsProduct";
                objCustomerReturn.GetItemDetails();
                ProductSearch.dgSearch.DataSource = objCustomerReturn.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                for (int i = 0; i < objCustomerReturn.GetItemDataset.Tables["dsProduct"].Columns.Count; i++)
                {
                    ProductSearch.dgSearch.Columns[i].ReadOnly = true;
                }
                ProductSearch.dgSearch.DataSource = objCustomerReturn.GetItemDataset.Tables["dsProduct"];
                ProductSearch.prop_Focus = txtProductCode;
                ProductSearch.Show();

                ProductSearch.Location = new Point(this.Location.X, this.Location.Y);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    txtInvoiceNo.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtInvoiceNo.Text.Trim() != string.Empty)
                {
                    txtSalesAssist.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtInvoiceNo.Text.Trim() == string.Empty)
                    {
                        txtSalesAssist.Text = ".";
                        txtSalesAssist.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtQty.Text) > 0)
                {
                    decAmount = decimal.Parse(txtSellingPrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
                    lblAmount.Text = decAmount.ToString();
                    
                    txtDiscount_KeyDown(sender, new KeyEventArgs(Keys.Enter));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtFreeQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtFreeQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtFreeQty.Text) >= 0)
                {
                    txtDiscount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtDiscount.Text.Trim() != string.Empty)
                {
                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objCustomerReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Whole_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.LockedItem = 'F' AND product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objCustomerReturn.ReadProductDetails();
                    if (objCustomerReturn.RecordFound == true)
                    {
                        txtProductName.Text = objCustomerReturn.ProductName;
                        objCustomerReturn.SellingPrice = decimal.Parse(txtSellingPrice.Text.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found or Transaction Locked for This Product. Please Check Product Code.", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductCode.Focus();
                        return;
                    }
                    if (Common.HasRecordFor("select BatchNo from Stock_Master_Batch where Prod_Code='" + txtProductCode.Text + "' and BatchNo='" + cmbBatchNo.Text.Trim() + "' and Loca='" + LoginManager.LocaCode + "'") == false)
                    {
                        MessageBox.Show("Invalid Batch No", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    strDisc = string.Empty;

                    if (clsValidation.isNumeric(txtDiscount.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        CalculateDiscount(txtDiscount.Text.Trim());
                    }
                    else
                    {
                        CalculateDiscountAmount(decimal.Parse(txtDiscount.Text.Trim()));
                    }

                    //Check For Invoice Value and Return Value If Select Invoice is Select
                    decAmount = decimal.Parse(lblNetAmount.Text.ToString()) + decimal.Parse(lblAmount.Text.ToString());
                    if (txtInvoiceNo.Text.Trim() != string.Empty && txtInvoiceNo.Text.Trim() != "." && decAmount > decimal.Parse(lblInvoiceAmount.Text.ToString()))
                    {
                        MessageBox.Show("Return Value Greater Than Selected Invoice Value. Please Enter Correct Return Value.", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQty.Select(0, txtQty.Text.Trim().Length);
                        txtQty.Focus();
                        return;
                    }
                    //***********
                    objCustomerReturn.TempDocNo = lblTempDocNo.Text.Trim();
                    objCustomerReturn.ProductCode = txtProductCode.Text.Trim();
                    objCustomerReturn.ProductName = txtProductName.Text.Trim();
                    lblCurrentQty.Text = objCustomerReturn.CurrentQty.ToString();
                    objCustomerReturn.Qty = decimal.Parse(txtQty.Text.ToString());
                    objCustomerReturn.FreeQty = decimal.Parse(txtFreeQty.Text.ToString());
                    objCustomerReturn.Disc = strDisc;
                    objCustomerReturn.Discount = decimal.Parse(txtDiscount.Text.ToString());
                    objCustomerReturn.Amount = decimal.Parse(lblAmount.Text.ToString());
                    objCustomerReturn.BatchNo = cmbBatchNo.Text.Trim();
                    objCustomerReturn.UpdateInvoiceTempDataSetCus(Settings.Default.TrInCon);
                    objCustomerReturn.GetTempDataset();
                    dataGridTempInvoice.DataSource = objCustomerReturn.TempInvoice.Tables["Invoice"];
                    dataGridTempInvoice.Refresh();
                    //Set Grid Last Record
                    if (dataGridTempInvoice.RowCount > 13)
                    {
                        dataGridTempInvoice.FirstDisplayedCell = dataGridTempInvoice[0, 12];
                    }
                    //******************
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    lblCurrentQty.Text = string.Empty;
                    txtSellingPrice.Text = string.Empty;
                    txtDiscount.Text = "0";
                    txtQty.Text = "0";
                    txtFreeQty.Text = "0";

                    lblAmount.Text = string.Empty;
                    objCustomerReturn.Disc = string.Empty;
                    //txtReference.Enabled = false;
                    //txtRemarks.Enabled = false;

                    objCustomerReturn.GetTotalValues();

                    lblTotalQty.Text = string.Format("{0:0.00}", objCustomerReturn.TotalQty);
                    lblTotalAmount.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);

                    txtSubDiscount.Text = "0";
                    txtSubDiscPer.Text = string.Empty;
                    txtTaxAmount.Text = "0";
                    lblSubTotal.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);
                    txtCustCode.ReadOnly = true;
                    txtCustName.Enabled = false;
                    txtSalesAssist.Enabled = false;
                    txtSaleName.Enabled = false;
                    btnSaleSearch.Enabled = false;
                    txtInvoiceNo.Enabled = false;
                    dtpDate.Enabled = false;
                   // txtReference.Enabled = false;
                   // txtRemarks.Enabled = false;
                    txtSubDiscPer.Enabled = true;
                    txtSubDiscount.Enabled = true;
                    txtTaxAmount.Enabled = true;
                    txtProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void CalculateDiscount(string strDiscText)
        {
            try
            {
                if (strDiscText.IndexOf("%") > 0 && strDiscText.IndexOf("%") < 3)
                {
                    strDisc = strDiscText;
                    intPosOfPerc = strDiscText.IndexOf("%");
                    fltDiscPer = decimal.Parse(strDiscText.Substring(0, intPosOfPerc).ToString());
                    decAmount = decimal.Parse(txtSellingPrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
                    fltDiscPer = 100 - fltDiscPer;
                    decAmount = (decimal.Parse(decAmount.ToString()) * decimal.Parse(fltDiscPer.ToString())) / 100;
                    decDiscountAmount = decimal.Parse(lblAmount.Text) - decAmount;
                    txtDiscount.Text = decDiscountAmount.ToString();
                    lblAmount.Text = decAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiscount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void CalculateDiscountAmount(decimal decDiscText)
        {
            try
            {
                if (decDiscText <= decimal.Parse(lblAmount.Text.ToString()))
                {
                    decAmount = decimal.Parse(txtSellingPrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
                    decAmount = decAmount - decDiscText;
                    decDiscountAmount = decDiscText;
                    txtDiscount.Text = decDiscountAmount.ToString();
                    lblAmount.Text = decAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiscount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        //calculating subtotal discount
        private void CalculateSubTotalDiscount(string strDiscText)
        {
            try
            {
                if (strDiscText.IndexOf("%") > 0 && strDiscText.IndexOf("%") < 3)
                {
                    strDisc = strDiscText;
                    intPosOfPerc = strDiscText.IndexOf("%");
                    fltDiscPer = decimal.Parse(strDiscText.Substring(0, intPosOfPerc).ToString());
                    decAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    fltDiscPer = 100 - fltDiscPer;
                    decAmount = (decimal.Parse(decAmount.ToString()) * decimal.Parse(fltDiscPer.ToString())) / 100;
                    decDiscountAmount = decimal.Parse(lblTotalAmount.Text) - decAmount;
                    txtSubDiscount.Text = string.Format("{0:0.00}", decDiscountAmount);
                    lblSubTotal.Text = string.Format("{0:0.00}", decAmount);
                    txtTaxAmount.Text = "0";
                    lblNetAmount.Text = string.Format("{0:0.00}", decAmount);
                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22%)", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSubDiscPer.Select(0, txtSubDiscPer.Text.Trim().Length);

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void CalculateSubTotalDiscountAmount(decimal decDiscText)
        {
            try
            {
                if (decDiscText <= decimal.Parse(lblTotalAmount.Text.ToString()))
                {
                    decAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    decAmount = decAmount - decDiscText;
                    decDiscountAmount = decDiscText;
                    //txtSubDiscount.Text = decDiscountAmount.ToString();
                    txtSubDiscount.Text = string.Format("{0:0.00}", decDiscountAmount);
                    lblSubTotal.Text = string.Format("{0:0.00}", decAmount);
                    txtTaxAmount.Text = "0";
                    lblNetAmount.Text = string.Format("{0:0.00}", decAmount);
                    txtSubDiscPer.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 225.00)", "Customer Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSubDiscount.Text = "0";
                    txtSubDiscount.Select(0, txtSubDiscount.Text.Trim().Length);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        //Tax Calculation
        private void CalculateTax(string strTaxText)
        {
            try
            {
                if (strTaxText.IndexOf("%") > 0 && strTaxText.IndexOf("%") < 3)
                {
                    strDisc = strTaxText;
                    intPosOfPerc = strTaxText.IndexOf("%");
                    fltDiscPer = decimal.Parse(strTaxText.Substring(0, intPosOfPerc).ToString());
                    decAmount = decimal.Parse(lblSubTotal.Text.ToString());
                    fltDiscPer = 100 + fltDiscPer;
                    decAmount = (decimal.Parse(decAmount.ToString()) * decimal.Parse(fltDiscPer.ToString())) / 100;
                    decDiscountAmount = decAmount - decimal.Parse(lblSubTotal.Text);
                    txtTaxAmount.Text = string.Format("{0:0.00}", decDiscountAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", decAmount);
                }
                else
                {
                    MessageBox.Show("Invalid Tax Percentage. Please Enter Valid Percentage(Ex: 22% )", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaxAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataSet dsDataForReport = new DataSet();
            frmReportViewer objRepViewer = new frmReportViewer();
            try
            {
                objRepViewer.Text = this.Text;
                objCustomerReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'CUR' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objCustomerReturn.ReadTempTransDetails();
                if (objCustomerReturn.RecordFound != true)
                {
                    MessageBox.Show("Customer Return Details Not Found.", "Customer Return Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objCustomerReturn.InvoiceNo = txtInvoiceNo.Text.Trim();
                objCustomerReturn.SalesAssistant = txtSalesAssist.Text.Trim();
                objCustomerReturn.Reference = txtReference.Text.Trim();
                objCustomerReturn.Remark = txtRemarks.Text.Trim();
                objCustomerReturn.Comments = txtComments.Text.Trim();
                objCustomerReturn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                objCustomerReturn.Disc = txtSubDiscPer.Text.Trim();
                objCustomerReturn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                objCustomerReturn.Amount = decimal.Parse(lblNetAmount.Text.ToString());
                objCustomerReturn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());

                objCustomerReturn.GetDataSetForPreview(Settings.Default.Shinghala);
                dsDataForReport = objCustomerReturn.GetReportDataset;

                if (Settings.Default.Shinghala)
                {
                    dsDataForReport.Tables[1].TableName = "dsCompanyLogo";
                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerReturnDetails.rpt");
                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                }
                else
                {
                    dsDataForReport.Tables[1].TableName = "CompanyProfile";
                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerReturnDetails_eng.rpt");
                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                }

                
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesAssist.Text.Trim() == string.Empty)
                {
                    txtSalesAssist.Text = ".";
                }

                if (txtInvoiceNo.Text.Trim() == string.Empty)
                {
                    txtInvoiceNo.Text = ".";
                }

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtReference.Text = ".";
                }

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtRemarks.Text = ".";
                }

                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "Customer Return", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();

                    objCustomerReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'CUR' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objCustomerReturn.ReadTempTransDetails();
                    if (objCustomerReturn.RecordFound != true)
                    {
                        MessageBox.Show("Customer Return  Details Not Found.", "Customer Return Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objCustomerReturn.InvoiceNo = txtInvoiceNo.Text.Trim();
                    objCustomerReturn.SalesAssistant = txtSalesAssist.Text.Trim();
                    objCustomerReturn.Reference = txtReference.Text.Trim();
                    objCustomerReturn.Remark = txtRemarks.Text.Trim();
                    objCustomerReturn.Comments = txtComments.Text.Trim();
                    objCustomerReturn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objCustomerReturn.Disc = txtSubDiscPer.Text.Trim();
                    objCustomerReturn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objCustomerReturn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objCustomerReturn.CustomerReturnSave();
                    MessageBox.Show("Customer Return Successfully Saved as Document No. " + objCustomerReturn.OrgDocNo, "Customer Return Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    this.Dispose();
                    CustomerReturn = null;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (txtSalesAssist.Text.Trim() == string.Empty)
                {
                    txtSalesAssist.Text = ".";
                }

                if (txtInvoiceNo.Text.Trim() == string.Empty)
                {
                    txtInvoiceNo.Text = ".";
                }

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtReference.Text = ".";
                }

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtRemarks.Text = ".";
                }

                if (MessageBox.Show("Do You want to Apply This Document. ", "Customer Retrun", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;
                    objCustomerReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'CUR' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objCustomerReturn.ReadTempTransDetails();
                    if (objCustomerReturn.RecordFound != true)
                    {
                        MessageBox.Show("Customer Return Details Not Found.", "Customer Retrun Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objCustomerReturn.InvoiceNo = txtInvoiceNo.Text.Trim();
                    objCustomerReturn.SalesAssistant = txtSalesAssist.Text.Trim();
                    objCustomerReturn.Reference = txtReference.Text.Trim();
                    objCustomerReturn.Remark = txtRemarks.Text.Trim();
                    objCustomerReturn.Comments = txtComments.Text.Trim();
                    objCustomerReturn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objCustomerReturn.Disc = txtSubDiscPer.Text.Trim();
                    objCustomerReturn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objCustomerReturn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objCustomerReturn.TotalAmount = decimal.Parse(lblNetAmount.Text.ToString());
                    objCustomerReturn.CustomerReturnApply();
                    MessageBox.Show("Customer Retrun Successfully Applied as Document No. " + objCustomerReturn.OrgDocNo, "Customer Retrun Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objCustomerReturn.GetDataSetForReport(Settings.Default.Shinghala);

                    
                    if (Settings.Default.Shinghala)
                    {
                        objCustomerReturn.GetReportDataset.Tables["dsInvoiceDetails1"].TableName = "dsCompanyLogo";
                        dsDataForReport = objCustomerReturn.GetReportDataset;
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerReturnDetails.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    }
                    else
                    {
                        objCustomerReturn.GetReportDataset.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                        dsDataForReport = objCustomerReturn.GetReportDataset;
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerReturnDetails_eng.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    }
                    

                    
                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();

                    this.Close();
                    this.Dispose();
                    CustomerReturn = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 029. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtInvoiceNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if (MessageBox.Show("Are You Sure You want to Return Invoice No :" + search.Code.Trim() + ". ", "Customer Return", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objCustomerReturn.InvoiceNo = search.Code.Trim();
                        objCustomerReturn.SqlStatement = "SELECT Transaction_Header.*, Customer.Cust_Name, Customer.Address1, Customer.Address2, Customer.Address3, Payment_Summary.Balance_Amount FROM Transaction_Header INNER JOIN Customer ON Customer.Cust_code = Transaction_Header.Supplier_Id INNER JOIN Payment_Summary ON Payment_Summary.Doc_No = Transaction_Header.Doc_No AND Payment_Summary.Tr_Type = Transaction_Header.Iid AND Payment_Summary.Loca = Transaction_Header.Loca AND Payment_Summary.Acc_No = Transaction_Header.Supplier_Id WHERE Transaction_Header.iid = 'INV' AND Transaction_Header.Doc_No = '" + search.Code.Trim() + "' AND Transaction_Header.Loca = ";
                        objCustomerReturn.ReadInvoiceDetail();
                        if (objCustomerReturn.RecordFound)
                        {
                            txtCustCode.Text = objCustomerReturn.CustCode.ToString();
                            txtCustName.Text = objCustomerReturn.CustName.ToString();
                            lblCustAddress1.Text = objCustomerReturn.Address1.ToString();
                            lblCustAddress2.Text = objCustomerReturn.Address2.ToString();
                            lblCustAddress3.Text = objCustomerReturn.Address3.ToString();
                            lblInvoiceAmount.Text = objCustomerReturn.InvoiceAmount.ToString();
                            txtCustCode.Enabled = false;
                            txtCustName.Enabled = false;
                            txtInvoiceNo.Enabled = false;
                            btnSearchInvoice.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            btnCustomerSearch.Enabled = false;
                            txtSalesAssist.Focus();
                        }
                        else
                        {
                            txtCustCode.Text = string.Empty;
                            txtCustName.Text = string.Empty;
                            lblCustAddress1.Text = string.Empty;
                            lblCustAddress2.Text = string.Empty;
                            lblCustAddress3.Text = string.Empty;
                            lblInvoiceAmount.Text = "0";
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempInvoice_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridTempInvoice.SelectedRows.Count <= 0 || dataGridTempInvoice.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductCode.Text = dataGridTempInvoice.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dataGridTempInvoice.SelectedRows[0].Cells[1].Value.ToString();
                    objCustomerReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Whole_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem = 'F' AND product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objCustomerReturn.ReadProductDetails();
                    txtSellingPrice.Text = dataGridTempInvoice.SelectedRows[0].Cells[3].Value.ToString();
                    txtQty.Text = dataGridTempInvoice.SelectedRows[0].Cells[4].Value.ToString();
                    txtFreeQty.Text = dataGridTempInvoice.SelectedRows[0].Cells[5].Value.ToString();
                    if (objCustomerReturn.Unit == "Nos")
                    {
                        txtQty.Text = string.Format("{0:0}", decimal.Parse(txtQty.Text.Trim()));
                        txtFreeQty.Text = string.Format("{0:0}", decimal.Parse(txtFreeQty.Text.Trim()));
                    }
                    txtDiscount.Text = dataGridTempInvoice.SelectedRows[0].Cells[6].Value.ToString();
                    lblAmount.Text = dataGridTempInvoice.SelectedRows[0].Cells[7].Value.ToString();
                    //Batch
                    cmbBatchNo.DataSource = Common.Get_BatchList(txtProductCode.Text, true);
                    cmbBatchNo.DisplayMember = "BatchNo";
                    cmbBatchNo.ValueMember = "BatchNo";

                    cmbBatchNo.Text = dataGridTempInvoice.SelectedRows[0].Cells[9].Value.ToString();
                    //Batch
                    txtQty.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridTempInvoice.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objCustomerReturn.TempDocNo = lblTempDocNo.Text.Trim();
                        objCustomerReturn.ProductCode = dataGridTempInvoice.SelectedRows[0].Cells[0].Value.ToString();
                        objCustomerReturn.Qty = decimal.Parse(dataGridTempInvoice.SelectedRows[0].Cells[4].Value.ToString());
                        objCustomerReturn._lnNo = int.Parse(dataGridTempInvoice.SelectedRows[0].Cells[8].Value.ToString());
                        objCustomerReturn.DeleteProductDetaileCus(Settings.Default.TrInCon);
                        objCustomerReturn.GetTempDataset();
                        dataGridTempInvoice.DataSource = objCustomerReturn.TempInvoice.Tables["Invoice"];
                        dataGridTempInvoice.Refresh();

                        objCustomerReturn.GetTotalValues();

                        lblTotalQty.Text = objCustomerReturn.TotalQty.ToString();
                        lblTotalAmount.Text = objCustomerReturn.TotalAmount.ToString();

                        objCustomerReturn.GetTotalValues();

                        lblTotalQty.Text = string.Format("{0:0.00}", objCustomerReturn.TotalQty);
                        lblTotalAmount.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);

                        txtSubDiscount.Text = "0";
                        txtSubDiscPer.Text = string.Empty;
                        txtTaxAmount.Text = "0";
                        lblSubTotal.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);
                        lblNetAmount.Text = string.Format("{0:0.00}", objCustomerReturn.TotalAmount);

                        txtProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 031. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSubDiscPer_KeyDown(object sender, KeyEventArgs e)
        {
            strDisc = string.Empty;
            try
            {
                if (e.KeyCode == Keys.Enter && txtSubDiscPer.Text.Trim() != string.Empty)
                {
                    if (clsValidation.isNumeric(txtSubDiscPer.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        CalculateSubTotalDiscount(txtSubDiscPer.Text.Trim());
                        btnApply.Focus();
                        //txtTaxAmount.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22%)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSubDiscPer.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSubDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            strDisc = string.Empty;
            try
            {
                if (e.KeyCode == Keys.Enter && txtSubDiscount.Text.Trim() != string.Empty)
                {
                    if (clsValidation.isNumeric(txtSubDiscount.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 225.00)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSubDiscount.Text = "0";
                        txtSubDiscount.Select(0, txtSubDiscount.Text.Trim().Length);
                    }
                    else
                    {
                        CalculateSubTotalDiscountAmount(decimal.Parse(txtSubDiscount.Text.Trim()));
                        btnApply.Focus();
                        //txtTaxAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 033. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtTaxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            strDisc = string.Empty;
            try
            {
                if (e.KeyCode == Keys.Enter && txtTaxAmount.Text.Trim() != string.Empty)
                {
                    if (clsValidation.isNumeric(txtTaxAmount.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        CalculateTax(txtTaxAmount.Text.Trim());
                        txtTaxAmount.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Tax Percentage. Please Enter Valid Tax Percentage(Ex: 22%)", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 034. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempInvoice_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                clsDGV dg = new clsDGV();
                dg.invoke(e);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 035. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCustomerReturn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && (txtProductCode.Focused || txtProductName.Focused))
                {
                    btnItemSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtCustCode.Focused || txtCustName.Focused))
                {
                    btnCustomerSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && txtInvoiceNo.Focused)
                {
                    btnSearchInvoice.PerformClick();
                }
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.P)
                        {
                            this.btnPreview.PerformClick();
                        }
                        else
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 036.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtSellingPrice.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtSellingPrice.Text) >= 0)
                {
                    txtQty.SelectAll();
                    txtQty.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (objCustomerReturn.Unit == "Nos")
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                    MessageBox.Show("You can't insert decimals for units of product with Nos.", "Invalid Qty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtQty.Text + e.KeyChar, out d);
                }
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtQty.Text + e.KeyChar, out d);
                }
            }
        }

        private void txtFreeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (objCustomerReturn.Unit == "Nos")
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                    MessageBox.Show("You can't insert decimals for units of product with Nos.", "Invalid Qty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtFreeQty.Text + e.KeyChar, out d);
                }
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtFreeQty.Text + e.KeyChar, out d);
                }
            }
        }

        private void btnSaleSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtSalesAssist.Text.Trim() == string.Empty && txtSaleName.Text.Trim() == string.Empty)
                {
                    objCustomerReturn.SqlStatement = "SELECT Sale_Code AS [Salesman Code],Sale_Name AS [Salesman Name] FROM tb_Salesman ORDER BY Sale_Code";
                }
                else
                {
                    if (txtSalesAssist.Text.Trim() != string.Empty && txtSaleName.Text.Trim() == string.Empty)
                    {
                        objCustomerReturn.SqlStatement = "SELECT Sale_Code AS [Salesman Code],Sale_Name AS [Salesman Name] FROM tb_Salesman WHERE Sale_Code LIKE '%" + txtSalesAssist.Text.Trim() + "%' ORDER BY Sale_Code";
                    }
                    else
                    {
                        if (txtSalesAssist.Text.Trim() == string.Empty && txtSaleName.Text.Trim() != string.Empty)
                        {
                            objCustomerReturn.SqlStatement = "SELECT Sale_Code AS [Salesman Code],sale_Name AS [Salesman Name] FROM tb_Salesman WHERE Sale_Name LIKE '%" + txtSaleName.Text.Trim() + "%' ORDER BY Sale_Code";
                        }
                        else
                        {
                            objCustomerReturn.SqlStatement = "SELECT Sale_Code AS [Salesman Code],Sale_Name AS [Salesman Name] FROM tb_Salesman ORDER BY Sale_Code";
                        }
                    }
                }
                objCustomerReturn.DataetName = "dsSalesman";
                objCustomerReturn.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomerReturn.GetCustomerDataSet.Tables["dsSalesman"];
                search.prop_Focus = txtSalesAssist;
                search.Cont_Descript = txtSaleName;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objCustomerReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'CUR' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objCustomerReturn.ReadTempTransDetails();
                if (objCustomerReturn.RecordFound != true)
                {
                    MessageBox.Show("" + this.Text + " Details Not Found.", "" + this.Text + " Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*
                objCustomerReturn.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'BTNPRN' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objCustomerReturn.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nDelete this " + this.Text + " Invoice through authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }*/
                if (MessageBox.Show("Are You sure you want to delete this document?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objCustomerReturn.SqlStatement = "EXEC sp_DeleteSavedDoc @DocNo = '" + lblTempDocNo.Text + "',  @Loca = '" + LoginManager.LocaCode + "', @Iid = 'CUR'";
                    objCustomerReturn.ReadTempTransDetails();
                    MessageBox.Show("Delete successful!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                objCustomerReturn.Errormsg(ex, "frmCustomerReturn- btnDelete_Click");
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBatchNo.Text != "")
                {
                    DataTable dtBatch = Common.Get_BatchDetails(txtProductCode.Text.Trim(), cmbBatchNo.Text.Trim());
                    if (dtBatch != null && dtBatch.Rows.Count > 0)
                    {
                        //lblBatchExpDate.Text = dtBatch.Rows[0]["Exp_Date"].ToString();
                        //lblBatchShipment.Text = dtBatch.Rows[0]["Shipment"].ToString();
                        //  txt.Text = dtBatch.Rows[0]["Purchase_Price"].ToString();
                        txtSellingPrice.Text = dtBatch.Rows[0]["Ret_Price"].ToString();
                        lblCurrentQty.Text = dtBatch.Rows[0]["Stock"].ToString();

                        objCustomerReturn.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objCustomerReturn.ProductCode + "' AND Doc_No = '" + objCustomerReturn.TempDocNo + "' AND BatchNo='" + cmbBatchNo.Text.Trim() + "' AND IId = 'CUR' AND Loca = ";
                        objCustomerReturn.ReadExsistProductDetails();
                        txtQty.Text = (string)objCustomerReturn.Qty.ToString();
                    }
                    else
                    {
                        lblCurrentQty.Text =  string.Empty;
                    }

                }
                else
                {
                    lblCurrentQty.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void cmbBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtProductCode.Text.Trim() != string.Empty && cmbBatchNo.Text.Trim() != string.Empty && e.KeyCode==Keys.Enter)
                {
                    if (Settings.Default.SRNSellingEdit)
                    {
                        txtSellingPrice.Focus(); txtSellingPrice.SelectAll();
                    }
                    else
                    {
                        txtQty.Focus(); txtQty.SelectAll();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtProductCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductCode.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnItemSearch.PerformClick();
                txtProductCode.Focus();
            }
        }

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnItemSearch.PerformClick();
                txtProductName.Focus();
            }
        }
        bool prodSearching = false;
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtProductCode.Text = string.Empty;
                txtProductName.Text = string.Empty;
            }

            //Serch ON OFF
            if (e.KeyCode == Keys.F5)
            {
                if (prodSearching == true)
                {
                    prodSearching = false;
                    txtProductCode.BackColor = Color.Empty;
                    txtProductName.BackColor = Color.Empty;
                    ProductSearch.Hide();
                }
                else
                {
                    prodSearching = true;
                    txtProductCode.BackColor = Color.MediumAquamarine;
                    txtProductName.BackColor = Color.MediumAquamarine;
                }
            }
            //Blocking Cursor Moving
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                ProductSearch.Focus();
            }

            //Product Serch Selection
            if (ProductSearch.dgSearch.Rows.Count > 0 && ProductSearch.Visible)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ProductSearch.selectRow();

                }
                int select = ProductSearch.dgSearch.SelectedRows[0].Index;
                if (e.KeyCode == Keys.Down && ProductSearch.dgSearch.SelectedRows[0].Index != ProductSearch.dgSearch.Rows.Count - 1)
                {
                    ProductSearch.dgSearch.SelectedRows[0].Selected = false;
                    ProductSearch.dgSearch.Rows[select + 1].Selected = true;
                    ProductSearch.dgSearch.CurrentCell = ProductSearch.dgSearch.Rows[select + 1].Cells[0];

                }
                if (e.KeyCode == Keys.Up && ProductSearch.dgSearch.SelectedRows[0].Index != 0)
                {
                    ProductSearch.dgSearch.SelectedRows[0].Selected = false;
                    ProductSearch.dgSearch.Rows[select - 1].Selected = true;
                    ProductSearch.dgSearch.CurrentCell = ProductSearch.dgSearch.Rows[select - 1].Cells[0];

                }
            }
        }
    }
}