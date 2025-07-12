namespace Inventory
{
    partial class frmSupplierPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSupplierSearch = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.dataGridViewPendingPayments = new System.Windows.Forms.DataGridView();
            this.docNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPaymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalSelectedValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewSelectedPayments = new System.Windows.Forms.DataGridView();
            this.docNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedPaymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.paymentModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.txtPaymentModeAmount = new System.Windows.Forms.TextBox();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPaymentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPaymentsBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDetailsBindingSource)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1019, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(881, 18);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Size = new System.Drawing.Size(128, 20);
            this.lblTempDocNo.TabIndex = 151;
            this.lblTempDocNo.Text = "0000000001";
            this.lblTempDocNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(780, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 150;
            this.label1.Text = "Document No:";
            // 
            // btnSupplierSearch
            // 
            this.btnSupplierSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSupplierSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSupplierSearch.Location = new System.Drawing.Point(544, 16);
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
            this.lblDate.Location = new System.Drawing.Point(667, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(103, 21);
            this.lblDate.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(616, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Date";
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(226, 16);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(312, 20);
            this.txtSuppName.TabIndex = 2;
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Location = new System.Drawing.Point(83, 16);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(137, 20);
            this.txtSuppCode.TabIndex = 1;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Enter += new System.EventHandler(this.txtSuppCode_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Supplier";
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
            this.groupBox2.Controls.Add(this.dataGridViewPendingPayments);
            this.groupBox2.Location = new System.Drawing.Point(5, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 261);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pending Payments";
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalOutstanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(348, 191);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(103, 21);
            this.lblTotalOutstanding.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total Outstanding";
            // 
            // txtPendingPaymentAmount
            // 
            this.txtPendingPaymentAmount.Location = new System.Drawing.Point(348, 237);
            this.txtPendingPaymentAmount.Name = "txtPendingPaymentAmount";
            this.txtPendingPaymentAmount.Size = new System.Drawing.Size(103, 20);
            this.txtPendingPaymentAmount.TabIndex = 4;
            this.txtPendingPaymentAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPendingPaymentAmount_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Payment Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Document";
            // 
            // lblPendingDocumentAmount
            // 
            this.lblPendingDocumentAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblPendingDocumentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDocumentAmount.Location = new System.Drawing.Point(248, 236);
            this.lblPendingDocumentAmount.Name = "lblPendingDocumentAmount";
            this.lblPendingDocumentAmount.Size = new System.Drawing.Size(99, 21);
            this.lblPendingDocumentAmount.TabIndex = 3;
            // 
            // lblPendingDocumentDate
            // 
            this.lblPendingDocumentDate.BackColor = System.Drawing.Color.LightCyan;
            this.lblPendingDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDocumentDate.Location = new System.Drawing.Point(152, 236);
            this.lblPendingDocumentDate.Name = "lblPendingDocumentDate";
            this.lblPendingDocumentDate.Size = new System.Drawing.Size(99, 21);
            this.lblPendingDocumentDate.TabIndex = 2;
            // 
            // lblPendingDocNo
            // 
            this.lblPendingDocNo.BackColor = System.Drawing.Color.LightCyan;
            this.lblPendingDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingDocNo.Location = new System.Drawing.Point(51, 236);
            this.lblPendingDocNo.Name = "lblPendingDocNo";
            this.lblPendingDocNo.Size = new System.Drawing.Size(101, 21);
            this.lblPendingDocNo.TabIndex = 1;
            // 
            // dataGridViewPendingPayments
            // 
            this.dataGridViewPendingPayments.AllowUserToAddRows = false;
            this.dataGridViewPendingPayments.AllowUserToDeleteRows = false;
            this.dataGridViewPendingPayments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewPendingPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPendingPayments.AutoGenerateColumns = false;
            this.dataGridViewPendingPayments.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewPendingPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPendingPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNoDataGridViewTextBoxColumn,
            this.transactionDateDataGridViewTextBoxColumn,
            this.transactionAmountDataGridViewTextBoxColumn,
            this.balanceAmountDataGridViewTextBoxColumn});
            this.dataGridViewPendingPayments.DataSource = this.pendingPaymentsBindingSource;
            this.dataGridViewPendingPayments.Location = new System.Drawing.Point(7, 16);
            this.dataGridViewPendingPayments.Name = "dataGridViewPendingPayments";
            this.dataGridViewPendingPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPendingPayments.Size = new System.Drawing.Size(445, 170);
            this.dataGridViewPendingPayments.TabIndex = 0;
            this.dataGridViewPendingPayments.DoubleClick += new System.EventHandler(this.dataGridViewPendingPayments_DoubleClick);
            // 
            // docNoDataGridViewTextBoxColumn
            // 
            this.docNoDataGridViewTextBoxColumn.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn.HeaderText = "Document";
            this.docNoDataGridViewTextBoxColumn.Name = "docNoDataGridViewTextBoxColumn";
            this.docNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.docNoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // transactionDateDataGridViewTextBoxColumn
            // 
            this.transactionDateDataGridViewTextBoxColumn.DataPropertyName = "Transaction_Date";
            this.transactionDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.transactionDateDataGridViewTextBoxColumn.Name = "transactionDateDataGridViewTextBoxColumn";
            this.transactionDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.transactionDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // transactionAmountDataGridViewTextBoxColumn
            // 
            this.transactionAmountDataGridViewTextBoxColumn.DataPropertyName = "Transaction_Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.transactionAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.transactionAmountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.transactionAmountDataGridViewTextBoxColumn.Name = "transactionAmountDataGridViewTextBoxColumn";
            this.transactionAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.transactionAmountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.transactionAmountDataGridViewTextBoxColumn.Width = 93;
            // 
            // balanceAmountDataGridViewTextBoxColumn
            // 
            this.balanceAmountDataGridViewTextBoxColumn.DataPropertyName = "Balance_Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.balanceAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.balanceAmountDataGridViewTextBoxColumn.HeaderText = "Balance Amount";
            this.balanceAmountDataGridViewTextBoxColumn.Name = "balanceAmountDataGridViewTextBoxColumn";
            this.balanceAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.balanceAmountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.balanceAmountDataGridViewTextBoxColumn.Width = 93;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalSelectedValue);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dataGridViewSelectedPayments);
            this.groupBox3.Location = new System.Drawing.Point(469, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 261);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Documents";
            // 
            // lblTotalSelectedValue
            // 
            this.lblTotalSelectedValue.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalSelectedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSelectedValue.Location = new System.Drawing.Point(446, 232);
            this.lblTotalSelectedValue.Name = "lblTotalSelectedValue";
            this.lblTotalSelectedValue.Size = new System.Drawing.Size(103, 21);
            this.lblTotalSelectedValue.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total Selected Payment";
            // 
            // dataGridViewSelectedPayments
            // 
            this.dataGridViewSelectedPayments.AllowUserToAddRows = false;
            this.dataGridViewSelectedPayments.AllowUserToDeleteRows = false;
            this.dataGridViewSelectedPayments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSelectedPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSelectedPayments.AutoGenerateColumns = false;
            this.dataGridViewSelectedPayments.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewSelectedPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNoDataGridViewTextBoxColumn1,
            this.transactionDateDataGridViewTextBoxColumn1,
            this.transactionAmountDataGridViewTextBoxColumn1,
            this.balanceAmountDataGridViewTextBoxColumn1,
            this.paidAmountDataGridViewTextBoxColumn});
            this.dataGridViewSelectedPayments.DataSource = this.selectedPaymentsBindingSource;
            this.dataGridViewSelectedPayments.Location = new System.Drawing.Point(5, 16);
            this.dataGridViewSelectedPayments.Name = "dataGridViewSelectedPayments";
            this.dataGridViewSelectedPayments.Size = new System.Drawing.Size(544, 213);
            this.dataGridViewSelectedPayments.TabIndex = 0;
            this.dataGridViewSelectedPayments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewSelectedPayments_KeyDown);
            // 
            // docNoDataGridViewTextBoxColumn1
            // 
            this.docNoDataGridViewTextBoxColumn1.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn1.HeaderText = "Document";
            this.docNoDataGridViewTextBoxColumn1.Name = "docNoDataGridViewTextBoxColumn1";
            this.docNoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.docNoDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // transactionDateDataGridViewTextBoxColumn1
            // 
            this.transactionDateDataGridViewTextBoxColumn1.DataPropertyName = "Transaction_Date";
            this.transactionDateDataGridViewTextBoxColumn1.HeaderText = "Date";
            this.transactionDateDataGridViewTextBoxColumn1.Name = "transactionDateDataGridViewTextBoxColumn1";
            this.transactionDateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.transactionDateDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // transactionAmountDataGridViewTextBoxColumn1
            // 
            this.transactionAmountDataGridViewTextBoxColumn1.DataPropertyName = "Transaction_Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.transactionAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.transactionAmountDataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.transactionAmountDataGridViewTextBoxColumn1.Name = "transactionAmountDataGridViewTextBoxColumn1";
            this.transactionAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            this.transactionAmountDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.transactionAmountDataGridViewTextBoxColumn1.Width = 95;
            // 
            // balanceAmountDataGridViewTextBoxColumn1
            // 
            this.balanceAmountDataGridViewTextBoxColumn1.DataPropertyName = "Balance_Amount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.balanceAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.balanceAmountDataGridViewTextBoxColumn1.HeaderText = "Balance Amount";
            this.balanceAmountDataGridViewTextBoxColumn1.Name = "balanceAmountDataGridViewTextBoxColumn1";
            this.balanceAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            this.balanceAmountDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.balanceAmountDataGridViewTextBoxColumn1.Width = 95;
            // 
            // paidAmountDataGridViewTextBoxColumn
            // 
            this.paidAmountDataGridViewTextBoxColumn.DataPropertyName = "Paid_Amount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.paidAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.paidAmountDataGridViewTextBoxColumn.HeaderText = "Paid Amount";
            this.paidAmountDataGridViewTextBoxColumn.Name = "paidAmountDataGridViewTextBoxColumn";
            this.paidAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.paidAmountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.paidAmountDataGridViewTextBoxColumn.Width = 95;
            // 
            // selectedPaymentsBindingSource
            // 
            this.selectedPaymentsBindingSource.DataMember = "SelectedPayments";
            this.selectedPaymentsBindingSource.DataSource = this.dsForReports;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblBalance);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.lblTotalPayment);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.dataGridViewPayments);
            this.groupBox4.Location = new System.Drawing.Point(469, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(554, 138);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Payments";
            // 
            // lblBalance
            // 
            this.lblBalance.BackColor = System.Drawing.Color.LightCyan;
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.Location = new System.Drawing.Point(141, 114);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(103, 21);
            this.lblBalance.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(83, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "Balance";
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalPayment.Location = new System.Drawing.Point(445, 114);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(103, 21);
            this.lblTotalPayment.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(342, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Total Payment";
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.AllowUserToAddRows = false;
            this.dataGridViewPayments.AllowUserToDeleteRows = false;
            this.dataGridViewPayments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewPayments.AutoGenerateColumns = false;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentModeDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn,
            this.branchDataGridViewTextBoxColumn,
            this.chequeNoDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dataGridViewPayments.DataSource = this.paymentDetailsBindingSource;
            this.dataGridViewPayments.Location = new System.Drawing.Point(7, 16);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.Size = new System.Drawing.Size(541, 93);
            this.dataGridViewPayments.TabIndex = 0;
            // 
            // paymentModeDataGridViewTextBoxColumn
            // 
            this.paymentModeDataGridViewTextBoxColumn.DataPropertyName = "Payment_Mode";
            this.paymentModeDataGridViewTextBoxColumn.HeaderText = "Payment Mode";
            this.paymentModeDataGridViewTextBoxColumn.Name = "paymentModeDataGridViewTextBoxColumn";
            this.paymentModeDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentModeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.paymentModeDataGridViewTextBoxColumn.Width = 95;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "Bank_Name";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "Bank Name";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // branchDataGridViewTextBoxColumn
            // 
            this.branchDataGridViewTextBoxColumn.DataPropertyName = "Branch";
            this.branchDataGridViewTextBoxColumn.HeaderText = "Branch";
            this.branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            this.branchDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // chequeNoDataGridViewTextBoxColumn
            // 
            this.chequeNoDataGridViewTextBoxColumn.DataPropertyName = "Cheque_No";
            this.chequeNoDataGridViewTextBoxColumn.HeaderText = "Cheque No";
            this.chequeNoDataGridViewTextBoxColumn.Name = "chequeNoDataGridViewTextBoxColumn";
            this.chequeNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.chequeNoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // paymentDetailsBindingSource
            // 
            this.paymentDetailsBindingSource.DataMember = "PaymentDetails";
            this.paymentDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnApply);
            this.groupBox5.Controls.Add(this.toolStrip1);
            this.groupBox5.Location = new System.Drawing.Point(5, 458);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1018, 83);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(888, 21);
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
            this.btnApply.Location = new System.Drawing.Point(758, 21);
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
            this.toolStrip1.Location = new System.Drawing.Point(3, 15);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1012, 65);
            this.toolStrip1.TabIndex = 134;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtpChequeDate);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.txtBranchName);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.cmbBankName);
            this.groupBox6.Controls.Add(this.txtChequeNo);
            this.groupBox6.Controls.Add(this.txtPaymentModeAmount);
            this.groupBox6.Controls.Add(this.cmbPaymentMode);
            this.groupBox6.Location = new System.Drawing.Point(5, 320);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(458, 138);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Payment Mode";
            // 
            // dtpChequeDate
            // 
            this.dtpChequeDate.CustomFormat = "dd/MM/yyyy";
            this.dtpChequeDate.Enabled = false;
            this.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChequeDate.Location = new System.Drawing.Point(91, 112);
            this.dtpChequeDate.Name = "dtpChequeDate";
            this.dtpChequeDate.Size = new System.Drawing.Size(109, 20);
            this.dtpChequeDate.TabIndex = 10;
            this.dtpChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpChequeDate_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Cheque Date.";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(7, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Branch";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(257, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Amount";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Enabled = false;
            this.txtBranchName.Location = new System.Drawing.Point(91, 65);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(360, 20);
            this.txtBranchName.TabIndex = 8;
            this.txtBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchName_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(7, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Cheque No.";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Bank Name";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Payment Mode";
            // 
            // cmbBankName
            // 
            this.cmbBankName.DisplayMember = "Bank_Name";
            this.cmbBankName.Enabled = false;
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(91, 39);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(360, 21);
            this.cmbBankName.TabIndex = 7;
            this.cmbBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBankName_KeyDown);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Enabled = false;
            this.txtChequeNo.Location = new System.Drawing.Point(91, 89);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(360, 20);
            this.txtChequeNo.TabIndex = 9;
            this.txtChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeNo_KeyDown);
            // 
            // txtPaymentModeAmount
            // 
            this.txtPaymentModeAmount.Location = new System.Drawing.Point(317, 12);
            this.txtPaymentModeAmount.Name = "txtPaymentModeAmount";
            this.txtPaymentModeAmount.ReadOnly = true;
            this.txtPaymentModeAmount.Size = new System.Drawing.Size(135, 20);
            this.txtPaymentModeAmount.TabIndex = 6;
            this.txtPaymentModeAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaymentModeAmount_KeyDown);
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(91, 13);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(160, 21);
            this.cmbPaymentMode.TabIndex = 5;
            this.cmbPaymentMode.SelectedValueChanged += new System.EventHandler(this.cmbPaymentMode_SelectedValueChanged);
            this.cmbPaymentMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentMode_KeyDown);
            // 
            // frmSupplierPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1026, 542);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplierPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Payment";
            this.Load += new System.EventHandler(this.frmSupplierPayment_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSupplierPayment_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSupplierPayment_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPaymentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPaymentsBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDetailsBindingSource)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridViewPendingPayments;
        private System.Windows.Forms.BindingSource pendingPaymentsBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.DataGridView dataGridViewSelectedPayments;
        private System.Windows.Forms.BindingSource selectedPaymentsBindingSource;
        private System.Windows.Forms.Label lblPendingDocumentDate;
        private System.Windows.Forms.Label lblPendingDocNo;
        private System.Windows.Forms.Label lblPendingDocumentAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPendingPaymentAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalOutstanding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalSelectedValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.TextBox txtPaymentModeAmount;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private System.Windows.Forms.BindingSource paymentDetailsBindingSource;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSupplierSearch;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidAmountDataGridViewTextBoxColumn;
    }
}