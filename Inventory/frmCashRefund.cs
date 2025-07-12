using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using CrystalDecisions.Shared;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmCashRefund : Form
    {
        public frmCashRefund()
        {
            InitializeComponent();
        }

        clsCustomerReturn objCustomerReturn = new clsCustomerReturn();
        private frmSearch search = new frmSearch();



        private static frmCashRefund getCashRefund;
        public static frmCashRefund _getCashRefund
        {
            get { return getCashRefund; }
            set { getCashRefund = value; }
        }


        private void rdbCashCust_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashRefund 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void rdbCreditCust_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashRefund 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "")
                {
                    objCustomerReturn.CustCode = txtCustCode.Text.ToString().Trim();
                    if (rdbCashCust.Checked==true)
                    {
                        objCustomerReturn.SqlStatement = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "' AND paymentType IN ('CASH','BOTH')";
                    }
                    else if (rdbCreditCust.Checked==true)
                    {
                        objCustomerReturn.SqlStatement = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "' AND paymentType IN ('CREDIT','BOTH')";
                    }
                    objCustomerReturn.ReadCustomerDetails();
                    if (objCustomerReturn.RecordFound == true)
                    {
                        txtCustCode.Text = objCustomerReturn.CustCode;
                        txtCustName.Text = objCustomerReturn.CustName;
                        lblCustAddress1.Text = objCustomerReturn.Address1;
                        lblCustAddress2.Text = objCustomerReturn.Address2;
                        lblCustAddress3.Text = objCustomerReturn.Address3;
                        btnDocSearch.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCustCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashRefund 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtCustCode.Text.Trim()!=string.Empty)
                {
                    objCustomerReturn.SqlStatement = "SELECT transaction_header.Doc_No [Document No], transaction_header.Post_Date +' '+ Customer.Cust_Name [Customer] FROM transaction_header INNER JOIN Payment_Summary ON Payment_Summary.Doc_No=transaction_header.Doc_No INNER JOIN Customer ON transaction_header.Supplier_Id=Customer.Cust_Code where Payment_Summary.Tr_Type='CUR' AND transaction_header.Loca='" + LoginManager.LocaCode + "' AND payment_Summary.Balance_Amount > 0 AND transaction_header.Supplier_Id='" + txtCustCode.Text.Trim() + "' ORDER BY RIGHT(transaction_header.Doc_No,6) DESC";
                }
                else
                {
                    MessageBox.Show("Customer Code Not Found.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustCode.Focus();
                    return;
                }
                
                
                objCustomerReturn.DataetName = "Table";
                objCustomerReturn.GetItemDetails();

                search.dgSearch.DataSource = objCustomerReturn.GetItemDataset.Tables["Table"];
                search.Show();

                search.prop_Focus = txtInvoiceNo;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    if (clsValidation.isNumeric(txtRefundAmount.Text.Trim(), System.Globalization.NumberStyles.Currency) == true && decimal.Parse(txtRefundAmount.Text.Trim()) <= decimal.Parse(lblInvoiceAmount.Text.Trim()) && decimal.Parse(txtRefundAmount.Text.Trim()) > 0 )
                    {
                        btnApply.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Amount.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRefundAmount.Focus();
                    }
                    txtReason.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashRefund 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                bool MultiCus = Settings.Default.MultiCus;
                string Loca = "";
                if (MultiCus == true)
                {
                    Loca = " and CLoca ='" + LoginManager.LocaCode + "' ";
                }

                if (rdbCashCust.Checked==true)
                {
                    objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE  paymentType IN('CASH','BOTH')";
                }
                else if (rdbCreditCust.Checked==true)
                {
                    objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE  paymentType IN('CREDIT','BOTH')";
                }

                //if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() == string.Empty)
                //{
                //    objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE paymentType='CASH'";
                //}
                //else
                //{
                //    if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                //    {
                //        objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE  WHERE paymentType='CASH' AND Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%'";
                //    }
                //    else
                //    {
                //        if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                //        {
                //            objCustomerReturn.SqlStatement = "Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE  WHERE paymentType='CASH' AND Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%'";
                //        }
                //        else
                //        {
                //            objCustomerReturn.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer  WHERE paymentType='CASH'";
                //        }
                //    }
                //}
                objCustomerReturn.DataetName = "dsCustomer";
                objCustomerReturn.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomerReturn.GetCustomerDataSet.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
                search.Cont_Descript = txtCustName;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCashRefund 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtInvoiceNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if (MessageBox.Show("Are You Sure You want to Refund Invoice No :" + search.Code.Trim() + ". ", "Cash Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objCustomerReturn.InvoiceNo = search.Code.Trim();
                        //objCustomerReturn.SqlStatement = "SELECT Transaction_Header.*, Customer.Cust_Name, Customer.Address1, Customer.Address2, Customer.Address3, Customer.PaymentType, Payment_Summary.Balance_Amount FROM Transaction_Header INNER JOIN Customer ON Customer.Cust_code = Transaction_Header.Supplier_Id INNER JOIN Payment_Summary ON Payment_Summary.Doc_No = Transaction_Header.Doc_No AND Payment_Summary.Tr_Type = Transaction_Header.Iid AND Payment_Summary.Loca = Transaction_Header.Loca AND Payment_Summary.Acc_No = Transaction_Header.Supplier_Id WHERE Transaction_Header.iid = 'CUR' AND Transaction_Header.Doc_No = '" + search.Code.Trim() + "' AND Transaction_Header.Loca = ";
                        objCustomerReturn.SqlStatement = "SELECT Transaction_Header.*, Customer.Cust_Name, Customer.Address1, Customer.Address2, Customer.Address3, Customer.PaymentType, Payment_Summary.Balance_Amount FROM Transaction_Header INNER JOIN Customer ON Customer.Cust_code = Transaction_Header.Supplier_Id INNER JOIN Payment_Summary ON Payment_Summary.Doc_No = Transaction_Header.Doc_No AND Payment_Summary.Loca = Transaction_Header.Loca AND Payment_Summary.Acc_No = Transaction_Header.Supplier_Id WHERE Payment_Summary.Tr_Type = 'CUR' AND Transaction_Header.Doc_No = '" + search.Code.Trim() + "' AND Transaction_Header.Loca = ";
                        objCustomerReturn.ReadCusRetDetail();
                        if (objCustomerReturn.RecordFound)
                        {
                            txtCustCode.Text = objCustomerReturn.CustCode.ToString();
                            txtCustName.Text = objCustomerReturn.CustName.ToString();
                            lblCustAddress1.Text = objCustomerReturn.Address1.ToString();
                            lblCustAddress2.Text = objCustomerReturn.Address2.ToString();
                            lblCustAddress3.Text = objCustomerReturn.Address3.ToString();
                            lblInvoiceAmount.Text = objCustomerReturn.InvoiceAmount.ToString();
                            lblRefInvNo.Text = objCustomerReturn.Reference.ToString().Trim();
                            if (objCustomerReturn.Pay_Type == "CASH")
                            {
                                rdbCashCust.Checked = true;
                            }
                            else
                            {
                                rdbCreditCust.Checked = true;
                            }
                            

                            txtCustCode.Enabled = false;
                            txtCustName.Enabled = false;
                            txtInvoiceNo.Enabled = false;
                            btnDocSearch.Enabled = false;
                            btnCustomerSearch.Enabled = false;
                            groupBox1.Enabled = false;
                            txtRefundAmount.Focus();
                        }
                        else
                        {
                            txtCustCode.Text = string.Empty;
                            txtCustName.Text = string.Empty;
                            lblCustAddress1.Text = string.Empty;
                            lblCustAddress2.Text = string.Empty;
                            lblCustAddress3.Text = string.Empty;
                            lblInvoiceAmount.Text = "0";
                        }
                    }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCashRefund_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                getCashRefund = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtCustCode.Text = string.Empty;
            txtCustName.Text = string.Empty;
            btnCustomerSearch.Enabled = true;
            btnDocSearch.Enabled = true;
            lblCustAddress1.Text = string.Empty;
            lblCustAddress2.Text = string.Empty;
            lblCustAddress3.Text = string.Empty;
            txtInvoiceNo.Text = string.Empty;
            lblInvoiceAmount.Text = string.Empty;
            txtRefundAmount.Text = string.Empty;
            txtReason.Text = string.Empty;
            txtCustCode.Enabled = true;
            txtCustName.Enabled = true;
            txtInvoiceNo.Enabled = true;
            dtPostDate.Text = DateTime.Today.ToShortDateString();
            txtCustCode.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                getCashRefund = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                objCustomerReturn.SqlStatement = "SELECT Cust_Code, Cust_Name, Address1, Address2, Address3 FROM Customer WHERE Cust_Code = '" + txtCustCode.Text.Trim() + "'";
                objCustomerReturn.ReadCustomerDetails();
                if (objCustomerReturn.RecordFound == true)
                {
                    txtCustCode.Text = objCustomerReturn.CustCode;
                    txtCustName.Text = objCustomerReturn.CustName;
                }
                else
                {
                    MessageBox.Show("Customer Code Not Found.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustCode.Focus();
                    return;
                }

                if (txtInvoiceNo.Text.Trim()=="")
                {
                    MessageBox.Show("Refund Document Not Found.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtRefundAmount.Text == "" || clsValidation.isNumeric(txtRefundAmount.Text.Trim(), System.Globalization.NumberStyles.Currency) == false)
                {
                    MessageBox.Show("Invalid Cash Refund Amount.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRefundAmount.Focus();
                    return;
                }

                if (lblInvoiceAmount.Text == "" || clsValidation.isNumeric(lblInvoiceAmount.Text.Trim(), System.Globalization.NumberStyles.Currency) == false)
                {
                    MessageBox.Show("Invalid Document Amount.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblInvoiceAmount.Focus();
                    return;
                }

                if (decimal.Parse(lblInvoiceAmount.Text.Trim()) < 0 || decimal.Parse(lblInvoiceAmount.Text.Trim()) < decimal.Parse(txtRefundAmount.Text.Trim()))
                {
                    MessageBox.Show("Invalid Refund/Invoice Amount.", "Cash Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                objCustomerReturn.CustCode = txtCustCode.Text.Trim().ToUpper();
                objCustomerReturn.CustName = txtCustName.Text.Trim().ToUpper();
                objCustomerReturn.PostDate = dtPostDate.Text.Trim();

                objCustomerReturn.TempDocNo = lblTempDocNo.Text.Trim().ToUpper();//Temp Document No
                objCustomerReturn.Reference = txtInvoiceNo.Text.Trim().ToUpper();//Customer Return Document No
                objCustomerReturn.InvoiceNo = lblRefInvNo.Text.Trim().ToUpper();//Ref Invoice Document No

                objCustomerReturn.Amount = decimal.Parse(txtRefundAmount.Text.Trim());//Refund Amount                
                objCustomerReturn.InvoiceAmount = decimal.Parse(lblInvoiceAmount.Text.Trim());//Customer Return Document Amount
                objCustomerReturn.Reason = txtReason.Text.Trim();

                objCustomerReturn.CashRefundApply();
                MessageBox.Show("Cash Refund Successfully Applied as Document No. " + objCustomerReturn.OrgDocNo, "Cash Refund Apply", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet dsDataForReport = new DataSet();
                frmReportViewer objRepViewer = new frmReportViewer();
                objRepViewer.Text = this.Text;

                objCustomerReturn.GetDataSetForRptCashRefund(Settings.Default.Shinghala);

                if (Settings.Default.Shinghala)
                {
                    objCustomerReturn.GetReportDataset.Tables["dsInvoiceDetails1"].TableName = "dsCompanyLogo";
                    dsDataForReport = objCustomerReturn.GetReportDataset;
                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCashRefundDetails.rpt");
                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                }
                else
                {
                    objCustomerReturn.GetReportDataset.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                    dsDataForReport = objCustomerReturn.GetReportDataset;
                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCashRefundDetails_eng.rpt");
                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                }

                
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();



                this.Close();
                this.Dispose();
                getCashRefund = null;


                
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCustomerReturn 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCashRefund_Load(object sender, EventArgs e)
        {
            try
            {
                clsCommon objCommon = new clsCommon();
                if (objCommon.CheckUnit().Tables[0].Rows.Count > 0)
                {
                    LoginManager.MachineUnit = (int)objCommon.Ads.Tables[0].Rows[0][0];
                }
                else
                {
                    MessageBox.Show("Invalid Unit", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnApply.Enabled = false;

                }

                if (Settings.Default.SaleDateEna == true)
                {
                    dtPostDate.Enabled = true;
                }
                else
                {
                    dtPostDate.Enabled = false;
                }
                objCustomerReturn.SqlStatement = "SELECT Temp_CurCA FROM DocumentNoDetails WHERE Loca = ";
                objCustomerReturn.GetTempDocumentNoCASH();
                lblTempDocNo.Text = objCustomerReturn.TempDocNo;
            }
            catch (Exception ex)
            {

            }
            
        }

        private void txtReason_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnApply.PerformClick();
            }
        }
    }
}