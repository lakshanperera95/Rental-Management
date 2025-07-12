using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;

namespace Inventory
{
    public partial class frmCustomerVisiting : Form
    {
        public frmCustomerVisiting()
        {
            InitializeComponent();
        }
        public int ReportNumber = 0;
        clsReport report = new clsReport();
        clsMainClass Rep = new clsMainClass();
        frmSearch search = new frmSearch();
         clsMainClass Main = new clsLibrary.clsMainClass();
       
        private static frmCustomerVisiting _CustomerVisiting;

        public static frmCustomerVisiting GetCustomerVisiting
        {
            get { return _CustomerVisiting; }
            set { _CustomerVisiting = value; }
        }

       
        private void frmCustomerVisiting_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _CustomerVisiting = null;
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtCustCodeFrom.Text = "";
                txtCustCodeTo.Text = "";
                txtCustNameFrom.Text = "";
                txtCustNameTo.Text = "";
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void txtCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string SqlStatement = "SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE Cus_Code='" + txtCustCodeFrom.Text.Trim() + "'";
                    Rep.getDataReader(SqlStatement);
                    if (Rep.Reader.Read())
                    {
                        txtCustNameFrom.Text = Rep.Reader["Cus_Name"].ToString();
                    }
                    txtCustNameFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());             
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = cmbCategory.Text.Trim();
                if (cmbCategory.Text.Trim() == "All")
                {
                    Category = "";
                }

                if (rbCustomerVisiting.Checked==true)
                {
                    if (chkAllLoca.Checked)
                    {
                        if (chkAll.Checked)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], COUNT(Cus_Code) [No_of_Visits], SUM(ActualBillAmt) [Amount], Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],Location.Loca_Descrip as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code INNER JOIN Location ON Location.Loca = CRM_Customer.Loca WHERE CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND Cust_Category LIKE '%"+Category+"%' GROUP BY Cus_Code, Cus_Name,Mobile, PhoneNo, Location.Loca_Descrip,Card_No ORDER BY COUNT(Cus_Code) DESC", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerVisiting(), Rep.dataset, "Location Wise Customer Visiting", "Location Wise Customer Visiting Report");
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], COUNT(Cus_Code) [No_of_Visits], SUM(ActualBillAmt) [Amount], Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],Location.Loca_Descrip as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code INNER JOIN Location ON Location.Loca = CRM_Customer.Loca WHERE Cus_Code BETWEEN '" + txtCustCodeFrom.Text.Trim() + "' AND '" + txtCustCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND Cust_Category LIKE '%" + Category + "%'  GROUP BY Cus_Code, Cus_Name,Mobile, PhoneNo,Location.Loca_Descrip,Card_No ORDER BY COUNT(Cus_Code) DESC", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerVisiting(), Rep.dataset, "Location Wise Customer Visiting", "Location Wise Customer Visiting Report");
                        }
                    }
                    else
                    {
                        if (chkAll.Checked)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], COUNT(Cus_Code) [No_of_Visits], SUM(ActualBillAmt) [Amount], Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],'" + txtLocaName.Text.Trim() + "' as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code WHERE CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND (CRM_Customer.Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%'  GROUP BY Cus_Code, Cus_Name,Mobile, PhoneNo,Card_No ORDER BY COUNT(Cus_Code) DESC", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerVisiting(), Rep.dataset, "Customer Visiting", "Customer Visiting Report");
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], COUNT(Cus_Code) [No_of_Visits], SUM(ActualBillAmt) [Amount], Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],'" + txtLocaName.Text.Trim() + "' as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code WHERE Cus_Code BETWEEN '" + txtCustCodeFrom.Text.Trim() + "' AND '" + txtCustCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND (CRM_Customer.Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%'  GROUP BY Cus_Code, Cus_Name,Mobile, PhoneNo,Card_No ORDER BY COUNT(Cus_Code) DESC", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerVisiting(), Rep.dataset, "Customer Visiting", "Customer Visiting Report");
                        }
                    }
                }
                else if (rbCustomerWise.Checked == true)
                {
                    if (chkAllLoca.Checked)
                    {
                        if (chkAll.Checked)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], ActualBillAmt [Amount], BillDate, BillTime, Points, Readeem, Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],'" + txtLocaName.Text.Trim() + "' as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code WHERE CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND Cust_Category LIKE '%" + Category + "%' GROUP BY Cus_Code, Cus_Name, ActualBillAmt, BillDate, BillTime, Points, Readeem, Mobile, PhoneNo,Card_No  ORDER BY CONVERT(DATETIME,BillDate,103)", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerWiseDateWiseVisitingReport(), Rep.dataset, "Location Wise Customer Wise Date Wise Visiting Report", "Location Wise Customer Wise Date Wise Visiting Report");
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], ActualBillAmt [Amount], BillDate, BillTime, Points, Readeem, Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],Location.Loca_Descrip as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code INNER JOIN Location ON Location.Loca = CRM_Customer.Loca WHERE Cus_Code = '" + txtCustCodeFrom.Text.Trim() + "'  AND CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND Cust_Category LIKE '%" + Category + "%' GROUP BY Cus_Code, Cus_Name, ActualBillAmt, BillDate, BillTime, Points, Readeem, Mobile, PhoneNo, Location.Loca_Descrip,Card_No  ORDER BY CONVERT(DATETIME,BillDate,103)", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerWiseDateWiseVisitingReport(), Rep.dataset, "Location Wise Customer Wise Date Wise Visiting Report", "Location Wise Customer Wise Date Wise Visiting Report");
                        }
                    }
                    else
                    {
                        if (chkAll.Checked)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], ActualBillAmt [Amount], BillDate, BillTime, Points, Readeem, Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],'" + txtLocaName.Text.Trim() + "' as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code WHERE CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND (CRM_Customer.Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' GROUP BY Cus_Code, Cus_Name, ActualBillAmt, BillDate, BillTime, Points, Readeem, Mobile, PhoneNo,Card_No  ORDER BY CONVERT(DATETIME,BillDate,103)", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerWiseDateWiseVisitingReport(), Rep.dataset, "Customer Wise Date Wise Visiting Report", "Customer Wise Date Wise Visiting Report");
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code [Cust_Code], Cus_Name [Cust_Name], ActualBillAmt [Amount], BillDate, BillTime, Points, Readeem, Mobile, PhoneNo, '" + dtpDateFrom.Text.Trim() + "' [DateFrom], '" + dtpDateTo.Text.Trim() + "' [DateTo],'" + txtLocaName.Text.Trim() + "' as LocaName,Card_No FROM dbo.CRM_Customer INNER JOIN dbo.Pos_CustomerPoints ON dbo.CRM_Customer.Cus_Code = dbo.Pos_CustomerPoints.Cust_Code WHERE Cus_Code = '" + txtCustCodeFrom.Text.Trim() + "'  AND CONVERT(DATETIME,BillDate,103) BETWEEN  CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103)  AND  CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103) AND (CRM_Customer.Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category = '"+cmbCategory.Text.Trim()+ "' AND Cust_Category LIKE '%" + Category + "%' GROUP BY Cus_Code, Cus_Name, ActualBillAmt, BillDate, BillTime, Points, Readeem, Mobile, PhoneNo,Card_No  ORDER BY CONVERT(DATETIME,BillDate,103)", "dsCustomerVisiting");
                            report.DisplayReport(new CRMReports.rptCustomerWiseDateWiseVisitingReport(), Rep.dataset, "Customer Wise Date Wise Visiting Report", "Customer Wise Date Wise Visiting Report");
                        }
                    }
                }              
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());              
            }
        }

        private void btnCustSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = cmbCategory.Text.Trim();
                if(Category=="All")
                {
                    Category = "";
                }            
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtCustCodeFrom.Text != string.Empty && txtCustNameFrom.Text == string.Empty)
                {
                    Sqlst="SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE (Cus_Code LIKE '%" + txtCustCodeFrom.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' ORDER BY Cus_Code";
                }
                else if (txtCustCodeFrom.Text == string.Empty && txtCustNameFrom.Text != string.Empty)
                {
                    Sqlst="SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustNameFrom.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' ORDER BY Cus_Code";
                }
                else
                {
                    Sqlst="SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' ORDER BY Cus_Code";
                }
                ObjCom.SqlStatement = Sqlst;
                ObjCom.GetDs();
                search.dgSearch.DataSource = ObjCom.Ads.Tables[0];
                search.Show();

                search.prop_Focus = txtCustCodeFrom;
                search.Cont_Descript = txtCustNameFrom;
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void btnCustSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = cmbCategory.Text.Trim();
                if (Category == "All")
                {
                    Category = "";
                }

                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtCustCodeTo.Text != string.Empty && txtCustNameTo.Text == string.Empty)
                {
                    Sqlst="SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE (Cus_Code='" + txtCustCodeTo.Text.Trim() + "') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' ORDER BY Cus_Code";
                }
                else if (txtCustCodeTo.Text == string.Empty && txtCustNameTo.Text != string.Empty)
                {
                   Sqlst="SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE (Cus_Name='" + txtCustNameTo.Text.Trim() + "') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' ORDER BY Cus_Code";
                }
                else
                {
                    Sqlst="SELECT Cus_Code, Cus_Name FROM CRM_Customer WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') AND Cust_Category LIKE '%" + Category + "%' ORDER BY Cus_Code";
                }
                ObjCom.SqlStatement = Sqlst;
                ObjCom.GetDs();
                search.dgSearch.DataSource = ObjCom.Ads.Tables[0];
                search.Show();

                search.prop_Focus = txtCustCodeTo;
                search.Cont_Descript = txtCustNameTo;
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void LoadCustomerCategory()
        {
            DataSet dsCustCat = Rep.getDataSet("SELECT Category FROM CRM_CustCategory");
            dsCustCat.Tables[0].Rows.Add("All");
            cmbCategory.DataSource = dsCustCat.Tables[0];
            cmbCategory.DisplayMember = "Category";

            //cmbCategory.Items.Add("All");
        }

        private void frmCustomerVisiting_Load(object sender, EventArgs e)
        {
            try
            {
                switch (ReportNumber)
                {
                    case 1:
                        label31.Visible = true; txtLocaCode.Visible = true; txtLocaName.Visible = true; btnLocaSearch.Visible = true;
                        rbCustomerVisiting.Checked = false;
                        rbCustomerWise.Checked = false;
                        lblCodeFrom.Enabled = false;
                        lblCodeTo.Enabled = false;
                        txtCustCodeFrom.Enabled = false;
                        txtCustNameFrom.Enabled = false;
                        txtCustCodeTo.Enabled = false;
                        txtCustNameTo.Enabled = false;
                        btnCustSearch1.Enabled = false;
                        btnCustSearch2.Enabled = false;
                        lblDateFrom.Enabled = false;
                        lblDateTo.Enabled = false;
                        dtpDateFrom.Enabled = false;
                        dtpDateTo.Enabled = false;

                        chkAllLoca.Visible = true; chkAll.Visible = true;
                        break;
                    case 2:
                        label31.Visible = true; txtLocaCode.Visible = true; txtLocaName.Visible = true; btnLocaSearch.Visible = true;
                        rbCustomerVisiting.Checked = false;
                        rbCustomerWise.Checked = false;
                        lblCodeFrom.Enabled = false;
                        lblCodeTo.Enabled = false;
                        txtCustCodeFrom.Enabled = false;
                        txtCustNameFrom.Enabled = false;
                        txtCustCodeTo.Enabled = false;
                        txtCustNameTo.Enabled = false;
                        btnCustSearch1.Enabled = false;
                        btnCustSearch2.Enabled = false;
                        lblDateFrom.Enabled = false;
                        lblDateTo.Enabled = false;
                        dtpDateFrom.Enabled = false;
                        dtpDateTo.Enabled = false;
                        lblCategory.Visible = true;
                        cmbCategory.Visible = true;
                        LoadCustomerCategory();

                        chkAllLoca.Visible = true; chkAll.Visible = false;
                    break;



                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void rbCustomerVisiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCustomerVisiting.Checked==true)
                {
                    lblCodeFrom.Enabled = true;
                    
                    txtCustCodeFrom.Enabled = true;
                    txtCustNameFrom.Enabled = true;
                    lblDateFrom.Enabled = true;
                    lblDateTo.Enabled = true;
                    dtpDateFrom.Enabled = true;
                    dtpDateTo.Enabled = true;
                    lblCodeTo.Enabled = true;
                    txtCustCodeTo.Enabled = true;
                    txtCustNameTo.Enabled = true;
                    btnCustSearch1.Enabled = true;
                    btnCustSearch2.Enabled = true;

                    lblCodeTo.Visible = true;
                    txtCustCodeTo.Visible = true;
                    txtCustNameTo.Visible = true;
                    btnCustSearch2.Visible = true;

                    lblCodeFrom.Text = "Code From";

                    txtCustCodeFrom.Text = "";
                    txtCustNameFrom.Text = "";
                    txtCustCodeTo.Text = "";
                    txtCustNameTo.Text = "";

                }

              
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }

        }

        private void rbCustomerWise_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCustomerWise.Checked == true)
                {
                    lblCodeFrom.Enabled = true;
                    txtCustCodeFrom.Enabled = true;
                    txtCustNameFrom.Enabled = true;
                    btnCustSearch1.Enabled = true;
                    lblDateFrom.Enabled = true;
                    lblDateTo.Enabled = true;
                    dtpDateFrom.Enabled = true;
                    dtpDateTo.Enabled = true;

                    lblCodeTo.Visible = false;
                    txtCustCodeTo.Visible = false;
                    txtCustNameTo.Visible = false;
                    btnCustSearch2.Visible = false;

                    txtCustCodeFrom.Text = "";
                    txtCustNameFrom.Text = "";
                    

                    lblCodeFrom.Text = "Customer";
                }
                
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
               
            }
        }

        private void txtCustCodeTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string SqlStatement = "SELECT Cus_Code, Cus_Name FROM CRM_Customer FROM CRM_Customer WHERE Cus_Code='" + txtCustCodeTo.Text.Trim() + "'";
                    Rep.getDataReader(SqlStatement);
                    if (Rep.Reader.Read())
                    {
                        txtCustNameTo.Text = Rep.Reader["Cus_Name"].ToString();
                    }
                    txtCustNameTo.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void txtCustNameTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpDateFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                 
            }
        }

        private void dtpDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpDateTo.Focus();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void dtpDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnDisplay.PerformClick();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                 
            }
        }
        string Sqlst = "";
        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                txtCustCodeFrom.Text = ""; txtCustNameFrom.Text = "";
                txtCustCodeTo.Text = ""; txtCustNameTo.Text = "";

                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtLocaCode.Text.Trim() != string.Empty && txtLocaName.Text.Trim() == string.Empty)
                {
                      Sqlst="SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca LIKE '%" + txtLocaCode.Text.Trim() + "%' ORDER BY Loca";
                }
                else if (txtLocaCode.Text.Trim() == string.Empty && txtLocaName.Text.Trim() != string.Empty)
                {
                      Sqlst="SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca_Descrip LIKE '%" + txtLocaName.Text.Trim() + "%' ORDER BY Loca";
                }
                else
                {
                       Sqlst="SELECT Loca [Code], Loca_Descrip [Location] FROM Location ORDER BY Loca";
                }


                ObjCom.SqlStatement = Sqlst;
                ObjCom.GetDs();
                search.dgSearch.DataSource = ObjCom.Ads.Tables[0];
                search.Show();

                search.prop_Focus = txtLocaCode;
                search.Cont_Descript = txtLocaName;

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        clsCommon ObjCom = new clsCommon();
        private void chkAllLoca_CheckedChanged(object sender, EventArgs e)
        {
            txtLocaCode.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
            txtLocaName.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
            btnLocaSearch.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            txtCustCodeFrom.Enabled = !Convert.ToBoolean(chkAll.Checked);
            txtCustCodeTo.Enabled = !Convert.ToBoolean(chkAll.Checked);
            txtCustNameFrom.Enabled = !Convert.ToBoolean(chkAll.Checked);
            txtCustNameTo.Enabled = !Convert.ToBoolean(chkAll.Checked);

            btnCustSearch1.Enabled = !Convert.ToBoolean(chkAll.Checked);
            btnCustSearch2.Enabled = !Convert.ToBoolean(chkAll.Checked);
        }
    }
}