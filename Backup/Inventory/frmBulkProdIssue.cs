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
                    objbundlIssue.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtProductCode.Text.Trim() + "%' AND Loose=1 AND LockedItem='F' ORDER BY Prod_Code ASC";
                }
                else
                {
                    if (txtProductCode.Text.Trim() == string.Empty && txtProductName.Text.Trim() != string.Empty)
                    {
                        objbundlIssue.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtProductName.Text.Trim() + "%' AND Loose=1 AND LockedItem='F' ORDER BY Prod_Code ASC";
                    }
                    else
                    {
                        objbundlIssue.SqlStatement = "SELECT Prod_Code [Product Code], Prod_Name [Product Name] FROM Product WHERE Loose=1 AND LockedItem='F' ORDER BY Prod_Code ASC";
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

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (objbundlIssue.Reder("SELECT Prod_Name, Stock_Master.Qty [Qty], tb_TempCombination.Qty Qty2, Product.Purchase_price [Purchase_price], MainProdCode, MainProdName FROM tb_TempCombination RIGHT OUTER JOIN  Product ON Prod_Code=SubProd_Code INNER JOIN Stock_Master ON MainProdCode=Stock_Master.Prod_Code  WHERE MainProdCode IS NOT NULL AND SubProd_Code='" + txtProductCode.Text.Trim() + "' AND LOOSE=1") == true)
                    {
                        txtProductName.Text = objbundlIssue.Reader["Prod_Name"].ToString();
                        lblPurchasePrice.Text = objbundlIssue.Reader["Purchase_price"].ToString();
                        lblPackQty.Text = objbundlIssue.Reader["Qty2"].ToString();
                        lblMainQty.Text = objbundlIssue.Reader["Qty"].ToString();
                        lblMainProductCode.Text = objbundlIssue.Reader["MainProdCode"].ToString();
                        lblMainProductName.Text = objbundlIssue.Reader["MainProdName"].ToString();
                        txtNoOfPackets.Enabled = true;
                        txtNoOfPackets.Focus();
                      //  if (objbundlIssue.Reder("SELECT Qty FROM Stock_Master WHERE Prod_Code='" + lblMainProductCode.Text + "' AND Loca='" + LoginManager.LocaCode + "'") == true)
                       // {
                            
                            //lblMainQty.Text = objbundlIssue.Reader["Qty"].ToString();
                          
                       // }
                    }
                    else
                    {
                        txtProductCode.Focus();
                        MessageBox.Show("Product code not found or don't have bulk product under this code please check the product code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                   
                    if (objbundlIssue.Reder("SELECT Prod_Name, Qty, Product.Purchase_price FROM tb_TempCombination INNER JOIN Product ON Prod_Code=SubProd_Code WHERE SubProd_Code='" + txtProductCode.Text.Trim() + "'") != true)
                    {
                        txtProductCode.Focus();
                        MessageBox.Show("Product Code Not Found. Please Check Product Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (decimal.Parse(lblMainQty.Text) < decimal.Parse(txtNoOfPackets.Text))
                        {
                            txtNoOfPackets.Focus();
                            txtNoOfPackets.SelectAll();
                            MessageBox.Show("No enugh qty in order to cuntinue", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        objbundlIssue.Temp_BulkIsse(txtProductCode.Text.Trim(), txtProductName.Text.Trim(), dtPostDate.Text, lblDocNo.Text, lblMainProductCode.Text, lblMainProductName.Text, decimal.Parse(lblPurchasePrice.Text), decimal.Parse(lblPackQty.Text), decimal.Parse(txtNoOfPackets.Text.Trim()));
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

        private void dgBulkIssue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objbundlIssue.Temp_BulkDelte(dgBulkIssue.SelectedRows[0].Cells[4].Value.ToString(), lblDocNo.Text, dgBulkIssue.SelectedRows[0].Cells[0].Value.ToString());
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
                    rptBulkIssue BulkIssue = new rptBulkIssue();
                    ds = objbundlIssue.dataset;
                    BulkIssue.SetDataSource(ds);
                    ReportViewer.crystalReportViewer1.ReportSource = BulkIssue;
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
    }
}