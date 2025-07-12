namespace Inventory
{
    partial class frmSerialNoSelect
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
            this.dgSerialNumber = new System.Windows.Forms.DataGridView();
            this.serialNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsSerialNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.dtPriceLevSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtForGrids = new Inventory.dtForGrids();
            ((System.ComponentModel.ISupportInitialize)(this.dgSerialNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSerialNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPriceLevSelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtForGrids)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSerialNumber
            // 
            this.dgSerialNumber.AllowUserToAddRows = false;
            this.dgSerialNumber.AllowUserToDeleteRows = false;
            this.dgSerialNumber.AllowUserToResizeRows = false;
            this.dgSerialNumber.AutoGenerateColumns = false;
            this.dgSerialNumber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSerialNumber.BackgroundColor = System.Drawing.Color.White;
            this.dgSerialNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSerialNumber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNoDataGridViewTextBoxColumn});
            this.dgSerialNumber.DataSource = this.dsSerialNoBindingSource;
            this.dgSerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSerialNumber.GridColor = System.Drawing.Color.White;
            this.dgSerialNumber.Location = new System.Drawing.Point(0, 0);
            this.dgSerialNumber.Name = "dgSerialNumber";
            this.dgSerialNumber.ReadOnly = true;
            this.dgSerialNumber.RowHeadersWidth = 25;
            this.dgSerialNumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSerialNumber.Size = new System.Drawing.Size(265, 294);
            this.dgSerialNumber.TabIndex = 0;
            this.dgSerialNumber.DoubleClick += new System.EventHandler(this.dgSerialNumber_DoubleClick);
            this.dgSerialNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSerialNumber_KeyDown);
            // 
            // serialNoDataGridViewTextBoxColumn
            // 
            this.serialNoDataGridViewTextBoxColumn.DataPropertyName = "SerialNo";
            this.serialNoDataGridViewTextBoxColumn.HeaderText = "Serial Number";
            this.serialNoDataGridViewTextBoxColumn.Name = "serialNoDataGridViewTextBoxColumn";
            this.serialNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsSerialNoBindingSource
            // 
            this.dsSerialNoBindingSource.DataMember = "dsSerialNo";
            this.dsSerialNoBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtPriceLevSelectBindingSource
            // 
            this.dtPriceLevSelectBindingSource.DataMember = "dtPriceLevSelect";
            this.dtPriceLevSelectBindingSource.DataSource = this.dtForGrids;
            // 
            // dtForGrids
            // 
            this.dtForGrids.DataSetName = "dtForGrids";
            this.dtForGrids.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmSerialNoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 294);
            this.Controls.Add(this.dgSerialNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSerialNoSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Number";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSerialNoSelect_FormClosed);
            this.Load += new System.EventHandler(this.frmSerialNoSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSerialNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSerialNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPriceLevSelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtForGrids)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgSerialNumber;
        private System.Windows.Forms.BindingSource dtPriceLevSelectBindingSource;
        private dtForGrids dtForGrids;
        private System.Windows.Forms.BindingSource dsSerialNoBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNoDataGridViewTextBoxColumn;
    }
}