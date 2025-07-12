namespace Inventory
{
    partial class frmDayEndProcessNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayEndProcessNew));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalesAmmount = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblNetSales = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbComPrts = new System.Windows.Forms.ComboBox();
            this.btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtCOMPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPAwait = new System.Windows.Forms.Label();
            this.btnCheckDuplicate = new System.Windows.Forms.Button();
            this.lvUnitSales = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkDuplicated = new System.Windows.Forms.CheckBox();
            this.btnRemoveDup = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Location = new System.Drawing.Point(0, 222);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 66);
            this.toolStrip1.TabIndex = 142;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(473, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 144;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(367, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 145;
            this.button1.Text = "Day End";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnDayEnd_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(261, 231);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 50);
            this.btnCheck.TabIndex = 145;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "Sales Date";
            // 
            // lblSalesAmmount
            // 
            this.lblSalesAmmount.AutoSize = true;
            this.lblSalesAmmount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSalesAmmount.Location = new System.Drawing.Point(6, 82);
            this.lblSalesAmmount.Name = "lblSalesAmmount";
            this.lblSalesAmmount.Size = new System.Drawing.Size(76, 13);
            this.lblSalesAmmount.TabIndex = 148;
            this.lblSalesAmmount.Text = "Sales Amount";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(90, 23);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 150;
            // 
            // lblNetSales
            // 
            this.lblNetSales.AutoSize = true;
            this.lblNetSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNetSales.Location = new System.Drawing.Point(84, 80);
            this.lblNetSales.Name = "lblNetSales";
            this.lblNetSales.Size = new System.Drawing.Size(0, 17);
            this.lblNetSales.TabIndex = 148;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbComPrts);
            this.groupBox1.Controls.Add(this.btn);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.txtCOMPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.lblNetSales);
            this.groupBox1.Controls.Add(this.lblSalesAmmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 142);
            this.groupBox1.TabIndex = 151;
            this.groupBox1.TabStop = false;
            // 
            // cmbComPrts
            // 
            this.cmbComPrts.FormattingEnabled = true;
            this.cmbComPrts.Location = new System.Drawing.Point(90, 55);
            this.cmbComPrts.Name = "cmbComPrts";
            this.cmbComPrts.Size = new System.Drawing.Size(49, 21);
            this.cmbComPrts.TabIndex = 158;
            // 
            // btn
            // 
            this.btn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(145, 55);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(127, 21);
            this.btn.TabIndex = 157;
            this.btn.Text = "Get Available Ports";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(122, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 156;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtCOMPort
            // 
            this.txtCOMPort.Location = new System.Drawing.Point(90, 93);
            this.txtCOMPort.Name = "txtCOMPort";
            this.txtCOMPort.Size = new System.Drawing.Size(26, 20);
            this.txtCOMPort.TabIndex = 155;
            this.txtCOMPort.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 152;
            this.label2.Text = "COM Port";
            // 
            // lblPAwait
            // 
            this.lblPAwait.AutoSize = true;
            this.lblPAwait.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPAwait.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPAwait.Location = new System.Drawing.Point(27, 171);
            this.lblPAwait.Name = "lblPAwait";
            this.lblPAwait.Size = new System.Drawing.Size(130, 21);
            this.lblPAwait.TabIndex = 152;
            this.lblPAwait.Text = "....Please Wait....";
            // 
            // btnCheckDuplicate
            // 
            this.btnCheckDuplicate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckDuplicate.Location = new System.Drawing.Point(455, 12);
            this.btnCheckDuplicate.Name = "btnCheckDuplicate";
            this.btnCheckDuplicate.Size = new System.Drawing.Size(127, 27);
            this.btnCheckDuplicate.TabIndex = 160;
            this.btnCheckDuplicate.Text = "Check Duplicates";
            this.btnCheckDuplicate.UseVisualStyleBackColor = true;
            this.btnCheckDuplicate.Click += new System.EventHandler(this.btnCheckDuplicate_Click);
            // 
            // lvUnitSales
            // 
            this.lvUnitSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUnitSales.AutoArrange = false;
            this.lvUnitSales.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lvUnitSales.GridLines = true;
            this.lvUnitSales.HideSelection = false;
            this.lvUnitSales.Location = new System.Drawing.Point(287, 45);
            this.lvUnitSales.Name = "lvUnitSales";
            this.lvUnitSales.ShowItemToolTips = true;
            this.lvUnitSales.Size = new System.Drawing.Size(295, 174);
            this.lvUnitSales.TabIndex = 208;
            this.lvUnitSales.UseCompatibleStateImageBehavior = false;
            this.lvUnitSales.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "";
            this.columnHeader2.Text = "Unit";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 45;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "RepId";
            this.columnHeader4.Width = 45;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "";
            this.columnHeader3.Text = "Net Amount";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 110;
            // 
            // chkDuplicated
            // 
            this.chkDuplicated.AutoSize = true;
            this.chkDuplicated.Enabled = false;
            this.chkDuplicated.Location = new System.Drawing.Point(354, 18);
            this.chkDuplicated.Name = "chkDuplicated";
            this.chkDuplicated.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDuplicated.Size = new System.Drawing.Size(93, 17);
            this.chkDuplicated.TabIndex = 209;
            this.chkDuplicated.Text = "No Duplicates";
            this.chkDuplicated.UseVisualStyleBackColor = true;
            // 
            // btnRemoveDup
            // 
            this.btnRemoveDup.Enabled = false;
            this.btnRemoveDup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDup.Location = new System.Drawing.Point(446, 145);
            this.btnRemoveDup.Name = "btnRemoveDup";
            this.btnRemoveDup.Size = new System.Drawing.Size(127, 21);
            this.btnRemoveDup.TabIndex = 210;
            this.btnRemoveDup.Text = "Remove Duplicates";
            this.btnRemoveDup.UseVisualStyleBackColor = true;
            this.btnRemoveDup.Click += new System.EventHandler(this.btnRemoveDup_Click);
            // 
            // frmDayEndProcessNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(585, 288);
            this.Controls.Add(this.chkDuplicated);
            this.Controls.Add(this.btnCheckDuplicate);
            this.Controls.Add(this.lvUnitSales);
            this.Controls.Add(this.lblPAwait);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnRemoveDup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDayEndProcessNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DayEnd Process";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDayEndProcess_FormClosed);
            this.Load += new System.EventHandler(this.frmDayEndProcess_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalesAmmount;
        private System.Windows.Forms.Label lblNetSales;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPAwait;
        private System.Windows.Forms.TextBox txtCOMPort;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox cmbComPrts;
        private System.Windows.Forms.Button btnCheckDuplicate;
        private System.Windows.Forms.ListView lvUnitSales;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox chkDuplicated;
        private System.Windows.Forms.Button btnRemoveDup;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}