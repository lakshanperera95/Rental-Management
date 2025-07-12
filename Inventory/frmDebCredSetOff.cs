using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmDebCredSetOff : Form
    {
        private decimal decSelPendingAmount;
        private decimal decSelRetAmount;
        private decimal decSelectAmount;
        private string strPaymentSetOffType;    // This Is used for Supplier Return Set Off 'SUP', Customer Return set off 'CUS'

        public frmDebCredSetOff()
        {
            InitializeComponent();
        }

        clsDebCredSetOff ObjPaymentSetOff = new clsDebCredSetOff();

        frmSearch search = new frmSearch();
        private static frmDebCredSetOff PaymentSetOff;

        private string strSqlString;

        public static frmDebCredSetOff GetPaymentSetOff
        {
            get { return PaymentSetOff; }
            set { PaymentSetOff = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                PaymentSetOff = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPaymentSetOff_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PaymentSetOff = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPaymentSetOff_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide the form...
                this.Hide();

                // Cancel the close...
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPaymentSetOff_Load(object sender, EventArgs e)
        {
            try
            {
                ObjPaymentSetOff.SqlStatement = "SELECT DebCredSetOf_Temp FROM DocumentNoDetails WHERE Loca = ";
                ObjPaymentSetOff.GetTempDocumentNo();
                lblTempDocNo.Text = ObjPaymentSetOff.TempDocNo;

                //Refreshing DataGrid View
                dataGridViewPendingPayment.DataSource = ObjPaymentSetOff.GetPendingPayment.Tables["PendingPayments"];
                dataGridViewPendingPayment.Refresh();
                dataGridViewReturns.DataSource = ObjPaymentSetOff.SupplierReturn.Tables["PendingReturns"];
                dataGridViewReturns.Refresh();
                dataGridViewSetOff.DataSource = ObjPaymentSetOff.SelectedsSetOff.Tables["SelectedSetoff"];
                dataGridViewSetOff.Refresh();

                lblDate.Text = ObjPaymentSetOff.PostDate;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                ObjPaymentSetOff.SqlStatement = "select Supplier.Supp_Code, Supplier.Supp_Name FROM tb_LinkedCustSupp INNER JOIN Supplier ON Supplier.Supp_Code=tb_LinkedCustSupp.Supp_Code INNER JOIN Customer ON Customer.Cust_Code=tb_LinkedCustSupp.Cust_Code WHERE Customer.Cust_Code='" + txtCustCode.Text.Trim() + "' AND Supplier.Supp_Code='" + txtSuppCode.Text.Trim() + "' ";

                ObjPaymentSetOff.ReadTempTransDetails();
                if (ObjPaymentSetOff.RecordFound != true)
                {
                    MessageBox.Show("Supplier/Customer Not Found Or Supplier And Customer Are Not Linked", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ObjPaymentSetOff.SqlStatement = "SELECT * from tbTempSetoff WHERE tbTempSetoff.IId = 'DCS' AND tbTempSetoff.Temp_DocNo = '" + lblTempDocNo.Text.ToString() + "' AND tbTempSetoff.Loca = '" + LoginManager.LocaCode+"' " ;
                
                ObjPaymentSetOff.ReadTempTransDetails();
                if (ObjPaymentSetOff.RecordFound != true)
                {
                    MessageBox.Show("Payment Set Off Details Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Payment Apply
                if (MessageBox.Show("Do You want to Apply This Payment Set Off. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    

                    DataSet dsDataForReport = new DataSet();
                    DataSet dsDataForSubReport = new DataSet();

                    frmReportViewer objRepViewer = new frmReportViewer();
                    objRepViewer.Text = this.Text;

                    ObjPaymentSetOff.strCustCode = txtCustCode.Text.Trim();
                    ObjPaymentSetOff.SuppCode = txtSuppCode.Text.Trim();

                        ObjPaymentSetOff.SetOffApply();
                        MessageBox.Show("Supplier/Customer Set Off Successfully Applied as Document No. " + ObjPaymentSetOff.OrgDocNo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ObjPaymentSetOff.GetDataSetForReport();
                        dsDataForReport = ObjPaymentSetOff.GetReportDataset;
                        rptSetOffDebCred rptSetOffDC = new rptSetOffDebCred();
                        rptSetOffDC.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSetOffDC;
                    

                    objRepViewer.Show();
                    this.Close();
                    this.Dispose();
                    PaymentSetOff = null;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

                if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() == string.Empty)
                {
                    ObjPaymentSetOff.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                }
                else
                {
                    if (txtSuppCode.Text.Trim() != string.Empty && txtSuppName.Text.Trim() == string.Empty)
                    {
                        ObjPaymentSetOff.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtSuppCode.Text.Trim() + "%' ORDER BY Supp_Code";
                    }
                    else
                    {
                        if (txtSuppCode.Text.Trim() == string.Empty && txtSuppName.Text.Trim() != string.Empty)
                        {
                            ObjPaymentSetOff.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                        }
                        else
                        {
                            ObjPaymentSetOff.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                        }
                    }
                }
                
                ObjPaymentSetOff.DataetName = "dsSupplier";
                ObjPaymentSetOff.GetSupplierDetails();
                search.dgSearch.DataSource = ObjPaymentSetOff.GetSupplierDataset.Tables["dsSupplier"];
                search.prop_Focus = txtSuppCode;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void txtSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtSuppCode.Text.Trim() != "")                
                {
                    
                    ObjPaymentSetOff.SuppCode = txtSuppCode.Text.ToString().Trim();
                    ObjPaymentSetOff.SqlStatement = "SELECT Supp_Code, Supp_Name FROM Supplier WHERE Supp_Code = '" + txtSuppCode.Text.Trim() + "'";
                    
                    ObjPaymentSetOff.ReadSupplierDetails();
                    if (ObjPaymentSetOff.RecordFound == true)
                    {
                        txtSuppCode.Text = ObjPaymentSetOff.SuppCode;
                        txtSuppName.Text = ObjPaymentSetOff.SuppName;
                        //txtSuppName.Focus();
                        if (MessageBox.Show("Are You Sure You want to Load Supplier Transaction ", "Supplier Payment Set Off", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            this.LoadSupplierDetails();

                            //Linked Customer Load
                            ObjPaymentSetOff.SqlStatement = "select Customer.Cust_Code, Customer.Cust_NAme FROM tb_LinkedCustSupp INNER JOIN Supplier ON Supplier.Supp_Code=tb_LinkedCustSupp.Supp_Code INNER JOIN Customer ON Customer.Cust_Code=tb_LinkedCustSupp.Cust_Code WHERE Supplier.Supp_Code='"+txtSuppCode.Text.Trim()+"' ";
                            ObjPaymentSetOff.ReadCustomerDetails();
                            if (ObjPaymentSetOff.RecordFound)
                            {
                                txtCustCode.Text = ObjPaymentSetOff.strCustCode;
                                txtCustName.Text = ObjPaymentSetOff.strCustName;
                                this.LoadCustomerDetails();
                            }

                            //====================
                        }
                    }
                    else
                    {
                        MessageBox.Show("Supplier Code Not Found.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSuppCode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void dataGridViewReturns_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewReturns.SelectedRows.Count <= 0 || dataGridViewReturns.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblReturnDocNO.Text = dataGridViewReturns.SelectedRows[0].Cells[0].Value.ToString();
                    lblReturnDocumentDate.Text = dataGridViewReturns.SelectedRows[0].Cells[1].Value.ToString();
                    lblReturnDocumentAmount.Text = dataGridViewReturns.SelectedRows[0].Cells[2].Value.ToString();
                    txtReturnAmount.Text = dataGridViewReturns.SelectedRows[0].Cells[3].Value.ToString();
                    decSelectAmount = decimal.Parse(dataGridViewReturns.SelectedRows[0].Cells[3].Value.ToString());
                    decSelRetAmount = decimal.Parse(dataGridViewReturns.SelectedRows[0].Cells[3].Value.ToString());
                    if (decimal.Parse(txtPendingPaymentAmount.Text.ToString()) <= decSelPendingAmount && decimal.Parse(txtReturnAmount.Text.ToString()) <= decSelRetAmount)
                    {
                        if (decSelectAmount < decimal.Parse(txtPendingPaymentAmount.Text.ToString()))
                        {
                            txtPendingPaymentAmount.Text = dataGridViewReturns.SelectedRows[0].Cells[3].Value.ToString();
                        }
                        else
                        {
                            txtReturnAmount.Text = txtPendingPaymentAmount.Text;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Selected Amount. Please Check Selected Amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtReturnAmount.Select(0, txtPendingPaymentAmount.Text.Trim().Length);
                    txtReturnAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewPendingPayment_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPendingPayment.SelectedRows.Count <= 0 || dataGridViewPendingPayment.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblPendingDocNo.Text = dataGridViewPendingPayment.SelectedRows[0].Cells[0].Value.ToString();
                    lblPendingDocumentDate.Text = dataGridViewPendingPayment.SelectedRows[0].Cells[1].Value.ToString();
                    lblPendingDocumentAmount.Text = dataGridViewPendingPayment.SelectedRows[0].Cells[2].Value.ToString();
                    txtPendingPaymentAmount.Text = dataGridViewPendingPayment.SelectedRows[0].Cells[3].Value.ToString();
                    decSelectAmount = decimal.Parse(dataGridViewPendingPayment.SelectedRows[0].Cells[3].Value.ToString());
                    decSelPendingAmount = decimal.Parse(dataGridViewPendingPayment.SelectedRows[0].Cells[3].Value.ToString());
                    txtPendingPaymentAmount.Select(0, txtPendingPaymentAmount.Text.Trim().Length);
                    txtPendingPaymentAmount.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtReturnAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter )
                {
                    txtPendingPaymentAmount.Text = txtReturnAmount.Text;
                    if (lblPendingDocNo.Text.Trim() != string.Empty && lblReturnDocNO.Text.Trim() != string.Empty && clsValidation.isNumeric(txtPendingPaymentAmount.Text, System.Globalization.NumberStyles.Currency) == true && clsValidation.isNumeric(txtReturnAmount.Text, System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtPendingPaymentAmount.Text) > 0 && decimal.Parse(txtReturnAmount.Text) > 0 && decimal.Parse(txtPendingPaymentAmount.Text) <= decimal.Parse(lblPendingDocumentAmount.Text) && decimal.Parse(txtPendingPaymentAmount.Text) == decimal.Parse(txtReturnAmount.Text))
                    {
                        if (decimal.Parse(txtPendingPaymentAmount.Text.ToString()) <= decSelPendingAmount && decimal.Parse(txtReturnAmount.Text.ToString()) <= decSelRetAmount)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Invalid Selected Amount. Please Check Selected Amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtReturnAmount.Text = decSelRetAmount.ToString();
                            return;
                        }

                        if (MessageBox.Show("Do You Want Add to Payment List ? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (decSelectAmount < decimal.Parse(txtPendingPaymentAmount.Text.ToString()))
                            {
                                MessageBox.Show("Invalid Amount. Please Enter Valid Amount. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtPendingPaymentAmount.Text = decSelectAmount.ToString();
                                return;
                            }

                            ObjPaymentSetOff.TempDocNo = lblTempDocNo.Text.Trim();
                            ObjPaymentSetOff.PendingDocNo = lblPendingDocNo.Text.Trim();
                            ObjPaymentSetOff.PendingPayAmount = decimal.Parse(txtPendingPaymentAmount.Text.ToString());
                            ObjPaymentSetOff.ReturnDocNo = lblReturnDocNO.Text.Trim();
                            ObjPaymentSetOff.ReturnPayAmount = decimal.Parse(txtReturnAmount.Text.ToString());
                            ObjPaymentSetOff.AddToSetOffList();

                            //Refreshing DataGrid View
                            ObjPaymentSetOff.GetTempDataset();

                            dataGridViewPendingPayment.DataSource = ObjPaymentSetOff.GetPendingPayment.Tables["PendingPayments"];
                            dataGridViewPendingPayment.Refresh();
                            dataGridViewReturns.DataSource = ObjPaymentSetOff.SupplierReturn.Tables["PendingReturns"];
                            dataGridViewReturns.Refresh();
                            dataGridViewSetOff.DataSource = ObjPaymentSetOff.SelectedsSetOff.Tables["SelectedSetoff"];
                            dataGridViewSetOff.Refresh();

                            ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_CRD WHERE Iid = 'DCS-C' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                            ObjPaymentSetOff.ReadPendingTotalAmounts();
                            lblTotalOutstanding.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();

                            ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_DEB WHERE Iid = 'DCS-D' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                            ObjPaymentSetOff.ReadPendingTotalAmounts();
                            lblTotalReturn.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();

                            lblPendingDocNo.Text = string.Empty;
                            lblPendingDocumentDate.Text = string.Empty;
                            lblPendingDocumentAmount.Text = string.Empty;
                            txtPendingPaymentAmount.Text = string.Empty;
                            lblReturnDocNO.Text = string.Empty;
                            lblReturnDocumentDate.Text = string.Empty;
                            lblReturnDocumentAmount.Text = string.Empty;
                            txtReturnAmount.Text = string.Empty;

                            txtSuppCode.Enabled = false;
                            txtSuppName.Enabled = false;
                            btnSupplierSearch.Enabled = false;

                            txtCustCode.Enabled = false;
                            txtCustName.Enabled = false;
                            btnCustSearch.Enabled = false;
                        }

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewSetOff_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dataGridViewSetOff.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete This Item. ", "Payment Set Off", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObjPaymentSetOff.TempDocNo = lblTempDocNo.Text.Trim();
                        ObjPaymentSetOff.PendingDocNo = dataGridViewSetOff.SelectedRows[0].Cells[0].Value.ToString();
                        ObjPaymentSetOff.ReturnDocNo = dataGridViewSetOff.SelectedRows[0].Cells[4].Value.ToString();
                        
                        ObjPaymentSetOff.DeleteSetOffDetaile();
                        ObjPaymentSetOff.GetTempDataset();
                        

                        //Refreshing DataGrid View
                        dataGridViewPendingPayment.DataSource = ObjPaymentSetOff.GetPendingPayment.Tables["PendingPayments"];
                        dataGridViewPendingPayment.Refresh();
                        dataGridViewReturns.DataSource = ObjPaymentSetOff.SupplierReturn.Tables["PendingReturns"];
                        dataGridViewReturns.Refresh();
                        dataGridViewSetOff.DataSource = ObjPaymentSetOff.SelectedsSetOff.Tables["SelectedSetoff"];
                        dataGridViewSetOff.Refresh();

                        ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_CRD WHERE Iid = 'DCS-C' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        ObjPaymentSetOff.ReadPendingTotalAmounts();
                        lblTotalOutstanding.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();

                        ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_DEB WHERE Iid = 'DCS-D' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                        ObjPaymentSetOff.ReadPendingTotalAmounts();
                        lblTotalReturn.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();


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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPaymentSetOff_KeyDown(object sender, KeyEventArgs e)
        {
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
                                this.btnClose.PerformClick();
                            }
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
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmDebCredSetOff 014.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() == string.Empty)
                {
                    ObjPaymentSetOff.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer ORDER BY Cust_Code";
                }
                else
                {
                    if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                        ObjPaymentSetOff.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                        {
                            ObjPaymentSetOff.SqlStatement = " SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%' ORDER BY Cust_Name";
                        }
                        else
                        {
                            ObjPaymentSetOff.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer ORDER BY Cust_Code";

                        }
                    }
                }
                ObjPaymentSetOff.DataetName = "dsCustomer";
                ObjPaymentSetOff.GetSupplierDetails();
                search.dgSearch.DataSource = ObjPaymentSetOff.GetSupplierDataset.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "")
            {

                ObjPaymentSetOff.strCustCode = txtCustCode.Text.ToString().Trim();
                ObjPaymentSetOff.SqlStatement = "SELECT Cust_Code , Cust_Name FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "'";

                ObjPaymentSetOff.ReadCustomerDetails();
                if (ObjPaymentSetOff.RecordFound == true)
                {
                    txtCustCode.Text = ObjPaymentSetOff.strCustCode;
                    txtCustName.Text = ObjPaymentSetOff.strCustName;

                    if (MessageBox.Show("Are You Sure You want to Load Customer Transaction ", "Customer Payment Set Off", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.LoadCustomerDetails();

                        //Linked Supplier Load
                        ObjPaymentSetOff.SqlStatement = "select Supplier.Supp_Code, Supplier.Supp_Name FROM tb_LinkedCustSupp INNER JOIN Supplier ON Supplier.Supp_Code=tb_LinkedCustSupp.Supp_Code INNER JOIN Customer ON Customer.Cust_Code=tb_LinkedCustSupp.Cust_Code WHERE Customer.Cust_Code='" + txtCustCode.Text.Trim() + "' ";
                        ObjPaymentSetOff.ReadSupplierDetails();
                        if (ObjPaymentSetOff.RecordFound)
                        {
                            txtSuppCode.Text = ObjPaymentSetOff.SuppCode;
                            txtSuppName.Text = ObjPaymentSetOff.SuppName;
                            this.LoadSupplierDetails();
                        }

                        //====================
                    }
                }
                else
                {
                    MessageBox.Show("Supplier Code Not Found.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustCode.Focus();
                }
            }
        }

        public void LoadCustomerDetails()
        {
            try
            {
                ObjPaymentSetOff.LoadCustomerTransaction();
                ObjPaymentSetOff.GetTempDataset();
                //Refreshing DataGrid View
                dataGridViewPendingPayment.DataSource = ObjPaymentSetOff.GetPendingPayment.Tables["PendingPayments"];
                dataGridViewPendingPayment.Refresh();
                dataGridViewReturns.DataSource = ObjPaymentSetOff.SupplierReturn.Tables["PendingReturns"];
                dataGridViewReturns.Refresh();
                dataGridViewSetOff.DataSource = ObjPaymentSetOff.SelectedsSetOff.Tables["SelectedSetoff"];
                dataGridViewSetOff.Refresh();

                ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_CRD WHERE Iid = 'DCS-C' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                ObjPaymentSetOff.ReadPendingTotalAmounts();
                lblTotalOutstanding.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();

                ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_DEB WHERE Iid = 'DCS-D' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                ObjPaymentSetOff.ReadPendingTotalAmounts();
                lblTotalReturn.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        public void LoadSupplierDetails()
        {
            try
            {
                ObjPaymentSetOff.LoadSupplierTransaction();
                ObjPaymentSetOff.GetTempDataset();
                //Refreshing DataGrid View
                dataGridViewPendingPayment.DataSource = ObjPaymentSetOff.GetPendingPayment.Tables["PendingPayments"];
                dataGridViewPendingPayment.Refresh();
                dataGridViewReturns.DataSource = ObjPaymentSetOff.SupplierReturn.Tables["PendingReturns"];
                dataGridViewReturns.Refresh();
                dataGridViewSetOff.DataSource = ObjPaymentSetOff.SelectedsSetOff.Tables["SelectedSetoff"];
                dataGridViewSetOff.Refresh();

                ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_CRD WHERE  Iid = 'DCS-C' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                ObjPaymentSetOff.ReadPendingTotalAmounts();
                lblTotalOutstanding.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();

                ObjPaymentSetOff.SqlStatement = "select ISNULL(SUM(Balance_Amount), 0) PendingPayTotalAmt from tbPendingPayments_DEB WHERE  Iid = 'DCS-D' AND Temp_DocNo = '" + lblTempDocNo.Text.Trim() + "' AND Loca = ";
                ObjPaymentSetOff.ReadPendingTotalAmounts();
                lblTotalReturn.Text = ObjPaymentSetOff.PendingPayTotalAmt.ToString();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

    }
}