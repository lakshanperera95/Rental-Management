using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
using Inventory.Properties; 

namespace Inventory
{
    public partial class frmCreditNote : Form
    {
        public frmCreditNote(int formOpt,string SuppCusCode,string DocNo,string TempDoc)
        {
            InitializeComponent();
            IntFrmOption = formOpt;
            strSuppCusCode = SuppCusCode; 
            strDocNo = DocNo;
            strTempDoc = TempDoc;
            if(strTempDoc!="")
            {
                lblRecNo.Visible = true;
                lblRecNo.Text = strTempDoc;
            }
        }

        public static frmCreditNote objCrdNote { get; set; }

        public static frmCreditNote objDebNote { get; set; }


        string strSuppCusCode, strDocNo,strTempDoc;

        private int IntFrmOption;
        
        string sqlStatement;
        clsCommon objclsCrdNote = new clsCommon();
        frmSearch search = new frmSearch();
        bool CusSearching = false;

        private void frmCreditNote_Load(object sender, EventArgs e)
        {
  
                CusSearching = true;
                txtCode.BackColor = Color.MediumAquamarine;
                txtName.BackColor = Color.MediumAquamarine;
          
            switch (IntFrmOption)
            {
                    //debit Note
                case 1: 
                    lblCusOrSup.Text = "Customer";
                    lblHeader.Text = "Credit Note - Customer";                  
                    lblDocNo.Text = "Invoice No";
                    lblDocAmount.Text = "Invoice Amount"; 
                    lblCreditDebitAmount.Text = "Credit Amount";
                    this.Text ="Credit Note";
                    break;

                case 2:

                    lblCusOrSup.Text = "Supplier";
                    lblHeader.Text = "Debit Note - Supplier";
                    this.Text = "Debit Note";
                    lblDocNo.Text = "GRN No";
                    lblDocAmount.Text = "GRN Amount"; 
                    lblCreditDebitAmount.Text = "Debit Amount";
                    
                    break;
                     
             

                default:
                    break;
            }


            if(strSuppCusCode!=string.Empty)
            {
                txtCode.Text = strSuppCusCode;
                txtCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));

                txtInvGRNNo.Text = strDocNo;
                txtInvNo_KeyDown(sender, new KeyEventArgs(Keys.Enter));


                txtCreditDebitAmount.Focus();
            }
        }

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                string sqlStatement = "";

                if (txtCode.Text.Trim() == string.Empty)
                {
                    if (txtName.Text.Trim() == string.Empty)
                    {
                        switch (IntFrmOption)
                        {
                            case 1: 
                                sqlStatement = "SELECT Cust_Code [Cust Code],Cust_Name [Cust Name] FROM Customer"; 

                                break;
                            case 2: 
                                sqlStatement = "SELECT Supp_Code [Supp Code],Supp_Name [Supp Name] FROM Supplier";
                                break;
                            default:
                                sqlStatement = "";
                                break;
                        }
                        
                    }
                    else
                    {
                        switch (IntFrmOption)
                        {
                            case 1: 
                            sqlStatement = "SELECT Cust_Code [Cust Code],Cust_Name [Cust Name] FROM Customer WHERE Cust_Name LIKE '%" + txtName.Text.Trim() + "%'";
                                break;

                            case 2: 
                            sqlStatement = "SELECT Supp_Code [Supp Code],Supp_Name [Supp Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtName.Text.Trim() + "%'";
                                break;

                            default:
                                break;


                        }

                    }
                }
                else
                {
                    switch (IntFrmOption)
                    {
                        case 1: 
                            sqlStatement = "SELECT Cust_Code [Cust Code],Cust_Name [Cust Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCode.Text.Trim() + "%'";
                            break;
                        case 2: 
                            sqlStatement = "SELECT Supp_Code [Supp Code],Supp_Name [Supp Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtCode.Text.Trim() + "%'";
                            break;

                        default:
                            break;
                    }
                    
                }
                if (IntFrmOption == 1 || IntFrmOption == 3)
                {
                    objclsCrdNote.getDataSet(sqlStatement, "dsCustomer");
                    search.dgSearch.DataSource = objclsCrdNote.Ads.Tables["dsCustomer"];
                    search.prop_Focus = txtCode;
                    search.Cont_Descript = txtName;
                    search.Show();
                }
                else if (IntFrmOption == 2 || IntFrmOption == 4)
                {
                    objclsCrdNote.getDataSet(sqlStatement, "dsSupplier");
                    search.dgSearch.DataSource = objclsCrdNote.Ads.Tables["dsSupplier"];
                    search.prop_Focus = txtCode;
                    search.Cont_Descript = txtName;
                    search.Show();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCreditNote btnCustSearch_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objclsCrdNote.closeConnection();
            }
        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCode.Text.Trim()!=string.Empty)
            {
                switch (IntFrmOption)
                {
                    case 1:
                        sqlStatement = "SELECT Cust_Code [Cust Code],Cust_Name [Cust Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCode.Text.Trim() + "%'";
                        break;
                    case 2:
                        sqlStatement = "SELECT Supp_Code [Supp Code],Supp_Name [Supp Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtCode.Text.Trim() + "%'";
                        break;

                    default:
                        break;
                }

                objclsCrdNote.getDataSet(sqlStatement, "dsCustomer");                
                if(objclsCrdNote.Ads.Tables["dsCustomer"].Rows.Count>0)
                {
                    txtCode.Text = objclsCrdNote.Ads.Tables["dsCustomer"].Rows[0][0].ToString();
                    txtName.Text = objclsCrdNote.Ads.Tables["dsCustomer"].Rows[0][1].ToString();
                    txtInvGRNNo.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid Account Name", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCode.Focus();
                }
            }
        }

     
        private void txtInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    switch (IntFrmOption)
                    {
                        case 1:
                        case 3:
                            sqlStatement = "SELECT Transaction_Amount,Balance_Amount FROM Payment_Summary WHERE Loca='" + LoginManager.LocaCode + "' AND Acc_No='" + txtCode.Text.Trim() + "' AND Doc_No='" + txtInvGRNNo.Text.Trim() + "' AND (Tr_Type='INV' OR Tr_Type='CQR') AND Balance_Amount>0";
                            objclsCrdNote.getDataReader(sqlStatement);
                            if (objclsCrdNote.Adr.Read())
                            {
                                txtInvGRNAmount.Text = objclsCrdNote.Adr["Transaction_Amount"].ToString();
                                txtBalAmount.Text = objclsCrdNote.Adr["Balance_Amount"].ToString();
                                txtCreditDebitAmount.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Invoice No.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            break;

                        case 2:
                        case 4:
                            sqlStatement = "SELECT Transaction_Amount,Balance_Amount FROM Payment_Summary WHERE Loca='" + LoginManager.LocaCode + "' AND Acc_No='" + txtCode.Text.Trim() + "' AND Doc_No='" + txtInvGRNNo.Text.Trim() + "' AND (Tr_Type='GRN' OR Tr_Type='CQR') AND Balance_Amount>0";
                            objclsCrdNote.getDataReader(sqlStatement);
                            if (objclsCrdNote.Adr.Read())
                            {
                                txtInvGRNAmount.Text = objclsCrdNote.Adr["Transaction_Amount"].ToString();
                                txtBalAmount.Text = objclsCrdNote.Adr["Balance_Amount"].ToString();
                                txtCreditDebitAmount.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Invalid GRN No.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            break;
                        default:
                            break;
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCreditNote txtInvNo_KeyDown. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    objclsCrdNote.closeConnection();
                }
            }
        }

        private void txtCreditAmount_KeyDown(object sender, KeyEventArgs e)
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
                btnSave.Focus();
            }
        }

        private void btnInvSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                string sqlStatement = "";

                if (txtInvGRNNo.Text.Trim() == string.Empty)
                {
                    switch (IntFrmOption)
                    {
                        case 1:
                        case 3: 
                            sqlStatement = "SELECT Doc_No [Invoice No],Balance_Amount [Bal Amount] FROM Payment_Summary WHERE Loca='" + LoginManager.LocaCode + "' AND (Tr_Type='INV' OR Tr_Type='CQR') AND Acc_No='" + txtCode.Text.Trim() + "' AND Balance_Amount>0";
                            break;
                        case 2:
                        case 4:
                            sqlStatement = "SELECT Doc_No [Invoice No],Balance_Amount [Bal Amount] FROM Payment_Summary WHERE Loca='" + LoginManager.LocaCode + "' AND (Tr_Type='GRN' OR Tr_Type='CQR') AND Acc_No='" + txtCode.Text.Trim() + "' AND Balance_Amount>0";
                            break;

                        default:
                            break;
                    }

                }
                else
                {


                    switch (IntFrmOption)
                    {
                        case 1:
                        case 3:
                            sqlStatement = "SELECT Doc_No [Invoice No],Balance_Amount [Bal Amount] FROM Payment_Summary WHERE Loca='" + LoginManager.LocaCode + "' AND (Tr_Type='INV' OR Tr_Type='CQR') AND Acc_No='" + txtCode.Text.Trim() + "' AND Balance_Amount>0 AND Doc_No LIKE '%" + txtInvGRNNo.Text.Trim() + "%'";
                            break;
                        case 2:
                        case 4:
                            sqlStatement = "SELECT Doc_No [Invoice No],Balance_Amount [Bal Amount] FROM Payment_Summary WHERE Loca='" + LoginManager.LocaCode + "' AND (Tr_Type='GRN' OR Tr_Type='CQR') AND Acc_No='" + txtCode.Text.Trim() + "' AND Balance_Amount>0 AND Doc_No LIKE '%" + txtInvGRNNo.Text.Trim() + "%'";
                            break;
                        default:
                            break;
                    }
                }

                objclsCrdNote.getDataSet(sqlStatement, "dsInvoice");
                search.dgSearch.DataSource = objclsCrdNote.Ads.Tables["dsInvoice"];
                search.prop_Focus = txtInvGRNNo;
                search.Cont_Descript = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCreditNote btnCustSearch_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objclsCrdNote.closeConnection();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreditNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            switch (IntFrmOption)
            {
                case 1:
                    objCrdNote = null;
                    break;
                case 2:
                    objDebNote = null;
                    break;
                
                default:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(strTempDoc!=string.Empty)
            {
                this.Close();
            }
            txtCode.Clear();
            txtName.Clear();
            txtInvGRNNo.Clear();
            txtInvGRNAmount.Clear();
            txtBalAmount.Clear();
            txtCreditDebitAmount.Clear();
            txtRemarks.Clear();
            dtpDate.Focus(); 
        }

        private void frmCreditNote_Activated(object sender, EventArgs e)
        {
            txtCreditDebitAmount.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                switch (IntFrmOption)
                {
                    case 1:
                    case 3://--------------Credit/Debit note Customer--------------

                        sqlStatement = "SELECT Cust_Code,Cust_Name FROM Customer WHERE Cust_Code='" + txtCode.Text.Trim() + "'";
                        objclsCrdNote.getDataReader(sqlStatement);
                        if (objclsCrdNote.Adr.Read())
                        {
                            txtCode.Text = objclsCrdNote.Adr["Cust_Code"].ToString();
                            txtName.Text = objclsCrdNote.Adr["Cust_Name"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Customer Not Found.", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        objclsCrdNote.closeConnection();


                        sqlStatement = "SELECT Transaction_Amount,Balance_Amount FROM Payment_Summary WHERE (Tr_Type='INV' OR Tr_Type='CQR') AND Acc_No='" + txtCode.Text.Trim() + "' AND Balance_Amount>0 AND Doc_No='" + txtInvGRNNo.Text.Trim() + "'";
                        objclsCrdNote.getDataReader(sqlStatement);
                        if (objclsCrdNote.Adr.Read())
                        {
                            txtInvGRNAmount.Text = objclsCrdNote.Adr["Transaction_Amount"].ToString();
                            txtBalAmount.Text = objclsCrdNote.Adr["Balance_Amount"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Invoice No.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (Convert.ToDecimal(txtCreditDebitAmount.Text.Trim()) <= 0)
                        {
                            MessageBox.Show("Invalid Credit/Debit Amount.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (IntFrmOption == 1 && Convert.ToDecimal(txtCreditDebitAmount.Text.Trim()) > Convert.ToDecimal(txtBalAmount.Text.Trim()))
                        {
                            MessageBox.Show("Invalid Credit/Debit Amount.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }



                        if (txtRemarks.Text.Trim() == string.Empty)
                        {
                            txtRemarks.Text = ".";
                        }

                        if (MessageBox.Show("Are you sure you want to save this record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            string DocNo = "";
                            sqlStatement = "EXEC sp_CreditNoteSaveWithGRNINV '" + dtpDate.Text.Trim() + "','" + txtCode.Text.Trim() + "','" + txtInvGRNNo.Text.Trim() + "'," + txtInvGRNAmount.Text.Trim() + "," + txtBalAmount.Text.Trim() + "," + txtCreditDebitAmount.Text.Trim() + ",'" + txtRemarks.Text.Trim() + "','" + LoginManager.LocaCode + "','" + LoginManager.UserName + "', '4'";
                            objclsCrdNote.getDataReader(sqlStatement);
                            if (objclsCrdNote.Adr.Read())
                            {
                                DocNo = objclsCrdNote.Adr["DocNo"].ToString();
                            }
                            MessageBox.Show("Record Successfully Saved As Document No " + DocNo + ".", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnClear.PerformClick();

                        }

                        //------------------------------------------------------------
                        break;


                    case 2:
                    case 4://-------------Credit/Debit Note Supplier------------------

                        sqlStatement = "SELECT Supp_Code,Supp_Name FROM Supplier WHERE Supp_Code='" + txtCode.Text.Trim() + "'";
                        objclsCrdNote.getDataReader(sqlStatement);
                        if (objclsCrdNote.Adr.Read())
                        {
                            txtCode.Text = objclsCrdNote.Adr["Supp_Code"].ToString();
                            txtName.Text = objclsCrdNote.Adr["Supp_Name"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Supplier Not Found.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        objclsCrdNote.closeConnection();

                        //clsCommon ObjComm = new clsCommon();
                        //if (ObjComm.CheckGrnInApprovement(txtInvGRNNo.Text,strTempDoc) == true)
                        //{
                        //    XtraMessageBox.Show("Grn In Approvel...Cannot Continue ", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}


                        sqlStatement = "SELECT Transaction_Amount,Balance_Amount FROM Payment_Summary WHERE (Tr_Type='GRN' OR Tr_Type='CQR') AND Acc_No='" + txtCode.Text.Trim() + "' AND Balance_Amount>0 AND Doc_No='" + txtInvGRNNo.Text.Trim() + "'";
                        objclsCrdNote.getDataReader(sqlStatement);
                        if (objclsCrdNote.Adr.Read())
                        {
                            txtInvGRNAmount.Text = objclsCrdNote.Adr["Transaction_Amount"].ToString();
                            txtBalAmount.Text = objclsCrdNote.Adr["Balance_Amount"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid GRN No.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (Convert.ToDecimal(txtCreditDebitAmount.Text.Trim()) <= 0)
                        {
                            MessageBox.Show("Invalid Credit/Debit Amount.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (IntFrmOption == 4 && Convert.ToDecimal(txtCreditDebitAmount.Text.Trim()) > Convert.ToDecimal(txtBalAmount.Text.Trim()))
                        {
                            MessageBox.Show("Invalid Credit/Debit Amount.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }



                        if (txtRemarks.Text.Trim() == string.Empty)
                        {
                            txtRemarks.Text = ".";
                        }

                        if (MessageBox.Show("Are you sure you want to save this record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {

                            string DocNo = "";
                            sqlStatement = "EXEC sp_CreditNoteSaveWithGRNINV '" + dtpDate.Text.Trim() + "','" + txtCode.Text.Trim() + "','" + txtInvGRNNo.Text.Trim() + "'," + txtInvGRNAmount.Text.Trim() + "," + txtBalAmount.Text.Trim() + "," + txtCreditDebitAmount.Text.Trim() + ",'" + txtRemarks.Text.Trim() + "','" + LoginManager.LocaCode + "','" + LoginManager.UserName + "', '" + IntFrmOption + "','" + strTempDoc + "'";
                            objclsCrdNote.getDataReader(sqlStatement);
                            if (objclsCrdNote.Adr.Read())
                            {
                                DocNo = objclsCrdNote.Adr["DocNo"].ToString();
                            }
                            MessageBox.Show("Record Successfully Saved As Document No " + DocNo + ".", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnClear.PerformClick();


                        }
                        //------------------------------------------------------------
                        break;

                    default:
                        break;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCreditNote btnSave_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objclsCrdNote.closeConnection();
            }
        }

        
        private void txtName_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    txtCode.Text = txtName.Text = string.Empty;
                    txtCode.Focus();
                }
                //Serch ON OFF
                if (e.KeyCode == Keys.F5)
                {
                    if (CusSearching == true)
                    {
                        CusSearching = false;
                        txtCode.BackColor = Color.Empty;
                        txtName.BackColor = Color.Empty;
                        search.Hide();
                    }
                    else
                    {
                        CusSearching = true;
                        txtCode.BackColor = Color.MediumAquamarine;
                        txtName.BackColor = Color.MediumAquamarine;
                    }
                  
                }
                //Blocking Cursor Moving
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    search.Focus();
                }
                //Product Serch Selection
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
                if (e.KeyCode == Keys.Enter && txtName.Text.Trim() != "")
                {
                    txtInvGRNNo.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }
    }
}