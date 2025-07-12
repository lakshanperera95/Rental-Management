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
    
    public partial class frmStockAdjustment : Form
    {

        clsStockAdjustment objStockAdjustment = new clsStockAdjustment();
        
        public frmStockAdjustment()
        {
            InitializeComponent();
        }

        private static frmStockAdjustment StockAdjust;
        private frmSearch search = new frmSearch();
        public static frmStockAdjustment GetStockAdjust
        {
            get
            {
                return StockAdjust;
            }
            set
            {
                StockAdjust = value;
            }
        }

        bool prodSearching = false;
        private void frmStockAdjustment_Load(object sender, EventArgs e)
        {
            try
            {
                objStockAdjustment.SqlString = "SELECT Temp_Sta FROM DocumentNoDetails WHERE Loca = ";
                objStockAdjustment.GetTempDocumentNo();
                lblDocumentNo.Text = objStockAdjustment.TempDocNo;
                dataGridTempGrn.DataSource = objStockAdjustment.GetTempStockAdjustDataSet;
                dataGridTempGrn.Refresh();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (txtProductCode.Text.Trim ()!=string.Empty )
                {
                    objStockAdjustment.SqlString = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Code LIKE '%'+'" + txtProductCode.Text.Trim() + "'+'%' ORDER BY Prod_Code";

                }
                else if (txtProductName.Text.Trim()!=string.Empty)
                {
                    objStockAdjustment.SqlString = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product WHERE Prod_Name LIKE '%'+'" + txtProductName.Text.Trim() + "'+'%' ORDER BY Prod_Name";

                }
                else
                {
                    objStockAdjustment.SqlString = "SELECT Prod_Code AS [Product Code],Prod_Name AS [Product Name] FROM Product ORDER BY Prod_Code";

                }

                objStockAdjustment.DataetName = "dsProduct";
                objStockAdjustment.GetItemDetails();
                search.dgSearch.DataSource = objStockAdjustment.GetItemDataset.Tables["dsProduct"];
                search.prop_Focus = txtProductCode;
                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y+100);

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                    txtProductCode.Text = search.Code.Trim(); ;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Escape)
                {
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    cmbBatch.DataSource = null;
                    txtProductCode.Focus();
                    return;
                }
                if (e.KeyCode == Keys.Enter && txtProductCode.Text.Trim() == string.Empty)
                {
                    txtProductName.Focus();
                    return;
                }
                    if (e.KeyCode == Keys.Enter && txtProductCode.Text.Trim()!=string.Empty)
                {

                    objStockAdjustment.SqlString = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem='F' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) and Stock_Master.Loca = ";
                    objStockAdjustment.ReadProductDetails();
                    if (objStockAdjustment.ProductName != string.Empty)
                    {
                        txtProductCode.Text = objStockAdjustment.ProductCode;
                        txtProductName.Text = objStockAdjustment.ProductName;
                        lblCurrentQty.Text = (string)objStockAdjustment.CurrentQty.ToString();

                        clsCommon objCommon = new clsCommon();

                        cmbBatch.DataSource = objCommon.Get_BatchList(txtProductCode.Text,true);
                        cmbBatch.DisplayMember = "BatchNo";
                        cmbBatch.ValueMember = "BatchNo";

                        if (Settings.Default.SingleBatch == false)
                        {
                            cmbBatch.SelectedValue = -1;
                            cmbBatch.DroppedDown = true;
                            cmbBatch.Focus();
                        }
                        else
                        {
                            cmbBatch.SelectedIndex = 0;
                            cmbBatch_SelectedIndexChanged(sender, e);
                            txtPhysicalQty.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Stock Adjustment Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPhysicalQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhysicalQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtPhysicalQty.Text, System.Globalization.NumberStyles.Number) == true)
                {
                    objStockAdjustment.SqlString = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem='F' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) and Stock_Master.Loca = ";
                    objStockAdjustment.ReadProductDetails();
                    if (objStockAdjustment.ProductName == string.Empty)
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Stock Adjustment Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (cmbBatch.SelectedIndex == -1)
                    {
                        MessageBox.Show("Batch Not Found. Please Check Batch.", "Stock Adjustment Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbBatch.DroppedDown = true;
                        cmbBatch.Focus();
                        return;
                    }

                    objStockAdjustment.ProductCode = txtProductCode.Text.Trim();
                    objStockAdjustment.ProductName = txtProductName.Text.Trim();
                    objStockAdjustment.CurrentQty = decimal.Parse(lblCurrentQty.Text.ToString());
                    objStockAdjustment.PhyQty = decimal.Parse(txtPhysicalQty.Text.ToString());
                    objStockAdjustment.BatchNo = cmbBatch.Text.Trim();

                    objStockAdjustment.UpdateStockAdjustDataSet();
                    objStockAdjustment.GetTempDataset();

                    dataGridTempGrn.DataSource = objStockAdjustment.GetTempStockAdjustDataSet.Tables["StockAdjust"];
                    dataGridTempGrn.Refresh();
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtPhysicalQty.Text = string.Empty;
                    lblCurrentQty.Text = string.Empty;
                    lblVarienceQty.Text = string.Empty;
                    cmbBatch.DataSource = null;
                    cmbBatch.SelectedIndex = -1;

                    objStockAdjustment.GetTotalValues();

                    lblTotalcurrQty.Text = objStockAdjustment.CurrentTotalQty.ToString();
                    lblTotalPhysicalQty.Text = objStockAdjustment.PhyTotalQty.ToString();
                    decimal f = objStockAdjustment.PhyTotalQty - objStockAdjustment.CurrentTotalQty;
                    lblTotalVarienceQty.Text = f.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objStockAdjustment = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                DataSet dsDataForReport = new DataSet();
                frmReportViewer objRepViewer = new frmReportViewer();
                objRepViewer.Text = this.Text;
                objStockAdjustment.SqlString = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'STA' AND TransactionTemp_Details.Doc_No = '" + lblDocumentNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objStockAdjustment.ReadTempTransDetails();
                if (objStockAdjustment.RecordFound != true)
                {
                    MessageBox.Show("Stock Adjustment Note Details Not Found.", "Stock Adjustment Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
           
                objStockAdjustment.Memo = txtMemo.Text.ToString();
                objStockAdjustment.StockAdjustApply();
                MessageBox.Show("Stock Adjustment Successfully Applied as Document No. " + objStockAdjustment.OrgDocNo, "Stock Adjustment Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objStockAdjustment.GetDataSetForReport();
                dsDataForReport = objStockAdjustment.GetReportDataset;
                rptStockAdjustment StockAdjustment = new rptStockAdjustment();
                StockAdjustment.SetDataSource(dsDataForReport);

                objRepViewer.crystalReportViewer1.ReportSource = StockAdjustment;
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();

                this.Close();
                this.Dispose();
                StockAdjust = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void lblCurrentQty_Click(object sender, EventArgs e)
        {

        }

        private void frmStockAdjustment_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                StockAdjust = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStockAdjustment_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempGrn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridTempGrn.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Transfer Of Goods Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes);
                    {
                        objStockAdjustment.TempDocNo = lblDocumentNo.Text.Trim();
                        objStockAdjustment.ProductCode = dataGridTempGrn.SelectedRows[0].Cells[0].Value.ToString();
                        objStockAdjustment.BatchNo = dataGridTempGrn.SelectedRows[0].Cells[2].Value.ToString();
                      
                        objStockAdjustment.DeleteProductDetaile();

                        objStockAdjustment.GetTempDataset();
                        dataGridTempGrn.DataSource = objStockAdjustment.GetTempStockAdjustDataSet.Tables["StockAdjust"];
                        dataGridTempGrn.Refresh();
                        objStockAdjustment.GetTotalValues();

                        lblTotalcurrQty.Text = objStockAdjustment.CurrentTotalQty.ToString();
                        lblTotalPhysicalQty.Text = objStockAdjustment.PhyTotalQty.ToString();
                        decimal f = objStockAdjustment.PhyTotalQty - objStockAdjustment.CurrentTotalQty;
                        lblTotalVarienceQty.Text = f.ToString();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempGrn_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            try
            {
                this.Close();
                this.Dispose();
                StockAdjust = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStockAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockAdjustment 013.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsCommon objCommon = new clsCommon();
                if (cmbBatch.Text != "")
                {
                    DataTable dtBatch = objCommon.Get_BatchDetails(txtProductCode.Text.Trim(), cmbBatch.Text.Trim());
                    if (dtBatch != null && dtBatch.Rows.Count > 0)
                    {

                      
                        lblCurrentQty.Text = dtBatch.Rows[0]["Stock"].ToString();
                        objStockAdjustment.PurchasePrice = decimal.Parse(dtBatch.Rows[0]["Purchase_Price"].ToString());
                        objStockAdjustment.SellingPrice = decimal.Parse(dtBatch.Rows[0]["Ret_Price"].ToString());

                     
                    }
                  

                }
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void cmbBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhysicalQty.Focus();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Blocking Cursor Moving
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;                  
                                         
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    cmbBatch.DataSource = null; 
                    txtProductCode.Focus();
                    return;
                }
                //Product Serch Selection
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    search.Focus();

                }
                if (txtProductName.Text != string.Empty)
                {
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

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 )
            {
                btnItemSearch.PerformClick();
                txtProductName.Focus();
            }
        }
    }
}