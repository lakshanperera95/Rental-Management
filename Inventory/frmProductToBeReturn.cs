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
using OfficeOpenXml;
using System.Data.SqlClient;
using System.Linq;

namespace Inventory
{
    public partial class frmProductToBeReturn : Form
    {
        clsProductToBeReturn objProductToBeReturn = new clsProductToBeReturn();

        public string opt = "";

        public frmProductToBeReturn()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
            likViewbincard.LinkClicked += new LinkLabelLinkClickedEventHandler(bincard.btnDisplay_Click);
        }

        private static frmProductToBeReturn ProductToBeReturn;

        private frmSearch search = new frmSearch();

        public static frmProductToBeReturn GetProductToBeReturn
        {
            get { return ProductToBeReturn; }
            set { ProductToBeReturn = value; }
        }

        private void frmProductToBeReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ProductToBeReturn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductToBeReturn_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductToBeReturn_Load(object sender, EventArgs e)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                lblDate.Text = string.Format("{0:dd/MM/yyyy}", PostDate);

                if (opt == "TOR")
                {
                    objProductToBeReturn.SqlStatement = "SELECT To_Be_Ret_Temp FROM DocumentNoDetails WHERE Loca = ";
                }
                else if (opt == "OPS")
                {
                    objProductToBeReturn.SqlStatement = "SELECT TempOpst [To_Be_Ret_Temp] FROM DocumentNoDetails WHERE Loca = ";
                }
                objProductToBeReturn.Optrion = opt;
                objProductToBeReturn.GetTempDocumentNo();
                lblTempDocNo.Text = objProductToBeReturn.TempDocNo;
                dataGridTempToBeReturn.DataSource = objProductToBeReturn.TempTransferNote;
                dataGridTempToBeReturn.Refresh();
                objProductToBeReturn.SqlStatement = "SELECT Loca, Loca_Descrip FROM location WHERE Loca = ";
                objProductToBeReturn.ReadFromLocationCode();
                lblLocaCode.Text = objProductToBeReturn.LocaCode;
                lblLocaName.Text = objProductToBeReturn.LocaName;



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
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                ProductToBeReturn = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmProductToBeReturn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        frmProductSearch ProductSearch = new frmProductSearch();
        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductSearch.IsDisposed)
                {
                    ProductSearch = new frmProductSearch();
                }
                //if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() == string.Empty)
                //{
                //    objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],Barcode,Prod_Name AS [Product Name] FROM Product P JOIN dbo.Stock_Master S ON S.Prod_Code = P.Prod_Code /*AND S.Op_St=0*/ ORDER BY P.Prod_Code";
                //}
                //else
                //{
                //    if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                //    {
                //        objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],Barcode,P.Prod_Name AS [Product Name] FROM Product P JOIN dbo.Stock_Master S ON S.Prod_Code = P.Prod_Code/*AND S.Op_St=0*/ WHERE (P.Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%' OR P.Barcode LIKE '%" + txtProductCode.Text.Trim() + "%' ) ORDER BY P.Prod_Code";
                //    }
                //    else
                //    {
                //        if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                //        {
                //            objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],Barcode,Prod_Name AS [Product Name] FROM Product P JOIN dbo.Stock_Master S ON S.Prod_Code = P.Prod_Code /*AND S.Op_St=0*/ WHERE P.Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' ORDER BY P.Prod_Code";
                //        }
                //        else
                //        {
                //            objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],Barcode,Prod_Name AS [Product Name] FROM Product P JOIN dbo.Stock_Master S ON S.Prod_Code = P.Prod_Code /*AND S.Op_St=0*/ ORDER BY P.Prod_Code";
                //        }
                //    }
                //}

                if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Retail Price],  CAST(P.Disc_Price AS DECIMAL(18,2)) [Distributed Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [M.M Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' AND (P.Prod_Code Like '%" + txtProductCode.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductCode.Text.Trim() + "%')  ORDER BY P.Prod_Name ASC";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Retail Price],  CAST(P.Disc_Price AS DECIMAL(18,2)) [Distributed Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [M.M Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' AND (P.Prod_Name Like '%" + txtProductName.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductName.Text.Trim() + "%')  ORDER BY P.Prod_Name ASC";
                    }
                    else
                    {
                        objProductToBeReturn.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Retail Price],  CAST(P.Disc_Price AS DECIMAL(18,2)) [Distributed Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [M.M Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' ORDER BY P.Prod_Name ASC";
                    }
                }

                objProductToBeReturn.DataetName = "dsProduct";
                objProductToBeReturn.GetItemDetails();
                //search.dgSearch.DataSource = objProductToBeReturn.GetItemDataset.Tables["dsProduct"];
                //search.prop_Focus = txtProductCode;
                //search.Show();

                ProductSearch.dgSearch.DataSource = objProductToBeReturn.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[8].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                for (int i = 0; i < objProductToBeReturn.GetItemDataset.Tables["dsProduct"].Columns.Count; i++)
                {
                    ProductSearch.dgSearch.Columns[i].ReadOnly = true;
                }




                ProductSearch.dgSearch.DataSource = objProductToBeReturn.GetItemDataset.Tables["dsProduct"];
                ProductSearch._ds = objProductToBeReturn.GetItemDataset;
                ProductSearch.prop_Focus = txtProductCode;

                ProductSearch.dgSearch.Columns[3].Visible = false;
                ProductSearch.Show();
                ProductSearch.Location = new Point(this.Location.X, this.Location.Y);
               
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        bool prodSearching = false;
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
                if (ProductSearch.dgSearch.Rows.Count > 0 && ProductSearch.Visible && txtProductCode.Text.Trim().Length != Settings.Default.ProdCodeLength + 4)
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

                    objProductToBeReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' /*AND S.Op_St=0*/ AND  LockedItem='F' and Stock_Master.Loca = ";
                    objProductToBeReturn.ReadProductDetails();
                    if (objProductToBeReturn.ProductName != string.Empty)
                    {
                        txtProductName.Text = objProductToBeReturn.ProductName;
                        lblCurrentQty.Text = (string)objProductToBeReturn.CurrentQty.ToString();
                        txtPurchPrice.Text = (string)objProductToBeReturn.PurchasePrice.ToString();
                        txtSellingPrice.Text = (string)objProductToBeReturn.SellingPrice.ToString();

                        objProductToBeReturn.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objProductToBeReturn.ProductCode + "' AND Doc_No = '" + objProductToBeReturn.TempDocNo + "' AND IId = 'TGN' AND Loca = ";
                        objProductToBeReturn.ReadExsistProductDetails();
                        txtQty.Text = (string)objProductToBeReturn.Qty.ToString();
                        txtQty.Select(0, txtQty.Text.Trim().Length);
                        txtPurchPrice.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Products To Be Return Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtQty.Text) > 0 && clsValidation.isNumeric(txtPurchPrice.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtPurchPrice.Text) > 0 && clsValidation.isNumeric(txtSellingPrice.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtSellingPrice.Text) > 0)
                {
                    if (opt == "OPS")
                    {
                        objProductToBeReturn.SqlStatement = "SELECT * FROM Transaction_Details TD WHERE TD.Prod_Code = '" + txtProductCode.Text.Trim().ToString() + "' AND TD.Iid = 'OPS' AND TD.Loca = '" + LoginManager.LocaCode.ToString() +"'";
                        objProductToBeReturn.ReadTempTransDetails();
                        if (objProductToBeReturn.RecordFound)
                        {
                            MessageBox.Show("This product already OPENING BALANCE. you can't enter again", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtProductCode.Focus(); txtProductCode.SelectAll();
                            return;
                        }
                    }
                    objProductToBeReturn.ProductCode = txtProductCode.Text.Trim().ToUpper();
                    objProductToBeReturn.ProductName = txtProductName.Text.Trim().ToUpper();
                    objProductToBeReturn.CurrentQty = decimal.Parse(lblCurrentQty.Text.ToString());

                    objProductToBeReturn.PurchasePrice = decimal.Parse(txtPurchPrice.Text.ToString());
                    objProductToBeReturn.SellingPrice = decimal.Parse(txtSellingPrice.Text.ToString());

                    objProductToBeReturn.Qty = decimal.Parse(txtQty.Text.ToString());
                    objProductToBeReturn.Amount = decimal.Parse(txtQty.Text.ToString()) * objProductToBeReturn.SellingPrice;
                    objProductToBeReturn.UpdateTobeReturnTempDataSet();
                    //objProductToBeReturn.GetTempDataset();
                    dataGridTempToBeReturn.DataSource = objProductToBeReturn.TempTransferNote.Tables["TransferNote"];
                    dataGridTempToBeReturn.Refresh();
                    //Set Grid Last Record
                    if (dataGridTempToBeReturn.RowCount > 10)
                    {
                        dataGridTempToBeReturn.FirstDisplayedCell = dataGridTempToBeReturn[0, dataGridTempToBeReturn.RowCount - 6];
                    }
                    //******************
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    lblCurrentQty.Text = string.Empty;
                    txtPurchPrice.Text = string.Empty;
                    txtSellingPrice.Text = string.Empty;
                    //txtReference.Enabled = false;
                    //txtRemarks.Enabled = false;

                    objProductToBeReturn.GetTotalValues(ref opt);

                    lblTotalQty.Text = objProductToBeReturn.TotalQty.ToString();
                    lblTotalAmount.Text = objProductToBeReturn.TotalAmount.ToString();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (opt == "TOR")
                {
                    objProductToBeReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'TOR' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objProductToBeReturn.ReadTempTransDetails();
                    if (objProductToBeReturn.RecordFound != true)
                    {
                        MessageBox.Show("Products To Be Return Note Details Not Found.", "To Be Return Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    objProductToBeReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'OPS' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objProductToBeReturn.ReadTempTransDetails();
                    if (objProductToBeReturn.RecordFound != true)
                    {
                        MessageBox.Show("Openning Stock Details Not Found.", "Openning Stock Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }               

                objProductToBeReturn.Remark = txtRemarks.Text.Trim();
                if (opt == "TOR")
                {
                    opt = "TOR";
                }
                else
                {
                    opt = "OPS";
                }
                objProductToBeReturn.GetDataSetForPreview(ref opt);
                dsDataForReport = objProductToBeReturn.GetReportDataset;
                if (opt == "TOR")
                {
                    rptToBeReturnNote ProductToBeRet = new rptToBeReturnNote();
                    ProductToBeRet.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = ProductToBeRet;
                }
                else
                {
                    rptOpeningStockNote OpeningStockNote = new rptOpeningStockNote();
                    OpeningStockNote.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = OpeningStockNote;
                }               
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "To Be Return Note Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (opt == "TOR")
                    {

                        objProductToBeReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'TOR' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                        objProductToBeReturn.ReadTempTransDetails();
                        if (objProductToBeReturn.RecordFound != true)
                        {
                            MessageBox.Show("Products To Be Return Note Details Not Found.", "To Be Return Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        objProductToBeReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'OPS' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                        objProductToBeReturn.ReadTempTransDetails();
                        if (objProductToBeReturn.RecordFound != true)
                        {
                            MessageBox.Show("Openning Stock Details Not Found.", "Openning Stock Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    objProductToBeReturn.Remark = txtRemarks.Text.Trim();
                    objProductToBeReturn.Reference = txtReference.Text.Trim();
                    objProductToBeReturn.TransferNoteSave(ref opt);
                    MessageBox.Show("Transaction Successfully Saved as Document No. " + objProductToBeReturn.OrgDocNo, "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    this.Dispose();
                    ProductToBeReturn = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            DataSet dsDataForReport = new DataSet();
            frmReportViewer objRepViewer = new frmReportViewer();
            try
            {
                objRepViewer.Text = this.Text;
                objProductToBeReturn.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE (TransactionTemp_Details.IId = 'TOR' OR TransactionTemp_Details.IId = 'OPS') AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objProductToBeReturn.ReadTempTransDetails();
                if (objProductToBeReturn.RecordFound != true)
                {
                    MessageBox.Show("Product " + this.Text.Trim() + " Details Not Found.", "To Be Return Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objProductToBeReturn.Remark = txtRemarks.Text.Trim();
                objProductToBeReturn.Reference = txtReference.Text.Trim();
                objProductToBeReturn.TransferNoteApply();
                MessageBox.Show("Product " + this.Text.Trim() + " Successfully Applied as Document No. " + objProductToBeReturn.OrgDocNo, "To Be Return Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //objProductToBeReturn.GetDataSetForReport();
                dsDataForReport = objProductToBeReturn.GetReportDataset;
                if (opt == "TOR")
                {
                    objRepViewer.VirtuaReport = new rptToBeReturnNote();
                }
                else
                {
                    objRepViewer.VirtuaReport = new rptOpeningStockNote();
                }
                objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);

                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();

                this.Close();
                this.Dispose();
                ProductToBeReturn = null;

                frmProductToBeReturn.ProductToBeReturn = new frmProductToBeReturn();
                frmProductToBeReturn.ProductToBeReturn.opt = opt;
                frmProductToBeReturn.ProductToBeReturn.MdiParent = MainClass.mdi;
                frmProductToBeReturn.ProductToBeReturn.Show();

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (opt == "TOR")
                {
                    objProductToBeReturn.SqlStatement = "SELECT Doc_No [Document No], Post_Date [Saved Date] FROM Transaction_Save_Header WHERE Iid = 'TOR' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                }
                else
                {
                    objProductToBeReturn.SqlStatement = "SELECT Doc_No [Document No], Post_Date [Saved Date] FROM Transaction_Save_Header WHERE Iid = 'OPS' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                }
                objProductToBeReturn.DataetName = "Table";
                objProductToBeReturn.GetItemDetails();

                search.dgSearch.DataSource = objProductToBeReturn.GetItemDataset.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Load Saved Document No :" + search.Code.Trim() + ". ", "Load?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objProductToBeReturn.RecallSaveDocNo = search.Code.Trim();
                        if (opt == "TOR")
                        {
                            objProductToBeReturn.SqlStatement = "SELECT Transaction_Save_Header.* FROM Transaction_Save_Header WHERE iid = 'TOR' AND Doc_No = '" + search.Code.Trim() + "' AND Transaction_Save_Header.Loca = ";
                        }
                        else
                        {
                            objProductToBeReturn.SqlStatement = "SELECT Transaction_Save_Header.* FROM Transaction_Save_Header WHERE iid = 'OPS' AND Doc_No = '" + search.Code.Trim() + "' AND Transaction_Save_Header.Loca = ";
         
                        }
                        objProductToBeReturn.ReadSavedDocument(ref opt);
                        if (objProductToBeReturn.RecordFound)
                        {
                            lblTempDocNo.Text = objProductToBeReturn.TempDocNo;
                            txtReference.Text = objProductToBeReturn.Reference.ToString();
                            txtRemarks.Text = objProductToBeReturn.Remark.ToString();

                            objProductToBeReturn.GetTempDataset(ref opt);
                            dataGridTempToBeReturn.DataSource = objProductToBeReturn.TempTransferNote.Tables["TransferNote"];
                            dataGridTempToBeReturn.Refresh();

                            objProductToBeReturn.GetTotalValues(ref opt);

                            lblTotalQty.Text = objProductToBeReturn.TotalQty.ToString();
                            lblTotalAmount.Text = objProductToBeReturn.TotalAmount.ToString();
                            btnSaveDocSearch.Enabled = false;

                            //txtProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempToBeReturn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridTempToBeReturn.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "To Be Return Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objProductToBeReturn.TempDocNo = lblTempDocNo.Text.Trim();
                        objProductToBeReturn.ProductCode = dataGridTempToBeReturn.SelectedRows[0].Cells[0].Value.ToString();
                        objProductToBeReturn.DeleteProductDetaile();
                        objProductToBeReturn.GetTempDataset(ref opt);
                        dataGridTempToBeReturn.DataSource = objProductToBeReturn.TempTransferNote.Tables["TransferNote"];
                        dataGridTempToBeReturn.Refresh();

                        objProductToBeReturn.GetTotalValues(ref opt);

                        lblTotalQty.Text = objProductToBeReturn.TotalQty.ToString();
                        lblTotalAmount.Text = objProductToBeReturn.TotalAmount.ToString();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempToBeReturn_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridTempToBeReturn.SelectedRows.Count <= 0 || dataGridTempToBeReturn.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductCode.Text = dataGridTempToBeReturn.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dataGridTempToBeReturn.SelectedRows[0].Cells[1].Value.ToString();
                    objProductToBeReturn.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objProductToBeReturn.ReadProductDetails();
                    lblCurrentQty.Text = (string)objProductToBeReturn.CurrentQty.ToString();
                    txtSellingPrice.Text = dataGridTempToBeReturn.SelectedRows[0].Cells[2].Value.ToString();
                    txtPurchPrice.Text = dataGridTempToBeReturn.SelectedRows[0].Cells[3].Value.ToString();
                    txtQty.Text = dataGridTempToBeReturn.SelectedRows[0].Cells[5].Value.ToString();
                    lblAmount.Text = dataGridTempToBeReturn.SelectedRows[0].Cells[6].Value.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void lblTempDocNo_Click(object sender, EventArgs e)
        {

        }

        private void txtPurchPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtPurchPrice.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtPurchPrice.Text) > 0)
            {
                txtSellingPrice.Focus();
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtSellingPrice.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtSellingPrice.Text) > 0)
            {
                txtQty.Focus();
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

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductToBeReturn 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && prodSearching == true)
            {
                btnItemSearch.PerformClick();
                txtProductName.Focus();
            }
        }
        frmSalesInquary bincard = new frmSalesInquary();
        private void likViewbincard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                MessageBox.Show("Product code doesn't exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductCode.Focus();
                return;
            }
            else
            {
                bincard.intRepOption = 404;
                bincard.txtCodeFrom.Text = txtProductCode.Text.ToString();
            }
        }
       
        private void btnExcelim_Click(object sender, EventArgs e)
        {
            try
            {
                string Sqlst = "DELETE  FROM dbo.Temp_StOveright WHERE Loca='" + LoginManager.LocaCode + "' AND Doc_No='" + lblTempDocNo.Text.Trim() + "';DELETE FROM TransactionTemp_Details where doc_No='"+lblTempDocNo.Text+"' and iid='OPS'  and Loca='"+LoginManager.LocaCode+"' ";
                ObjComm.getDataSet(Sqlst, "ds");

                //open User Selected excel file
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Excel Worksheets|*.xls;*.xlsx;*.xlsm;*.csv";
                if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileInfo newFile = new FileInfo(OFD.FileName);

                    //add licence context (Other wise error will occured in cracked licence excel)
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var ep = new ExcelPackage(newFile))
                    {

                        var theWorkbook = ep.Workbook;
                        var theSheet = theWorkbook.Worksheets.First();

                        //excel read and assign to custom list
                        List<clsExcel.ExcelColumnsOpenSt> listOfExcel = theSheet.ToList<clsExcel.ExcelColumnsOpenSt>(null);
                        DbConnection.dbcon db = new DbConnection.dbcon();
                        System.Data.DataSet ds = new DataSet();


                        DataTable Dt = clsExcel.ToDataTable(listOfExcel);

                        int Count = 1;
                        foreach (DataRow row in Dt.Rows)
                        {
                            string Code = row[0].ToString().Trim();
                            string Qty = row[1].ToString().Trim();
                            if ( Code=="")
                            {
                                MessageBox.Show("Product Code Not Found in Line "+Count,"Excel Import",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                return;
                            }
                            if (Qty == "" || clsValidation.isNumeric(Qty,System.Globalization.NumberStyles.Currency)==false)
                            {
                                MessageBox.Show("Invalid Qty Found in Line " + Count, "Excel Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            Sqlst = "SELECT TD.Prod_Code+'-'+TD.Prod_Name FROM dbo.Transaction_Details TD WHERE TD.Iid='OPS' AND TD.Loca='"+LoginManager.LocaCode+"' AND TD.Prod_Code='"+Code + "'";
                            ObjComm.getDataReader(Sqlst);
                            if(ObjComm.Adr.Read())
                            {
                                MessageBox.Show("Open Stock Available for Item "+ ObjComm.Adr[0].ToString() +" In Line" + Count, "Excel Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            if (Convert.ToDecimal(Qty) > 0)
                            {
                                Sqlst = "DECLARE @Err_x INT;EXEC [dbo].[sp_ToBeReturnTemp_UpdateFromExcel]  @Err_x = @Err_x OUTPUT,@Doc_No = N'" + lblTempDocNo.Text.Trim() + "',@Loca = N'" + LoginManager.LocaCode + "',@Prod_Code = N'" + Code + "',@Qty = " + Qty + ",@IId = 'OPS' ";
                                ObjComm.getDataSet(Sqlst, "ds");
                            }
                            Count++;
                        }


                        


                    }

                   Sqlst = "SELECT Prod_Code, Prod_Name, Selling_Price, Purchase_price, Pack_Size, Qty, Amount FROM TransactionTemp_Details	WHERE Doc_No = '"+lblTempDocNo.Text.Trim()+"' AND IId = 'OPS' AND Loca = '"+LoginManager.LocaCode+"' Order by Ln";
                    ObjComm.getDataSet(Sqlst, "ds");

                  
                    dataGridTempToBeReturn.DataSource = ObjComm.Ads.Tables[0];
                    dataGridTempToBeReturn.Refresh();
                  
                    if (dataGridTempToBeReturn.RowCount > 10)
                    {
                        dataGridTempToBeReturn.FirstDisplayedCell = dataGridTempToBeReturn[0, dataGridTempToBeReturn.RowCount - 6];
                    }
                  

                    objProductToBeReturn.GetTotalValues(ref opt);

                    lblTotalQty.Text = objProductToBeReturn.TotalQty.ToString();
                    lblTotalAmount.Text = objProductToBeReturn.TotalAmount.ToString();



                }
                else { return; }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

       


        clsCommon ObjComm = new clsCommon();
    }
}