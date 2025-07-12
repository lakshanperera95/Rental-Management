namespace Inventory
{
    partial class frmSalesInquary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesInquary));
            this.txtDescriptionTo = new System.Windows.Forms.TextBox();
            this.txtDescriptionFrom = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtCodeTo = new System.Windows.Forms.TextBox();
            this.txtCodeFrom = new System.Windows.Forms.TextBox();
            this.lblCodeTo = new System.Windows.Forms.Label();
            this.lblCodeFrom = new System.Windows.Forms.Label();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchCodeFrom = new System.Windows.Forms.Button();
            this.btnSearchCodeTo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.rbByCode = new System.Windows.Forms.RadioButton();
            this.rbByDesc = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.cmbSelection = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chkPaymentAll = new System.Windows.Forms.CheckBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescriptionTo
            // 
            this.txtDescriptionTo.Location = new System.Drawing.Point(201, 75);
            this.txtDescriptionTo.Name = "txtDescriptionTo";
            this.txtDescriptionTo.Size = new System.Drawing.Size(217, 20);
            this.txtDescriptionTo.TabIndex = 5;
            // 
            // txtDescriptionFrom
            // 
            this.txtDescriptionFrom.Location = new System.Drawing.Point(202, 43);
            this.txtDescriptionFrom.Name = "txtDescriptionFrom";
            this.txtDescriptionFrom.Size = new System.Drawing.Size(217, 20);
            this.txtDescriptionFrom.TabIndex = 2;
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(124, 177);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 50);
            this.btnDisplay.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(370, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 10;
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 170);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(497, 65);
            this.toolStrip1.TabIndex = 141;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtCodeTo
            // 
            this.txtCodeTo.Location = new System.Drawing.Point(76, 75);
            this.txtCodeTo.Name = "txtCodeTo";
            this.txtCodeTo.Size = new System.Drawing.Size(122, 20);
            this.txtCodeTo.TabIndex = 4;
            this.txtCodeTo.Enter += new System.EventHandler(this.txtCodeTo_Enter);
            // 
            // txtCodeFrom
            // 
            this.txtCodeFrom.Location = new System.Drawing.Point(76, 43);
            this.txtCodeFrom.Name = "txtCodeFrom";
            this.txtCodeFrom.Size = new System.Drawing.Size(123, 20);
            this.txtCodeFrom.TabIndex = 1;
            this.txtCodeFrom.Enter += new System.EventHandler(this.txtCodeFrom_Enter);
            // 
            // lblCodeTo
            // 
            this.lblCodeTo.AutoSize = true;
            this.lblCodeTo.Location = new System.Drawing.Point(12, 79);
            this.lblCodeTo.Name = "lblCodeTo";
            this.lblCodeTo.Size = new System.Drawing.Size(48, 13);
            this.lblCodeTo.TabIndex = 134;
            this.lblCodeTo.Text = "Code To";
            // 
            // lblCodeFrom
            // 
            this.lblCodeFrom.AutoSize = true;
            this.lblCodeFrom.Location = new System.Drawing.Point(12, 46);
            this.lblCodeFrom.Name = "lblCodeFrom";
            this.lblCodeFrom.Size = new System.Drawing.Size(58, 13);
            this.lblCodeFrom.TabIndex = 133;
            this.lblCodeFrom.Text = "Code From";
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(111, 106);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(115, 20);
            this.dtDateFrom.TabIndex = 7;
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(294, 106);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(111, 20);
            this.dtDateTo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "Date From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 147;
            this.label2.Text = "Date To";
            // 
            // btnSearchCodeFrom
            // 
            this.btnSearchCodeFrom.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCodeFrom.Image")));
            this.btnSearchCodeFrom.Location = new System.Drawing.Point(424, 43);
            this.btnSearchCodeFrom.Name = "btnSearchCodeFrom";
            this.btnSearchCodeFrom.Size = new System.Drawing.Size(28, 21);
            this.btnSearchCodeFrom.TabIndex = 3;
            this.btnSearchCodeFrom.UseVisualStyleBackColor = true;
            this.btnSearchCodeFrom.Click += new System.EventHandler(this.btnSearchCodeFrom_Click);
            // 
            // btnSearchCodeTo
            // 
            this.btnSearchCodeTo.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCodeTo.Image")));
            this.btnSearchCodeTo.Location = new System.Drawing.Point(423, 75);
            this.btnSearchCodeTo.Name = "btnSearchCodeTo";
            this.btnSearchCodeTo.Size = new System.Drawing.Size(28, 21);
            this.btnSearchCodeTo.TabIndex = 6;
            this.btnSearchCodeTo.UseVisualStyleBackColor = true;
            this.btnSearchCodeTo.Click += new System.EventHandler(this.btnSearchCodeTo_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(247, 177);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 50);
            this.btnClear.TabIndex = 148;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rbByCode
            // 
            this.rbByCode.AutoSize = true;
            this.rbByCode.Checked = true;
            this.rbByCode.Location = new System.Drawing.Point(175, 141);
            this.rbByCode.Name = "rbByCode";
            this.rbByCode.Size = new System.Drawing.Size(89, 17);
            this.rbByCode.TabIndex = 149;
            this.rbByCode.TabStop = true;
            this.rbByCode.Text = "Sort  by Code";
            this.rbByCode.UseVisualStyleBackColor = true;
            this.rbByCode.Visible = false;
            // 
            // rbByDesc
            // 
            this.rbByDesc.AutoSize = true;
            this.rbByDesc.Location = new System.Drawing.Point(305, 141);
            this.rbByDesc.Name = "rbByDesc";
            this.rbByDesc.Size = new System.Drawing.Size(114, 17);
            this.rbByDesc.TabIndex = 150;
            this.rbByDesc.Text = "Sort by Description";
            this.rbByDesc.UseVisualStyleBackColor = true;
            this.rbByDesc.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 141);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 151;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkDetails
            // 
            this.chkDetails.AutoSize = true;
            this.chkDetails.Location = new System.Drawing.Point(76, 141);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(58, 17);
            this.chkDetails.TabIndex = 152;
            this.chkDetails.Text = "Details";
            this.chkDetails.UseVisualStyleBackColor = true;
            this.chkDetails.Visible = false;
            // 
            // cmbSelection
            // 
            this.cmbSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelection.FormattingEnabled = true;
            this.cmbSelection.Location = new System.Drawing.Point(331, 12);
            this.cmbSelection.Name = "cmbSelection";
            this.cmbSelection.Size = new System.Drawing.Size(121, 21);
            this.cmbSelection.TabIndex = 153;
            this.cmbSelection.Visible = false;
            this.cmbSelection.SelectedIndexChanged += new System.EventHandler(this.cmbSelection_SelectedIndexChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(244, 15);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 154;
            this.lblUnit.Text = "Unit";
            this.lblUnit.Visible = false;
            // 
            // chkPaymentAll
            // 
            this.chkPaymentAll.AutoSize = true;
            this.chkPaymentAll.Location = new System.Drawing.Point(23, 11);
            this.chkPaymentAll.Name = "chkPaymentAll";
            this.chkPaymentAll.Size = new System.Drawing.Size(37, 17);
            this.chkPaymentAll.TabIndex = 155;
            this.chkPaymentAll.Text = "All";
            this.chkPaymentAll.UseVisualStyleBackColor = true;
            this.chkPaymentAll.Visible = false;
            this.chkPaymentAll.CheckedChanged += new System.EventHandler(this.chkPaymentAll_CheckedChanged);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(111, 138);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(54, 20);
            this.txtAge.TabIndex = 156;
            this.txtAge.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 157;
            this.label3.Text = "Age >";
            this.label3.Visible = false;
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Location = new System.Drawing.Point(276, 15);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(31, 13);
            this.lblSelection.TabIndex = 158;
            this.lblSelection.Text = "Type";
            this.lblSelection.Visible = false;
            // 
            // frmSalesInquary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(497, 235);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.chkPaymentAll);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbSelection);
            this.Controls.Add(this.chkDetails);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.rbByDesc);
            this.Controls.Add(this.rbByCode);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.dtDateFrom);
            this.Controls.Add(this.btnSearchCodeFrom);
            this.Controls.Add(this.txtDescriptionTo);
            this.Controls.Add(this.txtDescriptionFrom);
            this.Controls.Add(this.btnSearchCodeTo);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtCodeTo);
            this.Controls.Add(this.txtCodeFrom);
            this.Controls.Add(this.lblCodeTo);
            this.Controls.Add(this.lblCodeFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesInquary";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Inquary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesInquary_FormClosed);
            this.Load += new System.EventHandler(this.frmSalesInquary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSalesInquary_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchCodeFrom;
        private System.Windows.Forms.TextBox txtDescriptionTo;
        private System.Windows.Forms.TextBox txtDescriptionFrom;
        private System.Windows.Forms.Button btnSearchCodeTo;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtCodeTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.TextBox txtCodeFrom;
        private System.Windows.Forms.RadioButton rbByCode;
        private System.Windows.Forms.RadioButton rbByDesc;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkDetails;
        private System.Windows.Forms.ComboBox cmbSelection;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.CheckBox chkPaymentAll;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelection;
        public System.Windows.Forms.Label lblCodeTo;
        public System.Windows.Forms.Label lblCodeFrom;
    }
}