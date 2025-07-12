namespace Inventory
{
    partial class frmProductShortCodeDialog
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
            this.dgProductDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductDetails
            // 
            this.dgProductDetails.AllowUserToAddRows = false;
            this.dgProductDetails.AllowUserToDeleteRows = false;
            this.dgProductDetails.AllowUserToResizeRows = false;
            this.dgProductDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductDetails.Location = new System.Drawing.Point(2, 2);
            this.dgProductDetails.Name = "dgProductDetails";
            this.dgProductDetails.ReadOnly = true;
            this.dgProductDetails.RowHeadersWidth = 20;
            this.dgProductDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductDetails.Size = new System.Drawing.Size(657, 222);
            this.dgProductDetails.TabIndex = 0;
            this.dgProductDetails.DoubleClick += new System.EventHandler(this.dgProductPriceLevel_DoubleClick);
            this.dgProductDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProductPriceLevel_KeyDown);
            // 
            // frmProductShortCodeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 226);
            this.Controls.Add(this.dgProductDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductShortCodeDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Short Code";
            this.Load += new System.EventHandler(this.frmProductShortCodeDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductPriceLevel_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgProductDetails;

    }
}