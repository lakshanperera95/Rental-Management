namespace Inventory
{
    partial class frmTaxTransfer
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTrDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.lblSRNAmount = new System.Windows.Forms.Label();
            this.dgTransferingPurchDetails = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supp_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsTempTransferingDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.dgSelectedPurchDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsSelectedTransferingDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTransferingAmount = new System.Windows.Forms.Label();
            this.lblTransfering = new System.Windows.Forms.Label();
            this.lblSelectedAmount = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.lblloca = new System.Windows.Forms.Label();
            this.dtpTrDateTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransferingPurchDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempTransferingDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedPurchDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSelectedTransferingDocDetailsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 488);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(757, 64);
            this.toolStrip1.TabIndex = 144;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(550, 498);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 42);
            this.btnClear.TabIndex = 146;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(448, 498);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 42);
            this.btnBack.TabIndex = 145;
            this.btnBack.Text = "Transfer";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(653, 498);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 42);
            this.btnExit.TabIndex = 147;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.LightBlue;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(665, 41);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 148;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 149;
            this.label1.Text = "Transaction Date From:";
            // 
            // dtpTrDateFrom
            // 
            this.dtpTrDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrDateFrom.Location = new System.Drawing.Point(131, 36);
            this.dtpTrDateFrom.Name = "dtpTrDateFrom";
            this.dtpTrDateFrom.Size = new System.Drawing.Size(110, 20);
            this.dtpTrDateFrom.TabIndex = 150;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.SteelBlue;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(12, 383);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(139, 18);
            this.lblMsg.TabIndex = 189;
            this.lblMsg.Text = "Please wait.........";
            this.lblMsg.Visible = false;
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.Location = new System.Drawing.Point(329, 41);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(69, 13);
            this.lable.TabIndex = 188;
            this.lable.Text = "SRN Amount";
            this.lable.Visible = false;
            // 
            // lblSRNAmount
            // 
            this.lblSRNAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSRNAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSRNAmount.ForeColor = System.Drawing.Color.Orchid;
            this.lblSRNAmount.Location = new System.Drawing.Point(407, 36);
            this.lblSRNAmount.Name = "lblSRNAmount";
            this.lblSRNAmount.Size = new System.Drawing.Size(139, 21);
            this.lblSRNAmount.TabIndex = 185;
            this.lblSRNAmount.Text = "0.00";
            this.lblSRNAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSRNAmount.Visible = false;
            // 
            // dgTransferingPurchDetails
            // 
            this.dgTransferingPurchDetails.AllowUserToAddRows = false;
            this.dgTransferingPurchDetails.AllowUserToDeleteRows = false;
            this.dgTransferingPurchDetails.AllowUserToResizeColumns = false;
            this.dgTransferingPurchDetails.AllowUserToResizeRows = false;
            this.dgTransferingPurchDetails.AutoGenerateColumns = false;
            this.dgTransferingPurchDetails.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgTransferingPurchDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransferingPurchDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.docNoDataGridViewTextBoxColumn,
            this.Supp_Code,
            this.Supp_Name,
            this.qtyDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.checkDataGridViewCheckBoxColumn});
            this.dgTransferingPurchDetails.DataSource = this.dsTempTransferingDocDetailsBindingSource;
            this.dgTransferingPurchDetails.Location = new System.Drawing.Point(10, 12);
            this.dgTransferingPurchDetails.Name = "dgTransferingPurchDetails";
            this.dgTransferingPurchDetails.Size = new System.Drawing.Size(730, 184);
            this.dgTransferingPurchDetails.TabIndex = 207;
            this.dgTransferingPurchDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransferingPurchDetails_CellValueChanged);
            this.dgTransferingPurchDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgTransferingPurchDetails_CurrentCellDirtyStateChanged);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 88;
            // 
            // docNoDataGridViewTextBoxColumn
            // 
            this.docNoDataGridViewTextBoxColumn.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn.HeaderText = "Doc_No";
            this.docNoDataGridViewTextBoxColumn.Name = "docNoDataGridViewTextBoxColumn";
            this.docNoDataGridViewTextBoxColumn.Width = 80;
            // 
            // Supp_Code
            // 
            this.Supp_Code.DataPropertyName = "Supp_Code";
            this.Supp_Code.HeaderText = "Acc_Code";
            this.Supp_Code.Name = "Supp_Code";
            this.Supp_Code.Width = 80;
            // 
            // Supp_Name
            // 
            this.Supp_Name.DataPropertyName = "Supp_Name";
            this.Supp_Name.HeaderText = "Acc_Name";
            this.Supp_Name.Name = "Supp_Name";
            this.Supp_Name.Width = 170;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.Width = 79;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 120;
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            this.checkDataGridViewCheckBoxColumn.HeaderText = "Check";
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            this.checkDataGridViewCheckBoxColumn.Width = 70;
            // 
            // dsTempTransferingDocDetailsBindingSource
            // 
            this.dsTempTransferingDocDetailsBindingSource.DataMember = "dsTempTransferingDocDetails";
            this.dsTempTransferingDocDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgSelectedPurchDetails
            // 
            this.dgSelectedPurchDetails.AllowUserToAddRows = false;
            this.dgSelectedPurchDetails.AllowUserToDeleteRows = false;
            this.dgSelectedPurchDetails.AllowUserToResizeColumns = false;
            this.dgSelectedPurchDetails.AllowUserToResizeRows = false;
            this.dgSelectedPurchDetails.AutoGenerateColumns = false;
            this.dgSelectedPurchDetails.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgSelectedPurchDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedPurchDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.docNoDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.qtyDataGridViewTextBoxColumn1,
            this.amountDataGridViewTextBoxColumn1});
            this.dgSelectedPurchDetails.DataSource = this.dsSelectedTransferingDocDetailsBindingSource;
            this.dgSelectedPurchDetails.Location = new System.Drawing.Point(12, 229);
            this.dgSelectedPurchDetails.Name = "dgSelectedPurchDetails";
            this.dgSelectedPurchDetails.Size = new System.Drawing.Size(730, 148);
            this.dgSelectedPurchDetails.TabIndex = 208;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 88;
            // 
            // docNoDataGridViewTextBoxColumn1
            // 
            this.docNoDataGridViewTextBoxColumn1.DataPropertyName = "Doc_No";
            this.docNoDataGridViewTextBoxColumn1.HeaderText = "Doc_No";
            this.docNoDataGridViewTextBoxColumn1.Name = "docNoDataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Supp_Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Acc_Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Supp_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Acc_Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 199;
            // 
            // qtyDataGridViewTextBoxColumn1
            // 
            this.qtyDataGridViewTextBoxColumn1.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn1.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn1.Name = "qtyDataGridViewTextBoxColumn1";
            // 
            // amountDataGridViewTextBoxColumn1
            // 
            this.amountDataGridViewTextBoxColumn1.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn1.Name = "amountDataGridViewTextBoxColumn1";
            // 
            // dsSelectedTransferingDocDetailsBindingSource
            // 
            this.dsSelectedTransferingDocDetailsBindingSource.DataMember = "dsSelectedTransferingDocDetails";
            this.dsSelectedTransferingDocDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // lblTransferingAmount
            // 
            this.lblTransferingAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransferingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferingAmount.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblTransferingAmount.Location = new System.Drawing.Point(589, 380);
            this.lblTransferingAmount.Name = "lblTransferingAmount";
            this.lblTransferingAmount.Size = new System.Drawing.Size(152, 21);
            this.lblTransferingAmount.TabIndex = 209;
            this.lblTransferingAmount.Text = "0.00";
            this.lblTransferingAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTransfering
            // 
            this.lblTransfering.AutoSize = true;
            this.lblTransfering.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfering.Location = new System.Drawing.Point(457, 384);
            this.lblTransfering.Name = "lblTransfering";
            this.lblTransfering.Size = new System.Drawing.Size(126, 13);
            this.lblTransfering.TabIndex = 210;
            this.lblTransfering.Text = "Transfering GRN Amount";
            // 
            // lblSelectedAmount
            // 
            this.lblSelectedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedAmount.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblSelectedAmount.Location = new System.Drawing.Point(536, 205);
            this.lblSelectedAmount.Name = "lblSelectedAmount";
            this.lblSelectedAmount.Size = new System.Drawing.Size(109, 21);
            this.lblSelectedAmount.TabIndex = 211;
            this.lblSelectedAmount.Text = "0.00";
            this.lblSelectedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(419, 209);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(115, 13);
            this.lblSelected.TabIndex = 212;
            this.lblSelected.Text = "Selected GRN Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblSelectedAmount);
            this.groupBox1.Controls.Add(this.lblSelected);
            this.groupBox1.Controls.Add(this.lblTransferingAmount);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.dgSelectedPurchDetails);
            this.groupBox1.Controls.Add(this.dgTransferingPurchDetails);
            this.groupBox1.Controls.Add(this.lblTransfering);
            this.groupBox1.Controls.Add(this.lblSRNAmount);
            this.groupBox1.Controls.Add(this.lable);
            this.groupBox1.Location = new System.Drawing.Point(4, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 404);
            this.groupBox1.TabIndex = 213;
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(654, 202);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 25);
            this.btnAdd.TabIndex = 201;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbType);
            this.groupBox2.Controls.Add(this.btnLocaSearch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLocaName);
            this.groupBox2.Controls.Add(this.txtLocaCode);
            this.groupBox2.Controls.Add(this.lblTempDocNo);
            this.groupBox2.Controls.Add(this.lblloca);
            this.groupBox2.Controls.Add(this.dtpTrDateTo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpTrDateFrom);
            this.groupBox2.Location = new System.Drawing.Point(4, -3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 90);
            this.groupBox2.TabIndex = 214;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 220;
            this.label2.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Purchase",
            "Sales"});
            this.cmbType.Location = new System.Drawing.Point(432, 36);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 219;
            // 
            // btnLocaSearch
            // 
            this.btnLocaSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnLocaSearch.Location = new System.Drawing.Point(712, 15);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(28, 21);
            this.btnLocaSearch.TabIndex = 218;
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 217;
            this.label5.Text = "Transaction Date To:";
            // 
            // txtLocaName
            // 
            this.txtLocaName.Location = new System.Drawing.Point(495, 15);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(215, 20);
            this.txtLocaName.TabIndex = 217;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Location = new System.Drawing.Point(432, 15);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(60, 20);
            this.txtLocaCode.TabIndex = 215;
            this.txtLocaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocaCode_KeyDown);
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(131, 13);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Size = new System.Drawing.Size(110, 20);
            this.lblTempDocNo.TabIndex = 215;
            this.lblTempDocNo.Text = "0000000001";
            // 
            // lblloca
            // 
            this.lblloca.AutoSize = true;
            this.lblloca.Location = new System.Drawing.Point(378, 18);
            this.lblloca.Name = "lblloca";
            this.lblloca.Size = new System.Drawing.Size(48, 13);
            this.lblloca.TabIndex = 216;
            this.lblloca.Text = "Location";
            // 
            // dtpTrDateTo
            // 
            this.dtpTrDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrDateTo.Location = new System.Drawing.Point(131, 62);
            this.dtpTrDateTo.Name = "dtpTrDateTo";
            this.dtpTrDateTo.Size = new System.Drawing.Size(110, 20);
            this.dtpTrDateTo.TabIndex = 155;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 216;
            this.label8.Text = "Document No:";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(665, 70);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 221;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmTaxTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(757, 552);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaxTransfer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Transfer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPurchaseTransfer_FormClosed);
            this.Load += new System.EventHandler(this.frmPurchaseTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransferingPurchDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempTransferingDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedPurchDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSelectedTransferingDocDetailsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTrDateFrom;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Label lblSRNAmount;
        private System.Windows.Forms.DataGridView dgTransferingPurchDetails;
        private System.Windows.Forms.DataGridView dgSelectedPurchDetails;
        private System.Windows.Forms.Label lblTransferingAmount;
        private System.Windows.Forms.Label lblTransfering;
        private System.Windows.Forms.Label lblSelectedAmount;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.BindingSource dsTempTransferingDocDetailsBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.BindingSource dsSelectedTransferingDocDetailsBindingSource;
        private System.Windows.Forms.DateTimePicker dtpTrDateTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.Label lblloca;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supp_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.CheckBox chkAll;
    }
}