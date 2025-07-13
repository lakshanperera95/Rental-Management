using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.IO;
using clsLibrary;

namespace Inventory
{
    public partial class frmChequePrint : Form
    {
        public frmChequePrint()
        {
            InitializeComponent();

            try
            {
                dt = common.getChequePrint_Settings();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        Control Con = pnlCheque.Controls.Find(Row["FieldName"].ToString(), true)[0];
                        Con.Location = new Point(int.Parse(Row["x"].ToString()), int.Parse(Row["y"].ToString()));
                    }
                }

                dtNameProfile = common.getChequePrint_NameProfiles();
                cmbNameProfile.DataSource = null;
                cmbNameProfile.DataSource = dtNameProfile;
                cmbNameProfile.DisplayMember = "CompanyType";
                cmbNameProfile.ValueMember = "CompanyName";
                cmbNameProfile.Refresh();

                if (LoginManager.DupliCheqPrint == "T")
                {
                    btnLoadPrintedCheqDetails.Visible = true;
                    dtpDate.Enabled = true;
                    txtAmount.Enabled = true;
                    txtPay.Enabled = true;
                }
                else
                {
                    btnLoadPrintedCheqDetails.Visible = false;
                    dtpDate.Enabled = false;
                    txtAmount.Enabled = false;
                    txtPay.Enabled = false;
                }

                if (LoginManager.CheqPrSettings == "T")
                {
                    //cmbField.Enabled = true;
                    cmbNameProfile.Enabled = true;
                    chkHide.Enabled = true;
                    txtX.Enabled = true;
                    txtY.Enabled = true;
                    txtPageX.Enabled = true;
                    txtPageY.Enabled = true;
                    btnSaveBankFormat.Enabled = true;
                    btnDefault.Enabled = true;
                }
                else
                {
                    //cmbField.Enabled = false;
                    cmbNameProfile.Enabled = false;
                    chkHide.Enabled = false;
                    txtX.Enabled = false;
                    txtY.Enabled = false;
                    txtPageX.Enabled = false;
                    txtPageY.Enabled = false;
                    btnSaveBankFormat.Enabled = false;
                    btnDefault.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            

        }

        private DataSet dsBankName;
        private frmSearch search = new frmSearch();

        private static frmChequePrint objCP;
        public static frmChequePrint _objCP
        {
            get { return objCP; }
            set { objCP = value; }
        }

        clsChequePrint common = new clsChequePrint();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dtNameProfile = new DataTable();
        public int PageXX = 0;
        public int PageYY = 0;

        

        public void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDocNo.Text!="" && lblCheqDate.Text.Trim() != "" && lblCheqNo.Text.Trim() != "" && lblBank.Text.Trim() != "")
                {
                    if (MessageBox.Show("You Are Going To Print The Cheque No ''" + lblCheqNo.Text.Trim() + "'' . Do you Want To Continue ?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        int PreCount = common.getChequePrint_Count(lblDocNo.Text, lblCheqNo.Text.Trim());
                        if (PreCount > 0)
                        {
                            if (LoginManager.DupliCheqPrint=="T")
                            {
                                if (MessageBox.Show("Cheque No ''" + lblCheqNo.Text.Trim() + "'' Has Been Printed " + PreCount + " Times. Do You Want To Continue?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cheque No ''" + lblCheqNo.Text.Trim() + "'' Has Been Printed " + PreCount + " Times. Need Permission To Continue?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                return;
                            }
                        }
                        
                        printDocument1.DefaultPageSettings.Landscape = true;
                        printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        //printDocument1.DefaultPageSettings.PaperSize = new PaperSize("XXX", 380, 725);
                        printDocument1.Print();

                        common.ChequePrint_Apply(lblDocNo.Text.Trim(), "PMT", cmbBankName.SelectedValue.ToString(), lblCheqNo.Text.Trim(), common.SuppCode);

                        btnClear.PerformClick();
                        txtSuppCode.Text = txtSuppName.Text = "";
                        dataGridViewPendingPayments.DataSource = null;

                    }
                }
                else
                {
                    PrintPreviewDialog previewdlg = new PrintPreviewDialog();
                    printDocument1.DefaultPageSettings.Landscape = true;
                    printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                    //printDocument1.DefaultPageSettings.PaperSize = new PaperSize("XXX", 380, 725);
                    previewdlg.Document = printDocument1;
                    ((Form)previewdlg).WindowState = FormWindowState.Maximized;

                    previewdlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            /*
            //Rectangle pagearea = e.PageBounds;
            //e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (panel1.Width / 2), panel1.Location.Y);

            
            Bitmap bmp = new Bitmap(pnlCheque.Width, pnlCheque.Height, pnlCheque.CreateGraphics());
            pnlCheque.DrawToBitmap(bmp, new Rectangle(0, 0, pnlCheque.Width, pnlCheque.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            //e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            e.Graphics.DrawImage(bmp, 0, 0);
             */

            Rectangle pagearea = e.PageBounds;

            if (chkPayeeOnly.Checked)
            {
                
                PictureBox pict = (PictureBox)lblImgPO;
                pict.SizeMode = PictureBoxSizeMode.Zoom;
                Bitmap bm = new Bitmap(pict.ClientSize.Width, pict.ClientSize.Height);
                pict.DrawToBitmap(bm, pict.ClientRectangle);
                //pict.Location = new Point(pictureBox1.Location.X + PageXX, pictureBox1.Location.Y + PageYY);
                e.Graphics.DrawImage(bm, pict.Bounds.X + PageXX, pict.Bounds.Y + PageYY, pict.Bounds.Width, pict.Bounds.Height);

                //e.Graphics.ResetTransform();
                //e.Graphics.DrawLine(new Pen(Brushes.Black), 0 + PageXX, 75 + PageYY, 75 + PageXX, 0 + PageYY);
                //e.Graphics.ResetTransform();
                //e.Graphics.DrawLine(new Pen(Brushes.Black), 0 + PageXX, 110 + PageYY, 110 + PageXX, 0 + PageYY);

            }

            

            foreach (Control c in pnlCheque.Controls)
            {
                if (c.Visible == true)
                {

                    if (c is Label)
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        // Draw the text and the surrounding rectangle.

                        Rectangle r = new Rectangle(c.Location.X + PageXX, c.Location.Y + PageYY, c.Width, c.Height);

                        if (c.Name == "lblAmountValue")
                        {
                            e.Graphics.DrawString(c.Text, c.Font, Brushes.Black, r, stringFormat);
                        }
                        else if (c.Name == "lblAmountText")
                        {

                            string txt = c.Text;
                            SizeF fit = new SizeF(75F, 75);
                            StringFormat fmt = StringFormat.GenericTypographic;
                            int spacing = (int)(2.0 * c.Font.Height);
                            int line = 0;
                            for (int ix = 0; ix < txt.Length; )
                            {
                                int chars, lines;
                                e.Graphics.MeasureString(txt.Substring(ix), c.Font, fit, fmt, out chars, out lines);
                                //e.Graphics.MeasureString(txt.Substring(ix), c.Font, fit,
                                //e.Graphics.DrawString(txt.Substring(ix, chars), c.Font, Brushes.Black, 0, spacing * line);
                                e.Graphics.DrawString(txt.Substring(ix, chars), c.Font, Brushes.Black, new RectangleF(c.Location.X + PageXX, c.Location.Y + PageYY + (spacing * line), c.Width + 50, c.Height));
                                ++line;
                                ix += chars;
                            }

                        }
                        else if (c.Name == "lblCompanyName")
                        {
                            return;//This label Printed in Below Panel Section
                        }
                        else
                        {
                            e.Graphics.DrawString(c.Text, c.Font, Brushes.Black, new RectangleF(c.Location.X + PageXX, c.Location.Y + PageYY, c.Width, c.Height));
                        }

                    }
                    if (c is Panel)
                    {
                        
                        Bitmap bm2 = new Bitmap(c.ClientSize.Width, c.ClientSize.Height);
                        c.DrawToBitmap(bm2, c.ClientRectangle);
                        e.Graphics.DrawImage(bm2, c.Bounds.X + PageXX, c.Bounds.Y + PageYY, c.Bounds.Width, c.Bounds.Height);
                        bm2.Save(@"C:\TestDrawToBitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                        //foreach (Control b in c.Controls)
                        //{
                        //    if (b is Label)
                        //    {
                        //        e.Graphics.DrawString(c.Text, c.Font, Brushes.Black, new RectangleF(c.Location.X + PageXX, c.Location.Y + PageYY, c.Width, c.Height));
                        //    }
                        //    if (b is PictureBox && b.Name == "lblImgHolder")
                        //    {
                        //        PictureBox pict2 = (PictureBox)lblImgHolder;
                        //        pict2.SizeMode = PictureBoxSizeMode.Zoom;
                        //        Bitmap bm2 = new Bitmap(pict2.ClientSize.Width, pict2.ClientSize.Height);
                        //        pict2.DrawToBitmap(bm2, pict2.ClientRectangle);
                        //        e.Graphics.DrawImage(bm2, pict2.Bounds.X + PageXX, pict2.Bounds.Y + PageYY, pict2.Bounds.Width, pict2.Bounds.Height);
                        //    }
                        //}
                    }
                }
            }

            


           
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                common.GetBankDetails();
                dsBankName = common.BankName;
                cmbBankName.DataSource = dsBankName.Tables["BankDetails"];
                cmbBankName.DisplayMember = "Bank_Name";
                cmbBankName.ValueMember = "Bank_Code";

                
               
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            
        }

        public string NumberToWords(int number)
        {

            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 100000000) > 0)
            {
                words += NumberToWords(number / 100000000) + " billion ";
                number %= 100000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "";
                string[] unitsMap =  { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                string[] tensMap = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words.ToLower());

        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbField.Text.Trim() != "")
                {
                    Control c = pnlCheque.Controls.Find("lbl" + cmbField.Text.Trim(), true)[0];
                    
                    txtX.Value = c.Location.X;
                    txtY.Value = c.Location.Y;
                    if (c.Name!="lblImgPO")
                    {
                        c.BringToFront();
                        chkHide.Checked = !c.Visible;
                    }

                    if (c.Name == "lblHolderSeal")
                    {
                        cmbNameProfile_SelectedIndexChanged(new object(), new EventArgs());
                    }
                    
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtX_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbField.Text.Trim() != "")
                {
                    Control c = pnlCheque.Controls.Find("lbl" + cmbField.Text, true)[0];
                    c.Location = new Point(Convert.ToInt16(txtX.Value), c.Location.Y);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtY_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbField.Text.Trim() != "")
                {
                    Control c = pnlCheque.Controls.Find("lbl" + cmbField.Text, true)[0];
                    c.Location = new Point(c.Location.X, Convert.ToInt16(txtY.Value));
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankName.SelectedValue == null || cmbBankName.SelectedValue.ToString() == "" || cmbBankName.Text == "")
                {
                    MessageBox.Show("Bank Not Selected !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBankName.Focus();
                    btnClear.PerformClick();
                }

                dt3 = common.getChequePrint_BankSettings(cmbBankName.SelectedValue.ToString());
                if (dt3 != null && dt3.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt3.Rows)
                    {
                        Control Con = pnlCheque.Controls.Find(Row["FieldName"].ToString(), true)[0];
                        if (Con is Label || Con is Panel)
                        {
                            //if (Con.Name == "lblHolderSeal")
                            //{

                            //}
                            Con.Location = new Point(int.Parse(Row["x"].ToString()), int.Parse(Row["y"].ToString()));
                            Con.Visible = !Convert.ToBoolean(Row["Hide"].ToString());
                        }
                    }

                    cmbNameProfile.Text = dt3.Rows[0]["SealFormat"].ToString();
                    txtPageX.Value = int.Parse(dt3.Rows[0]["PageX"].ToString());
                    txtPageY.Value = int.Parse(dt3.Rows[0]["PageY"].ToString());


                    char[] d = dtpDate.Value.ToShortDateString().ToCharArray();
                    lblD1.Text = d[0].ToString();
                    lblD2.Text = d[1].ToString();
                    lblM1.Text = d[3].ToString();
                    lblM2.Text = d[4].ToString();
                    lblY1.Text = d[6].ToString();
                    lblY2.Text = d[7].ToString();
                    lblY3.Text = d[8].ToString();
                    lblY4.Text = d[9].ToString();

                    lblAmountValue.Text = "**" + Convert.ToDecimal(txtAmount.Text.Trim()).ToString("N2") + "**";

                    //Convert Amount to text
                    //decimal value = Convert.ToDecimal(Convert.ToDecimal(txtAmount.Text.Trim()).ToString("N2"));
                    //string[] values = value.ToString(CultureInfo.InvariantCulture).Split('.');

                    string[] values = Convert.ToDecimal(txtAmount.Text.Trim()).ToString("N2").Split('.');
                    int First = Convert.ToInt32(Convert.ToDecimal(values[0]));
                    int second = Convert.ToInt16(values[1]);
                    string paymentword1 = "";
                    string paymentword2 = "";
                    string paymentword = "";
                    if (First != 0)
                    {
                        paymentword1 = NumberToWords(Convert.ToInt32(First));
                    }
                    if (second != 0)
                    {
                        paymentword2 = NumberToWords(Convert.ToInt32(second.ToString("00").Substring(0, 2)));
                    }
                    if (second != 0)
                    {
                        paymentword = paymentword1 + " Rupees And " + paymentword2 + " Cents Only";
                    }
                    else
                    {
                        paymentword = paymentword1 + " Rupees Only";
                    }

                    lblAmountText.Text = "**" + paymentword + "**";

                    if (txtPay.Text.Trim()=="")
                    {
                        lblPay.Text = "";
                    }
                    else
                    {
                        lblPay.Text = "**" + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtPay.Text.Trim().ToLower()) + "**";
                        //lblPay.Text = "**" + txtPay.Text.Trim() + "**";

                    }
                    
                }
                else
                {
                    MessageBox.Show("No Format Found For Selected Bank !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBankName.Focus();
                    btnClear.PerformClick();
                }

            }
            catch (Exception ex)
            {
                btnClear.PerformClick();
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmChequePrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                objCP = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void chkPayeeOnly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkPayeeOnly.Checked)
                {
                    lblImgPO.Visible = true;
                }
                else
                {
                    lblImgPO.Visible = false;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Load Default Positions ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    dt2=common.getChequePrint_DefaultSettings();
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        foreach (DataRow Row in dt2.Rows)
                        {
                            Control Con = pnlCheque.Controls.Find(Row["FieldName"].ToString(), true)[0];
                            Con.Location = new Point(int.Parse(Row["x"].ToString()), int.Parse(Row["y"].ToString()));
                            Con.Visible = !Convert.ToBoolean(Row["Hide"].ToString());
                        }

                        txtPageX.Value = int.Parse(dt2.Rows[0]["PageX"].ToString());
                        txtPageY.Value = int.Parse(dt2.Rows[0]["PageY"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() == string.Empty)
                {
                    common.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        common.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code ASC";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            common.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                        }
                        else
                        {
                            common.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                        }
                    }
                }
                common.DataSetName = "dsSupplier";
                common.GetSupplierDetails();
                search.dgSearch.DataSource = common.GetSupplierDataSet.Tables["dsSupplier"];
                search.prop_Focus = txtSuppCode;
                search.Cont_Descript = txtSuppName;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtSuppCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtSuppCode.Text = search.Code.Trim();
                    txtSuppName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtSuppCode.Text!="")
                {
                    if (e.KeyCode==Keys.Enter)
                    {
                        common.SuppCode = txtSuppCode.Text.ToString().Trim();
                        common.SqlStatement = "SELECT Supp_Code, Supp_Name, Supp_Name PrintName FROM Supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                        common.ReadSupplierDetails();
                        if (common.RecordFound == true)
                        {
                            txtSuppCode.Text = common.SuppCode;
                            txtSuppName.Text = common.SuppName;

                            dataGridViewPendingPayments.DataSource = null;
                            dataGridViewPendingPayments.DataSource = common.Get_Pending_ChequePrintList("PMT", common.SuppCode);
                            dataGridViewPendingPayments.Refresh();
                        }

                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dataGridViewPendingPayments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPendingPayments.SelectedRows.Count == 1 && dataGridViewPendingPayments.SelectedRows[0].Cells[0].ToString() != "")
                {
                    if (MessageBox.Show("Do You Want To Load The Selected Document?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        lblDocNo.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[0].Value.ToString();
                        lblBank.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[1].Value.ToString();
                        lblCheqNo.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[2].Value.ToString();
                        lblCheqDate.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[3].Value.ToString();
                        lblCheqAmt.Text = dataGridViewPendingPayments.SelectedRows[0].Cells[4].Value.ToString();
                        dtpDate.Text = lblCheqDate.Text;
                        txtAmount.Text = decimal.Parse(lblCheqAmt.Text).ToString("N2");
                        if (common._strPrintName.ToString() == "")
                        {
                            txtPay.Text = common.SuppName;
                        }
                        else
                        {
                            txtPay.Text = common._strPrintName;
                        }
                        cmbBankName.Text = lblBank.Text;

                        cmbBankName.Enabled = false;
                        txtAmount.ReadOnly = true;
                        dtpDate.Enabled = false;

                        btnLoad.PerformClick();


                    }
                }
                else
                {
                    MessageBox.Show("Please Select Data Row", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnSaveBankFormat_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Save Current Format To Selected Bank ? Previous Settings Will Be Deleted !", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (cmbBankName.SelectedValue != null && cmbBankName.SelectedValue.ToString()!="" && cmbBankName.Text!="")
                    {

                        string BankCode=cmbBankName.SelectedValue.ToString();
                        foreach (Control CON in pnlCheque.Controls)
                        {
                            common.UpdateChequePrint_Settings(CON.Location.X, CON.Location.Y, CON.Name, BankCode, Convert.ToInt16(txtPageX.Value), Convert.ToInt16(txtPageY.Value), Convert.ToInt16(!CON.Visible), cmbNameProfile.Text.Trim());
                        }
                        MessageBox.Show("Bank Format Saved Succussfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Bank Not Selected !",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbBankName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                frmChequePrint objCPForValues = new frmChequePrint();
                lblD1.Text = objCPForValues.lblD1.Text;
                lblD2.Text = objCPForValues.lblD2.Text;
                lblM1.Text = objCPForValues.lblM1.Text;
                lblM2.Text = objCPForValues.lblM2.Text;
                lblY1.Text = objCPForValues.lblY1.Text;
                lblY2.Text = objCPForValues.lblY2.Text;
                lblY3.Text = objCPForValues.lblY3.Text;
                lblY4.Text = objCPForValues.lblY4.Text;
                lblPay.Text = objCPForValues.lblPay.Text;
                lblAmountText.Text = objCPForValues.lblAmountText.Text;
                lblAmountValue.Text = objCPForValues.lblAmountValue.Text;
                objCPForValues = null;

                lblDocNo.Text = lblBank.Text = lblCheqNo.Text = lblCheqDate.Text = lblCheqAmt.Text = "";

                txtPay.Text = txtAmount.Text = "";

                txtPageY.Value = txtPageX.Value= 0;

                dtpDate.Text = DateTime.Today.ToShortDateString();

                cmbBankName.Enabled = true;
                txtAmount.ReadOnly = false;
                dtpDate.Enabled = true;

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmChequePrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Exit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnLoadPrintedCheqDetails_Click(object sender, EventArgs e)
        {
            try
            {
                common.SuppCode = txtSuppCode.Text.ToString().Trim();
                common.SqlStatement = "SELECT Supp_Code, Supp_Name, Supp_Name PrintName FROM Supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                common.ReadSupplierDetails();
                if (common.RecordFound == true)
                {
                    txtSuppCode.Text = common.SuppCode;
                    txtSuppName.Text = common.SuppName;

                    if (LoginManager.DupliCheqPrint == "T")
                    {
                        if (MessageBox.Show("Do You Want To Load The Printed Cheques?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dataGridViewPendingPayments.DataSource = null;
                            dataGridViewPendingPayments.DataSource = common.Get_Printed_ChequePrintList("PMT", common.SuppCode);
                            dataGridViewPendingPayments.Refresh();
                        }
                    }
                    



                }
                else
                {
                    MessageBox.Show("Please Select Supplier First !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtPageX_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                PageXX = Convert.ToInt16(txtPageX.Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtPageY_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                PageYY = Convert.ToInt16(txtPageY.Value);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void chkShowHide_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbField.Text.Trim() != "")
                {
                    Control c = pnlCheque.Controls.Find("lbl" + cmbField.Text, true)[0];
                    if (chkHide.Checked)
                    {
                        if (c.Name != "lblImgPO")
                        {
                            c.Visible = false;
                        }
                    }
                    else
                    {
                        if (c.Name != "lblImgPO")
                        {
                            c.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        

        private void cmbNameProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbNameProfile.Visible == true)
                {


                    if (cmbNameProfile.DataSource != null)
                    {
                        string ImageFile = Application.StartupPath + @"\Cheque Print\" + cmbNameProfile.Text.ToString() + ".png ";
                        if (File.Exists(ImageFile))
                        {
                            lblImgHolder.Image = Image.FromFile(ImageFile);
                            lblCompanyName.Text = cmbNameProfile.SelectedValue.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Profile Not Found!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}