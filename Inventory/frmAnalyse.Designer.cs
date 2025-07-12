namespace Inventory
{
    partial class frmAnalyse
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpSecondDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpSecondDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblSecondDateTo = new System.Windows.Forms.Label();
            this.lblSecondDateFrom = new System.Windows.Forms.Label();
            this.lblFirstDateTo = new System.Windows.Forms.Label();
            this.lblFirstDateFrom = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.radioButtonSupplier = new System.Windows.Forms.RadioButton();
            this.radioButtonCategory = new System.Windows.Forms.RadioButton();
            this.radioButtonDepartment = new System.Windows.Forms.RadioButton();
            this.radioButtonProduct = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCollection = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSelected = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSelectCode = new System.Windows.Forms.Button();
            this.btnSelectAllCode = new System.Windows.Forms.Button();
            this.btnRemoveCode = new System.Windows.Forms.Button();
            this.btnRemoveAllCode = new System.Windows.Forms.Button();
            this.selectedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectedBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBindingSource2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpSecondDateTo);
            this.groupBox1.Controls.Add(this.dtpSecondDateFrom);
            this.groupBox1.Controls.Add(this.lblSecondDateTo);
            this.groupBox1.Controls.Add(this.lblSecondDateFrom);
            this.groupBox1.Controls.Add(this.lblFirstDateTo);
            this.groupBox1.Controls.Add(this.lblFirstDateFrom);
            this.groupBox1.Controls.Add(this.dtDateTo);
            this.groupBox1.Controls.Add(this.dtDateFrom);
            this.groupBox1.Controls.Add(this.radioButtonSupplier);
            this.groupBox1.Controls.Add(this.radioButtonCategory);
            this.groupBox1.Controls.Add(this.radioButtonDepartment);
            this.groupBox1.Controls.Add(this.radioButtonProduct);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpSecondDateTo
            // 
            this.dtpSecondDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpSecondDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSecondDateTo.Location = new System.Drawing.Point(774, 38);
            this.dtpSecondDateTo.Name = "dtpSecondDateTo";
            this.dtpSecondDateTo.Size = new System.Drawing.Size(97, 20);
            this.dtpSecondDateTo.TabIndex = 7;
            this.dtpSecondDateTo.Visible = false;
            // 
            // dtpSecondDateFrom
            // 
            this.dtpSecondDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpSecondDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSecondDateFrom.Location = new System.Drawing.Point(542, 38);
            this.dtpSecondDateFrom.Name = "dtpSecondDateFrom";
            this.dtpSecondDateFrom.Size = new System.Drawing.Size(94, 20);
            this.dtpSecondDateFrom.TabIndex = 6;
            this.dtpSecondDateFrom.Visible = false;
            // 
            // lblSecondDateTo
            // 
            this.lblSecondDateTo.AutoSize = true;
            this.lblSecondDateTo.Location = new System.Drawing.Point(650, 41);
            this.lblSecondDateTo.Name = "lblSecondDateTo";
            this.lblSecondDateTo.Size = new System.Drawing.Size(86, 13);
            this.lblSecondDateTo.TabIndex = 9;
            this.lblSecondDateTo.Text = "Second Date To";
            this.lblSecondDateTo.Visible = false;
            // 
            // lblSecondDateFrom
            // 
            this.lblSecondDateFrom.AutoSize = true;
            this.lblSecondDateFrom.Location = new System.Drawing.Point(441, 41);
            this.lblSecondDateFrom.Name = "lblSecondDateFrom";
            this.lblSecondDateFrom.Size = new System.Drawing.Size(96, 13);
            this.lblSecondDateFrom.TabIndex = 8;
            this.lblSecondDateFrom.Text = "Second Date From";
            this.lblSecondDateFrom.Visible = false;
            // 
            // lblFirstDateTo
            // 
            this.lblFirstDateTo.AutoSize = true;
            this.lblFirstDateTo.Location = new System.Drawing.Point(650, 18);
            this.lblFirstDateTo.Name = "lblFirstDateTo";
            this.lblFirstDateTo.Size = new System.Drawing.Size(46, 13);
            this.lblFirstDateTo.TabIndex = 7;
            this.lblFirstDateTo.Text = "Date To";
            // 
            // lblFirstDateFrom
            // 
            this.lblFirstDateFrom.AutoSize = true;
            this.lblFirstDateFrom.Location = new System.Drawing.Point(443, 17);
            this.lblFirstDateFrom.Name = "lblFirstDateFrom";
            this.lblFirstDateFrom.Size = new System.Drawing.Size(56, 13);
            this.lblFirstDateFrom.TabIndex = 6;
            this.lblFirstDateFrom.Text = "Date From";
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(774, 13);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(98, 20);
            this.dtDateTo.TabIndex = 5;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(542, 13);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(95, 20);
            this.dtDateFrom.TabIndex = 4;
            // 
            // radioButtonSupplier
            // 
            this.radioButtonSupplier.AutoSize = true;
            this.radioButtonSupplier.Location = new System.Drawing.Point(367, 16);
            this.radioButtonSupplier.Name = "radioButtonSupplier";
            this.radioButtonSupplier.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSupplier.TabIndex = 3;
            this.radioButtonSupplier.Text = "Supplier";
            this.radioButtonSupplier.UseVisualStyleBackColor = true;
            this.radioButtonSupplier.CheckedChanged += new System.EventHandler(this.radioButtonSupplier_CheckedChanged);
            // 
            // radioButtonCategory
            // 
            this.radioButtonCategory.AutoSize = true;
            this.radioButtonCategory.Location = new System.Drawing.Point(264, 16);
            this.radioButtonCategory.Name = "radioButtonCategory";
            this.radioButtonCategory.Size = new System.Drawing.Size(67, 17);
            this.radioButtonCategory.TabIndex = 2;
            this.radioButtonCategory.Text = "Category";
            this.radioButtonCategory.UseVisualStyleBackColor = true;
            this.radioButtonCategory.CheckedChanged += new System.EventHandler(this.radioButtonCategory_CheckedChanged);
            // 
            // radioButtonDepartment
            // 
            this.radioButtonDepartment.AutoSize = true;
            this.radioButtonDepartment.Location = new System.Drawing.Point(147, 16);
            this.radioButtonDepartment.Name = "radioButtonDepartment";
            this.radioButtonDepartment.Size = new System.Drawing.Size(80, 17);
            this.radioButtonDepartment.TabIndex = 1;
            this.radioButtonDepartment.Text = "Department";
            this.radioButtonDepartment.UseVisualStyleBackColor = true;
            this.radioButtonDepartment.CheckedChanged += new System.EventHandler(this.radioButtonDepartment_CheckedChanged);
            // 
            // radioButtonProduct
            // 
            this.radioButtonProduct.AutoSize = true;
            this.radioButtonProduct.Checked = true;
            this.radioButtonProduct.Location = new System.Drawing.Point(28, 16);
            this.radioButtonProduct.Name = "radioButtonProduct";
            this.radioButtonProduct.Size = new System.Drawing.Size(62, 17);
            this.radioButtonProduct.TabIndex = 0;
            this.radioButtonProduct.TabStop = true;
            this.radioButtonProduct.Text = "Product";
            this.radioButtonProduct.UseVisualStyleBackColor = true;
            this.radioButtonProduct.CheckedChanged += new System.EventHandler(this.radioButtonProduct_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewCollection);
            this.groupBox2.Location = new System.Drawing.Point(5, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 296);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Collection";
            // 
            // dataGridViewCollection
            // 
            this.dataGridViewCollection.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewCollection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCollection.AutoGenerateColumns = false;
            this.dataGridViewCollection.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewCollection.DataSource = this.collectionBindingSource;
            this.dataGridViewCollection.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewCollection.Name = "dataGridViewCollection";
            this.dataGridViewCollection.ReadOnly = true;
            this.dataGridViewCollection.Size = new System.Drawing.Size(421, 273);
            this.dataGridViewCollection.TabIndex = 0;
            this.dataGridViewCollection.DoubleClick += new System.EventHandler(this.dataGridViewCollection_DoubleClick);
            this.dataGridViewCollection.Click += new System.EventHandler(this.dataGridViewCollection_Click);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 270;
            // 
            // collectionBindingSource
            // 
            this.collectionBindingSource.DataMember = "Collection";
            this.collectionBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewSelected);
            this.groupBox3.Location = new System.Drawing.Point(470, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 296);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected";
            // 
            // dataGridViewSelected
            // 
            this.dataGridViewSelected.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSelected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSelected.AutoGenerateColumns = false;
            this.dataGridViewSelected.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1});
            this.dataGridViewSelected.DataSource = this.selectedBindingSource2;
            this.dataGridViewSelected.Location = new System.Drawing.Point(6, 17);
            this.dataGridViewSelected.Name = "dataGridViewSelected";
            this.dataGridViewSelected.ReadOnly = true;
            this.dataGridViewSelected.Size = new System.Drawing.Size(407, 272);
            this.dataGridViewSelected.TabIndex = 0;
            this.dataGridViewSelected.DoubleClick += new System.EventHandler(this.dataGridViewSelected_DoubleClick);
            this.dataGridViewSelected.Click += new System.EventHandler(this.dataGridViewSelected_Click);
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.Width = 260;
            // 
            // selectedBindingSource2
            // 
            this.selectedBindingSource2.DataMember = "Selected";
            this.selectedBindingSource2.DataSource = this.dsForReports;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDisplay);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Location = new System.Drawing.Point(5, 367);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(882, 78);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(633, 18);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 50);
            this.btnDisplay.TabIndex = 12;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(761, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(3, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 65);
            this.toolStrip1.TabIndex = 142;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSelectCode
            // 
            this.btnSelectCode.Enabled = false;
            this.btnSelectCode.Location = new System.Drawing.Point(435, 135);
            this.btnSelectCode.Name = "btnSelectCode";
            this.btnSelectCode.Size = new System.Drawing.Size(35, 25);
            this.btnSelectCode.TabIndex = 8;
            this.btnSelectCode.Text = ">";
            this.btnSelectCode.UseVisualStyleBackColor = true;
            this.btnSelectCode.Click += new System.EventHandler(this.btnSelectCode_Click);
            // 
            // btnSelectAllCode
            // 
            this.btnSelectAllCode.Enabled = false;
            this.btnSelectAllCode.Location = new System.Drawing.Point(435, 169);
            this.btnSelectAllCode.Name = "btnSelectAllCode";
            this.btnSelectAllCode.Size = new System.Drawing.Size(34, 25);
            this.btnSelectAllCode.TabIndex = 9;
            this.btnSelectAllCode.Text = ">>";
            this.btnSelectAllCode.UseVisualStyleBackColor = true;
            this.btnSelectAllCode.Click += new System.EventHandler(this.btnSelectAllCode_Click);
            // 
            // btnRemoveCode
            // 
            this.btnRemoveCode.Enabled = false;
            this.btnRemoveCode.Location = new System.Drawing.Point(435, 285);
            this.btnRemoveCode.Name = "btnRemoveCode";
            this.btnRemoveCode.Size = new System.Drawing.Size(33, 24);
            this.btnRemoveCode.TabIndex = 10;
            this.btnRemoveCode.Text = "<";
            this.btnRemoveCode.UseVisualStyleBackColor = true;
            this.btnRemoveCode.Click += new System.EventHandler(this.btnRemoveCode_Click);
            // 
            // btnRemoveAllCode
            // 
            this.btnRemoveAllCode.Enabled = false;
            this.btnRemoveAllCode.Location = new System.Drawing.Point(435, 315);
            this.btnRemoveAllCode.Name = "btnRemoveAllCode";
            this.btnRemoveAllCode.Size = new System.Drawing.Size(34, 24);
            this.btnRemoveAllCode.TabIndex = 11;
            this.btnRemoveAllCode.Text = "<<";
            this.btnRemoveAllCode.UseVisualStyleBackColor = true;
            this.btnRemoveAllCode.Click += new System.EventHandler(this.btnRemoveAllCode_Click);
            // 
            // selectedBindingSource
            // 
            this.selectedBindingSource.DataMember = "Selected";
            this.selectedBindingSource.DataSource = this.dsForReports;
            // 
            // selectedBindingSource1
            // 
            this.selectedBindingSource1.DataMember = "Selected";
            this.selectedBindingSource1.DataSource = this.dsForReports;
            // 
            // frmAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(891, 446);
            this.Controls.Add(this.btnRemoveAllCode);
            this.Controls.Add(this.btnRemoveCode);
            this.Controls.Add(this.btnSelectAllCode);
            this.Controls.Add(this.btnSelectCode);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnalyse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analyse";
            this.Load += new System.EventHandler(this.frmAnalyse_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAnalyse_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAnalyse_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBindingSource2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSupplier;
        private System.Windows.Forms.RadioButton radioButtonCategory;
        private System.Windows.Forms.RadioButton radioButtonDepartment;
        private System.Windows.Forms.RadioButton radioButtonProduct;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridViewCollection;
        private System.Windows.Forms.BindingSource collectionBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.BindingSource selectedBindingSource;
        private System.Windows.Forms.Button btnSelectCode;
        private System.Windows.Forms.Button btnSelectAllCode;
        private System.Windows.Forms.Button btnRemoveCode;
        private System.Windows.Forms.Button btnRemoveAllCode;
        private System.Windows.Forms.BindingSource selectedBindingSource1;
        private System.Windows.Forms.DataGridView dataGridViewSelected;
        private System.Windows.Forms.BindingSource selectedBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblFirstDateTo;
        private System.Windows.Forms.Label lblFirstDateFrom;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.DateTimePicker dtpSecondDateTo;
        private System.Windows.Forms.DateTimePicker dtpSecondDateFrom;
        private System.Windows.Forms.Label lblSecondDateTo;
        private System.Windows.Forms.Label lblSecondDateFrom;
    }
}