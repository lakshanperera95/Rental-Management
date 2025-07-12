namespace Inventory
{
    partial class frmPrinterSettings
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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudDocPrinterPrintCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomPaperName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInstalledDocPrinterList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudPosPrinterPrintCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInstalledPosPrinterList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.TextBox();
            this.rbRec = new System.Windows.Forms.RadioButton();
            this.rbDual = new System.Windows.Forms.RadioButton();
            this.rbPos = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocPrinterPrintCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosPrinterPrintCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnApply.Location = new System.Drawing.Point(433, 365);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(532, 365);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Location = new System.Drawing.Point(0, 358);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(640, 66);
            this.toolStrip3.TabIndex = 4;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudDocPrinterPrintCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomPaperName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbInstalledDocPrinterList);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receipt Printer";
            // 
            // nudDocPrinterPrintCount
            // 
            this.nudDocPrinterPrintCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudDocPrinterPrintCount.Location = new System.Drawing.Point(144, 76);
            this.nudDocPrinterPrintCount.Name = "nudDocPrinterPrintCount";
            this.nudDocPrinterPrintCount.Size = new System.Drawing.Size(67, 22);
            this.nudDocPrinterPrintCount.TabIndex = 2;
            this.nudDocPrinterPrintCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Print Count :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Custom Paper Name :";
            // 
            // txtCustomPaperName
            // 
            this.txtCustomPaperName.Location = new System.Drawing.Point(144, 48);
            this.txtCustomPaperName.Name = "txtCustomPaperName";
            this.txtCustomPaperName.Size = new System.Drawing.Size(129, 22);
            this.txtCustomPaperName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Receipt Printer Name :";
            // 
            // cmbInstalledDocPrinterList
            // 
            this.cmbInstalledDocPrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstalledDocPrinterList.FormattingEnabled = true;
            this.cmbInstalledDocPrinterList.Location = new System.Drawing.Point(144, 21);
            this.cmbInstalledDocPrinterList.Name = "cmbInstalledDocPrinterList";
            this.cmbInstalledDocPrinterList.Size = new System.Drawing.Size(445, 21);
            this.cmbInstalledDocPrinterList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudPosPrinterPrintCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbInstalledPosPrinterList);
            this.groupBox2.Location = new System.Drawing.Point(12, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 111);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pos Printer";
            // 
            // nudPosPrinterPrintCount
            // 
            this.nudPosPrinterPrintCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPosPrinterPrintCount.Location = new System.Drawing.Point(144, 48);
            this.nudPosPrinterPrintCount.Name = "nudPosPrinterPrintCount";
            this.nudPosPrinterPrintCount.Size = new System.Drawing.Size(67, 22);
            this.nudPosPrinterPrintCount.TabIndex = 1;
            this.nudPosPrinterPrintCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Print Count :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pos Printer Name :";
            // 
            // cmbInstalledPosPrinterList
            // 
            this.cmbInstalledPosPrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstalledPosPrinterList.FormattingEnabled = true;
            this.cmbInstalledPosPrinterList.Location = new System.Drawing.Point(144, 21);
            this.cmbInstalledPosPrinterList.Name = "cmbInstalledPosPrinterList";
            this.cmbInstalledPosPrinterList.Size = new System.Drawing.Size(445, 21);
            this.cmbInstalledPosPrinterList.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Machine Name :";
            // 
            // lblMachineName
            // 
            this.lblMachineName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineName.Location = new System.Drawing.Point(107, 11);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.ReadOnly = true;
            this.lblMachineName.Size = new System.Drawing.Size(264, 23);
            this.lblMachineName.TabIndex = 10;
            this.lblMachineName.Text = "MACHINE NAME";
            // 
            // rbRec
            // 
            this.rbRec.AutoSize = true;
            this.rbRec.Location = new System.Drawing.Point(487, 11);
            this.rbRec.Name = "rbRec";
            this.rbRec.Size = new System.Drawing.Size(100, 17);
            this.rbRec.TabIndex = 11;
            this.rbRec.Text = "Receipt Printer";
            this.rbRec.UseVisualStyleBackColor = true;
            this.rbRec.CheckedChanged += new System.EventHandler(this.rbRec_CheckedChanged);
            // 
            // rbDual
            // 
            this.rbDual.AutoSize = true;
            this.rbDual.Checked = true;
            this.rbDual.Location = new System.Drawing.Point(487, 54);
            this.rbDual.Name = "rbDual";
            this.rbDual.Size = new System.Drawing.Size(86, 17);
            this.rbDual.TabIndex = 12;
            this.rbDual.TabStop = true;
            this.rbDual.Text = "Dual Printer";
            this.rbDual.UseVisualStyleBackColor = true;
            // 
            // rbPos
            // 
            this.rbPos.AutoSize = true;
            this.rbPos.Location = new System.Drawing.Point(487, 31);
            this.rbPos.Name = "rbPos";
            this.rbPos.Size = new System.Drawing.Size(80, 17);
            this.rbPos.TabIndex = 13;
            this.rbPos.Text = "Pos Printer";
            this.rbPos.UseVisualStyleBackColor = true;
            // 
            // frmPrinterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(640, 424);
            this.Controls.Add(this.rbDual);
            this.Controls.Add(this.rbPos);
            this.Controls.Add(this.rbRec);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.toolStrip3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrinterSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Settings";
            this.Load += new System.EventHandler(this.Bill_Frm_PrinterSettings_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bill_Frm_PrinterSettings_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocPrinterPrintCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosPrinterPrintCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbInstalledDocPrinterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInstalledPosPrinterList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomPaperName;
        private System.Windows.Forms.NumericUpDown nudDocPrinterPrintCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPosPrinterPrintCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblMachineName;
        private System.Windows.Forms.RadioButton rbRec;
        private System.Windows.Forms.RadioButton rbDual;
        private System.Windows.Forms.RadioButton rbPos;
    }
}