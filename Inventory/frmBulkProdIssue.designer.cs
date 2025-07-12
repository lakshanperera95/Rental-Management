namespace Inventory
{
    partial class frmBulkProdIssue
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
            this.dgBulkIssue = new System.Windows.Forms.DataGridView();
            this.dsTempPacketProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMainQty = new System.Windows.Forms.Label();
            this.lblMainProductName = new System.Windows.Forms.Label();
            this.lblMainProductCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoOfPackets = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPackQty = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPostDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainProdCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainProdNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOfPacketsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBulkIssue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgBulkIssue);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtPostDate);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.lblDocNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgBulkIssue
            // 
            this.dgBulkIssue.AllowUserToAddRows = false;
            this.dgBulkIssue.AllowUserToDeleteRows = false;
            this.dgBulkIssue.AllowUserToResizeColumns = false;
            this.dgBulkIssue.AllowUserToResizeRows = false;
            this.dgBulkIssue.AutoGenerateColumns = false;
            this.dgBulkIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBulkIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mainProdCodeDataGridViewTextBoxColumn,
            this.mainProdNameDataGridViewTextBoxColumn,
            this.noOfPacketsDataGridViewTextBoxColumn,
            this.BatchNo,
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.packetQtyDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn});
            this.dgBulkIssue.DataSource = this.dsTempPacketProductBindingSource;
            this.dgBulkIssue.Location = new System.Drawing.Point(9, 178);
            this.dgBulkIssue.Name = "dgBulkIssue";
            this.dgBulkIssue.ReadOnly = true;
            this.dgBulkIssue.RowHeadersWidth = 20;
            this.dgBulkIssue.Size = new System.Drawing.Size(865, 193);
            this.dgBulkIssue.TabIndex = 164;
            this.dgBulkIssue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgBulkIssue_KeyDown);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbBatchNo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblMainQty);
            this.groupBox2.Controls.Add(this.lblMainProductName);
            this.groupBox2.Controls.Add(this.lblMainProductCode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNoOfPackets);
            this.groupBox2.Location = new System.Drawing.Point(11, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 63);
            this.groupBox2.TabIndex = 162;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bulk Product";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 216;
            this.label2.Text = "Batch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(629, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 157;
            this.label7.Text = "No Of Units";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(418, 32);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(111, 21);
            this.cmbBatchNo.TabIndex = 215;
            this.cmbBatchNo.SelectedIndexChanged += new System.EventHandler(this.cmbBatchNo_SelectedIndexChanged);
            this.cmbBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBatchNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(532, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 159;
            this.label5.Text = "Current Qty";
            // 
            // lblMainQty
            // 
            this.lblMainQty.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblMainQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainQty.Location = new System.Drawing.Point(535, 32);
            this.lblMainQty.Name = "lblMainQty";
            this.lblMainQty.Size = new System.Drawing.Size(90, 21);
            this.lblMainQty.TabIndex = 158;
            this.lblMainQty.Text = "0.00";
            this.lblMainQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMainProductName
            // 
            this.lblMainProductName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblMainProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainProductName.Location = new System.Drawing.Point(170, 33);
            this.lblMainProductName.Name = "lblMainProductName";
            this.lblMainProductName.Size = new System.Drawing.Size(242, 19);
            this.lblMainProductName.TabIndex = 157;
            this.lblMainProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMainProductCode
            // 
            this.lblMainProductCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblMainProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainProductCode.Location = new System.Drawing.Point(83, 33);
            this.lblMainProductCode.Name = "lblMainProductCode";
            this.lblMainProductCode.Size = new System.Drawing.Size(84, 19);
            this.lblMainProductCode.TabIndex = 156;
            this.lblMainProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMainProductCode.Enter += new System.EventHandler(this.lblMainProductCode_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 148;
            this.label4.Text = "Bulk Code";
            // 
            // txtNoOfPackets
            // 
            this.txtNoOfPackets.Enabled = false;
            this.txtNoOfPackets.Location = new System.Drawing.Point(631, 33);
            this.txtNoOfPackets.Name = "txtNoOfPackets";
            this.txtNoOfPackets.Size = new System.Drawing.Size(90, 20);
            this.txtNoOfPackets.TabIndex = 150;
            this.txtNoOfPackets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoOfPackets_KeyDown);
            this.txtNoOfPackets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfPackets_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblPackQty);
            this.groupBox3.Controls.Add(this.lblPurchasePrice);
            this.groupBox3.Controls.Add(this.btnItemSearch);
            this.groupBox3.Controls.Add(this.txtProductName);
            this.groupBox3.Controls.Add(this.txtProductCode);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(9, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(859, 54);
            this.groupBox3.TabIndex = 163;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loose Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 158;
            this.label6.Text = "Purchase Price";
            // 
            // lblPackQty
            // 
            this.lblPackQty.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblPackQty.Location = new System.Drawing.Point(577, 26);
            this.lblPackQty.Name = "lblPackQty";
            this.lblPackQty.Size = new System.Drawing.Size(92, 19);
            this.lblPackQty.TabIndex = 156;
            this.lblPackQty.Text = "0.00";
            this.lblPackQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblPurchasePrice.Location = new System.Drawing.Point(474, 26);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(99, 19);
            this.lblPurchasePrice.TabIndex = 155;
            this.lblPurchasePrice.Text = "0.00";
            this.lblPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(420, 25);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(27, 20);
            this.btnItemSearch.TabIndex = 154;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(175, 25);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(242, 20);
            this.txtProductName.TabIndex = 153;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(88, 25);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(84, 20);
            this.txtProductCode.TabIndex = 152;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(609, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 151;
            this.label8.Text = "Packet Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 148;
            this.label9.Text = "Loose Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 161;
            this.label3.Text = "Date.";
            // 
            // dtPostDate
            // 
            this.dtPostDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostDate.Location = new System.Drawing.Point(50, 19);
            this.dtPostDate.Name = "dtPostDate";
            this.dtPostDate.Size = new System.Drawing.Size(102, 20);
            this.dtPostDate.TabIndex = 160;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(764, 393);
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
            this.btnApply.Location = new System.Drawing.Point(646, 393);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 158;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(3, 393);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 58);
            this.toolStrip1.TabIndex = 157;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblDocNo
            // 
            this.lblDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocNo.Location = new System.Drawing.Point(772, 21);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(92, 15);
            this.lblDocNo.TabIndex = 1;
            this.lblDocNo.Text = "000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document No.";
            // 
            // mainProdCodeDataGridViewTextBoxColumn
            // 
            this.mainProdCodeDataGridViewTextBoxColumn.DataPropertyName = "Main_Prod_Code";
            this.mainProdCodeDataGridViewTextBoxColumn.FillWeight = 94.66192F;
            this.mainProdCodeDataGridViewTextBoxColumn.HeaderText = "Main Code";
            this.mainProdCodeDataGridViewTextBoxColumn.Name = "mainProdCodeDataGridViewTextBoxColumn";
            this.mainProdCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mainProdCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // mainProdNameDataGridViewTextBoxColumn
            // 
            this.mainProdNameDataGridViewTextBoxColumn.DataPropertyName = "Main_Prod_Name";
            this.mainProdNameDataGridViewTextBoxColumn.FillWeight = 102.4971F;
            this.mainProdNameDataGridViewTextBoxColumn.HeaderText = "Main P Name";
            this.mainProdNameDataGridViewTextBoxColumn.Name = "mainProdNameDataGridViewTextBoxColumn";
            this.mainProdNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.mainProdNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // noOfPacketsDataGridViewTextBoxColumn
            // 
            this.noOfPacketsDataGridViewTextBoxColumn.DataPropertyName = "No_Of_Packets";
            this.noOfPacketsDataGridViewTextBoxColumn.FillWeight = 121.942F;
            this.noOfPacketsDataGridViewTextBoxColumn.HeaderText = "Packets ";
            this.noOfPacketsDataGridViewTextBoxColumn.Name = "noOfPacketsDataGridViewTextBoxColumn";
            this.noOfPacketsDataGridViewTextBoxColumn.ReadOnly = true;
            this.noOfPacketsDataGridViewTextBoxColumn.Width = 80;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.FillWeight = 84.88628F;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Loose Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.FillWeight = 121.5172F;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Loose  P Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.prodNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // packetQtyDataGridViewTextBoxColumn
            // 
            this.packetQtyDataGridViewTextBoxColumn.DataPropertyName = "Packet_Qty";
            this.packetQtyDataGridViewTextBoxColumn.FillWeight = 80.36965F;
            this.packetQtyDataGridViewTextBoxColumn.HeaderText = "Packet Qty";
            this.packetQtyDataGridViewTextBoxColumn.Name = "packetQtyDataGridViewTextBoxColumn";
            this.packetQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.packetQtyDataGridViewTextBoxColumn.Width = 60;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            this.purchasepriceDataGridViewTextBoxColumn.FillWeight = 94.12585F;
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase Price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchasepriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // frmBulkProdIssue
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(878, 448);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBulkProdIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Abstracting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBulkProdIssue_FormClosed);
            this.Load += new System.EventHandler(this.frmBulkProdIssue_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBulkIssue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDocNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPostDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMainQty;
        private System.Windows.Forms.Label lblMainProductName;
        private System.Windows.Forms.Label lblMainProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPackQty;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgBulkIssue;
        private System.Windows.Forms.TextBox txtNoOfPackets;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn mainProdCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mainProdNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOfPacketsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
    }
}