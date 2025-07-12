using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using System.Drawing.Printing;

namespace Inventory
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }
        public CrystalDecisions.CrystalReports.Engine.ReportDocument verReport;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument verReport2;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument VirtuaReport;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument OtherReport;

        public CrystalDecisions.CrystalReports.Engine.ReportDocument DirectPrintVerRep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.mdi.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            //this.Text=frmSalesInquary.GetSalesInquary.Text;
        }

        private void frmReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void crystalReportViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        crystalReportViewer1.PrintReport();
                        VirtuaReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmReportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.P)
                    {
                        if (crystalReportViewer1.ReportSource==null)
                        {
                            return;
                        }

                        if (MessageBox.Show("Do you want to print the report?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Onimta Set Paper size INV.................. 
                            PrintDocument printDoc = new PrintDocument();
                            System.Drawing.Printing.PaperSize pkSize = new System.Drawing.Printing.PaperSize();

                            int rawKind = 0;
                            if (MDI.InvPaperType == 0)
                            {
                                for (int a = 0; a < printDoc.PrinterSettings.PaperSizes.Count; a++)
                                {
                                    if (printDoc.PrinterSettings.PaperSizes[a].PaperName == "INV")
                                    {
                                        rawKind = (int)printDoc.PrinterSettings.PaperSizes[a].GetType().GetField("kind", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(printDoc.PrinterSettings.PaperSizes[a]);
                                        MDI.InvPaperType = rawKind;
                                    }
                                }
                            }
                            else
                            {
                                rawKind = MDI.InvPaperType;
                            }


                            PrinterSettings settings = new PrinterSettings();
                            if (VirtuaReport!=null)
                            {
                                VirtuaReport.PrintOptions.PrinterName = settings.PrinterName;
                                VirtuaReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                                //............................................

                                VirtuaReport.PrintToPrinter(1, false, 0, 0);
                                
                            }
                            else if (verReport!=null)
                            {
                                verReport.PrintOptions.PrinterName = settings.PrinterName;
                                verReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                                //............................................

                                verReport.PrintToPrinter(1, false, 0, 0);
                            }
                            else if (verReport2!=null)
                            {
                                verReport2.PrintOptions.PrinterName = settings.PrinterName;
                                verReport2.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                                //............................................

                                verReport2.PrintToPrinter(1, false, 0, 0);
                            }
                            else if (DirectPrintVerRep!=null)
                            {
                                DirectPrintVerRep.PrintOptions.PrinterName = settings.PrinterName;
                                DirectPrintVerRep.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                                //............................................

                                DirectPrintVerRep.PrintToPrinter(1, false, 0, 0);
                            }
                            else if (crystalReportViewer1.ReportSource != null)
                            {
                                OtherReport = (CrystalDecisions.CrystalReports.Engine.ReportDocument)crystalReportViewer1.ReportSource;
                                //OtherReport.PrintOptions.PrinterName = settings.PrinterName;
                                OtherReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;

                                //............................................

                                OtherReport.PrintToPrinter(1, false, 0, 0);
                               
                            }
                            

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
        }

        private void frmReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                crystalReportViewer1.Dispose();
                crystalReportViewer1 = null;

                if (verReport != null)
                {
                verReport.Close();
                verReport.Dispose();
                verReport = null;
                }
                if (verReport2 != null)
                {
                verReport2.Close();
                verReport2.Dispose();
                verReport2 = null;
                }
                if (OtherReport != null)
                {
                OtherReport.Close();
                OtherReport.Dispose();
                OtherReport = null;
                }
                if (VirtuaReport != null)
                {
                    VirtuaReport.Close();
                    VirtuaReport.Dispose();
                    VirtuaReport = null;
                }
                if (DirectPrintVerRep != null)
                {
                    DirectPrintVerRep.Close();
                    DirectPrintVerRep.Dispose();
                    DirectPrintVerRep = null;
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
        }
    }
}