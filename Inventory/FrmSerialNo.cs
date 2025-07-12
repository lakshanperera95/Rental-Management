using clsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class FrmSerialNo : Form
    {
        public FrmSerialNo()
        {
            InitializeComponent();

        }
        //Dev by Kalani 15/07/2024
        clsGrn ObjGrn = new clsGrn();
        clsSerialNo objSerial = new clsSerialNo();
        public string tempDocNo { get; set; }
        public string prodCode { get; set; }
        public decimal Qty { get; set; }
        public bool Flag { get; set; } = false;

        public string Iid { get; set; }
     

        private static FrmSerialNo frmSerialNo;
        public static FrmSerialNo _frmSerialNo
        {
            get { return frmSerialNo; }
            set { frmSerialNo = value; }
        }

        private void FrmSerialNo_Load(object sender, EventArgs e)
        {
            
                objSerial.Qty = Qty;
                label1.Text = "Qty:" + objSerial.Qty.ToString();

                objSerial.ProdCode = prodCode.Trim();
                objSerial.TempDocNo = tempDocNo.Trim();
                objSerial.GetTempDataset();
                dtgridSerialNo.DataSource = objSerial.TempSerialNo.Tables["dsSerialNo"];
                dtgridSerialNo.Refresh();

                lblrowcount.Text = "Bal :" + (objSerial.Qty - dtgridSerialNo.Rows.Count).ToString();
          
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                objSerial.SqlStatement = "SELECT * FROM dbo.TransactionTemp_Details WHERE Doc_No ='" + tempDocNo + "' AND Iid ='GRN' AND Loca ='" + LoginManager.LocaCode + "' AND Prod_Code ='" + prodCode + "'";
                objSerial.GetDs();

                if(objSerial.Ads.Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("Allready Added Item.. You Cannot Remove Items", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (dtgridSerialNo.RowCount == 0)
                {
                    Flag = false;
                    _frmSerialNo = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Cannot Cancel.Row Count '" + dtgridSerialNo.RowCount + "'", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgridSerialNo.RowCount == objSerial.Qty)
                {
                    Flag = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Serial Numbers Count Not Equal to Qty", "Serial Number Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSerialNo.Text != string.Empty)
                {
                    if(frmGrn.GetGrn != null)
                    {
                        objSerial.SqlStatement = "SELECT SerialNo FROM SerialNo_Apply WHERE SerialNo ='" + txtSerialNo.Text.Trim() + "'";
                        objSerial.ReadTempDetail();
                        if (objSerial.RecordFound == true)
                        {
                            MessageBox.Show("This Serial Number Already Exsict.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                   
                    if ((objSerial.Qty- dtgridSerialNo.RowCount) <= 0)
                    {
                        MessageBox.Show("Serial Numbers Already Enter", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;

                    }

                    objSerial.ProdCode = prodCode.Trim();
                    objSerial.TempDocNo = tempDocNo.Trim();
                    objSerial.SerialNo = txtSerialNo.Text.ToString();
                    objSerial.GetSerialNo();
                    objSerial.GetTempDataset();
                    dtgridSerialNo.DataSource = objSerial.TempSerialNo.Tables["dsSerialNo"];
                    dtgridSerialNo.Refresh();
                    //Set Grid Last Record
                    //if (dtgridSerialNo.RowCount >12)
                    //{
                    //    dtgridSerialNo.FirstDisplayedCell = dtgridSerialNo[0, dtgridSerialNo.RowCount - 6];
                    //}
                    if (dtgridSerialNo.RowCount > 0)
                    {
                        lblrowcount.Text = "Bal :" + (objSerial.Qty- dtgridSerialNo.RowCount);
                    }
                    txtSerialNo.Text = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dtgridSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dtgridSerialNo.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are You Sure You want to Delete this Serial Number", "Serail Numbers", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                        objSerial.SerialNo = dtgridSerialNo.SelectedRows[0].Cells[0].Value.ToString();
                        objSerial.SqlStatement = "DELETE FROM TempSerialNo Where SerialNo ='" + objSerial.SerialNo + "' AND DocNo ='" + tempDocNo.Trim() + "'";
                        objSerial.GetDs();
                        objSerial.GetTempDataset();
                        dtgridSerialNo.DataSource = objSerial.TempSerialNo.Tables["dsSerialNo"];
                        dtgridSerialNo.Refresh();

                        lblrowcount.Text = "Bal :" + (objSerial.Qty- dtgridSerialNo.Rows.Count).ToString() ;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmGrn 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick(); 
            }
        }

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnApply.Focus();
                btnApply.Select();
            }
        }
       


    }

    }

