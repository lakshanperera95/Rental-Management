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
    public partial class frmCancellation : Form
    {
        public frmCancellation()
        {
            InitializeComponent();
        }
        public int cases = 0;

        private static frmCancellation objCancellation;
        public static frmCancellation AobjCancellation
        {
            get { return objCancellation; }
            set { objCancellation = value; }
        }

        clsCommon objclsCancellation = new clsCommon();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCancellation_FormClosed(object sender, FormClosedEventArgs e)
        {
            objCancellation = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                
                string sqlStatement = "";


                if (cmbTrans.Text.Trim() == string.Empty || txtDocNo.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Transaction details not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return;
                }


                if (txtUserName.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("User Details not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    sqlStatement = "SELECT * FROM dbo.Employee WHERE Loca='" + LoginManager.LocaCode + "' AND Emp_Name='" + txtUserName.Text.Trim() + "' AND Pass_Word='" + txtPassword.Text.Trim() + "' AND Trans_Cancel='T'";
                    objclsCancellation.getDataReader(sqlStatement);
                    if (!objclsCancellation.Adr.Read())
                    {
                        MessageBox.Show("Incorrect User name or User don't have permision for Cancelation", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                objclsCancellation.CheckCancelDt(cmbTrans.SelectedValue.ToString(), txtDocNo.Text.Trim());
                if(objclsCancellation.ErrCode==404)
                {
                    MessageBox.Show(objclsCancellation.Mes, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


           
                #region 
                //string Type = "";
                //if (Type == "GRN")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Iid='GRN' AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }

                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE (Iid='PMT' OR Iid='SOP') AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if(objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Cannot cancel this document.Payment or Setoff has been done.","Cancellation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "PON")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Iid='PON' AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                    
                //}

                //if (Type == "SRN")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Iid='SRN' AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }

                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE (Iid='SOP') AND Setoff_SR_Doc='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Cannot cancel this document.Setoff has been done.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "INV")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Iid='INV' AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }

                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE (Iid='REC' OR Iid='SOR') AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Cannot cancel this document.Payment or Setoff has been done.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "CUR")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Iid='CUR' AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }

                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE (Iid='SOR') AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Cannot cancel this document.Payment or Setoff has been done.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "Payment")
                //{
                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE Org_Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Iid='PMT'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "Receipt")
                //{
                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE Org_Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Iid='REC'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "Customer Setoff")
                //{
                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE Org_Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Iid='SOR'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}

                //if (Type == "Supplier Setoff")
                //{
                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE Org_Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Iid='SOP'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}
                //if (Type == "TGN")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Iid='TGN' AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}
                //if (Type == "EBN")
                //{
                //    sqlStatement = "SELECT * FROM Transaction_Header WHERE Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' AND Iid='EBN'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (!objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Document not found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }

                //    sqlStatement = "SELECT * FROM tbPaidPaymentDetails WHERE (Iid='REC' OR Iid='SOR') AND Doc_No='" + txtDocNo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                //    objclsCancellation.getDataReader(sqlStatement);
                //    if (objclsCancellation.Adr.Read())
                //    {
                //        MessageBox.Show("Cannot cancel this document.Payment or Setoff has been done.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtDocNo.Focus();
                //        return;
                //    }
                //}
#endregion



                if (txtRemaarks.Text.Trim()==string.Empty )
                {
                    MessageBox.Show("Remarks Not Found.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemaarks.Focus();
                    return;
                }



                if (MessageBox.Show("Are you sure you want to cancel this document?", "Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlStatement = "EXEC sp_Cancellation '" + cmbTrans.SelectedValue.ToString() + "','" + txtDocNo.Text.Trim() + "','" + LoginManager.LocaCode + "','" + LoginManager.UserName + "',@Remarks='" + txtRemaarks.Text.Trim() + "' ";
                    objclsCancellation.getDataReader(sqlStatement);
                    MessageBox.Show("Document cancelled successfully.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCancellation btnCancel_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objclsCancellation.closeConnection();
            }
        }

        private void frmCancellation_Load(object sender, EventArgs e)
        {
            try
            {
                objclsCancellation.SqlStatement = "SELECT Iid,IidDescr FROM dbo.tblCancelIid  WHERE SysType='Nor' order by IidDescr";
                cmbTrans.DataSource = objclsCancellation.getData(objclsCancellation.SqlStatement).Tables[0];
                cmbTrans.ValueMember = "Iid";
                cmbTrans.DisplayMember = "IidDescr";

                btnDocSearch.Visible = true;

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCancellation btnCancel_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDocSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTrans.Text == "")
                {
                    MessageBox.Show("Select transaction type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnDocSearch.Focus();
                    return;
                }
                string Sqlstatement = "";
                frmSearch search = new frmSearch();
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                //switch (cases)
                //{
                //    case 1:
                //        Sqlstatement = "SELECT Doc_No,Post_Date FROM Transaction_Header WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='GRN'";
                //        break;
                //    case 2:
                //        Sqlstatement = "SELECT Doc_No,Post_Date FROM Transaction_Header WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='SRN'";
                //        break;
                //    case 3:
                //        Sqlstatement = "SELECT Doc_No,Post_Date FROM Transaction_Header WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='INV'";
                //        break;
                //    case 4:
                //        Sqlstatement = "SELECT Doc_No,Post_Date FROM Transaction_Header WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='PON'";
                //        break;
                //    case 5:
                //        Sqlstatement = "SELECT Doc_No,Post_Date FROM Transaction_Header WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='CUR'";
                //        break;
                //    case 6:
                //        Sqlstatement = "SELECT Org_Doc_no, Post_Date FROM tbPaidPaymentSummary WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='PMT'";
                //        break;
                //    case 8:
                //        Sqlstatement = "SELECT Org_Doc_no, Post_Date FROM tbPaidPaymentSummary WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='REC'";
                //        break;
                //    case 7:
                //        Sqlstatement = "SELECT  Org_Doc_no, Post_Date FROM tbPaidPaymentDetails WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='SOR'";
                //        break;
                //    case 9:
                //        Sqlstatement = "SELECT  Org_Doc_no, Post_Date FROM tbPaidPaymentDetails WHERE Loca='" + LoginManager.LocaCode + "' AND Iid='SOP'";
                //        break;

                //    default:



                //        break;

                //}

                Sqlstatement = "Exec Sp_LoadCancelDoc '" + cmbTrans.SelectedValue.ToString() + "' , @Loca ='" + LoginManager.LocaCode + "',@DocNo='"+txtDocNo.Text.Trim()+"'";
                objclsCancellation.getDataSet(Sqlstatement, "dsSearch");
                grdData.DataSource = objclsCancellation.Ads.Tables["dsSearch"];


                //objclsCancellation.getDataSet(Sqlstatement, "dsSearch");
                //search.dgSearch.DataSource = objclsCancellation.Ads.Tables["dsSearch"];
                //search.Show();
                //search.prop_Focus = txtDocNo;
            }
            catch (Exception ex)
            {

                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCancellation btnCancel_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTrans.Text == "Good Receive Note")
            //{
            //    cases = 1;
            //}
            //if (cmbTrans.Text == "Supplier Return")
            //{
            //    cases = 2;
            //}
            //if (cmbTrans.Text == "Invoice")
            //{
            //    cases = 3;
            //}
            //if (cmbTrans.Text == "Purchase Order")
            //{
            //    cases = 4;
            //}
            //if (cmbTrans.Text == "Customer Return")
            //{
            //    cases = 5;
            //}
            //if (cmbTrans.Text == "Payment")
            //{
            //    cases = 6;
            //}

            //if (cmbTrans.Text == "Customer Setoff")
            //{
            //    cases = 7;
            //}
            //if (cmbTrans.Text == "Receipt")
            //{
            //    cases = 8;
            //}
            //if (cmbTrans.Text == "Supplier Setoff")
            //{
            //    cases = 9;
            //} 
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && txtUserName.Text.Trim()!=string.Empty)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPassword.Text.Trim() != string.Empty)
            {
                btnCancel.Focus();
            }
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdData.SelectedRows.Count <= 0 || grdData.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtDocNo.Text = grdData.SelectedRows[0].Cells[0].Value.ToString();
                    txtDocNo.Focus();
                }
            }
            catch (Exception ex)
            {

                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCancellation btnCancel_Click. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtRemaarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtRemaarks.Text.Trim() != string.Empty)
            {
                txtUserName.Focus();
            }
        }

        private void txtDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && txtDocNo.Text.Trim()!=string.Empty)
            {
                txtRemaarks.Focus();
            }
        }
    }
}