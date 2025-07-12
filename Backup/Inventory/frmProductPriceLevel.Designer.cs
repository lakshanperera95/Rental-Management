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
            this.dgProductPriceLevel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductPriceLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductPriceLevel
            // 
            this.dgProductPriceLevel.AllowUserToAddRows = false;
            this.dgProductPriceLevel.AllowUserToDeleteRows = false;
            this.dgProductPriceLevel.AllowUserToResizeRows = false;
            this.dgProductPriceLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductPriceLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductPriceLevel.Location = new System.Drawing.Point(2, 2);
            this.dgProductPriceLevel.Name = "dgProductPriceLevel";
            this.dgProductPriceLevel.ReadOnly = true;
            this.dgProductPriceLevel.RowHeadersWidth = 25;
            this.dgProductPriceLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductPriceLevel.Size = new System.Drawing.Size(336, 222);
            this.dgProductPriceLevel.TabIndex = 0;
            this.dgProductPriceLevel.DoubleClick += new System.EventHandler(this.dgProductPriceLevel_DoubleClick);
            this.dgProductPriceLevel.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgProductPriceLevel_RowPrePaint);
            this.dgProductPriceLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProductPriceLevel_KeyDown);
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
            this.Load += new System.EventHandler(this.frmProductPriceLevel_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductPriceLevel_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductPriceLevel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductPriceLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgProductPriceLevel;

    }
}