using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;

namespace Inventory
{
    public partial class frmCustomerAging : Form
    {
        public frmCustomerAging()
        {
            InitializeComponent();
            clsValidation.TextChanged(txtAge, System.Globalization.NumberStyles.Integer);
        }
        public int ReportNumber = 0;
        clsReport report = new clsReport();
        clsMainClass Rep = new clsMainClass();
       

        private static  frmCustomerAging _CustomerAging;

        public static  frmCustomerAging GetCustomerAging
        {
            get { return  _CustomerAging; }
            set {  _CustomerAging = value; }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                Rep.dataset = Rep.getDataSet("SELECT Cus_Code,Cus_Name,Address1 [Address],Mobile,NICNumber,Birthday,'" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo], ROUND((DATEDIFF(dd,CONVERT(DATETIME,REPLACE(Birthday,'/ ',''),103),GETDATE())/365.25),0,1) [Age],'"+txtAge.Text.Trim()+"' [Age], NICNumber [NIC] FROM CRM_Customer WHERE DATEADD(yy," + txtAge.Text.Trim().ToString() + ",CONVERT(DATETIME,REPLACE(Birthday,'/  /',''),103)) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim().ToString() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim().ToString() + "',103) AND LEN(REPLACE(Birthday,' ','')) = 10", "Customer");
                report.DisplayReport(new Inventory.CRMReports.rptCustomerAging(), Rep.dataset, "Customer Aging", "Customer Details");

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtAge.Text = "";

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
               
            }
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   
                }

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void lblAge_Click(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Rep.dataset = Rep.getDataSet("SELECT Cus_Code,Cus_Name,Address1 [Address],Mobile,NICNumber,Birthday,'" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo], ROUND((DATEDIFF(dd,CONVERT(DATETIME,REPLACE(Birthday,'/ ',''),103),GETDATE())/365.25),0,1) [Age],'" + txtAge.Text.Trim() + "' [Age], NICNumber [NIC],Card_No FROM CRM_Customer WHERE DATEADD(yy," + txtAge.Text.Trim().ToString() + ",CONVERT(DATETIME,REPLACE(Birthday,'/  /',''),103)) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim().ToString() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim().ToString() + "',103) AND LEN(REPLACE(Birthday,' ','')) = 10", "Customer");
                report.DisplayReport(new Inventory.CRMReports.rptCustomerAging(), Rep.dataset, "Customer Aging", "Customer Details");

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());

            }

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtAge.Text = "";

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
               
            }

        }

        private void frmCustomerAging_Load(object sender, EventArgs e)
        {

        }

       

    }
}