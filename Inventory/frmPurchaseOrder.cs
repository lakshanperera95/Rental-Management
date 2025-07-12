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
    public partial class frmPurchaseOrder : Form
    {

        private decimal decAmount;

        private string strDisc;

        private int intPosOfPerc;   // find Percentage mark on percentage
        private decimal fltDiscPer;
        private decimal decTaxAmount;

        clsPurchaseOrder objPon = new clsPurchaseOrder();

        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        private static frmPurchaseOrder Pon;

        private frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();

        public static frmPurchaseOrder GetPon
        {
            get { return Pon; }
            set { Pon = value; }
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                objPon.SqlStatement = "SELECT Temp_Po FROM DocumentNoDetails WHERE Loca = ";
                objPon.GetTempDocumentNo();
                lblTempDocNo.Text = objPon.TempDocNo;
                dataGridTempPON.DataSource = objPon.TempPon;
                dataGridTempPON.Refresh();
                txtPurchasePrice.Enabled = Inventory.Properties.Settings.Default.POCostEdit;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                Pon = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objPon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        objPon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            objPon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                        }
                        else
                        {
                            objPon.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                        }
                    }
                }
                objPon.DataetName = "dsSupplier";
                objPon.GetSupplierDetails();
                search.dgSearch.DataSource = objPon.GetSupplierDataset.Tables["dsSupplier"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objPon.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objPon.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objPon.ReadSupplierDetails();
                    if (objPon.RecordFound == true)
                    {
                        txtSuppCode.Text = objPon.SuppCode;
                        txtSuppName.Text = objPon.SuppName;
                        if (MessageBox.Show("Do You wan't To Load Re-Order Level Products", "Purchase Order Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            objPon.SelectReOrderProductDetaile();
                            objPon.GetTempDataset();
                            dataGridTempPON.DataSource = objPon.TempPon.Tables["PurchaseOrder"];
                            dataGridTempPON.Refresh();
                            txtTaxAmount.Text = "0";
                            txtCreditPeriod.Text = "0";
                            objPon.GetTotalValues();

                            lblTotalQty.Text = string.Format("{0:0.00}", objPon.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
                            txtTaxAmount.Enabled = true;
                        }
                        txtSuppName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Purchase Order Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                string withSupplier = (chkAccOtherSuppProd.Checked) ? "" : " AND P.Supplier_Id = '" + txtSuppCode.Text.Trim() + "'";
                
               
                if (txtProductCode.Text.Trim() != string.Empty && txtProductName.Text.Trim() == string.Empty)
                {
                    objPon.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND  (P.Prod_Code Like '%" + txtProductCode.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductCode.Text.Trim() + "%') " + withSupplier + " ORDER BY P.Prod_Code";
                }
                else if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                {
                    objPon.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND  (P.Prod_Code Like '%" + txtProductName.Text.Trim() + "%' Or P.Barcode Like '%" + txtProductName.Text.Trim() + "%') "+ withSupplier + " ORDER BY P.Prod_Code";
                }
                else
                {
                    objPon.SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name],P.barcode[Part No], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [Marked Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Selling Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], SM.Qty [Stock] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "'" + withSupplier + " ORDER BY P.Prod_Code";
                }

                objPon.DataetName = "dsProduct";
                objPon.GetItemDetails();
                ProductSearch.dgSearch.DataSource = objPon.GetItemDataset.Tables["dsProduct"];
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Format = "N3";
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Format = "N2";
                ProductSearch.dgSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ProductSearch.dgSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objPon.SuppCode = txtSuppCode.Text.ToString().Trim();
                    objPon.SqlStatement = "SELECT Supp_Code, Supp_Name FROM supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    objPon.ReadSupplierDetails();
                    if (objPon.RecordFound == true)
                    {
                        txtSuppCode.Text = objPon.SuppCode;
                        txtSuppName.Text = objPon.SuppName;
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Purchase Order Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSuppCode.Focus();
                    }

                    string withSupplier = (chkAccOtherSuppProd.Checked) ? "" : " AND product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "'";

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    //objPon.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Supplier_Id = '" + txtSuppCode.Text.Trim() + "' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR (Product.Barcode = '" + txtProductCode.Text.Trim() + "' AND LTRIM(RTRIM(product.barcode)) <> '')) and Stock_Master.Loca = ";
                    objPon.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size, product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code LEFT JOIN tbProductLink ON tbProductLink.Prod_Code = Product.Prod_Code AND Stock_Master.Prod_Code = tbProductLink.Prod_Code WHERE LockedItem = 'F' AND (product.Prod_Code = '" + txtProductCode.Text.Trim() + "' OR product.Barcode='" + txtProductCode.Text.Trim() + "' OR tbProductLink.Barcode= '" + txtProductCode.Text.Trim() + "') "+ withSupplier + " AND Stock_Master.Loca = ";
                       
                    objPon.ReadProductDetails();
                    if (objPon.RecordFound == true)
                    {
                        txtProductCode.Text = objPon.ProductCode;
                        txtProductName.Text = objPon.ProductName;
                        txtPurchasePrice.Text = (string)objPon.PurchasePrice.ToString();
                        lblCurrentQty.Text = (string)objPon.CurrentQty.ToString();

                        objPon.SqlStatement = "SELECT qty FROM TransactionTemp_Details WHERE Prod_Code = '" + objPon.ProductCode + "' AND Doc_No = '" + objPon.TempDocNo + "' AND IId = 'PON' AND Loca = ";
                        objPon.ReadExsistProductDetails();
                        txtQty.Text = (string)objPon.Qty.ToString();
                        if (txtPurchasePrice.Enabled == true)
                        {
                            txtPurchasePrice.Focus(); txtPurchasePrice.SelectAll();
                        }
                        else
                        {
                            txtQty.Focus(); txtQty.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", "Purchase Order Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    strDisc = string.Empty;

                    objPon.ProductCode = txtProductCode.Text.Trim().ToUpper();
                    objPon.ProductName = txtProductName.Text.Trim().ToUpper();
                    objPon.PurchasePrice = decimal.Parse(txtPurchasePrice.Text.Trim());
                    lblCurrentQty.Text = objPon.CurrentQty.ToString();
                    objPon.Qty = decimal.Parse(txtQty.Text.ToString());
                    decAmount = decimal.Parse(txtPurchasePrice.Text.ToString()) * decimal.Parse(txtQty.Text.ToString());
                    lblAmount.Text = decAmount.ToString();
                    objPon.Amount = decimal.Parse(lblAmount.Text.ToString());
                    objPon.UpdatePonTempDataSet();
                    objPon.GetTempDataset();
                    dataGridTempPON.DataSource = objPon.TempPon.Tables["PurchaseOrder"];
                    dataGridTempPON.Refresh();
                    //Set Grid Last Record
                    if (dataGridTempPON.RowCount > 12)
                    {
                        dataGridTempPON.FirstDisplayedCell = dataGridTempPON[0, dataGridTempPON.RowCount - 6];
                    }
                    //******************
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    lblCurrentQty.Text = string.Empty;
                    txtPurchasePrice.Text = "0.0000";
                    txtQty.Text = "0";
                    lblAmount.Text = string.Empty;
                   // btnSaveDocSearch.Enabled = false;
                    btnSupplierSearch.Enabled = true;
                    //txtRemarks.Enabled = false;

                    objPon.GetTotalValues();

                    lblTotalQty.Text = string.Format("{0:0.00}", objPon.TotalQty);
                    lblTotalAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);

                    txtTaxAmount.Text = "0";
                    lblNetAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
                    txtSuppCode.ReadOnly = true;
                    txtSuppName.Enabled = false;
                    cmbPayment.Enabled = false;
                    dtpDate.Enabled = false;
                    txtCreditPeriod.Enabled = false;
                   // txtRemarks.Enabled = false;

                    txtTaxAmount.Enabled = true;
                    txtContactPerson.Enabled = false;
                    txtShiftToHeader.Enabled = false;
                    txtShiftAddress1.Enabled = false;
                    txtShiftAddress2.Enabled = false;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objPon.CheckedPasswordValid("SELECT Emp_Name,Pass_Word,GRNAPP,POAPP,SRNAPP,TOGAPP,OPBAPP,PRDAPP,BATCAPP FROM dbo.tb_UserRoleSettings Us JOIN dbo.Employee E ON E.UserRole_Id=Us.UserRoleID WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='" + LoginManager.LocaCode + "' AND Us.POAPP=1");
                if (objPon.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nSave this " + this.Text + " via authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (MessageBox.Show("Do You want to Apply This Document. ", "Goods Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;
                    objPon.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'PON' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objPon.ReadTempTransDetails();
                    if (objPon.RecordFound != true)
                    {
                        MessageBox.Show("Purchase Order Details Not Found.", "Purchase Order Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (txtTaxAmount.Text.Trim() == string.Empty)
                    {
                        txtTaxAmount.Text = "0";
                    }

                    if (txtCreditPeriod.Text.Trim() == string.Empty)
                    {
                        txtCreditPeriod.Text = "0";
                    }

                    objPon.Pay_Type = cmbPayment.Text;
                    objPon.Remark = txtRemarks.Text.Trim();
                    objPon.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objPon.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objPon.TotalAmount = decimal.Parse(lblNetAmount.Text.ToString());
                    objPon.ExpectedDate = string.Format("{0:dd/MM/yyyy}", dtpExpectedOn.Value);
                    objPon.CreditPeriod = int.Parse(txtCreditPeriod.Text.ToString());
                    objPon.ContactPerson = txtContactPerson.Text.Trim();
                    objPon.ShiftToHeader = txtShiftToHeader.Text.Trim();
                    objPon.ShiftAddress1 = txtShiftAddress1.Text.Trim();
                    objPon.ShiftAddress2 = txtShiftAddress2.Text.Trim();
                    objPon.PurchaseOrderNoteApply();
                    MessageBox.Show("Purchase Order Note Successfully Applied as Document No. " + objPon.OrgDocNo, "Purchase Order Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //objPon.GetDataSetForReport();
                    dsDataForReport = objPon.GetReportDataset;
                    dsDataForReport.Tables[1].TableName = "CompanyProfile";
                    objRepViewer.VirtuaReport  = new rptPurchaseOrder();
                    objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();

                    this.Close();
                    this.Dispose();
                    Pon = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (MessageBox.Show("Are You Sure You want to Save This Document. ", "Purchase Order Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    objPon.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'PON' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                    objPon.ReadTempTransDetails();
                    if (objPon.RecordFound != true)
                    {
                        MessageBox.Show("Purchase Order Details Not Found.", "Purchase Order Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    objPon.Pay_Type = cmbPayment.Text;
                    objPon.Remark = txtRemarks.Text.Trim();
                    objPon.CreditPeriod = int.Parse(txtCreditPeriod.Text.ToString());
                    objPon.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    objPon.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                    objPon.ExpectedDate = string.Format("{0:dd/MM/yyyy}",dtpExpectedOn.Value);
                    objPon.ContactPerson = txtContactPerson.Text.Trim();
                    objPon.ShiftToHeader = txtShiftToHeader.Text.Trim();
                    objPon.ShiftAddress1 = txtShiftAddress1.Text.Trim();
                    objPon.ShiftAddress2 = txtShiftAddress2.Text.Trim();
                    objPon.PurchaseOrderNoteSave();
                    MessageBox.Show("Purchase Order Note Successfully Saved as Document No. " + objPon.OrgDocNo, "Purchase Order Note Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    this.Dispose();
                    Pon = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                objPon.SqlStatement = "SELECT Doc_No [Document No], Post_Date + '  ' + Supplier.Supp_Name [Supplier] FROM Transaction_Save_Header INNER JOIN supplier on Transaction_Save_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Save_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                objPon.DataetName = "Table";
                objPon.GetItemDetails();

                search.dgSearch.DataSource = objPon.GetItemDataset.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSaveDocSearch_Enter(object sender, EventArgs e)
        {
            //if (search.Code != null && search.Code != "")
            //{
            //    if (MessageBox.Show("Are You Sure You want to Load Saved Purchase Order Document No :" + search.Code.Trim() + ". ", "Purchase Order Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {

            //        objPon.RecallSaveDocNo = search.Code.Trim();
            //        objPon.SqlStatement = "SELECT Transaction_Save_Header.*, Supplier.Supp_Name FROM Transaction_Save_Header INNER JOIN Supplier ON Supplier.Supp_Code = Transaction_Save_Header.Supplier_Id WHERE Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
            //        objPon.ReadSavedDocument();
            //        if (objPon.RecordFound)
            //        {
            //            lblTempDocNo.Text = objPon.TempDocNo;
            //            txtSuppCode.Text = objPon.SuppCode.ToString();
            //            txtSuppName.Text = objPon.SuppName.ToString();
            //            cmbPayment.Text = objPon.Pay_Type;
            //            txtRemarks.Text = objPon.Remark.ToString();

            //            objPon.GetTempDataset();
            //            dataGridTempPON.DataSource = objPon.TempPon.Tables["PurchaseOrder"];
            //            dataGridTempPON.Refresh();

            //            objPon.GetTotalValues();

            //            lblTotalQty.Text = string.Format("{0:0.00}", objPon.TotalQty);
            //            lblTotalAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
            //            txtTaxAmount.Text = "0";
            //            lblNetAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
            //            txtSuppCode.Enabled = false;
            //            txtSuppName.Enabled = false;
            //            cmbPayment.Enabled = false;
            //            dtpDate.Enabled = false;
            //            txtCreditPeriod.Enabled = false;
            //            txtRemarks.Enabled = false;
            //            btnSaveDocSearch.Enabled = false;
            //        }
            //    }
            //    search.Code = string.Empty;
            //    search.Descript = string.Empty;
            //}
        }

        private void frmPurchaseOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Pon = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPurchaseOrder_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCreditPeriod.Text.Trim() != string.Empty)
                {
                    cmbPayment.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtCreditPeriod.Text.Trim() == string.Empty)
                    {
                        txtCreditPeriod.Text = "0";
                        cmbPayment.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && cmbPayment.Text.Trim() != string.Empty)
                {
                    txtRemarks.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && cmbPayment.Text.Trim() == string.Empty)
                    {
                        cmbPayment.Text = "CREDIT";
                        txtRemarks.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && txtRemarks.Text.Trim() != string.Empty)
                {
                    txtContactPerson.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtRemarks.Text.Trim() == string.Empty)
                    {
                        txtRemarks.Text = ".";
                        txtContactPerson.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtContactPerson.Text.Trim() != string.Empty)
                {
                    txtShiftToHeader.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtContactPerson.Text.Trim() == string.Empty)
                    {
                        txtContactPerson.Text = ".";
                        txtShiftToHeader.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtShiftAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtShiftAddress1.Text.Trim() != string.Empty)
                {
                    txtShiftAddress2.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtShiftAddress1.Text.Trim() == string.Empty)
                    {
                        txtShiftAddress1.Text = ".";
                        txtShiftAddress2.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtShiftAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtShiftAddress2.Text.Trim() != string.Empty)
                {
                    txtProductCode.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtShiftAddress2.Text.Trim() == string.Empty)
                    {
                        txtShiftAddress2.Text = ".";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSuppName.Text.Trim() != string.Empty)
                {
                    txtCreditPeriod.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtSuppName.Text.Trim() == string.Empty)
                    {
                        txtSuppName.Text = ".";
                        txtCreditPeriod.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtProductName.Text.Trim() != String.Empty)
                {
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtShiftToHeader_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtShiftToHeader.Text.Trim() != string.Empty)
                {
                    txtShiftAddress1.Focus();
                }
                else
                {
                    if (e.KeyCode == Keys.Enter && txtShiftToHeader.Text.Trim() == string.Empty)
                    {
                        txtShiftToHeader.Text = ".";
                        txtShiftAddress1.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void CalculateTax(string strTaxText)
        {
            try
            {
                if (strTaxText.IndexOf("%") > 0 && strTaxText.IndexOf("%") < 3)
                {
                    strDisc = strTaxText;
                    intPosOfPerc = strTaxText.IndexOf("%");
                    fltDiscPer = decimal.Parse(strTaxText.Substring(0, intPosOfPerc).ToString());

                    //fltDiscPer = 100 + fltDiscPer;
                    objPon.Amount = decimal.Parse(lblTotalAmount.Text.ToString());
                    decAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                    decTaxAmount = (decimal.Parse(decAmount.ToString()) * decimal.Parse(fltDiscPer.ToString())) / 100;
                    decAmount = decTaxAmount + decimal.Parse(lblTotalAmount.Text);
                    txtTaxAmount.Text = string.Format("{0:0.00}", decTaxAmount);
                    lblNetAmount.Text = string.Format("{0:0.00}", decAmount);
                }
                else
                {
                    MessageBox.Show("Invalid Tax Percentage. Please Enter Valid Percentage(Ex: 22% )", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaxAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempPON_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridTempPON.SelectedRows.Count <= 0 || dataGridTempPON.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductCode.Text = dataGridTempPON.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dataGridTempPON.SelectedRows[0].Cells[1].Value.ToString();
                    objPon.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, Stock_Master.Qty, product.Pack_Size,product.Unit FROM product INNER JOIN Stock_Master ON product.Prod_Code = Stock_Master.Prod_Code WHERE product.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objPon.ReadProductDetails();
                    txtPurchasePrice.Text = dataGridTempPON.SelectedRows[0].Cells[3].Value.ToString();
                    txtQty.Text = dataGridTempPON.SelectedRows[0].Cells[4].Value.ToString();
                    if (objPon.Unit == "Nos")
                    {
                        txtQty.Text = string.Format("{0:0}", decimal.Parse(txtQty.Text.Trim()));
                    }
                    //txtQty.Text = dataGridTempPON.SelectedRows[0].Cells[4].Value.ToString();
                    lblAmount.Text = dataGridTempPON.SelectedRows[0].Cells[5].Value.ToString();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempPON_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridTempPON_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridTempPON.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Purchase Order Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objPon.TempDocNo = lblTempDocNo.Text.Trim();
                        objPon.ProductCode = dataGridTempPON.SelectedRows[0].Cells[0].Value.ToString();
                        objPon.DeleteProductDetaile();
                        objPon.GetTempDataset();
                        dataGridTempPON.DataSource = objPon.TempPon.Tables["PurchaseOrder"];
                        dataGridTempPON.Refresh();

                        objPon.GetTotalValues();

                        lblTotalQty.Text = objPon.TotalQty.ToString();
                        lblTotalAmount.Text = objPon.TotalAmount.ToString();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objPon.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'PON' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objPon.ReadTempTransDetails();
                if (objPon.RecordFound != true)
                {
                    MessageBox.Show("Purchase Order Details Not Found.", "Purchase Order Note Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objPon.Pay_Type = cmbPayment.Text;
                objPon.Remark = txtRemarks.Text.Trim();
                objPon.GrossAmount = decimal.Parse(lblTotalAmount.Text.ToString());
                objPon.Tax = decimal.Parse(txtTaxAmount.Text.ToString());
                objPon.ExpectedDate = string.Format("{0:dd/MM/yyyy}", dtpExpectedOn.Value);
                objPon.CreditPeriod = int.Parse(txtCreditPeriod.Text.ToString());
                objPon.ContactPerson = txtContactPerson.Text.Trim();
                objPon.ShiftToHeader = txtShiftToHeader.Text.Trim();
                objPon.ShiftAddress1 = txtShiftAddress1.Text.Trim();
                objPon.ShiftAddress2 = txtShiftAddress2.Text.Trim();

                objPon.GetDataSetForPreviewReport();

                dsDataForReport = objPon.GetReportDataset;
                dsDataForReport.Tables[1].TableName = "CompanyProfile";
                objRepViewer.VirtuaReport = new rptPurchaseOrder();
                objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 029. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Load Saved Purchase Order Document No :" + search.Code.Trim() + ". ", "Purchase Order Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        objPon.RecallSaveDocNo = search.Code.Trim();
                        objPon.SqlStatement = "SELECT Transaction_Save_Header.*, Supplier.Supp_Name FROM Transaction_Save_Header INNER JOIN Supplier ON Supplier.Supp_Code = Transaction_Save_Header.Supplier_Id WHERE iid = 'PON' AND Doc_No = '" + search.Code.Trim() + "' AND Loca = ";
                        objPon.ReadSavedDocument();
                        if (objPon.RecordFound)
                        {
                            lblTempDocNo.Text = objPon.TempDocNo;
                            txtSuppCode.Text = objPon.SuppCode.ToString();
                            txtSuppName.Text = objPon.SuppName.ToString();
                            txtCreditPeriod.Text = objPon.CreditPeriod.ToString();
                            cmbPayment.Text = objPon.Pay_Type;
                            txtRemarks.Text = objPon.Remark.ToString();
                            txtContactPerson.Text = objPon.ContactPerson.ToString();
                            txtShiftToHeader.Text = objPon.ShiftToHeader.ToString();
                            txtShiftAddress1.Text = objPon.ShiftAddress1.ToString();
                            txtShiftAddress2.Text = objPon.ShiftAddress2.ToString();
                            //dtpExpectedOn.Value = string.Format("{0:dd/MM/yyyy}",DateTime.Parse( objPon.ExpectedDate.ToString()));
                            //dtExpDate = DateTime.Parse(string.Format("{0:dd/MM/yyyy}",objPon.ExpectedDate));
                            //dtpExpectedOn.Value = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(objPon.ExpectedDate.ToString()));
                            dtpExpectedOn.Value = DateTime.Parse(objPon.ExpectedDate.ToString());
                            objPon.GetTempDataset();
                            dataGridTempPON.DataSource = objPon.TempPon.Tables["PurchaseOrder"];
                            dataGridTempPON.Refresh();

                            objPon.GetTotalValues();

                            lblTotalQty.Text = string.Format("{0:0.00}", objPon.TotalQty);
                            lblTotalAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
                            txtTaxAmount.Text = "0";
                            //txtCreditPeriod.Text = "0";
                            lblTotalAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
                            lblNetAmount.Text = string.Format("{0:0.00}", objPon.TotalAmount);
                            txtSuppCode.ReadOnly = true;
                            txtSuppName.Enabled = false;
                            txtContactPerson.Enabled = false;
                            txtShiftToHeader.Enabled = false;
                            txtShiftAddress1.Enabled = false;
                            txtShiftAddress2.Enabled = false;
                            cmbPayment.Enabled = false;
                            dtpDate.Enabled = false;
                            txtCreditPeriod.Enabled = false;
                            //txtRemarks.Enabled = false;
                            //btnSaveDocSearch.Enabled = false;
                            //btnSupplierSearch.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 031.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus(); txtQty.SelectAll();
            }
        }

        private void txtTaxAmount_Leave(object sender, EventArgs e)
        {
            strDisc = string.Empty;
            try
            {
                if (txtTaxAmount.Text.Trim() != string.Empty && decimal.Parse(txtTaxAmount.Text.Replace("%","")) != 0)
                {
                    if (clsValidation.isNumeric(txtTaxAmount.Text, System.Globalization.NumberStyles.Currency) == false)
                    {
                        CalculateTax(txtTaxAmount.Text.Trim());
                        btnApply.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Tax Percentage. Please Enter Valid Tax Percentage(Ex: 22%)", "Goods Received Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTaxAmount.Focus();
                        txtTaxAmount.SelectAll();
                    }
                }
                else
                {
                    txtTaxAmount.Text = "0.00";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtTaxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnApply.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (objPon.Unit == "Nos")
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objPon.SqlStatement = "SELECT TransactionTemp_Details.* from TransactionTemp_Details WHERE TransactionTemp_Details.IId = 'PON' AND TransactionTemp_Details.Doc_No = '" + lblTempDocNo.Text.ToString() + "' AND TransactionTemp_Details.Loca = " + LoginManager.LocaCode;
                objPon.ReadTempTransDetails();
                if (objPon.RecordFound != true)
                {
                    MessageBox.Show("" + this.Text + " Details Not Found.", "" + this.Text + " Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                /*
                objPon.CheckedPasswordValid("SELECT TOP 1 Emp_Name, Pass_Word FROM tbUserRoleDetails URD INNER JOIN Employee E ON URD.UserRole_Id = E.UserRole_Id WHERE Option_Id = 'POAPP' AND Allow_Option = 'T' AND Loca = '" + LoginManager.LocaCode.ToString() + "' AND Emp_Name = '" + LoginManager.UserName.ToString() + "'");
                if (objPon.AccessStatus == false)
                {
                    MessageBox.Show("Access Denied !\r\nDelete this " + this.Text + " Invoice through authonticate user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }*/
                if (MessageBox.Show("Are You sure you want to delete this document?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objPon.SqlStatement = "EXEC sp_DeleteSavedDoc @DocNo = '" + lblTempDocNo.Text + "',  @Loca = '" + LoginManager.LocaCode + "', @Iid = 'PON'";
                    objPon.ReadTempTransDetails();
                    MessageBox.Show("Delete successfull!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                objPon.Errormsg(ex, "frmPurchaseOrder- btnDelete_Click");
            }
        }
    }
    
}