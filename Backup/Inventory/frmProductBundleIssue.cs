using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Inventory
{
    public partial class frmProductBundleIssue : Form
    {
        public frmProductBundleIssue()
        {
            InitializeComponent();
           
        }

        clsBundleIssue objPacketingProduct = new clsBundleIssue();

        private static frmProductBundleIssue BundleIssue;

        private frmSearch search = new frmSearch();

        public static frmProductBundleIssue GetBundleIssue
        {
            get
            {
                return BundleIssue;
            }
            set
            {
                BundleIssue = value;
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
                    objPacketingProduct.SqlStatement = "SELECT DISTINCT(Prod_Code) AS [Product Code],Prod_Name AS [Product Name] FROM tbBundlingProductDetails WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objPacketingProduct.SqlStatement = "SELECT DISTINCT(Prod_Code) AS [Product Code],Prod_Name AS [Product Name] FROM tbBundlingProductDetails WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%'";
                    }
                    else
                    {
                        objPacketingProduct.SqlStatement = "SELECT DISTINCT(Prod_Code) AS [Product Code],Prod_Name AS [Product Name] FROM tbBundlingProductDetails";
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmPacketingProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                BundleIssue = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                BundleIssue = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objPacketingProduct.SqlStatement = "SELECT tbBundlingProductDetails.Prod_Code, tbBundlingProductDetails.Prod_Name, tbBundlingProductDetails.Purchase_price, Stock_Master.Qty, CAST(COUNT(tbBundlingProductDetails.Packet_Qty) AS DECIMAL(10,2)) Packet_Qty  FROM tbBundlingProductDetails INNER JOIN Stock_Master ON tbBundlingProductDetails.Prod_Code = Stock_Master.Prod_Code WHERE tbBundlingProductDetails.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = '" + LoginManager.LocaCode + "' GROUP BY tbBundlingProductDetails.Prod_Code, tbBundlingProductDetails.Prod_Name, tbBundlingProductDetails.Purchase_price, Stock_Master.Qty";
                    objPacketingProduct.ReadProductDetails();
                    if (objPacketingProduct.RecordFound == true)
                    {
                        txtProductCode.Text = objPacketingProduct.MainProductCode;
                        txtProductName.Text = objPacketingProduct.MainProductName;
                        lblPurchasePrice.Text = (string)objPacketingProduct.MainPurchasePrice.ToString();

                        lstBoxPacketItems.Items.Clear();
                        objPacketingProduct.GetDataset("SELECT tbBundlingProductDetails.Packet_Prod_Code + '-' + tbBundlingProductDetails.Packet_Prod_Name [A], tbBundlingProductDetails.Packet_Qty [B], tbBundlingProductDetails.Packet_Purchase_price,Stock_Master.Qty FROM tbBundlingProductDetails INNER JOIN Stock_Master ON tbBundlingProductDetails.Prod_Code = Stock_Master.Prod_Code WHERE tbBundlingProductDetails.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = '" + LoginManager.LocaCode + "'", "dsItems");

                        for (int i = 0; i < objPacketingProduct.GetProductDataset.Tables[0].Rows.Count; i++)
                        {
                            string s = objPacketingProduct.GetProductDataset.Tables[0].Rows[i][1].ToString().PadRight(10, System.Convert.ToChar(' ')) + " x " + objPacketingProduct.GetProductDataset.Tables[0].Rows[i][0].ToString().PadLeft(20) + " --- " + objPacketingProduct.GetProductDataset.Tables[0].Rows[i]["Qty"].ToString();
                            lstBoxPacketItems.Items.Add(s);
                        }
                        lstBoxPacketItems.Visible = true;

                        lblPackQty.Text = objPacketingProduct.PacketQty.ToString();
                        txtNoOfPackets.Enabled = true;
                        txtNoOfPackets.Focus();
                    }
                    else
                    {
                        txtProductName.Text = string.Empty;
                        lblPurchasePrice.Text = string.Empty;
                        //  lblMainProductCode.Text = string.Empty;
                        //  lblMainProductName.Text = string.Empty;
                        //  lblMainQty.Text = "0";
                        lblPackQty.Text = "0";
                        txtNoOfPackets.Enabled = false;
                        txtProductCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmPacketingProduct_Load(object sender, EventArgs e)
        {
            try
            {
                objPacketingProduct.SqlStatement = "SELECT TempBDL FROM DocumentNoDetails WHERE Loca = '" + LoginManager.LocaCode + "';update DocumentNoDetails set TempBDL=TempBDL+1 where  Loca = '" + LoginManager.LocaCode + "'  ";
                objPacketingProduct.GetTempDocumentNo();
                lblTempDocNo.Text = objPacketingProduct.TempDocumentNo;
                objPacketingProduct.DeleteTempBundling("sp_TempBundlingDelete", lblTempDocNo.Text);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtPacketQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtNoOfPackets.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtNoOfPackets.Text) > 0)
                {

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objPacketingProduct.SqlStatement = "SELECT tbBundlingProductDetails.Prod_Code, tbBundlingProductDetails.Prod_Name, tbBundlingProductDetails.Purchase_price, Stock_Master.Qty, SUM(tbBundlingProductDetails.Packet_Qty) FROM tbBundlingProductDetails INNER JOIN Stock_Master ON tbBundlingProductDetails.Prod_Code = Stock_Master.Prod_Code WHERE tbBundlingProductDetails.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca ='" + LoginManager.LocaCode + "' GROUP BY tbBundlingProductDetails.Prod_Code, tbBundlingProductDetails.Prod_Name, tbBundlingProductDetails.Purchase_price, Stock_Master.Qty ";
                    objPacketingProduct.ReadProductDetails();
                    if (objPacketingProduct.RecordFound == true)
                    {
                        txtProductCode.Text = objPacketingProduct.MainProductCode;
                        txtProductName.Text = objPacketingProduct.MainProductName;
                        lblPurchasePrice.Text = (string)objPacketingProduct.MainPurchasePrice.ToString();
                        lblPackQty.Text = objPacketingProduct.PacketQty.ToString();
                        txtNoOfPackets.Enabled = true;
                        txtNoOfPackets.Focus();
                    }
                    else
                    {
                        txtProductName.Text = string.Empty;
                        lblPurchasePrice.Text = string.Empty;
                        lblPackQty.Text = "0";
                        txtNoOfPackets.Enabled = false;
                        txtProductCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    objPacketingProduct.MainProductCode = txtProductCode.Text.Trim().ToUpper();
                    objPacketingProduct.Qty = decimal.Parse(txtNoOfPackets.Text.ToString());

                    objPacketingProduct.RecallTempBundlingIssue();

                     
                    lstBoxPacketItems.Items.Clear();

                    for (int i = 0; i < objPacketingProduct.GetProductDataset.Tables[0].Rows.Count; i++)
                    {
                        string s = objPacketingProduct.GetProductDataset.Tables[0].Rows[i][1].ToString().PadRight(10, System.Convert.ToChar(' ')) + " x " + objPacketingProduct.GetProductDataset.Tables[0].Rows[i][0].ToString().PadLeft(20) + " --- " + objPacketingProduct.GetProductDataset.Tables[0].Rows[i]["Qty"].ToString();
                        lstBoxPacketItems.Items.Add(s);
                    }
                    lstBoxPacketItems.Visible = true;

                    dataGridViewTempPackProduct.DataSource = objPacketingProduct.TempSelectedItem.Tables[1];
                    dataGridViewTempPackProduct.Refresh();

                    txtTotal.Text = objPacketingProduct.TempSelectedItem.Tables[2].Rows[0][0].ToString();
                    txtCostprice.Text = objPacketingProduct.TempSelectedItem.Tables[2].Rows[0][1].ToString();
                    txtSalePrice.Text = objPacketingProduct.TempSelectedItem.Tables[2].Rows[0][2].ToString();
                    
                    txtProductCode.Focus();


                    groupBox2.Enabled = false;
                    txtSubProdCode.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {

                objPacketingProduct.GetTempBulkIssueDataset(lblTempDocNo.Text);
                if (objPacketingProduct.TempSelectedItem.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Product Bundle Note Details Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                if (clsValidation.isNumeric(txtSalePrice.Text.Trim(),System.Globalization.NumberStyles.Number)==false)
                {
                    MessageBox.Show("Invalid Selling Price", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                objPacketingProduct.SqlStatement = "SELECT (P.Packet_Qty*TM.Packet_Qty)   ,TM.No_Of_Packets FROM dbo.tbTempBundlingIssueProduct TM JOIN dbo.tbBundlingProductDetails P ON TM.Prod_Code=P.Packet_Prod_Code WHERE TempDocNo='"+lblTempDocNo.Text.Trim()+"' AND (P.Packet_Qty*TM.Packet_Qty) > TM.No_Of_Packets";
                objPacketingProduct.DataetName = "ds";
                objPacketingProduct.GetItemDetails();

                if (objPacketingProduct.GetProductDataset.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("not Enough Stock Available", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Are You Sure You want to Apply This Document. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataSet dsDataForReport = new DataSet();
                    frmReportViewer objRepViewer = new frmReportViewer();


                    objPacketingProduct.PostDate = dpdate.Text;
                    objPacketingProduct.PurchasePrice = decimal.Parse(txtCostprice.Text.Trim());
                    objPacketingProduct.SellingPrice = decimal.Parse(txtSalePrice.Text.Trim());

                    objPacketingProduct.IssuingBunlingProductApply();

                    MessageBox.Show("Product Bundle Note Successfully Applied as Document No. " + objPacketingProduct.OrgDocNo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                    this.Dispose();
                    BundleIssue = null;
                    objPacketingProduct.GetDataSetForBundlingReport();
                    dsDataForReport = objPacketingProduct.GetReportDataset;
                    rptProductBundleingNote ProductBundleingNote = new rptProductBundleingNote();
                    ProductBundleingNote.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = ProductBundleingNote;
                    objRepViewer.Show();

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dataGridViewTempPackProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewTempPackProduct.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objPacketingProduct.ProductCode = dataGridViewTempPackProduct.SelectedRows[0].Cells[0].Value.ToString();
                        objPacketingProduct.DeleteTempBundlingProduct(objPacketingProduct.ProductCode, lblTempDocNo.Text);
                        objPacketingProduct.GetTempBulkIssueDataset(lblTempDocNo.Text);
                        dataGridViewTempPackProduct.DataSource = objPacketingProduct.TempSelectedItem.Tables["dsTempPacketProduct"];
                        dataGridViewTempPackProduct.Refresh();

                        txtTotal.Text = objPacketingProduct.TempSelectedItem.Tables[1].Rows[0][0].ToString();
                        txtCostprice.Text = objPacketingProduct.TempSelectedItem.Tables[1].Rows[0][1].ToString();
                        txtSalePrice.Text = objPacketingProduct.TempSelectedItem.Tables[1].Rows[0][2].ToString();


                        txtSubProdCode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchSubProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtSubProdCode.Text.Trim() != string.Empty && txtSubProdName.Text.Trim() == string.Empty)
                {
                    objPacketingProduct.SqlStatement = "SELECT BP.Packet_Prod_Code[Code],BP.Packet_Prod_Name[Description],BP.Packet_Qty[Req Qty],S.Qty[Stock] FROM dbo.tbBundlingProductDetails BP JOIN dbo.Product P ON P.Prod_Code = BP.Packet_Prod_Code JOIN dbo.Stock_Master S ON S.Prod_Code=BP.Packet_Prod_Code AND S.Loca='' WHERE BP.Prod_Code";
                }
                else
                {
                    if (txtSubProdCode.Text.Trim() == string.Empty && txtSubProdName.Text.Trim() != string.Empty)
                    {
                        objPacketingProduct.SqlStatement = "SELECT Packet_Prod_Code[Prod Code],Packet_Prod_Name[Description],Packet_Qty[Qty] FROM tbBundlingProductDetails WHERE Packet_Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' and Prod_Code='" + txtProductCode.Text.Trim() + "' ";
                    }
                    else
                    {
                        objPacketingProduct.SqlStatement = "SELECT Packet_Prod_Code[Prod Code],Packet_Prod_Name[Description],Packet_Qty[Qty] FROM tbBundlingProductDetails where  Prod_Code='" + txtProductCode.Text.Trim() + "' ";
                    }
                }

                objPacketingProduct.DataetName = "dsProduct";
                objPacketingProduct.GetItemDetails();

                search.dgSearch.DataSource = objPacketingProduct.GetProductDataset.Tables["dsProduct"];
                search.prop_Focus = txtSubProdCode;
                search.Cont_Descript = txtSubProdName;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtSubProdCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtProductCode.Text = txtProductCode.Text.ToUpper();
                    objPacketingProduct.SqlStatement = "SELECT tbBundlingProductDetails.Prod_Code, tbBundlingProductDetails.Prod_Name, tbBundlingProductDetails.Purchase_price, Stock_Master.Qty, CAST(COUNT(tbBundlingProductDetails.Packet_Qty) AS DECIMAL(10,2)) Packet_Qty  FROM tbBundlingProductDetails INNER JOIN Stock_Master ON tbBundlingProductDetails.Prod_Code = Stock_Master.Prod_Code WHERE tbBundlingProductDetails.Prod_Code = '" + txtProductCode.Text.Trim() + "' and Stock_Master.Loca = '" + LoginManager.LocaCode + "' GROUP BY tbBundlingProductDetails.Prod_Code, tbBundlingProductDetails.Prod_Name, tbBundlingProductDetails.Purchase_price, Stock_Master.Qty";
                    
                    objPacketingProduct.ReadProductDetails();
                    if (objPacketingProduct.RecordFound == true)
                    {
                        txtProductCode.Text = objPacketingProduct.MainProductCode;
                        txtProductName.Text = objPacketingProduct.MainProductName;
                        lblPurchasePrice.Text = (string)objPacketingProduct.MainPurchasePrice.ToString();
                    }
                    else
                    {
                        txtSubProdCode.Text = string.Empty;
                        lblSubPrice.Text = string.Empty;
                        lblPackQty.Text = "0";
                        txtNoOfPackets.Enabled = false;
                        txtProductCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductBundleIssue.GetBundleIssue = new frmProductBundleIssue();
            frmProductBundleIssue.GetBundleIssue.MdiParent = MainClass.mdi;
            frmProductBundleIssue.GetBundleIssue.Show();
        }
    }
}