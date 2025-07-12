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
    public partial class frmBarcode : Form
    {
        public frmBarcode()
        {
            InitializeComponent();
        }

        frmSearch search = new frmSearch();

        clsBarcode objBarcode = new clsBarcode();

        private string strQuery;
        private string strCostCode;

        //private string strQuery;

        private static frmBarcode Barcode;

        public static frmBarcode GetBarcode
        {
            get { return Barcode; }
            set { Barcode = value; }
        }

        private void frmBarcode_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Barcode = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmBarcode_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objBarcode.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objBarcode.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%'";
                    }
                    else
                    {
                        objBarcode.SqlStatement = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product";
                    }
                }

                objBarcode.DataetName = "dsProduct";
                objBarcode.GetItemDetails();

                search.dgSearch.DataSource = objBarcode.GetItemDataset.Tables["dsProduct"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objBarcode.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Pack_Size, product.Unit, Supplier_Id, product.Cost_Code FROM product WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F'";
                    objBarcode.ReadProductDetails();
                    if (objBarcode.RecordFound == true)
                    {
                        txtProductName.Text = objBarcode.ProductName;
                        txtSellingPrice.Text = (string)objBarcode.SellingPrice.ToString();
                        //txtSellingPrice.Text = string.Format("{0:0.00}", objBarcode.SellingPrice);
                        strCostCode = objBarcode.CostCode;
                        lblSuppCode.Text = objBarcode.SuppCode;
                        objBarcode.SqlStatement = "SELECT qty FROM tbBarcode WHERE Prod_Code = '" + objBarcode.ProductCode + "' AND MachineName = '" + System.Environment.MachineName.ToString() + "'";
                        objBarcode.ReadExsistProductDetails();
                        txtQty.Text = (string)objBarcode.Qty.ToString();
                        txtQty.Select(0, txtQty.Text.Trim().Length);
                   //     txtQty.Focus();

                        clsCommon objCommon = new clsCommon();
                        cmbBatchNo.DataSource = objCommon.Get_BatchList(txtProductCode.Text, true);
                        cmbBatchNo.DisplayMember = "BatchNo";
                        cmbBatchNo.ValueMember = "BatchNo";
                        cmbBatchNo.DroppedDown = true;
                        cmbBatchNo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtQty.Text) > 0 && cmbBatchNo.Text.Trim()!=string.Empty)
                {
                    
                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objBarcode.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Pack_Size, product.Unit, Supplier_Id, product.Cost_Code FROM product WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F'";
                    objBarcode.ReadProductDetails();
                    if (objBarcode.RecordFound == true)
                    {
                        txtProductName.Text = objBarcode.ProductName;
                        lblSuppCode.Text = objBarcode.SuppCode;

                        txtSellingPrice.Text = (string)objBarcode.SellingPrice.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductCode.Focus();
                        return;
                    }

                    objBarcode.ProductCode = cmbBatchNo.Text.Trim();
                    objBarcode.ProductName = txtProductName.Text.Trim();
                    objBarcode.Qty = decimal.Parse(txtQty.Text.ToString());
                    lblSuppCode.Text = objBarcode.SuppCode;

                    objBarcode.UpdateBarcodeTempDataSet();
                    //objBarcode.GetTempDataset();
                    dataGridViewBarcode.DataSource = objBarcode.TempBarcode.Tables["dsBarcode"];
                    dataGridViewBarcode.Refresh();

                    objBarcode.ReadTotalLabels();
                    lblTotalLabels.Text = objBarcode.TotalLabel.ToString();

                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtSellingPrice.Text = string.Empty;
                    txtQty.Text = "0";
                    txtCodeFrom.Enabled = false;
                    btnDocumentFrom.Enabled = false;
                    txtSuppCode.Enabled = false;
                    txtSuppName.Enabled = false;
                    btnSupplierSearch.Enabled = false;
                    cmbBatchNo.DataSource = null;
                    cmbBatchNo.Text = string.Empty;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                objBarcode.DeleteAllBarcodeTempDataSet();
                dataGridViewBarcode.DataSource = objBarcode.TempBarcode;
                dataGridViewBarcode.Refresh();

                foreach (DataRow row in objBarcode.ResultSet.Tables[0].Rows)
                {
                    cmbBarcodeType.Items.Add(row["BarcodeType"].ToString());
                }

                //cmbBarcodeType.Items.Add("Tag Sheet 25 Pcs.");
                //cmbBarcodeType.Items.Add("Tag Sheet 20 Pcs.");
                //cmbBarcodeType.Items.Add("Tag Sheet 16 Pcs.");
                //cmbBarcodeType.Items.Add("Tag Sheet Custom");
                //cmbBarcodeType.Items.Add("Sticker Sheet 140 Pcs.");
                //cmbBarcodeType.Items.Add("Sticker Sheet 108 Pcs.");
                //cmbBarcodeType.Items.Add("Sticker Sheet 70 Pcs.");
                //cmbBarcodeType.Items.Add("Sticker Sheet 48 Pcs.");
                //cmbBarcodeType.Items.Add("Sticker Sheet Custom");            
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewBarcode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBarcode.SelectedRows.Count <= 0 || dataGridViewBarcode.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    //objBarcode.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Pack_Size, product.Unit, Supplier_Id FROM product WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "'";
                    //  objBarcode.SqlStatement = "SELECT Prod_Code,Cost_Code, Prod_Name, Purchase_price, Selling_Price, Pack_Size, Unit, Supplier_Id FROM Product WHERE Prod_Code = '" + txtProductCode.Text.Trim() + "'";
                    //objBarcode.ReadProductDetails();
                   

                    txtProductCode.Text = dataGridViewBarcode.SelectedRows[0].Cells[0].Value.ToString();
                    int ProdCodeLenght = Settings.Default.ProdCodeLength + 4;


                    clsCommon objCommon = new clsCommon();
                    cmbBatchNo.DataSource = objCommon.Get_BatchList(txtProductCode.Text.Trim().Substring(0, ProdCodeLenght - 4), true);
                    cmbBatchNo.DisplayMember = "BatchNo";
                    cmbBatchNo.ValueMember = "BatchNo";

                    cmbBatchNo.SelectedValue = txtProductCode.Text.Trim();
                    txtProductCode.Text = txtProductCode.Text.Trim().Substring(0, ProdCodeLenght - 4);

                  

                    txtProductName.Text = dataGridViewBarcode.SelectedRows[0].Cells[1].Value.ToString();
                    txtSellingPrice.Text = dataGridViewBarcode.SelectedRows[0].Cells[2].Value.ToString();
                    txtQty.Text = dataGridViewBarcode.SelectedRows[0].Cells[3].Value.ToString();
                    lblSuppCode.Text = dataGridViewBarcode.SelectedRows[0].Cells[4].Value.ToString();
                    cmbBatchNo_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewBarcode.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objBarcode.ProductCode = dataGridViewBarcode.SelectedRows[0].Cells[0].Value.ToString();
                        objBarcode.DeleteBarcodeTempDataSet();
                        //objBarcode.GetTempDataset();
                        dataGridViewBarcode.DataSource = objBarcode.TempBarcode.Tables["dsBarcode"];
                        dataGridViewBarcode.Refresh();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                Barcode = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            double dblQty;
            int count;
            if (dataGridViewBarcode.RowCount == 0)
            {
                MessageBox.Show("Enter barcode detail in order to print", "No detail found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbBarcodeType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Barcode Type.", "Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Write to Log
            FileStream fileStream = new FileStream(@"C:\barcode\BarcodeSource.txt", FileMode.Create);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                objBarcode.BarcodePrint(txtCodeFrom.Text.Trim().ToUpper());

                foreach (DataRow row in objBarcode.TempBarcode.Tables[0].Rows)
                {
                    string columnsValue = "";
                    for (int i = 0; i < objBarcode.TempBarcode.Tables[0].Columns.Count; i++)
                    {
                        columnsValue = columnsValue + row[i] + ",";
                    }
                    columnsValue = columnsValue.Remove(columnsValue.LastIndexOf(","));
                    m_streamWriter.WriteLine(columnsValue);
                }

                //Barcode Software
                System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
                processStartInfo.FileName = @"C:\barcode\LW.exe";
                processStartInfo.Arguments = @"C:\barcode\" + cmbBarcodeType.Text.ToString() + ".lbl";
                System.Diagnostics.Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());    
            }

            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objBarcode.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objBarcode.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objBarcode.ReadSupplierDetails();
                    if (objBarcode.RecordFound == true)
                    {
                        txtSuppCode.Text = objBarcode.SuppCode;
                        txtSuppName.Text = objBarcode.SuppName;
                        txtSuppName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objBarcode.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code ASC";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objBarcode.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code ASC";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            objBarcode.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name ASC";
                        }
                    }
                }
                objBarcode.DataetName = "dsSupplier";
                objBarcode.GetSupplierDetails();
                search.dgSearch.DataSource = objBarcode.GetSupplierDataset.Tables["dsSupplier"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDocumentFrom_Click(object sender, EventArgs e)
        {
            if (search.IsDisposed)
            {
                search = new frmSearch();
            }

            string Date = dpDate.Text;
            if (chkAll.Checked)
            { Date = ""; }
            if (txtSuppCode.Text.Trim() != string.Empty)
            {
                strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' and Transaction_Header.post_date like '%"+Date+"%' ORDER BY RIGHT(Doc_No,6) DESC";

            }
            else
            {
                strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Doc_No LIKE'%" + txtCodeFrom.Text.Trim() + "' and Transaction_Header.post_date like '%" + Date + "%' ORDER BY RIGHT(Doc_No,6) DESC";
            }
            objBarcode.SqlStatement = strQuery;
            objBarcode.dsName = "Table";
            objBarcode.RetriveData();

            search.dgSearch.DataSource = objBarcode.ResultSet.Tables["Table"];
            search.Show();

            search.prop_Focus = txtCodeFrom;
        }

        private void txtCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCodeFrom.Text.Trim() != string.Empty )
                {
                    objBarcode.Grn = txtCodeFrom.Text.Trim();
                    objBarcode.SqlStatement = "select Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Supp_Code, Supplier.Supp_name from Transaction_Header inner join Supplier on Transaction_Header.Supplier_Id = Supplier.Supp_Code where Transaction_Header.Iid = 'GRN' and Transaction_Header.Doc_no = '"+ txtCodeFrom.Text.Trim()  +"' and Transaction_Header.Loca = '" + LoginManager.LocaCode + "'";
                    objBarcode.ReadGrnDetails();
                    if (objBarcode.RecordFound == true)
                    {
                        txtSuppCode.Text = objBarcode.SuppCode.Trim();
                        txtSuppName.Text = objBarcode.SuppName.Trim();
                       
                        objBarcode.Date = "";
                        objBarcode.GoodReceivedNoteLoad();
                        //objBarcode.GetTempDataset();
                        dataGridViewBarcode.DataSource = objBarcode.TempBarcode.Tables["dsBarcode"];
                        dataGridViewBarcode.Refresh();
                        txtSuppCode.Enabled = false;
                        txtSuppName.Enabled = false;
                        btnSupplierSearch.Enabled = false;

                        search.Code = string.Empty;
                        search.Descript = string.Empty;
                        txtProductCode.Text = string.Empty;
                        txtProductName.Text = string.Empty;
                        txtQty.Text = string.Empty;
                        txtSellingPrice.Text = string.Empty;
                        txtQty.Text = "0";
                        txtCodeFrom.Enabled = false;
                        btnDocumentFrom.Enabled = false;
                        txtSuppCode.Enabled = false;
                        txtSuppName.Enabled = false;
                        btnSupplierSearch.Enabled = false;

                        txtProductCode.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Good Received Note Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCodeFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCodeFrom.Text = search.Code.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.D)
                    {
                        this.btnDisplay.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 012.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbBatchNo.Text.Trim() != string.Empty && e.KeyCode==Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsCommon objCommon = new clsCommon();
                if (cmbBatchNo.Text != "")
                {
                    DataTable dtBatch = objCommon.Get_BatchDetails(txtProductCode.Text.Trim(), cmbBatchNo.Text.Trim());
                    if (dtBatch != null && dtBatch.Rows.Count > 0)
                    {
                         txtSellingPrice.Text = dtBatch.Rows[0]["Ret_Price"].ToString();
                       
                    }
                   

                }
               
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dpDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    objBarcode.Grn = "";
                    objBarcode.Date = dpDate.Text;
                    objBarcode.GoodReceivedNoteLoad();
                    //objBarcode.GetTempDataset();
                    dataGridViewBarcode.DataSource = objBarcode.TempBarcode.Tables["dsBarcode"];
                    dataGridViewBarcode.Refresh();
                    txtSuppCode.Enabled = false;
                    txtSuppName.Enabled = false;
                    btnSupplierSearch.Enabled = false;

                    txtSuppCode.Text = txtSuppName.Text = "";
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtSellingPrice.Text = string.Empty;
                    txtQty.Text = "0";
                    txtCodeFrom.Enabled = false;
                    btnDocumentFrom.Enabled = false;
                    txtSuppCode.Enabled = false;
                    txtSuppName.Enabled = false;
                    btnSupplierSearch.Enabled = false;

                    txtProductCode.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

    }
}