namespace Inventory
{
    partial class frmScaleUpdate
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
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblmsge = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoad
            // 
            this.picLoad.Image = global::Inventory.Properties.Resources.loading;
            this.picLoad.Location = new System.Drawing.Point(130, 32);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(121, 117);
            this.picLoad.TabIndex = 0;
            this.picLoad.TabStop = false;
            this.picLoad.Visible = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(31, 169);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(99, 49);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblmsge
            // 
            this.lblmsge.BackColor = System.Drawing.Color.Transparent;
            this.lblmsge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsge.Location = new System.Drawing.Point(12, 74);
            this.lblmsge.Name = "lblmsge";
            this.lblmsge.Size = new System.Drawing.Size(348, 46);
            this.lblmsge.TabIndex = 2;
            this.lblmsge.Text = "To Upload All Scale Items to the Scale,                       Press Upload Button" +
                "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(249, 169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 49);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmScaleUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(372, 238);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblmsge);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.picLoad);
            this.MaximizeBox = false;
            this.Name = "frmScaleUpdate";
            this.Text = "Date Upload to Scale";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScaleUpdate_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoad;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblmsge;
        private System.Windows.Forms.Button btnExit;
    }
}