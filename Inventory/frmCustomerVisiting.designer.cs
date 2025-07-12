namespace Inventory
{
    partial class frmCustomerVisiting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerVisiting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkAllLoca = new System.Windows.Forms.CheckBox();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.btnCustSearch2 = new System.Windows.Forms.Button();
            this.btnCustSearch1 = new System.Windows.Forms.Button();
            this.txtCustNameTo = new System.Windows.Forms.TextBox();
            this.txtCustCodeTo = new System.Windows.Forms.TextBox();
            this.txtCustNameFrom = new System.Windows.Forms.TextBox();
            this.txtCustCodeFrom = new System.Windows.Forms.TextBox();
            this.lblCodeTo = new System.Windows.Forms.Label();
            this.lblCodeFrom = new System.Windows.Forms.Label();
            this.rbCustomerWise = new System.Windows.Forms.RadioButton();
            this.rbCustomerVisiting = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnDisplay = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.chkAllLoca);
            this.groupBox1.Controls.Add(this.btnLocaSearch);
            this.groupBox1.Controls.Add(this.txtLocaName);
            this.groupBox1.Controls.Add(this.txtLocaCode);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.btnCustSearch2);
            this.groupBox1.Controls.Add(this.btnCustSearch1);
            this.groupBox1.Controls.Add(this.txtCustNameTo);
            this.groupBox1.Controls.Add(this.txtCustCodeTo);
            this.groupBox1.Controls.Add(this.txtCustNameFrom);
            this.groupBox1.Controls.Add(this.txtCustCodeFrom);
            this.groupBox1.Controls.Add(this.lblCodeTo);
            this.groupBox1.Controls.Add(this.lblCodeFrom);
            this.groupBox1.Location = new System.Drawing.Point(2, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(105, 17);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(265, 21);
            this.cmbCategory.TabIndex = 123;
            this.cmbCategory.Visible = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(28, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(66, 13);
            this.lblCategory.TabIndex = 122;
            this.lblCategory.Text = "Category";
            this.lblCategory.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(549, 78);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(40, 17);
            this.chkAll.TabIndex = 72;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkAllLoca
            // 
            this.chkAllLoca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllLoca.Location = new System.Drawing.Point(549, 52);
            this.chkAllLoca.Name = "chkAllLoca";
            this.chkAllLoca.Size = new System.Drawing.Size(40, 17);
            this.chkAllLoca.TabIndex = 71;
            this.chkAllLoca.Text = "All";
            this.chkAllLoca.UseVisualStyleBackColor = true;
            this.chkAllLoca.Visible = false;
            this.chkAllLoca.CheckedChanged += new System.EventHandler(this.chkAllLoca_CheckedChanged);
            // 
            // btnLocaSearch
            // 
            this.btnLocaSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLocaSearch.BackgroundImage = global::Inventory.Properties.Resources.Search;
            this.btnLocaSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocaSearch.Location = new System.Drawing.Point(517, 49);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(27, 21);
            this.btnLocaSearch.TabIndex = 69;
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Visible = false;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // txtLocaName
            // 
            this.txtLocaName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLocaName.Location = new System.Drawing.Point(224, 49);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(292, 21);
            this.txtLocaName.TabIndex = 1;
            this.txtLocaName.Visible = false;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLocaCode.Location = new System.Drawing.Point(105, 49);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(116, 21);
            this.txtLocaCode.TabIndex = 0;
            this.txtLocaCode.Visible = false;
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(26, 53);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(62, 13);
            this.label31.TabIndex = 66;
            this.label31.Text = "Location";
            this.label31.Visible = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(366, 137);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(115, 21);
            this.dtpDateTo.TabIndex = 7;
            this.dtpDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateTo_KeyDown);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(306, 141);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 10;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(154, 137);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(115, 21);
            this.dtpDateFrom.TabIndex = 6;
            this.dtpDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateFrom_KeyDown);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(82, 141);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(67, 13);
            this.lblDateFrom.TabIndex = 8;
            this.lblDateFrom.Text = "Date From";
            // 
            // btnCustSearch2
            // 
            this.btnCustSearch2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustSearch2.Image = ((System.Drawing.Image)(resources.GetObject("btnCustSearch2.Image")));
            this.btnCustSearch2.Location = new System.Drawing.Point(517, 101);
            this.btnCustSearch2.Name = "btnCustSearch2";
            this.btnCustSearch2.Size = new System.Drawing.Size(30, 21);
            this.btnCustSearch2.TabIndex = 7;
            this.btnCustSearch2.UseVisualStyleBackColor = true;
            this.btnCustSearch2.Click += new System.EventHandler(this.btnCustSearch2_Click);
            // 
            // btnCustSearch1
            // 
            this.btnCustSearch1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustSearch1.Image = ((System.Drawing.Image)(resources.GetObject("btnCustSearch1.Image")));
            this.btnCustSearch1.Location = new System.Drawing.Point(517, 75);
            this.btnCustSearch1.Name = "btnCustSearch1";
            this.btnCustSearch1.Size = new System.Drawing.Size(30, 21);
            this.btnCustSearch1.TabIndex = 6;
            this.btnCustSearch1.UseVisualStyleBackColor = true;
            this.btnCustSearch1.Click += new System.EventHandler(this.btnCustSearch1_Click);
            // 
            // txtCustNameTo
            // 
            this.txtCustNameTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustNameTo.Location = new System.Drawing.Point(224, 101);
            this.txtCustNameTo.Name = "txtCustNameTo";
            this.txtCustNameTo.Size = new System.Drawing.Size(292, 21);
            this.txtCustNameTo.TabIndex = 5;
            this.txtCustNameTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustNameTo_KeyDown);
            // 
            // txtCustCodeTo
            // 
            this.txtCustCodeTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustCodeTo.Location = new System.Drawing.Point(105, 101);
            this.txtCustCodeTo.Name = "txtCustCodeTo";
            this.txtCustCodeTo.Size = new System.Drawing.Size(116, 21);
            this.txtCustCodeTo.TabIndex = 4;
            this.txtCustCodeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCodeTo_KeyDown);
            // 
            // txtCustNameFrom
            // 
            this.txtCustNameFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustNameFrom.Location = new System.Drawing.Point(224, 76);
            this.txtCustNameFrom.Name = "txtCustNameFrom";
            this.txtCustNameFrom.Size = new System.Drawing.Size(292, 21);
            this.txtCustNameFrom.TabIndex = 3;
            // 
            // txtCustCodeFrom
            // 
            this.txtCustCodeFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustCodeFrom.Location = new System.Drawing.Point(105, 76);
            this.txtCustCodeFrom.Name = "txtCustCodeFrom";
            this.txtCustCodeFrom.Size = new System.Drawing.Size(116, 21);
            this.txtCustCodeFrom.TabIndex = 2;
            this.txtCustCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodeFrom_KeyDown);
            // 
            // lblCodeTo
            // 
            this.lblCodeTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCodeTo.AutoSize = true;
            this.lblCodeTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeTo.Location = new System.Drawing.Point(26, 105);
            this.lblCodeTo.Name = "lblCodeTo";
            this.lblCodeTo.Size = new System.Drawing.Size(59, 13);
            this.lblCodeTo.TabIndex = 1;
            this.lblCodeTo.Text = "Code To";
            // 
            // lblCodeFrom
            // 
            this.lblCodeFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCodeFrom.AutoSize = true;
            this.lblCodeFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeFrom.Location = new System.Drawing.Point(26, 79);
            this.lblCodeFrom.Name = "lblCodeFrom";
            this.lblCodeFrom.Size = new System.Drawing.Size(77, 13);
            this.lblCodeFrom.TabIndex = 0;
            this.lblCodeFrom.Text = "Code From";
            // 
            // rbCustomerWise
            // 
            this.rbCustomerWise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbCustomerWise.AutoSize = true;
            this.rbCustomerWise.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomerWise.Location = new System.Drawing.Point(260, 15);
            this.rbCustomerWise.Name = "rbCustomerWise";
            this.rbCustomerWise.Size = new System.Drawing.Size(290, 17);
            this.rbCustomerWise.TabIndex = 13;
            this.rbCustomerWise.Text = "Customer Wise Date Wise Visiting Report";
            this.rbCustomerWise.UseVisualStyleBackColor = true;
            this.rbCustomerWise.CheckedChanged += new System.EventHandler(this.rbCustomerWise_CheckedChanged);
            // 
            // rbCustomerVisiting
            // 
            this.rbCustomerVisiting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbCustomerVisiting.AutoSize = true;
            this.rbCustomerVisiting.Checked = true;
            this.rbCustomerVisiting.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomerVisiting.Location = new System.Drawing.Point(28, 15);
            this.rbCustomerVisiting.Name = "rbCustomerVisiting";
            this.rbCustomerVisiting.Size = new System.Drawing.Size(186, 17);
            this.rbCustomerVisiting.TabIndex = 12;
            this.rbCustomerVisiting.TabStop = true;
            this.rbCustomerVisiting.Text = "Customer Visiting Report";
            this.rbCustomerVisiting.UseVisualStyleBackColor = true;
            this.rbCustomerVisiting.CheckedChanged += new System.EventHandler(this.rbCustomerVisiting_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnClear,
            this.btnDisplay});
            this.toolStrip1.Location = new System.Drawing.Point(3, 230);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(589, 57);
            this.toolStrip1.TabIndex = 120;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.AutoSize = false;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 42);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClear.AutoSize = false;
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 42);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDisplay.AutoSize = false;
            this.btnDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDisplay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.ForeColor = System.Drawing.Color.Black;
            this.btnDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(60, 42);
            this.btnDisplay.Text = "Display";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.rbCustomerVisiting);
            this.groupBox2.Controls.Add(this.rbCustomerWise);
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 43);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            // 
            // frmCustomerVisiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(595, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerVisiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Visiting Report";
            this.Load += new System.EventHandler(this.frmCustomerVisiting_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomerVisiting_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCodeFrom;
        private System.Windows.Forms.TextBox txtCustCodeFrom;
        private System.Windows.Forms.Label lblCodeTo;
        private System.Windows.Forms.TextBox txtCustNameTo;
        private System.Windows.Forms.TextBox txtCustCodeTo;
        private System.Windows.Forms.TextBox txtCustNameFrom;
        private System.Windows.Forms.Button btnCustSearch1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Button btnCustSearch2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnDisplay;
        private System.Windows.Forms.RadioButton rbCustomerWise;
        private System.Windows.Forms.RadioButton rbCustomerVisiting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chkAllLoca;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
    }
}