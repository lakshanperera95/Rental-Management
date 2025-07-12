namespace Inventory
{
    partial class frmCreditNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditNote));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecNo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCreditDebitAmount = new System.Windows.Forms.Label();
            this.lblCusOrSup = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCustSearch = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtCreditDebitAmount = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInvGRNNo = new System.Windows.Forms.TextBox();
            this.txtInvGRNAmount = new System.Windows.Forms.TextBox();
            this.btnInvSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.lblDocAmount = new System.Windows.Forms.Label();
            this.txtBalAmount = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblRecNo);
            this.groupBox1.Controls.Add(this.lblHeader);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblCreditDebitAmount);
            this.groupBox1.Controls.Add(this.lblCusOrSup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnCustSearch);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtCreditDebitAmount);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblRecNo
            // 
            this.lblRecNo.AutoSize = true;
            this.lblRecNo.Location = new System.Drawing.Point(448, 16);
            this.lblRecNo.Name = "lblRecNo";
            this.lblRecNo.Size = new System.Drawing.Size(30, 13);
            this.lblRecNo.TabIndex = 20;
            this.lblRecNo.Text = "Date";
            this.lblRecNo.Visible = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHeader.Location = new System.Drawing.Point(20, 5);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(134, 24);
            this.lblHeader.TabIndex = 18;
            this.lblHeader.Text = "Credit Note - ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Remarks";
            // 
            // lblCreditDebitAmount
            // 
            this.lblCreditDebitAmount.AutoSize = true;
            this.lblCreditDebitAmount.Location = new System.Drawing.Point(21, 191);
            this.lblCreditDebitAmount.Name = "lblCreditDebitAmount";
            this.lblCreditDebitAmount.Size = new System.Drawing.Size(73, 13);
            this.lblCreditDebitAmount.TabIndex = 16;
            this.lblCreditDebitAmount.Text = "Credit Amount";
            // 
            // lblCusOrSup
            // 
            this.lblCusOrSup.AutoSize = true;
            this.lblCusOrSup.Location = new System.Drawing.Point(21, 86);
            this.lblCusOrSup.Name = "lblCusOrSup";
            this.lblCusOrSup.Size = new System.Drawing.Size(51, 13);
            this.lblCusOrSup.TabIndex = 12;
            this.lblCusOrSup.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 65);
            this.panel1.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(448, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 37);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(363, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 37);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(278, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 37);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCustSearch
            // 
            this.btnCustSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCustSearch.Image")));
            this.btnCustSearch.Location = new System.Drawing.Point(515, 83);
            this.btnCustSearch.Name = "btnCustSearch";
            this.btnCustSearch.Size = new System.Drawing.Size(28, 21);
            this.btnCustSearch.TabIndex = 3;
            this.btnCustSearch.UseVisualStyleBackColor = true;
            this.btnCustSearch.Click += new System.EventHandler(this.btnCustSearch_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(117, 214);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(392, 20);
            this.txtRemarks.TabIndex = 9;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // txtCreditDebitAmount
            // 
            this.txtCreditDebitAmount.Location = new System.Drawing.Point(117, 188);
            this.txtCreditDebitAmount.Name = "txtCreditDebitAmount";
            this.txtCreditDebitAmount.Size = new System.Drawing.Size(100, 20);
            this.txtCreditDebitAmount.TabIndex = 8;
            this.txtCreditDebitAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditAmount_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(223, 83);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 20);
            this.txtName.TabIndex = 2;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown_1);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(117, 83);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(117, 57);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDate_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInvGRNNo);
            this.groupBox2.Controls.Add(this.txtInvGRNAmount);
            this.groupBox2.Controls.Add(this.btnInvSearch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblDocNo);
            this.groupBox2.Controls.Add(this.lblDocAmount);
            this.groupBox2.Controls.Add(this.txtBalAmount);
            this.groupBox2.Location = new System.Drawing.Point(18, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 75);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // txtInvGRNNo
            // 
            this.txtInvGRNNo.Location = new System.Drawing.Point(99, 19);
            this.txtInvGRNNo.Name = "txtInvGRNNo";
            this.txtInvGRNNo.Size = new System.Drawing.Size(100, 20);
            this.txtInvGRNNo.TabIndex = 4;
            this.txtInvGRNNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvNo_KeyDown);
            // 
            // txtInvGRNAmount
            // 
            this.txtInvGRNAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvGRNAmount.Location = new System.Drawing.Point(99, 45);
            this.txtInvGRNAmount.Name = "txtInvGRNAmount";
            this.txtInvGRNAmount.ReadOnly = true;
            this.txtInvGRNAmount.Size = new System.Drawing.Size(100, 20);
            this.txtInvGRNAmount.TabIndex = 6;
            // 
            // btnInvSearch
            // 
            this.btnInvSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnInvSearch.Image")));
            this.btnInvSearch.Location = new System.Drawing.Point(205, 18);
            this.btnInvSearch.Name = "btnInvSearch";
            this.btnInvSearch.Size = new System.Drawing.Size(28, 21);
            this.btnInvSearch.TabIndex = 5;
            this.btnInvSearch.UseVisualStyleBackColor = true;
            this.btnInvSearch.Click += new System.EventHandler(this.btnInvSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Balance Amount";
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.Location = new System.Drawing.Point(3, 22);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(59, 13);
            this.lblDocNo.TabIndex = 13;
            this.lblDocNo.Text = "Invoice No";
            // 
            // lblDocAmount
            // 
            this.lblDocAmount.AutoSize = true;
            this.lblDocAmount.Location = new System.Drawing.Point(3, 48);
            this.lblDocAmount.Name = "lblDocAmount";
            this.lblDocAmount.Size = new System.Drawing.Size(81, 13);
            this.lblDocAmount.TabIndex = 14;
            this.lblDocAmount.Text = "Invoice Amount";
            // 
            // txtBalAmount
            // 
            this.txtBalAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtBalAmount.Location = new System.Drawing.Point(391, 42);
            this.txtBalAmount.Name = "txtBalAmount";
            this.txtBalAmount.ReadOnly = true;
            this.txtBalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtBalAmount.TabIndex = 7;
            // 
            // frmCreditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(567, 320);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCreditNote";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Note";
            this.Activated += new System.EventHandler(this.frmCreditNote_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCreditNote_FormClosed);
            this.Load += new System.EventHandler(this.frmCreditNote_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtCreditDebitAmount;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCustSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCreditDebitAmount;
        private System.Windows.Forms.Label lblCusOrSup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDocAmount;
        private System.Windows.Forms.Label lblDocNo;
        private System.Windows.Forms.Button btnInvSearch;
        private System.Windows.Forms.TextBox txtBalAmount;
        private System.Windows.Forms.TextBox txtInvGRNAmount;
        private System.Windows.Forms.TextBox txtInvGRNNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRecNo;
    }
}