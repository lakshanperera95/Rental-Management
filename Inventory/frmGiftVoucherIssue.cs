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
    public partial class frmGiftVoucherIssue : Form
    {
        private GroupBox groupBox4;
        private Button btnApply;
        private Button btnClear;
        private Button btnExit;
        private BindingSource dtGiftIssueBindingSource;
        private IContainer components;
        private DateTimePicker dpDate;
        private Label label5;
        private Button btnAddVoucher;
        private Button btnCustSearch;
        private Label lb;
        private TextBox txtCustName;
        private TextBox txtGiftvNo;
        private TextBox txtCustCode;
        private Label lblDocNo;
        private Label label4;
        private TextBox txtGftAmount;
        private Label label3;
        private DataGridView dgVouchers;
        private Label label2;
        private TextBox txtTotal;
        private Label label1;
        private ComboBox cmbType;
        private Label label6;
        private DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private dtForGrids dtForGrids;
    
        public frmGiftVoucherIssue()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtForGrids = new Inventory.dtForGrids();
            this.dtGiftIssueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddVoucher = new System.Windows.Forms.Button();
            this.btnCustSearch = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtGiftvNo = new System.Windows.Forms.TextBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGftAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgVouchers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.docNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtForGrids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGiftIssueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVouchers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.btnApply);
            this.groupBox4.Controls.Add(this.btnClear);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 379);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(476, 58);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.Black;
            this.btnApply.Location = new System.Drawing.Point(177, 11);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 38);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(280, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(380, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtForGrids
            // 
            this.dtForGrids.DataSetName = "dtForGrids";
            this.dtForGrids.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtGiftIssueBindingSource
            // 
            this.dtGiftIssueBindingSource.DataMember = "dtGiftIssue";
            this.dtGiftIssueBindingSource.DataSource = this.dtForGrids;
            // 
            // dpDate
            // 
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDate.Location = new System.Drawing.Point(366, 14);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(97, 20);
            this.dpDate.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Total";
            // 
            // btnAddVoucher
            // 
            this.btnAddVoucher.BackColor = System.Drawing.Color.Silver;
            this.btnAddVoucher.Location = new System.Drawing.Point(249, 146);
            this.btnAddVoucher.Name = "btnAddVoucher";
            this.btnAddVoucher.Size = new System.Drawing.Size(75, 23);
            this.btnAddVoucher.TabIndex = 4;
            this.btnAddVoucher.Text = "Add";
            this.btnAddVoucher.UseVisualStyleBackColor = false;
            this.btnAddVoucher.Click += new System.EventHandler(this.btnAddVoucher_Click);
            // 
            // btnCustSearch
            // 
            this.btnCustSearch.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCustSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustSearch.Location = new System.Drawing.Point(364, 48);
            this.btnCustSearch.Name = "btnCustSearch";
            this.btnCustSearch.Size = new System.Drawing.Size(25, 22);
            this.btnCustSearch.TabIndex = 2;
            this.btnCustSearch.Text = "...";
            this.btnCustSearch.UseVisualStyleBackColor = false;
            this.btnCustSearch.Click += new System.EventHandler(this.btnCustSearch_Click);
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(12, 20);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(73, 13);
            this.lb.TabIndex = 26;
            this.lb.Text = "Document No";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(168, 49);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(196, 20);
            this.txtCustName.TabIndex = 1;
            // 
            // txtGiftvNo
            // 
            this.txtGiftvNo.Location = new System.Drawing.Point(92, 122);
            this.txtGiftvNo.Name = "txtGiftvNo";
            this.txtGiftvNo.Size = new System.Drawing.Size(151, 20);
            this.txtGiftvNo.TabIndex = 3;
            this.txtGiftvNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiftvNo_KeyDown);
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(92, 49);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(75, 20);
            this.txtCustCode.TabIndex = 0;
            this.txtCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocNo.Location = new System.Drawing.Point(100, 20);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(62, 15);
            this.lblDocNo.TabIndex = 28;
            this.lblDocNo.Text = "GIF000001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Cutomer";
            // 
            // txtGftAmount
            // 
            this.txtGftAmount.Location = new System.Drawing.Point(92, 148);
            this.txtGftAmount.Name = "txtGftAmount";
            this.txtGftAmount.ReadOnly = true;
            this.txtGftAmount.Size = new System.Drawing.Size(151, 20);
            this.txtGftAmount.TabIndex = 29;
            this.txtGftAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGftAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGftAmount_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Amount";
            // 
            // dgVouchers
            // 
            this.dgVouchers.AllowUserToAddRows = false;
            this.dgVouchers.AllowUserToDeleteRows = false;
            this.dgVouchers.AutoGenerateColumns = false;
            this.dgVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVouchers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNoDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dgVouchers.DataSource = this.dtGiftIssueBindingSource;
            this.dgVouchers.Location = new System.Drawing.Point(55, 193);
            this.dgVouchers.Name = "dgVouchers";
            this.dgVouchers.ReadOnly = true;
            this.dgVouchers.Size = new System.Drawing.Size(409, 152);
            this.dgVouchers.TabIndex = 31;
            this.dgVouchers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgVouchers_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Voucher No";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(364, 351);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 32;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "System",
            "Manual"});
            this.cmbType.Location = new System.Drawing.Point(92, 95);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(151, 21);
            this.cmbType.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Voucher Type";
            // 
            // docNoDataGridViewTextBoxColumn
            // 
            this.docNoDataGridViewTextBoxColumn.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn.HeaderText = "Book No";
            this.docNoDataGridViewTextBoxColumn.Name = "docNoDataGridViewTextBoxColumn";
            this.docNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.docNoDataGridViewTextBoxColumn.Width = 130;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Voucher No";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 130;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmGiftVoucherIssue
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(476, 437);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddVoucher);
            this.Controls.Add(this.btnCustSearch);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.txtGiftvNo);
            this.Controls.Add(this.txtCustCode);
            this.Controls.Add(this.lblDocNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGftAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgVouchers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGiftVoucherIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGiftVoucherIssue_FormClosed);
            this.Load += new System.EventHandler(this.frmGiftVoucherIssue_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtForGrids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGiftIssueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVouchers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtGftAmount_TextChanged(object sender, EventArgs e)
        {

        }

        frmSearch search = new frmSearch();
        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search ==null)
                {                    search =new frmSearch();
                }
                string Sqlst = "";
               if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() == string.Empty)
                {
                    Sqlst = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE  Inactive=0 ORDER BY Cust_Code";
                }
                else
                {
                    if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                    {
                        Sqlst = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Inactive=0 AND Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                        {
                            Sqlst = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Inactive=0  AND Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%' ORDER BY Cust_Name";
                        }
                        else
                        {
                            Sqlst = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name] FROM Customer WHERE Inactive=0 ORDER BY Cust_Code";
                        }
                    }
                }

                search.dgSearch.DataSource = ObjGifIssue.GetDs(Sqlst).Tables[0];
                search.prop_Focus = txtCustCode;
                search.Cont_Descript = txtCustName;
                search.Show();

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        clsGiftVoucherIssue ObjGifIssue = new clsGiftVoucherIssue();
        private static frmGiftVoucherIssue IsForm;
        public static frmGiftVoucherIssue GetForm
        {
            get { return IsForm; }
            set { IsForm = value; }
        }
        private void frmGiftVoucherIssue_Load(object sender, EventArgs e)
        {
            try
            {
                ObjGifIssue.GetTempDocumentNo("GVI");
                lblDocNo.Text = ObjGifIssue.TempDocNo;

                txtCustCode.Text = "GIFT";
                txtCustCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmGiftVoucherIssue_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsForm = null;
        }

        private void txtGiftvNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtGiftvNo.Text.Trim() != string.Empty)
                {
                    if (cmbType.SelectedIndex != -1)
                    {
                        if (cmbType.SelectedIndex == 0)
                        {
                            string Sqlst = "SELECT Amount FROM dbo.gif_Voucher WHERE Sale_Pen_Recall='T' AND Issued='F'   AND VisibleCode='" + txtGiftvNo.Text.Trim() + "'";
                            if (ObjGifIssue.GetDs(Sqlst).Tables[0].Rows.Count > 0)
                            {
                                txtGftAmount.ReadOnly = true;
                                txtGftAmount.Text = ObjGifIssue.Ds.Tables[0].Rows[0][0].ToString();
                                btnAddVoucher.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Gift Voucher", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtGiftvNo.Text = string.Empty;
                                txtGiftvNo.Focus();
                            }
                        }
                        else
                        {
                            txtGftAmount.ReadOnly = false;
                            txtGftAmount.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                 txtGiftvNo_KeyDown(sender, new KeyEventArgs(Keys.Enter));


                if(cmbType.SelectedIndex==-1)
                {

                    MessageBox.Show("Gift Voucher type not Selected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbType.Focus();
                }
                if (txtGiftvNo.Text.Trim() == string.Empty)
                {

                    MessageBox.Show("Gift Voucher No not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtGiftvNo.Focus();
                }

                if (cmbType.SelectedIndex != -1)
                {
                    if (cmbType.SelectedIndex == 0)
                    {
                        string Sqlst = "SELECT Amount FROM dbo.gif_Voucher WHERE Sale_Pen_Recall='T' AND Issued='F'  AND VisibleCode='" + txtGiftvNo.Text.Trim() + "'";
                        if (ObjGifIssue.GetDs(Sqlst).Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Invalid Gift Voucher", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtGiftvNo.Text = string.Empty;
                            txtGiftvNo.Focus();
                            return;
                        }
                     
                    }
                    else
                    {
                        string Sqlst = "SELECT Amount FROM dbo.gif_Voucher WHERE   VisibleCode='" + txtGiftvNo.Text.Trim() + "'";
                        if (ObjGifIssue.GetDs(Sqlst).Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Gift Voucher number Allready Exists", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtGiftvNo.Text = string.Empty;
                            txtGiftvNo.Focus();
                            return;
                        }
                    }
                }

                if ( (clsValidation.isNumeric(txtGftAmount.Text,System.Globalization.NumberStyles.Currency)==false) || Convert.ToDecimal(txtGftAmount.Text)==0)
                {

                    MessageBox.Show("Invaild Gift Voucher Amount", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtGftAmount.Focus();
                    return;
                }
                
                ObjGifIssue.UpdateGIIssue(lblDocNo.Text, txtGiftvNo.Text.Trim(),Convert.ToDecimal(txtGftAmount.Text.Trim()),cmbType.Text);
                LoadTempData();

                cmbType.Enabled = false;
                txtGiftvNo.Focus();



            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        public void LoadTempData()
        {
            try
            {
                ObjGifIssue.LoadData(lblDocNo.Text.Trim());


                dgVouchers.DataSource = ObjGifIssue.Ds.Tables[0];
                txtTotal.Text = ObjGifIssue.Ds.Tables[1].Rows[0][0].ToString();
                if(dgVouchers.Rows.Count==0)
                {
                    cmbType.Enabled = true;
                }

                txtGftAmount.Text = txtGiftvNo.Text = string.Empty;
                txtGiftvNo.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }    
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnExit.PerformClick();
            frmGiftVoucherIssue.GetForm = new frmGiftVoucherIssue();
            frmGiftVoucherIssue.GetForm.MdiParent = MainClass.mdi;
            frmGiftVoucherIssue.GetForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgVouchers_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 && dgVouchers.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {

                    ObjGifIssue.DeleteData(lblDocNo.Text.Trim(), dgVouchers.SelectedRows[0].Cells[1].Value.ToString());

                    LoadTempData();


                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }   
        }
        frmPayment Payment = new frmPayment("", "", "", "", "");
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                ObjGifIssue.LoadData(lblDocNo.Text.Trim());

                if (txtCustCode.Text.Trim()==string.Empty || txtCustName.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Customer Not Selected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustCode.Focus();
                }

                string Sqlst = "SELECT * FROM Customer WHERE  Inactive=0  and  Cust_Code ='"+txtCustCode.Text.Trim()+"' ORDER BY Cust_Code";
                if (ObjGifIssue.GetDs(Sqlst).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Customer not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (dgVouchers.Rows.Count == 0)
                {
                    MessageBox.Show("Data not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (Payment != null)
                { Payment.Close(); }
                Payment = new frmPayment(txtTotal.Text.Trim(),"CREDIT", lblDocNo.Text.Trim(), txtCustCode.Text.Trim(),"GIFTPAY");
                Payment.ShowDialog();


                decimal PayAmount = Payment.PayedAmount;
                decimal Total = Convert.ToDecimal(txtTotal.Text.Trim());

                if (Total > PayAmount)
                {
                    MessageBox.Show("Invalid Payment Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (MessageBox.Show("Do you want to Apply This Document. ", "Gift Voucher Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    frmReportViewer objRepViewer = new frmReportViewer();
                    DataSet ds = new DataSet();

                    ds = ObjGifIssue.ApplyData(lblDocNo.Text.Trim(),dpDate.Text,txtCustCode.Text.Trim(),cmbType.Text);


                    if (MessageBox.Show("Gift Voucher Issue Applied..!Do you Want to view the Receipt ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ds.Tables[0].TableName = "tbPaidPaymentSummary";
                        ds.Tables[1].TableName = "CompanyProfile";
                        ds.Tables[2].TableName = "tbPaidPaymentMode";

                        objRepViewer.DirectPrintVerRep.Load(@"..\DirectReports\rptCustomerPayment_eng.rpt");
                        objRepViewer.DirectPrintVerRep.SetDataSource(ds);
                        objRepViewer.DirectPrintVerRep.OpenSubreport("rptSupplierPaymentMode").SetDataSource(ds);
                        objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                        objRepViewer.WindowState = FormWindowState.Maximized;
                        objRepViewer.Show();
                    }
                    btnClear.PerformClick();

                }


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }   
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim()!=string.Empty)
            {
                string Sqlst = "SELECT Cust_Code,Cust_Name FROM Customer WHERE  Inactive=0  and  Cust_Code ='" + txtCustCode.Text.Trim() + "' ORDER BY Cust_Code";
              ObjGifIssue.GetDs(Sqlst);
                if (ObjGifIssue.Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Customer not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustCode.Text = txtCustName.Text = string.Empty;
                    txtCustCode.Focus();
                    return;
                }
                else
                {
                    txtCustCode.Text = ObjGifIssue.Ds.Tables[0].Rows[0][0].ToString();
                    txtCustName.Text = ObjGifIssue.Ds.Tables[0].Rows[0][1].ToString();
                }
                txtGiftvNo.Focus();
            }
        }

        private void txtGftAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnAddVoucher.Focus();

            }
        }
    }
}