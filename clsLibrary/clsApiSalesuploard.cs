using System;
using System.Collections.Generic;
using System.Text;

namespace clsLibrary
{
  public  class clsApiSalesuploard
    {
        private string _AppCode;

      public string AppCode
        {
            get { return _AppCode; }
            set { _AppCode = value; }
        }

        private string _PropertyCode;

        public string PropertyCode
        {
            get { return _PropertyCode; }
            set { _PropertyCode = value; }
        }

        private string _ClientID;

      public string ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }

        private string _ClientSecret;

        public string ClientSecret
        {
            get { return _ClientSecret; }
            set { _ClientSecret = value; }
        }

      private string _POSInterfaceCode;

      public string POSInterfaceCode
        {
            get { return _POSInterfaceCode; }
            set { _POSInterfaceCode = value; }
        }

      private string _BatchCode;

      public string BatchCode
        {
            get { return _BatchCode; }
            set { _BatchCode = value; }
        }


      private List<InvData> _InvData;

      public List<InvData> PosSales
        {
            get { return _InvData; }
            set { _InvData = value; }
        }
    }



    public class InvData 
    {
        private string _PropertyCode;

        public string PropertyCode
        {
            get { return _PropertyCode; }
            set { _PropertyCode = value; }
        }


        private string _POSInterfaceCode;

        public string POSInterfaceCode
        {
            get { return _POSInterfaceCode; }
            set { _POSInterfaceCode = value; }
        }

        private string _ReceiptDate;

        public string ReceiptDate
        {
            get { return _ReceiptDate; }
            set { _ReceiptDate = value; }
        }

        private string _ReceiptTime;

        public string ReceiptTime
        {
            get { return _ReceiptTime; }
            set { _ReceiptTime = value; }
        }

        private string _ReceiptNo;

        public string ReceiptNo
        {
            get { return _ReceiptNo; }
            set { _ReceiptNo = value; }
        }

        private int _NoOfItems;

        public int NoOfItems
        {
            get { return _NoOfItems; }
            set { _NoOfItems = value; }
        }


        private string _SalesCurrency;

        public string SalesCurrency
        {
            get { return _SalesCurrency; }
            set { _SalesCurrency = value; }
        }

        private decimal _TotalSalesAmtB4Tax;

        public decimal TotalSalesAmtB4Tax
        {
            get { return _TotalSalesAmtB4Tax; }
            set { _TotalSalesAmtB4Tax = value; }
        }

        private decimal _TotalSalesAmtAfterTax;

        public decimal TotalSalesAmtAfterTax
        {
            get { return _TotalSalesAmtAfterTax; }
            set { _TotalSalesAmtAfterTax = value; }
        }

        private decimal _SalesTaxRate;

        public decimal SalesTaxRate
        {
            get { return _SalesTaxRate; }
            set { _SalesTaxRate = value; }
        }

        private decimal _ServiceChargeAmt;

        public decimal ServiceChargeAmt
        {
            get { return _ServiceChargeAmt; }
            set { _ServiceChargeAmt = value; }
        }

        private decimal _PaymentAmt;

        public decimal PaymentAmt
        {
            get { return _PaymentAmt; }
            set { _PaymentAmt = value; }
        }

        private string _PaymentCurrency;

        public string PaymentCurrency
        {
            get { return _PaymentCurrency; }
            set { _PaymentCurrency = value; }
        }

        private string _PaymentMethod;

        public string PaymentMethod
        {
            get { return _PaymentMethod; }
            set { _PaymentMethod = value; }
        }

        private string _SalesType;

        public string SalesType
        {
            get { return _SalesType; }
            set { _SalesType = value; }
        }


        private List<ItemCls> _ItemData;

        public List<ItemCls> Items
        {
            get { return _ItemData; }
            set { _ItemData = value; }
        }


    }

    public class ItemCls {

        private string _ItemDesc;

        public string ItemDesc
        {
            get { return _ItemDesc; }
            set { _ItemDesc = value; }
        }

        private decimal _ItemAmt;

        public decimal ItemAmt
        {
            get { return _ItemAmt; }
            set { _ItemAmt = value; }
        }

        private decimal _ItemDiscoumtAmt;

        public decimal ItemDiscoumtAmt
        {
            get { return _ItemDiscoumtAmt; }
            set { _ItemDiscoumtAmt = value; }
        }


    }
}
