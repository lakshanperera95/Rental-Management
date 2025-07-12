using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmGiftVoucherPrint : Form
    {
        clsGiftVoucherPrint ObjBarcode = new clsGiftVoucherPrint();
        frmSearch search = new frmSearch();

        public frmGiftVoucherPrint()
        {
            InitializeComponent();
            btnExit.Enter += new EventHandler(this.btnExit_MouseEnter);
            btnPrint.Enter += new EventHandler(this.btnPrint_MouseEnter);
            btnAdd.Enter += new EventHandler(this.btnAdd_MouseEnter);
            btnExit.Leave += new EventHandler(this.btnExit_MouseLeave);
            btnPrint.Leave += new EventHandler(this.btnPrint_MouseLeave);
            btnAdd.Leave += new EventHandler(this.btnAdd_MouseLeave);
        }
        
        private static frmGiftVoucherPrint Barcode;
        public static frmGiftVoucherPrint GetBarcode
        {
            get { return Barcode; }
            set { Barcode = value; }
        }

        private void frmBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmGiftVoucherPrint.GetBarcode = null;
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCodeFrom_Click(object sender, EventArgs e)        
        {
            try
            {
                if (search == null)
                {
                    search = new frmSearch();
                }
                ObjBarcode.SearchCodeNew("SELECT VisibleCode AS [Gi_Vo_Code],Amount FROM gif_Voucher WHERE BookNo='" + txtBookNo.Text.Trim() + "' AND Iid='GV' ORDER BY VisibleCode", "Table");
                search.dgSearch.DataSource = ObjBarcode.GetDataSet.Tables["Table"];

                search.prop_Focus = txtGiftVoucherCodeFrom;
                //txtGiftVoucherCodeFrom.Text = search.Code;
                search.Cont_Descript = null;

                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnCodeTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (search == null)
                {
                    search = new frmSearch();
                }
                ObjBarcode.SearchCodeNew("SELECT VisibleCode AS [Gi_Vo_Code],Amount FROM gif_Voucher WHERE BookNo='" + txtBookNo.Text.Trim() + "' AND Iid='GV' ORDER BY VisibleCode", "Table");
                search.dgSearch.DataSource = ObjBarcode.GetDataSet.Tables["Table"];

                search.prop_Focus = txtGiftVoucherCodeTo;
                //txtGiftVoucherCodeTo.Text = search.Code;
                search.Cont_Descript = null;

                search.Show();
                txtGiftVoucherCodeTo.Focus();
                               
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGiftVoucherCodeFrom.Text.Trim() != string.Empty || txtGiftVoucherCodeTo.Text.Trim() != string.Empty)
                {
                    ObjBarcode.SearchCodeNew("SELECT Gi_Code[Prod_Code], Amount[Qty], VisibleCode[Prod_Name], CONVERT(NVARCHAR,InsertDate,102)AS [Supp_Code] FROM gif_Voucher WHERE Iid='GV' AND VisibleCode BETWEEN '" + txtGiftVoucherCodeFrom.Text.Trim() + "' AND '" + txtGiftVoucherCodeTo.Text.Trim() + "' ORDER BY VisibleCode", "dsBarCode");
                    this.dgBarCode.DataSource = ObjBarcode.GetDataSet.Tables["dsBarCode"];
                    this.dgBarCode.Refresh();
                    lblGiftVoucherQTY.Text = string.Format("{0:0}", dgBarCode.RowCount);
                }
                else
                {
                    ObjBarcode.SearchCodeNew("SELECT Gi_Code[Prod_Code], Amount[Qty], VisibleCode[Prod_Name], CONVERT(NVARCHAR,InsertDate,102)AS [Supp_Code] FROM gif_Voucher WHERE Iid='GV' AND BookNo='" + txtBookNo.Text.Trim() + "' ORDER BY VisibleCode", "dsBarCode");
                    this.dgBarCode.DataSource = ObjBarcode.GetDataSet.Tables["dsBarCode"];
                    this.dgBarCode.Refresh();
                    lblGiftVoucherQTY.Text = string.Format("{0:0}", dgBarCode.RowCount);
                }
               
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbLabelType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Barcode Type.", "Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Write to Log
            FileStream fileStream = new FileStream(@"C:\barcode\GiftVoucherBarcode.txt", FileMode.Create);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                foreach (DataRow row in ObjBarcode.GetDataSet.Tables["dsBarCode"].Rows)
                {
                    string strVisibleCode;
                    string strAmount;
                    string strGi_Code;
                    string strCreatedDate;
                    string GifNo;
                    string strType;

                    strVisibleCode = row["Prod_Name"].ToString();
                    strAmount = row["Qty"].ToString();
                    strAmount = string.Format("{0:0/=}", strAmount);
                    strGi_Code = row["Prod_Code"].ToString();
                    GifNo = row["Prod_Name"].ToString();
                    strCreatedDate = row["Supp_Code"].ToString();
                    double amount = Double.Parse(strAmount);
                    strAmount = string.Format("{0:0/=}", amount);
                    strType = "G";

                    m_streamWriter.WriteLine(strVisibleCode.Trim() + "," + strAmount.Trim() + "," + strGi_Code + "," + strCreatedDate + "," + strType);

                    ObjBarcode.BookNo = txtBookNo.Text.ToString().Trim();
                    ObjBarcode.CodeMin = GifNo;
                    ObjBarcode.CodeMax = GifNo;
                    ObjBarcode.VoucherType = "GV";
                    ObjBarcode.UpdateVoucher();

                }
                // read from file or write to file
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }
           
            try
            {
                //Barcode Software
                System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();

                processStartInfo.FileName = @"C:\barcode\LW.exe";
                if (cmbLabelType.SelectedIndex == 0)
                {
                    processStartInfo.Arguments = @"C:\barcode\Gift_01.lbl";
                }
                else if (cmbLabelType.SelectedIndex == 1)
                {
                    processStartInfo.Arguments = @"C:\barcode\Gift_02.lbl";
                }
                else if (cmbLabelType.SelectedIndex == 2)
                {
                    processStartInfo.Arguments = @"C:\barcode\Gift_03.lbl";
                }

                //else if (cmbLabelType.SelectedIndex == 3)
                //{
                //    processStartInfo.Arguments = @"C:\barcode\GiftSticker48.lbl";
                //}

                //else if (cmbLabelType.SelectedIndex == 4)
                //{
                //    processStartInfo.Arguments = @"C:\barcode\GifStickerCus.lbl";
                //}
                System.Diagnostics.Process.Start(processStartInfo);
                this.Close();
              
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
       }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
        }

        private void btnPrint_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnPrint_MouseLeave(object sender, EventArgs e)
        {
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
         }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
          }

        private void btnBookNoSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (search == null)
                {
                    search = new frmSearch();
                }
                ObjBarcode.SearchCodeNew("SELECT DISTINCT BookNo [Book Number], CONVERT(NVARCHAR,CONVERT(DATETIME,Tr_Date,103),103) [Date] FROM gif_Voucher WHERE Iid ='GV' AND BookNo <> ''  ORDER BY BookNo", "Table");
                search.dgSearch.DataSource = ObjBarcode.GetDataSet.Tables["Table"];
                            
                search.prop_Focus = txtBookNo;
                search.Cont_Descript = null;

                search.Show();
                txtBookNo.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtGiftVoucherCodeTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ObjBarcode.SearchCodeNew("SELECT Gi_Code[Prod_Code], Amount[Qty], VisibleCode[Prod_Name], CONVERT(NVARCHAR,InsertDate,102)AS [Supp_Code] FROM gif_Voucher WHERE Iid='GV' AND VisibleCode BETWEEN '" + txtGiftVoucherCodeFrom.Text.Trim() + "' AND '" + txtGiftVoucherCodeTo.Text.Trim() + "' ORDER BY VisibleCode", "dsBarCode");
                this.dgBarCode.DataSource = ObjBarcode.GetDataSet.Tables["dsBarCode"];
                this.dgBarCode.Refresh();
                lblGiftVoucherQTY.Text = string.Format("{0:0}", dgBarCode.RowCount);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtBookNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtGiftVoucherCodeFrom.Text = "0";
                    txtGiftVoucherCodeTo.Text = "zz";

                    if (dgBarCode.Rows.Count>0)
                    {
                        txtBookNo.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnBookNoSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGiftVoucherCodeFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtGiftVoucherCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                btnCodeFrom.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                txtGiftVoucherCodeTo.Focus();
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void frmBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                txtBookNo.Focus();
            }
            catch (Exception ex)
            { 
                clsBase.ErrorFound(ex.Message.ToString(),ex.StackTrace.ToString());                
            }
        }

        private void plTitalBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ObjBarcode.SearchCodeNew("SELECT Gi_Code[Prod_Code], Amount[Qty], VisibleCode[Prod_Name], CONVERT(NVARCHAR,InsertDate,102)AS [Supp_Code] FROM gif_Voucher WHERE BookNo='" + txtBookNo.Text.Trim() + "' and VisibleCode between '"+txtGiftVoucherCodeFrom.Text+"' and '"+txtGiftVoucherCodeTo.Text+"' ORDER BY VisibleCode", "dsBarCode");
                this.dgBarCode.DataSource = ObjBarcode.GetDataSet.Tables["dsBarCode"];
                this.dgBarCode.Refresh();
                lblGiftVoucherQTY.Text = string.Format("{0:0}", dgBarCode.RowCount);
                //  btnBookNoSearch.Focus();
                txtGiftVoucherCodeFrom.Text = string.Empty;
                txtGiftVoucherCodeTo.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

    
