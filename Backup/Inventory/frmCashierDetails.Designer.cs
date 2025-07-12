namespace Inventory
{
    partial class frmCashierDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCashier = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkSaleAmtDply = new System.Windows.Forms.CheckBox();
            this.chkGiftIssue = new System.Windows.Forms.CheckBox();
            this.chkNotIssue = new System.Windows.Forms.CheckBox();
            this.cmbMemberSecLevel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDisableCashier = new System.Windows.Forms.CheckBox();
            this.chkBillCopy = new System.Windows.Forms.CheckBox();
            this.chkDayEndRep = new System.Windows.Forms.CheckBox();
            this.chkDepartmentSale = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.chkDiscountAllow = new System.Windows.Forms.CheckBox();
            this.chkCashOut = new System.Windows.Forms.CheckBox();
            this.chkCashRefund = new System.Windows.Forms.CheckBox();
            this.chkRefund = new System.Windows.Forms.CheckBox();
            this.chkCancel = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtRfndLimit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDisplayName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCashier);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cashier";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(369, 52);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(108, 20);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirm Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(96, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(108, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(369, 20);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(108, 20);
            this.txtDisplayName.TabIndex = 3;
            this.txtDisplayName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDisplayName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee Name";
            // 
            // cmbCashier
            // 
            this.cmbCashier.FormattingEnabled = true;
            this.cmbCashier.Location = new System.Drawing.Point(96, 19);
            this.cmbCashier.Name = "cmbCashier";
            this.cmbCashier.Size = new System.Drawing.Size(166, 21);
            this.cmbCashier.TabIndex = 0;
            this.cmbCashier.SelectedIndexChanged += new System.EventHandler(this.cmbCashier_SelectedIndexChanged);
            this.cmbCashier.SelectedValueChanged += new System.EventHandler(this.cmbCashier_SelectedValueChanged);
            this.cmbCashier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCashier_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 212);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(563, 65);
            this.toolStrip1.TabIndex = 142;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRfndLimit);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.chkSaleAmtDply);
            this.groupBox2.Controls.Add(this.chkGiftIssue);
            this.groupBox2.Controls.Add(this.chkNotIssue);
            this.groupBox2.Controls.Add(this.cmbMemberSecLevel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkDisableCashier);
            this.groupBox2.Controls.Add(this.chkBillCopy);
            this.groupBox2.Controls.Add(this.chkDayEndRep);
            this.groupBox2.Controls.Add(this.chkDepartmentSale);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.chkDiscountAllow);
            this.groupBox2.Controls.Add(this.chkCashOut);
            this.groupBox2.Controls.Add(this.chkCashRefund);
            this.groupBox2.Controls.Add(this.chkRefund);
            this.groupBox2.Controls.Add(this.chkCancel);
            this.groupBox2.Location = new System.Drawing.Point(2, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 133);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(369, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "New Price Allow";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkSaleAmtDply
            // 
            this.chkSaleAmtDply.AutoSize = true;
            this.chkSaleAmtDply.Location = new System.Drawing.Point(221, 100);
            this.chkSaleAmtDply.Name = "chkSaleAmtDply";
            this.chkSaleAmtDply.Size = new System.Drawing.Size(119, 17);
            this.chkSaleAmtDply.TabIndex = 18;
            this.chkSaleAmtDply.Text = "Sales Value Display";
            this.chkSaleAmtDply.UseVisualStyleBackColor = true;
            // 
            // chkGiftIssue
            // 
            this.chkGiftIssue.AutoSize = true;
            this.chkGiftIssue.Location = new System.Drawing.Point(221, 77);
            this.chkGiftIssue.Name = "chkGiftIssue";
            this.chkGiftIssue.Size = new System.Drawing.Size(113, 17);
            this.chkGiftIssue.TabIndex = 17;
            this.chkGiftIssue.Text = "Gift Voucher Issue";
            this.chkGiftIssue.UseVisualStyleBackColor = true;
            // 
            // chkNotIssue
            // 
            this.chkNotIssue.AutoSize = true;
            this.chkNotIssue.Location = new System.Drawing.Point(221, 55);
            this.chkNotIssue.Name = "chkNotIssue";
            this.chkNotIssue.Size = new System.Drawing.Size(107, 17);
            this.chkNotIssue.TabIndex = 16;
            this.chkNotIssue.Text = "Credit Note Issue";
            this.chkNotIssue.UseVisualStyleBackColor = true;
            // 
            // cmbMemberSecLevel
            // 
            this.cmbMemberSecLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMemberSecLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMemberSecLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberSecLevel.FormattingEnabled = true;
            this.cmbMemberSecLevel.Location = new System.Drawing.Point(414, 28);
            this.cmbMemberSecLevel.Name = "cmbMemberSecLevel";
            this.cmbMemberSecLevel.Size = new System.Drawing.Size(141, 21);
            this.cmbMemberSecLevel.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Sec Level";
            // 
            // chkDisableCashier
            // 
            this.chkDisableCashier.AutoSize = true;
            this.chkDisableCashier.ForeColor = System.Drawing.Color.Crimson;
            this.chkDisableCashier.Location = new System.Drawing.Point(415, 11);
            this.chkDisableCashier.Name = "chkDisableCashier";
            this.chkDisableCashier.Size = new System.Drawing.Size(99, 17);
            this.chkDisableCashier.TabIndex = 13;
            this.chkDisableCashier.Text = "Disable Cashier";
            this.chkDisableCashier.UseVisualStyleBackColor = true;
            this.chkDisableCashier.CheckedChanged += new System.EventHandler(this.chkDisableCashier_CheckedChanged);
            // 
            // chkBillCopy
            // 
            this.chkBillCopy.AutoSize = true;
            this.chkBillCopy.Location = new System.Drawing.Point(108, 100);
            this.chkBillCopy.Name = "chkBillCopy";
            this.chkBillCopy.Size = new System.Drawing.Size(66, 17);
            this.chkBillCopy.TabIndex = 9;
            this.chkBillCopy.Text = "Bill Copy";
            this.chkBillCopy.UseVisualStyleBackColor = true;
            // 
            // chkDayEndRep
            // 
            this.chkDayEndRep.AutoSize = true;
            this.chkDayEndRep.Location = new System.Drawing.Point(108, 77);
            this.chkDayEndRep.Name = "chkDayEndRep";
            this.chkDayEndRep.Size = new System.Drawing.Size(102, 17);
            this.chkDayEndRep.TabIndex = 8;
            this.chkDayEndRep.Text = "Day End Report";
            this.chkDayEndRep.UseVisualStyleBackColor = true;
            // 
            // chkDepartmentSale
            // 
            this.chkDepartmentSale.AutoSize = true;
            this.chkDepartmentSale.Location = new System.Drawing.Point(108, 55);
            this.chkDepartmentSale.Name = "chkDepartmentSale";
            this.chkDepartmentSale.Size = new System.Drawing.Size(110, 17);
            this.chkDepartmentSale.TabIndex = 7;
            this.chkDepartmentSale.Text = "Department Sales";
            this.chkDepartmentSale.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "%";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(221, 29);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(59, 20);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            // 
            // chkDiscountAllow
            // 
            this.chkDiscountAllow.AutoSize = true;
            this.chkDiscountAllow.Location = new System.Drawing.Point(108, 31);
            this.chkDiscountAllow.Name = "chkDiscountAllow";
            this.chkDiscountAllow.Size = new System.Drawing.Size(96, 17);
            this.chkDiscountAllow.TabIndex = 4;
            this.chkDiscountAllow.Text = "Discount Allow";
            this.chkDiscountAllow.UseVisualStyleBackColor = true;
            this.chkDiscountAllow.CheckedChanged += new System.EventHandler(this.chkDiscountAllow_CheckedChanged);
            // 
            // chkCashOut
            // 
            this.chkCashOut.AutoSize = true;
            this.chkCashOut.Location = new System.Drawing.Point(10, 100);
            this.chkCashOut.Name = "chkCashOut";
            this.chkCashOut.Size = new System.Drawing.Size(70, 17);
            this.chkCashOut.TabIndex = 3;
            this.chkCashOut.Text = "Cash Out";
            this.chkCashOut.UseVisualStyleBackColor = true;
            // 
            // chkCashRefund
            // 
            this.chkCashRefund.AutoSize = true;
            this.chkCashRefund.Location = new System.Drawing.Point(10, 77);
            this.chkCashRefund.Name = "chkCashRefund";
            this.chkCashRefund.Size = new System.Drawing.Size(88, 17);
            this.chkCashRefund.TabIndex = 2;
            this.chkCashRefund.Text = "Cash Refund";
            this.chkCashRefund.UseVisualStyleBackColor = true;
            // 
            // chkRefund
            // 
            this.chkRefund.AutoSize = true;
            this.chkRefund.Location = new System.Drawing.Point(10, 55);
            this.chkRefund.Name = "chkRefund";
            this.chkRefund.Size = new System.Drawing.Size(61, 17);
            this.chkRefund.TabIndex = 1;
            this.chkRefund.Text = "Refund";
            this.chkRefund.UseVisualStyleBackColor = true;
            // 
            // chkCancel
            // 
            this.chkCancel.AutoSize = true;
            this.chkCancel.Location = new System.Drawing.Point(10, 33);
            this.chkCancel.Name = "chkCancel";
            this.chkCancel.Size = new System.Drawing.Size(59, 17);
            this.chkCancel.TabIndex = 0;
            this.chkCancel.Text = "Cancel";
            this.chkCancel.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(437, 222);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 42);
            this.btnExit.TabIndex = 158;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(326, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 42);
            this.btnDelete.TabIndex = 157;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(113, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 42);
            this.btnSave.TabIndex = 156;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(220, 222);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 42);
            this.btnClear.TabIndex = 159;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtRfndLimit
            // 
            this.txtRfndLimit.Location = new System.Drawing.Point(369, 98);
            this.txtRfndLimit.Name = "txtRfndLimit";
            this.txtRfndLimit.Size = new System.Drawing.Size(59, 20);
            this.txtRfndLimit.TabIndex = 20;
            this.txtRfndLimit.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cash Refund Limit";
            // 
            // frmCashierDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(563, 277);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashierDetails";
            this.Text = "Cashier Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCashierDetails_FormClosed);
            this.Load += new System.EventHandler(this.frmCashierDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCashier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCashRefund;
        private System.Windows.Forms.CheckBox chkRefund;
        private System.Windows.Forms.CheckBox chkCancel;
        private System.Windows.Forms.CheckBox chkBillCopy;
        private System.Windows.Forms.CheckBox chkDayEndRep;
        private System.Windows.Forms.CheckBox chkDepartmentSale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.CheckBox chkDiscountAllow;
        private System.Windows.Forms.CheckBox chkCashOut;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbMemberSecLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDisableCashier;
        private System.Windows.Forms.CheckBox chkSaleAmtDply;
        private System.Windows.Forms.CheckBox chkGiftIssue;
        private System.Windows.Forms.CheckBox chkNotIssue;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRfndLimit;
    }
}