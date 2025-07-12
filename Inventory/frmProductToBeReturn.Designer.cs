namespace Inventory
{
    partial class frmProductToBeReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveDocSearch = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLocaName = new System.Windows.Forms.Label();
            this.lblLocaCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridTempToBeReturn = new System.Windows.Forms.DataGridView();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferNoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPurchPrice = new System.Windows.Forms.TextBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.likViewbincard = new System.Windows.Forms.LinkLabel();
            this.btnExcelim = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempToBeReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferNoteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BackColor = System.Drawing.Color.LightCyan;
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(120, 16);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTempDocNo.Size = new System.Drawing.Size(85, 20);
            this.lblTempDocNo.TabIndex = 9;
            this.lblTempDocNo.Text = "TE01000001";
            this.lblTempDocNo.Click += new System.EventHandler(this.lblTempDocNo_Click);
            this.lblTempDocNo.Enter += new System.EventHandler(this.lblTempDocNo_Enter);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(466, 464);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 50);
            this.btnPreview.TabIndex = 156;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentQty.Location = new System.Drawing.Point(204, 430);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblCurrentQty.Size = new System.Drawing.Size(104, 24);
            this.lblCurrentQty.TabIndex = 166;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(102, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 165;
            this.label3.Text = "Current Stock is :";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(687, 436);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 164;
            this.label10.Text = "Total";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(871, 464);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 159;
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
            this.btnApply.Location = new System.Drawing.Point(734, 464);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 158;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalQty.Location = new System.Drawing.Point(747, 434);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTotalQty.Size = new System.Drawing.Size(102, 20);
            this.lblTotalQty.TabIndex = 163;
            this.lblTotalQty.Text = "0.00";
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Location = new System.Drawing.Point(852, 434);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTotalAmount.Size = new System.Drawing.Size(130, 20);
            this.lblTotalAmount.TabIndex = 162;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.SystemColors.Window;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmount.Location = new System.Drawing.Point(852, 405);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(130, 20);
            this.lblAmount.TabIndex = 161;
            this.lblAmount.Text = "0.00";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(747, 405);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(102, 20);
            this.txtQty.TabIndex = 155;
            this.txtQty.Text = "0.00";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(445, 402);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(37, 23);
            this.btnItemSearch.TabIndex = 154;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(168, 404);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(281, 20);
            this.txtProductName.TabIndex = 153;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            this.txtProductName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyUp);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(9, 404);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(153, 20);
            this.txtProductCode.TabIndex = 152;
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 460);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(995, 66);
            this.toolStrip1.TabIndex = 160;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemarks.Location = new System.Drawing.Point(327, 41);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(271, 20);
            this.txtRemarks.TabIndex = 5;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.SystemColors.Window;
            this.txtReference.ForeColor = System.Drawing.Color.Black;
            this.txtReference.Location = new System.Drawing.Point(327, 15);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(271, 20);
            this.txtReference.TabIndex = 4;
            this.txtReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReference_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Remarks";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(270, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Reference";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcelim);
            this.groupBox1.Controls.Add(this.btnSaveDocSearch);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtReference);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblTempDocNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblLocaName);
            this.groupBox1.Controls.Add(this.lblLocaCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 69);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveDocSearch
            // 
            this.btnSaveDocSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSaveDocSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSaveDocSearch.Location = new System.Drawing.Point(208, 15);
            this.btnSaveDocSearch.Name = "btnSaveDocSearch";
            this.btnSaveDocSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSaveDocSearch.TabIndex = 153;
            this.btnSaveDocSearch.TabStop = false;
            this.btnSaveDocSearch.UseVisualStyleBackColor = true;
            this.btnSaveDocSearch.Click += new System.EventHandler(this.btnSaveDocSearch_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.LightCyan;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Location = new System.Drawing.Point(120, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDate.Size = new System.Drawing.Size(85, 20);
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
            // lblLocaName
            // 
            this.lblLocaName.BackColor = System.Drawing.Color.LightCyan;
            this.lblLocaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocaName.Location = new System.Drawing.Point(752, 16);
            this.lblLocaName.Name = "lblLocaName";
            this.lblLocaName.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblLocaName.Size = new System.Drawing.Size(228, 20);
            this.lblLocaName.TabIndex = 3;
            this.lblLocaName.Text = "02";
            // 
            // lblLocaCode
            // 
            this.lblLocaCode.BackColor = System.Drawing.Color.LightCyan;
            this.lblLocaCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocaCode.Location = new System.Drawing.Point(682, 16);
            this.lblLocaCode.Name = "lblLocaCode";
            this.lblLocaCode.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblLocaCode.Size = new System.Drawing.Size(63, 20);
            this.lblLocaCode.TabIndex = 2;
            this.lblLocaCode.Text = "01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridTempToBeReturn);
            this.groupBox2.Location = new System.Drawing.Point(4, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(985, 328);
            this.groupBox2.TabIndex = 151;
            this.groupBox2.TabStop = false;
            // 
            // dataGridTempToBeReturn
            // 
            this.dataGridTempToBeReturn.AllowUserToAddRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridTempToBeReturn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridTempToBeReturn.AutoGenerateColumns = false;
            this.dataGridTempToBeReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTempToBeReturn.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridTempToBeReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTempToBeReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.packSizeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.Amount});
            this.dataGridTempToBeReturn.DataSource = this.transferNoteBindingSource;
            this.dataGridTempToBeReturn.Location = new System.Drawing.Point(6, 13);
            this.dataGridTempToBeReturn.Name = "dataGridTempToBeReturn";
            this.dataGridTempToBeReturn.Size = new System.Drawing.Size(977, 309);
            this.dataGridTempToBeReturn.TabIndex = 0;
            this.dataGridTempToBeReturn.DoubleClick += new System.EventHandler(this.dataGridTempToBeReturn_DoubleClick);
            this.dataGridTempToBeReturn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridTempToBeReturn_KeyDown);
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.FillWeight = 100.4197F;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Product Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.FillWeight = 221.663F;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_Price";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.sellingPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.sellingPriceDataGridViewTextBoxColumn.FillWeight = 63.63725F;
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N3";
            this.purchasepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.purchasepriceDataGridViewTextBoxColumn.FillWeight = 69.05375F;
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packSizeDataGridViewTextBoxColumn
            // 
            this.packSizeDataGridViewTextBoxColumn.DataPropertyName = "Pack_Size";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.packSizeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.packSizeDataGridViewTextBoxColumn.FillWeight = 40.63968F;
            this.packSizeDataGridViewTextBoxColumn.HeaderText = "P_Size";
            this.packSizeDataGridViewTextBoxColumn.Name = "packSizeDataGridViewTextBoxColumn";
            this.packSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.qtyDataGridViewTextBoxColumn.FillWeight = 81.76909F;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N3";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle18;
            this.Amount.FillWeight = 110.8176F;
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
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(596, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 157;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPurchPrice
            // 
            this.txtPurchPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchPrice.Location = new System.Drawing.Point(488, 405);
            this.txtPurchPrice.Name = "txtPurchPrice";
            this.txtPurchPrice.Size = new System.Drawing.Size(90, 20);
            this.txtPurchPrice.TabIndex = 167;
            this.txtPurchPrice.Text = "0.00";
            this.txtPurchPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchPrice_KeyDown);
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSellingPrice.Location = new System.Drawing.Point(584, 405);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(90, 20);
            this.txtSellingPrice.TabIndex = 168;
            this.txtSellingPrice.Text = "0.00";
            this.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            // 
            // likViewbincard
            // 
            this.likViewbincard.AutoSize = true;
            this.likViewbincard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.likViewbincard.Location = new System.Drawing.Point(606, 440);
            this.likViewbincard.Name = "likViewbincard";
            this.likViewbincard.Size = new System.Drawing.Size(68, 13);
            this.likViewbincard.TabIndex = 169;
            this.likViewbincard.TabStop = true;
            this.likViewbincard.Text = "View bincard";
            this.likViewbincard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.likViewbincard_LinkClicked);
            // 
            // btnExcelim
            // 
            this.btnExcelim.Location = new System.Drawing.Point(752, 41);
            this.btnExcelim.Name = "btnExcelim";
            this.btnExcelim.Size = new System.Drawing.Size(227, 23);
            this.btnExcelim.TabIndex = 170;
            this.btnExcelim.Text = "Import From Excel";
            this.btnExcelim.UseVisualStyleBackColor = true;
            this.btnExcelim.Click += new System.EventHandler(this.btnExcelim_Click);
            // 
            // frmProductToBeReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(995, 526);
            this.Controls.Add(this.likViewbincard);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.txtPurchPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPreview);
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
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductToBeReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product To Be Return";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductToBeReturn_FormClosed);
            this.Load += new System.EventHandler(this.frmProductToBeReturn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductToBeReturn_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempToBeReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferNoteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource transferNoteBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnSaveDocSearch;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLocaName;
        private System.Windows.Forms.Label lblLocaCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridTempToBeReturn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.TextBox txtPurchPrice;
        private System.Windows.Forms.TextBox txtSellingPrice;
        public System.Windows.Forms.LinkLabel likViewbincard;
        private System.Windows.Forms.Button btnExcelim;
    }
}