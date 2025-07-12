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
    public partial class frmProductPriceLevelDetails : Form
    {
        public frmProductPriceLevelDetails(string strProdCode, string strProdName)
        {
            InitializeComponent();
            this.txtProductCode.Text = strProdCode;
            this.txtProductName.Text = strProdName;
            this.RefreshPriceLevels();
        }

        frmSearch search = new frmSearch();

        clsProductPriceMaste objProductPriceMaste = new clsProductPriceMaste();

        private static frmProductPriceLevelDetails getFrmPriceLevelDet;
        public static frmProductPriceLevelDetails _getFrmPriceLevelDet
        {
            get { return getFrmPriceLevelDet; }
            set { getFrmPriceLevelDet = value; }
        }


        public void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.RefreshPriceLevels();


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

        private void RefreshPriceLevels()
        {
            try
            {
                //objProductPriceMaste._Line = 0;
                txtProductCode.Text = txtProductCode.Text.ToUpper();
                objProductPriceMaste.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, CAST(product.Purchase_price AS DECIMAL(18,2)) [Purchase_price], CAST(product.Selling_Price AS DECIMAL(18,2)) [Selling_Price], product.Pack_Size, product.Unit, Supplier_Id, product.Cost_Code, CAST(product.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(product.Whole_Price AS DECIMAL(18,2)) [Whole_Price], CAST(product.Last_Pur_Price AS DECIMAL(18,2)) [Last_Pur_Price] FROM product WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F' ";
                objProductPriceMaste.ReadProductDetails();
                if (objProductPriceMaste.RecordFound == true)
                {
                    txtProductName.Text = objProductPriceMaste.ProductName;

                    objProductPriceMaste.ProductCode = txtProductCode.Text.Trim();
                    objProductPriceMaste.ProductName = txtProductName.Text.Trim();
                    objProductPriceMaste.LoadPriceLevelTemp();
                    objProductPriceMaste.GetTempDataset();
                    dataGridViewProductPriceLevel.DataSource = null;
                    dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet.Tables["dsPriceMasterDetails"];
                    dataGridViewProductPriceLevel.Refresh();


                    txtSellingPrice.Text = (string)objProductPriceMaste.SellingPrice.ToString();
                    lblPurchasingPrice.Text = (string)objProductPriceMaste.PurchasingPrice.ToString();
                    txtMarkedPrice.Text = (string)objProductPriceMaste.MarkedPrice.ToString();
                    txtWholeSalePrice.Text = (string)objProductPriceMaste.WholeSalePrice.ToString();
                    lblLastPurPrice.Text = (string)objProductPriceMaste.LastPurchasePrice.ToString();
                    txtMarkedPrice.Enabled = true;
                    txtSellingPrice.Enabled = true;
                    txtWholeSalePrice.Enabled = true;
                   
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

        public void PriceBatchColor()
        {
            try
            {
                if (dataGridViewProductPriceLevel.Rows.Count <= 0 || dataGridViewProductPriceLevel.Rows[0].Cells[0].Value == null)
                {
                    return;
                }

                int maxRow = dataGridViewProductPriceLevel.Rows.Count;
                for (int i = 0; i < maxRow; i++)
                {
                    int currentBatch = int.Parse(dataGridViewProductPriceLevel.Rows[i].Cells[0].Value.ToString());
                    objProductPriceMaste.GetCurrentRowColor("SELECT BatchColor from tb_PriceBatchColor WHERE (BatchNo = " + currentBatch + ")");
                    dataGridViewProductPriceLevel.Rows[i].DefaultCellStyle.BackColor = Color.FromName(objProductPriceMaste._currentRowColor);

                }


                //Check priceBatch
                //foreach (DataGridViewRow row in dataGridViewProductPriceLevel.Rows)
                //{
                //    if (Convert.ToInt16(row.Cells[0].Value.ToString()) == 1)
                //    {
                //        //row.DefaultCellStyle.BackColor = Color.Beige;
                //        row.DefaultCellStyle.BackColor = Color.FromName("Beige");
                //    }
                //    else if (Convert.ToInt16(row.Cells[0].Value.ToString()) == 2)
                //    {
                //        //row.DefaultCellStyle.BackColor = Color.MediumAquamarine;
                //        row.DefaultCellStyle.BackColor = Color.MediumAquamarine;
                //    }
                //    else if (Convert.ToInt16(row.Cells[0].Value.ToString()) == 3)
                //    {
                //        //row.DefaultCellStyle.BackColor = Color.CadetBlue;
                //        row.DefaultCellStyle.BackColor = Color.CadetBlue;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProductPriceLevel_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            PriceBatchColor();
        }

        private void frmProductPriceLevelDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                getFrmPriceLevelDet = null;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            objProductPriceMaste.DeleteAllTempData();
            objProductPriceMaste.GetTempDataset();
            dataGridViewProductPriceLevel.DataSource = objProductPriceMaste.TempPriceLevelDet;
            dataGridViewProductPriceLevel.DataSource = null;
            dataGridViewProductPriceLevel.Refresh();
            txtProductCode.Text = "";
            txtProductName.Text = "";
            txtMarkedPrice.Text = "";
            txtSellingPrice.Text = "";
            txtWholeSalePrice.Text = "";
            lblLastPurPrice.Text = "0.00";
            lblPurchasingPrice.Text="0.00";
            this.RefreshPriceLevels();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    }
}