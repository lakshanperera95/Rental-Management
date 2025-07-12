using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
using System.IO;

namespace Inventory
{
    public partial class frmProductSearchImage : Form
    {
        private string StrCode;
        private string StrDescription;
        private Control ContFocus;
        private Control cntDescript;

        private string ContName;
        private static frmProductSearchImage search;

        clsCommon objCommon = new clsCommon();

        private string strQuery;
        public string _strQuery
        {
            get { return strQuery; }
            set { strQuery = value; }
        }

        private DataSet ds;
        public DataSet _ds
        {
            get { return ds; }
            set { ds = value; }
        }



        public frmProductSearchImage()
        {
            InitializeComponent();
        }

        #region Properties
        //property for search
        public static frmProductSearchImage GetSearch
        {
            get { return search; }
            set { search = value; }
        }

        // property for StrCode
        public string Code
        {
            get { return StrCode; }
            set { StrCode = value; }
        }

        // property for StrDescription
        public string Descript
        {
            get { return StrDescription; }
            set { StrDescription = value; }
        }

        // property for ContFocus
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

        // property for ContName
        public string prop_Name
        {
            get { return ContName; }
            set { ContName = value; }
        }
      
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void frmProductSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            search = null;
            if (frmImageView.GetForm != null)
            {
                frmImageView.GetForm.Close();
            }
        }

        private void frmProductSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hide the form...
            this.Hide();

            // Cancel the close...
            e.Cancel = true;
        }

        private void frmProductSearch_Activated(object sender, EventArgs e)
        {
            MainClass.getmdi().Cursor = Cursors.Default;
        }

        private void frmProductSearch_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.getmdi().Cursor = Cursors.Default;
                this.MdiParent = MainClass.getmdi();
                this.Cursor = Cursors.Default;
                dgSearch.Columns[0].ReadOnly = true;
                dgSearch.Columns[1].ReadOnly = true;
                dgSearch.Columns[2].ReadOnly = true;
                dgSearch.Columns[3].ReadOnly = true;
                dgSearch.Columns[4].ReadOnly = true;
                dgSearch.Columns[5].ReadOnly = true;
                dgSearch.Columns[6].ReadOnly = true;
                dgSearch.Columns[7].ReadOnly = true;

                dgSearch.Columns[0].Width  = 120;
                dgSearch.Columns[1].Width = 250;
                dgSearch.Columns[2].Width = 70;
                dgSearch.Columns[3].Width = 70;
                dgSearch.Columns[4].Width = 70;
                dgSearch.Columns[5].Width = 70;
                dgSearch.Columns[6].Width = 70;
                dgSearch.Columns[7].Width = 70;
                dgSearch.RowTemplate.Height = 25;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgSearch_DoubleClick(object sender, EventArgs e)
        {
            this.selectRow();
        }

        private void dgSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.selectRow();
            }
            if(e.KeyCode == Keys.F1)
            {
                txtProdSearch.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                try
                {

                    string ProdCode = dgSearch.SelectedRows[0].Cells[0].Value.ToString();
                    objCommon.SqlStatement = "EXEC dbo.Sp_LoadItemDetails  @ProdCode = '"+ProdCode+"',@Loca = '"+LoginManager.LocaCode+"' ";
                    objCommon.GetDs();
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])objCommon.Ads.Tables[0].Rows[0]["Prod_Image"];
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);

                    if (frmImageView.GetForm != null)
                    {
                        frmImageView.GetForm.Close();
                    }
                    frmImageView.GetForm = new frmImageView();
                    frmImageView.GetForm.pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    frmImageView.GetForm.pbImage.BackgroundImage = Image.FromStream(stmBLOBData);
                    frmImageView.GetForm.MdiParent = MainClass.mdi;
                    frmImageView.GetForm.Show();

                    

                    frmImageView.GetForm.Location = new Point(MainClass.mdi.Location.X, this.Location.Y);

                    this.Focus();
                     
                }
                catch (Exception ex)
                {

                    clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
                }
            }
            if (e.KeyCode == Keys.Left ||e.KeyCode == Keys.Escape)
            {
                if (frmImageView.GetForm != null)
                    frmImageView.GetForm.Close();
            }
        }

        public void selectRow()
        {

            try
            {
                if (dgSearch.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("No Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dgSearch.SelectedRows[0].Cells[0].ToString() == "" || dgSearch.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Code = dgSearch.SelectedRows[0].Cells[0].Value.ToString();
                    Descript = dgSearch.SelectedRows[0].Cells[1].Value.ToString();

                    if (prop_Focus != null)
                    {
                        prop_Focus.Text = Code;
                    }
                    if (Cont_Descript != null)
                    {
                        Cont_Descript.Text = Descript;
                    }
                    prop_Focus.Focus();
                    txtProdSearch.Text = string.Empty;
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgSearch_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            clsDGV dg = new clsDGV();
            dg.invoke(e);
        }

        private void txtProdSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dgSearch.DataSource = null;
                //objCommon.getDataSet(strQuery, "dsProduct");
                BindingSource bs = new BindingSource();
                bs.DataSource = ds.Tables["dsProduct"];
                bs.Filter = "[Product Name] like '%" + txtProdSearch.Text + "%'";
                dgSearch.DataSource = bs;
                dgSearch.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtProdSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.selectRow();
            }
            if (e.KeyCode==Keys.Up || e.KeyCode==Keys.Down)
            {
                e.Handled = true;
            }
          
            if (dgSearch.Rows.Count > 0)
            {
                if (e.KeyCode==Keys.F1)
                {
                    dgSearch.SelectedRows[0].Selected = true;
                    dgSearch.Focus();
                }
                
                int select = dgSearch.SelectedRows[0].Index;
                if (e.KeyCode == Keys.Down && dgSearch.SelectedRows[0].Index != dgSearch.Rows.Count - 1)
                {
                    dgSearch.SelectedRows[0].Selected = false;
                    dgSearch.Rows[select + 1].Selected = true;
                    dgSearch.CurrentCell = dgSearch.Rows[select + 1].Cells[0];
                   
                }
                if (e.KeyCode == Keys.Up && dgSearch.SelectedRows[0].Index != 0)
                {
                    dgSearch.SelectedRows[0].Selected = false;
                    dgSearch.Rows[select - 1].Selected = true;
                    dgSearch.CurrentCell = dgSearch.Rows[select - 1].Cells[0];
                    
                }
            }
            

        }

        private void txtProdSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = false;
                    break;
                default:
                    break;
            }
        }

        private void txtProdSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dgSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgSearch_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void frmProductSearchImage_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (frmImageView.GetForm != null)
                {
                    frmImageView.GetForm.Close();
                }
            }
        }

        private void frmProductSearchImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (frmImageView.GetForm != null)
                    frmImageView.GetForm.Close();
            }
        }

        private void frmProductSearchImage_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                if (frmImageView.GetForm != null)
                    frmImageView.GetForm.Close();
            }
        }
    }
}