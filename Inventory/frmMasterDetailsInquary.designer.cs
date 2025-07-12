namespace Inventory
{
    partial class frmMasterDetailsInquary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterDetailsInquary));
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtDescriptionTo = new System.Windows.Forms.TextBox();
            this.txtDescriptionFrom = new System.Windows.Forms.TextBox();
            this.txtCodeTo = new System.Windows.Forms.TextBox();
            this.txtCodeFrom = new System.Windows.Forms.TextBox();
            this.lblCodeTo = new System.Windows.Forms.Label();
            this.lblCodeFrom = new System.Windows.Forms.Label();
            this.btnSearchCodeTo = new System.Windows.Forms.Button();
            this.btnSearchCodeFrom = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.rbByCode = new System.Windows.Forms.RadioButton();
            this.rbByDescrip = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(106, 116);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 50);
            this.btnDisplay.TabIndex = 7;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(344, 117);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 109);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(460, 65);
            this.toolStrip1.TabIndex = 130;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtDescriptionTo
            // 
            this.txtDescriptionTo.Location = new System.Drawing.Point(197, 51);
            this.txtDescriptionTo.Name = "txtDescriptionTo";
            this.txtDescriptionTo.Size = new System.Drawing.Size(217, 20);
            this.txtDescriptionTo.TabIndex = 5;
            // 
            // txtDescriptionFrom
            // 
            this.txtDescriptionFrom.Location = new System.Drawing.Point(198, 11);
            this.txtDescriptionFrom.Name = "txtDescriptionFrom";
            this.txtDescriptionFrom.Size = new System.Drawing.Size(217, 20);
            this.txtDescriptionFrom.TabIndex = 2;
            // 
            // txtCodeTo
            // 
            this.txtCodeTo.Location = new System.Drawing.Point(72, 51);
            this.txtCodeTo.Name = "txtCodeTo";
            this.txtCodeTo.Size = new System.Drawing.Size(122, 20);
            this.txtCodeTo.TabIndex = 4;
            this.txtCodeTo.Enter += new System.EventHandler(this.txtCodeTo_Enter);
            // 
            // txtCodeFrom
            // 
            this.txtCodeFrom.Location = new System.Drawing.Point(72, 11);
            this.txtCodeFrom.Name = "txtCodeFrom";
            this.txtCodeFrom.Size = new System.Drawing.Size(123, 20);
            this.txtCodeFrom.TabIndex = 1;
            this.txtCodeFrom.Enter += new System.EventHandler(this.txtCodeFrom_Enter);
            // 
            // lblCodeTo
            // 
            this.lblCodeTo.AutoSize = true;
            this.lblCodeTo.Location = new System.Drawing.Point(8, 51);
            this.lblCodeTo.Name = "lblCodeTo";
            this.lblCodeTo.Size = new System.Drawing.Size(48, 13);
            this.lblCodeTo.TabIndex = 123;
            this.lblCodeTo.Text = "Code To";
            // 
            // lblCodeFrom
            // 
            this.lblCodeFrom.AutoSize = true;
            this.lblCodeFrom.Location = new System.Drawing.Point(8, 14);
            this.lblCodeFrom.Name = "lblCodeFrom";
            this.lblCodeFrom.Size = new System.Drawing.Size(58, 13);
            this.lblCodeFrom.TabIndex = 122;
            this.lblCodeFrom.Text = "Code From";
            // 
            // btnSearchCodeTo
            // 
            this.btnSearchCodeTo.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCodeTo.Image")));
            this.btnSearchCodeTo.Location = new System.Drawing.Point(420, 51);
            this.btnSearchCodeTo.Name = "btnSearchCodeTo";
            this.btnSearchCodeTo.Size = new System.Drawing.Size(28, 21);
            this.btnSearchCodeTo.TabIndex = 6;
            this.btnSearchCodeTo.UseVisualStyleBackColor = true;
            this.btnSearchCodeTo.Click += new System.EventHandler(this.btnSearchCodeTo_Click);
            // 
            // btnSearchCodeFrom
            // 
            this.btnSearchCodeFrom.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCodeFrom.Image")));
            this.btnSearchCodeFrom.Location = new System.Drawing.Point(420, 11);
            this.btnSearchCodeFrom.Name = "btnSearchCodeFrom";
            this.btnSearchCodeFrom.Size = new System.Drawing.Size(28, 21);
            this.btnSearchCodeFrom.TabIndex = 3;
            this.btnSearchCodeFrom.UseVisualStyleBackColor = true;
            this.btnSearchCodeFrom.Click += new System.EventHandler(this.btnSearchCodeFrom_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(225, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 50);
            this.btnClear.TabIndex = 131;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rbByCode
            // 
            this.rbByCode.AutoSize = true;
            this.rbByCode.Location = new System.Drawing.Point(171, 81);
            this.rbByCode.Name = "rbByCode";
            this.rbByCode.Size = new System.Drawing.Size(86, 17);
            this.rbByCode.TabIndex = 132;
            this.rbByCode.TabStop = true;
            this.rbByCode.Text = "Sort by Code";
            this.rbByCode.UseVisualStyleBackColor = true;
            this.rbByCode.Visible = false;
            this.rbByCode.CheckedChanged += new System.EventHandler(this.rbByCode_CheckedChanged);
            // 
            // rbByDescrip
            // 
            this.rbByDescrip.AutoSize = true;
            this.rbByDescrip.Location = new System.Drawing.Point(301, 81);
            this.rbByDescrip.Name = "rbByDescrip";
            this.rbByDescrip.Size = new System.Drawing.Size(114, 17);
            this.rbByDescrip.TabIndex = 133;
            this.rbByDescrip.TabStop = true;
            this.rbByDescrip.Text = "Sort by Description";
            this.rbByDescrip.UseVisualStyleBackColor = true;
            this.rbByDescrip.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(72, 82);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 134;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmMasterDetailsInquary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(460, 174);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.rbByDescrip);
            this.Controls.Add(this.rbByCode);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnSearchCodeTo);
            this.Controls.Add(this.btnSearchCodeFrom);
            this.Controls.Add(this.txtDescriptionTo);
            this.Controls.Add(this.txtDescriptionFrom);
            this.Controls.Add(this.txtCodeTo);
            this.Controls.Add(this.txtCodeFrom);
            this.Controls.Add(this.lblCodeTo);
            this.Controls.Add(this.lblCodeFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMasterDetailsInquary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Details Inquary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMasterDetailsInquary_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMasterDetailsInquary_KeyDown);
            this.Load += new System.EventHandler(this.frmMasterDetailsInquary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnSearchCodeTo;
        private System.Windows.Forms.Button btnSearchCodeFrom;
        private System.Windows.Forms.TextBox txtDescriptionTo;
        private System.Windows.Forms.TextBox txtDescriptionFrom;
        private System.Windows.Forms.TextBox txtCodeTo;
        private System.Windows.Forms.TextBox txtCodeFrom;
        private System.Windows.Forms.Label lblCodeTo;
        private System.Windows.Forms.Label lblCodeFrom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rbByCode;
        private System.Windows.Forms.RadioButton rbByDescrip;
        private System.Windows.Forms.CheckBox chkAll;
    }
}