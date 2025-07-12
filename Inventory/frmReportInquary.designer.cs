namespace OnimtaGiftVoucherSystem
{
    partial class frmReportInquary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportInquary));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchCodeTo = new System.Windows.Forms.Button();
            this.btnSearchCodeFrom = new System.Windows.Forms.Button();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameTo = new System.Windows.Forms.TextBox();
            this.txtCodeTo = new System.Windows.Forms.TextBox();
            this.txtNameFrom = new System.Windows.Forms.TextBox();
            this.txtCodeFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plTitalBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new OnimtaGiftVoucherSystem.ButtonClear();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.plTitalBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.plTitalBar);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.GifTool;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnDisplay);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Location = new System.Drawing.Point(0, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(549, 67);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(239, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDisplay.BackgroundImage")));
            this.btnDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.ForeColor = System.Drawing.Color.Black;
            this.btnDisplay.Location = new System.Drawing.Point(40, 14);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 38);
            this.btnDisplay.TabIndex = 3;
            this.btnDisplay.Text = "&Display";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            this.btnDisplay.MouseEnter += new System.EventHandler(this.btnDisplay_MouseEnter);
            this.btnDisplay.MouseLeave += new System.EventHandler(this.btnDisplay_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(437, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchCodeTo);
            this.groupBox2.Controls.Add(this.btnSearchCodeFrom);
            this.groupBox2.Controls.Add(this.dtDateTo);
            this.groupBox2.Controls.Add(this.dtDateFrom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNameTo);
            this.groupBox2.Controls.Add(this.txtCodeTo);
            this.groupBox2.Controls.Add(this.txtNameFrom);
            this.groupBox2.Controls.Add(this.txtCodeFrom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(5, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 148);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnSearchCodeTo
            // 
            this.btnSearchCodeTo.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSearchCodeTo.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.View;
            this.btnSearchCodeTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchCodeTo.Location = new System.Drawing.Point(492, 60);
            this.btnSearchCodeTo.Name = "btnSearchCodeTo";
            this.btnSearchCodeTo.Size = new System.Drawing.Size(25, 22);
            this.btnSearchCodeTo.TabIndex = 21;
            this.btnSearchCodeTo.Text = "...";
            this.btnSearchCodeTo.UseVisualStyleBackColor = false;
            this.btnSearchCodeTo.Click += new System.EventHandler(this.btnSearchCodeTo_Click);
            // 
            // btnSearchCodeFrom
            // 
            this.btnSearchCodeFrom.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSearchCodeFrom.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.View;
            this.btnSearchCodeFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchCodeFrom.Location = new System.Drawing.Point(492, 25);
            this.btnSearchCodeFrom.Name = "btnSearchCodeFrom";
            this.btnSearchCodeFrom.Size = new System.Drawing.Size(25, 22);
            this.btnSearchCodeFrom.TabIndex = 20;
            this.btnSearchCodeFrom.Text = "...";
            this.btnSearchCodeFrom.UseVisualStyleBackColor = false;
            this.btnSearchCodeFrom.Click += new System.EventHandler(this.btnSearchCodeFrom_Click);
            // 
            // dtDateTo
            // 
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateTo.Location = new System.Drawing.Point(337, 106);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(110, 20);
            this.dtDateTo.TabIndex = 9;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateFrom.Location = new System.Drawing.Point(136, 106);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(110, 20);
            this.dtDateFrom.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date From";
            // 
            // txtNameTo
            // 
            this.txtNameTo.Location = new System.Drawing.Point(214, 62);
            this.txtNameTo.Name = "txtNameTo";
            this.txtNameTo.Size = new System.Drawing.Size(268, 20);
            this.txtNameTo.TabIndex = 5;
            // 
            // txtCodeTo
            // 
            this.txtCodeTo.Location = new System.Drawing.Point(89, 62);
            this.txtCodeTo.Name = "txtCodeTo";
            this.txtCodeTo.Size = new System.Drawing.Size(119, 20);
            this.txtCodeTo.TabIndex = 4;
            // 
            // txtNameFrom
            // 
            this.txtNameFrom.Location = new System.Drawing.Point(214, 27);
            this.txtNameFrom.Name = "txtNameFrom";
            this.txtNameFrom.Size = new System.Drawing.Size(268, 20);
            this.txtNameFrom.TabIndex = 3;
            // 
            // txtCodeFrom
            // 
            this.txtCodeFrom.Location = new System.Drawing.Point(89, 27);
            this.txtCodeFrom.Name = "txtCodeFrom";
            this.txtCodeFrom.Size = new System.Drawing.Size(119, 20);
            this.txtCodeFrom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Code To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Code From";
            // 
            // plTitalBar
            // 
            this.plTitalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plTitalBar.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.GifTool;
            this.plTitalBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plTitalBar.Controls.Add(this.btnClose);
            this.plTitalBar.Controls.Add(this.btnMinimize);
            this.plTitalBar.Controls.Add(this.lblFormHeader);
            this.plTitalBar.Location = new System.Drawing.Point(0, 0);
            this.plTitalBar.Name = "plTitalBar";
            this.plTitalBar.Size = new System.Drawing.Size(550, 32);
            this.plTitalBar.TabIndex = 2;
            this.plTitalBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plTitalBar_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::OnimtaGiftVoucherSystem.Properties.Resources.ClosingButtonSmall;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(523, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 20;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimize.FormMinimize = null;
            this.btnMinimize.Location = new System.Drawing.Point(501, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(18, 18);
            this.btnMinimize.TabIndex = 18;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblFormHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.White;
            this.lblFormHeader.Location = new System.Drawing.Point(10, 7);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(0, 14);
            this.lblFormHeader.TabIndex = 19;
            // 
            // frmReportInquary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(555, 260);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportInquary";
            this.Text = "frmReportInquary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReportInquary_FormClosed);
            this.Load += new System.EventHandler(this.frmReportInquary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.plTitalBar.ResumeLayout(false);
            this.plTitalBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel plTitalBar;
        private ButtonClear btnMinimize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.TextBox txtCodeFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameTo;
        private System.Windows.Forms.TextBox txtCodeTo;
        private System.Windows.Forms.TextBox txtNameFrom;
        private System.Windows.Forms.Button btnSearchCodeTo;
        private System.Windows.Forms.Button btnSearchCodeFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClose;
    }
}