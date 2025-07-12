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
    public partial class frmProductShortCodeDialog : Form
    {
        public frmProductShortCodeDialog()
        {
            InitializeComponent();
        }
        
        private string strMarkedPrice;
        private string strSellingPrice;
        private Control ContFocus;
        private Control cntDescript;

        private static frmProductShortCodeDialog frmShortCodeDialog;
        public static frmProductShortCodeDialog _frmShortCodeDialog
        {
            get { return frmShortCodeDialog; }
            set { frmShortCodeDialog = value; }
        }


        private string strProdCode;
        public string _strProdCode
        {
            get { return strProdCode; }
            set { strProdCode = value; }
        }

        private string strProdName;
        public string _strProdName
        {
            get { return strProdName; }
            set { strProdName = value; }
        }




        public string MarkedPrice
        {
            get { return strMarkedPrice; }
            set { strMarkedPrice = value; }
        }

        public string SellingPrice
        {
            get { return strSellingPrice; }
            set { strSellingPrice = value; }
        }

        public Control prop_Focus
        {
            get { return ContFocus; }
            set { ContFocus = value; }
        }

        public Control Cont_Descript
        {
            get { return cntDescript; }
            set { cntDescript = value; }
        }

        private void SelectRow()
        {
            try
            {
                strProdCode = dgProductDetails.SelectedRows[0].Cells[0].Value.ToString();
                strProdName = dgProductDetails.SelectedRows[0].Cells[1].Value.ToString();

                if (prop_Focus != null)
                {
                    prop_Focus.Text = strProdCode;
                }
                if (Cont_Descript != null)
                {
                    Cont_Descript.Text = strProdName;
                }
                prop_Focus.Focus();
                this.Close();
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

        private void frmProductPriceLevel_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                dgProductDetails.DataSource = null;
                frmShortCodeDialog = null;
                
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

        private void dgProductPriceLevel_DoubleClick(object sender, EventArgs e)
        {
            this.SelectRow();
        }

        private void dgProductPriceLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectRow();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmProductShortCodeDialog_Load(object sender, EventArgs e)
        {

        }

    }
}