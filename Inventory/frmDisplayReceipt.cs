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
//using BillPreview;


namespace Inventory
{
    public partial class frmDisplayReceipt : Form
    {
        public frmDisplayReceipt()
        {
            InitializeComponent();
        }

        //ClsFillGrid objMod = new ClsFillGrid();
        clsDisplayReceipt objDisplayReceipt = new clsDisplayReceipt();
        clsCommon objCommon = new clsCommon();
        
        private static frmDisplayReceipt DisplayReceipt;
        public static frmDisplayReceipt GetDisplayReceipt
        {
            get { return DisplayReceipt; }
            set { DisplayReceipt = value; }
        }
        private DataSet dsUnit;
        

        private void frmDisplayReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                objCommon.SetConnection(LoginManager.ServerName, LoginManager.DatabaseName, LoginManager.User, LoginManager.Password);
                objDisplayReceipt.GetLocation();
                cmbLocaCode.DataSource = objDisplayReceipt._dsLocation.Tables["Location"];
                cmbLocaDes.DataSource = objDisplayReceipt._dsLocation.Tables["Location"];
                cmbLocaCode.DisplayMember = "Loca";
                cmbLocaDes.DisplayMember = "Loca_Descrip";
                
               // cmbLocaCode.Text = "-select-";
               // cmbLocaDes.Text = "-select-";

                objDisplayReceipt.GetUnit();
                cmbUnit.DataSource = objDisplayReceipt._dsUnit.Tables["unit"];
                cmbUnit.DisplayMember = "Unit";
                cmbUnit.Text = "-select-";

                


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }


        }

        private void frmDisplayReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisplayReceipt = null;
        }



        private void cmbUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        private void cmbLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLocaDes.Focus();
            }
        }

        private void cmbLocaDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpBillDate.Focus();
            }
        }

        private void dtpBillDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    objCommon.getDataReader("EXEC sp_Receipt_View '" + dtpBillDate.Text + "'");
                }
                catch (Exception ex)
                {

                    objCommon.Errormsg(ex, "frmDisplayReceipt, dtpBillDate_KeyDown");
                }
                cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    cmbReportID.Text = "";
                    cmbReceiptNo.Text = "";
                    //cmbReceiptNo.Items.Clear();
                    listView1.Items.Clear();
                    string SqlSatatement = "SELECT distinct ReportID FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' AND BillDate = '" + dtpBillDate.Text + "' AND Unit = '" + cmbUnit.Text.Trim() + "'";
                    objCommon.getDataSet(SqlSatatement, "DsCom");
                    cmbReportID.DataSource = objCommon.Ads.Tables["DsCom"];
                    cmbReportID.DisplayMember = "ReportID";
                    cmbReportID.Focus();
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                
            }
        }
        private void cmbReceiptNo_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void cmbReportID_SelectedValueChanged(object sender, EventArgs e)
        
        {

        }

        private void cmbReportID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbReportID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbReportID.Text == "")
                        return;
                    
                    string strSqlStatemnt = "SELECT DISTINCT Receipt_No FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' AND unit = '" + cmbUnit.Text + "' AND billdate = '" + dtpBillDate.Text + "' AND ReportID = '" + cmbReportID.Text + "' ORDER BY Receipt_No ASC";
                    objCommon.getDataSet(strSqlStatemnt, "DsRecpt");
                    cmbReceiptNo.DataSource = objCommon.Ads.Tables["DsRecpt"];
                    cmbReceiptNo.DisplayMember = "Receipt_No";
                    cmbReceiptNo.Focus();

                }


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
        }

        private void cmbReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cmbReceiptNo.Text == "")
                        return;
                    string SqlStatement = "SELECT Item_Code,Item_Descrip,Unit_Price,Qty,Amount,BillTime,UserName FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' and unit = '" + cmbUnit.Text + "' and billdate = '" + dtpBillDate.Text + "' and ReportID = '" + cmbReportID.Text + "' and Receipt_No = '" + cmbReceiptNo.Text + "' and Iid in('001','R01','SBTT','CSH','BAL','005','CNL','003','CRD','G01','G02') ORDER BY ID_NO ASC";
                    objCommon.getDataReader(SqlStatement);

                    listView1.Items.Clear();

                    while (objCommon.Adr.Read())
                    {

                        ListViewItem List = new ListViewItem(objCommon.Adr[0].ToString());

                        for (int i = 1; i < objCommon.Adr.FieldCount; i++)
                        {
                            List.SubItems.Add(objCommon.Adr[i].ToString());

                        }
                        listView1.Items.Add(List);
                    }
                    btnDisplayReceipt.PerformClick();
                }
                catch (Exception ex)
                {

                    objCommon.Errormsg(ex, "frmDisplayReceipt, cmbReceiptNo_KeyDown");
                }
                


            }
        }

        private void cmbReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string SqlStatement = "SELECT Item_Code,Item_Descrip,Unit_Price,Qty,Amount,BillTime,UserName FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' and unit = '" + cmbUnit.Text + "' and billdate = '" + dtpBillDate.Text + "' and ReportID = '" + cmbReportID.Text + "' and Receipt_No = '" + cmbReceiptNo.Text + "' and Iid in('001','R01','SBTT','CSH','BAL','005','CNL','003','CRD','G01','G02') ORDER BY ID_No ASC";
                objCommon.getDataReader(SqlStatement);

                listView1.Items.Clear();

                while (objCommon.Adr.Read())
                {

                    ListViewItem List = new ListViewItem(objCommon.Adr[0].ToString());

                    for (int i = 1; i < objCommon.Adr.FieldCount; i++)
                    {
                        List.SubItems.Add(objCommon.Adr[i].ToString());

                    }
                    listView1.Items.Add(List);
                }
               // btnDisplayReceipt.PerformClick();
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbReceiptNo_SelectedIndexChanged");
            }

                //foreach (ListViewItem item in listView1.Items)
                //{

                //    //item.BackColor = item.Index % 2 == 0 ? Color.Magenta : Color.White;
                //}

            
        }

        private void btnDisplayReceipt_Click(object sender, EventArgs e)
        {
               //try
               // {
               //     if (cmbReceiptNo.Text.Length < 8 || cmbReceiptNo.Text=="-select-")
               //         return;
               //     txtReceipt.Text = "";
               //     txtReceipt.ReadOnly = true;
               //     objMod.ModuleReader(cmbReceiptNo.Text, cmbReportID.Text, dtpBillDate.Text, cmbReceiptNo.Text,cmbLocaCode.Text, cmbUnit.Text,txtReceipt,LoginManager.ServerName, LoginManager.DatabaseName, LoginManager.User, LoginManager.Password);
               // //objMod.Print(cmbReceiptNo.Text, "T", txtReceipt, LoginManager.UserName, dtpBillDate.Text.ToString());
               // btnPrintBill.Visible = true;
               // }
               // catch (Exception ex)
               // {

               //     objCommon.Errormsg(ex, "frmDisplayReceipt, btnDisplayReceipt_Click");
               // }

            }

        private void cmbLocaCode_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmbLocaCode.DisplayMember = "Loca";
                cmbLocaDes.DisplayMember = "Loca_Descrip";
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbLocaCode_SelectedIndexChanged");
            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet dsDataForReport = new DataSet();
                DataSet dsSubReport = new DataSet();
                clsReportViewer objRepView = new clsReportViewer();
                clsSalesInquary objSalesInquary = new clsSalesInquary();

                frmReportViewer objRepViewer2 = new frmReportViewer();
                frmReportViewer objRepViewer = new frmReportViewer();
                objRepView.SqlStatement = "select ROW_NUMBER() OVER(PARTITION BY Receipt_No ORDER BY D.Id_No ASC) AS Ln,Iid,Receipt_No,unit,Item_Code,Item_Descrip,Dis,Unit_Price,Qty,Amount,BillTime,BillDate,UserName,ReportID,L.Loca , L.Loca_Descrip ,Header1 as Head1 ,Address1,Address2,Tel,EMail,Web_Address from DayEnd_Pos_Transaction D INNER JOIN Location L ON L.Loca = D.Loca INNER JOIN tb_ComHeader ON 1=1  WHERE BillDate ='" + dtpBillDate.Text.ToString() + "' AND D.Loca ='" + cmbLocaCode.Text.ToString() + "' AND Unit ='" + cmbUnit.Text.ToString() + "' AND ReportID='" + cmbReportID.Text.ToString() + "' AND Iid in('001','R01','SBTT','CSH','BAL','005','CNL','003','CRD','G01','G02','ERR','V01') order by D.Id_No ";
                objRepView.DataSetName = "dsPOSBillDetails";
                objRepView.RetrieveData();
                dsDataForReport = objRepView.TempResultSet;
                objRepViewer.verReport = new rptPOSBillDetails();
                objRepViewer.verReport.SetDataSource(dsDataForReport);
                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;


                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Refresh();
                objRepViewer.Show();
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbLocaCode_SelectedIndexChanged");
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsDataForReport = new DataSet();
                DataSet dsSubReport = new DataSet();
                clsReportViewer objRepView = new clsReportViewer();
                clsSalesInquary objSalesInquary = new clsSalesInquary();

                frmReportViewer objRepViewer2 = new frmReportViewer();
                frmReportViewer objRepViewer = new frmReportViewer();
                objRepView.SqlStatement = "select ROW_NUMBER() OVER(PARTITION BY Receipt_No ORDER BY D.Id_No ASC) AS Ln,Iid,Receipt_No,unit,Item_Code,Item_Descrip,Dis,Unit_Price,Qty,Amount,BillTime,BillDate,UserName,ReportID,L.Loca , L.Loca_Descrip ,Header1 as Head1 ,Address1,Address2,Tel,EMail,Web_Address from DayEnd_Pos_Transaction D INNER JOIN Location L ON L.Loca = D.Loca INNER JOIN tb_ComHeader ON 1=1  WHERE BillDate ='" + dtpBillDate.Text.ToString() + "' AND D.Loca ='" + cmbLocaCode.Text.ToString() + "' AND Unit ='" + cmbUnit.Text.ToString() + "' AND ReportID='" + cmbReportID.Text.ToString() + "' AND Receipt_No ='"+ cmbReceiptNo.Text.ToString()+"' AND Iid in('001','R01','SBTT','CSH','BAL','005','CNL','003','CRD','G01','G02','ERR','V01') order by D.Id_No ";
                objRepView.DataSetName = "dsPOSBillDetails";
                objRepView.RetrieveData();
                dsDataForReport = objRepView.TempResultSet;
                objRepViewer.verReport = new rptPOSBillDetails();
                objRepViewer.verReport.SetDataSource(dsDataForReport);
                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;


                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Refresh();
                objRepViewer.Show();
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbLocaCode_SelectedIndexChanged");
            }
        }

        private void btnDisplaydayend_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsDataForReport = new DataSet();
                DataSet dsSubReport = new DataSet();
                clsReportViewer objRepView = new clsReportViewer();
                clsSalesInquary objSalesInquary = new clsSalesInquary();

                frmReportViewer objRepViewer2 = new frmReportViewer();
                frmReportViewer objRepViewer = new frmReportViewer();
                objSalesInquary.DateFrom = dtpBillDate.Text.Trim();
                objSalesInquary.DateTo = dtpBillDate.Text.Trim();
                objSalesInquary.Loca = cmbLocaCode.Text.ToString();
                objSalesInquary.strUnits = cmbUnit.Text.Trim();
                objSalesInquary.strReportId = cmbReportID.Text.ToString();

                objSalesInquary.PosSalesSummaryFORPOSPRINT();
                //objRepView.SqlStatement = "select Unit_No, PosGross_Sales, PosRefund_Tot, PosRefund_No, PosVoid_Tot, PosVoid_No, PosError_Tot, PosError_No, PosCancel_Tot, PosCancel_No, PosNet_Amt, PosCash_Amt, PosCredit_amt, PosBill_Count, PosExchange_Tot, PosExchange_No, PosDiscount_Tot, PosDiscount_No, Declare_Amount, Pos_CashOut, Card1_Descr, Card1_Amount, Card2_Descr, Card2_Amount, Card3_Descr, Card3_Amount ,Card4_Descr ,Card4_Amount ,Card5_Descr ,Card5_Amount ,Dept1_Descr ,Dept1_Amount ,Dept2_Descr ,Dept2_Amount ,Dept3_Descr ,Dept3_Amount ,Dept4_Descr ,Dept4_Amount ,Dept5_Descr ,Dept5_Amount , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, tbPosSalesSummary.loca, Location.Loca_Descrip from tbPosSalesSummary inner join Location on tbPosSalesSummary.loca = Location.loca";
                //objRepView.DataSetName = "dsPosSalesSummary";
                //objRepView.RetrieveData();
                dsDataForReport = objSalesInquary.ResultSet;
                rptPosDayendunitwise PosSaleDet = new rptPosDayendunitwise();
                PosSaleDet.SetDataSource(dsDataForReport);
                PosSaleDet.SummaryInfo.ReportTitle = "Pos Sales Summary";
                objRepViewer.crystalReportViewer1.ReportSource = PosSaleDet;


                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Refresh();
                objRepViewer.Show();
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbLocaCode_SelectedIndexChanged");
            }
        }
    }
}
            
    

        

    
        

           
        
    
