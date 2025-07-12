using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmSearch : Form
    {

        private string StrCode;
        private string StrDescription;
        private Control ContFocus;
        private Control cntDescript;
        private string ContName;
        private static frmSearch search;

        public frmSearch()
        {
            InitializeComponent();
        }

        #region Properties
        //property for search
        public static frmSearch GetSearch
        {
            get
            {
                return search;
            }
            set
            {
                search = value;
            }

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
           // base.OnPaint(e);
        }

        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            search = null;
        }

        private void dgSearch_DoubleClick(object sender, EventArgs e)
        {

            this.selectRow();

        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hide the form...
            this.Hide();

            // Cancel the close...
            e.Cancel = true;
        }

        public bool Ismdi = true;
        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.getmdi().Cursor = Cursors.Default;
                if (Ismdi == true)
                { this.MdiParent = MainClass.getmdi(); }
                 
                //this.ShowDialog();
                this.Cursor = Cursors.Default;
                dgSearch.Columns[0].ReadOnly = true;
                dgSearch.Columns[1].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmSearch_Activated(object sender, EventArgs e)
        {
            MainClass.getmdi().Cursor = Cursors.Default;
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
        }

        public void selectRow()
        {

            try
            {
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
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //private void dgSearch_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    //clsDGV dg = new clsDGV();
        //    //          dg.invoke(e);
        //}
 
       
    }
}