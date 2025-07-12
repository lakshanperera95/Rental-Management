using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using clsLibrary;


namespace Inventory
{
    public partial class frmExpenseReturn : Form
    {
        public frmExpenseReturn()
        {
            InitializeComponent();
        }

        clsCommon objEnterBill = new clsCommon();
        frmSearch search = new frmSearch();


        private static frmExpenseReturn EnterBill;
        public static frmExpenseReturn getEnterBill
        {
            get { return EnterBill; }
            set { EnterBill = value; }
        }
	
        private void frmEnterBill_Load(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT Temp_EnterBill FROM DocumentNoDetails WHERE Loca='" + LoginManager.LocaCode + "'";
                objEnterBill.getDataReader(SqlStatement);
                if (objEnterBill.Adr.Read())
                {
                    int TempEnterBill = Convert.ToInt16(objEnterBill.Adr["Temp_EnterBill"].ToString());
                    txtTempDocNo.Text = "ETB" + LoginManager.LocaCode + string.Format("{0:000000}", TempEnterBill);
                }
                SqlStatement = "UPDATE DocumentNoDetails SET Temp_EnterBill=Temp_EnterBill+1 WHERE Loca='" + LoginManager.LocaCode + "'";
                objEnterBill.getDataReader(SqlStatement);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsBrand 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtExpenseCode.Focus();
            }
        }

        

        private void txtVenderName_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                txtExpenseCode.Focus();
            }
        }

        private void txtExpenseCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string SqlStatement;
                if (e.KeyCode == Keys.F1)
                {
                    btnExpenseSearch.PerformClick();
                }
                if (e.KeyCode == Keys.Enter)
                {


                    SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense WHERE Expense_Code='" + txtExpenseCode.Text.Trim() + "'";
                    objEnterBill.getDataReader(SqlStatement);
                    if (objEnterBill.Adr.Read())
                    {
                        txtExpenseName.Text = objEnterBill.Adr["Expense Name"].ToString();
                        txtExpenseName.Focus();
                    }
                    else
                    {
                        txtExpenseName.Text = "";
                        txtExpenseCode.Focus();
                    }

                    SqlStatement = "SELECT Expense_Code FROM tb_Expense WHERE Expense_Code='" + txtExpenseCode.Text.Trim() + "'";
                    objEnterBill.getDataReader(SqlStatement);
                    if (objEnterBill.Adr.Read())
                    {

                    }
                    else
                    {
                        txtExpenseCode.Focus();
                        txtExpenseCode.SelectAll();
                        txtExpenseName.Text = "";
                        return;
                    }

                    SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense WHERE Expense_Code='" + txtExpenseCode.Text.Trim() + "'";
                    objEnterBill.getDataReader(SqlStatement);
                    if (objEnterBill.Adr.Read())
                    {
                        txtExpenseName.Text = objEnterBill.Adr["Expense Name"].ToString();
                    }

                }

                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void txtExpenseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnExpenseSearch.PerformClick();
            }
             if (e.KeyCode == Keys.Enter)
            {
                txtBillNo.Focus();
            }
        }

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                txtMemo.Focus();
            }
        }


        private void btnExpenseSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                string SqlStatement = "";
                if (txtExpenseCode.Text.Trim() != string.Empty)
                {
                    SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense WHERE Expense_Code LIKE '%" + txtExpenseCode.Text.Trim() + "%'  ORDER BY Expense_Code";
                }
                else
                {
                    if (txtExpenseName.Text.Trim() != string.Empty)
                    {
                        SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense WHERE Expense_Name LIKE '%" + txtExpenseName.Text.Trim() + "%'  ORDER BY Expense_Code";
                    }
                    else
                    {
                        SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense ORDER BY Expense_Code";
                    }
                }
                objEnterBill.getDataSet(SqlStatement, "dsEnterBill");
                search.dgSearch.DataSource = objEnterBill.Ads.Tables["dsEnterBill"];
                search.prop_Focus = txtExpenseCode;
                search.Cont_Descript = txtExpenseName;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                EnterBill = null;
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
                //objEnterBill.Recordfind("SELECT Post_Date FROM tb_DailySummaryLog WHERE Post_Date='" + dtpDate.Text + "'");
                //if (objEnterBill.RecordFind == true)
                //{
                //    MessageBox.Show("Access Denied.Becouse Daily Summary processed !.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

                if (txtExpenseCode.Text.Trim() == string.Empty || txtExpenseName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Expense details not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtExpenseCode.Focus();
                    return;
                }
                //if (txtBillNo.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Bill Number not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    txtBillNo.Focus();
                //    return;
                //}
                if (txtAmount.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Amount should be entered.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAmount.Focus();
                    return;
                }
                if (txtMemo.Text.Trim().ToUpper() == "CASH")
                {
                    MessageBox.Show("You Can't Enter 'CASH'  For Memo .", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMemo.Focus();
                    txtMemo.SelectAll();
                    return;
                }
                if (txtMemo.Text.Trim().ToUpper() == "CHEQUE")
                {
                    MessageBox.Show("You Can't Enter 'CHEQUE'  For Memo .", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMemo.Focus();
                    txtMemo.SelectAll();
                    return;
                }


                if (MessageBox.Show("Are you sure you want to apply this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string SqlStatement = "EXEC sp_EnterBillApply '" + LoginManager.LocaCode + "', 'EXR', '" + dtpDate.Text.Trim() + "', '', '" + txtExpenseCode.Text.Trim() + "', '" + txtBillNo.Text.Trim() + "', " + Convert.ToDecimal(txtAmount.Text.Trim()) + ", '" + txtMemo.Text.Trim() + "', '" + LoginManager.UserName + "'";
                    //objEnterBill.getDataReader(SqlStatement);
                    //if (objEnterBill.Adr.Read())
                    //{
                    //    string OrgDocNo = objEnterBill.Adr["DocNo"].ToString();
                    //    MessageBox.Show("Record Apply Succesfully as " + OrgDocNo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    button1.PerformClick();
                    //    this.frmEnterBill_Load(sender, e);
                    //    //this.Close();
                    //}

                    objEnterBill.getDataSet(SqlStatement, "dtExpDetails");
                    if (objEnterBill.Ads.Tables[0].Rows.Count > 0)
                    {
                        string OrgDocNo = objEnterBill.Ads.Tables[0].Rows[0][0].ToString();
                        MessageBox.Show("Record Apply Succesfully as " + OrgDocNo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmReportViewer ReportViewer = new frmReportViewer();


                        rptExpDetails ExpDt = new rptExpDetails();
                        ExpDt.SetDataSource(objEnterBill.Ads);
                        ReportViewer.crystalReportViewer1.ReportSource = ExpDt;
                        ExpDt.SummaryInfo.ReportTitle = "EXPENSE RETURN DETAILS NOTE";
                        ReportViewer.WindowState = FormWindowState.Maximized;
                        ReportViewer.Show();

                        button1.PerformClick();
                        this.frmEnterBill_Load(sender, e);

                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtExpenseCode.Text = "";
            txtExpenseName.Text = "";
            txtBillNo.Text = "";
            txtAmount.Text = "";
            txtMemo.Text = "";

            txtExpenseCode.Focus();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objEnterBill.CheckNumeric(e, txtAmount.Text);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmEnterBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            EnterBill = null;
        }

        private void txtVenderCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmExpenseReturn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.Control == true)
                {

                    if (e.KeyCode == Keys.A)
                    {
                        this.btnApply.PerformClick();
                    }
                    else if (e.KeyCode == Keys.L)
                    {
                        this.button1.PerformClick();
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
    }
}