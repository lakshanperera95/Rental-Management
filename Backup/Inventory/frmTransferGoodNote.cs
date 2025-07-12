using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using CrystalDecisions.Shared;

namespace Inventory
{
    public partial class frmTransferGoodNote : Form
    {
        private string selectquery;
        clsTransferGoodNote objTransferNote = new clsTransferGoodNote();
        public frmTransferGoodNote()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtQty, System.Globalization.NumberStyles.Currency);
        }

        private static frmTransferGoodNote TransferNote;

        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();

        public static frmTransferGoodNote GetTransferNote
        {
            get { return TransferNote; }
            set { TransferNote = value; }
        }

        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location  WHERE Loca <> '" + LoginManager.LocaCode + "' ORDER BY Loca";

                search.dgSearch.DataSource = clsRetriveGenaral.combofill1(selectquery).Tables["Table"];
                search.Show();
                search.prop_Focus = txtLocaCode;
                txtLocaName.Text = search.Descript;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocaCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLocaCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtLocaCode.Text = search.Code.Trim();
                    txtLocaName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Display Departemnt
                    if (txtLocaCode.Text.Trim() != ""  && txtLocaCode.Text.Trim() != lblLocaCode.Text.Trim())
                    {
                        objTransferNote.ToLocaCode = txtLocaCode.Text.ToString().Trim();
                        objTransferNote.SqlStatement = "SELECT Loca, Loca_Descrip FROM location WHERE Loca = '";
                        objTransferNote.ReadToLocationCode();
                        if (objTransferNote.ToLocaName != string.Empty)
                        {
                            txtLocaName.Text = objTransferNote.ToLocaName;
                            txtReference.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Locaion Code Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtLocaCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransferGoodNote_Load(object sender, EventArgs e)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                lblDate.Text  = string.Format("{0:dd/MM/yyyy}", PostDate);

                objTransferNote.SqlStatement = "SELECT Temp_Tog FROM DocumentNoDetails WHERE Loca = ";
                objTransferNote.GetTempDocumentNo();
                lblTempDocNo.Text = objTransferNote.TempDocNo;
                dataGridTempTGN.DataSource = objTransferNote.TempTransferNote;
                dataGridTempTGN.Refresh();
                objTransferNote.SqlStatement = "SELECT Loca, Loca_Descrip FROM location WHERE Loca = ";
                objTransferNote.ReadFromLocationCode();
                lblLocaCode.Text = objTransferNote.LocaCode;
                lblLocaName.Text = objTransferNote.LocaName;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                TransferNote = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    objTransferNote.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' AND P.Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%' ORDER BY P.Prod_Code";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objTransferNote.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' AND P.Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' ORDER BY P.Prod_Name";
                    }
                    else
                    {
                        objTransferNote.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F' ORDER BY P.Prod_Code";
                    }
                }

                objTransferNote.DataetName = "dsProduct";
                objTransferNote.GetItemDetails();
                ProductSearch.dgSearch.DataSource = objTransferNote.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[2].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                for (int i = 0; i < objTransferNote.GetItemDataset.Tables["dsProduct"].Columns.Count; i++)
                {
                    ProductSearch.dgSearch.Columns[i].ReadOnly = true;
                }
                ProductSearch.dgSearch.DataSource = objTransferNote.GetItemDataset.Tables["dsProduct"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objTransferNote.ToLocaCode = txtLocaCode.Text.ToString().Trim();
                    objTransferNote.SqlStatement = "SELECT Loca, Loca_Descrip FROM location WHERE Loca = '";
                    objTransferNote.ReadToLocationCode();
                    if (objTransferNote.ToLocaName == string.Empty)
                    {
                        MessageBox.Show("Destination Location Not Found. Please Select Destination Locatin.", "Transfer Goods Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLocaCode.Focus();
                        return;
                    }

                    objTransferNote.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, CAST(product.Purchase_price AS DECIMAL(18,3))[Purchase_price], CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) AND LockedItem='F'  and Stock_Master.Loca = ";
                    objTransferNote.ReadProductDetails();
                    if (objTransferNote.ProductName != string.Empty)
                    {
                        txtProductCode.Text = objTransferNote.ProductCode;
                        txtProductName.Text = objTransferNote.ProductName;
                        lblCurrentQty.Text = (string)objTransferNote.CurrentQty.ToString();
                        lblPurchasePrice.Text = (string)objTransferNote.PurchasePrice.ToString();
                        lblSellingPrice.Text = (string)objTransferNote.SellingPrice.ToString();
                        objTransferNote.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objTransferNote.ProductCode + "' AND Doc_No = '" + objTransferNote.TempDocNo + "' AND IId = 'TGN' AND Loca = ";
                        objTransferNote.ReadExsistProductDetails();
                        if (objTransferNote.RecordFound == true)
                        {
                            txtQty.BackColor = System.Drawing.Color.OrangeRed;
                        }
                        else
                        {
                            txtQty.BackColor = System.Drawing.Color.White;
                        }

                        txtQty.Text = (string)objTransferNote.Qty.ToString();
                        txtQty.Focus(); txtQty.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Transfer Goods Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtQty.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtQty.Text) > 0)
                {
                    if (lblLocaCode.Text.Trim() == txtLocaCode.Text.Trim())
                    {
                        MessageBox.Show("Invalid Target Location(Location To). Please Select Other Location for Target Location.", "Transfer Of Goods Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLocaCode.Focus();
                        return;
                    }
                     objTransferNote.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, CAST(product.Purchase_price AS DECIMAL(18,3))[Purchase_price], CAST(product.Selling_Price AS DECIMAL(18,2))[Selling_Price], Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) AND LockedItem='F'  and Stock_Master.Loca = ";
                    objTransferNote.ReadProductDetails();
                    if (objTransferNote.ProductName == string.Empty)
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Transfer Goods Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    objTransferNote.ProductCode = txtProductCode.Text.Trim().ToUpper();
                    objTransferNote.ProductName = txtProductName.Text.Trim().ToUpper();
                    objTransferNote.CurrentQty = decimal.Parse(lblCurrentQty.Text.ToString());
                    objTransferNote.Qty = decimal.Parse(txtQty.Text.ToString());
                    objTransferNote.Amount = decimal.Parse(txtQty.Text.ToString()) * objTransferNote.SellingPrice;
                    objTransferNote.UpdateTransferNoteTempDataSet();
                    objTransferNote.GetTempDataset();
                    dataGridTempTGN.DataSource = objTransferNote.TempTransferNote.Tables["TransferNote"];
                    dataGridTempTGN.Refresh();
                    //Set Grid Last Record
                    if (dataGridTempTGN.RowCount > 10)
                    {
                        dataGridTempTGN.FirstDisplayedCell = dataGridTempTGN[0, dataGridTempTGN.RowCount - 6];
                    }
                    //******************
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    lblCurrentQty.Text = string.Empty;
                    txtLocaCode.ReadOnly = true;
                    txtLocaName.Enabled = false;
                    btnLocaSearch.Enabled = false;
                   // txtReference.Enabled = false;
                  //  txtRemarks.Enabled = false;

                    objTransferNote.GetTotalValues();

                    lblTotalQty.Text = objTransferNote.TotalQty.ToString();
                    lblTotalAmount.Text = objTransferNote.TotalAmount.ToString();
                    txtQty.BackColor = System.Drawing.Color.White;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objTransferNote.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'TOGAPP' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objTransferNote.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nSave this " + this.Text + " via authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                objTransferNote.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'TGN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objTransferNote.ReadTempTransDetails();
                if (objTransferNote.RecordFound != true)
                {
                    MessageBox.Show("Transfer Of Goods Note Details Not Found.", "Transfer Of Goods Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objTransferNote.SqlStatement = "SELECT * FROM Location WHERE Loca = '" + txtLocaCode.Text.Trim().ToString() + "'";
                objTransferNote.ReadTempTransDetails();
                if (objTransferNote.RecordFound != true)
                {
                    MessageBox.Show("Transfer Location Not Found.", "Transfer Of Goods Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLocaCode.Enabled = true;
                    txtLocaCode.Focus();
                    return;
                }

                objTransferNote.Remark = txtRemarks.Text.Trim();
                objTransferNote.Reference = txtReference.Text.Trim();
                objTransferNote.RecallSaveDocNo = txtGrnNo.Text.Trim().ToUpper().ToString();
                objTransferNote.ToLocaCode = txtLocaCode.Text.Trim();
                objTransferNote.TransferNoteApply();
                MessageBox.Show("Transfer Of Goods Note Successfully Applied as Document No. " + objTransferNote.OrgDocNo, "Transfer Of Goods Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //objTransferNote.GetDataSetForReport();
                dsDataForReport = objTransferNote.GetReportDataset;
                rptTransferNote TransferNote = new rptTransferNote();
                TransferNote.SetDataSource(dsDataForReport);

                objRepViewer.crystalReportViewer1.ReportSource = TransferNote;
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();

                this.Close();
                this.Dispose();
                TransferNote = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransferGoodNote_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransferGoodNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                TransferNote = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        }

        private void dataGridTempTGN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridTempTGN_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridTempTGN.SelectedRows.Count <= 0 || dataGridTempTGN.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductCode.Text = dataGridTempTGN.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dataGridTempTGN.SelectedRows[0].Cells[1].Value.ToString();
                    objTransferNote.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objTransferNote.ReadProductDetails();
                    lblCurrentQty.Text = (string)objTransferNote.CurrentQty.ToString();
                    txtQty.Text = dataGridTempTGN.SelectedRows[0].Cells[5].Value.ToString();
                    if (objTransferNote.GetUnit == "Nos")
                    {
                        txtQty.Text = string.Format("{0:0}", decimal.Parse(txtQty.Text.Trim()));
                    }
                    lblAmount.Text = dataGridTempTGN.SelectedRows[0].Cells[6].Value.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempTGN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridTempTGN.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Transfer Of Goods Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objTransferNote.TempDocNo = lblTempDocNo.Text.Trim();
                        objTransferNote.ProductCode = dataGridTempTGN.SelectedRows[0].Cells[0].Value.ToString();
                        objTransferNote.DeleteProductDetaile();
                        objTransferNote.GetTempDataset();
                        dataGridTempTGN.DataSource = objTransferNote.TempTransferNote.Tables["TransferNote"];
                        dataGridTempTGN.Refresh();

                        objTransferNote.GetTotalValues();

                        lblTotalQty.Text = objTransferNote.TotalQty.ToString();
                        lblTotalAmount.Text = objTransferNote.TotalAmount.ToString();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempTGN_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                clsDGV dg = new clsDGV();
                dg.invoke(e);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objTransferNote.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'TGN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objTransferNote.ReadTempTransDetails();
                if (objTransferNote.RecordFound != true)
                {
                    MessageBox.Show("Transfer Of Goods Note Details Not Found.", "Transfer Of Goods Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objTransferNote.Remark = txtRemarks.Text.Trim();

                objTransferNote.GetDataSetForPreview();
                dsDataForReport = objTransferNote.GetReportDataset;
                rptTransferNote TransferNote = new rptTransferNote();
                TransferNote.SetDataSource(dsDataForReport);
                objRepViewer.Text = this.Text;
                objRepViewer.crystalReportViewer1.ReportSource = TransferNote;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                objTransferNote.SqlStatement = "SELECT Doc_No [Document No], Post_Date + '  ' + Transaction_Save_Header.To_Loca + '  ' + Location.Loca_Descrip [To Location] FROM Transaction_Save_Header INNER JOIN location on Transaction_Save_Header.To_Loca = Location.Loca WHERE Iid = 'TGN' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                objTransferNote.DataetName = "Table";
                objTransferNote.GetItemDetails();

                search.dgSearch.DataSource = objTransferNote.GetItemDataset.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Load Saved Transfer Of Goods Note Document No :" + search.Code.Trim() + ". ", "Transfer Of Goods Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objTransferNote.RecallSaveDocNo = search.Code.Trim();
                        objTransferNote.SqlStatement = "SELECT Transaction_Save_Header.*, Location.Loca_Descrip FROM Transaction_Save_Header INNER JOIN Location ON Location.Loca = Transaction_Save_Header.To_Loca WHERE iid = 'TGN' AND Doc_No = '" + search.Code.Trim() + "' AND Transaction_Save_Header.Loca = ";
                        objTransferNote.ReadSavedDocument();
                        if (objTransferNote.RecordFound)
                        {
                            lblTempDocNo.Text = objTransferNote.TempDocNo;
                            txtLocaCode.Text = objTransferNote.ToLocaCode.ToString();
                            txtLocaName.Text = objTransferNote.ToLocaName.ToString();
                            txtReference.Text = objTransferNote.Reference.ToString();
                            txtRemarks.Text = objTransferNote.Remark.ToString();

                            objTransferNote.GetTempDataset();
                            dataGridTempTGN.DataSource = objTransferNote.TempTransferNote.Tables["TransferNote"];
                            dataGridTempTGN.Refresh();

                            objTransferNote.GetTotalValues();

                            lblTotalQty.Text = objTransferNote.TotalQty.ToString();
                            lblTotalAmount.Text = objTransferNote.TotalAmount.ToString();
                            txtLocaCode.ReadOnly = true;
                            txtLocaName.Enabled = false;
                           // btnLocaSearch.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "Transfer Of Goods Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    objTransferNote.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'TGN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objTransferNote.ReadTempTransDetails();
                    if (objTransferNote.RecordFound != true)
                    {
                        MessageBox.Show("Transfer Of Goods Note Details Not Found.", "Transfer Of Goods Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objTransferNote.Remark = txtRemarks.Text.Trim();
                    objTransferNote.Reference = txtReference.Text.Trim();
                    objTransferNote.TransferNoteSave();
                    MessageBox.Show("Transfer Of Goods Note Successfully Saved as Document No. " + objTransferNote.OrgDocNo, "Transfer Of Goods Note Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    this.Dispose();
                    TransferNote = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransferGoodNote_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && (txtLocaCode.Focused || txtLocaName.Focused))
                {
                    btnLocaSearch.PerformClick();
                }
                else if (e.KeyCode == Keys.F1 && (txtProductCode.Focused || txtProductName.Focused))
                {
                    btnItemSearch.PerformClick();
                }
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }

                    else if (e.KeyCode == Keys.P)
                    {
                        this.btnPreview.PerformClick();
                    }

                    else if (e.KeyCode == Keys.A)
                    {
                        this.btnApply.PerformClick();
                    }

                    else if (e.KeyCode == Keys.E)
                    {
                        this.btnClose.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferOfGoodsNote 022.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtGrnNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objTransferNote.TempDocNo = lblTempDocNo.Text.Trim().ToString();
                    objTransferNote.RecallSaveDocNo = txtGrnNo.Text.Trim();
                    objTransferNote.GrnIntoTgn();
                    dataGridTempTGN.DataSource = objTransferNote.GetItemDataset.Tables[0];
                    dataGridTempTGN.Refresh();

                    objTransferNote.GetTotalValues();
                    lblTotalQty.Text = objTransferNote.TotalQty.ToString();
                    lblTotalAmount.Text = objTransferNote.TotalAmount.ToString();
                    txtQty.BackColor = System.Drawing.Color.White;
                    txtProductCode.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (objTransferNote.GetUnit == "Nos")
                {
                    if (e.KeyChar == '.')
                    {
                        e.Handled = true;
                        MessageBox.Show("You can't insert decimals for units of product with Nos.", "Invalid Qty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (e.KeyChar == ',')
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar == '\b')
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        decimal d = 0;
                        e.Handled = !decimal.TryParse(txtQty.Text + e.KeyChar, out d);
                    }
                }
                else
                {
                    if (e.KeyChar == '\b')
                    {
                        e.Handled = false;
                    }
                    else if (e.KeyChar == ',')
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        decimal d = 0;
                        e.Handled = !decimal.TryParse(txtQty.Text + e.KeyChar, out d);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objTransferNote.GetDataReader.Close();
            }
        }

        private void dataGridTempTGN_MouseUp(object sender, MouseEventArgs e)
        {
            //DataGridView.HitTestInfo hittext = dataGridTempTGN.HitTest(e.X, e.Y);

            //pr CellTemplate.Controls.Add(txtProductCode);
            //txtProductCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objTransferNote.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'TGN' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objTransferNote.ReadTempTransDetails();
                if (objTransferNote.RecordFound != true)
                {
                    MessageBox.Show("" + this.Text + " Details Not Found.", "" + this.Text + " Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*
                objSupplierReturn.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'SRNAPP' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objSupplierReturn.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nDelete this " + this.Text + " Invoice through authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }*/
                if (MessageBox.Show("Are You sure you want to delete this document?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objTransferNote.SqlStatement = "EXEC sp_DeleteSavedDoc @DocNo = '" + lblTempDocNo.Text + "',  @Loca = '" + LoginManager.LocaCode + "', @Iid = 'TGN'";
                    objTransferNote.ReadTempTransDetails();
                    MessageBox.Show("Delete successfull!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                objTransferNote.Errormsg(ex, "frmSRN- btnDelete_Click");
            }
        }
    }
}