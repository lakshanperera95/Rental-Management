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
    public partial class frmCardTopup : Form
    {
        public frmCardTopup()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private static frmCardTopup IsForm;
        public static frmCardTopup GetForm
        {
            get { return IsForm; }
            set { IsForm = value; }
        }
        frmPayment Payment = new frmPayment("", "", "", "", "");
        frmSearch search = new frmSearch();
        clsGiftVoucherIssue ObjGifIssue = new clsGiftVoucherIssue();
     

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCardNo.Text.Trim()!=string.Empty)
                {

                    ObjGifIssue.RecallTopUpCard(txtCardNo.Text.Trim());
                    if (ObjGifIssue.Ds.Tables[0].Rows.Count > 0)
                    {
                        txtBalAmount.Text = ObjGifIssue.Ds.Tables[0].Rows[0][0].ToString();
                        txtCardNo.Enabled = false;
                        txtRechargeAmount.SelectAll();
                        txtRechargeAmount.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Card Number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBalAmount.Text =txtRechargeAmount.Text= "0.00";
                        txtCardNo.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmCardTopup_Load(object sender, EventArgs e)
        {
            try
            {
                ObjGifIssue.GetTempDocumentNo("TCR");
                lblDocNo.Text = ObjGifIssue.TempDocNo;

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
                if (txtCardNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Card Number not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCardNo.Focus();
                    return;
                }

                ObjGifIssue.RecallTopUpCard(txtCardNo.Text.Trim());
                if (ObjGifIssue.Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Card Number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCardNo.Focus();
                    return;
                }

                if (txtRechargeAmount.Text.Trim() == string.Empty || clsValidation.isNumeric(txtRechargeAmount.Text.Trim(), System.Globalization.NumberStyles.Number) == false || Convert.ToDecimal(txtRechargeAmount.Text.Trim())==0)
                {
                    MessageBox.Show("Invalid Amount", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRechargeAmount.Focus();
                    return;
                }
                if (Payment != null)
                { Payment.Close(); }
                Payment = new frmPayment(txtRechargeAmount.Text.Trim(),"CREDIT", lblDocNo.Text.Trim(),"TOPC","GIFTPAY");
                Payment.ShowDialog();


                decimal PayAmount = Payment.PayedAmount;
                decimal Total = Convert.ToDecimal(txtRechargeAmount.Text.Trim());

                if (Total > PayAmount)
                {
                    MessageBox.Show("Invalid Payment Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (MessageBox.Show("Do you want to Recharge this Amount. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmReportViewer objRepViewer = new frmReportViewer();
                    DataSet ds = new DataSet();

                    ds = ObjGifIssue.ApplyTopUpCard(lblDocNo.Text.Trim(), txtCardNo.Text.Trim(), Convert.ToDecimal(txtRechargeAmount.Text.Trim()));


                    if (MessageBox.Show("Card Recharge Success.!Do you Want to view the Receipt ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ds.Tables[0].TableName = "tbPaidPaymentSummary";
                        ds.Tables[1].TableName = "CompanyProfile";
                        ds.Tables[2].TableName = "tbPaidPaymentMode";

                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerPayment_eng.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(ds);
                        objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(ds);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        objRepViewer.WindowState = FormWindowState.Maximized;
                        objRepViewer.Show();
                    }
                    btnClear.PerformClick();

                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCardNo.Text = txtBalAmount.Text = txtRechargeAmount.Text = string.Empty;
            txtCardNo.Enabled = true;

            dpDate.Value = DateTime.Now;
        }

        private void txtRechargeAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnApply.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCardTopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsForm = null;
        }
    }
}