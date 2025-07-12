namespace Inventory
{
    partial class frmStockOverwrite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotalcurrQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.dataGridTempGrn = new System.Windows.Forms.DataGridView();
            this.stockAdjustBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblTotalPhysicalQty = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblTotalVarienceQty = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optLocation = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReadStock = new System.Windows.Forms.Button();
            this.optDataCollector = new System.Windows.Forms.RadioButton();
            this.optPosSalesData = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.optSupplier = new System.Windows.Forms.RadioButton();
            this.optCategory = new System.Windows.Forms.RadioButton();
            this.optDepartment = new System.Windows.Forms.RadioButton();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phyQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPhysicalQty = new System.Windows.Forms.TextBox();
            this.lblVarienceQty = new System.Windows.Forms.Label();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempGrn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAdjustBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalcurrQty
            // 
            this.lblTotalcurrQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalcurrQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalcurrQty.Location = new System.Drawing.Point(714, 452);
            this.lblTotalcurrQty.Name = "lblTotalcurrQty";
            this.lblTotalcurrQty.Size = new System.Drawing.Size(98, 21);
            this.lblTotalcurrQty.TabIndex = 129;
            this.lblTotalcurrQty.Text = "0.00";
            this.lblTotalcurrQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Total";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocumentNo.Location = new System.Drawing.Point(141, 15);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(94, 19);
            this.lblDocumentNo.TabIndex = 127;
            this.lblDocumentNo.Text = "TE01000001";
            // 
            // dataGridTempGrn
            // 
            this.dataGridTempGrn.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridTempGrn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTempGrn.AutoGenerateColumns = false;
            this.dataGridTempGrn.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridTempGrn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTempGrn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.BatchNo,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.Pack_Size,
            this.currQtyDataGridViewTextBoxColumn,
            this.phyQtyDataGridViewTextBoxColumn,
            this.varQtyDataGridViewTextBoxColumn});
            this.dataGridTempGrn.DataSource = this.stockAdjustBindingSource;
            this.dataGridTempGrn.Location = new System.Drawing.Point(5, 85);
            this.dataGridTempGrn.Name = "dataGridTempGrn";
            this.dataGridTempGrn.ReadOnly = true;
            this.dataGridTempGrn.Size = new System.Drawing.Size(1013, 310);
            this.dataGridTempGrn.TabIndex = 126;
            this.dataGridTempGrn.DoubleClick += new System.EventHandler(this.dataGridTempGrn_DoubleClick);
            this.dataGridTempGrn.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridTempGrn_RowPostPaint);
            // 
            // stockAdjustBindingSource
            // 
            this.stockAdjustBindingSource.DataMember = "StockAdjust";
            this.stockAdjustBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(808, 482);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 138;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTotalPhysicalQty
            // 
            this.lblTotalPhysicalQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalPhysicalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalPhysicalQty.Location = new System.Drawing.Point(817, 452);
            this.lblTotalPhysicalQty.Name = "lblTotalPhysicalQty";
            this.lblTotalPhysicalQty.Size = new System.Drawing.Size(106, 21);
            this.lblTotalPhysicalQty.TabIndex = 130;
            this.lblTotalPhysicalQty.Text = "0.00";
            this.lblTotalPhysicalQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnItemSearch.Location = new System.Drawing.Point(772, 54);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(25, 22);
            this.btnItemSearch.TabIndex = 7;
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(518, 55);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(248, 20);
            this.txtDescr.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(403, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(113, 20);
            this.txtCode.TabIndex = 5;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // lblTotalVarienceQty
            // 
            this.lblTotalVarienceQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalVarienceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalVarienceQty.Location = new System.Drawing.Point(922, 452);
            this.lblTotalVarienceQty.Name = "lblTotalVarienceQty";
            this.lblTotalVarienceQty.Size = new System.Drawing.Size(93, 21);
            this.lblTotalVarienceQty.TabIndex = 131;
            this.lblTotalVarienceQty.Text = "0.00";
            this.lblTotalVarienceQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 478);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 66);
            this.toolStrip1.TabIndex = 136;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.txtPhysicalQty);
            this.groupBox1.Controls.Add(this.lblVarienceQty);
            this.groupBox1.Controls.Add(this.lblCurrentQty);
            this.groupBox1.Controls.Add(this.cmbBatch);
            this.groupBox1.Controls.Add(this.optLocation);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.optSupplier);
            this.groupBox1.Controls.Add(this.optCategory);
            this.groupBox1.Controls.Add(this.optDepartment);
            this.groupBox1.Controls.Add(this.btnItemSearch);
            this.groupBox1.Controls.Add(this.txtDescr);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.lblTotalVarienceQty);
            this.groupBox1.Controls.Add(this.lblTotalPhysicalQty);
            this.groupBox1.Controls.Add(this.lblTotalcurrQty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDocumentNo);
            this.groupBox1.Controls.Add(this.dataGridTempGrn);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 476);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            // 
            // optLocation
            // 
            this.optLocation.AutoSize = true;
            this.optLocation.Location = new System.Drawing.Point(301, 59);
            this.optLocation.Name = "optLocation";
            this.optLocation.Size = new System.Drawing.Size(66, 17);
            this.optLocation.TabIndex = 137;
            this.optLocation.TabStop = true;
            this.optLocation.Text = "Location";
            this.optLocation.UseVisualStyleBackColor = true;
            this.optLocation.CheckedChanged += new System.EventHandler(this.optLocation_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReadStock);
            this.groupBox2.Controls.Add(this.optDataCollector);
            this.groupBox2.Controls.Add(this.optPosSalesData);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(403, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 47);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            // 
            // btnReadStock
            // 
            this.btnReadStock.Location = new System.Drawing.Point(402, 11);
            this.btnReadStock.Name = "btnReadStock";
            this.btnReadStock.Size = new System.Drawing.Size(108, 30);
            this.btnReadStock.TabIndex = 3;
            this.btnReadStock.Text = "Read Stock";
            this.btnReadStock.UseVisualStyleBackColor = true;
            this.btnReadStock.Click += new System.EventHandler(this.btnReadStock_Click);
            // 
            // optDataCollector
            // 
            this.optDataCollector.AutoSize = true;
            this.optDataCollector.Location = new System.Drawing.Point(212, 19);
            this.optDataCollector.Name = "optDataCollector";
            this.optDataCollector.Size = new System.Drawing.Size(188, 17);
            this.optDataCollector.TabIndex = 2;
            this.optDataCollector.Text = "Data Collector File On C:\\Stock.txt";
            this.optDataCollector.UseVisualStyleBackColor = true;
            // 
            // optPosSalesData
            // 
            this.optPosSalesData.AutoSize = true;
            this.optPosSalesData.Checked = true;
            this.optPosSalesData.Location = new System.Drawing.Point(98, 19);
            this.optPosSalesData.Name = "optPosSalesData";
            this.optPosSalesData.Size = new System.Drawing.Size(107, 17);
            this.optPosSalesData.TabIndex = 1;
            this.optPosSalesData.TabStop = true;
            this.optPosSalesData.Text = "Pos Sales Details";
            this.optPosSalesData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stock Read From ";
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(805, 54);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(109, 23);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "Download Stock Count";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // optSupplier
            // 
            this.optSupplier.AutoSize = true;
            this.optSupplier.Location = new System.Drawing.Point(207, 58);
            this.optSupplier.Name = "optSupplier";
            this.optSupplier.Size = new System.Drawing.Size(63, 17);
            this.optSupplier.TabIndex = 4;
            this.optSupplier.TabStop = true;
            this.optSupplier.Text = "Supplier";
            this.optSupplier.UseVisualStyleBackColor = true;
            this.optSupplier.CheckedChanged += new System.EventHandler(this.optSupplier_CheckedChanged);
            // 
            // optCategory
            // 
            this.optCategory.AutoSize = true;
            this.optCategory.Location = new System.Drawing.Point(110, 58);
            this.optCategory.Name = "optCategory";
            this.optCategory.Size = new System.Drawing.Size(67, 17);
            this.optCategory.TabIndex = 3;
            this.optCategory.TabStop = true;
            this.optCategory.Text = "Category";
            this.optCategory.UseVisualStyleBackColor = true;
            this.optCategory.CheckedChanged += new System.EventHandler(this.optCategory_CheckedChanged);
            // 
            // optDepartment
            // 
            this.optDepartment.AutoSize = true;
            this.optDepartment.Location = new System.Drawing.Point(9, 58);
            this.optDepartment.Name = "optDepartment";
            this.optDepartment.Size = new System.Drawing.Size(80, 17);
            this.optDepartment.TabIndex = 2;
            this.optDepartment.TabStop = true;
            this.optDepartment.Text = "Department";
            this.optDepartment.UseVisualStyleBackColor = true;
            this.optDepartment.CheckedChanged += new System.EventHandler(this.optDepartment_CheckedChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(282, 13);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(113, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(242, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 124;
            this.label6.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 123;
            this.label1.Text = "Temp Document No:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(918, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 149;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(493, 413);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(175, 21);
            this.cmbBatch.TabIndex = 141;
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.FillWeight = 130F;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Product Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodCodeDataGridViewTextBoxColumn.Width = 90;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNameDataGridViewTextBoxColumn.Width = 280;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase Price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchasepriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_Price";
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling Price";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellingPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // Pack_Size
            // 
            this.Pack_Size.DataPropertyName = "Pack_Size";
            this.Pack_Size.HeaderText = "Pack Size";
            this.Pack_Size.Name = "Pack_Size";
            this.Pack_Size.ReadOnly = true;
            this.Pack_Size.Width = 50;
            // 
            // currQtyDataGridViewTextBoxColumn
            // 
            this.currQtyDataGridViewTextBoxColumn.DataPropertyName = "Curr_Qty";
            this.currQtyDataGridViewTextBoxColumn.HeaderText = "Current Qty";
            this.currQtyDataGridViewTextBoxColumn.Name = "currQtyDataGridViewTextBoxColumn";
            this.currQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.currQtyDataGridViewTextBoxColumn.Width = 90;
            // 
            // phyQtyDataGridViewTextBoxColumn
            // 
            this.phyQtyDataGridViewTextBoxColumn.DataPropertyName = "Phy_Qty";
            this.phyQtyDataGridViewTextBoxColumn.HeaderText = "Physical Qty";
            this.phyQtyDataGridViewTextBoxColumn.Name = "phyQtyDataGridViewTextBoxColumn";
            this.phyQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.phyQtyDataGridViewTextBoxColumn.Width = 90;
            // 
            // varQtyDataGridViewTextBoxColumn
            // 
            this.varQtyDataGridViewTextBoxColumn.DataPropertyName = "Var_Qty";
            this.varQtyDataGridViewTextBoxColumn.HeaderText = "Varience Qty";
            this.varQtyDataGridViewTextBoxColumn.Name = "varQtyDataGridViewTextBoxColumn";
            this.varQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.varQtyDataGridViewTextBoxColumn.Width = 90;
            // 
            // txtPhysicalQty
            // 
            this.txtPhysicalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhysicalQty.Location = new System.Drawing.Point(797, 414);
            this.txtPhysicalQty.Name = "txtPhysicalQty";
            this.txtPhysicalQty.Size = new System.Drawing.Size(105, 20);
            this.txtPhysicalQty.TabIndex = 142;
            this.txtPhysicalQty.Text = "0.00";
            this.txtPhysicalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPhysicalQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhysicalQty_KeyDown);
            // 
            // lblVarienceQty
            // 
            this.lblVarienceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVarienceQty.Location = new System.Drawing.Point(915, 414);
            this.lblVarienceQty.Name = "lblVarienceQty";
            this.lblVarienceQty.Size = new System.Drawing.Size(100, 20);
            this.lblVarienceQty.TabIndex = 144;
            this.lblVarienceQty.Text = "0.00";
            this.lblVarienceQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentQty.Location = new System.Drawing.Point(693, 413);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(98, 22);
            this.lblCurrentQty.TabIndex = 143;
            this.lblCurrentQty.Text = "0.00";
            this.lblCurrentQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 21);
            this.button2.TabIndex = 147;
            this.button2.Text = "....";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(167, 415);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(290, 20);
            this.txtProductName.TabIndex = 146;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(48, 415);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(113, 20);
            this.txtProductCode.TabIndex = 145;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown_1);
            // 
            // frmStockOverwrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 544);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockOverwrite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Overwrite";
            this.Load += new System.EventHandler(this.frmStockOverwrite_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStockOverwrite_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStockOverwrite_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempGrn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAdjustBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalcurrQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.DataGridView dataGridTempGrn;
        private System.Windows.Forms.BindingSource stockAdjustBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblTotalPhysicalQty;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblTotalVarienceQty;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optSupplier;
        private System.Windows.Forms.RadioButton optCategory;
        private System.Windows.Forms.RadioButton optDepartment;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optDataCollector;
        private System.Windows.Forms.RadioButton optPosSalesData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton optLocation;
        private System.Windows.Forms.Button btnReadStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn currQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phyQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.TextBox txtPhysicalQty;
        private System.Windows.Forms.Label lblVarienceQty;
        private System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
    }
}