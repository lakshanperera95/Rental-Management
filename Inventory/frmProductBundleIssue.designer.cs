namespace Inventory
{
    partial class frmProductBundleIssue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTempPackProduct = new System.Windows.Forms.DataGridView();
            this.dsTempPacketProductBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports2 = new Inventory.dsForReports();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtNoOfPackets = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBatchQty = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblSubTotQty = new System.Windows.Forms.Label();
            this.lblSubPrice = new System.Windows.Forms.Label();
            this.btnSearchSubProd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSubProdName = new System.Windows.Forms.TextBox();
            this.txtSubProdCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPackQty = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.lstBoxPacketItems = new System.Windows.Forms.ListBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.dsProdBundleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsTempPacketProductBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports1 = new Inventory.dsForReports();
            this.dsTempPacketProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCostprice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dpdate = new System.Windows.Forms.DateTimePicker();
            this.Main_Prod_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Main_Prod_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_Of_Packets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempPackProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdBundleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports2BindingSource)).BeginInit();
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
            this.dataGridViewTempPackProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Main_Prod_Code,
            this.Main_Prod_Name,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.No_Of_Packets,
            this.packetQtyDataGridViewTextBoxColumn,
            this.BatchNo});
            this.dataGridViewTempPackProduct.DataSource = this.dsTempPacketProductBindingSource2;
            this.dataGridViewTempPackProduct.Location = new System.Drawing.Point(6, 66);
            this.dataGridViewTempPackProduct.Name = "dataGridViewTempPackProduct";
            this.dataGridViewTempPackProduct.ReadOnly = true;
            this.dataGridViewTempPackProduct.Size = new System.Drawing.Size(762, 209);
            this.dataGridViewTempPackProduct.TabIndex = 0;
            this.dataGridViewTempPackProduct.Tag = "GridView";
            this.dataGridViewTempPackProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTempPackProduct_KeyDown);
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 504);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 66);
            this.toolStrip1.TabIndex = 153;
            this.toolStrip1.Tag = "ToolStrip";
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(672, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 156;
            this.btnClose.Tag = "MainButton";
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
            this.btnApply.Location = new System.Drawing.Point(430, 509);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 155;
            this.btnApply.Tag = "MainButton";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtNoOfPackets
            // 
            this.txtNoOfPackets.Enabled = false;
            this.txtNoOfPackets.Location = new System.Drawing.Point(671, 23);
            this.txtNoOfPackets.Name = "txtNoOfPackets";
            this.txtNoOfPackets.Size = new System.Drawing.Size(79, 20);
            this.txtNoOfPackets.TabIndex = 150;
            this.txtNoOfPackets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoOfPackets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPacketQty_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "No Of Items";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBatchQty);
            this.groupBox3.Controls.Add(this.cmbBatch);
            this.groupBox3.Controls.Add(this.txtQty);
            this.groupBox3.Controls.Add(this.lblSubTotQty);
            this.groupBox3.Controls.Add(this.dataGridViewTempPackProduct);
            this.groupBox3.Controls.Add(this.lblSubPrice);
            this.groupBox3.Controls.Add(this.btnSearchSubProd);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtSubProdName);
            this.groupBox3.Controls.Add(this.txtSubProdCode);
            this.groupBox3.Location = new System.Drawing.Point(4, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 283);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Items";
            // 
            // lblBatchQty
            // 
            this.lblBatchQty.BackColor = System.Drawing.Color.Aqua;
            this.lblBatchQty.Location = new System.Drawing.Point(479, 40);
            this.lblBatchQty.Name = "lblBatchQty";
            this.lblBatchQty.Size = new System.Drawing.Size(117, 19);
            this.lblBatchQty.TabIndex = 166;
            this.lblBatchQty.Text = "0.00";
            this.lblBatchQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(482, 16);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(114, 21);
            this.cmbBatch.TabIndex = 165;
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            this.cmbBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBatch_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(682, 15);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(76, 20);
            this.txtQty.TabIndex = 159;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // lblSubTotQty
            // 
            this.lblSubTotQty.BackColor = System.Drawing.Color.Aqua;
            this.lblSubTotQty.Location = new System.Drawing.Point(600, 40);
            this.lblSubTotQty.Name = "lblSubTotQty";
            this.lblSubTotQty.Size = new System.Drawing.Size(76, 19);
            this.lblSubTotQty.TabIndex = 164;
            this.lblSubTotQty.Text = "0.00";
            this.lblSubTotQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubPrice
            // 
            this.lblSubPrice.BackColor = System.Drawing.Color.Aqua;
            this.lblSubPrice.Location = new System.Drawing.Point(600, 16);
            this.lblSubPrice.Name = "lblSubPrice";
            this.lblSubPrice.Size = new System.Drawing.Size(76, 19);
            this.lblSubPrice.TabIndex = 163;
            this.lblSubPrice.Text = "0.00";
            this.lblSubPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearchSubProd
            // 
            this.btnSearchSubProd.Location = new System.Drawing.Point(455, 16);
            this.btnSearchSubProd.Name = "btnSearchSubProd";
            this.btnSearchSubProd.Size = new System.Drawing.Size(21, 20);
            this.btnSearchSubProd.TabIndex = 162;
            this.btnSearchSubProd.Text = "....";
            this.btnSearchSubProd.UseVisualStyleBackColor = true;
            this.btnSearchSubProd.Click += new System.EventHandler(this.btnSearchSubProd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 159;
            this.label8.Text = "Product Code";
            // 
            // txtSubProdName
            // 
            this.txtSubProdName.Location = new System.Drawing.Point(196, 16);
            this.txtSubProdName.Name = "txtSubProdName";
            this.txtSubProdName.Size = new System.Drawing.Size(259, 20);
            this.txtSubProdName.TabIndex = 161;
            // 
            // txtSubProdCode
            // 
            this.txtSubProdCode.Location = new System.Drawing.Point(102, 16);
            this.txtSubProdCode.Name = "txtSubProdCode";
            this.txtSubProdCode.Size = new System.Drawing.Size(92, 20);
            this.txtSubProdCode.TabIndex = 160;
            this.txtSubProdCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubProdCode_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPackQty);
            this.groupBox2.Controls.Add(this.lblPurchasePrice);
            this.groupBox2.Controls.Add(this.btnItemSearch);
            this.groupBox2.Controls.Add(this.lstBoxPacketItems);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNoOfPackets);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(4, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 118);
            this.groupBox2.TabIndex = 152;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bundle Item";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "Purchase Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(671, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "Qty";
            // 
            // lblPackQty
            // 
            this.lblPackQty.BackColor = System.Drawing.Color.Aqua;
            this.lblPackQty.Location = new System.Drawing.Point(573, 25);
            this.lblPackQty.Name = "lblPackQty";
            this.lblPackQty.Size = new System.Drawing.Size(92, 19);
            this.lblPackQty.TabIndex = 156;
            this.lblPackQty.Text = "0.00";
            this.lblPackQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.BackColor = System.Drawing.Color.Aqua;
            this.lblPurchasePrice.Location = new System.Drawing.Point(470, 25);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(99, 19);
            this.lblPurchasePrice.TabIndex = 155;
            this.lblPurchasePrice.Text = "0.00";
            this.lblPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(447, 25);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(21, 20);
            this.btnItemSearch.TabIndex = 154;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // lstBoxPacketItems
            // 
            this.lstBoxPacketItems.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxPacketItems.FormattingEnabled = true;
            this.lstBoxPacketItems.Location = new System.Drawing.Point(190, 47);
            this.lstBoxPacketItems.Name = "lstBoxPacketItems";
            this.lstBoxPacketItems.Size = new System.Drawing.Size(471, 56);
            this.lstBoxPacketItems.TabIndex = 159;
            this.lstBoxPacketItems.Visible = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(190, 25);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(257, 20);
            this.txtProductName.TabIndex = 153;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(94, 25);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(92, 20);
            this.txtProductCode.TabIndex = 152;
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "Document No.";
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempDocNo.Location = new System.Drawing.Point(100, 9);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Size = new System.Drawing.Size(90, 17);
            this.lblTempDocNo.TabIndex = 161;
            this.lblTempDocNo.Text = "BDL0000001";
            // 
            // dsProdBundleBindingSource
            // 
            this.dsProdBundleBindingSource.DataMember = "dsProdBundle";
            this.dsProdBundleBindingSource.DataSource = this.dsForReports2BindingSource;
            // 
            // dsForReports2BindingSource
            // 
            this.dsForReports2BindingSource.DataSource = this.dsForReports2;
            this.dsForReports2BindingSource.Position = 0;
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
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(555, 508);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 50);
            this.btnClear.TabIndex = 162;
            this.btnClear.Tag = "MainButton";
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(672, 428);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(90, 20);
            this.txtTotal.TabIndex = 167;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 167;
            this.label5.Text = "Total Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(568, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 169;
            this.label7.Text = "Cost Price 1 unit";
            // 
            // txtCostprice
            // 
            this.txtCostprice.Enabled = false;
            this.txtCostprice.Location = new System.Drawing.Point(672, 454);
            this.txtCostprice.Name = "txtCostprice";
            this.txtCostprice.ReadOnly = true;
            this.txtCostprice.Size = new System.Drawing.Size(90, 20);
            this.txtCostprice.TabIndex = 168;
            this.txtCostprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(568, 483);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 171;
            this.label9.Text = "Selling Price 1 unit";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(672, 480);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(90, 20);
            this.txtSalePrice.TabIndex = 170;
            this.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(604, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 172;
            this.label10.Text = "Date";
            // 
            // dpdate
            // 
            this.dpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpdate.Location = new System.Drawing.Point(658, 6);
            this.dpdate.Name = "dpdate";
            this.dpdate.Size = new System.Drawing.Size(96, 20);
            this.dpdate.TabIndex = 173;
            // 
            // Main_Prod_Code
            // 
            this.Main_Prod_Code.DataPropertyName = "Main_Prod_Code";
            this.Main_Prod_Code.Frozen = true;
            this.Main_Prod_Code.HeaderText = "Prod Code";
            this.Main_Prod_Code.Name = "Main_Prod_Code";
            this.Main_Prod_Code.ReadOnly = true;
            // 
            // Main_Prod_Name
            // 
            this.Main_Prod_Name.DataPropertyName = "Main_Prod_Name";
            this.Main_Prod_Name.Frozen = true;
            this.Main_Prod_Name.HeaderText = "Prod Name";
            this.Main_Prod_Name.Name = "Main_Prod_Name";
            this.Main_Prod_Name.ReadOnly = true;
            this.Main_Prod_Name.Width = 250;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.purchasepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.purchasepriceDataGridViewTextBoxColumn.Frozen = true;
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase Price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // No_Of_Packets
            // 
            this.No_Of_Packets.DataPropertyName = "No_Of_Packets";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No_Of_Packets.DefaultCellStyle = dataGridViewCellStyle2;
            this.No_Of_Packets.Frozen = true;
            this.No_Of_Packets.HeaderText = "Qty";
            this.No_Of_Packets.Name = "No_Of_Packets";
            this.No_Of_Packets.ReadOnly = true;
            // 
            // packetQtyDataGridViewTextBoxColumn
            // 
            this.packetQtyDataGridViewTextBoxColumn.DataPropertyName = "Packet_Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.packetQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.packetQtyDataGridViewTextBoxColumn.Frozen = true;
            this.packetQtyDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.packetQtyDataGridViewTextBoxColumn.Name = "packetQtyDataGridViewTextBoxColumn";
            this.packetQtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.Frozen = true;
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            // 
            // frmProductBundleIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 570);
            this.Controls.Add(this.dpdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCostprice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTempDocNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductBundleIssue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bundled Product Issuing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPacketingProduct_FormClosed);
            this.Load += new System.EventHandler(this.frmPacketingProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempPackProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdBundleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTempPacketProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTempPackProduct;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtNoOfPackets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource1;
        private dsForReports dsForReports1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPackQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dsTempPacketProductBindingSource2;
        private dsForReports dsForReports2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.ListBox lstBoxPacketItems;
        private System.Windows.Forms.BindingSource dsProdBundleBindingSource;
        private System.Windows.Forms.BindingSource dsForReports2BindingSource;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblSubTotQty;
        private System.Windows.Forms.Label lblSubPrice;
        private System.Windows.Forms.Button btnSearchSubProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSubProdName;
        private System.Windows.Forms.TextBox txtSubProdCode;
        private System.Windows.Forms.Label lblBatchQty;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCostprice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Main_Prod_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Main_Prod_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Of_Packets;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
    }
}