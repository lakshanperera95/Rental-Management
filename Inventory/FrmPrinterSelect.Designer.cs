namespace Inventory
{
    partial class FrmPrinterSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPos = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDoc.SuspendLayout();
            this.pnlPos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press Left Arrow Key For Pos Printer. Right Arrow Key For Document Printer";
            // 
            // pnlDoc
            // 
            this.pnlDoc.BackgroundImage = global::Inventory.Properties.Resources._13;
            this.pnlDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlDoc.Controls.Add(this.label3);
            this.pnlDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDoc.Location = new System.Drawing.Point(192, 8);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(168, 168);
            this.pnlDoc.TabIndex = 4;
            this.pnlDoc.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDoc_Paint);
            this.pnlDoc.Click += new System.EventHandler(this.pnlDoc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "DOCUMENT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pnlPos
            // 
            this.pnlPos.BackgroundImage = global::Inventory.Properties.Resources._12;
            this.pnlPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlPos.Controls.Add(this.label2);
            this.pnlPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlPos.Location = new System.Drawing.Point(8, 8);
            this.pnlPos.Name = "pnlPos";
            this.pnlPos.Size = new System.Drawing.Size(168, 168);
            this.pnlPos.TabIndex = 3;
            this.pnlPos.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPos_Paint);
            this.pnlPos.Click += new System.EventHandler(this.pnlPos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(96, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "POS";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FrmPrinterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(367, 211);
            this.Controls.Add(this.pnlDoc);
            this.Controls.Add(this.pnlPos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPrinterSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Select";
            this.Load += new System.EventHandler(this.FrmPrinterSelect_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrinterSelect_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrinterSelect_KeyDown);
            this.pnlDoc.ResumeLayout(false);
            this.pnlDoc.PerformLayout();
            this.pnlPos.ResumeLayout(false);
            this.pnlPos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDoc;
        private System.Windows.Forms.Label label3;
    }
}