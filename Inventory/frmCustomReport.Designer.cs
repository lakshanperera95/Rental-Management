namespace Inventory
{
    partial class frmCustomReport
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkAllLoca = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnCusSearch = new System.Windows.Forms.Button();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.lblLoca = new System.Windows.Forms.Label();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgSelectedCusDetails = new System.Windows.Forms.DataGridView();
            this.fittingDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workshopNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dailyDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data_Set = new Inventory.dsForReports();
            this.btnMoreInquire = new System.Windows.Forms.Button();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.raiCustomerType = new System.Windows.Forms.RadioButton();
            this.raiAll = new System.Windows.Forms.RadioButton();
            this.cmbPoints = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpUpto = new System.Windows.Forms.DateTimePicker();
            this.lblUpto = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.rbLoca = new System.Windows.Forms.RadioButton();
            this.cmbLoca = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedCusDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(9, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Customer";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(89, 39);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(119, 21);
            this.txtCustomerID.TabIndex = 2;
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(208, 39);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(368, 21);
            this.txtCustomerName.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.btnDisplay);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.chkAllLoca);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.btnCusSearch);
            this.groupBox1.Controls.Add(this.btnLocaSearch);
            this.groupBox1.Controls.Add(this.txtCustomerID);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.txtLocaName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblLoca);
            this.groupBox1.Controls.Add(this.txtLocaCode);
            this.groupBox1.Location = new System.Drawing.Point(4, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(10, 69);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 13);
            this.lblType.TabIndex = 74;
            this.lblType.Text = "Type";
            this.lblType.Visible = false;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisplay.Location = new System.Drawing.Point(369, 63);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(87, 25);
            this.btnDisplay.TabIndex = 5;
            this.btnDisplay.Text = "&Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(462, 63);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 25);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(555, 63);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 25);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(89, 66);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(265, 21);
            this.cmbCategory.TabIndex = 72;
            this.cmbCategory.Visible = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(10, 69);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(66, 13);
            this.lblCategory.TabIndex = 71;
            this.lblCategory.Text = "Category";
            this.lblCategory.Visible = false;
            // 
            // chkAllLoca
            // 
            this.chkAllLoca.Location = new System.Drawing.Point(606, 16);
            this.chkAllLoca.Name = "chkAllLoca";
            this.chkAllLoca.Size = new System.Drawing.Size(40, 17);
            this.chkAllLoca.TabIndex = 70;
            this.chkAllLoca.Text = "All";
            this.chkAllLoca.UseVisualStyleBackColor = true;
            this.chkAllLoca.Visible = false;
            this.chkAllLoca.CheckedChanged += new System.EventHandler(this.chkAllLoca_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(606, 40);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(40, 17);
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnCusSearch
            // 
            this.btnCusSearch.BackgroundImage = global::Inventory.Properties.Resources.Search;
            this.btnCusSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCusSearch.Location = new System.Drawing.Point(576, 39);
            this.btnCusSearch.Name = "btnCusSearch";
            this.btnCusSearch.Size = new System.Drawing.Size(26, 19);
            this.btnCusSearch.TabIndex = 4;
            this.btnCusSearch.UseVisualStyleBackColor = true;
            this.btnCusSearch.Click += new System.EventHandler(this.btnCusSearch_Click);
            // 
            // btnLocaSearch
            // 
            this.btnLocaSearch.BackgroundImage = global::Inventory.Properties.Resources.Search;
            this.btnLocaSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocaSearch.Location = new System.Drawing.Point(576, 14);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(27, 21);
            this.btnLocaSearch.TabIndex = 69;
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Visible = false;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // txtLocaName
            // 
            this.txtLocaName.Location = new System.Drawing.Point(208, 14);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(368, 21);
            this.txtLocaName.TabIndex = 1;
            this.txtLocaName.Visible = false;
            // 
            // lblLoca
            // 
            this.lblLoca.AutoSize = true;
            this.lblLoca.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoca.Location = new System.Drawing.Point(10, 17);
            this.lblLoca.Name = "lblLoca";
            this.lblLoca.Size = new System.Drawing.Size(62, 13);
            this.lblLoca.TabIndex = 66;
            this.lblLoca.Text = "Location";
            this.lblLoca.Visible = false;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Location = new System.Drawing.Point(89, 14);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(119, 21);
            this.txtLocaCode.TabIndex = 0;
            this.txtLocaCode.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgSelectedCusDetails);
            this.groupBox2.Location = new System.Drawing.Point(7, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 238);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "More Inquire";
            // 
            // dgSelectedCusDetails
            // 
            this.dgSelectedCusDetails.AllowUserToAddRows = false;
            this.dgSelectedCusDetails.AllowUserToDeleteRows = false;
            this.dgSelectedCusDetails.AllowUserToResizeColumns = false;
            this.dgSelectedCusDetails.AllowUserToResizeRows = false;
            this.dgSelectedCusDetails.AutoGenerateColumns = false;
            this.dgSelectedCusDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSelectedCusDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedCusDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fittingDataGridViewCheckBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.workshopNameDataGridViewTextBoxColumn,
            this.Loca});
            this.dgSelectedCusDetails.DataSource = this.dailyDetailsBindingSource;
            this.dgSelectedCusDetails.Location = new System.Drawing.Point(10, 22);
            this.dgSelectedCusDetails.Name = "dgSelectedCusDetails";
            this.dgSelectedCusDetails.RowHeadersVisible = false;
            this.dgSelectedCusDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSelectedCusDetails.Size = new System.Drawing.Size(612, 208);
            this.dgSelectedCusDetails.TabIndex = 0;
            this.dgSelectedCusDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSelectedCusDetails_CellContentClick);
            // 
            // fittingDataGridViewCheckBoxColumn
            // 
            this.fittingDataGridViewCheckBoxColumn.DataPropertyName = "Fitting";
            this.fittingDataGridViewCheckBoxColumn.FillWeight = 15.56017F;
            this.fittingDataGridViewCheckBoxColumn.HeaderText = "";
            this.fittingDataGridViewCheckBoxColumn.Name = "fittingDataGridViewCheckBoxColumn";
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.FillWeight = 60.37104F;
            this.customerDataGridViewTextBoxColumn.HeaderText = "Code";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workshopNameDataGridViewTextBoxColumn
            // 
            this.workshopNameDataGridViewTextBoxColumn.DataPropertyName = "WorkshopName";
            this.workshopNameDataGridViewTextBoxColumn.FillWeight = 224.0688F;
            this.workshopNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.workshopNameDataGridViewTextBoxColumn.Name = "workshopNameDataGridViewTextBoxColumn";
            this.workshopNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Loca
            // 
            this.Loca.DataPropertyName = "Loca";
            this.Loca.HeaderText = "Loca";
            this.Loca.Name = "Loca";
            // 
            // dailyDetailsBindingSource
            // 
            this.dailyDetailsBindingSource.DataMember = "DailyDetails";
            this.dailyDetailsBindingSource.DataSource = this.data_Set;
            // 
            // data_Set
            // 
            this.data_Set.DataSetName = "Data_Set";
            this.data_Set.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnMoreInquire
            // 
            this.btnMoreInquire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoreInquire.Location = new System.Drawing.Point(16, 114);
            this.btnMoreInquire.Name = "btnMoreInquire";
            this.btnMoreInquire.Size = new System.Drawing.Size(124, 25);
            this.btnMoreInquire.TabIndex = 5;
            this.btnMoreInquire.Text = "&More Inquire >>";
            this.btnMoreInquire.UseVisualStyleBackColor = true;
            this.btnMoreInquire.Visible = false;
            this.btnMoreInquire.Click += new System.EventHandler(this.btnMoreInquire_Click);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(338, 118);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(105, 21);
            this.cmbCustomerType.TabIndex = 4;
            this.cmbCustomerType.Visible = false;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            // 
            // raiCustomerType
            // 
            this.raiCustomerType.AutoSize = true;
            this.raiCustomerType.Location = new System.Drawing.Point(220, 120);
            this.raiCustomerType.Name = "raiCustomerType";
            this.raiCustomerType.Size = new System.Drawing.Size(112, 17);
            this.raiCustomerType.TabIndex = 21;
            this.raiCustomerType.TabStop = true;
            this.raiCustomerType.Text = "Customer Type";
            this.raiCustomerType.UseVisualStyleBackColor = true;
            this.raiCustomerType.Visible = false;
            this.raiCustomerType.CheckedChanged += new System.EventHandler(this.raiCustomerType_CheckedChanged);
            // 
            // raiAll
            // 
            this.raiAll.AutoSize = true;
            this.raiAll.Location = new System.Drawing.Point(175, 120);
            this.raiAll.Name = "raiAll";
            this.raiAll.Size = new System.Drawing.Size(39, 17);
            this.raiAll.TabIndex = 22;
            this.raiAll.TabStop = true;
            this.raiAll.Text = "All";
            this.raiAll.UseVisualStyleBackColor = true;
            this.raiAll.Visible = false;
            this.raiAll.CheckedChanged += new System.EventHandler(this.raiAll_CheckedChanged);
            // 
            // cmbPoints
            // 
            this.cmbPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPoints.FormattingEnabled = true;
            this.cmbPoints.Location = new System.Drawing.Point(63, 118);
            this.cmbPoints.Name = "cmbPoints";
            this.cmbPoints.Size = new System.Drawing.Size(108, 21);
            this.cmbPoints.TabIndex = 3;
            this.cmbPoints.Visible = false;
            this.cmbPoints.SelectedIndexChanged += new System.EventHandler(this.cmbPoints_SelectedIndexChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(14, 122);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(41, 13);
            this.lblPoint.TabIndex = 5;
            this.lblPoint.Text = "Points";
            this.lblPoint.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(146, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 75);
            this.dataGridView1.TabIndex = 73;
            this.dataGridView1.Visible = false;
            // 
            // dtpUpto
            // 
            this.dtpUpto.CustomFormat = "dd/MM/yyyy";
            this.dtpUpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUpto.Location = new System.Drawing.Point(93, 91);
            this.dtpUpto.Name = "dtpUpto";
            this.dtpUpto.Size = new System.Drawing.Size(188, 21);
            this.dtpUpto.TabIndex = 74;
            this.dtpUpto.Visible = false;
            // 
            // lblUpto
            // 
            this.lblUpto.AutoSize = true;
            this.lblUpto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpto.Location = new System.Drawing.Point(14, 97);
            this.lblUpto.Name = "lblUpto";
            this.lblUpto.Size = new System.Drawing.Size(37, 13);
            this.lblUpto.TabIndex = 75;
            this.lblUpto.Text = "Upto";
            this.lblUpto.Visible = false;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(93, 90);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(121, 21);
            this.dtpDateFrom.TabIndex = 76;
            this.dtpDateFrom.Visible = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(297, 89);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(121, 21);
            this.dtpDateTo.TabIndex = 77;
            this.dtpDateTo.Visible = false;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(16, 90);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(75, 13);
            this.lblDateFrom.TabIndex = 78;
            this.lblDateFrom.Text = "Date From";
            this.lblDateFrom.Visible = false;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(234, 91);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(57, 13);
            this.lblDateTo.TabIndex = 79;
            this.lblDateTo.Text = "Date To";
            this.lblDateTo.Visible = false;
            // 
            // rbLoca
            // 
            this.rbLoca.AutoSize = true;
            this.rbLoca.Enabled = false;
            this.rbLoca.Location = new System.Drawing.Point(457, 120);
            this.rbLoca.Name = "rbLoca";
            this.rbLoca.Size = new System.Drawing.Size(72, 17);
            this.rbLoca.TabIndex = 81;
            this.rbLoca.TabStop = true;
            this.rbLoca.Text = "Location";
            this.rbLoca.UseVisualStyleBackColor = true;
            this.rbLoca.Visible = false;
            // 
            // cmbLoca
            // 
            this.cmbLoca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoca.Enabled = false;
            this.cmbLoca.FormattingEnabled = true;
            this.cmbLoca.Location = new System.Drawing.Point(535, 118);
            this.cmbLoca.Name = "cmbLoca";
            this.cmbLoca.Size = new System.Drawing.Size(105, 21);
            this.cmbLoca.TabIndex = 80;
            this.cmbLoca.Visible = false;
            // 
            // frmCustomReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 144);
            this.Controls.Add(this.rbLoca);
            this.Controls.Add(this.cmbLoca);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.lblUpto);
            this.Controls.Add(this.dtpUpto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnMoreInquire);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.raiAll);
            this.Controls.Add(this.raiCustomerType);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.cmbPoints);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCustomReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomReport_FormClosing);
            this.Load += new System.EventHandler(this.frmCustomReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedCusDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCusSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMoreInquire;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.RadioButton raiCustomerType;
        private System.Windows.Forms.RadioButton raiAll;
        private System.Windows.Forms.DataGridView dgSelectedCusDetails;
        private System.Windows.Forms.BindingSource dailyDetailsBindingSource;
        private dsForReports data_Set;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fittingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workshopNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbPoints;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.Label lblLoca;
        private System.Windows.Forms.CheckBox chkAllLoca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loca;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DateTimePicker dtpUpto;
        private System.Windows.Forms.Label lblUpto;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.RadioButton rbLoca;
        private System.Windows.Forms.ComboBox cmbLoca;
    }
}