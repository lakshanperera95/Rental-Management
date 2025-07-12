using System;
using System.Collections.Generic;
using System.Text;
using DbConnection;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
namespace clsLibrary
{
    public class clsPrinterSettings
    {

        private string strRecPrinterName;
        public string _strRecPrinterName
        {
            get { return strRecPrinterName; }
            set { strRecPrinterName = value; }
        }

        private string strPosPrinterName;
        public string _strPosPrinterName
        {
            get { return strPosPrinterName; }
            set { strPosPrinterName = value; }
        }

        private string strRecPrinterCustomPaper;
        public string _strRecPrinterCustomPaper
        {
            get { return strRecPrinterCustomPaper; }
            set { strRecPrinterCustomPaper = value; }
        }

        private int intRecPrintCount;
        public int _intRecPrintCount
        {
            get { return intRecPrintCount; }
            set { intRecPrintCount = value; }
        }

        private int intPosPrintCount;
        public int _intPosPrintCount
        {
            get { return intPosPrintCount; }
            set { intPosPrintCount = value; }
        }

        

        private string Messg;
        public string _Messg
        {
            get { return Messg; }
            set { Messg = value; }
        }
        private bool _Pos;
        public bool Pos
        {
            get { return _Pos; }
            set { _Pos = value; }
        }

        private bool _Rec;
        public bool Rec
        {
            get { return _Rec; }
            set { _Rec = value; }
        }

        public void getRecPrinterDetails()
        {   SqlDataReader dr = null;
            try
            {
                string sqlStatement = "";
                sqlStatement = "SELECT PrinterId, PrinterName,CustomPaper, PrintCount,DefaultP FROM tb_PrinterDetails WHERE MachineName=@MachineName and  PosPrinter=0 ";

                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@MachineName", System.Environment.MachineName));

                dr = dbcon.GetReader(sqlStatement, lstPrm);
                if (dr.Read())
                {
                    strRecPrinterName = dr["PrinterName"].ToString();
                    strRecPrinterCustomPaper = dr["CustomPaper"].ToString();
                    intRecPrintCount = int.Parse(dr["PrintCount"].ToString());
                    _Rec = bool.Parse(dr["DefaultP"].ToString());
                }
                else
                {
                    strRecPrinterName = strRecPrinterCustomPaper = string.Empty;
                    intRecPrintCount = 1;
                }

            }
            catch (Exception ex)
            {
                strRecPrinterName = strRecPrinterCustomPaper  = string.Empty;
                intRecPrintCount = 1;
                throw ex;

            }
            finally
            {
                dbcon.CloseConnection();
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }
        public void getPosPrinterDetails()
        {
            SqlDataReader dr = null;
            try
            {
                string sqlStatement = "";
                sqlStatement = "SELECT PrinterId, PrinterName, CustomPaper, PrintCount,DefaultP FROM tb_PrinterDetails WHERE MachineName=@MachineName and  PosPrinter=1";

                List<SqlParameter> lstPrm = new List<SqlParameter>();
                lstPrm.Add(new SqlParameter("@MachineName", System.Environment.MachineName));

                dr = dbcon.GetReader(sqlStatement, lstPrm);
                if (dr.Read())
                {
                    strPosPrinterName = dr["PrinterName"].ToString();
                    intPosPrintCount = int.Parse(dr["PrintCount"].ToString());
                     _Pos = bool.Parse(dr["DefaultP"].ToString());
                }
                else
                {
                    strPosPrinterName  = string.Empty;
                    intPosPrintCount = 1;
                }

            }
            catch (Exception ex)
            {
                strPosPrinterName  = string.Empty;
                intPosPrintCount = 1;
                throw ex;

            }
            finally
            {
                dbcon.CloseConnection();
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }

        public void ApplyPrinterSettings(bool Pos,bool Rec)
        {
            SqlDataReader dr = null;
            try
            {

                SqlParameter[] parameter = {
                    new SqlParameter("@MachineName", System.Environment.MachineName),
                    new SqlParameter("@RecPrinter", strRecPrinterName),
                    new SqlParameter("@CustomerPaper", strRecPrinterCustomPaper),
                    new SqlParameter("@RecPrintCount", intRecPrintCount),
                    new SqlParameter("@PosPrinter", strPosPrinterName),
                    new SqlParameter("@PosPrintCount", intPosPrintCount),
                    new SqlParameter("@Pos", Pos),
                    new SqlParameter("@Rec", Rec)
                };

                dr = dbcon.GetReader("[sp_PrinterSettings_Apply]", parameter);
                if (dr.Read())
                {
                    Messg = dr["Msg"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.CloseConnection();

                if (dr != null)
                {
                    dr.Close();
                }
            }
        }

    }
}
