namespace Inventory
{
    partial class frmTransactionInquary
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
            this.lblType = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.grpSuppCust = new System.Windows.Forms.GroupBox();
            this.rdbsupplier = new System.Windows.Forms.RadioButton();
            this.rdbcustomer = new System.Windows.Forms.RadioButton();
            this.radioButtonDate = new System.Windows.Forms.RadioButton();
            this.radioButtonDocumentNo = new System.Windows.Forms.RadioButton();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnDocumentTo = new System.Windows.Forms.Button();
            this.btnDocumentFrom = new System.Windows.Forms.Button();
            this.txtCodeTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodeFrom = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.grpSuppCust.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.lblUnit);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.cmbtype);
            this.groupBox1.Controls.Add(this.grpSuppCust);
            this.groupBox1.Controls.Add(this.radioButtonDate);
            this.groupBox1.Controls.Add(this.radioButtonDocumentNo);
            this.groupBox1.Controls.Add(this.dtDateTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtDateFrom);
            this.groupBox1.Controls.Add(this.btnDocumentTo);
            this.groupBox1.Controls.Add(this.btnDocumentFrom);
            this.groupBox1.Controls.Add(this.txtCodeTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodeFrom);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(308, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(56, 13);
            this.lblType.TabIndex = 135;
            this.lblType.Text = "Date From";
            this.lblType.Visible = false;
            // 
            // cmbtype
            // 
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "CASH",
            "CREDIT",
            "ALL"});
            this.cmbtype.Location = new System.Drawing.Point(375, 10);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(88, 21);
            this.cmbtype.TabIndex = 134;
            this.cmbtype.Visible = false;
            // 
            // grpSuppCust
            // 
            this.grpSuppCust.Controls.Add(this.rdbsupplier);
            this.grpSuppCust.Controls.Add(this.rdbcustomer);
            this.grpSuppCust.Location = new System.Drawing.Point(370, 30);
            this.grpSuppCust.Name = "grpSuppCust";
            this.grpSuppCust.Size = new System.Drawing.Size(93, 61);
            this.grpSuppCust.TabIndex = 13;
            this.grpSuppCust.TabStop = false;
            this.grpSuppCust.Visible = false;
            // 
            // rdbsupplier
            // 
            this.rdbsupplier.AutoSize = true;
            this.rdbsupplier.Location = new System.Drawing.Point(13, 36);
            this.rdbsupplier.Name = "rdbsupplier";
            this.rdbsupplier.Size = new System.Drawing.Size(63, 17);
            this.rdbsupplier.TabIndex = 12;
            this.rdbsupplier.Text = "Supplier";
            this.rdbsupplier.UseVisualStyleBackColor = true;
            // 
            // rdbcustomer
            // 
            this.rdbcustomer.AutoSize = true;
            this.rdbcustomer.Checked = true;
            this.rdbcustomer.Location = new System.Drawing.Point(12, 13);
            this.rdbcustomer.Name = "rdbcustomer";
            this.rdbcustomer.Size = new System.Drawing.Size(69, 17);
            this.rdbcustomer.TabIndex = 11;
            this.rdbcustomer.TabStop = true;
            this.rdbcustomer.Text = "Customer";
            this.rdbcustomer.UseVisualStyleBackColor = true;
            // 
            // radioButtonDate
            // 
            this.radioButtonDate.AutoSize = true;
            this.radioButtonDate.Location = new System.Drawing.Point(17, 99);
            this.radioButtonDate.Name = "radioButtonDate";
            this.radioButtonDate.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDate.TabIndex = 1;
            this.radioButtonDate.Text = "Date";
            this.radioButtonDate.UseVisualStyleBackColor = true;
            this.radioButtonDate.CheckedChanged += new System.EventHandler(this.radioButtonDate_CheckedChanged);
            // 
            // radioButtonDocumentNo
            // 
            this.radioButtonDocumentNo.AutoSize = true;
            this.radioButtonDocumentNo.Checked = true;
            this.radioButtonDocumentNo.Location = new System.Drawing.Point(17, 16);
            this.radioButtonDocumentNo.Name = "radioButtonDocumentNo";
            this.radioButtonDocumentNo.Size = new System.Drawing.Size(91, 17);
            this.radioButtonDocumentNo.TabIndex = 0;
            this.radioButtonDocumentNo.TabStop = true;
            this.radioButtonDocumentNo.Text = "Document No";
            this.radioButtonDocumentNo.UseVisualStyleBackColor = true;
            this.radioButtonDocumentNo.CheckedChanged += new System.EventHandler(this.radioButtonDocumentNo_CheckedChanged);
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(333, 126);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(114, 20);
            this.dtDateTo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(138, 126);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(125, 20);
            this.dtDateFrom.TabIndex = 6;
            // 
            // btnDocumentTo
            // 
            this.btnDocumentTo.Location = new System.Drawing.Point(287, 71);
            this.btnDocumentTo.Name = "btnDocumentTo";
            this.btnDocumentTo.Size = new System.Drawing.Size(45, 20);
            this.btnDocumentTo.TabIndex = 5;
            this.btnDocumentTo.Text = "....";
            this.btnDocumentTo.UseVisualStyleBackColor = true;
            this.btnDocumentTo.Click += new System.EventHandler(this.btnDocumentTo_Click);
            // 
            // btnDocumentFrom
            // 
            this.btnDocumentFrom.Location = new System.Drawing.Point(287, 37);
            this.btnDocumentFrom.Name = "btnDocumentFrom";
            this.btnDocumentFrom.Size = new System.Drawing.Size(45, 21);
            this.btnDocumentFrom.TabIndex = 3;
            this.btnDocumentFrom.Text = "....";
            this.btnDocumentFrom.UseVisualStyleBackColor = true;
            this.btnDocumentFrom.Click += new System.EventHandler(this.btnDocumentFrom_Click);
            // 
            // txtCodeTo
            // 
            this.txtCodeTo.Location = new System.Drawing.Point(138, 71);
            this.txtCodeTo.Name = "txtCodeTo";
            this.txtCodeTo.Size = new System.Drawing.Size(133, 20);
            this.txtCodeTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Document No To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Document No From";
            // 
            // txtCodeFrom
            // 
            this.txtCodeFrom.Location = new System.Drawing.Point(137, 37);
            this.txtCodeFrom.Name = "txtCodeFrom";
            this.txtCodeFrom.Size = new System.Drawing.Size(134, 20);
            this.txtCodeFrom.TabIndex = 2;
            this.txtCodeFrom.TextChanged += new System.EventHandler(this.txtCodeFrom_TextChanged);
            this.txtCodeFrom.Enter += new System.EventHandler(this.txtCodeFrom_Enter);
            this.txtCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodeFrom_KeyDown);
            this.txtCodeFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeFrom_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 167);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(488, 66);
            this.toolStrip1.TabIndex = 133;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(376, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(239, 176);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 50);
            this.btnDisplay.TabIndex = 8;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(166, 10);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(88, 21);
            this.cmbUnit.TabIndex = 136;
            this.cmbUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(134, 13);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 137;
            this.lblUnit.Text = "Unit";
            this.lblUnit.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(265, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 152;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmTransactionInquary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(488, 233);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransactionInquary";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Inquary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransactionInquary_FormClosed);
            this.Load += new System.EventHandler(this.frmTransactionInquary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTransactionInquary_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSuppCust.ResumeLayout(false);
            this.grpSuppCust.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Button btnDocumentTo;
        private System.Windows.Forms.Button btnDocumentFrom;
        private System.Windows.Forms.TextBox txtCodeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radioButtonDocumentNo;
        private System.Windows.Forms.RadioButton radioButtonDate;
        private System.Windows.Forms.GroupBox grpSuppCust;
        private System.Windows.Forms.RadioButton rdbsupplier;
        private System.Windows.Forms.RadioButton rdbcustomer;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Label lblType;
        public System.Windows.Forms.TextBox txtCodeFrom;
        public System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.CheckBox chkAll;
    }
}