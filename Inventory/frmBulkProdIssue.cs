using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmBulkProdIssue : Form
    {
        public frmBulkProdIssue()
        {
            InitializeComponent();
        }
        public frmBulkProdIssue(string ProdCode)
        {
            InitializeComponent();
            txtProductCode.Text = ProdCode;
           

        }
        private static frmBulkProdIssue _BulkProdIssue;
        public static frmBulkProdIssue BulkProdIssue
        {
            get { return _BulkProdIssue; }
            set { _BulkProdIssue = value; }
        }


        frmSearch search = new frmSearch();

        clsBulkProductCombination objbundlIssue = new clsBulkProductCombination();

        frmReportViewer ReportViewer = new frmReportViewer();
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
                    objbundlIssue.SqlStatement = "SELECT  Prod_Code [Product Code], Prod_Name [Product Name] FROM dbo.tb_CombinationProduct  JOIN dbo.Product P ON SubProd_Code=P.Prod_Code WHERE P.Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%'  AND P.LockedItem='F' group by Prod_Code,Prod_Name  ORDER BY P.Prod_Code ASC";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objbundlIssue.SqlStatement = "SELECT  Prod_Code [Product Code], Prod_Name [Product Name] FROM dbo.tb_CombinationProduct  JOIN dbo.Product P ON SubProd_Code=P.Prod_Code  WHERE P.Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%'   AND P.LockedItem='F'  group by Prod_Code,Prod_Name   ORDER BY P.Prod_Code ASC";
                    }
                    else
                    {
                        objbundlIssue.SqlStatement = "SELECT  Prod_Code [Product Code], Prod_Name [Product Name] FROM dbo.tb_CombinationProduct  JOIN dbo.Product P ON SubProd_Code=P.Prod_Code WHERE P.LockedItem='F'   group by Prod_Code,Prod_Name   ORDER BY P.Prod_Code ASC";
                    }
                }
                objbundlIssue.GetItemDetails("dsProduct");
                search.dgSearch.DataSource = objbundlIssue.dataset.Tables["dsProduct"];
                search.prop_Focus = txtProductCode;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmBulkProdIssue_Load(object sender, EventArgs e)
        {
            try
            {
                if (objbundlIssue.Reder("SELECT Temp_BIS FROM DocumentNoDetails WHERE Loca='" + LoginManager.LocaCode + "'; UPDATE DocumentNoDetails SET Temp_BIS=Temp_BIS+1 WHERE Loca='" + LoginManager.LocaCode + "'") == true)
                {
                    int docNo = (int)objbundlIssue.Reader[0];
                    lblDocNo.Text = "BIS" + string.Format("{0:0000000}", docNo);
                }
                else
                {
                    lblDocNo.Text = "Empty DocNo";
                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }



        }

        private void frmBulkProdIssue_FormClosed(object sender, FormClosedEventArgs e)
        {
            _BulkProdIssue = null;
        }

        public void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string Sqlst = "SELECT P1.Prod_Name, Stock_Master.Qty [Qty], dbo.tb_CombinationProduct.Qty Qty2, P1.Purchase_price [Purchase_price], MainProdCode, P2.Prod_Name MainProdName FROM dbo.tb_CombinationProduct  JOIN  Product P1 ON P1.Prod_Code=SubProd_Code JOIN  Product P2 ON P2.Prod_Code=MainProdCode INNER JOIN Stock_Master ON MainProdCode=Stock_Master.Prod_Code  AND Loca='" + LoginManager.LocaCode + "'  WHERE MainProdCode IS NOT NULL AND SubProd_Code='" + txtProductCode.Text.Trim() + "'  AND P1.LockedItem='F' AND P2.LockedItem='F'";

                    clsCommon ObjComm = new clsCommon();
                    ObjComm.getDataSet(Sqlst, "ds");

                    if(ObjComm.Ads.Tables[0].Rows.Count > 0)
                    {

                        if (ObjComm.Ads.Tables[0].Rows.Count > 1)
                        {
                            Sqlst = "SELECT  MainProdCode, P2.Prod_Name MainProdName,tb_CombinationProduct.Qty FROM dbo.tb_CombinationProduct  JOIN  Product P1 ON P1.Prod_Code=SubProd_Code JOIN  Product P2 ON P2.Prod_Code=MainProdCode INNER JOIN Stock_Master ON MainProdCode=Stock_Master.Prod_Code  AND Loca='"+LoginManager.LocaCode+"'  WHERE MainProdCode IS NOT NULL AND SubProd_Code='"+txtProductCode.Text+"'  AND P1.LockedItem='F' AND P2.LockedItem='F'";
                            ObjComm.getDataSet(Sqlst, "ds");

                            search.dgSearch.DataSource = ObjComm.Ads.Tables[0];
                            search.prop_Focus = lblMainProductCode;
                            search.Show();
                            search.BringToFront();

                        }
                        else if (objbundlIssue.Reder("SELECT P1.Prod_Name, Stock_Master.Qty [Qty], dbo.tb_CombinationProduct.Qty Qty2, P1.Purchase_price [Purchase_price], MainProdCode, P2.Prod_Name MainProdName FROM dbo.tb_CombinationProduct  JOIN  Product P1 ON P1.Prod_Code=SubProd_Code JOIN  Product P2 ON P2.Prod_Code=MainProdCode INNER JOIN Stock_Master ON MainProdCode=Stock_Master.Prod_Code  AND Loca='" + LoginManager.LocaCode + "'  WHERE MainProdCode IS NOT NULL AND SubProd_Code='" + txtProductCode.Text.Trim() + "'  AND P1.LockedItem='F' AND P2.LockedItem='F'") == true)
                        {
                            txtProductName.Text = objbundlIssue.Reader["Prod_Name"].ToString();
                            lblPurchasePrice.Text = objbundlIssue.Reader["Purchase_price"].ToString();
                            lblPackQty.Text = objbundlIssue.Reader["Qty2"].ToString();
                            lblMainQty.Text = objbundlIssue.Reader["Qty"].ToString();
                            lblMainProductCode.Text = objbundlIssue.Reader["MainProdCode"].ToString();
                            lblMainProductName.Text = objbundlIssue.Reader["MainProdName"].ToString();

                            clsCommon objCommon = new clsCommon();
                            cmbBatchNo.DataSource = objCommon.Get_BatchList(lblMainProductCode.Text, false);
                            cmbBatchNo.DisplayMember = "BatchNo";
                            cmbBatchNo.ValueMember = "BatchNo";



                            txtNoOfPackets.Enabled = true;
                            cmbBatchNo.Focus();

                        }
                        else
                        {
                            txtProductCode.Focus();
                            MessageBox.Show("Product code not found or don't have bulk product under this code please check the product code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }

                   


                }
                catch (Exception ex)
                {

                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
            }
        }

        private void txtNoOfPackets_KeyPress(object sender, KeyPressEventArgs e)
        {
            objbundlIssue.checkNumeric(e, txtNoOfPackets.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNoOfPackets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtNoOfPackets.Text == "")
                    {
                        txtNoOfPackets.Text = "0";

                    }
                    if (decimal.Parse(txtNoOfPackets.Text) <= 0)
                    {
                        txtNoOfPackets.Focus();
                        txtNoOfPackets.SelectAll();
                        MessageBox.Show("Invalied Qty", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                    if (objbundlIssue.Reder("SELECT Prod_Name, Qty, Product.Purchase_price FROM tb_CombinationProduct INNER JOIN Product ON Prod_Code=SubProd_Code WHERE SubProd_Code='" + txtProductCode.Text.Trim() + "'") != true)
                    {
                        txtProductCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    else
                    {

                        if (cmbBatchNo.Text.Trim()==string.Empty)
                        { 
                            MessageBox.Show("No Batch Selected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbBatchNo.Focus();
                            return;
                        }

                        cmbBatchNo_SelectedIndexChanged(sender, e);

                        string Sqlst = "SELECT isnull(SUM(No_Of_Packets),0) FROM dbo.tb_TempBulkProductDetails WHERE BatchNo='"+cmbBatchNo.Text+"' AND Main_Prod_Code='"+lblMainProductCode.Text+"' AND Doc_No='"+lblDocNo.Text.Trim()+"'";
                        clsCommon ObjComm = new clsCommon();

                        ObjComm.getDataSet(Sqlst, "ds");

                        decimal frevQty = Convert.ToDecimal( ObjComm.Ads.Tables[0].Rows[0][0]);

                        if (decimal.Parse(lblMainQty.Text) < (decimal.Parse(txtNoOfPackets.Text)+frevQty ))
                        {
                            txtNoOfPackets.Focus();
                            txtNoOfPackets.SelectAll();
                            MessageBox.Show("No enough qty in order to continue", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        objbundlIssue.Temp_BulkIsse(txtProductCode.Text.Trim(), txtProductName.Text.Trim(), dtPostDate.Text, lblDocNo.Text, lblMainProductCode.Text, lblMainProductName.Text, decimal.Parse(lblPurchasePrice.Text), decimal.Parse(lblPackQty.Text), decimal.Parse(txtNoOfPackets.Text.Trim()),cmbBatchNo.Text);
                        dgBulkIssue.DataSource = objbundlIssue.dataset.Tables["dsTempPacketProduct"];
                        dgBulkIssue.Refresh();

                        txtProductCode.Text = txtProductName.Text = lblMainProductCode.Text = lblMainProductName.Text = string.Empty;
                        lblPurchasePrice.Text = lblMainQty.Text = lblPackQty.Text = txtNoOfPackets.Text = "0" ;
                        cmbBatchNo.DataSource = null;
                        cmbBatchNo.Text = string.Empty;

                        txtProductCode.Focus();

                    }


                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());

                }
            }
        }

        private void dgBulkIssue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objbundlIssue.Temp_BulkDelte(dgBulkIssue.SelectedRows[0].Cells[4].Value.ToString(), lblDocNo.Text, dgBulkIssue.SelectedRows[0].Cells[0].Value.ToString(), dgBulkIssue.SelectedRows[0].Cells[3].Value.ToString());
                        dgBulkIssue.DataSource = objbundlIssue.dataset.Tables["dsTempPacketProduct"];
                        dgBulkIssue.Refresh();
                    }
                }
                catch (Exception ex)
                {

                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }               
                
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Apply this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet ds = new DataSet();
                    objbundlIssue.BulkIssueApply(dtPostDate.Text, lblDocNo.Text);
                    MessageBox.Show("Transaction Applied successful!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //  rptBulkIssue BulkIssue = new rptBulkIssue();
                    ReportViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptBulkIssue.rpt");                   
                    ds = objbundlIssue.dataset;
                    ReportViewer.DirectPrintVerRep.SetDataSource(ds);
                    ReportViewer.crystalReportViewer1.ReportSource = ReportViewer.DirectPrintVerRep;
                    ReportViewer.WindowState = FormWindowState.Maximized;
                    ReportViewer.Show();
                    this.Close();
                    this.Dispose();
                    _BulkProdIssue = null;
                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBatchNo.Text != "")
                {
                    clsCommon objCommon = new clsCommon();
                    DataTable dtBatch = objCommon.Get_BatchDetails(lblMainProductCode.Text.Trim(), cmbBatchNo.Text.Trim());
                    if (dtBatch != null && dtBatch.Rows.Count > 0)
                    {
                       
                        lblMainQty.Text = dtBatch.Rows[0]["Stock"].ToString();
                         
                    }
                    

                }
               
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void cmbBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && cmbBatchNo.Text.Trim()!=string.Empty)
            {
                txtNoOfPackets.Focus();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblMainProductCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if(search.Code!=null && search.Code!=string.Empty)
                {
                    if (objbundlIssue.Reder("SELECT P1.Prod_Name, Stock_Master.Qty [Qty], dbo.tb_CombinationProduct.Qty Qty2, P1.Purchase_price [Purchase_price], MainProdCode, P2.Prod_Name MainProdName FROM dbo.tb_CombinationProduct  JOIN  Product P1 ON P1.Prod_Code=SubProd_Code JOIN  Product P2 ON P2.Prod_Code=MainProdCode INNER JOIN Stock_Master ON MainProdCode=Stock_Master.Prod_Code  AND Loca='01'  WHERE MainProdCode IS NOT NULL AND SubProd_Code='" + txtProductCode.Text.Trim() + "' and MainProdCode='"+lblMainProductCode.Text+"'  AND P1.LockedItem='F' AND P2.LockedItem='F'") == true)
                    {
                        txtProductName.Text = objbundlIssue.Reader["Prod_Name"].ToString();
                        lblPurchasePrice.Text = objbundlIssue.Reader["Purchase_price"].ToString();
                        lblPackQty.Text = objbundlIssue.Reader["Qty2"].ToString();
                        lblMainQty.Text = objbundlIssue.Reader["Qty"].ToString();
                        lblMainProductCode.Text = objbundlIssue.Reader["MainProdCode"].ToString();
                        lblMainProductName.Text = objbundlIssue.Reader["MainProdName"].ToString();

                        clsCommon objCommon = new clsCommon();
                        cmbBatchNo.DataSource = objCommon.Get_BatchList(lblMainProductCode.Text, false);
                        cmbBatchNo.DisplayMember = "BatchNo";
                        cmbBatchNo.ValueMember = "BatchNo";



                        txtNoOfPackets.Enabled = true;
                        cmbBatchNo.Focus();

                    }
                    else
                    {
                        txtProductCode.Focus();
                        MessageBox.Show("Product code not found or don't have bulk product under this code please check the product code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

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