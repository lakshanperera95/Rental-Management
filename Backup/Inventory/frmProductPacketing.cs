using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
namespace Inventory
{
    public partial class frmProductPacketing : Form
    {
        public frmProductPacketing()
        {
            InitializeComponent();
        }

        clsProductPacketing objPacketingProduct = new clsProductPacketing();

        private static frmProductPacketing PacketingProduct;

        private frmSearch search = new frmSearch();

        public static frmProductPacketing GetPacketingProduct
        {
            get
            {
                return PacketingProduct;
            }
            set
            {
                PacketingProduct = value;
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
                    objPacketingProduct.SqlStatement = "SELECT DISTINCT(Packet_Prod_Code) AS [Product Code],Packet_Prod_Name AS [Product Name] FROM tbPacketProductDetails WHERE Packet_Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objPacketingProduct.SqlStatement = "SELECT DISTINCT(Packet_Prod_Code) AS [Product Code],Packet_Prod_Name AS [Product Name] FROM tbPacketProductDetails WHERE Packet_Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%'";
                    }
                    else
                    {
                        objPacketingProduct.SqlStatement = "SELECT DISTINCT(Packet_Prod_Code) AS [Product Code],Packet_Prod_Name AS [Product Name] FROM tbPacketProductDetails";
                    }
                }

                objPacketingProduct.DataetName = "dsProduct";
                objPacketingProduct.GetItemDetails();

                search.dgSearch.DataSource = objPacketingProduct.GetProductDataset.Tables["dsProduct"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPacketingProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PacketingProduct = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPacketingProduct_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                PacketingProduct = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objPacketingProduct.SqlStatement = "SELECT tbPacketProductDetails.Prod_Code, tbPacketProductDetails.Prod_Name, tbPacketProductDetails.Purchase_price, Stock_Master.Qty, tbPacketProductDetails.Packet_Qty, tbPacketProductDetails.Packet_Prod_Code, tbPacketProductDetails.Packet_Prod_Name, tbPacketProductDetails.Packet_Purchase_price FROM tbPacketProductDetails INNER JOIN Stock_Master ON tbPacketProductDetails.Prod_Code = Stock_Master.Prod_Code INNER JOIN Product ON Product.Prod_Code=tbPacketProductDetails.Prod_Code WHERE tbPacketProductDetails.Packet_Prod_Code = '" + txtProductCode.Text.Trim() + "' AND LockedItem='F'  and Stock_Master.Loca = ";
                    objPacketingProduct.ReadProductDetails();
                    if (objPacketingProduct.RecordFound == true)
                    {
                        txtProductName.Text = objPacketingProduct.ProductName;
                        lblPurchasePrice.Text = (string)objPacketingProduct.PurchasePrice.ToString();
                        lblMainProductCode.Text = objPacketingProduct.MainProductCode.ToString();
                        lblMainProductName.Text = objPacketingProduct.MainProductName.ToString();
                        lblMainQty.Text = objPacketingProduct.CurrentQty.ToString();
                        lblPackQty.Text = objPacketingProduct.PacketQty.ToString();
                        txtNoOfPackets.Enabled = true;
                        txtNoOfPackets.Focus();
                    }
                    else
                    {
                        txtProductName.Text = string.Empty ;
                        lblPurchasePrice.Text = string.Empty;
                        lblMainProductCode.Text = string.Empty;
                        lblMainProductName.Text = string.Empty;
                        lblMainQty.Text = "0";
                        lblPackQty.Text = "0";
                        txtNoOfPackets.Enabled = false;
                        txtProductCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPacketingProduct_Load(object sender, EventArgs e)
        {
            try
            {
                objPacketingProduct.DeleteTempPacketing();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtNoOfPackets.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtNoOfPackets.Text) > 0)
                {

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objPacketingProduct.SqlStatement = "SELECT tbPacketProductDetails.Prod_Code, tbPacketProductDetails.Prod_Name, tbPacketProductDetails.Purchase_price, Stock_Master.Qty, tbPacketProductDetails.Packet_Qty, tbPacketProductDetails.Packet_Prod_Code, tbPacketProductDetails.Packet_Prod_Name, tbPacketProductDetails.Packet_Purchase_price FROM tbPacketProductDetails INNER JOIN Stock_Master ON tbPacketProductDetails.Prod_Code = Stock_Master.Prod_Code WHERE tbPacketProductDetails.Packet_Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = ";
                    objPacketingProduct.ReadProductDetails();
                    if (objPacketingProduct.RecordFound == true)
                    {
                        txtProductName.Text = objPacketingProduct.ProductName;
                        lblPurchasePrice.Text = (string)objPacketingProduct.PurchasePrice.ToString();
                        lblPackQty.Text = objPacketingProduct.PacketQty.ToString();
                        lblMainProductCode.Text = objPacketingProduct.MainProductCode.ToString();
                        lblMainProductName.Text = objPacketingProduct.MainProductName.ToString();
                        lblMainQty.Text = objPacketingProduct.CurrentQty.ToString();
                        txtNoOfPackets.Enabled = true;
                        txtNoOfPackets.Focus();
                    }
                    else
                    {
                        txtProductName.Text = string.Empty;
                        lblPurchasePrice.Text = string.Empty;
                        lblPackQty.Text = "0";
                        lblMainProductCode.Text = string.Empty;
                        lblMainProductName.Text = string.Empty;
                        lblMainQty.Text = "0";
                        txtNoOfPackets.Enabled = false;
                        txtProductCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    objPacketingProduct.ProductCode = txtProductCode.Text.Trim().ToUpper();
                    objPacketingProduct.ProductName = txtProductName.Text.Trim().ToUpper();
                    objPacketingProduct.MainProductCode = lblMainProductCode.Text.Trim().ToUpper();
                    objPacketingProduct.MainProductName = lblMainProductName.Text.Trim().ToUpper();
                    objPacketingProduct.PurchasePrice = decimal.Parse(lblPurchasePrice.Text);
                    objPacketingProduct.No_Of_Packets = decimal.Parse(txtNoOfPackets.Text.ToString());
                    objPacketingProduct.PacketQty = decimal.Parse(lblPackQty.Text.ToString());

                    objPacketingProduct.UpdateTempPacketing();
                    objPacketingProduct.GetTempDataset();
                    dataGridViewTempPackProduct.DataSource = objPacketingProduct.TempSelectedItem.Tables["dsTempPacketProduct"];
                    dataGridViewTempPackProduct.Refresh();

                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    lblMainProductCode.Text = string.Empty;
                    lblMainProductName.Text = string.Empty;
                    txtNoOfPackets.Text = string.Empty;
                    lblPurchasePrice.Text = string.Empty;
                    lblMainQty.Text = "0";
                    lblPackQty.Text = "0";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (MessageBox.Show("Are You Sure You want to Apply This Document. ", this.Text , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (dataGridViewTempPackProduct.RowCount==0)
                    {
                        MessageBox.Show("No data found in order to apply", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;
                    objPacketingProduct.PacketingProductApply();
                    MessageBox.Show("Product Packeting Note Successfully Applied as Document No. " + objPacketingProduct.OrgDocNo, this.Text , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    objPacketingProduct.GetDataSetForReport();
                    dsDataForReport = objPacketingProduct.GetReportDataset;
                    rptProductPacketingNote rptPacketingProduct = new rptProductPacketingNote();
                    rptPacketingProduct.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = rptPacketingProduct;
                    objRepViewer.Show();

                    this.Close();
                    this.Dispose();
                    PacketingProduct = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", this.Text , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objPacketingProduct.ProductCode = dataGridViewTempPackProduct.SelectedRows[0].Cells[3].Value.ToString();
                        objPacketingProduct.DeleteTempPacketingProduct();
                        objPacketingProduct.GetTempDataset();
                        dataGridViewTempPackProduct.DataSource = objPacketingProduct.TempSelectedItem.Tables["dsTempPacketProduct"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPaketingProduct 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
}