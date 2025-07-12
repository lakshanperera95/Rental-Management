using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmPaymentSearch : Form
    {

        private string StrCode;
        private string StrDescription;
        private Control ContFocus;
        private Control cntDescript;
        private string ContName;
        private static frmPaymentSearch search;

        public frmPaymentSearch()
        {
            InitializeComponent();
        }

        #region Properties
        //property for search
        public static frmPaymentSearch GetSearch
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

        private Control GetValue1;
        public Control Value1
        {
            get { return GetValue1; }
            set { GetValue1 = value; }
        }

        private Control GetValue2;
        public Control Value2
        {
            get { return GetValue2; }
            set { GetValue2 = value; }
        }

        private Control GetValue3;
        public Control Value3
        {
            get { return GetValue3; }
            set { GetValue3 = value; }
        }

        private Control GetValue4;
        public Control Value4
        {
            get { return GetValue4; }
            set { GetValue4 = value; }
        }

        private Control GetValue5;
        public Control Value5
        {
            get { return GetValue5; }
            set { GetValue5 = value; }
        }

        private string StrAmount;
        public string Amount
        {
            get { return StrAmount; }
            set { StrAmount = value; }
        }

        private string StrBank;
        public string Bank
        {
            get { return StrBank; }
            set { StrBank = value; }
        }

        private string StrBranch;
        public string Branch
        {
            get { return StrBranch; }
            set { StrBranch = value; }
        }

        private string StrChqueNo;
        public string ChqueNo
        {
            get { return StrChqueNo; }
            set { StrChqueNo = value; }
        }

        private string StrChqueDate;
        public string ChqueDate
        {
            get { return StrChqueDate; }
            set { StrChqueDate = value; }
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

        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.getmdi().Cursor = Cursors.Default;
                this.MdiParent = MainClass.getmdi();
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

        private void selectRow()
        {

            try
            {
                if (dgSearch.SelectedRows[0].Cells[0].ToString() == "" || dgSearch.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    

                    Bank = dgSearch.SelectedRows[0].Cells[0].Value.ToString();
                    ChqueDate = dgSearch.SelectedRows[0].Cells[2].Value.ToString();
                    ChqueNo = dgSearch.SelectedRows[0].Cells[3].Value.ToString();
                    Amount = dgSearch.SelectedRows[0].Cells[4].Value.ToString();
                    Branch=dgSearch.SelectedRows[0].Cells[1].Value.ToString();

                    //Bank_Name,Cheque_Date,Cheque_No,Amount,Branch 

                    if (Value1 != null)
                    {
                        Value1.Text = Amount;
                    }
                    if (Value2 != null)
                    {
                        Value2.Text = Bank;
                    }
                    if (Value3 != null)
                    {
                        Value3.Text = Branch;
                    }
                    if (Value4 != null)
                    {
                        Value4.Text = ChqueNo;
                    }
                    if (Value5 != null)
                    {
                        Value5.Text = ChqueDate;
                    }
                   

                    if (prop_Focus != null)
                    {
                        prop_Focus.Text = Code;
                    }
                    if (Cont_Descript != null)
                    {
                        Cont_Descript.Text = Descript;
                    }
                    Value1.Focus();
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

        private void dgSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //int rowIndex = e.RowIndex;
            //DataGridViewRow theRow = dgSearch.Rows[rowIndex];
            //if (rowIndex % 2 == 0)
            //{
            //    theRow.DefaultCellStyle.BackColor = Color.White;

            //}
            //else
            //{
            //    theRow.DefaultCellStyle.BackColor = Color.Yellow;
            //}
        }

    }
}