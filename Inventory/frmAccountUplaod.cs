using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using System.Threading;
namespace Inventory
{
    public partial class frmAccountUplaod : Form
    {
        public frmAccountUplaod()
        {
            InitializeComponent();
        }
        clsAccUplad objAccApload = new clsAccUplad();
        private static frmAccountUplaod _AccountUp;
        public static frmAccountUplaod AccountUp
        {
            get { return _AccountUp; }
            set { _AccountUp = value; }
        }
        Thread st;
        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTransType.Text=="")
                {
                    MessageBox.Show("Select Transaction Type", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTransType.Focus(); return;
                }

                objAccApload.DateFrom = dtDateFrom.Text;
                objAccApload.DateTo = dtDateTo.Text;
                objAccApload.TempDocNo = lblDocNo.Text;
                objAccApload.TransType = cmbTransType.Text;
                objAccApload.Loca = cmbLoca.Text;
                Pnlloading.Visible = true;
                this.Refresh();
                objAccApload.UpdateData();
                if (tbcLoad.SelectedIndex==0)
                {
                    dgSalePur.DataSource = objAccApload.Ds.Tables["DsInvoiceDetails"];
                    dgSalePur.Refresh();
                    dgReceipt.DataSource = null;
                }
                else
                {
                    dgReceipt.DataSource = objAccApload.Ds1.Tables["PaymentDetails"];
                    dgReceipt.Refresh();
                    dgSalePur.DataSource = null;

                }
                Pnlloading.Visible = false;
            }
            catch (Exception ex)
            {
                objAccApload.Errormsg(ex, "frmAccountUplaod");
            }
        }
       
        private void frmAccountUplaod_Load(object sender, EventArgs e)
        {
            try
            {
                
                objAccApload.SqlQuery = "SELECT AccTemp FROM DocumentNoDetails WHERE Loca = ";
                objAccApload.GetTempDocumentNo();
                lblDocNo.Text = objAccApload.TempDocNo;
                objAccApload.SqlQuery = "SELECT Loca FROM Location";
                objAccApload.Dataset = "Location";
                objAccApload.SetDataset();
                cmbLoca.DataSource = objAccApload.Ds.Tables["Location"];
                cmbLoca.DisplayMember = "Loca";               
                pgBar.Maximum = 1000;
                cmbLoca.Refresh();
            }
            catch (Exception ex)
            {

                objAccApload.Errormsg(ex, "frmAccountUplaod");
            }
        }

        private void frmAccountUplaod_FormClosing(object sender, FormClosingEventArgs e)
        {
            AccountUp = null;
        }

        private void tbcLoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcLoad.SelectedIndex==1)
            {
                cmbTransType.Items.Clear();
                cmbTransType.Items.Add("Receipt");
               
                
            }
            else
            {
                cmbTransType.Items.Clear();
                cmbTransType.Items.Add("WholeSale");
                cmbTransType.Items.Add("Retail");
                cmbTransType.Items.Add("Purchase");
                
            }
        }

        private void btnUplaod_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Upload this data?", "Data uploaded ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    timer1.Enabled = true;
                    objAccApload.DateFrom = dtDateFrom.Text;
                    objAccApload.DateTo = dtDateTo.Text;
                    objAccApload.TempDocNo = lblDocNo.Text;
                    objAccApload.TransType = cmbTransType.Text;
                    objAccApload.Loca = cmbLoca.Text;
                    this.Refresh();
                    objAccApload.AccountUplad();
                    this.Refresh();

                    

                }
            }
            catch (Exception ex)
            {

                objAccApload.Errormsg(ex, "frmAccountUplaod");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pgBar.Minimum = 0;
            pgBar.Maximum = 100;
            pgBar.Step = 5;
            pgBar.PerformStep();
            lblPercent.Text = pgBar.Value.ToString()+"%";
            if (pgBar.Value == 100)
            {
                timer1.Stop();
                MessageBox.Show("Data uploade operation has been completed successfully!", "Data uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmAccountUplaod.AccountUp = new frmAccountUplaod();
                frmAccountUplaod.AccountUp.MdiParent = MainClass.mdi;
                frmAccountUplaod.AccountUp.Show();
                return;
            }
        }
    }
}