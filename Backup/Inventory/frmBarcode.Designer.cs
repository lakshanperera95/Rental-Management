namespace Inventory
{
    partial class frmBarcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewBarcode = new System.Windows.Forms.DataGridView();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsBarcodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.lblTotalLabels = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSuppCode = new System.Windows.Forms.Label();
            this.cmbBarcodeType = new System.Windows.Forms.ComboBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDocumentFrom = new System.Windows.Forms.Button();
            this.txtCodeFrom = new System.Windows.Forms.TextBox();
            this.btnSupplierSearch = new System.Windows.Forms.Button();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBarcodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewBarcode);
            this.groupBox1.Location = new System.Drawing.Point(4, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 288);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewBarcode
            // 
            this.dataGridViewBarcode.AllowUserToAddRows = false;
            this.dataGridViewBarcode.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewBarcode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewBarcode.AutoGenerateColumns = false;
            this.dataGridViewBarcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBarcode.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.suppCodeDataGridViewTextBoxColumn});
            this.dataGridViewBarcode.DataSource = this.dsBarcodeBindingSource;
            this.dataGridViewBarcode.Location = new System.Drawing.Point(8, 12);
            this.dataGridViewBarcode.Name = "dataGridViewBarcode";
            this.dataGridViewBarcode.ReadOnly = true;
            this.dataGridViewBarcode.RowHeadersWidth = 31;
            this.dataGridViewBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBarcode.Size = new System.Drawing.Size(897, 269);
            this.dataGridViewBarcode.TabIndex = 0;
            this.dataGridViewBarcode.DoubleClick += new System.EventHandler(this.dataGridViewBarcode_DoubleClick);
            this.dataGridViewBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewBarcode_KeyDown);
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.FillWeight = 58.54801F;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Prod Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.FillWeight = 218.1847F;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.sellingPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.sellingPriceDataGridViewTextBoxColumn.FillWeight = 71.15419F;
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling Price";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellingPriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.qtyDataGridViewTextBoxColumn.FillWeight = 74.62569F;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // suppCodeDataGridViewTextBoxColumn
            // 
            this.suppCodeDataGridViewTextBoxColumn.DataPropertyName = "Supp_Code";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.suppCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.suppCodeDataGridViewTextBoxColumn.FillWeight = 77.48744F;
            this.suppCodeDataGridViewTextBoxColumn.HeaderText = "Supp Code";
            this.suppCodeDataGridViewTextBoxColumn.Name = "suppCodeDataGridViewTextBoxColumn";
            this.suppCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.suppCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dsBarcodeBindingSource
            // 
            this.dsBarcodeBindingSource.DataMember = "dsBarcode";
            this.dsBarcodeBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbBatchNo);
            this.groupBox2.Controls.Add(this.lblTotalLabels);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnItemSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblSuppCode);
            this.groupBox2.Controls.Add(this.cmbBarcodeType);
            this.groupBox2.Controls.Add(this.txtSellingPrice);
            this.groupBox2.Controls.Add(this.txtQty);
            this.groupBox2.Location = new System.Drawing.Point(4, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(382, 12);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(136, 21);
            this.cmbBatchNo.TabIndex = 202;
            this.cmbBatchNo.SelectedIndexChanged += new System.EventHandler(this.cmbBatchNo_SelectedIndexChanged);
            this.cmbBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBatchNo_KeyDown);
            // 
            // lblTotalLabels
            // 
            this.lblTotalLabels.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLabels.Location = new System.Drawing.Point(680, 40);
            this.lblTotalLabels.Name = "lblTotalLabels";
            this.lblTotalLabels.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblTotalLabels.Size = new System.Drawing.Size(115, 18);
            this.lblTotalLabels.TabIndex = 9;
            this.lblTotalLabels.Text = "0.00";
            this.lblTotalLabels.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(13, 12);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(97, 20);
            this.txtProductCode.TabIndex = 0;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(112, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(266, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "No Of Labels";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(521, 12);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(32, 20);
            this.btnItemSearch.TabIndex = 2;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Barcode Type";
            // 
            // lblSuppCode
            // 
            this.lblSuppCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSuppCode.Location = new System.Drawing.Point(771, 12);
            this.lblSuppCode.Name = "lblSuppCode";
            this.lblSuppCode.Size = new System.Drawing.Size(132, 20);
            this.lblSuppCode.TabIndex = 5;
            // 
            // cmbBarcodeType
            // 
            this.cmbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcodeType.FormattingEnabled = true;
            this.cmbBarcodeType.Location = new System.Drawing.Point(378, 38);
            this.cmbBarcodeType.Name = "cmbBarcodeType";
            this.cmbBarcodeType.Size = new System.Drawing.Size(211, 21);
            this.cmbBarcodeType.TabIndex = 7;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Enabled = false;
            this.txtSellingPrice.Location = new System.Drawing.Point(556, 12);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(118, 20);
            this.txtSellingPrice.TabIndex = 3;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(680, 12);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(89, 20);
            this.txtQty.TabIndex = 4;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 393);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(917, 65);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(664, 400);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 50);
            this.btnDisplay.TabIndex = 4;
            this.btnDisplay.Text = "Print";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(799, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAll);
            this.groupBox3.Controls.Add(this.dpDate);
            this.groupBox3.Controls.Add(this.btnDocumentFrom);
            this.groupBox3.Controls.Add(this.txtCodeFrom);
            this.groupBox3.Controls.Add(this.btnSupplierSearch);
            this.groupBox3.Controls.Add(this.txtSuppName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtSuppCode);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(4, -3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(911, 49);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnDocumentFrom
            // 
            this.btnDocumentFrom.Location = new System.Drawing.Point(698, 21);
            this.btnDocumentFrom.Name = "btnDocumentFrom";
            this.btnDocumentFrom.Size = new System.Drawing.Size(45, 21);
            this.btnDocumentFrom.TabIndex = 6;
            this.btnDocumentFrom.Text = "....";
            this.btnDocumentFrom.UseVisualStyleBackColor = true;
            this.btnDocumentFrom.Click += new System.EventHandler(this.btnDocumentFrom_Click);
            // 
            // txtCodeFrom
            // 
            this.txtCodeFrom.Location = new System.Drawing.Point(558, 21);
            this.txtCodeFrom.Name = "txtCodeFrom";
            this.txtCodeFrom.Size = new System.Drawing.Size(134, 20);
            this.txtCodeFrom.TabIndex = 5;
            this.txtCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodeFrom_KeyDown);
            this.txtCodeFrom.Enter += new System.EventHandler(this.txtCodeFrom_Enter);
            // 
            // btnSupplierSearch
            // 
            this.btnSupplierSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSupplierSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSupplierSearch.Location = new System.Drawing.Point(394, 17);
            this.btnSupplierSearch.Name = "btnSupplierSearch";
            this.btnSupplierSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSupplierSearch.TabIndex = 3;
            this.btnSupplierSearch.UseVisualStyleBackColor = true;
            this.btnSupplierSearch.Click += new System.EventHandler(this.btnSupplierSearch_Click);
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(189, 19);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(199, 20);
            this.txtSuppName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Supplier:";
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Location = new System.Drawing.Point(72, 19);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(111, 20);
            this.txtSuppCode.TabIndex = 1;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Enter += new System.EventHandler(this.txtSuppCode_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Good Received Note No";
            // 
            // dpDate
            // 
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDate.Location = new System.Drawing.Point(749, 21);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(100, 20);
            this.dpDate.TabIndex = 7;
            this.dpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpDate_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(858, 23);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 8;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // frmBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(917, 458);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBarcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.frmBarcode_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBarcode_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBarcode_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBarcodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewBarcode;
        private System.Windows.Forms.BindingSource dsBarcodeBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblSuppCode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSupplierSearch;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.Button btnDocumentFrom;
        private System.Windows.Forms.TextBox txtCodeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBarcodeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalLabels;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dpDate;
    }
}