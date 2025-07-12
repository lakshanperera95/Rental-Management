using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
using MetroFramework;
using System.Net;
using System.Web.Script.Serialization;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmPayment : Form
    {
        bool Loaded = false;
        static string FType;
        public frmPayment(string Balance,string Paytype,string DocNO,string CustCode,string FTyp)
        {
            InitializeComponent();
            
            lblPayAmount.Text = lblPayBalance.Text = Balance;
            lblInvPaytype.Text = Paytype;
            lblDocNo.Text = DocNO;
            lblCustCode.Text = CustCode;

            FType = FTyp;

          
            
        }
        public string frmState = "";
        public decimal PayedAmount = 0, BalanceAmount = 0;
        public string LoyalityCard = "";
        clsCommon ObjComman = new clsCommon();
        private void frmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT Name[Mode],Cash,Ctype,BType,RType FROM dbo.Pay_Settings WHERE FType='" + FType + "' and code like '%"+lblInvPaytype.Text.Trim()+"%';SELECT Bank_Name[Bank] FROM dbo.BankDetails;SELECT Name[Mode] FROM dbo.Pay_Settings WHERE FType='Ctype';DELETE FROM tbPaymentDetails WHERE Temp_DocNo = '" + lblDocNo.Text + "' AND Loca='" + LoginManager.LocaCode + "'";

                ObjComman.getDataSet(SqlStatement, "ds");
                grdPaytypes.DataSource = ObjComman.Ads.Tables[0];

                grdPaytypes.Columns[1].Visible = false;
                grdPaytypes.Columns[2].Visible = false;
                grdPaytypes.Columns[3].Visible = false;
                grdPaytypes.Columns[4].Visible = false;

                cmbBankName.DataSource = ObjComman.Ads.Tables[1];
                cmbBankName.DisplayMember = "Bank";

                cmbCardTypes.DataSource = ObjComman.Ads.Tables[2];
                cmbCardTypes.DisplayMember = "Mode";

                txtRecPayment.Enabled = false;

                //if (lblInvPaytype.Text == "CASH")
                //{
                //    btnSinglePay.PerformClick();

                //    btnMultipay.Enabled = false;
                //    grdPaytypes.Enabled = false;

                //    lblPayType.Text = lblInvPaytype.Text;
                //    vsblCrType(false);
                //    EnableFields(true);
                //    txtRecPayment.Enabled = true;
                //    txtRecPayment.SelectAll();
                //    txtRecPayment.Focus();
                //}


                if (lblInvPaytype.Text == "CASH")
                {
                    btnSinglePay.PerformClick();
                    lblPayType.Text = lblInvPaytype.Text;
                    txtRecPayment.Enabled = true;
                    cmbBankName.Enabled = cmbCardTypes.Enabled = false;                    
                    txtRecPayment.Focus();
                    txtRecPayment.SelectAll();
                }
               



                //grdPaytypes_CellClick(new object(), new DataGridViewCellEventArgs(0, 0));

               

            }
            catch (Exception ex)
            {
               
                clsClear.ErrMessage(ex.Message, ex.StackTrace);

            }
            finally
            {
               this.ActiveControl = txtRecPayment;
            }
        }

        private void lblPayType_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearPayments();
            frmState = "Closed";
            BalanceAmount = decimal.Parse(lblPayBalance.Text);
            PayedAmount = 0;

            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

            if (txtRecPayment.Text.Trim() == string.Empty)
            {
                txtRecPayment.Text = "0";
            }

            if (btnMultipay.Enabled == false)
            {
                if (Convert.ToDecimal(txtRecPayment.Text.Trim()) < Convert.ToDecimal(lblPayAmount.Text.Trim()))
                {
                    MetroMessageBox.Show(this, "Invalid Payment Amount", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 100);
                    txtRecPayment.Focus();
                    return;
                }
            }

            if (txtLoyalityCard.Text.Trim() != string.Empty)
            {
                ObjComman.SqlStatement = "SELECT * FROM dbo.CRM_Customer WHERE (Card_No='" + txtLoyalityCard.Text.Trim() + "' OR cus_Code='" + txtLoyalityCard.Text.Trim() + "' or mobile='" + txtLoyalityCard.Text.Trim() + "' )AND Cust_Category='Loyalty customer'";

                ObjComman.GetDs();
                if (ObjComman.Ads.Tables[0].Rows.Count == 0)
                {
                    txtLoyalityCard.Text = string.Empty;
                    if (MetroMessageBox.Show(this, "Invalid loyality card number.. Do you want to Contineu", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, 100) == DialogResult.No)
                    {

                        txtLoyalityCard.Focus();
                        return;
                    }

                }
                 
            }
            //-----UPDATE RECORD FOR SINGLE PAYMENT----------
            if (dataGridViewPayments.Visible == false)
            {
                ClearPaymentsGrid();

                decimal PayAmount = 0;

                PayAmount = decimal.Parse(txtRecPayment.Text.Trim());


                txtRecPayment.Text = PayAmount.ToString();
                bool Success = false;
                AddPayment("Single", ref Success);
                if (Success == false)
                    return;
                //    btnAdd_Click(sender, e);
                //txtRecPayment.Text = txtPayBalance.Text = (Convert.ToDecimal(lblPayBalance.Text.Trim()) - Convert.ToDecimal(txtTotalPayed.Text.Trim())).ToString("N2");

                BalanceAmount = decimal.Parse(txtRecPayment.Text.Trim()) - decimal.Parse(txtPayBalance.Text.Trim());
                PayedAmount = decimal.Parse(txtRecPayment.Text);

            }
            else
            {
                BalanceAmount = decimal.Parse(txtPayBalance.Text);
                PayedAmount = decimal.Parse(txtTotalPayed.Text);
            }
            //------------------------------------------------

            string sqlst = "SELECT * FROM dbo.tbPaymentDetails WHERE  Temp_DocNo='" + lblDocNo.Text.Trim() + "' AND Payment_Mode='REWARD' AND Loca='" + LoginManager.LocaCode + "'";

            ObjComman.SqlStatement = sqlst;
            ObjComman.GetDs();
            if (ObjComman.Ads.Tables[0].Rows.Count > 0 && TransNo!="")
            {
                if (UpdateApiLast() == false)
                {
                    MessageBox.Show("Error In point Redeem", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (Settings.Default.AllowCreditbill == false)
            {
                if (Convert.ToDecimal(txtPayBalance.Text.Trim()) > 0)
                {
                    MessageBox.Show("Credit Billing Not Allow", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //if (Comp == true)
            {
                LoyalityCard = txtLoyalityCard.Text.Trim();
                frmState = "Finish";
                this.Close();
            }
        }

        clsWholeSaleInvoice objWholeInvoice = new clsWholeSaleInvoice();
        public void ClearPayments()
        {
            try
            {
                objWholeInvoice.SqlStatement = "DELETE FROM tbPaymentDetails WHERE Temp_DocNo = '" + lblDocNo.Text + "' AND Loca='" + LoginManager.LocaCode + "'";
                objWholeInvoice.DataetName = "ds";
                objWholeInvoice.GetItemDetails();

                dataGridViewPayments.DataSource = null;
                dataGridViewPayments.Refresh();

                txtTotalPayed.Text = "0.00";
                txtPayBalance.Text = lblPayAmount.Text;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        public void ClearPaymentsGrid()
        {
            try
            {
                objWholeInvoice.SqlStatement = "DELETE FROM tbPaymentDetails WHERE Temp_DocNo = '" + lblDocNo.Text + "' AND Loca='" + LoginManager.LocaCode + "'";
                objWholeInvoice.DataetName = "ds";
                objWholeInvoice.GetItemDetails();

                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        private void btnSinglePay_Click(object sender, EventArgs e)
        {
            try
            {
                btnCLear.PerformClick();
                dataGridViewPayments.Visible = btnAdd.Visible=false;

                lblTotPayed.Location = new Point(339, 232);
                txtTotalPayed.Location= new Point(483, 231);

                if (btnMultipay.Enabled == false)
                {
                    lblPayType.Text = "CASH";
                    txtRecPayment.SelectAll();
                    txtRecPayment.Focus();


                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnMultipay_Click(object sender, EventArgs e)
        {
            try
            {
                btnCLear.PerformClick();
                dataGridViewPayments.Visible = btnAdd.Visible  = true;


               
                lblTotPayed.Location = new Point(339, 335);
                txtTotalPayed.Location = new Point(483, 334);

               

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ClearPayments();
            lblPayType.Text = "XXXX";
            lblPayDiscount.Text=txtTotalPayed.Text = "0.00";
            txtBranchName.Text = txtChequeNo.Text = cmbBankName.Text = cmbCardTypes.Text = string.Empty;
            txtRecPayment.Text = txtPayBalance.Text = lblPayAmount.Text = lblPayBalance.Text;
            cmbCardTypes.SelectedIndex = cmbCardTypes.SelectedIndex = -1;
        }

        public void EnableFields(bool State)
        {
            txtBranchName.Text = txtChequeNo.Text = cmbBankName.Text = cmbCardTypes.Text = string.Empty;
            cmbCardTypes.SelectedIndex = cmbCardTypes.SelectedIndex = -1;
            if (State == true)
            {
                txtBranchName.Enabled = txtChequeNo.Enabled = cmbCardTypes.Enabled = dtpChequeDate.Enabled = cmbBankName.Enabled = false;
                txtRecPayment.SelectAll();
                txtRecPayment.Focus();
            }
            else
            { 
                txtBranchName.Enabled = txtChequeNo.Enabled = cmbCardTypes.Enabled = dtpChequeDate.Enabled = cmbBankName.Enabled = true;
             //   cmbBankName.DroppedDown = true;
                cmbBankName.Focus();
            }
          
        }

        public void EnableFieldsRedeem(bool State)
        {
            txtBranchName.Text = txtChequeNo.Text = cmbBankName.Text = cmbCardTypes.Text = string.Empty;
            cmbCardTypes.SelectedIndex = cmbCardTypes.SelectedIndex = -1;
            
            if (State == true)
            {
                txtBranchName.Enabled =   cmbCardTypes.Enabled = dtpChequeDate.Enabled = cmbBankName.Enabled=txtChequeNo.Enabled = false;
                txtBranchName.Enabled = true;
                lblBranch.Text = "CARD NO";
                txtBranchName.Focus();


               
            }
          

        }


        public void vsblCrType(bool state)
        {
            if (state == true)
            {

                cmbCardTypes.Visible = true;
                txtBranchName.Visible = false;
                lblBranch.Text = "Card Type";
                lblCheqNo.Text = "Card No";
            }
            else
            {
                cmbCardTypes.Visible = false;
                txtBranchName.Visible = true;
                lblBranch.Text = "Branch Name";
                lblCheqNo.Text = "Cheque No";


            }

            if(lblPayType.Text=="BANK TRANSFER")
            {
                lblBranch.Text = "Branch Name";
                lblCheqNo.Text = "Slip No";
            }
        }
        public void vsblBtnType(bool state)
        {
            if (state == true)
            {
                txtBranchName.SendToBack();
                cmbCardTypes.BringToFront();
                lblBranch.Text = "Card Type";
            }
            else
            {
                txtBranchName.BringToFront();
                cmbCardTypes.SendToBack();
                lblBranch.Text = "Branch Name";

            }
        }
        private void grdPaytypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                
                vsblCrType(Convert.ToBoolean(grdPaytypes.Rows[e.RowIndex].Cells[2].Value.ToString()));
                EnableFields(Convert.ToBoolean(grdPaytypes.Rows[e.RowIndex].Cells[1].Value.ToString()));
                txtRecPayment.Enabled = true;

                if (Convert.ToBoolean(grdPaytypes.Rows[e.RowIndex].Cells[3].Value.ToString()) == true)
                { BtnAdv.Visible = true; }
                else
                { BtnAdv.Visible = false; }

                EnableFieldsRedeem(Convert.ToBoolean(grdPaytypes.Rows[e.RowIndex].Cells[4].Value.ToString()));

                lblPayType.Text = grdPaytypes.Rows[e.RowIndex].Cells[0].Value.ToString();
                //Added by Kalani
                if (lblPayType.Text == "RETURN")
                {
                    BtnAdv.Text = "RTN";
                }
                else
                {
                    BtnAdv.Text = "ADV";
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        frmSearch search = new frmSearch();
        private void BtnAdv_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPayType.Text=="ADVANCE")
                {

                    if (search.IsDisposed)
                    {
                        search = new frmSearch();
                    }

                    objWholeInvoice.SqlStatement = "SELECT Balance_Amount[Amount],Doc_No[Advance No] FROM dbo.Payment_Summary WHERE Acc_No='" + lblCustCode.Text.Trim() + "' AND Tr_Type='CADV' AND Balance_Amount>0 and Loca='" + LoginManager.LocaCode + "' ";
                    objWholeInvoice.DataetName = "Table";
                    objWholeInvoice.GetItemDetails();
                    search.Ismdi = false;
                    search.dgSearch.DataSource = objWholeInvoice.GetItemDataset.Tables["Table"];
                    search.prop_Focus = txtRecPayment;
                    search.Cont_Descript = txtChequeNo;
                    search.ShowDialog();

          

                    txtRecPayment.Focus();

                }

                if (lblPayType.Text == "POINTS")
                {

                    if (search.IsDisposed)
                    {
                        search = new frmSearch();
                    }

                    objWholeInvoice.SqlStatement = "SELECT Balance[Amount],Cus_Code[Advance No] FROM dbo.CRM_Customer" +
                        " WHERE Cus_Code='" + lblCustCode.Text.Trim() + "'  ";
                    objWholeInvoice.DataetName = "Table";
                    objWholeInvoice.GetItemDetails();
                    search.Ismdi = false;
                    search.dgSearch.DataSource = objWholeInvoice.GetItemDataset.Tables["Table"];
                    search.prop_Focus = txtRecPayment;
                    search.Cont_Descript = txtChequeNo;
                    search.ShowDialog();
                    txtRecPayment.Focus();

                }

                if (lblPayType.Text == "REWARD")
                {
                    

                    txtRecPayment.Text = "100.00";
                  
                }
                if (lblPayType.Text == "RETURN")
                {

                    if (search.IsDisposed)
                    {
                        search = new frmSearch();
                    }

                    objWholeInvoice.SqlStatement = "select Balance_Amount[Amount],Doc_No[CreditNote No] from Payment_Summary  where Acc_No ='" + lblCustCode.Text.Trim() + "' AND Tr_Type ='CUR'  AND Balance_Amount>0 and Loca='"+LoginManager.LocaCode+"' ";
                    objWholeInvoice.DataetName = "Table";
                    objWholeInvoice.GetItemDetails();
                    search.Ismdi = false;
                    search.dgSearch.DataSource = objWholeInvoice.GetItemDataset.Tables["Table"];
                    search.prop_Focus = txtRecPayment;
                    search.Cont_Descript = txtChequeNo;
                    search.ShowDialog();



                    txtRecPayment.Focus();

                }

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
                
               
                if (dataGridViewPayments.Visible == true)
                {
                    bool Comp = false;
                    AddPayment("",ref Comp);
                   
                }
                else
                {
                   // AddPayment();
                  //  LoadPaymentDt();
                    txtRecPayment_Leave(new object(), e);
                  //  txtRecPayment.Text = "0.00";
                    btnFinish.Focus();
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
         
        public void AddPayment(string Typep,ref bool Comp)
        {
            try
            {
                
                Comp = false;
                if (lblPayType.Text.Trim() == "XXXX")
                {
                    MessageBox.Show("Select Payment Mode", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecPayment.Focus();
                    return;
                }

                if (decimal.Parse(txtRecPayment.Text) <= 0)
                {
                    MessageBox.Show("Payment Detail Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecPayment.Focus();
                    return;

                }
                if (cmbBankName.Enabled == true)
                {
                    if (cmbBankName.Text == "")
                    {
                        MessageBox.Show("Please Fill Bank Detail", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbBankName.Focus();
                        return;
                    }

                    if (cmbCardTypes.Visible == true && cmbCardTypes.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please Select Card Type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbCardTypes.Focus();
                        return;
                    }
                    if (txtChequeNo.Text == "")
                    {
                        MessageBox.Show("Please Fill Cheque No", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtChequeNo.Focus();
                        return;
                    }
                }
                if (lblPayType.Text.ToUpper() == "ADVANCE" && txtChequeNo.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Advance Document not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtRecPayment.Text.Trim() == string.Empty)
                { txtRecPayment.Text = "0.00"; }

                if (decimal.Parse(txtRecPayment.Text) < 0)
                {
                    MessageBox.Show("Payment Detail Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecPayment.Focus();
                    return;

                }

                //Validate Loylity Details-------------
                if ((lblPayType.Text.ToUpper() == "TOP UP CARD" || lblPayType.Text.ToUpper() == "GIFT VOUCHER" || lblPayType.Text.ToUpper() == "POINTS") && cmbBankName.Enabled == false)
                {
                    ObjComman.GetCardDetails(txtBranchName.Text.Trim(), lblPayType.Text.Trim());

                    if (ObjComman.Ads.Tables[0].Rows.Count == 0)
                    {
                        MetroMessageBox.Show(this,"Loyality Details not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBranchName.Focus();
                        return;
                    }

                    decimal PointAmount = Convert.ToDecimal(ObjComman.Ads.Tables[0].Rows[0][0].ToString());

                    if (PointAmount < Convert.ToDecimal(txtRecPayment.Text.Trim()))
                    {
                        MetroMessageBox.Show(this, "Entered amount is more than the Current Points", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRecPayment.Focus();
                        return;
                    }
                    ObjComman.SqlStatement = "SELECT * FROM dbo.CRM_Customer WHERE RedeemStatus='T' AND (Card_No='" + txtBranchName.Text.Trim() + "' or cus_code='" + txtBranchName.Text.Trim() + "' or mobile='" + txtBranchName.Text.Trim() + "') AND Inactive=0";
                    ObjComman.GetDs();
                    if (ObjComman.Ads.Tables[0].Rows.Count == 0 && lblPayType.Text.ToUpper() == "POINTS" )
                    {
                        MetroMessageBox.Show(this, "Not Allowed redeem points", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRecPayment.Focus();
                        return;
                    }
                  
                }
                //-------------------

                if (dataGridViewPayments.Visible == false)
                {
                    ClearPayments();
                }
                decimal Payment = decimal.Parse(txtRecPayment.Text.Trim());
                decimal Balance = decimal.Parse(txtPayBalance.Text.Trim());
                decimal Total = decimal.Parse(lblPayAmount.Text.Trim());
                decimal PaidAmount = decimal.Parse(txtTotalPayed.Text.Trim());




                if ((lblPayType.Text != "CASH") && (PaidAmount + Payment) > Total)
                {
                    if (MessageBox.Show("Over Payment Not Allowed.Sure to Contineu?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if ((PaidAmount + Payment) > Total)
                        {
                            txtRecPayment.Text = (Total - PaidAmount).ToString();
                        }
                    }
                    else
                    {
                        return;
                    }

                    return;
                }
                string BrnchCRName = "", BankName = "", ChequDate = "";
                if (cmbCardTypes.Visible == true)
                {
                    BrnchCRName = cmbCardTypes.Text;
                }
                if (txtBranchName.Visible == true)
                {
                    BrnchCRName = txtBranchName.Text;
                }
                if (cmbBankName.Enabled == true)
                {
                    BankName = cmbBankName.Text;
                }
                if (dtpChequeDate.Enabled == true)
                {
                    ChequDate = dtpChequeDate.Text;
                }

                objWholeInvoice.TempDocNo = lblDocNo.Text.Trim();
                objWholeInvoice.Pay_Type = lblPayType.Text.Trim();
                objWholeInvoice.ChequeNo = txtChequeNo.Text.Trim();
                objWholeInvoice.SelectBankName = BankName.ToUpper();
                objWholeInvoice.BranchName = BrnchCRName.ToUpper();
                objWholeInvoice.ChequeDate = ChequDate;
                objWholeInvoice.ChequeDate = ChequDate;
                objWholeInvoice.Amount = decimal.Parse(txtRecPayment.Text.ToString());
                objWholeInvoice.AddToPaymentModeForRpt();

                //CUSTOMER DISPLAY PRINT
                string Text = "Total :" + new String(' ', ((20 - 7) - (decimal.Parse(lblPayAmount.Text.ToString()).ToString("N2").Length))) + decimal.Parse(lblPayAmount.Text.ToString()).ToString("N2");

                string Text1 = Text;
                Text =  lblPayType.Text + " "  + decimal.Parse(txtRecPayment.Text.ToString()).ToString("N2");
                string Text2 = Text;
                clsPosDisplay.PrintDisplay(Text1, Text2);
               // clsPosDisplay.PrintDisplay("12345678912345678911", "987454");
                //############################

                if (Typep != "Single")
                {
                    LoadPaymentDt();
                }
                 Comp = true;

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void LoadPaymentDt()
        {
            try
            {
                ObjComman.SqlStatement = "SELECT * FROM dbo.tbPaymentDetails WHERE Temp_DocNo='" + lblDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' ;SELECT  cast (isnull(SUM(Amount),0) as decimal(18,2)) FROM dbo.tbPaymentDetails WHERE Temp_DocNo='" + lblDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' ;";
                ObjComman.GetDs(); 
                dataGridViewPayments.DataSource = ObjComman.Ads.Tables[0];
                txtTotalPayed.Text = ObjComman.Ads.Tables[1].Rows[0][0].ToString();

                //txtRecPayment.Text = txtPayBalance.Text = (Convert.ToDecimal(lblPayBalance.Text.Trim()) - Convert.ToDecimal(txtTotalPayed.Text.Trim())).ToString("N2");
                // Edited by kalani 02/09/2024 balance amount change below
                 txtRecPayment.Text = txtTotalPayed.Text;
                 txtPayBalance.Text = (Convert.ToDecimal(txtTotalPayed.Text.Trim())-Convert.ToDecimal(lblPayBalance.Text.Trim())).ToString("N2");
                if (Convert.ToDecimal(txtPayBalance.Text.Trim()) < 0)
                {
                    txtRecPayment.Text = "0.00";
                }
                txtBranchName.Text = txtChequeNo.Text = cmbBankName.Text = cmbCardTypes.Text = string.Empty;

                cmbCardTypes.SelectedIndex = cmbCardTypes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dataGridViewPayments_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewPayments.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Payment. ", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObjComman.SqlStatement = "DELETE FROM dbo.tbPaymentDetails WHERE Temp_DocNo ='" + lblDocNo.Text.Trim() + "' AND Payment_Mode='" + dataGridViewPayments.SelectedRows[0].Cells[0].Value.ToString() + "' AND Cheque_No='" + dataGridViewPayments.SelectedRows[0].Cells[3].Value.ToString() + "'";
                        ObjComman.GetDs();

                        LoadPaymentDt();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtRecPayment_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            { btnAdd_Click(new object(), e); }

            if (e.KeyCode == Keys.Up) { e.Handled = false; }
            if (e.KeyCode == Keys.Down) { e.Handled = false; }
            if (e.KeyCode == Keys.Add) { e.Handled = false; } 
        }

        private void cmbBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbBankName.Text.Trim()!=string.Empty)
            {
                if (cmbCardTypes.Visible == true)
                {
                    cmbCardTypes.DroppedDown = true;
                    cmbCardTypes.Focus();
                }
                else
                {
                    txtBranchName.SelectAll();
                    txtBranchName.Focus();
                }
            }
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBranchName.Text.Trim() != string.Empty && cmbBankName.Enabled==true)
            {
                txtChequeNo.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtBranchName.Text.Trim() != string.Empty && cmbBankName.Enabled == false)
            {

                if (lblPayType.Text.Trim() != "REWARD")
                {
                    ObjComman.GetCardDetails(txtBranchName.Text.Trim(), lblPayType.Text.Trim());
                    txtRecPayment.Text = ObjComman.Ads.Tables[0].Rows[0][0].ToString();
                }
                
                if (lblPayType.Text == "POINTS")
                {
                    txtLoyalityCard.Text = txtBranchName.Text.Trim();
                    txtLoyalBalance.Text = txtRecPayment.Text.Trim();
                }
                if (dataGridViewPayments.Visible == false)
                {
                    btnFinish.Focus();
                }
                else
                { txtRecPayment.Focus(); }
                 
            }
        }

        private void cmbCardTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbCardTypes.Text.Trim() != string.Empty)
            {
                txtChequeNo.Focus();
            }
        }

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtChequeNo.Text.Trim() != string.Empty)
            {
                dtpChequeDate.Focus();
            }
        }

        private void dtpChequeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter  )
            {
                txtRecPayment.Focus();
            }
        }

        private void txtRecPayment_Leave(object sender, EventArgs e)
        {
            if (txtRecPayment.Text.Trim() == string.Empty)
            {
                txtRecPayment.Text = "0";

              
            }
            //if (decimal.Parse(txtRecPayment.Text) > 0)
            //{
            //    txtRecPayment_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            //}
        }

        private void txtLoyalityCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtLoyalityCard.Text.Trim() != string.Empty)
                    {
                        ObjComman.SqlStatement = "SELECT * FROM dbo.CRM_Customer WHERE (Card_No='" + txtLoyalityCard.Text.Trim() + "'  or cus_code='" + txtLoyalityCard.Text.Trim() + "' or mobile='" + txtLoyalityCard.Text.Trim() + "')AND Inactive=0 and loca='" + LoginManager.LocaCode + "' and  Cust_Category='Loyalty customer'";
                        ObjComman.GetDs();
                        if (ObjComman.Ads.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Invalid Loyality Card", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtLoyalBalance.Text = "0.00";
                            return;
                        }
                        ObjComman.GetCardDetails(txtLoyalityCard.Text.Trim(), "POINTS");
                        txtLoyalBalance.Text = ObjComman.Ads.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        txtLoyalBalance.Text = "0.00";
                    
                    }
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
            }
        }
       public  string TransNo = "";
        private void lblPayType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (lblPayType.Text.Trim() == "REWARD" && dataGridViewPayments.Visible==true)
                {
                    string sqlst = "SELECT * FROM dbo.tbPaymentDetails WHERE  Temp_DocNo='"+lblDocNo.Text.Trim()+"' AND Payment_Mode='REWARD' AND Loca='"+LoginManager.LocaCode+"'";

                    ObjComman.SqlStatement = sqlst;
                    ObjComman.GetDs();
                    if (ObjComman.Ads.Tables[0].Rows.Count > 0)
                    {
                         lblPayType.Text = "XXXX";
                         return;
                    }


                    if (MetroMessageBox.Show(this,"Do you want to Wait For Response. ", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 150) == DialogResult.Yes)
                    {
                        try
                        {
                            using (WebClient client = new WebClient())
                            {

                                groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = false;
                                DateTime Dt = DateTime.Now.ToUniversalTime();
                                string DTT = Dt.ToString();

                                string OrgDocNo = "";
                                clsWholeSaleInvoice objWholeInvoice = new clsWholeSaleInvoice();

                                //objWholeInvoice.SqlStatement = "SELECT Temp_Inv,Inv FROM DocumentNoDetails WHERE Loca = ";
                                DataTable dt = null;
                                objWholeInvoice.GetTempDocumentNo(ref dt);
                                OrgDocNo= objWholeInvoice.TempDocNo;

                                ObjComman.SqlStatement = "SELECT DeviceApi,AppCode FROM dbo.tb_DeviceSettings WHERE MacName='"+LoginManager.MachinName+"'";
                                ObjComman.GetDs();

                                string DeviceApi = ObjComman.Ads.Tables[0].Rows[0][0].ToString();
                                string DeviceName = ObjComman.Ads.Tables[0].Rows[0][1].ToString();
                                //client.Headers.Add("Authorization", "Bearer " + Settings.Default.ApiAccessToken + "");
                                
                                client.Headers.Add("Content-Type", "application/json");
                                //string postData = "{\"amount\":" + lblPayAmount.Text.Trim() + ",\"receiptNumber\":\"" + OrgDocNo + "\",\"receiptDateTime\":\"" + DTT + "\",\"posId\":\"" + DeviceName + "\"}";
                                string postData = "{\"amount\":" + lblPayAmount.Text.Trim() + ",\"posId\":\"" + DeviceName + "\"}";
                               
                                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                                string baseURL = DeviceApi;

                                
                                byte[] responseArray = client.UploadData(baseURL, "POST", byteArray);

                                string x = Encoding.ASCII.GetString(responseArray);

                                JavaScriptSerializer j = new JavaScriptSerializer();
                                clsApiResponse Data = j.Deserialize<clsApiResponse>(x);

                                string erorrCode = "";
                                 TransNo = "";
                                string serialNumber = "";
                                List<ComrevTransaction> listOfItems;

                                erorrCode = Data.error;

                                if (erorrCode == null)
                                {
                                    groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
                                    MetroMessageBox.Show(this, "No Vouchers Received", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, 150);
                                    return;
                                }

                                
                               
                                listOfItems = Data.rewardConfirmation.rewardTransactions;

                                if (listOfItems == null)
                                {
                                    groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
                                    MetroMessageBox.Show(this, "No Vouchers Received", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, 150);
                                    return;
                                }
                                else
                                {
                                    TransNo = Data.rewardConfirmation.transNo;
                                }
                              
                               groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
                                if (listOfItems.Count > 0)
                                {
                                    for (int i = 0; i < listOfItems.Count; i++)
                                    {
                                        cmbBankName.Text = "";
                                        txtChequeNo.Text = listOfItems[i].serialNumber;
                                        txtRecPayment.Text = listOfItems[i].rewardValue;
                                        txtRecPayment_KeyDown(new object(), new KeyEventArgs(Keys.Enter));

                                    }
                                }
                                else
                                {
                                    groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
                                    MetroMessageBox.Show(this, "No Vouchers Received", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, 150);
                                }

                            }
                           

                        }
                        catch (Exception ex)
                        {

                            MetroMessageBox.Show(this,"Eror In Connection",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
                            lblPayType.Text = "XXXX";
                        }
                       

                    }
                    
                }
                if (lblPayType.Text.ToUpper() == "POINTS")
                {
                    txtBranchName.Text = lblCustCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public bool  UpdateApiLast()
        {
            try
            {

                using (WebClient client = new WebClient())
                {

                    
                    DateTime Dt = DateTime.Now.ToUniversalTime();
                    string DTT = Dt.ToString();
                    string foo = DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ff'Z'");

                    string OrgDocNo = "";
                    clsWholeSaleInvoice objWholeInvoice = new clsWholeSaleInvoice();

                    DataTable dt = null;
                    objWholeInvoice.GetTempDocumentNo(ref dt);
                    OrgDocNo = objWholeInvoice.TempDocNo;

                    ObjComman.SqlStatement = "SELECT DeviceApiCon,AppCode FROM dbo.tb_DeviceSettings WHERE MacName='" + LoginManager.MachinName + "'";
                    ObjComman.GetDs();

                    string DeviceApi = ObjComman.Ads.Tables[0].Rows[0][0].ToString();
                    string DeviceName = ObjComman.Ads.Tables[0].Rows[0][1].ToString();
                    //client.Headers.Add("Authorization", "Bearer " + Settings.Default.ApiAccessToken + "");

                    client.Headers.Add("Content-Type", "application/json");
                    string postData = "{\"amount\":" + lblPayAmount.Text.Trim() + ",\"posId\":\"" + DeviceName + "\",\"transNo\":\"" + TransNo + "\",\"receiptNumber\":\"" + OrgDocNo + "\",\"receiptDateTime\":\"" + foo + "\" }";
                    //string postData = "{\"amount\":" + lblPayAmount.Text.Trim() + ",\"posId\":\"" + DeviceName + "\"}";

                    byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                    string baseURL = DeviceApi;


                    byte[] responseArray = client.UploadData(baseURL, "POST", byteArray);

                    string x = Encoding.ASCII.GetString(responseArray);

                    JavaScriptSerializer j = new JavaScriptSerializer();
                    clsApiResponse Data = j.Deserialize<clsApiResponse>(x);

                      TransNo = "";
                      TransNo = Data.rewardConfirmation.transNo;
                    string Err= Data.error;

                    if (Err == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                    

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                return false;
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdPaytypes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    grdPaytypes_CellClick(this.grdPaytypes, new DataGridViewCellEventArgs(this.grdPaytypes.CurrentCell.ColumnIndex, this.grdPaytypes.CurrentRow.Index));

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmPayment_Activated(object sender, EventArgs e)
        {
           // txtRecPayment.Focus();
        }

        //private void frmPayment_Activated_1(object sender, EventArgs e)
        //{
        //    if (Loaded == false)
        //    {
        //        txtRecPayment.SelectAll();
        //        txtRecPayment.Focus();
        //        Loaded = true;
        //    }
        //}

        private void frmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.Control == true)
                    {
                        if (e.KeyCode == Keys.L)
                        {
                            txtLoyalityCard.SelectAll();
                            txtLoyalityCard.Focus();
                        }
                        if (e.KeyCode == Keys.Z)
                        {
                            btnCLear.PerformClick();
                        }
                    }
                    if (e.KeyCode == Keys.Escape)
                    {
                        btnCancel.PerformClick();
                    }
                    if (e.KeyCode == Keys.Add)
                    {
                        btnFinish.PerformClick();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        btnMultipay.PerformClick();
                    }
                    if (e.KeyCode == Keys.Left)
                    {
                        btnSinglePay.PerformClick();
                    }
                    if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    {
                        if (cmbBankName.Focused == false && cmbCardTypes.Focused == false)
                        {
                            if (grdPaytypes.Focused == false)
                            { grdPaytypes.Focus(); }
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
              
            }
        }
    }
}