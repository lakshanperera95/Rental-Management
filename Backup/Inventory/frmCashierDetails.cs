using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using clsLibrary;
namespace Inventory
{
    public partial class frmCashierDetails : Form
    {
        public frmCashierDetails()
        {
            InitializeComponent();
            txtPassword.PasswordChar = (char)0x25CF;
            txtConfirmPassword.PasswordChar = (char)0x25CF;
        }
                frmSearch search = new frmSearch();

        clsCashierDetails objCashierDetails = new clsCashierDetails();

        private static frmCashierDetails CashierDetails;

        public static frmCashierDetails GetCashierDetails
        {
            get
            {
                return CashierDetails;
            }
            set
            {
                CashierDetails = value;
            }
        }

        private void LoadCombo()
        {
            objCashierDetails.dsName = "tb_CashierDetails";
            objCashierDetails.SqlStatement = "select User_Name from tb_CashierDetails; SELECT Member FROM tb_MemberSecLevel";
            objCashierDetails.RetriveData();
            cmbCashier.Items.Clear();
            cmbMemberSecLevel.Items.Clear();
            foreach (DataRow row in objCashierDetails.ResultSet.Tables["tb_CashierDetails"].Rows)
            {
                cmbCashier.Items.Add(row["User_Name"]);
                
            }

            foreach (DataRow row in objCashierDetails.ResultSet.Tables["tb_CashierDetails1"].Rows)
            {
                cmbMemberSecLevel.Items.Add(row["Member"]);
                
            }
           
        }


        private void frmCashierDetails_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCombo();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCashierDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CashierDetails = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCashierDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide the form...
                this.Hide();

                // Cancel the close...
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCashier.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Cashier Name Not Found", "Cashier Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCashier.Focus();
                    return;
                }
                if (txtRfndLimit.Text=="")
                {
                    txtRfndLimit.Text = "0";
                }
                if (txtDisplayName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Display Name Not Found", "Display Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDisplayName.Focus();
                    return;
                }

                if (txtPassword.Text.Trim().ToUpper() != txtConfirmPassword.Text.Trim().ToUpper())
                {
                    MessageBox.Show("The Password was Not Correctly Confirmed. Please Check Password and Confirmed Password are Match exactly.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtPassword.Focus();
                    return;
                }

                if (txtPassword.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Display Name Not Found", "Display Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDisplayName.Focus();
                    return;
                }

                if (clsValidation.isNumeric(txtPassword.Text, System.Globalization.NumberStyles.Float) == false)
                {
                    MessageBox.Show("Invalid Password. Please Enter Numaric Value Only", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtPassword.Focus();
                    return;
                }
                objCashierDetails.DisplayName = txtDisplayName.Text.ToUpper();
                objCashierDetails.Password = txtPassword.Text.Trim();
                if (chkCancel.Checked == true)
                {
                    objCashierDetails.Cancel = "T";
                }
                else
                {
                    objCashierDetails.Cancel = "F";
                }

                if (chkRefund.Checked == true)
                {
                    objCashierDetails.Refund = "T";
                }
                else
                {
                    objCashierDetails.Refund = "F";
                }

                if (chkCashRefund.Checked == true)
                {
                    objCashierDetails.Cash_Refund = "T";
                }
                else
                {
                    objCashierDetails.Cash_Refund = "F";
                }
                if (chkCashOut.Checked == true)
                {
                    objCashierDetails.Cash_Out = "T";
                }
                else
                {
                    objCashierDetails.Cash_Out = "F";
                }

                if (chkDiscountAllow.Checked == true)
                {
                    objCashierDetails.Discount_All = "T";
                    objCashierDetails.Discount = decimal.Parse(txtDiscount.Text);
                }
                else
                {
                    objCashierDetails.Discount_All = "F";
                    objCashierDetails.Discount = 0;
                }

                if (chkDepartmentSale.Checked == true)
                {
                    objCashierDetails.Dept_Allow = "T";
                }
                else
                {
                    objCashierDetails.Dept_Allow = "F";
                }

                if (chkDayEndRep.Checked == true)
                {
                    objCashierDetails.Dept_Allow = "T";
                }
                else
                {
                    objCashierDetails.Dept_Allow = "F";
                }

                if (chkDayEndRep.Checked == true)
                {
                    objCashierDetails.DayEndRep = "T";
                }
                else
                {
                    objCashierDetails.DayEndRep = "F";
                }

                if (chkBillCopy.Checked == true)
                {
                    objCashierDetails.BillCopy = "T";
                }
                else
                {
                    objCashierDetails.BillCopy = "F";
                }
                //Minda
                if (chkNotIssue.Checked == true)
                {
                    objCashierDetails.CrNoteIssue = "T";
                }
                else
                {
                    objCashierDetails.CrNoteIssue = "F";
                }
                //******************
                if (chkGiftIssue.Checked == true)
                {
                    objCashierDetails.GiftVoucherIssue = "T";
                }
                else
                {
                    objCashierDetails.GiftVoucherIssue = "F";
                }
                //*****************
                if (chkSaleAmtDply.Checked == true)
                {
                    objCashierDetails.SalesAmtDiply = "T";
                }
                else
                {
                    objCashierDetails.SalesAmtDiply = "F";
                }

                objCashierDetails.CashierName = cmbCashier.Text.ToUpper();
                objCashierDetails.Password = txtPassword.Text.Trim();
                objCashierDetails.DisplayName = txtDisplayName.Text.ToUpper();
                objCashierDetails.ADisCashier = chkDisableCashier.Checked;
                objCashierDetails.AsecLevel = cmbMemberSecLevel.Text.Trim();
                objCashierDetails.RefundLimit = decimal.Parse(txtRfndLimit.Text.Trim());
                //objCashierDetails.CrNoteIssue = chkNotIssue.Checked;

                objCashierDetails.UpdateCashierDetails();
                MessageBox.Show("Cashier Created Successfully.", "Cashier Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear.PerformClick();
                LoadCombo();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            try
            {
                this.Close();
                this.Dispose();
                CashierDetails = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbCashier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && cmbCashier.Text.Trim() != "")
                {
                    txtDisplayName.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDisplayName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtDisplayName.Text.Trim() != "")
                {
                    txtPassword.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtPassword.Text.Trim() != "")
                {
                    txtConfirmPassword.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void chkDiscountAllow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDiscountAllow.Checked == true)
                {
                    txtDiscount.Enabled = true;
                }
                else
                {
                    txtDiscount.Text = "0";
                    txtDiscount.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbCashier_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //objCashierDetails.SqlStatement = "select Emp_Name, User_Name, Pass_Word,  Cancel, Refund, Cash_Refund, Cash_Out, Discount_All,  convert(decimal,Discount) Discount, Dept_Allow, DayEndRep, BillCopy from tb_CashierDetails where User_Name = '" + cmbCashier.Text.Trim() + "'";
                objCashierDetails.SqlStatement = "SELECT Emp_Name, User_Name, Pass_Word,  Cancel, Refund, Cash_Refund, Cash_Out, Discount_All,  convert(decimal,Discount) Discount, Dept_Allow, DayEndRep, BillCopy, Disables, MSL.Member,CrNoteIssue, GiftVoucherIssue, SaleValue, RefundLimit FROM tb_CashierDetails  CD INNER JOIN tb_MemberSecLevel MSL ON CD.Sec_Level = MSL.SecLevel WHERE User_Name = '" + cmbCashier.Text.Trim() + "'";
                objCashierDetails.ReadCashierDetails();
                if (objCashierDetails.RecordFound == true)
                {
                    txtPassword.Text = txtConfirmPassword.Text = objCashierDetails.Password.ToString();
                    txtDisplayName.Text = objCashierDetails.DisplayName.ToString();
                    cmbMemberSecLevel.Text = objCashierDetails.AsecLevel;
                    if (objCashierDetails.Cancel == "T")
                    {
                        chkCancel.Checked = true;
                        
                    }
                    else
                    {
                        chkCancel.Checked = false;
                    }
                    if (objCashierDetails.Refund == "T")
                    {
                        chkRefund.Checked = true;
                    }
                    else
                    {
                        chkRefund.Checked = false;
                    }

                    if (objCashierDetails.Cash_Refund == "T")
                    {
                        chkCashRefund.Checked = true;
                    }
                    else
                    {
                        chkCashRefund.Checked = false;
                    }

                    if (objCashierDetails.Cash_Out == "T")
                    {
                        chkCashOut.Checked = true;
                    }
                    else
                    {
                        chkCashOut.Checked = false;
                    }

                    if (objCashierDetails.Discount_All == "T")
                    {
                        chkDiscountAllow.Checked = true;
                        txtDiscount.Text = objCashierDetails.Discount.ToString();
                    }
                    else
                    {
                        chkDiscountAllow.Checked = false;
                        txtDiscount.Text = "0";
                    }

                    if (objCashierDetails.Dept_Allow == "T")
                    {
                        chkDepartmentSale.Checked = true;
                    }
                    else
                    {
                        chkDepartmentSale.Checked = false;
                    }

                    if (objCashierDetails.DayEndRep == "T")
                    {
                        chkDayEndRep.Checked = true;
                    }
                    else
                    {
                        chkDayEndRep.Checked = false;
                    }

                    if (objCashierDetails.BillCopy == "T")
                    {
                        chkBillCopy.Checked = true;
                    }
                    else
                    {
                        chkBillCopy.Checked = false;
                    }
                    //**********
                    if (objCashierDetails.CrNoteIssue == "T")
                    {
                        chkNotIssue.Checked = true;
                    }
                    else
                    {
                        chkNotIssue.Checked = false;
                    }
                    //*************
                    if (objCashierDetails.GiftVoucherIssue == "T")
                    {
                        chkGiftIssue.Checked = true;
                    }
                    else
                    {
                        chkGiftIssue.Checked = false;
                    }
                    //***********
                    if (objCashierDetails.SalesAmtDiply == "T")
                    {
                        chkSaleAmtDply.Checked = true;
                    }
                    else
                    {
                        chkSaleAmtDply.Checked = false;
                    }
                    chkDisableCashier.Checked = objCashierDetails.ADisCashier;
                    txtRfndLimit.Text = objCashierDetails.RefundLimit.ToString();
                    string SqlStatement = "SELECT Option_Id FROM tbUserRoleDetails WHERE User_Name='" + LoginManager.UserName + "' AND Option_Id='UNLOCK' AND Allow_Option='T'";
                    objCashierDetails.PublicReader(SqlStatement);
                    if (objCashierDetails.RecordFound == true)
                    {
                        if (objCashierDetails.ADisCashier == true)
                        {
                            chkDisableCashier.Enabled = true;
                        }
                        else
                        {
                            chkDisableCashier.Enabled = true;
                        }
                    }
                    else
                    {
                        if (objCashierDetails.ADisCashier == true)
                        {
                            chkDisableCashier.Enabled = false;
                        }
                        else
                        {
                            chkDisableCashier.Enabled = true;
                        }
                    }
                   
                }
                else
                {

                    chkCancel.Checked = true;
                    chkRefund.Checked = true;
                    chkCashRefund.Checked = true;
                    chkCashOut.Checked = true;
                    chkDiscountAllow.Checked = true;
                    txtDiscount.Text = "0";
                    chkDepartmentSale.Checked = true;
                    chkDayEndRep.Checked = true;
                    chkBillCopy.Checked = true;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (clsValidation.isNumeric(txtDiscount.Text, System.Globalization.NumberStyles.Float) == true && float.Parse(txtDiscount.Text) > 0 && float.Parse(txtDiscount.Text) < 70)
                    {
                        chkDepartmentSale.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Discount Percentage. Please Enter Valid Discount Percentage", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDiscount.Text = "0";
                        txtDiscount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objCashierDetails.CashierName = cmbCashier.Text.ToUpper();
                objCashierDetails.Password = txtPassword.Text.Trim();
                objCashierDetails.DisplayName = txtDisplayName.Text.ToUpper();

                objCashierDetails.DeleteCashierDetails();
                MessageBox.Show("User Deleted Successfully.", "Cashier Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbCashier.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                txtDisplayName.Text = string.Empty;

                chkCancel.Checked = false;
                chkRefund.Checked = false;
                chkCashRefund.Checked = false;
                chkCashOut.Checked = false;
                chkDiscountAllow.Checked = false;
                txtDiscount.Text = "0";
                chkDepartmentSale.Checked = false;
                chkDayEndRep.Checked = false;
                chkBillCopy.Checked = false;
                LoadCombo();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashierDetails 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbCashier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void enabled()
        {
            txtDisplayName.Enabled = true;
            txtPassword.Enabled = true;
            txtConfirmPassword.Enabled = true;
            chkCancel.Enabled = true;
            chkRefund.Enabled = true;
            chkCashRefund.Enabled = true;
            chkCashOut.Enabled = true;
            chkDiscountAllow.Enabled = true;
            chkDepartmentSale.Enabled = true;
            chkDayEndRep.Enabled = true;
            chkBillCopy.Enabled = true;
            chkNotIssue.Enabled = true;
            chkGiftIssue.Enabled = true;
            chkSaleAmtDply.Enabled = true;
            cmbMemberSecLevel.Enabled = true;
            txtDiscount.Enabled = true;
            chkDisableCashier.Enabled = true;
            txtRfndLimit.Enabled = true;
        }

        private void Disable()
        {
            txtRfndLimit.Enabled = false;
            txtDisplayName.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            chkCancel.Enabled = false;
            chkRefund.Enabled = false;
            chkCashRefund.Enabled = false;
            chkCashOut.Enabled = false;
            chkDiscountAllow.Enabled = false;
            chkDepartmentSale.Enabled = false;
            chkDayEndRep.Enabled = false;
            chkBillCopy.Enabled = false;
            chkNotIssue.Enabled = false;
            chkGiftIssue.Enabled = false;
            chkSaleAmtDply.Enabled = false;
            cmbMemberSecLevel.Enabled = false;
            txtDiscount.Enabled = false;
            chkDisableCashier.Enabled=false;
        }
         
        private void chkDisableCashier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisableCashier.Checked==true)
            {
                this.Disable();

            }
            else
            {
                this.enabled();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           this.enabled();
           chkDisableCashier.Checked = false;
            chkCancel.Checked = false;
            chkRefund.Checked = false;
            chkCashRefund.Checked = false;
            chkCashOut.Checked = false;
            chkDiscountAllow.Checked = false;
            chkDepartmentSale.Checked = false;
            chkDayEndRep.Checked = false;
            chkBillCopy.Checked = false;
            chkNotIssue.Checked = false;
            chkGiftIssue.Checked = false;
            chkSaleAmtDply.Checked = false;  
            
            txtDiscount.Text = "0";
            txtDisplayName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cmbMemberSecLevel.Text = "";
            cmbCashier.Text="";
            txtRfndLimit.Text = "0";
            cmbCashier.Focus();
        }
    }
}