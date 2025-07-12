using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using clsLibrary;

namespace OnimtaGiftVoucherSystem
{
    public partial class frmReportInquary : Form
    {
        public frmReportInquary()
        {
            InitializeComponent();
        }
        clsReportInquary objReportInquary = new clsReportInquary();
        frmSearch search = new frmSearch();
        clsReportViewer objRepView = new clsReportViewer();

        private string strQuery;
        public int RepOption;

        private static frmReportInquary ReportInquary;

        public static frmReportInquary GetReportInquary
        {
            get { return ReportInquary; }
            set { ReportInquary = value; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtCodeFrom.Text = "";
                txtNameFrom.Text = "";
                txtCodeTo.Text = "";
                txtNameTo.Text = "";
                
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
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
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void frmReportInquary_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ReportInquary = null;

            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void btnDisplay_MouseEnter(object sender, EventArgs e)
        {
            this.btnDisplay.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.LocationLeave;
        }

        private void btnDisplay_MouseLeave(object sender, EventArgs e)
        {
            this.btnDisplay.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.GifTool;
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            this.btnClear.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.LocationLeave;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            this.btnClear.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.GifTool;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            this.btnExit.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.LocationLeave;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.GifTool;
        }

        private void btnSearchCodeFrom_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                switch (RepOption)
                {

                    case 01:
                    case 02:
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Loca [Code], Loca_Descrip [Location] FROM gif_Location WHERE Loca LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Loca";

                        }
                        else
                        {
                            if (txtNameFrom.Text.Trim() != string.Empty)
                            {
                                strQuery = "SELECT Loca [Code], Loca_Descrip [Location] FROM gif_Location WHERE  Loca_Descrip LIKE '%" + txtNameFrom.Text.Trim() + "%' ORDER By Loca";

                            }
                            else
                            {
                                strQuery = "SELECT Loca [Code], Loca_Descrip [Location] FROM gif_Location ORDER By Loca";

                            }
                        }
                        break;


                }
                
                objReportInquary.CodeFrom = txtNameFrom.Text.Trim();
                objReportInquary.SqlStatement = strQuery;
                objReportInquary.DataSetName = "Table";
                objReportInquary.RetreiveData();
                search.dgSearch.DataSource = objReportInquary.ResultSet.Tables["Table"];
                  

                    //search.Cont_Code = txtCodeFrom;

                    
                        search.Cont_Code = txtCodeFrom;
                        search.Cont_Descrtip = txtNameFrom;
                        //txtCodeFrom.Text = search.Code;
                        //txtNameFrom.Text = search.Descrip;
                       // txtCodeFrom.Focus();
                        search.ShowDialog();
                    
         
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());

            }
            finally
            {
                objReportInquary.CloseConnection();
            }
        }

        private void btnSearchCodeTo_Click(object sender, EventArgs e)
        {
            try
            {
                 if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                switch (RepOption)
                {
                    case 01:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Loca [Code], Loca_Descrip [Location] FROM gif_Location WHERE Loca LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Loca";
                        }
                        else
                        {
                            if (txtNameTo.Text.Trim() != string.Empty)
                            {
                                strQuery = "SELECT Loca [Code], Loca_Descrip [Location] FROM gif_Location WHERE  Loca_Descrip LIKE '%" + txtNameTo.Text.Trim() + "%' ORDER By Loca";
                            }
                            else
                            {
                                strQuery = "SELECT Loca [Code], Loca_Descrip [Location] FROM gif_Location ORDER By Loca";
                            }
                        }
                        break;
                }
              
                    objReportInquary.CodeTo = txtNameTo.Text.Trim();
                    objReportInquary.SqlStatement = strQuery;
                    objReportInquary.DataSetName = "Table";
                    objReportInquary.RetreiveData();
                    search.dgSearch.DataSource = objReportInquary.ResultSet.Tables["Table"];
                   
                
                    //search.Cont_Code = txtCodeFrom;

                    
                        search.Cont_Code = txtCodeTo;
                        search.Cont_Descrtip = txtNameTo;
                        //txtCodeTo.Text = search.Code;
                        //txtNameTo.Text = search.Descrip;
                        //txtCodeTo.Focus();
                   
                    //search.EventEnd = false;
               search.ShowDialog();


            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReport = new DataSet();
                frmReportViewer ReportViewer = new frmReportViewer();
                if (DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateFrom.Text)) > DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateTo.Text)))
                {
                    MessageBox.Show("Selected date range is invalid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                switch (RepOption)
                {
                    case 01:
                        objRepView.SqlString = "SELECT BookNo, VisibleCode, Amount, Tr_Date, gif_Voucher.Loca , Loca_Descrip , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text.Trim() + "' DateFrom, '" + dtDateTo.Text.Trim() + "' DateTo  FROM gif_Voucher INNER JOIN gif_Location ON gif_Voucher.Loca = gif_Location.Loca WHERE (gif_Voucher.Loca BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND CONVERT(DATETIME, Tr_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ";
                        objRepView.DataSetName = "dsLocaWiseGift";
                        objRepView.RetrieveData();
                        dsReport = objRepView.TempDataSet;
                        rptLocaWiseCreatedGiftVoucher LocaWiseGift = new rptLocaWiseCreatedGiftVoucher();
                        LocaWiseGift.SetDataSource(dsReport);
                        ReportViewer.cryReport.ReportSource = LocaWiseGift;
                        ReportViewer.Show();
                        break;

                    case 02:
                        objRepView.SqlString = "SELECT VisibleCode [Voucher_Code], Receipt_No, Issued_Date, Amount, gif_Voucher.Loca, gif_Location.Loca_Descrip, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo] FROM gif_Voucher INNER JOIN gif_Location ON gif_Voucher.Loca = gif_Location.Loca  WHERE gif_Voucher.Loca = '" + txtCodeFrom.Text.Trim() + "'  AND CONVERT(DATETIME,gif_Voucher.Issued_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "' ,103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "' ,103) AND Iid='GV' AND Issued='T' ";
                        objRepView.DataSetName = "dsIssuedVoucher";
                        objRepView.RetrieveData();
                        dsReport = objRepView.TempDataSet;
                        rptIssuedGiftVoucher IssuedgiftVoucher = new rptIssuedGiftVoucher();
                        IssuedgiftVoucher.SetDataSource(dsReport);
                        ReportViewer.cryReport.ReportSource = IssuedgiftVoucher;
                        ReportViewer.Show();
                        break;

                }                                             
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void plTitalBar_MouseDown(object sender, MouseEventArgs e)
        {    
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    clsBase.ReleaseCapture();
                    clsBase.SendMessage(Handle, clsBase.WM_NCLBUTTONDOWN, clsBase.HT_CAPTION, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Stop Move", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
        
        }

        private void ctrlClose1_Load(object sender, EventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;

            }
            catch (Exception ex )
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void frmReportInquary_Load(object sender, EventArgs e)
        {
            try
            {
                switch (RepOption)
                {
                    case 02:
                        txtCodeTo.Enabled = false;
                        txtNameTo.Enabled = false;
                        lblFormHeader.Text = "Issued Gift Voucher";
                        btnSearchCodeTo.Enabled = false; 
                        break;

                }

            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

      

    }
}