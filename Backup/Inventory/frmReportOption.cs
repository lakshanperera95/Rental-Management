using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
using Inventory.CRMReports;

namespace Inventory
{
    public partial class frmReportOption : Form
    {
        public int switchs;
        public frmReportOption()
        {
            InitializeComponent();
        }

        clsMainClass main = new clsMainClass();
        clsReport report = new clsReport();

        frmSearch search1 = new frmSearch();
        frmCustomerSearch search = new frmCustomerSearch();

        clsLibrary.clsMainClass Main = new clsLibrary.clsMainClass();

        private static frmReportOption ReportOption;
        public static frmReportOption GetReportOption
        {
            get { return ReportOption; }
            set { ReportOption = value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportOption = null;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "";
                string query;
                switch (switchs)
                {
                    case 1:
                        #region Patients Birthday
                        if (chkWithoutVen.Checked == true)
                        {
                            query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address4 + Address5,',',',\r\n') AS [Address], Birthday, Mobile, '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], Referance [Select] FROM CRM_Customer WHERE SUBSTRING(Cus_Name, 1, 3) <> 'ven' AND SUBSTRING(Birthday, 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "' AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " AND Abrod = " + Convert.ToByte(chkAbroad.Checked) + " AND Workshop = " + Convert.ToByte(chkWorkShop.Checked) + " AND DontBCard = " + Convert.ToByte(chkInformation.Checked) + " ORDER BY CONVERT(DATETIME,Birthday,103)";
                        }
                        else
                        {
                            query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address4 + Address5,',',',\r\n') AS [Address], Birthday, Mobile, '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], Referance [Select] FROM CRM_Customer WHERE SUBSTRING(Birthday, 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "' AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " AND Abrod = " + Convert.ToByte(chkAbroad.Checked) + " AND Workshop = " + Convert.ToByte(chkWorkShop.Checked) + " AND DontBCard = " + Convert.ToByte(chkInformation.Checked) + " ORDER BY CONVERT(DATETIME,Birthday,103)";
                        }
                        main.dataset = main.getDataSet(query, "Customer");
                        if (chkAddressLable.Checked == false)
                        {
                            report.DisplayReport(new rptCustomerBirthday(), main.dataset, "Customer Birthday","");
                        }                       
                        break;
                        #endregion

                    case 6:
                        #region Department Details Report
                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Depa_Code +' - '+Depa_Name [Prod_Name] FROM Department ORDER BY Depa_Name", "GRN");
                            report.DisplayReport(new rptCommMasterDetails(), main.dataset, "Department Details Report",
                         new string[,] {    { "ReportHeader", "DEPARTMENT DETAILS" }, 
                                            { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }, 
                                            { "FieldsHeader", "Department Code & Name" } },"");
                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Depa_Code +' - '+Depa_Name [Prod_Name] FROM Department WHERE Depa_Code = '" + txtCodeFrom.Text.Trim() + "' ORDER BY Depa_Name", "GRN");
                            report.DisplayReport(new  rptCommMasterDetails(), main.dataset, "Department Details Report",
                             new string[,] { 
                                            { "ReportHeader", "DEPARTMENT DETAILS" }, 
                                            { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "FieldsHeader", "Department Code & Name" } },"");
                        }
                       
                        break;
                        #endregion

                    case 7:
                        #region Category Details Report

                        
                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cat_Code + '-' + Cat_Name [Prod_Name], D.Depa_Code + ' - ' + D.Depa_Name [Prod_Code] FROM Category C INNER JOIN Department D ON C.Depa_Code = D.Depa_Code ORDER BY C.Cat_Name", "GRN");
                            report.DisplayReport(new rptCategoryDetails(), main.dataset, "Department Details Report",
                         new string[,] {    { "ReportHeader", "CATEGORY DETAILS" }, 
                                            { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }, 
                                            { "FieldsHeader", "Category Code & Name" } },"");
                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cat_Code + '-' + Cat_Name [Prod_Name], D.Depa_Code + ' - ' + D.Depa_Name [Prod_Code] FROM Category C INNER JOIN Department D ON C.Depa_Code = D.Depa_Code WHERE C.Cat_Code = '" + txtCodeFrom.Text.Trim() + "' ORDER BY Prod_Name", "GRN");
                            report.DisplayReport(new rptCategoryDetails(), main.dataset, "Department Details Report",
                             new string[,] { 
                                            { "ReportHeader", "CATEGORY DETAILS" }, 
                                            { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "FieldsHeader", "Category Code & Name" } },"");
                        }

                        break;
                        #endregion

                    case 8:
                        #region Brand Details Report
                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Brand_Code + ' - ' + Brand_Name [Prod_Name] FROM Brand ORDER BY Brand_Name", "GRN");
                            report.DisplayReport(new rptCommMasterDetails(), main.dataset, "Brand Details Report",
                            new string[,] { { "ReportHeader", "BRAND DETAILS" }, 
                                            { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }, 
                                            { "FieldsHeader", "Brand Code & Name" } },"");
                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Brand_Code + ' - ' + Brand_Name [Prod_Name] FROM Brand WHERE Brand_Code = '" + txtCodeFrom.Text.Trim() + "' ORDER BY Brand_Name", "GRN");
                            report.DisplayReport(new rptCommMasterDetails(), main.dataset, "Brand Details Report",
                             new string[,] { 
                                            { "ReportHeader", "BRAND DETAILS" }, 
                                            { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "FieldsHeader", "Brand Code & Name" } },"");
                        }

                        break;
                        #endregion
                        
                    case 9:
                        #region Customer Details Report

                        CrystalDecisions.CrystalReports.Engine.ReportDocument r;
                        if (chkWithMoreDetails.Checked)
	                    {
                            r = new   rptCustomer();
                        }
                        else
                        {
                            r = new rptCustomers();
                        }

                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName, Cust_Category, Balance FROM CRM_Customer WHERE /*(Loca = '" + txtLocaCode.Text.Trim() + "') AND */ (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport( r, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }}, "Customer Details");
                         
                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name, REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,Cust_Category, Balance FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') AND  (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                    #endregion

                    case 16:
                        #region Customer Details Report

                        CrystalDecisions.CrystalReports.Engine.ReportDocument r16;
                        if (chkWithMoreDetails.Checked)
                        {
                            r16 = new rptCustomer();
                        }
                        else
                        {
                            r16 = new rptCustomers();
                        }

                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName,Cust_Category FROM CRM_Customer WHERE /*(Loca = '" + txtLocaCode.Text.Trim() + "') AND*/  (Cust_Category = 'Tourist guide') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r16, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" },
                                            { "CodeTo", "All" }}, "Customer Details");

                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name, REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,Cust_Category FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') AND  (Cust_Category = 'Tourist guide') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r16, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                    #endregion

                    case 18:
                        #region Registered date wise registered location wise customer report

                        if ((chkAll.Checked)&&(chkAllLoca.Checked))
                        {
                            main.dataset = main.getDataSet("SELECT 'All' Code_From,'All' Code_To,'"+dtDateFrom.Text+"' Date_From,'"+dtDateTo.Text+"' Date_To,Cus_Code,Cus_Name,Mobile,NICNumber,Cus_Type,Cust_Category,Location.Loca_Descrip as Registered_Location,CONVERT(VARCHAR,CRM_Customer.InsertDate,103) as Registered_Date from CRM_Customer inner join Location on CRM_Customer.Loca = Location.Loca where CRM_Customer.InsertDate BETWEEN CONVERT(DATE,'"+dtDateFrom.Text+"',103) AND CONVERT(DATE,'"+dtDateTo.Text+ "',103) Order by CRM_Customer.InsertDate, Location.Loca_Descrip", "dsRegDateLocaWiseData");
                            
                        }
                        else if ((!chkAll.Checked) && (chkAllLoca.Checked))
                        {

                            if (!string.IsNullOrEmpty(txtCodeFrom.Text) && (!string.IsNullOrEmpty(txtCodeTo.Text)))
                            {
                                main.dataset = main.getDataSet("SELECT '"+txtCodeFrom.Text+"' Code_From,'"+txtCodeTo.Text+"' Code_To,'" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,Cus_Code,Cus_Name,Mobile,NICNumber,Cus_Type,Cust_Category,Location.Loca_Descrip as Registered_Location,CONVERT(VARCHAR,CRM_Customer.InsertDate,103) as Registered_Date from CRM_Customer inner join Location on CRM_Customer.Loca = Location.Loca where CRM_Customer.InsertDate BETWEEN CONVERT(DATE,'" + dtDateFrom.Text + "',103) AND CONVERT(DATE,'" + dtDateTo.Text + "',103) AND Cus_Code between '"+txtCodeFrom.Text.Trim()+"' AND '"+txtCodeTo.Text.Trim()+ "' Order by CRM_Customer.InsertDate, Location.Loca_Descrip", "dsRegDateLocaWiseData");
                               
                            }
                            else if (string.IsNullOrEmpty(txtCodeFrom.Text) && (!string.IsNullOrEmpty(txtCodeTo.Text)))
                            {
                                main.dataset = main.getDataSet("SELECT '"+txtCodeFrom.Text+ "' Code_From,'" + txtCodeFrom.Text + "' Code_To,'" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,Cus_Code,Cus_Name,Mobile,NICNumber,Cus_Type,Cust_Category,Location.Loca_Descrip as Registered_Location,CONVERT(VARCHAR,CRM_Customer.InsertDate,103) as Registered_Date from CRM_Customer inner join Location on CRM_Customer.Loca = Location.Loca where CRM_Customer.InsertDate BETWEEN CONVERT(DATE,'" + dtDateFrom.Text + "',103) AND CONVERT(DATE,'" + dtDateTo.Text + "',103) AND Cus_Code = '" + txtCodeFrom.Text.Trim() + "' Order by CRM_Customer.InsertDate, Location.Loca_Descrip", "dsRegDateLocaWiseData");

                            }
                            else
                            {
                                main.dataset = null;
                            }
                        }
                        else if ((chkAll.Checked) && (!chkAllLoca.Checked))
                        {
                            main.dataset = main.getDataSet("SELECT 'All' Code_From,'All' Code_To,'" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,Cus_Code,Cus_Name,Mobile,NICNumber,Cus_Type,Cust_Category,Location.Loca_Descrip as Registered_Location,CONVERT(VARCHAR,CRM_Customer.InsertDate,103) as Registered_Date from CRM_Customer inner join Location on CRM_Customer.Loca = Location.Loca where CRM_Customer.InsertDate BETWEEN CONVERT(DATE,'" + dtDateFrom.Text + "',103) AND CONVERT(DATE,'" + dtDateTo.Text + "',103) AND Location.Loca_Descrip = '" + txtLocaName.Text.Trim()+ "' Order by CRM_Customer.InsertDate, Location.Loca_Descrip", "dsRegDateLocaWiseData");
                            
                        }
                        else if ((!chkAll.Checked) && (!chkAllLoca.Checked))
                        {

                            if (!string.IsNullOrEmpty(txtCodeFrom.Text) && (!string.IsNullOrEmpty(txtCodeTo.Text)))
                            {
                                main.dataset = main.getDataSet("SELECT '" + txtCodeFrom.Text + "' Code_From,'" + txtCodeTo.Text + "' Code_To,'" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,Cus_Code,Cus_Name,Mobile,NICNumber,Cus_Type,Cust_Category,Location.Loca_Descrip as Registered_Location,CONVERT(VARCHAR,CRM_Customer.InsertDate,103) as Registered_Date from CRM_Customer inner join Location on CRM_Customer.Loca = Location.Loca where CRM_Customer.InsertDate BETWEEN CONVERT(DATE,'" + dtDateFrom.Text + "',103) AND CONVERT(DATE,'" + dtDateTo.Text + "',103) AND Cus_Code between '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' and Location.Loca_Descrip = '" + txtLocaName.Text.Trim() + "' Order by CRM_Customer.InsertDate, Location.Loca_Descrip", "dsRegDateLocaWiseData");
                            }
                            else if (string.IsNullOrEmpty(txtCodeFrom.Text) && (!string.IsNullOrEmpty(txtCodeTo.Text)))
                            {
                                main.dataset = main.getDataSet("SELECT '" + txtCodeFrom.Text + "' Code_From,'' Code_To,'" + dtDateFrom.Text + "' Date_From,'" + dtDateTo.Text + "' Date_To,Cus_Code,Cus_Name,Mobile,NICNumber,Cus_Type,Cust_Category,Location.Loca_Descrip as Registered_Location,CONVERT(VARCHAR,CRM_Customer.InsertDate,103) as Registered_Date from CRM_Customer inner join Location on CRM_Customer.Loca = Location.Loca where CRM_Customer.InsertDate BETWEEN CONVERT(DATE,'" + dtDateFrom.Text + "',103) AND CONVERT(DATE,'" + dtDateTo.Text + "',103) AND Cus_Code = '" + txtCodeFrom.Text.Trim() + "' and Location.Loca_Descrip = '" + txtLocaName.Text.Trim() + "' Order by CRM_Customer.InsertDate, Location.Loca_Descrip", "dsRegDateLocaWiseData");
                            }
                            else
                            {
                                main.dataset = null;
                            }
                        }
                        else
                        {
                            main.dataset = null;
                        }

                        report.DisplayReport(new rptRegDateLocaWiseData(), main.dataset, "Registered date wise registered location wise customer report", null, "");

                        break;

                        #endregion

                    case 20:
                        #region Customer Details Report - Location Wise 

                        CrystalDecisions.CrystalReports.Engine.ReportDocument r1;

                        if (chkWithMoreDetails.Checked)
                        {
                            r1 = new rptCustomer();
                        }
                        else
                        {
                            r1 = new rptCustomers();
                        }

                        if (chkAllLoca.Checked)
                        {
                            if (chkAll.Checked)
                            {
                                main.dataset = main.getDataSet("SELECT '"+dtDateFrom.Text+"' [DateFrom],'"+dtDateTo.Text+"' [DateTo],Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName,Balance,RegisteredDate as RegDate FROM CRM_Customer where Convert(datetime,RegisteredDate,103) between convert(datetime,'"+dtDateFrom.Text+"',103) and convert(datetime,'"+dtDateTo.Text+"',103) ORDER BY Cus_Name", "CRM_Customer");
                                report.DisplayReport(r1, main.dataset, "Location Wise Customer Details Report",
                                new string[,] { { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" },{ "Loca", "All" }}, "Location Wise Customer Details");

                            }
                            else
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text + "' [DateFrom],'" + dtDateTo.Text + "' [DateTo],Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName,Balance,RegisteredDate as RegDate FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') and Convert(datetime,RegisteredDate,103) between convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103) ORDER BY Cus_Name", "CRM_Customer");
                                report.DisplayReport(r1, main.dataset, "Location Wise Customer Details Report",
                                new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" },{ "Loca", "All" } }, "Location Wise Customer Details");
                            }
                        }
                        else
                        {
                            if (chkAll.Checked)
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text + "' [DateFrom],'" + dtDateTo.Text + "' [DateTo],Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName,Balance,RegisteredDate as RegDate FROM CRM_Customer WHERE (Loca = '" + txtLocaCode.Text.Trim() + "') and  Convert(datetime,RegisteredDate,103) between convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103) ORDER BY Cus_Name", "CRM_Customer");
                                report.DisplayReport(r1, main.dataset, "Customer Details Report",
                                new string[,] { { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" },{ "Loca", "" + txtLocaCode.Text.Trim() + "" }}, "Customer Details");

                            }
                            else
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text + "' [DateFrom],'" + dtDateTo.Text + "' [DateTo],Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName,Balance,RegisteredDate as RegDate FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') AND (Loca = '" + txtLocaCode.Text.Trim() + "') and Convert(datetime,RegisteredDate,103) between convert(datetime,'" + dtDateFrom.Text + "',103) and convert(datetime,'" + dtDateTo.Text + "',103) ORDER BY Cus_Name", "CRM_Customer");
                                report.DisplayReport(r1, main.dataset, "Customer Details Report",
                                new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" },{ "Loca", "" + txtLocaCode.Text.Trim() + "" } }, "Customer Details");
                            }
                        }
                        break;

                    #endregion

                    /*case 24:

                        #region Customer wise location visit

                        CrystalDecisions.CrystalReports.Engine.ReportDocument r24;
                     
                        r24 = new rptCustWiseLocaVisit();                        
                        
                        if (chkAllLoca.Checked)
                        {
                            if (chkAll.Checked)
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text.Trim() + "' DateFrom,'" + dtDateTo.Text.Trim() + "' DateTo,Cust_Code,Pos_CustomerPoints.Loca,L.Loca_Descrip AS LocaName,Card_No,Cus_Name [Cust_Name], Mobile, Points, Readeem,(BFBalance) as Balance,BillDate,BillAmount from Pos_CustomerPoints INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code INNER JOIN Location L ON L.Loca = Pos_CustomerPoints.Loca WHERE  Cust_Code between  '0' and 'ZZ' AND CONVERT(DATE,BillDate,103) BETWEEN CONVERT(DATE,'" + dtDateFrom.Text.Trim()+ "',103) AND CONVERT(DATE,'" + dtDateTo.Text.Trim() + "',103)  ORDER BY CONVERT(DATE,BillDate,103) ASC", "dsCusWiseLocaVisit");
                                report.DisplayReport(r24, main.dataset, "Customer wise location visit Report",null, "Customer wise location visit");

                            }
                            else
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text.Trim() + "' DateFrom,'" + dtDateTo.Text.Trim() + "' DateTo,Cust_Code,Pos_CustomerPoints.Loca,L.Loca_Descrip as LocaName,Card_No,Cus_Name [Cust_Name], Mobile, Points, Readeem,(BFBalance) as Balance,BillDate,BillAmount from Pos_CustomerPoints INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code INNER JOIN Location L ON L.Loca = Pos_CustomerPoints.Loca WHERE  Cust_Code between  '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATE,BillDate,103) BETWEEN CONVERT(DATE,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATE,'" + dtDateTo.Text.Trim() + "',103)  ORDER BY CONVERT(DATE,BillDate,103) ASC", "dsCusWiseLocaVisit");
                                report.DisplayReport(r24, main.dataset, "Customer wise location visit Report",null, "Customer wise location visit ");
                            }
                        }
                        else
                        {
                            if (chkAll.Checked)
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text.Trim() + "' DateFrom,'" + dtDateTo.Text.Trim() + "' DateTo,Cust_Code,Pos_CustomerPoints.Loca,L.Loca_Descrip as LocaName,Card_No,Cus_Name [Cust_Name], Mobile, Points, Readeem,(BFBalance) as Balance,BillDate,BillAmount from Pos_CustomerPoints INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code INNER JOIN Location L ON L.Loca = Pos_CustomerPoints.Loca WHERE Cust_Code between '0' and 'ZZ' AND Pos_CustomerPoints.Loca = '" + txtLocaCode.Text.Trim() + "' AND CONVERT(DATE,BillDate,103) BETWEEN CONVERT(DATE,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATE,'" + dtDateTo.Text.Trim() + "',103) ORDER BY CONVERT(DATE,BillDate,103) ASC", "dsCusWiseLocaVisit");
                                report.DisplayReport(r24, main.dataset, "Customer wise location visit Report",null, "Customer wise location visit");
                            }
                            else
                            {
                                main.dataset = main.getDataSet("SELECT '" + dtDateFrom.Text.Trim() + "' DateFrom,'" + dtDateTo.Text.Trim() + "' DateTo,Cust_Code,Pos_CustomerPoints.Loca,L.Loca_Descrip as LocaName,Card_No,Cus_Name [Cust_Name], Mobile, Points, Readeem,(BFBalance) as Balance,BillDate,BillAmount from Pos_CustomerPoints INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code INNER JOIN Location L ON L.Loca = Pos_CustomerPoints.Loca WHERE  Cust_Code between  '" + txtCodeFrom.Text.Trim()+"' and '"+txtCodeTo.Text.Trim()+"' AND Pos_CustomerPoints.Loca = '"+txtLocaCode.Text.Trim()+ "' AND CONVERT(DATE,BillDate,103) BETWEEN CONVERT(DATE,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATE,'" + dtDateTo.Text.Trim() + "',103) ORDER BY CONVERT(DATE,BillDate,103) ASC", "dsCusWiseLocaVisit");
                                report.DisplayReport(r24, main.dataset, "Customer wise location visit Report", null , "Customer wise location visit ");
                            }
                        }

                        break;
*/
               

                    case 10:
                        Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        main.dataset = main.getDataSet("SELECT PCP.Cust_Code, PCP.Receipt_No, CONVERT(DATETIME,PCP.BillDate+ ' ' +PCP.BillTime,103) [BillDate], PCP.ActualBillAmt, PCP.Points [Earn], PCP.Readeem [Redeem], PCP.Unit, C.Cus_Name,Card_No FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code WHERE CONVERT(DATETIME,PCP.BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) AND " + Category + " ORDER BY PCP.Cust_Code", "Statement");
                        report.DisplayReport(new rptDailyEarnRedeemPoint(), main.dataset, "Customer Point Earned/Redeemed Report", "Daily Point Earned/Redeemed Report");
                        break;

                    case 15:
                        Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        main.dataset = main.getDataSet("SELECT PCP.Cust_Code, PCP.Receipt_No, CONVERT(DATETIME,PCP.BillDate+ ' ' +PCP.BillTime,103) [BillDate], PCP.ActualBillAmt, PCP.Points [Earn], PCP.Readeem [Redeem],((PCP.BFBalance + PCP.Points)-PCP.Readeem) As BalPoints, PCP.Unit, C.Cus_Name, PCP.BFBalance,Card_No FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code WHERE CONVERT(DATETIME,PCP.BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) AND " + Category + " ORDER BY PCP.Cust_Code,PCP.Id_No", "Statement");
                        report.DisplayReport(new rptCustomerPurchaseAnalyse(), main.dataset, "Customer Point Earned/Redeemed Report", "Daily Point Earned/Redeemed Report");
                        break;

                    case 11:
                        #region Customer Details Report Location wise

                        CrystalDecisions.CrystalReports.Engine.ReportDocument Location;
                        if (chkWithMoreDetails.Checked)
                        {
                            Location = new rptCustomer();
                        }
                        else
                        {
                            Location = new rptLocaWiseCustomers();
                        }

                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code [Cus_Code] , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber,Card_No,Loca,LocaName  FROM CRM_Customer ORDER BY Cus_Code", "CRM_Customer");
                            report.DisplayReport(Location, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }}, "Customer Details");

                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code [Cus_Code] , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber,Card_No,Loca,LocaName  FROM CRM_Customer WHERE (Loca BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') ORDER BY Cus_Code", "CRM_Customer");
                            report.DisplayReport(Location, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                        #endregion

                    case 12:
                        #region Customer Details Report  A/O wise

                        CrystalDecisions.CrystalReports.Engine.ReportDocument AO;
                        if (chkWithMoreDetails.Checked)
                        {
                            AO = new rptCustomer();
                        }
                        else
                        {
                            AO = new rptCustomers();
                        }

                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber,Card_No,Loca,LocaName  FROM CRM_Customer ORDER BY Cus_Code", "CRM_Customer");
                            report.DisplayReport(AO, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }}, "Customer Details");

                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber,Card_No,Loca,LocaName  FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') ORDER BY Cus_Code", "CRM_Customer");
                            report.DisplayReport(AO, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                        #endregion

                    case 13:
                        #region Customer Details Report  CARD wise

                        CrystalDecisions.CrystalReports.Engine.ReportDocument CARD;
                        if (chkWithMoreDetails.Checked)
                        {
                            CARD = new rptCustomer();
                        }
                        else
                        {
                            CARD = new rptCustomers();
                        }

                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName  FROM CRM_Customer ORDER BY Card_No", "CRM_Customer");
                            report.DisplayReport(CARD, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" }, 
                                            { "CodeTo", "All" }}, "Customer Details");

                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName  FROM CRM_Customer WHERE (Card_No BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') ORDER BY Card_No", "CRM_Customer");
                            report.DisplayReport(CARD, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" }, 
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                        #endregion

                    case 14:
                        Category = "(Cust_Category LIKE '%')";

                        if (cmbCategory.Text.Trim() != "All")
                        {
                            Category = "(Cust_Category = '" + cmbCategory.Text.Trim() + "')";
                        }

                        if (chkAllLoca.Checked == true)
                        {
                            main.dataset = main.getDataSet("SELECT PCP.Cust_Code, PCP.Receipt_No, CONVERT(DATETIME,PCP.BillDate+ ' ' +PCP.BillTime,103) [BillDate], PCP.ActualBillAmt, PCP.Points [Earn], PCP.Readeem [Redeem], PCP.Unit, C.Cus_Name,Location.Loca_Descrip AS LocaName,Card_No FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code INNER JOIN Location ON Location.Loca = PCP.Loca WHERE CONVERT(DATETIME,PCP.BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) AND " + Category + " ORDER BY PCP.Cust_Code", "Statement");
                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT PCP.Cust_Code, PCP.Receipt_No, CONVERT(DATETIME,PCP.BillDate+ ' ' +PCP.BillTime,103) [BillDate], PCP.ActualBillAmt, PCP.Points [Earn], PCP.Readeem [Redeem], PCP.Unit, C.Cus_Name,Location.Loca_Descrip AS LocaName,Card_No FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer C ON PCP.Cust_Code = C.Cus_Code INNER JOIN Location ON Location.Loca = PCP.Loca WHERE CONVERT(DATETIME,PCP.BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text + "',103) And (PCP.Loca = '" + txtLocaCode.Text.Trim() + "') AND " + Category + " ORDER BY PCP.Cust_Code", "Statement");
                        }
                        report.DisplayReport(new rptDailyEarnRedeemPoint_LocaWise(), main.dataset, "Customer Point Earned/Redeemed Report", "Daily Point Earned/Redeemed Report");
                        break;

                    case 17:
                        #region Tour Guide Details Report
                        if (chkAllLoca.Checked == true)
                        {
                            if (chkAll.Checked)
                            {
                                main.dataset = main.getDataSet("SELECT Cus_Code AS Cus_No,Cus_Name ,Receipt_No,BillDate,BillAmount,Disc_Rate,BFBalance,Points,Readeem,Balance,Unit ,Pos_CustomerPoints.Loca,Card_No FROM Pos_CustomerPoints  INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code WHERE Cust_Category = 'Tourist guide' AND  CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103)  AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)", "dsTourGuide");
                                report.DisplayReport(new rptTourGuideCustomerDetails(), main.dataset, "Tour Guide Details Report",
                             new string[,] {    { "ReportHeader", "TOUR GUIDE COMMISSION DETAILS" },
                                            { "CodeFrom", "All" },
                                            { "CodeTo", "All" },
                                            { "FieldsHeader", "Tour Guide Code & Name" } }, "");
                            }
                            else
                            {
                                main.dataset = main.getDataSet("SELECT Cus_Code AS Cus_No,Cus_Name ,Receipt_No,BillDate,BillAmount,Disc_Rate,BFBalance,Points,Readeem,Balance,Unit ,Pos_CustomerPoints.Loca,Card_No FROM Pos_CustomerPoints  INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code WHERE Cust_Category = 'Tourist guide' AND Cus_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103)  AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ", "dsTourGuide");
                                report.DisplayReport(new rptTourGuideCustomerDetails(), main.dataset, "Department Details Report",
                                 new string[,] {
                                            { "ReportHeader", "TOUR GUIDE COMMISSION DETAILS" },
                                            { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "FieldsHeader", "Tour Guide Code & Name" } }, "");
                            }
                        }
                        else
                        {
                            if (chkAll.Checked)
                            {
                                main.dataset = main.getDataSet("SELECT Cus_Code AS Cus_No,Cus_Name ,Receipt_No,BillDate,BillAmount,Disc_Rate,BFBalance,Points,Readeem,Balance,Unit ,Pos_CustomerPoints.Loca FROM Pos_CustomerPoints  INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code WHERE Pos_CustomerPoints.Loca = '"+txtLocaCode.Text.Trim()+"' AND Cust_Category = 'Tourist guide' AND  CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103)  AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103)", "dsTourGuide");
                                report.DisplayReport(new rptTourGuideCustomerDetails(), main.dataset, "Tour Guide Details Report",
                             new string[,] {    { "ReportHeader", "TOUR GUIDE COMMISSION DETAILS" },
                                            { "CodeFrom", "All" },
                                            { "CodeTo", "All" },
                                            { "FieldsHeader", "Tour Guide Code & Name" } }, "");
                            }
                            else
                            {
                                main.dataset = main.getDataSet("SELECT Cus_Code AS Cus_No,Cus_Name ,Receipt_No,BillDate,BillAmount,Disc_Rate,BFBalance,Points,Readeem,Balance,Unit ,Pos_CustomerPoints.Loca FROM Pos_CustomerPoints  INNER JOIN CRM_Customer ON Pos_CustomerPoints.Cust_Code = CRM_Customer.Cus_Code WHERE Pos_CustomerPoints.Loca = '" + txtLocaCode.Text.Trim() + "' AND Cust_Category = 'Tourist guide' AND Cus_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103)  AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ", "dsTourGuide");
                                report.DisplayReport(new rptTourGuideCustomerDetails(), main.dataset, "Department Details Report",
                                 new string[,] {
                                            { "ReportHeader", "TOUR GUIDE COMMISSION DETAILS" },
                                            { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "FieldsHeader", "Tour Guide Code & Name" } }, "");
                            }
                        }
                        

                        break;
                    #endregion

                    case 21:
                        #region Customer Details Report

                        CrystalDecisions.CrystalReports.Engine.ReportDocument r17;
                        r17 = new rptCustomers();
                        
                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code + ' - ' + Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName,Cust_Category FROM CRM_Customer WHERE /*(Loca = '" + txtLocaCode.Text.Trim() + "') AND*/  (Cust_Category = 'Tourist guide') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r17, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" },
                                            { "CodeTo", "All" }}, "Customer Details");

                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code + ' - ' + Cus_Name [Cus_Name], REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,Cust_Category FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') AND  (Cust_Category = 'Tourist guide') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r17, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                    #endregion

                    case 22:
                        CrystalDecisions.CrystalReports.Engine.ReportDocument r22;
                        
                        r22 = new rptCustomersReligion();
                        

                        if (chkAll.Checked)
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name , REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,LocaName, Cust_Category, Religion FROM CRM_Customer WHERE /*(Loca = '" + txtLocaCode.Text.Trim() + "') AND */ (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r22, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "All" },
                                            { "CodeTo", "All" }}, "Customer Details");

                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT Cus_Code , Cus_Name, REPLACE(Address1 ,',',',')+'\r\n'+ REPLACE(Address2 ,',',',')+'\r\n'+ REPLACE(Address3 ,',',',')+'\r\n'+ REPLACE(Address4 ,',',',')+'\r\n'+ REPLACE(Address5 ,',',',') [Address1], PhoneNo, Fax, OfficePhone, Other, Mobile, E_mail, Birthday, Referance, InsertDate, Cus_Type, NICNumber ,Card_No,Loca,Cust_Category, Religion FROM CRM_Customer WHERE (Cus_Code BETWEEN  '" + txtCodeFrom.Text.Trim() + "' AND  '" + txtCodeTo.Text.Trim() + "') AND  (Cust_Category = 'Loyalty customer') ORDER BY Cus_Name", "CRM_Customer");
                            report.DisplayReport(r22, main.dataset, "Customer Details Report",
                            new string[,] { { "CodeFrom", "" + txtCodeFrom.Text.Trim() + "" },
                                            { "CodeTo", "" + txtCodeFrom.Text.Trim() + "" } }, "Customer Details");
                        }
                        break;

                    case 23:
                        if (chkAllLoca.Checked == true)
                        {
                            main.dataset = main.getDataSet("SELECT '" + txtLocaCode.Text.Trim() + " " + txtLocaName.Text.Trim() + "' LocaName, 'All Customer' CodeFrom, '" + dtDateFrom.Text.Trim() + "' DateFrom, '" + dtDateTo.Text.Trim() + "' DateTo,Loca,BillDate, Unit, Receipt_No, CONVERT(VARCHAR,ReportID) ReportID, -Amount Amount, Dis, Discount BillAmount, Customer, UserName, Item_Descrip DiscType FROM DayEnd_Pos_Transaction WHERE Iid='005' AND Item_Descrip IN ('LOYALTY DISCOUNT','CRM PROMOTION','CRM DISCOUNT') AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) ORDER BY CONVERT(DATETIME,BillDate,103),Unit,Reportid,Receipt_No", "dsCRMPromo");
                        }
                        else
                        {
                            main.dataset = main.getDataSet("SELECT '" + txtLocaCode.Text.Trim() + " " + txtLocaName.Text.Trim() + "' LocaName, 'All Customer' CodeFrom, '" + dtDateFrom.Text.Trim() + "' DateFrom, '" + dtDateTo.Text.Trim() + "' DateTo,Loca,BillDate, Unit, Receipt_No, CONVERT(VARCHAR,ReportID) ReportID, -Amount Amount, Dis, Discount BillAmount, Customer, UserName, Item_Descrip DiscType FROM DayEnd_Pos_Transaction WHERE Iid='005' AND Item_Descrip IN ('LOYALTY DISCOUNT','CRM PROMOTION','CRM DISCOUNT') AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'" + dtDateFrom.Text.Trim() + "',103) AND CONVERT(DATETIME,'" + dtDateTo.Text.Trim() + "',103) AND Loca='" + txtLocaCode.Text.Trim() + "' ORDER BY CONVERT(DATETIME,BillDate,103),Unit,Reportid,Receipt_No", "dsCRMPromo");
                        }
                        report.DisplayReport(new rptCrmPromo(), main.dataset, "CRM Customer Discount Report");
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

        void VisibleTF(Control [] contT, Control [] contF)
        {
            for (int i = 0; i < contT.Length; i++)
            {
                contT[i].Visible = true;
                contT[i].TabIndex = i;
            }
            for (int i = 0; i < contF.Length; i++)
            {
                contF[i].Visible = false;
            }
        }

        void ReportObjectVisible(bool lbldatefrom, bool dtdatefrom, bool lbldateto, bool dtdateto, bool lblrecord, bool txtcodefrom, bool txtcodename, bool chkall )
        {
            lblDatefrom.Visible = lbldatefrom; 
            dtDateFrom.Visible = dtdatefrom; 
            lblDateTo.Visible = lbldateto;
            dtDateTo.Visible = dtdateto;
            lblRecord.Visible = lblrecord;
            txtCodeFrom.Visible = txtcodefrom;
            txtCodeFromName.Visible = txtcodename;
            chkAll.Visible = chkall;
        }

        private void frmReportOption_Load(object sender, EventArgs e)
        {
            switch (switchs)
            {
                case 3: // Customer Prescription Details
                case 2: // Daily Order Details
                    plOrderDetailsDoc.Visible = true;
                    btnCusSearch.Visible = false;
                    break;

                case 4: // Due Date Order Details
                    plOrderDetailsDoc.Visible = true;
                    ReportObjectVisible(true, true, false, false, false, false, false, false);
                    btnCusSearch.Visible = false;
                    lblDatefrom.Text = "Due Date";

                    break;

                case 5: // Customer Transaction
                    plOrderDetailsDoc.Visible = true;
                    ReportObjectVisible(false, false, false, false, true, true, true, false);
                    chkAddressLable.Visible = false;
                    this.Size = new System.Drawing.Size(472, 126);
                    btnCusSearch.Visible = false;
                    break;

                case 18:

                    txtLocaCode.Visible = true;
                    txtLocaName.Visible = true;
                    btnLocaSearch.Visible = true;
                    lblLoca.Visible = true;

                    txtLocaCode.Enabled = true;
                    txtLocaName.Enabled = true;

                    txtCodeFrom.Enabled = true;
                    txtCodeFromName.Enabled = true;

                    txtCodeTo.Enabled = true;
                    txtCodeToName.Enabled = true;

                    dtDateFrom.Visible = true;
                    dtDateTo.Visible = true;

                    lblDatefrom.Visible = true;
                    lblDateTo.Visible = true;

                    btnCusSearch.Visible = true;
                    btnCustToSearch.Visible = true;

                    cmbCategory.Visible = false;
                    plOrderDetailsDoc.Visible = true;

                    lblCategory.Visible = false;
                    chkAllLoca.Checked = false;
                    chkAll.Checked = false;
                    chkAllLoca.Visible = true;

                    break;

                case 16:
                case 9: // Customer Details Report                
                case 22:
                    txtLocaCode.Visible = false;
                    txtLocaName.Visible = false;
                    btnLocaSearch.Visible = false;
                    lblLoca.Visible = false;
                    dtDateFrom.Visible = false;
                    dtDateTo.Visible = false;
                    btnCusSearch.Visible = true;
                    btnCustToSearch.Visible = true;
                    plOrderDetailsDoc.Visible = true;

                    lblDatefrom.Visible = false;
                    lblDateTo.Visible = false;
                    chkAllLoca.Visible = false;
                    chkAll.Visible = true;
                  
                    break;
                case 17:
                    txtLocaCode.Visible = true;
                    txtLocaName.Visible = true;
                    btnLocaSearch.Visible = true; 
                    lblLoca.Visible = true;
                    dtDateFrom.Visible = true;
                    dtDateTo.Visible = true;
                    btnCusSearch.Visible = true;
                    btnCustToSearch.Visible = true;
                    plOrderDetailsDoc.Visible = true;

                    lblDatefrom.Visible = true;
                    lblDateTo.Visible = true;
                    chkAllLoca.Visible = true;
                    chkAll.Visible = true;

                    break;

                case 20:

                    txtLocaCode.Visible = true;
                    txtLocaName.Visible = true;
                    btnLocaSearch.Visible = true;
                    lblLoca.Visible = true;
                    dtDateFrom.Visible = true;
                    dtDateTo.Visible = true;
                    btnCusSearch.Visible = true;
                    btnCustToSearch.Visible = true;
                    plOrderDetailsDoc.Visible = true;
                    lblDatefrom.Visible = false;
                    lblDateTo.Visible = false;

                    chkAllLoca.Visible = true; chkAll.Visible = true;
                    break;

                case 24:

                    txtLocaCode.Visible = true;
                    txtLocaName.Visible = true;
                    btnLocaSearch.Visible = true;
                    chkAllLoca.Visible = true;
                    lblLoca.Visible = true;

                    dtDateFrom.Visible = true;
                    dtDateTo.Visible = true;

                    btnCusSearch.Visible = true;
                    btnCustToSearch.Visible = true;

                    plOrderDetailsDoc.Visible = true;
                    lblDatefrom.Visible = true;
                    lblDateTo.Visible = true;
                    dtDateFrom.Visible = true;
                    dtDateTo.Visible = true;

                    chkAll.Visible = true;

                    break;

                case 12: // Customer Details Report A/O wise
                case 13: // Customer Details Report Card wise
                    dtDateFrom.Visible = false;
                    dtDateTo.Visible = false;
                    btnCusSearch.Visible = true;
                    btnCustToSearch.Visible = true;
                    chkWithMoreDetails.Visible = false;
                    plOrderDetailsDoc.Visible = true;
                    lblDatefrom.Visible = false;
                    lblDateTo.Visible = false;
                    break;
                
                
                case 8: // Brand Details Report
                case 7: // Category Details Report
                case 6: // Department Details Report
                    plOrderDetailsDoc.Visible = true;
                    //ReportObjectVisible(false, false, false, false, true, true, true, true);
                    VisibleTF(new Control[] { lblRecord, txtCodeFrom, txtCodeFromName, chkAll, chkWithMoreDetails }, new Control[] { lblDatefrom, dtDateFrom, lblDateTo, dtDateTo });
                    //this.Size = new System.Drawing.Size(482, 137);

                    break;

                case 10:// Cancel Customer Report
                case 15:
                    VisibleTF(new Control[] { lblDatefrom, dtDateFrom, lblDateTo, dtDateTo, plOrderDetailsDoc }, new Control[] { lblRecord, txtCodeFrom, txtCodeFromName, chkAll, chkWithMoreDetails, panel1, label1, txtCodeTo, txtCodeToName });
                    //this.Size = new System.Drawing.Size(500, 253);
                    lblCategory.Visible = true; cmbCategory.Visible = true;
                    LoadCustomerCategory();
                    break;

                case 14:// 
                case 23:
                    VisibleTF(new Control[] { lblDatefrom, dtDateFrom, lblDateTo, dtDateTo, plOrderDetailsDoc }, new Control[] { lblRecord, txtCodeFrom, txtCodeFromName, chkAll, chkWithMoreDetails, panel1, label1, txtCodeTo, txtCodeToName });
                    txtLocaCode.Visible = true; txtLocaName.Visible = true; btnLocaSearch.Visible = true; lblLoca.Visible = true;
                    chkAllLoca.Visible = true; 
                    this.Size = new System.Drawing.Size(600, 253);
                    lblCategory.Visible = true; cmbCategory.Visible = true;
                    LoadCustomerCategory();
                    break;

                default:
                    break;
            }
        }

        private void LoadCustomerCategory()
        {
            DataSet dsCustCat = main.getDataSet("SELECT Category FROM CRM_CustCategory");
            dsCustCat.Tables[0].Rows.Add("All");
            cmbCategory.DataSource = dsCustCat.Tables[0];
            cmbCategory.DisplayMember = "Category";

            //cmbCategory.Items.Add("All");
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            txtCodeFrom.Enabled = !Convert.ToBoolean(chkAll.Checked);
            txtCodeFromName.Enabled = !Convert.ToBoolean(chkAll.Checked);

            txtCodeTo.Enabled = !Convert.ToBoolean(chkAll.Checked);
            txtCodeToName.Enabled = !Convert.ToBoolean(chkAll.Checked);
        }

        private void frmReportOption_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && txtCodeFrom.Focused == true && switchs == 6)
                {

                } 
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            
        }

        private void txtCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCodeFrom.Text != string.Empty)
            {
                try
                {
                    switch (switchs)
                    {
                        case 9: // Customer Details Report
                        case 5: // Customer Transaction Details
                        case 3: // Customer Prescription Details
                        case 20:
                            #region
                            main.Reader = main.getReader("SELECT Cus_Code [Code], Cus_Name [Name] FROM CRM_Customer WHERE Cus_Code = '" + txtCodeFrom.Text.Trim() + "'");
                            break;
                            #endregion

                        case 6: // Department Details Report
                            #region
                            main.Reader = main.getReader("SELECT Depa_Code [Code] , Depa_Name [Name] FROM Department WHERE Depa_Code = '" + txtCodeFrom.Text.Trim() + "'");
                            break;
                            #endregion

                        case 7: // Category Details Report
                            #region
                            main.Reader = main.getReader("SELECT Cat_Code [Code] , Cat_Name [Name] FROM Category WHERE Cat_Code = '" + txtCodeFrom.Text.Trim() + "'");
                            break;
                            #endregion

                        case 8: // Brand Details Report
                            #region
                            main.Reader = main.getReader("SELECT Brand_Code [Code] , Brand_Name [Name] FROM Brand WHERE Brand_Code = '" + txtCodeFrom.Text.Trim() + "'");
                            break;
                            #endregion

                        default:
                            break;


                    }
                    if (main.Reader.Read())
                    {
                        txtCodeFrom.Text = main.Reader["Code"].ToString();
                        txtCodeFromName.Text = main.Reader["Name"].ToString();

                        txtCodeTo.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
                finally
                {
                    main.CloseReaderAndConnection();
                }
            }
        }

        private void btnCusSearch_Click(object sender, EventArgs e)
        { 
            try
            {

                switch (switchs)
                {
                    case 17:
                    case 9:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeFrom.Text.Trim() != string.Empty && txtCodeFromName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCodeFrom.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeFrom.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeFrom.Text.Trim() + "%')) AND (Cust_Category <> 'Tourist guide') /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/ ORDER BY Cus_Code");
                        }
                        else if (txtCodeFrom.Text.Trim() == string.Empty && txtCodeFromName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Name LIKE '" + txtCodeFromName.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeFrom.Text.Trim() + "%')) AND (Cust_Category <> 'Tourist guide') /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/  ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],NICNumber [NIC] FROM CRM_Customer WHERE (Cust_Category <> 'Tourist guide') /*(Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/ ORDER BY Cus_Code");
                        }
                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
                        break;

                    case 16:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeFrom.Text.Trim() != string.Empty && txtCodeFromName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCodeFrom.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeFrom.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeFrom.Text.Trim() + "%')) AND (Cust_Category = 'Tourist guide') /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/ ORDER BY Cus_Code");
                        }
                        else if (txtCodeFrom.Text.Trim() == string.Empty && txtCodeFromName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Name LIKE '" + txtCodeFromName.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeFrom.Text.Trim() + "%')) AND  (Cust_Category = 'Tourist guide') /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/  ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],NICNumber [NIC] FROM CRM_Customer WHERE /*(Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/  (Cust_Category = 'Tourist guide') ORDER BY Cus_Code");
                        }
                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
                        break;

                    case 20: 
                    case 22:
                    case 24:
                    case 18:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeFrom.Text.Trim() != string.Empty && txtCodeFromName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCodeFrom.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeFrom.Text.Trim() + "%')) AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                        }
                        else if (txtCodeFrom.Text.Trim() == string.Empty && txtCodeFromName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCodeFromName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')  ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],NICNumber [NIC] FROM CRM_Customer WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                        }

                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
                        break;

                    case 11:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeFrom.Text.Trim() != string.Empty && txtCodeFromName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Loca");
                        }
                        else if (txtCodeFrom.Text.Trim() == string.Empty && txtCodeFromName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca_Descrip LIKE '%" + txtCodeFromName.Text.Trim() + "%' ORDER BY Loca");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location ORDER BY Loca");
                        }
                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
                        break;

                    case 12:

                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
                        break;

                    case 13:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeFrom.Text.Trim() != string.Empty && txtCodeFromName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Card_No [Card Number], Cus_Name AS [Name]  FROM CRM_Customer WHERE Card_No LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Card_No");
                        }
                        else if (txtCodeFrom.Text.Trim() == string.Empty && txtCodeFromName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Card_No [Card Number], Cus_Name AS [Name]  FROM CRM_Customer WHERE Cus_Name LIKE '%" + txtCodeFromName.Text.Trim() + "%' ORDER BY Card_No");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Card_No [Card Number], Cus_Name AS [Name]  FROM CRM_Customer ORDER BY Card_No");
                        }

                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
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

        private void btnCustToSearch_Click(object sender, EventArgs e)
        {
            try
            {
                switch (switchs)
                {
                    case 17:
                    case 9:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeTo.Text.Trim() != string.Empty && txtCodeToName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Code LIKE '" + txtCodeTo.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeTo.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeTo.Text.Trim() + "%') /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/ ORDER BY Cus_Code");
                        }
                        else if (txtCodeTo.Text.Trim() == string.Empty && txtCodeToName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCodeToName.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeTo.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeTo.Text.Trim() + "%') /*AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/  ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC] FROM CRM_Customer /*WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/ ORDER BY Cus_Code");
                        }

                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeTo.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeToName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();

                        break;

                    case 16:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeTo.Text.Trim() != string.Empty && txtCodeToName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCodeTo.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeTo.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeTo.Text.Trim() + "%')) AND  (Cust_Category = 'Tourist guide') /*AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%')*/ ORDER BY Cus_Code");
                        }
                        else if (txtCodeTo.Text.Trim() == string.Empty && txtCodeToName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Name LIKE '%" + txtCodeToName.Text.Trim() + "%') OR (Card_No LIKE '" + txtCodeTo.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeTo.Text.Trim() + "%')) AND  (Cust_Category = 'Tourist guide') /*AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/  ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number],NICNumber [NIC] FROM CRM_Customer WHERE /*(Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')*/ (Cust_Category = 'Tourist guide') ORDER BY Cus_Code");
                        }

                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeTo.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeToName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();

                        break;

                    case 18:
                    case 24:
                    case 20:
                    case 22:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeTo.Text.Trim() != string.Empty && txtCodeToName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number], NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE ((Cus_Code LIKE '" + txtCodeTo.Text.Trim() + "%') OR (NICNumber LIKE '" + txtCodeTo.Text.Trim() + "%'))  AND (Loca LIKE '" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                        }
                        else if (txtCodeTo.Text.Trim() == string.Empty && txtCodeToName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name],Card_No [Card Number], NICNumber [NIC], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + txtCodeToName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%')  ORDER BY Cus_Name");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], NICNumber [NIC] FROM CRM_Customer WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code");
                        }

                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeTo.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeToName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();
                        break;

                    case 11:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeTo.Text.Trim() != string.Empty && txtCodeToName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Loca");
                        }
                        else if (txtCodeTo.Text.Trim() == string.Empty && txtCodeToName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca_Descrip LIKE '%" + txtCodeToName.Text.Trim() + "%' ORDER BY Loca");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location ORDER BY Loca");
                        }
                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeTo.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeToName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeTo.SelectAll();
                        txtCodeTo.Focus();

                        break;

                    case 12:
                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeFrom.Focus();

                        break;

                    case 13:
                        if (search.IsDisposed)
                        {
                            search = new frmCustomerSearch();
                        }
                        if (txtCodeTo.Text.Trim() != string.Empty && txtCodeToName.Text.Trim() == string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Card_No [Card Number], Cus_Name AS [Name]  FROM CRM_Customer WHERE Card_No LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Card_No");
                        }
                        else if (txtCodeTo.Text.Trim() == string.Empty && txtCodeToName.Text.Trim() != string.Empty)
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Card_No [Card Number], Cus_Name AS [Name]  FROM CRM_Customer WHERE Cus_Name LIKE '%" + txtCodeToName.Text.Trim() + "%' ORDER BY Card_No");
                        }
                        else
                        {
                            clsMainClass.SearchDataset = Main.getDataSet("SELECT Card_No [Card Number], Cus_Name AS [Name]  FROM CRM_Customer ORDER BY Card_No");
                        }
                        search.ShowDialog();
                        if (clsMainClass.Cnt_Focus != null)
                        {
                            txtCodeTo.Text = clsMainClass.Cnt_Focus.ToString();
                            txtCodeToName.Text = clsMainClass.Cnt_Descrip.ToString();
                            clsMainClass.Cnt_Focus = null;
                            clsMainClass.Cnt_Descrip = null;
                        }
                        txtCodeTo.SelectAll();
                        txtCodeTo.Focus();

                        break;

                    default:
                        break;
                }

                //search.ShowDialog();
                //if (clsMainClass.Cnt_Focus != null)
                //{
                //    txtCodeFrom.Text = clsMainClass.Cnt_Focus.ToString();
                //    txtCodeFromName.Text = clsMainClass.Cnt_Descrip.ToString();
                //    clsMainClass.Cnt_Focus = null;
                //    clsMainClass.Cnt_Descrip = null;
                //}
                //txtCodeFrom.Focus();

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmCustomerSearch();
                }

                if (txtLocaCode.Text.Trim() != string.Empty && txtLocaName.Text.Trim() == string.Empty)
                {
                    clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca LIKE '%" + txtLocaCode.Text.Trim() + "%' ORDER BY Loca");
                }
                else if (txtLocaCode.Text.Trim() == string.Empty && txtLocaName.Text.Trim() != string.Empty)
                {
                    clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca_Descrip LIKE '%" + txtLocaName.Text.Trim() + "%' ORDER BY Loca");
                }
                else
                {
                    clsMainClass.SearchDataset = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location ORDER BY Loca");
                }

                search.ShowDialog();
                if (clsMainClass.Cnt_Focus != null)
                {
                    txtLocaCode.Text = clsMainClass.Cnt_Focus.ToString();
                    txtLocaName.Text = clsMainClass.Cnt_Descrip.ToString();
                    clsMainClass.Cnt_Focus = null;
                    clsMainClass.Cnt_Descrip = null;
                }
                txtCodeFrom.Focus();

            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void chkAllLoca_CheckedChanged(object sender, EventArgs e)
        {            
            txtLocaCode.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
            txtLocaName.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
            btnLocaSearch.Enabled = !Convert.ToBoolean(chkAllLoca.Checked);
        }

        private void txtCodeFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void plOrderDetailsDoc_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}