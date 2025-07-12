namespace Inventory
{
    partial class frmProductPacketing
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
            this.dataGridViewTempPackProduct = new System.Windows.Forms.DataGridView();
            this.Main_Prod_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Main_Prod_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_Of_Packets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsTempPacketProductBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports2 = new Inventory.dsForReports();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoOfPackets = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMainQty = new System.Windows.Forms.Label();
            this.lblMainProductName = new System.Windows.Forms.Label();
            this.lblMainProductCode = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPackQty = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.dsTempPacketProductBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports1 = new Inventory.dsForReports();
            this.dsTempPacketProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempPackProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTempPackProduct
            // 
            this.dataGridViewTempPackProduct.AllowUserToAddRows = false;
            this.dataGridViewTempPackProduct.AllowUserToDeleteRows = false;
            this.dataGridViewTempPackProduct.AutoGenerateColumns = false;
            this.dataGridViewTempPackProduct.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewTempPackProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTempPackProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Main_Prod_Code,
            this.Main_Prod_Name,
            this.No_Of_Packets,
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.packetQtyDataGridViewTextBoxColumn});
            this.dataGridViewTempPackProduct.DataSource = this.dsTempPacketProductBindingSource2;
            this.dataGridViewTempPackProduct.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewTempPackProduct.Name = "dataGridViewTempPackProduct";
            this.dataGridViewTempPackProduct.ReadOnly = true;
            this.dataGridViewTempPackProduct.Size = new System.Drawing.Size(934, 222);
            this.dataGridViewTempPackProduct.TabIndex = 0;
            this.dataGridViewTempPackProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTempPackProduct_KeyDown);
            // 
            // Main_Prod_Code
            // 
            this.Main_Prod_Code.DataPropertyName = "Main_Prod_Code";
            this.Main_Prod_Code.Frozen = true;
            this.Main_Prod_Code.HeaderText = "Main Prod Code";
            this.Main_Prod_Code.Name = "Main_Prod_Code";
            this.Main_Prod_Code.ReadOnly = true;
            this.Main_Prod_Code.Width = 120;
            // 
            // Main_Prod_Name
            // 
            this.Main_Prod_Name.DataPropertyName = "Main_Prod_Name";
            this.Main_Prod_Name.Frozen = true;
            this.Main_Prod_Name.HeaderText = "Main Prod Name";
            this.Main_Prod_Name.Name = "Main_Prod_Name";
            this.Main_Prod_Name.ReadOnly = true;
            this.Main_Prod_Name.Width = 200;
            // 
            // No_Of_Packets
            // 
            this.No_Of_Packets.DataPropertyName = "No_Of_Packets";
            this.No_Of_Packets.Frozen = true;
            this.No_Of_Packets.HeaderText = "No Of Packets";
            this.No_Of_Packets.Name = "No_Of_Packets";
            this.No_Of_Packets.ReadOnly = true;
            this.No_Of_Packets.Width = 75;
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.Frozen = true;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Prod Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodCodeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.prodCodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.Frozen = true;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNameDataGridViewTextBoxColumn.Width = 200;
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
            this.packetQtyDataGridViewTextBoxColumn.Width = 75;
            // 
            // dsTempPacketProductBindingSource2
            // 
            this.dsTempPacketProductBindingSource2.DataMember = "dsTempPacketProduct";
            this.dsTempPacketProductBindingSource2.DataSource = this.dsForReports2;
            // 
            // dsForReports2
            // 
            this.dsForReports2.DataSetName = "dsForReports";
            this.dsForReports2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 355);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(956, 66);
            this.toolStrip1.TabIndex = 153;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(827, 364);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 156;
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
            this.btnApply.Location = new System.Drawing.Point(697, 364);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 155;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
            // txtNoOfPackets
            // 
            this.txtNoOfPackets.Enabled = false;
            this.txtNoOfPackets.Location = new System.Drawing.Point(842, 26);
            this.txtNoOfPackets.Name = "txtNoOfPackets";
            this.txtNoOfPackets.Size = new System.Drawing.Size(90, 20);
            this.txtNoOfPackets.TabIndex = 150;
            this.txtNoOfPackets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPacketQty_KeyDown);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Product Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblMainQty);
            this.groupBox1.Controls.Add(this.lblMainProductName);
            this.groupBox1.Controls.Add(this.lblMainProductCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 50);
            this.groupBox1.TabIndex = 151;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 159;
            this.label5.Text = "Current Qty";
            // 
            // lblMainQty
            // 
            this.lblMainQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblMainQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainQty.Location = new System.Drawing.Point(700, 16);
            this.lblMainQty.Name = "lblMainQty";
            this.lblMainQty.Size = new System.Drawing.Size(90, 21);
            this.lblMainQty.TabIndex = 158;
            this.lblMainQty.Text = "0.00";
            this.lblMainQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMainProductName
            // 
            this.lblMainProductName.BackColor = System.Drawing.Color.LightCyan;
            this.lblMainProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainProductName.Location = new System.Drawing.Point(223, 16);
            this.lblMainProductName.Name = "lblMainProductName";
            this.lblMainProductName.Size = new System.Drawing.Size(314, 19);
            this.lblMainProductName.TabIndex = 157;
            this.lblMainProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMainProductCode
            // 
            this.lblMainProductCode.BackColor = System.Drawing.Color.LightCyan;
            this.lblMainProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainProductCode.Location = new System.Drawing.Point(94, 16);
            this.lblMainProductCode.Name = "lblMainProductCode";
            this.lblMainProductCode.Size = new System.Drawing.Size(126, 19);
            this.lblMainProductCode.TabIndex = 156;
            this.lblMainProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewTempPackProduct);
            this.groupBox3.Location = new System.Drawing.Point(4, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(946, 247);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Items";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPackQty);
            this.groupBox2.Controls.Add(this.lblPurchasePrice);
            this.groupBox2.Controls.Add(this.btnItemSearch);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNoOfPackets);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(4, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(946, 54);
            this.groupBox2.TabIndex = 152;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Packet Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "Purchase Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(855, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "No Of Packets";
            // 
            // lblPackQty
            // 
            this.lblPackQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblPackQty.Location = new System.Drawing.Point(697, 25);
            this.lblPackQty.Name = "lblPackQty";
            this.lblPackQty.Size = new System.Drawing.Size(92, 19);
            this.lblPackQty.TabIndex = 156;
            this.lblPackQty.Text = "0.00";
            this.lblPackQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblPurchasePrice.Location = new System.Drawing.Point(594, 25);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(99, 19);
            this.lblPurchasePrice.TabIndex = 155;
            this.lblPurchasePrice.Text = "0.00";
            this.lblPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(543, 24);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(45, 20);
            this.btnItemSearch.TabIndex = 154;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(222, 25);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(315, 20);
            this.txtProductName.TabIndex = 153;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(94, 25);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(126, 20);
            this.txtProductCode.TabIndex = 152;
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // dsTempPacketProductBindingSource1
            // 
            this.dsTempPacketProductBindingSource1.DataMember = "dsTempPacketProduct";
            this.dsTempPacketProductBindingSource1.DataSource = this.dsForReports1;
            // 
            // dsForReports1
            // 
            this.dsForReports1.DataSetName = "dsForReports";
            this.dsForReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // frmPacketingProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(956, 421);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPacketingProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Packeting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPacketingProduct_FormClosed);
            this.Load += new System.EventHandler(this.frmPacketingProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempPackProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTempPackProduct;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoOfPackets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMainProductName;
        private System.Windows.Forms.Label lblMainProductCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMainQty;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource1;
        private dsForReports dsForReports1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPackQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource2;
        private dsForReports dsForReports2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Main_Prod_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Main_Prod_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Of_Packets;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetQtyDataGridViewTextBoxColumn;
    }
}