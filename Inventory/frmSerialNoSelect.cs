using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmSerialNoSelect : Form
    {
        public frmSerialNoSelect()
        {
            InitializeComponent();
        }
        private static frmSerialNoSelect SerialNumber;
 

        public static frmSerialNoSelect GetSerialNmuber
        {
            get { return SerialNumber; }
            set { SerialNumber = value; }
        }

        private string strSerialNo;      
        
        public Control ContFocus { get; set; }
        private void SelectRow()
        {
            try
            {
                if (dgSerialNumber.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("No Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dgSerialNumber.SelectedRows[0].Cells[0].ToString() == "" || dgSerialNumber.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string SerialNo = dgSerialNumber.SelectedRows[0].Cells[0].Value.ToString();                   
                    ContFocus.Text = SerialNo;
                   // SerialNumber.Text = SerialNo;
                    ContFocus.Focus();
                    this.Hide();                  
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProductPriceLevel SelectRow. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgSerialNumber_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (dgSerialNumber.Enabled)
                {
                    //this.PriceBatchColor();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     

       

        private void dgSerialNumber_DoubleClick(object sender, EventArgs e)
        {
            this.SelectRow();
        }

        private void dgSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SelectRow();
            }
            if(Keys.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmSerialNoSelect_Load(object sender, EventArgs e)
        {

        }

        private void frmSerialNoSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSerialNoSelect.GetSerialNmuber = null;
                this.Dispose();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmProductPriceLevel frmProductPriceLevel_FormClosed. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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