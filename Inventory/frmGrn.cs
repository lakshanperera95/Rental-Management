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
    public partial class frmGrn : Form
    {
        private decimal decDiscountAmount;
        private decimal decAmount;
        private decimal decAdjustment;
        bool prodSearching = false;

        private string strDisc;

        private bool SelectObjectName = true;

        private int intPosOfPerc;   // find Percentage mark on percentage
        private decimal fltDiscPer;

        private frmProductShortCodeDialog prodShortCode = new frmProductShortCodeDialog();

       
        clsGrn objGrn = new clsGrn();
        clsCommon Common = new clsCommon();
        clsProduct objProduct = new clsProduct();
        public frmGrn()
        {
            InitializeComponent();
            this.lblTempDocNo.Enter += new EventHandler(this.txtSuppCode_Leave);
            clsValidation.TextChanged(txtInvAmount, System.Globalization.NumberStyles.Currency);
            txtInvAmount.TextChanged += new EventHandler(lblNetAmount_TextChanged);
            clsValidation.TextChanged(txtPurchasePrice, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtSellingPrice, System.Globalization.NumberStyles.Currency);
            /// clsValidation.TextChanged(txtDiscount, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtSubDiscount, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtFreeQty, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtSelling, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtMarked, System.Globalization.NumberStyles.Currency);
            clsValidation.TextChanged(txtWhole, System.Globalization.NumberStyles.Currency);
        }

        private static frmGrn Grn;

        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();
 

        public static frmGrn GetGrn
        {
            get { return Grn; }
            set { Grn = value; }
        }

        public bool SerialAllow { get; set; }
        private void frmGrn_Load(object sender, EventArgs e)
        {
            try
            {
                objGrn.SqlStatement = "SELECT Temp_Grn FROM DocumentNoDetails WHERE Loca = ";
                objGrn.GetTempDocumentNo("GRN");
                lblTempDocNo.Text = objGrn.TempDocNo;
                //dataGridTempGRN.DataSource = objGrn.TempGrn;
                //dataGridTempGRN.Refresh();
                txtPurchasePrice.Enabled = Settings.Default.GRNCostEdit;
                txtSellingPrice.Enabled = Settings.Default.GRNSellingEdit;

                rdbReduce.Visible = Settings.Default.GrnAllowReduce;
                lblReduce.Visible = Settings.Default.GrnAllowReduce;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                Grn = null;
                this.Close();
                this.Dispose();

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objGrn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objGrn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            objGrn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                        }
                        else
                        {
                            objGrn.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Name";
                        }
                    }
                }
                objGrn.DataetName = "dsSupplier";
                objGrn.GetSupplierDetails();
                search.dgSearch.DataSource = objGrn.GetSupplierDataset.Tables["dsSupplier"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objGrn.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objGrn.SqlStatement = "SELECT Supp_Code, Supp_Name,VAT,VatNo FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objGrn.ReadSupplierDetails();
                    if (objGrn.RecordFound == true)
                    {
                        txtSuppCode.Text = objGrn.SuppCode;
                        txtSuppName.Text = objGrn.SuppName;
                        txtVatRegNo.Text = objGrn.VatRegNo;
                        chkvat.Checked = objGrn.VAT;
                        txtSuppName.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSuppCode.Text = txtSuppName.Text = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    txtInvAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtInvAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtInvAmount.Text.Trim() != string.Empty && clsValidation.isNumeric(txtInvAmount.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtInvAmount.Text) > 0)
                {
                    //cmbPayment.Focus();
                    txtSupplierInv.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtInvAmount.Text.Trim() == string.Empty)
                    {
                        txtInvAmount.Text = "0";
                        //cmbPayment.Focus();
                        txtSupplierInv.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && cmbPayment.Text.Trim() != string.Empty)
                {
                    txtCreditPeriod.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCreditPeriod.Text.Trim() != string.Empty && clsValidation.isNumeric(txtCreditPeriod.Text, System.Globalization.NumberStyles.Number) == true && int.Parse(txtCreditPeriod.Text) > 0)
                {
                    //txtSupplierInv.Focus();
                    txtReference.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtCreditPeriod.Text.Trim() == string.Empty)
                    {
                        txtCreditPeriod.Text = "0";
                        //txtSupplierInv.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupplierInv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSupplierInv.Text.Trim() != string.Empty)
                {
                    //txtReference.Focus();
                    txtCreditPeriod.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtSupplierInv.Text.Trim() == string.Empty)
                    {
                        txtSupplierInv.Text = ".";
                        txtCreditPeriod.Focus();
                        //txtReference.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter)
                {
                    dtpInvDate.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objGrn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND (P.Prod_Code Like '%" + txtProductCode.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductCode.Text.Trim() + "%') " + withSupplier + " AND  LockedItem='F' ORDER BY P.Prod_name ASC";
                }
                else if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                {
                    objGrn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND (P.Prod_Name Like '%" + txtProductName.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductName.Text.Trim() + "%')" + withSupplier + "  AND  LockedItem='F'  ORDER BY P.Prod_name ASC";
                }
                else
                {
                    objGrn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "'" + withSupplier + "  AND  LockedItem='F'  ORDER BY P.Prod_name ASC";
                }

                objGrn.DataetName = "dsProduct";
                objGrn.GetItemDetails();

                ProductSearch.dgSearch.DataSource = objGrn.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                SelectObjectName = true;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    this.CheckProductValidate();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtQty.Text) >= 0)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtFreeQty.Text, System.Globalization.NumberStyles.Number) == true && clsValidation.isNumeric(txtQty.Text, System.Globalization.NumberStyles.Number) == true && (decimal.Parse(txtFreeQty.Text) + decimal.Parse(txtQty.Text)) > 0)
                if (e.KeyCode == Keys.Enter)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (strDiscText.IndexOf("%") > 0 && strDiscText.IndexOf("%") < 6)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    //added by kalani
                  
                    if (txtDiscount.Text.IndexOf("-") != -1)
                    {
                        txtDiscount.Text = string.Format("{0:0.00}", (decimal.Parse(txtPurchasePrice.Text) * decimal.Parse(txtQty.Text)) * decimal.Parse(txtDiscount.Text.Replace("-", "")) / 100);
                    }
                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    this.CheckSupplierDetails();
                    if (objGrn.RecordFound != true)
                    {
                        return;
                    }
                    if (chkAccOtherSuppProd.Checked != true)
                    {
                        objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price],VatProd FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F' and Stock_Master.Loca = ";
                    }
                    else
                    {
                        objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price],VatProd FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F' and Stock_Master.Loca = ";
                    }
                    objGrn.ReadProductDetails();
                    if (objGrn.RecordFound == true)
                    {

                        txtProductName.Text = objGrn.ProductName;
                        objGrn.PurchasePrice = decimal.Parse(txtPurchasePrice.Text);
                        objGrn.SellingPrice = decimal.Parse(txtSellingPrice.Text);
                        //   txtWhole.Text = objGrn.WholePrice.ToString("N2");
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

                    objGrn.ProductCode = txtProductCode.Text.Trim().ToUpper();
                    objGrn.ProductName = txtProductName.Text.Trim().ToUpper();
                    lblCurrentQty.Text = objGrn.CurrentQty.ToString();
                    if (txtInvAmount.Text.Trim() == string.Empty || clsValidation.isNumeric(txtInvAmount.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        txtInvAmount.Text = "0";
                    }
                    if (decimal.Parse(txtQty.Text) == 0 && decimal.Parse(txtFreeQty.Text) == 0)
                        return;
                    if (chkvat.Checked == false)
                    { chkVatPro.Checked = false; }

                    objGrn.SqlStatement = "select Prod_Code from Product where Prod_Code ='"+objGrn.ProductCode+"' AND SerialAllow =1 AND LockedItem='F'";
                    objGrn.ReadTempTransDetails();
                    if (objGrn.RecordFound == true && Settings.Default.SerialNo==true)
                    {
                        FrmSerialNo GetForm = new FrmSerialNo();

                        GetForm.Width = 291;
                        GetForm.Height = 424;
                        int x = this.Location.X + this.Width - GetForm.Width;
                        int y = this.Location.Y + this.Height - GetForm.Height;

                        // Set the location of the form 
                        GetForm.Location = new System.Drawing.Point(x, y);

                        // form data insert 
                        objGrn.Qty = decimal.Parse(txtQty.Text.ToString());
                        GetForm.tempDocNo =objGrn.TempDocNo;
                        GetForm.Qty = objGrn.Qty;
                        GetForm.prodCode = objGrn.ProductCode;
                        GetForm.ShowDialog();

                        if(GetForm.Flag==false)
                        {
                            return;
                        }

                    }

                    objGrn.Qty = decimal.Parse(txtQty.Text.ToString());
                    objGrn.FreeQty = decimal.Parse(txtFreeQty.Text.ToString());
                    objGrn.Disc = strDisc;
                    objGrn.Discount = decimal.Parse(txtDiscount.Text.ToString());
                    //objGrn.Amount = (decimal.Parse(txtQty.Text.ToString()) * objGrn.SellingPrice) - decimal.Parse(txtDiscount.Text.ToString());
                    objGrn.MarkedPrice = decimal.Parse(txtMarked.Text);
                    objGrn.WholePrice = decimal.Parse(txtWhole.Text);
                    objGrn.Amount = decimal.Parse(lblAmount.Text.ToString());
                    objGrn.VatProd = chkVatPro.Checked;

                    if (Common.ProductExpireHave(txtProductCode.Text))
                    {
                        objGrn._expDate = dtpExpireDate.Value.ToShortDateString();
                    }
                    else
                    {
                        objGrn._expDate = string.Empty;
                    }

                    if (Settings.Default.GrnAllowReduce && rdbReduce.Checked)
                    {
                        objGrn.Qty = objGrn.Qty * -1;
                        objGrn.FreeQty = objGrn.FreeQty * -1;
                        objGrn.Disc = strDisc;
                        objGrn.Discount = objGrn.Discount * -1;
                        objGrn.Amount = objGrn.Amount * -1;
                    }

                    objGrn.UpdateGrnTempDataSet(Settings.Default.TrInCon);
                    //objGrn.GetTotalValues("GRN");
                    dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
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
                    txtPurchasePriceNonVAt.Text = string.Empty;
                    txtDiscount.Text = "0";
                    txtQty.Text = "0";
                    txtFreeQty.Text = "0";
                    chkVatPro.Checked = true;
                    lblAmount.Text = string.Empty;
                    objGrn.Disc = string.Empty;
                    // txtReference.Enabled = false;
                    // txtRemarks.Enabled = false;

                    objGrn.GetTotalValues("GRN");

                    lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                    lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                    decAdjustment = decimal.Parse(txtInvAmount.Text.Trim().ToString());
                    decAdjustment = decAdjustment - objGrn.TotalAmount;
                    lblInvoiceAdjust.Text = string.Format("{0:0.00}", decAdjustment);
                    txtSubDiscount.Text = "0";
                    txtSubDiscPer.Text = string.Empty;
                    txtTaxAmount.Text = "0";
                    lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                    txtSuppCode.ReadOnly = true;
                    txtSuppName.Enabled = false;
                    //txtInvAmount.Enabled = false;
                    cmbPayment.Enabled = false;
                    dtpInvDate.Enabled = false;
                    txtCreditPeriod.Enabled = false;
                    //txtReference.Enabled = false;
                    //txtRemarks.Enabled = false;
                    //txtSupplierInv.Enabled = false;
                    txtSubDiscPer.Enabled = true;
                    txtSubDiscount.Enabled = true;
                    txtTaxAmount.Enabled = true;

                    chkvat.Enabled = false;
                    chkVatExtract.Enabled = false;
                    VatCalculationForItem();

                    if (chkvat.Checked == false)
                    {
                        chkVatPro.Enabled = false;
                        chkVatPro.Checked = false;
                        chkVatforProd.Enabled = false;
                        chkVatforProd.Checked = false;
                    }


                    if (SelectObjectName == true)
                    {
                        txtProductCode.Focus();
                    }
                    else
                    {
                        lisProdCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { GC.Collect(); }
        }

        clsCommon objComman = new clsCommon();
        public void VatCalculationForItem()
        {
            try
            {


                if (lblNetAmount.Text.Trim() == string.Empty || Convert.ToDecimal(lblNetAmount.Text.Trim()) == 0)
                {
                    txtTaxAmount.Text = "0.00";
                    return;
                }
                if (chkvat.Checked == true)
                {
                    if (chkVatforProd.Checked == true)
                    {
                        objComman.SqlStatement = "EXEC [dbo].[Sp_VatCalculation] @DocNo = '" + lblTempDocNo.Text.Trim() + "',@Loca = '" + LoginManager.LocaCode + "',@IId = 'GRN'";
                        objComman.GetDs();
                        dataGridTempGRN.DataSource = objComman.Ads.Tables[0];
                        dataGridTempGRN.Refresh();
                        if (dataGridTempGRN.RowCount > 12)
                        {
                            dataGridTempGRN.FirstDisplayedCell = dataGridTempGRN[0, dataGridTempGRN.RowCount - 6];
                        }


                        txtTaxAmount.Text = ((decimal)(objComman.Ads.Tables[1].Rows[0][0])).ToString("N2");
                    }
                    else if (chkVatforProd.Checked == false)
                    {
                        decimal Amount = Convert.ToDecimal(lblNetAmount.Text.Trim());
                        decimal VatPer = Settings.Default.VatPrecentage;

                        decimal VatAmount = (Amount / (100 + VatPer)) * VatPer;
                        txtTaxAmount.Text = VatAmount.ToString("N2");
                    }
                }
                else
                {
                    txtTaxAmount.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                    objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(TTD.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(TTD.Whole_Price AS DECIMAL(18,2)) [Whole_Price],product.VatProd FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code INNER JOIN TransactionTemp_Details TTD ON Stock_Master.Prod_Code = TTD.Prod_Code AND Stock_Master.Loca = TTD.Loca WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "'  AND TTD.Doc_No = '" + lblTempDocNo.Text.Trim().ToUpper() + "' AND Stock_Master.Loca = ";
                    objGrn.ReadProductDetails();
                    txtPurchasePrice.Text = dataGridTempGRN.SelectedRows[0].Cells[3].Value.ToString();
                    txtSellingPrice.Text = dataGridTempGRN.SelectedRows[0].Cells[4].Value.ToString();
                    txtWhole.Text = objGrn.WholePrice.ToString("N2");

                    if (Common.ProductExpireHave(txtProductCode.Text))
                    {
                        dtpExpireDate.Enabled = true;
                        dtpExpireDate.Text = dataGridTempGRN.SelectedRows[0].Cells[5].Value.ToString();
                    }
                    else
                    {
                        dtpExpireDate.Enabled = false;
                    }

                    decimal QQ = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[6].Value.ToString()); QQ = Math.Abs(QQ);
                    txtQty.Text = QQ.ToString("N2");

                    decimal FQ = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[7].Value.ToString()); FQ = Math.Abs(FQ);
                    txtFreeQty.Text = FQ.ToString("N2");

                    //txtQty.Text = dataGridTempGRN.SelectedRows[0].Cells[5].Value.ToString();
                    //txtFreeQty.Text = dataGridTempGRN.SelectedRows[0].Cells[6].Value.ToString();

                    if (objGrn.Unit == "Nos")
                    {
                        txtQty.Text = string.Format("{0:0}", decimal.Parse(txtQty.Text.Trim()));
                        txtFreeQty.Text = string.Format("{0:0}", decimal.Parse(txtFreeQty.Text.Trim()));
                    }

                    decimal DD = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[8].Value.ToString()); DD = Math.Abs(DD);
                    txtDiscount.Text = DD.ToString("N2");

                    decimal AA = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[9].Value.ToString()); AA = Math.Abs(AA);
                    lblAmount.Text = AA.ToString();

                    decimal VAT = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[12].Value.ToString()); VAT = Math.Abs(VAT);

                    if (VAT > 0)
                    {
                        chkVatPro.Checked = true;
                    }
                    else
                    { chkVatPro.Checked = false; }
                    //txtDiscount.Text = dataGridTempGRN.SelectedRows[0].Cells[7].Value.ToString();
                    //lblAmount.Text = dataGridTempGRN.SelectedRows[0].Cells[8].Value.ToString();

                    txtQty.Focus();
                    txtQty.SelectAll();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                        objGrn.TempDocNo = lblTempDocNo.Text.Trim();
                        objGrn.ProductCode = dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString();
                        objGrn.Qty = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[6].Value.ToString());
                        objGrn._lnNo = int.Parse(dataGridTempGRN.SelectedRows[0].Cells[11].Value.ToString());
                        objGrn.DeleteProductDetaile(Settings.Default.TrInCon);
                        dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                        dataGridTempGRN.Refresh();
                        objGrn.GetTotalValues("GRN");
                        lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                        lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                        decAdjustment = decimal.Parse(txtInvAmount.Text.Trim().ToString());
                        decAdjustment = decAdjustment - objGrn.TotalAmount;
                        lblInvoiceAdjust.Text = string.Format("{0:0.00}", decAdjustment);
                        txtSubDiscount.Text = "0";
                        txtSubDiscPer.Text = string.Empty;
                        txtTaxAmount.Text = "0";
                        lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                        lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objGrn.CheckedPasswordValid("SELECT Emp_Name,Pass_Word,GRNAPP,POAPP,SRNAPP,TOGAPP,OPBAPP,PRDAPP,BATCAPP FROM dbo.tb_UserRoleSettings Us JOIN dbo.Employee E ON E.UserRole_Id=Us.UserRoleID WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='" + LoginManager.LocaCode + "' AND Us.GRNAPP=1");
                if (objGrn.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nSave this " + this.Text + " via authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                objGrn.SqlStatement = "SELECT TOP 1 * FROM Transaction_Header TH WHERE TH.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND TH.Inv_No = '" + txtSupplierInv.Text.Trim() + "'";
                objGrn.RecordFound = false;
                objGrn.ReadTempTransDetails();
                if (objGrn.RecordFound == true)
                {
                    if (MessageBox.Show("Already exsist this invoice no for supplier\r\nDo you want to continue", "GRN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        txtSupplierInv.Focus();
                        txtSupplierInv.SelectAll();
                        return;
                    }
                }

                if (chkvat.Checked == true && Convert.ToDecimal(txtTaxAmount.Text.Trim()) == 0)
                {
                    MessageBox.Show("TAX Amount not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //objGrn.SqlStatement = "SELECT ShipmentCode AS Code FROM tb_Shipment WHERE ShipmentCode='" + txtShipmentCode.Text + "' AND Loca='" + LoginManager.LocaCode + "' ";
                //objGrn.ReadTempTransDetails();
                //if (objGrn.RecordFound != true)
                //{
                //    MessageBox.Show("Shipment Details Not Found !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtShipmentCode.Focus();
                //    return;
                //}

                if (MessageBox.Show("Do you want to Apply This Document. ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;
                    objGrn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'GRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objGrn.ReadTempTransDetails();
                    if (objGrn.RecordFound != true)
                    {
                        MessageBox.Show("Goods Received Note Details Not Found.", "Goods Received Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objGrn.InvAmount = decimal.Parse(txtInvAmount.Text.Trim());
                    objGrn.Pay_Type = cmbPayment.Text;
                    objGrn.PoNo = lblPoNumber.Text.Trim();
                    objGrn.InvNo = txtSupplierInv.Text.Trim();
                    objGrn.Reference = txtReference.Text.Trim();
                    objGrn.Remark = txtRemarks.Text.Trim();
                    objGrn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objGrn.Disc = txtSubDiscPer.Text.Trim();
                    objGrn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objGrn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());

                    objGrn._strShipment = txtShipmentCode.Text.Trim();
                    objGrn.PostDate = dpDate.Text.Trim();
                    objGrn.InvDate = dtpInvDate.Text.Trim();

                    objGrn.VAT = chkvat.Checked;
                    objGrn.VatProd = chkVatforProd.Checked;
                    objGrn.VatAmount = Convert.ToDecimal(txtTaxAmount.Text.Trim());


                    objGrn.TotalAmount = decimal.Parse(lblNetAmount.Text.ToString());
                    objGrn.GoodReceivedNoteApply();
                    MessageBox.Show("Goods Received Note Successfully Applied as Document No. " + objGrn.OrgDocNo, "Goods Received Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    dsDataForReport = objGrn.GetReportDataset;


                    if (MessageBox.Show("Do you want to display Selling Price?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (File.Exists(@"..\DirectReports\rptGoodReceivedNote.rpt"))
                        {
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNote.rpt");
                        }
                        else
                        {
                            objRepViewer.DirectPrintVerRep = new rptGoodReceivedNote();
                        }
                    }
                    else
                    {
                        if (File.Exists(@"..\DirectReports\rptGoodReceivedNoteWithSelprice.rpt"))
                        {
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNoteWithSelprice.rpt");
                        }
                        else
                        {
                            objRepViewer.DirectPrintVerRep = new rptGoodReceivedNoteWithSelprice();
                        }


                    }

                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    objRepViewer.Show();

                    Grn = null;
                    this.Close();
                    this.Dispose();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        //calculating subtotal discount
        private void CalculateSubTotalDiscount(string strDiscText)
        {
            try
            {
                if (strDiscText.IndexOf("%") > 0 && strDiscText.IndexOf("%") < 6)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                objGrn.SqlStatement = "SELECT Doc_No [Document No], Post_Date + '  ' + Supplier.Supp_Name [Supplier] FROM Transaction_Save_Header INNER JOIN supplier on Transaction_Save_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                objGrn.DataetName = "Table";
                objGrn.GetItemDetails();

                search.dgSearch.DataSource = objGrn.GetItemDataset.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 029. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    objGrn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'GRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objGrn.ReadTempTransDetails();
                    if (objGrn.RecordFound != true)
                    {
                        MessageBox.Show("Goods Received Note Details Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //objGrn.SqlStatement = "SELECT ShipmentCode AS Code FROM tb_Shipment WHERE ShipmentCode='"+txtShipmentCode.Text+"' AND Loca='"+LoginManager.LocaCode+"' ";
                    //objGrn.ReadTempTransDetails();
                    //if (objGrn.RecordFound != true)
                    //{
                    //    MessageBox.Show("Shipment Details Not Found !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtShipmentCode.Focus();
                    //    return;
                    //}

                    objGrn.Reference = txtReference.Text.Trim();
                    objGrn.InvAmount = decimal.Parse(txtInvAmount.Text.Trim());
                    objGrn.Pay_Type = cmbPayment.Text;
                    objGrn.PoNo = lblPoNumber.Text.Trim();
                    objGrn.InvNo = txtSupplierInv.Text.Trim();
                    objGrn.Reference = txtReference.Text.Trim();
                    objGrn.Remark = txtRemarks.Text.Trim();
                    objGrn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objGrn.Disc = txtSubDiscPer.Text.Trim();
                    objGrn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                    objGrn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objGrn._strShipment = txtShipmentCode.Text.Trim();
                    objGrn.VAT = chkvat.Checked;
                    objGrn.VatProd = chkVatforProd.Checked;

                    objGrn.GoodReceivedNoteSave();
                    MessageBox.Show("Goods Received Note Successfully Saved as Document No. " + objGrn.OrgDocNo, "Goods Received Note Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Grn = null;
                    this.Close();
                    this.Dispose();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void lblTempDocNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if (MessageBox.Show("Are You Sure You want to Load Saved GRN Document No :" + search.Code.Trim() + ". ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objGrn.RecallSaveDocNo = search.Code.Trim();
                        objGrn.SqlStatement = "SELECT Transaction_Save_Header.*, Supplier.Supp_Name FROM Transaction_Save_Header INNER JOIN Supplier ON Supplier.Supp_Code = Transaction_Save_Header.Supplier_Id WHERE iid = 'GRN' AND Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
                        objGrn.ReadSavedDocument();
                        if (objGrn.RecordFound)
                        {
                            lblTempDocNo.Text = objGrn.TempDocNo;
                            lblPoNumber.Text = objGrn.PoNo.ToString();
                            txtSuppCode.Text = objGrn.SuppCode.ToString();
                            txtSuppName.Text = objGrn.SuppName.ToString();
                            txtInvAmount.Text = (string)objGrn.InvAmount.ToString();
                            cmbPayment.Text = objGrn.Pay_Type;
                            txtSupplierInv.Text = objGrn.InvNo.ToString();
                            txtReference.Text = objGrn.Reference.ToString();
                            txtRemarks.Text = objGrn.Remark.ToString();

                            chkvat.Checked = objGrn.VAT;
                            chkVatforProd.Checked = objGrn.VatProd;


                            txtShipmentCode.Text = objGrn._strShipment.ToString();
                            Shipment_Load();

                            //objGrn.GetTempDataset();
                            dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                            dataGridTempGRN.Refresh();

                            objGrn.GetTotalValues("GRN");

                            lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                            txtSubDiscount.Text = objGrn.Discount.ToString("N2");
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount - objGrn.Discount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount - objGrn.Discount);
                            txtSuppCode.ReadOnly = true;
                            txtSuppName.Enabled = false;
                            //txtInvAmount.Enabled = false;
                            cmbPayment.Enabled = false;
                            dtpInvDate.Enabled = false;
                            txtCreditPeriod.Enabled = true;
                            // txtReference.Enabled = true;
                            //txtRemarks.Enabled = true;
                            //txtSupplierInv.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            btnPoSearch.Enabled = false;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 031. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmGrn_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Grn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmGrn_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 033. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnPoSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                objGrn.SqlStatement = "SELECT Doc_No [Document No], Post_Date + '  ' + Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Recalled = 'F' AND Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                objGrn.DataetName = "Table";
                objGrn.GetItemDetails();

                search.dgSearch.DataSource = objGrn.GetItemDataset.Tables["Table"];
                search.Show();

                search.prop_Focus = lblPoNumber;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 034. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 035. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void lblPoNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if (MessageBox.Show("Are You Sure You want to Load Purchase Order Document No :" + search.Code.Trim() + ". ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objGrn.RecallSaveDocNo = search.Code.Trim();
                        objGrn.SqlStatement = "SELECT Transaction_Header.*, Supplier.Supp_Name FROM Transaction_Header INNER JOIN Supplier ON Supplier.Supp_Code = Transaction_Header.Supplier_Id WHERE Iid = 'PON' AND Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
                        objGrn.ReadPurchaseOrderDocument();
                        if (objGrn.RecordFound)
                        {
                            //lblTempDocNo.Text = objGrn.TempDocNo;
                            lblPoNumber.Text = objGrn.PoNo.ToString();
                            txtSuppCode.Text = objGrn.SuppCode.ToString();
                            txtSuppName.Text = objGrn.SuppName.ToString();
                            txtInvAmount.Text = (string)objGrn.InvAmount.ToString();
                            cmbPayment.Text = objGrn.Pay_Type;
                            txtSupplierInv.Text = objGrn.InvNo.ToString();
                            txtReference.Text = objGrn.Reference.ToString();
                            txtRemarks.Text = objGrn.Remark.ToString();

                            //objGrn.GetTempDataset();
                            dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                            dataGridTempGRN.Refresh();

                            objGrn.GetTotalValues("GRN");

                            lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                            txtSubDiscount.Text = "0";
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                            txtSuppCode.Enabled = false;
                            txtSuppName.Enabled = false;
                            txtInvAmount.Enabled = true;
                            cmbPayment.Enabled = false;
                            dtpInvDate.Enabled = false;
                            //txtCreditPeriod.Enabled = false;
                            txtReference.Enabled = true;
                            txtRemarks.Enabled = true;
                            //txtSupplierInv.Enabled = false;
                            btnSaveDocSearch.Enabled = false;
                            txtInvAmount.Focus(); txtInvAmount.SelectAll();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 036. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objGrn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'GRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objGrn.ReadTempTransDetails();
                if (objGrn.RecordFound != true)
                {
                    MessageBox.Show("Goods Received Note Details Not Found.", "Goods Received Note Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objGrn.Reference = txtReference.Text.Trim();
                objGrn.InvAmount = decimal.Parse(txtInvAmount.Text.Trim());
                objGrn.Pay_Type = cmbPayment.Text;
                objGrn.PoNo = lblPoNumber.Text.Trim();
                objGrn.InvNo = txtSupplierInv.Text.Trim();
                objGrn.Reference = txtReference.Text.Trim();
                objGrn.Remark = txtRemarks.Text.Trim();
                objGrn.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                objGrn.Disc = txtSubDiscPer.Text.Trim();
                objGrn.Discount = decimal.Parse(txtSubDiscount.Text.ToString());
                objGrn.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                objGrn.Amount = decimal.Parse(lblNetAmount.Text.ToString());
                objGrn._strShipment = txtShipmentCode.Text.Trim();

                objGrn.GetDataSetForPreview();
                dsDataForReport = objGrn.GetReportDataset;





                if (MessageBox.Show("Do you want to display Selling Price?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (File.Exists(@"..\DirectReports\rptGoodReceivedNote.rpt"))
                    {
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNote.rpt");
                    }
                    else
                    {
                        objRepViewer.DirectPrintVerRep = new rptGoodReceivedNote();
                    }
                }
                else
                {
                    if (File.Exists(@"..\DirectReports\rptGoodReceivedNoteWithSelprice.rpt"))
                    {
                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNoteWithSelprice.rpt");
                    }
                    else
                    {
                        objRepViewer.DirectPrintVerRep = new rptGoodReceivedNoteWithSelprice();
                    }


                }


                objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 037. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 038. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSubDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmGrn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F6)
                {
                    rdbReduce.Checked = !rdbReduce.Checked;
                }
                /*if (e.KeyCode == Keys.F1 && (txtProductCode.Focused == true || txtProductName.Focused == true))
                {
                    this.btnItemSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtSuppCode.Focused == true || txtSuppName.Focused == true))
                {
                    this.btnSupplierSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F12)
                {
                    lisProdCode.Focus();
                }
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }
                    else if (e.KeyCode == Keys.P)
                    {
                        this.btnPreview.PerformClick();
                    }
                    else if (e.KeyCode == Keys.A)
                    {
                        this.btnApply.PerformClick();
                    }
                    else if (e.KeyCode == Keys.E)
                    {
                        this.btnClose.PerformClick();
                    }
                }*/
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 039.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string tempCode;
                //string tempCode = string.Format("{0:0}", dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString());
                //if (txtCode.Text.Trim() != string.Empty)
                //{dataGridTempGRN.SelectionMode==DataGridViewSelectionMode.RowHeaderSelect && 
                //if (dataGridTempGRN.SelectionMode==DataGridViewSelectionMode.FullRowSelect)
                //{
                //    string.Format("{0:0}", dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString());
                //}
                //else if (txtProductCode.Text!= string.Empty)
                //{
                //    txtProductCode.Text.Trim();
                //}
                //else if (dataGridTempGRN.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect || txtProductCode.Text==string.Empty)
                //{
                //    MessageBox.Show("Select Row or Type Product Code", "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtProductCode.Focus();
                //}
                if (frmProduct.GetProduct == null)
                {
                    int s = dataGridTempGRN.CurrentRow.Index;
                    if (txtProductCode.Text != string.Empty)
                    {
                        frmProduct.GetProduct = new frmProduct(txtProductCode.Text.Trim());
                    }
                    else if (dataGridTempGRN.Rows[s].Selected == true)
                    {
                        frmProduct.GetProduct = new frmProduct(string.Format("{0:0}", dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString()));
                    }

                    else if (dataGridTempGRN.Rows[s].Selected != true || txtProductCode.Text == string.Empty)
                    {
                        MessageBox.Show("Select Row or Type Product Code", "System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //frmProductPriceMaster.GetProductPriceMaster = new frmProductPriceMaster();
                    //frmProduct.GetProduct = new frmProduct(string.Format("{0:0}", dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString()));
                    frmProduct.GetProduct.MdiParent = MainClass.getmdi();
                    frmProduct.GetProduct.Show();
                    frmProduct.GetProduct.PropClose = "GrnOpen";
                    frmProduct.GetProduct.Focus();
                }
                else
                {
                    frmProduct.GetProduct.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 050. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                // MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridTempGRN.SelectedRows.Count != 0)
                {


                    if (dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                    {
                        if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            objGrn.TempDocNo = lblTempDocNo.Text.Trim();
                            objGrn.ProductCode = dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString();
                            objGrn.Qty = decimal.Parse(dataGridTempGRN.SelectedRows[0].Cells[5].Value.ToString());
                            objGrn.DeleteProductDetaile(Settings.Default.TrInCon);
                            objGrn.GetTotalValues("GRN");
                            dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                            dataGridTempGRN.Refresh();

                            objGrn.GetTotalValues("GRN");

                            lblTotalQty.Text = objGrn.TotalQty.ToString();
                            lblTotalAmount.Text = objGrn.TotalAmount.ToString();

                            objGrn.GetTotalValues("GRN");

                            lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                            decAdjustment = decimal.Parse(txtInvAmount.Text.Trim().ToString());
                            decAdjustment = decAdjustment - objGrn.TotalAmount;
                            lblInvoiceAdjust.Text = string.Format("{0:0.00}", decAdjustment);
                            txtSubDiscount.Text = "0";
                            txtSubDiscPer.Text = string.Empty;
                            txtTaxAmount.Text = "0";
                            lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);

                            txtProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempGRN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridTempGRN.SelectedRows.Count == 0)
                {
                    deleteEntryToolStripMenuItem.Enabled = false;
                    refreshToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void ContextMenuGRN_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            deleteEntryToolStripMenuItem.Enabled = true;
            refreshToolStripMenuItem.Enabled = true;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridTempGRN.SelectedRows.Count != 0)
            {
                if (dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    int SelectedRows = dataGridTempGRN.SelectedRows[0].Index;
                    objGrn.TempDocNo = lblTempDocNo.Text.Trim();
                    objGrn.LocaCode = LoginManager.LocaCode;
                    objGrn.ProductCode = dataGridTempGRN.SelectedRows[0].Cells[0].Value.ToString();
                    objGrn.RefershTempGRNProduct();

                    objGrn.GetTotalValues("GRN");
                    dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                    dataGridTempGRN.Refresh();
                    dataGridTempGRN.CurrentRow.Selected = false;
                    dataGridTempGRN.Rows[SelectedRows].Selected = true;

                    if (dataGridTempGRN.RowCount > 12)
                    {
                        dataGridTempGRN.FirstDisplayedCell = dataGridTempGRN[0, SelectedRows - 5];
                    }

                    objGrn.GetTotalValues("GRN");
                    lblTotalQty.Text = objGrn.TotalQty.ToString();
                    lblTotalAmount.Text = objGrn.TotalAmount.ToString();
                    objGrn.GetTotalValues("GRN");
                }
            }
        }

        private void frmGrn_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (Grn != null)
            {
                if (MessageBox.Show("Are sure you want to Exit Without Save / Apply ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void lisProdCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.SelectedIndex = lisProdCode.SelectedIndex;
            txtProductCode.Text = lisProdCode.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductName.Text = listBox1.Text;
        }

        private void lisProdCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtProductCode.Text.Trim() == lisProdCode.Text.Trim())
            {
                this.CheckProductValidate();
                //txtQty.Focus();
            }
        }

        private void CheckSupplierDetails()
        {
            objGrn.SuppCode = txtSuppCode.Text.ToString().Trim();
            objGrn.SqlStatement = "SELECT Supp_Code, Supp_Name,VAT,VatNo FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
            objGrn.ReadSupplierDetails();
            if (objGrn.RecordFound == true)
            {
                txtSuppCode.Text = objGrn.SuppCode;
                txtSuppName.Text = objGrn.SuppName;
            }
            else
            {
                MessageBox.Show("Supplier Code Not Found.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSuppCode.Focus();
            }
        }

        private void CheckProductValidate()
        {
            this.CheckSupplierDetails();
            if (objGrn.RecordFound != true)
            {
                return;
            }
            txtProductCode.Text = txtProductCode.Text.ToUpper();
            if (chkAccOtherSuppProd.Checked != true)
            {
                objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price],VatProd  FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code LEFT JOIN tbProductLink ON tbProductLink.Prod_Code = Product.Prod_Code AND Stock_Master.Prod_Code = tbProductLink.Prod_Code WHERE product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '') OR tbProductLink.Barcode= '" + txtProductCode.Text.Trim() + "') AND LockedItem='F'  and Stock_Master.Loca = ";
            }
            else
            {
                objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price],VatProd  FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code LEFT JOIN tbProductLink ON tbProductLink.Prod_Code = Product.Prod_Code AND Stock_Master.Prod_Code = tbProductLink.Prod_Code WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '') OR tbProductLink.Barcode= '" + txtProductCode.Text.Trim() + "' ) AND LockedItem='F'  AND Stock_Master.Loca = ";
            }
            objGrn.ReadProductDetails();
            if (objGrn.RecordFound == true)
            {
                txtProductCode.Text = objGrn.ProductCode;
                txtProductName.Text = objGrn.ProductName;
                txtPurchasePrice.Text = (string)objGrn.PurchasePrice.ToString();
                txtSellingPrice.Text = (string)objGrn.SellingPrice.ToString();
                lblCurrentQty.Text = (string)objGrn.CurrentQty.ToString();
                lblOldSellingPrice.Text = (string)objGrn.SellingPrice.ToString();
                txtMarked.Text = lblOldMarkedPrice.Text = (string)objGrn.MarkedPrice.ToString();
                txtWhole.Text = lblOldWholeSale.Text = (string)objGrn.WholePrice.ToString();

                //      chkVatPro.Checked = objGrn.VatProd;

                txtFreeQty.Text = "0";
                txtDiscount.Text = "0";
                objGrn.SqlStatement = "SELECT ABS(qty) Qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objGrn.ProductCode + "' AND Doc_No = '" + objGrn.TempDocNo + "' AND IId = 'GRN' AND Loca = ";
                objGrn.ReadExsistProductDetails();
                if (objGrn.Unit == "Nos")
                {
                    txtQty.Text = (string.Format("{0:0}", objGrn.Qty));
                }
                else
                {
                    txtQty.Text = (string)objGrn.Qty.ToString();
                }

                //if (Settings.Default.GRNCostEdit)
                //{
                //    txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                //}
                //else
                //{
                //    txtQty.Focus(); txtQty.SelectAll();
                //}

                if (Common.ProductExpireHave(txtProductCode.Text))
                {
                    dtpExpireDate.Enabled = true;
                    dtpExpireDate.Focus();
                }
                else
                {
                    dtpExpireDate.Enabled = false;
                    if (chkvat.Checked == true)
                    {
                        if (chkVatforProd.Checked == true)
                        {
                            if (chkVatExtract.Checked == true)
                            {
                                if (Settings.Default.GRNCostEdit)
                                {
                                    decimal VatBefPrice = ((Convert.ToDecimal(txtPurchasePrice.Text.Trim())) / (Settings.Default.VatPrecentage + 100)) * Settings.Default.VatPrecentage; ;

                                    decimal VatAfterPrice = (Convert.ToDecimal(txtPurchasePrice.Text.Trim()) - VatBefPrice);

                                    txtPurchasePriceNonVAt.Text = VatAfterPrice.ToString("N2");
                                    txtPurchasePriceNonVAt.ReadOnly = true;
                                    txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                                }
                                else
                                {
                                    txtQty.Focus(); txtQty.SelectAll();
                                }
                            }
                            else
                            {
                                txtPurchasePriceNonVAt.ReadOnly = false;
                                txtPurchasePriceNonVAt.SelectAll();
                                txtPurchasePriceNonVAt.Focus();
                            }
                        }
                    }

                    else if (Settings.Default.GRNCostEdit)
                    {
                        txtPurchasePriceNonVAt.ReadOnly = false;
                        txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                    }
                    else
                    {
                        txtPurchasePriceNonVAt.ReadOnly = false;

                        txtQty.Focus(); txtQty.SelectAll();
                    }
                }
                if (chkvat.Checked == false)
                { chkVatPro.Checked = false; }


            }
            else
            {
                MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtSuppCode_Leave(object sender, EventArgs e)
        {
            try
            {
                objGrn.SqlStatement = "SELECT P.Prod_Code, Prod_Name, CAST(SM.Qty AS DECIMAL(18,2))[Qty] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE Supplier_Id ='" + txtSuppCode.Text.Trim() + "' AND SM.Loca = '" + LoginManager.LocaCode.ToString() + "' ORDER BY Prod_Name";
                objGrn.DataetName = "SuppProduct";
                objGrn.GetItemDetails();
                listBox2.DataSource = listBox1.DataSource = lisProdCode.DataSource = objGrn.GetItemDataset.Tables["SuppProduct"];
                lisProdCode.DisplayMember = "Prod_Code";
                listBox1.DisplayMember = "Prod_Name";
                listBox2.DisplayMember = "Qty";
                txtProductCode.Text = txtProductName.Text = string.Empty; lblCurrentQty.Text = "0";
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void lisProdCode_Enter(object sender, EventArgs e)
        {
            SelectObjectName = false;
        }

        private void lblNetAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtInvAmount.Text == string.Empty)
                {
                    txtInvAmount.Text = "0.00";
                    txtInvAmount.SelectAll();
                }
                lblInvoiceAdjust.Text = string.Format("{0:0.00}", decimal.Parse(txtInvAmount.Text) - decimal.Parse(lblNetAmount.Text));
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupplierInv_Leave(object sender, EventArgs e)
        {
            try
            {
                objGrn.SqlStatement = "SELECT TOP 1* FROM Transaction_Header TH WHERE TH.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND TH.Inv_No = '" + txtSupplierInv.Text.Trim() + "' AND TH.Iid = 'GRN'";
                objGrn.RecordFound = false;
                objGrn.ReadTempTransDetails();
                if (objGrn.RecordFound == true)
                {
                    MessageBox.Show("This invoice number already exsists under this supplier", "GRN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtInvAmount_Leave(object sender, EventArgs e)
        {
            txtInvAmount.Text = (txtInvAmount.Text == string.Empty) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtInvAmount.Text));
        }

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Settings.Default.GRNSellingEdit)
                    {
                        if (chkVatPro.Checked == true)
                        {
                            decimal SellPrice = (Convert.ToDecimal(txtPurchasePrice.Text.Trim())) + ((Convert.ToDecimal(txtPurchasePrice.Text.Trim()) * Settings.Default.Margin) / 100);
                            txtSellingPrice.Text = SellPrice.ToString("N2");

                            decimal BeforeVat = ((Convert.ToDecimal(txtPurchasePrice.Text.Trim())) * (Settings.Default.VatPrecentage)) / (100 + Settings.Default.VatPrecentage);

                            txtPurchasePriceNonVAt.Text = ((Convert.ToDecimal(txtPurchasePrice.Text.Trim())) - BeforeVat).ToString("N2");
                        }
                        else
                        {
                            decimal WithVat = Convert.ToDecimal(txtPurchasePrice.Text.Trim()) + ((Convert.ToDecimal(txtPurchasePrice.Text.Trim()) * Settings.Default.VatPrecentage) / 100);
                            if (Settings.Default.Margin != 0)
                            {
                                decimal SellPrice = WithVat + ((WithVat * Settings.Default.Margin) / 100);
                                txtSellingPrice.Text = SellPrice.ToString("N2");
                            }
                        }

                        txtSellingPrice.Focus(); txtSellingPrice.SelectAll();
                    }
                    else
                    {
                        txtQty.Focus(); txtQty.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtPurchasePrice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPurchasePrice.Text = (string.IsNullOrEmpty(txtPurchasePrice.Text)) ? "0.0000" : string.Format("{0:0.0000}", decimal.Parse(txtPurchasePrice.Text));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSellingPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSellingPrice.Text = (string.IsNullOrEmpty(txtSellingPrice.Text)) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtSellingPrice.Text));
                if (decimal.Parse(txtSellingPrice.Text) != objGrn.SellingPrice)
                {
                    pnlNewEdit.BringToFront();
                    lblOldSellingPrice.Text = string.Format("{0:0.00}", objGrn.SellingPrice);
                    lblOldMarkedPrice.Text = string.Format("{0:0.00}", objGrn.MarkedPrice);
                    lblOldWholeSale.Text = string.Format("{0:0.00}", objGrn.WholePrice);
                    txtSelling.Text = txtMarked.Text = txtWhole.Text = txtSellingPrice.Text;
                    lblOldMargin.Text = string.Format("{0:0.00}", ((objGrn.SellingPrice - objGrn.PurchasePrice) / objGrn.PurchasePrice) * 100);
                    lblNewMargin.Text = string.Format("{0:0.00}", (((decimal.Parse(txtSellingPrice.Text) - decimal.Parse(txtPurchasePrice.Text)) / decimal.Parse(txtPurchasePrice.Text)) * 100));
                    txtMarked.Focus(); txtMarked.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (objGrn.Unit == "Nos")
                {
                    txtQty.Text = (string.IsNullOrEmpty(txtQty.Text)) ? "0" : string.Format("{0:0}", double.Parse(txtQty.Text));
                }
                else
                {
                    txtQty.Text = (string.IsNullOrEmpty(txtQty.Text)) ? "0.000" : string.Format("{0:0.000}", double.Parse(txtQty.Text));
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtFreeQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (objGrn.Unit == "Nos")
                {
                    txtFreeQty.Text = (string.IsNullOrEmpty(txtFreeQty.Text)) ? "0" : string.Format("{0:0}", decimal.Parse(txtFreeQty.Text));
                }
                else
                {
                    txtFreeQty.Text = (string.IsNullOrEmpty(txtFreeQty.Text)) ? "0.000" : string.Format("{0:0.000}", decimal.Parse(txtFreeQty.Text));
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus(); txtQty.SelectAll();
            }
        }

        private void txtSelling_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSelling.Text = (string.IsNullOrEmpty(txtSelling.Text)) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtSelling.Text));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtMarked_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMarked.Text = (string.IsNullOrEmpty(txtMarked.Text)) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtMarked.Text));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtWhole_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMarked.Text = (string.IsNullOrEmpty(txtMarked.Text)) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtMarked.Text));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSelling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMarked.Focus(); txtMarked.SelectAll();
            }
        }

        private void txtMarked_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWhole.Focus(); txtWhole.SelectAll();
            }
        }

        private void txtWhole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus(); txtQty.SelectAll();
            }
        }

        private void pnlNewEdit_Leave(object sender, EventArgs e)
        {
            pnlNewEdit.SendToBack();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCurrentQty.Text = listBox2.Text;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (objGrn.Unit == "Nos")
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
                // clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
                // clsValidation.TextChanged(txtFreeQty, System.Globalization.NumberStyles.Currency);
            }
        }

        private void txtFreeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (objGrn.Unit == "Nos")
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
                // clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
                // clsValidation.TextChanged(txtFreeQty, System.Globalization.NumberStyles.Currency);
            }
        }

        private void btnDownload_Enter(object sender, EventArgs e)
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                /* if (search.IsDisposed)
                 {
                     search= new frmSearch();
                 }
                 if (txtSuppCode.Text != "")
                 {
                     objGrn.SqlStatement = "SELECT Document_No,Purr_Date FROM tb_Purchase WHERE Loca='" + LoginManager.LocaCode + "' AND Supp_Code='" + txtSuppCode.Text.Trim() + "' AND Rcl=0";
                 }
                 else
                 {
                     objGrn.SqlStatement = "SELECT Document_No,Purr_Date FROM tb_Purchase WHERE Loca='" + LoginManager.LocaCode + "' AND Rcl=0";
                 }               
                 objGrn.DataetName = "dsPurch";               
                 objGrn.GetItemDetails();
                 search.dgSearch.DataSource = objGrn.GetItemDataset.Tables["dsPurch"];
                 search.prop_Focus = txtSavedDoc;
                 search.Show();      */



                if (dataGridTempGRN.Rows.Count > 0)
                {
                    if (MessageBox.Show("Current Items will be Removed..Contineu?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                txtSuppCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                if (txtSuppCode.Text.Trim() == string.Empty)
                {
                    return;
                }
                objGrn.RecallProductItems(dpDate.Text, txtSuppCode.Text.Trim());

                dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                dataGridTempGRN.Refresh();

                objGrn.GetTotalValues("GRN");

                lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                decAdjustment = decimal.Parse(txtInvAmount.Text.Trim().ToString());
                decAdjustment = decAdjustment - objGrn.TotalAmount;
                lblInvoiceAdjust.Text = string.Format("{0:0.00}", decAdjustment);
                txtSubDiscount.Text = "0";
                txtSubDiscPer.Text = string.Empty;
                txtTaxAmount.Text = "0";
                lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnDownload_Leave(object sender, EventArgs e)
        {

        }

        private void txtSavedDoc_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtSavedDoc.Text != "")
                {
                    objGrn.SqlStatement = "SELECT Purr_Date, Bill_No, Bill_Amount, Supp_Code, Supp_Name  FROM tb_Purchase WHERE Loca='" + LoginManager.LocaCode + "' AND Document_No='" + txtSavedDoc.Text + "' AND Rcl=0";
                    objGrn.Reader();
                    if (objGrn.RecordFound == true)
                    {
                        txtInvAmount.Text = objGrn.Dr["Bill_Amount"].ToString();
                        txtSupplierInv.Text = objGrn.Dr["Bill_No"].ToString();
                        dtpInvDate.Text = objGrn.Dr["Purr_Date"].ToString();
                        txtSuppCode.Text = objGrn.Dr["Supp_Code"].ToString();
                        txtSuppName.Text = objGrn.Dr["Supp_Name"].ToString();
                        txtSuppCode.Enabled = false;
                        txtSuppName.Enabled = false;
                        txtSupplierInv.Enabled = false;
                        //txtInvAmount.Enabled = false;
                        btnSupplierSearch.Enabled = false;
                        txtCreditPeriod.Focus();

                    }
                    else
                    {
                        txtSuppCode.Enabled = true;
                        txtSuppName.Enabled = true;
                        txtSupplierInv.Enabled = true;
                        // txtInvAmount.Enabled = true;
                        btnSupplierSearch.Enabled = true;
                    }


                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objGrn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'GRN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objGrn.ReadTempTransDetails();
                if (objGrn.RecordFound != true)
                {
                    MessageBox.Show("GRN Details Not Found.", "Invoice Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*
                objGrn.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'GRNAPP' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objGrn.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nDelete this " + this.Text + " Invoice through authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }*/
                if (MessageBox.Show("Are You sure you want to delete this document?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objGrn.SqlStatement = "EXEC sp_DeleteSavedDoc @DocNo = '" + lblTempDocNo.Text + "',  @Loca = '" + LoginManager.LocaCode + "', @Iid = 'GRN'";
                    objGrn.ReadTempTransDetails();
                    MessageBox.Show("Delete successful!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                objGrn.Errormsg(ex, "frmGRN- btnDelete_Click");
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOrgPriceUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Update The Original Prices For All Details?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objGrn.SqlStatement = "EXEC sp_UpdateOriginalPrices	@Err_x=0, @Iid='GRN', @Loca='" + LoginManager.LocaCode + "', @DocNo='" + lblTempDocNo.Text + "' ";
                    objGrn.ReadTempTransDetails();
                    MessageBox.Show("Succussfully Updated", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objGrn.GetTempDataset();
                    dataGridTempGRN.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                    dataGridTempGRN.Refresh();
                    objGrn.GetTotalValues("GRN");
                    lblTotalQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);
                    lblTotalAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                    decAdjustment = decimal.Parse(txtInvAmount.Text.Trim().ToString());
                    decAdjustment = decAdjustment - objGrn.TotalAmount;
                    lblInvoiceAdjust.Text = string.Format("{0:0.00}", decAdjustment);
                    txtSubDiscount.Text = "0";
                    txtSubDiscPer.Text = string.Empty;
                    txtTaxAmount.Text = "0";
                    lblSubTotal.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                }


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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

        private void txtProductCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductCode.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnItemSearch.PerformClick();
                txtProductCode.Focus();
            }
        }

        private void btnShipmentSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();

                }

                Common.getDataSet("SELECT ShipmentCode AS Code, ShipmentDescription AS Department FROM tb_Shipment WHERE (ShipmentCode LIKE '%" + txtShipmentCode.Text.Trim() + "%') AND (ShipmentDescription LIKE '%" + txtShipmentDescription.Text.Trim() + "%') ORDER BY ShipmentCode", "dtShipment");

                search.dgSearch.DataSource = Common.Ads.Tables["dtShipment"];
                search.prop_Focus = txtShipmentCode;
                search.Cont_Descript = txtShipmentDescription;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtShipmentCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Shipment_Load();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void Shipment_Load()
        {
            try
            {
                try
                {

                    Common.getDataSet("SELECT ShipmentCode, ShipmentDescription, CONVERT(VARCHAR(10),ShipmentDate,103) ShipmentDate FROM tb_Shipment WHERE ShipmentCode='" + txtShipmentCode.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'", "dtShipment");

                    if (Common.Ads.Tables["dtShipment"].Rows.Count > 0)
                    {
                        txtShipmentCode.Text = Common.Ads.Tables["dtShipment"].Rows[0]["ShipmentCode"].ToString();
                        txtShipmentDescription.Text = Common.Ads.Tables["dtShipment"].Rows[0]["ShipmentDescription"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dtpExpireDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Settings.Default.GRNCostEdit)
                {
                    txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                }
                else
                {
                    txtQty.Focus(); txtQty.SelectAll();
                }
            }
        }

        private void chkvat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkvat.Checked == true)
                {
                    chkVatforProd.Checked = true;
                    chkVatPro.Checked = true;
                    chkVatforProd.Enabled = true;
                    chkVatPro.Enabled = true;
                    chkInputVAT.Enabled = true;
                    chkVatExtract.Enabled = true;
                    chkVatExtract.Checked = true;
                }
                else
                {
                    chkVatforProd.Checked = false;
                    chkVatPro.Checked = false;
                    chkVatforProd.Enabled = false;
                    chkVatPro.Enabled = false;
                    chkInputVAT.Enabled = false;
                    chkVatExtract.Enabled = false;
                    chkVatExtract.Checked = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chkVatforProd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                VatCalculationForItem();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductCode.Focus();
            }
        }

        private void chkInputVAT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInputVAT.Checked == true)
                {

                }
                else
                { }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtPurchasePriceNonVAt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtPurchasePriceNonVAt.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtPurchasePriceNonVAt.Text) >= 0 && chkvat.Checked == true && chkVatExtract.Checked == false)
                {
                    if (chkVatPro.Checked == true)
                    {
                        decimal CostPrice = ((decimal.Parse(txtPurchasePriceNonVAt.Text.ToString()) * Settings.Default.VatPrecentage)) / 100;
                        decAmount = (decimal.Parse(txtPurchasePriceNonVAt.Text.ToString())) + CostPrice;
                        txtPurchasePrice.Text = decAmount.ToString("N2");
                        txtPurchasePrice.Focus();
                    }
                    else
                    {
                        txtPurchasePrice.Text = txtPurchasePriceNonVAt.Text.Trim();
                        txtPurchasePrice.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtSuppName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}