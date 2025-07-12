namespace Inventory
{
    partial class frmAccountUplaod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountUplaod));
            this.tbcLoad = new System.Windows.Forms.TabControl();
            this.Tab1 = new System.Windows.Forms.TabPage();
            this.dgSalePur = new System.Windows.Forms.DataGridView();
            this.Doc_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cust_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsInvoiceDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgReceipt = new System.Windows.Forms.DataGridView();
            this.tempDocNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Pnlloading = new System.Windows.Forms.Panel();
            this.Location = new System.Windows.Forms.Label();
            this.cmbLoca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnUplaod = new System.Windows.Forms.Button();
            this.tbcLoad.SuspendLayout();
            this.Tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalePur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoiceDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDetailsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcLoad
            // 
            this.tbcLoad.Controls.Add(this.Tab1);
            this.tbcLoad.Controls.Add(this.tabPage2);
            this.tbcLoad.Location = new System.Drawing.Point(3, 60);
            this.tbcLoad.Name = "tbcLoad";
            this.tbcLoad.SelectedIndex = 0;
            this.tbcLoad.Size = new System.Drawing.Size(700, 491);
            this.tbcLoad.TabIndex = 0;
            this.tbcLoad.SelectedIndexChanged += new System.EventHandler(this.tbcLoad_SelectedIndexChanged);
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.dgSalePur);
            this.Tab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab1.Location = new System.Drawing.Point(4, 22);
            this.Tab1.Name = "Tab1";
            this.Tab1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab1.Size = new System.Drawing.Size(692, 465);
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "                                                       Sales/ Purchase Transactio" +
                "n";
            this.Tab1.UseVisualStyleBackColor = true;
            // 
            // dgSalePur
            // 
            this.dgSalePur.AllowUserToAddRows = false;
            this.dgSalePur.AllowUserToDeleteRows = false;
            this.dgSalePur.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgSalePur.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSalePur.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Doc_No,
            this.Post_Date,
            this.Cust_Code,
            this.custNameDataGridViewTextBoxColumn,
            this.Status,
            this.Net_Amount});
            this.dgSalePur.DataSource = this.dsInvoiceDetailsBindingSource;
            this.dgSalePur.Location = new System.Drawing.Point(3, 3);
            this.dgSalePur.Name = "dgSalePur";
            this.dgSalePur.ReadOnly = true;
            this.dgSalePur.RowHeadersWidth = 21;
            this.dgSalePur.Size = new System.Drawing.Size(685, 460);
            this.dgSalePur.TabIndex = 0;
            // 
            // Doc_No
            // 
            this.Doc_No.DataPropertyName = "Doc_No";
            this.Doc_No.HeaderText = "Document No";
            this.Doc_No.Name = "Doc_No";
            this.Doc_No.ReadOnly = true;
            // 
            // Post_Date
            // 
            this.Post_Date.DataPropertyName = "Post_Date";
            this.Post_Date.HeaderText = "Date";
            this.Post_Date.Name = "Post_Date";
            this.Post_Date.ReadOnly = true;
            // 
            // Cust_Code
            // 
            this.Cust_Code.DataPropertyName = "Cust_Code";
            this.Cust_Code.HeaderText = "Customer Id";
            this.Cust_Code.Name = "Cust_Code";
            this.Cust_Code.ReadOnly = true;
            // 
            // custNameDataGridViewTextBoxColumn
            // 
            this.custNameDataGridViewTextBoxColumn.DataPropertyName = "Cust_Name";
            this.custNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
            this.custNameDataGridViewTextBoxColumn.Name = "custNameDataGridViewTextBoxColumn";
            this.custNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.custNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 50;
            // 
            // Net_Amount
            // 
            this.Net_Amount.DataPropertyName = "Net_Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Net_Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Net_Amount.HeaderText = "Net Amount";
            this.Net_Amount.Name = "Net_Amount";
            this.Net_Amount.ReadOnly = true;
            this.Net_Amount.Width = 110;
            // 
            // dsInvoiceDetailsBindingSource
            // 
            this.dsInvoiceDetailsBindingSource.DataMember = "dsInvoiceDetails";
            this.dsInvoiceDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgReceipt);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "                                                                                 " +
                "                   Receipt Detail";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgReceipt
            // 
            this.dgReceipt.AllowUserToAddRows = false;
            this.dgReceipt.AllowUserToDeleteRows = false;
            this.dgReceipt.AutoGenerateColumns = false;
            this.dgReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tempDocNoDataGridViewTextBoxColumn,
            this.paymentModeDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn,
            this.chequeNoDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.Cheque_Date});
            this.dgReceipt.DataSource = this.paymentDetailsBindingSource;
            this.dgReceipt.Location = new System.Drawing.Point(4, 3);
            this.dgReceipt.Name = "dgReceipt";
            this.dgReceipt.ReadOnly = true;
            this.dgReceipt.RowHeadersWidth = 15;
            this.dgReceipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgReceipt.Size = new System.Drawing.Size(685, 463);
            this.dgReceipt.TabIndex = 1;
            // 
            // tempDocNoDataGridViewTextBoxColumn
            // 
            this.tempDocNoDataGridViewTextBoxColumn.DataPropertyName = "Temp_DocNo";
            this.tempDocNoDataGridViewTextBoxColumn.HeaderText = "Rept No";
            this.tempDocNoDataGridViewTextBoxColumn.Name = "tempDocNoDataGridViewTextBoxColumn";
            this.tempDocNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tempDocNoDataGridViewTextBoxColumn.Width = 80;
            // 
            // paymentModeDataGridViewTextBoxColumn
            // 
            this.paymentModeDataGridViewTextBoxColumn.DataPropertyName = "Payment_Mode";
            this.paymentModeDataGridViewTextBoxColumn.HeaderText = "P.Mode";
            this.paymentModeDataGridViewTextBoxColumn.Name = "paymentModeDataGridViewTextBoxColumn";
            this.paymentModeDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentModeDataGridViewTextBoxColumn.Width = 70;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "Bank_Name";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "Bank";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankNameDataGridViewTextBoxColumn.Width = 105;
            // 
            // chequeNoDataGridViewTextBoxColumn
            // 
            this.chequeNoDataGridViewTextBoxColumn.DataPropertyName = "Cheque_No";
            this.chequeNoDataGridViewTextBoxColumn.HeaderText = "Chq No";
            this.chequeNoDataGridViewTextBoxColumn.Name = "chequeNoDataGridViewTextBoxColumn";
            this.chequeNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.chequeNoDataGridViewTextBoxColumn.Width = 80;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Post_Date";
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // Cheque_Date
            // 
            this.Cheque_Date.DataPropertyName = "Cheque_Date";
            this.Cheque_Date.HeaderText = "Chq Date";
            this.Cheque_Date.Name = "Cheque_Date";
            this.Cheque_Date.ReadOnly = true;
            this.Cheque_Date.Width = 80;
            // 
            // paymentDetailsBindingSource
            // 
            this.paymentDetailsBindingSource.DataMember = "PaymentDetails";
            this.paymentDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pnlloading);
            this.groupBox1.Controls.Add(this.Location);
            this.groupBox1.Controls.Add(this.cmbLoca);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtDateTo);
            this.groupBox1.Controls.Add(this.dtDateFrom);
            this.groupBox1.Controls.Add(this.lblDocNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbTransType);
            this.groupBox1.Location = new System.Drawing.Point(2, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 545);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Pnlloading
            // 
            this.Pnlloading.BackColor = System.Drawing.Color.White;
            this.Pnlloading.BackgroundImage = global::Inventory.Properties.Resources.new_loading1;
            this.Pnlloading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Pnlloading.Location = new System.Drawing.Point(1, 0);
            this.Pnlloading.Name = "Pnlloading";
            this.Pnlloading.Size = new System.Drawing.Size(696, 64);
            this.Pnlloading.TabIndex = 11;
            this.Pnlloading.Tag = "";
            this.Pnlloading.Visible = false;
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(7, 38);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(48, 13);
            this.Location.TabIndex = 10;
            this.Location.Text = "Location";
            // 
            // cmbLoca
            // 
            this.cmbLoca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoca.FormattingEnabled = true;
            this.cmbLoca.Items.AddRange(new object[] {
            "Sale",
            "Purchase",
            "Recpt"});
            this.cmbLoca.Location = new System.Drawing.Point(103, 35);
            this.cmbLoca.Name = "cmbLoca";
            this.cmbLoca.Size = new System.Drawing.Size(121, 21);
            this.cmbLoca.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // dtDateTo
            // 
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateTo.Location = new System.Drawing.Point(419, 36);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(84, 20);
            this.dtDateTo.TabIndex = 6;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateFrom.Location = new System.Drawing.Point(419, 11);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(84, 20);
            this.dtDateFrom.TabIndex = 5;
            // 
            // lblDocNo
            // 
            this.lblDocNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDocNo.Location = new System.Drawing.Point(594, 19);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(101, 19);
            this.lblDocNo.TabIndex = 4;
            this.lblDocNo.Text = "010100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Document No";
            // 
            // btnLoad
            // 
            this.btnLoad.BackgroundImage = global::Inventory.Properties.Resources.Load;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoad.Location = new System.Drawing.Point(234, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(49, 45);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transaction Type";
            // 
            // cmbTransType
            // 
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.FormattingEnabled = true;
            this.cmbTransType.Items.AddRange(new object[] {
            "WholeSale",
            "Purchase",
            "Retail"});
            this.cmbTransType.Location = new System.Drawing.Point(103, 11);
            this.cmbTransType.Name = "cmbTransType";
            this.cmbTransType.Size = new System.Drawing.Size(121, 21);
            this.cmbTransType.TabIndex = 0;
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataMember = "Invoice";
            this.invoiceBindingSource.DataSource = this.dsForReports;
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(57, 566);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(593, 13);
            this.pgBar.TabIndex = 2;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(656, 566);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(0, 13);
            this.lblPercent.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnUplaod
            // 
            this.btnUplaod.BackgroundImage = global::Inventory.Properties.Resources.UP1;
            this.btnUplaod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUplaod.Location = new System.Drawing.Point(7, 551);
            this.btnUplaod.Name = "btnUplaod";
            this.btnUplaod.Size = new System.Drawing.Size(44, 41);
            this.btnUplaod.TabIndex = 9;
            this.btnUplaod.UseVisualStyleBackColor = true;
            this.btnUplaod.Click += new System.EventHandler(this.btnUplaod_Click);
            // 
            // frmAccountUplaod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(703, 594);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.btnUplaod);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.tbcLoad);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAccountUplaod";
            this.Text = "Account Data Uplaod";
            this.Load += new System.EventHandler(this.frmAccountUplaod_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountUplaod_FormClosing);
            this.tbcLoad.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSalePur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoiceDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDetailsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcLoad;
        private System.Windows.Forms.TabPage Tab1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTransType;
        private System.Windows.Forms.Label lblDocNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgSalePur;
        private System.Windows.Forms.BindingSource dsInvoiceDetailsBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.DataGridView dgReceipt;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private System.Windows.Forms.BindingSource paymentDetailsBindingSource;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempDocNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn custCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cust_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn custNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Net_Amount;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.Windows.Forms.Button btnUplaod;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.ComboBox cmbLoca;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel Pnlloading;

    }
}