using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Datas;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;
using Inventory.Properties;
using Inventory.CRMReports;
using Inventory.GiftVoucherReports;

namespace Inventory
{
    public partial class frmSalesInquary : Form
    {
        public frmSalesInquary()
        {
            InitializeComponent();
        }

        public int intRepOption;

        frmSearch search = new frmSearch();
        DataSet dsSubReport = new DataSet();
        clsSalesInquary objMasterDetails = new clsSalesInquary();
        //SQLDataManagement objDataManagement = new SQLDataManagement();

        private string strQuery;

        private static frmSalesInquary SalesInquary;

        public static frmSalesInquary GetSalesInquary
        {
            get { return SalesInquary; }
            set { SalesInquary = value; }
        }

        private void frmSalesInquary_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SalesInquary = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSalesInquary_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                SalesInquary = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCodeFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCodeFrom.Text = search.Code.Trim();
                    txtDescriptionFrom.Text = search.Descript.Trim();
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

        private void txtCodeTo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCodeTo.Text = search.Code.Trim();
                    txtDescriptionTo.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                MainClass.mdi.Cursor = Cursors.WaitCursor;
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                switch (intRepOption)
                {
                    case 451:
                    case 446:
                    case 431:                    
                    case 100://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code ASC";
                            }
                        }
                        break;
                    case 436:
                    case 432:
                    case 101://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;
                    case 437:
                    case 433:
                    case 102://stock Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;
                    case 445:
                    case 443:
                    case 438:
                    case 448:
                    case 435:
                    case 434:
                    case 447:
                    case 103://Supplier select for the search
                    case 429:
                    case 430:

                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 104://Brand - wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand Brand_Code ";
                            }
                        }
                        break;

                    case 117://Product select for the search in Purchasing Report
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 454:
                    case 427:
                    case 442:
                    case 119://Customer select for the search
                    case 460:
                     

                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'WSL') AND Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'WSL') AND Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'WSL') ORDER BY Cust_Code";
                            }
                        }
                        break;
                    case 462:

                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE   Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE   Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer    ORDER BY Cust_Code";
                            }
                        }
                        break;
                    case 200://Product select for the search in Purchasing Report
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 201://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;

                    case 202://stock Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;
                    case 441:
                    case 203://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 204://Brand -wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand Brand_Code ";
                            }
                        }
                        break;

                    case 300://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 301://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;

                    case 302://stock Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;
                    case 303://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 304://Brand-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code ";
                            }
                        }
                        break;

                    case 400://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 401://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;

                    case 402://stock Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;

                    case 403://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 404://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 405://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 406://Customer select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE  Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer ORDER BY Cust_Code";
                            }
                        }
                        break;

                    case 407://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 408://Customer select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer ORDER BY Cust_Code";
                            }
                        }
                        break;

                    case 411://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 413://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 415://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 416://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 418://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 419://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;

                    case 420://Product select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 421://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;
                    case 422://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 423://Supplier select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 424://Customer select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer ORDER BY Cust_Code";
                            }
                        }
                        break;
                    case 425://Customer select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Iid = 'RGL' AND Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Iid = 'RGL' AND Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE Iid = 'RGL' ORDER BY Cust_Code";
                            }
                        }
                        break;
                    case 440:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DISTINCT To_Loca [Code], To_LocaDesc [Location] FROM Transaction_Header WHERE Iid='TGN' AND Loca LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY To_Loca";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT DISTINCT To_Loca [Code], To_LocaDesc [Location] FROM Transaction_Header WHERE Iid='TGN' AND Loca_Descrip LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY To_Loca";
                            }
                            else
                            {
                                strQuery = "SELECT DISTINCT To_Loca [Code], To_LocaDesc [Location] FROM Transaction_Header WHERE Iid='TGN' ORDER BY To_Loca";
                            }
                        }
                        break;

                    case 455:
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.ExpenseCode LIKE'%" + txtCodeFrom.Text.Trim() + "%' AND ATS.Loca='" + LoginManager.LocaCode + "' GROUP BY Expense_Code,Expense_Name ORDER BY TS.Expense_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE Expense_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' AND ATS.Loca='" + LoginManager.LocaCode + "' GROUP BY Expense_Code,Expense_Name ORDER BY TS.Expense_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.Loca='" + LoginManager.LocaCode + "' GROUP BY Expense_Code,Expense_Name ORDER BY TS.Expense_Code";
                            }
                        }
                        break;

                    case 456:
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM tb_Expense TS  WHERE TS.Expense_Code LIKE'%" + txtCodeFrom.Text.Trim() + "%' ORDER BY TS.Expense_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM tb_Expense TS WHERE TS.Expense_Name LIKE'%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY TS.Expense_Name";
                            }
                            else
                            {
                                strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM tb_Expense TS ORDER BY TS.Expense_Code";
                            }
                        }
                        break;

                    case 458:   //Ledger Book
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Customer.Cust_code [Code], Customer.Cust_Name [Customer Name] FROM tb_LinkedCustSupp INNER JOIN Customer ON Customer.Cust_code=tb_LinkedCustSupp.Cust_code WHERE Customer.Cust_Code Like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Customer.Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Customer.Cust_code [Code], Customer.Cust_Name [Customer Name] FROM tb_LinkedCustSupp INNER JOIN Customer ON Customer.Cust_code=tb_LinkedCustSupp.Cust_code WHERE  Customer.Cust_Name Like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Customer.Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Customer.Cust_code [Code], Customer.Cust_Name [Customer Name] FROM tb_LinkedCustSupp INNER JOIN Customer ON Customer.Cust_code=tb_LinkedCustSupp.Cust_code ORDER BY Customer.Cust_Code";
                            }
                        }
                        break;

                    default:
                        break;
                }
                objMasterDetails.CodeFrom = txtDescriptionFrom.Text.Trim();
                objMasterDetails.SqlStatement = strQuery;
                objMasterDetails.dsName = "Table";
                objMasterDetails.RetriveData();

                search.dgSearch.DataSource = objMasterDetails.ResultSet.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSearchCodeTo_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.mdi.Cursor = Cursors.WaitCursor;
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                switch (intRepOption)
                {
                    case 451:
                    case 446:
                    case 431:
                    
                    case 100://Product select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code ASC";
                            }
                        }
                        break;
                    case 436:
                    case 432:
                    case 101://Deaprtment select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department ORDER BY Code";
                            }
                        }
                        break;
                    case 437:
                    case 433:
                    case 102://stock Category-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;
                    case 445:
                    case 443:
                    case 438:
                    case 435:
                    case 434:
                    case 447:
                    case 103://Supplier select for the search
                    case 430:
                    case 413:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 104://Brand-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand Brand_Code ";
                            }
                        }
                        break;

                    case 117://Product select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 454:
                    case 427:
                    case 442:
                    case 119://Customer select for the search
                    case 460:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'WSL') AND Cust_Code Like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'WSL') AND Cust_Name Like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_code [Code], Cust_Name [Customer Name] FROM Customer WHERE (Iid = 'RGL' OR Iid = 'WSL') ORDER BY Cust_Code";
                            }
                        }
                        break;

                    case 200://Product select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 201://Deaprtment select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department ORDER BY Code";
                            }
                        }
                        break;
                    case 202://stock Category-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;
                    case 441:
                    case 203://Supplier select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 204://Brand-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand Brand_Code ";
                            }
                        }
                        break;

                    case 300://Product select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 301://Deaprtment select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department ORDER BY Code";
                            }
                        }
                        break;
                    case 302://stock Category-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;
                    case 303://Supplier select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;

                    case 304://Brand-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code ";
                            }
                        }
                        break;

                    case 418://Product select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 419://Deaprtment select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department ORDER BY Code";
                            }
                        }
                        break;
                    case 420://Product select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 421://Deaprtment select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department ORDER BY Code";
                            }
                        }
                        break;
                    case 422://Supplier select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code Like '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name Like '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Supp_code [Code], Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 440:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT DISTINCT To_Loca [Code], To_LocaDesc [Location] FROM Transaction_Header WHERE Iid='TGN' AND Loca LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY To_Loca";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT DISTINCT To_Loca [Code], To_LocaDesc [Location] FROM Transaction_Header WHERE Iid='TGN' AND Loca_Descrip LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY To_Loca";
                            }
                            else
                            {
                                strQuery = "SELECT DISTINCT To_Loca [Code], To_LocaDesc [Location] FROM Transaction_Header WHERE Iid='TGN' ORDER BY To_Loca";
                            }
                        }
                        break;

                    case 455:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.ExpenseCode LIKE'%" + txtCodeTo.Text.Trim() + "%' AND ATS.Loca='" + LoginManager.LocaCode + "' GROUP BY Expense_Code,Expense_Name ORDER BY TS.Expense_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE Expense_Name LIKE'%" + txtDescriptionTo.Text.Trim() + "%' AND ATS.Loca='" + LoginManager.LocaCode + "' GROUP BY Expense_Code,Expense_Name ORDER BY TS.Expense_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Expense_Code  [Expence Code], Expense_Name [Expence Name] FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.Loca='" + LoginManager.LocaCode + "' GROUP BY Expense_Code,Expense_Name ORDER BY TS.Expense_name";
                            }
                        }
                        break;

                    default:
                        break;
                }
                objMasterDetails.CodeFrom = txtDescriptionTo.Text.Trim();
                objMasterDetails.SqlStatement = strQuery;
                objMasterDetails.dsName = "Table";
                objMasterDetails.RetriveData();

                search.dgSearch.DataSource = objMasterDetails.ResultSet.Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.mdi.Cursor = Cursors.WaitCursor;
                ///////////////////////////
                try
                {
                    // Cursor cu = new Cursor(@"..\\..\\horse.ani");

                    //this.Cursor = new Cursor(this.GetType().Assembly.GetManifestResourceStream("Resources.horse.ani"));

                    // MainClass.mdi.Cursor = cu;
                    // this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, "blob.ani"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                DataSet dsDataForReport = new DataSet();
                clsReportViewer objRepView = new clsReportViewer();
                clsSalesInquary objSalesInquary = new clsSalesInquary();

                frmReportViewer objRepViewer = new frmReportViewer();
                objRepViewer.Text = this.Text;

                if (DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateFrom.Value)) > DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateTo.Value)))
                {
                    MainClass.mdi.Cursor = Cursors.Default;
                    MessageBox.Show("Selected Date Is Not Valid. Please Select Valid Date Range.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MainClass.mdi.Cursor = Cursors.WaitCursor;
                switch (intRepOption)
                {
                    case 100:
                        bool ImageInRep = false;
                        if (Settings.Default.ProdImage == true && MessageBox.Show("Do you want to show Image in Report?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ImageInRep = true;
                        }
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '"+intRepOption+"',@DateFrom = '"+dtDateFrom.Text+"',@DateTo = '"+dtDateTo.Text+"',@CodeFrom = '"+txtCodeFrom.Text+"',@CodeTo = '"+txtCodeTo.Text+"',@Loca = '"+LoginManager.LocaCode+"', @Mac = '"+LoginManager.MacAddress+"',@Image='"+ImageInRep+"' ";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                
                                
                                if (Settings.Default.ProdImage == true && ImageInRep==true)
                                {
                                    rptProductSalesImg ProductSaleDet = new rptProductSalesImg();
                                    ProductSaleDet.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSaleDet;
                                }
                                else
                                {
                                    rptProductSales ProductSaleDet = new rptProductSales();
                                    ProductSaleDet.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSaleDet;
                                }

                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "',@DateFrom = '" + dtDateFrom.Text + "',@DateTo = '" + dtDateTo.Text + "',@CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "' ,@Image='" + ImageInRep + "' ";

                                //objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo,Product.Prod_Image FROM ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca  WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND ProductSalesSummery.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                if (Settings.Default.ProdImage == true && ImageInRep == true)
                                {
                                    rptProductSalesSortByDescImg ProductSalesSortByDesc = new rptProductSalesSortByDescImg();
                                    ProductSalesSortByDesc.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSalesSortByDesc;
                                }
                                else
                                {
                                    rptProductSalesSortByDesc ProductSalesSortByDesc = new rptProductSalesSortByDesc();
                                    ProductSalesSortByDesc.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSalesSortByDesc;
                                }
                                break;
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "',@DateFrom = '" + dtDateFrom.Text + "',@DateTo = '" + dtDateTo.Text + "',@CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "',@Image='" + ImageInRep + "' ";

                                //objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo,Product.Prod_Image FROM ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca  WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND ProductSalesSummery.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                if (Settings.Default.ProdImage == true  && ImageInRep==true)
                                {   rptProductSalesImg ProductSaleDet = new rptProductSalesImg();
                                    ProductSaleDet.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSaleDet;
                                }
                                else
                                {
                                    rptProductSales ProductSaleDet = new rptProductSales();
                                    ProductSaleDet.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSaleDet;
                                }
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "',@DateFrom = '" + dtDateFrom.Text + "',@DateTo = '" + dtDateTo.Text + "',@CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "' ,@Image='" + ImageInRep + "' ";

                                //objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo,Product.Prod_Image FROM ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND ProductSalesSummery.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                if (Settings.Default.ProdImage == true && ImageInRep == true)
                                {
                                    rptProductSalesSortByDescImg ProductSalesSortByDesc = new rptProductSalesSortByDescImg();
                                    ProductSalesSortByDesc.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSalesSortByDesc;
                                }
                                else
                                {
                                    rptProductSalesSortByDesc ProductSalesSortByDesc = new rptProductSalesSortByDesc();
                                    ProductSalesSortByDesc.SetDataSource(dsDataForReport);
                                    objRepViewer.crystalReportViewer1.ReportSource = ProductSalesSortByDesc;
                                }
                                break;
                            }
                        }

                    case 101:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Department_Id, Department.Dept_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptDepartmentSales DepartmentSaleDet = new rptDepartmentSales();
                                DepartmentSaleDet.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = DepartmentSaleDet;
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Department_Id, Department.Dept_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptDepartmentSalesSortByDesc DepartmentSalesSortByDesc = new rptDepartmentSalesSortByDesc();
                                DepartmentSalesSortByDesc.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = DepartmentSalesSortByDesc;
                                break;
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Department_Id, Department.Dept_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptDepartmentSales DepartmentSaleDet = new rptDepartmentSales();
                                DepartmentSaleDet.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = DepartmentSaleDet;
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Department_Id, Department.Dept_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptDepartmentSalesSortByDesc DepartmentSalesSortByDesc = new rptDepartmentSalesSortByDesc();
                                DepartmentSalesSortByDesc.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = DepartmentSalesSortByDesc;
                                break;
                            }

                        }

                    case 102:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Category_Id, Category.Cat_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptCategorySales CategorySaleDet = new rptCategorySales();
                                CategorySaleDet.SetDataSource(dsDataForReport);
                                //objDataManagement.OpenManager();
                                objRepViewer.crystalReportViewer1.ReportSource = CategorySaleDet;
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Category_Id, Category.Cat_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptCategorySalesByDesc CategorySalesByDesc = new rptCategorySalesByDesc();
                                CategorySalesByDesc.SetDataSource(dsDataForReport);
                                //objDataManagement.OpenManager();
                                objRepViewer.crystalReportViewer1.ReportSource = CategorySalesByDesc;
                                break;
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Category_Id, Category.Cat_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptCategorySales CategorySaleDet = new rptCategorySales();
                                CategorySaleDet.SetDataSource(dsDataForReport);
                                //objDataManagement.OpenManager();
                                objRepViewer.crystalReportViewer1.ReportSource = CategorySaleDet;
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Category_Id, Category.Cat_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptCategorySalesByDesc CategorySalesByDesc = new rptCategorySalesByDesc();
                                CategorySalesByDesc.SetDataSource(dsDataForReport);
                                //objDataManagement.OpenManager();
                                objRepViewer.crystalReportViewer1.ReportSource = CategorySalesByDesc;
                                break;
                            }
                        }

                    case 103:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Supplier_Id, Supplier.Supp_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptSupplierSales SupplierSaleDet = new rptSupplierSales();
                                SupplierSaleDet.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = SupplierSaleDet;
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Supplier_Id, Supplier.Supp_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptSupplierSalesByDesc SupplierSalesByDesc = new rptSupplierSalesByDesc();
                                SupplierSalesByDesc.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = SupplierSalesByDesc;
                                break;
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Supplier_Id, Supplier.Supp_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptSupplierSales SupplierSaleDet = new rptSupplierSales();
                                SupplierSaleDet.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = SupplierSaleDet;
                                break;
                            }
                            else
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Supplier_Id, Supplier.Supp_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                                objRepView.DataSetName = "dsSalesDetails";
                                objRepView.RetrieveData();
                                dsDataForReport = objRepView.TempResultSet;
                                rptSupplierSalesByDesc SupplierSalesByDesc = new rptSupplierSalesByDesc();
                                SupplierSalesByDesc.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = SupplierSalesByDesc;
                                break;
                            }
                        }

                    case 104:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY ProductSalesSummery.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY ProductSalesSummery.Prod_Name ASC";
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY ProductSalesSummery.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY ProductSalesSummery.Prod_Name ASC";
                            }
                        }
                        //objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Manufacturer_Id, manufacturer.Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN manufacturer ON manufacturer.Manf_Code = Product.Manufacturer_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Manufacturer_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";                      
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptManufactureSales ManufacturSaleDet = new rptManufactureSales();
                        ManufacturSaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ManufacturSaleDet;
                        break;

                    case 105:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.MonthlySalesSummary();
                        objRepView.SqlStatement = "select Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbReportMonthlyAnalyse Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptMonthlySalesAnalys MonyhlySaleDet = new rptMonthlySalesAnalys();
                        MonyhlySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = MonyhlySaleDet;
                        break;

                    case 106:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name,CONVERT(DATETIME, Tr_Date,103) Tr_Date, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbReportDailyAnalyse";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDailySalesAnalys DailySaleDet = new rptDailySalesAnalys();
                        DailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailySaleDet;
                        break;

                    case 107:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Product.Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Product ON tbSalesAnalyseType2.Prod_Code = Product.Prod_Code Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductDailySalesAnalys ProdDailySaleDet = new rptProductDailySalesAnalys();
                        ProdDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdDailySaleDet;
                        break;

                    case 108:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.PosSalesSummary();
                        //objRepView.SqlStatement = "select Unit_No, PosGross_Sales, PosRefund_Tot, PosRefund_No, PosVoid_Tot, PosVoid_No, PosError_Tot, PosError_No, PosCancel_Tot, PosCancel_No, PosNet_Amt, PosCash_Amt, PosCredit_amt, PosBill_Count, PosExchange_Tot, PosExchange_No, PosDiscount_Tot, PosDiscount_No, Declare_Amount, Pos_CashOut Cash_Out, Card1_Descr, Card1_Amount, Card2_Descr, Card2_Amount, Card3_Descr, Card3_Amount ,Card4_Descr ,Card4_Amount ,Card5_Descr ,Card5_Amount ,Dept1_Descr ,Dept1_Amount ,Dept2_Descr ,Dept2_Amount ,Dept3_Descr ,Dept3_Amount ,Dept4_Descr ,Dept4_Amount ,Dept5_Descr ,Dept5_Amount , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, tbPosSalesSummary.loca, Location.Loca_Descrip,WholeSale_Inv Invice,WholeSale_Return [Return],Wholesale_Payment Cheque, Wholesales_PaymentRtn RtnChq, Wholesale_Cash, GiftIssuesCash GVCash, GiftIssuesCredit GVCredit, Bank, Supplier_Pmt Payment, PettyCash Pos_CashOut FROM tbPosSalesSummary INNER JOIN Location on tbPosSalesSummary.loca = Location.loca";
                        //objRepView.DataSetName = "dsPosSalesSummary";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptPosSalesSummary PosSaleDet = new rptPosSalesSummary();
                        PosSaleDet.SetDataSource(dsDataForReport);
                        PosSaleDet.SummaryInfo.ReportTitle = "Pos Sale Summary Report";
                        objRepViewer.crystalReportViewer1.ReportSource = PosSaleDet;
                        break;

                    case 109:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca WHERE (ProductSalesSummery.Iid = 'CUR' OR ProductSalesSummery.Iid = 'R01') and ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) Order By ProductSalesSummery.Prod_Code ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptProductExchange ProductExchangeDet = new rptProductExchange();
                            ProductExchangeDet.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductExchangeDet;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca WHERE (ProductSalesSummery.Iid = 'CUR' OR ProductSalesSummery.Iid = 'R01') and ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) Order By ProductSalesSummery.Prod_Name ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptProductExchangeDesc ProductExchangeDesc = new rptProductExchangeDesc();
                            ProductExchangeDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductExchangeDesc;
                        }
                        break;

                    case 110:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objRepView.SqlStatement = "select tb_salesman.Sale_Code, tb_salesman.Sale_Name, tb_salesman.Vehicle_No, tb_salesman.Sales_Target, DayEnd_Pos_Transaction.iid, sum(DayEnd_Pos_Transaction.Amount) Amount, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from DayEnd_Pos_Transaction inner join tb_salesman on DayEnd_Pos_Transaction.salesman = tb_Salesman.Sale_Code where (iid = '001' or iid = 'R01' or iid = '005') and DayEnd_Pos_Transaction.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,DayEnd_Pos_Transaction.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) group by tb_salesman.Sale_Code, tb_salesman.Sale_Name, tb_salesman.Vehicle_No, tb_salesman.Sales_Target, DayEnd_Pos_Transaction.iid ";
                        objRepView.DataSetName = "dsSalesmanSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSalesmanSales SalesManSales = new rptSalesmanSales();
                        SalesManSales.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SalesManSales;
                        break;

                    case 111:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.PosCurrentSalesSummary();
                        //objRepView.SqlStatement = "select Unit_No, PosGross_Sales, PosRefund_Tot, PosRefund_No, PosVoid_Tot, PosVoid_No, PosError_Tot, PosError_No, PosCancel_Tot, PosCancel_No, PosNet_Amt, PosCash_Amt, PosCredit_amt, PosBill_Count, PosExchange_Tot, PosExchange_No, PosDiscount_Tot, PosDiscount_No, Declare_Amount, Pos_CashOut Cash_Out, Card1_Descr, Card1_Amount, Card2_Descr, Card2_Amount, Card3_Descr, Card3_Amount ,Card4_Descr ,Card4_Amount ,Card5_Descr ,Card5_Amount ,Dept1_Descr ,Dept1_Amount ,Dept2_Descr ,Dept2_Amount ,Dept3_Descr ,Dept3_Amount ,Dept4_Descr ,Dept4_Amount ,Dept5_Descr ,Dept5_Amount , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, tbPosSalesSummary.loca, Location.Loca_Descrip,WholeSale_Inv Invice,WholeSale_Return [Return],Wholesale_Payment Cheque, Wholesales_PaymentRtn RtnChq, Wholesale_Cash, GiftIssuesCash GVCash, GiftIssuesCredit GVCredit, Bank, Supplier_Pmt Payment, PettyCash Pos_CashOut FROM tbPosSalesSummary INNER JOIN Location on tbPosSalesSummary.loca = Location.loca";                        
                        //objRepView.SqlStatement = "select Unit_No, PosGross_Sales, PosRefund_Tot, PosRefund_No, PosVoid_Tot, PosVoid_No, PosError_Tot, PosError_No, PosCancel_Tot, PosCancel_No, PosNet_Amt, PosCash_Amt, PosCredit_amt, PosBill_Count, PosExchange_Tot, PosExchange_No, PosDiscount_Tot, PosDiscount_No, Declare_Amount, Pos_CashOut, Card1_Descr, Card1_Amount, Card2_Descr, Card2_Amount, Card3_Descr, Card3_Amount ,Card4_Descr ,Card4_Amount ,Card5_Descr ,Card5_Amount ,Dept1_Descr ,Dept1_Amount ,Dept2_Descr ,Dept2_Amount ,Dept3_Descr ,Dept3_Amount ,Dept4_Descr ,Dept4_Amount ,Dept5_Descr ,Dept5_Amount , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, tbPosSalesSummary.loca, Location.Loca_Descrip from tbPosSalesSummary inner join Location on tbPosSalesSummary.loca = Location.loca";
                        objRepView.DataSetName = "dsPosSalesSummary";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptPosSalesSummary CurrPosSaleDet = new rptPosSalesSummary();
                        CurrPosSaleDet.SetDataSource(dsDataForReport);
                        CurrPosSaleDet.SummaryInfo.ReportTitle = "Current Sale Summary Report";
                        //objDataManagement.OpenManager();
                        objRepViewer.crystalReportViewer1.ReportSource = CurrPosSaleDet;
                        break;

                    case 112://Current Hourly sales
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.Iid = "CUR";
                        objSalesInquary.PosHourlySales();
                        objRepView.SqlStatement = "select tb_HourlySales.Time_Id, tb_HourlySales.Time_Desc, tb_HourlySales.Qty, tb_HourlySales.Amount, tb_HourlySales.Loca , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, Location.Loca_Descrip from tb_HourlySales inner join Location on tb_HourlySales.loca = Location.loca WHERE tb_HourlySales.loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsHourlySales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptHourlySales CurHourlySales = new rptHourlySales();
                        CurHourlySales.SetDataSource(dsDataForReport);
                        CurHourlySales.SummaryInfo.ReportTitle = "Hourly Sale Summary";
                        objRepViewer.crystalReportViewer1.ReportSource = CurHourlySales;
                        break;

                    case 113://Current Hourly sales Previous Day
                        objRepView.SqlStatement = "select convert(datetime,BillDate,103) BillDate_Tr, BillDate, Datepart(hh,convert(datetime,BillTime,103)) Time_Id, ISNULL(SUM(CASE Iid WHEN '001' THEN Qty WHEN 'R01' THEN QTY ELSE 0 END), 0) Qty, ISNULL(SUM(CASE Iid WHEN '001' THEN Amount WHEN '002' THEN Amount WHEN 'R01' THEN Amount WHEN 'R02' THEN Amount WHEN '005' THEN Amount ELSE 0 END), 0) Amount, DayEnd_Pos_Transaction.Loca, Location.Loca_Descrip, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from DayEnd_Pos_Transaction INNER JOIN Location ON DayEnd_Pos_Transaction.Loca = Location.Loca  WHERE DayEnd_Pos_Transaction.loca = '" + LoginManager.LocaCode + "' AND (CONVERT(DATETIME,BillDate, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)) AND (Iid = '001' OR Iid = 'R01' OR Iid = '002' OR Iid = 'R02' OR Iid = '005') GROUP BY Datepart(hh,convert(datetime,BillTime,103)),convert(datetime,BillDate,103), BillDate, DayEnd_Pos_Transaction.Loca, Location.Loca_Descrip";
                        objRepView.DataSetName = "dsHourlySales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPreHourlySales PreHourlySales = new rptPreHourlySales();
                        PreHourlySales.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = PreHourlySales;
                        break;

                    case 114://Collection report
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailyCollection();
                        objRepView.SqlStatement = "select Sale_Date, Unit_No, PosGross_Sales, PosRefund_Tot, PosRefund_No, PosVoid_Tot, PosVoid_No, PosError_Tot, PosError_No, PosCancel_Tot, PosCancel_No, PosNet_Amt, PosCash_Amt, PosCredit_amt, PosBill_Count, PosExchange_Tot, PosExchange_No, PosDiscount_Tot, PosDiscount_No, Declare_Amount, Pos_CashOut, Card1_Descr, Card1_Amount, Card2_Descr, Card2_Amount, Card3_Descr, Card3_Amount ,Card4_Descr ,Card4_Amount ,Card5_Descr ,Card5_Amount ,Dept1_Descr ,Dept1_Amount ,Dept2_Descr ,Dept2_Amount ,Dept3_Descr ,Dept3_Amount ,Dept4_Descr ,Dept4_Amount ,Dept5_Descr ,Dept5_Amount , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, tbPosSalesSummary.loca, Location.Loca_Descrip from tbPosSalesSummary inner join Location on tbPosSalesSummary.loca = Location.loca";
                        objRepView.DataSetName = "dsDailyCollection";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDailyCollectionReport DailyCollection = new rptDailyCollectionReport();
                        DailyCollection.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailyCollection;
                        break;
                    case 115://Receipt wise sales report

                        objRepView.SqlStatement = "SELECT DayEnd_Pos_Transaction.Loca, Location.Loca_Descrip, DayEnd_Pos_Transaction.BillDate, DayEnd_Pos_Transaction.UserName, DayEnd_Pos_Transaction.Receipt_No, DayEnd_Pos_Transaction.Unit, ISNULL(SUM((CASE Iid WHEN '001' THEN Amount WHEN 'R01' THEN Amount WHEN '002' THEN Amount WHEN 'R02' THEN Amount WHEN '005' THEN Amount ELSE 0 END)), 0) Amount, ISNULL(SUM((CASE Iid WHEN '005' THEN -Amount ELSE 0 END)), 0) Discount , '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo FROM DayEnd_Pos_Transaction INNER JOIN Location ON DayEnd_Pos_Transaction.Loca = Location.Loca WHERE DayEnd_Pos_Transaction.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) GROUP By DayEnd_Pos_Transaction.Loca, Location.Loca_Descrip, BillDate, Receipt_No, Unit, DayEnd_Pos_Transaction.UserName ORDER BY convert(datetime,BillDate, 103), Unit, Receipt_No";
                        objRepView.DataSetName = "dsReceiptWiseSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptReceiptWiseSales ReceiptSales = new rptReceiptWiseSales();
                        ReceiptSales.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ReceiptSales;
                        break;
                    case 116:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objRepView.SqlStatement = "select tb_salesman.Sale_Code, tb_salesman.Sale_Name, tb_salesman.Vehicle_No, tb_salesman.Sales_Target, CASE DayEnd_Pos_Transaction.Iid WHEN '005' THEN 'ZZZZZZZZZZ' ELSE DayEnd_Pos_Transaction.Item_Code END Item_Code, DayEnd_Pos_Transaction.Item_Descrip,DayEnd_Pos_Transaction.Unit_Price, sum(DayEnd_Pos_Transaction.Qty) Qty, DayEnd_Pos_Transaction.iid, sum(DayEnd_Pos_Transaction.Amount) Amount, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from DayEnd_Pos_Transaction inner join tb_salesman on DayEnd_Pos_Transaction.salesman = tb_Salesman.Sale_Code where (iid = '001' or iid = 'R01' or iid = '005') and DayEnd_Pos_Transaction.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,DayEnd_Pos_Transaction.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) group by tb_salesman.Sale_Code, tb_salesman.Sale_Name, tb_salesman.Vehicle_No, tb_salesman.Sales_Target, DayEnd_Pos_Transaction.iid, DayEnd_Pos_Transaction.Item_Code, DayEnd_Pos_Transaction.Item_Descrip,DayEnd_Pos_Transaction.Unit_Price";
                        objRepView.DataSetName = "dsSalesmanSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSalesmanProductSales SalesManProductSales = new rptSalesmanProductSales();
                        SalesManProductSales.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SalesManProductSales;
                        break;

                    case 117:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select DE.Item_Code, DE.Item_Descrip, DE.Unit_Price, DE.Amount, DE.Qty, DE.Receipt_No, DE.UserName, DE.BillDate, CONVERT(DATETIME, DE.BillDate, 103) Tr_Date, DE.Unit, DE.Loca, L.Loca_Descrip, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from DayEnd_Pos_Transaction DE INNER JOIN Location L ON DE.Loca = L.Loca WHERE DE.Loca = '" + LoginManager.LocaCode + "' AND DE.Iid ='004' AND (Item_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND (CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)) Order By DE.Item_Code ASC";
                            objRepView.DataSetName = "dsProductDiscount";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptProductDiscount ProductDiscount = new rptProductDiscount();
                            ProductDiscount.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductDiscount;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select DE.Item_Code, DE.Item_Descrip, DE.Unit_Price, DE.Amount, DE.Qty, DE.Receipt_No, DE.UserName, DE.BillDate, CONVERT(DATETIME, DE.BillDate, 103) Tr_Date, DE.Unit, DE.Loca, L.Loca_Descrip, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from DayEnd_Pos_Transaction DE INNER JOIN Location L ON DE.Loca = L.Loca WHERE DE.Loca = '" + LoginManager.LocaCode + "' AND DE.Iid ='004' AND (Item_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND (CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)) Order By DE.Item_Descrip Asc";
                            objRepView.DataSetName = "dsProductDiscount";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptProductDiscountDesc ProductDiscountDesc = new rptProductDiscountDesc();
                            ProductDiscountDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductDiscountDesc;
                        }

                        break;

                    case 118:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objRepView.SqlStatement = "select tb_salesman.Sale_Code, tb_salesman.Sale_Name, tb_salesman.Vehicle_No, tb_salesman.Sales_Target, sum(DayEnd_Pos_Transaction.Amount) Amount, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from DayEnd_Pos_Transaction inner join tb_salesman on DayEnd_Pos_Transaction.salesman = tb_Salesman.Sale_Code where (iid = '001' or iid = 'R01' or iid = '005') and DayEnd_Pos_Transaction.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,DayEnd_Pos_Transaction.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) group by tb_salesman.Sale_Code, tb_salesman.Sale_Name, tb_salesman.Vehicle_No, tb_salesman.Sales_Target";
                        objRepView.DataSetName = "dsSalesmanSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSalesmanSalesPerform SalesManSalesPer = new rptSalesmanSalesPerform();
                        SalesManSalesPer.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SalesManSalesPer;
                        break;

                    case 119:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT SL.Item_Code, SL.Item_Descrip, SL.BillDate, CONVERT(DATETIME,SL.BillDate,103) Tr_Date, CASE SL.Iid WHEN '001' THEN SL.Qty WHEN 'R01' THEN -SL.Qty ELSE 0 END Qty, CASE SL.Iid WHEN '001' THEN SL.Amount WHEN 'R01' THEN -SL.Amount ELSE 0 END Amount, SL.Unit_Price, SL.Receipt_No, SL.Customer, SL.Loca, C.Cust_Name, L.Loca_Descrip,'" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo  FROM DayEnd_Pos_Transaction SL INNER JOIN Location L ON SL.Loca = L.Loca INNER JOIN Customer C ON SL.Customer = C.Cust_Code WHERE (SL.iid = '001' or SL.iid = 'R01') and SL.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,SL.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) ORDER BY SL.Item_Code";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT SL.Item_Code, SL.Item_Descrip, SL.BillDate, CONVERT(DATETIME,SL.BillDate,103) Tr_Date, CASE SL.Iid WHEN '001' THEN SL.Qty WHEN 'R01' THEN -SL.Qty ELSE 0 END Qty, CASE SL.Iid WHEN '001' THEN SL.Amount WHEN 'R01' THEN -SL.Amount ELSE 0 END Amount, SL.Unit_Price, SL.Receipt_No, SL.Customer, SL.Loca, C.Cust_Name, L.Loca_Descrip,'" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo  FROM DayEnd_Pos_Transaction SL INNER JOIN Location L ON SL.Loca = L.Loca INNER JOIN Customer C ON SL.Customer = C.Cust_Code WHERE (SL.iid = '001' or SL.iid = 'R01') and SL.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,SL.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) ORDER BY SL.Item_Descrip";
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT SL.Item_Code, SL.Item_Descrip, SL.BillDate, CONVERT(DATETIME,SL.BillDate,103) Tr_Date, CASE SL.Iid WHEN '001' THEN SL.Qty WHEN 'R01' THEN -SL.Qty ELSE 0 END Qty, CASE SL.Iid WHEN '001' THEN SL.Amount WHEN 'R01' THEN -SL.Amount ELSE 0 END Amount, SL.Unit_Price, SL.Receipt_No, SL.Customer, SL.Loca, C.Cust_Name, L.Loca_Descrip,'" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo  FROM DayEnd_Pos_Transaction SL INNER JOIN Location L ON SL.Loca = L.Loca INNER JOIN Customer C ON SL.Customer = C.Cust_Code WHERE (SL.iid = '001' or SL.iid = 'R01') and SL.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,SL.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) ORDER BY SL.Item_Code";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT SL.Item_Code, SL.Item_Descrip, SL.BillDate, CONVERT(DATETIME,SL.BillDate,103) Tr_Date, CASE SL.Iid WHEN '001' THEN SL.Qty WHEN 'R01' THEN -SL.Qty ELSE 0 END Qty, CASE SL.Iid WHEN '001' THEN SL.Amount WHEN 'R01' THEN -SL.Amount ELSE 0 END Amount, SL.Unit_Price, SL.Receipt_No, SL.Customer, SL.Loca, C.Cust_Name, L.Loca_Descrip,'" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo  FROM DayEnd_Pos_Transaction SL INNER JOIN Location L ON SL.Loca = L.Loca INNER JOIN Customer C ON SL.Customer = C.Cust_Code WHERE (SL.iid = '001' or SL.iid = 'R01') and SL.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,SL.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103)) ORDER BY SL.Item_Descrip";
                            }
                        }
                        //objRepView.SqlStatement = "SELECT SL.Item_Code, SL.Item_Descrip, SL.BillDate, CONVERT(DATETIME,SL.BillDate,103) Tr_Date, CASE SL.Iid WHEN '001' THEN SL.Qty WHEN 'R01' THEN -SL.Qty ELSE 0 END Qty, CASE SL.Iid WHEN '001' THEN SL.Amount WHEN 'R01' THEN -SL.Amount ELSE 0 END Amount, SL.Unit_Price, SL.Receipt_No, SL.Customer, SL.Loca, C.Cust_Name, L.Loca_Descrip,'" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo  FROM DayEnd_Pos_Transaction SL INNER JOIN Location L ON SL.Loca = L.Loca INNER JOIN Customer C ON SL.Customer = C.Cust_Code WHERE (SL.iid = '001' or SL.iid = 'R01') and SL.Loca = '" + LoginManager.LocaCode + "' and (convert(datetime,SL.BillDate,103) between  convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103))";
                        objRepView.DataSetName = "dsCustomerSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCustomerProductSales CustomerProSale = new rptCustomerProductSales();
                        CustomerProSale.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CustomerProSale;
                        break;

                    //Purchasing Repot
                    case 200:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Name ASC";
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Name ASC";
                            }
                        }
                        //objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsPurchasingDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProdWisePurchase ProductPurchDet = new rptProdWisePurchase();
                        ProductPurchDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProductPurchDet;
                        break;

                    case 201:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Department_Id, Department.Dept_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Department ON Product.Department_Id = Department.Dept_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Code";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Department_Id, Department.Dept_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Department ON Product.Department_Id = Department.Dept_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Name";
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Department_Id, Department.Dept_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Department ON Product.Department_Id = Department.Dept_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Code";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Department_Id, Department.Dept_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Department ON Product.Department_Id = Department.Dept_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Name";
                            }
                        }
                        //objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Department_Id, Department.Dept_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Department ON Product.Department_Id = Department.Dept_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsPurchasingDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDepartmentWisePurchase DeptPurchDet = new rptDepartmentWisePurchase();
                        DeptPurchDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DeptPurchDet;
                        break;

                    case 202:
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Category_Id, Category.Cat_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Category ON Product.Category_Id = Category.Cat_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Category_Id, Category.Cat_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Category ON Product.Category_Id = Category.Cat_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Name ASC";
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Category_Id, Category.Cat_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Category ON Product.Category_Id = Category.Cat_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Category_Id, Category.Cat_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Category ON Product.Category_Id = Category.Cat_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' ORDER BY Transaction_Details.Prod_Name ASC";
                            }
                        }
                        //objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Category_Id, Category.Cat_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Category ON Product.Category_Id = Category.Cat_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsPurchasingDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategoryWisePurchase CatPurchDet = new rptCategoryWisePurchase();
                        CatPurchDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CatPurchDet;
                        break;

                    case 203:
                        if (MessageBox.Show("Do You Want To Show Purchasing Details From Grn Supplier Wise?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Supplier.Supp_Code Supplier_Id, Supplier.Supp_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Supplier ON Transaction_Details.Supplier_Id = Supplier.Supp_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Transaction_Details.Supplier_Id ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Supplier.Supp_Code Supplier_Id, Supplier.Supp_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Supplier ON Transaction_Details.Supplier_Id = Supplier.Supp_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Transaction_Details.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Supplier.Supp_Name ASC";
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Supplier_Id, Supplier.Supp_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Supplier ON Product.Supplier_Id = Supplier.Supp_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Product.Supplier_Id ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Supplier_Id, Supplier.Supp_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Supplier ON Product.Supplier_Id = Supplier.Supp_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Supplier.Supp_Name ASC";
                            }
                        }
                        if (rbByCode.Checked == true)
                        {
                            objRepView.DataSetName = "dsPurchasingDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptSupplierWisePurchase SuppPurchDet = new rptSupplierWisePurchase();
                            SuppPurchDet.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = SuppPurchDet;
                        }
                        else
                        {

                            objRepView.DataSetName = "dsPurchasingDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptSupplierWisePurchasedesc SupplierWisePurchasedesc = new rptSupplierWisePurchasedesc();
                            SupplierWisePurchasedesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = SupplierWisePurchasedesc;
                        }
                        break;

                    case 204:
                        //objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Manufacturer_Id, manufacturer.Manf_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN manufacturer ON Product.Manufacturer_Id = manufacturer.Manf_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Manufacturer_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.SqlStatement = "select Transaction_Details.Loca, Location.Loca_Descrip,Transaction_Details.Doc_No, Transaction_Details.Iid, Transaction_Details.Post_Date Purch_Date, Transaction_Details.Prod_Code, Transaction_Details.Prod_Name, Product.Brand_Code Manufacturer_Id, Brand.BRand_Name Manf_Name, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Qty WHEN 'SRN' THEN -Transaction_Details.Qty ELSE 0 END Qty, CASE Transaction_Details.Iid WHEN 'GRN' THEN Transaction_Details.Amount WHEN 'SRN' THEN -Transaction_Details.Amount ELSE 0 END Amount, Transaction_Details.Purchase_price, Transaction_Details.Selling_Price , '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Transaction_Details INNER JOIN Product ON Transaction_Details.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = Transaction_Details.Loca INNER JOIN Brand ON Product.Brand_Code = Brand.Brand_Code WHERE (Transaction_Details.IId = 'GRN' OR Transaction_Details.Iid = 'SRN') AND Transaction_Details.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,Transaction_Details.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsPurchasingDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptManufacWisePurchase MnauPurchDet = new rptManufacWisePurchase();
                        MnauPurchDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = MnauPurchDet;
                        break;

                    case 205:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.MonthlyPurchaseSummary();
                        objRepView.SqlStatement = "select Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbReportMonthlyAnalyse Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptMonthlyPurchaseAnalys MonyhlyPurchDet = new rptMonthlyPurchaseAnalys();
                        MonyhlyPurchDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = MonyhlyPurchDet;
                        break;

                    //Profit Report
                    case 300:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND ProductSalesSummery.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' AND ProductSalesSummery.Qty<>0 Order By ProductSalesSummery.Prod_Code ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptProductGrossProfit ProductProfitDet = new rptProductGrossProfit();
                            ProductProfitDet.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductProfitDet;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND ProductSalesSummery.Prod_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' AND ProductSalesSummery.Qty<>0 Order By ProductSalesSummery.Prod_Name ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptProductGrossProfitDesc ProductGrossProfitDesc = new rptProductGrossProfitDesc();
                            ProductGrossProfitDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductGrossProfitDesc;
                        }

                        break;

                    case 301:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Department_Id, Department.Dept_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By ProductSalesSummery.Prod_Code, Product.Department_Id ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptDepartmentProfit DepartmentProfitDet = new rptDepartmentProfit();
                            DepartmentProfitDet.SetDataSource(dsDataForReport);
                            //objDataManagement.OpenManager();
                            objRepViewer.crystalReportViewer1.ReportSource = DepartmentProfitDet;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Department_Id, Department.Dept_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Department_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Department.Dept_Name, ProductSalesSummery.Prod_Name ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptDepartmentProfitDesc DepartmentProfitDesc = new rptDepartmentProfitDesc();
                            DepartmentProfitDesc.SetDataSource(dsDataForReport);
                            //objDataManagement.OpenManager();
                            objRepViewer.crystalReportViewer1.ReportSource = DepartmentProfitDesc;
                        }

                        break;

                    case 302:
                        objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Category_Id, Category.Cat_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Category_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategoryProfit CategoryProfitDet = new rptCategoryProfit();
                        CategoryProfitDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CategoryProfitDet;
                        break;

                    case 303:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Supplier_Id, Supplier.Supp_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By ProductSalesSummery.Prod_Code, Product.Supplier_Id ASC";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptSupplierProfit SupplierProfitDet = new rptSupplierProfit();
                            SupplierProfitDet.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = SupplierProfitDet;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Supplier_Id, Supplier.Supp_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Supplier_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order BY  Supplier.Supp_Name, ProductSalesSummery.Prod_Name";
                            objRepView.DataSetName = "dsSalesDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptSupplierProfitDesc SupplierProfitDesc = new rptSupplierProfitDesc();
                            SupplierProfitDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = SupplierProfitDesc;
                        }

                        break;

                    case 304:
                        //                        objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Manufacturer_Id, manufacturer.Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN manufacturer ON manufacturer.Manf_Code = Product.Manufacturer_Id WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Manufacturer_Id between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.SqlStatement = "select ProductSalesSummery.Loca, Location.Loca_Descrip, CASE ProductSalesSummery.Iid WHEN 'INV' THEN '001' WHEN 'CUR' THEN 'R01' ELSE ProductSalesSummery.Iid END Iid, ProductSalesSummery.Sales_Date, ProductSalesSummery.Prod_Code, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, ProductSalesSummery.Prod_Name, ProductSalesSummery.Qty, ProductSalesSummery.Amount, ProductSalesSummery.Purchase_price, ProductSalesSummery.Selling_Price, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Location ON Location.Loca = ProductSalesSummery.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code WHERE ProductSalesSummery.Loca = " + LoginManager.LocaCode + " AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ) AND Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptManufactureProfit ManufacturProfitDet = new rptManufactureProfit();
                        ManufacturProfitDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ManufacturProfitDet;
                        break;

                    case 305:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.MonthlyProfitSummary();
                        objRepView.SqlStatement = "select Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbReportMonthlyAnalyse Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptMonthlyProfitAnalys MonyhlyProfitDet = new rptMonthlyProfitAnalys();
                        MonyhlyProfitDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = MonyhlyProfitDet;
                        break;

                    case 306:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, convert(datetime,Tr_Date,103) Tr_Date, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbReportDailyAnalyse order by convert(datetime,Tr_Date,103)";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDailyProfitAnalys DailyProfitDet = new rptDailyProfitAnalys();
                        DailyProfitDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailyProfitDet;
                        break;


                    case 307:

                        objRepView.SqlStatement = "select SL.User_Name, SL.Tr_Date, SL.Loca, SL.Iid, SL.Tr_Code, SL.Tr_Description, L.Loca_Descrip, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tb_System_Log SL INNER JOIN Location L ON SL.Loca = L.Loca WHERE SL.Loca = '" + LoginManager.LocaCode + "' AND CONVERT(DATETIME, Tr_Date, 103) BETWEEN CONVERT(DATETIME, '" + dtDateFrom.Text + "', 103) AND CONVERT(DATETIME, '" + dtDateTo.Text + "', 103) Order by Tr_Date";
                        objRepView.DataSetName = "dsSystem_Log";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSystemLog SystemLog = new rptSystemLog();
                        SystemLog.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SystemLog;
                        break;

                    case 308:

                        objRepView.SqlStatement = "SELECT PPS.Org_Doc_no, PPS.Bank_Name, PPS.Cheque_No, PPS.Cheque_Date, PPS.Branch, PPS.Amount, PPS.Loca, L.Loca_Descrip, PPS.Acc_Code, S.Supp_Name, Tr_Date, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from tbPaidPaymentSummary PPS INNER JOIN Location L ON PPS.Loca = L.Loca INNER JOIN Supplier S ON PPS.Acc_Code = S.Supp_Code WHERE PPS.Loca = '" + LoginManager.LocaCode + "' AND PPS.Payment_Mode = 'CHEQUE' AND (CONVERT(DATETIME, PPS.Cheque_Date, 103) BETWEEN CONVERT(DATETIME, '" + dtDateFrom.Text + "', 103) AND CONVERT(DATETIME, '" + dtDateTo.Text + "', 103)) AND PPS.Iid = 'PMT'";
                        objRepView.DataSetName = "dsPostDatedCheque";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptIssuedPostDateCheque IssuedPostDateCheque = new rptIssuedPostDateCheque();
                        IssuedPostDateCheque.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = IssuedPostDateCheque;
                        break;

                    case 309:

                        objRepView.SqlStatement = "SELECT PPS.Org_Doc_no, PPS.Bank_Name, PPS.Cheque_No, PPS.Cheque_Date, PPS.Branch, PPS.Amount, PPS.Loca, L.Loca_Descrip, PPS.Acc_Code, S.Cust_Name Supp_Name, Tr_Date, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from tbPaidPaymentSummary PPS INNER JOIN Location L ON PPS.Loca = L.Loca INNER JOIN Customer S ON PPS.Acc_Code = S.Cust_Code WHERE PPS.Loca = '" + LoginManager.LocaCode + "' AND PPS.Payment_Mode = 'CHEQUE' AND (CONVERT(DATETIME, PPS.Cheque_Date, 103) BETWEEN CONVERT(DATETIME, '" + dtDateFrom.Text + "', 103) AND CONVERT(DATETIME, '" + dtDateTo.Text + "', 103)) AND PPS.Iid = 'REC'";
                        objRepView.DataSetName = "dsPostDatedCheque";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptReceivedPostDateCheque ReceivedPostDateCheque = new rptReceivedPostDateCheque();
                        ReceivedPostDateCheque.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ReceivedPostDateCheque;
                        break;

                    case 400:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Iid = "PR";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailyProfitSummary();
                        objRepView.SqlStatement = "select Prod_Code, Prod_Name, Purchase_price, Selling_Price, Purch_Amount, Sel_Amount, Pro_Amount, Tr_Date, Sel_Qty, Pur_Qty, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbDailyPurSaleProfAnalyse";
                        objRepView.DataSetName = "dsAnalyseData";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductAnalyse DailyProfitSummary = new rptProductAnalyse();
                        DailyProfitSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailyProfitSummary;
                        break;
                    case 401:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Iid = "DP";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailyProfitSummary();
                        objRepView.SqlStatement = "select Prod_Code, Prod_Name, Purchase_price, Selling_Price, Purch_Amount, Sel_Amount, Pro_Amount, Tr_Date, Sel_Qty, Pur_Qty, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbDailyPurSaleProfAnalyse";
                        objRepView.DataSetName = "dsAnalyseData";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDepartmentAnalyse DailyDepartmentProfitSummary = new rptDepartmentAnalyse();
                        DailyDepartmentProfitSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailyDepartmentProfitSummary;
                        break;
                    case 402:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Iid = "CT";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailyProfitSummary();
                        objRepView.SqlStatement = "select Prod_Code, Prod_Name, Purchase_price, Selling_Price, Purch_Amount, Sel_Amount, Pro_Amount, Tr_Date, Sel_Qty, Pur_Qty, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbDailyPurSaleProfAnalyse";
                        objRepView.DataSetName = "dsAnalyseData";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategoryAnalyse DailyCategoryProfitSummary = new rptCategoryAnalyse();
                        DailyCategoryProfitSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailyCategoryProfitSummary;
                        break;

                    case 403:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Iid = "SP";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailyProfitSummary();
                        objRepView.SqlStatement = "select Prod_Code, Prod_Name, Purchase_price, Selling_Price, Purch_Amount, Sel_Amount, Pro_Amount, Tr_Date, Sel_Qty, Pur_Qty, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbDailyPurSaleProfAnalyse";
                        objRepView.DataSetName = "dsAnalyseData";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSupplierAnalyse DailySupplierProfitSummary = new rptSupplierAnalyse();
                        DailySupplierProfitSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailySupplierProfitSummary;
                        break;

                    case 404:   //Product Bin Card
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim().ToString();
                        //objSalesInquary.Loca = LoginManager.LocaCode.ToString();
                        objSalesInquary.ProductBinCard();
                        //objRepView.SqlStatement = "SELECT BC.Prod_Code, BC.Qty, BC.Iid, BC.Loca, BC.To_Loca, BC.Doc_No, CONVERT(DATETIME,BC.Post_Date,103) [Post_Date], BC.InsertDate, BC.idx, BC.TrId, P.Prod_Name, P.Purchase_price, P.Selling_Price, L.Loca_Descrip FROM tbBinCard BC INNER JOIN Product P On BC.Prod_Code = P.Prod_Code INNER JOIN Location L ON L.Loca = " + LoginManager.LocaCode + "ORDER BY CONVERT(DATETIME,BC.Post_Date,103) ASC";
                        //objRepView.DataSetName = "dsProductBinCard";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptProductBinCard ProductBinCard = new rptProductBinCard();
                        ProductBinCard.SetDataSource(dsDataForReport);
                        //objDataManagement.OpenManager();
                        objRepViewer.crystalReportViewer1.ReportSource = ProductBinCard;
                        break;

                    case 405:   //Creditor Statement
                        objSalesInquary.Iid = "SUP";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.CreditorStatement();
                        //objRepView.SqlStatement = "select tbCreditorStatement.*, Supplier.Supp_Name, Location.Loca_Descrip from tbCreditorStatement inner join Supplier On tbCreditorStatement.Acc_No = Supplier.Supp_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        //objRepView.DataSetName = "SupplierStatement";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptCreditorStatement CreditorStatement = new rptCreditorStatement();
                        CreditorStatement.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CreditorStatement;
                        break;

                    case 406:   //debtor Statement
                        objSalesInquary.Iid = "CUS";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.CreditorStatement();
                        //objRepView.SqlStatement = "SELECT tbCreditorStatement.*, Customer.Cust_Name Supp_Name, Location.Loca_Descrip from tbCreditorStatement inner join Customer On tbCreditorStatement.Acc_No = Customer.Cust_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        //objRepView.DataSetName = "SupplierStatement";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptDebetorStatement DebtorStatement = new rptDebetorStatement();
                        DebtorStatement.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DebtorStatement;
                        break;

                    case 407:   //Creditor Balance
                        objSalesInquary.Iid = "SUP";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.CreditorBalance();
                        objRepView.SqlStatement = "select tbCreditorStatement.*, Supplier.Supp_Name, Location.Loca_Descrip from tbCreditorStatement inner join Supplier On tbCreditorStatement.Acc_No = Supplier.Supp_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        objRepView.DataSetName = "SupplierStatement";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCreditorBalance CreditorBalance = new rptCreditorBalance();
                        CreditorBalance.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CreditorBalance;
                        break;

                    case 408:   //debtor Balance
                        objSalesInquary.Iid = "CUS";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.CreditorBalance();
                        objRepView.SqlStatement = "select tbCreditorStatement.*, Customer.Cust_Name Supp_Name, Location.Loca_Descrip from tbCreditorStatement inner join Customer On tbCreditorStatement.Acc_No = Customer.Cust_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        objRepView.DataSetName = "SupplierStatement";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDebetorBalance DebtorBalance = new rptDebetorBalance();
                        DebtorBalance.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DebtorBalance;
                        break;

                    case 409:   //Profitable Moving Report
                        objSalesInquary.DateFrom = dtDateFrom.Text;
                        objSalesInquary.DateTo = dtDateTo.Text;
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.ProfitableMovingProduct();
                        if (MessageBox.Show("Do You wan't to Sort By Profit Amount. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            objRepView.SqlStatement = "select tbProfitableMovingProduct.Prod_Code, tbProfitableMovingProduct.Prod_Name, tbProfitableMovingProduct.Purchase_price, tbProfitableMovingProduct.Selling_Price, tbProfitableMovingProduct.Sold_Qty, tbProfitableMovingProduct.Pur_Qty, tbProfitableMovingProduct.Profit_Amount, tbProfitableMovingProduct.Loca, Location.Loca_Descrip, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from tbProfitableMovingProduct INNER JOIN Location On tbProfitableMovingProduct.Loca = Location.Loca order by Profit_Amount desc, Sold_Qty Desc";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select tbProfitableMovingProduct.Prod_Code, tbProfitableMovingProduct.Prod_Name, tbProfitableMovingProduct.Purchase_price, tbProfitableMovingProduct.Selling_Price, tbProfitableMovingProduct.Sold_Qty, tbProfitableMovingProduct.Pur_Qty, tbProfitableMovingProduct.Profit_Amount, tbProfitableMovingProduct.Loca, Location.Loca_Descrip, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from tbProfitableMovingProduct INNER JOIN Location On tbProfitableMovingProduct.Loca = Location.Loca order by Sold_Qty Desc, Profit_Amount desc";
                        }
                        objRepView.DataSetName = "dsProfitableProduct";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProfitableProduct ProfitableProduct = new rptProfitableProduct();
                        ProfitableProduct.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProfitableProduct;
                        break;

                    case 410:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Supplier_Id, Supplier.Supp_Name, product.Reorder_Level, Product.Reorder_Qty, stock_master.Qty from product Inner Join stock_master on product.Prod_Code = stock_master.Prod_Code inner join supplier on product.Supplier_Id = Supplier.Supp_Code where product.Reorder_Level > 0 and product.Reorder_Level > stock_master.Qty And Stock_Master.Loca = '" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsReOrderLevelDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptReOrderLevelReport ReOrderLevel = new rptReOrderLevelReport();
                            ReOrderLevel.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ReOrderLevel;
                            break;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Supplier_Id, Supplier.Supp_Name, product.Reorder_Level, Product.Reorder_Qty, stock_master.Qty from product Inner Join stock_master on product.Prod_Code = stock_master.Prod_Code inner join supplier on product.Supplier_Id = Supplier.Supp_Code where product.Reorder_Level > 0 and product.Reorder_Level > stock_master.Qty And Stock_Master.Loca = '" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsReOrderLevelDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptReOrderLevelReportDesc ReOrderLevelReportDesc = new rptReOrderLevelReportDesc();
                            ReOrderLevelReportDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ReOrderLevelReportDesc;
                            break;
                        }

                    case 411:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Supplier_Id, Supplier.Supp_Name, product.Reorder_Level, Product.Reorder_Qty, stock_master.Qty from product Inner Join stock_master on product.Prod_Code = stock_master.Prod_Code inner join supplier on product.Supplier_Id = Supplier.Supp_Code where product.Reorder_Level > 0 and product.Reorder_Level > stock_master.Qty And product.Supplier_Id = '" + txtCodeFrom.Text.Trim() + "' and  Stock_Master.Loca = '" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsReOrderLevelDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptSupplierReOrderLevelReport SuppReOrderLevel = new rptSupplierReOrderLevelReport();
                            SuppReOrderLevel.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = SuppReOrderLevel;
                            break;
                        }
                        else
                        {
                            objRepView.SqlStatement = "select product.Prod_Code, product.Prod_Name, product.Purchase_price, product.Selling_Price, product.Supplier_Id, Supplier.Supp_Name, product.Reorder_Level, Product.Reorder_Qty, stock_master.Qty from product Inner Join stock_master on product.Prod_Code = stock_master.Prod_Code inner join supplier on product.Supplier_Id = Supplier.Supp_Code where product.Reorder_Level > 0 and product.Reorder_Level > stock_master.Qty And product.Supplier_Id = '" + txtCodeFrom.Text.Trim() + "' and  Stock_Master.Loca = '" + LoginManager.LocaCode + "'";
                            objRepView.DataSetName = "dsReOrderLevelDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            rptSupplierReOrderLevelReportDesc SupplierReOrderLevelReportDesc = new rptSupplierReOrderLevelReportDesc();
                            SupplierReOrderLevelReportDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = SupplierReOrderLevelReportDesc;
                            break;
                        }


                    case 412:

                        objRepView.SqlStatement = "select ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ISNULL(SUM(CASE Iid WHEN '001' THEN ProductSalesSummery.Qty WHEN 'R01' THEN -ProductSalesSummery.Qty END), 0) Qty, Product.Purchase_price, Product.Selling_Price, max(Stock_Master.Qty) Bal_Qty, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, ProductSalesSummery.Loca, Location.Loca_Descrip from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON ProductSalesSummery.Loca = Location.Loca WHERE (CONVERT(DATETIME,ProductSalesSummery.Sales_Date, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "', 103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "', 103)) AND Stock_Master.Loca = '" + LoginManager.LocaCode + "' AND ProductSalesSummery.Loca = '" + LoginManager.LocaCode + "' GROUP BY ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name,Product.Purchase_price, Product.Selling_Price, ProductSalesSummery.Loca, Location.Loca_Descrip";
                        objRepView.DataSetName = "dsProductMoving";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptFastMovingProduct FastMove = new rptFastMovingProduct();
                        FastMove.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = FastMove;
                        break;

                    case 413:

                        objRepView.SqlStatement = "select ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ISNULL(SUM(CASE Iid WHEN '001' THEN ProductSalesSummery.Qty WHEN 'R01' THEN -ProductSalesSummery.Qty END), 0) Qty, Product.Purchase_price, Product.Selling_Price, max(Stock_Master.Qty) Bal_Qty, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, ProductSalesSummery.Loca, Location.Loca_Descrip, Supplier.Supp_Code, Supplier.Supp_Name from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON ProductSalesSummery.Loca = Location.Loca INNER JOIN Supplier ON Product.Supplier_Id=supplier.Supp_Code WHERE (Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND (CONVERT(DATETIME,ProductSalesSummery.Sales_Date, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "', 103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "', 103)) AND Stock_Master.Loca = '" + LoginManager.LocaCode + "' AND ProductSalesSummery.Loca = '" + LoginManager.LocaCode + "' GROUP BY ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name,Product.Purchase_price, Product.Selling_Price, ProductSalesSummery.Loca, Location.Loca_Descrip, Supplier.Supp_Code, Supplier.Supp_Name";
                        objRepView.DataSetName = "dsProductMoving";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSuppFastMovingProduct SuppFastMove = new rptSuppFastMovingProduct();
                        SuppFastMove.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SuppFastMove;
                        break;

                    case 414:
                        //objRepView.SqlStatement = "select Product_Change.Prod_Code, Product_Change.Prod_Name, Product_Change.Barcode, Product_Change.Department_Id, Department.Dept_Name, Product_Change.Category_Id, Category.Cat_Name, Product_Change.Supplier_Id, Supplier.Supp_Name, Product_Change.Manufacturer_Id, manufacturer.Manf_Name, Product_Change.Purchase_price, Product_Change.Selling_Price, Product_Change.Disc_Price, Product_Change.Reorder_Level, Product_Change.Unit, Product_'" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from Product_Change inner join department on Product_Change.Department_Id = Department.Dept_Code Inner join Category on Product_Change.Category_Id = Category.Cat_Code inner join Supplier on Product_Change.Supplier_Id = Supplier.Supp_Code inner join manufacturer on Product',103) and convert(datetime,'',103)";
                        objRepView.SqlStatement = "SELECT PC.Prod_Code, PC.Prod_Name, PC.Barcode, PC.Department_Id, Department.Dept_Name, PC.Category_Id, Category.Cat_Name, PC.Supplier_Id, Supplier.Supp_Name, PC.Manufacturer_Id, PC.Purchase_price, PC.Selling_Price, PC.Disc_Price, PC.Reorder_Level, PC.Unit, PC.Reorder_Qty,PC.Rack_No, PC.Pack_Size, PC.Modified_User, PC.Modified_Date, PC.LockedItem, PC.Short_Description, PC.Whole_Price, PC.Disc_Str, PC.Chg_Iid, PC.Tr_Date, PC.Chg_No, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo FROM Product_Change PC INNER JOIN department ON PC.Department_Id = Department.Dept_Code INNER JOIN Category on PC.Category_Id = Category.Cat_Code INNER JOIN Supplier ON PC.Supplier_Id = Supplier.Supp_Code  WHERE CONVERT(datetime,PC.Modified_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) and CONVERT(DATETIME,'" + dtDateTo.Text + " 23:59:00',103)";
                        objRepView.DataSetName = "dsProductDetails_Change";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductChangeDateReport ProdChangeDate = new rptProductChangeDateReport();
                        ProdChangeDate.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdChangeDate;
                        break;

                    case 415:

                        objRepView.SqlStatement = "select Product_Change.Prod_Code, Product_Change.Prod_Name, Product_Change.Barcode, Product_Change.Department_Id, Department.Dept_Name, Product_Change.Category_Id, Category.Cat_Name, Product_Change.Supplier_Id, Supplier.Supp_Name, Product_Change.Manufacturer_Id, manufacturer.Manf_Name, Product_Change.Purchase_price, Product_Change.Selling_Price, Product_Change.Disc_Price, Product_Change.Reorder_Level, Product_Change.Unit, Product_Change.Reorder_Qty,Product_Change.Rack_No, Product_Change.Pack_Size, Product_Change.Modified_User, Product_Change.Modified_Date, Product_Change.LockedItem, Product_Change.Short_Description, Product_Change.Whole_Price, Product_Change.Disc_Str, Product_Change.Chg_Iid, Product_Change.Tr_Date, Product_Change.Chg_No, '" + txtCodeFrom.Text + "' CodeFrom, '" + txtDescriptionFrom.Text + "' DescriptionFrom from Product_Change inner join department on Product_Change.Department_Id = Department.Dept_Code Inner join Category on Product_Change.Category_Id = Category.Cat_Code inner join Supplier on Product_Change.Supplier_Id = Supplier.Supp_Code inner join manufacturer on Product_Change.Manufacturer_Id = manufacturer.Manf_Code WHERE Product_Change.Prod_Code = '" + txtCodeFrom.Text.Trim() + "'";
                        objRepView.DataSetName = "dsProductDetails_Change";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductChangeProductReport ProdChangeProd = new rptProductChangeProductReport();
                        ProdChangeProd.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdChangeProd;
                        break;

                    case 416:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DateFrom = dtDateFrom.Text;
                        objSalesInquary.DateTo = dtDateTo.Text;
                        objSalesInquary.NonMovingReport();

                        objRepView.SqlStatement = "select Prod_Code, Prod_Name, Purchase_price, Selling_Price, Supplier_Id, Qty, tbNonMovingProduct.Loca, Location.Loca_Descrip, Supplier.Supp_Name, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo from tbNonMovingProduct inner join Location on Location.loca = tbNonMovingProduct.loca inner join supplier on tbNonMovingProduct.Supplier_Id = supplier.supp_code where tbNonMovingProduct.Sold_Qty = 0";
                        objRepView.DataSetName = "dsNonMovingProduct";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptNonMovingProduct NonMove = new rptNonMovingProduct();
                        NonMove.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = NonMove;
                        break;

                    case 417:

                        objRepView.SqlStatement = "select ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name, ISNULL(SUM(CASE Iid WHEN '001' THEN ProductSalesSummery.Qty WHEN 'R01' THEN -ProductSalesSummery.Qty END), 0) Qty, Product.Purchase_price, Product.Selling_Price, (Stock_Master.Qty) Bal_Qty, '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, ProductSalesSummery.Loca, Location.Loca_Descrip from ProductSalesSummery INNER JOIN Product ON ProductSalesSummery.Prod_Code = Product.Prod_Code INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON ProductSalesSummery.Loca = Location.Loca WHERE (CONVERT(DATETIME,ProductSalesSummery.Sales_Date, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "', 103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "', 103)) AND ProductSalesSummery.Loca = '" + LoginManager.LocaCode + "' AND Stock_Master.Loca='" + LoginManager.LocaCode + "' GROUP BY ProductSalesSummery.Prod_Code, ProductSalesSummery.Prod_Name,Product.Purchase_price, Product.Selling_Price, ProductSalesSummery.Loca, Location.Loca_Descrip,Stock_Master.Qty";
                        objRepView.DataSetName = "dsProductMoving";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSlowMovingProduct SlowMove = new rptSlowMovingProduct();
                        SlowMove.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SlowMove;
                        break;

                    case 418:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.CodeTo = txtCodeTo.Text.Trim();
                        objSalesInquary.Iid = "PR";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.PurchaseSalesStock();
                        objRepView.SqlStatement = "SELECT A.Prod_Code, A.Prod_Name, A.Purchase_price, A.Selling_Price, A.Purch_Amount, A.Sel_Amount, A.Pro_Amount, A.Tr_Date, A.Sel_Qty, S.Qty St_Qty, A.Pur_Qty, L.Loca, L.Loca_Descrip, '" + txtCodeFrom.Text + "' CodeFrom, '" + txtCodeTo.Text + "' CodeTo from tbDailyPurSaleProfAnalyse A inner join stock_master S on A.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsPurSalesStock";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductPurSaleStock ProductPurSaleStock = new rptProductPurSaleStock();
                        ProductPurSaleStock.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProductPurSaleStock;
                        break;

                    case 419:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.CodeTo = txtCodeTo.Text.Trim();
                        objSalesInquary.Iid = "DP";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.PurchaseSalesStock();
                        objRepView.SqlStatement = "SELECT A.Prod_Code, A.Prod_Name, A.Purchase_price, A.Selling_Price, A.Purch_Amount, A.Sel_Amount, A.Pro_Amount, A.Tr_Date, A.Sel_Qty, S.Qty St_Qty, A.Pur_Qty, D.Dept_Code, D.Dept_Name, L.Loca, L.Loca_Descrip, '" + txtCodeFrom.Text + "' CodeFrom, '" + txtCodeTo.Text + "' CodeTo from tbDailyPurSaleProfAnalyse A inner join stock_master S on A.Prod_Code = S.Prod_Code INNER JOIN Product P ON A.Prod_Code = P.Prod_Code INNER JOIN Department D ON P.Department_Id = D.Dept_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsPurSalesStock";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDeptPurSaleStock DepartmentPurSaleStock = new rptDeptPurSaleStock();
                        DepartmentPurSaleStock.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DepartmentPurSaleStock;
                        break;

                    case 420:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.CodeTo = txtCodeTo.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text;
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        if (rbByCode.Checked == true)
                        {
                            objSalesInquary.Sort = "C";
                            objSalesInquary.StockGivenDate();
                            //objRepView.SqlStatement = "select S.Prod_Code, S.Prod_Name, S.Curr_Qty, S.Pur_Qty, S.Sale_Qty, S.St_Adj, S.Loca, S.On_Date_Stock, S.Department_Id, L.Loca_Descrip from tbGivenDateStock S INNER JOIN DEPARTMENT D ON S.Department_Id = D.Dept_Code INNER JOIN Location L ON S.Loca = L.Loca";
                            objRepView.DataSetName = "dsGivenDateStock";
                            //objRepView.RetrieveData();
                            dsDataForReport = objSalesInquary.ResultSet;
                            rptProductStockGivenDate ProductStockGivenDate = new rptProductStockGivenDate();
                            ProductStockGivenDate.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductStockGivenDate;
                        }
                        else
                        {
                            objSalesInquary.Sort = "D";
                            objSalesInquary.StockGivenDate();
                            //objRepView.SqlStatement = "select S.Prod_Code, S.Prod_Name, S.Curr_Qty, S.Pur_Qty, S.Sale_Qty, S.St_Adj, S.Loca, S.On_Date_Stock, S.Department_Id, L.Loca_Descrip from tbGivenDateStock S INNER JOIN DEPARTMENT D ON S.Department_Id = D.Dept_Code INNER JOIN Location L ON S.Loca = L.Loca";
                            objRepView.DataSetName = "dsGivenDateStock";
                            //objRepView.RetrieveData();
                            dsDataForReport = objSalesInquary.ResultSet;
                            rptProductStockGivenDateDesc ProductStockGivenDateDesc = new rptProductStockGivenDateDesc();
                            ProductStockGivenDateDesc.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = ProductStockGivenDateDesc;
                        }

                        break;

                    case 421:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.CodeTo = txtCodeTo.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text;
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        if (chkAll.Checked == true)
                        {
                            if (rbByCode.Checked == true)
                            {
                                objSalesInquary.Sort = "C";
                                objSalesInquary.StockGivenDate();
                                dsDataForReport = objSalesInquary.ResultSet;
                                rptProductStockValGivenDate ProductStockValGivenDate = new rptProductStockValGivenDate();
                                ProductStockValGivenDate.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = ProductStockValGivenDate;
                                break;
                            }
                            else
                            {
                                objSalesInquary.Sort = "D";
                                objSalesInquary.StockGivenDate();
                                //objRepView.SqlStatement = "select S.Prod_Code, S.Prod_Name, S.Curr_Qty, S.Pur_Qty, S.Sale_Qty, S.St_Adj, S.Loca, S.On_Date_Stock, S.Department_Id, L.Loca_Descrip, P.Purchase_price, P.Selling_Price, D.Dept_Name from tbGivenDateStock S INNER JOIN DEPARTMENT D ON S.Department_Id = D.Dept_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Product P ON S.Prod_Code = P.Prod_Code";
                                //objRepView.DataSetName = "dsGivenDateStock";
                                //objRepView.RetrieveData();
                                dsDataForReport = objSalesInquary.ResultSet;
                                rptProductStockValGivenDateDesc ProductStockValGivenDateDesc = new rptProductStockValGivenDateDesc();
                                ProductStockValGivenDateDesc.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = ProductStockValGivenDateDesc;
                                break;
                            }
                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objSalesInquary.Sort = "C";
                                objSalesInquary.StockGivenDate();
                                dsDataForReport = objSalesInquary.ResultSet;
                                rptProductStockValGivenDate ProductStockValGivenDate = new rptProductStockValGivenDate();
                                //rptProductStockValGivenDate222 ProductStockValGivenDate = new rptProductStockValGivenDate222();
                                ProductStockValGivenDate.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = ProductStockValGivenDate;
                                break;
                            }
                            else
                            {
                                objSalesInquary.Sort = "D";
                                objSalesInquary.StockGivenDate();
                                //objRepView.SqlStatement = "select S.Prod_Code, S.Prod_Name, S.Curr_Qty, S.Pur_Qty, S.Sale_Qty, S.St_Adj, S.Loca, S.On_Date_Stock, S.Department_Id, L.Loca_Descrip, P.Purchase_price, P.Selling_Price, D.Dept_Name from tbGivenDateStock S INNER JOIN DEPARTMENT D ON S.Department_Id = D.Dept_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Product P ON S.Prod_Code = P.Prod_Code";
                                //objRepView.DataSetName = "dsGivenDateStock";
                                //objRepView.RetrieveData();
                                dsDataForReport = objSalesInquary.ResultSet;
                                rptProductStockValGivenDateDesc ProductStockValGivenDateDesc = new rptProductStockValGivenDateDesc();
                                ProductStockValGivenDateDesc.SetDataSource(dsDataForReport);
                                objRepViewer.crystalReportViewer1.ReportSource = ProductStockValGivenDateDesc;
                                break;
                            }
                        }

                    case 422:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.CodeTo = txtCodeTo.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Iid = "SP";
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.PurchaseSalesStock();
                        objRepView.SqlStatement = "SELECT A.Prod_Code, A.Prod_Name, A.Purchase_price, A.Selling_Price, A.Purch_Amount, A.Sel_Amount, A.Pro_Amount, A.Tr_Date, A.Sel_Qty, S.Qty St_Qty, A.Pur_Qty, D.Supp_Code Dept_Code, D.Supp_Name Dept_Name, L.Loca, L.Loca_Descrip, '" + txtCodeFrom.Text + "' CodeFrom, '" + txtCodeTo.Text + "' CodeTo from tbDailyPurSaleProfAnalyse A inner join stock_master S on A.Prod_Code = S.Prod_Code INNER JOIN Product P ON A.Prod_Code = P.Prod_Code INNER JOIN Supplier D ON P.Supplier_Id = D.Supp_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Loca = '" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsPurSalesStock";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSuppPurSaleStock SupplierPurSaleStock = new rptSuppPurSaleStock();
                        SupplierPurSaleStock.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SupplierPurSaleStock;
                        break;
                    case 423:   //Creditor Statement (GivenDate)
                        objSalesInquary.Iid = "SUP";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text;
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.CreditorStatementGivenDate();
                        objRepView.SqlStatement = "select tbCreditorStatement.*, Supplier.Supp_Name, Location.Loca_Descrip, '" + dtDateFrom.Text + "' DateFrom from tbCreditorStatement inner join Supplier On tbCreditorStatement.Acc_No = Supplier.Supp_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        objRepView.DataSetName = "SupplierStatement";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCreditorStatementGivendate CreditorStatementGivenDate = new rptCreditorStatementGivendate();
                        CreditorStatementGivenDate.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CreditorStatementGivenDate;
                        break;
                    case 424:   //debtor Statement
                        objSalesInquary.Iid = "CUS";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.DateFrom = dtDateFrom.Text;
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DebtorsStatementGivenDate();
                        objRepView.SqlStatement = "select tbCreditorStatement.*, Customer.Cust_Name Supp_Name, Location.Loca_Descrip, '" + dtDateFrom.Text + "' DateFrom from tbCreditorStatement inner join Customer On tbCreditorStatement.Acc_No = Customer.Cust_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        objRepView.DataSetName = "SupplierStatement";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDebetorStatementGivenDate DebtorStatementGivenDate = new rptDebetorStatementGivenDate();
                        DebtorStatementGivenDate.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DebtorStatementGivenDate;
                        break;

                    case 425:   //debtor Balance
                        objSalesInquary.Iid = "CUS";
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.CreditorBalance();
                        objRepView.SqlStatement = "select tbCreditorStatement.*, Customer.Cust_Name Supp_Name, Location.Loca_Descrip from tbCreditorStatement inner join Customer On tbCreditorStatement.Acc_No = Customer.Cust_Code inner join Location on tbCreditorStatement.Loca = Location.Loca WHERE Customer.Iid = 'RGL'";
                        objRepView.DataSetName = "SupplierStatement";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDebetorBalanceRegular DebtorBalanceReg = new rptDebetorBalanceRegular();
                        DebtorBalanceReg.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DebtorBalanceReg;
                        break;
                    case 426:

                        objRepView.SqlStatement = "select Prod_Code, Prod_Name, Pre_Purchase_price, New_Purchase_price, Pre_Selling_Price, New_Selling_Price, Tr_Date, Modified_User FROM ProductPriceChange WHERE CONVERT(DATETIME, Tr_Date, 103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + " 00:00:00', 103) AND CONVERT(DATETIME,'" + dtDateFrom.Text + " 23:59:00', 103)";
                        objRepView.DataSetName = "PriceChange";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPriceChange PriceChange = new rptPriceChange();
                        PriceChange.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = PriceChange;
                        break;

                    case 427:
                        objRepView.SqlStatement = "SELECT C.Cust_Code, C.Cust_Name, C.NIC, DPT.Amount, DPT.Receipt_No, DPT.Unit, DPT.BillDate, '" + txtCodeFrom.Text.Trim() + "' AS [CodeFrom], '" + txtCodeTo.Text.Trim() + "'[CodeTo], '" + LoginManager.LocaCode + ' ' + LoginManager.Location + "' AS [Location], 'Credit Customer Sales Report' AS [Heder] FROM Customer C INNER JOIN DayEnd_Pos_Transaction DPT ON C.Cust_Code = DPT.Customer INNER JOIN Pos_CardTransaction PCT ON PCT.Card_No = DPT.Tr_Type AND PCT.[Description] = DPT.Item_Descrip WHERE DPT.Iid = 'CRD' AND C.Cust_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,ReportDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ORDER BY CONVERT(DATETIME,DPT.BillDate,103) ASC";
                        objRepView.DataSetName = "dsCustomerSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCustometSalesReport CustometSalesReport = new rptCustometSalesReport();
                        CustometSalesReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CustometSalesReport;
                        break;

                    case 428:
                        objRepView.SqlStatement = "SELECT Customer AS [Cust_Code], Amount, Receipt_No, Unit, BillDate, '" + txtCodeFrom.Text.Trim() + "' AS [CodeFrom], '" + txtCodeTo.Text.Trim() + "'[CodeTo], '" + LoginManager.LocaCode + ' ' + LoginManager.Location + "' AS [Location], 'Temporary Customer Sales Report' AS [Heder] FROM DayEnd_Pos_Transaction WHERE DayEnd_Pos_Transaction.Iid='001' AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Customer <> '' AND Customer <> 'DEFAULT'";
                        objRepView.DataSetName = "dsCustomerSales";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCustometSalesReport TempCustometSalesReport = new rptCustometSalesReport();
                        TempCustometSalesReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = TempCustometSalesReport;
                        break;

                    case 429:
                        objRepView.SqlStatement = "EXEC sp_PurchSchedule '" + LoginManager.LocaCode + "','" + txtCodeFrom.Text.Trim() + "','" + dtDateFrom.Text.Trim() + "','" + dtDateTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsPurchSchedule";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPurchSchedule tempPurchSchedule = new rptPurchSchedule();
                        tempPurchSchedule.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = tempPurchSchedule;
                        break;

                    case 430: // Product To be Return details
                        objRepView.SqlStatement = "SELECT T.Doc_No, T.Post_Date, T.Prod_Code, T.Prod_Name, Sum(T.Phy_Qty) Qty, T.Purchase_Price, P.Supplier_Id, S.Supp_Name, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo,'" + dtDateFrom.Text.Trim() + "' DateFrom,'" + dtDateTo.Text.Trim() + "' DateTo, P.Purchased_Date FROM transaction_details T INNER JOIN Product P ON T.Prod_Code = P.Prod_Code INNER JOIN Supplier S ON P.Supplier_Id = S.Supp_Code where (P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND T.Bin_Id = 'F' AND T.Phy_Qty > 0 AND iid = 'TOR' AND CONVERT(DATETIME,T.Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' Group by T.Doc_No, T.Post_Date, T.Prod_Code, T.Prod_Name, T.Purchase_Price,P.Supplier_Id, S.Supp_Name, P.Purchased_Date ORDER BY CONVERT(DATETIME,T.Post_Date,103) DESC";
                        objRepView.DataSetName = "dsProductToBeReturn";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductToBeReturnSupp();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 431: // Location wide Product sales details
                        objRepView.SqlStatement = "SELECT SS.Prod_Code, SS.Prod_Name, SS.Purchase_price, SS.Selling_Price, SS.Loca, ISNULL(SUM(CAST(SS.Qty AS DECIMAL(18,2))),0) [Qty], ISNULL(SUM(CAST(SS.Amount AS DECIMAL(18,2))),0) [Amount], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM (SELECT PSS.Loca, PSS.Prod_Code, P.Prod_Name, P.Purchase_price, P.Selling_Price, ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Qty + PSS.FreeQty WHEN '001' THEN PSS.Qty + PSS.FreeQty WHEN 'R01' THEN -(PSS.Qty + PSS.FreeQty) WHEN 'CUR' THEN -(PSS.Qty + PSS.FreeQty) ELSE 0 END),0) [Qty], ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Amount WHEN '001' THEN PSS.Amount WHEN 'R01' THEN -(PSS.Amount)WHEN 'CUR' THEN -(PSS.Amount) ELSE 0 END),0) [Amount] FROM ProductSalesSummery PSS INNER JOIN Product P ON PSS.Prod_Code = P.Prod_Code WHERE (PSS.Iid = 'INV' OR PSS.Iid = '001' OR PSS.Iid = 'CUR' OR PSS.Iid = 'R01') AND CONVERT(DATETIME,PSS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND PSS.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY PSS.Prod_Code, PSS.Prod_Name, PSS.Iid, PSS.Loca, P.Purchase_price, P.Selling_Price, P.Prod_Name) SS GROUP BY SS.Prod_Code, SS.Prod_Name, SS.Loca, SS.Purchase_price, SS.Selling_Price";
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseProductSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.crystalReportViewer1.DisplayGroupTree = false;
                        break;

                    case 432: // Location wise Department sales details
                        objRepView.SqlStatement = "SELECT DS.Dept_Code [Prod_Code], DS.Dept_Name [Prod_Name], DS.Loca, ISNULL(SUM(CAST(DS.Qty AS DECIMAL(18,2))),0) [Qty], ISNULL(SUM(CAST(DS.Amount AS DECIMAL(18,2))),0) [Amount], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM (SELECT PSS.Loca, D.Dept_Code, D.Dept_Name, ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Qty + PSS.FreeQty WHEN '001' THEN PSS.Qty + PSS.FreeQty WHEN 'R01' THEN -(PSS.Qty + PSS.FreeQty) WHEN 'CUR' THEN -(PSS.Qty + PSS.FreeQty) ELSE 0 END),0) [Qty], ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Amount WHEN '001' THEN PSS.Amount WHEN 'R01' THEN -(PSS.Amount)WHEN 'CUR' THEN -(PSS.Amount) ELSE 0 END),0) [Amount] FROM ProductSalesSummery PSS INNER JOIN Product P ON PSS.Prod_Code = P.Prod_Code INNER JOIN Department D ON D.Dept_Code = P.Department_Id WHERE (PSS.Iid = 'INV' OR PSS.Iid = '001' OR PSS.Iid = 'CUR' OR PSS.Iid = 'R01') AND CONVERT(DATETIME,PSS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND P.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY D.Dept_Code, D.Dept_Name, PSS.Iid, PSS.Loca) DS GROUP BY DS.Dept_Code, DS.Dept_Name, DS.Loca";
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location Wise Department Sales Report";
                        objRepViewer.crystalReportViewer1.DisplayGroupTree = false;
                        break;

                    case 433: // Location wise Category sales details
                        objRepView.SqlStatement = "SELECT DS.Cat_Code [Prod_Code], DS.Cat_Name [Prod_Name], DS.Loca, ISNULL(SUM(CAST(DS.Qty AS DECIMAL(18,2))),0) [Qty], ISNULL(SUM(CAST(DS.Amount AS DECIMAL(18,2))),0) [Amount], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM (SELECT PSS.Loca, C.Cat_Code, C.Cat_Name, ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Qty + PSS.FreeQty WHEN '001' THEN PSS.Qty + PSS.FreeQty WHEN 'R01' THEN -(PSS.Qty + PSS.FreeQty) WHEN 'CUR' THEN -(PSS.Qty + PSS.FreeQty) ELSE 0 END),0) [Qty], ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Amount WHEN '001' THEN PSS.Amount WHEN 'R01' THEN -(PSS.Amount)WHEN 'CUR' THEN -(PSS.Amount) ELSE 0 END),0) [Amount] FROM ProductSalesSummery PSS INNER JOIN Product P ON PSS.Prod_Code = P.Prod_Code INNER JOIN Category C ON C.Cat_Code = P.Category_Id WHERE (PSS.Iid = 'INV' OR PSS.Iid = '001' OR PSS.Iid = 'CUR' OR PSS.Iid = 'R01') AND CONVERT(DATETIME,PSS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND P.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY C.Cat_Code, C.Cat_Name, PSS.Iid, PSS.Loca) DS GROUP BY DS.Cat_Code, DS.Cat_Name, DS.Loca";
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location Wise Category Sales Report";
                        objRepViewer.crystalReportViewer1.DisplayGroupTree = false;
                        break;

                    case 434: // Location wise Supplier sales details
                        objRepView.SqlStatement = "SELECT DS.Supp_Code [Prod_Code], DS.Supp_Name [Prod_Name], DS.Loca, ISNULL(SUM(CAST(DS.Qty AS DECIMAL(18,2))),0) [Qty], ISNULL(SUM(CAST(DS.Amount AS DECIMAL(18,2))),0) [Amount], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM (SELECT PSS.Loca, S.Supp_Code, S.Supp_Name, ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Qty + PSS.FreeQty WHEN '001' THEN PSS.Qty + PSS.FreeQty WHEN 'R01' THEN -(PSS.Qty + PSS.FreeQty) WHEN 'CUR' THEN -(PSS.Qty + PSS.FreeQty) ELSE 0 END),0) [Qty], ISNULL(SUM(CASE PSS.Iid WHEN 'INV' THEN PSS.Amount WHEN '001' THEN PSS.Amount WHEN 'R01' THEN -(PSS.Amount)WHEN 'CUR' THEN -(PSS.Amount) ELSE 0 END),0) [Amount] FROM ProductSalesSummery PSS INNER JOIN Product P ON PSS.Prod_Code = P.Prod_Code INNER JOIN Supplier S ON S.Supp_Code = P.Supplier_Id WHERE (PSS.Iid = 'INV' OR PSS.Iid = '001' OR PSS.Iid = 'CUR' OR PSS.Iid = 'R01') AND CONVERT(DATETIME,PSS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY S.Supp_Code, S.Supp_Name, PSS.Iid, PSS.Loca) DS GROUP BY DS.Supp_Code, DS.Supp_Name, DS.Loca";
                        objRepView.DataSetName = "dsSalesDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location Wise Supplier Sales Report";
                        objRepViewer.crystalReportViewer1.DisplayGroupTree = false;
                        break;

                    case 435: // Supplier wise Location Stock and sales details
                        objRepView.SqlStatement = "SELECT Supplier_Id, Supp_Name, P.Prod_Code, Prod_Name, Purchase_price, Selling_Price, Qty, ISNULL(SoldQty,0) [SoldQty], ISNULL((SELECT TOP 1 Supp_Code + ' - ' + Supp_Name FROM Supplier WHERE Supp_Code = '" + txtCodeFrom.Text.Trim() + "'),'Unknown') [CodeFrom], ISNULL((SELECT TOP 1 Supp_Code + ' - ' + Supp_Name FROM Supplier WHERE Supp_Code = '" + txtCodeTo.Text.Trim() + "'),'Unknown') [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM (SELECT DISTINCT(SM.Prod_Code) [Prod_Code], CAST(SUM(Qty) AS DECIMAL(18,3)) [Qty] FROM Stock_Master SM GROUP BY SM.Prod_Code) ST LEFT OUTER JOIN (SELECT DISTINCT(Prod_Code) [Prod_Code], CAST(SUM(CASE Iid WHEN '001' THEN Qty WHEN 'R01' THEN -Qty ELSE Qty END) AS DECIMAL(18,3)) [SoldQty]  FROM ProductSalesSummery PSS WHERE CONVERT(DATETIME,Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND (Iid = '001' OR Iid = 'R01') GROUP  BY Prod_Code) SA ON ST.Prod_Code = SA.Prod_Code INNER JOIN Product P ON ST.Prod_Code = P.Prod_Code INNER JOIN Supplier S ON P.Supplier_Id = S.Supp_Code WHERE Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        //rptLocationStock_Sales  aa= new rptLocationStock_Sales();
                        objRepViewer.VirtuaReport = new rptLocationStock_Sales();
                        objRepViewer.VirtuaReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.crystalReportViewer1.DisplayGroupTree = true;
                        break;
                    case 436://Location Wise Department Wise Sales Report
                        objRepView.SqlStatement = "SELECT D.Dept_Code + ' - ' + D.Dept_Name [Dept_Code], P.Prod_Code + ' - ' + P.Prod_Name [Prod_Code], PS.Purchase_price, PS.Selling_Price, CASE PS.Iid WHEN 'INV' THEN PS.Qty WHEN '001' THEN PS.Qty WHEN 'CUR' THEN -(PS.Qty) WHEN 'R01' THEN -(PS.Qty) END [Qty], CASE PS.Iid WHEN 'INV' THEN PS.Amount WHEN '001' THEN PS.Amount WHEN 'CUR' THEN -(PS.Amount) WHEN 'R01' THEN -(PS.Amount) END [Amount], 'Location   ' + PS.Loca [Loca], PS.Sales_Date, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Product P INNER JOIN ProductSalesSummery PS ON P.Prod_Code = PS.Prod_Code INNER JOIN Department D ON P.Department_Id=D.Dept_Code WHERE (PS.Iid='001' OR PS.Iid='INV' OR PS.Iid='R01' OR PS.Iid='CUR') AND P.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,PS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)";
                        objRepView.DataSetName = "dsLocaWiseDeptSale";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseDeptWiseSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 437://Location Wise Category Wise Sales Report 
                        objRepView.SqlStatement = "SELECT C.Cat_Code + ' - ' + C.Cat_Name [Cat_Code], P.Prod_Code + ' - ' + P.Prod_Name [Prod_Code], PS.Purchase_price, PS.Selling_Price, CASE PS.Iid WHEN 'INV' THEN PS.Qty WHEN '001' THEN PS.Qty WHEN 'CUR' THEN -(PS.Qty) WHEN 'R01' THEN -(PS.Qty) END [Qty], CASE PS.Iid WHEN 'INV' THEN PS.Amount WHEN '001' THEN PS.Amount WHEN 'CUR' THEN -(PS.Amount) WHEN 'R01' THEN -(PS.Amount) END [Amount], 'Location   ' + PS.Loca [Loca], PS.Sales_Date, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Product P INNER JOIN ProductSalesSummery PS ON P.Prod_Code = PS.Prod_Code INNER JOIN Category C ON P.Category_Id=C.Cat_Code WHERE (PS.Iid='001' OR PS.Iid='INV' OR PS.Iid='R01' OR PS.Iid='CUR') AND P.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,PS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)";
                        objRepView.DataSetName = "dsLocaWiseDeptSale";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseCatWiseSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 438://Location Wise Supplier Wise Sales Report 
                        objRepView.SqlStatement = "SELECT S.Supp_Code + ' - ' + S.Supp_Name [Supp_Code], P.Prod_Code + ' - ' + P.Prod_Name [Prod_Code], PS.Purchase_price, PS.Selling_Price, CASE PS.Iid WHEN 'INV' THEN PS.Qty WHEN '001' THEN PS.Qty WHEN 'CUR' THEN -(PS.Qty) WHEN 'R01' THEN -(PS.Qty) END [Qty], CASE PS.Iid WHEN 'INV' THEN PS.Amount WHEN '001' THEN PS.Amount WHEN 'CUR' THEN -(PS.Amount) WHEN 'R01' THEN -(PS.Amount) END [Amount], 'Location   ' + PS.Loca [Loca], PS.Sales_Date, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Product P INNER JOIN ProductSalesSummery PS ON P.Prod_Code = PS.Prod_Code INNER JOIN Supplier S ON P.Supplier_Id=S.Supp_Code WHERE (PS.Iid='001' OR PS.Iid='INV' OR PS.Iid='R01' OR PS.Iid='CUR') AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,PS.Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)";
                        objRepView.DataSetName = "dsLocaWiseDeptSale";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseSuppWiseSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 439://Free Issued Product Report
                        objRepView.SqlStatement = "SELECT Prod_Code, Prod_Name, Purchase_price, Selling_Price, Sales_Date, FreeQty, '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM ProductSalesSummery WHERE FreeQty <> 0 AND (Iid='INV' OR Iid='001') and CONVERT(DATETIME,Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) and Loca='" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsFreeIssuedProduct";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptFreeIssuedProductReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 440://Location Wise TGN Summary
                        objRepView.SqlStatement = "SELECT To_Loca, To_LocaDesc, Doc_No, Post_Date, Amount, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Transaction_Header WHERE Iid='TGN' AND To_Loca BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)";
                        objRepView.DataSetName = "dsLocaWiseTGNSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocaWiseTGNSummary();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 441://Supplier Wise Return Cheque Details Report
                        objRepView.SqlStatement = "SELECT Supp_Code + ' - ' + Supp_Name [Supplier], Doc_No, Post_Date, Inv_Date [Cheque_Date], Inv_No [Cheque_No], To_LocaDesc [Bank], Code [Branch], Amount, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Transaction_Header INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Iid='PRT' AND Supp_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsReturnCheque";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSuppWiseReturnChqDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 442://Customer Wise Return Cheque Details Report
                        objRepView.SqlStatement = "SELECT Cust_Code + ' - ' + Cust_Name [Customer], Doc_No, Post_Date, Inv_Date [Cheque_Date], Inv_No [Cheque_No], To_LocaDesc [Bank], Code [Branch], Amount, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Transaction_Header INNER JOIN Customer ON Transaction_Header.Supplier_Id = Customer.Cust_Code WHERE Transaction_Header.Iid='RRT' AND Cust_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsReturnCheque";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptCustWiseReturnChqDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 443://Supplier Wise Product Discard Details Report
                        objRepView.SqlStatement = "SELECT Supp_Code + ' - ' + Supp_Name [Supplier], Doc_No, Prod_Code, Prod_Name, Qty, Purchase_Price, Amount, Transaction_Details.Loca + ' - ' + Location.Loca_Descrip [Loca], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Transaction_Details INNER JOIN Supplier ON Transaction_Details.Supplier_Id = Supplier.Supp_Code INNER JOIN Location ON Transaction_Details.Loca = Location.Loca WHERE Iid='PDN' AND Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,Post_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Location.Loca='" + LoginManager.LocaCode + "'";
                        objRepView.DataSetName = "dsProductDiscard";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSuppWiseProdDiscard();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;
                    case 444:
                        objSalesInquary.ExecuteSP("EXEC sp_AllTransDetails @Loca='" + LoginManager.LocaCode + "',@DateFrom='" + dtDateFrom.Text.Trim() + "',@DateTo='" + dtDateTo.Text.Trim() + "'");
                        objRepView.SqlStatement = "SELECT '" + LoginManager.LocaCode + " " + LoginManager.Location + "' Location,'" + dtDateFrom.Text.Trim() + "' DateFrom,'" + dtDateTo.Text.Trim() + "' DateTo,* FROM tb_AllTransDetails ORDER BY TransDate";
                        //objRepView.getHeader(dtDateFrom.Text, dtDateTo.Text);
                        objRepView.Query = "SELECT  ISNULL(SUM(CAmount),0) Cash, ISNULL(SUM(SAmount),0) NetSale, ISNULL(SUM(OAmount),0) Others, Post_Date  FROM tb_SubAllTranse GROUP BY Post_Date";
                        objRepView.strDs = "dsSubAlltran";
                        objRepView.SubRetrieveData();
                        objRepView.DataSetName = "dsAllTransaction";

                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        dsSubReport = objRepView.Ds;
                        objRepViewer.verReport = new rptAllTransaction();

                        objRepViewer.verReport2 = new rptSubAllTran();

                        objRepViewer.verReport.SetDataSource(dsDataForReport);
                        objRepViewer.verReport.OpenSubreport("rptSubAllTran.rpt").SetDataSource(dsSubReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;
                        //objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport2;
                        objRepViewer.verReport.SummaryInfo.ReportTitle = "All Transaction Report";
                        // objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.verReport;
                        break;
                    case 445:
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.CodeTo = txtCodeTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.EntireStock();
                        //objRepView.DataSetName = "dsLocaWiseMonthlySales";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptEntireStockReport EntireStockReport = new rptEntireStockReport();
                        EntireStockReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = EntireStockReport;
                        break;

                    case 446:
                        objRepView.SqlStatement = "SELECT Item_Code, Item_Descrip, SUM(Qty) Qty, Marked_Price, Unit_Price, (Marked_Price-Unit_Price)*sum(Qty) [Discount], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo]  FROM DayEnd_Pos_Transaction WHERE Iid='001'  AND Item_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' AND (Marked_Price-Unit_Price)<>0 Group By Item_Code, Item_Descrip, Marked_Price, Unit_Price";
                        objRepView.DataSetName = "dsProdWiseSpecialDisc";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProdWiseSpecialDiscReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 447:  //Supplier Purchase Schedule
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT PS.Prod_Code, PS.Prod_Name, PS.Purchase_price, PS.Selling_Price, Reorder_Qty, SUM(PS.Qty) [Sold_Qty], SM.Qty [Curr_Qty], SUM(PS.Qty-SM.Qty) [Order_Qty], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtDescriptionFrom.Text.Trim() + "' [Description], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo]  FROM ProductSalesSummery PS LEFT JOIN Stock_Master SM ON PS.Prod_Code = SM.Prod_Code AND PS.Loca = SM.Loca LEFT JOIN Product P ON PS.Prod_Code = P.Prod_Code WHERE (Iid='INV' OR Iid='001') AND Supplier_Id='" + txtCodeFrom.Text.Trim() + "' AND CONVERT(DATETIME,Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND PS.Loca='" + LoginManager.LocaCode + "' GROUP BY PS.Prod_Code, PS.Prod_Name, PS.Purchase_price, PS.Selling_Price, Reorder_Qty, SM.Qty  ORDER BY PS.Prod_Code ";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT PS.Prod_Code, PS.Prod_Name, PS.Purchase_price, PS.Selling_Price, Reorder_Qty, SUM(PS.Qty) [Sold_Qty], SM.Qty [Curr_Qty], SUM(PS.Qty-SM.Qty) [Order_Qty], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtDescriptionFrom.Text.Trim() + "' [Description], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo]  FROM ProductSalesSummery PS LEFT JOIN Stock_Master SM ON PS.Prod_Code = SM.Prod_Code AND PS.Loca = SM.Loca LEFT JOIN Product P ON PS.Prod_Code = P.Prod_Code WHERE (Iid='INV' OR Iid='001') AND Supplier_Id='" + txtCodeFrom.Text.Trim() + "' AND CONVERT(DATETIME,Sales_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND PS.Loca='" + LoginManager.LocaCode + "' GROUP BY PS.Prod_Code, PS.Prod_Name, PS.Purchase_price, PS.Selling_Price, Reorder_Qty, SM.Qty  ORDER BY PS.Prod_Name ";
                        }
                        objRepView.DataSetName = "dsPurchaseSchedule";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSuppPurchSchedule();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 448: //Location Wise Product Report
                        objRepView.SqlStatement = "SELECT Product.Prod_Code + ' - ' + Product.Prod_Name [Prod_Code], Product.Reorder_Qty, Stock_Master.Qty [Curr_Qty], (Reorder_Qty-Qty) [Order_Qty], 'Location  '+ Stock_Master.Loca [Loca] , '" + txtCodeFrom.Text.Trim() + "' [SuppCode], '" + txtDescriptionFrom.Text.Trim() + "' [SuppName], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM Product INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code WHERE Supplier_Id ='" + txtCodeFrom.Text.Trim() + "' ";
                        objRepView.DataSetName = "dsLocaWiseProdOrder";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocaWiseProductOrderReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;


                    case 449: //Purchase Summary Report
                        objRepView.SqlStatement = "SELECT '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo,Post_Date, Supp_Code, Supp_Name, Bill_No, Purr_Date, Bill_Amount, Memo, Document_No FROM tb_Purchase WHERE Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,Purr_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) ";
                        objRepView.DataSetName = "dsPurchase";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptPurchase();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Purchasing Bill Detials Summary";

                        break;

                    case 450: //Purchase Summary Report to be fina
                        objRepView.SqlStatement = "SELECT '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo,Post_Date, Supp_Code, Supp_Name, Bill_No, Purr_Date, Bill_Amount, Memo, Document_No FROM tb_Purchase WHERE Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,Purr_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) AND RCL =0";
                        objRepView.DataSetName = "dsPurchase";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptPurchase();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "To Be Finalized GRN Summary";
                        break;

                    case 451://
                        objRepView.SqlStatement = "SELECT Product.Prod_Code,Product.Prod_Name,ProductSalesSummery.Selling_Price,ISNULL(SUM(ProductSalesSummery.Amount),0) Amount,ISNULL(SUM(ProductSalesSummery.Qty),0) Qty, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo], '" + dtDateFrom.Text.Trim() + "' [DateFrom], '" + dtDateTo.Text.Trim() + "' [DateTo] FROM dbo.ProductSalesSummery INNER JOIN dbo.Product ON dbo.ProductSalesSummery.Prod_Code = dbo.Product.Prod_Code WHERE dbo.Product.Selling_Price > dbo.ProductSalesSummery.Selling_Price AND dbo.ProductSalesSummery.Qty > 2 AND dbo.Product.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND  CONVERT(datetime, Sales_date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND (IId='INV' OR IId='CUR') GROUP BY Product.Prod_Code,Product.Prod_Name,ProductSalesSummery.Selling_Price";
                        objRepView.DataSetName = "dsProductSumDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSepecialPromotionSalesReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "To Be Finalized ProductSumDetails summary";
                        break;

                    case 452://Daily Sales Summary - Collection
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.DailySalesSummaryDetailWise();
                        dsDataForReport = objSalesInquary.ResultSet;

                        if (MessageBox.Show("Do You want to view in  Small Paper", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rptDailySalesSummaryDetailWisepos DailySaleSumDet = new rptDailySalesSummaryDetailWisepos();
                            DailySaleSumDet.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = DailySaleSumDet;
                        }
                        else
                        {
                            rptDailySalesSummaryDetailWise DailySaleSumDet = new rptDailySalesSummaryDetailWise();
                            DailySaleSumDet.SetDataSource(dsDataForReport);
                            objRepViewer.crystalReportViewer1.ReportSource = DailySaleSumDet;
                        }

                        break;

                    case 453://Daily Collection Summary
                        objRepView.SqlStatement = "SELECT '" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo],'" + LoginManager.LocaCode + "' [Loca],'" + LoginManager.Location + "' [Loca_Descrip],(SELECT ISNULL(SUM(Net_Amount),0) [INV_CREDIT] FROM dbo.Transaction_Header WHERE Iid='INV' AND convert(datetime,Post_date,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' AND Pay_Type='CREDIT') [INV_CREDIT],(SELECT ISNULL(SUM(Net_Amount),0) [INV_CASH] FROM dbo.Transaction_Header WHERE Iid='INV' AND convert(datetime,Post_date,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' AND Pay_Type='CASH') [INV_CASH],(SELECT ISNULL(SUM(Amount),0) [PAY_CASH] FROM dbo.tbPaidPaymentSummary WHERE Iid='REC' AND convert(datetime,Post_date,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' AND Payment_Mode='CASH') [PAY_CASH],(SELECT ISNULL(SUM(Amount),0) [PAY_CREDIT] FROM dbo.tbPaidPaymentSummary WHERE Iid='REC' AND convert(datetime,Post_date,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' AND Payment_Mode='CHEQUE') [PAY_CHEQUE],(SELECT ISNULL(SUM(Cash_IN),0) [CASH_IN] FROM tb_CashINOUTDetails WHERE convert(datetime,Postdate,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' ) [CASH_IN],(SELECT ISNULL(SUM(Cash_OUT),0) [CASH_OUT] FROM tb_CashINOUTDetails WHERE convert(datetime,Postdate,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' ) [CASH_OUT], (SELECT ISNULL(SUM(CASE Iid WHEN 'EXP' THEN Transaction_Amount WHEN 'EXR' THEN -Transaction_Amount ELSE 0 END),0) [EXPENSE] FROM Account_TransSummary WHERE Iid IN ('EXR','EXP') AND convert(datetime,Transaction_Date,103) = convert(datetime,'" + dtDateFrom.Text.Trim() + "',103) AND Loca='" + LoginManager.LocaCode + "' ) [EXPENSE]";
                        //objRepView.SqlStatement = "EXEC sp_DailyCollectionSummary 0,'" + LoginManager.LocaCode + "','" + LoginManager.Location + "','" + dtDateFrom.Text.Trim() + "','" + dtDateTo.Text.Trim() + "','" + LoginManager.UserName + "'";
                        objRepView.DataSetName = "dsDailyCollectionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDailyCollectionSummary DailyCollSummary = new rptDailyCollectionSummary();
                        DailyCollSummary.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DailyCollSummary;
                        break;

                    case 454://Cua wise Daily Summary
                        objRepView.SqlStatement = "EXEC [sp_CusWiseDailySales]	@Err_x=0, @DateFrom='" + dtDateFrom.Text + "', @DateTo='" + dtDateTo.Text + "', @Loca='" + LoginManager.LocaCode + "', @CodeFrom='" + txtCodeFrom.Text.Trim() + "', @CodeTo='" + txtCodeTo.Text.Trim() + "' ";
                        objRepView.DataSetName = "dsCusWiseDailySumm";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCusWiseDailyBalance CWDB = new rptCusWiseDailyBalance();
                        CWDB.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CWDB;
                        break;

                    case 455: //Expences Report
                        objRepView.SqlStatement = "";
                        if (MessageBox.Show("Do You Want To Get B/F Balance", "Expences Summary", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            objRepView.SqlStatement = "SELECT '" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,'" + txtCodeFrom.Text + "' Code_From,'" + txtCodeTo.Text + "' Code_To,'B/F Balance' Doc_No,'" + LoginManager.LocaCode + "' Loca,'BFE' Iid,'' VenderCode,ExpenseCode,Expense_Name,'' Bill_No,SUM(CASE Iid WHEN 'EXP' THEN Transaction_Amount WHEN 'EXR' THEN -Transaction_Amount END ) Transaction_Amount,0 Balance_Amount,CONVERT(DATETIME,'" + dtDateFrom.Text + "',103)  Date,'' Remarks,'ONIMTA' UserName FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.ExpenseCode BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND ATS.Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,ATS.Transaction_Date,103) < CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) GROUP BY ExpenseCode,Expense_Name  UNION ALL ";
                            objRepView.SqlStatement = objRepView.SqlStatement + "SELECT '" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,'" + txtCodeFrom.Text + "' Code_From,'" + txtCodeTo.Text + "' Code_To,Doc_No,Loca,Iid,VenderCode,ExpenseCode,Expense_Name,Bill_No,CASE Iid WHEN 'EXP' THEN Transaction_Amount WHEN 'EXR' THEN -Transaction_Amount END Transaction_Amount,Balance_Amount,CONVERT(DATETIME,ATS.Transaction_Date,103) Date,Remarks,UserName FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE TS.Bf='T' AND ATS.ExpenseCode BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND ATS.Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,ATS.Transaction_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)  ";
                        }
                        else
                        {
                            objRepView.SqlStatement = objRepView.SqlStatement + "SELECT '" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,'" + txtCodeFrom.Text + "' Code_From,'" + txtCodeTo.Text + "' Code_To,Doc_No,Loca,Iid,VenderCode,ExpenseCode,Expense_Name,Bill_No,CASE Iid WHEN 'EXP' THEN Transaction_Amount WHEN 'EXR' THEN -Transaction_Amount END Transaction_Amount,Balance_Amount,CONVERT(DATETIME,ATS.Transaction_Date,103) Date,Remarks,UserName FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE TS.Bf='F' AND ATS.ExpenseCode BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND ATS.Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,ATS.Transaction_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103)  ";
                        }
                        objRepView.SqlStatement = objRepView.SqlStatement + "SELECT * FROM CompanyProfile";

                        objRepView.DataSetName = "dsExpenceTransaction";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        dsDataForReport.Tables[1].TableName = "CompanyProfile";
                        objRepViewer.VirtuaReport = new rptExpencesTransaction();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 456:  //Expence Statement

                        //if (MessageBox.Show("Do You Want To Get B/F Balance", "Expences Summary", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        //{
                        //    objRepView.SqlStatement = "SELECT '" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,'" + txtCodeFrom.Text + "' Code_From,'" + txtCodeTo.Text + "' Code_To,'B/F Balance' Doc_No,'" + LoginManager.LocaCode + "' Loca,'BFE' Iid,'' VenderCode,ExpenseCode,Expense_Name,'' Bill_No,SUM(CASE Iid WHEN 'EXP' THEN Transaction_Amount WHEN 'EXR' THEN -Transaction_Amount END ) Transaction_Amount,0 Balance_Amount,'" + dtDateFrom.Text + "' Transaction_Date,'' Remarks,'ONIMTA' UserName FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.ExpenseCode BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND ATS.Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,ATS.Transaction_Date,103) < CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) GROUP BY ExpenseCode,Expense_Name  UNION ALL ";
                        //}

                        objRepView.SqlStatement = "EXEC sp_ExpenceStatement @DateFrom='" + dtDateFrom.Text + "',@DateTo='" + dtDateTo.Text + "',@Loca='" + LoginManager.LocaCode + "',@CodeFrom='" + txtCodeFrom.Text + "',@CodeTo='" + txtCodeTo.Text + "'";
                        //objRepView.SqlStatement + "SELECT '" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,'" + txtCodeFrom.Text + "' Code_From,'" + txtCodeTo.Text + "' Code_To,Doc_No,Loca,Iid,VenderCode,ExpenseCode,Expense_Name,Bill_No,CASE Iid WHEN 'EXP' THEN Transaction_Amount WHEN 'EXR' THEN Transaction_Amount END Transaction_Amount,Balance_Amount,Transaction_Date,Remarks,UserName FROM Account_TransSummary ATS INNER JOIN tb_Expense TS ON TS.Expense_Code=ATS.ExpenseCode WHERE ATS.ExpenseCode BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeFrom.Text + "' AND ATS.Loca='" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,ATS.Transaction_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) Order By CONVERT(DATETIME,ATS.Transaction_Date,103) ";

                        objRepView.DataSetName = "dsExpenceTransaction";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        dsDataForReport.Tables[1].TableName = "CompanyProfile";
                        objRepViewer.VirtuaReport = new rptExpenceStatement();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 457:  //Day Book
                        objRepView.SqlStatement = "EXEC [sp_DayBookForRep]	@Err_x =0, @DateFrom='" + dtDateFrom.Text + "',	@Loca='" + LoginManager.LocaCode + "' ";
                        objRepView.DataSetName = "dsDayBookRep";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptDayBook();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        break;

                    case 458:   //Ledger Book
                        objSalesInquary.CodeFrom = txtCodeFrom.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objSalesInquary.LedgerBook();
                        //objRepView.SqlStatement = "SELECT tbCreditorStatement.*, Customer.Cust_Name Supp_Name, Location.Loca_Descrip from tbCreditorStatement inner join Customer On tbCreditorStatement.Acc_No = Customer.Cust_Code inner join Location on tbCreditorStatement.Loca = Location.Loca";
                        //objRepView.DataSetName = "SupplierStatement";
                        //objRepView.RetrieveData();
                        dsDataForReport = objSalesInquary.ResultSet;
                        rptLedgerBook lb = new rptLedgerBook();
                        lb.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = lb;
                        break;

                    case 459:
                        objSalesInquary.DateFrom = dtDateFrom.Text.Trim();
                        objSalesInquary.DateTo = dtDateTo.Text.Trim();
                        objSalesInquary.Loca = LoginManager.LocaCode;
                        objRepView.SqlStatement = "select '" + dtDateFrom.Text + "' DateFrom, '" + dtDateTo.Text + "' DateTo, '" + LoginManager.LocaCode + " - " + LoginManager.Location + "' Loca, Product.Prod_Code, Product.Prod_Name, BatchNo [Manufacturer_Id], CONVERT(VARCHAR(10),Exp_Date,103) [Manf_Name], tb_Shipment.ShipmentCode [Category_Id], tb_Shipment.ShipmentDescription [Cat_Name], Stock [Qty] from Stock_Master_Batch INNER JOIN Product ON Stock_Master_Batch.Prod_Code=Product.Prod_Code INNER JOIN tb_Shipment ON Stock_Master_Batch.Shipment=tb_Shipment.ShipmentCode where Stock_Master_Batch.Loca='" + LoginManager.LocaCode + "' and (CONVERT(DATETIME,CONVERT(VARCHAR(10),Exp_Date,103),103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) )";
                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptExpireBatchWise EXBW = new rptExpireBatchWise();
                        EXBW.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = EXBW;
                        break;

                    case 460:
                        objRepView.SqlStatement = "EXEC [dbo].[sp_CreditorBalanceLet]  @Err_x = 0,@Loca = N'" + LoginManager.LocaCode + "' ";
                        objRepView.DataSetName = "dsCusAddress";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        dsDataForReport.Tables[1].TableName = "CompanyProfile";

                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\DebtorLetter.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        break;

                    case 461:

                        if (chkAll.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName, Cust_Category,'"+txtCodeFrom.Text+"'[Code_From],'"+txtCodeTo.Text+"'[Code_To] FROM CRM_Customer WHERE (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName, Cust_Category,'"+ txtCodeFrom.Text+"'[Code_From],'" + txtCodeTo.Text + "'[Code_To] FROM CRM_Customer WHERE  (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') AND (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name";

                        }
                        objRepView.DataSetName = "CRM_Customer";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        
                      
                        rptCusDetails Cust = new rptCusDetails();
                        Cust.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = Cust;   
                        break;

                    case 462:
                           Rep.GetStoredProcedure("CRM_sp_CustomerPointStatement", new object[,] { { "@CustCode", "" + txtCodeFrom.Text.Trim().ToString() + "" }, { "@Loca", "" + LoginManager.LocaCode + "" }, { "@Cust_Category","" } }, "Statement");
                           Rep.dataset.Tables[1].TableName = "Company";
                          // report.DisplayReport(new rptCustomerPontStatement(), Rep.dataset, "Customer Point Statement", "");

                           dsDataForReport = Rep.dataset;


                           rptCustomerPontStatement Points = new rptCustomerPontStatement();
                           Points.SetDataSource(dsDataForReport);
                           objRepViewer.crystalReportViewer1.ReportSource = Points; 
                        break;

                    case 463:
                        objRepView.SqlStatement = "SELECT VisibleCode [Voucher_Code], Receipt_No, Issued_Date, Amount, gif_Voucher.Loca,  Location.Loca_Descrip, '" + LoginManager.LocaCode + "' [CodeFrom], '" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo] FROM gif_Voucher INNER JOIN Location ON gif_Voucher.Loca = Location.Loca  WHERE gif_Voucher.Loca = '" +LoginManager.LocaCode+ "'  AND CONVERT(DATETIME,gif_Voucher.Issued_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "' ,103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "' ,103) AND Iid='GV' AND Issued='T' ";
                        objRepView.DataSetName = "dsIssuedVoucher";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptIssuedGiftVoucher IssuedgiftVoucher = new rptIssuedGiftVoucher();
                        IssuedgiftVoucher.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = IssuedgiftVoucher;
                        

                        break;
                    case 464:

                        objRepView.SqlStatement = "SELECT VisibleCode [Voucher_Code],Received_Receipt_No AS Receipt_No,Received_Date,Amount,'" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo]  FROM gif_Voucher WHERE CONVERT( DATETIME,gif_Voucher.Received_Date,103) BETWEEN CONVERT( DATETIME,'" + dtDateFrom.Text.Trim() + "' ,103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "' ,103) AND Iid='GV' AND Raceived='T'";
                        objRepView.DataSetName = "dsReceivedVoucher";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptReceivedGiftVoucherto ReceivedGiftVoucherto = new rptReceivedGiftVoucherto();
                        ReceivedGiftVoucherto.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ReceivedGiftVoucherto;
                     

                        break;

                    case 465:

                        objRepView.SqlStatement = "SELECT VisibleCode [Voucher_Code],Amount, Receipt_No, '" + dtDateFrom.Text.Trim() + "' [Date_From], '" + dtDateTo.Text.Trim() + "' [Date_To] FROM gif_Voucher WHERE gif_Voucher.Issued='T' AND gif_Voucher.Raceived='F' and Loca='"+LoginManager.LocaCode+"'";
                        objRepView.DataSetName = "dsPendingVoucher";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPendingVoucher PendingVoucher = new rptPendingVoucher();
                        PendingVoucher.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = PendingVoucher;
                         

                        break;
                    case 466:

                        objRepView.SqlStatement = "SELECT VisibleCode [Voucher_Code], Receipt_No, Tr_Date [Printed_Date], Amount, BookNo, '" + dtDateFrom.Text.Trim() + "' [DateFrom],'" + dtDateTo.Text.Trim() + "' [DateTo] FROM gif_Voucher WHERE CONVERT( DATETIME,gif_Voucher.Tr_Date,103) BETWEEN CONVERT( DATETIME,'" + dtDateFrom.Text.Trim() + "' ,103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "' ,103) AND gif_Voucher.Iid='GV' AND gif_Voucher.Sale_Pen_Recall='T'";
                        objRepView.DataSetName = "dsPrintedVoucher";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptPrintedGiftVoucher PrintedVoucher = new rptPrintedGiftVoucher();
                        PrintedVoucher.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = PrintedVoucher;

                        break;
                    //Gift Voucer Issued and Received Summery
                    case 467:

                        objRepView.SqlStatement = "SELECT [Item_Code], Item_Descrip, Tr_Type, Iid, Amount, tbx.Receipt_No, [Cashier], tbx.Unit, Dis, ReportDate, [DateFrom], [DateTo] , tbx.Loca , Loca_Descrip, Tr_Date,BillValue  FROM (SELECT Item_Code + dis AS [Item_Code], Item_Descrip, Tr_Type, D.Iid, D.Amount, D.Receipt_No, Billdate,  UserName AS [Cashier], Unit, Dis, ReportDate, '" + dtDateFrom.Text.Trim() + "' AS [DateFrom], '" + dtDateTo.Text.Trim() + "' AS [DateTo] ,D.Loca ,L.Loca_Descrip,G.Tr_Date,ReportId  FROM DayEnd_Pos_Transaction D inner join location L on L.Loca = D.Loca  left join gif_Voucher G on  D.item_Code like G.visibleCode +'%' WHERE CONVERT(DATETIME,ReportDate,103) BETWEEN  CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)     AND (D.Iid = 'G01'  OR Tr_Type = '006'  ) and D.iid <> 'crds'  and D.Loca = '" + LoginManager.LocaCode + "' UNION ALL select GVNumber[item_Code],'Gift Voucher'[Item_Descrip],case Tr_Type when 'SALE' then 'XXXX' when 'REDEEM' then '006' end Tr_Type ,  case Tr_Type when 'SALE' then 'G01' when 'REDEEM' then 'CRD' end Iid ,Amount,Reason as  Receipt_no, Tr_Date,''Cashier,''unit,''Dis,Tr_Date [ReportDate] ,'" + dtDateFrom.Text.Trim() + "' AS [DateFrom], '" + dtDateTo.Text.Trim() + "' AS [DateTo] ,D.Loca ,L.Loca_Descrip,Tr_Date,0 ReportId from gif_GVManualTransaction D  INNER JOIN location L on L.Loca = D.Loca   WHERE iid = 'PT' and L.Loca = '" + LoginManager.LocaCode + "' AND CONVERT(DATETIME,Tr_Date,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) )tbx  LEFT JOIN  (SELECT Loca,Billdate,Unit,ReportId,Receipt_No,SUM(CASE Iid WHEN '001' THEN Amount WHEN '002' THEN Amount WHEN 'R01' THEN Amount WHEN 'R02' THEN Amount WHEN '005' THEN Amount WHEN 'G01' THEN Amount ELSE 0 END) BillValue  FROM Dayend_pos_Transaction  WHERE iid IN ('001','002','R01','R02','G01' )   AND Loca = '" + LoginManager.LocaCode + "' AND ( CONVERT(DATETIME,ReportDate,103) BETWEEN  CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)) GROUP BY Loca,Billdate,Unit,ReportId,Receipt_No)tb3  ON tbx.Loca = tb3.Loca AND tbx.Billdate = tb3.Billdate AND tbx.Unit = tb3.Unit AND tbx.ReportId = tb3.ReportId AND  tbx.Receipt_No = tb3.Receipt_No";
                        objRepView.DataSetName = "DayEnd_Pos_Transaction";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptGiftVoucherIssuedReceivedSummery gftIssuRecSumm = new rptGiftVoucherIssuedReceivedSummery();
                        gftIssuRecSumm.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = gftIssuRecSumm;

                        break;


                }
                objRepViewer.WindowState = FormWindowState.Maximized;
                MainClass.mdi.Cursor = Cursors.Default;
                objRepViewer.Refresh();
                objRepViewer.Show();

                try
                {
                    dsDataForReport.Dispose();
                    dsDataForReport = null;


                    objRepView.TempResultSet.Dispose();
                    objRepView.TempResultSet = null;
                }
                catch (Exception)
                {
                    
                    
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MainClass.mdi.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


            }

        }
        clsSMS2 Rep = new clsSMS2();
        clsReport report = new clsReport();
        private void frmSalesInquary_Load(object sender, EventArgs e)
        {
            try
            {
                switch (intRepOption)
                {
                    case 445:
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;
                    case 100:
                    case 101:
                    case 102:
                    case 103:
                    case 104:  
                    case 119:
                    case 200:
                    case 201:
                    case 202:
                    case 203:
                    case 117:
                    case 300:
                   
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        chkAll.Visible = true;
                        break;
                    case 461:

                        dtDateFrom.Enabled = dtDateTo.Enabled = false;
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        chkAll.Visible = true;
                        break;
                    case 431:
                    case 432:
                    case 433:
                    case 434:
                    case 435:
                    case 436:
                    case 437:
                    case 438:
                    
                        chkAll.Visible = true;
                        break;

                    case 105:
                    case 449:
                    case 450:
                    case 463:
                    case 464:
                    case 465:
                    case 466:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;
                    case 462:
                       
                        txtCodeTo.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = dtDateTo.Enabled = chkAll.Enabled = false;
                        break;

                    case 459:
                    case 428:
                    case 106:
                    case 452://Daily Sales Summary - Collection
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;
                    case 108:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;
                    case 109:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        
                        break;
                    case 110:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;
                    case 111:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;
                    case 112:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;
                    case 113:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;
                    case 114:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;
                    case 115:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;
                    case 116:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 118:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 205:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 305:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;
                    case 306:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 307:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 308:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 309:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 400:
                    case 429:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 456:
                    case 401:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        break;


                    case 402:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 403:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 404:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;

                    case 405:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;

                    case 458:   //Ledger Book
                    case 406:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;

                    case 407:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;

                    case 408:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;
                    case 409:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 410:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        break;

                    case 411:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        break;

                    case 412:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 413:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 414://Product Details changed date wise
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 415://Product Details changed Product wise
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;


                    case 416:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 417:
                    case 444:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;

                    case 418:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;

                    case 419:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;

                    case 420:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Text = "01/01/2000";
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = true;
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        chkAll.Visible = true;
                        break;

                    case 421:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Text = "01/01/2000";
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = true;
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        rbByCode.Checked = true;
                        chkAll.Visible = true;                        
                        break;

                    case 422:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = true;
                        break;
                    case 423:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = false;
                        break;
                    case 424:
                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = false;
                        break;
                    case 425:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        break;
                    case 426:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = false;
                        break;
                    case 439:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        break;

                    case 447:
                        txtCodeTo.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        lblCodeFrom.Text = "Supplier";
                        rbByCode.Visible = true;
                        rbByDesc.Visible = true;
                        break;

                    case 448:
                        txtCodeTo.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        lblCodeFrom.Text = "Supplier";
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        
                        break;

                    case 457:
                    case 453:
                        txtCodeFrom.Enabled = false;
                        txtCodeTo.Enabled = false;
                        txtDescriptionFrom.Enabled = false;
                        txtDescriptionTo.Enabled = false;
                        btnSearchCodeFrom.Enabled = false;
                        btnSearchCodeTo.Enabled = false;
                        dtDateFrom.Enabled = true;
                        dtDateTo.Enabled = false;
                        break;
                    case 460:

                        txtCodeFrom.Enabled = true;
                        txtCodeTo.Enabled = true;
                        txtDescriptionFrom.Enabled = true;
                        txtDescriptionTo.Enabled = true;
                        btnSearchCodeFrom.Enabled = true;
                        btnSearchCodeTo.Enabled = true;
                        dtDateFrom.Enabled = false;
                        dtDateTo.Enabled = false;
                        chkAll.Visible = true;
                        chkAll.Checked = true;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmSalesInquary_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 010.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            txtCodeFrom.Text = string.Empty;
            txtDescriptionFrom.Text = string.Empty;
            txtCodeTo.Text = string.Empty;
            txtDescriptionTo.Text = string.Empty;
            txtCodeFrom.Focus();

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAll.Checked == true)
                {
                    txtCodeFrom.Text = "0";
                    txtCodeTo.Text = "Z";
                    txtDescriptionFrom.Text = "";
                    txtDescriptionTo.Text = "";
                }
                else
                {
                    txtCodeFrom.Text = "";
                    txtCodeTo.Text = "";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesInquary 010.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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