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
    public partial class frmRental : Form
    {
        private decimal decDiscountAmount;
        private decimal decAmount;
        private string strDisc;
        private int intPosOfPerc;   // find Percentage mark on percentage
        private decimal fltDiscPer;
        bool CusSearching = Settings.Default.Searching;
        clsRent objRent = new clsRent();

        public frmRental()
        {
            InitializeComponent();
        }

        private static frmRental Rental;

        private frmSearch search = new frmSearch();

        public static frmRental GetRent
        {
            get { return Rental; }
            set { Rental = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                Rental = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmRental_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Rental = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmRental_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmRental_Load(object sender, EventArgs e)
        {
            try
            {
                //objRent.SqlStatement = "SELECT Temp_Quot FROM DocumentNoDetails WHERE Loca = ";
                //objRent.GetTempDocumentNo();
                //lblTempDocNo.Text = objRent.TempDocNo;
                dataGridTempInvoice.DataSource = objRent.TempInvoice;
                dataGridTempInvoice.Refresh();

                if (CusSearching == true)
                {
                    txtCustCode.BackColor = Color.MediumAquamarine;
                    txtCustName.BackColor = Color.MediumAquamarine;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                objRent.SqlStatement = " SELECT Doc_No [Document No], Post_Date + '  ' + Customer.Cust_Name [Customer] FROM Transaction_Header INNER JOIN Customer on Transaction_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Header.Iid = 'INV'  and Transaction_Header.InvType = 'RENT' and Transaction_Header.Recalled = 'F'AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC ";
                objRent.DataetName = "Table";
                objRent.GetItemDetails();

                search.dgSearch.DataSource = objRent.GetItemDataset.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Load Rental Item  Document No :" + search.Code.Trim() + ". ", "Rental", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objRent.RecallSaveDocNo = search.Code.Trim();
                        objRent.SqlStatement = " SELECT Supplier_Id, To_LocaDesc, PayRemark1, PayRemark2, PayRemark3, Pay_Type, Remarks, Reference, Code, Ref_Name, Tax, Discount FROM Transaction_Header WHERE iid = 'INV' and Transaction_Header.InvType = 'RENT' and Transaction_Header.Recalled = 'F' AND Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
                        objRent.ReadSavedDocument();
                        if (objRent.RecordFound)
                        {
                            lblTempDocNo.Text = objRent.TempDocNo;
                            txtCustCode.Text = objRent.CustCode.ToString();
                            txtCustName.Text = objRent.CustName.ToString();
                            txtCustAddress1.Text = objRent.Address1.ToString();
                            txtCustAddress2.Text = objRent.Address2.ToString();
                            txtCustAddress3.Text = objRent.Address3.ToString();
                            txtReference.Text = objRent.Reference.ToString();
                            txtRemarks.Text = objRent.Remark.ToString();
                            txtSalesAssist.Text = objRent.SalesAssistant.ToString();
                            txtComments.Text = objRent.Comments.ToString();
                            objRent.GetTempDataset();
                            dataGridTempInvoice.DataSource = objRent.TempInvoice.Tables["Invoice"];
                            dataGridTempInvoice.Refresh();

                            objRent.GetTotalValues();

                            lblTotalQty.Text = string.Format("{0:0.00}", objRent.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objRent.TotalAmount);
                            txtSubDiscount.Text = "0";
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objRent.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objRent.TotalAmount);
                            txtCustCode.ReadOnly = true;
                            txtCustName.Enabled = false;
                            txtCustAddress1.Enabled = false;
                            txtCustAddress2.Enabled = false;
                            txtCustAddress3.Enabled = false;
                            txtSalesAssist.Enabled = false;
                            dtpDate.Enabled = false;
                            //txtReference.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objRent.CustCode = txtCustCode.Text.ToString().Trim();
                    objRent.SqlStatement = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "'";
                    objRent.ReadCustomerDetails();
                    if (objRent.RecordFound == true)
                    {
                        txtCustCode.Text = objRent.CustCode;
                        txtCustName.Text = objRent.CustName;
                        txtCustAddress1.Text = objRent.Address1;
                        txtCustAddress2.Text = objRent.Address2;
                        txtCustAddress3.Text = objRent.Address3;
                        txtCustName.Focus();
                    }
                    else
                    {
                        txtCustName.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    txtCustAddress1.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtCustCode.Text = txtCustName.Text = string.Empty;
                    search.Hide();
                    txtCustName.Focus();
                }
                if (e.KeyCode == Keys.F5)
                {
                    if (CusSearching == true)
                    {
                        CusSearching = false;
                        txtCustCode.BackColor = Color.Empty;
                        txtCustName.BackColor = Color.Empty;
                        search.Hide();
                        //ProductSearchImg.Hide();

                        Settings.Default.Searching = false;
                        Settings.Default.Save();
                    }
                    else
                    {
                        CusSearching = true;
                        txtCustCode.BackColor = Color.MediumAquamarine;
                        txtCustName.BackColor = Color.MediumAquamarine;
                        Settings.Default.Searching = true;
                        Settings.Default.Save();
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objRent.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer ORDER BY Cust_Code";
                }
                else
                {
                    if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                        objRent.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                        {
                            objRent.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%' ORDER BY Cust_Name";
                        }
                        else
                        {
                            objRent.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer ORDER BY Cust_Code";
                        }
                    }
                }
                objRent.DataetName = "dsCustomer";
                objRent.GetCustomerDetails();
                search.dgSearch.DataSource = objRent.GetCustomerDataSet.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
                search.Cont_Descript = txtCustName;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustAddress1.Text.Trim() != string.Empty)
                {
                    txtCustAddress2.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtCustAddress1.Text.Trim() == string.Empty)
                    {
                        txtCustAddress1.Text = ".";
                        txtCustAddress2.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustAddress2.Text.Trim() != string.Empty)
                {
                    txtCustAddress3.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtCustAddress2.Text.Trim() == string.Empty)
                    {
                        txtCustAddress2.Text = ".";
                        txtCustAddress3.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustAddress3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustAddress3.Text.Trim() != string.Empty)
                {
                    txtSalesAssist.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtCustAddress3.Text.Trim() == string.Empty)
                    {
                        txtCustAddress3.Text = ".";
                        txtSaleAssisCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && txtReference.Text.Trim() != string.Empty)
                {
                    txtProductCode.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtReference.Text.Trim() == string.Empty)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objRent.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Whole_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem = 'F' AND product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objRent.ReadProductDetails();
                    if (objRent.RecordFound == true)
                    {
                        txtProductName.Text = objRent.ProductName;
                        txtSellingPrice.Text = (string)objRent.SellingPrice.ToString();
                        lblCurrentQty.Text = (string)objRent.CurrentQty.ToString();
                        txtFreeQty.Text = "0";
                        txtDiscount.Text = "0";
                        objRent.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objRent.ProductCode + "' AND Doc_No = '" + objRent.TempDocNo + "' AND IId = 'QUO' AND Loca = ";
                        objRent.ReadExsistProductDetails();
                        txtQty.Text = (string)objRent.Qty.ToString();
                        txtQty.Select(0, txtQty.Text.Trim().Length);
                        txtQty.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found Or Locked For Transaction. Please Check Product Code.", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    objRent.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objRent.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%'";
                    }
                    else
                    {
                        objRent.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product";
                    }
                }

                objRent.DataetName = "dsProduct";
                objRent.GetItemDetails();

                search.dgSearch.DataSource = objRent.GetItemDataset.Tables["dsProduct"];
                search.prop_Focus = txtProductCode;
                search.Cont_Descript = txtProductName;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    txtFreeQty.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objRent.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Whole_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.LockedItem = 'F' AND product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objRent.ReadProductDetails();
                    if (objRent.RecordFound == true)
                    {
                        txtProductName.Text = objRent.ProductName;
                        txtSellingPrice.Text = (string)objRent.SellingPrice.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found or Transaction Locked for This Product. Please Check Product Code.", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductCode.Focus();
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

                    objRent.ProductCode = txtProductCode.Text.Trim().ToUpper();
                    objRent.ProductName = txtProductName.Text.Trim().ToUpper();
                    lblCurrentQty.Text = objRent.CurrentQty.ToString();
                    objRent.Qty = decimal.Parse(txtQty.Text.ToString());
                    objRent.FreeQty = decimal.Parse(txtFreeQty.Text.ToString());
                    objRent.Disc = strDisc;
                    objRent.Discount = decimal.Parse(txtDiscount.Text.ToString());

                    objRent.Amount = decimal.Parse(lblAmount.Text.ToString());
                    objRent.UpdateInvoiceTempDataSet();
                    objRent.GetTempDataset();
                    dataGridTempInvoice.DataSource = objRent.TempInvoice.Tables["Invoice"];
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
                    objRent.Disc = string.Empty;
                    //txtReference.Enabled = false;
                    //txtRemarks.Enabled = false;

                    objRent.GetTotalValues();

                    lblTotalQty.Text = string.Format("{0:0.00}", objRent.TotalQty);
                    lblTotalAmount.Text = string.Format("{0:0.00}", objRent.TotalAmount);

                    txtSubDiscount.Text = "0";
                    txtSubDiscPer.Text = string.Empty;
                    txtTaxAmount.Text = "0";
                    lblSubTotal.Text = string.Format("{0:0.00}", objRent.TotalAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", objRent.TotalAmount);
                    txtCustCode.ReadOnly = true;
                    txtCustName.Enabled = false;
                    txtCustAddress1.Enabled = false;
                    txtCustAddress2.Enabled = false;
                    txtCustAddress3.Enabled = false;
                    txtSalesAssist.Enabled = false;
                    dtpDate.Enabled = false;
                    //txtReference.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                        txtTaxAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22%)", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 225.00)", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objRent.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Whole_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem = 'F' AND product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objRent.ReadProductDetails();
                    txtSellingPrice.Text = dataGridTempInvoice.SelectedRows[0].Cells[3].Value.ToString();
                    txtQty.Text = dataGridTempInvoice.SelectedRows[0].Cells[4].Value.ToString();
                    txtFreeQty.Text = dataGridTempInvoice.SelectedRows[0].Cells[5].Value.ToString();
                    txtDiscount.Text = dataGridTempInvoice.SelectedRows[0].Cells[6].Value.ToString();
                    lblAmount.Text = dataGridTempInvoice.SelectedRows[0].Cells[7].Value.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 029. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Rental", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objRent.TempDocNo = lblTempDocNo.Text.Trim();
                        objRent.ProductCode = dataGridTempInvoice.SelectedRows[0].Cells[0].Value.ToString();
                        objRent.DeleteProductDetaile();
                        objRent.GetTempDataset();
                        dataGridTempInvoice.DataSource = objRent.TempInvoice.Tables["Invoice"];
                        dataGridTempInvoice.Refresh();

                        objRent.GetTotalValues();

                        lblTotalQty.Text = objRent.TotalQty.ToString();
                        lblTotalAmount.Text = objRent.TotalAmount.ToString();

                        objRent.GetTotalValues();

                        lblTotalQty.Text = string.Format("{0:0.00}", objRent.TotalQty);
                        lblTotalAmount.Text = string.Format("{0:0.00}", objRent.TotalAmount);

                        txtSubDiscount.Text = "0";
                        txtSubDiscPer.Text = string.Empty;
                        txtTaxAmount.Text = "0";
                        lblSubTotal.Text = string.Format("{0:0.00}", objRent.TotalAmount);
                        lblNetAmount.Text = string.Format("{0:0.00}", objRent.TotalAmount);

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objRent.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'QUO' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objRent.ReadTempTransDetails();
                if (objRent.RecordFound != true)
                {
                    MessageBox.Show("Rental Details Not Found.", "Rental Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objRent.CustCode = txtCustCode.Text.Trim();
                objRent.CustName = txtCustName.Text.Trim();
                objRent.Address1 = txtCustAddress1.Text.Trim();
                objRent.Address2 = txtCustAddress2.Text.Trim();
                objRent.Address3 = txtCustAddress3.Text.Trim();
                objRent.PostDate = dtpDate.Text;
                objRent.SalesAssistant = txtSalesAssist.Text.Trim();
                objRent.Reference = txtReference.Text.Trim();
                objRent.Remark = txtRemarks.Text.Trim();
                objRent.Comments = txtComments.Text.Trim();
                objRent.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                objRent.Disc = txtSubDiscPer.Text.Trim();
                objRent.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                objRent.Amount = decimal.Parse(lblNetAmount.Text.ToString());
                objRent.Tax = decimal.Parse(txtTaxAmount.Text.ToString());

                objRent.GetDataSetForPreview();
                dsDataForReport = objRent.GetReportDataset;
                rptQuotation Rental = new rptQuotation();
                Rental.SetDataSource(dsDataForReport);

                objRepViewer.crystalReportViewer1.ReportSource = Rental;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 031. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtReference.Text = ".";
                }

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtRemarks.Text = ".";
                }

                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "Rental", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();

                    objRent.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'QUO' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objRent.ReadTempTransDetails();
                    if (objRent.RecordFound != true)
                    {
                        MessageBox.Show("Rental Details Not Found.", "Rental Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    objRent.CustName = txtCustName.Text.Trim();
                    objRent.Address1 = txtCustAddress1.Text.Trim();
                    objRent.Address2 = txtCustAddress2.Text.Trim();
                    objRent.Address3 = txtCustAddress3.Text.Trim();
                    objRent.SalesAssistant = txtSalesAssist.Text.Trim();
                    objRent.Reference = txtReference.Text.Trim();
                    objRent.Remark = txtRemarks.Text.Trim();
                    objRent.Comments = txtComments.Text.Trim();
                    objRent.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objRent.Disc = txtSubDiscPer.Text.Trim();
                    objRent.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objRent.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objRent.InvoiceSave();
                    MessageBox.Show("Rental Successfully Saved as Document No. " + objRent.OrgDocNo, "Rental Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    this.Dispose();
                    Rental = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtReference.Text = ".";
                }

                if (txtReference.Text.Trim() == string.Empty)
                {
                    txtRemarks.Text = ".";
                }

                if (MessageBox.Show("Do You want to Apply This Document. ", "Rental", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();

                    objRent.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'QUO' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objRent.ReadTempTransDetails();
                    if (objRent.RecordFound != true)
                    {
                        MessageBox.Show("Rental Details Not Found.", "Rental Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    objRent.CustCode = txtCustCode.Text.Trim().ToUpper();
                    objRent.CustName = txtCustName.Text.Trim().ToUpper();
                    objRent.Address1 = txtCustAddress1.Text.Trim().ToUpper();
                    objRent.Address2 = txtCustAddress2.Text.Trim().ToUpper();
                    objRent.Address3 = txtCustAddress3.Text.Trim().ToUpper();
                    objRent.SalesAssistant = txtSalesAssist.Text.Trim();
                    objRent.Reference = txtReference.Text.Trim();
                    objRent.Remark = txtRemarks.Text.Trim();
                    objRent.Comments = txtComments.Text.Trim();
                    objRent.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objRent.Disc = txtSubDiscPer.Text.Trim();
                    objRent.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objRent.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objRent.TotalAmount = decimal.Parse(lblNetAmount.Text.ToString());
                    objRent.InvoiceApply();
                    MessageBox.Show("Rental Successfully Applied as Document No. " + objRent.OrgDocNo, "Rental Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objRent.GetDataSetForReport();
                    objRent.GetReportDataset.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                    dsDataForReport = objRent.GetReportDataset;
                    rptQuotation Rental = new rptQuotation();
                    Rental.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = Rental;
                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();

                    this.Close();
                    this.Dispose();
                    Rental = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 033. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmRental_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 034.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            try
            {
                strDisc = string.Empty;
                if (e.KeyCode == Keys.Enter && txtSubDiscPer.Text.Trim() != string.Empty)
                {
                    if (clsValidation.isNumeric(txtSubDiscPer.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        CalculateSubTotalDiscount(txtSubDiscPer.Text.Trim());
                        txtTaxAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 035. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSubDiscount_KeyDown_1(object sender, KeyEventArgs e)
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
                        txtTaxAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 036. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                        MessageBox.Show("Invalid Tax Percentage. Please Enter Valid Tax Percentage(Ex: 22%)", "Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 037. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnAssitant_Click(object sender, EventArgs e)
        {
            try
            {

                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtSaleAssisCode.Text.Trim() == string.Empty && txtSalesAssist.Text.Trim() == string.Empty)
                {
                    objRent.SqlStatement = "select Sale_Code[Saleman Code], Sale_Name[Salesman Name] from tb_Salesman order by Sale_Code ASC";
                }
                else
                {
                    if (txtSaleAssisCode.Text.Trim() != string.Empty && txtSalesAssist.Text.Trim() == string.Empty)
                    {
                        objRent.SqlStatement = "select Sale_Code[Saleman Code],Sale_Name[Salesman Name] from tb_Salesman  WHERE Sale_Code  LIKE '%" + txtSaleAssisCode.Text.Trim() + "%' order by Sale_Code ASC";
                    }
                    else
                    {
                        if (txtSaleAssisCode.Text.Trim() == string.Empty && txtSalesAssist.Text.Trim() != string.Empty)
                        {
                            objRent.SqlStatement = "select Sale_Code[Saleman Code], Sale_Name[Salesman Name] from tb_Salesman WHERE Sale_Name  LIKE '%" + txtSalesAssist.Text.Trim() + "%' order by Sale_Name ASC";
                        }
                        else
                        {
                            objRent.SqlStatement = "select Sale_Code[Saleman Code], Sale_Name[Salesman Name] from tb_Salesman order by Sale_Code ASC";
                        }
                    }
                }
                objRent.DataetName = "dsAssitant";
                objRent.GetCustomerDetails();
                search.dgSearch.DataSource = objRent.GetCustomerDataSet.Tables["dsAssitant"];
                search.prop_Focus = txtSaleAssisCode;
                search.Cont_Descript = txtSalesAssist;
                search.Show();

            }
            catch (Exception ex)
            {
                clsClear.Err(ex.Message, ex.StackTrace);
            }
        }

        private void txtSaleAssisCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtSaleAssisCode.Text = search.Code.Trim();
                txtSalesAssist.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        private void txtSaleAssisCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSaleAssisCode.Text != string.Empty)
                {
                    objRent.SalesAssisCode = txtSaleAssisCode.Text.Trim();
                    objRent.SqlStatement = "select Sale_Code, Sale_Name from tb_Salesman where Sale_Code = '"+txtSaleAssisCode.Text.Trim()+"'";
                    objRent.ReadAssitantDetail();
                    if(objRent.RecordFound == true)
                    {
                        txtSaleAssisCode.Text = objRent.SalesAssisCode;
                        txtSalesAssist.Text = objRent.SalesAssistant;
                        txtReference.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Sales Assitant Code Invalid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSaleAssisCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmRental 031. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
                txtCustName.Focus();
            }
        }
    }
}