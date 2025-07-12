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
using CrystalDecisions.Shared;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmTransactionInquary : Form
    {
        public int intRepOption;
        private string strQuery;

        public frmTransactionInquary()
        {
            InitializeComponent();
        }

        private static frmTransactionInquary TransactionInquary;

        clsTransactionInquary  objTransactionInquary = new clsTransactionInquary();

        private frmSearch search = new frmSearch();

        public static frmTransactionInquary GetTransactionInquary
        {
            get
            {
                return TransactionInquary;
            }
            set
            {
                TransactionInquary = value;
            }
        }

        private void frmTransactionInquary_Load(object sender, EventArgs e)
        {
            DateTime PostDate = DateTime.Now;
            try
            {
                dtDateFrom.Value = PostDate;
                dtDateTo.Value = PostDate;

                switch (intRepOption)
                {
                    case 239:
                    case 240:
                        label2.Visible = false;
                        label1.Visible = false;
                        txtCodeFrom.Visible = false;
                        txtCodeTo.Visible = false;
                        btnDocumentTo.Visible = false;
                        btnDocumentFrom.Visible = false;
                        radioButtonDocumentNo.Visible = false;
                        radioButtonDate.Visible = false;
                        //label1.Text = "Account No";
                        cmbtype.Visible = true;

                        cmbtype.Items.Clear();
                        cmbtype.Items.Add("ALL");
                        cmbtype.Items.Add("CHEQUE");
                        cmbtype.Items.Add("CASH");
                        cmbtype.Top = 37;
                        break;

                    case 247:
                        radioButtonDocumentNo.Enabled = txtCodeFrom.Enabled = txtCodeTo.Enabled = btnDocumentFrom.Enabled = btnDocumentTo.Enabled = false;
                        break;
                    case 237: //Cash IN/OUT Note
                    case 229:
                    case 200://whole sale invoice
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 201://Purchase Order
                    case 233:
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;
                    case 2020://Good Received Note with invoice NO
                    case 202://Good Received Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 249:
                    case 250:
                    case 203://Stock adjustment
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 204://transfer note details
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 205://Supplier Payment
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 243:
                    case 245:
                    case 206://whole sale invoice
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 207://Customer Return
                    case 235://Cash Return
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 208://Payment Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 244:
                    case 246:
                    case 209://Receipt Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 210://Receipt Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 236://Cash Return Summary
                    case 211://Customer Return Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 212://Purchase Order Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 213://Good Received Note Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 248:
                    case 214://Stock Adjustment Note Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 215://Transfer Note Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 216://Supplier Return Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 217://Supplier Return Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 218://Cheque Recon Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 219://Product Packeting Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 220://Product To be Return details
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 221://Payment set off Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 222://Payment setoff Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 223://Payment set off Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 224://Payment set off Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 225://Payment setoff Summary
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        break;

                    case 226://Payment set off Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;

                    case 227://Quotation

                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;
                    case 231://Advance report 
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        radioButtonDocumentNo.Checked = true;
                        rdbcustomer.Checked = true;
                        grpSuppCust.Visible = true;
                        radioButtonDate.Enabled = false;
                        break;
                    case 232://OP Balance
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
                        break;
                    case 228:
                        rdbcustomer.Visible = true;
                        rdbsupplier.Visible = true;
                        grpSuppCust.Visible = true;
                        break;

                    case 241://Deb cred set off Note
                        txtCodeTo.Enabled = false;
                        btnDocumentTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        radioButtonDocumentNo.Enabled = false;
                        radioButtonDate.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                TransactionInquary = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDocumentFrom_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                switch (intRepOption)
                {
                    case 249: //Stock Adjustment
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = " SELECT Doc_No [Document No], Transaction_Date [Doc Date] FROM dbo.Account_TransSummary  WHERE Iid = 'EXP' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Transaction_Date [Doc Date] FROM dbo.Account_TransSummary WHERE Iid = 'EXP' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;
                    case 250: //Stock Adjustment
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Transaction_Date [Doc Date] FROM dbo.Account_TransSummary WHERE Iid = 'EXR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Transaction_Date [Doc Date] FROM dbo.Account_TransSummary  WHERE Iid = 'EXR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;

                    case 200:   //Whole Sale Invoice
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'  ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;

                    case 201://Purchase Order
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;

                    case 202://Grn
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;
                    case 2020://Grn (Invoice No)
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Inv_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Inv_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Inv_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    
                    case 203: //Stock Adjustment
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'STA' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'STA' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;

                    case 204://transfer note details
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], To_LocaDesc [To Location] FROM Transaction_Header WHERE Iid = 'TGN' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], To_LocaDesc [To Location] FROM Transaction_Header WHERE Iid = 'TGN' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 205://Supp Payment
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Supplier.Supp_Name [Supplier] FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE tbPaidPaymentSummary.Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Org_Doc_no, Supp_Name ORDER BY RIGHT(Org_Doc_no,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Supplier.Supp_Name [Supplier] FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE tbPaidPaymentSummary.Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no, Supp_Name ORDER BY RIGHT(Org_Doc_no,6) DESC";
                        }
                        break;

                    case 206:// Receipt
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Customer.Cust_Name [Customer] FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Org_Doc_no, Cust_Name ORDER BY RIGHT(Org_Doc_no,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Customer.Cust_Name [Customer] FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no, Cust_Name ORDER BY RIGHT(Org_Doc_no,6) DESC";
                        }
                        break;

                    case 207:   //Customer Return
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CUR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CUR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 208://Supp Payment  Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Supplier.Supp_Name [Supplier] FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Org_Doc_no, Supp_Name ORDER BY RIGHT(Org_Doc_no,6) ";
                        }
                        else
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Supplier.Supp_Name [Supplier] FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no, Supp_Name ORDER BY RIGHT(Org_Doc_no,6) ";
                        }
                        break;

                    case 209:// Receipt Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Customer.Cust_Name [Customer] FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Org_Doc_no, Cust_Name ORDER BY RIGHT(Org_Doc_no,6) ";
                        }
                        else
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Customer.Cust_Name [Customer] FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no, Cust_Name ORDER BY RIGHT(Org_Doc_no,6) ";
                        }
                        break;

                    case 210:// Invoice Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date + '  ' + Customer.Cust_Name [Doc Date    Customer Name] FROM Transaction_Header Inner Join Customer on Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date + '  ' + Customer.Cust_Name [Doc Date    Customer Name] FROM Transaction_Header Inner Join Customer on Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 211:// Customer Return Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CUR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CUR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 212://Purchase Order
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 213://Grn summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }

                        break;
                    case 214: //Stock Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'STA' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'STA' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }

                        break;

                    case 215://transfer note Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], To_LocaDesc [To Location] FROM Transaction_Header WHERE Iid = 'TGN' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], To_LocaDesc [To Location] FROM Transaction_Header WHERE Iid = 'TGN' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) ASC";
                        }

                        break;

                    case 216://Supplier Return
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;

                    case 217://Supplier Return summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }

                        break;

                    case 218://Cheque Reco Note
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "select Doc_No [Document No], Post_Date + ' ' + Reference [Date  Account] from transaction_header where (iid = 'PRT' OR Iid = 'RRT') AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Doc_No,Reference, Post_Date ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "select Doc_No [Document No], Post_Date + ' ' + Reference [Date  Account] from transaction_header where (iid = 'PRT' OR Iid = 'RRT') AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_No,Reference, Post_Date ORDER BY RIGHT(Doc_No,6)";
                        }

                        break;

                    case 219://Product Packeting Note
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "select Doc_No [Document No], Post_Date [Date] from tbPacketingProductDetails where tbPacketingProductDetails.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) desc";
                        }
                        else
                        {
                            strQuery = "select Doc_No [Document No], Post_Date [Date] from tbPacketingProductDetails where tbPacketingProductDetails.Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) desc";
                        }

                        break;

                    case 220://Product To Be Retrun
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'TOR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'TOR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }

                        break;

                    case 221://Payment Set Off
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 222://Payment Set Off
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 223://Payment Set Off Grn No wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Doc_no ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_no ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 224://Payment Set Off
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 225://Payment Set Off Grn No wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Org_Doc_no,Post_Date ORDER BY RIGHT(Org_Doc_no,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no,Post_Date ORDER BY RIGHT(Org_Doc_no,6)";
                        }
                        break;

                    case 226://Payment Set Off
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Doc_no, Post_Date ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_no, Post_Date ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;
                    case 227:   //Quotation
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'QUO' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'QUO' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;
                    case 231:   //Advance Report
                        if (rdbcustomer.Checked == true)
                        {
                            strQuery = "SELECT DISTINCT Org_Doc_no [Document NO],Post_Date [Post Date] FROM tbPaidPaymentSummary WHERE Iid='CADV' AND Loca='" + LoginManager.LocaCode + "' ORDER BY Org_Doc_no DESC";
                        }
                        else
                        {
                            strQuery = "SELECT DISTINCT Org_Doc_no [Document NO],Post_Date [Post Date] FROM tbPaidPaymentSummary WHERE Iid='SADV' AND Loca='" + LoginManager.LocaCode + "' ORDER BY Org_Doc_no DESC";
                        }
                        break;
                    case 248:
                    case 232:   //OPST
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'OPS' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'OPS' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;
                    case 228:
                        if (rdbcustomer.Checked == true)
                        {
                            if (txtCodeFrom.Text.Trim() != string.Empty)
                            {
                                strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid= 'RRT' AND Loca='" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) ASC ";
                            }
                            else
                            {
                                strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'RRT' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) ASC";
                            }
                        }
                        else
                        {
                            if (txtCodeFrom.Text.Trim() != string.Empty)
                            {
                                strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid= 'PRT' AND Loca='" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) ASC ";
                            }
                            else
                            {
                                strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'PRT' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) ASC";
                            }
                        }

                        break;

                    case 229://Product Discard Note
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'PDN' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'PDN' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        break;

                    case 230://Product Discard Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'PDN' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'PDN' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        break;
                    case 233:   //Combination
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No, Post_Date FROM Transaction_Header WHERE Iid='BIS' AND Loca='" + LoginManager.LocaCode + "' AND Doc_No='" + txtCodeFrom.Text + "'";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No, Post_Date FROM Transaction_Header WHERE Iid='BIS' AND Loca='" + LoginManager.LocaCode + "' ";
                        }
                        break;

                    case 234:   //Special discount Report
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Discount >0 AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'  ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Discount >0 ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        break;

                    case 235:   //Cash Return
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CAR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CAR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 236:// Cash Return Summary
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CAR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CAR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 238:
                    case 237:
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], PostDate [Doc Date] FROM tb_CashINOUTDetails WHERE  Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], PostDate [Doc Date] FROM tb_CashINOUTDetails WHERE  Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 240://Cheque Withdrowals 
                    case 239://Cheque Diposited 
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Branch_ACNo [Account No],Bank_Name [Bank],Branch FROM BankDetails WHERE Branch_ACNo LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ";
                        }
                        else
                        {
                            strQuery = "SELECT Branch_ACNo [Account No],Bank_Name [Bank],Branch FROM BankDetails ";
                        }
                        break;

                    case 241://Payment Set Off
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'DCS' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'DCS' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;
                    case 242:   //Special discount Report
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT distinct Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Discount >0 AND Doc_No LIKE '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT distinct Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Discount >0 ";
                        }
                        break;
                    case 243:   //ROA
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='ROA' AND Loca='"+ LoginManager.LocaCode+"' and docNo like '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='ROA' AND Loca='" + LoginManager.LocaCode + "'";
                        }
                        break;
                    case 244:   //ROA
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='ROA' AND Loca='" + LoginManager.LocaCode + "' and docNo like '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='ROA' AND Loca='" + LoginManager.LocaCode + "'";
                        }
                        break;

                    case 245:   //CDNM
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='CDNM' AND Loca='" + LoginManager.LocaCode + "' and docNo like '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='CDNM' AND Loca='" + LoginManager.LocaCode + "'";
                        }
                        break;
                    case 246:   //CDNM
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='CDNM' AND Loca='" + LoginManager.LocaCode + "' and docNo like '%'+'" + txtCodeFrom.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='CDNM' AND Loca='" + LoginManager.LocaCode + "'";
                        }
                        break;

                    default:
                        break;
                }

                objTransactionInquary.SqlStatement = strQuery;
                objTransactionInquary.dsName = "Table";
                objTransactionInquary.RetriveData();

                search.dgSearch.DataSource = objTransactionInquary.ResultSet.Tables["Table"];
                search.Show();

                search.prop_Focus = txtCodeFrom;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCodeFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCodeFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodeFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCodeFrom.Text = search.Code.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            CrystalDecisions.CrystalReports.Engine.ReportDocument rep; 
            DataSet dsDataForReport = new DataSet();
            DataSet dsDataForReport2 = new DataSet();

            DialogResult blResult;

            clsReportViewer objRepView = new clsReportViewer();
            frmReportViewer objRepViewer = new frmReportViewer();
           

            try
            {
                objRepViewer.Text = this.Text;

                MainClass.mdi.Cursor = Cursors.WaitCursor;

                if (DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateFrom.Value)) > DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateTo.Value)))
                {
                    MainClass.mdi.Cursor = Cursors.Default;
                    MessageBox.Show("Selected Date Is Not Valid. Please Select Valid Date Range.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string ComName = "";
                string ComAdd = "";
                string ComTel = "";
                switch (intRepOption)
                {
                case 200:


                    bool VatBill = false;

                    clsCommon objComman = new clsCommon();
                    objComman.SqlStatement = "EXEC dbo.Sp_printSingleReports @DocNo = '" + txtCodeFrom.Text.Trim() + "',@Loca = '" + LoginManager.LocaCode + "',@Iid = 'INV',@State = 'Duplicate' ";

                    FrmPrinterSelect ObjPrinterSelect = new FrmPrinterSelect();

                    objComman.GetDs();
                    objComman.Ads.Tables[0].TableName = "dsInvoiceDetails";
                    objComman.Ads.Tables[1].TableName = "CompanyProfile";
                    objComman.Ads.Tables[2].TableName = "tbPaidPaymentMode";

                    ObjPrinterSelect.dsForRep = objComman.Ads;
                    ObjPrinterSelect.IID = "INV";
                    if (MessageBox.Show("Do you want to Print the Bill",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    { ObjPrinterSelect.Print = true; }
                    else
                    { ObjPrinterSelect.Print = false; }
                  
                    ObjPrinterSelect.VatBill = Convert.ToBoolean(objComman.Ads.Tables[0].Rows[0]["VAT"]);
                    ObjPrinterSelect.ShowDialog();
                    return;
                    
                    break;

                    case 201:
                        objRepView.SqlStatement = "SELECT Transaction_Header.Doc_No, Transaction_Header.Post_Date, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Pay_Type, Transaction_Header.Remarks, Transaction_Header.Expected_Date, Transaction_Header.AddRemarks, Transaction_Header.Reference, Transaction_Header.PayRemark1, Transaction_Header.PayRemark2, Transaction_Header.Tax, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Amount, Transaction_Details.Ln, Supplier.Address1, Supplier.Address2, Supplier.Address3, Supplier.Address4, Supplier.Tel, Supplier.Fax, (Transaction_Header.Amount + Transaction_Header.Tax) NetAmount, Transaction_Header.Pay1, 'Duplicate' Status from Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.IId = 'PON' AND Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode.ToString() + "'; SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "dsPurchaseOrderDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        dsDataForReport.Tables[1].TableName = "CompanyProfile";
                        rptPurchaseOrder rptPo = new rptPurchaseOrder();
                        rptPo.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptPo;
                        break;

                    case 202:
                        objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id ,Supplier.Supp_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, ((Selling_Price*Qty)- (Purchase_Price*Qty))/(Purchase_Price * CASE Qty WHEN 0 THEN 1 ELSE QTY END)*100 Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, 'Duplicate' Status, Transaction_Header.User_Name, Transaction_Header.AccessUser, (case ISNUMERIC(Transaction_Details.Code) WHEN 1 THEN CONVERT(DECIMAL(10,3),Transaction_Details.Code) ELSE 0 END) AS Whole_Price,  (( (case ISNUMERIC(Transaction_Details.Code) WHEN 1 THEN CONVERT(DECIMAL(10,3), Transaction_Details.Code) ELSE 0 END)*Qty)- (Purchase_Price*Qty))/(Purchase_Price*case Qty when 0 then 1 else qty end)*100 Wh_Perr,Transaction_Details.VATAmount[Wh_Per],Transaction_Details.Batchno FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca inner join supplier ON Transaction_Header.Supplier_Id = supplier.supp_code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'GRN' ORDER BY Ln;SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "dsGRNDetailsForRep";
                        objRepView.RetrieveData();
                        objRepView.TempResultSet.Tables["dsGRNDetailsForRep1"].TableName = "CompanyProfile";
                        dsDataForReport = objRepView.TempResultSet;
                        blResult = MessageBox.Show("Do You Want To Display Selling Price ?", "Good Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (Settings.Default.TrInCon)
                        {
                            //if (File.Exists(@"..\DirectReports\rptGoodReceivedNote_Con.rpt"))
                            //{
                            //    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNote_Con.rpt");
                            //}
                            //else 
                             if (File.Exists(@"..\DirectReports\rptGoodReceivedNote.rpt"))
                            {
                                if (blResult == DialogResult.Yes)
                                {
                                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNote.rpt");
                                }
                                else
                                {
                                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNoteWithSelprice.rpt");
                                }

                            }
                            else
                            {
                                objRepViewer.DirectPrintVerRep = new rptGoodReceivedNote();
                            }

                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        else
                        {
                            if (File.Exists(@"..\DirectReports\rptGoodReceivedNote.rpt"))
                            {
                                if (blResult == DialogResult.Yes)
                                {
                                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNote.rpt");
                                }
                                else
                                {
                                    objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptGoodReceivedNoteWithSelprice.rpt");
                                }
                                objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                            }
                        }

                        
                        break;

                    case 2020:
                        objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id ,Supplier.Supp_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt AS InvoiceAmount, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, 'Duplicate' Status, Transaction_Header.User_Name, Transaction_Header.AccessUser, ((Selling_Price*Qty)- (Purchase_Price*Qty))/(Purchase_Price * CASE Qty WHEN 0 THEN 1 ELSE QTY END)*100 Inv_Amt, (case ISNUMERIC(Transaction_Details.Code) WHEN 1 THEN CONVERT(DECIMAL,Transaction_Details.Code) ELSE 0 END) AS Whole_Price,  (( (case ISNUMERIC(Transaction_Details.Code) WHEN 1 THEN CONVERT(DECIMAL, Transaction_Details.Code) ELSE 0 END)*Qty)- (Purchase_Price*Qty))/(Purchase_Price*case Qty when 0 then 1 else qty end)*100 Wh_Per FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca inner join supplier ON Transaction_Header.Supplier_Id = supplier.supp_code WHERE Transaction_Header.Inv_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'GRN' ORDER BY Ln;SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "dsGRNDetailsForRep";
                        objRepView.RetrieveData();
                        objRepView.TempResultSet.Tables["dsGRNDetailsForRep1"].TableName = "CompanyProfile";
                        dsDataForReport = objRepView.TempResultSet;
                        blResult = MessageBox.Show("Do You Want To Display Selling Price ?", "Good Received Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (blResult == System.Windows.Forms.DialogResult.Yes)
                        {

                            rptGoodReceivedNote rptGrn = new rptGoodReceivedNote();
                            rptGrn.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptGrn;
                        }
                        else
                        {
                            rptGoodReceivedNoteWithSelprice rptGrn2 = new rptGoodReceivedNoteWithSelprice();
                            rptGrn2.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptGrn2;
                        }
                        break;

                    case 203:
                        objRepView.SqlStatement = "select Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.Doc_No, Transaction_Header.Post_Date, Transaction_Header.[User_Name], Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.Phy_Qty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Pack_Size, Transaction_Details.Ln, 'Duplicate' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_no = Transaction_Details.Doc_no AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.doc_no = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'STA' ORDER BY Ln";
                        objRepView.DataSetName = "dsStockAdjustDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptStockAdjustment StockAdjustment = new rptStockAdjustment();
                        StockAdjustment.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = StockAdjustment;
                        break;

                    case 204:
                        objRepView.SqlStatement = "SELECT Transaction_Header.doc_no, Transaction_Header.Loca, Location.Loca_Descrip LocaDesc, Transaction_Header.To_Loca, Transaction_Header.To_LocaDesc, Transaction_Header.Post_Date, Transaction_Header.Remarks, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Pack_Size, Transaction_Details.Amount,'Duplicate' Status FROM Transaction_Header INNER join Transaction_Details ON Transaction_Header.doc_no = Transaction_Details.doc_no AND Transaction_Header.iid = Transaction_Details.iid AND Transaction_Header.Loca = Transaction_Details.Loca INNER JOIN Location ON Location.Loca = Transaction_Header.Loca WHERE Transaction_Header.doc_no = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'TGN' ORDER BY Ln;SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "dsTogDetails";
                        objRepView.RetrieveData();
                        objRepView.TempResultSet.Tables["dsTogDetails1"].TableName = "CompanyProfile";
                        dsDataForReport = objRepView.TempResultSet;
                        rptTransferNote TransferNote = new rptTransferNote();
                        TransferNote.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = TransferNote;
                        break;

                    case 205:

                        objRepView.SqlStatement = "SELECT tbPaidPaymentDetails.Org_Doc_no, tbPaidPaymentDetails.Post_Date, tbPaidPaymentDetails.Doc_No, tbPaidPaymentDetails.Transaction_Date, tbPaidPaymentDetails.Balance_Amount, tbPaidPaymentDetails.Transaction_Amount, tbPaidPaymentDetails.Paid_Amount, tbPaidPaymentDetails.Loca, Location.Loca_Descrip, tbPaidPaymentDetails.Acc_Code, Supplier.Supp_Name Acc_Name, Supplier.Address1, Supplier.Address2, Supplier.Address3, Supplier.Address4, tbPaidPaymentDetails.[User_Name], 'Duplicate' Status FROM tbPaidPaymentDetails INNER JOIN Supplier ON tbPaidPaymentDetails.Acc_Code = Supplier.Supp_Code INNER JOIN Location ON tbPaidPaymentDetails.Loca = Location.Loca WHERE tbPaidPaymentDetails.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND tbPaidPaymentDetails.Iid = 'PMT' AND tbPaidPaymentDetails.Loca = '" + LoginManager.LocaCode + "';SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "tbPaidPaymentSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepView.TempResultSet.Tables["tbPaidPaymentSummary1"].TableName = "CompanyProfile";
                        objRepView.SqlStatement = "SELECT Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, Branch, Amount FROM tbPaidPaymentSummary WHERE tbPaidPaymentSummary.Iid = 'PMT' AND tbPaidPaymentSummary.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "tbPaidPaymentMode";
                        objRepView.RetrieveData();
                        dsDataForReport2 = objRepView.TempResultSet;

                        if (File.Exists(@"..\DirectReports\rptSupplierPayment.rpt"))
                        {
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptSupplierPayment.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForReport2);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        else
                        {
                            rptSupplierPayment rptPayment = new rptSupplierPayment();
                            rptPayment.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptPayment;
                            rptPayment.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForReport2);
                            objRepViewer.crystalReportViewer1.ReportSource = rptPayment;
                        }
                        
                        break;

                    case 206:

                        if (Settings.Default.Shinghala)
                        {
                            objRepView.SqlStatement = "SELECT tbPaidPaymentDetails.Org_Doc_no, tbPaidPaymentDetails.Post_Date, tbPaidPaymentDetails.Doc_No, tbPaidPaymentDetails.Transaction_Date, tbPaidPaymentDetails.Balance_Amount, tbPaidPaymentDetails.Transaction_Amount, tbPaidPaymentDetails.Paid_Amount, tbPaidPaymentDetails.Loca, Location.Loca_Descrip, tbPaidPaymentDetails.Acc_Code, Customer.Cust_Name Acc_Name, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, tbPaidPaymentDetails.[User_Name], 'Duplicate' Status FROM tbPaidPaymentDetails INNER JOIN Customer ON tbPaidPaymentDetails.Acc_Code = Customer.Cust_Code INNER JOIN Location ON tbPaidPaymentDetails.Loca = Location.Loca WHERE tbPaidPaymentDetails.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND tbPaidPaymentDetails.Iid = 'REC' AND tbPaidPaymentDetails.Loca = '" + LoginManager.LocaCode + "';SELECT * FROM CompanyProfileSinhala";
                            objRepView.DataSetName = "tbPaidPaymentSummary";
                            objRepView.RetrieveData();
                            objRepView.TempResultSet.Tables["tbPaidPaymentSummary1"].TableName = "dsCompanyLogo";
                            dsDataForReport = objRepView.TempResultSet;
                            objRepView.SqlStatement = "SELECT Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, Branch, Amount FROM tbPaidPaymentSummary WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "tbPaidPaymentMode";
                            objRepView.RetrieveData();
                            dsDataForReport2 = objRepView.TempResultSet;
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerPayment.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForReport2);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT tbPaidPaymentDetails.Org_Doc_no, tbPaidPaymentDetails.Post_Date, tbPaidPaymentDetails.Doc_No, tbPaidPaymentDetails.Transaction_Date, tbPaidPaymentDetails.Balance_Amount, tbPaidPaymentDetails.Transaction_Amount, tbPaidPaymentDetails.Paid_Amount, tbPaidPaymentDetails.Loca, Location.Loca_Descrip, tbPaidPaymentDetails.Acc_Code, Customer.Cust_Name Acc_Name, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, tbPaidPaymentDetails.[User_Name], 'Duplicate' Status FROM tbPaidPaymentDetails INNER JOIN Customer ON tbPaidPaymentDetails.Acc_Code = Customer.Cust_Code INNER JOIN Location ON tbPaidPaymentDetails.Loca = Location.Loca WHERE tbPaidPaymentDetails.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND tbPaidPaymentDetails.Iid = 'REC' AND tbPaidPaymentDetails.Loca = '" + LoginManager.LocaCode + "';SELECT * FROM CompanyProfile";
                            objRepView.DataSetName = "tbPaidPaymentSummary";
                            objRepView.RetrieveData();
                            objRepView.TempResultSet.Tables["tbPaidPaymentSummary1"].TableName = "CompanyProfile";
                            dsDataForReport = objRepView.TempResultSet;
                            objRepView.SqlStatement = "SELECT Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, Branch, Amount FROM tbPaidPaymentSummary WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "tbPaidPaymentMode";
                            objRepView.RetrieveData();
                            dsDataForReport2 = objRepView.TempResultSet;
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerPayment_eng.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(dsDataForReport2);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        
                        break;

                    case 207:

                        if (Settings.Default.Shinghala)
                        {
                            objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code ,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Product.Singhala AS Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Duplicate' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code INNER JOIN Product ON Product.Prod_Code=Transaction_Details.Prod_Code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CUR' ORDER BY Ln;SELECT * FROM CompanyProfileSinhala";
                            objRepView.DataSetName = "dsInvoiceDetails";
                            objRepView.RetrieveData();
                            objRepView.TempResultSet.Tables["dsInvoiceDetails1"].TableName = "dsCompanyLogo";
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerReturnDetails.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code ,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Duplicate' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code INNER JOIN Product ON Product.Prod_Code=Transaction_Details.Prod_Code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CUR' ORDER BY Ln;SELECT * FROM CompanyProfile";
                            objRepView.DataSetName = "dsInvoiceDetails";
                            objRepView.RetrieveData();
                            objRepView.TempResultSet.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerReturnDetails_eng.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        //objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code ,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.PayRemark1, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Duplicate' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CUR' ORDER BY Ln;SELECT * FROM CompanyProfile";
                        
                        
                        break;

                    case 208:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Acc_Code, Supplier.Supp_Name Acc_Name, Org_Doc_no, Post_Date, Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, tbPaidPaymentSummary.Branch, Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from tbPaidPaymentSummary INNER JOIN Supplier On tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE (tbPaidPaymentSummary.Org_Doc_no BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND tbPaidPaymentSummary.Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Acc_Code, Supplier.Supp_Name Acc_Name, Org_Doc_no, Post_Date, Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, tbPaidPaymentSummary.Branch, Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from tbPaidPaymentSummary INNER JOIN Supplier On tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE (CONVERT(DATETIME,tbPaidPaymentSummary.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND tbPaidPaymentSummary.Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                        }
                        objRepView.DataSetName = "SupplierPaymentSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPaymentSummary rptPaymentSummary = new rptPaymentSummary();
                        rptPaymentSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptPaymentSummary;
                        break;

                    case 209:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Acc_Code, Customer.Cust_Name Acc_Name, Org_Doc_no, Post_Date, Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, Branch, Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from tbPaidPaymentSummary INNER JOIN Customer On tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE (tbPaidPaymentSummary.Org_Doc_no BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Acc_Code, Customer.Cust_Name Acc_Name, Org_Doc_no, Post_Date, Payment_Mode, Bank_Name, Cheque_No, Cheque_Date, Branch, Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from tbPaidPaymentSummary INNER JOIN Customer On tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE (CONVERT(DATETIME,tbPaidPaymentSummary.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "'";
                        }
                        objRepView.DataSetName = "SupplierPaymentSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptReceiptSummary rptReceiptummary = new rptReceiptSummary();
                        rptReceiptummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptReceiptummary;
                        break;

                    case 210: //Invoice Summary
                        bool DateAll = true ;
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            DateAll = false;
                        }
                        objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '210',@DateFrom = '"+dtDateFrom.Text+"',@DateTo = '"+dtDateTo.Text+"',@CodeFrom = '"+txtCodeFrom.Text+"',@CodeTo = '"+txtCodeTo.Text+"',@Loca = '"+LoginManager.LocaCode+"',@DateAll = '"+DateAll+"'";
                        


                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        if (MessageBox.Show("Do you want to view Report in Small Paper", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rptInvoiceSummarySmall rptInvSummary = new rptInvoiceSummarySmall();
                            dsDataForReport.Tables[1].TableName = "dsInvoiceColSummery";
                            rptInvSummary.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptInvSummary;
                        }
                        else
                        {
                            rptInvoiceSummary rptInvSummary = new rptInvoiceSummary();
                            dsDataForReport.Tables[1].TableName = "dsInvoiceColSummery";
                            rptInvSummary.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptInvSummary;
                        }
                        
                        break;

                    case 211: //Customer Return Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Customer.Cust_Name Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CUR' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Customer.Cust_Name Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CUR' ORDER BY RIGHT(Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCustomerReturnSummary rptCusRetSummary = new rptCustomerReturnSummary();
                        rptCusRetSummary.SetDataSource(dsDataForReport);
                        rptCusRetSummary.SummaryInfo.ReportTitle = "CUSTOMER RETURN SUMMARY";
                        objRepViewer.crystalReportViewer1.ReportSource = rptCusRetSummary;
                        break;

                    case 212: //Purchase Order Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'PON' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Net_Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'PON' ORDER BY RIGHT(Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPurchaseOrderSummary rptPurchSummary = new rptPurchaseOrderSummary();
                        rptPurchSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptPurchSummary;
                        break;

                    case 213: //Grn Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo, TD.Prod_Code,TD.Prod_Name,TD.Purchase_Price,TD.Selling_Price,TD.Qty,TD.FreeQty,TD.Discount[Disc],TD.Amount[ItAmount],P.Barcode from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca JOIN dbo.Transaction_Details TD ON TD.Doc_No = Transaction_Header.Doc_No AND TD.Iid = Transaction_Header.Iid  JOIN dbo.Product P ON P.Prod_Code = TD.Prod_Code INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'GRN' ORDER BY RIGHT(Transaction_Header.Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo, TD.Prod_Code,TD.Prod_Name,TD.Purchase_Price,TD.Selling_Price,TD.Qty,TD.FreeQty,TD.Discount[Disc],TD.Amount[ItAmount],P.Barcode from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca JOIN dbo.Transaction_Details TD ON TD.Doc_No = Transaction_Header.Doc_No AND TD.Iid = Transaction_Header.Iid  JOIN dbo.Product P ON P.Prod_Code = TD.Prod_Code INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'GRN' ORDER BY RIGHT(Transaction_Header.Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptGrnSummary rptGrnSummary = new rptGrnSummary();
                        rptGrnSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptGrnSummary;
                        break;

                    case 214: //Stock Adjustment Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, '' Supplier_Id, '' Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Net_Amount from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'STA' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, '' Supplier_Id, '' Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Net_Amount from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'STA' ORDER BY RIGHT(Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptStockAdjustSummary rptStAdjustSummary = new rptStockAdjustSummary();
                        rptStAdjustSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptStAdjustSummary;
                        break;

                    case 215: //transfer Of Goods Note Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.To_Loca, Transaction_Header.Post_Date, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'TGN' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.To_Loca, Transaction_Header.Post_Date, Transaction_Header.Net_Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'TGN' ORDER BY RIGHT(Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptTogSummary rptTogSummary = new rptTogSummary();
                        rptTogSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptTogSummary;
                        break;

                    case 216:
                        objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id ,Supplier.Supp_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, 'Duplicate' Status, BatchNo, ExpDate FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN supplier ON Transaction_Header.Supplier_Id = supplier.supp_code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'SRN' ORDER BY Ln;SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "dsGRNDetailsForRep";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepView.TempResultSet.Tables["dsGRNDetailsForRep1"].TableName = "CompanyProfile";
                        blResult = MessageBox.Show("Do You Want To Display Selling Price?", "Supplier Return Note", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (blResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            rptSupplierReturnNote rptSrn = new rptSupplierReturnNote();
                            rptSrn.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptSrn;
                        }
                        else
                        {
                            rptSupplierReturnNoteSupp rptSrnSupp = new rptSupplierReturnNoteSupp();
                            rptSrnSupp.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = rptSrnSupp;
                        }
                        break;

                    case 217: //Srn Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'SRN' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'SRN' ORDER BY RIGHT(Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSrnSummary rptSrnSummary = new rptSrnSummary();
                        rptSrnSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSrnSummary;
                        break;

                    case 218:
                        objRepView.SqlStatement = "select transaction_header.Loca, Location.Loca_Descrip, transaction_header.Doc_No, transaction_header.Supplier_Id, transaction_header.Reference Acc_Name, transaction_header.Post_Date, transaction_header.Inv_Date, transaction_header.Inv_No, transaction_header.Code, transaction_header.Amount, transaction_header.Remarks, transaction_header.To_LocaDesc, transaction_header.User_Name, transaction_header.Iid from transaction_header inner join Location on transaction_header.Loca = Location.Loca where (transaction_header.iid = 'RRT' OR transaction_header.iid = 'PRT') AND transaction_header.Loca = '" + LoginManager.LocaCode + "' and transaction_header.Doc_No = '" + txtCodeFrom.Text.ToString() + "'";
                        objRepView.DataSetName = "dsChequeReconDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptChequeRecon rptChequeRecon = new rptChequeRecon();
                        rptChequeRecon.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptChequeRecon;
                        break;

                    case 219:
                        objRepView.SqlStatement = "select tbPacketingProductDetails.Doc_No, tbPacketingProductDetails.Post_Date, tbPacketingProductDetails.Main_Prod_Code, tbPacketingProductDetails.Main_Prod_Name, tbPacketingProductDetails.Prod_Code, tbPacketingProductDetails.Prod_Name, tbPacketingProductDetails.Purchase_price, tbPacketingProductDetails.Packet_Qty, tbPacketingProductDetails.No_Of_Packets, tbPacketingProductDetails.Loca, Location.Loca_Descrip, 'Duplicate' Status from tbPacketingProductDetails inner join Location on tbPacketingProductDetails.Loca = Location.Loca WHERE tbPacketingProductDetails.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND tbPacketingProductDetails.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsPacketingProductNote";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductPacketingNote rptPacketingProduct = new rptProductPacketingNote();
                        rptPacketingProduct.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptPacketingProduct;
                        break;

                    case 220:
                        objRepView.SqlStatement = "SELECT Transaction_Header.doc_no, Transaction_Header.Loca, Location.Loca_Descrip LocaDesc, Transaction_Header.To_Loca, Transaction_Header.To_LocaDesc, Transaction_Header.Post_Date, Transaction_Header.Remarks, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Pack_Size, Transaction_Details.Amount,'Duplicate' Status FROM Transaction_Header INNER join Transaction_Details ON Transaction_Header.doc_no = Transaction_Details.doc_no AND Transaction_Header.iid = Transaction_Details.iid AND Transaction_Header.Loca = Transaction_Details.Loca INNER JOIN Location ON Location.Loca = Transaction_Header.Loca WHERE Transaction_Header.doc_no = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'TOR' ORDER BY Ln";
                        objRepView.DataSetName = "dsTogDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptToBeReturnNote ToBeReturnNote = new rptToBeReturnNote();
                        ToBeReturnNote.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ToBeReturnNote;
                        break;

                    case 221:
                        objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Paid_Amount, PD.Post_Date, PD.SetOff_SR_Doc, PD.Loca, L.Loca_Descrip, PD.Acc_Code, S.Supp_Name, 'Duplicate' Status FROM tbPaidPaymentDetails PD INNER JOIN Location L ON PD.Loca = L.Loca INNER JOIN Supplier S ON PD.Acc_Code = S.Supp_Code WHERE PD.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND PD.Loca = '" + LoginManager.LocaCode + "' AND PD.Iid = 'SOP'";
                        objRepView.DataSetName = "dsPaymentsetOffDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSetOffPayment rptSetOff = new rptSetOffPayment();
                        rptSetOff.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSetOff;
                        break;

                    case 222:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, TH.Net_Amount Transaction_Amount, PD.Balance_Amount, PD.Paid_Amount, PD.Loca, PD.Tr_Date, PD.Acc_Code, PD.Post_Date, PD.SetOff_SR_Doc, L.Loca_Descrip, S.Supp_Name FROM tbPaidPaymentDetails PD INNER JOIN Location L on PD.Loca = L.Loca INNER JOIN SUPPLIER S ON PD.Acc_Code = S.Supp_Code INNER JOIN Transaction_Header TH ON TH.Doc_No = PD.Doc_No AND TH.Loca = PD.Loca WHERE TH.Iid = 'GRN' AND PD.Iid = 'SOP' AND PD.Loca = '" + LoginManager.LocaCode + "' AND (PD.Org_Doc_no BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "')";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, TH.Net_Amount Transaction_Amount, PD.Balance_Amount, PD.Paid_Amount, PD.Loca, PD.Tr_Date, PD.Acc_Code, PD.Post_Date, PD.SetOff_SR_Doc, L.Loca_Descrip, S.Supp_Name FROM tbPaidPaymentDetails PD INNER JOIN Location L on PD.Loca = L.Loca INNER JOIN SUPPLIER S ON PD.Acc_Code = S.Supp_Code INNER JOIN Transaction_Header TH ON TH.Doc_No = PD.Doc_No AND TH.Loca = PD.Loca WHERE TH.Iid = 'GRN' AND PD.Iid = 'SOP' AND PD.Loca = '" + LoginManager.LocaCode + "' AND (CONVERT(DATETIME,PD.Post_Date, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.ToString() + "', 103) AND CONVERT(DATETIME,'" + dtDateTo.Text.ToString() + "', 103))";
                        }
                        objRepView.DataSetName = "dsPaymentSetOffSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPaymentSetoffSummary rptSetOffSumm = new rptPaymentSetoffSummary();
                        rptSetOffSumm.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSetOffSumm;
                        break;
                    case 223:

                        objRepView.SqlStatement = "select PD.Org_Doc_no, PD.Doc_No, PD.SetOff_SR_Doc, PD.Transaction_Date, PD.Paid_Amount, PD.Loca, PD.Acc_Code, S.Supp_Name, L.Loca_Descrip from tbPaidPaymentDetails PD INNER JOIN Supplier S ON PD.Acc_Code = S.Supp_Code INNER JOIN Location L ON PD.Loca = L.Loca where PD.iid = 'SOP' AND PD.Doc_No = '" + txtCodeFrom.Text.Trim() + "' AND PD.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsPaymentSetOffSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPaymentSetOffGrnwise rptSetOffGrn = new rptPaymentSetOffGrnwise();
                        rptSetOffGrn.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSetOffGrn;
                        break;

                    case 224:
                        objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Paid_Amount, PD.Post_Date, PD.SetOff_SR_Doc, PD.Loca, L.Loca_Descrip, PD.Acc_Code, S.Cust_Name Supp_Name, 'Duplicate' Status FROM tbPaidPaymentDetails PD INNER JOIN Location L ON PD.Loca = L.Loca INNER JOIN Customer S ON PD.Acc_Code = S.Cust_Code WHERE PD.Org_Doc_no = '" + txtCodeFrom.Text.ToString() + "' AND PD.Loca = '" + LoginManager.LocaCode + "' AND PD.Iid = 'SOR'";
                        objRepView.DataSetName = "dsPaymentsetOffDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCustSetOffPayment rptCustSetOff = new rptCustSetOffPayment();
                        rptCustSetOff.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptCustSetOff;
                        break;

                    case 225:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Balance_Amount, PD.Paid_Amount, PD.Loca, PD.Tr_Date, PD.Acc_Code, PD.Post_Date, PD.SetOff_SR_Doc, L.Loca_Descrip, S.Cust_Name Supp_Name FROM tbPaidPaymentDetails PD INNER JOIN Location L on PD.Loca = L.Loca INNER JOIN Customer S ON PD.Acc_Code = S.Cust_Code INNER JOIN Transaction_Header TH ON TH.Doc_No = PD.Doc_No AND TH.Loca = PD.Loca WHERE TH.Iid = 'INV' AND PD.Iid = 'SOR' AND PD.Loca = '" + LoginManager.LocaCode + "' AND (PD.Org_Doc_no BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "')";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Balance_Amount, PD.Paid_Amount, PD.Loca, PD.Tr_Date, PD.Acc_Code, PD.Post_Date, PD.SetOff_SR_Doc, L.Loca_Descrip, S.Cust_Name Supp_Name FROM tbPaidPaymentDetails PD INNER JOIN Location L on PD.Loca = L.Loca INNER JOIN Customer S ON PD.Acc_Code = S.Cust_Code INNER JOIN Transaction_Header TH ON TH.Doc_No = PD.Doc_No AND TH.Loca = PD.Loca WHERE TH.Iid = 'INV' AND PD.Iid = 'SOR' AND PD.Loca = '" + LoginManager.LocaCode + "' AND (CONVERT(DATETIME,PD.Post_Date, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.ToString() + "', 103) AND CONVERT(DATETIME,'" + dtDateTo.Text.ToString() + "', 103))";
                        }
                        objRepView.DataSetName = "dsPaymentSetOffSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCustomerSetoffSummary rptCustSetOffSumm = new rptCustomerSetoffSummary();
                        rptCustSetOffSumm.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptCustSetOffSumm;
                        break;

                    case 226:
                        objRepView.SqlStatement = "select PD.Org_Doc_no, PD.Doc_No, PD.SetOff_SR_Doc, PD.Transaction_Date, PD.Paid_Amount, PD.Loca, PD.Acc_Code, S.Cust_Name Supp_Name, L.Loca_Descrip from tbPaidPaymentDetails PD INNER JOIN Customer S ON PD.Acc_Code = S.Cust_Code INNER JOIN Location L ON PD.Loca = L.Loca where PD.iid = 'SOR' AND PD.Doc_No = '" + txtCodeFrom.Text.Trim() + "' AND PD.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsPaymentSetOffSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPaymentSetOffInvwise rptSetOffInv = new rptPaymentSetOffInvwise();
                        rptSetOffInv.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSetOffInv;
                        break;

                    case 227:

                        objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code,Transaction_Header.To_LocaDesc Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no, Transaction_Header.Inv_Amt, Transaction_Header.Porder_no, Transaction_Header.Net_Amount,Transaction_Header.Amount Gross_Amount ,Transaction_Header.Discount Sub_Discount, Transaction_Header.Disc, Transaction_Header.Remarks, Transaction_Header.Reference, Transaction_Header.Pay_Type, Transaction_Header.Tax, Ref_Name Sales_Assist,Transaction_Details.Prod_code, Transaction_Details.Prod_Name, Transaction_Details.Qty, Transaction_Details.FreeQty, Transaction_Details.Purchase_Price, Transaction_Details.Selling_Price, Transaction_Details.Discount, Transaction_Details.Amount, Transaction_Details.Ln, Transaction_Header.Code PayRemark1, Transaction_Header.PayRemark1 Address1, Transaction_Header.PayRemark2 Address2, Transaction_Header.PayRemark3 Address3, '' Address4, Location.Loca_Descrip, Location.Address1 Loca_Address2, Location.Address2 Loca_Address2, Location.Address3 Loca_Address3, Location.Tel Loca_Tel, Location.Fax Loca_Fax, Location.EMail Loca_EMail, Location.TaxReg Loca_TaxReg, Location.Web_Address Loca_Web_Address, 'Duplicate' Status FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No AND Transaction_Header.Loca = Transaction_Details.Loca AND Transaction_Header.Iid = Transaction_Details.Iid INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'QUO' ORDER BY Ln;SELECT * FROM CompanyProfile";
                        objRepView.DataSetName = "dsInvoiceDetails";
                        objRepView.RetrieveData();
                        objRepView.TempResultSet.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                        dsDataForReport = objRepView.TempResultSet;
                        rptQuotation Quotation = new rptQuotation();
                        Quotation.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = Quotation;
                        break;
                         case 228:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            if (rdbcustomer.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT Doc_No, Inv_Date, Inv_No, Amount, Supplier_Id + ' - ' +Cust_Name [Customer], To_LocaDesc, Code, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Transaction_Header INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid='RRT' AND Doc_No BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                                objRepView.DataSetName = "dsChqReconn";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                objRepViewer.VirtuaReport = new rptCustWiseChqReconn();
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["From"].Text = "\"Code From :\"";
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["To"].Text = "\"Code To :\"";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT Doc_No, Inv_Date, Inv_No, Amount, Supplier_Id + ' - ' +Supp_Name [Supplier], To_LocaDesc, Code, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Transaction_Header INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.Iid='PRT' AND Doc_No BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                                objRepView.DataSetName = "dsChqReconn";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                objRepViewer.VirtuaReport = new rptSuppWiseChqReconn();
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["From1"].Text = "\"Code From :\"";
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["To1"].Text = "\"Code To :\"";
                            }
                        }
                        else
                        {
                            if (rdbcustomer.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT Doc_No, Inv_Date, Inv_No, Amount, Supplier_Id + ' - ' +Cust_Name [Customer], To_LocaDesc, Code, '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Transaction_Header INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid='RRT' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "'";
                                objRepView.DataSetName = "dsChqReconn";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                objRepViewer.VirtuaReport = new rptCustWiseChqReconn();
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["From"].Text = "\"Date From :\"";
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["To"].Text = "\"Date To :\"";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT Doc_No, Inv_Date, Inv_No, Amount, Supplier_Id + ' - ' +Supp_Name [Supplier], To_LocaDesc, Code, '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Transaction_Header INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.Iid='PRT' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "'";
                                objRepView.DataSetName = "dsChqReconn";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                objRepViewer.VirtuaReport = new rptSuppWiseChqReconn();
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["From1"].Text = "\"Date From :\"";
                                objRepViewer.VirtuaReport.DataDefinition.FormulaFields["To1"].Text = "\"Date To :\"";
                            }
                        }                       
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;                       
                        break;

                    case 229:
                        objRepView.SqlStatement = "SELECT Supp_Code + ' - ' + Supp_Name [Supplier], Transaction_Header.Doc_No, Transaction_Header.Post_Date, Transaction_Header.Loca + ' - ' + Loca_Descrip [Loca], Transaction_Header.Net_Amount, Transaction_Header.Amount [Gross_Amount], Transaction_Details.Amount, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Transaction_Details.Purchase_Price, Transaction_Details.Qty, Remarks   FROM Transaction_Header INNER JOIN Transaction_Details ON Transaction_Header.Doc_No = Transaction_Details.Doc_No INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Transaction_Header.Iid='PDN' AND Transaction_Header.Doc_No ='" + txtCodeFrom.Text.Trim() + "' AND Transaction_Header.Loca='" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsProductDiscard";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductDiscardNote();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 230:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Supp_Code + ' - ' + Supp_Name [Supplier], Doc_No, Post_Date, Net_Amount, Transaction_Header.Loca + ' - ' + Location.Loca_Descrip [Loca],  '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo]  FROM Transaction_Header INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Iid='PDN' AND Doc_No BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND Transaction_Header.Loca='" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsProductDiscard";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptProductDiscardSummary();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                            objRepViewer.VirtuaReport.DataDefinition.FormulaFields["From"].Text = "\"Code From : \"";
                            objRepViewer.VirtuaReport.DataDefinition.FormulaFields["To"].Text = "\"Code To : \"";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Supp_Code + ' - ' + Supp_Name [Supplier], Doc_No, Post_Date, Net_Amount, Transaction_Header.Loca + ' - ' + Location.Loca_Descrip [Loca], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo]  FROM Transaction_Header INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code INNER JOIN Location ON Transaction_Header.Loca = Location.Loca WHERE Iid='PDN' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Transaction_Header.Loca='" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsProductDiscard";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptProductDiscardSummary();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                            objRepViewer.VirtuaReport.DataDefinition.FormulaFields["From"].Text = "\"Date From : \"";
                            objRepViewer.VirtuaReport.DataDefinition.FormulaFields["To"].Text = "\"Date To : \"";
                        }                                              
                        break;
                    case 231:
                        rptAdvanceReport objadvance = new rptAdvanceReport();
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            if (rdbcustomer.Checked == true)
                            {
                                objRepView.SqlStatement = "select  tbPaidPaymentSummary.Acc_Code [Sup_Cus_Id], Customer.Cust_Name [Sup_Cus_Name],tbPaidPaymentSummary.Org_Doc_no [Doc_No],tbPaidPaymentSummary.Iid ,tbPaidPaymentSummary.Payment_Mode,tbPaidPaymentSummary.Bank_Name,tbPaidPaymentSummary.Post_Date,tbPaidPaymentSummary.Cheque_No,tbPaidPaymentSummary.Cheque_Date,tbPaidPaymentSummary.Amount FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code=Customer.Cust_Code  WHERE tbPaidPaymentSummary.Org_Doc_no='" + txtCodeFrom.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' ";
                                objadvance.SummaryInfo.ReportTitle = "Customer Advance Report";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select  tbPaidPaymentSummary.Acc_Code [Sup_Cus_Id], Supplier.Supp_Name [Sup_Cus_Name],tbPaidPaymentSummary.Org_Doc_no [Doc_No],tbPaidPaymentSummary.Iid ,tbPaidPaymentSummary.Payment_Mode,tbPaidPaymentSummary.Bank_Name,tbPaidPaymentSummary.Post_Date,tbPaidPaymentSummary.Cheque_No,tbPaidPaymentSummary.Cheque_Date,tbPaidPaymentSummary.Amount FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code=Supplier.Supp_Code  WHERE tbPaidPaymentSummary.Org_Doc_no='" + txtCodeFrom.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "' ";
                                objadvance.SummaryInfo.ReportTitle = "Supplier Advance Report";
                            }
                        }
                        objRepView.DataSetName = "dsAdvanceReport";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objadvance.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objadvance;
                        break;

                    case 232:
                        objRepView.SqlStatement = "SELECT TH.Doc_No, TH.Loca, L.Loca_Descrip LocaDesc, TH.To_Loca, TH.To_LocaDesc, TH.Post_Date, TH.Remarks, TD.Prod_Code, TD.Prod_Name, TD.Qty, TD.Purchase_Price, TD.Selling_Price, TD.Pack_Size, TD.Amount,'Original' Status FROM Transaction_Header TH INNER JOIN Transaction_Details TD ON TH.Doc_No = TD.Doc_No AND TH.Iid = TD.Iid AND TH.Loca = TD.Loca INNER JOIN Location L ON L.Loca = TH.Loca WHERE TH.Doc_No = '"+txtCodeFrom.Text.Trim()+"' AND TH.Loca = '"+LoginManager.LocaCode+"' AND TH.Iid = 'OPS' ORDER BY Ln";
                        objRepView.DataSetName = "dsTogDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptOpeningStockNote OpeningStockNote = new rptOpeningStockNote();
                        OpeningStockNote.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = OpeningStockNote;
                        break;
                    case 233:
                        objRepView.SqlStatement = "SELECT Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Code, Qty, FreeQty, Post_Date, Product.Prod_Name [To_LocaDesc], Doc_No FROM Transaction_Details INNER JOIN Product ON Code=Product.Prod_Code WHERE Loca='" + LoginManager.LocaCode + "' AND Doc_No='" + txtCodeFrom.Text + "' AND Iid='BIS'";
                        objRepView.DataSetName = "dsBulkIssue";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptBulkIssue BulkIssue = new rptBulkIssue();
                        BulkIssue.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = BulkIssue;
                        break;

                        //Special discount report
                    case 234:
                        if (radioButtonDate.Checked==true)
                        {
                            objRepView.SqlStatement = "SELECT ('DATE FROM - '+'" + dtDateFrom.Text.Trim() + "'+'  DATE TO - '+'" + dtDateTo.Text.Trim() + "') [Address1], '' [Address2], ('LOCATION : '+Transaction_Header.Loca+'-'+Location.Loca_Descrip) [Address3], Doc_No, Post_Date, Pay_Type [Status],Cust_Code+'- '+Cust_Name [Cust_Code], Amount,Disc [Remarks], Transaction_Header.Discount, Net_Amount  FROM Transaction_Header INNER JOIN Location ON Location.Loca=Transaction_Header.Loca INNER JOIN Customer ON Cust_Code=Supplier_Id WHERE Transaction_Header.Iid='INV' AND Transaction_Header.Loca='" + LoginManager.LocaCode + "' AND Transaction_Header.Discount >0 AND CONVERT(Datetime,Post_Date,103) BETWEEN CONVERT(Datetime,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(Datetime,'" + dtDateTo.Text.Trim() + "',103) ORDER BY CONVERT(Datetime,Post_Date,103)";
                        }
                        else if (radioButtonDocumentNo.Checked==true)
                        {
                            objRepView.SqlStatement = "SELECT ('CODE FROM - '+'" + txtCodeFrom.Text.Trim() + "'+'  CODE TO - '+'" + txtCodeTo.Text.Trim() + "') [Address2], '' [Address1], ('LOCATION : '+Transaction_Header.Loca+'-'+Location.Loca_Descrip) [Address3], Doc_No, Post_Date, Pay_Type [Status],Cust_Code+'- '+Cust_Name [Cust_Code], Amount,Disc [Remarks], Transaction_Header.Discount, Net_Amount  FROM Transaction_Header INNER JOIN Location ON Location.Loca=Transaction_Header.Loca  INNER JOIN Customer ON Cust_Code=Supplier_Id WHERE Transaction_Header.Iid='INV' AND Transaction_Header.Loca='" + LoginManager.LocaCode + "' AND Transaction_Header.Discount >0 AND Doc_No BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Doc_No";
                        }
                        
                        objRepView.DataSetName = "dsInvoiceDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSpescialDiscountDetails rptSpecDiscount = new rptSpescialDiscountDetails();
                        rptSpecDiscount.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSpecDiscount;
                        break;

                    case 235://Cash Return Details
                        if (Settings.Default.Shinghala)
                        {
                            objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code ,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no payRemark1, Transaction_Header.Inv_Amt Amount, Transaction_Header.Porder_no, Transaction_Header.Net_Amount, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Duplicate' Status FROM Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.Trim() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CAR' ; SELECT * FROM CompanyProfileSinhala";
                            objRepView.DataSetName = "dsInvoiceDetails";
                            objRepView.RetrieveData();
                            objRepView.TempResultSet.Tables["dsInvoiceDetails1"].TableName = "dsCompanyLogo";
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCashRefundDetails.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Transaction_Header.Doc_no, Transaction_Header.Supplier_Id Cust_Code ,Customer.Cust_Name, Transaction_Header.Loca,Location.Loca_Descrip, Transaction_Header.Post_Date, Transaction_Header.inv_no payRemark1, Transaction_Header.Inv_Amt Amount, Transaction_Header.Porder_no, Transaction_Header.Net_Amount, Customer.Address1, Customer.Address2, Customer.Address3, Customer.Address4, 'Duplicate' Status FROM Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN customer ON Transaction_Header.Supplier_Id = Customer.Cust_code WHERE Transaction_Header.Doc_No = '" + txtCodeFrom.Text.Trim() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CAR' ; SELECT * FROM CompanyProfile";
                            objRepView.DataSetName = "dsInvoiceDetails";
                            objRepView.RetrieveData();
                            objRepView.TempResultSet.Tables["dsInvoiceDetails1"].TableName = "CompanyProfile";
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCashRefundDetails_eng.rpt");
                            objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        }
                        break;

                    case 236://Cash Return Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.Inv_No To_LocaDesc, Transaction_Header.Supplier_Id, Customer.Cust_Name Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CAR' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.Inv_No To_LocaDesc, Transaction_Header.Supplier_Id, Customer.Cust_Name Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'CAR' ORDER BY RIGHT(Doc_No,6)";
                        }
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCashReturnSummary rptCashRetSummary = new rptCashReturnSummary();
                        rptCashRetSummary.SetDataSource(dsDataForReport);
                        rptCashRetSummary.SummaryInfo.ReportTitle = "CASH RETURN SUMMARY";
                        objRepViewer.crystalReportViewer1.ReportSource = rptCashRetSummary;
                        break;

                    case 237: //Cash IN/OUT Note
                        objRepView.SqlStatement = "SELECT Doc_No, PostDate, Cash_IN, Cash_OUT, Reason FROM  tb_CashINOUTDetails WHERE Doc_No ='" + txtCodeFrom.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsCashINOUT";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.verReport = new rptCashINOUT();
                        objRepViewer.verReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;
                        break;

                    case 238: //Cash IN/OUT Summary
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Doc_No, PostDate, Cash_IN, Cash_OUT, Reason, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM  tb_CashINOUTDetails WHERE Doc_No BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND Loca='" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsCashINOUT";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.verReport = new rptCashINOUTSummary();
                            objRepViewer.verReport.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;
                            objRepViewer.verReport.DataDefinition.FormulaFields["From"].Text = "\"Code From \"";
                            objRepViewer.verReport.DataDefinition.FormulaFields["To"].Text = "\" Code To \"";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Doc_No, PostDate, Cash_IN, Cash_OUT, Reason, '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM  tb_CashINOUTDetails WHERE CONVERT(DATETIME,PostDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsCashINOUT";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.verReport = new rptCashINOUTSummary();
                            objRepViewer.verReport.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;
                            objRepViewer.verReport.DataDefinition.FormulaFields["From"].Text = "\"Date From \"";
                            objRepViewer.verReport.DataDefinition.FormulaFields["To"].Text = "\" Date To \"";
                        }
                     
                        break;

                    case 239:
                        string str;
                        if (cmbtype.Text == "ALL")
                            str = " ";
                        else
                            str = "AND Mode='" + cmbtype.Text + "' ";
                        objRepView.SqlStatement = "SELECT '" + cmbtype.Text + " - " + txtCodeFrom.Text.Trim() + "' loca_Descrip,'" + dtDateFrom.Text + "' DateFrom,'" + dtDateTo.Text + "' DateTo,Post_Date Tr_Date,Cheque_No,Bank_Name,Amount,Acc_Name Acc_Code,C.Cust_Name Supp_Name FROM tb_BankDeposit TB LEFT JOIN Customer C ON TB.Acc_Name=C.Cust_Code WHERE Type='DEPOSITS' " + str + " AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)";
                        objRepView.DataSetName = "dsPostDatedCheque";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;

                        rptChequeInHand Chq1 = new rptChequeInHand();
                        Chq1.SetDataSource(dsDataForReport);
                        Chq1.SummaryInfo.ReportTitle = "CASH/CHEQUE Deposits";
                        objRepViewer.crystalReportViewer1.ReportSource = Chq1;
                        break;

                    case 240:
                        //string str1;
                        if (cmbtype.Text == "ALL")
                            str = " ";
                        else
                            str = "AND Mode='" + cmbtype.Text + "' ";
                        objRepView.SqlStatement = "SELECT '" + cmbtype.Text + " - " + txtCodeFrom.Text.Trim() + "' loca_Descrip,'" + dtDateFrom.Text + "' DateFrom,'" + dtDateTo.Text + "' DateTo,Post_Date Tr_Date,Cheque_No,Bank_Name,Amount,Acc_Name Acc_Code,C.Cust_Name Supp_Name FROM tb_BankDeposit TB LEFT JOIN Customer C ON TB.Acc_Name=C.Cust_Code WHERE Loca='" + LoginManager.LocaCode + "' AND Type='WITHDRAWALS' " + str + " AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)";
                        objRepView.DataSetName = "dsPostDatedCheque";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptChequeInHand Chq2 = new rptChequeInHand();
                        Chq2.SetDataSource(dsDataForReport);
                        Chq2.SummaryInfo.ReportTitle = "CASH/CHEQUE Withdrawals";
                        objRepViewer.crystalReportViewer1.ReportSource = Chq2;
                        break;

                    case 241:
                        objRepView.SqlStatement = "SELECT PD.Org_Doc_no, PD.Doc_No, PD.Transaction_Date, PD.Transaction_Amount, PD.Paid_Amount, PD.Post_Date, PD.SetOff_SR_Doc, PD.Loca, L.Loca_Descrip, PD.Acc_Code, S.Supp_Name, PD.SetOff_Acc_Code , C.Cust_Name, 'Duplicate' Status, PD.SetOff_Doc_Date AS Transaction_Date2 FROM tbPaidPaymentDetails PD INNER JOIN Location L ON PD.Loca = L.Loca INNER JOIN Supplier S ON PD.Acc_Code = S.Supp_Code INNER JOIN Customer C ON PD.SetOff_Acc_Code=C.Cust_Code WHERE PD.Org_Doc_no = '" + txtCodeFrom.Text + "' AND PD.Loca = '" + LoginManager.LocaCode + "' AND PD.Iid = 'DCS'";
                        objRepView.DataSetName = "dsPaymentsetOffDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSetOffDebCred rptSetOffDEbCred = new rptSetOffDebCred();
                        rptSetOffDEbCred.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSetOffDEbCred;
                        break;
                    //Special discount report
                    case 242:
                        if (radioButtonDate.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT ('DATE FROM - '+'" + dtDateFrom.Text.Trim() + "'+'  DATE TO - '+'" + dtDateTo.Text.Trim() + "') [Address1], '' [Address2], ('LOCATION : '+L.Loca+'-'+L.Loca_Descrip) [Address3],Pay_Type [Status],Prod_Code,Prod_Name,Selling_Price,sum(Qty)Qty,sum(TD.Discount)Discount,sum(TD.Amount)Amount FROM dbo.Transaction_Header Th JOIN dbo.Transaction_Details TD ON Th.Doc_No = TD.Doc_No AND Th.Iid = TD.Iid  JOIN dbo.Location L ON TD.Loca = L.Loca WHERE TD.Discount>0 AND Th.Iid='INV' AND Th.Loca='" + LoginManager.LocaCode + "' AND CONVERT(Datetime,Th.Post_Date,103) BETWEEN CONVERT(Datetime,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(Datetime,'" + dtDateTo.Text.Trim() + "',103) GROUP BY L.Loca,L.Loca_Descrip,Pay_Type ,Prod_Code,Prod_Name,Selling_Price ORDER BY TD.Prod_Code ASC";
                        }
                        else if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT ('DOCUMENT FROM - '+'" + txtCodeFrom.Text.Trim() + "'+'  DOCUMENT TO - '+'" + txtCodeTo.Text.Trim() + "') [Address1], '' [Address2], ('LOCATION : '+L.Loca+'-'+L.Loca_Descrip) [Address3],Pay_Type [Status],Prod_Code,Prod_Name,Selling_Price,sum(Qty)Qty,sum(TD.Discount)Discount,sum(TD.Amount)Amount FROM dbo.Transaction_Header Th JOIN dbo.Transaction_Details TD ON Th.Doc_No = TD.Doc_No AND Th.Iid = TD.Iid  JOIN dbo.Location L ON TD.Loca = L.Loca WHERE TD.Discount>0 AND Th.Iid='INV' AND Th.Loca='" + LoginManager.LocaCode + "' AND  Th.Doc_No BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY L.Loca,L.Loca_Descrip,Pay_Type ,Prod_Code,Prod_Name,Selling_Price ORDER BY TD.Prod_Code ASC";
                        }

                        objRepView.DataSetName = "dsInvoiceDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSpescialDiscountDetails_Itemwise rptSpecDiscountIt = new rptSpescialDiscountDetails_Itemwise();
                        rptSpecDiscountIt.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSpecDiscountIt;
                        break;

                    case 243:
                        objRepView.SqlStatement = "SELECT *,L.Loca_Descrip[LocaDesc],CASE CD.Iid WHEN 'ROA' THEN 'RECEIVED ON ACCOUNT' ELSE 'CASH DENOMINATION' END [RepName],CD.UserName[Cashier],'Duplicate'[State],CD.Post_Date[PostDate] FROM dbo.tbCashDenoDetails CD JOIN dbo.Location L ON L.Loca = CD.Loca  WHERE CD.DocNo='"+txtCodeFrom.Text+"' and cd.loca='"+LoginManager.LocaCode+"' and cd.iid='ROA' ";
                        objRepView.DataSetName = "dsCashDeno";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCashDeno rptRoa = new rptCashDeno();
                        rptRoa.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptRoa;
                        break;
                    case 244:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT DocNo[Org_Doc_no],Post_Date,UserName[Acc_Code],Amount,'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo FROM dbo.tbCashDenoDetails WHERE DocNo BETWEEN '"+txtCodeFrom.Text+"' AND '"+txtCodeTo.Text+"' AND Loca='"+LoginManager.LocaCode+"' AND Iid='ROA'";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT DocNo[Org_Doc_no],Post_Date,UserName[Acc_Code],Amount,'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo FROM dbo.tbCashDenoDetails   WHERE CONVERT(DATETIME,Post_Date,103) BETWEEN  CONVERT(DATETIME,'" + dtDateFrom.Text + "',103)  AND  CONVERT(DATETIME,'" + dtDateTo.Text + "',103) AND Loca='" + LoginManager.LocaCode + "' AND Iid='ROA'";
                        }
                        objRepView.DataSetName = "SupplierPaymentSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCashDenoSummary ROASumm = new rptCashDenoSummary();
                        ROASumm.SetDataSource(dsDataForReport);
                        ROASumm.SummaryInfo.ReportTitle = "Received on Account Summary";
                        objRepViewer.crystalReportViewer1.ReportSource = ROASumm;
                        break;
                    case 245:
                        objRepView.SqlStatement = "SELECT *,L.Loca_Descrip[LocaDesc],CASE CD.Iid WHEN 'ROA' THEN 'RECEIVED ON ACC' ELSE 'CASH DENOMINATION' END [RepName],CD.UserName[Cashier],'Duplicate'[State],CD.Post_Date[PostDate] FROM dbo.tbCashDenoDetails CD JOIN dbo.Location L ON L.Loca = CD.Loca  WHERE CD.DocNo='" + txtCodeFrom.Text + "' and cd.loca='" + LoginManager.LocaCode + "' and cd.iid='CDNM' ";
                        objRepView.DataSetName = "dsCashDeno";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCashDeno rptcdm = new rptCashDeno();
                        rptcdm.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptcdm;
                        break;

                    case 246:
                        if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT DocNo[Org_Doc_no],Post_Date,UserName[Acc_Code],Amount,'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo FROM dbo.tbCashDenoDetails WHERE DocNo BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND Loca='" + LoginManager.LocaCode + "' AND Iid='CDNM'";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT DocNo[Org_Doc_no],Post_Date,UserName[Acc_Code],Amount,'Date From " + dtDateFrom.Text.Trim() + "' CodeFrom, 'Date To " + dtDateTo.Text.Trim() + "' CodeTo FROM dbo.tbCashDenoDetails   WHERE CONVERT(DATETIME,Post_Date,103) BETWEEN  CONVERT(DATETIME,'" + dtDateFrom.Text + "',103)  AND  CONVERT(DATETIME,'" + dtDateTo.Text + "',103) AND Loca='" + LoginManager.LocaCode + "' AND Iid='CDNM'";
                        }
                        objRepView.DataSetName = "SupplierPaymentSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCashDenoSummary CDNM = new rptCashDenoSummary();
                        CDNM.SetDataSource(dsDataForReport);
                        CDNM.SummaryInfo.ReportTitle = "Cash Denomination Summary";
                        objRepViewer.crystalReportViewer1.ReportSource = CDNM;
                        break;


                    case 247:
                     
                         objRepView.SqlStatement = "EXEC dbo.Sp_GetReport @Report = '247',@DateFrom = '"+dtDateFrom.Text+"',@DateTo = '"+dtDateTo.Text+"'";

                         objRepView.DataSetName = "dtOGFUpload";
                         
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        dsDataForReport.Tables[1].TableName="CompanyProfile";
                        rptOgfSale OGFSALE = new rptOgfSale();
                        OGFSALE.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = OGFSALE;
                        break;

                    case 248:
                      if (radioButtonDocumentNo.Checked == true)
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid,Transaction_Header.Post_Date,Remarks[To_LocaDesc], Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip,  Transaction_Header.Post_Date, Transaction_Header.Net_Amount,P.Prod_Code,P.Prod_Name,TD.Qty,TD.Amount,'DOCUMENT FROM '+'" + txtCodeFrom.Text + "'+'-'+'" + txtCodeFrom.Text + "'[To_Loca] from Transaction_Header INNER JOIN Location  ON Transaction_Header.Loca = Location.Loca  JOIN dbo.Transaction_Details TD ON TD.Doc_No=Transaction_Header.Doc_No AND TD.Loca = Location.Loca JOIN dbo.Product P ON P.Prod_Code = TD.Prod_Code WHERE Transaction_Header.Doc_No BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'OPS' ORDER BY RIGHT(Transaction_Header.Doc_No,6)";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Transaction_Header.Iid,Transaction_Header.Post_Date,Remarks[To_LocaDesc], Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip,  Transaction_Header.Post_Date, Transaction_Header.Net_Amount,P.Prod_Code,P.Prod_Name,TD.Qty,TD.Amount,'DATE FROM '+'" + txtCodeFrom.Text + "'+'-'+'" + txtCodeFrom.Text + "'[To_Loca] from Transaction_Header INNER JOIN Location  ON Transaction_Header.Loca = Location.Loca  JOIN dbo.Transaction_Details TD ON TD.Doc_No=Transaction_Header.Doc_No AND TD.Loca = Location.Loca JOIN dbo.Product P ON P.Prod_Code = TD.Prod_Code WHERE (CONVERT(DATETIME,Transaction_Header.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "', 103)) AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'OPS' ORDER BY RIGHT(Transaction_Header.Doc_No,6)";
                        }
                        objRepView.DataSetName = "dsTogDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptOpeningStockNoteSummary rptSpstSummary = new rptOpeningStockNoteSummary();
                        rptSpstSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = rptSpstSummary;
                  
                        break;
                    case 249:

                        objRepView.SqlStatement = "SELECT EXD.Doc_No,EXD.Transaction_Date[Date],EXD.Remarks[Memo],Ex.Expense_Code[Exp_Code],Ex.Expense_Name[Exp_Name],EXD.Transaction_Amount[Amount],EXD.Bill_No,EXD.UserName[CreateUser],EXD.Loca,L.Loca_Descrip[Loca_Desc],'ORGINAL'[State] FROM dbo.Account_TransSummary EXD JOIN dbo.tb_Expense Ex ON Ex.Expense_Code=EXD.ExpenseCode JOIN dbo.Location L ON L.Loca = EXD.Loca WHERE EXD.Doc_No='"+txtCodeFrom.Text.Trim()+"' AND EXD.Loca='"+LoginManager.LocaCode+"' AND EXD.Iid='EXP'";
                        objRepView.DataSetName = "dtExpDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;

                        rptExpDetails ExpDt = new rptExpDetails();
                        ExpDt.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ExpDt;
                        ExpDt.SummaryInfo.ReportTitle = "EXPENSE DETAILS NOTE";
                        objRepViewer.WindowState = FormWindowState.Maximized;
                        objRepViewer.Show();

                        break;
                    case 250:

                        objRepView.SqlStatement = "SELECT EXD.Doc_No,EXD.Transaction_Date[Date],EXD.Remarks[Memo],Ex.Expense_Code[Exp_Code],Ex.Expense_Name[Exp_Name],EXD.Transaction_Amount[Amount],EXD.Bill_No,EXD.UserName[CreateUser],EXD.Loca,L.Loca_Descrip[Loca_Desc],'ORGINAL'[State] FROM dbo.Account_TransSummary EXD JOIN dbo.tb_Expense Ex ON Ex.Expense_Code=EXD.ExpenseCode JOIN dbo.Location L ON L.Loca = EXD.Loca WHERE EXD.Doc_No='" + txtCodeFrom.Text.Trim() + "' AND EXD.Loca='" + LoginManager.LocaCode + "' AND EXD.Iid='EXR'";
                        objRepView.DataSetName = "dtExpDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;

                        rptExpDetails ExpDtRt = new rptExpDetails();
                        ExpDtRt.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ExpDtRt;
                        ExpDtRt.SummaryInfo.ReportTitle = "EXPENSE RETURN DETAILS NOTE";
                        objRepViewer.WindowState = FormWindowState.Maximized;
                        objRepViewer.Show();

                        break;
                    default:
                        break;
                }
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();
            }
            catch (Exception ex)
            {
                
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDocumentTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                switch (intRepOption)
                {
                    case 248:
                    case 232:   //OPST
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'OPS' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'OPS' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 208://Supp Payment Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Supplier.Supp_Name [Supplier] FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' GROUP BY Org_Doc_no, Supp_Name ORDER BY RIGHT(Org_Doc_no,6)";
                        }
                        else
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Supplier.Supp_Name [Supplier] FROM tbPaidPaymentSummary INNER JOIN Supplier ON tbPaidPaymentSummary.Acc_Code = Supplier.Supp_Code WHERE Iid = 'PMT' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no, Supp_Name ORDER BY RIGHT(Org_Doc_no,6)";
                        }
                        break;

                    case 209://Customer Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Customer.Cust_Name [Customer] FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' GROUP BY Org_Doc_no, Cust_Name ORDER BY RIGHT(Org_Doc_no,6)";
                            
                        }
                        else
                        {
                            strQuery = "SELECT tbPaidPaymentSummary.Org_Doc_no [Document No], Customer.Cust_Name [Customer] FROM tbPaidPaymentSummary INNER JOIN Customer ON tbPaidPaymentSummary.Acc_Code = Customer.Cust_Code WHERE tbPaidPaymentSummary.Iid = 'REC' AND tbPaidPaymentSummary.Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no, Cust_Name ORDER BY RIGHT(Org_Doc_no,6)";

                        }
                        break;

                    case 210: //Invoice Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date + '  ' + Customer.Cust_Name [Doc Date    Customer Name] FROM Transaction_Header Inner Join Customer on Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date + '  ' + Customer.Cust_Name [Doc Date    Customer Name] FROM Transaction_Header Inner Join Customer on Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;

                    case 211: //Customer Return Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CUR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CUR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";

                        }
                        break;

                    case 212://Purchase Order
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                       
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'PON' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";

                        }
                        break;

                    case 213://Grn summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'GRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        
                        break;

                    case 214: //Stock Adjustment
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'STA' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
  
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'STA' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";

                        }
                        break;

                    case 215://transfer note Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Doc_No [Document No], To_LocaDesc [To Location] FROM Transaction_Header WHERE Iid = 'TGN' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) ASC";
                           
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], To_LocaDesc [To Location] FROM Transaction_Header WHERE Iid = 'TGN' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) ASC";

                        }
                        break;

                    case 216://Supplier Return
                        if (txtCodeTo.Text.Trim()!=string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "' +'%' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) DESC";
                        }
                        break;

                    case 217://Supplier Return summary
                        if (txtCodeTo.Text.Trim()!=string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(,6)";  
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Supplier.Supp_Name [Supplier] FROM Transaction_Header INNER JOIN supplier on Transaction_Header.Supplier_Id = supplier.supp_code WHERE Iid = 'SRN' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                      
                        break;

                    case 222://Payment Set Off Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOP' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        
                        break;
                    case 225://Payment Set Off Summary
                        if (txtCodeTo.Text.Trim()!=string.Empty )
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' AND Org_Doc_no LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' GROUP BY Org_Doc_no,Post_Date ORDER BY RIGHT(Org_Doc_no,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Org_Doc_no [Document No], Post_Date [Date] FROM tbPaidPaymentDetails WHERE Iid = 'SOR' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Org_Doc_no,Post_Date ORDER BY RIGHT(Org_Doc_no,6)";
                        }
                        
                        break;
                    case 228:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid= 'RRT' AND Loca='" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) ASC ";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'RRT' AND Loca = '" + LoginManager.LocaCode + "' GROUP BY Doc_No, Post_Date ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        break;

                    case 230://Product Discard Summary
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'PDN' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Date] FROM Transaction_Header WHERE Iid = 'PDN' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        break;

                    case 234:   //Special discount Report
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Discount >0 AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%'  ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Discount >0 ORDER BY RIGHT(Doc_No,6) ASC";
                        }
                        break;

                    case 236: //Cash Return Summary
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CAR' AND Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_Header WHERE Iid = 'CAR' AND Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";

                        }
                        break;

                    case 238: //Cash IN/OUT Summary
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Doc_No [Document No], PostDate [Doc Date] FROM tb_CashINOUTDetails WHERE  Loca = '" + LoginManager.LocaCode + "' AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%' ORDER BY RIGHT(Doc_No,6)";
                        }
                        else
                        {
                            strQuery = "SELECT Doc_No [Document No], PostDate [Doc Date] FROM tb_CashINOUTDetails WHERE  Loca = '" + LoginManager.LocaCode + "' ORDER BY RIGHT(Doc_No,6)";
                        }
                        break;
                    case 242:   //Special discount Report
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT distinct Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Discount >0 AND Doc_No LIKE '%'+'" + txtCodeTo.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT distinct Doc_No [Document No], Post_Date [Doc Date] FROM Transaction_details WHERE Iid = 'INV' AND Loca = '" + LoginManager.LocaCode + "' AND Discount >0 ";
                        }
                        break;
                    case 244:   //CDNM
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='ROA' AND Loca='" + LoginManager.LocaCode + "' and docNo like '%'+'" + txtCodeTo.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='ROA' AND Loca='" + LoginManager.LocaCode + "'";
                        }
                        break;
                    case 246:   //CDNM
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='CDNM' AND Loca='" + LoginManager.LocaCode + "' and docNo like '%'+'" + txtCodeTo.Text.Trim() + "'+'%'   ";
                        }
                        else
                        {
                            strQuery = "SELECT DocNo[Document],Post_Date[Date],Amount FROM dbo.tbCashDenoDetails WHERE Iid='CDNM' AND Loca='" + LoginManager.LocaCode + "'";
                        }
                        break;
                    default:
                        break;
                }

                objTransactionInquary.SqlStatement = strQuery;
                objTransactionInquary.dsName = "Table";
                objTransactionInquary.RetriveData();

                search.dgSearch.DataSource = objTransactionInquary.ResultSet.Tables["Table"];
                search.Show();

                search.prop_Focus = txtCodeTo;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonDocumentNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonDocumentNo.Checked == true)
                {
                    btnDocumentFrom.Enabled = true;
                    btnDocumentTo.Enabled = true;
                    txtCodeFrom.Enabled = true;
                    txtCodeTo.Enabled = true;
                    dtDateFrom.Enabled = false;
                    dtDateTo.Enabled = false;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = false;
                    label4.Enabled = false;
                }
                else
                {
                    btnDocumentFrom.Enabled = false;
                    btnDocumentTo.Enabled = false;
                    txtCodeFrom.Enabled = false;
                    txtCodeTo.Enabled = false;
                    dtDateFrom.Enabled = true;
                    dtDateTo.Enabled = true;
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = true;
                    label4.Enabled = true;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonDate.Checked == true)
                {
                    btnDocumentFrom.Enabled = false;
                    btnDocumentTo.Enabled = false;
                    txtCodeFrom.Enabled = false;
                    txtCodeTo.Enabled = false;
                    dtDateFrom.Enabled = true;
                    dtDateTo.Enabled = true;
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = true;
                    label4.Enabled = true;
                }
                else
                {
                    btnDocumentFrom.Enabled = true;
                    btnDocumentTo.Enabled = true;
                    txtCodeFrom.Enabled = true;
                    txtCodeTo.Enabled = true;
                    dtDateFrom.Enabled = false;
                    dtDateTo.Enabled = false;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = false;
                    label4.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransactionInquary_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                TransactionInquary = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransactionInquary_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInqary 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmTransactionInquary_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.D)
                    {
                        this.btnDisplay.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransactionInquary 011.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
}