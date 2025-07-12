namespace Inventory
{
    partial class frmUserRole
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
            this.trvMenuList = new System.Windows.Forms.TreeView();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.rdbEditExisting = new System.Windows.Forms.RadioButton();
            this.rdbCreateNew = new System.Windows.Forms.RadioButton();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpAdvance = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkBatchPriceUpdate = new System.Windows.Forms.CheckBox();
            this.chkProdSave = new System.Windows.Forms.CheckBox();
            this.chkCrDeOpBalPassword = new System.Windows.Forms.CheckBox();
            this.chkTOGApply = new System.Windows.Forms.CheckBox();
            this.chkSRNApply = new System.Windows.Forms.CheckBox();
            this.chkPOApply = new System.Windows.Forms.CheckBox();
            this.chkGRNApply = new System.Windows.Forms.CheckBox();
            this.chkAllowDiscs = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdvancePercentage = new System.Windows.Forms.NumericUpDown();
            this.chkBillRePrint = new System.Windows.Forms.CheckBox();
            this.grpAdvance.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdvancePercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // trvMenuList
            // 
            this.trvMenuList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.trvMenuList.CheckBoxes = true;
            this.trvMenuList.Location = new System.Drawing.Point(12, 65);
            this.trvMenuList.Name = "trvMenuList";
            this.trvMenuList.Size = new System.Drawing.Size(469, 447);
            this.trvMenuList.TabIndex = 0;
            this.trvMenuList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvMenuList_AfterCheck);
            // 
            // txtUserRole
            // 
            this.txtUserRole.Location = new System.Drawing.Point(214, 25);
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.Size = new System.Drawing.Size(154, 20);
            this.txtUserRole.TabIndex = 10;
            // 
            // rdbEditExisting
            // 
            this.rdbEditExisting.AutoSize = true;
            this.rdbEditExisting.Checked = true;
            this.rdbEditExisting.Location = new System.Drawing.Point(112, 26);
            this.rdbEditExisting.Name = "rdbEditExisting";
            this.rdbEditExisting.Size = new System.Drawing.Size(82, 17);
            this.rdbEditExisting.TabIndex = 9;
            this.rdbEditExisting.TabStop = true;
            this.rdbEditExisting.Text = "Edit Existing";
            this.rdbEditExisting.UseVisualStyleBackColor = true;
            this.rdbEditExisting.CheckedChanged += new System.EventHandler(this.rdbEditExisting_CheckedChanged);
            // 
            // rdbCreateNew
            // 
            this.rdbCreateNew.AutoSize = true;
            this.rdbCreateNew.Location = new System.Drawing.Point(12, 26);
            this.rdbCreateNew.Name = "rdbCreateNew";
            this.rdbCreateNew.Size = new System.Drawing.Size(81, 17);
            this.rdbCreateNew.TabIndex = 8;
            this.rdbCreateNew.Text = "Create New";
            this.rdbCreateNew.UseVisualStyleBackColor = true;
            this.rdbCreateNew.CheckedChanged += new System.EventHandler(this.rdbCreateNew_CheckedChanged);
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(214, 25);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(174, 21);
            this.cmbUserRole.TabIndex = 7;
            this.cmbUserRole.Visible = false;
            this.cmbUserRole.SelectedIndexChanged += new System.EventHandler(this.cmbUserRole_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(406, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpAdvance
            // 
            this.grpAdvance.Controls.Add(this.groupBox4);
            this.grpAdvance.Controls.Add(this.chkAllowDiscs);
            this.grpAdvance.Controls.Add(this.groupBox1);
            this.grpAdvance.Location = new System.Drawing.Point(487, 65);
            this.grpAdvance.Name = "grpAdvance";
            this.grpAdvance.Size = new System.Drawing.Size(180, 447);
            this.grpAdvance.TabIndex = 11;
            this.grpAdvance.TabStop = false;
            this.grpAdvance.Text = "Advance User Settigs";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chkBillRePrint);
            this.groupBox4.Controls.Add(this.chkBatchPriceUpdate);
            this.groupBox4.Controls.Add(this.chkProdSave);
            this.groupBox4.Controls.Add(this.chkCrDeOpBalPassword);
            this.groupBox4.Controls.Add(this.chkTOGApply);
            this.groupBox4.Controls.Add(this.chkSRNApply);
            this.groupBox4.Controls.Add(this.chkPOApply);
            this.groupBox4.Controls.Add(this.chkGRNApply);
            this.groupBox4.Location = new System.Drawing.Point(6, 105);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(145, 273);
            this.groupBox4.TabIndex = 144;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transaction Apply";
            // 
            // chkBatchPriceUpdate
            // 
            this.chkBatchPriceUpdate.AutoSize = true;
            this.chkBatchPriceUpdate.Location = new System.Drawing.Point(15, 201);
            this.chkBatchPriceUpdate.Name = "chkBatchPriceUpdate";
            this.chkBatchPriceUpdate.Size = new System.Drawing.Size(119, 17);
            this.chkBatchPriceUpdate.TabIndex = 6;
            this.chkBatchPriceUpdate.Text = "Batch Price Update";
            this.chkBatchPriceUpdate.UseVisualStyleBackColor = true;
            // 
            // chkProdSave
            // 
            this.chkProdSave.AutoSize = true;
            this.chkProdSave.Location = new System.Drawing.Point(15, 178);
            this.chkProdSave.Name = "chkProdSave";
            this.chkProdSave.Size = new System.Drawing.Size(91, 17);
            this.chkProdSave.TabIndex = 5;
            this.chkProdSave.Text = "Product Save";
            this.chkProdSave.UseVisualStyleBackColor = true;
            // 
            // chkCrDeOpBalPassword
            // 
            this.chkCrDeOpBalPassword.AutoSize = true;
            this.chkCrDeOpBalPassword.Location = new System.Drawing.Point(15, 129);
            this.chkCrDeOpBalPassword.Name = "chkCrDeOpBalPassword";
            this.chkCrDeOpBalPassword.Size = new System.Drawing.Size(111, 43);
            this.chkCrDeOpBalPassword.TabIndex = 4;
            this.chkCrDeOpBalPassword.Text = "Debtor Creditor \r\nOpening Balance \r\nPassword";
            this.chkCrDeOpBalPassword.UseVisualStyleBackColor = true;
            // 
            // chkTOGApply
            // 
            this.chkTOGApply.AutoSize = true;
            this.chkTOGApply.Location = new System.Drawing.Point(15, 102);
            this.chkTOGApply.Name = "chkTOGApply";
            this.chkTOGApply.Size = new System.Drawing.Size(78, 17);
            this.chkTOGApply.TabIndex = 3;
            this.chkTOGApply.Text = "TOG Apply";
            this.chkTOGApply.UseVisualStyleBackColor = true;
            // 
            // chkSRNApply
            // 
            this.chkSRNApply.AutoSize = true;
            this.chkSRNApply.Location = new System.Drawing.Point(15, 75);
            this.chkSRNApply.Name = "chkSRNApply";
            this.chkSRNApply.Size = new System.Drawing.Size(78, 17);
            this.chkSRNApply.TabIndex = 2;
            this.chkSRNApply.Text = "SRN Apply";
            this.chkSRNApply.UseVisualStyleBackColor = true;
            // 
            // chkPOApply
            // 
            this.chkPOApply.AutoSize = true;
            this.chkPOApply.Location = new System.Drawing.Point(15, 48);
            this.chkPOApply.Name = "chkPOApply";
            this.chkPOApply.Size = new System.Drawing.Size(70, 17);
            this.chkPOApply.TabIndex = 1;
            this.chkPOApply.Text = "PO Apply";
            this.chkPOApply.UseVisualStyleBackColor = true;
            // 
            // chkGRNApply
            // 
            this.chkGRNApply.AutoSize = true;
            this.chkGRNApply.Location = new System.Drawing.Point(15, 21);
            this.chkGRNApply.Name = "chkGRNApply";
            this.chkGRNApply.Size = new System.Drawing.Size(79, 17);
            this.chkGRNApply.TabIndex = 0;
            this.chkGRNApply.Text = "GRN Apply";
            this.chkGRNApply.UseVisualStyleBackColor = true;
            // 
            // chkAllowDiscs
            // 
            this.chkAllowDiscs.AutoSize = true;
            this.chkAllowDiscs.Checked = true;
            this.chkAllowDiscs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowDiscs.Location = new System.Drawing.Point(9, 19);
            this.chkAllowDiscs.Name = "chkAllowDiscs";
            this.chkAllowDiscs.Size = new System.Drawing.Size(101, 17);
            this.chkAllowDiscs.TabIndex = 4;
            this.chkAllowDiscs.Text = "Allow Discounts";
            this.chkAllowDiscs.UseVisualStyleBackColor = true;
            this.chkAllowDiscs.CheckedChanged += new System.EventHandler(this.chkAllowDiscs_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAdvancePercentage);
            this.groupBox1.Location = new System.Drawing.Point(6, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 64);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advance Alacotions";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "%";
            // 
            // txtAdvancePercentage
            // 
            this.txtAdvancePercentage.Location = new System.Drawing.Point(71, 30);
            this.txtAdvancePercentage.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtAdvancePercentage.Name = "txtAdvancePercentage";
            this.txtAdvancePercentage.Size = new System.Drawing.Size(51, 20);
            this.txtAdvancePercentage.TabIndex = 2;
            // 
            // chkBillRePrint
            // 
            this.chkBillRePrint.AutoSize = true;
            this.chkBillRePrint.Location = new System.Drawing.Point(15, 224);
            this.chkBillRePrint.Name = "chkBillRePrint";
            this.chkBillRePrint.Size = new System.Drawing.Size(76, 17);
            this.chkBillRePrint.TabIndex = 7;
            this.chkBillRePrint.Text = "Bill Reprint";
            this.chkBillRePrint.UseVisualStyleBackColor = true;
            // 
            // frmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 521);
            this.Controls.Add(this.grpAdvance);
            this.Controls.Add(this.txtUserRole);
            this.Controls.Add(this.rdbEditExisting);
            this.Controls.Add(this.rdbCreateNew);
            this.Controls.Add(this.cmbUserRole);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.trvMenuList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserRole";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Role";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUserRole_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserRole_FormClosed);
            this.Load += new System.EventHandler(this.frmUserRole_Load);
            this.grpAdvance.ResumeLayout(false);
            this.grpAdvance.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdvancePercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvMenuList;
        private System.Windows.Forms.TextBox txtUserRole;
        private System.Windows.Forms.RadioButton rdbEditExisting;
        private System.Windows.Forms.RadioButton rdbCreateNew;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpAdvance;
        private System.Windows.Forms.NumericUpDown txtAdvancePercentage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAllowDiscs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkCrDeOpBalPassword;
        private System.Windows.Forms.CheckBox chkTOGApply;
        private System.Windows.Forms.CheckBox chkSRNApply;
        private System.Windows.Forms.CheckBox chkPOApply;
        private System.Windows.Forms.CheckBox chkGRNApply;
        private System.Windows.Forms.CheckBox chkBatchPriceUpdate;
        private System.Windows.Forms.CheckBox chkProdSave;
        private System.Windows.Forms.CheckBox chkBillRePrint;
    }
}