using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.PointOfService;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace clsLibrary
{
    public class clsCashDrawerClass
    {
       

        public void CashDrawer_Open()
        {
            clsCommon objCommon = new clsCommon();
            string qry = "SELECT PrinterName FROM tb_PrinterDetails WHERE PosPrinter = 1";
            objCommon.getDataSet(qry, "dsPrinter");
            string PosPrinter = objCommon.Ads.Tables["dsPrinter"].Rows[0][0].ToString();

                string st = "027-112-048-050-250";
                st = "027-112-0-50-250";
                string SOut = "";
                string[] words = st.Split('-');
                foreach (string word in words) {
                    SOut = (SOut + ((char)(int.Parse(word))));
                }

                RawPrinterHelper.SendStringToPrinter(PosPrinter, SOut);

        }

        

    }
}
