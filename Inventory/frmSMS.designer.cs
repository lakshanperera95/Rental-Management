namespace Inventory
{
    partial class frmSMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMS));
            this.btnSend = new System.Windows.Forms.Button();
            this.richMessage = new System.Windows.Forms.RichTextBox();
            this.dgCustomer = new System.Windows.Forms.DataGridView();
            this.selectDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cusCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.successDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data_Set = new Inventory.dtForGrids();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSend = new System.Windows.Forms.TabPage();
            this.lblCust = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbVPN = new System.Windows.Forms.RadioButton();
            this.rdbDongel = new System.Windows.Forms.RadioButton();
            this.rbAnniversary = new System.Windows.Forms.RadioButton();
            this.cmbCustGroup = new System.Windows.Forms.ComboBox();
            this.lblCustGroup = new System.Windows.Forms.Label();
            this.cmbCustType = new System.Windows.Forms.ComboBox();
            this.lblCustType = new System.Windows.Forms.Label();
            this.rbPurchValue = new System.Windows.Forms.RadioButton();
            this.chkSpouseBDay = new System.Windows.Forms.CheckBox();
            this.dtpCustRegDate = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtPointsTo = new System.Windows.Forms.TextBox();
            this.lblPointsTo = new System.Windows.Forms.Label();
            this.txtPointsFrom = new System.Windows.Forms.TextBox();
            this.rbPoints = new System.Windows.Forms.RadioButton();
            this.chkChildBDays = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCOMPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lisTemplate = new System.Windows.Forms.ListBox();
            this.btnTextSave = new System.Windows.Forms.Button();
            this.btnCusSearch = new System.Windows.Forms.Button();
            this.txtCus_Name = new System.Windows.Forms.TextBox();
            this.raiIndividual = new System.Windows.Forms.RadioButton();
            this.raiFestival = new System.Windows.Forms.RadioButton();
            this.raiBirthDay = new System.Windows.Forms.RadioButton();
            this.raiAll = new System.Windows.Forms.RadioButton();
            this.lblMSGLength = new System.Windows.Forms.Label();
            this.btnWithName = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.chkWithoutVen = new System.Windows.Forms.CheckBox();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblFestival = new System.Windows.Forms.Label();
            this.dtAnniversary = new System.Windows.Forms.DateTimePicker();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtCus_Code = new System.Windows.Forms.TextBox();
            this.cmbFestival = new System.Windows.Forms.ComboBox();
            this.lblPurchValue = new System.Windows.Forms.Label();
            this.chkCustRegDate = new System.Windows.Forms.CheckBox();
            this.lblPointsFrom = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.rdbReligion = new System.Windows.Forms.RadioButton();
            this.lblReligion = new System.Windows.Forms.Label();
            this.cmbReligion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Set)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSend.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(694, 406);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 27);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send SMS";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // richMessage
            // 
            this.richMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richMessage.Location = new System.Drawing.Point(7, 322);
            this.richMessage.MaxLength = 160;
            this.richMessage.Name = "richMessage";
            this.richMessage.Size = new System.Drawing.Size(208, 92);
            this.richMessage.TabIndex = 1;
            this.richMessage.Text = "";
            this.richMessage.TextChanged += new System.EventHandler(this.richMessage_TextChanged);
            // 
            // dgCustomer
            // 
            this.dgCustomer.AllowUserToAddRows = false;
            this.dgCustomer.AllowUserToDeleteRows = false;
            this.dgCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCustomer.AutoGenerateColumns = false;
            this.dgCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCustomer.BackgroundColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectDataGridViewCheckBoxColumn,
            this.cusCodeDataGridViewTextBoxColumn,
            this.cusNameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.mobileDataGridViewTextBoxColumn,
            this.birthdayDataGridViewTextBoxColumn,
            this.successDataGridViewCheckBoxColumn});
            this.dgCustomer.DataSource = this.customerBindingSource;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCustomer.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgCustomer.Location = new System.Drawing.Point(7, 66);
            this.dgCustomer.Name = "dgCustomer";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgCustomer.RowHeadersVisible = false;
            this.dgCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomer.Size = new System.Drawing.Size(766, 249);
            this.dgCustomer.TabIndex = 2;
            this.dgCustomer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgCustomer_MouseDoubleClick);
            // 
            // selectDataGridViewCheckBoxColumn
            // 
            this.selectDataGridViewCheckBoxColumn.DataPropertyName = "Select";
            this.selectDataGridViewCheckBoxColumn.FillWeight = 54.26357F;
            this.selectDataGridViewCheckBoxColumn.HeaderText = "Select";
            this.selectDataGridViewCheckBoxColumn.Name = "selectDataGridViewCheckBoxColumn";
            // 
            // cusCodeDataGridViewTextBoxColumn
            // 
            this.cusCodeDataGridViewTextBoxColumn.DataPropertyName = "Cus_Code";
            this.cusCodeDataGridViewTextBoxColumn.FillWeight = 102.3009F;
            this.cusCodeDataGridViewTextBoxColumn.HeaderText = "Customer Code";
            this.cusCodeDataGridViewTextBoxColumn.Name = "cusCodeDataGridViewTextBoxColumn";
            this.cusCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cusNameDataGridViewTextBoxColumn
            // 
            this.cusNameDataGridViewTextBoxColumn.DataPropertyName = "Cus_Name";
            this.cusNameDataGridViewTextBoxColumn.FillWeight = 147.3199F;
            this.cusNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.cusNameDataGridViewTextBoxColumn.Name = "cusNameDataGridViewTextBoxColumn";
            this.cusNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.FillWeight = 139.771F;
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mobileDataGridViewTextBoxColumn
            // 
            this.mobileDataGridViewTextBoxColumn.DataPropertyName = "Mobile";
            this.mobileDataGridViewTextBoxColumn.FillWeight = 100.2638F;
            this.mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";
            this.mobileDataGridViewTextBoxColumn.Name = "mobileDataGridViewTextBoxColumn";
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            dataGridViewCellStyle14.NullValue = null;
            this.birthdayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.birthdayDataGridViewTextBoxColumn.FillWeight = 101.4417F;
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // successDataGridViewCheckBoxColumn
            // 
            this.successDataGridViewCheckBoxColumn.DataPropertyName = "Success";
            this.successDataGridViewCheckBoxColumn.FillWeight = 54.63912F;
            this.successDataGridViewCheckBoxColumn.HeaderText = "Success";
            this.successDataGridViewCheckBoxColumn.Name = "successDataGridViewCheckBoxColumn";
            this.successDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.data_Set;
            // 
            // data_Set
            // 
            this.data_Set.DataSetName = "Data_Set";
            this.data_Set.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSend);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 465);
            this.tabControl1.TabIndex = 3;
            // 
            // tabSend
            // 
            this.tabSend.BackColor = System.Drawing.Color.AliceBlue;
            this.tabSend.Controls.Add(this.cmbReligion);
            this.tabSend.Controls.Add(this.lblReligion);
            this.tabSend.Controls.Add(this.rdbReligion);
            this.tabSend.Controls.Add(this.lblCust);
            this.tabSend.Controls.Add(this.groupBox1);
            this.tabSend.Controls.Add(this.rbAnniversary);
            this.tabSend.Controls.Add(this.cmbCustGroup);
            this.tabSend.Controls.Add(this.lblCustGroup);
            this.tabSend.Controls.Add(this.cmbCustType);
            this.tabSend.Controls.Add(this.lblCustType);
            this.tabSend.Controls.Add(this.rbPurchValue);
            this.tabSend.Controls.Add(this.chkSpouseBDay);
            this.tabSend.Controls.Add(this.dtpCustRegDate);
            this.tabSend.Controls.Add(this.lblFrom);
            this.tabSend.Controls.Add(this.txtPointsTo);
            this.tabSend.Controls.Add(this.lblPointsTo);
            this.tabSend.Controls.Add(this.txtPointsFrom);
            this.tabSend.Controls.Add(this.rbPoints);
            this.tabSend.Controls.Add(this.chkChildBDays);
            this.tabSend.Controls.Add(this.label2);
            this.tabSend.Controls.Add(this.txtCOMPort);
            this.tabSend.Controls.Add(this.label1);
            this.tabSend.Controls.Add(this.lisTemplate);
            this.tabSend.Controls.Add(this.btnTextSave);
            this.tabSend.Controls.Add(this.btnCusSearch);
            this.tabSend.Controls.Add(this.txtCus_Name);
            this.tabSend.Controls.Add(this.raiIndividual);
            this.tabSend.Controls.Add(this.raiFestival);
            this.tabSend.Controls.Add(this.raiBirthDay);
            this.tabSend.Controls.Add(this.raiAll);
            this.tabSend.Controls.Add(this.lblMSGLength);
            this.tabSend.Controls.Add(this.btnWithName);
            this.tabSend.Controls.Add(this.btnDisplay);
            this.tabSend.Controls.Add(this.chkInactive);
            this.tabSend.Controls.Add(this.chkWithoutVen);
            this.tabSend.Controls.Add(this.dgCustomer);
            this.tabSend.Controls.Add(this.btnSend);
            this.tabSend.Controls.Add(this.richMessage);
            this.tabSend.Controls.Add(this.btnTemplate);
            this.tabSend.Controls.Add(this.lblBirthday);
            this.tabSend.Controls.Add(this.lblFestival);
            this.tabSend.Controls.Add(this.dtAnniversary);
            this.tabSend.Controls.Add(this.dtBirthDate);
            this.tabSend.Controls.Add(this.txtCus_Code);
            this.tabSend.Controls.Add(this.cmbFestival);
            this.tabSend.Controls.Add(this.lblPurchValue);
            this.tabSend.Controls.Add(this.chkCustRegDate);
            this.tabSend.Controls.Add(this.lblPointsFrom);
            this.tabSend.Location = new System.Drawing.Point(4, 22);
            this.tabSend.Name = "tabSend";
            this.tabSend.Padding = new System.Windows.Forms.Padding(3);
            this.tabSend.Size = new System.Drawing.Size(780, 439);
            this.tabSend.TabIndex = 0;
            this.tabSend.Text = "                            Send                            ";
            // 
            // lblCust
            // 
            this.lblCust.Location = new System.Drawing.Point(542, 365);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(229, 13);
            this.lblCust.TabIndex = 52;
            this.lblCust.Text = "Cust";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbVPN);
            this.groupBox1.Controls.Add(this.rdbDongel);
            this.groupBox1.Location = new System.Drawing.Point(546, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 37);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // rdbVPN
            // 
            this.rdbVPN.AutoSize = true;
            this.rdbVPN.Checked = true;
            this.rdbVPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbVPN.Location = new System.Drawing.Point(94, 13);
            this.rdbVPN.Name = "rdbVPN";
            this.rdbVPN.Size = new System.Drawing.Size(45, 17);
            this.rdbVPN.TabIndex = 1;
            this.rdbVPN.TabStop = true;
            this.rdbVPN.Text = "API";
            this.rdbVPN.UseVisualStyleBackColor = true;
            this.rdbVPN.CheckedChanged += new System.EventHandler(this.rdbVPN_CheckedChanged);
            // 
            // rdbDongel
            // 
            this.rdbDongel.AutoSize = true;
            this.rdbDongel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDongel.Location = new System.Drawing.Point(9, 13);
            this.rdbDongel.Name = "rdbDongel";
            this.rdbDongel.Size = new System.Drawing.Size(76, 17);
            this.rdbDongel.TabIndex = 0;
            this.rdbDongel.Text = "DONGEL";
            this.rdbDongel.UseVisualStyleBackColor = true;
            this.rdbDongel.CheckedChanged += new System.EventHandler(this.rdbDongel_CheckedChanged);
            // 
            // rbAnniversary
            // 
            this.rbAnniversary.AutoSize = true;
            this.rbAnniversary.Location = new System.Drawing.Point(452, 9);
            this.rbAnniversary.Name = "rbAnniversary";
            this.rbAnniversary.Size = new System.Drawing.Size(80, 17);
            this.rbAnniversary.TabIndex = 49;
            this.rbAnniversary.TabStop = true;
            this.rbAnniversary.Text = "Anniversary";
            this.rbAnniversary.UseVisualStyleBackColor = true;
            this.rbAnniversary.CheckedChanged += new System.EventHandler(this.rbAnniversary_CheckedChanged);
            // 
            // cmbCustGroup
            // 
            this.cmbCustGroup.FormattingEnabled = true;
            this.cmbCustGroup.Location = new System.Drawing.Point(541, 35);
            this.cmbCustGroup.Name = "cmbCustGroup";
            this.cmbCustGroup.Size = new System.Drawing.Size(121, 21);
            this.cmbCustGroup.TabIndex = 48;
            this.cmbCustGroup.Visible = false;
            this.cmbCustGroup.SelectedValueChanged += new System.EventHandler(this.cmbCustGroup_SelectedValueChanged);
            // 
            // lblCustGroup
            // 
            this.lblCustGroup.AutoSize = true;
            this.lblCustGroup.Location = new System.Drawing.Point(477, 39);
            this.lblCustGroup.Name = "lblCustGroup";
            this.lblCustGroup.Size = new System.Drawing.Size(60, 13);
            this.lblCustGroup.TabIndex = 47;
            this.lblCustGroup.Text = "Cust.Group";
            this.lblCustGroup.Visible = false;
            // 
            // cmbCustType
            // 
            this.cmbCustType.FormattingEnabled = true;
            this.cmbCustType.Location = new System.Drawing.Point(344, 35);
            this.cmbCustType.Name = "cmbCustType";
            this.cmbCustType.Size = new System.Drawing.Size(121, 21);
            this.cmbCustType.TabIndex = 46;
            this.cmbCustType.Visible = false;
            this.cmbCustType.SelectedValueChanged += new System.EventHandler(this.cmbCustType_SelectedValueChanged);
            // 
            // lblCustType
            // 
            this.lblCustType.AutoSize = true;
            this.lblCustType.Location = new System.Drawing.Point(287, 39);
            this.lblCustType.Name = "lblCustType";
            this.lblCustType.Size = new System.Drawing.Size(55, 13);
            this.lblCustType.TabIndex = 45;
            this.lblCustType.Text = "Cust.Type";
            this.lblCustType.Visible = false;
            // 
            // rbPurchValue
            // 
            this.rbPurchValue.AutoSize = true;
            this.rbPurchValue.Location = new System.Drawing.Point(345, 9);
            this.rbPurchValue.Name = "rbPurchValue";
            this.rbPurchValue.Size = new System.Drawing.Size(100, 17);
            this.rbPurchValue.TabIndex = 41;
            this.rbPurchValue.TabStop = true;
            this.rbPurchValue.Text = "Purchase Value";
            this.rbPurchValue.UseVisualStyleBackColor = true;
            this.rbPurchValue.CheckedChanged += new System.EventHandler(this.rbPurchValue_CheckedChanged);
            // 
            // chkSpouseBDay
            // 
            this.chkSpouseBDay.AutoSize = true;
            this.chkSpouseBDay.Location = new System.Drawing.Point(518, 38);
            this.chkSpouseBDay.Name = "chkSpouseBDay";
            this.chkSpouseBDay.Size = new System.Drawing.Size(110, 17);
            this.chkSpouseBDay.TabIndex = 40;
            this.chkSpouseBDay.Text = "Spouse BirthDays";
            this.chkSpouseBDay.UseVisualStyleBackColor = true;
            this.chkSpouseBDay.Visible = false;
            this.chkSpouseBDay.CheckedChanged += new System.EventHandler(this.chkSpouseBDay_CheckedChanged);
            // 
            // dtpCustRegDate
            // 
            this.dtpCustRegDate.Enabled = false;
            this.dtpCustRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCustRegDate.Location = new System.Drawing.Point(169, 38);
            this.dtpCustRegDate.Name = "dtpCustRegDate";
            this.dtpCustRegDate.Size = new System.Drawing.Size(95, 20);
            this.dtpCustRegDate.TabIndex = 39;
            this.dtpCustRegDate.Visible = false;
            this.dtpCustRegDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpCustRegDate_KeyDown);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(203, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 37;
            this.lblFrom.Text = "From";
            this.lblFrom.Visible = false;
            // 
            // txtPointsTo
            // 
            this.txtPointsTo.Location = new System.Drawing.Point(362, 38);
            this.txtPointsTo.Name = "txtPointsTo";
            this.txtPointsTo.Size = new System.Drawing.Size(95, 20);
            this.txtPointsTo.TabIndex = 36;
            this.txtPointsTo.Visible = false;
            this.txtPointsTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPointsTo_KeyDown);
            // 
            // lblPointsTo
            // 
            this.lblPointsTo.AutoSize = true;
            this.lblPointsTo.Location = new System.Drawing.Point(339, 42);
            this.lblPointsTo.Name = "lblPointsTo";
            this.lblPointsTo.Size = new System.Drawing.Size(20, 13);
            this.lblPointsTo.TabIndex = 35;
            this.lblPointsTo.Text = "To";
            this.lblPointsTo.Visible = false;
            // 
            // txtPointsFrom
            // 
            this.txtPointsFrom.Location = new System.Drawing.Point(235, 38);
            this.txtPointsFrom.Name = "txtPointsFrom";
            this.txtPointsFrom.Size = new System.Drawing.Size(100, 20);
            this.txtPointsFrom.TabIndex = 34;
            this.txtPointsFrom.Visible = false;
            this.txtPointsFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPointsFrom_KeyDown);
            // 
            // rbPoints
            // 
            this.rbPoints.AutoSize = true;
            this.rbPoints.Location = new System.Drawing.Point(281, 9);
            this.rbPoints.Name = "rbPoints";
            this.rbPoints.Size = new System.Drawing.Size(54, 17);
            this.rbPoints.TabIndex = 32;
            this.rbPoints.TabStop = true;
            this.rbPoints.Text = "Points";
            this.rbPoints.UseVisualStyleBackColor = true;
            this.rbPoints.CheckedChanged += new System.EventHandler(this.rbPoints_CheckedChanged);
            // 
            // chkChildBDays
            // 
            this.chkChildBDays.AutoSize = true;
            this.chkChildBDays.Location = new System.Drawing.Point(636, 38);
            this.chkChildBDays.Name = "chkChildBDays";
            this.chkChildBDays.Size = new System.Drawing.Size(112, 17);
            this.chkChildBDays.TabIndex = 31;
            this.chkChildBDays.Text = "Children BirthDays";
            this.chkChildBDays.UseVisualStyleBackColor = true;
            this.chkChildBDays.Visible = false;
            this.chkChildBDays.CheckedChanged += new System.EventHandler(this.chkChildBDays_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "COM PORT";
            // 
            // txtCOMPort
            // 
            this.txtCOMPort.Location = new System.Drawing.Point(687, 330);
            this.txtCOMPort.Name = "txtCOMPort";
            this.txtCOMPort.Size = new System.Drawing.Size(85, 20);
            this.txtCOMPort.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(338, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Templates";
            // 
            // lisTemplate
            // 
            this.lisTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lisTemplate.FormattingEnabled = true;
            this.lisTemplate.Location = new System.Drawing.Point(338, 340);
            this.lisTemplate.Name = "lisTemplate";
            this.lisTemplate.Size = new System.Drawing.Size(193, 95);
            this.lisTemplate.TabIndex = 26;
            this.lisTemplate.SelectedIndexChanged += new System.EventHandler(this.lisTemplate_SelectedIndexChanged);
            // 
            // btnTextSave
            // 
            this.btnTextSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTextSave.Location = new System.Drawing.Point(218, 381);
            this.btnTextSave.Name = "btnTextSave";
            this.btnTextSave.Size = new System.Drawing.Size(111, 23);
            this.btnTextSave.TabIndex = 25;
            this.btnTextSave.Text = "Saved Templates ->";
            this.btnTextSave.UseVisualStyleBackColor = true;
            this.btnTextSave.Click += new System.EventHandler(this.btnTextSave_Click);
            // 
            // btnCusSearch
            // 
         //   this.btnCusSearch.BackgroundImage = global::Inventory.Properties.Resources.Search;
            this.btnCusSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCusSearch.Location = new System.Drawing.Point(492, 38);
            this.btnCusSearch.Name = "btnCusSearch";
            this.btnCusSearch.Size = new System.Drawing.Size(23, 21);
            this.btnCusSearch.TabIndex = 24;
            this.btnCusSearch.UseVisualStyleBackColor = true;
            this.btnCusSearch.Visible = false;
            this.btnCusSearch.Click += new System.EventHandler(this.btnCusSearch_Click);
            // 
            // txtCus_Name
            // 
            this.txtCus_Name.Location = new System.Drawing.Point(179, 39);
            this.txtCus_Name.Name = "txtCus_Name";
            this.txtCus_Name.Size = new System.Drawing.Size(310, 20);
            this.txtCus_Name.TabIndex = 23;
            this.txtCus_Name.Visible = false;
            // 
            // raiIndividual
            // 
            this.raiIndividual.AutoSize = true;
            this.raiIndividual.Location = new System.Drawing.Point(58, 9);
            this.raiIndividual.Name = "raiIndividual";
            this.raiIndividual.Size = new System.Drawing.Size(70, 17);
            this.raiIndividual.TabIndex = 21;
            this.raiIndividual.TabStop = true;
            this.raiIndividual.Text = "Individual";
            this.raiIndividual.UseVisualStyleBackColor = true;
            this.raiIndividual.CheckedChanged += new System.EventHandler(this.raiIndividual_CheckedChanged);
            // 
            // raiFestival
            // 
            this.raiFestival.AutoSize = true;
            this.raiFestival.Location = new System.Drawing.Point(209, 9);
            this.raiFestival.Name = "raiFestival";
            this.raiFestival.Size = new System.Drawing.Size(61, 17);
            this.raiFestival.TabIndex = 18;
            this.raiFestival.TabStop = true;
            this.raiFestival.Text = "Festival";
            this.raiFestival.UseVisualStyleBackColor = true;
            this.raiFestival.CheckedChanged += new System.EventHandler(this.raiFestival_CheckedChanged);
            // 
            // raiBirthDay
            // 
            this.raiBirthDay.AutoSize = true;
            this.raiBirthDay.Location = new System.Drawing.Point(138, 9);
            this.raiBirthDay.Name = "raiBirthDay";
            this.raiBirthDay.Size = new System.Drawing.Size(63, 17);
            this.raiBirthDay.TabIndex = 17;
            this.raiBirthDay.TabStop = true;
            this.raiBirthDay.Text = "Birthday";
            this.raiBirthDay.UseVisualStyleBackColor = true;
            this.raiBirthDay.CheckedChanged += new System.EventHandler(this.raiBirthDay_CheckedChanged);
            // 
            // raiAll
            // 
            this.raiAll.AutoSize = true;
            this.raiAll.Location = new System.Drawing.Point(12, 9);
            this.raiAll.Name = "raiAll";
            this.raiAll.Size = new System.Drawing.Size(36, 17);
            this.raiAll.TabIndex = 16;
            this.raiAll.TabStop = true;
            this.raiAll.Text = "All";
            this.raiAll.UseVisualStyleBackColor = true;
            this.raiAll.CheckedChanged += new System.EventHandler(this.raiAll_CheckedChanged);
            // 
            // lblMSGLength
            // 
            this.lblMSGLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMSGLength.AutoSize = true;
            this.lblMSGLength.Location = new System.Drawing.Point(191, 418);
            this.lblMSGLength.Name = "lblMSGLength";
            this.lblMSGLength.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMSGLength.Size = new System.Drawing.Size(25, 13);
            this.lblMSGLength.TabIndex = 15;
            this.lblMSGLength.Text = "160";
            // 
            // btnWithName
            // 
            this.btnWithName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWithName.Location = new System.Drawing.Point(218, 323);
            this.btnWithName.Name = "btnWithName";
            this.btnWithName.Size = new System.Drawing.Size(111, 23);
            this.btnWithName.TabIndex = 14;
            this.btnWithName.Text = "With name";
            this.btnWithName.UseVisualStyleBackColor = true;
            this.btnWithName.Click += new System.EventHandler(this.btnWithName_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(675, 9);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 22);
            this.btnDisplay.TabIndex = 6;
            this.btnDisplay.Text = "&Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Visible = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Location = new System.Drawing.Point(535, 41);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(64, 17);
            this.chkInactive.TabIndex = 13;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            this.chkInactive.Visible = false;
            // 
            // chkWithoutVen
            // 
            this.chkWithoutVen.AutoSize = true;
            this.chkWithoutVen.Checked = true;
            this.chkWithoutVen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithoutVen.Location = new System.Drawing.Point(636, 41);
            this.chkWithoutVen.Name = "chkWithoutVen";
            this.chkWithoutVen.Size = new System.Drawing.Size(114, 17);
            this.chkWithoutVen.TabIndex = 11;
            this.chkWithoutVen.Text = "Without Venerable";
            this.chkWithoutVen.UseVisualStyleBackColor = true;
            this.chkWithoutVen.Visible = false;
            // 
            // btnTemplate
            // 
            this.btnTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTemplate.Location = new System.Drawing.Point(401, 365);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(88, 23);
            this.btnTemplate.TabIndex = 28;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(7, 41);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(54, 13);
            this.lblBirthday.TabIndex = 10;
            this.lblBirthday.Text = "Birth Date";
            this.lblBirthday.Visible = false;
            // 
            // lblFestival
            // 
            this.lblFestival.AutoSize = true;
            this.lblFestival.Location = new System.Drawing.Point(7, 41);
            this.lblFestival.Name = "lblFestival";
            this.lblFestival.Size = new System.Drawing.Size(43, 13);
            this.lblFestival.TabIndex = 19;
            this.lblFestival.Text = "Festival";
            this.lblFestival.Visible = false;
            // 
            // dtAnniversary
            // 
            this.dtAnniversary.CustomFormat = "dd/MM/.......";
            this.dtAnniversary.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAnniversary.Location = new System.Drawing.Point(70, 36);
            this.dtAnniversary.Name = "dtAnniversary";
            this.dtAnniversary.Size = new System.Drawing.Size(96, 20);
            this.dtAnniversary.TabIndex = 50;
            this.dtAnniversary.Visible = false;
            this.dtAnniversary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtAnniversary_KeyDown);
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.CustomFormat = "dd/MM/.......";
            this.dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBirthDate.Location = new System.Drawing.Point(78, 39);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(96, 20);
            this.dtBirthDate.TabIndex = 7;
            this.dtBirthDate.Visible = false;
            this.dtBirthDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtBirthDate_KeyDown);
            // 
            // txtCus_Code
            // 
            this.txtCus_Code.Location = new System.Drawing.Point(67, 39);
            this.txtCus_Code.Name = "txtCus_Code";
            this.txtCus_Code.Size = new System.Drawing.Size(113, 20);
            this.txtCus_Code.TabIndex = 22;
            this.txtCus_Code.Visible = false;
            this.txtCus_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCus_Code_KeyDown);
            // 
            // cmbFestival
            // 
            this.cmbFestival.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFestival.FormattingEnabled = true;
            this.cmbFestival.Location = new System.Drawing.Point(67, 38);
            this.cmbFestival.Name = "cmbFestival";
            this.cmbFestival.Size = new System.Drawing.Size(121, 21);
            this.cmbFestival.TabIndex = 20;
            this.cmbFestival.Visible = false;
            // 
            // lblPurchValue
            // 
            this.lblPurchValue.AutoSize = true;
            this.lblPurchValue.Location = new System.Drawing.Point(110, 41);
            this.lblPurchValue.Name = "lblPurchValue";
            this.lblPurchValue.Size = new System.Drawing.Size(82, 13);
            this.lblPurchValue.TabIndex = 44;
            this.lblPurchValue.Text = "Purchase Value";
            this.lblPurchValue.Visible = false;
            // 
            // chkCustRegDate
            // 
            this.chkCustRegDate.AutoSize = true;
            this.chkCustRegDate.Location = new System.Drawing.Point(20, 38);
            this.chkCustRegDate.Name = "chkCustRegDate";
            this.chkCustRegDate.Size = new System.Drawing.Size(150, 17);
            this.chkCustRegDate.TabIndex = 38;
            this.chkCustRegDate.Text = "Customers Registered on :";
            this.chkCustRegDate.UseVisualStyleBackColor = true;
            this.chkCustRegDate.Visible = false;
            this.chkCustRegDate.CheckedChanged += new System.EventHandler(this.chkCustRegDate_CheckedChanged);
            // 
            // lblPointsFrom
            // 
            this.lblPointsFrom.AutoSize = true;
            this.lblPointsFrom.Location = new System.Drawing.Point(107, 42);
            this.lblPointsFrom.Name = "lblPointsFrom";
            this.lblPointsFrom.Size = new System.Drawing.Size(76, 13);
            this.lblPointsFrom.TabIndex = 33;
            this.lblPointsFrom.Text = "Monthly Points";
            this.lblPointsFrom.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SMS";
            this.notifyIcon1.Visible = true;
            // 
            // rdbReligion
            // 
            this.rdbReligion.AutoSize = true;
            this.rdbReligion.Location = new System.Drawing.Point(546, 9);
            this.rdbReligion.Name = "rdbReligion";
            this.rdbReligion.Size = new System.Drawing.Size(63, 17);
            this.rdbReligion.TabIndex = 53;
            this.rdbReligion.TabStop = true;
            this.rdbReligion.Text = "Religion";
            this.rdbReligion.UseVisualStyleBackColor = true;
            this.rdbReligion.CheckedChanged += new System.EventHandler(this.rdbReligion_CheckedChanged);
            // 
            // lblReligion
            // 
            this.lblReligion.AutoSize = true;
            this.lblReligion.Location = new System.Drawing.Point(487, 39);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(45, 13);
            this.lblReligion.TabIndex = 54;
            this.lblReligion.Text = "Religion";
            this.lblReligion.Visible = false;
            // 
            // cmbReligion
            // 
            this.cmbReligion.FormattingEnabled = true;
            this.cmbReligion.Location = new System.Drawing.Point(541, 34);
            this.cmbReligion.Name = "cmbReligion";
            this.cmbReligion.Size = new System.Drawing.Size(121, 21);
            this.cmbReligion.TabIndex = 55;
            this.cmbReligion.Visible = false;
            this.cmbReligion.SelectedValueChanged += new System.EventHandler(this.cmbReligion_SelectedValueChanged);
            // 
            // frmSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSMS_FormClosing);
            this.Load += new System.EventHandler(this.frmSMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Set)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSend.ResumeLayout(false);
            this.tabSend.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox richMessage;
        private System.Windows.Forms.DataGridView dgCustomer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSend;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private dtForGrids data_Set;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.CheckBox chkWithoutVen;
        private System.Windows.Forms.Button btnWithName;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblMSGLength;
        private System.Windows.Forms.RadioButton raiAll;
        private System.Windows.Forms.RadioButton raiBirthDay;
        private System.Windows.Forms.RadioButton raiFestival;
        private System.Windows.Forms.RadioButton raiIndividual;
        private System.Windows.Forms.ComboBox cmbFestival;
        private System.Windows.Forms.Label lblFestival;
        private System.Windows.Forms.TextBox txtCus_Name;
        private System.Windows.Forms.TextBox txtCus_Code;
        private System.Windows.Forms.Button btnCusSearch;
        private System.Windows.Forms.Button btnTextSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lisTemplate;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCOMPort;
        private System.Windows.Forms.CheckBox chkChildBDays;
        private System.Windows.Forms.TextBox txtPointsTo;
        private System.Windows.Forms.Label lblPointsTo;
        private System.Windows.Forms.TextBox txtPointsFrom;
        private System.Windows.Forms.Label lblPointsFrom;
        private System.Windows.Forms.RadioButton rbPoints;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn successDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DateTimePicker dtpCustRegDate;
        private System.Windows.Forms.CheckBox chkCustRegDate;
        private System.Windows.Forms.CheckBox chkSpouseBDay;
        private System.Windows.Forms.RadioButton rbPurchValue;
        private System.Windows.Forms.Label lblPurchValue;
        private System.Windows.Forms.ComboBox cmbCustGroup;
        private System.Windows.Forms.Label lblCustGroup;
        private System.Windows.Forms.ComboBox cmbCustType;
        private System.Windows.Forms.Label lblCustType;
        private System.Windows.Forms.RadioButton rbAnniversary;
        private System.Windows.Forms.DateTimePicker dtAnniversary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDongel;
        private System.Windows.Forms.RadioButton rdbVPN;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.RadioButton rdbReligion;
        private System.Windows.Forms.ComboBox cmbReligion;
        private System.Windows.Forms.Label lblReligion;
    }
}