namespace Inventory
{
    partial class frmTransferGoodNote
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGrnNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveDocSearch = new System.Windows.Forms.Button();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.lblLocaName = new System.Windows.Forms.Label();
            this.lblLocaCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridTempTGN = new System.Windows.Forms.DataGridView();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferNoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempTGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferNoteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGrnNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSaveDocSearch);
            this.groupBox1.Controls.Add(this.btnLocaSearch);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtReference);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblTempDocNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLocaName);
            this.groupBox1.Controls.Add(this.txtLocaCode);
            this.groupBox1.Controls.Add(this.lblLocaName);
            this.groupBox1.Controls.Add(this.lblLocaCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtGrnNo
            // 
            this.txtGrnNo.Location = new System.Drawing.Point(880, 17);
            this.txtGrnNo.MaxLength = 12;
            this.txtGrnNo.Name = "txtGrnNo";
            this.txtGrnNo.Size = new System.Drawing.Size(97, 20);
            this.txtGrnNo.TabIndex = 155;
            this.txtGrnNo.Visible = false;
            this.txtGrnNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrnNo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(836, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 154;
            this.label4.Text = "Grn No";
            this.label4.Visible = false;
            // 
            // btnSaveDocSearch
            // 
            this.btnSaveDocSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSaveDocSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSaveDocSearch.Location = new System.Drawing.Point(217, 15);
            this.btnSaveDocSearch.Name = "btnSaveDocSearch";
            this.btnSaveDocSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSaveDocSearch.TabIndex = 153;
            this.btnSaveDocSearch.TabStop = false;
            this.btnSaveDocSearch.UseVisualStyleBackColor = true;
            this.btnSaveDocSearch.Click += new System.EventHandler(this.btnSaveDocSearch_Click);
            // 
            // btnLocaSearch
            // 
            this.btnLocaSearch.Location = new System.Drawing.Point(615, 42);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(31, 19);
            this.btnLocaSearch.TabIndex = 3;
            this.btnLocaSearch.Text = "....";
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemarks.Location = new System.Drawing.Point(706, 42);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(271, 20);
            this.txtRemarks.TabIndex = 5;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.SystemColors.Window;
            this.txtReference.ForeColor = System.Drawing.Color.Black;
            this.txtReference.Location = new System.Drawing.Point(706, 16);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(271, 20);
            this.txtReference.TabIndex = 4;
            this.txtReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReference_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(649, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Remarks";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(649, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Reference";
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BackColor = System.Drawing.Color.LightCyan;
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(120, 16);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTempDocNo.Size = new System.Drawing.Size(91, 20);
            this.lblTempDocNo.TabIndex = 9;
            this.lblTempDocNo.Text = "TE01000001";
            this.lblTempDocNo.Enter += new System.EventHandler(this.lblTempDocNo_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Date";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.LightCyan;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Location = new System.Drawing.Point(120, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDate.Size = new System.Drawing.Size(79, 20);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "01/01/2008";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Temp. Document No.";
            // 
            // txtLocaName
            // 
            this.txtLocaName.Location = new System.Drawing.Point(392, 42);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(224, 20);
            this.txtLocaName.TabIndex = 2;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Location = new System.Drawing.Point(323, 42);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(63, 20);
            this.txtLocaCode.TabIndex = 1;
            this.txtLocaCode.TextChanged += new System.EventHandler(this.txtLocaCode_TextChanged);
            this.txtLocaCode.Enter += new System.EventHandler(this.txtLocaCode_Enter);
            this.txtLocaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocaCode_KeyDown);
            // 
            // lblLocaName
            // 
            this.lblLocaName.BackColor = System.Drawing.Color.LightCyan;
            this.lblLocaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocaName.Location = new System.Drawing.Point(393, 16);
            this.lblLocaName.Name = "lblLocaName";
            this.lblLocaName.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblLocaName.Size = new System.Drawing.Size(223, 20);
            this.lblLocaName.TabIndex = 3;
            this.lblLocaName.Text = "02";
            // 
            // lblLocaCode
            // 
            this.lblLocaCode.BackColor = System.Drawing.Color.LightCyan;
            this.lblLocaCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocaCode.Location = new System.Drawing.Point(323, 16);
            this.lblLocaCode.Name = "lblLocaCode";
            this.lblLocaCode.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblLocaCode.Size = new System.Drawing.Size(63, 20);
            this.lblLocaCode.TabIndex = 2;
            this.lblLocaCode.Text = "01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridTempTGN);
            this.groupBox2.Location = new System.Drawing.Point(4, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(985, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridTempTGN
            // 
            this.dataGridTempTGN.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridTempTGN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTempTGN.AutoGenerateColumns = false;
            this.dataGridTempTGN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTempTGN.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridTempTGN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTempTGN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.BatchNo,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.packSizeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.Amount});
            this.dataGridTempTGN.DataSource = this.transferNoteBindingSource;
            this.dataGridTempTGN.Location = new System.Drawing.Point(6, 13);
            this.dataGridTempTGN.Name = "dataGridTempTGN";
            this.dataGridTempTGN.Size = new System.Drawing.Size(977, 257);
            this.dataGridTempTGN.TabIndex = 0;
            this.dataGridTempTGN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTempTGN_CellContentClick);
            this.dataGridTempTGN.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridTempTGN_RowPostPaint);
            this.dataGridTempTGN.DoubleClick += new System.EventHandler(this.dataGridTempTGN_DoubleClick);
            this.dataGridTempTGN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridTempTGN_KeyDown);
            this.dataGridTempTGN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridTempTGN_MouseUp);
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.FillWeight = 74.94646F;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Product Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.FillWeight = 235.7997F;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.Name = "BatchNo";
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.sellingPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.sellingPriceDataGridViewTextBoxColumn.FillWeight = 67.69575F;
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling Price";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.purchasepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.purchasepriceDataGridViewTextBoxColumn.FillWeight = 73.45769F;
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purch Price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packSizeDataGridViewTextBoxColumn
            // 
            this.packSizeDataGridViewTextBoxColumn.DataPropertyName = "Pack_Size";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.packSizeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.packSizeDataGridViewTextBoxColumn.FillWeight = 43.23149F;
            this.packSizeDataGridViewTextBoxColumn.HeaderText = "Pa.Size";
            this.packSizeDataGridViewTextBoxColumn.Name = "packSizeDataGridViewTextBoxColumn";
            this.packSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.qtyDataGridViewTextBoxColumn.FillWeight = 86.98396F;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.Amount.FillWeight = 117.885F;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // transferNoteBindingSource
            // 
            this.transferNoteBindingSource.DataMember = "TransferNote";
            this.transferNoteBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 411);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(990, 66);
            this.toolStrip1.TabIndex = 132;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(472, 354);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(29, 21);
            this.btnItemSearch.TabIndex = 8;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(185, 355);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(284, 20);
            this.txtProductName.TabIndex = 7;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(49, 355);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(130, 20);
            this.txtProductCode.TabIndex = 6;
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(747, 356);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(102, 20);
            this.txtQty.TabIndex = 9;
            this.txtQty.Text = "0.00";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.SystemColors.Window;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmount.Location = new System.Drawing.Point(852, 356);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAmount.Size = new System.Drawing.Size(130, 20);
            this.lblAmount.TabIndex = 142;
            this.lblAmount.Text = "0.00";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Location = new System.Drawing.Point(852, 385);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTotalAmount.Size = new System.Drawing.Size(130, 20);
            this.lblTotalAmount.TabIndex = 143;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalQty.Location = new System.Drawing.Point(747, 385);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTotalQty.Size = new System.Drawing.Size(102, 20);
            this.lblTotalQty.TabIndex = 144;
            this.lblTotalQty.Text = "0.00";
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(734, 420);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(871, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(687, 387);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 147;
            this.label10.Text = "Total";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(307, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 148;
            this.label3.Text = "Current Stock is :";
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentQty.Location = new System.Drawing.Point(409, 380);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblCurrentQty.Size = new System.Drawing.Size(104, 24);
            this.lblCurrentQty.TabIndex = 149;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(466, 420);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 50);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(596, 421);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.Location = new System.Drawing.Point(520, 355);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(86, 19);
            this.lblPurchasePrice.TabIndex = 150;
            this.lblPurchasePrice.Text = "0.00";
            this.lblPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.Location = new System.Drawing.Point(626, 355);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(86, 19);
            this.lblSellingPrice.TabIndex = 151;
            this.lblSellingPrice.Text = "0.00";
            this.lblSellingPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(16, 419);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 152;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 216;
            this.label6.Text = "Batch";
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(95, 381);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(206, 21);
            this.cmbBatchNo.TabIndex = 215;
            this.cmbBatchNo.SelectedIndexChanged += new System.EventHandler(this.cmbBatchNo_SelectedIndexChanged);
            // 
            // frmTransferGoodNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(990, 477);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbBatchNo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblSellingPrice);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCurrentQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnItemSearch);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransferGoodNote";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Of Goods Note";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransferGoodNote_FormClosed);
            this.Load += new System.EventHandler(this.frmTransferGoodNote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTransferGoodNote_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempTGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferNoteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocaName;
        private System.Windows.Forms.Label lblLocaCode;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridTempTGN;
        private System.Windows.Forms.BindingSource transferNoteBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveDocSearch;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.TextBox txtGrnNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}