namespace Inventory
{
    partial class frmGiftVoucherPrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBookNoSearch = new System.Windows.Forms.Button();
            this.txtBookNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGiftVoucherQTY = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCodeTo = new System.Windows.Forms.Button();
            this.btnCodeFrom = new System.Windows.Forms.Button();
            this.dgBarCode = new System.Windows.Forms.DataGridView();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsBarCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReport = new Inventory.dsForReports();
            this.txtGiftVoucherCodeTo = new System.Windows.Forms.TextBox();
            this.txtGiftVoucherCodeFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBarCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReport)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 458);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnBookNoSearch);
            this.groupBox2.Controls.Add(this.txtBookNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbLabelType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblGiftVoucherQTY);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnCodeTo);
            this.groupBox2.Controls.Add(this.btnCodeFrom);
            this.groupBox2.Controls.Add(this.dgBarCode);
            this.groupBox2.Controls.Add(this.txtGiftVoucherCodeTo);
            this.groupBox2.Controls.Add(this.txtGiftVoucherCodeFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 439);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnBookNoSearch
            // 
            this.btnBookNoSearch.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBookNoSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBookNoSearch.Location = new System.Drawing.Point(361, 15);
            this.btnBookNoSearch.Name = "btnBookNoSearch";
            this.btnBookNoSearch.Size = new System.Drawing.Size(25, 22);
            this.btnBookNoSearch.TabIndex = 1;
            this.btnBookNoSearch.Text = "...";
            this.btnBookNoSearch.UseVisualStyleBackColor = false;
            this.btnBookNoSearch.Click += new System.EventHandler(this.btnBookNoSearch_Click);
            this.btnBookNoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnBookNoSearch_KeyDown);
            // 
            // txtBookNo
            // 
            this.txtBookNo.Location = new System.Drawing.Point(154, 17);
            this.txtBookNo.Name = "txtBookNo";
            this.txtBookNo.Size = new System.Drawing.Size(195, 20);
            this.txtBookNo.TabIndex = 0;
            this.txtBookNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBookNo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Book Number";
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLabelType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Items.AddRange(new object[] {
            "Gift_01",
            "Gift_02",
            "Gift_03"});
            this.cmbLabelType.Location = new System.Drawing.Point(357, 352);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(140, 21);
            this.cmbLabelType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Llabel Type";
            // 
            // lblGiftVoucherQTY
            // 
            this.lblGiftVoucherQTY.AutoSize = true;
            this.lblGiftVoucherQTY.Location = new System.Drawing.Point(150, 357);
            this.lblGiftVoucherQTY.Name = "lblGiftVoucherQTY";
            this.lblGiftVoucherQTY.Size = new System.Drawing.Size(0, 13);
            this.lblGiftVoucherQTY.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Gift Voucher QTY";
            // 
            // btnCodeTo
            // 
            this.btnCodeTo.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCodeTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCodeTo.Location = new System.Drawing.Point(431, 45);
            this.btnCodeTo.Name = "btnCodeTo";
            this.btnCodeTo.Size = new System.Drawing.Size(25, 22);
            this.btnCodeTo.TabIndex = 5;
            this.btnCodeTo.Text = "...";
            this.btnCodeTo.UseVisualStyleBackColor = false;
            this.btnCodeTo.Click += new System.EventHandler(this.btnCodeTo_Click);
            // 
            // btnCodeFrom
            // 
            this.btnCodeFrom.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCodeFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCodeFrom.Location = new System.Drawing.Point(276, 43);
            this.btnCodeFrom.Name = "btnCodeFrom";
            this.btnCodeFrom.Size = new System.Drawing.Size(25, 22);
            this.btnCodeFrom.TabIndex = 3;
            this.btnCodeFrom.Text = "...";
            this.btnCodeFrom.UseVisualStyleBackColor = false;
            this.btnCodeFrom.Click += new System.EventHandler(this.btnCodeFrom_Click);
            this.btnCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCodeFrom_KeyDown);
            // 
            // dgBarCode
            // 
            this.dgBarCode.AllowUserToAddRows = false;
            this.dgBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBarCode.AutoGenerateColumns = false;
            this.dgBarCode.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgBarCode.ColumnHeadersHeight = 22;
            this.dgBarCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.suppCodeDataGridViewTextBoxColumn});
            this.dgBarCode.DataSource = this.dsBarCodeBindingSource;
            this.dgBarCode.GridColor = System.Drawing.SystemColors.InfoText;
            this.dgBarCode.Location = new System.Drawing.Point(8, 110);
            this.dgBarCode.Name = "dgBarCode";
            this.dgBarCode.ReadOnly = true;
            this.dgBarCode.RowHeadersWidth = 26;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dgBarCode.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgBarCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgBarCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBarCode.Size = new System.Drawing.Size(490, 236);
            this.dgBarCode.TabIndex = 9;
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Gift V Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodCodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Visible Code";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // suppCodeDataGridViewTextBoxColumn
            // 
            this.suppCodeDataGridViewTextBoxColumn.DataPropertyName = "Supp_Code";
            this.suppCodeDataGridViewTextBoxColumn.HeaderText = "Date";
            this.suppCodeDataGridViewTextBoxColumn.Name = "suppCodeDataGridViewTextBoxColumn";
            this.suppCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.suppCodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // dsBarCodeBindingSource
            // 
            this.dsBarCodeBindingSource.DataMember = "dsBarCode";
            this.dsBarCodeBindingSource.DataSource = this.dsForReport;
            // 
            // dsForReport
            // 
            this.dsForReport.DataSetName = "dsForReport";
            this.dsForReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtGiftVoucherCodeTo
            // 
            this.txtGiftVoucherCodeTo.Location = new System.Drawing.Point(308, 45);
            this.txtGiftVoucherCodeTo.Name = "txtGiftVoucherCodeTo";
            this.txtGiftVoucherCodeTo.Size = new System.Drawing.Size(117, 20);
            this.txtGiftVoucherCodeTo.TabIndex = 4;
            this.txtGiftVoucherCodeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiftVoucherCodeTo_KeyDown);
            // 
            // txtGiftVoucherCodeFrom
            // 
            this.txtGiftVoucherCodeFrom.Location = new System.Drawing.Point(154, 44);
            this.txtGiftVoucherCodeFrom.Name = "txtGiftVoucherCodeFrom";
            this.txtGiftVoucherCodeFrom.Size = new System.Drawing.Size(117, 20);
            this.txtGiftVoucherCodeFrom.TabIndex = 2;
            this.txtGiftVoucherCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiftVoucherCodeFrom_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gift Voucher Code From";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnPrint);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Location = new System.Drawing.Point(3, 397);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(507, 58);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(6, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 38);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(311, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 38);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseEnter += new System.EventHandler(this.btnPrint_MouseEnter);
            this.btnPrint.MouseLeave += new System.EventHandler(this.btnPrint_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(411, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(361, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 22);
            this.button1.TabIndex = 15;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGiftVoucherPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(512, 458);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGiftVoucherPrint";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Barcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBarcode_FormClosing);
            this.Load += new System.EventHandler(this.frmBarcode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBarCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReport)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource dsBarCodeBindingSource;
        private dsForReports dsForReport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBookNoSearch;
        private System.Windows.Forms.TextBox txtBookNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLabelType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGiftVoucherQTY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCodeTo;
        private System.Windows.Forms.Button btnCodeFrom;
        private System.Windows.Forms.DataGridView dgBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn visibleCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtGiftVoucherCodeTo;
        private System.Windows.Forms.TextBox txtGiftVoucherCodeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}