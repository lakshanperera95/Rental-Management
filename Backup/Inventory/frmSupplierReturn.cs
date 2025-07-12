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
namespace Inventory
{
    public partial class frmSupplierReturn : Form
    {
        private decimal decDiscountAmount;
        private decimal decAmount;
        bool prodSearching = false;
        private string strDisc;

        private int intPosOfPerc;   // find Percentage mark on percentage
        private decimal fltDiscPer;

        clsSupplierReturn objSupplierReturn = new clsSupplierReturn();
        clsCommon Common = new clsCommon();

        private static frmSupplierReturn SupplierReturn;

        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();
        private frmProductShortCodeDialog prodShortCode = new frmProductShortCodeDialog();

        public frmSupplierReturn()
        {
            InitializeComponent();
        }

        public static frmSupplierReturn GetSupplierReturn
        {
            get { return SupplierReturn; }
            set { SupplierReturn = value; }
        }

        private void frmSupplierReturn_Load(object sender, EventArgs e)
        {
            try
            {
                objSupplierReturn.SqlStatement = "SELECT Temp_Prn FROM DocumentNoDetails WHERE Loca = ";
                objSupplierReturn.GetTempDocumentNo();
                lblTempDocNo.Text = objSupplierReturn.TempDocNo;
                dataGridTempGRN.DataSource = objSupplierReturn.TempGrn;
                dataGridTempGRN.Refresh();
                txtPurchasePrice.Enabled = Settings.Default.PRNCostEdit;
                txtSellingPrice.Enabled = Settings.Default.PRNSellingEdit;
               
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                SupplierReturn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSupplierReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SupplierReturn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSupplierReturn_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objSupplierReturn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objSupplierReturn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            objSupplierReturn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                        }
                        else
                        {
                            objSupplierReturn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
             
                        }
                    }
                }
                objSupplierReturn.DataetName = "dsSupplier";
                objSupplierReturn.GetSupplierDetails();
                search.dgSearch.DataSource = objSupplierReturn.GetSupplierDataset.Tables["dsSupplier"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objSupplierReturn.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objSupplierReturn.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objSupplierReturn.ReadSupplierDetails();
                    if (objSupplierReturn.RecordFound == true)
                    {
                        txtSuppCode.Text = objSupplierReturn.SuppCode;
                        txtSuppName.Text = objSupplierReturn.SuppName;
                        txtSuppName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSuppName.Text.Trim() != "")
                {
                    txtReference.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                objSupplierReturn.SqlStatement = "SELECT Doc_No [Document No], Post_Date + '  ' + Supplier.Supp_Name [Supplier] FROM Transaction_Save_Header INNER JOIN supplier on Transaction_Save_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                objSupplierReturn.DataetName = "Table";
                objSupplierReturn.GetItemDetails();

                search.dgSearch.DataSource = objSupplierReturn.GetItemDataset.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void lblGrnNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if (MessageBox.Show("Are You Sure You want to Return Grn No :" + search.Code.Trim() + ". ", "Supplier Return", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objSupplierReturn.GrnNo = search.Code.Trim();
                        objSupplierReturn.SqlStatement = "SELECT Transaction_Header.*, Supplier.Supp_Name, Payment_Summary.Balance_Amount FROM Transaction_Header INNER JOIN Payment_Summary ON Payment_Summary.Doc_No = Transaction_Header.Doc_No AND Payment_Summary.Tr_Type = Transaction_Header.Iid AND Payment_Summary.Loca = Transaction_Header.Loca AND Payment_Summary.Acc_No = Transaction_Header.Supplier_Id INNER JOIN Supplier ON Supplier.Supp_code = Transaction_Header.Supplier_Id WHERE iid = 'GRN' AND Transaction_Header.Doc_No = '" + search.Code.Trim() + "' AND Transaction_Header.Loca = ";
                        objSupplierReturn.TempDocNo = lblTempDocNo.Text.Trim();
                        objSupplierReturn.ReadGrnDetail();

                        if (objSupplierReturn.RecordFound)
                        {
                            txtSuppCode.Text = objSupplierReturn.SuppCode.ToString();
                            txtSuppName.Text = objSupplierReturn.SuppName.ToString();
                            lblGRNAmount.Text = objSupplierReturn.GrnAmount.ToString();
                            txtSuppCode.Enabled = false;
                            txtSuppName.Enabled = false;
                            btnGrnSearch.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            btnSupplierSearch.Enabled = false;

                            objSupplierReturn.GetTempDataset();
                            dataGridTempGRN.DataSource = objSupplierReturn.TempGrn.Tables["GoodReceivedNote"];
                            dataGridTempGRN.Refresh();

                            objSupplierReturn.GetTotalValues();

                            lblTotalQty.Text = string.Format("{0:0.00}", objSupplierReturn.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                            txtSubDiscount.Text = "0";
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                            txtSuppCode.ReadOnly = true;
                            txtSuppName.Enabled = false;
                            dtpDate.Enabled = false;
                            // txtReference.Enabled = false;
                            // txtRemarks.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            btnGrnSearch.Enabled = false;
                            //btnSupplierSearch.Enabled = false;

                            txtReference.Focus();
                        }
                        else
                        {
                            txtSuppCode.Text = string.Empty;
                            txtSuppName.Text = string.Empty;
                            lblGRNAmount.Text = "0";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnGrnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtSuppCode.Text.Trim() != string.Empty)
                {
                    objSupplierReturn.SqlStatement = "SELECT Doc_No [Document No], Transaction_Date + ' ' +  Supplier.Supp_Name [Supplier] FROM  Payment_Summary INNER JOIN Supplier ON Payment_Summary.Acc_No = Supplier.Supp_Code WHERE Acc_No = '" + txtSuppCode.Text.Trim() + "' AND Tr_Type = 'GRN' AND Payment_Summary.Loca = '" + LoginManager.LocaCode + "' AND Balance_Amount > 0 ORDER BY RIGHT(Doc_No,6) DESC";
                }
                else
                {
                    objSupplierReturn.SqlStatement = "SELECT Doc_No [Document No], Transaction_Date + ' ' +  Supplier.Supp_Name [Supplier] FROM  Payment_Summary INNER JOIN Supplier ON Payment_Summary.Acc_No = Supplier.Supp_Code WHERE Tr_Type = 'GRN' AND Payment_Summary.Loca = '" + LoginManager.LocaCode + "' AND Balance_Amount > 0 ORDER BY RIGHT(Doc_No,6) DESC";
                }
                objSupplierReturn.DataetName = "Table";
                objSupplierReturn.GetItemDetails();

                search.dgSearch.DataSource = objSupplierReturn.GetItemDataset.Tables["Table"];
                search.Show();

                search.prop_Focus = lblGrnNumber;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    
                    objSupplierReturn.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objSupplierReturn.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objSupplierReturn.ReadSupplierDetails();
                    if (objSupplierReturn.RecordFound == true)
                    {
                        txtSuppCode.Text = objSupplierReturn.SuppCode;
                        txtSuppName.Text = objSupplierReturn.SuppName;
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSuppCode.Focus();
                    }
                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    if (chkAccOtherSuppProd.Checked != true)
                    {
                        objSupplierReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price]  FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code LEFT JOIN tbProductLink ON tbProductLink.Prod_Code = Product.Prod_Code AND Stock_Master.Prod_Code = tbProductLink.Prod_Code WHERE product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '') OR tbProductLink.Barcode= '" + txtProductCode.Text.Trim() + "') AND LockedItem='F' and Stock_Master.Loca = ";
                    }
                    else
                    {

                        objSupplierReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price]  FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code LEFT JOIN tbProductLink ON tbProductLink.Prod_Code = Product.Prod_Code AND Stock_Master.Prod_Code = tbProductLink.Prod_Code WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '') OR tbProductLink.Barcode= '" + txtProductCode.Text.Trim() + "' ) AND LockedItem='F' AND Stock_Master.Loca = ";
                    }
                    objSupplierReturn.ReadProductDetails();
                    if (objSupplierReturn.RecordFound == true)
                    {
                        txtProductCode.Text = objSupplierReturn.ProductCode;
                        txtProductName.Text = objSupplierReturn.ProductName;
                        txtPurchasePrice.Text = (string)objSupplierReturn.PurchasePrice.ToString();
                        txtSellingPrice.Text = (string)objSupplierReturn.SellingPrice.ToString();
                        lblCurrentQty.Text = (string)objSupplierReturn.CurrentQty.ToString();
                        txtFreeQty.Text = "0";
                        txtDiscount.Text = "0";


                        cmbBatchNo.DataSource = Common.Get_BatchList(txtProductCode.Text,true);
                        cmbBatchNo.DisplayMember = "BatchNo";
                        cmbBatchNo.ValueMember = "BatchNo";
                        cmbBatchNo.Focus();

                        //if (Settings.Default.PRNCostEdit)
                        //{
                        //    txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                        //}
                        //else
                        //{
                        //    txtQty.Focus(); txtQty.SelectAll();
                        //}
                        
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Supplier Return Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                string withSupplier = (chkAccOtherSuppProd.Checked) ? "" : " AND P.Supplier_Id = '" + txtSuppCode.Text.Trim() + "'";
                if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    objSupplierReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND (P.Prod_Code Like '%" + txtProductCode.Text.Trim() + "%' OR P.Barcode Like '%" + txtProductCode.Text.Trim() + "%' ) " + withSupplier + " ORDER BY P.Prod_Name ASC";
                }
                else if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                {
                    objSupplierReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND (P.Prod_Name Like '%" + txtProductName.Text.Trim() + "%' OR P.Barcode Like '%" + txtProductName.Text.Trim() + "%' ) " + withSupplier + " ORDER BY P.Prod_Name ASC";
                }
                else
                {
                    objSupplierReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "'" + withSupplier + " ORDER BY P.Prod_Name ASC";
                }

                objSupplierReturn.DataetName = "dsProduct";
                objSupplierReturn.GetItemDetails();
                ProductSearch.dgSearch.DataSource = objSupplierReturn.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                for (int i = 0; i < objSupplierReturn.GetItemDataset.Tables["dsProduct"].Columns.Count; i++)
                {
                    ProductSearch.dgSearch.Columns[i].ReadOnly = true;
                }
                ProductSearch.prop_Focus = txtProductCode;
                ProductSearch.Location = new Point(this.Location.X, this.Location.Y);

                ProductSearch.Show();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter && txtProductName.Text.Trim() != String.Empty)
                //{
                //    txtQty.Focus();
                //}

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
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    decAmount = decimal.Parse(txtPurchasePrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    decAmount = decimal.Parse(txtPurchasePrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
                    fltDiscPer = 100 - fltDiscPer;
                    decAmount = (decimal.Parse(decAmount.ToString()) * decimal.Parse(fltDiscPer.ToString())) / 100;
                    decDiscountAmount = decimal.Parse(lblAmount.Text) - decAmount;
                    txtDiscount.Text = decDiscountAmount.ToString();
                    lblAmount.Text = decAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    decAmount = decimal.Parse(txtPurchasePrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
                    decAmount = decAmount - decDiscText;
                    decDiscountAmount = decDiscText;
                    txtDiscount.Text = decDiscountAmount.ToString();
                    lblAmount.Text = decAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22%)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 225.00)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (chkAccOtherSuppProd.Checked != true)
                    {
                        objSupplierReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) AND LockedItem='F'  and Stock_Master.Loca = ";
                    }
                    else
                    {
                        objSupplierReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) AND LockedItem='F'  and Stock_Master.Loca = ";
                    }
                    objSupplierReturn.ReadProductDetails();
                    if (objSupplierReturn.RecordFound == true)
                    {
                        txtProductName.Text = objSupplierReturn.ProductName;

                        if (Settings.Default.PRNCostEdit)
                        {
                            objSupplierReturn.PurchasePrice = decimal.Parse(txtPurchasePrice.Text);
                        }
                       
                        if (Settings.Default.PRNSellingEdit)
                        {
                            objSupplierReturn.SellingPrice = decimal.Parse(txtSellingPrice.Text);
                        }
                       

                        //Batch Price
                            if (Common.HasRecordFor("select BatchNo from Stock_Master_Batch where Prod_Code='" + txtProductCode.Text + "' and BatchNo='" + cmbBatchNo.Text.Trim() + "' and Loca='" + LoginManager.LocaCode + "'") == false)
                            {
                                MessageBox.Show("Invalid Batch No", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            
                            //DataTable dtBatch = Common.Get_BatchDetails(txtProductCode.Text.Trim(), cmbBatchNo.Text.Trim());
                            //if (dtBatch != null && dtBatch.Rows.Count > 0)
                            //{
                            //    lblBatchExpDate.Text = dtBatch.Rows[0]["Exp_Date"].ToString();
                            //    lblBatchShipment.Text = dtBatch.Rows[0]["Shipment"].ToString();
                            //    txtPurchasePrice.Text = dtBatch.Rows[0]["Purchase_Price"].ToString();
                            //    txtSellingPrice.Text = dtBatch.Rows[0]["Ret_Price"].ToString();
                            //    lblCurrentQty.Text = dtBatch.Rows[0]["Stock"].ToString();
                            //}
                            //else
                            //{
                            //    lblBatchExpDate.Text = lblBatchShipment.Text = string.Empty;
                            //}

                            objSupplierReturn.SellingPrice = decimal.Parse(txtSellingPrice.Text);
                            objSupplierReturn.PurchasePrice = decimal.Parse(txtPurchasePrice.Text);
                            objSupplierReturn.CurrentQty = decimal.Parse(lblCurrentQty.Text);
                        //end batch Price
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    ////Check For Invoice Value and Return Value If Select Invoice is Select
                    //decAmount = decimal.Parse(lblNetAmount.Text.ToString()) + decimal.Parse(lblAmount.Text.ToString());
                    //if (lblGrnNumber.Text.Trim() != string.Empty && decAmount > decimal.Parse(lblGRNAmount.Text.ToString()))
                    //{
                    //    MessageBox.Show("Return Value Greater Than Selected Good Received Note Value. Please Enter Correct Return Value.", "Supplier Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtQty.Select(0, txtQty.Text.Trim().Length);
                    //    txtQty.Focus();
                    //    return;
                    //}
                    //***********

                    objSupplierReturn.ProductCode = txtProductCode.Text.Trim();
                    objSupplierReturn.ProductName = txtProductName.Text.Trim();
                    lblCurrentQty.Text = objSupplierReturn.CurrentQty.ToString();
                    objSupplierReturn.Qty = decimal.Parse(txtQty.Text.ToString());
                    objSupplierReturn.FreeQty = decimal.Parse(txtFreeQty.Text.ToString());
                    objSupplierReturn.Disc = strDisc;
                    objSupplierReturn.Discount = decimal.Parse(txtDiscount.Text.ToString());
                    //objSupplierReturn.Amount = (decimal.Parse(txtQty.Text.ToString()) * objSupplierReturn.SellingPrice) - decimal.Parse(txtDiscount.Text.ToString());
                    objSupplierReturn.Amount = decimal.Parse(lblAmount.Text.ToString());
                    objSupplierReturn.BatchNo = cmbBatchNo.Text.Trim();
                    objSupplierReturn.UpdateSrnTempDataSet();
                    objSupplierReturn.GetTempDataset();
                    dataGridTempGRN.DataSource = objSupplierReturn.TempGrn.Tables["GoodReceivedNote"];
                    dataGridTempGRN.Refresh();
                    //Set Grid Last Record
                    if (dataGridTempGRN.RowCount > 12)
                    {
                        dataGridTempGRN.FirstDisplayedCell = dataGridTempGRN[0, dataGridTempGRN.RowCount - 6];
                    }
                    //******************
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    lblCurrentQty.Text = string.Empty;
                    txtPurchasePrice.Text = string.Empty;
                    txtSellingPrice.Text = string.Empty;
                    txtDiscount.Text = "0";
                    txtQty.Text = "0";
                    txtFreeQty.Text = "0";

                    lblAmount.Text = string.Empty;
                    objSupplierReturn.Disc = string.Empty;
                   // txtReference.Enabled = false;
                   // txtRemarks.Enabled = false;

                    objSupplierReturn.GetTotalValues();

                    lblTotalQty.Text = string.Format("{0:0.00}", objSupplierReturn.TotalQty);
                    lblTotalAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);

                    txtSubDiscount.Text = "0";
                    txtSubDiscPer.Text = string.Empty;
                    txtTaxAmount.Text = "0";
                    lblSubTotal.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                    txtSuppCode.ReadOnly = true;
                    txtSuppName.Enabled = false;
                    dtpDate.Enabled = false;
                    //txtReference.Enabled = true;
                    //txtRemarks.Enabled = true;
                    txtSubDiscPer.Enabled = true;
                    txtSubDiscount.Enabled = true;
                    txtTaxAmount.Enabled = true;

                    cmbBatchNo.SelectedIndex = -1;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void dataGridTempGRN_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridTempGRN.SelectedRows.Count <= 0 || dataGridTempGRN.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductCode.Text = dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dataGridTempGRN.SelectedRows[0].Cells[1].Value.ToString();
                    objSupplierReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objSupplierReturn.ReadProductDetails();
                    
                    txtPurchasePrice.Text = dataGridTempGRN.SelectedRows[0].Cells[5].Value.ToString();
                    txtSellingPrice.Text = dataGridTempGRN.SelectedRows[0].Cells[6].Value.ToString();
                    txtQty.Text = dataGridTempGRN.SelectedRows[0].Cells[7].Value.ToString();
                    txtFreeQty.Text = dataGridTempGRN.SelectedRows[0].Cells[8].Value.ToString();
                    if (objSupplierReturn.Unit == "Nos")
                    {
                        txtQty.Text = string.Format("{0:0}", decimal.Parse(txtQty.Text.Trim()));
                        txtFreeQty.Text = string.Format("{0:0}", decimal.Parse(txtFreeQty.Text.Trim()));
                    }
                    
                    txtDiscount.Text = dataGridTempGRN.SelectedRows[0].Cells[9].Value.ToString();
                    lblAmount.Text = dataGridTempGRN.SelectedRows[0].Cells[10].Value.ToString();

                    //Batch
                        cmbBatchNo.DataSource = Common.Get_BatchList(txtProductCode.Text,true);
                        cmbBatchNo.DisplayMember = "BatchNo";
                        cmbBatchNo.ValueMember = "BatchNo";

                        cmbBatchNo.Text = dataGridTempGRN.SelectedRows[0].Cells[2].Value.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempGRN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objSupplierReturn.TempDocNo = lblTempDocNo.Text.Trim();
                        objSupplierReturn.ProductCode = dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString();
                        objSupplierReturn.BatchNo = dataGridTempGRN.SelectedRows[0].Cells[2].Value.ToString();
                        objSupplierReturn.DeleteProductDetaile();
                        objSupplierReturn.GetTempDataset();
                        dataGridTempGRN.DataSource = objSupplierReturn.TempGrn.Tables["GoodReceivedNote"];
                        dataGridTempGRN.Refresh();

                        objSupplierReturn.GetTotalValues();

                        lblTotalQty.Text = objSupplierReturn.TotalQty.ToString();
                        lblTotalAmount.Text = objSupplierReturn.TotalAmount.ToString();

                        objSupplierReturn.GetTotalValues();

                        lblTotalQty.Text = string.Format("{0:0.00}", objSupplierReturn.TotalQty);
                        lblTotalAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);

                        txtSubDiscount.Text = "0";
                        txtSubDiscPer.Text = string.Empty;
                        txtTaxAmount.Text = "0";
                        lblSubTotal.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                        lblNetAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objSupplierReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'SRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objSupplierReturn.ReadTempTransDetails();
                if (objSupplierReturn.RecordFound != true)
                {
                    MessageBox.Show("Supplier Return Note Details Not Found.", "Supplier Return Note Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objSupplierReturn.Reference = txtReference.Text.Trim();
                objSupplierReturn.GrnNo = lblGrnNumber.Text.Trim();
                objSupplierReturn.Reference = txtReference.Text.Trim();
                objSupplierReturn.Remark = txtRemarks.Text.Trim();
                objSupplierReturn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                objSupplierReturn.Disc = txtSubDiscPer.Text.Trim();
                objSupplierReturn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                objSupplierReturn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                objSupplierReturn.Amount = decimal.Parse(lblNetAmount.Text.ToString());

                objSupplierReturn.GetDataSetForPreview();
                dsDataForReport = objSupplierReturn.GetReportDataset;
                rptSupplierReturnNote rptSrn = new rptSupplierReturnNote();
                rptSrn.SetDataSource(dsDataForReport);

                objRepViewer.crystalReportViewer1.ReportSource = rptSrn;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 029. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                        MessageBox.Show("Invalid Tax Percentage. Please Enter Valid Tax Percentage(Ex: 22%)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "Supplier Return Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    objSupplierReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'SRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objSupplierReturn.ReadTempTransDetails();
                    if (objSupplierReturn.RecordFound != true)
                    {
                        MessageBox.Show("Supplier Return Note Details Not Found.", "Supplier Return Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objSupplierReturn.Reference = txtReference.Text.Trim();
                    objSupplierReturn.GrnNo = lblGrnNumber.Text.Trim();
                    objSupplierReturn.GrnAmount = decimal.Parse(lblGRNAmount.Text.ToString());
                    objSupplierReturn.Reference = txtReference.Text.Trim();
                    objSupplierReturn.Remark = txtRemarks.Text.Trim();
                    objSupplierReturn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objSupplierReturn.Disc = txtSubDiscPer.Text.Trim();
                    objSupplierReturn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objSupplierReturn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objSupplierReturn.SupplierReturnNoteSave();
                    MessageBox.Show("Supplier Return Note Successfully Saved as Document No. " + objSupplierReturn.OrgDocNo, "Supplier Return Note Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GC.Collect();
                    this.Close();
                    this.Dispose();
                    SupplierReturn = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 031. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Load Saved GRN Document No :" + search.Code.Trim() + ". ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objSupplierReturn.RecallSaveDocNo = search.Code.Trim();
                        objSupplierReturn.SqlStatement = "SELECT Transaction_Save_Header.*, Supplier.Supp_Name FROM Transaction_Save_Header INNER JOIN Supplier ON Supplier.Supp_Code = Transaction_Save_Header.Supplier_Id WHERE iid = 'SRN' AND Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
                        objSupplierReturn.ReadSavedDocument();
                        if (objSupplierReturn.RecordFound)
                        {
                            lblTempDocNo.Text = objSupplierReturn.TempDocNo;
                            lblGrnNumber.Text = objSupplierReturn.GrnNo.ToString();
                            lblGRNAmount.Text = (string)objSupplierReturn.GrnAmount.ToString();
                            txtSuppCode.Text = objSupplierReturn.SuppCode.ToString();
                            txtSuppName.Text = objSupplierReturn.SuppName.ToString();
                            txtReference.Text = objSupplierReturn.Reference.ToString();
                            txtRemarks.Text = objSupplierReturn.Remark.ToString();

                            objSupplierReturn.GetTempDataset();
                            dataGridTempGRN.DataSource = objSupplierReturn.TempGrn.Tables["GoodReceivedNote"];
                            dataGridTempGRN.Refresh();

                            objSupplierReturn.GetTotalValues();

                            lblTotalQty.Text = string.Format("{0:0.00}", objSupplierReturn.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                            txtSubDiscount.Text = "0";
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objSupplierReturn.TotalAmount);
                            txtSuppCode.ReadOnly = true;
                            txtSuppName.Enabled = false;
                            dtpDate.Enabled = false;
                           // txtReference.Enabled = false;
                           // txtRemarks.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            btnGrnSearch.Enabled = false;
                            //btnSupplierSearch.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objSupplierReturn.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'SRNAPP' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objSupplierReturn.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nSave this " + this.Text + " via authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (MessageBox.Show("Do You want to Apply This Document. ", "Supplier Return Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;

                    objSupplierReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'SRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objSupplierReturn.ReadTempTransDetails();
                    if (objSupplierReturn.RecordFound != true)
                    {
                        MessageBox.Show("Supplier Return Note Details Not Found.", "Supplier Return Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objSupplierReturn.GrnNo = lblGrnNumber.Text.Trim();
                    objSupplierReturn.GrossAmount = decimal.Parse(lblGRNAmount.Text.Trim());
                    objSupplierReturn.Reference = txtReference.Text.Trim();
                    objSupplierReturn.Remark = txtRemarks.Text.Trim();
                    objSupplierReturn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objSupplierReturn.Disc = txtSubDiscPer.Text.Trim();
                    objSupplierReturn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objSupplierReturn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objSupplierReturn.TotalAmount  = decimal.Parse(lblNetAmount.Text.ToString());
                    objSupplierReturn.SupplierReturnNoteApply();
                    MessageBox.Show("Supplier Return Note Successfully Applied as Document No. " + objSupplierReturn.OrgDocNo, "Supplier Return Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //objSupplierReturn.GetDataSetForReport();
                    dsDataForReport = objSupplierReturn.GetReportDataset;
                    rptSupplierReturnNote rptSrn = new rptSupplierReturnNote();
                    rptSrn.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = rptSrn;
                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();

                    GC.Collect();
                    this.Close();
                    this.Dispose();
                    SupplierReturn = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 033. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempGRN_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 034. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSupplierReturn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && (txtSuppCode.Focused || txtSuppName.Focused))
                {
                    btnSupplierSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtProductCode.Focused || txtProductName.Focused))
                {
                    btnItemSearch.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 035.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter )
                {
                    if (Settings.Default.PRNSellingEdit)
                    {
                        txtSellingPrice.Focus(); txtSellingPrice.SelectAll();
                    }
                   
                } 
                else if (e.KeyCode == Keys.Enter)
                {
                    txtQty.Focus(); txtQty.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtQty.Focus(); txtQty.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (objSupplierReturn.Unit == "Nos")
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
            if (objSupplierReturn.Unit == "Nos")
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objSupplierReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'SRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objSupplierReturn.ReadTempTransDetails();
                if (objSupplierReturn.RecordFound != true)
                {
                    MessageBox.Show("" + this.Text + " Details Not Found.", "" + this.Text + " Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*
                objSupplierReturn.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'SRNAPP' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objSupplierReturn.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nDelete this " + this.Text + " Invoice through authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }*/
                if (MessageBox.Show("Are You sure you want to delete this document?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objSupplierReturn.SqlStatement = "EXEC sp_DeleteSavedDoc @DocNo = '" + lblTempDocNo.Text + "',  @Loca = '" + LoginManager.LocaCode + "', @Iid = 'SRN'";
                    objSupplierReturn.ReadTempTransDetails();
                    MessageBox.Show("Delete successfull!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                objSupplierReturn.Errormsg(ex, "frmSRN- btnDelete_Click");
            }
        }

        private void txtPurchasePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnItemSearch.PerformClick();
                txtProductName.Focus();
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

        private void cmbBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    if (Settings.Default.PRNCostEdit)
                    {
                        txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                    }
                    else
                    {
                        txtQty.Focus(); txtQty.SelectAll();
                    }
                }
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBatchNo.Text!="")
                {
                    DataTable dtBatch= Common.Get_BatchDetails(txtProductCode.Text.Trim(), cmbBatchNo.Text.Trim());
                    if (dtBatch!=null && dtBatch.Rows.Count>0)
	                {
                        lblBatchExpDate.Text = dtBatch.Rows[0]["Exp_Date"].ToString();
                        lblBatchShipment.Text = dtBatch.Rows[0]["Shipment"].ToString();
                        txtPurchasePrice.Text = dtBatch.Rows[0]["Purchase_Price"].ToString();
                        txtSellingPrice.Text = dtBatch.Rows[0]["Ret_Price"].ToString();
                        lblCurrentQty.Text = dtBatch.Rows[0]["Stock"].ToString();

                        objSupplierReturn.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objSupplierReturn.ProductCode + "' AND Doc_No = '" + objSupplierReturn.TempDocNo + "' AND BatchNo='"+cmbBatchNo.Text.Trim()+"' AND IId = 'SRN' AND Loca = ";
                        objSupplierReturn.ReadExsistProductDetails();
                        txtQty.Text = (string)objSupplierReturn.Qty.ToString();
                    }
                    else
                    {
                        lblBatchExpDate.Text = lblBatchShipment.Text = string.Empty;
                    }

                }
                else
                {
                    lblBatchExpDate.Text = lblBatchShipment.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        
    }
}