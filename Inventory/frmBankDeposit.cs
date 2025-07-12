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
    public partial class frmBankDeposit : Form
    {
        public frmBankDeposit()
        {
            InitializeComponent();
        }

        clsCommon objBankDeposit = new clsCommon();
        frmSearch search = new frmSearch();
        private frmPaymentSearch PaymentSearch = new frmPaymentSearch();
        

        private static frmBankDeposit BankDiposit;

        public static frmBankDeposit getBankDiposit
        {
            get { return BankDiposit; }
            set { BankDiposit = value; }
        }

        private void txtDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtBankcode.Focus();
            }
        }

        private void txtBankcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.F1)
                //{
                //   // btnBankNameSearch.PerformClick();
                //}

                //if (e.KeyCode == Keys.Enter)
                //{
                //   // txtBankName.Focus();

                //    string SqlStatement = " select Bank_Code,Bank_Name,Branch_ACNo from tb_BankDeposit where Bank_Code = '" + txtBankcode.Text.Trim() + "'";
                //    objBankDeposit.getDataReader(SqlStatement);

                //    if (objBankDeposit.Adr.Read())
                //    {
                //        //txtBankName.Text = objBankDeposit.Adr["Bank_Name"].ToString();
                //        txtBranchACN.Text = objBankDeposit.Adr["Branch_ACNo"].ToString();
                         

                //    }
                //}
            }


            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBranchACN.Focus();
            }
        }

        private void txtBranchACN_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                txtBranchACNDis.Focus();
            }
        }

        private void txtBranchACNDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSlipNo.Focus();
            }
        }

         

        private void txtSlipNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmemo.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChequeNo.Focus();
            }
        }

      

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbChequeBank.Enabled == false)
                {
                    cmbBankNames.Focus();
                }
                else
                {
                    cmbChequeBank.Focus();
                }
                
            }
            if (e.KeyCode == Keys.F1)
            {
                btnThirdPartyCheque.PerformClick();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            try
            {
                this.Close();
                this.Dispose();
                BankDiposit = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmBankDeposit_Load(object sender, EventArgs e)
        {
            Load_Details();
        }

        private void Load_Details()
        {
            try
            {
                cmbType.SelectedIndex = -1;

                objBankDeposit.getDataSet("SELECT Bank_Name FROM BankDetails ORDER BY Bank_Code", "BankDetails");
                cmbChequeBank.DataSource = objBankDeposit.Ads.Tables["BankDetails"];
                cmbChequeBank.DisplayMember = "Bank_Name";

                objBankDeposit.getDataSet("SELECT Bank_Name FROM BankDetails ORDER BY Bank_Code", "BankDetails2");
                cmbBankNames.DataSource = objBankDeposit.Ads.Tables["BankDetails2"];
                cmbBankNames.DisplayMember = "Bank_Name";

                cmbBankNames.Text = "";
                cmbChequeBank.Text = "";

                string SqlStatement = " select Diposit from DocumentNoDetails where Loca= '" + LoginManager.LocaCode + "'";
                objBankDeposit.getDataReader(SqlStatement);
                if (objBankDeposit.Adr.Read())
                {
                    string s = objBankDeposit.Adr["Diposit"].ToString();
                    txtDocNo.Text = "DEP" + LoginManager.LocaCode + string.Format("{0:000000}", decimal.Parse(objBankDeposit.Adr["Diposit"].ToString()));
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void frmBankDeposit_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                BankDiposit = null;

                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Type is not Selected", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbType.Focus();
                    return;
                }
                if (cmbMode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Mode is not Selected", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbType.Focus();
                    return;
                }

                if (cmbMode.Text == "CASH")
                {
                    if (txtSlipNo.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(" Slip No is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSlipNo.Focus();
                        return;
                    }
                }
                if (cmbMode.Text == "CHEQUE")
                {
                    if (txtChequeNo.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Cheque No is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtChequeNo.Focus();
                        return;
                    }
                    if (cmbChequeBank.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Cheque Bank is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbChequeBank.Focus();
                        return;
                    }
                }

                //if (cmbBank.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Bank code is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //txtBankcode.Focus();
                //    return;
                //}
                
                if (txtBranchACNDis.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Branch & A/C No is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBranchACN.Focus();
                    return;
                }
                                
                if (txtAmount.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Amount is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmount.Focus();
                    return;
                }

                //objBankDeposit.Recordfind("SELECT Post_Date FROM tb_DailySummaryLog WHERE Post_Date='" + dtpDate.Text + "'");
                //if (objBankDeposit.RecordFind == true)
                //{
                //    MessageBox.Show("Access Denied.Becouse Daily Summary processed !.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                
                    if (MessageBox.Show("Do You Want To Apply ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sqlStatement = "EXEC sp_BankDeposit '" + txtDocNo.Text.Trim() + "','" + cmbBankNames.Text.Trim() + "','" + cmbBankNames.Text.Trim() + "','" + dtpDate.Text.Trim() + "','" + txtBranchACN.Text.Trim() + "','" + txtBranchACNDis.Text.Trim() + "','" + cmbType.Text.Trim() + "','" + txtSlipNo.Text.Trim() + "'," + Convert.ToDecimal(txtAmount.Text.Trim()) + ",'" + cmbChequeBank.Text.Trim() + "','" + txtChequeNo.Text.Trim() + "','" + txtmemo.Text.Trim() + "','" + LoginManager.UserName + "','" + LoginManager.LocaCode + "','" + cmbMode.Text.Trim() + "'";
                        objBankDeposit.getDataReader(sqlStatement);
                        txtDocNo.Text = string.Empty;

                        MessageBox.Show("Record Saved Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
               
                 
                txtDocNo.Focus();
                cmbType.Text = string.Empty;
                cmbMode.Text = string.Empty;
                //cmbBank.Text="";
                cmbChequeBank.Text="";
                txtBranchACN.Clear();
                txtBranchACNDis.Clear();
                txtSlipNo.Clear();
                txtAmount.Clear();
                txtChequeNo.Clear();
                txtmemo.Clear();
                cmbType.Focus();
                Load_Details();
                //DataSet dsDataForReport = new DataSet();
                //clsReportViewer objRepView = new clsReportViewer();
                //clsSalesInquary objSalesInquary = new clsSalesInquary();

                //frmReportViewer objRepViewer = new frmReportViewer();

                //objRepView.SqlStatement = "SELECT Document_No,Post_Date,Bank_Code,Bank_Name,Branch_ACNo,Type,Slip_No,Amount,Bank,Cheque_No,Memo FROM tb_BankDeposit where Document_No = '" + txtDocNo.Text.Trim() + "'";
                //objRepView.DataSetName = "dsBankDeposit";
                //objRepView.RetrieveData();
                //dsDataForReport = objRepView.TempResultSet;
                //objRepViewer.VirtuaReport = new rptBankDeposit();
                //objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                //objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;

                //objRepViewer.Show();

                this.Close();

                frmBankDeposit.BankDiposit = new frmBankDeposit();
                frmBankDeposit.BankDiposit.MdiParent = MainClass.mdi;
                frmBankDeposit.BankDiposit.Show();


                


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtBranchACNDis_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMode.Focus();
            }
        }

        

        private void btnBankNameSearch_Click(object sender, EventArgs e)
        {
            try
            {

                //if (search.IsDisposed)
                //{
                //    search = new frmSearch();
                //}

                //string SqlStatement = "";
                //if (txtBankcode.Text.Trim() != string.Empty)
                //{
                //    SqlStatement = "SELECT Bank_Code [Bank Code], Bank_Name [Bank Name] FROM BankDetails WHERE Bank_Code LIKE '%" + txtBankcode.Text.Trim() + "%'  ORDER BY Bank_Code";
                //}
                //else
                //{
                //    if (txtBankName.Text.Trim() != string.Empty)
                //    {
                //        SqlStatement = "SELECT Bank_Code [Bank Code], Bank_Name [Bank Name] FROM BankDetails WHERE Bank_Code LIKE '%" + txtBankName.Text.Trim() + "%'  ORDER BY Bank_Code";
                //    }
                //    else
                //    {
                //        SqlStatement = "SELECT Bank_Code [Bank Code], Bank_Name [Bank Name] FROM BankDetails order by Bank_Code";

                //    }
                //}


                //objBankDeposit.getDataSet(SqlStatement, "dsBankDeposit");

                //search.dgSearch.DataSource = objBankDeposit.Ads.Tables["dsBankDeposit"];
                //search.prop_Focus = txtBankcode;
                //search.Cont_Descript = txtBankName;
                //search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            //txtChequeNo.Enabled = true;
            //cmbChequeBank.Enabled = true;
            //btnThirdPartyCheque.Enabled = true;
            if (cmbType.Text == "DEPOSITS")
            {
                if (cmbMode.SelectedIndex == 0)
                {
                    txtChequeNo.Enabled = false;
                    cmbChequeBank.Enabled = false;
                    btnThirdPartyCheque.Enabled = false;
                }
                else
                {
                    txtChequeNo.Enabled = true;
                    cmbChequeBank.Enabled = true;
                    btnThirdPartyCheque.Enabled = true;
                } 
            }
            else
            {
                txtChequeNo.Enabled = true;
                cmbChequeBank.Enabled = true;
                btnThirdPartyCheque.Enabled = true;
            }
            
        }

        
        private void cmbChequeBank_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cmbBankNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SqlStatement = "SELECT Acc_No [Account No], Bank_Branch [Branch] FROM tbBankAccounts INNER JOIN BankDetails ON tbBankAccounts.Bank_Code=BankDetails.Bank_Code WHERE BankDetails.Bank_Name ='" + cmbBankNames.Text.Trim() + "'";
            objBankDeposit.getDataReader(SqlStatement);
            if (objBankDeposit.Adr.Read() && cmbType.Text!="")
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                SqlStatement = "SELECT Acc_No [Account No], Bank_Branch [Branch] FROM tbBankAccounts INNER JOIN BankDetails ON tbBankAccounts.Bank_Code=BankDetails.Bank_Code WHERE BankDetails.Bank_Name ='" + cmbBankNames.Text.Trim() + "'  ORDER BY BankDetails.Bank_Code";
                objBankDeposit.getDataSet(SqlStatement, "dsBank");
                search.dgSearch.DataSource = objBankDeposit.Ads.Tables["dsBank"];
                search.prop_Focus = txtBranchACNDis;
                search.Cont_Descript = txtBranchACN;
                search.Show();
            }
        }

        private void cmbMode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void cmbChequeBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBankNames.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                btnThirdPartyCheque.PerformClick();
            }
        }

        private void cmbBankNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBranchACN.Focus();
            }
        }
        private void btnThirdPartyCheque_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbMode.Text!="CHEQUE")
                //{
                //    MessageBox.Show("First Select Mode !", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbMode.Focus();
                //    return;
                //}
                if (PaymentSearch.IsDisposed)
                {
                    PaymentSearch = new frmPaymentSearch();
                }
                objBankDeposit.getDataSet("SELECT TC.Bank_Name,TC.Branch,TC.Cheque_Date,TC.Cheque_No,TC.Amount,C.Cust_Name FROM tbThirdPartyCheque TC LEFT JOIN Customer C On TC.Received_Acc_Code=C.Cust_Code WHERE TC.IssuedStatus='F' AND TC.Return_Status='F' AND TC.Loca='" + LoginManager.LocaCode + "' ORDER BY CONVERT(DATETIME,TC.Cheque_Date,103)", "dsSupplier");
                PaymentSearch.dgSearch.DataSource = objBankDeposit.Ads.Tables["dsSupplier"];
                PaymentSearch.Value1 = txtAmount;
                PaymentSearch.Value2 = cmbChequeBank;
                PaymentSearch.Value3 = null;
                PaymentSearch.Value4 = txtChequeNo;
                PaymentSearch.Value5 = null;
                PaymentSearch.Show();               
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }            
        }

        private void txtChequeNo_Enter(object sender, EventArgs e)
        {
            

        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            if (PaymentSearch.Amount != null && PaymentSearch.Amount != "")
            {
                cmbMode.Enabled = false;
                txtAmount.ReadOnly = true;
                cmbChequeBank.Enabled = false;
                txtChequeNo.ReadOnly = true;
            }
        }

        private void frmBankDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
                if (e.Control == true)
                {

                    if (e.KeyCode == Keys.A)
                    {
                        this.btnApply.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.E)
                        {
                            this.btnExit.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMode.Enabled = true;
            txtAmount.ReadOnly = false;
            cmbChequeBank.Enabled = true;
            txtChequeNo.ReadOnly = false;

            txtChequeNo.Text = "";
            cmbChequeBank.Text = "";
            btnThirdPartyCheque.Enabled = true;
            cmbBankNames.Text = "";
            txtBranchACN.Text = "";
            txtBranchACNDis.Text = "";
            txtSlipNo.Text = "";
            txtmemo.Text = "";
            txtAmount.Text = "";
            cmbMode.Text = "";

            PaymentSearch.Amount = null;

            if (cmbType.Text=="DIPOSIT")
            {
                if (cmbMode.Text == "CASH")
                {
                    txtChequeNo.Enabled = false;
                    cmbChequeBank.Enabled = false;
                    btnThirdPartyCheque.Enabled = false;
                }
                else if (cmbMode.Text == "CHEQUE")
                {
                    txtChequeNo.Enabled = true;
                    cmbChequeBank.Enabled = true;
                    btnThirdPartyCheque.Enabled = true;
                }
                else
                {
 
                }
            }
            else if (cmbType.Text == "WITHDRAWALS")
            {
                txtChequeNo.Enabled = true;
                cmbChequeBank.Enabled = true;
                btnThirdPartyCheque.Enabled = true;     
            }

            
        }

     

       

        

        
    }
}