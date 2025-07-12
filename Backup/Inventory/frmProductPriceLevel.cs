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
    public partial class frmProductPriceLevel : Form
    {
        public frmProductPriceLevel()
        {
            InitializeComponent();
        }
        private static frmProductPriceLevel ProductPriceLevel;
        private string strMarkedPrice;
        private string strSellingPrice;
        private Control ContFocus;
        private Control cntDescript;

        public static frmProductPriceLevel GetProductPriceLevel
        {
            get { return ProductPriceLevel; }
            set { ProductPriceLevel = value; }
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
                SellingPrice = dgProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString();
                //MarkedPrice = dgProductPriceLevel.SelectedRows[0].Cells[0].Value.ToString();
                

                if (prop_Focus != null)
                {
                    prop_Focus.Text = SellingPrice;
                }
                if (Cont_Descript != null)
                {
                    Cont_Descript.Text = MarkedPrice;
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
                frmProductPriceLevel.GetProductPriceLevel = null;
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
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmProductPriceLevel_Load(object sender, EventArgs e)
        {
           
        }

        private void dgProductPriceLevel_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (dgProductPriceLevel.Enabled)
                {
                    //this.PriceBatchColor();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PriceBatchColor()
        {
            try
            {
                clsProductPriceMaste objProductPriceMaste = new clsProductPriceMaste();
                if (dgProductPriceLevel.Rows.Count <= 0 || dgProductPriceLevel.Rows[0].Cells[0].Value == null)
                {
                    return;
                }

                int maxRow = dgProductPriceLevel.Rows.Count;
                for (int i = 0; i < maxRow; i++)
                {
                    int currentBatch = int.Parse(dgProductPriceLevel.Rows[i].Cells[2].Value.ToString());
                    objProductPriceMaste.GetCurrentRowColor("SELECT BatchColor from tb_PriceBatchColor WHERE (BatchNo = " + currentBatch + ")");
                    dgProductPriceLevel.Rows[i].DefaultCellStyle.BackColor = Color.FromName(objProductPriceMaste._currentRowColor);

                }


                //Check priceBatch
                //foreach (DataGridViewRow row in dataGridViewProductPriceLevel.Rows)
                //{
                //    if (Convert.ToInt16(row.Cells[0].Value.ToString()) == 1)
                //    {
                //        //row.DefaultCellStyle.BackColor = Color.Beige;
                //        row.DefaultCellStyle.BackColor = Color.FromName("Beige");
                //    }
                //    else if (Convert.ToInt16(row.Cells[0].Value.ToString()) == 2)
                //    {
                //        //row.DefaultCellStyle.BackColor = Color.MediumAquamarine;
                //        row.DefaultCellStyle.BackColor = Color.MediumAquamarine;
                //    }
                //    else if (Convert.ToInt16(row.Cells[0].Value.ToString()) == 3)
                //    {
                //        //row.DefaultCellStyle.BackColor = Color.CadetBlue;
                //        row.DefaultCellStyle.BackColor = Color.CadetBlue;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProductPriceLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

    }
}