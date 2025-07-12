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
    public partial class frmProductPriceMaster : Form
    {
        public frmProductPriceMaster(string strProdCode, string strProdName)
        {
            InitializeComponent();
            this.txtProductCode.Text = strProdCode;
            this.txtProductName.Text = strProdName;
            this.Load += new System.EventHandler(this.button1_Click);
        }

        frmSearch search = new frmSearch();

        clsProductPriceMaste objProductPriceMaste = new clsProductPriceMaste();

        private static frmProductPriceMaster ProductPriceMaster;

        public static frmProductPriceMaster GetProductPriceMaster
        {
            get { return ProductPriceMaster; }
            set { ProductPriceMaster = value; }
        }

        private void frmProductPriceMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (txtProductCode.Text.Trim() == string.Empty)
                {
                    objProductPriceMaste.ProductCode = "";
                }
                else
                {
                    objProductPriceMaste.ProductCode = txtProductCode.Text.Trim();

                   
                }
                objProductPriceMaste.DeleteAllTempData();
                objProductPriceMaste.GetTempDataset();
                dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet;
                dataGridViewProductPriceLevel.Refresh();

                txtPurchPrice.Focus();

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductPriceMaster_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductPriceMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ProductPriceMaster = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objProductPriceMaste.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objProductPriceMaste.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' ORDER BY Prod_Name";
                    }
                    else
                    {
                        objProductPriceMaste.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product";
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
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                ProductPriceMaster = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        
        private void Refresh()
        {
            try
            {
                //objProductPriceMaste._Line = 0;
                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objProductPriceMaste.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, CAST(product.Purchase_price AS DECIMAL(18,2)) [Purchaseprice], CAST(product.Selling_Price AS DECIMAL(18,2)) [RetailPrice], CAST(product.Whole_Price AS DECIMAL(18,2)) [WholesalePrice], CAST(product.Disc_Price AS DECIMAL(18,2)) [DistributionPrice], CAST(product.Marked_Price AS DECIMAL(18,2)) [ModernMarketPrice], product.Pack_Size, product.Unit, Supplier_Id, product.Cost_Code FROM product WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F' ";
                    objProductPriceMaste.ReadProductDetails();
                    if (objProductPriceMaste.RecordFound == true)
                    {
                        txtProductName.Text = objProductPriceMaste.ProductName;

                        objProductPriceMaste.ProductCode = txtProductCode.Text.Trim();
                        objProductPriceMaste.ProductName = txtProductName.Text.Trim();
                        objProductPriceMaste.LoadPriceLevelTemp();
                        objProductPriceMaste.GetTempDatasetPriceBatchWise();
                        dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet.Tables["dsPriceMasterDetails"];
                        dataGridViewProductPriceLevel.Refresh();

                        
                        lblRPrice.Text = txtRPrice.Text= (string)objProductPriceMaste._decRPrice.ToString();
                        lblWPrice.Text = txtWPrice.Text = (string)objProductPriceMaste._decWPrice.ToString();
                        lblDPrice.Text = txtDPrice.Text = (string)objProductPriceMaste._decDPrice.ToString();
                        lblMMPrice.Text = txtMMPrice.Text = (string)objProductPriceMaste._decMMPrice.ToString();
                        lblPurchPrice.Text =txtPurchPrice.Text= (string)objProductPriceMaste.PurchasingPrice.ToString();

                        
                        btnApply.Enabled = true;
                        btnClearAll.Enabled = true;

                        txtPurchPrice.SelectAll();
                        txtPurchPrice.Focus();
                    }
                    else
                    {
                        //MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    this.Refresh();
                    
                   
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objProductPriceMaste.ProductCode = txtProductCode.Text.Trim();
                
                objProductPriceMaste.ProductPriceLevelApply();
                if (objProductPriceMaste.ErrorCode == 0)
                {
                    MessageBox.Show("Product Price Level Updated Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    ProductPriceMaster = null;
                }
                else
                {
                    MessageBox.Show("Invalid Product Price Level Update.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    ProductPriceMaster = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductPriceMaster_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 011.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewProductPriceLevel_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductPriceLevel.SelectedRows.Count <= 0 || dataGridViewProductPriceLevel.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtPurchPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString();
                    txtRPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[1].Value.ToString();
                    txtWPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[2].Value.ToString();
                    txtDPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[3].Value.ToString();
                    txtMMPrice.Text = dataGridViewProductPriceLevel.SelectedRows[0].Cells[4].Value.ToString();
                    txtPurchPrice.Focus();
                    txtPurchPrice.SelectAll();
                    
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dataGridViewProductPriceLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", this.Text , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objProductPriceMaste.ProductCode = txtProductCode.Text.Trim();
                        objProductPriceMaste.PurchasingPrice = decimal.Parse(dataGridViewProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString());
                        objProductPriceMaste._decRPrice = decimal.Parse(dataGridViewProductPriceLevel.SelectedRows[0].Cells[1].Value.ToString());
                        objProductPriceMaste._decWPrice = decimal.Parse(dataGridViewProductPriceLevel.SelectedRows[0].Cells[2].Value.ToString());
                        objProductPriceMaste._decDPrice = decimal.Parse(dataGridViewProductPriceLevel.SelectedRows[0].Cells[3].Value.ToString());
                        objProductPriceMaste._decMMPrice = decimal.Parse(dataGridViewProductPriceLevel.SelectedRows[0].Cells[4].Value.ToString());

                        
                        objProductPriceMaste.DeletePriceLevelDetaile();
                        objProductPriceMaste.GetTempDatasetPriceBatchWise();
                        dataGridViewProductPriceLevel.DataSource = null;
                        dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet.Tables["dsPriceMasterDetails"];
                        dataGridViewProductPriceLevel.Refresh();
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
            try
            {
                objProductPriceMaste.DeleteAllTempData();
                objProductPriceMaste.GetTempDataset();
                dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet;
                dataGridViewProductPriceLevel.DataSource = null;
                dataGridViewProductPriceLevel.Refresh();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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


       
        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Refresh();
        }

        

        private void dataGridViewProductPriceLevel_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void txtRPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    string Valid=Price_Check(txtRPrice.Text);
                    if (Valid != "Valid")
                    {
                        MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtRPrice.Focus();
                        return;
                    }

                    txtRPrice.Text = decimal.Parse(txtRPrice.Text).ToString("N2");
                    txtWPrice.Focus();
                    txtWPrice.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtWPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Valid = Price_Check(txtWPrice.Text);
                    if (Valid != "Valid")
                    {
                        MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtWPrice.Focus();
                        return;
                    }

                    txtWPrice.Text = decimal.Parse(txtWPrice.Text).ToString("N2");
                    txtDPrice.Focus();
                    txtDPrice.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtDPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Valid = Price_Check(txtDPrice.Text);
                    if (Valid != "Valid")
                    {
                        MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDPrice.Focus();
                        return;
                    }

                    txtDPrice.Text = decimal.Parse(txtDPrice.Text).ToString("N2");
                    txtMMPrice.Focus();
                    txtMMPrice.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtMMPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Valid = Price_Check(txtMMPrice.Text);
                    if (Valid != "Valid")
                    {
                        MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMMPrice.Focus();
                        return;
                    }

                    txtMMPrice.Text = decimal.Parse(txtMMPrice.Text).ToString("N2");
                    btnInsert.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                objProductPriceMaste.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, CAST(product.Purchase_price AS DECIMAL(18,2)) [Purchaseprice], CAST(product.Selling_Price AS DECIMAL(18,2)) [RetailPrice], CAST(product.Whole_Price AS DECIMAL(18,2)) [WholesalePrice], CAST(product.Disc_Price AS DECIMAL(18,2)) [DistributionPrice], CAST(product.Marked_Price AS DECIMAL(18,2)) [ModernMarketPrice], product.Pack_Size, product.Unit, Supplier_Id, product.Cost_Code FROM product WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F' ";
                objProductPriceMaste.ReadProductDetails();
                if (objProductPriceMaste.RecordFound == false)
                {
                    MessageBox.Show("Product Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtProductCode.Focus();
                    txtProductCode.SelectAll();
                    return;
                }

                string Valid = Price_Check(txtRPrice.Text);
                if (Valid != "Valid")
                {
                    MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRPrice.Focus();
                    txtRPrice.SelectAll();
                    return;
                }

                Valid = Price_Check(txtWPrice.Text);
                if (Valid != "Valid")
                {
                    MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtWPrice.Focus();
                    txtWPrice.SelectAll();
                    return;
                }

                Valid = Price_Check(txtDPrice.Text);
                if (Valid != "Valid")
                {
                    MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDPrice.Focus();
                    txtDPrice.SelectAll();
                    return;
                }

                Valid = Price_Check(txtMMPrice.Text);
                if (Valid != "Valid")
                {
                    MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMMPrice.Focus();
                    txtMMPrice.SelectAll();
                    return;
                }

                objProductPriceMaste.ProductCode = txtProductCode.Text;
                objProductPriceMaste._decRPrice = decimal.Parse(txtRPrice.Text);
                objProductPriceMaste._decWPrice = decimal.Parse(txtWPrice.Text);
                objProductPriceMaste._decDPrice = decimal.Parse(txtDPrice.Text);
                objProductPriceMaste._decMMPrice = decimal.Parse(txtMMPrice.Text);
                objProductPriceMaste.PurchasingPrice = decimal.Parse(txtPurchPrice.Text);

                objProductPriceMaste.UpdatePriceLevelTempDataSet();
                objProductPriceMaste.GetTempDatasetPriceBatchWise();

                dataGridViewProductPriceLevel.DataSource = null;
                dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet.Tables["dsPriceMasterDetails"];
                dataGridViewProductPriceLevel.Refresh();

                //price Batch


                btnItemSearch.Enabled = false;
                txtProductCode.Enabled = false;
                txtProductName.Enabled = false;
                btnApply.Enabled = true;

                txtRPrice.Text = txtWPrice.Text = txtDPrice.Text = txtMMPrice.Text=txtPurchPrice.Text = "0.00";

                txtPurchPrice.Focus();
                txtPurchPrice.SelectAll();

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public string Price_Check(string strprice) 
        {
            try
            {
                if (strprice == string.Empty || clsValidation.isNumeric(strprice, NumberStyles.Currency) == false || decimal.Parse(strprice) < 0)
                {
                    return "Invalid Price";
                }

                objProductPriceMaste.DataExists("select Prod_Code from Stock_Master WHERE UnderCost=0 AND Prod_Code='" + txtProductCode.Text + "' AND Loca='" + LoginManager.LocaCode + "' ");
                if (objProductPriceMaste.RecordFound)
                {
                    if (decimal.Parse(strprice) < decimal.Parse(lblPurchPrice.Text))
                    {
                        return "Under Cost Not Allowed";
                    }
                }

                return "Valid";
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                return "Error";
            }
        }

        private void txtPurchPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Valid = Price_Check(txtPurchPrice.Text);
                    if (Valid != "Valid" && Valid != "Under Cost Not Allowed")
                    {
                        MessageBox.Show(Valid, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPurchPrice.Focus();
                        return;
                    }

                    txtPurchPrice.Text = decimal.Parse(txtPurchPrice.Text).ToString("N2");
                    txtRPrice.Focus();
                    txtRPrice.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

    }
}