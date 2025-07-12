using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
using System.Data;
using Inventory;

namespace Inventory
{
    public class clsShortCut : clsSMS2
    {
        //clsCustomer ObCustomer = new clsCustomer();
        frmCustomerSearch search = new frmCustomerSearch();

        public void CustomerSearch(ref string Customer, ref string CustName, ref string Loca, Control focus)
        {
            if (search.IsDisposed)
            {
                search = new frmCustomerSearch();
            }

            if (Customer != string.Empty && CustName == string.Empty && Loca == string.Empty)
            {
                SearchDataset = getDataSet("SELECT Cus_Code AS [Customer],Card_No [Card Number], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Code LIKE '" + Customer.Trim() + "%') AND (Loca LIKE '" + Loca.Trim() + "%') ORDER BY Cus_Code", "T");
            }
            else if (Customer == string.Empty && CustName != string.Empty)
            {
                SearchDataset = getDataSet("SELECT Cus_Code AS [Customer],Card_No [Card Number], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + CustName.Trim() + "%') AND (Loca LIKE '%" + Loca.Trim() + "%')  ORDER BY Cus_Name", "T");
            }
            else
            {
                SearchDataset = getDataSet("SELECT Cus_Code AS [Customer],Card_No [Card Number], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE (Loca LIKE '%" + Loca.Trim() + "%') ORDER BY Cus_Code", "T");
            }

            if (SearchDataset.Tables[0].Rows.Count > 1)
            {

                search.ShowDialog();
            }
              focus.Focus(); 
            
            
        }
    }
}