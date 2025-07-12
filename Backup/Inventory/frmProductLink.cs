using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
namespace Inventory
{
    public partial class frmProductLink : Form
    {
        public frmProductLink()
        {
            InitializeComponent();
        }

        clsProductLink ObjProductLink = new clsProductLink();
        frmSearch search = new frmSearch();
        private static frmProductLink ProductLink;

        private string strSqlString;
        private string strDatasetName;

        public static frmProductLink GetProductLink
        {
            get { return ProductLink; }
            set { ProductLink = value; }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    ObjProductLink.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product ORDER BY Prod_Code";
                }
                else
                {
                    if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                    {
                        ObjProductLink.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%' ORDER BY Prod_Code";
                    }
                    else
                    {
                        if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                        {
                            ObjProductLink.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' ORDER BY Prod_Name";
                        }
                        else
                        {
                            ObjProductLink.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product ORDER BY Prod_Code";
                        }
                    }
                }
                ObjProductLink.DataetName = "dsProduct";
                ObjProductLink.GetProductDetails();
                search.dgSearch.DataSource = ObjProductLink.GetProductDataset.Tables["dsProduct"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                    ObjProductLink.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Selling_Price FROM product WHERE  LockedItem='F' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) ";
                    ObjProductLink.ReadProductDetails();
                    if (ObjProductLink.ProductName != string.Empty)
                    {
                        txtProductCode.Text = ObjProductLink.ProductCode;
                        txtProductName.Text = ObjProductLink.ProductName;
                        lblSellingPrice.Text = (string)ObjProductLink.SellingPrice.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Product Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ObjProductLink.ProductLinkLoad();
                    ObjProductLink.GetTempProductLink();
                    dataGridProductLink.DataSource = ObjProductLink.TempProductLink.Tables["dsProductLinkTemp"];
                    dataGridProductLink.Refresh();

                    if (ObjProductLink.RecordFound)
                    {
                        txtBarcode.Focus();
                    }
                    else
                    {
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                ProductLink = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    ObjProductLink.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Selling_Price FROM tbProductLink INNER JOIN Product ON tbProductLink.Prod_Code = Product.Prod_Code WHERE tbProductLink.Prod_Code <> '"+ txtProductCode.Text.Trim() +"' AND tbProductLink.Barcode = '"+ txtBarcode.Text.Trim() +"'";
                    ObjProductLink.ReadProductDetails();
                    if (ObjProductLink.RecordFound)
                    {
                        MessageBox.Show("Barcode Using Different Other Product. You Can't Duplicate Barcode.", "Product Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBarcode.Focus();
                    }
                    else
                    {
                        ObjProductLink.ProductCode = txtProductCode.Text.Trim().ToUpper();
                        ObjProductLink.Barcode = txtBarcode.Text.Trim().ToUpper();
                        ObjProductLink.ProductLinkTempUpdate();
                        ObjProductLink.GetTempProductLink();
                        dataGridProductLink.DataSource = ObjProductLink.TempProductLink.Tables["dsProductLinkTemp"];
                        dataGridProductLink.Refresh();
                        txtBarcode.Text = string.Empty;
                        txtProductCode.Enabled = false;
                        txtProductName.Enabled = false;
                        btnItemSearch.Enabled = false;
                        btnApply.Enabled = true;
                        txtBarcode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductLink_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ProductLink = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductLink_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide the form...
                this.Hide();
                ProductLink = null;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridProductLink_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridProductLink.SelectedRows.Count <= 0 || dataGridProductLink.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtBarcode.Text = dataGridProductLink.SelectedRows[0].Cells[1].Value.ToString();
                    txtBarcode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductLink_KeyDown(object sender, KeyEventArgs e)
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
                            this.btnExit.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 009.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridProductLink_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridProductLink.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Product Link", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObjProductLink.ProductCode = dataGridProductLink.SelectedRows[0].Cells[0].Value.ToString();
                        ObjProductLink.Barcode = dataGridProductLink.SelectedRows[0].Cells[1].Value.ToString();
                        ObjProductLink.DeleteProductDetaile(false);
                        ObjProductLink.GetTempProductLink();
                        dataGridProductLink.DataSource = ObjProductLink.TempProductLink.Tables["dsProductLinkTemp"];
                        dataGridProductLink.Refresh();
                        btnApply.Enabled = true;
                        txtBarcode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            //ProductLinkApply
            try
            {
                ObjProductLink.ProductCode = txtProductCode.Text.Trim().ToUpper();
                ObjProductLink.ProductLinkApply();
                MessageBox.Show("Product Link Applied Successfully ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Dispose();
                ProductLink  = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductLink 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductLink_Load(object sender, EventArgs e)
        {

        }

        private void btnClearAllData_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridProductLink.RowCount > 0)
                {
                    ObjProductLink.ProductCode = txtProductCode.Text.Trim().ToString();
                    ObjProductLink.Barcode = "";
                    ObjProductLink.DeleteProductDetaile(true);
                    ObjProductLink.GetTempProductLink();
                    dataGridProductLink.DataSource = ObjProductLink.TempProductLink.Tables["dsProductLinkTemp"];
                    dataGridProductLink.Refresh();
                    MessageBox.Show("Record cleared successfully", "Product Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnApply.Enabled = true;
                    txtBarcode.Focus();
                }
                else
                {
                    MessageBox.Show("Record not found to clear", "Product Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarcode.Focus();
                }
            }
            catch (Exception myVar)
            {
                clsClear.ErrMessage(myVar.Message.ToString(), myVar.StackTrace.ToString());
            }
        }
    }
}