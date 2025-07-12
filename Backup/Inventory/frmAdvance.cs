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
    public partial class frmAdvance : Form
    {
        public frmAdvance(string Code)
        {
            InitializeComponent();
            if (Code != "")
            {
                txtCustCode.Text = Code;
                txtCustCode_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
            }
        }

        private static frmAdvance objAdvance;
        public static frmAdvance AobjAdvance
        {
            get { return objAdvance; }
            set { objAdvance = value; }
        }

        clsCommon objclsAdvance = new clsCommon();

        frmSearch search = new frmSearch();

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                string sqlStatement = "";

                if (rdbCustomer.Checked == true)
                {
                    if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                         sqlStatement= "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE (Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' OR Mobile LIKE '%" + txtCustCode.Text.Trim() + "%'  ) AND dbo.CRM_Customer.Inactive=0 ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                        {
                            sqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE  (Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%'  Or Mobile LIKE '%" + txtCustName.Text.Trim() + "%' ) AND dbo.CRM_Customer.Inactive=0 ORDER BY Cust_Name";
                        }
                        else
                        {
                            sqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer  JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE  dbo.CRM_Customer.Inactive=0 ORDER BY Cust_Code";
                        }
                    }
                }
                else
                {
                    if (txtCustCode.Text.Trim() == string.Empty)
                    {
                        if (txtCustName.Text.Trim() == string.Empty)
                        {
                            sqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Inactive=0 ORDER BY Supp_Code";
                        }
                        else
                        {
                            sqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtCustName.Text.Trim() + "%' AND Inactive=0 ORDER BY Supp_Code";
                        }
                    }
                    else
                    {
                        sqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtCustCode.Text.Trim() + "%' AND Inactive=0 ORDER BY Supp_Code";
                    }
                }


                objclsAdvance.getDataSet(sqlStatement, "dsCustomer");
                search.dgSearch.DataSource = objclsAdvance.Ads.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
                search.Cont_Descript = txtCustName;
               
                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y + 100);
                if (rdbCustomer.Checked == true)
                {
                    search.dgSearch.Columns[0].Width = 75;
                    search.dgSearch.Columns[1].Width = 200;
                    search.dgSearch.Columns[2].Width = 125;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmAdvance btnCustomerSearch_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Text.Trim() == "Cash")
            {
                dtpChqDate.Enabled = false;
                cmbBank.Enabled = false;
                cmbBank.SelectedIndex = -1;
                cmbBank.Text = "";
                txtBranch.Enabled = false;
                txtBranch.Clear();
                txtChqNo.Clear();
                txtChqNo.Enabled = false;
            }
            else
            {
                dtpChqDate.Enabled = true;
                cmbBank.Enabled = true;
                cmbBank.SelectedIndex = -1;
                cmbBank.Text = "";
                txtBranch.Enabled = true;
                txtBranch.Clear();
                txtChqNo.Clear();
                txtChqNo.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool CusSearching = false;
        private void frmAdvance_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlStatement = "SELECT Bank_Name FROM BankDetails";
                objclsAdvance.getDataSet(sqlStatement, "BankDetails");
                cmbBank.DataSource = objclsAdvance.Ads.Tables["BankDetails"];
                cmbBank.DisplayMember = "Bank_Name";
                cmbBank.SelectedIndex = -1;
                cmbBank.Text = "";
                cmbPayType.Text = "Cash";

                CusSearching = true;
                txtCustCode.BackColor = Color.MediumAquamarine;
                txtCustName.BackColor = Color.MediumAquamarine;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmAdvance frmAdvance_Load. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objclsAdvance.closeConnection();
            }
        }

        private void frmAdvance_FormClosed(object sender, FormClosedEventArgs e)
        {
            objAdvance = null;
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
                {
                    dtpDate.Focus();
                }
                if (e.KeyCode == Keys.F5)
                {
                    if (CusSearching == true)
                    {
                        CusSearching = false;
                        txtCustName.BackColor = Color.Empty;
                        txtCustCode.BackColor = Color.Empty;
                        frmSearch.GetSearch.Hide();

                    }
                    else
                    {
                        CusSearching = true;
                        txtCustCode.BackColor = Color.MediumAquamarine;
                        txtCustName.BackColor = Color.MediumAquamarine;
                    }
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;

                    search.Focus();

                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtCustName.Text = txtCustCode.Text = string.Empty;
                }
                if (search.dgSearch.Rows.Count > 0 && search.Visible)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        search.selectRow();

                    }
                    int select = search.dgSearch.SelectedRows[0].Index;
                    if (e.KeyCode == Keys.Down && search.dgSearch.SelectedRows[0].Index != search.dgSearch.Rows.Count - 1)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select + 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select + 1].Cells[0];

                    }
                    if (e.KeyCode == Keys.Up && search.dgSearch.SelectedRows[0].Index != 0)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select - 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select - 1].Cells[0];

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmWholeSaleInvoice 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
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
                cmbPayType.Focus();
            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbPayType.Text.Trim() == "Cheque")
                {
                    txtChqNo.Focus();
                }
                else
                {
                    txtRemarks.Focus();
                }
            }
        }

        private void dtpChqDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBank.Focus();
            }
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBranch.Focus();
            }
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnApply.Focus();
            }
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        txtCustName.Text = txtCustCode.Text = string.Empty;
                    }
                    if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    {
                        e.Handled = true;

                        search.Focus();

                    }

                    if (search.dgSearch.Rows.Count > 0 && search.Visible)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            search.selectRow();

                        }
                        int select = search.dgSearch.SelectedRows[0].Index;
                        if (e.KeyCode == Keys.Down && search.dgSearch.SelectedRows[0].Index != search.dgSearch.Rows.Count - 1)
                        {
                            search.dgSearch.SelectedRows[0].Selected = false;
                            search.dgSearch.Rows[select + 1].Selected = true;
                            search.dgSearch.CurrentCell = search.dgSearch.Rows[select + 1].Cells[0];

                        }
                        if (e.KeyCode == Keys.Up && search.dgSearch.SelectedRows[0].Index != 0)
                        {
                            search.dgSearch.SelectedRows[0].Selected = false;
                            search.dgSearch.Rows[select - 1].Selected = true;
                            search.dgSearch.CurrentCell = search.dgSearch.Rows[select - 1].Cells[0];

                        }
                    }
                    if (txtCustCode.Text.Trim() != string.Empty)
                    {
                        string sqlStatement = "";
                        if (rdbCustomer.Checked == true)
                        {
                            sqlStatement = "SELECT Cust_Name FROM Customer WHERE Cust_Code='" + txtCustCode.Text.Trim() + "'";
                        }
                        else
                        {
                            sqlStatement = "SELECT Supp_Name Cust_Name FROM Supplier WHERE Supp_Code='" + txtCustCode.Text.Trim() + "'";
                        }
                        objclsAdvance.getDataReader(sqlStatement);
                        if (objclsAdvance.Adr.Read())
                        {
                            txtCustName.Text = objclsAdvance.Adr["Cust_Name"].ToString();
                        }
                    }
                    txtCustName.Focus();
                }
                catch (Exception ex)
                {
                    //Write to Log
                    DateTime dtCurrentDate = DateTime.Now;
                    FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmAdvance txtCustCode_KeyDown. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                        // read from file or write to file
                    }
                    finally
                    {
                        m_streamWriter.Close();
                        fileStream.Close();
                    }
                    MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    objclsAdvance.closeConnection();
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustCode.Text.Trim() == "")
                {
                    MessageBox.Show("Code is not entered.", "Advance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustCode.Focus();
                    return;
                }

                if (txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Amount is not entered.", "Advance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmount.Focus();
                    return;
                }

                if (cmbPayType.Text.Trim() == "Cheque")
                {
                    if (txtChqNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Cheque no is not entered.", "Cheque Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtChqNo.Focus();
                        return;
                    }

                    if (cmbBank.Text.Trim() == "")
                    {
                        MessageBox.Show("Bank is not entered.", "Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbBank.Focus();
                        return;
                    }

                    if (txtBranch.Text.Trim() == "")
                    {
                        MessageBox.Show("Branch is not entered.", "Branch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBranch.Focus();
                        return;
                    }
                }

                if (txtRemarks.Text.Trim() == "")
                {
                    MessageBox.Show("Remarks is not entered.", "Remarks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemarks.Focus();
                    return;
                }

                if (MessageBox.Show("Are you sure you want to save this record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string chqDate = "";
                    if (cmbPayType.Text.Trim() == "Cheque")
                    {
                        chqDate = dtpChqDate.Text.Trim();
                    }

                    string Iid = "";
                    if (rdbCustomer.Checked == true)
                    {
                        Iid = "CUS";
                    }
                    else
                    {
                        Iid = "SUP";
                    }

                    string sqlStatement = "EXEC sp_AdvanceApply '" + dtpDate.Text.Trim() + "','" + LoginManager.LocaCode + "','" + txtCustCode.Text.Trim() + "'," + txtAmount.Text.Trim() + ",'" + cmbPayType.Text.Trim() + "','" + txtChqNo.Text.Trim() + "','" + chqDate + "','" + cmbBank.Text.Trim() + "','" + txtBranch.Text.Trim() + "','" + txtRemarks.Text.Trim() + "','" + LoginManager.UserName + "','" + Iid + "'";
                    objclsAdvance.getDataReader(sqlStatement);
                    if (objclsAdvance.Adr.Read())
                    {
                        MessageBox.Show("Record Saved Successfully as " + objclsAdvance.Adr["DocNo"].ToString(), "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    string docno = objclsAdvance.Adr["DocNo"].ToString();
                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;
                    objRepViewer.verReport = new rptAdvanceReport();
                    string SqlStatement;
                    if (rdbCustomer.Checked == true)
                    {
                        SqlStatement = "select  tbPaidPaymentSummary.Acc_Code [Sup_Cus_Id], Customer.Cust_Name [Sup_Cus_Name],tbPaidPaymentSummary.Org_Doc_no [Doc_No],tbPaidPaymentSummary.Iid ,tbPaidPaymentSummary.Payment_Mode,tbPaidPaymentSummary.Bank_Name,tbPaidPaymentSummary.Post_Date,tbPaidPaymentSummary.Cheque_No,tbPaidPaymentSummary.Cheque_Date,tbPaidPaymentSummary.Amount FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code=Customer.Cust_Code  WHERE tbPaidPaymentSummary.Org_Doc_no='" + docno + "' AND Loca='" + LoginManager.LocaCode + "' ";
                        objRepViewer.verReport.SummaryInfo.ReportTitle = "Customer Advance Report";
                    }
                    else
                    {
                        SqlStatement = "select  tbPaidPaymentSummary.Acc_Code [Sup_Cus_Id], Supplier.Supp_Name [Sup_Cus_Name],tbPaidPaymentSummary.Org_Doc_no [Doc_No],tbPaidPaymentSummary.Iid ,tbPaidPaymentSummary.Payment_Mode,tbPaidPaymentSummary.Bank_Name,tbPaidPaymentSummary.Post_Date,tbPaidPaymentSummary.Cheque_No,tbPaidPaymentSummary.Cheque_Date,tbPaidPaymentSummary.Amount FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code=Supplier.Supp_Code  WHERE tbPaidPaymentSummary.Org_Doc_no='" + docno + "' AND Loca='" + LoginManager.LocaCode + "' ";
                        objRepViewer.verReport.SummaryInfo.ReportTitle = "Supplier Advance Report";
                    }
                    DataSet ds = new DataSet();
                    objclsAdvance.getDataSet(SqlStatement, "dsAdvanceReport");
                    objRepViewer.verReport.SetDataSource(objclsAdvance.Ads);
                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;
                    objRepViewer.Show();
                    txtCustCode.Clear();
                    txtCustName.Clear();
                    txtAmount.Clear();
                    cmbPayType.Text = "Cheque";
                    cmbPayType.Text = "Cash";
                    txtRemarks.Clear();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmAdvance btnApply_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objclsAdvance.closeConnection();
            }
        }

        private void txtChqNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpChqDate.Focus();
            }
        }

        private void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                label1.Text = "Customer";
            }
            else
            {
                label1.Text = "Supplier";
            }
        }

        private void rdbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                label1.Text = "Customer";
            }
            else
            {
                label1.Text = "Supplier";
            }
        }

        private void txtCustName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
                txtCustName.Focus();
            }
        }

        private void txtCustCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustCode.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
                txtCustCode.Focus();
            }
        }
    }
}