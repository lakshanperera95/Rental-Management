using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
using System.IO;


namespace Inventory
{
    public partial class frmSpaVoucher : Form
    {
        public frmSpaVoucher()
        {
            InitializeComponent();
        }
        clsGiftVoucher ObjGiftVoucher = new clsGiftVoucher();

        private static frmSpaVoucher GiftVoucher;

        public static frmSpaVoucher GetGiftVoucher
        {
            get { return GiftVoucher; }
            set { GiftVoucher = value; }
        }

        private  void StringClear()
        {
            txtGiftVoucherCode.Text = string.Empty;
            cmbLocation.Text = string.Empty;
            lblCreateDate.Text = string.Empty;
            lblCreateUser.Text = string.Empty;
            chkNoExpire.Checked = false;
            dtExpireDate.Enabled = true;
            dtExpireDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            btnSave.Enabled = true;
            cmbLocation.Enabled = true;
            chkNoExpire.Enabled = true;

        }

        private void AccessEnabled()
        {
            cmbLocation.Enabled = false;
            dtExpireDate.Enabled = false;
            chkNoExpire.Enabled = false;
            btnSave.Enabled = false;
            cmbLocation.BackColor = Color.White;
            dtExpireDate.BackColor = Color.White;
            
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiftVoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
           GetGiftVoucher = null;
        }
     
        private void btnMinimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtGiftVoucherCode_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtGiftVoucherCode.Text = txtGiftVoucherCode.Text.ToUpper();
            //        ObjGiftVoucher.SqlString = "SELECT gif_Voucher.Loca, gif_Voucher.Gi_Code, gif_Voucher.Amount, gif_Voucher.CreateUser, CONVERT(NVARCHAR,gif_Voucher.InsertDate,103)AS [InsertDate], gif_Voucher.ExpireDate, Location.Loca_Descrip FROM Location INNER JOIN gif_Voucher ON Location.Loca = gif_Voucher.Loca WHERE gif_Voucher.Gi_Code='" + txtGiftVoucherCode.Text.Trim() + "' AND gif_Voucher.Iid='GI'";
            //        ObjGiftVoucher.ReadGiftVoucherDetails();
            //        if (ObjGiftVoucher.RecordFound == true)
            //        {
            //            cmbGiftVoucherAmount.Text = ObjGiftVoucher.Amount.ToString();
            //            cmbLocation.Text = ObjGiftVoucher.Location.ToString();
            //            lblCreateDate.Text = ObjGiftVoucher.CreateDate.ToString();
            //            lblCreateUser.Text = ObjGiftVoucher.CreateUser.ToString();
            //            if (ObjGiftVoucher.ExpireDate != string.Empty)
            //            {
            //                dtExpireDate.Text = ObjGiftVoucher.ExpireDate.ToString();
            //                chkNoExpire.Checked = false;
            //            }
            //            else
            //            {
            //                chkNoExpire.Checked = true;
            //            }
            //            this.AccessEnabled();
            //        }
            //        else
            //        {
            //            cmbGiftVoucherAmount.Enabled = true;
            //            cmbLocation.Enabled = true;
            //            dtExpireDate.Enabled = true;
            //            chkNoExpire.Enabled = true;
            //            btnSave.Enabled = true;
            //            cmbGiftVoucherAmount.Focus();
            //            //MessageBox.Show("Voucher Cord Not Found", "Onimta Gift Voucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
                
            //    clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            //}
        }

        private void chkNoExpire_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoExpire.Checked == true)
            {
                dtExpireDate.Enabled = false;
            }
            else
            {
                dtExpireDate.Enabled = true;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "";

                SqlStatement = "SELECT * FROM Spa_Voucher WHERE BookNo = '" + txtBookNumber.Text.Trim() + "'";
                ObjGiftVoucher.GetDataReader(SqlStatement);
                if (ObjGiftVoucher.GetReader.Read())
                {
                    MessageBox.Show("Book Number is already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBookNumber.Focus();
                    return; 
                }
                if (txtBookNumber.Text == string.Empty)
                {
                    MessageBox.Show("Book Number is not entered.Please check again.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBookNumber.Focus();
                    return; 
                }
                if (txtDi_Code.Text != string.Empty && cmbQty.Text != string.Empty)
                {
                    
                    try
                    {
                        int code = int.Parse(txtDi_Code.Text.Trim());
                        for (int i = 0; i < int.Parse(cmbQty.Text); i++)
                        {
                            string strCode = string.Format("{0:000000000}", code);
                            //ObjDiscountCard.Gi_Code = txtDiscountCardCode.Text.Trim();
                            // ObjDiscountCard.Gi_Code = txtDi_Code.Text.Trim();
                            ObjGiftVoucher.Gi_Code = strCode;
                            ObjGiftVoucher.Amount = 0;// decimal.Parse(cmbGiftVoucherAmount.Text.Trim());
                            if (chkNoExpire.Checked == false)
                            {
                                ObjGiftVoucher.ExpireDate = string.Format("{0:dd/MM/yyyy}", dtExpireDate.Value);
                            }
                            else
                            {
                                ObjGiftVoucher.ExpireDate = string.Empty;
                            }

                            ObjGiftVoucher.Location = cmbLocation.Text.Trim();
                            ObjGiftVoucher.CreateUser = BaseClass.LoginUser;
                            ObjGiftVoucher.BookNo = txtBookNumber.Text.Trim();
                            ObjGiftVoucher.decQty = decimal.Parse(cmbQty.Text.Trim());
                            //ObjGiftVoucher.strVoucherId = cmbVoucherId.Text.Trim();
                            ObjGiftVoucher.decId = i; 

                            ObjGiftVoucher.UpdateSpaVoucherDetails();
                            code = code + 1;
                        }
                        MessageBox.Show("Successfully Created " + cmbQty.Text.Trim() + " Spa Vouchers !", "Onimta Gift Voucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //Write to Log
                        DateTime dtCurrentDate = DateTime.Now;
                        FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                        StreamWriter m_streamWriter = new StreamWriter(fileStream);
                        try
                        {
                            m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //}
                else
                {
                    MessageBox.Show("Qty is missing.Please check again!", "OnimtaGiftVoucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDi_Code.SelectAll();
                    cmbQty.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierReturn 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.StringClear();
            txtBookNumber.Clear();
            txtGiftVoucherCode.Focus();
            txtDi_Code.Clear();
            if (cmbQty.DropDownStyle == ComboBoxStyle.DropDown)
            {
                cmbQty.Text = string.Empty;
            }
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
        //   this.btnSave.BackgroundImage = global::Inventory.Properties.Resources.LocationLeave;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
          //  this.btnSave.BackgroundImage = global::Inventory.Properties.Resources.GifTool;
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
          //  this.btnClear.BackgroundImage = global::Inventory.Properties.Resources.LocationLeave;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
           // this.btnClear.BackgroundImage = global::Inventory.Properties.Resources.GifTool;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
          //  this.btnExit.BackgroundImage = global::Inventory.Properties.Resources.LocationLeave;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
          //  this.btnExit.BackgroundImage = global::Inventory.Properties.Resources.GifTool;
        }

        private void frmGiftVoucher_Load(object sender, EventArgs e)
        {
            try
            {

                ObjGiftVoucher.SqlString = "SELECT Loca_Descrip FROM Location where TaxLoca='" + LoginManager.TaxLocaLogin + "' ORDER BY Loca_Descrip DESC; " +
                    "SELECT ISNULL(MAX(BookNo),1) FROM dbo.Spa_Voucher WHERE Iid ='GV'";
                ObjGiftVoucher.GetData();
                cmbLocation.DataSource = ObjGiftVoucher.GetDataSet.Tables["Table"];
                cmbLocation.DisplayMember = "Loca_Descrip";

               
        
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "Input string was not in a correct format.")
                {
                    txtDi_Code.Text = "000000";
                    cmbQty.Focus();
                }
                else
                {
                    
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            
                }
                
            }
        }

        private void txtDi_Code_KeyDown(object sender, KeyEventArgs e)
        {
            try
           {
                if (e.KeyCode == Keys.Enter)
                {
                    /*//txtGiftVoucherCode.Text = txtGiftVoucherCode.Text.ToUpper();
                    ObjGiftVoucher.SqlString = "SELECT gif_Voucher.Loca, gif_Voucher.Gi_Code, gif_Voucher.Amount, gif_Voucher.CreateUser, CONVERT(NVARCHAR,gif_Voucher.InsertDate,103)AS [InsertDate], gif_Voucher.ExpireDate, Location.Loca_Descrip FROM Location INNER JOIN gif_Voucher ON Location.Loca = gif_Voucher.Loca WHERE gif_Voucher.Gi_Code='" + txtDi_Code.Text.Trim() + "' AND gif_Voucher.Iid='GV'";
                    ObjGiftVoucher.ReadGiftVoucherDetails();
                    if (ObjGiftVoucher.RecordFound == true)
                    {
                        //cmbGiftVoucherAmount.Text = ObjGiftVoucher.Amount.ToString();
                        cmbLocation.Text = ObjGiftVoucher.Location.ToString();
                        lblCreateDate.Text = ObjGiftVoucher.CreateDate.ToString();
                        lblCreateUser.Text = ObjGiftVoucher.CreateUser.ToString();
                        if (ObjGiftVoucher.ExpireDate != string.Empty)
                        {
                            dtExpireDate.Text = ObjGiftVoucher.ExpireDate.ToString();
                            chkNoExpire.Checked = false;
                        }
                        else
                        {
                            chkNoExpire.Checked = true;
                        }
                        this.AccessEnabled();
                    }
                    else
                    {
                        cmbGiftVoucherAmount.Enabled = true;
                        cmbLocation.Enabled = true;
                        dtExpireDate.Enabled = true;
                        chkNoExpire.Enabled = true;
                        btnSave.Enabled = true;
                        cmbGiftVoucherAmount.Focus();
                        //MessageBox.Show("Voucher Cord Not Found", "Onimta Gift Voucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                    cmbQty.Focus();
                }
            }
            catch (Exception )
            {

                //clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void cmbGiftVoucherAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDi_Code.Focus();
            }
        }

        private void txtQtyOfCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLocation.Focus();
            }
        }

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtExpireDate.Focus();
            }
        }

        private void cmbGiftVoucherAmount_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtBookNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // cmbGiftVoucherAmount.Focus();
            }
        }

        private void cmbQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLocation.Focus();
            }
        }

        private void ctrlClose1_Load(object sender, EventArgs e)
        {

        }

        private void cmbGiftVoucherAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cmbVoucherId.SelectedIndex = cmbGiftVoucherAmount.SelectedIndex;

                //if (cmbVoucherId.SelectedIndex > 0)
                //{
                //    ObjGiftVoucher.SqlString = "SELECT  Characters FROM gif_Amount WHERE Amount = " + cmbGiftVoucherAmount.Text.Trim() + "";
                //    ObjGiftVoucher.Charecter();
                //    if (ObjGiftVoucher.RecordFound == true)
                //    {
                //        txtCharacter.Text = ObjGiftVoucher.strCharecter.ToString();
                //    }
                //    else
                //    {
                //        txtCharacter.Text = "";
                //    }
                //}


               

                /*
                string SqlStatement = "";
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "500.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";                   
                }
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "1000.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";
                }
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "1500.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";
                }
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "2000.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";
                }
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "2500.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";
                }
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "5000.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";
                }
                ObjGiftVoucher.CloseConnection();
                if (cmbGiftVoucherAmount.Text == "2000.00")
                {
                    SqlStatement = "SELECT Characters, Amount FROM gif_Amount WHERE Amount=" + cmbGiftVoucherAmount.Text.Trim() + "";
                }

                ObjGiftVoucher.CloseConnection();
                ObjGiftVoucher.GetDataReader(SqlStatement);
                if (ObjGiftVoucher.GetReader.Read())
                {
                    txtCharacter.Text = ObjGiftVoucher.GetReader["Characters"].ToString();
                }

                */
                //ObjGiftVoucher.SelectCharacter();
            }
            catch (Exception ex)
            {
                clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ObjGiftVoucher.SqlString = "SELECT ISNULL(MAX(Gi_Code),0) FROM dbo.Spa_Voucher WHERE Iid ='GV'";
                ObjGiftVoucher.GetData();
              
                int NewCode = 1;

                if (ObjGiftVoucher.GetDataSet.Tables[0].Rows.Count > 0)
                {
                    NewCode = int.Parse(ObjGiftVoucher.GetDataSet.Tables[0].Rows[0][0].ToString());
                    NewCode = NewCode + 1;
                }               
                
                txtDi_Code.Text = string.Format("{0:000000000}", NewCode);
                 
            }
            catch (Exception ex)
            {

                if (ex.Message.ToString() == "Input string was not in a correct format.")
                {
                    txtDi_Code.Text = "0000";
                }
                else
                {
                    clsBase.ErrorFound(ex.Message.ToString(), ex.StackTrace.ToString());
                }
            }
        }

        private void chkUserDefine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserDefine.Checked == true)
            {
                cmbQty.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cmbQty.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

       
    }
}