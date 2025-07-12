using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using clsLibrary;

namespace Inventory
{
    public partial class frmPrinterSettings : Form
    {
        public frmPrinterSettings()
        {
            InitializeComponent();
        }

        

        private static frmPrinterSettings Obj_PrinterSettings;
        public static frmPrinterSettings _Obj_PrinterSettings
        {
            get { return Obj_PrinterSettings; }
            set { Obj_PrinterSettings = value; }
        }

        private void Bill_Frm_PrinterSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Obj_PrinterSettings = null;
            }
            catch (Exception ex)
            {
                
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            cmbInstalledDocPrinterList.Items.Clear();
            cmbInstalledPosPrinterList.Items.Clear();
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmbInstalledDocPrinterList.Items.Add(pkInstalledPrinters);
                cmbInstalledPosPrinterList.Items.Add(pkInstalledPrinters);
            }
        }

        private void Bill_Frm_PrinterSettings_Load(object sender, EventArgs e)
        {
            try
            {
                if (LoginManager.UserName.ToUpper() != "ONIMTA")
                {
                    btnApply.Enabled = false;
                }
               
                lblMachineName.Text = System.Environment.MachineName;
                PopulateInstalledPrintersCombo();

                clsPrinterSettings obj_Cls_PrinterSettings = new clsPrinterSettings();

                obj_Cls_PrinterSettings.getRecPrinterDetails();

                if (cmbInstalledDocPrinterList.Items.Contains(obj_Cls_PrinterSettings._strRecPrinterName))
                {
                    cmbInstalledDocPrinterList.Text = obj_Cls_PrinterSettings._strRecPrinterName;
                }

                txtCustomPaperName.Text = obj_Cls_PrinterSettings._strRecPrinterCustomPaper;
                nudDocPrinterPrintCount.Value = obj_Cls_PrinterSettings._intRecPrintCount;
                

                obj_Cls_PrinterSettings.getPosPrinterDetails();

                if (cmbInstalledPosPrinterList.Items.Contains(obj_Cls_PrinterSettings._strPosPrinterName))
                {
                    cmbInstalledPosPrinterList.Text = obj_Cls_PrinterSettings._strPosPrinterName;
                }
                nudPosPrinterPrintCount.Value = obj_Cls_PrinterSettings._intPosPrintCount;

                if (obj_Cls_PrinterSettings.Pos == true && obj_Cls_PrinterSettings.Rec == true)
                {
                    rbDual.Checked = true;
                }
                else
                {
                    rbPos.Checked = obj_Cls_PrinterSettings.Pos;
                    rbRec.Checked = obj_Cls_PrinterSettings.Rec;
                }

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
                if (MessageBox.Show("Do You Want To Save The Printer Settings For This Machine?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (nudDocPrinterPrintCount.Value<1 || nudPosPrinterPrintCount.Value<1)
                    {
                        MessageBox.Show("Print Count Must Be Greater Than 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (nudDocPrinterPrintCount.Value > 10 || nudPosPrinterPrintCount.Value > 10)
                    {
                        MessageBox.Show("Print Count Must Be Less Than 10", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    clsPrinterSettings obj_Cls_PrinterSettings = new clsPrinterSettings();
                    obj_Cls_PrinterSettings._strRecPrinterName = cmbInstalledDocPrinterList.Text.Trim();
                    obj_Cls_PrinterSettings._strRecPrinterCustomPaper = txtCustomPaperName.Text.Trim();
                    obj_Cls_PrinterSettings._intRecPrintCount = (int)nudDocPrinterPrintCount.Value;

                    obj_Cls_PrinterSettings._strPosPrinterName = cmbInstalledPosPrinterList.Text.Trim();
                    obj_Cls_PrinterSettings._intPosPrintCount = (int)nudPosPrinterPrintCount.Value;

                    bool Pos = rbPos.Checked;
                    bool REC = rbRec.Checked;
                    if (rbDual.Checked)
                    {
                       Pos=REC = true;
                    }


                    obj_Cls_PrinterSettings.ApplyPrinterSettings(Pos,REC);

                    MessageBox.Show(obj_Cls_PrinterSettings._Messg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void rbRec_CheckedChanged(object sender, EventArgs e)
        {
         
        }

    }
}