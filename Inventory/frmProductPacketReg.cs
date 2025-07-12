using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
namespace Inventory
{
    public partial class frmProductPacketReg : Form
    {
        public frmProductPacketReg()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtPacketQty, System.Globalization.NumberStyles.Currency);
        }

        clsProductPacketReg objPacketingItemSelect = new clsProductPacketReg();

        private static frmProductPacketReg PacketingItemSelect;

        private frmSearch search = new frmSearch();

        public static frmProductPacketReg GetPacketingItemSelect
        {
            get
            {
                return PacketingItemSelect;
            }
            set
            {
                PacketingItemSelect = value;
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
                    objPacketingItemSelect.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'  AND LockedItem='F' /*and Packet=1*/ ";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objPacketingItemSelect.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%'  AND LockedItem='F'  /*and Packet=1*/";
                    }
                    else
                    {
                        objPacketingItemSelect.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE  LockedItem='F'  and bundle=1 ";
                    }
                }

                objPacketingItemSelect.DataetName = "dsProduct";
                objPacketingItemSelect.GetItemDetails();

                search.dgSearch.DataSource = objPacketingItemSelect.GetProductDataset.Tables["dsProduct"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPacketingItemSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PacketingItemSelect = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPacketingItemSelect 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPacketingItemSelect_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPacketingItemSelect 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPacketProductCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtPacketProductCode.Text = search.Code.Trim();
                    txtPacketProductName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objPacketingItemSelect.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "'  AND LockedItem='F' ";
                    objPacketingItemSelect.ReadProductDetails();
                    if (objPacketingItemSelect.RecordFound == true)
                    {
                        txtProductName.Text = objPacketingItemSelect.ProductName;
                        lblPurchasePrice.Text = (string)objPacketingItemSelect.PurchasePrice.ToString();
                        txtPacketProductCode.Enabled = true;
                        txtPacketProductName.Enabled = true;
                        btnPacketItemSearch.Enabled = true;
                        objPacketingItemSelect.RetreivePacketingProduct();
                        objPacketingItemSelect.GetTempDataset();
                        dataGridViewTempPackProduct.DataSource = objPacketingItemSelect.TempSelectedItem.Tables["dsTempPacketProduct"];
                        dataGridViewTempPackProduct.Refresh();

                        txtPacketProductCode.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPacketProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string code = "";
                    objPacketingItemSelect.ReadProductCode("SELECT PPD.Prod_Code FROM tbPacketProductDetails PPD WHERE PPD.Packet_Prod_Code = '" + txtPacketProductCode.Text.Trim() + "' AND PPD.Prod_Code <> '" + txtProductCode.Text.Trim() + "'", ref code);
                    if (code != "")
                    {
                        MessageBox.Show("This product already exists under this main code (" + code + ")", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPacketProductCode.Focus(); txtPacketProductCode.SelectAll();
                        return;
                    }

                    objPacketingItemSelect.ReadProductCode("SELECT DISTINCT(PPD.Prod_Code) [Prod_Code] FROM tbPacketProductDetails PPD WHERE PPD.Prod_Code = '" + txtPacketProductCode.Text.Trim() + "'", ref code);
                    if (code != "")
                    {
                        MessageBox.Show("This product code has already been added as a main product", "Main Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPacketProductCode.Focus(); txtPacketProductCode.SelectAll();
                        return;
                    }

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objPacketingItemSelect.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtPacketProductCode.Text.Trim() + "'  AND LockedItem='F' ";
                    objPacketingItemSelect.ReadProductDetails();
                    if (objPacketingItemSelect.RecordFound == true)
                    {
                        txtPacketProductName.Text = objPacketingItemSelect.ProductName;
                        lblPacketPurchasePrice.Text = (string)objPacketingItemSelect.PurchasePrice.ToString();
                        txtPacketQty.Enabled = true;
                        txtPacketQty.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnPacketItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtPacketProductCode.Text.Trim() != string.Empty && txtPacketProductName.Text.Trim() == string.Empty)
                {
                    objPacketingItemSelect.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code <> '" + txtProductCode.Text.Trim() + "' AND Prod_Code LIKE '%" + txtPacketProductCode.Text.Trim() + "%'  AND LockedItem='F' ";
                }
                else
                {
                    if (txtPacketProductCode.Text.Trim() == string.Empty && txtPacketProductName.Text.Trim() != string.Empty)
                    {
                        objPacketingItemSelect.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code <> '" + txtProductCode.Text.Trim() + "' AND Prod_Name LIKE '%" + txtPacketProductName.Text.Trim() + "%'  AND LockedItem='F' ";
                    }
                    else
                    {
                        objPacketingItemSelect.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code <> '" + txtProductCode.Text.Trim() + "'  AND LockedItem='F' ";
                    }
                }

                objPacketingItemSelect.DataetName = "dsProduct";
                objPacketingItemSelect.GetItemDetails();

                search.dgSearch.DataSource = objPacketingItemSelect.GetProductDataset.Tables["dsProduct"];
                search.prop_Focus = txtPacketProductCode;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPacketQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtPacketQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtPacketQty.Text) > 0)
                {
                    if (txtProductCode.Text.Trim() == txtPacketProductCode.Text.Trim())
                    {
                        txtPacketProductCode.Text = string.Empty;
                        txtPacketProductName.Text = string.Empty;
                        lblPacketPurchasePrice.Text = string.Empty;
                        MessageBox.Show("Can't Create Same Product as Packeting Product.", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    txtPacketProductCode.Text = txtPacketProductCode.Text.ToUpper();
                    objPacketingItemSelect.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtPacketProductCode.Text.Trim() + "' AND LockedItem='F' ";
                    objPacketingItemSelect.ReadProductDetails();
                    if (objPacketingItemSelect.RecordFound == true)
                    {
                       //txtProductName.Text = objPacketingItemSelect.ProductName;
                        //lblPurchasePrice.Text = (string)objPacketingItemSelect.PurchasePrice.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPacketProductCode.Focus();
                        return;
                    }

                    string code = "";
                    objPacketingItemSelect.ReadProductCode("SELECT PPD.Prod_Code FROM tbPacketProductDetails PPD WHERE PPD.Packet_Prod_Code = '" + txtPacketProductCode.Text.Trim() + "' AND PPD.Prod_Code <> '" + txtProductCode.Text.Trim() + "'", ref code);
                    if (code != "")
                    {
                        MessageBox.Show("This product already exists under this main code (" + code + ")", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPacketProductCode.Focus(); txtPacketProductCode.SelectAll(); 
                        return;
                    }

                    objPacketingItemSelect.ReadProductCode("SELECT DISTINCT(PPD.Prod_Code) [Prod_Code] FROM tbPacketProductDetails PPD WHERE PPD.Prod_Code = '" + txtPacketProductCode.Text.Trim() + "'", ref code);
                    if (code != "")
                    {
                        MessageBox.Show("This product code has already been added as a main product", "Main Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPacketProductCode.Focus(); txtPacketProductCode.SelectAll();
                        return;
                    }

                    objPacketingItemSelect.ProductCode = txtPacketProductCode.Text.Trim().ToUpper();
                    objPacketingItemSelect.ProductName = txtPacketProductName.Text.Trim().ToUpper();
                    objPacketingItemSelect.PurchasePrice = decimal.Parse(lblPurchasePrice.Text);
                    objPacketingItemSelect.Qty = decimal.Parse(txtPacketQty.Text.ToString());

                    objPacketingItemSelect.UpdateTempPacketing();
                    objPacketingItemSelect.GetTempDataset();
                    dataGridViewTempPackProduct.DataSource = objPacketingItemSelect.TempSelectedItem.Tables["dsTempPacketProduct"];
                    dataGridViewTempPackProduct.Refresh();

                    txtPacketProductCode.Text = string.Empty;
                    txtPacketProductName.Text = string.Empty;
                    txtPacketQty.Text = string.Empty;
                    lblPacketPurchasePrice.Text = string.Empty;

                    txtProductCode.Enabled = false;
                    txtProductName.Enabled = false;
                    txtPacketProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPacketingItemSelect_Load(object sender, EventArgs e)
        {
            try
            {
                objPacketingItemSelect.DeleteTempPacketing();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewTempPackProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewTempPackProduct.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objPacketingItemSelect.ProductCode = dataGridViewTempPackProduct.SelectedRows[0].Cells[0].Value.ToString();
                        objPacketingItemSelect.DeleteTempPacketingProduct();
                        objPacketingItemSelect.GetTempDataset();
                        dataGridViewTempPackProduct.DataSource = objPacketingItemSelect.TempSelectedItem.Tables["dsTempPacketProduct"];
                        dataGridViewTempPackProduct.Refresh();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                PacketingItemSelect = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (dataGridViewTempPackProduct.RowCount == 0)
                {
                    MessageBox.Show("No data found in order to apply", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                objPacketingItemSelect.ProductCode = txtProductCode.Text.Trim().ToUpper();
                objPacketingItemSelect.ProductName = txtProductName.Text.Trim().ToUpper();
                objPacketingItemSelect.PurchasePrice = decimal.Parse(lblPurchasePrice.Text);
                objPacketingItemSelect.PacketingProductApply();
                MessageBox.Show("Packeting Product Create Successfully." , this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                this.Dispose();
                PacketingItemSelect = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingItemSelect 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductPacketReg.GetPacketingItemSelect = new frmProductPacketReg();
            frmProductPacketReg.GetPacketingItemSelect.MdiParent = MainClass.mdi;
            frmProductPacketReg.GetPacketingItemSelect.Show();
        }

    }
}