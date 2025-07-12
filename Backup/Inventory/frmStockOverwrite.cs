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
    public partial class frmStockOverwrite : Form
    {
        public frmStockOverwrite()
        {
            InitializeComponent();
        }

        private  static frmStockOverwrite StockOverwrite;
        private frmSearch search = new frmSearch();

        public static frmStockOverwrite GetStockOverwrite
        {
            get
            {
                return StockOverwrite;
            }
            set {
                StockOverwrite = value;
            }

        }

        private clsStockOverwrite ObjStockOverwrite = new clsStockOverwrite();

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (optDepartment.Checked == true)
                {
                    ObjStockOverwrite.SqlString = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                    ObjStockOverwrite.DataSetName = "dsDept";
                    ObjStockOverwrite.GetProduct();
                    search.dgSearch.DataSource = ObjStockOverwrite.ItemDataSet.Tables["dsDept"];
                    search.prop_Focus = txtCode;
                    search.Cont_Descript = txtDescr;
                    search.Show();
                }
                if (optCategory.Checked == true)
                {
                    ObjStockOverwrite.SqlString = "SELECT Cat_Code AS [Category Code], Cat_Name AS [Category Name] FROM Category ORDER BY Cat_Code";
                    ObjStockOverwrite.DataSetName = "dsCat";
                    ObjStockOverwrite.GetProduct();
                    search.dgSearch.DataSource = ObjStockOverwrite.ItemDataSet.Tables["dsCat"];
                    search.prop_Focus = txtCode;
                    search.Cont_Descript = txtDescr;
                    search.Show();
                }
                if (optSupplier.Checked == true)
                {
                    ObjStockOverwrite.SqlString = "SELECT  Supp_Code [Supplier Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                    ObjStockOverwrite.DataSetName = "dsSupplier";
                    ObjStockOverwrite.GetProduct();
                    search.dgSearch.DataSource = ObjStockOverwrite.ItemDataSet.Tables["dsSupplier"];
                    search.prop_Focus = txtCode;
                    search.Cont_Descript = txtDescr;
                    search.Show();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    btnDownload.Focus();

                    //if (optDepartment.Checked == true)
                    //{
                    //    if (ObjStockOverwrite.ProductName != string.Empty)
                    //    {
                    //        this.dataGridTempGrn.DataSource = ObjStockOverwrite.ItemDataSet.Tables["empty"];
                    //        this.dataGridTempGrn.Refresh();
                    //        ObjStockOverwrite.SqlString = "SELECT P.Prod_Code, P.Prod_Name, P.Purchase_price, P.Selling_Price,P.Pack_Size,S.Qty [Curr_Qty],'00' [Phy_Qty],'00' [Var_Qty] FROM Product P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code WHERE P.Department_Id = '" + txtProductCode.Text.Trim() + "' ORDER BY P.Prod_Code";
                    //        ObjStockOverwrite.DataetName = "dsLocation";
                    //        ObjStockOverwrite.GetProduct();
                    //        this.dataGridTempGrn.DataSource = ObjStockOverwrite.ItemDataSet.Tables["dsLocation"];
                    //        ObjStockOverwrite.ItemDataSet.Dispose();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Location Code Not Found. Please Check Product Code.", "Stock Adjustment Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    //if (optCategory.Checked == true)
                    //{
                    //    if (ObjStockOverwrite.ProductName != string.Empty)
                    //    {
                    //        this.dataGridTempGrn.DataSource = ObjStockOverwrite.ItemDataSet.Tables["empty"];
                    //        this.dataGridTempGrn.Refresh();
                    //        ObjStockOverwrite.SqlString = "SELECT P.Prod_Code, P.Prod_Name, P.Purchase_price, P.Selling_Price,P.Pack_Size,S.Qty [Curr_Qty],'00' [Phy_Qty],'00' [Var_Qty] FROM Product P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code WHERE P.Category_Id = '" + txtProductCode.Text.Trim() + "' ORDER BY P.Prod_Code";
                    //        ObjStockOverwrite.DataetName = "dsCategory";
                    //        ObjStockOverwrite.GetProduct();
                    //        this.dataGridTempGrn.DataSource = ObjStockOverwrite.ItemDataSet.Tables["dsCategory"];
                    //        ObjStockOverwrite.ItemDataSet.Dispose();

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Location Code Not Found. Please Check Product Code.", "Stock Adjustment Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    //if (optSupplier.Checked == true)
                    //{
                    //    if (ObjStockOverwrite.ProductName != string.Empty)
                    //    {
                    //        this.dataGridTempGrn.DataSource = ObjStockOverwrite.ItemDataSet.Tables["empty"];
                    //        this.dataGridTempGrn.Refresh();
                    //        ObjStockOverwrite.SqlString = "SELECT P.Prod_Code, P.Prod_Name, P.Purchase_price, P.Selling_Price,P.Pack_Size,S.Qty [Curr_Qty],'00' [Phy_Qty],'00' [Var_Qty] FROM Product P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code WHERE P.Supplier_Id = '" + txtProductCode.Text.Trim() + "' ORDER BY P.Supplier_Id";
                    //        ObjStockOverwrite.DataetName = "dsCategory";
                    //        ObjStockOverwrite.GetProduct();
                    //        this.dataGridTempGrn.DataSource = ObjStockOverwrite.ItemDataSet.Tables["dsCategory"];
                    //        ObjStockOverwrite.ItemDataSet.Dispose();

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Location Code Not Found. Please Check Product Code.", "Stock Adjustment Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStockOverwrite_Load(object sender, EventArgs e)
        {
            try
            {
                ObjStockOverwrite.SqlString = "SELECT Temp_Sta FROM DocumentNoDetails WHERE Loca = ";
                ObjStockOverwrite.GetTempDocumentNo();
                lblDocumentNo.Text = ObjStockOverwrite.TempDocNo;
                dataGridTempGrn.DataSource = ObjStockOverwrite.GetTempStockAdjustDataSet;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                ObjStockOverwrite.StockAdjustApply();
                MessageBox.Show("Stock Adjustment Successfully Applied as Document No. " + ObjStockOverwrite.OrgDocNo, "Stock Adjustment Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ObjStockOverwrite.GetDataSetForReport();
                dsDataForReport = ObjStockOverwrite.GetReportDataset;
                rptStockAdjustment StockAdjustment = new rptStockAdjustment();
                StockAdjustment.SetDataSource(dsDataForReport);
                objRepViewer.Text = this.Text;
                objRepViewer.crystalReportViewer1.ReportSource = StockAdjustment;
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();

                this.Close();
                this.Dispose();
                StockOverwrite = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStockOverwrite_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                StockOverwrite = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (optDepartment.Checked == true)
                {
                    ObjStockOverwrite.Iid = "DP";
                    ObjStockOverwrite.Code = txtCode.Text.Trim();
                    ObjStockOverwrite.SelectStockData();
                    ObjStockOverwrite.GetTempDataset();
                    this.dataGridTempGrn.DataSource = ObjStockOverwrite.GetTempStockAdjustDataSet.Tables["StockAdjust"];
                    //ObjStockOverwrite.ItemDataSet.Dispose();
                    optCategory.Enabled = false;
                    optSupplier.Enabled = false;
                    optLocation.Enabled = false;
                }
                if (optCategory.Checked == true)
                {
                    ObjStockOverwrite.Iid = "CT";
                    ObjStockOverwrite.Code = txtCode.Text.Trim();
                    ObjStockOverwrite.SelectStockData();
                    ObjStockOverwrite.GetTempDataset();
                    this.dataGridTempGrn.DataSource = ObjStockOverwrite.GetTempStockAdjustDataSet.Tables["StockAdjust"];
                    //ObjStockOverwrite.ItemDataSet.Dispose();
                    optDepartment.Enabled = false;
                    optSupplier.Enabled = false;
                    optLocation.Enabled = false;
                }
                if (optSupplier.Checked == true)
                {
                    ObjStockOverwrite.Iid = "SP";
                    ObjStockOverwrite.Code = txtCode.Text.Trim();
                    ObjStockOverwrite.SelectStockData();
                    ObjStockOverwrite.GetTempDataset();
                    this.dataGridTempGrn.DataSource = ObjStockOverwrite.GetTempStockAdjustDataSet.Tables["StockAdjust"];
                    //ObjStockOverwrite.ItemDataSet.Dispose();
                    optDepartment.Enabled = false;
                    optCategory.Enabled = false;
                    optLocation.Enabled = false;
                }
                if (optLocation.Checked == true)
                {
                    ObjStockOverwrite.Iid = "PR";
                    ObjStockOverwrite.Code = "";
                    ObjStockOverwrite.SelectStockData();
                    ObjStockOverwrite.GetTempDataset();
                    this.dataGridTempGrn.DataSource = ObjStockOverwrite.GetTempStockAdjustDataSet.Tables["StockAdjust"];
                    //ObjStockOverwrite.ItemDataSet.Dispose();
                    optCategory.Enabled = false;
                    optSupplier.Enabled = false;
                    optDepartment.Enabled = false;
                }
                ObjStockOverwrite.GetTotalValues();

                lblTotalcurrQty.Text = ObjStockOverwrite.CurrentTotalQty.ToString();
                lblTotalPhysicalQty.Text = ObjStockOverwrite.PhyTotalQty.ToString();
                decimal f = ObjStockOverwrite.PhyTotalQty - ObjStockOverwrite.CurrentTotalQty;
                lblTotalVarienceQty.Text = f.ToString();
                btnDownload.Enabled = false;
               
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (txtCode.Text.Trim() != string.Empty)
                {
                    btnDownload.Enabled = true;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                StockOverwrite = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmStockOverwrite_KeyDown(object sender, KeyEventArgs e)
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOverwrite 011.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void optCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (optCategory.Checked == true)
            {
                btnDownload.Enabled = false;
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        private void optProduct_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (optLocation.Checked == true)
            {
                txtCode.Enabled = false;
                txtDescr.Enabled = false;
                txtCode.Text = string.Empty;
                txtDescr.Text = string.Empty;
                btnDownload.Enabled = true;
                btnItemSearch.Enabled = false;
            }
            else
            {
                txtCode.Enabled = true;
                txtDescr.Enabled = true;
                btnDownload.Enabled = false;
                btnItemSearch.Enabled = true;
            }
        }

        private void btnReadStock_Click(object sender, EventArgs e)
        {
                try
                {
                    if (optPosSalesData.Checked == true)
                    {
                        ObjStockOverwrite.ImportData();
                    }
                    else
                    {
                        ObjStockOverwrite.ImportTextData();
                    }
                    MessageBox.Show("Data Importing Completed Successfully.", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                catch (Exception ex)
                {
                    //Write to Log
                    DateTime dtCurrentDate = DateTime.Now;
                    FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmStockOvewrite 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void optSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (optSupplier.Checked == true)
            {
                btnDownload.Enabled = false;
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        private void optDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (optDepartment.Checked == true)
            {
                btnDownload.Enabled = false;
            }
            else
            {
                btnDownload.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void dataGridTempGrn_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ( dataGridTempGrn.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    txtProductCode.Text = dataGridTempGrn.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductCode_KeyDown_1(sender,new KeyEventArgs(Keys.Enter));

                    cmbBatch.Text=dataGridTempGrn.SelectedRows[0].Cells[2].Value.ToString();

                    txtPhysicalQty.Focus();
                }
            }
            catch (Exception Ex)
            {

                clsClear.ErrMessage(Ex.ToString(), Ex.StackTrace);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    objStockAdjustment.SqlString = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem='F' AND (product.Prod_Code = '" + txtCode.Text.Trim() + "' OR (Product.Barcode = '" + txtCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) and Stock_Master.Loca = ";
                    objStockAdjustment.ReadProductDetails();
                    if (objStockAdjustment.ProductName != string.Empty)
                    {
                        txtCode.Text = objStockAdjustment.ProductCode;
                        txtDescr.Text = objStockAdjustment.ProductName;
                        lblCurrentQty.Text = (string)objStockAdjustment.CurrentQty.ToString();

                        clsCommon objCommon = new clsCommon();

                        cmbBatch.DataSource = objCommon.Get_BatchList(txtCode.Text, true);
                        cmbBatch.DisplayMember = "BatchNo";
                        cmbBatch.ValueMember = "BatchNo";



                        cmbBatch.SelectedValue = -1;


                        cmbBatch.DroppedDown = true;
                        cmbBatch.Focus();
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

        private void txtProductCode_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    objStockAdjustment.SqlString = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE LockedItem='F' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) and Stock_Master.Loca = ";
                    objStockAdjustment.ReadProductDetails();
                    if (objStockAdjustment.ProductName != string.Empty)
                    {
                        txtProductCode.Text = objStockAdjustment.ProductCode;
                        txtProductName.Text = objStockAdjustment.ProductName;
                        lblCurrentQty.Text = (string)objStockAdjustment.CurrentQty.ToString();

                        clsCommon objCommon = new clsCommon();

                        cmbBatch.DataSource = objCommon.Get_BatchList(txtProductCode.Text, true);
                        cmbBatch.DisplayMember = "BatchNo";
                        cmbBatch.ValueMember = "BatchNo";



                        cmbBatch.SelectedValue = -1;


                        cmbBatch.DroppedDown = true;
                        cmbBatch.Focus();
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

        clsStockAdjustment objStockAdjustment = new clsStockAdjustment();
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

                    objStockAdjustment.TempDocNo = lblDocumentNo.Text.Trim();
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
    }
}