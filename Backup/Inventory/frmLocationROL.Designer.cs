namespace Inventory
{
    partial class frmLocationROL
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dataGridViewLocationROL = new System.Windows.Forms.DataGridView();
            this.locaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loca_Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsProdROLBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.txtROL = new System.Windows.Forms.TextBox();
            this.txtReOrderQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProdCode = new System.Windows.Forms.Label();
            this.lblProdName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dsProdROLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocationROL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdROLBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdROLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 216);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(612, 65);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dataGridViewLocationROL
            // 
            this.dataGridViewLocationROL.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewLocationROL.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLocationROL.AutoGenerateColumns = false;
            this.dataGridViewLocationROL.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewLocationROL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocationROL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.locaDataGridViewTextBoxColumn,
            this.Loca_Descrip,
            this.rOLDataGridViewTextBoxColumn,
            this.rOQtyDataGridViewTextBoxColumn,
            this.Qty});
            this.dataGridViewLocationROL.DataSource = this.dsProdROLBindingSource1;
            this.dataGridViewLocationROL.Location = new System.Drawing.Point(5, 29);
            this.dataGridViewLocationROL.Name = "dataGridViewLocationROL";
            this.dataGridViewLocationROL.ReadOnly = true;
            this.dataGridViewLocationROL.RowHeadersVisible = false;
            this.dataGridViewLocationROL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLocationROL.Size = new System.Drawing.Size(605, 156);
            this.dataGridViewLocationROL.TabIndex = 9;
            this.dataGridViewLocationROL.DoubleClick += new System.EventHandler(this.dataGridViewLocationROL_DoubleClick);
            this.dataGridViewLocationROL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewLocationROL_KeyDown);
            // 
            // locaDataGridViewTextBoxColumn
            // 
            this.locaDataGridViewTextBoxColumn.DataPropertyName = "Loca";
            this.locaDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locaDataGridViewTextBoxColumn.Name = "locaDataGridViewTextBoxColumn";
            this.locaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Loca_Descrip
            // 
            this.Loca_Descrip.DataPropertyName = "Loca_Descrip";
            this.Loca_Descrip.HeaderText = "Description";
            this.Loca_Descrip.Name = "Loca_Descrip";
            this.Loca_Descrip.ReadOnly = true;
            this.Loca_Descrip.Width = 252;
            // 
            // rOLDataGridViewTextBoxColumn
            // 
            this.rOLDataGridViewTextBoxColumn.DataPropertyName = "ROL";
            this.rOLDataGridViewTextBoxColumn.HeaderText = "Re Order Level";
            this.rOLDataGridViewTextBoxColumn.Name = "rOLDataGridViewTextBoxColumn";
            this.rOLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOQtyDataGridViewTextBoxColumn
            // 
            this.rOQtyDataGridViewTextBoxColumn.DataPropertyName = "RO_Qty";
            this.rOQtyDataGridViewTextBoxColumn.HeaderText = "Re Order Qty";
            this.rOQtyDataGridViewTextBoxColumn.Name = "rOQtyDataGridViewTextBoxColumn";
            this.rOQtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 50;
            // 
            // dsProdROLBindingSource1
            // 
            this.dsProdROLBindingSource1.DataMember = "dsProdROL";
            this.dsProdROLBindingSource1.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(474, 223);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 50);
            this.btnExit.TabIndex = 168;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLocaSearch
            // 
            this.btnLocaSearch.Location = new System.Drawing.Point(355, 190);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(36, 19);
            this.btnLocaSearch.TabIndex = 171;
            this.btnLocaSearch.Text = "....";
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // txtLocaName
            // 
            this.txtLocaName.Location = new System.Drawing.Point(111, 190);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(238, 20);
            this.txtLocaName.TabIndex = 170;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Location = new System.Drawing.Point(6, 190);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(99, 20);
            this.txtLocaCode.TabIndex = 169;
            this.txtLocaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocaCode_KeyDown);
            this.txtLocaCode.Enter += new System.EventHandler(this.txtLocaCode_Enter);
            // 
            // txtROL
            // 
            this.txtROL.Location = new System.Drawing.Point(398, 190);
            this.txtROL.Name = "txtROL";
            this.txtROL.Size = new System.Drawing.Size(96, 20);
            this.txtROL.TabIndex = 172;
            this.txtROL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtROL_KeyDown);
            // 
            // txtReOrderQty
            // 
            this.txtReOrderQty.Location = new System.Drawing.Point(496, 190);
            this.txtReOrderQty.Name = "txtReOrderQty";
            this.txtReOrderQty.Size = new System.Drawing.Size(104, 20);
            this.txtReOrderQty.TabIndex = 173;
            this.txtReOrderQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReOrderQty_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Product";
            // 
            // lblProdCode
            // 
            this.lblProdCode.Location = new System.Drawing.Point(57, 9);
            this.lblProdCode.Name = "lblProdCode";
            this.lblProdCode.Size = new System.Drawing.Size(144, 20);
            this.lblProdCode.TabIndex = 175;
            // 
            // lblProdName
            // 
            this.lblProdName.Location = new System.Drawing.Point(207, 9);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(384, 20);
            this.lblProdName.TabIndex = 176;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(335, 223);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 50);
            this.btnAdd.TabIndex = 177;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dsProdROLBindingSource
            // 
            this.dsProdROLBindingSource.DataMember = "dsProdROL";
            this.dsProdROLBindingSource.DataSource = this.dsForReports;
            // 
            // frmLocationROL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(612, 281);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblProdName);
            this.Controls.Add(this.lblProdCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReOrderQty);
            this.Controls.Add(this.txtROL);
            this.Controls.Add(this.btnLocaSearch);
            this.Controls.Add(this.txtLocaName);
            this.Controls.Add(this.txtLocaCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridViewLocationROL);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocationROL";
            this.Text = "Location Re Order Level";
            this.Load += new System.EventHandler(this.frmLocationROL_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLocationROL_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLocationROL_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocationROL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdROLBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdROLBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridViewLocationROL;
        private System.Windows.Forms.BindingSource dsProdROLBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.BindingSource dsProdROLBindingSource1;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.TextBox txtROL;
        private System.Windows.Forms.TextBox txtReOrderQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProdCode;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn locaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loca_Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;

    }
}