namespace Inventory
{
    partial class frmPaymentSetOff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalOutstanding = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPendingPaymentAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPendingDocumentAmount = new System.Windows.Forms.Label();
            this.lblPendingDocumentDate = new System.Windows.Forms.Label();
            this.lblPendingDocNo = new System.Windows.Forms.Label();
            this.dataGridViewPendingPayment = new System.Windows.Forms.DataGridView();
            this.docNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPaymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSupplierSearch = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalReturn = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReturnAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblReturnDocumentAmount = new System.Windows.Forms.Label();
            this.lblReturnDocumentDate = new System.Windows.Forms.Label();
            this.lblReturnDocNO = new System.Windows.Forms.Label();
            this.dataGridViewReturns = new System.Windows.Forms.DataGridView();
            this.docNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingReturnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSetOff = new System.Windows.Forms.DataGridView();
            this.grnDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grnTrDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grnBalanceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grnTrAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srnDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srnTrDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srnTrAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srnBalanceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedSetoffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPaymentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReturns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingReturnsBindingSource)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSetoffBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalOutstanding);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPendingPaymentAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblPendingDocumentAmount);
            this.groupBox2.Controls.Add(this.lblPendingDocumentDate);
            this.groupBox2.Controls.Add(this.lblPendingDocNo);
            this.groupBox2.Controls.Add(this.dataGridViewPendingPayment);
            this.groupBox2.Location = new System.Drawing.Point(4, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 246);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pending Payments";
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalOutstanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(348, 177);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(103, 21);
            this.lblTotalOutstanding.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total Outstanding";
            // 
            // txtPendingPaymentAmount
            // 
            this.txtPendingPaymentAmount.Location = new System.Drawing.Point(348, 217);
            this.txtPendingPaymentAmount.Name = "txtPendingPaymentAmount";
            this.txtPendingPaymentAmount.Size = new System.Drawing.Size(103, 20);
            this.txtPendingPaymentAmount.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Set Off Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Document";
            // 
            // lblPendingDocumentAmount
            // 
            this.lblPendingDocumentAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblPendingDocumentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDocumentAmount.Location = new System.Drawing.Point(248, 216);
            this.lblPendingDocumentAmount.Name = "lblPendingDocumentAmount";
            this.lblPendingDocumentAmount.Size = new System.Drawing.Size(99, 21);
            this.lblPendingDocumentAmount.TabIndex = 3;
            // 
            // lblPendingDocumentDate
            // 
            this.lblPendingDocumentDate.BackColor = System.Drawing.Color.LightCyan;
            this.lblPendingDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDocumentDate.Location = new System.Drawing.Point(152, 216);
            this.lblPendingDocumentDate.Name = "lblPendingDocumentDate";
            this.lblPendingDocumentDate.Size = new System.Drawing.Size(99, 21);
            this.lblPendingDocumentDate.TabIndex = 2;
            // 
            // lblPendingDocNo
            // 
            this.lblPendingDocNo.BackColor = System.Drawing.Color.LightCyan;
            this.lblPendingDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDocNo.Location = new System.Drawing.Point(51, 216);
            this.lblPendingDocNo.Name = "lblPendingDocNo";
            this.lblPendingDocNo.Size = new System.Drawing.Size(101, 21);
            this.lblPendingDocNo.TabIndex = 1;
            // 
            // dataGridViewPendingPayment
            // 
            this.dataGridViewPendingPayment.AllowUserToAddRows = false;
            this.dataGridViewPendingPayment.AllowUserToDeleteRows = false;
            this.dataGridViewPendingPayment.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewPendingPayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPendingPayment.AutoGenerateColumns = false;
            this.dataGridViewPendingPayment.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewPendingPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPendingPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNoDataGridViewTextBoxColumn,
            this.transactionDateDataGridViewTextBoxColumn,
            this.transactionAmountDataGridViewTextBoxColumn,
            this.balanceAmountDataGridViewTextBoxColumn});
            this.dataGridViewPendingPayment.DataSource = this.pendingPaymentsBindingSource;
            this.dataGridViewPendingPayment.Location = new System.Drawing.Point(7, 16);
            this.dataGridViewPendingPayment.Name = "dataGridViewPendingPayment";
            this.dataGridViewPendingPayment.ReadOnly = true;
            this.dataGridViewPendingPayment.Size = new System.Drawing.Size(445, 158);
            this.dataGridViewPendingPayment.TabIndex = 0;
            this.dataGridViewPendingPayment.DoubleClick += new System.EventHandler(this.dataGridViewPendingPayment_DoubleClick);
            // 
            // docNoDataGridViewTextBoxColumn
            // 
            this.docNoDataGridViewTextBoxColumn.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn.HeaderText = "Document";
            this.docNoDataGridViewTextBoxColumn.Name = "docNoDataGridViewTextBoxColumn";
            this.docNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionDateDataGridViewTextBoxColumn
            // 
            this.transactionDateDataGridViewTextBoxColumn.DataPropertyName = "Transaction_Date";
            this.transactionDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.transactionDateDataGridViewTextBoxColumn.Name = "transactionDateDataGridViewTextBoxColumn";
            this.transactionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionAmountDataGridViewTextBoxColumn
            // 
            this.transactionAmountDataGridViewTextBoxColumn.DataPropertyName = "Transaction_Amount";
            this.transactionAmountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.transactionAmountDataGridViewTextBoxColumn.Name = "transactionAmountDataGridViewTextBoxColumn";
            this.transactionAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // balanceAmountDataGridViewTextBoxColumn
            // 
            this.balanceAmountDataGridViewTextBoxColumn.DataPropertyName = "Balance_Amount";
            this.balanceAmountDataGridViewTextBoxColumn.HeaderText = "Balance Amount";
            this.balanceAmountDataGridViewTextBoxColumn.Name = "balanceAmountDataGridViewTextBoxColumn";
            this.balanceAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pendingPaymentsBindingSource
            // 
            this.pendingPaymentsBindingSource.DataMember = "PendingPayments";
            this.pendingPaymentsBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTempDocNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSupplierSearch);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSuppName);
            this.groupBox1.Controls.Add(this.txtSuppCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 47);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(786, 18);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Size = new System.Drawing.Size(128, 20);
            this.lblTempDocNo.TabIndex = 151;
            this.lblTempDocNo.Text = "0000000001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(685, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 150;
            this.label1.Text = "Document No:";
            // 
            // btnSupplierSearch
            // 
            this.btnSupplierSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSupplierSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSupplierSearch.Location = new System.Drawing.Point(501, 16);
            this.btnSupplierSearch.Name = "btnSupplierSearch";
            this.btnSupplierSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSupplierSearch.TabIndex = 3;
            this.btnSupplierSearch.UseVisualStyleBackColor = true;
            this.btnSupplierSearch.Click += new System.EventHandler(this.btnSupplierSearch_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.LightCyan;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Location = new System.Drawing.Point(571, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(103, 21);
            this.lblDate.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(532, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Date";
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(183, 16);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(312, 20);
            this.txtSuppName.TabIndex = 2;
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Location = new System.Drawing.Point(63, 16);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(116, 20);
            this.txtSuppCode.TabIndex = 1;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Enter += new System.EventHandler(this.txtSuppCode_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Supplier";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalReturn);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtReturnAmount);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lblReturnDocumentAmount);
            this.groupBox3.Controls.Add(this.lblReturnDocumentDate);
            this.groupBox3.Controls.Add(this.lblReturnDocNO);
            this.groupBox3.Controls.Add(this.dataGridViewReturns);
            this.groupBox3.Location = new System.Drawing.Point(468, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 246);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Returns";
            // 
            // lblTotalReturn
            // 
            this.lblTotalReturn.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalReturn.Location = new System.Drawing.Point(348, 177);
            this.lblTotalReturn.Name = "lblTotalReturn";
            this.lblTotalReturn.Size = new System.Drawing.Size(103, 21);
            this.lblTotalReturn.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Total Returns && Advance";
            // 
            // txtReturnAmount
            // 
            this.txtReturnAmount.Location = new System.Drawing.Point(348, 217);
            this.txtReturnAmount.Name = "txtReturnAmount";
            this.txtReturnAmount.Size = new System.Drawing.Size(103, 20);
            this.txtReturnAmount.TabIndex = 4;
            this.txtReturnAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReturnAmount_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(349, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Set Off Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Amount";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(149, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Document";
            // 
            // lblReturnDocumentAmount
            // 
            this.lblReturnDocumentAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblReturnDocumentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturnDocumentAmount.Location = new System.Drawing.Point(248, 216);
            this.lblReturnDocumentAmount.Name = "lblReturnDocumentAmount";
            this.lblReturnDocumentAmount.Size = new System.Drawing.Size(99, 21);
            this.lblReturnDocumentAmount.TabIndex = 3;
            // 
            // lblReturnDocumentDate
            // 
            this.lblReturnDocumentDate.BackColor = System.Drawing.Color.LightCyan;
            this.lblReturnDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturnDocumentDate.Location = new System.Drawing.Point(152, 216);
            this.lblReturnDocumentDate.Name = "lblReturnDocumentDate";
            this.lblReturnDocumentDate.Size = new System.Drawing.Size(99, 21);
            this.lblReturnDocumentDate.TabIndex = 2;
            // 
            // lblReturnDocNO
            // 
            this.lblReturnDocNO.BackColor = System.Drawing.Color.LightCyan;
            this.lblReturnDocNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturnDocNO.Location = new System.Drawing.Point(51, 216);
            this.lblReturnDocNO.Name = "lblReturnDocNO";
            this.lblReturnDocNO.Size = new System.Drawing.Size(101, 21);
            this.lblReturnDocNO.TabIndex = 1;
            // 
            // dataGridViewReturns
            // 
            this.dataGridViewReturns.AllowUserToAddRows = false;
            this.dataGridViewReturns.AllowUserToDeleteRows = false;
            this.dataGridViewReturns.AllowUserToResizeColumns = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewReturns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewReturns.AutoGenerateColumns = false;
            this.dataGridViewReturns.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReturns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNoDataGridViewTextBoxColumn1,
            this.transactionDateDataGridViewTextBoxColumn1,
            this.transactionAmountDataGridViewTextBoxColumn1,
            this.balanceAmountDataGridViewTextBoxColumn1});
            this.dataGridViewReturns.DataSource = this.pendingReturnsBindingSource;
            this.dataGridViewReturns.Location = new System.Drawing.Point(7, 16);
            this.dataGridViewReturns.Name = "dataGridViewReturns";
            this.dataGridViewReturns.ReadOnly = true;
            this.dataGridViewReturns.Size = new System.Drawing.Size(445, 158);
            this.dataGridViewReturns.TabIndex = 0;
            this.dataGridViewReturns.DoubleClick += new System.EventHandler(this.dataGridViewReturns_DoubleClick);
            // 
            // docNoDataGridViewTextBoxColumn1
            // 
            this.docNoDataGridViewTextBoxColumn1.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn1.HeaderText = "Document";
            this.docNoDataGridViewTextBoxColumn1.Name = "docNoDataGridViewTextBoxColumn1";
            this.docNoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // transactionDateDataGridViewTextBoxColumn1
            // 
            this.transactionDateDataGridViewTextBoxColumn1.DataPropertyName = "Transaction_Date";
            this.transactionDateDataGridViewTextBoxColumn1.HeaderText = "Date";
            this.transactionDateDataGridViewTextBoxColumn1.Name = "transactionDateDataGridViewTextBoxColumn1";
            this.transactionDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // transactionAmountDataGridViewTextBoxColumn1
            // 
            this.transactionAmountDataGridViewTextBoxColumn1.DataPropertyName = "Transaction_Amount";
            this.transactionAmountDataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.transactionAmountDataGridViewTextBoxColumn1.Name = "transactionAmountDataGridViewTextBoxColumn1";
            this.transactionAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // balanceAmountDataGridViewTextBoxColumn1
            // 
            this.balanceAmountDataGridViewTextBoxColumn1.DataPropertyName = "Balance_Amount";
            this.balanceAmountDataGridViewTextBoxColumn1.HeaderText = "Balance Amount";
            this.balanceAmountDataGridViewTextBoxColumn1.Name = "balanceAmountDataGridViewTextBoxColumn1";
            this.balanceAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // pendingReturnsBindingSource
            // 
            this.pendingReturnsBindingSource.DataMember = "PendingReturns";
            this.pendingReturnsBindingSource.DataSource = this.dsForReports;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnApply);
            this.groupBox5.Controls.Add(this.toolStrip1);
            this.groupBox5.Location = new System.Drawing.Point(3, 437);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(923, 83);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(801, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(679, 19);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(3, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(917, 70);
            this.toolStrip1.TabIndex = 134;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewSetOff);
            this.groupBox4.Location = new System.Drawing.Point(3, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(922, 147);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected Set Off Document";
            // 
            // dataGridViewSetOff
            // 
            this.dataGridViewSetOff.AllowUserToAddRows = false;
            this.dataGridViewSetOff.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSetOff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSetOff.AutoGenerateColumns = false;
            this.dataGridViewSetOff.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewSetOff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSetOff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grnDocDataGridViewTextBoxColumn,
            this.grnTrDateDataGridViewTextBoxColumn,
            this.grnBalanceAmountDataGridViewTextBoxColumn,
            this.grnTrAmountDataGridViewTextBoxColumn,
            this.srnDocDataGridViewTextBoxColumn,
            this.srnTrDateDataGridViewTextBoxColumn,
            this.srnTrAmountDataGridViewTextBoxColumn,
            this.srnBalanceAmountDataGridViewTextBoxColumn});
            this.dataGridViewSetOff.DataSource = this.selectedSetoffBindingSource;
            this.dataGridViewSetOff.Location = new System.Drawing.Point(9, 16);
            this.dataGridViewSetOff.Name = "dataGridViewSetOff";
            this.dataGridViewSetOff.ReadOnly = true;
            this.dataGridViewSetOff.Size = new System.Drawing.Size(906, 125);
            this.dataGridViewSetOff.TabIndex = 0;
            this.dataGridViewSetOff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewSetOff_KeyDown);
            // 
            // grnDocDataGridViewTextBoxColumn
            // 
            this.grnDocDataGridViewTextBoxColumn.DataPropertyName = "Grn_Doc";
            this.grnDocDataGridViewTextBoxColumn.HeaderText = "Selected Document";
            this.grnDocDataGridViewTextBoxColumn.Name = "grnDocDataGridViewTextBoxColumn";
            this.grnDocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grnTrDateDataGridViewTextBoxColumn
            // 
            this.grnTrDateDataGridViewTextBoxColumn.DataPropertyName = "Grn_Tr_Date";
            this.grnTrDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.grnTrDateDataGridViewTextBoxColumn.Name = "grnTrDateDataGridViewTextBoxColumn";
            this.grnTrDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grnBalanceAmountDataGridViewTextBoxColumn
            // 
            this.grnBalanceAmountDataGridViewTextBoxColumn.DataPropertyName = "Grn_Balance_Amount";
            this.grnBalanceAmountDataGridViewTextBoxColumn.HeaderText = "Balance Amount";
            this.grnBalanceAmountDataGridViewTextBoxColumn.Name = "grnBalanceAmountDataGridViewTextBoxColumn";
            this.grnBalanceAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.grnBalanceAmountDataGridViewTextBoxColumn.Width = 155;
            // 
            // grnTrAmountDataGridViewTextBoxColumn
            // 
            this.grnTrAmountDataGridViewTextBoxColumn.DataPropertyName = "Grn_Tr_Amount";
            this.grnTrAmountDataGridViewTextBoxColumn.HeaderText = "Set Off Amount";
            this.grnTrAmountDataGridViewTextBoxColumn.Name = "grnTrAmountDataGridViewTextBoxColumn";
            this.grnTrAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // srnDocDataGridViewTextBoxColumn
            // 
            this.srnDocDataGridViewTextBoxColumn.DataPropertyName = "Srn_Doc";
            this.srnDocDataGridViewTextBoxColumn.HeaderText = "Set Off Document";
            this.srnDocDataGridViewTextBoxColumn.Name = "srnDocDataGridViewTextBoxColumn";
            this.srnDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.srnDocDataGridViewTextBoxColumn.Width = 105;
            // 
            // srnTrDateDataGridViewTextBoxColumn
            // 
            this.srnTrDateDataGridViewTextBoxColumn.DataPropertyName = "Srn_Tr_Date";
            this.srnTrDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.srnTrDateDataGridViewTextBoxColumn.Name = "srnTrDateDataGridViewTextBoxColumn";
            this.srnTrDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // srnTrAmountDataGridViewTextBoxColumn
            // 
            this.srnTrAmountDataGridViewTextBoxColumn.DataPropertyName = "Srn_Tr_Amount";
            this.srnTrAmountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.srnTrAmountDataGridViewTextBoxColumn.Name = "srnTrAmountDataGridViewTextBoxColumn";
            this.srnTrAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // srnBalanceAmountDataGridViewTextBoxColumn
            // 
            this.srnBalanceAmountDataGridViewTextBoxColumn.DataPropertyName = "Srn_Balance_Amount";
            this.srnBalanceAmountDataGridViewTextBoxColumn.HeaderText = "Balance Amount";
            this.srnBalanceAmountDataGridViewTextBoxColumn.Name = "srnBalanceAmountDataGridViewTextBoxColumn";
            this.srnBalanceAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // selectedSetoffBindingSource
            // 
            this.selectedSetoffBindingSource.DataMember = "SelectedSetoff";
            this.selectedSetoffBindingSource.DataSource = this.dsForReports;
            // 
            // frmPaymentSetOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(930, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentSetOff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Set Off";
            this.Load += new System.EventHandler(this.frmPaymentSetOff_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPaymentSetOff_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPaymentSetOff_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPaymentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReturns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingReturnsBindingSource)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSetoffBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalOutstanding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPendingPaymentAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPendingDocumentAmount;
        private System.Windows.Forms.Label lblPendingDocumentDate;
        private System.Windows.Forms.Label lblPendingDocNo;
        private System.Windows.Forms.DataGridView dataGridViewPendingPayment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSupplierSearch;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalReturn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReturnAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblReturnDocumentAmount;
        private System.Windows.Forms.Label lblReturnDocumentDate;
        private System.Windows.Forms.Label lblReturnDocNO;
        private System.Windows.Forms.DataGridView dataGridViewReturns;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.BindingSource pendingPaymentsBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.BindingSource pendingReturnsBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewSetOff;
        private System.Windows.Forms.BindingSource selectedSetoffBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grnDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grnTrDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grnBalanceAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grnTrAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnTrDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnTrAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srnBalanceAmountDataGridViewTextBoxColumn;
        public System.Windows.Forms.TextBox txtSuppName;
        public System.Windows.Forms.TextBox txtSuppCode;
    }
}