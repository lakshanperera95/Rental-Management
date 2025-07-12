namespace Inventory
{
    partial class frmChildrenDetails
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
            this.label5 = new System.Windows.Forms.Label();
            this.dgChildren = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsChildrenDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data_Set = new Inventory.dtForGrids();
            this.cmbChildSex = new System.Windows.Forms.ComboBox();
            this.dtpChildBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtChildName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustCode = new System.Windows.Forms.Label();
            this.lblCustName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsChildrenDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Set)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Name";
            // 
            // dgChildren
            // 
            this.dgChildren.AllowUserToAddRows = false;
            this.dgChildren.AllowUserToResizeRows = false;
            this.dgChildren.AutoGenerateColumns = false;
            this.dgChildren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgChildren.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgChildren.ColumnHeadersHeight = 18;
            this.dgChildren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.sexDataGridViewTextBoxColumn,
            this.birthdayDataGridViewTextBoxColumn});
            this.dgChildren.DataSource = this.dsChildrenDetailsBindingSource;
            this.dgChildren.EnableHeadersVisualStyles = false;
            this.dgChildren.Location = new System.Drawing.Point(29, 80);
            this.dgChildren.Name = "dgChildren";
            this.dgChildren.ReadOnly = true;
            this.dgChildren.RowHeadersWidth = 20;
            this.dgChildren.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgChildren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChildren.Size = new System.Drawing.Size(528, 90);
            this.dgChildren.TabIndex = 56;
            this.dgChildren.DoubleClick += new System.EventHandler(this.dgChildren_DoubleClick);
            this.dgChildren.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgChildren_UserDeletedRow);
            this.dgChildren.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgChildren_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 139.2111F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "Sex";
            this.sexDataGridViewTextBoxColumn.FillWeight = 70.87594F;
            this.sexDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            this.sexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.FillWeight = 89.91292F;
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsChildrenDetailsBindingSource
            // 
            this.dsChildrenDetailsBindingSource.DataMember = "dsChildrenDetails";
            this.dsChildrenDetailsBindingSource.DataSource = this.data_Set;
            // 
            // data_Set
            // 
            this.data_Set.DataSetName = "Data_Set";
            this.data_Set.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbChildSex
            // 
            this.cmbChildSex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbChildSex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChildSex.BackColor = System.Drawing.SystemColors.Window;
            this.cmbChildSex.FormattingEnabled = true;
            this.cmbChildSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbChildSex.Location = new System.Drawing.Point(288, 54);
            this.cmbChildSex.Name = "cmbChildSex";
            this.cmbChildSex.Size = new System.Drawing.Size(117, 21);
            this.cmbChildSex.TabIndex = 54;
            this.cmbChildSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbChildSex_KeyDown);
            // 
            // dtpChildBirthday
            // 
            this.dtpChildBirthday.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.dtpChildBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChildBirthday.Location = new System.Drawing.Point(408, 54);
            this.dtpChildBirthday.Name = "dtpChildBirthday";
            this.dtpChildBirthday.Size = new System.Drawing.Size(149, 21);
            this.dtpChildBirthday.TabIndex = 55;
            this.dtpChildBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpChildBirthday_KeyDown);
            // 
            // txtChildName
            // 
            this.txtChildName.BackColor = System.Drawing.SystemColors.Window;
            this.txtChildName.Location = new System.Drawing.Point(73, 54);
            this.txtChildName.Name = "txtChildName";
            this.txtChildName.Size = new System.Drawing.Size(213, 21);
            this.txtChildName.TabIndex = 53;
            this.txtChildName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChildName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Customer";
            // 
            // lblCustCode
            // 
            this.lblCustCode.Location = new System.Drawing.Point(100, 23);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(83, 14);
            this.lblCustCode.TabIndex = 58;
            // 
            // lblCustName
            // 
            this.lblCustName.Location = new System.Drawing.Point(205, 23);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(321, 14);
            this.lblCustName.TabIndex = 59;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(408, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 38);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(408, 182);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 38);
            this.btnExit.TabIndex = 61;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 235);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // frmChildrenDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(584, 240);
            this.Controls.Add(this.txtChildName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.lblCustCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgChildren);
            this.Controls.Add(this.cmbChildSex);
            this.Controls.Add(this.dtpChildBirthday);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChildrenDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Children Details";
            this.Load += new System.EventHandler(this.frmChildrenDetails_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChildrenDetails_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChildrenDetails_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsChildrenDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Set)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgChildren;
        private System.Windows.Forms.ComboBox cmbChildSex;
        private System.Windows.Forms.DateTimePicker dtpChildBirthday;
        private System.Windows.Forms.TextBox txtChildName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dsChildrenDetailsBindingSource;
        private dtForGrids data_Set;
        public System.Windows.Forms.Label lblCustCode;
        public System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
    }
}