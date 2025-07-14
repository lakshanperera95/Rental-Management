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

//using Onimta_AccClassLibrary;
using clsLibrary;

namespace Inventory
//namespace Onimta_Accounting
{
    public partial class frmChequePrint : Form
    {
        public frmChequePrint()
        {
            InitializeComponent();

            DataSet dsCPS = new DataSet();
            
            dsCPS = objChqPrint.getDataset("SELECT x, y, FieldName FROM tb_Settings_CheqPrint WHERE Standerd=0", "table1");
           
            if ( dt!=null && dt.Rows.Count>0)
            {
                foreach (DataRow Row in dt.Rows)
                {
                    Control Con = pnlCheque.Controls.Find(Row["FieldName"].ToString(), true)[0];
                    Con.Location = new Point(int.Parse(Row["x"].ToString()), int.Parse(Row["y"].ToString()));
                }
            }
        }

        private DataSet dsBankName;
       // private frmSearch search = new frmSearch();

        private static frmChequePrint objCP;
        public static frmChequePrint _objCP
        {
            get { return objCP; }
            set { objCP = value; }
        }

        clsCommon objChqPrint = new clsCommon();
        //clsChequePrint common = new clsChequePrint();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        public int PageXX = 0;
        public int PageYY = 0;

        

        public void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog previewdlg = new PrintPreviewDialog();
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                previewdlg.Document = printDocument1;
                ((Form)previewdlg).WindowState = FormWindowState.Maximized;

                
                //string SqlStatement = "DELETE FROM tb_Settings_CheqPrint WHERE Standerd=0;";
                //objChqPrint.ReadDetails(SqlStatement);

                //common.DeleteChequePrint_Settings();

                foreach (Control CON in pnlCheque.Controls)
                {
                    //string SqlStatement = "INSERT INTO tb_Settings_CheqPrint (x, y, FieldName, Standerd) VALUES (" + CON.Location.X + ", " + CON.Location.Y + ", '" + CON.Name + "', 0)";
                    //objChqPrint.ReadDetails(SqlStatement);

                    string SqlStatement = "DELETE FROM tb_Settings_CheqPrint WHERE FieldName='" + CON.Name + "' AND BankFormat='" + cmbBankName.Text.ToString() + "' AND Standerd=0";
                    objChqPrint.getDataReader(SqlStatement);

                    SqlStatement = " INSERT INTO tb_Settings_CheqPrint (x, y, FieldName, Standerd, BankFormat, PageX, PageY, Hide) VALUES (" + CON.Location.X + ", " + CON.Location.Y + ", '" + CON.Name + "', 0, '" + cmbBankName.Text.ToString() + "', " + Convert.ToInt16(txtPageX.Value) + ", " + Convert.ToInt16(txtPageY.Value) + ", " + Convert.ToInt16(!CON.Visible) + ")";
                    objChqPrint.getDataReader(SqlStatement);

                    //common.UpdateChequePrint_Settings(CON.Location.X, CON.Location.Y, CON.Name);
                }

                previewdlg.ShowDialog();
                btnPrint.Enabled = false;
                btnClear.PerformClick();
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
                PictureBox pict = (PictureBox)pictureBox1;
                pict.SizeMode = PictureBoxSizeMode.Zoom;
                Bitmap bm = new Bitmap(pict.ClientSize.Width, pict.ClientSize.Height);
                pict.DrawToBitmap(bm, pict.ClientRectangle);
                //pict.Location = new Point(pictureBox1.Location.X + PageXX, pictureBox1.Location.Y + PageYY);
                e.Graphics.DrawImage(bm, pict.Bounds.X + PageXX, pict.Bounds.Y + PageYY, pict.Bounds.Width, pict.Bounds.Height);

                e.Graphics.ResetTransform();
                e.Graphics.DrawLine(new Pen(Brushes.Black), 0 + PageXX, 75 + PageYY, 75 + PageXX, 0 + PageYY);
                e.Graphics.ResetTransform();
                e.Graphics.DrawLine(new Pen(Brushes.Black), 0 + PageXX, 110 + PageYY, 110 + PageXX, 0 + PageYY);
            }

            if (chkNormalCrossing.Checked)
            {
                e.Graphics.ResetTransform();
                e.Graphics.DrawLine(new Pen(Brushes.Black), 0 + PageXX, 75 + PageYY, 75 + PageXX, 0 + PageYY);
                e.Graphics.ResetTransform();
                e.Graphics.DrawLine(new Pen(Brushes.Black), 0 + PageXX, 110 + PageYY, 110 + PageXX, 0 + PageYY);
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
                            SizeF fit = new SizeF(75F, 125);
                            StringFormat fmt = StringFormat.GenericTypographic;
                            int spacing = (int)(1.8 * c.Font.Height);
                            int line = 0;
                            for (int ix = 0; ix < txt.Length; )
                            {
                                int chars, lines;
                                e.Graphics.MeasureString(txt.Substring(ix), c.Font, fit, fmt, out chars, out lines);
                                //e.Graphics.MeasureString(txt.Substring(ix), c.Font, fit,
                                //e.Graphics.DrawString(txt.Substring(ix, chars), c.Font, Brushes.Black, 0, spacing * line);
                                e.Graphics.DrawString(txt.Substring(ix, chars), c.Font, Brushes.Black, new RectangleF(c.Location.X + PageXX, c.Location.Y + PageYY + (spacing * line), c.Width + 100, c.Height));
                                ++line;
                                ix += chars;
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(c.Text, c.Font, Brushes.Black, new RectangleF(c.Location.X + PageXX, c.Location.Y + PageYY, c.Width, c.Height));
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                string SqlStatement = "SELECT * FROM BankDetails ORDER BY Bank_Code";
                objChqPrint.getDataReader(SqlStatement);
                while (objChqPrint.Adr.Read())
                {
                    cmbBankName.Items.Add(objChqPrint.Adr["Bank_Name"]).ToString();
                    cmbBankName.DisplayMember = "Bank_Name";
                    cmbBankName.ValueMember = "Bank_Code";
                }
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
                words += NumberToWords(number / 100) + " hundred and ";
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
                        words += " " + unitsMap[number % 10];
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
                    c.BringToFront();
                    txtX.Value = c.Location.X;
                    txtY.Value = c.Location.Y;
                    chkHide.Checked = !c.Visible;
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
                //if (cmbBankName.SelectedValue == null || cmbBankName.SelectedValue.ToString() == "" || cmbBankName.Text == "")
                if(cmbBankName.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Bank Not Selected !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbBankName.Focus();
                    btnClear.PerformClick();
                }
                DataSet dsCPS = new DataSet();
                dsCPS = objChqPrint.getDataset("SELECT x, y, FieldName, PageX, PageY, Hide FROM tb_Settings_CheqPrint WHERE Standerd=0 AND BankFormat='" + cmbBankName.Text.ToString() + "' ", "table3");

                dt3 = dsCPS.Tables[0];

                if (dt3 != null && dt3.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt3.Rows)
                    {
                        Control Con = pnlCheque.Controls.Find(Row["FieldName"].ToString(), true)[0];
                        if (Con is Label)
                        {
                            Con.Location = new Point(int.Parse(Row["x"].ToString()), int.Parse(Row["y"].ToString()));
                            Con.Visible = !Convert.ToBoolean(Row["Hide"].ToString());
                        }
                    }

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
                        string x = paymentword1.Substring(paymentword1.Length - 5,5);
                        if (x ==  " And ")
                        {
                            paymentword1 = paymentword1.Substring(0, paymentword1.Length - 5);
                        }
                    }
                    if (second != 0)
                    {
                        paymentword2 = NumberToWords(Convert.ToInt32(second.ToString("00").Substring(0, 2)));
                    }
                    if (second != 0)
                    {
                        paymentword = paymentword1 + " And Cents " + paymentword2 + " Only";
                    }
                    else
                    {
                        paymentword = paymentword1 + " Only";
                    }
                    paymentword = paymentword.Replace("And  Thousand", "Thousand");

                    lblAmountText.Text = "**" + paymentword + "**";

                    lblPay.Text = "**" + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtPay.Text.Trim().ToLower()) + "**";
                    //lblPay.Text = "**" + txtPay.Text.Trim() + "**";

                    btnPrint.Enabled = true;
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
                    pictureBox1.Visible = true;
                    chkNormalCrossing.Checked = false;
                }
                else
                {
                    pictureBox1.Visible = false;
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
                    DataSet dsCPS = new DataSet();
                    dsCPS = objChqPrint.getDataset("SELECT x, y, FieldName, PageX, PageY, Hide FROM tb_Settings_CheqPrint WHERE Standerd=1", "table2");
                   
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

        private void btnSaveBankFormat_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Save Current Format To Selected Bank ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(cmbBankName.Text.Trim() != string.Empty)
                    {
                        foreach (Control CON in pnlCheque.Controls)
                        {
                            string SqlStatement = "DELETE FROM tb_Settings_CheqPrint WHERE FieldName='" + CON.Name + "' AND BankFormat='" + cmbBankName.Text.ToString() + "' AND Standerd=0";
                            objChqPrint.getDataReader(SqlStatement);

                            SqlStatement = " INSERT INTO tb_Settings_CheqPrint (x, y, FieldName, Standerd, BankFormat, PageX, PageY, Hide) VALUES (" + CON.Location.X + ", " + CON.Location.Y + ", '" + CON.Name + "', 0, '" + cmbBankName.Text.ToString() + "', " + Convert.ToInt16(txtPageX.Value) + ", " + Convert.ToInt16(txtPageY.Value) + ", " + Convert.ToInt16(!CON.Visible) + ")";
                            objChqPrint.getDataReader(SqlStatement);
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

               // lblDocNo.Text = lblBank.Text = lblCheqNo.Text = lblCheqDate.Text = lblCheqAmt.Text = "";

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
                        c.Visible = false;
                    }
                    else
                    {
                        c.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPay.Focus();
            }
        }

        private void chkNormalCrossing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNormalCrossing.Checked == true)
            {
                chkPayeeOnly.Checked = false;
            }
        }

    }
}