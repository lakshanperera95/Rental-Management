using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web.UI;
using System.IO;
using clsLibrary;
 
using Inventory.CRMReports;
 
namespace Inventory
{
    public partial class frmCustomReport : Form
    {
        public frmCustomReport()
        {
            InitializeComponent();
        } 

        public int ReportNumber = 0;
        clsMainClass Rep = new clsMainClass();
        clsReport report = new clsReport();
        string Range;

        frmCustomerSearch search = new frmCustomerSearch();
        clsLibrary.clsMainClass Main = new clsLibrary.clsMainClass();

        private static frmCustomReport _CustomReport;

        public static frmCustomReport GetCustomReport
        {
            get { return _CustomReport; }
            set { _CustomReport = value;}
        }

        private void btnMoreInquire_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnMoreInquire.Text == "&More Inquire >>")
                {
                    this.Size = new Size(658, 428);
                    btnMoreInquire.Text = "&Less Inquire <<";
                    raiAll.Visible = raiCustomerType.Visible = cmbCustomerType.Visible = cmbPoints.Visible= true;
                    groupBox1.Enabled = false;

                    cmbCustomerType.Enabled = false;
                    Rep.dataset = Rep.getDataSet("SELECT Type FROM CRM_CustomerType", "T");
                    cmbCustomerType.Items.Clear();
                    foreach (DataRow row in Rep.dataset.Tables[0].Rows)
                    {
                        cmbCustomerType.Items.Add(row["Type"].ToString());
                    }

                    //add locations
                    DataSet loca = new DataSet();
                    loca = Rep.getDataSet("SELECT Loca_Descrip FROM Location", "Location");
                    cmbLoca.Items.Clear();
                    foreach (DataRow row in loca.Tables[0].Rows)
                    {
                        cmbLoca.Items.Add(row["Loca_Descrip"].ToString());
                    }




                }
                else if (btnMoreInquire.Text == "&Less Inquire <<")
                {
                    this.Size = new Size(658, 173);
                    btnMoreInquire.Text = "&More Inquire >>";
                    raiAll.Checked = raiCustomerType.Checked = false;
                    raiAll.Visible = raiCustomerType.Visible = cmbCustomerType.Visible = cmbPoints.Visible = false;
                    groupBox1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmCustomReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _CustomReport = null;
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void raiCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerType.Enabled = raiCustomerType.Checked;
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Rep.dataset = Rep.getDataSet("SELECT 1 [Fitting], C.Cus_Code [Customer], C.Cus_Name [WorkshopName], C.Loca [Loca] FROM CRM_Customer C INNER JOIN CRM_CustomerType CT ON C.Cus_Type = CT.Type WHERE C.Cus_Type = '" + cmbCustomerType.Text.Trim() + "'", "DailyDetails");
                dgSelectedCusDetails.DataSource = Rep.dataset.Tables["DailyDetails"];
                dgSelectedCusDetails.Refresh();
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCusSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmCustomerSearch();
                }

                string Category = "";

                switch (ReportNumber)
                {
                    case 12:
                        if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT DISTINCT Cust_Category [Code], Cust_Category [Description] FROM CRM_Customer WHERE (Cust_Category <> '')");
                        }
                        else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT DISTINCT Cust_Category [Code], Cust_Category [Description] FROM CRM_Customer WHERE (Cust_Category <> '')");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT DISTINCT Cust_Category [Code], Cust_Category [Description] FROM CRM_Customer WHERE (Cust_Category <> '')");
                        }
                        break;

                    case 14:
                       
                            if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("select Cus_Code,Cus_Name from CRM_Customer/* where Cus_Type = '" + cmbCategory.Text.Trim() + "'*/");
                            }
                            else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("select Cus_Code,Cus_Name from CRM_Customer /*where Cus_Type = '" + cmbCategory.Text.Trim() + "'*/");
                            }
                            else
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("select Cus_Code,Cus_Name from CRM_Customer /*where Cus_Type = '" + cmbCategory.Text.Trim() + "'*/");
                            }
                                                
                        break;

                    case 5:
                    case 40:
                        if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') and Inactive=1 ORDER BY Cus_Code");
                        }
                        else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') and Inactive=1 ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer where Inactive=1/*WHERE (Cust_Category = 'Loyalty customer')*/ ORDER BY Cus_Code");
                        }
                        break;

                    case 3:
                    case 10:
                        Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Card_No [Card Number], NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/ AND " + Category + " ORDER BY Cus_Code");
                        }
                        else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Card_No [Card Number], NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') /*AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/ AND "+Category+" ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Card_No [Card Number], NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE " + Category+" ORDER BY Cus_Code");
                        }
                        break;

                    
                    case 4:
                        Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) AND (Loca = '" + clsMainClass.LoginLocaCode.ToString() + "') AND " + Category + " ORDER BY Cus_Code");
                        }
                        else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') AND (Loca = '" + clsMainClass.LoginLocaCode.ToString() + "') AND " + Category + " ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE " + Category + " AND (Loca = '" + clsMainClass.LoginLocaCode.ToString() + "') ORDER BY Cus_Code");
                        }
                        break;


                    case 6:
                        if (chkAllLoca.Checked)// all loca
                        {
                            if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                            }
                            else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Name");
                            }
                            else
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer /*WHERE (Cust_Category = 'Loyalty customer')*/ ORDER BY Cus_Code");
                            }
                        }
                        else
                        {
                            if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                            }
                            else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Name");
                            }
                            else
                            {
                                clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                            }
                        }
                        break;

                    case 11:
                    case 16:
                        Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile,Card_No FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') AND " + Category + " ORDER BY Cus_Code");
                        }
                        else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile,Card_No FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') AND " + Category + " ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile,Card_No FROM CRM_Customer WHERE " + Category + " AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                        }
                        break;

                    default:
                        if (txtCustomerID.Text.Trim() != string.Empty && txtCustomerName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile,Card_No FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCustomerID.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCustomerID.Text.Trim() + "%')) AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') AND (Cust_Category = 'Loyalty customer') ORDER BY Cus_Code");
                        }
                        else if (txtCustomerID.Text.Trim() == string.Empty && txtCustomerName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile,Card_No FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCustomerName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')  AND (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile,Card_No FROM CRM_Customer WHERE (Cust_Category = 'Loyalty customer') ORDER BY Cus_Code");
                        }
                        break;
                }


                search.ShowDialog();
                if (clsMainClass.Cnt_Focus != null)
                {
                    txtCustomerID.Text = clsMainClass.Cnt_Focus.ToString();
                    txtCustomerName.Text = clsMainClass.Cnt_Descrip.ToString();
                    clsMainClass.Cnt_Focus = null;
                    clsMainClass.Cnt_Descrip = null;
                }
                txtCustomerID.Focus();


            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    btnCusSearch.PerformClick();
                }
                catch (Exception ex)
                {
                    clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
            }
        }

        private void raiAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllLoca.Checked)
                {
                    if (raiAll.Checked)
                    {
                        Rep.dataset = Rep.getDataSet("SELECT 1 [Fitting], C.Cus_Code [Customer], C.Cus_Name [WorkshopName], C.Loca [Loca] FROM CRM_Customer C INNER JOIN CRM_CustomerType CT ON C.Cus_Type = CT.Type", "DailyDetails");
                        dgSelectedCusDetails.DataSource = Rep.dataset.Tables["DailyDetails"];
                        dgSelectedCusDetails.Refresh();
                    }
                }
                else
                {
                    if (raiAll.Checked)
                    {
                        Rep.dataset = Rep.getDataSet("SELECT 1 [Fitting], C.Cus_Code [Customer], C.Cus_Name [WorkshopName], C.Loca [Loca] FROM CRM_Customer C INNER JOIN CRM_CustomerType CT ON C.Cus_Type = CT.Type WHERE (C.Loca = '" + txtLocaCode.Text.Trim() + "')", "DailyDetails");
                        dgSelectedCusDetails.DataSource = Rep.dataset.Tables["DailyDetails"];
                        dgSelectedCusDetails.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        void CustomerPoint(string filter)
        {
            if (chkAllLoca.Checked)
            {
                if (raiAll.Checked)
                {
                    CancelCustomer();
                    if (chkAll.Checked == true)
                    {
                        Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),C.InsertDate,103) [RegDate] ,Location.Loca_Descrip AS LocaName,Card_No FROM CRM_Customer C INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code INNER JOIN Location ON Location.Loca = TC.Loca  WHERE TC.Checke = 1  ORDER BY Balance DESC; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company", "CustomerPoint");
                        Rep.dataset.Tables[1].TableName = "Company";
                    }
                    else
                    {
                        if (cmbPoints.Text == "5000<")
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance,Card_No FROM CRM_Customer C INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code WHERE TC.Checke = 1 " + filter + " AND C.Balance>5000; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance,Card_No FROM CRM_Customer C INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code WHERE TC.Checke = 1 " + filter + " AND C.Balance BETWEEN CAST(substring('" + cmbPoints.Text + "',0,CHARINDEX('-','" + cmbPoints.Text + "',0)) AS MONEY) AND CAST(substring('" + cmbPoints.Text + "',CHARINDEX('-','" + cmbPoints.Text + "',0)+1,(LEN('" + cmbPoints.Text + "')-CHARINDEX('-','" + cmbPoints.Text + "',0))) AS MONEY); SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                    }
                    //report.DisplayReport(new Report.rptCustomerPoints(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "" + OnimtaOpticalSystem.Properties.Settings.Default.PrintShadow.ToString() + "" } });
                }
                else
                {
                    string Category = "(Cust_Category LIKE '%')";

                    if (cmbCategory.Text.Trim() != "All")
                    {
                        Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                    }

                    if (chkAll.Checked)
                    {
                        Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate], LocaName,Card_No FROM CRM_Customer C WHERE " + Category + " ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company;", "CustomerPoint");
                        Rep.dataset.Tables[1].TableName = "Company";

                    }
                    else
                    {
                        Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate], LocaName,Card_No FROM CRM_Customer C WHERE C.Cus_Code = '" + txtCustomerID.Text.Trim() + "'" + filter + " AND " + Category + " ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company;", "CustomerPoint");
                        Rep.dataset.Tables[1].TableName = "Company";
                    }
                }
            }
            else
            {
                if (raiAll.Checked)
                {
                    CancelCustomer();
                    if (chkAll.Checked == true)
                    {
                        //Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate] ,'" + txtLocaName.Text.Trim() + "' AS LocaName FROM CRM_Customer C INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code WHERE TC.Checke = 1  ORDER BY Balance DESC; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                        Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103) AS RegDate, '" + txtLocaName.Text.Trim() + "' AS LocaName, SUM(CASE iid WHEN '001' THEN Amount WHEN 'INV' THEN Amount WHEN 'R01' THEN - Amount WHEN 'CUR' THEN - Amount WHEN '005' THEN - Amount ELSE 0 END) AS PurchaseValue,Card_No FROM CRM_Customer AS C INNER JOIN CRM_TempCodeLoca AS TC ON C.Cus_Code = TC.Code INNER JOIN DayEnd_Pos_Transaction ON TC.Loca = DayEnd_Pos_Transaction.Loca AND TC.Code = DayEnd_Pos_Transaction.Customer WHERE (TC.Checke = 1) AND (C.Cust_Category = 'Loyalty customer') GROUP BY C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103)  ORDER BY C.Balance DESC; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                        Rep.dataset.Tables[1].TableName = "Company";
                    }
                    else
                    {
                        if (cmbPoints.Text == "5000<")
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance,Card_No FROM CRM_Customer C INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code WHERE TC.Checke = 1 " + filter + " AND C.Balance>5000; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance,Card_No FROM CRM_Customer C INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code WHERE TC.Checke = 1 " + filter + " AND C.Balance BETWEEN CAST(substring('" + cmbPoints.Text + "',0,CHARINDEX('-','" + cmbPoints.Text + "',0)) AS MONEY) AND CAST(substring('" + cmbPoints.Text + "',CHARINDEX('-','" + cmbPoints.Text + "',0)+1,(LEN('" + cmbPoints.Text + "')-CHARINDEX('-','" + cmbPoints.Text + "',0))) AS MONEY); SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                    }
                    //report.DisplayReport(new Report.rptCustomerPoints(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "" + OnimtaOpticalSystem.Properties.Settings.Default.PrintShadow.ToString() + "" } });
                }
                else
                {
                    string Category = "(Cust_Category LIKE '%')";

                    if (cmbCategory.Text.Trim() != "All")
                    {
                        Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                    }
                    if (chkAll.Checked)
                    {
                        Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate],'"+txtLocaName.Text.Trim()+ "' as LocaName,Card_No FROM CRM_Customer C WHERE " + Category + " AND Loca='"+txtLocaCode.Text.Trim()+"' ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company;", "CustomerPoint");
                    }
                    else
                    {
                        Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate],'" + txtLocaName.Text.Trim() + "' as LocaName,Card_No FROM CRM_Customer C WHERE C.Cus_Code = '" + txtCustomerID.Text.Trim() + "'" + filter + " AND " + Category + " AND Loca='" + txtLocaCode.Text.Trim() + "' ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company;", "CustomerPoint");
                    }
                    Rep.dataset.Tables[1].TableName = "Company";
                }
            }
        }  //case 0

        void CustomerPointEarnedRedeemedReport()
        { 
        
        } //case 1

        private void CustomerDetails()
        {
            
        } // case 2

        private void CancelCustomer()
        {
            if (raiAll.Checked || raiCustomerType.Checked) 
            {
                bool Delete = true;
                for (int i = 0; i < dgSelectedCusDetails.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgSelectedCusDetails.Rows[i].Cells[0].FormattedValue) == true)
                    {
                        Rep.GetStoredProcedure("CRM_sp_InsertSelected", new object[,] { { "@Code", "" + dgSelectedCusDetails.Rows[i].Cells[1].Value.ToString() + "" }, { "@Loca", "" + dgSelectedCusDetails.Rows[i].Cells[3].Value.ToString() + "" }, { "@Delete", "" + Convert.ToByte(Delete) + "" } });
                        Delete = false;
                    }
                }
            }
        } // case 5

        private void CustomerPointStatement()
        { 
            //Rep.GetStoredProcedure("CRM_sp_CustomerPointStatement", new object[,] { { "@CustCode", "" + txtCustomerID.Text.Trim().ToString() + "" }, { "@Loca", "" + clsMainClass.LoginLocaCode.ToString() + "" }, { "@Cust_Category", "" + cmbCategory.Text.ToString() + "" } }, "Statement");
            Rep.GetStoredProcedure("CRM_sp_CustomerPointStatement", new object[,] { { "@CustCode", "" + txtCustomerID.Text.Trim().ToString() + "" }, { "@Loca", "" + clsMainClass.LoginLocaCode.ToString() + "" }}, "Statement");
            Rep.dataset.Tables[1].TableName = "Company";
            report.DisplayReport(new rptCustomerPontStatement(), Rep.dataset, "Customer Point Statement","");

        } // case 3

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ReportNumber)
                {

                    case 1:
                        CustomerPointEarnedRedeemedReport();
                        break;

                    case 2:
                        CustomerDetails();
                        break;

                    case 3:
                        CustomerPointStatement();
                        break;

                    case 4:
                        //CustomerPoint(" AND C.Balance <= 0");
                        string Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        if (chkAll.Checked == true)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance,Card_No FROM CRM_Customer C WHERE C.Balance <= 0 AND " + Category + " ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + clsMainClass.LoginLocaCode.ToString() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance,Card_No FROM CRM_Customer C WHERE C.Cus_Code = '" + txtCustomerID.Text.Trim() + "' AND C.Balance <= 0 AND " + Category + " ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + clsMainClass.LoginLocaCode.ToString() + "'", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                        report.DisplayReport(new rptCustomerPoints(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "TRUE" } }, "Customer Point Zero/Minus Report");
                        break;

                    case 5:
                        //CancelCustomer();
                        if (chkAll.Checked == true)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, LocaName Loca,Card_No, LocaName,InactiveDate,ModUser,Balance FROM CRM_Customer C /*INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code*/ WHERE Inactive = 1 ORDER BY Cus_Name", "CRM_Customer");
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, LocaName Loca,Card_No, LocaName,InactiveDate,ModUser,Balance FROM CRM_Customer C /*INNER JOIN CRM_TempCodeLoca TC ON C.Cus_Code = TC.Code*/ WHERE Inactive = 1 AND Cus_Code = '" + txtCustomerID.Text.Trim()+"' ORDER BY Cus_Name", "CRM_Customer");
                        }                        
                        report.DisplayReport(new rptCustomers(), Rep.dataset, "Cancel Customer Report",
                        new string[,] { { "CodeFrom", "All" },
                                        { "CodeTo", "All" }}, "Cancel Customer Details");
                        break;

                    case 6:
                        if (string.IsNullOrEmpty(txtLocaCode.Text))//all loca
                        {
                            //original query -- @"SELECT PCP.Cust_Code, DPT.Item_Code [Prod_Code], DPT.Item_Descrip [Prod_Name], DPT.Unit_Price [Selling], DPT.Qty, DPT.Amount, DPT.Receipt_No, DPT.Unit, DPT.ReportDate, C.Cus_Name,Card_No FROM DayEnd_Pos_Transaction DPT INNER JOIN Pos_CustomerPoints PCP ON DPT.Receipt_No = PCP.Receipt_No AND DPT.Loca = PCP.Loca AND DPT.ReportID = PCP.ReportID AND DPT.ReportDate = PCP.ReportDate AND DPT.Unit = PCP.Unit INNER JOIN CRM_TempCodeLoca TC ON PCP.Cust_Code = TC.Code INNER JOIN CRM_Customer C ON C.Cus_Code = TC.Code WHERE  PCP.Cust_Code = '" + txtCustomerID.Text.Trim() + "' AND (DPT.Iid = '001' OR DPT.Iid = 'R01') AND DPT.Loca = '" + clsMainClass.LoginLocaCode.ToString() + "' ORDER BY DPT.Qty DESC
                                                       
                            Rep.dataset = Rep.getDataSet(@"SELECT '"+dtpDateFrom.Text+"' DateFrom,'"+dtpDateTo.Text+"'DateTo,'"+txtLocaCode.Text.Trim()+ "' Loca,L.Loca_Descrip as LocaName,PCP.Cust_Code, DPT.Item_Code [Prod_Code], DPT.Item_Descrip [Prod_Name], DPT.Unit_Price [Selling], DPT.Qty, DPT.Amount, DPT.Receipt_No, DPT.Unit, DPT.ReportDate, C.Cus_Name,Card_No FROM DayEnd_Pos_Transaction DPT INNER JOIN Location L ON L.Loca = DPT.Loca INNER JOIN Pos_CustomerPoints PCP ON DPT.Receipt_No = PCP.Receipt_No AND DPT.Loca = PCP.Loca AND DPT.ReportID = PCP.ReportID AND DPT.ReportDate = PCP.ReportDate AND DPT.Unit = PCP.Unit INNER JOIN CRM_Customer C ON C.Cus_Code = '" + txtCustomerID.Text.Trim() + "' WHERE  PCP.Cust_Code = '" + txtCustomerID.Text.Trim() + "'  AND (DPT.Iid = '001' OR DPT.Iid = 'R01') AND CONVERT(DATETIME,DPT.ReportDate,103) BETWEEN CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103)  ORDER BY DPT.Qty DESC", "Statement");
                            report.DisplayReport(new rptCustomerProductUsage(), Rep.dataset, "Customer Product Usage Report", "Cancel Customer Details");

                        }
                        else // loca selected
                        {                           
                            Rep.dataset = Rep.getDataSet(@"SELECT '" + dtpDateFrom.Text + "' DateFrom,'" + dtpDateTo.Text + "'DateTo,'" +txtLocaCode.Text.Trim()+ "' Loca,L.Loca_Descrip as LocaName,PCP.Cust_Code, DPT.Item_Code [Prod_Code], DPT.Item_Descrip [Prod_Name], DPT.Unit_Price [Selling], DPT.Qty, DPT.Amount, DPT.Receipt_No, DPT.Unit, DPT.ReportDate, C.Cus_Name,Card_No FROM DayEnd_Pos_Transaction DPT INNER JOIN Location L ON L.Loca = DPT.Loca INNER JOIN Pos_CustomerPoints PCP ON DPT.Receipt_No = PCP.Receipt_No AND DPT.Loca = PCP.Loca AND DPT.ReportID = PCP.ReportID AND DPT.ReportDate = PCP.ReportDate AND DPT.Unit = PCP.Unit INNER JOIN CRM_Customer C ON C.Cus_Code = '" + txtCustomerID.Text.Trim() + "'  WHERE  PCP.Cust_Code = '" + txtCustomerID.Text.Trim() + "' AND (DPT.Iid = '001' OR DPT.Iid = 'R01') AND DPT.Loca = '" + txtLocaCode.Text.Trim() + "' AND CONVERT(DATETIME,DPT.ReportDate,103) BETWEEN CONVERT(DATETIME,'" + dtpDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtpDateTo.Text.Trim() + "',103)  ORDER BY DPT.Qty DESC", "Statement");
                            report.DisplayReport(new rptCustomerProductUsage(), Rep.dataset, "Customer Product Usage Report", "Cancel Customer Details");

                        }

                        break;

                    case 7:
                        CancelCustomer();
                        Rep.dataset = Rep.getDataSet("SELECT Card_Name,Company_Name,TelNo FROM  CRM_CardInfo", "dsCardInfo");
                        report.DisplayReport(new rptCusRegForm(), Rep.dataset, "Customer Registation Form", "Customer Registration");
                        break;

                    case 8:

                        break;

                    case 10:
                        Range = cmbPoints.Text.Trim();
                        CustomerPoint("");
                        report.DisplayReport(new rptCustomerPoints(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "" + Inventory.Properties.Settings.Default.PrintShadow.ToString() + "" } }, "Customer Point Report");
                        break;

                    case 11:
                        
                        Range = cmbPoints.Text.Trim();
                        raiCustomerType.Checked = true;
                        CustomerPoint("");
                        report.DisplayReport(new rptCustomerPoints_LocaWise(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "" + Inventory.Properties.Settings.Default.PrintShadow.ToString() + "" } }, "Location Wise Customer Point Report");
                        break;
                       

                    case 16:

                        Range = cmbPoints.Text.Trim();
                        raiCustomerType.Checked = true;

                        //CustomerPoint("");   

                        if ((!chkAll.Checked) && (!chkAllLoca.Checked))
                        {
                            Rep.dataset = Rep.getDataSet("SELECT PCP.Cust_Code as Cus_Code,PCP.Loca, PCP.ActualBillAmt,PCP.BillDate, PCP.Points as Points,(PCP.Points-PCP.Readeem) as [Balance],C.Cus_Name,Location.Loca_Descrip AS LocaName,C.Mobile, C.PhoneNo ,Card_No,Receipt_No as ReceiptNo,Readeem,Unit FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code INNER JOIN Location ON Location.Loca = PCP.Loca WHERE PCP.Loca = '" + txtLocaCode.Text.Trim() + "' AND PCP.Cust_Code = '" + txtCustomerID.Text.Trim() + "' AND Cust_Category = '" + cmbCategory.Text.Trim() + "' ORDER BY PCP.Cust_Code,PCP.BillDate", "CustomerPoint");
                           
                        }
                        else if ((chkAll.Checked) && (!chkAllLoca.Checked))
                        {
                            Rep.dataset = Rep.getDataSet("SELECT PCP.Cust_Code as Cus_Code,PCP.Loca, PCP.ActualBillAmt,PCP.BillDate, PCP.Points as Points,(PCP.Points-PCP.Readeem) as [Balance],C.Cus_Name,Location.Loca_Descrip AS LocaName,C.Mobile, C.PhoneNo ,Card_No,Receipt_No as ReceiptNo,Readeem,Unit FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code INNER JOIN Location ON Location.Loca = PCP.Loca WHERE PCP.Loca = '" + txtLocaCode.Text.Trim() + "' AND Cust_Category = '" + cmbCategory.Text.Trim() + "' ORDER BY PCP.Cust_Code,PCP.BillDate", "CustomerPoint");

                        }
                        else if ((!chkAll.Checked) && (chkAllLoca.Checked))
                        {
                            Rep.dataset = Rep.getDataSet("SELECT PCP.Cust_Code as Cus_Code,PCP.Loca, PCP.ActualBillAmt,PCP.BillDate, PCP.Points as Points,(PCP.Points-PCP.Readeem) as [Balance],C.Cus_Name,Location.Loca_Descrip AS LocaName,C.Mobile, C.PhoneNo ,Card_No,Receipt_No as ReceiptNo,Readeem,Unit FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code INNER JOIN Location ON Location.Loca = PCP.Loca WHERE PCP.Cust_Code = '" + txtCustomerID.Text.Trim() + "' AND Cust_Category = '" + cmbCategory.Text.Trim() + "' ORDER BY PCP.Cust_Code,PCP.BillDate", "CustomerPoint");

                        }
                        else if((chkAll.Checked) && (chkAllLoca.Checked))
                        {
                            Rep.dataset = Rep.getDataSet("SELECT PCP.Cust_Code as Cus_Code,PCP.Loca, PCP.ActualBillAmt,PCP.BillDate, PCP.Points as Points,(PCP.Points-PCP.Readeem) as [Balance],C.Cus_Name,Location.Loca_Descrip AS LocaName,C.Mobile, C.PhoneNo ,Card_No,Receipt_No as ReceiptNo,Readeem,Unit FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code INNER JOIN Location ON Location.Loca = PCP.Loca WHERE  Cust_Category = '" + cmbCategory.Text.Trim() + "' ORDER BY PCP.Cust_Code,PCP.BillDate", "CustomerPoint");
                        }
                        else
                        {
                            Rep.dataset = null;
                        } 
                                             
                    //    report.DisplayReport(new rptCustomerPoints_LocaWise_Modif(), Rep.dataset, "Customer Point", null, "Location Wise Customer Point Report");

                        break;

                    case 12:
                        Range = cmbPoints.Text.Trim();

                        if (chkAll.Checked == true)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cust_Category As Category, C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103) AS RegDate,SUM(CASE iid WHEN '001' THEN Amount WHEN 'INV' THEN Amount WHEN 'R01' THEN - Amount WHEN 'CUR' THEN - Amount WHEN '005' THEN - Amount ELSE 0 END) AS PurchaseValue, DayEnd_Pos_Transaction.Loca,C.Card_No FROM CRM_Customer AS C INNER JOIN (SELECT Customer,Iid,Amount,Loca FROM DayEnd_Pos_Transaction WHERE Iid IN ('001','R01','INV','CUR','005')) DayEnd_Pos_Transaction ON C.Cus_Code = DayEnd_Pos_Transaction.Customer GROUP BY C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103), DayEnd_Pos_Transaction.Loca, C.Cust_Category,C.Card_No ORDER BY C.Balance DESC ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cust_Category As Category, C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103) AS RegDate,SUM(CASE iid WHEN '001' THEN Amount WHEN 'INV' THEN Amount WHEN 'R01' THEN - Amount WHEN 'CUR' THEN - Amount WHEN '005' THEN - Amount ELSE 0 END) AS PurchaseValue, DayEnd_Pos_Transaction.Loca,C.Card_No FROM CRM_Customer AS C INNER JOIN (SELECT Customer,Iid,Amount,Loca FROM DayEnd_Pos_Transaction WHERE Iid IN ('001','R01','INV','CUR','005')) DayEnd_Pos_Transaction ON C.Cus_Code = DayEnd_Pos_Transaction.Customer WHERE (Cust_Category = '" + txtCustomerID.Text.Trim() + "') GROUP BY C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103), DayEnd_Pos_Transaction.Loca, C.Cust_Category, C.Card_No ORDER BY C.Balance DESC ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }

                        report.DisplayReport(new rptCustomerPoints_CustomerCategoryWise(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "" + Inventory.Properties.Settings.Default.PrintShadow.ToString() + "" } }, "Customer Category Wise Customer Point Report");
                        break;

                    case 13:
                        //Range = cmbPoints.Text.Trim();
                        //CustomerPoint("");
                        if (chkAll.Checked)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate],'' as LocaName FROM CRM_Customer C WHERE Cust_Category = 'Tourist guide' ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company;", "CustomerPoint");
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cus_Code, C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10),InsertDate,103) [RegDate],'' as LocaName FROM CRM_Customer C WHERE C.Cus_Code='" + txtCustomerID.Text.Trim() + "' AND Cust_Category = 'Tourist guide' ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company;", "CustomerPoint");
                        }
                        Rep.dataset.Tables[1].TableName = "Company";
                        report.DisplayReport(new rptCustomerPoints(), Rep.dataset, "Customer Point", new string[,] { { "Shadow", "" + Inventory.Properties.Settings.Default.PrintShadow.ToString() + "" } }, "Customer Point Report");
                        break;

                    case 14:
                        Range = cmbPoints.Text.Trim();

                        if (chkAll.Checked == true)
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cust_Category As Category, C.Cus_Code, C.Cus_Type,C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103) AS RegDate,SUM(CASE iid WHEN '001' THEN Amount WHEN 'INV' THEN Amount WHEN 'R01' THEN - Amount WHEN 'CUR' THEN - Amount WHEN '005' THEN - Amount ELSE 0 END) AS PurchaseValue, DayEnd_Pos_Transaction.Loca,C.Card_No FROM CRM_Customer AS C INNER JOIN (SELECT Customer,Iid,Amount,Loca FROM DayEnd_Pos_Transaction WHERE Iid IN ('001','R01','INV','CUR','005')) DayEnd_Pos_Transaction ON C.Cus_Code = DayEnd_Pos_Transaction.Customer GROUP BY C.Cus_Code, C.Cus_Type,C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103), DayEnd_Pos_Transaction.Loca, C.Cust_Category,C.Card_No ORDER BY C.Balance DESC ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }
                        else
                        {
                            Rep.dataset = Rep.getDataSet("SELECT C.Cust_Category As Category, C.Cus_Code, C.Cus_Type,C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103) AS RegDate,SUM(CASE iid WHEN '001' THEN Amount WHEN 'INV' THEN Amount WHEN 'R01' THEN - Amount WHEN 'CUR' THEN - Amount WHEN '005' THEN - Amount ELSE 0 END) AS PurchaseValue, DayEnd_Pos_Transaction.Loca,C.Card_No FROM CRM_Customer AS C INNER JOIN (SELECT Customer,Iid,Amount,Loca FROM DayEnd_Pos_Transaction WHERE Iid IN ('001','R01','INV','CUR','005')) DayEnd_Pos_Transaction ON C.Cus_Code = DayEnd_Pos_Transaction.Customer WHERE (Cus_Code = '" + txtCustomerID.Text.Trim() + "') GROUP BY C.Cus_Code, C.Cus_Type,C.Cus_Name, C.Mobile, C.PhoneNo, C.Balance, CONVERT(NVARCHAR(10), C.InsertDate, 103), DayEnd_Pos_Transaction.Loca, C.Cust_Category, C.Card_No ORDER BY C.Balance DESC ; SELECT CompanyCode, CompanyName, Address1, Address2, Phone, FaxNo, email, WebAddress FROM CRM_Company WHERE CRM_Company.Loca = '" + txtLocaCode.Text.Trim() + "';", "CustomerPoint");
                            Rep.dataset.Tables[1].TableName = "Company";
                        }

                        
                     //   report.DisplayReport(new rptCustomerPoints_CustomerTypeWise(), Rep.dataset, "Customer Point", null, "Customer Type Wise Customer Point Report");
                        break;

                    case 15:

                        if (chkAll.Checked)
                        {

                            Rep.dataset = Rep.getDataSet("select '" + dtpUpto.Text.ToString() + "' as DateUpto,Cust_Code, Cus_Name [Cust_Name], Mobile, SUM(Points) [Points], SUM(Points-Readeem) AS Balance,LocaName,Card_No from Pos_CustomerPoints INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code where (CONVERT(DATE,BillDate,103) < CONVERT(DATE,'" + dtpUpto.Text.ToString() + "',103)) GROUP BY Cust_Code,Cus_Name,Mobile,LocaName,Card_No ORDER BY Balance DESC", "dsCusPointsGD");
                           
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(txtCustomerID.Text.Trim()))
                            {
                                Rep.dataset = Rep.getDataSet("select '" + dtpUpto.Text.ToString() + "' as DateUpto,Cust_Code, Cus_Name [Cust_Name], Mobile, SUM(Points) [Points], SUM(Points-Readeem) AS Balance,LocaName,Card_No from Pos_CustomerPoints INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code where (CONVERT(DATE,BillDate,103) < CONVERT(DATE,'" + dtpUpto.Text.ToString() + "',103)) and Cust_Code = '" + txtCustomerID.Text.Trim() + "' GROUP BY Cust_Code,Cus_Name,Mobile,LocaName,Card_No ORDER BY Balance DESC", "dsCusPointsGD");
                            }
                            else
                            {
                                MessageBox.Show("Select Customer","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            }
                        }
                     //   report.DisplayReport(new rptCustomerPointsUptoGD(), Rep.dataset, "Customers Point Upto Given Date", "Customers Point Upto Given Date");
                        break;

                    case 40:
                        Rep.dataset = Rep.getDataSet("SELECT Cus_Code, Status, Cus_Name, FirstName, SecondName, Address1, Address2, Address3, Address5, PhoneNo, Fax, OfficePhone, Other, Mobile,NoMobile, ContactPersion, E_mail, Web, NICNumber, Birthday, Cus_Type, Referance, Age, Inactive, InsertDate, ModDate, InsertUser, ModUser, Workshop, Wesak, NewYear, DontBCard, Abrod, Festival, NameOfSpouse, Card_No, CardIssuedDate, Occupation, MaritalStatus, SpouseBirthDay, Group_Code, Group_Name, Anniversary, Loca, LocaName,Cust_Category ,Point_Rate,Gender, Religion, RedeemStatus FROM CRM_Customer_ChangeDetails WHERE Cus_Code = '" + txtCustomerID.Text.Trim() + "'");
                        Rep.dataset.Tables[0].TableName = "Company";
                        dataGridView1.DataSource = Rep.dataset.Tables["Company"];

                        try
                        {

                            copyAlltoClipboard();
                            Microsoft.Office.Interop.Excel.Application xlexcel;
                            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                            object misValue = System.Reflection.Missing.Value;
                            xlexcel = new Excel.Application();
                            xlexcel.Visible = true;
                            xlWorkBook = xlexcel.Workbooks.Add(misValue);
                            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                            CR.Select();
                            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }




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

        private void ToCsV(DataGridView dGV, string filename)
        {
            FileStream fs;
            BinaryWriter bw;
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            sHeaders = sHeaders + "\r\n";
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(sHeaders);
            fs = new FileStream(filename, FileMode.Create);
            bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            fs.Close();
            bw.Close();

            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stLine = stLine + "\r\n";

                output = utf16.GetBytes(stLine);
                fs = new FileStream(filename, FileMode.Append);
                bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                fs.Close();
                bw.Close();
            }


        }


        private void copyAlltoClipboard()
        {
            //string sHeaders = "";
            //for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //    sHeaders = sHeaders.ToString() + Convert.ToString(dataGridView1.Columns[j].HeaderText) + "\t";
            //sHeaders = sHeaders + "\r\n";

            CopyToClipboardWithHeaders(dataGridView1);
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
            Clipboard.SetDataObject(dataObj);
        }

        private void CopyToClipboardWithHeaders(DataGridView dataGridView1)
        {
            
        }

        private void frmCustomReport_Load(object sender, EventArgs e)
        {
            try
            {
                switch (ReportNumber)
                {
                    case 10:
                        lblLoca.Visible = true; txtLocaCode.Visible = true; txtLocaName.Visible = true;
                        chkAllLoca.Visible = true; chkAll.Visible = false; btnLocaSearch.Visible = true;
                        lblCategory.Visible = true; cmbCategory.Visible = true;
                        LoadCustomerCategory();
                        break;

                    case 11:
                    case 16:

                        lblLoca.Visible = true; txtLocaCode.Visible = true; txtLocaName.Visible = true;
                        chkAllLoca.Visible = true; chkAll.Visible = true; btnLocaSearch.Visible = true;
                        lblCategory.Visible = true; cmbCategory.Visible = true;
                        LoadCustomerCategory();
                        raiCustomerType.Checked = true;
                        break;
                    
                    case 3:                   
                        btnMoreInquire.Visible = false;
                        chkAll.Visible = false;
                        lblCategory.Visible = true; cmbCategory.Visible = true;
                        LoadCustomerCategory();
                        break;

                    case 6:

                        
                        lblCategory.Visible = false;
                        cmbCategory.Visible = false;
                        lblUpto.Visible = false;
                        dtpUpto.Visible = false;

                        txtCustomerID.Enabled = true;
                        txtCustomerName.Enabled = true;
                        btnCusSearch.Enabled = true;
                        btnLocaSearch.Visible = true;
                        chkAll.Enabled = false;

                        txtLocaCode.Visible = true;
                        txtLocaName.Visible = true;
                        btnLocaSearch.Visible = true;
                        lblDateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        dtpDateFrom.Visible = true;
                        dtpDateTo.Visible = true;
                        chkAllLoca.Visible = true;
                        lblLoca.Visible = true;
                        btnMoreInquire.Visible = false;

                        rbLoca.Enabled = true;
                        cmbLoca.Enabled = true;

                        break;

                    case 15:
                        btnMoreInquire.Visible = false;
                        chkAll.Enabled = true;
                        lblCategory.Visible = false; cmbCategory.Visible = false;
                        lblUpto.Visible = true;
                        dtpUpto.Visible = true;
                        txtCustomerID.Enabled = true;
                        txtCustomerName.Enabled = true;
                        btnCusSearch.Enabled = true;
                        btnLocaSearch.Visible = false;
                        
                        break;

                    case 40: 
                        btnMoreInquire.Visible = false;
                        chkAll.Visible = false;
                        lblCategory.Visible = false;
                        cmbCategory.Visible = false;
                        LoadCustomerCategory();
                        break;

                    case 4:
                        lblCategory.Visible = true;
                        cmbCategory.Visible = true;
                        LoadCustomerCategory();
                        break;

                    case 5:
                        btnMoreInquire.PerformClick();
                        btnMoreInquire.Visible = false;
                        break;

                    case 7:
                        btnClear.Enabled = false;
                        btnCusSearch.Enabled = false;
                        btnMoreInquire.Enabled = false;
                        txtCustomerID.Enabled = false;
                        txtCustomerName.Enabled = false;
                        lblName.Enabled = false;
                        chkAll.Enabled = false;
                        //radioButton1.Visible = false;
                        //radioButton2.Visible = false;
                        break;

                    case 8:
                        btnMoreInquire.Visible = false;
                        chkAll.Visible = false;
                        txtCustomerID.Enabled = false;
                        break;

                    case 14:
                        lblLoca.Visible = false; txtLocaCode.Visible = false; txtLocaName.Visible = false;
                        chkAllLoca.Visible = false; chkAll.Visible = true; btnLocaSearch.Visible = false;
                        lblCategory.Visible = false; cmbCategory.Visible = false;lblType.Visible = false;
                        LoadCustomerTypes();
                        break;

                    default:
                        break;
                }
                Rep.getDataset("SELECT PointRange FROM CRM_PointRange WHERE Loca='" + txtLocaCode.Text.Trim() + "'", "DsPoints");
                cmbPoints.Items.Clear();
                foreach (DataRow row in Rep.dataset.Tables[0].Rows)
                {
                    cmbPoints.Items.Add(row["PointRange"].ToString());
                }                 
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

        /// <summary>
        /// load types
        /// </summary>
        private void LoadCustomerTypes()
        {
            DataSet dsCustCat = Rep.getDataSet("select [Type] from CRM_CustomerType");
            dsCustCat.Tables[0].Rows.Add("All");
            cmbCategory.DataSource = dsCustCat.Tables[0];
            cmbCategory.DisplayMember = "Type";

            //cmbCategory.Items.Add("All");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgSelectedCusDetails.DataSource = null;
            txtLocaCode.Text = ""; txtLocaName.Text = "";
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtCustomerID.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                txtCustomerID.Enabled = false;
                txtCustomerName.Enabled = false;
                btnCusSearch.Enabled = false;
                raiAll.Checked = true;
                txtCustomerName.Clear();
                txtCustomerID.Clear();
            }
            else
            {
                txtCustomerID.Enabled = true;
                txtCustomerName.Enabled = true;
                btnCusSearch.Enabled = true;
                raiAll.Checked = false;
            }
        }

        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {

                txtCustomerID.Text = ""; txtCustomerName.Text = "";
                if (search.IsDisposed)
                {
                    search = new frmCustomerSearch();
                }
                if (txtLocaCode.Text.Trim() != string.Empty && txtLocaName.Text.Trim() == string.Empty)
                {
                    clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca LIKE '%" + txtLocaCode.Text.Trim() + "%' and TaxLoca='" + LoginManager.TaxLocaLogin + "' ORDER BY Loca");
                }
                else if (txtLocaCode.Text.Trim() == string.Empty && txtLocaName.Text.Trim() != string.Empty)
                {
                    clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca_Descrip LIKE '%" + txtLocaName.Text.Trim() + "%' and TaxLoca='" + LoginManager.TaxLocaLogin + "' ORDER BY Loca");
                }
                else
                {
                    clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location where TaxLoca='" + LoginManager.TaxLocaLogin + "' ORDER BY Loca");
                }

                search.ShowDialog();
                if (clsMainClass.Cnt_Focus != null)
                {
                    txtLocaCode.Text = clsMainClass.Cnt_Focus.ToString();
                    txtLocaName.Text = clsMainClass.Cnt_Descrip.ToString();
                    clsMainClass.Cnt_Focus = null;
                    clsMainClass.Cnt_Descrip = null;
                }
                txtLocaCode.Focus();

                Rep.getDataset("SELECT PointRange FROM CRM_PointRange WHERE Loca='" + txtLocaCode.Text.Trim() + "'", "DsPoints");
                cmbPoints.Items.Clear();
                foreach (DataRow row in Rep.dataset.Tables[0].Rows)
                {
                    cmbPoints.Items.Add(row["PointRange"].ToString());
                }
                //Rep.dataset = Rep.getDataSet("SELECT 1 [Fitting], C.Cus_Code [Customer], C.Cus_Name [WorkshopName] FROM CRM_Customer C INNER JOIN CRM_CustomerType CT ON C.Cus_Type = CT.Type WHERE C.Cus_Type = '" + cmbCustomerType.Text.Trim() + "' AND (C.Loca = '" + txtLocaCode.Text.Trim() + "')", "DailyDetails");

                Rep.dataset = Rep.getDataSet("SELECT 1 [Fitting], C.Cus_Code [Customer], C.Cus_Name [WorkshopName], C.Loca [Loca] FROM CRM_Customer C INNER JOIN CRM_CustomerType CT ON C.Cus_Type = CT.Type WHERE (C.Loca = '" + txtLocaCode.Text.Trim() + "')", "DailyDetails");
                dgSelectedCusDetails.DataSource = Rep.dataset.Tables["DailyDetails"];
                dgSelectedCusDetails.Refresh();



            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgSelectedCusDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbPoints_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAllLoca_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                txtLocaCode.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
                txtLocaName.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
                btnLocaSearch.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);

                Rep.dataset = Rep.getDataSet("SELECT 1 [Fitting], C.Cus_Code [Customer], C.Cus_Name [WorkshopName], C.Loca [Loca] FROM CRM_Customer C INNER JOIN CRM_CustomerType CT ON C.Cus_Type = CT.Type ", "DailyDetails");
                dgSelectedCusDetails.DataSource = Rep.dataset.Tables["DailyDetails"];
                dgSelectedCusDetails.Refresh();
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }     
    }
}