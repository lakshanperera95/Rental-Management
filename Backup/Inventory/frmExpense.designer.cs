namespace Inventory
{
    partial class frmExpense
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
            this.btnSuppSerch = new System.Windows.Forms.Button();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBf = new System.Windows.Forms.CheckBox();
            this.btnCustSerch = new System.Windows.Forms.Button();
            this.btnExpenseSearch = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExitB = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtExpenseName = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.txtExpenseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSuppSerch);
            this.groupBox1.Controls.Add(this.txtSuppName);
            this.groupBox1.Controls.Add(this.txtSuppCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkBf);
            this.groupBox1.Controls.Add(this.btnCustSerch);
            this.groupBox1.Controls.Add(this.btnExpenseSearch);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.txtExpenseName);
            this.groupBox1.Controls.Add(this.txtCustName);
            this.groupBox1.Controls.Add(this.txtCustCode);
            this.groupBox1.Controls.Add(this.txtExpenseCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSuppSerch
            // 
            this.btnSuppSerch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSuppSerch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSuppSerch.Location = new System.Drawing.Point(450, 124);
            this.btnSuppSerch.Name = "btnSuppSerch";
            this.btnSuppSerch.Size = new System.Drawing.Size(25, 20);
            this.btnSuppSerch.TabIndex = 131;
            this.btnSuppSerch.UseVisualStyleBackColor = true;
            this.btnSuppSerch.Click += new System.EventHandler(this.btnSuppSerch_Click);
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(215, 124);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(226, 20);
            this.txtSuppName.TabIndex = 130;
            this.txtSuppName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppName_KeyDown);
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Location = new System.Drawing.Point(99, 124);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(110, 20);
            this.txtSuppCode.TabIndex = 129;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Enter += new System.EventHandler(this.txtSuppCode_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 128;
            this.label4.Text = "Link Supp Code:";
            // 
            // chkBf
            // 
            this.chkBf.AutoSize = true;
            this.chkBf.Location = new System.Drawing.Point(230, 22);
            this.chkBf.Name = "chkBf";
            this.chkBf.Size = new System.Drawing.Size(44, 17);
            this.chkBf.TabIndex = 127;
            this.chkBf.Text = "B/F";
            this.chkBf.UseVisualStyleBackColor = true;
            // 
            // btnCustSerch
            // 
            this.btnCustSerch.ForeColor = System.Drawing.Color.DimGray;
            this.btnCustSerch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnCustSerch.Location = new System.Drawing.Point(450, 89);
            this.btnCustSerch.Name = "btnCustSerch";
            this.btnCustSerch.Size = new System.Drawing.Size(25, 20);
            this.btnCustSerch.TabIndex = 5;
            this.btnCustSerch.UseVisualStyleBackColor = true;
            this.btnCustSerch.Click += new System.EventHandler(this.btnCustSerch_Click);
            // 
            // btnExpenseSearch
            // 
            this.btnExpenseSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnExpenseSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnExpenseSearch.Location = new System.Drawing.Point(450, 53);
            this.btnExpenseSearch.Name = "btnExpenseSearch";
            this.btnExpenseSearch.Size = new System.Drawing.Size(25, 20);
            this.btnExpenseSearch.TabIndex = 2;
            this.btnExpenseSearch.UseVisualStyleBackColor = true;
            this.btnExpenseSearch.Click += new System.EventHandler(this.btnBankSearchB_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.btnClear);
            this.panel5.Controls.Add(this.btnExitB);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 168);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(483, 56);
            this.panel5.TabIndex = 125;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(269, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 43);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear\r\n(ctrl+L)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExitB
            // 
            this.btnExitB.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExitB.FlatAppearance.BorderSize = 0;
            this.btnExitB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitB.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitB.Location = new System.Drawing.Point(372, 6);
            this.btnExitB.Name = "btnExitB";
            this.btnExitB.Size = new System.Drawing.Size(82, 43);
            this.btnExitB.TabIndex = 2;
            this.btnExitB.Text = "Exit\r\n(ctrl+E)";
            this.btnExitB.UseVisualStyleBackColor = false;
            this.btnExitB.Click += new System.EventHandler(this.btnExitB_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(154, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save\r\n(ctrl+S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnApplyB_Click);
            // 
            // txtExpenseName
            // 
            this.txtExpenseName.Location = new System.Drawing.Point(99, 53);
            this.txtExpenseName.Name = "txtExpenseName";
            this.txtExpenseName.Size = new System.Drawing.Size(342, 20);
            this.txtExpenseName.TabIndex = 1;
            this.txtExpenseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpenseName_KeyDown);
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(215, 89);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(226, 20);
            this.txtCustName.TabIndex = 4;
            this.txtCustName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustName_KeyDown);
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(99, 89);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(110, 20);
            this.txtCustCode.TabIndex = 3;
            this.txtCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            this.txtCustCode.Enter += new System.EventHandler(this.txtCustCode_Enter);
            // 
            // txtExpenseCode
            // 
            this.txtExpenseCode.Location = new System.Drawing.Point(99, 19);
            this.txtExpenseCode.Name = "txtExpenseCode";
            this.txtExpenseCode.Size = new System.Drawing.Size(110, 20);
            this.txtExpenseCode.TabIndex = 0;
            this.txtExpenseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpenseCode_KeyDown);
            this.txtExpenseCode.Enter += new System.EventHandler(this.txtExpenseCode_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Link Cust Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expense Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Expense Code:";
            // 
            // frmExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(495, 231);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense";
            this.Load += new System.EventHandler(this.frmExpense_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExpense_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExpense_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpenseName;
        private System.Windows.Forms.TextBox txtExpenseCode;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnExitB;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExpenseSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkBf;
        private System.Windows.Forms.Button btnCustSerch;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSuppSerch;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.Label label4;

    }
}