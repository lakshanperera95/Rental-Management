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

                    LoadTempData();
                    
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

        public void LoadTempData()
        {
            try
            {
                objPacketingProduct.LoadTempDetails(Convert.ToDecimal(txtNoOfPackets.Text), lblTempDocNo.Text.Trim());
                dataGridViewTempPackProduct.DataSource = objPacketingProduct.TempSelectedItem.Tables[0];
                dataGridViewTempPackProduct.Refresh();

                txtTotal.Text = objPacketingProduct.TempSelectedItem.Tables[1].Rows[0][0].ToString();
                txtCostprice.Text = objPacketingProduct.TempSelectedItem.Tables[1].Rows[0][1].ToString();
                txtSalePrice.Text = objPacketingProduct.TempSelectedItem.Tables[1].Rows[0][2].ToString();
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

                objPacketingProduct.LoadTempDetails(Convert.ToDecimal(txtNoOfPackets.Text), lblTempDocNo.Text);


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

                if(Convert.ToDecimal(txtCostprice.Text) > Convert.ToDecimal(txtSalePrice.Text))
                {
                    MessageBox.Show("Item Price Under Cost Check and Contineu", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSalePrice.Focus();
                    return;
                }

                string Sqlst = "SELECT isnull(COUNT(*),0) FROM dbo.tbTempBundlingIssueProduct WHERE TempDocNo='" + lblTempDocNo.Text+"' GROUP BY Prod_Code;SELECT isnull(COUNT(*),0) FROM dbo.tbBundlingProductDetails WHERE Prod_Code='"+txtProductCode.Text+"'";
                objCommon.getDataSet(Sqlst, "ds");
                if( ( (int)objCommon.Ads.Tables[0].Rows[0][0]) != ((int)objCommon.Ads.Tables[1].Rows[0][0]))
                {
                    if(MessageBox.Show("Item Count Mismatch.. Need Item Count is  "+objCommon.Ads.Tables[1].Rows[0][0].ToString() +" Exist Count is "+objCommon.Ads.Tables[0].Rows[0][0].ToString() + " Sure to Contineu?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.No)
                    {
                        return;
                    }
                    
                }

                Sqlst = "SELECT  TM.Prod_Code,SUM(TM.No_Of_Packets),SUM(TM.Packet_Qty*Bn.Packet_Qty)  FROM dbo.tbTempBundlingIssueProduct TM JOIN dbo.tbBundlingProductDetails Bn ON Bn.Packet_Prod_Code=TM.Prod_Code AND TM.Main_Prod_Code=Bn.Prod_Code WHERE TempDocNo='"+lblTempDocNo.Text.Trim()+"'   GROUP BY TM.Prod_Code HAVING SUM(TM.No_Of_Packets) <> SUM(TM.Packet_Qty*Bn.Packet_Qty) ";
                objCommon.getDataSet(Sqlst, "ds");
                if((objCommon.Ads.Tables[0].Rows.Count>0))
                {
                    if (MessageBox.Show("Qty Mismatch.. "+ objCommon.Ads.Tables[0].Rows[0][0] + " Need Qty " + objCommon.Ads.Tables[0].Rows[0][2] + " Exsist Qty " + objCommon.Ads.Tables[0].Rows[0][1] + "   Sure to Contineu?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }

                }


                //objPacketingProduct.SqlStatement = "SELECT (P.Packet_Qty*TM.Packet_Qty)   ,TM.No_Of_Packets FROM dbo.tbTempBundlingIssueProduct TM JOIN dbo.tbBundlingProductDetails P ON TM.Prod_Code=P.Packet_Prod_Code WHERE TempDocNo='"+lblTempDocNo.Text.Trim()+"' AND (P.Packet_Qty*TM.Packet_Qty) > TM.No_Of_Packets";
                //objPacketingProduct.DataetName = "ds";
                //objPacketingProduct.GetItemDetails();

                //if (objPacketingProduct.GetProductDataset.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("not Enough Stock Available", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

              
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
                        objPacketingProduct.DeleteTempBundlingProduct(objPacketingProduct.ProductCode, lblTempDocNo.Text, dataGridViewTempPackProduct.SelectedRows[0].Cells[5].Value.ToString());

                        LoadTempData();


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
                    objPacketingProduct.SqlStatement = "SELECT BP.Packet_Prod_Code[Code],BP.Packet_Prod_Name[Description],BP.Packet_Qty[Req Qty],S.Qty[Stock] FROM dbo.tbBundlingProductDetails BP JOIN dbo.Product P ON P.Prod_Code = BP.Packet_Prod_Code JOIN dbo.Stock_Master S ON S.Prod_Code=BP.Packet_Prod_Code AND S.Loca='"+LoginManager.LocaCode+ "' WHERE  BP.Prod_Code='" + txtProductCode.Text.Trim() + "' ";
                }
                else
                {
                    if (txtSubProdCode.Text.Trim() == string.Empty && txtSubProdName.Text.Trim() != string.Empty)
                    {
                        objPacketingProduct.SqlStatement = "SELECT Packet_Prod_Code[Prod Code],Packet_Prod_Name[Description],Packet_Qty[Qty] FROM tbBundlingProductDetails WHERE Packet_Prod_Name LIKE '%" + txtSubProdName.Text.Trim() + "%' and Prod_Code='" + txtProductCode.Text.Trim() + "' ";
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
                    objPacketingProduct.SqlStatement = "SELECT P.Prod_Code, p.Prod_Name, P.Purchase_price, Stock_Master.Qty,  Packet_Qty  FROM tbBundlingProductDetails INNER JOIN Stock_Master ON tbBundlingProductDetails.Packet_Prod_Code = Stock_Master.Prod_Code JOIN dbo.Product P ON Packet_Prod_Code=P.Prod_Code WHERE tbBundlingProductDetails.Packet_Prod_Code = '" + txtSubProdCode.Text.Trim() + "' and Stock_Master.Loca = '" + LoginManager.LocaCode + "'  ";
                    
                    objPacketingProduct.ReadProductDetails();
                    if (objPacketingProduct.RecordFound == true)
                    {
                        txtSubProdCode.Text = objPacketingProduct.MainProductCode;
                        txtSubProdName.Text = objPacketingProduct.MainProductName;
                        lblSubPrice.Text = (string)objPacketingProduct.MainPurchasePrice.ToString();

                        lblSubTotQty.Text = (string)objPacketingProduct.CurrentQty.ToString();

                        cmbBatch.DataSource = objCommon.Get_BatchList(txtSubProdCode.Text, false);
                        cmbBatch.DisplayMember = "BatchNo";
                        cmbBatch.ValueMember = "BatchNo";
                        //cmbBatchNo.DroppedDown = true;
                        txtQty.Enabled = true;
                        cmbBatch.Focus();

                    }
                    else
                    {
                        txtSubProdCode.Text = string.Empty;
                        txtSubProdName.Text = string.Empty;
                        txtNoOfPackets.Text = string.Empty;
                        lblSubPrice.Text = string.Empty;
                        cmbBatch.DataSource = null;
                        lblBatchQty.Text = "0";
                        txtQty.Enabled = false;
                        txtSubProdCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        clsCommon objCommon = new clsCommon();

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductBundleIssue.GetBundleIssue = new frmProductBundleIssue();
            frmProductBundleIssue.GetBundleIssue.MdiParent = MainClass.mdi;
            frmProductBundleIssue.GetBundleIssue.Show();
        }



        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBatch.Text != "")
                {
                    clsCommon objCommon = new clsCommon();
                    DataTable dtBatch = objCommon.Get_BatchDetails(txtSubProdCode.Text.Trim(), cmbBatch.Text.Trim());
                    if (dtBatch != null && dtBatch.Rows.Count > 0)
                    {

                        lblBatchQty.Text = dtBatch.Rows[0]["Stock"].ToString();

                    }


                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubProdCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));

                    if (clsValidation.isNumeric(txtQty.Text.Trim(), System.Globalization.NumberStyles.Currency) == false)
                    {
                        MessageBox.Show("Qty not valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQty.Focus();
                        return;
                    }
                    if (txtSubProdCode.Text.Trim() == string.Empty || txtSubProdName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSubProdCode.Focus();
                        return;
                    }

                    if (cmbBatch.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Product batch not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbBatch.Focus();
                        return;
                    }
                    if(Convert.ToDecimal(lblBatchQty.Text.Trim()) < Convert.ToDecimal(txtQty.Text.Trim()))
                    {
                        MessageBox.Show("No Enogh Qty to Proceed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQty.Focus();
                        return;
                    }


                    objPacketingProduct.UpdateTempBundlingIssuePacketing(txtSubProdCode.Text,Convert.ToDecimal(txtQty.Text),cmbBatch.Text,lblTempDocNo.Text,txtProductCode.Text.Trim(),Convert.ToDecimal(txtNoOfPackets.Text));

                    LoadTempData();

                    txtSubProdCode.Text = string.Empty;
                    txtSubProdName.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    lblSubPrice.Text = string.Empty;
                    cmbBatch.DataSource = null;
                    lblBatchQty.Text = "0";
                    txtNoOfPackets.Enabled = false;
                  

                    txtSubProdCode.Focus();

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void cmbBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && cmbBatch.Text.Trim()!=string.Empty)
            {
                txtQty.Focus();
            }
        }
    }
}