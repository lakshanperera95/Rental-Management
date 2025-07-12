using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using clsLibrary;
using BillPreview;
 

namespace Inventory
{
    public partial class frmDisplayReceipt : Form
    {
        public frmDisplayReceipt()
        {
            InitializeComponent();
        }
        ClsFillGrid objMod = new ClsFillGrid();
        clsDisplayReceipt objDisplayReceipt = new clsDisplayReceipt();
        clsCommon objCommon = new clsCommon();
        
        private static frmDisplayReceipt DisplayReceipt;
        public static frmDisplayReceipt GetDisplayReceipt
        {
            get { return DisplayReceipt; }
            set { DisplayReceipt = value; }
        }
        private DataSet dsUnit;
        

        private void frmDisplayReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                objCommon.SetConnection(LoginManager.ServerName,LoginManager.DatabaseName,LoginManager.User,LoginManager.Password);
                objDisplayReceipt.GetLocation();
                cmbLocaCode.DataSource = objDisplayReceipt._dsLocation.Tables["Location"];
                cmbLocaDes.DataSource = objDisplayReceipt._dsLocation.Tables["Location"];
                cmbLocaCode.DisplayMember = "Loca";
                cmbLocaDes.DisplayMember = "Loca_Descrip";
                
               // cmbLocaCode.Text = "-select-";
               // cmbLocaDes.Text = "-select-";

                objDisplayReceipt.GetUnit();
                cmbUnit.DataSource = objDisplayReceipt._dsUnit.Tables["unit"];
                cmbUnit.DisplayMember = "Unit";
                cmbUnit.Text = "-select-";

                


            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDisplayReceipt cmbfill. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmDisplayReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisplayReceipt = null;
        }



        private void cmbUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        private void cmbLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLocaDes.Focus();
            }
        }

        private void cmbLocaDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpBillDate.Focus();
            }
        }

        private void dtpBillDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    objCommon.getDataReader("EXEC sp_Receipt_View '" + dtpBillDate.Text + "'");
                }
                catch (Exception ex)
                {

                    objCommon.Errormsg(ex, "frmDisplayReceipt, dtpBillDate_KeyDown");
                }
                cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    cmbReportID.Text = "";
                    cmbReceiptNo.Text = "";
                    //cmbReceiptNo.Items.Clear();
                    listView1.Items.Clear();
                    string SqlSatatement = "SELECT distinct ReportID FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' AND BillDate = '" + dtpBillDate.Text + "' AND Unit = '" + cmbUnit.Text.Trim() + "'";
                    objCommon.getDataSet(SqlSatatement, "DsCom");
                    cmbReportID.DataSource = objCommon.Ads.Tables["DsCom"];
                    cmbReportID.DisplayMember = "ReportID";
                    cmbReportID.Focus();
                }
                catch (Exception ex)
                {
                    //Write to Log
                    DateTime dtCurrentDate = DateTime.Now;
                    FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDisplayReceipt cmbfill. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        private void cmbReceiptNo_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void cmbReportID_SelectedValueChanged(object sender, EventArgs e)
        
        {

        }

        private void cmbReportID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbReportID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbReportID.Text == "")
                        return;
                    
                    string strSqlStatemnt = "SELECT DISTINCT Receipt_No FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' AND unit = '" + cmbUnit.Text + "' AND billdate = '" + dtpBillDate.Text + "' AND ReportID = '" + cmbReportID.Text + "' ORDER BY Receipt_No ASC";
                    objCommon.getDataSet(strSqlStatemnt, "DsRecpt");
                    cmbReceiptNo.DataSource = objCommon.Ads.Tables["DsRecpt"];
                    cmbReceiptNo.DisplayMember = "Receipt_No";
                    cmbReceiptNo.Focus();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDisplayReceipt cmbfill. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cmbReceiptNo.Text == "")
                        return;
                    string SqlStatement = "SELECT Item_Code,Item_Descrip,Unit_Price,Qty,Amount,BillTime,UserName FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' and unit = '" + cmbUnit.Text + "' and billdate = '" + dtpBillDate.Text + "' and ReportID = '" + cmbReportID.Text + "' and Receipt_No = '" + cmbReceiptNo.Text + "' and Iid in('001','R01','SBTT','CSH','BAL','005','CNL') ORDER BY ID_NO ASC";
                    objCommon.getDataReader(SqlStatement);

                    listView1.Items.Clear();

                    while (objCommon.Adr.Read())
                    {

                        ListViewItem List = new ListViewItem(objCommon.Adr[0].ToString());

                        for (int i = 1; i < objCommon.Adr.FieldCount; i++)
                        {
                            List.SubItems.Add(objCommon.Adr[i].ToString());

                        }
                        listView1.Items.Add(List);
                    }
                    btnDisplayReceipt.PerformClick();
                }
                catch (Exception ex)
                {

                    objCommon.Errormsg(ex, "frmDisplayReceipt, cmbReceiptNo_KeyDown");
                }
                


            }
        }

        private void cmbReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string SqlStatement = "SELECT Item_Code,Item_Descrip,Unit_Price,Qty,Amount,BillTime,UserName FROM DayEnd_Pos_TransactionForReport WHERE Loca = '" + cmbLocaCode.Text + "' and unit = '" + cmbUnit.Text + "' and billdate = '" + dtpBillDate.Text + "' and ReportID = '" + cmbReportID.Text + "' and Receipt_No = '" + cmbReceiptNo.Text + "' and Iid in('001','R01','SBTT','CSH','BAL','005','CNL') ORDER BY ID_No ASC";
                objCommon.getDataReader(SqlStatement);

                listView1.Items.Clear();

                while (objCommon.Adr.Read())
                {

                    ListViewItem List = new ListViewItem(objCommon.Adr[0].ToString());

                    for (int i = 1; i < objCommon.Adr.FieldCount; i++)
                    {
                        List.SubItems.Add(objCommon.Adr[i].ToString());

                    }
                    listView1.Items.Add(List);
                }
               // btnDisplayReceipt.PerformClick();
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbReceiptNo_SelectedIndexChanged");
            }

                //foreach (ListViewItem item in listView1.Items)
                //{

                //    //item.BackColor = item.Index % 2 == 0 ? Color.Magenta : Color.White;
                //}

            
        }

        private void btnDisplayReceipt_Click(object sender, EventArgs e)
        {
               try
                {
                    if (cmbReceiptNo.Text.Length < 8 || cmbReceiptNo.Text=="-select-")
                        return;
                    txtReceipt.Text = "";
                    txtReceipt.ReadOnly = true;
                   // objMod.ModuleReader(cmbReceiptNo.Text, cmbReportID.Text, dtpBillDate.Text, cmbReceiptNo.Text,cmbLocaCode.Text, cmbUnit.Text,txtReceipt);
                    //objMod.Print(cmbReceiptNo.Text, "T");
                }
                catch (Exception ex)
                {

                    objCommon.Errormsg(ex, "frmDisplayReceipt, btnDisplayReceipt_Click");
                }


            }

        private void cmbLocaCode_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmbLocaCode.DisplayMember = "Loca";
                cmbLocaDes.DisplayMember = "Loca_Descrip";
            }
            catch (Exception ex)
            {

                objCommon.Errormsg(ex, "frmDisplayReceipt, cmbLocaCode_SelectedIndexChanged");
            }
        }
    }
}
            
    

        

    
        

           
        
    
