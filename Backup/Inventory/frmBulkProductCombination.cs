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
    public partial class frmBulkProductCombination : Form
    {
        public frmBulkProductCombination()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
        }

        frmSearch search = new frmSearch();

        clsBulkProductCombination objCombination = new clsBulkProductCombination();

        private static frmBulkProductCombination _BulkProductCombination;

        public static frmBulkProductCombination GetBulkProductCombination
        {
            get { return _BulkProductCombination; }
            set { _BulkProductCombination = value; }
        }

        private void frmBulkProductCombination_FormClosing(object sender, FormClosingEventArgs e)
        {
            _BulkProductCombination = null;
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
                    objCombination.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%' AND Loose=1 AND LockedItem='F' ";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objCombination.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' AND Loose=1 AND LockedItem='F' ";
                    }
                    else
                    {
                        objCombination.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Loose=1 AND LockedItem='F' ";
                    }
                }
                objCombination.GetItemDetails("dsProduct");
                search.dgSearch.DataSource = objCombination.dataset.Tables["dsProduct"];
                search.prop_Focus = txtProductCode;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objCombination.RetProduct("SELECT Prod_Code, Prod_Name FROM Product WHERE Prod_Code = '" + txtProductCode.Text.Trim() + "' AND Loose=0");
                    if (string.IsNullOrEmpty(objCombination.ProdCode))
                    {
                        MessageBox.Show("Product not found. Enter the valid code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductCode.Focus();
                        txtProductCode.SelectAll();
                        return;
                    }
                    objCombination.SqlStatement = "SELECT SubProd_Code [Prod_Code], Prod_Name, TC.Purchase_Price, TC.Selling_Price, Qty FROM tb_TempCombination TC INNER JOIN Product P ON TC.SubProd_Code = P.Prod_Code WHERE MainProdCode = '" + txtProductCode.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode + "'";
                    //objCombination.SqlStatement = "MainProdCode = '" + txtProductCode.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode + "'";
                    objCombination.GetItemDetails("dsProduct");
                    dgCombination.DataSource = objCombination.dataset.Tables[0];
                    dgCombination.Refresh();
                    objCombination.SqlStatement = "SELECT CAST(SUM(Purchase_Price * Qty) AS DECIMAL(18,2)) [Purchaes], CAST(SUM(Selling_Price * Qty) AS DECIMAL(18,2)) [Selling], SUM(Qty) [Qty]  FROM tb_TempCombination WHERE MainProdCode = '" + txtProductCode.Text.Trim() + "' AND Loca = '" + LoginManager.LocaCode + "'";
                    objCombination.GetItemDetails("dsProduct");
                    foreach (DataRow row in objCombination.dataset.Tables[0].Rows)
                    {
                        lblTotPurchase.Text = row["Purchaes"].ToString();
                        lblTotSelling.Text = row["Selling"].ToString();
                        lblTotQty.Text = row["Qty"].ToString();
                    }
                    txtLooseProd_Code.Text = txtLooseProd_Name.Text = string.Empty;
                    txtQty.Text = "0.00";
                 
                    txtProductCode.Text = objCombination.ProdCode.ToString();
                    txtProductName.Text = objCombination.ProdName.ToString();
                    txtLooseProd_Code.Focus();
                }          
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtLooseProd_Code_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtProductCode.Text.Trim().ToString().ToUpper() == txtLooseProd_Code.Text.Trim().ToString().ToUpper())
                    {
                        MessageBox.Show("This code already assigned as main code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLooseProd_Code.Focus();
                        txtLooseProd_Code.SelectAll();
                        return;
                    }
                    objCombination.ProdCode = txtLooseProd_Code.Text.Trim();
                    objCombination.MainProdCode = txtProductCode.Text.Trim();
                    objCombination.ProdDown();
                    if (string.IsNullOrEmpty(objCombination.ProdCode))
                    {
                        MessageBox.Show("Product not found. Enter the valid code",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtLooseProd_Code.Focus();
                        txtLooseProd_Code.SelectAll();
                        return;
                    }
                    txtLooseProd_Code.Text = objCombination.ProdCode.ToString();
                    txtLooseProd_Name.Text = objCombination.ProdName.ToString();
                    lblPuchase.Text = objCombination.PurchasePrice.ToString("N2");
                    lblSelling.Text = objCombination.SellingPrice.ToString("N2");
                    txtQty.Text = objCombination.Qty.ToString();
                
                    txtQty.Focus();
                    txtQty.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtQty.Text == "")
                    {
                        txtQty.Text = "0";

                    }
                    if (decimal.Parse(txtQty.Text)<=0)
                    {
                        MessageBox.Show("Invalied qty amout", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQty.Focus();
                        txtQty.SelectAll();
                        return;
                    }
                    if (txtProductCode.Text.Trim().ToString().ToUpper() == txtLooseProd_Code.Text.Trim().ToString().ToUpper())
                    {
                        MessageBox.Show("This code is a bulk code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLooseProd_Code.Focus();
                        txtLooseProd_Code.SelectAll();
                        return;
                    }
                    
                    objCombination.RetProduct("SELECT Prod_Code, Prod_Name FROM Product WHERE Prod_Code = '" + txtProductCode.Text.Trim() + "' AND Loose=0");
                    if (string.IsNullOrEmpty(objCombination.ProdCode))
                    {
                        MessageBox.Show("You have selectd an invalied bulk product", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtProductCode.Focus();
                        txtProductCode.SelectAll();
                        return;
                    }
                    objCombination.RetProduct("SELECT Prod_Code, Prod_Name FROM Product WHERE Prod_Code = '" + txtLooseProd_Code.Text.Trim() + "' AND Loose=1");
                    if (string.IsNullOrEmpty(objCombination.ProdCode))
                    {
                        MessageBox.Show("This product is not an abstracted product", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLooseProd_Code.Focus();
                        txtLooseProd_Code.SelectAll();
                        return;
                    }
                    if (objCombination.Reder("SELECT SubProd_Code FROM tb_TempCombination INNER JOIN Product ON Prod_Code=SubProd_Code INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code WHERE SubProd_Code='" + txtLooseProd_Code.Text.Trim() + "' AND Stock_Master.Loca='" + LoginManager.LocaCode + "' AND [ABS]=1") == true)
                    {
                        MessageBox.Show("This product already has been abstracted!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLooseProd_Code.Focus();
                        txtLooseProd_Code.SelectAll();
                        return;
                    }
                    objCombination.MainProdCode = txtProductCode.Text.ToString();
                    objCombination.MainProdName = txtProductName.Text.ToString();
                    objCombination.ProdCode = txtLooseProd_Code.Text.ToString();
                    objCombination.Qty = decimal.Parse(txtQty.Text.Trim());
                    objCombination.AddTempCombinationProduct();
                    dgCombination.DataSource = objCombination.dataset.Tables[0];
                    dgCombination.Refresh();
                    foreach (DataRow row in objCombination.dataset.Tables[1].Rows)
                    {
                        lblTotPurchase.Text = row["Purchaes"].ToString();
                        lblTotSelling.Text = row["Selling"].ToString();
                        lblTotQty.Text = row["Qty"].ToString();
                    }
                    txtLooseProd_Code.Text = txtLooseProd_Name.Text = string.Empty;
                    txtQty.Text = "0.00";
                    lblSelling.Text = "0.0";
                    lblPuchase.Text = "0.0";
                    txtLooseProd_Code.Focus();
                    txtProductCode.Enabled = false;
                    txtProductName.Enabled = false;
                    btnItemSearch.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear these records", "Clear?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                txtLooseProd_Code.Text = "";
                txtLooseProd_Name.Text = "";
                txtProductCode.Text = "";
                txtProductName.Text = "";
                lblPuchase.Text = "0.00";
                lblSelling.Text = "0.00";
                lblTotPurchase.Text = "0.00";
                lblTotQty.Text = "0.00";
                lblTotSelling.Text = "0.00";
                dgCombination.DataSource = null;
                txtProductCode.Enabled = true;
                txtProductName.Enabled = true;
                btnItemSearch.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet dsDataForReport = new DataSet();
            clsReportViewer objRepView = new clsReportViewer();
            frmReportViewer objRepViewer = new frmReportViewer();
            objRepViewer.Text = this.Text;
           
            if (MessageBox.Show("Are you sure you want to save this record?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objCombination.Reder("UPDATE Product SET [Abs]=1 FROM Product INNER JOIN tb_TempCombination ON Prod_Code=SubProd_Code WHERE Loca='" + LoginManager.LocaCode + "'");

                if (dgCombination.RowCount > 0)
                {
                    MessageBox.Show("Successfully Saved!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No record found in order to save.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }            
            }
        }

        private void btnLooseProdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtLooseProd_Code.Text.Trim() != string.Empty && txtLooseProd_Name.Text.Trim() == string.Empty)
                {
                    objCombination.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtLooseProd_Code.Text.Trim() + "%' AND Loose=0 AND LockedItem='F'  ORDER BY Prod_Code ASC";
                }
                else
                {
                    if (txtLooseProd_Code.Text.Trim() == string.Empty && txtLooseProd_Name.Text.Trim() != string.Empty)
                    {
                        objCombination.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtLooseProd_Name.Text.Trim() + "%' AND Loose=0 AND LockedItem='F'  ORDER BY Prod_Code ASC";
                    }
                    else
                    {
                        objCombination.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Loose=0 AND LockedItem='F'  ORDER BY Prod_Code ASC";
                    }
                }
                objCombination.GetItemDetails("dsProduct");
                search.dgSearch.DataSource = objCombination.dataset.Tables["dsProduct"];
                search.prop_Focus = txtLooseProd_Code;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgCombination_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (MessageBox.Show("Are you sure you want to delete this record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objCombination.MainProdCode = txtProductCode.Text.ToString();
                        objCombination.ProdCode = dgCombination.SelectedRows[0].Cells[0].Value.ToString();
                        objCombination.DeleteTempCombinationProduct();
                        dgCombination.DataSource = objCombination.dataset.Tables[0];
                        dgCombination.Refresh();
                        foreach (DataRow row in objCombination.dataset.Tables[1].Rows)
                        {
                            lblTotPurchase.Text = row["Purchaes"].ToString();
                            lblTotSelling.Text = row["Selling"].ToString();
                            lblTotQty.Text = row["Qty"].ToString();
                        }
                        txtLooseProd_Code.Text = txtLooseProd_Name.Text = string.Empty;
                        txtQty.Text = "0.00";
                        txtLooseProd_Code.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            dgCombination.DataSource = null;
        }
    }
}