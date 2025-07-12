using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;

using System.Runtime.InteropServices;
using System.IO;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Inventory.Properties;
namespace Inventory
{
    public partial class frmMasterDetailsInquary : Form
    {
        public int intRepOption;

        public frmMasterDetailsInquary()
        {
            InitializeComponent();
        }

        frmSearch search = new frmSearch();

        clsMasterDetailsInquary objMasterDetails = new clsMasterDetailsInquary();
        //SQLDataManagement objDataManagement = new SQLDataManagement();

        string StockQry = "";
        private string strQuery;

        private static frmMasterDetailsInquary masterDetInquary;

        public static frmMasterDetailsInquary GetMasterDetailsInquary
        {
            get { return masterDetInquary; }
            set { masterDetInquary = value; }
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
                    case 89:
                        //Product Serial Stock Issue & Receieved Detail Report
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P WHERE  SerialAllow =1 AND P.Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1 AND P.Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1  ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 75:
                    case 1://Deaprtment select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department WHERE Dept_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department ORDER BY Code";
                            }
                        }
                        break;

                    case 76:
                    case 2:
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category WHERE Cat_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category WHERE Cat_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category ORDER BY Code";
                            }
                        }
                        break;

                    case 78:
                    case 79:
                    case 74://Product select for the Location Stock
                    case 73://Product select for the search
                    case 3:
                    case 83:
                    
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
                    case 4://Customer select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'WSL' AND Cust_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'WSL' AND Cust_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'WSL' ORDER BY Cust_Code";
                            }
                        }
                        break;

                    case 77:
                    case 5://Supplier select for the search
                    case 84: 
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_Code AS Code, Supp_Name AS Name FROM Supplier WHERE  Supp_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_Code AS Code, Supp_Name AS Name FROM Supplier WHERE  Supp_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Supp_Code AS Code, Supp_Name AS Name FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 6://Brand select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name WHERE  Supp_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code";
                            }
                        }
                        break;
                    case 7://Product select for the Packeting Product
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') GROUP BY Prod_Code, Prod_Name ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') GROUP BY Prod_Code, Prod_Name ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails GROUP BY Prod_Code, Prod_Name ORDER BY Code";
                            }
                        }
                        break;
                    case 8://salesman Details
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "select Sale_Code Code, Sale_Name [Salesman Name] from tb_salesman WHERE (Sale_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_salesman WHERE (Sale_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_salesman ORDER BY Code";
                            }
                        }
                        break;
                    case 86://salesman Details
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "select Sale_Code Code, Sale_Name [Salesman Name] from tb_Technician WHERE (Sale_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_Technician WHERE (Sale_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_Technician ORDER BY Code";
                            }
                        }
                        break;

                    case 9://Deaprtment select for the search
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
                    case 10://Customer select for the search
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'RGL' AND Cust_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'RGL' AND Cust_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE  Iid = 'RGL' ORDER BY Cust_Code";
                            }
                        }
                        break;

                    case 11://Deaprtment select for the search
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
                    case 87: // product serial stock datail report
                        if(txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P WHERE  SerialAllow =1 AND P.Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if(txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1 AND P.Prod_Name LIKE '%"+txtDescriptionFrom.Text.Trim()+"%' ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1  ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 85:
                    case 50://stock productwise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;

                    case 51://stock locationwise
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
                    case 52://stock Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Cat_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE AND Cat_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Cat_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category ORDER BY Cat_Code ";
                            }
                        }
                        break;

                    case 53://Brand Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code ";
                            }
                        }
                        break;

                    case 54://Supplier select for the search
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

                    case 55://Deaprtment select for the search
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
                    case 56://stock Category-wise
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

                    case 57://Brand Category-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code ";
                            }
                        }
                        break;

                    case 58://Supplier select for the search
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

                    case 59://stock Valuation productwise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code [Code],Prod_Name [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code [Code],Prod_Name [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code [Code],Prod_Name [Product Name] FROM Product ORDER BY Prod_Code";
                            }
                        }
                        break;

                    case 60://Deaprtment select for the search
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
                    case 88: // stock category -wise (Disributed price) 
                    case 61://stock Category-wise
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
                    case 62://Supplier select for the search
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

                    case 63://Brand-wise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code like '%" + txtCodeFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name like '%" + txtDescriptionFrom.Text.Trim() + "%' ORDER BY Brand_Code ";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code ";
                            }
                        }
                        break;
                    case 64://stock productwise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 65://stock productwise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 66://stock productwise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 67://Supplier select for the search
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

                    case 82:
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%') AND Loose=1 ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%') AND Loose=1  ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE Loose=1 ORDER BY Code";
                            }
                        }
                        break;

                    case 68://stock Valuation productwise
                        if (txtCodeFrom.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code [Code],Prod_Name [Product Name] FROM Product WHERE Prod_Code LIKE '%" + txtCodeFrom.Text.Trim() + "%'ORDER BY Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionFrom.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code [Code],Prod_Name [Product Name] FROM Product WHERE Prod_Name LIKE '%" + txtDescriptionFrom.Text.Trim() + "%'ORDER BY Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code [Code],Prod_Name [Product Name] FROM Product ORDER BY Prod_Code";
                            }
                        }
                        break;

                    case 69://Supplier select for the search
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
                    case 70://Deaprtment select for the search
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
                    case 71://Supplier select for the search
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
                    case 72://Supplier select for the search
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmMasterDetailsInquary_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                masterDetInquary = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //if (txtCodeFrom.Text != string.Empty)
                //{
                //    txtCodeTo.Focus();
                //}
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //MainClass.mdi.Cursor = Cursors.WaitCursor;
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                switch (intRepOption)
                {
                    case 89:
                        //Product Serial Stock Issue & Receieved Detail Report
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P WHERE  SerialAllow =1 AND P.Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1 AND P.Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1  ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 75:
                    case 1://Deaprtment select for the search
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

                    case 76:
                    case 2:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category WHERE Cat_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category WHERE Cat_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category ORDER BY Code";
                            }
                        }
                        break;
                    case 82:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') AND Loose=1 ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') AND Loose=1  ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE Loose=1 ORDER BY Code";
                            }
                        }
                        break;
                    case 78:
                    case 79:
                    case 74://Product select for the Location Stock
                    case 73:
                    case 3:
                    case 83:
                    
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 4://Customer select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'WSL' AND Cust_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'WSL' AND Cust_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'WSL' ORDER BY Cust_Code";
                            }
                        }
                        break;
                    case 77:
                    case 5://Supplier select for the search
                    case 84: 
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Supp_Code AS Code, Supp_Name AS Name FROM Supplier WHERE  Supp_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Supp_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Supp_Code AS Code, Supp_Name AS Name FROM Supplier WHERE  Supp_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Supp_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Supp_Code AS Code, Supp_Name AS Name FROM Supplier ORDER BY Supp_Code";
                            }
                        }
                        break;
                    case 6://Brand select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Brand_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand WHERE  Brand_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Brand_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Brand_Code AS Code, Brand_Name AS Name FROM Brand ORDER BY Brand_Code";
                            }
                        }
                        break;
                    case 7://Product select for the Packeting Product
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') GROUP BY Prod_Code, Prod_Name ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails WHERE (Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') GROUP BY Prod_Code, Prod_Name ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails GROUP BY Prod_Code, Prod_Name ORDER BY Code";
                            }
                        }
                        break;

                    //case 7:
                    //    if (txtCodeTo.Text.Trim() != string.Empty)
                    //    {
                    //        strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                    //    }
                    //    else
                    //    {
                    //        if (txtDescriptionTo.Text != string.Empty)
                    //        {
                    //            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails WHERE (Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                    //        }
                    //        else
                    //        {
                    //            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM tbPacketProductDetails ORDER BY Code";
                    //        }
                    //    }
                    //    break;
                    case 8://salesman Details
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "select Sale_Code Code, Sale_Name [Salesman Name] from tb_salesman WHERE (Sale_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_salesman WHERE (Sale_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_salesman ORDER BY Code";
                            }
                        }
                        break;
                    case 86://salesman Details
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "select Sale_Code Code, Sale_Name [Salesman Name] from tb_Technician WHERE (Sale_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_Technician WHERE (Sale_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Sale_Code Code, Sale_Name [Salesman Name] from tb_Technician ORDER BY Code";
                            }
                        }
                        break;
                    case 9:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 10://Customer select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'RGL' AND Cust_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Cust_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'RGL' AND Cust_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Cust_Code";
                            }
                            else
                            {
                                strQuery = "SELECT  Cust_Code As Code, Cust_Name As Name FROM Customer WHERE Iid = 'RGL' ORDER BY Cust_Code";
                            }
                        }
                        break;
                    case 11:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;
                    case 87: // product serial stock datail report
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P WHERE  SerialAllow =1 AND P.Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1 AND P.Prod_Name LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P  WHERE SerialAllow =1  ORDER BY P.Prod_Code";
                            }
                        }
                        break;

                    case 85:
                    case 50://Supplier select for the search
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 51://stock locationwise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY Dept_Code ";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department WHERE Dept_Name LIKE'%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Dept_Code";
                            }
                            else
                            {
                                strQuery = "SELECT Dept_Code [Department Code],Dept_Name [Department Name] FROM Department ORDER BY Dept_Code";
                            }
                        }
                        break;
                    case 52://stock Category-wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code [Category Code], Cat_Name [Category Name] FROM Category WHERE Cat_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Cat_Code ";
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
                    case 53://Brand wise
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

                    case 54://Supplier select for the search
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

                    case 55://Deaprtment select for the search
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

                    case 56: //CategoryAttribute wise ItemActivation wise
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category WHERE Cat_Code LIKE '%" + txtCodeTo.Text.Trim() + "%' ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category WHERE Cat_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%' ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Cat_Code AS Code, Cat_Name AS Category FROM Category ORDER BY Code";
                            }
                        }
                        break;

                    case 57://Brand-wise
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

                    case 58://Supplier select for the search
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

                    case 59:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 60://Deaprtment select for the search
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
                    case 88: // Stock category wise (distributed price)
                    case 61://stock Category-wise
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
                    case 62://Supplier select for the search
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

                    case 63://manufacturer Category-wise
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
                    case 64://
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 65://
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 66://
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%'ORDER BY P.Prod_Code";
                            }
                            else
                            {
                                strQuery = "SELECT P.Prod_Code,P.Prod_Name FROM Product P INNER JOIN Stock_Master S ON P.Prod_code = S.Prod_code WHERE S.Loca = " + LoginManager.LocaCode + "ORDER BY P.Prod_Code";
                            }
                        }
                        break;
                    case 67://Supplier select for the search
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

                    case 68:
                        if (txtCodeTo.Text.Trim() != string.Empty)
                        {
                            strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtCodeTo.Text.Trim() + "%') ORDER BY Code";
                        }
                        else
                        {
                            if (txtDescriptionTo.Text != string.Empty)
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product WHERE (Prod_Code LIKE '%" + txtDescriptionTo.Text.Trim() + "%') ORDER BY Code";
                            }
                            else
                            {
                                strQuery = "SELECT Prod_Code AS Code, Prod_Name AS Product FROM Product ORDER BY Code";
                            }
                        }
                        break;

                    case 69://Supplier select for the search
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
                    case 70://Deaprtment select for the search
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
                    case 71://Supplier select for the search
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
                    case 72://Supplier select for the search
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //if (txtCodeTo.Text != string.Empty)
                //{
                //    btnDisplay.Focus();
                //}
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                masterDetInquary = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            MainClass.mdi.Cursor = Cursors.WaitCursor;
            ///////////////////////////
            try
            {
                if (txtCodeFrom.Text == "")
                {
                    MessageBox.Show("Enter data in order to display report", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodeFrom.Focus();
                    return;
                }
                DataSet dsDataForReport = new DataSet();
                clsReportViewer objRepView = new clsReportViewer();
                frmReportViewer objRepViewer = new frmReportViewer();
                objRepViewer.Text = this.Text;

                switch (intRepOption)
                {
                    case 86:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select Sale_Code, Sale_Name, Area_Code, Address1, Address2, Address3, Address4, Tel, Fax, Email, Sales_Target, Vehicle_No, NIC,Commision from tb_Technician WHERE Sale_Code Between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Sale_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Sale_Code, Sale_Name, Area_Code, Address1, Address2, Address3, Address4, Tel, Fax, Email, Sales_Target, Vehicle_No, NIC,Commision from tb_Technician WHERE Sale_Code Between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Sale_Name ASC";
                        }
                        objRepView.DataSetName = "dsSalesman";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSalesmanDetails();
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Technician Details";
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 1:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Department.Dept_Code, Department.Dept_Name, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Department LEFT OUTER JOIN Product on Department.Dept_Code = Product.Department_Id WHERE Dept_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Dept_Code ASC";
                            objRepView.DataSetName = "Department";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptDepartmentDetails();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Department.Dept_Code, Department.Dept_Name, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Department LEFT OUTER JOIN Product on Department.Dept_Code = Product.Department_Id WHERE Dept_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Dept_Name ASC";
                            objRepView.DataSetName = "Department";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptDepartmentDetailsDesc();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        }
                        break;

                    case 2:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Department.Dept_Code, Department.Dept_Name, category.Cat_Code, category.Cat_Name, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Category INNER JOIN Department ON Category.Dept_Code = Department.Dept_Code LEFT JOIN Product on Product.Category_Id = Category.Cat_Code WHERE Cat_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order By Department.Dept_Code, Cat_Code ASC";
                            objRepView.DataSetName = "Category";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptCategoryDetails();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Department.Dept_Code, Department.Dept_Name, category.Cat_Code, category.Cat_Name, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Category INNER JOIN Department ON Category.Dept_Code = Department.Dept_Code LEFT JOIN Product on Product.Category_Id = Category.Cat_Code WHERE Cat_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order By Cat_Name ASC";

                            objRepView.DataSetName = "Category";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptCategoryDetailsDesc();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                        }
                    case 3:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Prod_Code,Prod_Name,Purchase_Price,Selling_Price, Prod_Image, Marked_Price, LockedItem FROM Product WHERE(Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') ORDER BY Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Prod_Code,Prod_Name,Purchase_Price,Selling_Price, Prod_Image, Marked_Price, LockedItem FROM Product WHERE(Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') ORDER BY Prod_Name ASC";
                        }
                        objRepView.DataSetName = "Product";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "PRODUCT DETAILS";
                        break;

                    case 4:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT  Cust_Code Acc_Code, Cust_Name Acc_Name, Address1, Address2, Address3, Address4 City, Country, Tel Telephone, Fax, Email, Contact_Prsn, Credit_Limit, Credit_Period Period, '' BankDraft FROM customer WHERE iid = 'WSL' AND Cust_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND'" + txtCodeTo.Text.Trim() + "' ORDER BY Cust_Code ASC";

                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT  Cust_Code Acc_Code, Cust_Name Acc_Name, Address1, Address2, Address3, Address4 City, Country, Tel Telephone, Fax, Email, Contact_Prsn, Credit_Limit, Credit_Period Period, '' BankDraft FROM customer WHERE iid = 'WSL' AND Cust_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND'" + txtCodeTo.Text.Trim() + "' ORDER BY Cust_Name ASC";

                        }
                        objRepView.DataSetName = "dsAccount";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptCustomerDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 5:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT  Supplier.Supp_Code Acc_Code, Supplier.Supp_Name Acc_Name, Supplier.Address1, Supplier.Address2, Supplier.Address3, Supplier.Address4 City, '' Country, Supplier.Tel Telephone, Supplier.Fax, Supplier.Email, Supplier.Contact_Prsn, 0 Credit_Limit, Supplier.Credit_Period Period, '' BankDraft, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Supplier LEFT join Product on supplier.supp_code = product.Supplier_Id WHERE Supp_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND'" + txtCodeTo.Text.Trim() + "' ORDER BY Supp_Code";
                            objRepView.DataSetName = "dsAccount";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptSupplierDetails();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT  Supplier.Supp_Code Acc_Code, Supplier.Supp_Name Acc_Name, Supplier.Address1, Supplier.Address2, Supplier.Address3, Supplier.Address4 City, '' Country, Supplier.Tel Telephone, Supplier.Fax, Supplier.Email, Supplier.Contact_Prsn, 0 Credit_Limit, Supplier.Credit_Period Period, '' BankDraft, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Supplier LEFT join Product on supplier.supp_code = product.Supplier_Id WHERE Supp_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND'" + txtCodeTo.Text.Trim() + "' ORDER BY Supp_Name";
                            objRepView.DataSetName = "dsAccount";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptSupplierDetailsDesc();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;

                        }


                    case 6:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Brand.Brand_Code DEPT_CODE, Brand.Brand_Name DEPT_NAME, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Brand INNER JOIN Product on Product.Brand_Code = Brand.Brand_Code WHERE Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order by Brand.Brand_Code ASC";
                            objRepView.DataSetName = "Department";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptBrandDetails();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Brand.Brand_Code DEPT_CODE, Brand.Brand_Name DEPT_NAME, Product.Prod_Code, Product.Prod_Name, Product.Purchase_price, Product.Selling_Price FROM Brand INNER JOIN Product on Product.Brand_Code = Brand.Brand_Code WHERE Product.Brand_Code between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order by Brand.Brand_Name ASC";
                            objRepView.DataSetName = "Department";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptBrandDetailsDesc();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                        }


                    case 7:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT  PP.Prod_Code [Main_Prod_Code], PP.Prod_Name [Main_Prod_Name], Packet_Prod_Code [Prod_Code], Packet_Prod_Name [Prod_Name], Packet_Purchase_price [Purchase_price], Packet_Qty, P.Purchase_price [MPurchase], P.Selling_Price [MSelling] FROM tbPacketProductDetails PP INNER JOIN Product P ON PP.Prod_Code = P.Prod_Code WHERE PP.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order By Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT  PP.Prod_Code [Main_Prod_Code], PP.Prod_Name [Main_Prod_Name], Packet_Prod_Code [Prod_Code], Packet_Prod_Name [Prod_Name], Packet_Purchase_price [Purchase_price], Packet_Qty, P.Purchase_price [MPurchase], P.Selling_Price [MSelling] FROM tbPacketProductDetails PP INNER JOIN Product P ON PP.Prod_Code = P.Prod_Code WHERE PP.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order By Prod_Name ASC";
                        }
                        objRepView.DataSetName = "dsPacketingProductNote";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptPacketProductDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 8:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select Sale_Code, Sale_Name, Area_Code, Address1, Address2, Address3, Address4, Tel, Fax, Email, Sales_Target, Vehicle_No, NIC,Commision from tb_salesman WHERE Sale_Code Between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Sale_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Sale_Code, Sale_Name, Area_Code, Address1, Address2, Address3, Address4, Tel, Fax, Email, Sales_Target, Vehicle_No, NIC,Commision from tb_salesman WHERE Sale_Code Between '" + txtCodeFrom.Text.Trim() + "' and '" + txtCodeTo.Text.Trim() + "' Order By Sale_Name ASC";
                        }
                        objRepView.DataSetName = "dsSalesman";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSalesmanDetails();
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Salesman Details";
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 9:
                        if (rbByCode.Checked == true)
                        {
                            /*--------before 06/11/2013------------------
                            objRepView.SqlStatement = "SELECT P.Prod_Code,P.Prod_Name,PL.Purchase_Price, PL.Selling_Price, PL.Marked_Price, PL.Qty, PL.Price_Level FROM Product P INNER JOIN tbProductPriceLevel PL ON P.Prod_Code = PL.Prod_Code WHERE(P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') ORDER BY P.Prod_Code, PL.Qty ASC";
                            objRepView.DataSetName = "Product";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptProductPriceLevelDetails();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                             * */
                            objRepView.SqlStatement = "SELECT P.Prod_Code,P.Prod_Name,PL.Purchase_Price, PL.Selling_Price RPrice, PL.Whole_Price WPrice,PL.Price_Level DPrice , PL.Marked_Price MMPrice  FROM Product P INNER JOIN tbProductPriceLevel PL ON P.Prod_Code = PL.Prod_Code WHERE(P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') ORDER BY P.Prod_Code, PL.IDNo ASC";
                            objRepView.DataSetName = "dsPriceMasterDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptProductPriceLevelDetails2();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;
                        }
                        else
                        {/*
                            objRepView.SqlStatement = "SELECT P.Prod_Code,P.Prod_Name,PL.Purchase_Price, PL.Selling_Price, PL.Marked_Price, PL.Qty, PL.Price_Level FROM Product P INNER JOIN tbProductPriceLevel PL ON P.Prod_Code = PL.Prod_Code WHERE(P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') ORDER BY P.Prod_Name, PL.Qty ASC";
                            objRepView.DataSetName = "Product";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptProductPriceLevelDetailsDesc();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;*/

                            objRepView.SqlStatement = "SELECT P.Prod_Code,P.Prod_Name,PL.Purchase_Price, PL.Selling_Price RPrice, PL.Whole_Price WPrice,PL.Price_Level DPrice , PL.Marked_Price MMPrice  FROM Product P INNER JOIN tbProductPriceLevel PL ON P.Prod_Code = PL.Prod_Code WHERE(P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') ORDER  BY P.Prod_Name, PL.IDNo ASC";
                            objRepView.DataSetName = "dsPriceMasterDetails";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptProductPriceLevelDetails2();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                            break;

                        }


                    case 10:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT  Cust_Code Acc_Code, Cust_Name Acc_Name, Address1, Address2, Address3, Address4 City, Country, Tel Telephone, Fax, Email, Contact_Prsn, Credit_Limit, Credit_Period Period, '' BankDraft FROM customer WHERE iid = 'RGL' AND Cust_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND'" + txtCodeTo.Text.Trim() + "' ORDER BY Cust_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT  Cust_Code Acc_Code, Cust_Name Acc_Name, Address1, Address2, Address3, Address4 City, Country, Tel Telephone, Fax, Email, Contact_Prsn, Credit_Limit, Credit_Period Period, '' BankDraft FROM customer WHERE iid = 'RGL' AND Cust_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "'AND'" + txtCodeTo.Text.Trim() + "' ORDER BY Cust_Name ASC";
                        }
                        objRepView.DataSetName = "dsAccount";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptCustomerDetailsRegular();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 11:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Selling_Price, tbProductLink.Barcode, tbProductLink.Tr_Date, tbProductLink.UserName, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo FROM tbProductLink INNER JOIN Product ON tbProductLink.Prod_Code = Product.Prod_Code WHERE tbProductLink.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT product.Prod_Code, product.Prod_Name, product.Selling_Price, tbProductLink.Barcode, tbProductLink.Tr_Date, tbProductLink.UserName, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo FROM tbProductLink INNER JOIN Product ON tbProductLink.Prod_Code = Product.Prod_Code WHERE tbProductLink.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY product.Prod_Name ASC";
                        }
                        objRepView.DataSetName = "dsProductLinkTemp";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductLinkedDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 50:
                        bool ImageInRep = false;
                        if (Settings.Default.ProdImage == true && MessageBox.Show("Do you want to show Image in Report?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ImageInRep = true;
                        }
                        if ((MessageBox.Show(" Do you want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "', @CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "',@WithZero=1,@Shortname=0,@Image='" + ImageInRep + "' ";
                            }
                            else
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "', @CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "',@WithZero=1,@Shortname=1,@Image='" + ImageInRep + "'  ";
                            }

                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "' ,@CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "',@WithZero=0,@Shortname=0,@Image='" + ImageInRep + "' ";
                            }
                            else
                            {
                                objRepView.SqlStatement = "EXEC dbo.Sp_GetReport  @Report = '" + intRepOption + "',@CodeFrom = '" + txtCodeFrom.Text + "',@CodeTo = '" + txtCodeTo.Text + "',@Loca = '" + LoginManager.LocaCode + "', @Mac = '" + LoginManager.MacAddress + "',@WithZero=0,@Shortname=1,@Image='" + ImageInRep + "'  ";
                            }


                        }

                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        if (Settings.Default.ProdImage == true && ImageInRep == true)
                        {
                            objRepViewer.VirtuaReport = new rptStockProdwiseImg();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        }
                        else
                        {
                            objRepViewer.VirtuaReport = new rptStockProdwise();
                            objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        }

                        break;

                    case 51:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order by Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order by Product.Prod_Name ASC";
                            }


                        }
                        else
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order by Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order by Product.Prod_Name ASC";
                            }



                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptDepartmentStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 52:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code,Product.Barcode Supp_Name, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code,Product.Barcode Supp_Name, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }


                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Barcode Supp_Name,Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE  Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code,Product.Barcode Supp_Name, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE  Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }

                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptCategoryStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 53:

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, '' Supplier_Id, '' Supp_Name, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, '' Supplier_Id, '' Supp_Name, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                        }

                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptManufacturerStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 54:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }

                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE  Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE  Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }

                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSupplierStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 55:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }

                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }


                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptDepartmentItemStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 56:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }


                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, Product.Department_Id, Department.Dept_Name, Product.Category_Id, Category.Cat_Name, '' Supplier_Id, '' Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Category ON Product.Category_Id = Category.Cat_Code INNER JOIN Department On Product.Department_Id = Department.Dept_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }


                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptCategoryItemStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 57:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, '' Supplier_Id, '' Supp_Name, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, '' Supplier_Id, '' Supp_Name, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }


                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, '' Supplier_Id, '' Supp_Name, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, '' Supplier_Id, '' Supp_Name, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }


                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptManufacturerItemStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 58:
                        if ((MessageBox.Show("You want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }

                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Code ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "select Product.Prod_Code, Product.Prod_Name, '' Department_Id, '' Dept_Name, '' Category_Id, '' Cat_Name, Product.Supplier_Id, Supplier.Supp_Name, '' Manufacturer_Id, '' Manf_Name, Product.Purchase_price, Product.Selling_Price, Stock_Master.Qty, 'CODE FROM " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'CODE TO " + txtCodeTo.Text.Trim() + "'CodeTo from product INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id INNER JOIN stock_master ON Product.Prod_Code = stock_master.Prod_Code WHERE Stock_Master.Qty <> 0 AND stock_master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY Product.Prod_Name ASC";
                            }

                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptSupplierItemStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;
                   
                    case 59:
                       

                        if ((MessageBox.Show("Do you Want to Display with Zero Qty Product?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            StockQry = " AND dbo.Stock_Master.Qty <> 0";
                        }

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price,Product.Department_Id, Department.Dept_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price,Product.Department_Id, Department.Dept_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "'  " + StockQry + " ORDER BY Product.Prod_Name ASC";
                        }

                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockValProdwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 60:                   

                        if ((MessageBox.Show("Do you Want to Display with Zero Qty Product?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            StockQry = " AND dbo.Stock_Master.Qty <> 0";
                        }

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Department_Id, Department.Dept_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + "  ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Department_Id, Department.Dept_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Department ON Department.Dept_Code = Product.Department_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + "  ORDER BY Product.Prod_Name ASC";
                        }


                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockValDeptwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 61:

                        if ((MessageBox.Show("Do you Want to Display with Zero Qty Product?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            StockQry = " AND dbo.Stock_Master.Qty <> 0";
                        }

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Category_Id, Category.Cat_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Category_Id, Category.Cat_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + "  ORDER BY Product.Prod_Name ASC";
                        }


                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockValCatwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 62:

                        if ((MessageBox.Show("Do you Want to Display with Zero Qty Product?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            StockQry = " AND dbo.Stock_Master.Qty <> 0";
                        }

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Supplier_Id, Supplier.Supp_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Supplier_Id, Supplier.Supp_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Supplier ON Supplier.Supp_Code = Product.Supplier_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Name ASC";
                        }



                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockValSuppwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 63:

                        if ((MessageBox.Show("Do you Want to Display with Zero Qty Product?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            StockQry = " AND dbo.Stock_Master.Qty <> 0";
                        }

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code  WHERE Stock_Master.Qty >0 AND Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.Selling_Price, Product.Brand_Code Manufacturer_Id, Brand.Brand_Name Manf_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Brand ON Brand.Brand_Code = Product.Brand_Code  WHERE Stock_Master.Qty >0 AND Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Brand_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Name ASC";
                        }



                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockValManuwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 64:    // Zero Stock Report

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Qty = 0 AND S.Op_St = 1 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Qty = 0 AND S.Op_St = 1 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name ASC";
                        }

                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockZeroProdwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 65:    // Minus Stock Report

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Qty < 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Qty < 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name ASC";
                        }


                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockMinusProdwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 66:    // Opening Stock Report

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty , S.Opening_Stock, L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Opening_Stock > 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty , S.Opening_Stock, L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Opening_Stock > 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name ASC";
                        }


                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptOpeningStockProdwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 67:    // Minus Stock Report

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty , P.Supplier_Id, SP.Supp_Name , L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Supplier SP ON P.Supplier_Id = SP.Supp_Code WHERE S.Qty < 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty , P.Supplier_Id, SP.Supp_Name , L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Supplier SP ON P.Supplier_Id = SP.Supp_Code WHERE S.Qty < 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name ASC";
                        }



                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockMinusSuppwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 68:    // Product To be Return details

                        objRepView.SqlStatement = "select T.Doc_No, T.Post_Date, T.Prod_Code, T.Prod_Name, Sum(T.Phy_Qty) Qty, T.Purchase_Price, P.Supplier_Id, S.Supp_Name, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo from transaction_details T INNER JOIN Product P ON T.Prod_Code = P.Prod_Code INNER JOIN Supplier S ON P.Supplier_Id = S.Supp_Code where (P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND T.Bin_Id = 'F' AND T.Phy_Qty > 0 AND iid = 'TOR' Group by T.Doc_No, T.Post_Date, T.Prod_Code, T.Prod_Name, T.Purchase_Price,P.Supplier_Id, S.Supp_Name ORDER BY CONVERT(DATETIME,T.Post_Date,103) DESC";
                        objRepView.DataSetName = "dsProductToBeReturn";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductToBeReturn();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    //case 69:    // Product To be Return details
                    //    objRepView.SqlStatement = "select T.Doc_No, T.Post_Date, T.Prod_Code, T.Prod_Name, Sum(T.Phy_Qty) Qty, T.Purchase_Price, P.Supplier_Id, S.Supp_Name, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo from transaction_details T INNER JOIN Product P ON T.Prod_Code = P.Prod_Code INNER JOIN Supplier S ON P.Supplier_Id = S.Supp_Code where (P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND T.Bin_Id = 'F' AND T.Phy_Qty > 0 AND iid = 'TOR' Group by T.Doc_No, T.Post_Date, T.Prod_Code, T.Prod_Name, T.Purchase_Price,P.Supplier_Id, S.Supp_Name ORDER BY CONVERT(DATETIME,T.Post_Date,103) DESC";
                    //    objRepView.DataSetName = "dsProductToBeReturn";
                    //    objRepView.RetrieveData();
                    //    dsDataForReport = objRepView.TempResultSet;
                    //    rptProductToBeReturnSupp ProductToBeReturnSupp = new rptProductToBeReturnSupp();
                    //    ProductToBeReturnSupp
                    //    objRepViewer.crystalReportViewer1.ReportSource = ProductToBeReturnSupp;
                    //    break;

                    case 70:    // Product To be Return details
                        objRepView.SqlStatement = "SELECT S.Prod_Code, P.Prod_Name, P.Department_Id, D.Dept_Name, SS.Qty St_Qty, S.Qty SR_Qty, S.ROL, S.RO_Qty, P.Department_Id, D.Dept_Name, '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo FROM stock_master S INNER JOIN Product P ON P.Prod_Code = S.Prod_Code INNER JOIN stock_master SS ON SS.Prod_Code = S.Prod_Code INNER JOIN Department D ON P.Department_Id = D.Dept_Code where (P.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND SS.Loca = '01' AND S.Loca = '" + LoginManager.LocaCode + "' AND (S.ROL > S.Qty) AND SS.Qty > 0 AND S.ROL >0";
                        objRepView.DataSetName = "dsProductReq";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductRequesting();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 71:    // Zero Stock Report

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,P.Supplier_Id, SP.Supp_Name, L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Supplier SP ON P.Supplier_Id = SP.Supp_Code WHERE S.Qty = 0 AND S.Op_St = 1 AND L.Loca = " + LoginManager.LocaCode + " AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,P.Supplier_Id, SP.Supp_Name, L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Supplier SP ON P.Supplier_Id = SP.Supp_Code WHERE S.Qty = 0 AND S.Op_St = 1 AND L.Loca = " + LoginManager.LocaCode + " AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name ASC";
                        }


                        //objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name,P.Purchase_Price,P.Selling_Price ,S.Qty ,P.Supplier_Id, SP.Supp_Name, L.Loca,L.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca INNER JOIN Supplier SP ON P.Supplier_Id = SP.Supp_Code WHERE S.Qty = 0 AND S.Op_St = 1 AND L.Loca = " + LoginManager.LocaCode + " AND P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "'";
                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockZeroSuppwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 72:    //Grn Summary Supplier wise
                        objRepView.SqlStatement = "select Transaction_Header.Iid, Transaction_Header.Doc_No, Transaction_Header.Loca, Location.Loca_Descrip, Transaction_Header.To_LocaDesc, Transaction_Header.Supplier_Id, Supplier.Supp_Name, Transaction_Header.Post_Date, Transaction_Header.Discount, Transaction_Header.Amount, Transaction_Header.Net_Amount, 'Code From " + txtCodeFrom.Text.Trim() + "' CodeFrom, 'Code To " + txtCodeTo.Text.Trim() + "' CodeTo from Transaction_Header INNER JOIN Location ON Transaction_Header.Loca = Location.Loca INNER JOIN Supplier ON Transaction_Header.Supplier_Id = Supplier.Supp_Code WHERE Transaction_Header.Supplier_Id BETWEEN '" + txtCodeFrom.Text.ToString() + "' AND '" + txtCodeTo.Text.ToString() + "' AND Transaction_Header.Loca = '" + LoginManager.LocaCode + "' AND Transaction_Header.Iid = 'GRN' ORDER BY RIGHT(Doc_No,6)";
                        objRepView.DataSetName = "TransactionSummary";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptGrnSummarySuppwise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    case 73:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Prod_Code,Prod_Name,Purchase_Price,Selling_Price, Prod_Image, Marked_Price FROM Product WHERE(Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND LockedItem = 'T' ORDER BY Prod_Code";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Prod_Code,Prod_Name,Purchase_Price,Selling_Price, Prod_Image, Marked_Price FROM Product WHERE(Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "') AND LockedItem = 'T' ORDER BY Prod_Name";
                        }

                        objRepView.DataSetName = "Product";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptProductDetails();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Locked Product Details";
                        break;

                    case 74:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code, P.Prod_Name, P.Purchase_price, P.Selling_Price, 'Location   ' + SM.Loca [Loca], SM.Qty, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT P.Prod_Code, P.Prod_Name, P.Purchase_price, P.Selling_Price, 'Location   ' + SM.Loca [Loca], SM.Qty, '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name";
                        }
                        objRepView.DataSetName = "Product";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseProductStockReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        //objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "LOCATION WISE PRODUCT STOCK DETAILS";
                        break;

                    case 75:
                        objRepView.SqlStatement = "SELECT D.Dept_Code [Prod_Code], D.Dept_Name [Prod_Name], 'Location   ' + SM.Loca [Loca], CAST(ISNULL(SUM(SM.Qty), 0) AS DECIMAL(18,2)) [Qty], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code INNER JOIN Department D ON P.Department_Id = D.Dept_Code WHERE P.Department_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY D.Dept_Code, D.Dept_Name, SM.Loca ORDER BY D.Dept_Code";
                        objRepView.DataSetName = "Product";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseDepartmentStockReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location Wise Department Stock Report";
                        objRepViewer.VirtuaReport.DataDefinition.FormulaFields["Field Name"].Text = "\"Department Code & Name\"";
                        break;

                    case 76:
                        objRepView.SqlStatement = "SELECT C.Cat_Code [Prod_Code], C.Cat_Name [Prod_Name], 'Location   ' + SM.Loca [Loca], CAST(ISNULL(SUM(SM.Qty), 0) AS DECIMAL(18,2)) [Qty], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code INNER JOIN Category C ON P.Category_Id = C.Cat_Code WHERE P.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY C.Cat_Code, C.Cat_Name, SM.Loca ORDER BY C.Cat_Code";
                        objRepView.DataSetName = "Product";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseDepartmentStockReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location Wise Category Stock Report";
                        objRepViewer.VirtuaReport.DataDefinition.FormulaFields["Field Name"].Text = "\"Category Code & Name\"";
                        break;

                    case 77:
                        objRepView.SqlStatement = "SELECT S.Supp_Code+' - '+ Supp_Name [Supp_Code], P.Prod_Code+' - '+Prod_Name  [Prod_Code], Purchase_price, Selling_Price, 'Loca   ' + SM.Loca [Loca], CAST(ISNULL(SUM(SM.Qty), 0) AS DECIMAL(18,2)) [Qty], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo] FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code INNER JOIN Supplier S ON P.Supplier_Id = S.Supp_Code WHERE P.Supplier_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' GROUP BY S.Supp_Code, S.Supp_Name, SM.Loca , Purchase_price, Selling_Price,P.Prod_Code, Prod_Name  ORDER BY S.Supp_Code";
                        objRepView.DataSetName = "DsLocaWiseDeptSale";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseSuppWiseStockReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location Wise Supplier Stock Report";
                        //objRepViewer.VirtuaReport.DataDefinition.FormulaFields["Field Name"].Text = "\"Supplier Code & Name\"";
                        break;

                    //case 78:
                    //    objRepView.SqlStatement = "SELECT Item_Code, Item_Descrip, SUM(Qty) Qty, Marked_Price, Unit_Price, (Marked_Price-Unit_Price)*sum(Qty) [Discount], '" + txtCodeFrom.Text.Trim() + "' [CodeFrom], '" + txtCodeTo.Text.Trim() + "' [CodeTo]  FROM DayEnd_Pos_Transaction WHERE Iid='001' AND Discount <> 0 AND Item_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' AND CONVERT(DATETIME,BillDate,103) BETWEEN CONVERT(DATETIME,'"++"',103) AND CONVERT(DATETIME,'',103) Group By Item_Code, Item_Descrip, Marked_Price, Unit_Price, Discount";
                    //    objRepView.DataSetName = "dsProdWiseSpecialDisc";
                    //    objRepView.RetrieveData();
                    //    dsDataForReport = objRepView.TempResultSet;
                    //    objRepViewer.VirtuaReport = new rptProdWiseSpecialDiscReport();
                    //    objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                    //    break;
                    case 79:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT MainProdCode, Prod_Name [MainProdName], SubProd_Code, Prod_Name [SubProdName], tb_TempCombination.Purchase_Price, tb_TempCombination.Selling_Price, tb_TempCombination.Qty FROM tb_TempCombination INNER JOIN Product ON tb_TempCombination.MainProdCode = Product.Prod_Code WHERE MainProdCode BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order by Product.Prod_Code ASC";
                            objRepView.DataSetName = "dsProdCombination";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptBulkProdCombination();
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT MainProdCode, Prod_Name [MainProdName], SubProd_Code, Prod_Name [SubProdName], tb_TempCombination.Purchase_Price, tb_TempCombination.Selling_Price, tb_TempCombination.Qty FROM tb_TempCombination INNER JOIN Product ON tb_TempCombination.MainProdCode = Product.Prod_Code WHERE MainProdCode BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' Order by Product.Prod_Name ASC";
                            objRepView.DataSetName = "dsProdCombination";
                            objRepView.RetrieveData();
                            dsDataForReport = objRepView.TempResultSet;
                            objRepViewer.VirtuaReport = new rptBulkProdCombinationDesc();

                        }

                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                        objRepViewer.WindowState = FormWindowState.Maximized;
                        objRepViewer.Show();
                        break;
                    case 82:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, Product.Prod_Code, Prod_Name, Selling_Price, Qty, Purchase_price , '" + LoginManager.UserName + "' Supp_Name FROM Product INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code WHERE Product.Prod_Code BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND Loose=1 AND Loca='" + LoginManager.LocaCode + "' Order by Product.Prod_Code ASC";

                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT '" + txtCodeFrom.Text.Trim() + "' CodeFrom, '" + txtCodeTo.Text.Trim() + "' CodeTo, Product.Prod_Code, Prod_Name, Selling_Price, Qty, Purchase_price , '" + LoginManager.UserName + "' Supp_Name FROM Product INNER JOIN Stock_Master ON Product.Prod_Code = Stock_Master.Prod_Code WHERE Product.Prod_Code BETWEEN '" + txtCodeFrom.Text + "' AND '" + txtCodeTo.Text + "' AND Loose=1 AND Loca='" + LoginManager.LocaCode + "' Order by Product.Prod_Name ASC";

                        }
                        objRepView.DataSetName = "StockDetails";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLooseProductStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Loose Product Stocks";
                        break;

                    case 83:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "EXEC dbo.Sp_GetReport @Report = '83', @Loca = '" + LoginManager.LocaCode + "',@CodeFrom='" + txtCodeFrom.Text + "',@CodeTo='" + txtCodeTo.Text + "',@OBy='Code'";
 
                        }
                        else
                        {
                            objRepView.SqlStatement = "EXEC dbo.Sp_GetReport @Report = '83', @Loca = '" + LoginManager.LocaCode + "',@CodeFrom='" + txtCodeFrom.Text + "',@CodeTo='" + txtCodeTo.Text + "',@OBy='Code'";

                        }
                        objRepView.DataSetName = "dsPurSalesStock";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseOrderReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        //objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location wise";
                        break;

                    case 84:
                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "EXEC dbo.Sp_GetReport @Report = '84', @Loca = '" + LoginManager.LocaCode + "',@CodeFrom='" + txtCodeFrom.Text + "',@CodeTo='" + txtCodeTo.Text + "',@OBy='Code'";
                        }
                        else
                        {
                            objRepView.SqlStatement = "EXEC dbo.Sp_GetReport @Report = '84', @Loca = '" + LoginManager.LocaCode + "',@CodeFrom='" + txtCodeFrom.Text + "',@CodeTo='" + txtCodeTo.Text + "',@OBy='Code'";
                        }
                        objRepView.DataSetName = "dsPurSalesStock";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptLocationWiseSupWiseOrderReport();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        //objRepViewer.VirtuaReport.SummaryInfo.ReportTitle = "Location wise";
                        break;


                    case 85:
                        if ((MessageBox.Show(" Do you want to display with zero qty product ?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name, P.Barcode Department_Id, P.Purchase_Price,P.Selling_Price ,S.Stock AS Qty ,L.Loca,L.Loca_Descrip, S.BatchNo [Manufacturer_Id], CONVERT(VARCHAR(10),S.Exp_Date,103) [Manf_Name], '" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master_Batch S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code,S.BatchNo ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name, P.Barcode Department_Id,P.Purchase_Price,P.Selling_Price ,S.Stock AS Qty ,L.Loca,L.Loca_Descrip, S.BatchNo [Manufacturer_Id], CONVERT(VARCHAR(10),S.Exp_Date,103) [Manf_Name], '" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master_Batch S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name,S.BatchNo ASC";
                            }

                        }
                        else
                        {

                            if (rbByCode.Checked == true)
                            {
                                objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name, P.Barcode Department_Id, P.Purchase_Price,P.Selling_Price ,S.Stock AS Qty ,L.Loca,L.Loca_Descrip, S.BatchNo [Manufacturer_Id], CONVERT(VARCHAR(10),S.Exp_Date,103) [Manf_Name], '" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master_Batch S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Stock <> 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Code,S.BatchNo  ASC";
                            }
                            else
                            {
                                objRepView.SqlStatement = "SELECT P.Prod_Code ,P.Prod_Name, P.Barcode Department_Id, P.Purchase_Price,P.Selling_Price ,S.Stock AS Qty ,L.Loca,L.Loca_Descrip, S.BatchNo [Manufacturer_Id], CONVERT(VARCHAR(10),S.Exp_Date,103) [Manf_Name], '" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT P INNER JOIN Stock_Master_Batch S ON P.Prod_Code = S.Prod_Code INNER JOIN Location L ON S.Loca = L.Loca WHERE S.Stock <> 0 AND L.Loca = " + LoginManager.LocaCode + " AND P.Prod_Code BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' ORDER BY P.Prod_Name, S.BatchNo ASC";
                            }


                        }
                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockProdwiseBatchWise();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;
                        //Product Serial Number Datail Report
                    case 87:
                        if ((MessageBox.Show("Do you want to Dispaly with zero Serial No Stock? ", "Serial No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            objRepView.SqlStatement = "Exec Sp_SerialNoStockReport '" + txtCodeFrom.Text.Trim() + "','" + txtCodeTo.Text.Trim() + "','" + LoginManager.LocaCode + "',@WithZero=1,@ReportId=1";
                        }
                        else
                        {
                            objRepView.SqlStatement = "Exec Sp_SerialNoStockReport '" + txtCodeFrom.Text.Trim() + "','" + txtCodeTo.Text.Trim() + "','" + LoginManager.LocaCode + "',@WithZero=0,@ReportId=1";
                        }                        
                        objRepView.DataSetName = "dsStockSerialNo";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptprodSerialNoStock();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;
                    case 88:

                        if ((MessageBox.Show("Do you Want to Display with Zero Qty Product?", "Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            StockQry = " AND dbo.Stock_Master.Qty <> 0";
                        }

                        if (rbByCode.Checked == true)
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.MinimumPrice[Selling_Price], Product.Category_Id, Category.Cat_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Code ASC";
                        }
                        else
                        {
                            objRepView.SqlStatement = "SELECT Product.Prod_Code ,Product.Prod_Name,Product.Purchase_Price, Product.MinimumPrice[Selling_Price], Product.Category_Id, Category.Cat_Name, Stock_Master.Qty , Stock_Master.Loca,Location.Loca_Descrip,'" + txtCodeFrom.Text.Trim() + "' AS CodeFrom,'" + txtCodeTo.Text.Trim() + "'AS CodeTo FROM  PRODUCT INNER JOIN Stock_Master ON PRODUCT.Prod_Code = Stock_Master.Prod_Code INNER JOIN Location ON Stock_Master.Loca = Location.Loca INNER JOIN Category ON Category.Cat_Code = Product.Category_Id  WHERE Stock_Master.Loca = " + LoginManager.LocaCode + " AND Product.Category_Id BETWEEN '" + txtCodeFrom.Text.Trim() + "' AND '" + txtCodeTo.Text.Trim() + "' " + StockQry + " ORDER BY Product.Prod_Name ASC";
                        }


                        objRepView.DataSetName = "dsStockProductwise";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptStockValCatwiseDistributedPrice();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;
                    case 89:
                        //Product Serial Stock Issue & Receieved Detail Report
                        if ((MessageBox.Show("Do you want to Dispaly with zero Serial No Stock? ", "Serial No", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            objRepView.SqlStatement = "Exec Sp_SerialNoStockReport '" + txtCodeFrom.Text.Trim() + "','" + txtCodeTo.Text.Trim() + "','" + LoginManager.LocaCode + "',@WithZero=1,@ReportId=2";
                        }
                        else
                        {
                            objRepView.SqlStatement = "Exec Sp_SerialNoStockReport '" + txtCodeFrom.Text.Trim() + "','" + txtCodeTo.Text.Trim() + "','" + LoginManager.LocaCode + "',@WithZero=0,@ReportId=2";
                        }
                        objRepView.DataSetName = "dsStockSerialNo";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        objRepViewer.VirtuaReport = new rptprodSerialNoStockIssuedReceived();
                        objRepViewer.VirtuaReport.SetDataSource(dsDataForReport);
                        break;

                    default:
                        break;

                }
                objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.VirtuaReport;
                objRepViewer.WindowState = FormWindowState.Maximized;
                objRepViewer.Show();

                dsDataForReport.Dispose();
                dsDataForReport = null;


                objRepView.TempResultSet.Dispose();
                objRepView.TempResultSet = null;
            }

            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmMasterDetailsInquary_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 008.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            chkAll.Checked = false;
            txtCodeFrom.Focus();

        }

        private void frmMasterDetailsInquary_Load(object sender, EventArgs e)
        {
            switch (intRepOption)
            {
                case 89:
                    //Product Serial Stock Issue & Receieved Detail Report
                    rbByCode.Visible = false;
                    rbByCode.Checked = false;
                    rbByDescrip.Visible = false;
                    chkAll.Visible = true;
                    break;
                case 86:
                case 85:
                case 3:
                case 1:
                case 2:
                case 11:
                case 5:
                case 4:
                case 10:
                case 6:
                case 8:
                case 7:
                case 9:
                case 79:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 88:
                case 61:        
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 69:
                case 71:
                case 73:
                case 74:                
                case 75:
                case 76:
                case 77:              
                
                case 82:
                case 83:
                case 84: 
                    rbByCode.Visible = true;
                    rbByCode.Checked = true;
                    rbByDescrip.Visible = true;
                    chkAll.Visible = true;
                    break;
                case 87:  // product serial stock report datail
                    rbByCode.Visible = false;
                    rbByCode.Checked = false;
                    rbByDescrip.Visible = false;
                    chkAll.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void rbByCode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAll.Checked == true)
                {
                    txtCodeFrom.Text = "0";
                    txtCodeTo.Text = "z";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmMasterDetailsInquary 008.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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