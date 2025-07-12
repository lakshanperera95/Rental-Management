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

        public string PrintType { get; set; } = "";

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.mdi.Cursor = Cursors.Default;

                if (PrintType == "INV")
                {
                    clsWholeSaleInvoice ObjComm = new clsWholeSaleInvoice();
                    ObjComm.CheckedPasswordValid("SELECT * FROM dbo.tb_UserRoleSettings Us JOIN dbo.Employee E ON E.UserRole_Id=Us.UserRoleID WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='" + LoginManager.LocaCode + "' AND Us.BillReprint=1");
                    if (ObjComm.AccessStatus == false)
                    {
                        crystalReportViewer1.ShowPrintButton = false;
                    }
                }
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
                        clsWholeSaleInvoice ObjComm = new clsWholeSaleInvoice();
                        ObjComm.CheckedPasswordValid("SELECT * FROM dbo.tb_UserRoleSettings Us JOIN dbo.Employee E ON E.UserRole_Id=Us.UserRoleID WHERE E.Emp_Name='" + LoginManager.UserName + "' AND E.Loca='" + LoginManager.LocaCode + "' AND Us.BillReprint=1");
                        if (ObjComm.AccessStatus == false)
                        {
                            MessageBox.Show("Access Denied  to RePrint Invoices", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;                           
                        }

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
        frmTransactionInquary objTransactionInq = new frmTransactionInquary();
        frmSalesInquary objSalesInq = new frmSalesInquary();
        private void crystalReportViewer1_DoubleClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            try
            {
                string strDocNo = e.ObjectInfo.Text;
                frmReportViewer objRepViewr = new frmReportViewer();
                clsReportViewer objRepView = new clsReportViewer();
                DataSet dsDataForReport = new DataSet();

                //--------------- Purchase Order Note -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "' AND Iid='PON' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 201;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                  //  objTransactionInq.GetIid = "PON";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                //--------------- Good Received Note -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "' AND Iid='GRN' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 202;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                  //  objTransactionInq.GetIid = "GRN";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                //--------------- Purchase Return Note -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "' AND Iid='SRN' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 216;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                    objTransactionInq.btnApply_Click(sender, e);
                }
                //--------------- Good Transfer  Note -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "' AND Iid='TGN' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 204;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                  //  objTransactionInq.GetIid = "TGN";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                 
                //--------------- Whole Sale Invoice -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "'   AND Iid = 'INV' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 200;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                 //   objTransactionInq.GetIid = "INV";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                
                //--------------- Quotation -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "' AND Iid = 'QUO' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 227;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
               //     objTransactionInq.GetIid = "QUO";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                 
                //--------------- Supplier Payment Details -----------
                objRepView.SqlStatement = "SELECT tbPaidPaymentSummary.Org_Doc_no FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE Org_Doc_no='" + strDocNo + "' AND Iid = 'PMT' AND  Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 205;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                 //   objTransactionInq.GetIid = "PMT";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                //--------------- Supplier Payment Set Off Note -----------
                objRepView.SqlStatement = "SELECT Org_Doc_no FROM tbPaidPaymentDetails WHERE Org_Doc_no='" + strDocNo + "' AND Iid = 'REC' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 206;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                    //   objTransactionInq.GetIid = "SOP";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                //--------------- Supplier Payment Set Off Note -----------
                objRepView.SqlStatement = "SELECT Org_Doc_no FROM tbPaidPaymentDetails WHERE Org_Doc_no='" + strDocNo + "' AND Iid = 'SOP' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 221;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                 //   objTransactionInq.GetIid = "SOP";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                //--------------- Customer Invoice Set Off Note -----------
                objRepView.SqlStatement = "SELECT Org_Doc_no FROM tbPaidPaymentDetails WHERE Doc_No='" + strDocNo + "' AND Iid = 'SOR' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 224;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                 //   objTransactionInq.GetIid = "SOR";
                    objTransactionInq.btnApply_Click(sender, e);
                }

                //--------------- Stock Adjustment Details -----------
                objRepView.SqlStatement = "SELECT Doc_No FROM Transaction_Header WHERE Doc_No='" + strDocNo + "' AND Iid = 'STA' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 203;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                  //  objTransactionInq.GetIid = "Transaction_Header";
                    objTransactionInq.btnApply_Click(sender, e);
                }
                 
                //--------------- Product Bincaed -----------
                objRepView.SqlStatement = "SELECT Prod_Code FROM Product WHERE Prod_Code='" + strDocNo + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objSalesInq.intRepOption = 404;
                    objSalesInq.txtCodeFrom.Text = strDocNo;
                    objSalesInq.btnDisplay_Click(sender, e);
                }

                
                //--------------- Customer Invoice Set Off Note -----------
                objRepView.SqlStatement = "SELECT Org_Doc_no FROM tbPaidPaymentDetails WHERE Org_Doc_no='" + strDocNo + "' AND Iid = 'SOR' AND Loca='" + LoginManager.LocaCode + "'";
                objRepView.ReadTempDetails();
                if (objRepView.RecordFound)
                {
                    objTransactionInq.intRepOption = 224;
                    objTransactionInq.txtCodeFrom.Text = strDocNo;
                //    objTransactionInq.GetIid = "SOR";
                    objTransactionInq.btnApply_Click(sender, e);
                }

               

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmReportViewer 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}