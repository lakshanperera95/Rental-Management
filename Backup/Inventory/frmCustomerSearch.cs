using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmCustomerSearch : Form
    {
        public frmCustomerSearch()
        {
            InitializeComponent();
        }

        private Control cntFocus;
        public Control Cont_Focus
        {
            get { return cntFocus; }
            set { cntFocus = value; }
        }

        private Control cntDescript;
        public Control Cont_Descript
        {
            get { return cntDescript; }
            set { cntDescript = value; }
        }

        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            try
            {
                if (clsMainClass.SearchDataset!=null)
                {
                    try
                    {
                        dgSearch.Refresh();

                        BindingSource bs = new BindingSource();
                        bs.DataSource = clsMainClass.SearchDataset.Tables[0];
                        //dgSearch.DataSource = clsMainClass.SearchDataset.Tables[0];

                        dgSearch.DataSource = null;
                        dgSearch.DataSource = bs;

                        dgSearch.Columns[0].Width = 78;
                        dgSearch.Columns[1].Width = 221;
                        dgSearch.Columns[2].Width = 78;
                        //dgSearch.Columns[3].DefaultCellStyle.Format = "d";
                        dgSearch.Columns[3].Width = 100;
                        dgSearch.Columns[4].Width = 87;
                        dgSearch.Columns[5].Width = 92;
                    }
                    catch (InvalidOperationException ex)
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void dgSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectedData();
                }
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void SelectedData()
        {
            if (dgSearch.SelectedRows[0].Cells[0].ToString() == "" || dgSearch.SelectedRows.Count < 0)
            {
                MessageBox.Show("Select Data");
            }
            else
            {
                clsMainClass.Cnt_Focus = dgSearch.SelectedRows[0].Cells[0].Value.ToString();
                clsMainClass.Cnt_Descrip = dgSearch.SelectedRows[0].Cells[1].Value.ToString();
                if (dgSearch.ColumnCount > 2)
                {
                    clsMainClass.MobileN = dgSearch.SelectedRows[0].Cells[2].Value.ToString();
                }             

                if (Cont_Focus != null)
                {
                    Cont_Focus.Text = clsMainClass.Cnt_Focus;
                }
                if (Cont_Descript != null)
                {
                    Cont_Descript.Text = clsMainClass.Cnt_Descrip;
                }
               
                //Cont_Focus.Focus();
                this.Hide();
            }
        }

        private void dgSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.SelectedData();
            }
            catch (Exception ex)
            {
                clsMainClass.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

    }
}