namespace Inventory
{
    partial class frmProductPriceMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPurchPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMMPrice = new System.Windows.Forms.Label();
            this.lblDPrice = new System.Windows.Forms.Label();
            this.lblWPrice = new System.Windows.Forms.Label();
            this.lblRPrice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPurchPrice = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtMMPrice = new System.Windows.Forms.TextBox();
            this.txtDPrice = new System.Windows.Forms.TextBox();
            this.txtWPrice = new System.Windows.Forms.TextBox();
            this.txtRPrice = new System.Windows.Forms.TextBox();
            this.dataGridViewProductPriceLevel = new System.Windows.Forms.DataGridView();
            this.dsPriceMasterDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mMPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPriceMasterDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 358);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(762, 63);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(592, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.Enabled = false;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(472, 360);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Save";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblPurchPrice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblMMPrice);
            this.groupBox2.Controls.Add(this.lblDPrice);
            this.groupBox2.Controls.Add(this.lblWPrice);
            this.groupBox2.Controls.Add(this.lblRPrice);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnItemSearch);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Location = new System.Drawing.Point(3, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 89);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Purchase Price";
            // 
            // lblPurchPrice
            // 
            this.lblPurchPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblPurchPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPurchPrice.Location = new System.Drawing.Point(8, 64);
            this.lblPurchPrice.Name = "lblPurchPrice";
            this.lblPurchPrice.Size = new System.Drawing.Size(98, 18);
            this.lblPurchPrice.TabIndex = 24;
            this.lblPurchPrice.Text = "0.00";
            this.lblPurchPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(400, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Distribution Price";
            // 
            // lblMMPrice
            // 
            this.lblMMPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblMMPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMMPrice.Location = new System.Drawing.Point(536, 64);
            this.lblMMPrice.Name = "lblMMPrice";
            this.lblMMPrice.Size = new System.Drawing.Size(98, 18);
            this.lblMMPrice.TabIndex = 22;
            this.lblMMPrice.Text = "0.00";
            this.lblMMPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDPrice
            // 
            this.lblDPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblDPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDPrice.Location = new System.Drawing.Point(400, 64);
            this.lblDPrice.Name = "lblDPrice";
            this.lblDPrice.Size = new System.Drawing.Size(98, 18);
            this.lblDPrice.TabIndex = 21;
            this.lblDPrice.Text = "0.00";
            this.lblDPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWPrice
            // 
            this.lblWPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblWPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWPrice.Location = new System.Drawing.Point(264, 64);
            this.lblWPrice.Name = "lblWPrice";
            this.lblWPrice.Size = new System.Drawing.Size(98, 18);
            this.lblWPrice.TabIndex = 20;
            this.lblWPrice.Text = "0.00";
            this.lblWPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRPrice
            // 
            this.lblRPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblRPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRPrice.Location = new System.Drawing.Point(136, 64);
            this.lblRPrice.Name = "lblRPrice";
            this.lblRPrice.Size = new System.Drawing.Size(98, 18);
            this.lblRPrice.TabIndex = 19;
            this.lblRPrice.Text = "0.00";
            this.lblRPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoEllipsis = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(536, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Modern Market Price";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Retail Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wholesale Price";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(552, 16);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(38, 19);
            this.btnItemSearch.TabIndex = 2;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(160, 15);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(383, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(56, 15);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(96, 20);
            this.txtProductCode.TabIndex = 0;
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtPurchPrice);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.txtMMPrice);
            this.groupBox1.Controls.Add(this.txtDPrice);
            this.groupBox1.Controls.Add(this.txtWPrice);
            this.groupBox1.Controls.Add(this.txtRPrice);
            this.groupBox1.Controls.Add(this.dataGridViewProductPriceLevel);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Price Levels";
            // 
            // txtPurchPrice
            // 
            this.txtPurchPrice.Location = new System.Drawing.Point(8, 24);
            this.txtPurchPrice.Name = "txtPurchPrice";
            this.txtPurchPrice.Size = new System.Drawing.Size(98, 20);
            this.txtPurchPrice.TabIndex = 0;
            this.txtPurchPrice.Text = "0.00";
            this.txtPurchPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchPrice_KeyDown);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(718, 21);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(21, 23);
            this.btnInsert.TabIndex = 25;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtMMPrice
            // 
            this.txtMMPrice.Location = new System.Drawing.Point(536, 24);
            this.txtMMPrice.Name = "txtMMPrice";
            this.txtMMPrice.Size = new System.Drawing.Size(98, 20);
            this.txtMMPrice.TabIndex = 4;
            this.txtMMPrice.Text = "0.00";
            this.txtMMPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMMPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMMPrice_KeyDown);
            // 
            // txtDPrice
            // 
            this.txtDPrice.Location = new System.Drawing.Point(400, 24);
            this.txtDPrice.Name = "txtDPrice";
            this.txtDPrice.Size = new System.Drawing.Size(98, 20);
            this.txtDPrice.TabIndex = 3;
            this.txtDPrice.Text = "0.00";
            this.txtDPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDPrice_KeyDown);
            // 
            // txtWPrice
            // 
            this.txtWPrice.Location = new System.Drawing.Point(264, 24);
            this.txtWPrice.Name = "txtWPrice";
            this.txtWPrice.Size = new System.Drawing.Size(98, 20);
            this.txtWPrice.TabIndex = 2;
            this.txtWPrice.Text = "0.00";
            this.txtWPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWPrice_KeyDown);
            // 
            // txtRPrice
            // 
            this.txtRPrice.Location = new System.Drawing.Point(136, 24);
            this.txtRPrice.Name = "txtRPrice";
            this.txtRPrice.Size = new System.Drawing.Size(98, 20);
            this.txtRPrice.TabIndex = 1;
            this.txtRPrice.Text = "0.00";
            this.txtRPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRPrice_KeyDown);
            // 
            // dataGridViewProductPriceLevel
            // 
            this.dataGridViewProductPriceLevel.AllowUserToAddRows = false;
            this.dataGridViewProductPriceLevel.AllowUserToDeleteRows = false;
            this.dataGridViewProductPriceLevel.AllowUserToResizeColumns = false;
            this.dataGridViewProductPriceLevel.AllowUserToResizeRows = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewProductPriceLevel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewProductPriceLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductPriceLevel.AutoGenerateColumns = false;
            this.dataGridViewProductPriceLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductPriceLevel.BackgroundColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductPriceLevel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewProductPriceLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProductPriceLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchasePriceDataGridViewTextBoxColumn,
            this.rPriceDataGridViewTextBoxColumn,
            this.wPriceDataGridViewTextBoxColumn,
            this.dPriceDataGridViewTextBoxColumn,
            this.mMPriceDataGridViewTextBoxColumn,
            this.Qty});
            this.dataGridViewProductPriceLevel.DataSource = this.dsPriceMasterDetailsBindingSource;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProductPriceLevel.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewProductPriceLevel.Location = new System.Drawing.Point(12, 62);
            this.dataGridViewProductPriceLevel.Name = "dataGridViewProductPriceLevel";
            this.dataGridViewProductPriceLevel.ReadOnly = true;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductPriceLevel.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridViewProductPriceLevel.Size = new System.Drawing.Size(727, 197);
            this.dataGridViewProductPriceLevel.TabIndex = 10;
            this.dataGridViewProductPriceLevel.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewProductPriceLevel_RowPrePaint);
            this.dataGridViewProductPriceLevel.DoubleClick += new System.EventHandler(this.dataGridViewProductPriceLevel_DoubleClick);
            this.dataGridViewProductPriceLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewProductPriceLevel_KeyDown);
            // 
            // dsPriceMasterDetailsBindingSource
            // 
            this.dsPriceMasterDetailsBindingSource.DataMember = "dsPriceMasterDetails";
            this.dsPriceMasterDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(746, 248);
            this.shapeContainer1.TabIndex = 23;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 6;
            this.lineShape1.X2 = 1200;
            this.lineShape1.Y1 = 37;
            this.lineShape1.Y2 = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClearAll.Enabled = false;
            this.btnClearAll.FlatAppearance.BorderSize = 0;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(352, 360);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(100, 50);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_Price";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "N2";
            this.purchasePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle30;
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "Purch Price";
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            this.purchasePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rPriceDataGridViewTextBoxColumn
            // 
            this.rPriceDataGridViewTextBoxColumn.DataPropertyName = "RPrice";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "N2";
            this.rPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle31;
            this.rPriceDataGridViewTextBoxColumn.HeaderText = "Retail Price";
            this.rPriceDataGridViewTextBoxColumn.Name = "rPriceDataGridViewTextBoxColumn";
            this.rPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wPriceDataGridViewTextBoxColumn
            // 
            this.wPriceDataGridViewTextBoxColumn.DataPropertyName = "WPrice";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.Format = "N2";
            this.wPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle32;
            this.wPriceDataGridViewTextBoxColumn.HeaderText = "Wholesale Price";
            this.wPriceDataGridViewTextBoxColumn.Name = "wPriceDataGridViewTextBoxColumn";
            this.wPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dPriceDataGridViewTextBoxColumn
            // 
            this.dPriceDataGridViewTextBoxColumn.DataPropertyName = "DPrice";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Format = "N2";
            this.dPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle33;
            this.dPriceDataGridViewTextBoxColumn.HeaderText = "Distribution Price";
            this.dPriceDataGridViewTextBoxColumn.Name = "dPriceDataGridViewTextBoxColumn";
            this.dPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mMPriceDataGridViewTextBoxColumn
            // 
            this.mMPriceDataGridViewTextBoxColumn.DataPropertyName = "MMPrice";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "N2";
            this.mMPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle34;
            this.mMPriceDataGridViewTextBoxColumn.HeaderText = "Mod Mar. Price";
            this.mMPriceDataGridViewTextBoxColumn.Name = "mMPriceDataGridViewTextBoxColumn";
            this.mMPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.FillWeight = 80F;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(640, 24);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(72, 20);
            this.txtQty.TabIndex = 26;
            this.txtQty.Text = "0";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(643, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Qty";
            // 
            // frmProductPriceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(762, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductPriceMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Price Master";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductPriceMaster_FormClosed);
            this.Load += new System.EventHandler(this.frmProductPriceMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductPriceMaster_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPriceMasterDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewProductPriceLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.BindingSource dsPriceMasterDetailsBindingSource;
        private dsForReports dsForReports;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtDPrice;
        private System.Windows.Forms.TextBox txtWPrice;
        private System.Windows.Forms.TextBox txtRPrice;
        private System.Windows.Forms.Label lblMMPrice;
        private System.Windows.Forms.Label lblDPrice;
        private System.Windows.Forms.Label lblWPrice;
        private System.Windows.Forms.Label lblRPrice;
        private System.Windows.Forms.TextBox txtMMPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPurchPrice;
        private System.Windows.Forms.TextBox txtPurchPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mMPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
    }
}