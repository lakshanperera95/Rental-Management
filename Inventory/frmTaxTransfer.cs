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
    public partial class frmTaxTransfer : Form
    {
        public frmTaxTransfer()
        {
            InitializeComponent();
        }
        clsSalesTransfer objSalesTransfer = new clsSalesTransfer();
        frmSearch search = new frmSearch();

        private static frmTaxTransfer PurchaseTransfer;

        public static frmTaxTransfer getPurchaseTransfer
        {
            get { return PurchaseTransfer; }
            set { PurchaseTransfer = value; }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            PurchaseTransfer = null;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            { 
                objSalesTransfer.Reading("SELECT * FROM Location WHERE Loca  = '"+ txtLocaCode.Text.ToString() +"'");
                if (txtLocaCode.Text == string.Empty )
                {
                    MessageBox.Show("Invalied Location. Please Select the Location.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                lblMsg.Visible = true;
                this.Refresh();
                if (dgSelectedPurchDetails.Rows.Count == 0)
                {
                    MessageBox.Show("Select Transactions.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                #region


                objSalesTransfer.TransactionTransfer(LoginManager.LocaCode, txtLocaCode.Text.ToString(), lblTempDocNo.Text.ToString(), dtpTrDateFrom.Text, dtpTrDateTo.Text, cmbType.Text, "sp_GRNSRNDetailsTransfer");
                MessageBox.Show("Transaction Applied Successfully", "Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion



                //---- Clearing
                dgTransferingPurchDetails.DataSource = null;
                dgSelectedPurchDetails.DataSource = null;
                lblSelectedAmount.Text = "0.00";
                lblTransferingAmount.Text = "0.00";

                this.Refresh();
                lblMsg.Visible = false;
                this.Close();
            }
            catch (Exception ex)
            {
                lblMsg.Visible = false;
                objSalesTransfer.Errormsg(ex, "frmSalesTransfer-btnCheck_Click");

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //---- Clearing
            dgTransferingPurchDetails.DataSource = null;
            dgSelectedPurchDetails.DataSource = null;
            lblSelectedAmount.Text = "0.00";
            lblTransferingAmount.Text = "0.00";
            lblMsg.Visible = false; 
            dtpTrDateFrom.Enabled = dtpTrDateTo.Enabled = txtLocaCode.Enabled = txtLocaName.Enabled = btnLocaSearch.Enabled = cmbType.Enabled = btnCheck.Enabled = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.Text == string.Empty)
                    return;

                lblMsg.Visible = true;
                this.Refresh();
                objSalesTransfer.TempDocumentNo = lblTempDocNo.Text.ToString().Trim();
                
                objSalesTransfer.Selected_Loca = txtLocaCode.Text.ToString().Trim();
                objSalesTransfer.iid = cmbType.Text;
                objSalesTransfer.CheckPurchaseTr(dtpTrDateFrom.Text, dtpTrDateTo.Text, "sp_LoadPurchaseTransferDetails"); //sp_GRNSRNPurchaseTransferforReport
                dgTransferingPurchDetails.DataSource = null;
                dgTransferingPurchDetails.DataSource = objSalesTransfer.getds1.Tables["dsTrPurchAmount"];
                dgTransferingPurchDetails.Refresh();
                 
                this.Refresh();
                lblMsg.Visible = false; 


                if(dgTransferingPurchDetails.Rows.Count>0)
                {
                    dtpTrDateFrom.Enabled = dtpTrDateTo.Enabled= txtLocaCode.Enabled =txtLocaName.Enabled =btnLocaSearch.Enabled=cmbType.Enabled=btnCheck.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = false;
                objSalesTransfer.Errormsg(ex, "frmSalesTransfer-btnCheck_Click");

            }
        }

        private void frmPurchaseTransfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            PurchaseTransfer = null;
        }

        private void frmPurchaseTransfer_Load(object sender, EventArgs e)
        {
            try
            {
               
                string SqlStatement = "SELECT Tmp_PTX FROM DocumentNoDetails WHERE Loca = ";
                objSalesTransfer.GetTempDocumentNo(SqlStatement);
                lblTempDocNo.Text = objSalesTransfer.strTempDocumentNo;

                cmbType.SelectedIndex = 0;

                txtLocaCode.Text = LoginManager.LocaCode;
                txtLocaCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            }
            catch (Exception ex)
            {
                lblMsg.Visible = false;
                objSalesTransfer.Errormsg(ex, "frmSalesTransfer-btnCheck_Click");

            }
        }

        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string selectquery = "";
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                //if (rdbTGN.Checked)
                //{
                selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location where   TaxLoca=0  ORDER BY Loca";
                search.dgSearch.DataSource = clsRetriveGenaral.combofill1(selectquery).Tables["Table"];
                search.Show();
                search.prop_Focus = txtLocaCode;
                txtLocaName.Text = search.Descript;
                //}
                //else if (rdbATGN.Checked)
                //{
                //    selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location  WHERE Loca NOT IN ( SELECT TAX_LOCA AS LOCA FROM tb_TaxLocations)   ORDER BY Loca";
                //    search.dgSearch.DataSource = clsRetriveGenaral.combofill1(selectquery).Tables["Table"];
                //    search.Show();
                //    search.prop_Focus = txtLocaCode;
                //    txtLocaName.Text = search.Descript;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        
        private void dgTransferingPurchDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgTransferingPurchDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgTransferingPurchDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgTransferingPurchDetails.RowCount > 0)
                { 
                    decimal NetAmount = 0;
                    int RowCount = 0;
                    RowCount = dgTransferingPurchDetails.RowCount;
                    for (int i = 0; i < RowCount; i++)
                    {
                        if (bool.Parse(dgTransferingPurchDetails.Rows[i].Cells[6].FormattedValue.ToString()) == true)
                        {
                            NetAmount = NetAmount + decimal.Parse(dgTransferingPurchDetails.Rows[i].Cells[5].Value.ToString());
                        }


                    }

                    lblSelectedAmount.Text = NetAmount.ToString(); 
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = false;
                objSalesTransfer.Errormsg(ex, "frmSalesTransfer-rdbSRN_CheckedChanged");

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                 
                lblMsg.Visible = true;
                this.Refresh();


                dgSelectedPurchDetails.DataSource = null;
                if (dgTransferingPurchDetails.RowCount > 0)
                {

                    int RowCount = 0;
                    RowCount = dgTransferingPurchDetails.RowCount;
                    for (int i = 0; i < RowCount; i++)
                    {
                        if (bool.Parse(dgTransferingPurchDetails.Rows[i].Cells[6].FormattedValue.ToString()) == true)
                        {
                            string Date = "";
                            string Doc_No = "";
                            string Supp_Code = "";
                            Date = dgTransferingPurchDetails.Rows[i].Cells[0].FormattedValue.ToString();
                            Doc_No = dgTransferingPurchDetails.Rows[i].Cells[1].FormattedValue.ToString();
                            Supp_Code = dgTransferingPurchDetails.Rows[i].Cells[2].FormattedValue.ToString();
                            //if (TIid == "AGN")
                            //{
                            //    objSalesTransfer.DataReader("UPDATE tb_TempTaxPurchaseDetails SET [Check] = CAST( 1 AS BIT ) WHERE [Post_Date] ='" + Date + "' AND Loca='" + txtLocaCode.Text.Trim().ToString() + "' AND Doc_no='" + Doc_No.Trim().ToString() + "' AND Temp_Doc_no = '" + lblTempDocNo.Text.Trim().ToString() + "'");
                            //}
                            //else
                            {
                                objSalesTransfer.DataReader("UPDATE tb_TempTaxPurchaseDetails SET [Check] = CAST( 1 AS BIT ) WHERE Loca='" + txtLocaCode.Text.Trim().ToString() + "' AND Doc_no='" + Doc_No.Trim().ToString() + "'   AND Temp_Doc_no = '" + lblTempDocNo.Text.Trim().ToString() + "'");
                            }
                            
                        }
                        else if (bool.Parse(dgTransferingPurchDetails.Rows[i].Cells[6].FormattedValue.ToString()) == false)
                        {
                            string Date = "";
                            string Doc_No = "";
                            string Supp_Code = "";
                            Date = dgTransferingPurchDetails.Rows[i].Cells[0].FormattedValue.ToString();
                            Doc_No = dgTransferingPurchDetails.Rows[i].Cells[1].FormattedValue.ToString();
                            Supp_Code = dgTransferingPurchDetails.Rows[i].Cells[2].FormattedValue.ToString();
                            //if (TIid == "AGN")
                            //{
                            //    objSalesTransfer.DataReader("UPDATE tb_TempTaxPurchaseDetails SET [Check] = CAST( 0 AS BIT ) WHERE [Post_Date] ='" + Date + "' AND Loca='" + txtLocaCode.Text.Trim().ToString() + "' AND Doc_no='" + Doc_No.Trim().ToString() + "' AND Temp_Doc_no = '" + lblTempDocNo.Text.Trim().ToString() + "'");
                            //}
                            //else
                            {
                                objSalesTransfer.DataReader("UPDATE tb_TempTaxPurchaseDetails SET [Check] = CAST( 0 AS BIT ) WHERE [Post_Date] ='" + Date + "' AND Loca='" + LoginManager.LocaCode.Trim().ToString() + "' AND Doc_no='" + Doc_No.Trim().ToString() + "' AND Supp_Code ='" + Supp_Code.Trim().ToString() + "' AND Temp_Doc_no = '" + lblTempDocNo.Text.Trim().ToString() + "'");
                            }
                        } 
                        
                        objSalesTransfer.Dataset("SELECT Temp_Doc_no , Post_Date [Date] ,Doc_no ,Qty ,Net_Amount Amount ,Supp_Code ,Supp_Name ,Pc_Name FROM tb_TempTaxPurchaseDetails  WHERE Temp_Doc_no = '" + lblTempDocNo.Text.Trim().ToString() + "' AND Loca = '" + txtLocaCode.Text.Trim().ToString() + "' AND  [Check] = CAST( 1 AS BIT )  AND Iid = '" + cmbType.Text + "' ");                         
                        dgSelectedPurchDetails.DataSource = null;
                        dgSelectedPurchDetails.DataSource = objSalesTransfer.getds1.Tables[0];
                        dgSelectedPurchDetails.Refresh();
                    }


                    decimal NetAmount = 0;
                    RowCount = 0;
                    RowCount = dgSelectedPurchDetails.RowCount;
                    for (int i = 0; i < RowCount; i++)
                    {
                        NetAmount = NetAmount + decimal.Parse(dgSelectedPurchDetails.Rows[i].Cells[5].Value.ToString());

                    }
                    lblTransferingAmount.Text = NetAmount.ToString();


                }
                else
                {
                    return;
                    this.Refresh();
                    lblMsg.Visible = false;
                }

                this.Refresh();
                lblMsg.Visible = false;
            }
            catch (Exception ex)
            {
                lblMsg.Visible = false;
                objSalesTransfer.Errormsg(ex, "frmSalesTransfer-btnCheck_Click");

            }
        }

        private void rdbSRN_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void txtLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    if (txtLocaCode.Text.Trim() != "")
                    {
                        string SqlStatement = "SELECT Loca , Loca_Descrip  FROM Location WHERE Loca = '" + txtLocaCode.Text.Trim() + "'";
                        objSalesTransfer.ReadingLocaDetails(SqlStatement); 
                        if (objSalesTransfer.blRecordFound == true)
                        {
                            txtLocaName.Text = objSalesTransfer.Descript;  
                        }
                        
                    }
                }
                else if (e.KeyCode == Keys.F1)
                {
                    this.btnLocaSearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                foreach (DataGridViewRow dr in dgTransferingPurchDetails.Rows)
                {
                    dr.Cells[6].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow dr in dgTransferingPurchDetails.Rows)
                {
                    dr.Cells[6].Value = false;
                }
            }
        }
    }
}