namespace Inventory
{
    partial class frmBatchPriceChange
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.dataGridViewProductPriceLevel = new System.Windows.Forms.DataGridView();
            this.dtBatchWisePriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.txtRetPrice = new System.Windows.Forms.TextBox();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.txtDistribPrice = new System.Windows.Forms.TextBox();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWsPrice = new System.Windows.Forms.TextBox();
            this.txtModMktPrice = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.batchNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wsPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distrPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modMktPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBatchWisePriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(744, 357);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 42);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Product";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(512, 16);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(38, 20);
            this.btnItemSearch.TabIndex = 2;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(184, 16);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(320, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(72, 16);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(104, 20);
            this.txtProductCode.TabIndex = 0;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // dataGridViewProductPriceLevel
            // 
            this.dataGridViewProductPriceLevel.AllowUserToAddRows = false;
            this.dataGridViewProductPriceLevel.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewProductPriceLevel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProductPriceLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductPriceLevel.AutoGenerateColumns = false;
            this.dataGridViewProductPriceLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductPriceLevel.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridViewProductPriceLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductPriceLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batchNoDataGridViewTextBoxColumn,
            this.expDateDataGridViewTextBoxColumn,
            this.shipmentDataGridViewTextBoxColumn,
            this.purchasePriceDataGridViewTextBoxColumn,
            this.wsPriceDataGridViewTextBoxColumn,
            this.retPriceDataGridViewTextBoxColumn,
            this.distrPriceDataGridViewTextBoxColumn,
            this.modMktPriceDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn});
            this.dataGridViewProductPriceLevel.DataSource = this.dtBatchWisePriceBindingSource;
            this.dataGridViewProductPriceLevel.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewProductPriceLevel.MultiSelect = false;
            this.dataGridViewProductPriceLevel.Name = "dataGridViewProductPriceLevel";
            this.dataGridViewProductPriceLevel.ReadOnly = true;
            this.dataGridViewProductPriceLevel.RowHeadersWidth = 31;
            this.dataGridViewProductPriceLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductPriceLevel.Size = new System.Drawing.Size(825, 253);
            this.dataGridViewProductPriceLevel.TabIndex = 9;
            this.dataGridViewProductPriceLevel.DoubleClick += new System.EventHandler(this.dataGridViewProductPriceLevel_DoubleClick);
            this.dataGridViewProductPriceLevel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductPriceLevel_CellContentClick);
            // 
            // dtBatchWisePriceBindingSource
            // 
            this.dtBatchWisePriceBindingSource.DataMember = "dtBatchWisePrice";
            this.dtBatchWisePriceBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtRetPrice
            // 
            this.txtRetPrice.Location = new System.Drawing.Point(300, 368);
            this.txtRetPrice.Name = "txtRetPrice";
            this.txtRetPrice.Size = new System.Drawing.Size(72, 20);
            this.txtRetPrice.TabIndex = 6;
            this.txtRetPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(24, 368);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(91, 20);
            this.txtPurchasePrice.TabIndex = 4;
            this.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchasePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchasePrice_KeyDown);
            // 
            // txtDistribPrice
            // 
            this.txtDistribPrice.Location = new System.Drawing.Point(430, 368);
            this.txtDistribPrice.Name = "txtDistribPrice";
            this.txtDistribPrice.Size = new System.Drawing.Size(72, 20);
            this.txtDistribPrice.TabIndex = 7;
            this.txtDistribPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDistribPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDollarPrice_KeyDown);
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(96, 312);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.ReadOnly = true;
            this.txtBatchNo.Size = new System.Drawing.Size(98, 20);
            this.txtBatchNo.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "BatchNo";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(560, 344);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(108, 13);
            this.label28.TabIndex = 212;
            this.label28.Text = "Modern Mkd Price";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(304, 344);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(71, 13);
            this.label32.TabIndex = 213;
            this.label32.Text = "Retail Price";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(432, 344);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 13);
            this.label23.TabIndex = 211;
            this.label23.Text = "Distribution Price";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(160, 344);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 210;
            this.label20.Text = "Whole Sale Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 209;
            this.label8.Text = "Purchase price";
            // 
            // txtWsPrice
            // 
            this.txtWsPrice.Location = new System.Drawing.Point(162, 368);
            this.txtWsPrice.Name = "txtWsPrice";
            this.txtWsPrice.Size = new System.Drawing.Size(80, 20);
            this.txtWsPrice.TabIndex = 5;
            this.txtWsPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWsPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWsPrice_KeyDown);
            // 
            // txtModMktPrice
            // 
            this.txtModMktPrice.Location = new System.Drawing.Point(560, 368);
            this.txtModMktPrice.Name = "txtModMktPrice";
            this.txtModMktPrice.Size = new System.Drawing.Size(72, 20);
            this.txtModMktPrice.TabIndex = 8;
            this.txtModMktPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtModMktPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModMktPrice_KeyDown);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(216, 314);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 17);
            this.label30.TabIndex = 216;
            this.label30.Text = "Exp Date";
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpireDate.Location = new System.Drawing.Point(272, 312);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(112, 20);
            this.dtpExpireDate.TabIndex = 3;
            this.dtpExpireDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpExpireDate_KeyDown);
            // 
            // batchNoDataGridViewTextBoxColumn
            // 
            this.batchNoDataGridViewTextBoxColumn.DataPropertyName = "BatchNo";
            this.batchNoDataGridViewTextBoxColumn.HeaderText = "BatchNo";
            this.batchNoDataGridViewTextBoxColumn.Name = "batchNoDataGridViewTextBoxColumn";
            this.batchNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "Exp_Date";
            this.expDateDataGridViewTextBoxColumn.FillWeight = 75F;
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Exp Date";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shipmentDataGridViewTextBoxColumn
            // 
            this.shipmentDataGridViewTextBoxColumn.DataPropertyName = "Shipment";
            this.shipmentDataGridViewTextBoxColumn.FillWeight = 50F;
            this.shipmentDataGridViewTextBoxColumn.HeaderText = "Shipment";
            this.shipmentDataGridViewTextBoxColumn.Name = "shipmentDataGridViewTextBoxColumn";
            this.shipmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_Price";
            this.purchasePriceDataGridViewTextBoxColumn.FillWeight = 60F;
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "Purchase Price";
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            this.purchasePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wsPriceDataGridViewTextBoxColumn
            // 
            this.wsPriceDataGridViewTextBoxColumn.DataPropertyName = "Ws_Price";
            this.wsPriceDataGridViewTextBoxColumn.FillWeight = 60F;
            this.wsPriceDataGridViewTextBoxColumn.HeaderText = "Ws Price";
            this.wsPriceDataGridViewTextBoxColumn.Name = "wsPriceDataGridViewTextBoxColumn";
            this.wsPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // retPriceDataGridViewTextBoxColumn
            // 
            this.retPriceDataGridViewTextBoxColumn.DataPropertyName = "Ret_Price";
            this.retPriceDataGridViewTextBoxColumn.FillWeight = 60F;
            this.retPriceDataGridViewTextBoxColumn.HeaderText = "Retail Price";
            this.retPriceDataGridViewTextBoxColumn.Name = "retPriceDataGridViewTextBoxColumn";
            this.retPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // distrPriceDataGridViewTextBoxColumn
            // 
            this.distrPriceDataGridViewTextBoxColumn.DataPropertyName = "Distr_Price";
            this.distrPriceDataGridViewTextBoxColumn.FillWeight = 60F;
            this.distrPriceDataGridViewTextBoxColumn.HeaderText = "Distr Price";
            this.distrPriceDataGridViewTextBoxColumn.Name = "distrPriceDataGridViewTextBoxColumn";
            this.distrPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modMktPriceDataGridViewTextBoxColumn
            // 
            this.modMktPriceDataGridViewTextBoxColumn.DataPropertyName = "ModMkt_Price";
            this.modMktPriceDataGridViewTextBoxColumn.FillWeight = 60F;
            this.modMktPriceDataGridViewTextBoxColumn.HeaderText = "Market Price";
            this.modMktPriceDataGridViewTextBoxColumn.Name = "modMktPriceDataGridViewTextBoxColumn";
            this.modMktPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.FillWeight = 45F;
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBatchPriceChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 414);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.dtpExpireDate);
            this.Controls.Add(this.txtModMktPrice);
            this.Controls.Add(this.txtWsPrice);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.txtRetPrice);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.txtDistribPrice);
            this.Controls.Add(this.dataGridViewProductPriceLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnItemSearch);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBatchPriceChange";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Price Change";
            this.Load += new System.EventHandler(this.frmLotWiseDollarPrice_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLotWiseDollarPrice_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBatchWisePriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        public System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.DataGridView dataGridViewProductPriceLevel;
        private dsForReports dsForReports;
        private System.Windows.Forms.TextBox txtRetPrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.TextBox txtDistribPrice;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dtBatchWisePriceBindingSource;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWsPrice;
        private System.Windows.Forms.TextBox txtModMktPrice;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wsPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distrPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modMktPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
    }
}