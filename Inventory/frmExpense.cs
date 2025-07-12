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
    public partial class frmExpense : Form
    {
        public frmExpense()
        {
            InitializeComponent();

        }
        clsCommon objExpense = new clsCommon();
        frmSearch search = new frmSearch();

        private static frmExpense Expense;

        public static frmExpense getExpense
        {
            get { return Expense; }
            set { Expense = value; }
        }
	

        private void frmExpense_Load(object sender, EventArgs e)
        {

        }

        private void btnBankSearchB_Click(object sender, EventArgs e)
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
                        SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense WHERE Expense_Code LIKE '%" + txtExpenseName.Text.Trim() + "%'  ORDER BY Expense_Code";
                    }
                    else
                    {
                        SqlStatement = "SELECT Expense_Code [Expense Code], Expense_Name [Expense Name] FROM tb_Expense ORDER BY Expense_Code";

                    }
                }


                objExpense.getDataSet(SqlStatement, "dsExpense");

                search.dgSearch.DataSource = objExpense.Ads.Tables["dsExpense"];
                search.prop_Focus = txtExpenseCode;
                search.Cont_Descript = txtExpenseName;
                search.Show();
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

        private void btnExitB_Click(object sender, EventArgs e)
        {

            try
            {
                this.Close();
                this.Dispose();
                Expense = null;
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

        private void frmExpense_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                Expense = null;
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

        private void txtExpenseCode_KeyDown(object sender, KeyEventArgs e)
        {


            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    btnExpenseSearch.PerformClick();
                }

                if (e.KeyCode == Keys.Enter)
                {
                    txtExpenseName.Focus();

                    string SqlStatement = " select Expense_Code,Expense_Name,Bf,Link_Cust_Code,Cust_Name,Link_Supp_Code,Supp_Name from tb_Expense Left join Customer On tb_Expense.Link_Cust_Code=Customer.Cust_Code Left join Supplier On tb_Expense.Link_Supp_Code=Supplier.Supp_Code where Expense_Code = '" + txtExpenseCode.Text.Trim() + "'";
                    objExpense.getDataReader(SqlStatement);

                    if (objExpense.Adr.Read())
                    {
                        txtExpenseName.Text = objExpense.Adr["Expense_Name"].ToString();
                        txtCustCode.Text = objExpense.Adr["Link_Cust_Code"].ToString();
                        txtCustName.Text = objExpense.Adr["Cust_Name"].ToString();
                        txtSuppCode.Text = objExpense.Adr["Link_Supp_Code"].ToString();
                        txtSuppName.Text = objExpense.Adr["Supp_Name"].ToString();

                        if (objExpense.Adr["Bf"].ToString() == "T")
                        {
                            chkBf.Checked = true;
                        }
                        else
                        {
                            chkBf.Checked = false;
                        }
                    }
                    else
                    {
                        txtExpenseName.Clear();
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

        private void btnApplyB_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtExpenseCode.Text.Trim() != string.Empty && txtExpenseName.Text.Trim() != string.Empty)
                {
                   

                    if (MessageBox.Show("Do you want to save this record ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Bf;
                        string strCust_Code;
                        if (chkBf.Checked == true)
                        {
                            Bf = "T";
                        }
                        else
                        {
                            Bf = "F";
                        }

                        strCust_Code = txtCustCode.Text;

                        string sqlStatement = "EXEC sp_ExpenseSave '" + txtExpenseCode.Text.Trim() + "','" + txtExpenseName.Text.Trim() + "','" + LoginManager.UserName + "','" + Bf + "','" + strCust_Code + "','" + txtSuppCode.Text + "'";
                        objExpense.getDataReader(sqlStatement);                        
                        MessageBox.Show("Record Saved Successfully ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Expense Details not completed. Please complete Expense Details.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                txtExpenseCode.Focus();
                txtExpenseCode.Clear();
                txtExpenseName.Clear();
                txtCustCode.Clear();
                txtCustName.Clear();
                txtSuppCode.Clear();
                txtSuppName.Clear();

                chkBf.Checked = false;
                
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBrand 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                txtExpenseCode.Text = "";
                txtExpenseName.Text = "";
                txtCustCode.Text = "";
                txtCustName.Text = "";
                txtSuppCode.Text = "";
                txtSuppName.Text = "";
                chkBf.Checked = false;

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBrand 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtExpenseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnExpenseSearch.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
               txtCustCode.Focus();
            }
        }

        private void btnCustSerch_Click(object sender, EventArgs e)
        {
            if (search.IsDisposed)
            {
                search = new frmSearch();
            }
           
            string SqlStatement = "";
            if (txtCustCode.Text.Trim() != string.Empty)
            {
                SqlStatement = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'CR') AND Cust_Code Like '%" + txtCustCode.Text.Trim() + "%' ORDER BY Cust_Code";
            }
            else
            {
                if (txtCustName.Text != string.Empty)
                {
                    SqlStatement = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'CR') AND Cust_Name Like '%" + txtCustName.Text.Trim() + "%' ORDER BY Cust_Code";
                }
                else
                {
                    SqlStatement = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'CR') ORDER BY Cust_Code";
                }
            }


            objExpense.getDataSet(SqlStatement, "Table");
            search.dgSearch.DataSource = objExpense.Ads.Tables["Table"];
            search.prop_Focus = txtCustCode;
            search.Cont_Descript = txtCustName;
            search.Show();





        }

        private void txtCustCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCustCode.Text = search.Code.Trim();
                    txtCustName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtExpenseCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtExpenseCode.Text = search.Code.Trim();
                    txtExpenseName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnCustSerch.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtCustName.Focus();
            }
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnCustSerch.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtSuppCode.Focus();
            }
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSuppName.Focus();
            }
        }

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnSuppSerch_Click(object sender, EventArgs e)
        {
            
            if (search.IsDisposed)
            {
                search = new frmSearch();
            }
           
            string SqlStatement = "";
            if (txtSuppCode.Text.Trim() != string.Empty)
            {
                SqlStatement = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE  Supp_Code Like '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code";
            }
            else
            {
                if (txtSuppName.Text != string.Empty)
                {
                    SqlStatement = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE  Supp_Name Like '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Code";
                }
                else
                {
                    SqlStatement = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
            }


            objExpense.getDataSet(SqlStatement, "Table");
            search.dgSearch.DataSource = objExpense.Ads.Tables["Table"];
            search.prop_Focus = txtSuppCode;
            search.Cont_Descript = txtSuppName;
            search.Show();

        }

        private void txtSuppCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtSuppCode.Text = search.Code.Trim();
                    txtSuppName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmExpense_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.Control == true)
                {

                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }
                    else if (e.KeyCode == Keys.L)
                    {
                        this.btnClear.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.E)
                        {
                            this.btnExitB.PerformClick();
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