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
    public partial class frmProductDiscard : Form
    {
        public frmProductDiscard()
        {
            InitializeComponent();
        }

        clsGrn objGrn = new clsGrn();
        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();

        private static frmProductDiscard _ProductDiscard;
        public static frmProductDiscard ProductDiscard
        {
            get { return _ProductDiscard; }
            set { _ProductDiscard = value; }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmProductDiscard_Load(object sender, EventArgs e)
        {
            try
            {
                objGrn.SqlStatement = "SELECT TempPDN FROM DocumentNoDetails WHERE Loca = ";
                objGrn.GetTempDocumentNo("PDN");
                lblTempDocNo.Text = objGrn.TempDocNo;
               
               
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
                    objGrn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Prod_Code Like '%" + txtProductCode.Text.Trim() + "%' " + withSupplier + " ORDER BY P.Prod_Code";
                }
                else if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                {
                    objGrn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Prod_Name Like '%" + txtProductName.Text.Trim() + "%'" + withSupplier + " ORDER BY P.Prod_Code";
                }
                else
                {
                    objGrn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "'" + withSupplier + " ORDER BY P.Prod_Code";
                }

                objGrn.DataetName = "dsProduct";
                objGrn.GetItemDetails();
                ProductSearch.dgSearch.DataSource = objGrn.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[2].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.prop_Focus = txtProductCode;
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

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.CheckSupplierDetails();
                txtSuppName.Focus();
            }
        }

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMemo.Focus();
            }
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductCode.Focus();
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckProductValidate();
               
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCost.Focus();
            }
        }

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter && txtQty.Text.Trim() != string.Empty)
                    {
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
                            objGrn.PurchasePrice = decimal.Parse(txtCost.Text);
                           
                        }
                        else
                        {
                            MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtProductCode.Focus();
                            return;
                        }                     
                        objGrn.ProductCode = txtProductCode.Text.Trim().ToUpper();
                        objGrn.ProductName = txtProductName.Text.Trim().ToUpper();
                        lblCurrentQty.Text = objGrn.CurrentQty.ToString();                     
                        objGrn.Qty = decimal.Parse(txtQty.Text.ToString());
                        lblAmount.Text= (decimal.Parse(txtQty.Text) * decimal.Parse(txtCost.Text)).ToString();

                        objGrn.Amount = decimal.Parse(lblAmount.Text.ToString());
                        objGrn.UpdatePDNTempDataSet();
                        //objGrn.GetTempDataset();
                        dgProdDiscard.DataSource = objGrn.TempGrn.Tables["GoodReceivedNote"];
                        dgProdDiscard.Refresh();
                        //Set Grid Last Record
                        if (dgProdDiscard.RowCount > 12)
                        {
                            dgProdDiscard.FirstDisplayedCell = dgProdDiscard[0, dgProdDiscard.RowCount - 6];
                        }

                        //******************
                        txtProductCode.Text = string.Empty;
                        txtProductName.Text = string.Empty;
                        txtQty.Text = string.Empty;
                        lblCurrentQty.Text = string.Empty;
                        txtCost.Text = string.Empty;                       
                        txtQty.Text = "0";                        
                        lblAmount.Text = string.Empty;
                        objGrn.Disc = string.Empty;                        
                        txtMemo.Enabled = false;

                        objGrn.GetTotalValues("PDN");

                        lblTotQty.Text = string.Format("{0:0.00}", objGrn.TotalQty);                
                        lblNetAmount.Text = string.Format("{0:0.00}", objGrn.TotalAmount);
                        txtSuppCode.Enabled = false;
                        txtSuppName.Enabled = false;                
                       
                       
                      

                       
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
            }
        }

        private void frmProductDiscard_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProductDiscard = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                ProductDiscard = null;
                this.Close();
                

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

        private void CheckSupplierDetails()
        {
            objGrn.SuppCode = txtSuppCode.Text.ToString().Trim();
            objGrn.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
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
                objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price],VatProd FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) AND LockedItem='F' and Stock_Master.Loca = ";
            }
            else
            {
                objGrn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit, CAST(Product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(Product.Whole_Price AS DECIMAL(18,2))[Whole_Price],VatProd FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) AND LockedItem='F' AND Stock_Master.Loca = ";
            }
            objGrn.ReadProductDetails();
            if (objGrn.RecordFound == true)
            {
                txtProductCode.Text = objGrn.ProductCode;
                txtProductName.Text = objGrn.ProductName;
                txtCost.Text = (string)objGrn.PurchasePrice.ToString();
                lblCurrentQty.Text = (string)objGrn.CurrentQty.ToString();               
                objGrn.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objGrn.ProductCode + "' AND Doc_No = '" + objGrn.TempDocNo + "' AND IId = 'GRN' AND Loca = ";
                objGrn.ReadExsistProductDetails();
                if (objGrn.Unit == "Nos")
                {
                    txtQty.Text = (string.Format("{0:0}", objGrn.Qty));
                }
                else
                {
                    txtQty.Text = (string)objGrn.Qty.ToString();
                }

                if (Settings.Default.GRNCostEdit)
                {
                    txtCost.Focus(); txtCost.SelectAll();
                }
                else
                {
                    txtQty.Focus(); txtQty.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmProductDiscard_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProductDiscard = null;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You want to Apply This Document. ", "Product Discard Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;
                    objGrn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'PDN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objGrn.ReadTempTransDetails();
                    if (objGrn.RecordFound != true)
                    {
                        MessageBox.Show("Product Discard Note Details Not Found.", "Product Discard Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    clsCommon objCommon = new clsCommon();
                    objCommon.CheckStock(lblTempDocNo.Text, "PDN");
                    int i = 0;
                    string CodeCollection = "";
                    foreach (DataRow row in objCommon.Ads.Tables[0].Rows)
                    {
                        if (float.Parse(row["Stock"].ToString()) < float.Parse(row["Qty"].ToString()))
                        {
                            dgProdDiscard.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                            dgProdDiscard.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            CodeCollection = CodeCollection + row[0].ToString() + ", ";
                        }
                        i++;
                    }
                    if (CodeCollection != string.Empty)
                    {
                        MessageBox.Show("Damage Qty is greater than the Current Qty.Product Code is at below \n " + CodeCollection + "", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;


                    }



                    objGrn.PostDate = dtdate.Text;
                    objGrn.Remark = txtMemo.Text.Trim();
                    objGrn.TotalAmount = decimal.Parse(lblNetAmount.Text.ToString());
                    objGrn.PDNoteApply();
                    MessageBox.Show("Product Discard Note Successfully Applied as Document No. " + objGrn.OrgDocNo, "Product Discard Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objGrn.GetDataSetForReportPDN();
                    dsDataForReport = objGrn.GetReportDataset;
                    rptProductDiscardNote ProductDiscardNote = new rptProductDiscardNote();
                    ProductDiscardNote.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = ProductDiscardNote;
                    objRepViewer.Show();

                    ProductDiscard = null;
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
        }
    }
}