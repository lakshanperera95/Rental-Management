using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;

namespace Inventory
{
    public partial class frmAccountAnalyse : Form
    {
        public frmAccountAnalyse()
        {
            InitializeComponent();
        }

        public int intRepOption;
        
        frmSearch search = new frmSearch();

        clsAccountAnalyse objAccountAnalyse = new clsAccountAnalyse();

        //private string strQuery;

        private static frmAccountAnalyse AccountAnalyse;

        public static frmAccountAnalyse GetAccountAnalyse
        {
            get
            {
                return AccountAnalyse;
            }
            set
            {
                AccountAnalyse = value;
            }
        }

        private void frmAccountAnalyse_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                AccountAnalyse = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAccountAnalyse_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                AccountAnalyse = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDateStartTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtDateStartTo.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtDateStartTo.Text) > 0)
                {
                    int intStartTo;
                    intStartTo = int.Parse(txtDateStartTo.Text) + 1;
                    lblSecondDayRangeStart.Text = intStartTo.ToString();
                    txtSeconDayTo.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSeconDayTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtSeconDayTo.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtSeconDayTo.Text) > 0 && decimal.Parse(txtSeconDayTo.Text) > decimal.Parse(txtDateStartTo.Text))
                {
                    int intSecondTo;
                    intSecondTo = int.Parse(txtSeconDayTo.Text) + 1;
                    lblThirdDayRangeStart.Text = intSecondTo.ToString();
                    txtThirdDayTo.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtThirdDayTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtThirdDayTo.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtThirdDayTo.Text) > 0 && decimal.Parse(txtThirdDayTo.Text) > decimal.Parse(txtSeconDayTo.Text))
                {
                    int intThirdTo;
                    intThirdTo = int.Parse(txtThirdDayTo.Text) + 1;
                    lblOver.Text = "Over " + intThirdTo.ToString() + " Day s";
                    btnDisplay.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsDataForReport = new DataSet();
                frmReportViewer objRepViewer = new frmReportViewer();
                objRepViewer.Text = this.Text;
                objAccountAnalyse.Cust_Code = txtCode.Text.Trim();
                objAccountAnalyse.Cust_CodeTo = txtCodeTo.Text.Trim();
                if (intRepOption == 412)
                {
                    objAccountAnalyse.Iid = "SUP";
                }
                else
                {
                    objAccountAnalyse.Iid = "CUS";
                }

                objAccountAnalyse.DayStartTo = int.Parse(txtDateStartTo.Text.Trim());
                objAccountAnalyse.SecondDayTo = int.Parse(txtSeconDayTo.Text.Trim());
                objAccountAnalyse.ThirdDayTo = int.Parse(txtThirdDayTo.Text.Trim());
                objAccountAnalyse.GetDetails();

                if (intRepOption == 412)
                {
                    objAccountAnalyse.SqlStatement = "select tbSupplierAnalyse.Supp_Code, tbSupplierAnalyse.Doc_No, tbSupplierAnalyse.Doc_Date, tbSupplierAnalyse.Tr_Date, tbSupplierAnalyse.Tr_Amount, tbSupplierAnalyse.No_Of_Days, tbSupplierAnalyse.First_Bal_Amount, tbSupplierAnalyse.Second_Bal_Amount, tbSupplierAnalyse.Third_Bal_Amount, tbSupplierAnalyse.Over_Forth_Bal_Amount, Supplier.Supp_Name, '0 - " + txtDateStartTo.Text.Trim() + "' DayRange1, '" + lblSecondDayRangeStart.Text.Trim() + " - " + txtSeconDayTo.Text.Trim() + "' DayRange2, '" + lblThirdDayRangeStart.Text.Trim() + " - " + txtThirdDayTo.Text.Trim() + "' DayRange3, '" + lblOver.Text.Trim() + "' DayRange4 from tbSupplierAnalyse INNER Join Supplier On tbSupplierAnalyse.Supp_Code = Supplier.Supp_Code WHERE tbSupplierAnalyse.Supp_Code between '" + txtCode.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ";

                    objAccountAnalyse.GetDetailsForDisplay();
                    dsDataForReport = objAccountAnalyse.GetCustomerDataset;
                    rptCreditorOutstanding rptCreditorOutstand = new rptCreditorOutstanding();
                    rptCreditorOutstand.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = rptCreditorOutstand;
                }
                else
                {
                    objAccountAnalyse.SqlStatement = "select tbSupplierAnalyse.Supp_Code, tbSupplierAnalyse.Doc_No, tbSupplierAnalyse.Doc_Date, tbSupplierAnalyse.Tr_Date, tbSupplierAnalyse.Tr_Amount, tbSupplierAnalyse.No_Of_Days, tbSupplierAnalyse.First_Bal_Amount, tbSupplierAnalyse.Second_Bal_Amount, tbSupplierAnalyse.Third_Bal_Amount, tbSupplierAnalyse.Over_Forth_Bal_Amount, Customer.Cust_Name Supp_Name, '0 - " + txtDateStartTo.Text.Trim() + "' DayRange1, '" + lblSecondDayRangeStart.Text.Trim() + " - " + txtSeconDayTo.Text.Trim() + "' DayRange2, '" + lblThirdDayRangeStart.Text.Trim() + " - " + txtThirdDayTo.Text.Trim() + "' DayRange3, '" + lblOver.Text.Trim() + "' DayRange4 from tbSupplierAnalyse INNER Join Customer On tbSupplierAnalyse.Supp_Code = Customer.Cust_Code WHERE tbSupplierAnalyse.Supp_Code between '" + txtCode.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";

                    objAccountAnalyse.GetDetailsForDisplay();
                    dsDataForReport = objAccountAnalyse.GetCustomerDataset;
                    rptDebtorsOutstanding rptDebtorOutstand = new rptDebtorsOutstanding();
                    rptDebtorOutstand.SetDataSource(dsDataForReport);

                    objRepViewer.crystalReportViewer1.ReportSource = rptDebtorOutstand;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSearchCodeFrom_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (intRepOption == 412)
                {
                    if (txtCode.Text.Trim() == string.Empty && txtDescription.Text.Trim() == string.Empty)
                    {
                        objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier";
                    }
                    else
                    {
                        if (txtCode.Text.Trim() != string.Empty && txtDescription.Text.Trim() == string.Empty)
                        {
                            objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtCode.Text.Trim() + "%'";
                        }
                        else
                        {
                            if (txtCode.Text.Trim() == string.Empty && txtDescription.Text.Trim() != string.Empty)
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtDescription.Text.Trim() + "%'";
                            }
                            else
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier";
                            }
                        }
                    }
                }
                else
                {
                    if (txtCode.Text.Trim() == string.Empty && txtDescription.Text.Trim() == string.Empty)
                    {
                        objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                    }
                    else
                    {
                        if (txtCode.Text.Trim() != string.Empty && txtDescription.Text.Trim() == string.Empty)
                        {
                            objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCode.Text.Trim() + "%'";
                        }
                        else
                        {
                            if (txtCode.Text.Trim() == string.Empty && txtDescription.Text.Trim() != string.Empty)
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtDescription.Text.Trim() + "%'";
                            }
                            else
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                            }
                        }
                    }
                }
                objAccountAnalyse.DataSetName = "dsCustomer";
                objAccountAnalyse.GetCustomerDetails();
                search.dgSearch.DataSource = objAccountAnalyse.GetCustomerDataset.Tables["dsCustomer"];
                search.prop_Focus = txtCode;
                search.Cont_Descript = txtDescription;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCode.Text.Trim() != "")
                {
                    objAccountAnalyse.Cust_Code = txtCode.Text.ToString().Trim();
                    if (intRepOption == 412)
                    {
                        objAccountAnalyse.SqlStatement = "SELECT Supp_Code Cust_Code, Supp_Name Cust_Name FROM Supplier WHERE Supp_Code = '" + txtCode.Text.Trim() + "'";
                    }
                    else
                    {
                        objAccountAnalyse.SqlStatement = "SELECT Cust_Code, Cust_Name FROM Customer  WHERE Cust_Code = '" + txtCode.Text.Trim() + "'";
                    }
                    objAccountAnalyse.ReadCustomerDetails();
                    if (objAccountAnalyse.RecordFound == true)
                    {
                        txtCode.Text = objAccountAnalyse.Cust_Code;
                        txtDescription.Text = objAccountAnalyse.Cust_Name;
                        txtDescription.Focus();
                    }
                    else
                    {
                        if (intRepOption == 412)
                        {
                            MessageBox.Show("Supplier Code Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Customer Code Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        txtCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAccountAnalyse_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 010.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAccountAnalyse_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchCodeTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (intRepOption == 412)
                {
                    if (txtCodeTo.Text.Trim() == string.Empty && txtDescriptionTo.Text.Trim() == string.Empty)
                    {
                        objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier";
                    }
                    else
                    {
                        if (txtCodeTo.Text.Trim() != string.Empty && txtDescriptionTo.Text.Trim() == string.Empty)
                        {
                            objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'";
                        }
                        else
                        {
                            if (txtCodeTo.Text.Trim() == string.Empty && txtDescriptionTo.Text.Trim() != string.Empty)
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%'";
                            }
                            else
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Supp_Code AS [Supplier Code],Supp_Name AS [Supplier Name] FROM Supplier";
                            }
                        }
                    }
                }
                else
                {
                    if (txtCodeTo.Text.Trim() == string.Empty && txtDescriptionTo.Text.Trim() == string.Empty)
                    {
                        objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                    }
                    else
                    {
                        if (txtCodeTo.Text.Trim() != string.Empty && txtDescriptionTo.Text.Trim() == string.Empty)
                        {
                            objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'";
                        }
                        else
                        {
                            if (txtCodeTo.Text.Trim() == string.Empty && txtDescriptionTo.Text.Trim() != string.Empty)
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%'";
                            }
                            else
                            {
                                objAccountAnalyse.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer";
                            }
                        }
                    }
                }
                objAccountAnalyse.DataSetName = "dsCustomer";
                objAccountAnalyse.GetCustomerDetails();
                search.dgSearch.DataSource = objAccountAnalyse.GetCustomerDataset.Tables["dsCustomer"];
                search.prop_Focus = txtCodeTo;
                search.Cont_Descript = txtDescriptionTo;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccountAnalyse 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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