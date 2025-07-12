using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using clsLibrary;
using Inventory.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Inventory
{
    public partial class frmCashOut : Form
    {
        public frmCashOut()
        {
            InitializeComponent();
        }

        clsCommon objCashOut = new clsCommon();

        private static frmCashOut CashOut;
        public static frmCashOut GetCashOut
        {
            get { return CashOut; }
            set { CashOut = value; }
        }

        private void frmCashOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            CashOut = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCashOut.Text = "0";
            txtCashIn.Text = "0";
            txtReason.Text = string.Empty;
        }

        private void frmCashOut_Load(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT TempCIO FROM DocumentNoDetails WHERE Loca='" + LoginManager.LocaCode + "'";
                objCashOut.getDataReader(SqlStatement);
                if (objCashOut.Adr.Read())
                {
                    int TempCIO = Convert.ToInt16(objCashOut.Adr["TempCIO"].ToString());
                    lblTempDocNo.Text = "CIO" + LoginManager.LocaCode + string.Format("{0:000000}", TempCIO);
                }

                if (Settings.Default.SaleDateEna == true)
                {
                    dtpDate.Enabled = true;
                }
                else
                {
                    dtpDate.Enabled = false;
                }
                SqlStatement = "UPDATE DocumentNoDetails SET TempCIO=TempCIO+1 WHERE Loca='" + LoginManager.LocaCode + "'";
                objCashOut.getDataReader(SqlStatement);

                txtCashIn.Enabled = false;
                txtCashOut.Enabled = false;

                if (objCashOut.CheckUnit().Tables[0].Rows.Count > 0)
                {
                    LoginManager.MachineUnit = Convert.ToInt32(objCashOut.Ads.Tables[0].Rows[0][0]);
                    //lblUnit.Text = lblUnit.Text + LoginManager.MachineUnit;
                }
                else
                {
                    MessageBox.Show("Invalid Unit", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void rbCashIN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCashIN.Checked == true)
                {
                    txtCashIn.Focus();
                    txtCashOut.Enabled = false;
                    txtCashIn.Enabled = true;
                    txtCashIn.Text = "0.00";
                    txtCashOut.Text = "0.00";
                }
                else if (rbCashOUT.Checked == true)
                {
                    txtCashOut.Focus();
                    txtCashOut.Enabled = true;
                    txtCashIn.Enabled = false;
                    txtCashIn.Text = "0.00";
                    txtCashOut.Text = "0.00";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCashIn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReason.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCashOut_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReason.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (rbCashIN.Checked == true)
                {
                    if (Convert.ToDecimal(txtCashIn.Text.Trim()) == 0)
                    {
                        MessageBox.Show("Please enter a Cash IN amount.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCashIn.Focus();
                        return;
                    }
                }
                if(rbCashOUT.Checked==true)
                {
                    if(Convert.ToDecimal(txtCashOut.Text.Trim()) == 0)
                    {
                        MessageBox.Show("Please enter as Cash OUT amount.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCashOut.Focus();
                        return;
                    }
                }

                if (MessageBox.Show("Do you want to save this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                     
                    string SqlStatement = "EXEC sp_CashINOUTSave '" + dtpDate.Text.Trim() + "', '" + LoginManager.LocaCode + "', " + Convert.ToDecimal(txtCashIn.Text.Trim()) + ", " + Convert.ToDecimal(txtCashOut.Text.Trim()) + ", '" + txtReason.Text.Trim() + "', '" + LoginManager.UserName + "','"+LoginManager.MachineUnit+"'";
                    objCashOut.getDataReader(SqlStatement);
                    if (objCashOut.Adr.Read())
                    {
                        string OrgDocNo = objCashOut.Adr["DocNo"].ToString();
                        MessageBox.Show("Record Saved Successfully " + OrgDocNo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCashIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objCashOut.CheckNumeric(e, txtCashIn.Text);

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCashOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objCashOut.CheckNumeric(e, txtCashOut.Text);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void rbCashOUT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCashOUT.Checked == true)
                {
                    txtCashOut.Focus();
                    txtCashOut.Enabled = true;
                    txtCashIn.Enabled = false;
                    txtCashIn.Text = "0.00";
                    txtCashOut.Text = "0.00";

                }
                else if (rbCashIN.Checked == true)
                {
                    txtCashIn.Focus();
                    txtCashOut.Enabled = false;
                    txtCashIn.Enabled = true;
                    txtCashIn.Text = "0.00";
                    txtCashOut.Text = "0.00";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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