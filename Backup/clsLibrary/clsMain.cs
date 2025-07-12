using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbConnection;

namespace clsLibrary
{
    public class clsMain:clsValidation
    {
        private string _MainProdCode;
        public string MainProdCode
        {
            get { return _MainProdCode; }
            set { _MainProdCode = value; }
        }

        private string _MainProdName;
        public string MainProdName
        {
            get { return _MainProdName; }
            set { _MainProdName = value; }
        }


        private string _Prod_Code;
        public string ProdCode
        {
            get { return _Prod_Code.Trim(); }
            set { _Prod_Code = value.Trim(); }
        }

        private string _Prod_Name;
        public string ProdName
        {
            get { return _Prod_Name.Trim(); }
            set { _Prod_Name = value.Trim(); }
        }

        private decimal _Qty;
        public decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        private decimal _Purchase_Price;
        public decimal PurchasePrice
        {
            get { return _Purchase_Price; }
            set { _Purchase_Price = value; }
        }

        private decimal _Selling_Price;
        public decimal SellingPrice
        {
            get { return _Selling_Price; }
            set { _Selling_Price = value; }
        }

        private string _SqlStatement;
        public string SqlStatement
        {
            get { return _SqlStatement; }
            set { _SqlStatement = value; }
        }

        private DataSet _Dataset;
        public DataSet dataset
        {
            get { return _Dataset; }
            set { _Dataset = value; }
        }

        private SqlDataReader _reader;
        public SqlDataReader Reader
        {
            get { return _reader; }
            set { _reader = value; }
        }

        private string _ReturnMSG;
        public string ReturnMSG
        {
            get { return _ReturnMSG; }
            set { _ReturnMSG = value; }
        }

        private string _FocusCont;
        public string FocusCont
        {
            get { return _FocusCont; }
            set { _FocusCont = value; }
        }

        private string _MsgTital;
        public string MsgTital
        {
            get { return _MsgTital; }
            set { _MsgTital = value; }
        }



    }
}