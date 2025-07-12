namespace Inventory
{
    partial class frmProductPacketReg
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPacketQty = new System.Windows.Forms.TextBox();
            this.lblPacketPurchasePrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPacketItemSearch = new System.Windows.Forms.Button();
            this.txtPacketProductName = new System.Windows.Forms.TextBox();
            this.txtPacketProductCode = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTempPackProduct = new System.Windows.Forms.DataGridView();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsTempPacketProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempPackProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPurchasePrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnItemSearch);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Product";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchasePrice.Location = new System.Drawing.Point(594, 21);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(99, 16);
            this.lblPurchasePrice.TabIndex = 149;
            this.lblPurchasePrice.Text = "0.00";
            this.lblPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Product Code";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(543, 19);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(45, 20);
            this.btnItemSearch.TabIndex = 146;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(222, 18);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(315, 20);
            this.txtProductName.TabIndex = 145;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(94, 18);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(126, 20);
            this.txtProductCode.TabIndex = 144;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPacketQty);
            this.groupBox2.Controls.Add(this.lblPacketPurchasePrice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnPacketItemSearch);
            this.groupBox2.Controls.Add(this.txtPacketProductName);
            this.groupBox2.Controls.Add(this.txtPacketProductCode);
            this.groupBox2.Location = new System.Drawing.Point(4, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Packet Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(729, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "Packet Qty";
            // 
            // txtPacketQty
            // 
            this.txtPacketQty.Enabled = false;
            this.txtPacketQty.Location = new System.Drawing.Point(697, 27);
            this.txtPacketQty.Name = "txtPacketQty";
            this.txtPacketQty.Size = new System.Drawing.Size(90, 20);
            this.txtPacketQty.TabIndex = 150;
            this.txtPacketQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPacketQty_KeyDown);
            // 
            // lblPacketPurchasePrice
            // 
            this.lblPacketPurchasePrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPacketPurchasePrice.Location = new System.Drawing.Point(594, 30);
            this.lblPacketPurchasePrice.Name = "lblPacketPurchasePrice";
            this.lblPacketPurchasePrice.Size = new System.Drawing.Size(99, 16);
            this.lblPacketPurchasePrice.TabIndex = 149;
            this.lblPacketPurchasePrice.Text = "0.00";
            this.lblPacketPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Product Code";
            // 
            // btnPacketItemSearch
            // 
            this.btnPacketItemSearch.Enabled = false;
            this.btnPacketItemSearch.Location = new System.Drawing.Point(543, 29);
            this.btnPacketItemSearch.Name = "btnPacketItemSearch";
            this.btnPacketItemSearch.Size = new System.Drawing.Size(45, 20);
            this.btnPacketItemSearch.TabIndex = 146;
            this.btnPacketItemSearch.Text = "....";
            this.btnPacketItemSearch.UseVisualStyleBackColor = true;
            this.btnPacketItemSearch.Click += new System.EventHandler(this.btnPacketItemSearch_Click);
            // 
            // txtPacketProductName
            // 
            this.txtPacketProductName.Enabled = false;
            this.txtPacketProductName.Location = new System.Drawing.Point(222, 28);
            this.txtPacketProductName.Name = "txtPacketProductName";
            this.txtPacketProductName.Size = new System.Drawing.Size(315, 20);
            this.txtPacketProductName.TabIndex = 145;
            // 
            // txtPacketProductCode
            // 
            this.txtPacketProductCode.Enabled = false;
            this.txtPacketProductCode.Location = new System.Drawing.Point(94, 28);
            this.txtPacketProductCode.Name = "txtPacketProductCode";
            this.txtPacketProductCode.Size = new System.Drawing.Size(126, 20);
            this.txtPacketProductCode.TabIndex = 144;
            this.txtPacketProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPacketProductCode_KeyDown);
            this.txtPacketProductCode.Enter += new System.EventHandler(this.txtPacketProductCode_Enter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 365);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(801, 66);
            this.toolStrip1.TabIndex = 134;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewTempPackProduct);
            this.groupBox3.Location = new System.Drawing.Point(4, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 247);
            this.groupBox3.TabIndex = 135;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Items";
            // 
            // dataGridViewTempPackProduct
            // 
            this.dataGridViewTempPackProduct.AllowUserToAddRows = false;
            this.dataGridViewTempPackProduct.AllowUserToDeleteRows = false;
            this.dataGridViewTempPackProduct.AutoGenerateColumns = false;
            this.dataGridViewTempPackProduct.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewTempPackProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTempPackProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.packetQtyDataGridViewTextBoxColumn});
            this.dataGridViewTempPackProduct.DataSource = this.dsTempPacketProductBindingSource;
            this.dataGridViewTempPackProduct.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewTempPackProduct.Name = "dataGridViewTempPackProduct";
            this.dataGridViewTempPackProduct.ReadOnly = true;
            this.dataGridViewTempPackProduct.Size = new System.Drawing.Size(782, 222);
            this.dataGridViewTempPackProduct.TabIndex = 0;
            this.dataGridViewTempPackProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTempPackProduct_KeyDown);
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.Frozen = true;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Prod Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.prodCodeDataGridViewTextBoxColumn.Width = 175;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.Frozen = true;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNameDataGridViewTextBoxColumn.Width = 370;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            this.purchasepriceDataGridViewTextBoxColumn.Frozen = true;
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase Price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packetQtyDataGridViewTextBoxColumn
            // 
            this.packetQtyDataGridViewTextBoxColumn.DataPropertyName = "Packet_Qty";
            this.packetQtyDataGridViewTextBoxColumn.Frozen = true;
            this.packetQtyDataGridViewTextBoxColumn.HeaderText = "Packet Qty";
            this.packetQtyDataGridViewTextBoxColumn.Name = "packetQtyDataGridViewTextBoxColumn";
            this.packetQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.packetQtyDataGridViewTextBoxColumn.Width = 90;
            // 
            // dsTempPacketProductBindingSource
            // 
            this.dsTempPacketProductBindingSource.DataMember = "dsTempPacketProduct";
            this.dsTempPacketProductBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(680, 372);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 150;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(450, 372);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 149;
            this.btnApply.Text = "Save";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(570, 372);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 50);
            this.btnClear.TabIndex = 151;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmProductPacketReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(801, 431);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductPacketReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Packeting Registre";
            this.Load += new System.EventHandler(this.frmPacketingItemSelect_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPacketingItemSelect_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempPackProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPacketPurchasePrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPacketItemSearch;
        private System.Windows.Forms.TextBox txtPacketProductName;
        private System.Windows.Forms.TextBox txtPacketProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPacketQty;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewTempPackProduct;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnClear;
    }
}