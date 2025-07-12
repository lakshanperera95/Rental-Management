namespace Inventory
{
    partial class frmProductPriceLevel
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
            this.dgProductPriceLevel = new System.Windows.Forms.DataGridView();
            this.dtForGrids = new Inventory.dtForGrids();
            this.dtPriceLevSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markedPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductPriceLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtForGrids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPriceLevSelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductPriceLevel
            // 
            this.dgProductPriceLevel.AllowUserToAddRows = false;
            this.dgProductPriceLevel.AllowUserToDeleteRows = false;
            this.dgProductPriceLevel.AllowUserToResizeRows = false;
            this.dgProductPriceLevel.AutoGenerateColumns = false;
            this.dgProductPriceLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductPriceLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductPriceLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sellingPriceDataGridViewTextBoxColumn,
            this.markedPriceDataGridViewTextBoxColumn,
            this.purchasepriceDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
            this.dgProductPriceLevel.DataSource = this.dtPriceLevSelectBindingSource;
            this.dgProductPriceLevel.Location = new System.Drawing.Point(2, 2);
            this.dgProductPriceLevel.Name = "dgProductPriceLevel";
            this.dgProductPriceLevel.ReadOnly = true;
            this.dgProductPriceLevel.RowHeadersWidth = 25;
            this.dgProductPriceLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductPriceLevel.Size = new System.Drawing.Size(336, 222);
            this.dgProductPriceLevel.TabIndex = 0;
            this.dgProductPriceLevel.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgProductPriceLevel_RowPrePaint);
            this.dgProductPriceLevel.DoubleClick += new System.EventHandler(this.dgProductPriceLevel_DoubleClick);
            this.dgProductPriceLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProductPriceLevel_KeyDown);
            // 
            // dtForGrids
            // 
            this.dtForGrids.DataSetName = "dtForGrids";
            this.dtForGrids.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtPriceLevSelectBindingSource
            // 
            this.dtPriceLevSelectBindingSource.DataMember = "dtPriceLevSelect";
            this.dtPriceLevSelectBindingSource.DataSource = this.dtForGrids;
            // 
            // sellingPriceDataGridViewTextBoxColumn
            // 
            this.sellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Selling_Price";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sellingPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.sellingPriceDataGridViewTextBoxColumn.HeaderText = "Selling Price";
            this.sellingPriceDataGridViewTextBoxColumn.Name = "sellingPriceDataGridViewTextBoxColumn";
            this.sellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // markedPriceDataGridViewTextBoxColumn
            // 
            this.markedPriceDataGridViewTextBoxColumn.DataPropertyName = "Marked_Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.markedPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.markedPriceDataGridViewTextBoxColumn.HeaderText = "Marked Price";
            this.markedPriceDataGridViewTextBoxColumn.Name = "markedPriceDataGridViewTextBoxColumn";
            this.markedPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasepriceDataGridViewTextBoxColumn
            // 
            this.purchasepriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_price";
            this.purchasepriceDataGridViewTextBoxColumn.HeaderText = "Purchase_price";
            this.purchasepriceDataGridViewTextBoxColumn.Name = "purchasepriceDataGridViewTextBoxColumn";
            this.purchasepriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchasepriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmProductPriceLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 226);
            this.Controls.Add(this.dgProductPriceLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductPriceLevel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Price Level";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductPriceLevel_FormClosed);
            this.Load += new System.EventHandler(this.frmProductPriceLevel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductPriceLevel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductPriceLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtForGrids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPriceLevSelectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgProductPriceLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markedPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dtPriceLevSelectBindingSource;
        private dtForGrids dtForGrids;
    }
}