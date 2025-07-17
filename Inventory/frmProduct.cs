using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Inventory.Properties;
using clsLibrary;

namespace Inventory
{
    public partial class frmProduct : Form
    {
        frmSalesInquary bincard = new frmSalesInquary();
        public frmProduct(string Code)
        {
            InitializeComponent();
            this.txtCode.Text = Code;
            likViewbincard.LinkClicked +=new LinkLabelLinkClickedEventHandler(bincard.btnDisplay_Click);
        }
        private string strPropClose;
        bool prodSearching = Settings.Default.Searching;
        public string PropClose
        {
            get { return strPropClose; }
            set { strPropClose = value; }
        }

        private static frmProduct product;
        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();
        private clsProduct prod = new clsProduct();
        private string strDisc;
        private int intPosOfPrec;
        private decimal fltDiscPer;
        private decimal decAmount;
        private string strNextProductCode;
        private Int64 intNextProductCode;
        private decimal decPurchasePrice;
        private decimal decSellingPrice;
        private decimal decMargine;

        int Err;
        public static frmProduct GetProduct
        {
            get { return product; }
            set { product = value; }
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    //if (search.Code != null && search.Code != "")
            //    //{
            //    //    txtCode.Text = search.Code.Trim(); ;
            //    //    txtDescript.Text = search.Descript.Trim();
            //    //}
            //    //search.Code = string.Empty;
            //    //search.Descript = string.Empty;
            //}
            //catch (Exception ex)
            //{
            //    //Write to Log
            //    DateTime dtCurrentDate = DateTime.Now;
            //    FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
            //    StreamWriter m_streamWriter = new StreamWriter(fileStream);
            //    try
            //    {
            //        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
            //        // read from file or write to file
            //    }
            //    finally
            //    {
            //        m_streamWriter.Close();
            //        fileStream.Close();
            //    }
            //    MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnProdsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductSearch.IsDisposed)
                {
                    ProductSearch = new frmProductSearch();

                    
                }
                if (chkAllItem.Checked==true) 
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name], Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' order by P.Prod_Code";
                    //chkAllItem.Checked = false;
                }
                else if (txtSupCode.Text.Trim() != string.Empty && txtCode.Text.Trim() == string.Empty && txtDescript.Text.Trim() == string.Empty && txtDepCode.Text.Trim() == string.Empty && txtDepDescript.Text.Trim() == string.Empty && txtCatCode.Text.Trim() == string.Empty && txtCatDescript.Text.Trim() == string.Empty && txtBrandCode.Text == string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name], Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Supplier_Id LIKE '%'+'" + txtSupCode.Text.Trim() + "'+'%' order by P.Prod_Code";

                }
               else if (txtCode.Text.Trim() == string.Empty && txtDepCode.Text.Trim() != string.Empty && txtCatCode.Text.Trim() != string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Department_Id = '" + txtDepCode.Text.Trim() + "' and P.Category_Id = '" + txtCatCode.Text.Trim() + "' order by P.Prod_Code";
                }
                else if (txtCode.Text.Trim() == string.Empty && txtDepCode.Text.Trim() != string.Empty && txtCatCode.Text.Trim() == string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Department_Id = '" + txtDepCode.Text.Trim() + "' order by P.Prod_Code";
                }
                else if (txtCode.Text.Trim() != string.Empty && txtDepCode.Text.Trim() == string.Empty && txtCatCode.Text.Trim() == string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Prod_Code Like '%" + txtCode.Text.Trim() + "%' order by P.Prod_Code";
                }
                else if (txtCode.Text.Trim() != string.Empty && txtDepCode.Text.Trim() != string.Empty && txtCatCode.Text.Trim() != string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Department_Id = '" + txtDepCode.Text.Trim() + "' and P.Category_Id = '" + txtCatCode.Text.Trim() + "' and P.Prod_Code Like '%" + txtCode.Text.Trim() + "%' order by P.Prod_Code";
                }
                else if (txtCode.Text.Trim() == string.Empty && txtDepCode.Text.Trim() == string.Empty && txtCatCode.Text.Trim() == string.Empty && txtDescript.Text.Trim() != string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Prod_Name Like '%" + txtDescript.Text.Trim() + "%' order by P.Prod_Code";
                }
                else if (txtSupCode.Text.Trim() != string.Empty && txtBrandCode.Text != string.Empty && txtDepCode.Text.Trim() == string.Empty && txtCatCode.Text.Trim() == string.Empty)
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.Supplier_Id = '" + txtSupCode.Text.Trim() + "' AND Brand_Code='" + txtBrandCode.Text.Trim() + "' order by P.Prod_Code";

                }
                else
                {
                    prod.SqlString = "SELECT top 300 P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name],  Supplier_Id [Supplier], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock],p.LockedItem FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' order by P.Prod_Code";
                }
                    
                //prod.SqlString = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name]FROM Product";
                prod.RetrieveFields_ProductNo();
                ProductSearch.dgSearch.DataSource = prod.GetDataset1.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.prop_Focus = txtCode;
                ProductSearch.Show();
                ProductSearch.Location = new Point(this.Location.X, this.Location.Y+170);
                ProductSearch.dgSearch.Columns[8].Visible = false;
                ProductSearch.dgSearch.CellFormatting += dataGridView1_CellFormatting;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int lockedColumnIndex = ProductSearch.dgSearch.Columns["LockedItem"].Index;

            // Check if the current row's "Locked" column contains the value "T"
            if (ProductSearch.dgSearch.Rows[e.RowIndex].Cells[lockedColumnIndex].Value != null &&
                ProductSearch.dgSearch.Rows[e.RowIndex].Cells[lockedColumnIndex].Value.ToString() == "T")
            {
                // Loop through all cells in the current row and set the font color
                foreach (DataGridViewCell cell in ProductSearch.dgSearch.Rows[e.RowIndex].Cells)
                {
                    cell.Style.ForeColor = Color.Red;
                }
            }
            else
            {
                // Optional: Reset the color if the condition is not met
                foreach (DataGridViewCell cell in ProductSearch.dgSearch.Rows[e.RowIndex].Cells)
                {
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }
        private void txtDepCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtDepCode.Text = search.Code.Trim();
                    txtDepDescript.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
                if (txtDepCode.Text == string.Empty)
                {
                    txtDepCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDepDescript_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtDepCode.Text.Trim() == String.Empty && txtDepDescript.Text.Trim() != string.Empty)
                {
                    prod.SqlString = "SELECT Dept_Code AS [Department Code] ,Dept_Name AS [Department Name]FROM Department WHERE Dept_Name LIKE '%" + txtDepDescript.Text.Trim() + "%'";
                }
                else
                {
                    if (txtDepCode.Text.Trim() != String.Empty && txtDepDescript.Text.Trim() == string.Empty)
                    {
                        prod.SqlString = "SELECT Dept_Code AS [Department Code] ,Dept_Name AS [Department Name]FROM Department WHERE Dept_Code LIKE '%" + txtDepCode.Text.Trim() + "%'";
                    }
                    else
                    {
                        prod.SqlString = "SELECT Dept_Code AS [Department Code] ,Dept_Name AS [Department Name]FROM Department";
                    }
                }
                prod.RetrieveFields_Department();
                search.dgSearch.DataSource = prod.GetDataset1.Tables["dsDept"];
                search.prop_Focus = txtDepCode;
                search.Show();
                search.Location = new Point(this.Location.X + 125, this.Location.Y + 75);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCatCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCatCode.Text = search.Code.Trim();
                    txtCatDescript.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
                if (txtCatCode.Text != string.Empty && txtCatDescript.Text.Trim() == string.Empty)
                {
                    btnSupSearch.Focus();
                }
                else
                {
                    txtCatCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCatSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtDepCode.Text == string.Empty)
                {
                    MessageBox.Show("Please Select the Department", "Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDepCode.Focus();
                }
                else
                {
                    if (txtCatCode.Text.Trim() != string.Empty && txtCatDescript.Text.Trim() == string.Empty)
                    {
                        prod.SqlString = "SELECT Cat_Code AS [Category Code],Cat_Name AS [Category Name] FROM Category WHERE Dept_Code = '" + txtDepCode.Text + "' AND Cat_Code LIKE '%" + txtCatCode.Text.Trim() + "%'";
                    }
                    else
                    {
                        if (txtCatCode.Text.Trim() == string.Empty && txtCatDescript.Text.Trim() != string.Empty)
                        {
                            prod.SqlString = "SELECT Cat_Code AS [Category Code],Cat_Name AS [Category Name] FROM Category WHERE Dept_Code = '" + txtDepCode.Text + "' AND Cat_Name LIKE '%" + txtCatDescript.Text.Trim() + "%'";
                        }
                        else
                        {
                            prod.SqlString = "SELECT Cat_Code AS [Category Code],Cat_Name AS [Category Name] FROM Category WHERE Dept_Code = '" + txtDepCode.Text + "'";
                        }
                    }
                    
                    prod.RetrieveFields_Category();
                    search.dgSearch.DataSource = prod.GetDataset1.Tables["dsCategory"];
                    search.prop_Focus = txtCatCode;
                    search.Show();
                    search.Location = new Point(this.Location.X + 115, this.Location.Y + 95);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != string.Empty)
                {
                    txtSupCode.Text = search.Code.Trim();
                    txtSupDescript.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
                if (txtSupCode.Text != string.Empty && txtSupDescript.Text.Trim() == string.Empty)
                {
                    //btnManSearch.Focus();
                }
                else
                {
                    txtSupCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtSupCode.Text.Trim() != string.Empty && txtSupDescript.Text.Trim() == string.Empty)
                {
                    prod.SqlString = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%"+ txtSupCode.Text.Trim() +"%'";
                }
                else
                {
                    if (txtSupCode.Text.Trim() == string.Empty && txtSupDescript.Text.Trim() != string.Empty)
                    {
                        prod.SqlString = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSupDescript.Text.Trim() + "%'";
                    }
                    else
                    {
                        prod.SqlString = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier";
                    }
                }

                prod.RetrieveFields_Supplier();
                search.dgSearch.DataSource = prod.GetDataset1.Tables["dsSupplier"];
                search.prop_Focus = txtSupCode;
                search.Show();
                search.Location = new Point(this.Location.X + 115, this.Location.Y + 120);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #region Validate whether credit limit contains non numerical character
        internal static bool IsNumeric(string cnt)
        {
            double d;
            try
            {
                d = Double.Parse(cnt);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Validate whether textfeilds contains ' character
        public void validator(Control cnt)
        {
            try
            {
                for (int i = 0; i < cnt.Controls.Count; i++)
                {
                    if ((cnt.Controls[i].GetType() == typeof(TextBox)) && (cnt.Controls[i].Text.Contains("'")))
                    {
                        MessageBox.Show("Invalid characters in Textfeilds Please check the characters entered.", "Invalid character (') found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cnt.Controls[i].Text = string.Empty;
                        cnt.Controls[i].Focus();

                        Err++;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        #endregion 

        public void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnProductPriceMaster.BackColor = Color.AliceBlue;
                    //if (Settings.Default.ImageFromServer == true)
                    //{
                    prod.SqlString = "EXEC dbo.Sp_LoadItemDetails  @ProdCode = '"+txtCode.Text.Trim()+"',@Loca = '"+LoginManager.LocaCode+"' ";
                    //}
                    //else
                    //{
                    //    prod.SqlString = "SELECT P.Prod_Code, P.Prod_Name, P.Short_Description, P.Barcode, P.Department_Id, P.Category_Id, P.Supplier_Id, P.Manufacturer_Id, P.Purchase_price, CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling_Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole_Price], P.Reorder_Level, P.Purchased_Date, P.Last_Purch_Qty, P.Unit, CAST(P.Avarage_Cost AS DECIMAL(18,2)) [Avarage_Cost], P.Reorder_Qty, P.Rack_No, P.Pack_Size, CAST(P.Discontinued AS DECIMAL(18,2)) [Discontinued], P.Created_User, P.Modified_User, P.Created_Date, P.Modified_Date, P.LockedItem, Stock_Master.Loca, Stock_Master.Qty, CAST(P.Disc_Price AS DECIMAL(18,2)) [Disc_Price], P.Disc_Str, P.Cost_Code, P.Margine,  P.Prod_Image, P.Brand_Code, P.Count_False, CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked_Price], CAST(P.Last_Pur_Price AS DECIMAL(18,2)) [Last_Pur_Price], P.CreditBilling, Stock_Master.MinusAllow, Stock_Master.UnderCost, PackQty, P.Singhala, P.Disc_App, P.Loose, P.Scale, P.discountNotAllow, P.ExpireItem,P.VatProd,P.Bundle,P.Grnqty,p.GrnDate,p.RecallGrn FROM Product P INNER JOIN Stock_Master ON P.Prod_Code = Stock_Master.Prod_Code WHERE (P.Prod_Code = '" + txtCode.Text.Trim() + "' OR (P.Barcode = '" + txtCode.Text.Trim() + "' AND LTRIM(RTRIM(P.barcode)) <> '')) AND Stock_Master.Loca = ";
                    //}

                    prod.GetProductDetails();
                    if (prod.RecordFound == true)
                    {
                        txtCode.Text = txtCode.Text.Trim().ToUpper();
                        txtCode.Text = prod.Code;
                        txtDescript.Text = prod.Descript;
                        txtShortDescription.Text = prod.Short_Description;
                        txtBarcode.Text = prod.Barcode.ToUpper();
                        txtDepCode.Text = prod.Department.ToUpper();
                        txtCatCode.Text = prod.Category.ToUpper();
                        txtSupCode.Text = prod.Supplier.ToUpper();
                        txtReOrdrQty.Text = prod.ReorderQty.ToString();

                        txtPurchPrice.Text = prod.Purchaseprice;
                        txtWholeSalePrice.Text = prod.WholePrice;
                        txtSelPrice.Text = prod.SellingPrice;
                        lblDiscounted.Text = string.Empty;
                        lblDiscounted.Text = prod.DiscountPrice;
                        txtDistributePrice.Text = prod.DiscountPrice; 
                        txtMarkedPrice.Text = prod.MarkedPrice;
                        txtminimumPrice.Text = prod.MinimumPrice;
                        
                        
                        lblLastPurchasePrice.Text = prod.LastPurchasePrice;
                        lblLastPurQty.Text = prod.Last_Purch_Qty.ToString();
                        txtReOrderLevl.Text = prod.Reorderlevel;
                        lblCurntQty.Text = prod.CurrentQty.ToString();
                        lblPurDate.Text = prod.PurchaseDate;
                        txtRackNo.Text = prod.Rack_No.ToString();
                        cmbUnit.Text = prod.Unit;
                        txtPackSize.Text = prod.PackSize.ToString();
                        lblAvgCost.Text = prod.Avarage_Cost;
                        lblLastEditDate.Text = prod.Modified_Date;
                        lblCostCode.Text = prod.CostCode;
                        lblMargine.Text = prod.Margine;
                        txtSaleMargin.Text = prod.Margine;
                        chkCreditBilling.Checked = prod.CreditBilling;
                        txtBrandCode.Text = prod.BrandCode;
                        chkMinusAllow.Checked = prod.MinusAllow;
                        chkUnderCost.Checked = prod.UnderCost;
                        txtPackQty.Text = prod.PackQty.ToString();
                        txtSinghalaDescription.Text = prod.SinghalaDescription.ToString();
                        chkPointsAllow.Checked = prod.PointsAllow;
                        chkLoose.Checked = prod.Abs;
                        chkScaleProduct.Checked = prod.ScaleProd;
                        chkExpireItem.Checked = prod._blExpireItem;
                        chkVatProd.Checked = prod._blVatProd;
                        chkbundle.Checked = prod._blBundleProd;

                        txtGRNQTY.Text = prod.GrnQty.ToString();
                        dtpGRNDate.Text = prod.GrnDate;
                        chkCld.Checked = prod.RecallGRN;
                        chkPkt.Checked = prod.PacketingProd;
                        chkFreeIssue.Checked = prod.FreeIsue;
                        chkOgf.Checked = prod.OGF;
                        chkBatchPUpdate.Checked = prod.BatchPUpdate;

                        chkSerialNo.Checked = prod.SerialAllow;
                        chkInstallCharges.Checked = prod.InstallChargeAllow;
                        chkwarntyhandle.Checked = prod.warrentyAllow;

                        cmbwarenty.Text = prod.WarrentyPeriod;
                        txtInstallCharge.Text = prod.InstallCharge.ToString("N2");
                        txtInstallChargePer.Text = prod.InstallChargePer.ToString("N2");
                        
                        // Added by Nipuni - 2024.03.28
                        chkServItem.Checked = prod.ServiceItem;
                        txtServTime.Text = prod.ServiceTime.ToString();
                        chkRentItem.Checked = prod.Rentitem;

                        lblMargineAmount.Text = string.Format("{0:0.00}", decimal.Parse(txtSelPrice.Text) - decimal.Parse(txtPurchPrice.Text));
                        lblDiscounted.Text = prod.DiscountPrice;// string.Format("{0:0.00}", decimal.Parse(txtSelPrice.Text) - decimal.Parse(txtPurchPrice.Text));
                        prod.SqlString = "SELECT  Location.Loca, Location.Loca_Descrip, ISNULL(Qty,0)Qty, Address1 FROM Stock_Master INNER JOIN Location ON Stock_Master.Loca = Location.Loca    WHERE Stock_Master.Prod_Code='" + txtCode.Text.Trim() + "' and TaxLoca='" + LoginManager.TaxLocaLogin + "' order by Location.Loca";
                        prod.newReader();
                        lvLocaQty.Items.Clear();
                        while (prod.Dr.Read())
                        {
                            ListViewItem list = new ListViewItem(prod.Dr[0].ToString());
                            for (int i = 1; i < prod.Dr.FieldCount; i++)
                            {
                                list.SubItems.Add(prod.Dr[i].ToString());

                            }
                            lvLocaQty.Items.Add(list);
                            int count = lvLocaQty.Items.Count;
                            if (count % 2 == 1)
                            {
                                list.BackColor = System.Drawing.Color.DeepSkyBlue;
                            }
                            else
                            {
                                list.BackColor = Color.White;
                            }
                        }
                        try
                        {
                            if (prod.ProductImage == null)
                            {
                                PictureProduct.Image = global::Inventory.Properties.Resources.DefaultImage;
                            }
                            else
                            {
                                Byte[] byteBLOBData = new Byte[0];
                                //MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                                byteBLOBData = prod.ProductImage;
                                MemoryStream stmBLOBData = new MemoryStream(prod.ProductImage);
                                PictureProduct.Image = Image.FromStream(stmBLOBData);
                            }
                        }
                        catch
                        {
                            //Set Default Image
                            PictureProduct.Image = global::Inventory.Properties.Resources.DefaultImage;
                        }
                        if (prod.LockedItem == "T")
                        {
                            DesabledControl(false);
                            chkTransactionLock.Checked = true;
                        }
                        else
                        {
                            DesabledControl(true);
                            chkTransactionLock.Checked = false;
                        }
                        //discount Not Allow
                        if (prod._strDisCountNotAllow=="T")
                        {
                            chkDisNotAllow.Checked = true;
                        }
                        else
                        {
                            chkDisNotAllow.Checked = false;
                        }


                        //check Pricce Change Allow
                        if (chkTransactionLock.Checked == false)
                        {
                            if (LoginManager.PriceChange.Trim() == "F")
                            {
                                txtPurchPrice.Enabled = false;
                                txtSelPrice.Enabled = false;
                                txtWholeSalePrice.Enabled = false;
                                txtDistributePrice.Enabled = false;
                                txtMarkedPrice.Enabled = false;
                                txtminimumPrice.Enabled = false;
                            }
                            else
                            {
                                txtPurchPrice.Enabled = true;
                                txtSelPrice.Enabled = true;
                                txtWholeSalePrice.Enabled = true;
                                txtDistributePrice.Enabled = true;
                                txtMarkedPrice.Enabled = true;
                                txtminimumPrice.Enabled = true;
                            }
                        }
                        //*******
                        txtDiscount.Text = prod.Disc_Str;
                        lblCreatedUser.Text = prod.Created_User;
                        lblModifiedUser.Text = prod.Modified_User;
                        //Display Departemnt
                        prod.SqlString = "SELECT Dept_Code,Dept_Name FROM Department WHERE Dept_Code = '" + txtDepCode.Text.Trim() + "'";
                        prod.DeptRead();
                        txtDepDescript.Text = prod.DepartmentName;

                        //Display Category
                        prod.SqlString = "SELECT Cat_Code, Cat_Name FROM Category WHERE Cat_Code = '" + txtCatCode.Text.Trim() + "'";
                        prod.CategoryRead();
                        txtCatDescript.Text = prod.CategoryName;

                        //Display Supplier
                        prod.SqlString = "SELECT Supp_Code, Supp_Name FROM Supplier WHERE Supp_Code = '" + txtSupCode.Text.Trim() + "'";
                        prod.SupplierRead();
                        txtSupDescript.Text = prod.SupplierName;

                        ////Display Manufacturer
                        //prod.SqlString = "SELECT Manf_Code, Manf_Name FROM manufacturer WHERE Manf_Code = '" + txtManCode.Text.Trim() + "'";
                        //prod.ManufacturerRead();
                        //txtManDescript.Text = prod.ManufacturerName;

                        //Display Brand
                        prod.SqlString = "SELECT Brand_Code, Brand_Name FROM Brand WHERE Brand_Code = '" + txtBrandCode.Text.Trim() + "'";
                        prod.BrandRead();
                        txtBrandName.Text = prod.BrandName;
                       

                        if (prod.PriceLevelFound)
                        {
                            btnProductPriceMaster.BackColor = Color.Red ;
                        }
                        else
                        {
                            btnProductPriceMaster.BackColor = Color.AliceBlue ;
                        }

                        txtPurchPrice.Focus();
                    }
                    else
                    {
                        txtPurchPrice.Enabled = true;
                        txtSelPrice.Enabled = true;
                        txtWholeSalePrice.Enabled = true;
                        txtDistributePrice.Enabled = true;
                        txtMarkedPrice.Enabled = true;
                        txtminimumPrice.Enabled = true;
                        txtDescript.Focus();
                    }

                }
                else if (e.KeyCode == Keys.F1)
                {
                    this.btnProdsearch.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDepCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Display Departemnt

                    if (txtDepCode.Text.Trim() != "")
                    {
                        txtDepCode.Text = txtDepCode.Text.ToUpper();
                        prod.SqlString = "SELECT Dept_Code,Dept_Name FROM Department WHERE Dept_Code = '" + txtDepCode.Text.Trim() + "'";
                        prod.DeptRead();
                        if (prod.RecordFound == true)
                        {
                            txtDepDescript.Text = prod.DepartmentName;
                            txtCatCode.Focus();
                        }
                        else
                        {
                            txtDepDescript.Text = string.Empty;
                            MessageBox.Show("Department Code Not Found. Please Check Department Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDepCode.Focus();
                        }
                    }
                }
                else if (e.KeyCode==Keys.F1)
                {
                    this.btnDepDescript.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCatCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Display Category
                    if (txtCatCode.Text.Trim() != "")
                    {
                        txtCatCode.Text = txtCatCode.Text.ToUpper();
                        prod.SqlString = "SELECT Cat_Code, Cat_Name FROM Category WHERE Dept_Code = '" + txtDepCode.Text.Trim() + "' and Cat_Code = '" + txtCatCode.Text.Trim() + "'";
                        prod.CategoryRead();
                        if (prod.RecordFound == true)
                        {
                            txtCatDescript.Text = prod.CategoryName.ToUpper();
                            //Generate New Product Code
                            if (chkNextItemCode.Checked == true && txtCode.Text.Trim() == String.Empty && txtDepCode.Text.Trim() != String.Empty && txtCatCode.Text.Trim() != String.Empty)
                            {
                                //if (Settings.Default.CodeGenOrder == true)
                                //{
                                //    prod.SqlString = "SELECT MAX(Prod_Code) Prod_Code FROM Product WHERE Prod_Code LIKE '" + txtCatCode.Text.Trim() + "%' AND Department_Id = '" + txtDepCode.Text.Trim() + "' AND Category_Id = '" + txtCatCode.Text.Trim() + "'";
                                //}
                                //else
                                //{
                                //    prod.SqlString = "SELECT MAX(Prod_Code) Prod_Code FROM product WHERE ISNUMERIC(Prod_Code)>0 ORDER BY Prod_Code";
                                //}
                                prod.SqlString = "EXEC dbo.Sp_GetNextProdCode  @DeptCode = '"+txtDepCode.Text.Trim()+"',@CatCode = '"+txtCatCode.Text.Trim()+"' ";
                                prod.ReadMaxProductCode();
                                strNextProductCode = prod.NextProductCode;
                                if (clsValidation.isNumeric(strNextProductCode, System.Globalization.NumberStyles.Number) == true)
                                {
                                    intNextProductCode = Int64.Parse(strNextProductCode) + 1;
                                    prod.SqlString = "SELECT Prod_Code from Product WHERE Prod_Code = '" + intNextProductCode.ToString().Trim().ToUpper() + "'";
                                    prod.ReadProductCode();
                                    if (prod.RecordFound != true)
                                    {
                                        txtCode.Text = intNextProductCode.ToString();
                                        txtSupCode.Focus();
                                    }
                                    else
                                    {
                                        txtCatCode.Focus();
                                    }

                                }
                                else
                                {
                                    txtSupCode.Focus();
                                }


                            }
                            else
                            {
                                txtSupCode.Focus();
                            }
                        }
                        else
                        {
                            txtCatDescript.Text = string.Empty;
                            MessageBox.Show("Category Code Not Found. Please Check Category Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCatCode.Focus();
                        }
                    }
                }
                else if (e.KeyCode == Keys.F1)
                {
                    this.btnCatSearch.PerformClick();
                }
                //if (chkAllItem.Checked == true)
                //{
                //    //prod.SqlString = "SELECT MAX(Prod_Code) Prod_Code FROM Product WHERE Department_Id = '" + txtDepCode.Text.Trim() + "' AND Category_Id = '" + txtCatCode.Text.Trim() + "'";
                //    prod.SqlString = "SELECT MAX(Prod_Code) Prod_Code FROM product WHERE ISNUMERIC(Prod_Code)>0 ORDER BY Prod_Code";
                //    prod.ReadMaxProductCode();
                //    strNextProductCode = prod.NextProductCode;
                //    if (clsValidation.isNumeric(strNextProductCode, System.Globalization.NumberStyles.Number) == true)
                //    {
                //        intNextProductCode = Int64.Parse(strNextProductCode) + 1;
                //        prod.SqlString = "SELECT Prod_Code from Product WHERE Prod_Code = '" + intNextProductCode.ToString().Trim().ToUpper() + "'";
                //        //prod.SqlString = "SELECT MAX(Prod_Code) Prod_Code FROM product WHERE ISNUMERIC(Prod_Code)>0 ORDER BY Prod_Code";
                //        prod.ReadProductCode();
                //        if (prod.RecordFound != true)
                //        {
                //            txtCode.Text = intNextProductCode.ToString();
                //            txtDescript.Focus();
                //        }
                //        else
                //        {
                //            txtCatCode.Focus();
                //        }

                //    }
                //}
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Display Supplier
                    if (txtSupCode.Text.Trim() != "")
                    {
                        txtSupCode.Text = txtSupCode.Text.ToUpper();
                        prod.SqlString = "SELECT Supp_Code, Supp_Name FROM Supplier WHERE Supp_Code = '" + txtSupCode.Text.Trim() + "'";
                        prod.SupplierRead();
                        if (prod.RecordFound == true)
                        {
                            txtSupDescript.Text = prod.SupplierName;
                            //txtManCode.Focus();
                            txtBrandCode.Focus();
                        }
                        else
                        {
                            txtSupDescript.Text = string.Empty;
                            MessageBox.Show("Supplier Code Not Found. Please Check Supplier Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSupCode.Focus();
                        }
                    }
                }
                else if (e.KeyCode == Keys.F1)
                {
                    this.btnSupSearch.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    //Display Barcode
                    prod.SqlString = " EXEC dbo.Sp_GetCostFromCode  @Code ='" + txtBarcode.Text.Trim() + "'";
                    prod.GetCostPrice();
                    if (prod.Purchaseprice != "")
                    {
                        txtPurchPrice.Text = prod.Purchaseprice;
                    }

                    if (txtCode.Text.Trim() == "")
                    {
                        prod.SqlString = "SELECT Product.Prod_Code, Product.Barcode FROM product LEFT JOIN tbProductLink ON Product.Prod_Code = tbProductLink.Prod_Code WHERE Product.Barcode = '" + txtBarcode.Text.Trim() + "' OR tbProductLink.Barcode='" + txtBarcode.Text.Trim() + "'";
                        prod.BarcodeRead();
                        txtCode.Text = prod.Code;
                        txtCode.Focus();
                    }
                    else if (txtBarcode.Text.Trim() != "")
                    {
                        prod.SqlString = "SELECT Product.Prod_Code, Product.Barcode FROM Product LEFT JOIN tbProductLink ON Product.Prod_Code = tbProductLink.Prod_Code WHERE (Product.Barcode = '" + txtBarcode.Text.Trim() + "' OR tbProductLink.Barcode='" + txtBarcode.Text.Trim() + "') AND Product.Prod_Code <> '" + txtCode.Text.Trim() + "'";
                        prod.BarcodeReadForDuplicate();
                        if (prod.Code != string.Empty)
                        {
                            MessageBox.Show("Barcode Already Using for Other Product.", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          
                         
                        }
                         

                       
                        txtShortDescription.Focus();
                    }
                    else
                    {
                        txtShortDescription.Focus();
                    }


                }
                else if (e.KeyCode == Keys.Up)
                {
                    txtCode.Focus();
                    txtCode.SelectAll();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDescript_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDescript.Text.Trim() != "")
                    {
                        if (txtShortDescription.Text.Trim() == string.Empty)
                        {
                            if (txtDescript.Text.Trim().Length <= 30)
                            {
                                txtShortDescription.Text = txtDescript.Text.Trim().Substring(0, txtDescript.Text.Trim().Length);
                            }
                            else
                            {
                                txtShortDescription.Text = txtDescript.Text.Trim().Substring(0, 30);
                            }
                        }
                        txtBarcode.Focus();
                    }
                }
                else if (e.KeyCode == Keys.F1)
                {
                    this.btnProdsearch.PerformClick();
                }

                //Serch ON OFF
                if (e.KeyCode == Keys.F5)
                {
                    if (prodSearching == true)
                    {
                        prodSearching = false;
                        txtCode.BackColor = Color.Empty;
                        txtDescript.BackColor = Color.Empty;
                        ProductSearch.Hide();
                        //ProductSearchImg.Hide();

                        Settings.Default.Searching = false;
                        Settings.Default.Save();
                    }
                    else
                    {
                        prodSearching = true;
                        txtCode.BackColor = Color.MediumAquamarine;
                        txtDescript.BackColor = Color.MediumAquamarine;
                        Settings.Default.Searching = true;
                        Settings.Default.Save();
                    }
                }

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPurchPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtPurchPrice.Text) == true)
                    {

                        //prod.CreateCostCode();
                        //Mindada 02022011
                        //string XCode = "", Dup = "", Dup2 = "";
                        //decimal AD = (decimal.Parse(txtPurchPrice.Text.Trim()) + (decimal)0.01);
                        //string AC = AD.ToString();
                        //string Cost = AC.Substring(0, AC.IndexOf('.', 0));
                        //string A = "", B = "", C = "", D = "", E = "", F = "", G = "", H = "", I = "";
                        //prod.costCode("EXEC sp_CostCode '" + Cost + "'", ref A, ref B, ref C, ref D, ref E, ref F, ref G, ref H, ref I);
                        //prod.GetXCode(ref XCode, " SELECT xCode FROM tbCostCodeInfo");
                        //lblCostCode.Text = A + B + C + D + E + F + G + H + I;
                        //string Costs = "";
                        //for (int i = 0; i < lblCostCode.Text.Length; i++)
                        //{
                        //    Dup = lblCostCode.Text.Substring(i, 1);
                        //    if (Dup == Dup2 && Costs.Substring(Costs.Length - 1, 1) != "X")
                        //    {

                        //        Costs = Costs + XCode;
                        //    }
                        //    else
                        //    {
                        //        Dup2 = Dup;
                        //        Costs += Dup;
                        //    }
                        //}
                        lblCostCode.Text = clsCommon.CostCodeGenrate(Convert.ToDecimal(txtPurchPrice.Text));
                        txtWholeSalePrice.Focus();
                        txtWholeSalePrice.SelectAll();

                        decimal SellPrice = 0;

                        if (chkMargine.Visible == true)
                        {
                            if (chkMargine.Checked == true)
                            {
                                if (chkVatProd.Checked == false)
                                {
                                    decimal WithVat = Convert.ToDecimal(txtPurchPrice.Text.Trim()) + ((Convert.ToDecimal(txtPurchPrice.Text.Trim()) * Settings.Default.VatPrecentage) / 100);
                                    SellPrice = WithVat + ((WithVat * Convert.ToDecimal(txtSaleMargin.Text.Trim())) / 100);
                                }
                                else
                                {
                                    decimal WithVat = Convert.ToDecimal(txtPurchPrice.Text.Trim());
                                    SellPrice = WithVat + ((WithVat * Convert.ToDecimal(txtSaleMargin.Text.Trim())) / 100);
                                }

                                txtSaleMargin.Text = Convert.ToDecimal(txtSaleMargin.Text.Trim()).ToString("N2");
                                txtSelPrice.Text =  txtWholeSalePrice.Text = SellPrice.ToString("N2");
                                txtSelPrice_Leave(new object(), e);
                            }
                            else
                            {

                                if (chkVatProd.Checked == false)
                                {
                                    decimal marge = ((Convert.ToDecimal(txtWholeSalePrice.Text.Trim())) / (100 + Convert.ToDecimal(txtSaleMargin.Text))) * (Convert.ToDecimal(txtSaleMargin.Text.Trim()));
                                    decimal Purchwithwat = Convert.ToDecimal(txtWholeSalePrice.Text) - (marge);
                                    decimal Purchwithoutwat = Purchwithwat - (Purchwithwat / (100 + Convert.ToDecimal(Settings.Default.VatPrecentage))) * Settings.Default.VatPrecentage;
                                    txtPurchPrice.Text = Purchwithoutwat.ToString("N2");

                                }
                                else
                                {
                                    decimal Purchwithwat = Convert.ToDecimal(txtWholeSalePrice.Text) - ((Convert.ToDecimal(txtWholeSalePrice.Text.Trim())) / (100 + Convert.ToDecimal(txtSaleMargin.Text.Trim()))) * Convert.ToDecimal(txtSaleMargin.Text.Trim());
                                    txtPurchPrice.Text = Purchwithwat.ToString("N2");
                                }

                                txtSaleMargin.Text = Convert.ToDecimal(txtSaleMargin.Text.Trim()).ToString("N2");
                                txtSelPrice.Text =  txtWholeSalePrice.Text;
                                txtSelPrice_Leave(new object(), e);
                            }
                            txtSaleMargin.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtReOrdrQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtReOrdrQty.Text) == true)
                    {
                        cmbUnit.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSelPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtSelPrice.Text) == false)
                    {
                        MessageBox.Show("Invalid Retail Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (chkUnderCost.Checked == false)
                    {
                        if (decimal.Parse(txtSelPrice.Text) < decimal.Parse(txtPurchPrice.Text))
                        {
                            MessageBox.Show("Under Cost Not Allowed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if (txtMarkedPrice.Text.Trim() == string.Empty || Convert.ToDecimal(txtMarkedPrice.Text.Trim()) == 0)
                    {
                        txtMarkedPrice.Text = txtSelPrice.Text;
                    }

                   
                    txtMarkedPrice.Focus();
                    txtMarkedPrice.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtReOrderLevl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtReOrderLevl.Text) == true)
                    {
                        txtReOrdrQty.Focus();
                        //cmbUnit.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbUnit.Text.Trim() != "Select")
                    {
                        txtPackSize.Select();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                clsGrn objGrn = new clsGrn();
                objGrn.CheckedPasswordValid("SELECT Emp_Name,Pass_Word,GRNAPP,POAPP,SRNAPP,TOGAPP,OPBAPP,PRDAPP,BATCAPP FROM dbo.tb_UserRoleSettings Us JOIN dbo.Employee E ON E.UserRole_Id=Us.UserRoleID WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='" + LoginManager.LocaCode + "' AND Us.PRDAPP=1");
                if (objGrn.AccessStatus == false)
                {
                    MessageBox.Show("You Are Not Autherized For This Action", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Settings.Default.ProdCodeLength!=0 &&(Settings.Default.ProdCodeLength != txtCode.Text.Length) == true)
                {
                    MessageBox.Show("Product Code Length Incorrect", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Focus();
                    return;
                }

                if (txtCode.Text.Length > 15)
                {
                    MessageBox.Show("Product Code Length Incorrect", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Focus();
                    return;
                }

                if (PictureProduct.Image == null)
                {
                    PictureProduct.Image = Inventory.Properties.Resources.DefaultImage;
                }


                if (PictureProduct.Image != Inventory.Properties.Resources.DefaultImage)
                {
                    MemoryStream ms = new MemoryStream();
                    PictureProduct.Image.Save(ms, ImageFormat.Jpeg);
                    //Read from MemoryStream into Byte array.
                    Byte[] bytBLOBData = new Byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(bytBLOBData, 0, Convert.ToInt32(ms.Length));
                    prod.ProductImage = bytBLOBData;                 //Product Image
                }

                Err = 0;
                if ((txtCatDescript.Text == string.Empty) || (txtDescript.Text == string.Empty))
                {
                    Err++;
                }
                if ((!IsNumeric(txtPurchPrice.Text)) || (!IsNumeric(txtSelPrice.Text)))
                {
                    Err++;
                }
                this.validator(grpProduct);
                this.validator(grpPrice);

                if (txtGRNQTY.Text.Trim() == string.Empty || clsValidation.isNumeric(txtGRNQTY.Text.Trim(), System.Globalization.NumberStyles.Currency) == false)
                {
                    MessageBox.Show("Invalid GRN Qty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGRNQTY.Text = "0";
                    txtGRNQTY.Focus();
                    return;
                   
                }

                if (txtDescript.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Product Description Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescript.Focus();
                    return;
                }

                if (txtCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Product Code Not Found. You Must Enter a Product Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                    return;
                }

                if (txtShortDescription.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Product Short Description Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShortDescription.Focus();
                    return;
                }

                if (cmbUnit.SelectedIndex == -1)
                {
                    MessageBox.Show("Invalid Unit. Please Select Valid Unit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbUnit.Focus();
                    return;
                }

                if (clsValidation.isNumeric(txtPackSize.Text, System.Globalization.NumberStyles.Number) == false || decimal.Parse(txtPackSize.Text) <= 0)
                {
                    MessageBox.Show("Invalid Pack Size. Please Select Valid Pack Size.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPackSize.Focus();
                    return;
                }

                if (clsValidation.isNumeric(txtRackNo.Text, System.Globalization.NumberStyles.Number) == false || decimal.Parse(txtRackNo.Text) <= 0)
                {
                    MessageBox.Show("Invalid Rack Number. Please Select Valid Rack Number.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRackNo.Focus();
                    return;
                }

                prod.SqlString = "SELECT TOP 1 Prod_Code, Prod_Name, Short_Description FROM Product WHERE Prod_Code <> '" + txtCode.Text.ToString().ToUpper() + "' AND Prod_Name LIKE '" + txtDescript.Text.Trim().ToUpper() + "'";
                prod.ProductRead();
                if (prod.RecordFound == true)
                {
                    MessageBox.Show("This product code is already exists\n\rCode is : "+prod.Code.ToString()+"", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescript.Focus();
                    txtDescript.SelectAll();
                    return;
                }

                prod.SqlString = "SELECT Dept_Code,Dept_Name FROM Department WHERE Dept_Code = '" + txtDepCode.Text.Trim() + "'";
                prod.DeptRead();
                if (prod.RecordFound != true)
                {
                    MessageBox.Show("Department Code Not Found. Please Check Department Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDepCode.Focus();
                    return;
                }

                prod.SqlString = "SELECT Cat_Code, Cat_Name FROM Category WHERE Dept_Code = '" + txtDepCode.Text.Trim() + "' and Cat_Code = '" + txtCatCode.Text.Trim() + "'";
                prod.CategoryRead();
                if (prod.RecordFound != true)
                {
                    txtCatDescript.Text = string.Empty;
                    MessageBox.Show("Category Code Not Found. Please Check Category Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCatCode.Focus();
                    return;
                }

             

                prod.SqlString = "SELECT Supp_Code, Supp_Name FROM Supplier WHERE Supp_Code = '" + txtSupCode.Text.Trim() + "'";
                prod.SupplierRead();
                if (prod.RecordFound != true)
                {
                    txtSupDescript.Text = string.Empty;
                    MessageBox.Show("Supplier Code Not Found. Please Check Supplier Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupCode.Focus();
                    return;
                }


                prod.SqlString = "SELECT Brand_Code, Brand_Name FROM Brand WHERE Brand_Code = '" + txtBrandCode.Text.Trim() + "'";
                prod.BrandRead();
                if (prod.RecordFound != true)
                {
                    txtBrandName.Text = string.Empty;
                    MessageBox.Show("Brand Code Not Found. Please Check Brand Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrandCode.Focus();
                    return;
                }

                prod.SqlString = "SELECT Prod_Code, Prod_Name,Short_Description FROM Product WHERE Prod_Code = '" + txtCode.Text.Trim() + "'";
                prod.ProductRead();
                if (prod.RecordFound == true)
                {
                    string TempProductName;
                    TempProductName = prod.Descript.ToString().Trim();
                    if (LoginManager.ProductDetChange == false && TempProductName != txtDescript.Text.Trim())
                    {
                        MessageBox.Show("Product Code Already Created! You Can Not Change Product Name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCode.Focus();
                        return;
                    }
                    else if (LoginManager.ProductDetChange == false && prod.Short_Description.ToString().Trim() != txtShortDescription.Text.Trim())
                    {
                        MessageBox.Show("Product Code Already Created ! You Can Not Change Short Deacription", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCode.Focus();
                        return;
                    }

                    else
                    {
                        clsLibrary.LoginManager.ProductDetChange = false;
                    }
                }

                prod.SqlString = "SELECT Prod_Code from Product WHERE Prod_Code = '" + txtCode.Text.Trim().ToUpper() + "'";
                prod.ReadProductCode();
                if (prod.RecordFound == true)
                {
                    if (MessageBox.Show("Product Code Already Created. Do You wan't to Replace This Product Details. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        txtCode.Focus();
                        return;
                    }
                }


                if (decimal.Parse(txtWholeSalePrice.Text) < 0)
                {
                    MessageBox.Show("Invalid Whole Sale Price.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWholeSalePrice.Focus();
                    return;
                }

                if (decimal.Parse(txtSelPrice.Text) < 0)
                {
                    MessageBox.Show("Invalid Retail Price.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSelPrice.Focus();
                    return;
                }

                //if (decimal.Parse(txtDistributePrice.Text) < 0)
                //{
                //    MessageBox.Show("Invalid Distribution Price.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtDistributePrice.Focus();
                //    return;
                //}

                if (decimal.Parse(txtMarkedPrice.Text) < 0)
                {
                    MessageBox.Show("Invalid Modern Marked Price.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMarkedPrice.Focus();
                    return;
                }


                if (chkUnderCost.Checked==false)
                {
                    if (decimal.Parse(txtWholeSalePrice.Text) < decimal.Parse(txtPurchPrice.Text))
                    {
                        MessageBox.Show("Under Cost Not Allowed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtWholeSalePrice.Focus();
                        return;
                    }
                    if (decimal.Parse(txtSelPrice.Text) < decimal.Parse(txtPurchPrice.Text))
                    {
                        MessageBox.Show("Under Cost Not Allowed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPurchPrice.Focus();
                        return;
                    }
                    //if (decimal.Parse(txtDiscount.Text) < decimal.Parse(txtPurchPrice.Text))
                    //{
                    //    MessageBox.Show("Under Cost Not Allowed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtDiscount.Focus();
                    //    return;
                    //}
                    if (decimal.Parse(txtMarkedPrice.Text) < decimal.Parse(txtPurchPrice.Text))
                    {
                        MessageBox.Show("Under Cost Not Allowed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMarkedPrice.Focus();
                        return;
                    }
                }                

                if (txtSaleMargin.Text.Trim() == string.Empty)
                {
                    txtSaleMargin.Text = "0";
                }

                if(chkwarntyhandle.Checked==false)
                {
                    cmbwarenty.SelectedIndex = -1;
                }
                else if(chkwarntyhandle.Checked ==true && cmbwarenty.SelectedIndex==-1)
                {
                    MessageBox.Show("Select Warrenty Period.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbwarenty.Focus();
                    return;
                }

                if (chkInstallCharges.Checked == false)
                {
                    txtInstallCharge.Text = txtInstallChargePer.Text = "0.00";
                }
                else if (chkInstallCharges.Checked == true)
                {
                    if(txtInstallCharge.Text.Trim()==string.Empty)
                    {
                        txtInstallCharge.Text = "0";
                    }
                    if (txtInstallChargePer.Text.Trim() == string.Empty)
                    {
                        txtInstallChargePer.Text = "0";
                    }
                    if (Convert.ToDecimal(txtInstallCharge.Text) <= 0 && Convert.ToDecimal(txtInstallChargePer.Text) <= 0)
                    {
                        MessageBox.Show("Select Instalation Charge.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtInstallCharge.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(txtInstallCharge.Text) > 0 && Convert.ToDecimal(txtInstallChargePer.Text) > 0)
                    {
                        MessageBox.Show("Select Instalation Charge Percentage or Amount.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtInstallCharge.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(txtInstallChargePer.Text) > 0 && Convert.ToDecimal(txtInstallChargePer.Text) > 100)
                    {
                        MessageBox.Show("Installation Percentage Cannot Be 100.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtInstallChargePer.Focus();
                        return;
                    }
                }
                if (txtServTime.Text.Trim() == string.Empty || clsValidation.isNumeric(txtServTime.Text)==false)
                {
                    txtInstallCharge.Text = "0";
                }

                if (chkServItem.Checked == true && Convert.ToDecimal(txtServTime.Text) <= 0)
                {
                    MessageBox.Show("Give Time for this Item, You cannot enter 0 or minus value.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServTime.Focus();
                    return;
                }
               

                if (Err == 0)
                {

                    prod.ErrorCode = 0;
                    prod.Code = txtCode.Text.Trim().ToUpper();
                    prod.Descript = txtDescript.Text.Trim();
                    prod.Short_Description = txtShortDescription.Text.Trim();
                    prod.Barcode = txtBarcode.Text.Trim().ToUpper();
                    prod.Department = txtDepCode.Text.Trim().ToUpper();
                    prod.Category = txtCatCode.Text.Trim().ToUpper();
                    prod.Supplier = txtSupCode.Text.Trim().ToUpper();

                    prod.Purchaseprice = txtPurchPrice.Text.Trim().ToUpper();
                    prod.SellingPrice = txtSelPrice.Text.Trim().ToUpper(); //Retail Price
                    prod.WholePrice = txtWholeSalePrice.Text.Trim().ToUpper(); //Whole sale
                    prod.DiscountPrice = txtDistributePrice.Text.Trim().ToUpper(); //Distribution 
                    prod.MarkedPrice = txtMarkedPrice.Text.Trim().ToUpper(); //Marked Price
                    prod.MinimumPrice = txtminimumPrice.Text.Trim().ToUpper(); // Minimum price

                    prod.Reorderlevel = txtReOrderLevl.Text.Trim().ToUpper(); 
                    prod.Unit = cmbUnit.Text.Trim();
                    prod.Disc_Str = txtDiscount.Text.Trim();
                    //prod.Disc_Str = "";

                    prod.CostCode = lblCostCode.Text.ToUpper();
                    prod.Margine = lblMargine.Text;
                    prod.CreditBilling = Convert.ToBoolean(chkCreditBilling.Checked.ToString());
                    prod.SinghalaDescription = txtSinghalaDescription.Text.ToString();
                    prod.Abs = Convert.ToBoolean(chkLoose.Checked);
                    prod.ScaleProd = Convert.ToBoolean(chkScaleProduct.Checked);
                    //Check Item Locked
                    prod.LockedItem = (chkTransactionLock.Checked) ? "T" : "F";
                    prod._strDisCountNotAllow = (chkDisNotAllow.Checked) ? "T" : "F";
                    prod._blExpireItem = chkExpireItem.Checked;
                    prod._blVatProd = chkVatProd.Checked;
                    prod._blBundleProd = chkbundle.Checked;

                    prod.GrnQty = Convert.ToDecimal(txtGRNQTY.Text.Trim());
                    prod.GrnDate = dtpGRNDate.Text;
                    prod.RecallGRN = chkCld.Checked;
                    prod.PacketingProd = chkPkt.Checked;
                    prod.FreeIsue = chkFreeIssue.Checked;
                    prod.OGF = chkOgf.Checked;
                    prod.BatchPUpdate = chkBatchPUpdate.Checked;

                    // Added By Nipuni - 2024.03.28
                    prod.ServiceItem = chkServItem.Checked;
                    prod.Rentitem = chkRentItem.Checked;
                    prod.ServiceTime = Convert.ToDecimal(txtServTime.Text);

                    try
                    {
                        prod.ReorderQty = decimal.Parse(txtReOrdrQty.Text.Trim());
                        //prod.CurrentQty = decimal.Parse(txtCurntQty.Text.Trim());
                        prod.Rack_No = txtRackNo.Text.Trim();

                        prod.PackSize = Int32.Parse(txtPackSize.Text.Trim());
                        prod.BrandCode = txtBrandCode.Text.Trim().ToUpper();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //clear all the properties used in search form
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                    search.prop_Focus = null;
                    search.prop_Name = string.Empty;
                    prod.MinusAllow = chkMinusAllow.Checked;
                    prod.UnderCost = chkUnderCost.Checked;
                    prod.PackQty = decimal.Parse(txtPackQty.Text.Trim());
                    prod.PointsAllow = Convert.ToBoolean(chkPointsAllow.Checked);

                    prod.SerialAllow = chkSerialNo.Checked;
                    prod.warrentyAllow = chkwarntyhandle.Checked;
                    prod.InstallChargeAllow = chkInstallCharges.Checked;

                    prod.WarrentyPeriod = cmbwarenty.Text;
                    prod.InstallCharge = Convert.ToDecimal(txtInstallCharge.Text);
                    prod.InstallChargePer = Convert.ToDecimal(txtInstallChargePer.Text);

                    prod.UpdateData();
                    //Price Change
                    //if (prod.RecordFound == true)
                    //{
                    //    prod.PriceChange();
                    //}
                    //*****
                    chkTransactionLock.Checked = false;
                    chkCreditBilling.Checked = false;
                    //chkOgf.Checked = false;
                    if (chkClearItemDet.Checked == true)
                    {
                        //clsClear.getclear().clearfeilds(grpProduct, txtCode);
                        //clsClear.getclear().clearfeilds(grpPrice, txtCode);
                        //PictureProduct.BackgroundImage = Inventory.Properties.Resources.DefaultImage; //Image.FromFile(Application.StartupPath + @"\DefaultImage.JPG");
                        //txtPurchPrice.Text = "0.0000";
                        //txtMarkedPrice.Text = txtWholeSalePrice.Text = txtSelPrice.Text =
                        //txtDiscount.Text = lblAvgCost.Text = lblLastPurchasePrice.Text = lblLastPurQty.Text = txtReOrderLevl.Text =
                        //lblMargine.Text = lblMargineAmount.Text = lblDiscounted.Text = "0.00";
                        //lblCurntQty.Text = txtReOrdrQty.Text = "0";
                        //chkTransactionLock.Checked = chkPointsAllow.Checked = chkMinusAllow.Checked = chkUnderCost.Checked = chkAllItem.Checked = false;
                        //chkCreditBilling.Checked = false;
                        btnClear.PerformClick();
                    }
                    txtPackSize.Text = "1";
                    txtRackNo.Text = "1";
                    txtGRNQTY.Text = "1";
                    txtPackQty.Text = "1";
                    txtReOrderLevl.Text = "0";
                    txtReOrdrQty.Text = "0";

                    lblAvgCost.Text = "0.00";
                    lblMargine.Text = "0.00";
                    lblDiscounted.Text = "0.00";
                    lblPurDate.Text = "dd/mm/yyyy";
                    lblCurntQty.Text = "0.00";
                    lblLastPurQty.Text = "0.00";



                    dtpGRNDate.Value = DateTime.Now;
                    //Set Default Image
                    //PictureProduct.BackgroundImage = Image.FromFile(@"..\DefaultImage.JPG");
                    
                    txtCode.Focus();
                    //
                
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (this.PropClose == "GrnOpen")
                {
                   
                    frmGrn.GetGrn.txtProductCode.Focus();
                    this.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                product = null;
                prod = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                clsClear.getclear().clearfeilds(grpProduct, txtCode);
                clsClear.getclear().clearfeilds(grpPrice, txtCode);
                txtPurchPrice.Text = "0.0000";
                txtMarkedPrice.Text = txtWholeSalePrice.Text = txtSelPrice.Text = txtminimumPrice.Text=
                txtDistributePrice.Text = lblAvgCost.Text = lblLastPurchasePrice.Text = lblLastPurQty.Text = txtReOrderLevl.Text = txtSaleMargin.Text=
                lblMargine.Text = lblMargineAmount.Text = lblDiscounted.Text = "0.00";
                lblCurntQty.Text = txtReOrdrQty.Text = "0";
                txtPackSize.Text = txtPackQty.Text = txtRackNo.Text=txtGRNQTY.Text = "1";
                chkTransactionLock.Checked = chkPointsAllow.Checked = chkDisNotAllow.Checked = false;
                lblCostCode.Text = "AAA";
                chkMinusAllow.Checked = chkUnderCost.Checked = chkAllItem.Checked = false;
                chkCreditBilling.Checked = false;
                lblPurDate.Text = "dd/mm/yyyy";
                btnProductPriceMaster.BackColor = Color.AliceBlue;
                lvLocaQty.Items.Clear();
                chkLoose.Checked = false;
                PictureProduct.Image = global::Inventory.Properties.Resources.DefaultImage;
                chkExpireItem.Checked = false;
                chkVatProd.Checked = chkbundle.Checked=chkPkt.Checked= false;
                dtpGRNDate.Value = DateTime.Now;
                cmbUnit.SelectedIndex = 0;
                txtDiscount.Text = string.Empty;
                chkOgf.Checked =chkBatchPUpdate.Checked=chkSerialNo.Checked=chkInstallCharges.Checked=chkwarntyhandle.Checked= false;
                chkServItem.Checked = false;
                txtServTime.Text = "0";
                chkRentItem.Checked = false;

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtShortDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtShortDescription.Text.Trim() != "" && !Settings.Default.Shinghala)
                    {
                        txtPurchPrice.Focus();
                    }
                    else if (txtShortDescription.Text.Trim() != "" && Settings.Default.Shinghala)
                    {
                        txtSinghalaDescription.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Short Description Can't Be Empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtShortDescription.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void DesabledControl(bool TF)
        {
            try
            {
                txtDescript.Enabled = TF;             
                txtBarcode.Enabled = TF;              
                txtShortDescription.Enabled = TF;     
                txtDepCode.Enabled = TF;              
                txtDepDescript.Enabled = TF;          
                txtCatCode.Enabled = TF;              
                txtCatDescript.Enabled = TF;          
                txtSupCode.Enabled = TF;              
                txtSupDescript.Enabled = TF;          
                txtBrandCode.Enabled = TF;            
                txtBrandName.Enabled = TF;            
                txtPurchPrice.Enabled = TF;           
                txtReOrderLevl.Enabled = TF;          
                txtSelPrice.Enabled = TF;             
                txtWholeSalePrice.Enabled = TF;
                txtMarkedPrice.Enabled = TF;
                txtPackQty.Enabled = TF;
                lblLastPurQty.Enabled = TF;           
                txtReOrderLevl.Enabled = TF;          
                txtRackNo.Enabled = TF;               
                cmbUnit.Enabled = TF;                 
                txtPackSize.Enabled = TF;             
                txtDistributePrice.Enabled = TF;             
                txtReOrdrQty.Enabled = TF;            
                btnDepDescript.Enabled = TF;          
                btnCatSearch.Enabled = TF;            
                btnSupSearch.Enabled = TF;            
                btnBrandSearch.Enabled = TF;          
                btnNewDept.Enabled = TF;              
                btnNewCategory.Enabled = TF;          
                btnNewSupplier.Enabled = TF;          
                btnNewBrand.Enabled = TF;
                btnLocationROL.Enabled = TF;
                btnProductPriceMaster.Enabled = TF;
                txtSinghalaDescription.Enabled = TF;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void chkTransactionLock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DesabledControl(!chkTransactionLock.Checked);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtWholeSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtWholeSalePrice.Text) == false)
                    {
                        MessageBox.Show("Invalid Whole sale Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (chkUnderCost.Checked == false)
                    {
                        if (decimal.Parse(txtWholeSalePrice.Text) < decimal.Parse(txtPurchPrice.Text))
                        {
                            MessageBox.Show("Under Cost Not Allowed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    if (chkMargine.Visible==true && chkMargine.Checked == false)
                    {
                        txtSaleMargin_KeyDown(sender, e);
                    }
                    if (txtSelPrice.Text.Trim() == string.Empty || Convert.ToDecimal(txtSelPrice.Text.Trim()) == 0)
                    {
                        txtSelPrice.Text = txtWholeSalePrice.Text;
                    }
                    txtSelPrice.Focus();
                    txtSelPrice.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtDistributePrice.Text) == false)
                    {
                        MessageBox.Show("Invalid Distribution Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                 

                    txtRackNo.Focus();
                   
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        
        private void CalculateDiscount(string strDiscText)
        {
            try
            {
                if (strDiscText.IndexOf("%") > 0 && strDiscText.IndexOf("%") < 3)
                {
                    strDisc = strDiscText;
                    intPosOfPrec = strDiscText.IndexOf("%");
                    fltDiscPer = decimal.Parse(strDiscText.Substring(0, intPosOfPrec).ToString());
                    decAmount = decimal.Parse(txtSelPrice.Text.ToString());
                    fltDiscPer = 100 - fltDiscPer;
                    decAmount = (decimal.Parse(decAmount.ToString()) * decimal.Parse(fltDiscPer.ToString())) / 100;
                    //decDiscountAmount = decimal.Parse(txtSelPrice.Text) - decAmount;
                    lblDiscounted.Text = decAmount.ToString();

                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDistributePrice.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 033. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (decDiscText <= decimal.Parse(txtSelPrice.Text.ToString()))
                {
                    decAmount = decimal.Parse(txtSelPrice.Text.ToString());
                    decAmount = decAmount - decDiscText;
                    //decDiscountAmount = decDiscText;
                    lblDiscounted.Text = decAmount.ToString();

                }
                else
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22% or 225.00)", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDistributePrice.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 034. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                product = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 035. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProduct_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 036. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnBarSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                prod.SqlString = "SELECT Barcode AS [Barcode], Prod_Code [Product Code], Prod_Name AS [Product Name] FROM Product WHERE Barcode <> '' AND Barcode LIKE '%"+txtBarcode.Text.Trim()+"%'";
                prod.RetrieveFields_ProductNo();
                search.dgSearch.DataSource = prod.GetDataset1.Tables["dsProduct"];
                search.Show();
                search.prop_Focus = txtBarcode;
                search.Cont_Descript = txtCode;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 037. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {

                    txtBarcode.Text = search.Code.Trim(); ;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 038. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtRackNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtRackNo.Text) == true)
                    {
                        txtReOrderLevl.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 039. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPackSize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtPackSize.Text) == true)
                    {
                        txtPackQty.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 040. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCostCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDistributePrice.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 041. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && (txtDepCode.Focused == true || txtDepDescript.Focused==true))
                {
                    this.btnDepDescript.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtCatCode.Focused == true || txtCatDescript.Focused==true))
                {
                    this.btnCatSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtSupCode.Focused == true || txtSupDescript.Focused==true))
                {
                    this.btnSupSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtBrandCode.Focused == true || txtBrandName.Focused==true))
                {
                    this.btnBrandSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtCode.Focused == true || txtDescript.Focused==true))
                {
                    this.btnProdsearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && txtBarcode.Focused == true)
                {
                    this.btnBarSearch.PerformClick();
                }
                else if(e.KeyCode == Keys.F1 && txtSelPrice.Focused == true)
                {
                    this.btnProductPriceMaster.PerformClick();
                }
                
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }
                    else if (e.KeyCode == Keys.D)
                    {
                        this.btnDelete.PerformClick();
                    }
                    else if (e.KeyCode == Keys.L)
                    {
                        this.btnClear.PerformClick();
                    }
                    else if (e.KeyCode == Keys.E)
                    {
                        this.btnExit.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 042.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                //openFileDialog1.InitialDirectory = "c:\\";
                ////openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog1.Filter = "All Picture files (*.bmp)|*.bmp|JPG (*.JPG)|*.JPG|JPEG (*.JPEG)|*.JPEG|All files (*.*)|*.*";
                //openFileDialog1.FilterIndex = 1;
                //openFileDialog1.RestoreDirectory = true;

                //if (openFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    if ((myStream = openFileDialog1.OpenFile()) != null)
                //    {
                //        lblImagePath.Text = openFileDialog1.FileName;
                //        myStream.Close();

                //        PictureProduct.BackgroundImage = Image.FromFile(lblImagePath.Text);
                //    }
                //}

                //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.Filter = "All Picture files (*.bmp)|*.bmp|JPG (*.JPG)|*.JPG|JPEG (*.JPEG)|*.JPEG|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                MainClass.mdi.SnapImage = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        // Insert code to read the stream here.
                        lblImagePath.Text = openFileDialog1.FileName;
                        //string FileNAme = openFileDialog1.SafeFileName;
                        //string Path = lblImagePath.Text.Substring(0, lblImagePath.Text.Length - FileNAme.Length);

                        myStream.Close();
                        //PictureProduct.SizeMode = PictureBoxSizeMode.CenterImage;
                        //PictureProduct.BackgroundImage = Image.FromFile(lblImagePath.Text);

                        ImageProcessor IMGProc = new ImageProcessor();
                        Bitmap bmp = (Bitmap)Image.FromFile(lblImagePath.Text);
                        int width = 600;
                        int height = 400;
                        Bitmap BitMapImage = IMGProc.Resize(bmp, width, height, txtCode.Text);
                        picTempProduct.Image = BitMapImage;
                        //PictureProduct.Image = resizeImage(315, 180);

                        int newWidth = (int)((Convert.ToDecimal(BitMapImage.Width) / Convert.ToDecimal(BitMapImage.Height)) * PictureProduct.Height);

                        Bitmap x = new Bitmap(BitMapImage, new Size(newWidth, PictureProduct.Height));
                        PictureProduct.Image = x;

                        MainClass.mdi.SnapImage = PictureProduct.Image;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 043.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDefaultImg_Click(object sender, EventArgs e)
        {
            try
            {
                //Set Default Image
                //PictureProduct.BackgroundImage = Image.FromFile(@"..\DefaultImage.JPG");
                PictureProduct.Image = global::Inventory.Properties.Resources.DefaultImage;
                //
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 044.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               // MessageBox.Show("Product Delete Function is Removed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
               // return;
                DialogResult blResult;
                blResult = MessageBox.Show("Are You Sure You Want To Delete This Product ?", "Product Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (blResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if (txtCode.Text.Trim() == string.Empty)
                    {
                       

                        MessageBox.Show("Product Code Not Found. Please Select Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode.Focus();
                        return;
                    }
                    prod.SqlString = "SELECT Prod_Code FROM Transaction_Details WHERE Prod_Code = '" + txtCode.Text.Trim() + "'";
                    prod.ReadProductCode();
                    if (prod.RecordFound == true)
                    {
                        MessageBox.Show("Can't Delete This Product , Transaction Already Having .", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //txtDepCode.Focus();
                        return;
                    }
                    prod.SqlString = "SELECT Prod_Code FROM ProductSalesSummery WHERE Prod_Code = '" + txtCode.Text.Trim() + "'";
                    prod.ReadProductCode();
                    if (prod.RecordFound == true)
                    {
                        MessageBox.Show("Can't Delete This Product , Transaction Already Having .", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //txtDepCode.Focus();
                        return;
                    }

                    prod.ErrorCode = 0;
                    prod.Code = txtCode.Text.Trim().ToUpper();
                    prod.DeleteData();

                    //MessageBox.Show("Product Code Deleted Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsClear.getclear().clearfeilds(grpProduct, txtCode);
                    clsClear.getclear().clearfeilds(grpPrice, txtCode);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 046.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnBrandSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (string.IsNullOrEmpty(txtBrandCode.Text) && string.IsNullOrEmpty(txtBrandName.Text))
                {
                    prod.SqlString = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand Order by Brand_Code";
                }
                else if (!string.IsNullOrEmpty(txtBrandCode.Text) && string.IsNullOrEmpty(txtBrandName.Text))
                {
                    prod.SqlString = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand WHERE Brand_Code LIKE '%" + txtBrandCode.Text.Trim() + "%' Order by Brand_Code";
                }
                else if (string.IsNullOrEmpty(txtBrandCode.Text) && !string.IsNullOrEmpty(txtBrandName.Text))
                {
                    prod.SqlString = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand WHERE Brand_Name LIKE '%" + txtBrandName.Text.Trim() + "%' Order by Brand_Code";
                }
                else
                {
                    prod.SqlString = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand Order by Brand_Code";
                }
                prod.RetrieveBrand();
                search.dgSearch.DataSource = prod.GetDataset1.Tables["dsBrand"];
                search.prop_Focus = txtBrandCode;
                search.Show();
                search.Location = new Point(this.Location.X + 115, this.Location.Y + 145);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 047. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBrandCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != string.Empty)
                {
                    txtBrandCode.Text = search.Code.Trim();
                    txtBrandName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 048. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBrandCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Display Supplier
                    if (txtBrandCode.Text.Trim() != "")
                    {
                        txtBrandCode.Text = txtBrandCode.Text.ToUpper();
                        prod.SqlString = "SELECT Brand_Code, Brand_Name FROM brand WHERE Brand_Code = '" + txtBrandCode.Text.Trim() + "'";
                        prod.BrandRead();
                        if (prod.RecordFound == true)
                        {
                            txtBrandName.Text = prod.BrandName;
                            if (txtCode.Text.Trim() == string.Empty)
                            {
                                txtCode.Focus();
                            }
                            else if (txtDescript.Text.Trim() == string.Empty)
                            {
                                txtDescript.Focus();
                            }
                             else
                            {
                                txtPurchPrice.Focus();
                            }
                        }
                        else
                        {
                            txtBrandName.Text = string.Empty;
                            MessageBox.Show("Brand Code Not Found. Please Check Brand Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBrandCode.Focus();
                        }
                    }
                }
                else if (e.KeyCode == Keys.F1)
                {
                    this.btnBrandSearch.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 049. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnNewDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmDepartment.GetDepartment == null)
                {
                    frmDepartment.GetDepartment = new frmDepartment();
                    frmDepartment.GetDepartment.MdiParent = MainClass.getmdi();
                    frmDepartment.GetDepartment.Show();
                }
                else
                {
                    frmDepartment.GetDepartment.Focus();
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
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmCategory.GetCategory == null)
                {
                    frmCategory.GetCategory = new frmCategory();
                    frmCategory.GetCategory.MdiParent = MainClass.getmdi();
                    frmCategory.GetCategory.Show();
                }
                else
                {
                    frmCategory.GetCategory.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 051. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmSupplier.GetAccount == null)
                {
                    frmSupplier.GetAccount = new frmSupplier();
                    frmSupplier.GetAccount.MdiParent = MainClass.getmdi();
                    frmSupplier.GetAccount.Show();
                }
                else
                {
                    frmDepartment.GetDepartment.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 051. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnNewBrand_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmBrand.GetBrand == null)
                {
                    frmBrand.GetBrand = new frmBrand();
                    frmBrand.GetBrand.MdiParent = MainClass.getmdi();
                    frmBrand.GetBrand.Show();
                }
                else
                {
                    frmBrand.GetBrand.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 052. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnLocationROL_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() != string.Empty)
                {
                    if (frmLocationROL.GetLocationROL == null)
                    {
                        frmLocationROL.GetLocationROL = new frmLocationROL(txtCode.Text.Trim(), txtDescript.Text.Trim());
                        frmLocationROL.GetLocationROL.MdiParent = MainClass.getmdi();
                        frmLocationROL.GetLocationROL.Show();
                    }
                    else
                    {
                        frmLocationROL.GetLocationROL.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Product Detail Not Found. Please Select Valid Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
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
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMarkedPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtMarkedPrice.Text) == false)
                    {
                        MessageBox.Show("Invalid Modern Marked Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (chkUnderCost.Checked == false)
                    {
                        if (decimal.Parse(txtMarkedPrice.Text) < decimal.Parse(txtPurchPrice.Text))
                        {
                            MessageBox.Show("Under Cost Not Allowed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                   // if (txtDistributePrice.Text.Trim() == string.Empty || Convert.ToDecimal(txtDistributePrice.Text.Trim()) == 0)
                    {
                        txtDistributePrice.Text = txtSelPrice.Text;
                    }
                    txtDiscount.Focus();
                    txtDiscount.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnProductPriceMaster_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() != string.Empty)
                {
                    if (frmProductPriceMaster.GetProductPriceMaster == null)
                    {
                        //frmProductPriceMaster.GetProductPriceMaster = new frmProductPriceMaster();
                        frmProductPriceMaster.GetProductPriceMaster = new frmProductPriceMaster(txtCode.Text.Trim(), txtDescript.Text.Trim());
                        frmProductPriceMaster.GetProductPriceMaster.MdiParent = MainClass.getmdi();
                        frmProductPriceMaster.GetProductPriceMaster.Show();
                     
                    }
                    else
                    {
                        frmProductPriceMaster.GetProductPriceMaster.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Product Detail Not Found. Please Select Valid Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
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
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblBarcodeLength.Text = txtBarcode.Text.Trim().Length.ToString();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 051. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtShortDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblShortDescLength.Text = txtShortDescription.Text.Trim().Length.ToString();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 052. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
       
        private void txtDepDescript_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode==Keys.F1)
            {
                this.btnDepDescript.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtDepCode.Text = txtDepDescript.Text = string.Empty;
                search.Hide();
                txtDepDescript.Focus();
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

        private void txtCatDescript_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.F1)
            {
                this.btnCatSearch.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtCatCode.Text = txtCatDescript.Text = string.Empty;
                search.Hide();
                txtCatDescript.Focus();
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

        private void txtSupDescript_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.F1)
            {
                this.btnSupSearch.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtSupCode.Text = txtSupDescript.Text = string.Empty;
                search.Hide();
                txtSupDescript.Focus();
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

        private void txtBrandName_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.F1)
            {
                this.btnBrandSearch.PerformClick();
            }
           
            if (e.KeyCode == Keys.Escape)
            {
                txtBrandCode.Text = txtBrandName.Text = string.Empty;
                search.Hide();
                txtBrandName.Focus();
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

        private void likViewbincard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Product code doesn't exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }
            else
            {
                bincard.intRepOption = 404;
                bincard.txtCodeFrom.Text = txtCode.Text.ToString();
            }
        
        }

        private void txtPurchPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPurchPrice.Text = (txtPurchPrice.Text == string.Empty) ? "0.0000" : string.Format("{0:0.0000}", decimal.Parse(txtPurchPrice.Text.ToString()));
                
                decimal purChPrice  = (( Convert.ToDecimal(txtPurchPrice.Text.Trim()) * Settings.Default.VatPrecentage )/100) +  ( Convert.ToDecimal(txtPurchPrice.Text.Trim()));

                lblMargineAmount.Text = string.Format("{0:0.00}", decimal.Parse(txtSelPrice.Text) - purChPrice);

               
            }

            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void txtMarkedPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMarkedPrice.Text = (txtMarkedPrice.Text == string.Empty) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtMarkedPrice.Text.ToString()));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void txtWholeSalePrice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtWholeSalePrice.Text = (txtWholeSalePrice.Text == string.Empty) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtWholeSalePrice.Text.ToString()));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void txtSelPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(txtPurchPrice.Text) == 0)
                {
                    MessageBox.Show("Can not pass zero values", "Purchase Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurchPrice.Focus();
                    txtPurchPrice.SelectAll();
                }
                else
                {
                    txtSelPrice.Text = (txtSelPrice.Text == string.Empty) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtSelPrice.Text.ToString()));

                    if (chkVatProd.Checked == false)
                    {
                        decimal purChPrice = ((Convert.ToDecimal(txtPurchPrice.Text.Trim()) * Settings.Default.VatPrecentage) / 100) + (Convert.ToDecimal(txtPurchPrice.Text.Trim()));


                        lblMargineAmount.Text = string.Format("{0:0.00}", decimal.Parse(txtSelPrice.Text) - purChPrice);
                        if (IsNumeric(txtSelPrice.Text) == true)
                        {
                            decMargine = ((decimal.Parse(txtSelPrice.Text) - purChPrice) / purChPrice) * 100;
                            lblMargine.Text = string.Format("{0:0.00}", decMargine);
                        }
                    }
                    else
                    {
                        decimal purChPrice = Convert.ToDecimal(txtPurchPrice.Text.Trim());


                        lblMargineAmount.Text = string.Format("{0:0.00}", decimal.Parse(txtSelPrice.Text) - purChPrice);
                        if (IsNumeric(txtSelPrice.Text) == true)
                        {
                            decMargine = ((decimal.Parse(txtSelPrice.Text) - purChPrice) / purChPrice) * 100;
                            lblMargine.Text = string.Format("{0:0.00}", decMargine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDistributePrice.Text = (txtDistributePrice.Text == string.Empty) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtDistributePrice.Text.ToString()));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void txtPackQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtPackSize.Text) == true)
                    {
                        txtGRNQTY.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProduct 040. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                txtServTime.Enabled = false;
                //if (!Settings.Default.Shinghala)
                //{
                //    this.Size = new Size(923, 582);
                //}
                label31.Visible = txtSinghalaDescription.Visible = Settings.Default.Shinghala;

                prod.CheckedPasswordValid("SELECT  * FROM dbo.tb_UserRoleDetails US JOIN dbo.Employee E ON E.UserRole_Id=US.UserRoleId WHERE US.MenuID='productBinCardToolStripMenuItem' AND  E.Emp_Name='" + LoginManager.UserName+"' AND E.Loca='"+LoginManager.LocaCode+"'   AND US.Allow=1 ");
                if (prod.AccessStatus == false)
                {
                    likViewbincard.Enabled = false;
                }


                txtSaleTax.Text = Settings.Default.VatPrecentage.ToString("N2");
            
                cmbUnit.SelectedIndex = 0;

                if(Settings.Default.ProdMargine==true)
                {
                    chkMargine.Visible = true;
                    txtSaleMargin.ReadOnly = false;
                    txtSaleMargin.Text = Settings.Default.Margin.ToString("N2");
                    chkMargine.Checked = Settings.Default.MargineToCost;
                }
                else
                {
                    chkMargine.Visible = false;
                    txtSaleMargin.ReadOnly = false;
                }
                if (prodSearching == true)
                {
                    txtCode.BackColor = Color.MediumAquamarine;
                    txtDescript.BackColor = Color.MediumAquamarine;
                }
                if(Settings.Default.LastPriceName != string.Empty)
                {
                    label38.Text = Settings.Default.LastPriceName.ToString();
                }
                else
                {
                    label38.Text = "Minimum Price";
                }
            }
            catch (Exception ex)
            {

                prod.Errormsg(ex, "frmProduct-frmProduct_Load");
            }

        }

        private void txtSinghalaDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Settings.Default.Shinghala)
            {
                txtDepCode.Focus();
            }
        }

        private void lvLocaQty_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

    

        private void txtSaleMargin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSaleMargin.Text.Trim() == string.Empty)
                {
                    txtSaleMargin.Text = "0";
                }
                txtPurchPrice_KeyDown(sender, e);

                txtWholeSalePrice.SelectAll();
                txtWholeSalePrice.Focus();
            }
        }

        private void txtGRNQTY_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsNumeric(txtPackSize.Text) == true)
                    {
                        dtpGRNDate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }
        }

        private void dtpGRNDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void picTempProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() != string.Empty)
            {
                if (frmBatchPriceChange._objBatchPriceChange != null)
                {
                    frmBatchPriceChange._objBatchPriceChange.Close();
                }
                frmBatchPriceChange._objBatchPriceChange = new frmBatchPriceChange();
                frmBatchPriceChange._objBatchPriceChange.txtProductCode.Text = txtCode.Text;
                frmBatchPriceChange._objBatchPriceChange.txtProductCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                frmBatchPriceChange._objBatchPriceChange.MdiParent = MainClass.mdi;
                frmBatchPriceChange._objBatchPriceChange.Show();
            }
        }

        private void chkMargine_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MargineToCost = chkMargine.Checked;
        }

        private void chkOgf_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPointsAllow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkwarntyhandle_CheckedChanged(object sender, EventArgs e)
        {
            if(chkwarntyhandle.Checked)
            {
                cmbwarenty.Enabled = true;
            }
            else
            {
                cmbwarenty.SelectedIndex = -1;
                cmbwarenty.Enabled =false;
            }
        }

        private void chkInstallCharges_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInstallCharges.Checked)
            {
                txtInstallCharge.Enabled = txtInstallChargePer.Enabled = true;
            }
            else
            {
                txtInstallCharge.Text = txtInstallChargePer.Text = "0";
                txtInstallCharge.Enabled = txtInstallChargePer.Enabled = false;
            }
        }

        private void chkServItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServItem.Checked == true)
            {
                txtServTime.Enabled = true;
                txtServTime.SelectAll();
            }
            else
            {
                txtServTime.Enabled = false;
                txtServTime.Text = "0";
            }
        }

        private void txtDiscount_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtminimumPrice.Focus();
                    //txtRackNo.Focus();

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtminimumPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtminimumPrice.Text = (txtminimumPrice.Text == string.Empty) ? "0.00" : string.Format("{0:0.00}", decimal.Parse(txtminimumPrice.Text.ToString()));
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtminimumPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtRackNo.Focus();
            }
        }

        private void txtDescript_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDescript.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnProdsearch.PerformClick();
                txtDescript.Focus();
            }
        }

        private void txtDepDescript_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDepDescript.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnDepDescript.PerformClick();
                txtDepDescript.Focus();
            }
        }

        private void txtCatDescript_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCatDescript.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnCatSearch.PerformClick();
                txtCatDescript.Focus();
            }
        }

        private void txtSupDescript_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSupDescript.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnSupSearch.PerformClick();
                txtSupDescript.Focus();
            }
        }

        private void txtBrandName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBrandName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnBrandSearch.PerformClick();
                txtBrandName.Focus();
            }
        }

        private void lblMargine_Click(object sender, EventArgs e)
        {

        }
    }
}

