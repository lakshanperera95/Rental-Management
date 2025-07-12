using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using CrystalDecisions.Shared;
using System.IO.Ports;
using Inventory.Properties;

namespace Inventory
{
    public partial class FrmPrinterSelect : Form
    {

        clsCommon objCommon = new clsCommon();
        string PosPrinter, DocumentPrinter, PosCustomPaper, DocCustomPaper;
        int PosPrintCount, DocPrintCount;
        public string IID;
        public bool Print=false;
        public DataSet dsForRep, dsForRep2;
        public string InvPrintType = "";
        public bool VatBill = false;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument PrintingRpt= new CrystalDecisions.CrystalReports.Engine.ReportDocument();



        public FrmPrinterSelect()
        {
            InitializeComponent();
        }

        private void FrmPrinterSelect_Load(object sender, EventArgs e)
        {
            try
            {
                bool DefaultNor = false, DefaultPos =false;
                string qry = "SELECT PrinterName, CustomPaper, PrintCount,Defaultp FROM tb_PrinterDetails WHERE PosPrinter = 1 AND MachineName='" + System.Environment.MachineName + "' ";
                objCommon.getDataSet(qry, "dsPrinter");
                PosPrinter = objCommon.Ads.Tables["dsPrinter"].Rows[0]["PrinterName"].ToString();
                PosCustomPaper = objCommon.Ads.Tables["dsPrinter"].Rows[0]["CustomPaper"].ToString();
                PosPrintCount = int.Parse(objCommon.Ads.Tables["dsPrinter"].Rows[0]["PrintCount"].ToString());
                DefaultPos = bool.Parse(objCommon.Ads.Tables["dsPrinter"].Rows[0]["Defaultp"].ToString());

                qry = "SELECT PrinterName, CustomPaper, PrintCount,Defaultp FROM tb_PrinterDetails WHERE PosPrinter = 0 AND MachineName='" + System.Environment.MachineName + "' ";
                objCommon.getDataSet(qry, "dsPrinter");
                DocumentPrinter = objCommon.Ads.Tables["dsPrinter"].Rows[0]["PrinterName"].ToString();
                DocCustomPaper = objCommon.Ads.Tables["dsPrinter"].Rows[0]["CustomPaper"].ToString();
                DocPrintCount = int.Parse(objCommon.Ads.Tables["dsPrinter"].Rows[0]["PrintCount"].ToString());
                DefaultNor = bool.Parse(objCommon.Ads.Tables["dsPrinter"].Rows[0]["Defaultp"].ToString());

                if (DefaultNor == true && DefaultPos == true)
                {

                }
                else
                {
                    if (DefaultPos == true)
                    {
                        pnlPos_Click(new object(), e);
                    }
                    if (DefaultNor == true)
                    {
                        pnlDoc_Click(new object(), e);
                    }
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        } 

        private void FrmPrinterSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                //PrintingRpt.Close();
               // PrintingRpt.Dispose();
               // PrintingRpt = null;
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
           
        }

        private void FrmPrinterSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                pnlPos_Click(new object(), new EventArgs());
            }
            else if (e.KeyCode==Keys.Right)
            {
                pnlDoc_Click(new object(), new EventArgs());
            }
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnDocumentPrint_Click(object sender, EventArgs e)
        {
            
        }

        

        private void pnlPos_Click(object sender, EventArgs e)
        {
            try
            {
                if (IID == "INV")
                {
                    if(Settings.Default.InvMultiLan==false)
                    {
                        InvPrintType = "English";
                    }
                    if (InvPrintType == "English")
                    {
                        PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_Pos.rpt");
                    }
                    else
                    {
                        PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_PosSin.rpt");
                    }
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else if (IID == "CUR")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCustomerReturnDetails_Pos.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else if (IID == "REC")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCustomerPayment_Pos.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                    PrintingRpt.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsForRep2);
                }
                else if (IID == "CAR")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCashRefundDetails_Pos.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else if (IID == "CDM")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCashDenoDetails_Pos.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else   if (IID == "ADV")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptAdvanceReport_Pos.rpt");
                    PrintingRpt.SummaryInfo.ReportTitle =ReportTitle;
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else
                {
                    return;
                }

                if (Print)
                {   
                    MainClass.mdi.CustomPaperPrint(PrintingRpt, PosPrinter, PosCustomPaper, PosPrintCount);
                this.Close();
                }
                else
                {
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.PrintType = IID;
                    objRepViewer.crystalReportViewer1.ReportSource = PrintingRpt;
                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();
                    this.Close();
                }
               
            
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public string ReportTitle { get; set; }

        private void pnlDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (IID == "INV")
                {
                    if (Settings.Default.InvMultiLan == false)
                    {
                        InvPrintType = "English";
                    }
                    if (VatBill == false)
                    {
                        if (InvPrintType == "English")
                        {
                            PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_NonTax.rpt");
                        }
                        else
                        {
                            PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_NonTaxSin.rpt");
                        }
                    }
                    else
                    {
                        if (InvPrintType == "English")
                        {
                            PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_Tax.rpt");
                        }
                        else
                        {
                            PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_TaxSin.rpt");
                        }
                       
                    }

                  //  PrintingRpt.Load(@"..\DirectReports\rptInvoiceDetails_NonTax.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
        
                    
                }
                else if (IID == "CUR")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCustomerReturnDetails.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                    PrintingRpt.OpenSubreport("rptTransactionTaxes.rpt").SetDataSource(dsForRep.Tables[2]);
                }
                else if (IID == "REC")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCustomerPayment.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                    PrintingRpt.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsForRep2);
                }
                else if (IID == "CAR")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCashRefundDetails.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else if (IID == "CDM")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptCashDenoDetails.rpt");
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else if (IID == "ADV")
                {
                    PrintingRpt.Load(@"..\DirectReports\rptAdvanceReport.rpt");
                    PrintingRpt.SummaryInfo.ReportTitle = ReportTitle;
                    PrintingRpt.SetDataSource(dsForRep);
                }
                else
                {
                    return;
                }
                if (Print)
                {
                    MainClass.mdi.CustomPaperPrint(PrintingRpt, DocumentPrinter, DocCustomPaper, DocPrintCount);
                    this.Close();
                }
                else
                {
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.PrintType = IID;
                    objRepViewer.crystalReportViewer1.ReportSource = PrintingRpt;
                    objRepViewer.WindowState = FormWindowState.Maximized;
                    objRepViewer.Show();
                    this.Close();
                }
             
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlDoc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
     
    }
}