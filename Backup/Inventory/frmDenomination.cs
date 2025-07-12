using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
using System.Globalization;


namespace Inventory
{
    public partial class frmDenomination : Form
    {
        public frmDenomination()
        {
            InitializeComponent();
        }

        clsDenomination obj_ClsDeno = new clsDenomination();
        clsCommon objDenomination = new clsCommon();
        clsReportViewer objRepView = new clsReportViewer();
        DataSet dsDataForReport = new DataSet();

        frmReportViewer objRepViewer = new frmReportViewer();
        //objRepViewer.Text = this.Text;

        private static frmDenomination Denomination;
        public static frmDenomination GetDenomination
        {
            get { return Denomination; }
            set { Denomination = value; }
        }

        private void frmDenomination_FormClosed(object sender, FormClosedEventArgs e)
        {
            Denomination = null;
        }

        private void txt5000_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt5000.Text != "")
                    {
                        if (clsValidation.isNumeric(txt5000.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt5000.Text) >= 0)
                        {
                            lbl5000.Text = Calculate_Amount(txt5000.Text.Trim(), V5000.Text).ToString("N2");
                            txt2000.Focus();
                            txt2000.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public decimal Calculate_Amount(string Qty, string Value)
        {
            try
            {
                int NoOfQty = int.Parse(Qty);
                decimal Valv = decimal.Parse(Value);

                decimal Amount = 0;
                Amount = (NoOfQty * Valv);
                return Amount;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();

                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public decimal Calculate_TotalAmount()
        {
            try
            {
                decimal dec5000 = 0;
                decimal dec2000 = 0;
                decimal dec1000 = 0;
                decimal dec500 = 0;
                decimal dec200 = 0;
                decimal dec100 = 0;
                decimal dec50 = 0;
                decimal dec20 = 0;
                decimal dec10 = 0;
                decimal dec5 = 0;
                decimal dec2 = 0;
                decimal dec1 = 0;
                decimal dec_5 = 0;
                decimal dec_25 = 0;

                dec5000 = decimal.Parse(lbl5000.Text);
                dec2000 = decimal.Parse(lbl2000.Text);
                dec1000 = decimal.Parse(lbl1000.Text);
                dec500 = decimal.Parse(lbl500.Text);
                dec100 = decimal.Parse(lbl100.Text);
                dec50 = decimal.Parse(lbl50.Text);
                dec20 = decimal.Parse(lbl20.Text);
                dec10 = decimal.Parse(lbl10.Text);
                dec5 = decimal.Parse(lbl5.Text);
                dec2 = decimal.Parse(lbl2.Text);
                dec1 = decimal.Parse(lbl1.Text);
                

                decimal Total = dec5000 + dec2000 + dec1000 + dec500  + dec100 + dec50 + dec20 + dec10 + dec5 + dec2 + dec1 + dec_5 + dec_25;

                return Total;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void txt2000_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt2000.Text != "")
                    {
                        if (clsValidation.isNumeric(txt2000.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt2000.Text) >= 0)
                        {
                            lbl2000.Text = Calculate_Amount(txt2000.Text.Trim(), V2000.Text).ToString("N2");
                            txt1000.Focus();
                            txt1000.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt1000_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt1000.Text != "")
                    {
                        if (clsValidation.isNumeric(txt1000.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt1000.Text) >= 0)
                        {
                            lbl1000.Text = Calculate_Amount(txt1000.Text.Trim(), V1000.Text).ToString("N2");
                            txt500.Focus();
                            txt500.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt500_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt500.Text != "")
                    {
                        if (clsValidation.isNumeric(txt500.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt500.Text) >= 0)
                        {
                            lbl500.Text = Calculate_Amount(txt500.Text.Trim(), V500.Text).ToString("N2");
                            txt100.Focus();
                            txt100.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

     
        private void txt100_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt100.Text != "")
                    {
                        if (clsValidation.isNumeric(txt100.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt100.Text) >= 0)
                        {
                            lbl100.Text = Calculate_Amount(txt100.Text.Trim(), V100.Text).ToString("N2");
                            txt50.Focus();
                            txt50.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt50_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt50.Text != "")
                    {
                        if (clsValidation.isNumeric(txt50.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt50.Text) >= 0)
                        {
                            lbl50.Text = Calculate_Amount(txt50.Text.Trim(), V50.Text).ToString("N2");
                            txt20.Focus();
                            txt20.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt20_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                 if (e.KeyCode == Keys.Enter)
                {
                    if (txt20.Text != "")
                    {
                        if (clsValidation.isNumeric(txt20.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt20.Text) >= 0)
                        {
                            lbl20.Text = Calculate_Amount(txt20.Text.Trim(), V20.Text).ToString("N2");
                            txt10.Focus();
                            txt10.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt10_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt10.Text != "")
                    {
                        if (clsValidation.isNumeric(txt10.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt10.Text) >= 0)
                        {
                            lbl10.Text = Calculate_Amount(txt10.Text.Trim(), V10.Text).ToString("N2");
                            txt5.Focus();
                            txt5.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt5.Text != "")
                    {
                        if (clsValidation.isNumeric(txt5.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt5.Text) >= 0)
                        {
                            lbl5.Text = Calculate_Amount(txt5.Text.Trim(), V5.Text).ToString("N2");
                            txt2.Focus();
                            txt2.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt2.Text != "")
                    {
                        if (clsValidation.isNumeric(txt2.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt2.Text) >= 0)
                        {
                            lbl2.Text = Calculate_Amount(txt2.Text.Trim(), V2.Text).ToString("N2");
                            txt1.Focus();
                            txt1.SelectAll();

                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt1.Text != "")
                    {
                        if (clsValidation.isNumeric(txt1.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt1.Text) >= 0)
                        {
                            lbl1.Text = Calculate_Amount(txt1.Text.Trim(), V1.Text).ToString("N2");
                            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt0_5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 //if (txt0_5.Text != "")
                 //   {
                 //       if (clsValidation.isNumeric(txt0_5.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt0_5.Text) >= 0)
                 //       {
                 //           lbl0_5.Text = Calculate_Amount(txt0_5.Text.Trim(), V0_5.Text).ToString("N2");
                 //           txt0_25.Focus();
                 //           txt0_25.SelectAll();

                 //           lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                 //       }
                 //   }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
 
      
        private void btnApply_Click(object sender, EventArgs e)
        {
           try
            {
                if (MessageBox.Show("Do you Want To Apply "+this.Text, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (decimal.Parse(txtCashAll.Text) < 0)
                    {
                        MessageBox.Show("Invalid Cash Amount", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (this.Text == "Received On Account")
                    {
                        obj_ClsDeno.Iid = "ROA";
                    }
                    else
                    { obj_ClsDeno.Iid = "CDNM"; }

                   
                    obj_ClsDeno.declareAmount = decimal.Parse(txtCashAll.Text);
                   
                    obj_ClsDeno.Post_Date = dtpDate.Text;
                     obj_ClsDeno.UserName = LoginManager.UserName;
                  
                    obj_ClsDeno._N5000 = decimal.Parse(txt5000.Text.Trim());
                    obj_ClsDeno._N2000 = decimal.Parse(txt2000.Text.Trim());
                    obj_ClsDeno._N1000 = decimal.Parse(txt1000.Text.Trim());
                    obj_ClsDeno._N500 = decimal.Parse(txt500.Text.Trim());
                    obj_ClsDeno._N100 = decimal.Parse(txt100.Text.Trim());
                    obj_ClsDeno._N50 = decimal.Parse(txt50.Text.Trim());
                    obj_ClsDeno._N20 = decimal.Parse(txt20.Text.Trim());
                    obj_ClsDeno._N10 = decimal.Parse(txt10.Text.Trim());
                    obj_ClsDeno._N5 = decimal.Parse(txt5.Text.Trim());
                    obj_ClsDeno._N2 = decimal.Parse(txt2.Text.Trim());
                    obj_ClsDeno._N1 = decimal.Parse(txt1.Text.Trim());
                  
                    obj_ClsDeno.Cash_Deno_Apply();

                    if (obj_ClsDeno.ResultSet.Tables[0].Rows.Count>0)
                    {
                        if (MessageBox.Show("Succussfully Applied  " + this.Text + " " + obj_ClsDeno.ResultSet.Tables[0].Rows[0]["DocNo"].ToString() + "  Do you want to Print Report?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            frmReportViewer objRepViewer = new frmReportViewer();
                            objRepViewer.DirectPrintVerRep = new rptCashDeno();
                            objRepViewer.DirectPrintVerRep.SetDataSource(obj_ClsDeno.ResultSet);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                            objRepViewer.DirectPrintVerRep.PrintToPrinter(1, false, 0, 0);
                          
                        }
                        else
                        {
                            frmReportViewer objRepViewer = new frmReportViewer();
                            objRepViewer.DirectPrintVerRep = new rptCashDeno();
                            objRepViewer.DirectPrintVerRep.SetDataSource(obj_ClsDeno.ResultSet);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                            objRepViewer.Show();
                            
                        }
                        this.Close();
                      
                        


                    }
                    else
                    {
                        MessageBox.Show(this.Text+" Apply Failed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you Want To Clear Values.","Cash Denomenation Form",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    txt5000.Text = "0";
                    txt2000.Text = "0";
                    txt1000.Text = "0";
                    txt500.Text = "0";
                     txt100.Text = "0";
                    txt50.Text = "0";
                    txt20.Text = "0";
                    txt10.Text = "0";
                    txt5.Text = "0";
                    txt2.Text = "0";
                    txt1.Text = "0";
                    
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt5000_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt5000.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt5000.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt5000.Text) >= 0)
                //        {
                //            lbl5000.Text = Calculate_Amount(txt5000.Text.Trim(), V5000.Text).ToString("N2");
                //            txt2000.Focus();
                //            txt2000.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt2000_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt2000.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt2000.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt2000.Text) >= 0)
                //        {
                //            lbl2000.Text = Calculate_Amount(txt2000.Text.Trim(), V2000.Text).ToString("N2");
                //            txt1000.Focus();
                //            txt1000.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt1000_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt1000.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt1000.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt1000.Text) >= 0)
                //        {
                //            lbl1000.Text = Calculate_Amount(txt1000.Text.Trim(), V1000.Text).ToString("N2");
                //            txt500.Focus();
                //            txt500.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt500_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt500.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt500.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt500.Text) >= 0)
                //        {
                //            lbl500.Text = Calculate_Amount(txt500.Text.Trim(), V500.Text).ToString("N2");
                //            txt200.Focus();
                //            txt200.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt200_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt200.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt200.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt200.Text) >= 0)
                //        {
                //            lbl200.Text = Calculate_Amount(txt200.Text.Trim(), V200.Text).ToString("N2");
                //            txt100.Focus();
                //            txt100.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt100_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 //if (txt100.Text != "")
                 //   {
                 //       if (clsValidation.isNumeric(txt100.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt100.Text) >= 0)
                 //       {
                 //           lbl100.Text = Calculate_Amount(txt100.Text.Trim(), V100.Text).ToString("N2");
                 //           txt50.Focus();
                 //           txt50.SelectAll();

                 //           lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                 //       }
                 //   }
            }
            catch (Exception ex)
            {
                 //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt50_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt50.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt50.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt50.Text) >= 0)
                //        {
                //            lbl50.Text = Calculate_Amount(txt50.Text.Trim(), V50.Text).ToString("N2");
                //            txt20.Focus();
                //            txt20.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt20.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt20.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt20.Text) >= 0)
                //        {
                //            lbl20.Text = Calculate_Amount(txt20.Text.Trim(), V20.Text).ToString("N2");
                //            txt10.Focus();
                //            txt10.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt10.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt10.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt10.Text) >= 0)
                //        {
                //            lbl10.Text = Calculate_Amount(txt10.Text.Trim(), V10.Text).ToString("N2");
                //            txt5.Focus();
                //            txt5.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt5.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt5.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt5.Text) >= 0)
                //        {
                //            lbl5.Text = Calculate_Amount(txt5.Text.Trim(), V5.Text).ToString("N2");
                //            txt2.Focus();
                //            txt2.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt2.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt2.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt2.Text) >= 0)
                //        {
                //            lbl2.Text = Calculate_Amount(txt2.Text.Trim(), V2.Text).ToString("N2");
                //            txt1.Focus();
                //            txt1.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt1.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt1.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt1.Text) >= 0)
                //        {
                //            lbl1.Text = Calculate_Amount(txt1.Text.Trim(), V1.Text).ToString("N2");
                //            txt0_5.Focus();
                //            txt0_5.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txt0_25_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txt0_25.Text != "")
                //    {
                //        if (clsValidation.isNumeric(txt0_25.Text.Trim(), System.Globalization.NumberStyles.Integer) && decimal.Parse(txt0_25.Text) >= 0)
                //        {
                //            lbl0_25.Text = Calculate_Amount(txt0_25.Text.Trim(), V0_25.Text).ToString("N2");
                //            txtCashAll.Focus();
                //            txtCashAll.SelectAll();

                //            lblCashAll.Text = txtCashAll.Text = Calculate_TotalAmount().ToString("N2");
                //        }
                //    }
            }
            catch (Exception ex)
            {
                 //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmProductPriceMaster 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmDenomination_Load(object sender, EventArgs e)
        {
            lblCashier.Text = LoginManager.UserName;
        }

        private void cmbCashierName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string Iid = "CDNM";
                if (this.Text == "Received On Account")
                {
                      Iid = "ROA";
                }
                clsCommon objComm = new clsCommon();


                objComm.SqlStatement = "SELECT SUM(Amount) FROM dbo.tbCashDenoDetails WHERE CONVERT(DATETIME,Post_Date,103)=  CONVERT(DATETIME,'"+dtpDate.Text+"',103) AND Iid='"+Iid+"' AND Loca='"+LoginManager.LocaCode+"'";
                
                objComm.GetDs();
                lblAmount.Text = objComm.Ads.Tables[0].Rows[0][0].ToString();





                
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}