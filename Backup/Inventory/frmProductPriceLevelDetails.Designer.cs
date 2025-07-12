namespace Inventory
{
    partial class frmProductPriceLevelDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblLastPurPrice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWholeSalePrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMarkedPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.lblPurchasingPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.dataGridViewProductPriceLevel = new System.Windows.Forms.DataGridView();
            this.PriceBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Purchase_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marked_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Whole_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_Level_Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholeQtyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholeQtyPrice_Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyCreditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceLevelCreditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markedPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholeQtyCreditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholeQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholeQtyPriceCreditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholeQtyPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceBatchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsPriceMasterDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPriceMasterDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtBatch);
            this.groupBox2.Controls.Add(this.lblLastPurPrice);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtWholeSalePrice);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMarkedPrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSellingPrice);
            this.groupBox2.Controls.Add(this.lblPurchasingPrice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnItemSearch);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::Inventory.Properties.Resources.Imagetools_Eraser_icon;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(688, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 54);
            this.btnClear.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnClear, "Clear");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(684, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "Price Batch";
            this.label16.Visible = false;
            // 
            // txtBatch
            // 
            this.txtBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(688, 57);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.ReadOnly = true;
            this.txtBatch.Size = new System.Drawing.Size(55, 26);
            this.txtBatch.TabIndex = 13;
            this.txtBatch.Text = "1";
            this.txtBatch.Visible = false;
            // 
            // lblLastPurPrice
            // 
            this.lblLastPurPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblLastPurPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastPurPrice.Location = new System.Drawing.Point(98, 40);
            this.lblLastPurPrice.Name = "lblLastPurPrice";
            this.lblLastPurPrice.Size = new System.Drawing.Size(98, 18);
            this.lblLastPurPrice.TabIndex = 4;
            this.lblLastPurPrice.Text = "0.00";
            this.lblLastPurPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Last Pur Price";
            // 
            // txtWholeSalePrice
            // 
            this.txtWholeSalePrice.Location = new System.Drawing.Point(567, 63);
            this.txtWholeSalePrice.Name = "txtWholeSalePrice";
            this.txtWholeSalePrice.Size = new System.Drawing.Size(98, 20);
            this.txtWholeSalePrice.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(481, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "WholeSale Price";
            // 
            // txtMarkedPrice
            // 
            this.txtMarkedPrice.Location = new System.Drawing.Point(98, 66);
            this.txtMarkedPrice.Name = "txtMarkedPrice";
            this.txtMarkedPrice.Size = new System.Drawing.Size(98, 20);
            this.txtMarkedPrice.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Marked Price";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Location = new System.Drawing.Point(329, 64);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(96, 20);
            this.txtSellingPrice.TabIndex = 7;
            // 
            // lblPurchasingPrice
            // 
            this.lblPurchasingPrice.BackColor = System.Drawing.Color.LightCyan;
            this.lblPurchasingPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPurchasingPrice.Location = new System.Drawing.Point(329, 41);
            this.lblPurchasingPrice.Name = "lblPurchasingPrice";
            this.lblPurchasingPrice.Size = new System.Drawing.Size(96, 18);
            this.lblPurchasingPrice.TabIndex = 5;
            this.lblPurchasingPrice.Text = "0.00";
            this.lblPurchasingPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Purchase Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selling Price";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(591, 14);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(38, 20);
            this.btnItemSearch.TabIndex = 3;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(202, 15);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(383, 20);
            this.txtProductName.TabIndex = 2;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(98, 15);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(98, 20);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // dataGridViewProductPriceLevel
            // 
            this.dataGridViewProductPriceLevel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewProductPriceLevel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProductPriceLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductPriceLevel.AutoGenerateColumns = false;
            this.dataGridViewProductPriceLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductPriceLevel.BackgroundColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductPriceLevel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProductPriceLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PriceBatch,
            this.Purchase_Price,
            this.Marked_Price,
            this.Whole_Price,
            this.Qty,
            this.Price_Level,
            this.Price_Level_Credit,
            this.WholeQty,
            this.WholeQtyPrice,
            this.WholeQtyPrice_Credit,
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.sellingPriceDataGridViewTextBoxColumn,
            this.qtyCreditDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.priceLevelCreditDataGridViewTextBoxColumn,
            this.priceLevelDataGridViewTextBoxColumn,
            this.markedPriceDataGridViewTextBoxColumn,
            this.wholePriceDataGridViewTextBoxColumn,
            this.wholeQtyCreditDataGridViewTextBoxColumn,
            this.wholeQtyDataGridViewTextBoxColumn,
            this.wholeQtyPriceCreditDataGridViewTextBoxColumn,
            this.wholeQtyPriceDataGridViewTextBoxColumn,
            this.purchasePriceDataGridViewTextBoxColumn,
            this.lnDataGridViewTextBoxColumn,
            this.priceBatchDataGridViewTextBoxColumn});
            this.dataGridViewProductPriceLevel.DataSource = this.dsPriceMasterDetailsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProductPriceLevel.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewProductPriceLevel.Location = new System.Drawing.Point(3, 98);
            this.dataGridViewProductPriceLevel.Name = "dataGridViewProductPriceLevel";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductPriceLevel.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewProductPriceLevel.RowHeadersWidth = 20;
            this.dataGridViewProductPriceLevel.Size = new System.Drawing.Size(825, 161);
            this.dataGridViewProductPriceLevel.TabIndex = 11;
            this.dataGridViewProductPriceLevel.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewProductPriceLevel_RowPrePaint);
            // 
            // PriceBatch
            // 
            this.PriceBatch.DataPropertyName = "PriceBatch";
            this.PriceBatch.HeaderText = "Price Batch";
            this.PriceBatch.Name = "PriceBatch";
            // 
            // Purchase_Price
            // 
            this.Purchase_Price.DataPropertyName = "Purchase_Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Purchase_Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Purchase_Price.FillWeight = 92.80743F;
            this.Purchase_Price.HeaderText = "Purchase Price";
            this.Purchase_Price.Name = "Purchase_Price";
            this.Purchase_Price.ReadOnly = true;
            // 
            // Marked_Price
            // 
            this.Marked_Price.DataPropertyName = "Marked_Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Marked_Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.Marked_Price.FillWeight = 98.73602F;
            this.Marked_Price.HeaderText = "Marked Price";
            this.Marked_Price.Name = "Marked_Price";
            this.Marked_Price.ReadOnly = true;
            // 
            // Whole_Price
            // 
            this.Whole_Price.DataPropertyName = "Whole_Price";
            this.Whole_Price.FillWeight = 108.6097F;
            this.Whole_Price.HeaderText = "Wholesale Price";
            this.Whole_Price.Name = "Whole_Price";
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "RT Qty";
            this.Qty.Name = "Qty";
            // 
            // Price_Level
            // 
            this.Price_Level.DataPropertyName = "Price_Level";
            this.Price_Level.HeaderText = "RT Price CASH";
            this.Price_Level.Name = "Price_Level";
            // 
            // Price_Level_Credit
            // 
            this.Price_Level_Credit.DataPropertyName = "Price_Level_Credit";
            this.Price_Level_Credit.HeaderText = "RT Price CREDIT";
            this.Price_Level_Credit.Name = "Price_Level_Credit";
            // 
            // WholeQty
            // 
            this.WholeQty.DataPropertyName = "WholeQty";
            this.WholeQty.HeaderText = "WS Qty";
            this.WholeQty.Name = "WholeQty";
            // 
            // WholeQtyPrice
            // 
            this.WholeQtyPrice.DataPropertyName = "WholeQtyPrice";
            this.WholeQtyPrice.HeaderText = "WS Price CASH";
            this.WholeQtyPrice.Name = "WholeQtyPrice";
            // 
            // WholeQtyPrice_Credit
            // 
            this.WholeQtyPrice_Credit.DataPropertyName = "WholeQtyPrice_Credit";
            this.WholeQtyPrice_Credit.HeaderText = "WS Price CREDIT";
            this.WholeQtyPrice_Credit.Name = "WholeQtyPrice_Credit";
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_Price";
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling_Price";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            // 
            // qtyCreditDataGridViewTextBoxColumn
            // 
            this.qtyCreditDataGridViewTextBoxColumn.DataPropertyName = "Qty_Credit";
            this.qtyCreditDataGridViewTextBoxColumn.HeaderText = "Qty_Credit";
            this.qtyCreditDataGridViewTextBoxColumn.Name = "qtyCreditDataGridViewTextBoxColumn";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            // 
            // priceLevelCreditDataGridViewTextBoxColumn
            // 
            this.priceLevelCreditDataGridViewTextBoxColumn.DataPropertyName = "Price_Level_Credit";
            this.priceLevelCreditDataGridViewTextBoxColumn.HeaderText = "Price_Level_Credit";
            this.priceLevelCreditDataGridViewTextBoxColumn.Name = "priceLevelCreditDataGridViewTextBoxColumn";
            // 
            // priceLevelDataGridViewTextBoxColumn
            // 
            this.priceLevelDataGridViewTextBoxColumn.DataPropertyName = "Price_Level";
            this.priceLevelDataGridViewTextBoxColumn.HeaderText = "Price_Level";
            this.priceLevelDataGridViewTextBoxColumn.Name = "priceLevelDataGridViewTextBoxColumn";
            // 
            // markedPriceDataGridViewTextBoxColumn
            // 
            this.markedPriceDataGridViewTextBoxColumn.DataPropertyName = "Marked_Price";
            this.markedPriceDataGridViewTextBoxColumn.HeaderText = "Marked_Price";
            this.markedPriceDataGridViewTextBoxColumn.Name = "markedPriceDataGridViewTextBoxColumn";
            // 
            // wholePriceDataGridViewTextBoxColumn
            // 
            this.wholePriceDataGridViewTextBoxColumn.DataPropertyName = "Whole_Price";
            this.wholePriceDataGridViewTextBoxColumn.HeaderText = "Whole_Price";
            this.wholePriceDataGridViewTextBoxColumn.Name = "wholePriceDataGridViewTextBoxColumn";
            // 
            // wholeQtyCreditDataGridViewTextBoxColumn
            // 
            this.wholeQtyCreditDataGridViewTextBoxColumn.DataPropertyName = "WholeQty_Credit";
            this.wholeQtyCreditDataGridViewTextBoxColumn.HeaderText = "WholeQty_Credit";
            this.wholeQtyCreditDataGridViewTextBoxColumn.Name = "wholeQtyCreditDataGridViewTextBoxColumn";
            // 
            // wholeQtyDataGridViewTextBoxColumn
            // 
            this.wholeQtyDataGridViewTextBoxColumn.DataPropertyName = "WholeQty";
            this.wholeQtyDataGridViewTextBoxColumn.HeaderText = "WholeQty";
            this.wholeQtyDataGridViewTextBoxColumn.Name = "wholeQtyDataGridViewTextBoxColumn";
            // 
            // wholeQtyPriceCreditDataGridViewTextBoxColumn
            // 
            this.wholeQtyPriceCreditDataGridViewTextBoxColumn.DataPropertyName = "WholeQtyPrice_Credit";
            this.wholeQtyPriceCreditDataGridViewTextBoxColumn.HeaderText = "WholeQtyPrice_Credit";
            this.wholeQtyPriceCreditDataGridViewTextBoxColumn.Name = "wholeQtyPriceCreditDataGridViewTextBoxColumn";
            // 
            // wholeQtyPriceDataGridViewTextBoxColumn
            // 
            this.wholeQtyPriceDataGridViewTextBoxColumn.DataPropertyName = "WholeQtyPrice";
            this.wholeQtyPriceDataGridViewTextBoxColumn.HeaderText = "WholeQtyPrice";
            this.wholeQtyPriceDataGridViewTextBoxColumn.Name = "wholeQtyPriceDataGridViewTextBoxColumn";
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_Price";
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "Purchase_Price";
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            // 
            // lnDataGridViewTextBoxColumn
            // 
            this.lnDataGridViewTextBoxColumn.DataPropertyName = "Ln";
            this.lnDataGridViewTextBoxColumn.HeaderText = "Ln";
            this.lnDataGridViewTextBoxColumn.Name = "lnDataGridViewTextBoxColumn";
            // 
            // priceBatchDataGridViewTextBoxColumn
            // 
            this.priceBatchDataGridViewTextBoxColumn.DataPropertyName = "PriceBatch";
            this.priceBatchDataGridViewTextBoxColumn.HeaderText = "PriceBatch";
            this.priceBatchDataGridViewTextBoxColumn.Name = "priceBatchDataGridViewTextBoxColumn";
            // 
            // dsPriceMasterDetailsBindingSource
            // 
            this.dsPriceMasterDetailsBindingSource.DataMember = "dsPriceMasterDetails";
            this.dsPriceMasterDetailsBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmProductPriceLevelDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 263);
            this.Controls.Add(this.dataGridViewProductPriceLevel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProductPriceLevelDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Price Level Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductPriceLevelDetails_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPriceMasterDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label lblLastPurPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtWholeSalePrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMarkedPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Label lblPurchasingPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        public System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.DataGridView dataGridViewProductPriceLevel;
        private System.Windows.Forms.BindingSource dsPriceMasterDetailsBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Purchase_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marked_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Whole_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price_Level_Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholeQtyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholeQtyPrice_Credit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCreditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceLevelCreditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markedPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholeQtyCreditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholeQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholeQtyPriceCreditDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholeQtyPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceBatchDataGridViewTextBoxColumn;
    }
}