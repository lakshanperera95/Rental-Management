using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
using System.Globalization;

namespace Inventory
{
    public partial class frmBatchPriceChange : Form
    {
        public frmBatchPriceChange()
        {
            InitializeComponent();
        }

        public frmBatchPriceChange(string strProdCode, string strProdName)
        {
            InitializeComponent();
            this.txtProductCode.Text = strProdCode;
            this.txtProductName.Text = strProdName;
            this.LoadItem();
        }
        

        clsProductPriceMaste objProductPriceMaste = new clsProductPriceMaste();
        clsCommon Common = new clsCommon();
        frmSearch search = new frmSearch();

        private static frmBatchPriceChange objBatchPriceChange;
        public static frmBatchPriceChange _objBatchPriceChange
        {
            get { return objBatchPriceChange; }
            set { objBatchPriceChange = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                objBatchPriceChange = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmLotWiseDollarPrice_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                objBatchPriceChange = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmLotWiseDollarPrice_Load(object sender, EventArgs e)
        {

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
                    objProductPriceMaste.SqlStatement = "SELECT Prod_Code AS [Product Code],Barcode,Prod_Name AS [Product Name] FROM Product WHERE ( Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%' or barcode like '%" + txtProductCode.Text.Trim() + "%')";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objProductPriceMaste.SqlStatement = "SELECT Prod_Code AS [Product Code],Barcode,Prod_Name AS [Product Name] FROM Product WHERE (Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' or barcode like '%" + txtProductName.Text.Trim() + "%' )ORDER BY Prod_Name";
                    }
                    else
                    {
                        objProductPriceMaste.SqlStatement = "SELECT Prod_Code AS [Product Code],Barcode,Prod_Name AS [Product Name] FROM Product";
                    }
                }

                objProductPriceMaste.DataetName = "dsProduct";
                objProductPriceMaste.GetItemDetails();

                search.dgSearch.DataSource = objProductPriceMaste.GetItemDataset.Tables["dsProduct"];
                search.prop_Focus = txtProductCode;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    this.LoadItem();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void LoadItem()
        {
            try
            {
                txtProductCode.Text = txtProductCode.Text.ToUpper();
                objProductPriceMaste.SqlStatement = " SELECT product.Prod_Code, product.Prod_Name, CAST(Stock_Master_Batch.Purchase_Price AS DECIMAL(18,2)) [Purchase_Price], CAST(Stock_Master_Batch.Ws_Price AS DECIMAL(18,2)) [Ws_Price], CAST(Stock_Master_Batch.Ret_Price AS DECIMAL(18,2)) [Ret_Price], CAST(Stock_Master_Batch.Distr_Price AS DECIMAL(18,2)) [Distr_Price], CAST(Stock_Master_Batch.ModMkt_Price AS DECIMAL(18,2)) [ModMkt_Price], Stock_Master_Batch.BatchNo AS [BatchNo],  Stock_Master_Batch.Exp_Date , Stock_Master_Batch.Shipment, Stock_Master_Batch.Stock" +
                                                    " FROM product INNER JOIN Stock_Master_Batch ON Product.Prod_Code=Stock_Master_Batch.Prod_Code  "+
                                                    " WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "'  or barcode = '" + txtProductCode.Text.Trim() + "') AND Stock_Master_Batch.Loca='" + LoginManager.LocaCode + "' ORDER BY Stock_Master_Batch.BatchNo ";
                objProductPriceMaste.DataetName = "dtBatchWisePrice";
                objProductPriceMaste.GetItemDetails();
                if (objProductPriceMaste.GetItemDataset.Tables["dtBatchWisePrice"].Rows.Count > 0)
                {
                    txtProductCode.Text = objProductPriceMaste.GetItemDataset.Tables["dtBatchWisePrice"].Rows[0]["Prod_Code"].ToString();
                    txtProductName.Text = objProductPriceMaste.GetItemDataset.Tables["dtBatchWisePrice"].Rows[0]["Prod_Name"].ToString();

                    dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.GetItemDataset.Tables["dtBatchWisePrice"];
                    dataGridViewProductPriceLevel.Refresh();
                }
                else
                {
                    //MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dataGridViewProductPriceLevel_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductPriceLevel.SelectedRows.Count==1 && dataGridViewProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString()!="")
                {
                    
                    txtBatchNo.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString();

                    txtPurchasePrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[3].Value.ToString();
                    txtWsPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[4].Value.ToString();
                    txtRetPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[5].Value.ToString();
                    txtDistribPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[6].Value.ToString();
                    txtModMktPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[7].Value.ToString();

                    if (Common.ProductExpireHave(txtProductCode.Text))
                    {
                        dtpExpireDate.Enabled = true;
                        dtpExpireDate.Value = (DateTime)(dataGridViewProductPriceLevel.SelectedRows[0].Cells[1].Value);
                        dtpExpireDate.Focus();
                    }
                    else
                    {
                        dtpExpireDate.Enabled=false;
                        txtPurchasePrice.Focus();
                        txtPurchasePrice.SelectAll();
                    }
                    
                    

                    

                }
                else
                {
                    MessageBox.Show("Select Data", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                try
                {
                    if (MessageBox.Show("Do You Want To Update The Prices?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        

                        if (txtPurchasePrice.Text == "" || clsValidation.isNumeric(txtPurchasePrice.Text, NumberStyles.Currency) == false || decimal.Parse(txtPurchasePrice.Text) <= 0)
                        {
                            MessageBox.Show("Invalid Purchase Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (txtWsPrice.Text == "" || clsValidation.isNumeric(txtWsPrice.Text, NumberStyles.Currency) == false || decimal.Parse(txtWsPrice.Text) < 0)
                        {
                            MessageBox.Show("Invalid Wholesale Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (txtRetPrice.Text == "" || clsValidation.isNumeric(txtRetPrice.Text, NumberStyles.Currency) == false || decimal.Parse(txtRetPrice.Text) <= 0)
                        {
                            MessageBox.Show("Invalid Retail Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (txtDistribPrice.Text == "" || clsValidation.isNumeric(txtDistribPrice.Text, NumberStyles.Currency) == false || decimal.Parse(txtDistribPrice.Text) < 0)
                        {
                            MessageBox.Show("Invalid Distributor Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (txtModMktPrice.Text == "" || clsValidation.isNumeric(txtModMktPrice.Text, NumberStyles.Currency) == false || decimal.Parse(txtModMktPrice.Text) < 0)
                        {
                            MessageBox.Show("Invalid Modern Market Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        

                        objProductPriceMaste.DataExists("select BatchNo from Stock_Master_Batch where Prod_Code='"+txtProductCode.Text+"' and BatchNo='"+txtBatchNo.Text.Trim()+"' and Loca='"+LoginManager.LocaCode+"' ");
                        if (objProductPriceMaste.RecordFound==false)
                        {
                            MessageBox.Show("Invalid Batch No", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        string A=txtProductCode.Text.Trim().ToUpper();
                        string B=txtBatchNo.Text.Substring(0, txtBatchNo.Text.IndexOf('-'));
                        if (A!=B)
                        {
                            MessageBox.Show("BatchNo Not Matching With Product Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        objProductPriceMaste.ProductCode = txtProductCode.Text;
                        objProductPriceMaste._strBatchNo = txtBatchNo.Text.Trim();

                        if (Common.ProductExpireHave(txtProductCode.Text))
                        {
                            objProductPriceMaste._strExpDate = dtpExpireDate.Value.ToShortDateString();
                        }
                        else
                        {
                            objProductPriceMaste._strExpDate = "";
                        }
                        objProductPriceMaste.PurchasingPrice = decimal.Parse(txtPurchasePrice.Text);
                        objProductPriceMaste._decRPrice = decimal.Parse(txtRetPrice.Text);
                        objProductPriceMaste._decWPrice = decimal.Parse(txtWsPrice.Text);
                        objProductPriceMaste._decDPrice = decimal.Parse(txtDistribPrice.Text);
                        objProductPriceMaste._decMMPrice = decimal.Parse(txtModMktPrice.Text);
                      


                        objProductPriceMaste.DataExists("SELECT UnderCost FROM Stock_Master WHERE Loca='" + LoginManager.LocaCode + "' AND Prod_Code='" + objProductPriceMaste.ProductCode + "' AND UnderCost=1 ");
                        if (objProductPriceMaste.RecordFound == false)
                        {
                            if (objProductPriceMaste._decRPrice < objProductPriceMaste.PurchasingPrice)
                            {
                                MessageBox.Show("Purchase Price Grater Than Retail Price ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (objProductPriceMaste._decWPrice < objProductPriceMaste.PurchasingPrice)
                            {
                                MessageBox.Show("Purchase Price Grater Than Whole Price ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (objProductPriceMaste._decDPrice < objProductPriceMaste.PurchasingPrice)
                            {
                                MessageBox.Show("Purchase Price Grater Than Distributor Price ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (objProductPriceMaste._decMMPrice < objProductPriceMaste.PurchasingPrice)
                            {
                                MessageBox.Show("Purchase Price Grater Than Modern Mkt Price ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        if (objProductPriceMaste._decRPrice <= 0 || objProductPriceMaste.PurchasingPrice <= 0 || objProductPriceMaste._decWPrice <= 0 || objProductPriceMaste._decDPrice <= 0 || objProductPriceMaste._decMMPrice <= 0)
                        {
                            MessageBox.Show("Invalid Prices ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        objProductPriceMaste.BatchPrice_Update();

                        MessageBox.Show("Batch Price Updated Succussfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                        txtBatchNo.Text = txtPurchasePrice.Text = txtRetPrice.Text = txtDistribPrice.Text =txtModMktPrice.Text=txtWsPrice.Text= "";
                        dtpExpireDate.ResetText();

                        this.LoadItem();
                    }

                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
        }

        private void txtDollarPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    if (txtDistribPrice.Text!="")
                    {
                        if (clsValidation.isNumeric(txtDistribPrice.Text, NumberStyles.Currency) && decimal.Parse(txtDistribPrice.Text)>=0)
                        {
                            txtModMktPrice.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProductPriceLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtPurchasePrice.Text != "")
                    {
                        if (clsValidation.isNumeric(txtPurchasePrice.Text, NumberStyles.Currency) && decimal.Parse(txtPurchasePrice.Text) > 0)
                        {
                            txtWsPrice.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtRetPrice.Text != "")
                    {
                        if (clsValidation.isNumeric(txtRetPrice.Text, NumberStyles.Currency) && decimal.Parse(txtRetPrice.Text) > 0)
                        {
                            txtDistribPrice.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dtpExpireDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtPurchasePrice.Focus();
            }
        }

        private void txtWsPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtWsPrice.Text != "")
                    {
                        if (clsValidation.isNumeric(txtWsPrice.Text, NumberStyles.Currency) && decimal.Parse(txtWsPrice.Text) > 0)
                        {
                            txtRetPrice.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtModMktPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtModMktPrice.Text != "")
                    {
                        if (clsValidation.isNumeric(txtModMktPrice.Text, NumberStyles.Currency) && decimal.Parse(txtModMktPrice.Text) >= 0)
                        {
                            btnUpdate.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        

    }
}