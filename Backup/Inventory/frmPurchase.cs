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
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }
        frmSearch search = new frmSearch();
        clsCommon clsobjPurchase = new clsCommon();

        //This Form Developed by Aruni 06/2012

        private static frmPurchase _Purchase;
        public static frmPurchase Purchase
        {
            get { return _Purchase; }
            set { _Purchase = value; }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {

           
        }

        private void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    txtSuppName.Focus();

                    string SqlStatement = " select Supp_Code,Supp_Name from Supplier  where Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    clsobjPurchase.getDataReader(SqlStatement);

                    if (clsobjPurchase.Adr.Read())
                    {
                        txtSuppName.Text = clsobjPurchase.Adr["Supp_Name"].ToString();
                       


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

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBillNo.Focus();
            }
        }

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpPurrDate.Focus();
            }
        }

        private void dtpPurrDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBillAmount.Focus();
            }
        }

        private void txtBillAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMemo.Focus();
            }
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnApply.Focus();
            }
        }

        private void frmPurchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _Purchase = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                 _Purchase = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPurchaseOrder 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                string SqlStatement = "";
                if (txtSuppCode.Text.Trim() != string.Empty)
                {
                    SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%'  ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppName.Text.Trim() != string.Empty)
                    {
                        SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppName.Text.Trim() + "%'  ORDER BY Supp_Code";
                    }
                    else
                    {
                        SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier order by Supp_Code";

                    }
                }


                clsobjPurchase.getDataSet(SqlStatement, "ds");

                search.dgSearch.DataSource = clsobjPurchase.Ads.Tables["ds"];
                search.prop_Focus = txtSuppCode;
                search.Cont_Descript = txtSuppName;
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSuppCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Supplier Code is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                    return;
                }


                if (txtSuppName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Bank name is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;
                }
                if (txtBillNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Bill No is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;

                }
                if(txtBillAmount.Text.Trim()== string.Empty)
                {
                    MessageBox.Show("Bill Amount No is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;
                }
                if(txtMemo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Memo is not entered", "Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    return;

                }

                string SqlStatement = "SELECT Bill_No FROM tb_Purchase WHERE Loca='"+LoginManager.LocaCode+"' AND Supp_Code='"+txtSuppCode.Text.Trim()+"' AND Bill_No='"+txtBillNo.Text.Trim()+"'";
                clsobjPurchase.getDataReader(SqlStatement);
                if (clsobjPurchase.Adr.Read())
                {
                    MessageBox.Show("Bill No Already Exists", "Can't Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBillNo.Focus();
                    txtBillNo.SelectAll();
                    return;

                }
                if (MessageBox.Show("Do You Want To Apply ?", "Apply", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string DocumentNo = "";
                    string sqlStatement = "EXEC sp_Purchase '"+dtpDate.Text.Trim()+"','" + txtSuppCode.Text.Trim() + "','" + txtSuppName.Text.Trim() + "', '" + txtBillNo.Text.Trim() + "','"+dtpPurrDate.Text.Trim()+"',"+ Convert.ToDecimal(txtBillAmount.Text.Trim())+",'"+txtMemo.Text.Trim()+"','" + LoginManager.UserName + "','"+LoginManager.LocaCode+"'";
                    clsobjPurchase.getDataReader(sqlStatement);

                    if (clsobjPurchase.Adr.Read())
                    {
                        DocumentNo = clsobjPurchase.Adr["Doc_No"].ToString();
                        MessageBox.Show("Record Saved Succesfully as Document No " + DocumentNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    txtSuppCode.Clear();
                    txtSuppName.Clear();
                    txtBillNo.Clear();
                    txtBillAmount.Clear();
                    txtMemo.Clear();
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
                txtSuppCode.Clear();
                txtSuppName.Clear();
                txtBillNo.Clear();
                txtBillAmount.Clear();
                txtMemo.Clear();
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

        private void txtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsobjPurchase.checkNumeric(e, txtBillAmount.Text);
        }
    }
}