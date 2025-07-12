namespace Inventory
{
    partial class frmReportOption
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
            this.plOrderDetailsDoc = new System.Windows.Forms.Panel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkAllLoca = new System.Windows.Forms.CheckBox();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.lblLoca = new System.Windows.Forms.Label();
            this.btnCustToSearch = new System.Windows.Forms.Button();
            this.txtCodeToName = new System.Windows.Forms.TextBox();
            this.txtCodeTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCusSearch = new System.Windows.Forms.Button();
            this.chkWithMoreDetails = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtCodeFromName = new System.Windows.Forms.TextBox();
            this.txtCodeFrom = new System.Windows.Forms.TextBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDatefrom = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.chkWithoutVen = new System.Windows.Forms.CheckBox();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAddressLable = new System.Windows.Forms.CheckBox();
            this.chkInformation = new System.Windows.Forms.CheckBox();
            this.chkAbroad = new System.Windows.Forms.CheckBox();
            this.chkWorkShop = new System.Windows.Forms.CheckBox();
            this.plOrderDetailsDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plOrderDetailsDoc
            // 
            this.plOrderDetailsDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plOrderDetailsDoc.Controls.Add(this.cmbCategory);
            this.plOrderDetailsDoc.Controls.Add(this.lblCategory);
            this.plOrderDetailsDoc.Controls.Add(this.chkAllLoca);
            this.plOrderDetailsDoc.Controls.Add(this.btnLocaSearch);
            this.plOrderDetailsDoc.Controls.Add(this.txtLocaName);
            this.plOrderDetailsDoc.Controls.Add(this.txtLocaCode);
            this.plOrderDetailsDoc.Controls.Add(this.lblLoca);
            this.plOrderDetailsDoc.Controls.Add(this.btnCustToSearch);
            this.plOrderDetailsDoc.Controls.Add(this.txtCodeToName);
            this.plOrderDetailsDoc.Controls.Add(this.txtCodeTo);
            this.plOrderDetailsDoc.Controls.Add(this.label1);
            this.plOrderDetailsDoc.Controls.Add(this.btnCusSearch);
            this.plOrderDetailsDoc.Controls.Add(this.chkWithMoreDetails);
            this.plOrderDetailsDoc.Controls.Add(this.chkAll);
            this.plOrderDetailsDoc.Controls.Add(this.txtCodeFromName);
            this.plOrderDetailsDoc.Controls.Add(this.txtCodeFrom);
            this.plOrderDetailsDoc.Controls.Add(this.lblRecord);
            this.plOrderDetailsDoc.Controls.Add(this.lblDateTo);
            this.plOrderDetailsDoc.Controls.Add(this.lblDatefrom);
            this.plOrderDetailsDoc.Controls.Add(this.dtDateTo);
            this.plOrderDetailsDoc.Controls.Add(this.dtDateFrom);
            this.plOrderDetailsDoc.Location = new System.Drawing.Point(0, 1);
            this.plOrderDetailsDoc.Name = "plOrderDetailsDoc";
            this.plOrderDetailsDoc.Size = new System.Drawing.Size(588, 177);
            this.plOrderDetailsDoc.TabIndex = 42;
            this.plOrderDetailsDoc.Visible = false;
            this.plOrderDetailsDoc.Paint += new System.Windows.Forms.PaintEventHandler(this.plOrderDetailsDoc_Paint);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(114, 137);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(243, 21);
            this.cmbCategory.TabIndex = 74;
            this.cmbCategory.Visible = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(15, 140);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(66, 13);
            this.lblCategory.TabIndex = 73;
            this.lblCategory.Text = "Category";
            this.lblCategory.Visible = false;
            // 
            // chkAllLoca
            // 
            this.chkAllLoca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllLoca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAllLoca.Location = new System.Drawing.Point(503, 32);
            this.chkAllLoca.Name = "chkAllLoca";
            this.chkAllLoca.Size = new System.Drawing.Size(40, 17);
            this.chkAllLoca.TabIndex = 66;
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
            this.btnLocaSearch.Location = new System.Drawing.Point(479, 28);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(23, 21);
            this.btnLocaSearch.TabIndex = 65;
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Visible = false;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // txtLocaName
            // 
            this.txtLocaName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLocaName.Location = new System.Drawing.Point(214, 28);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(262, 21);
            this.txtLocaName.TabIndex = 64;
            this.txtLocaName.Visible = false;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLocaCode.Location = new System.Drawing.Point(114, 28);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(97, 21);
            this.txtLocaCode.TabIndex = 63;
            this.txtLocaCode.Visible = false;
            // 
            // lblLoca
            // 
            this.lblLoca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoca.AutoSize = true;
            this.lblLoca.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoca.Location = new System.Drawing.Point(15, 32);
            this.lblLoca.Name = "lblLoca";
            this.lblLoca.Size = new System.Drawing.Size(62, 13);
            this.lblLoca.TabIndex = 62;
            this.lblLoca.Text = "Location";
            this.lblLoca.Visible = false;
            // 
            // btnCustToSearch
            // 
            this.btnCustToSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustToSearch.BackgroundImage = global::Inventory.Properties.Resources.Search;
            this.btnCustToSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustToSearch.Location = new System.Drawing.Point(479, 81);
            this.btnCustToSearch.Name = "btnCustToSearch";
            this.btnCustToSearch.Size = new System.Drawing.Size(24, 19);
            this.btnCustToSearch.TabIndex = 13;
            this.btnCustToSearch.UseVisualStyleBackColor = true;
            this.btnCustToSearch.Visible = false;
            this.btnCustToSearch.Click += new System.EventHandler(this.btnCustToSearch_Click);
            // 
            // txtCodeToName
            // 
            this.txtCodeToName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodeToName.Location = new System.Drawing.Point(214, 81);
            this.txtCodeToName.Name = "txtCodeToName";
            this.txtCodeToName.Size = new System.Drawing.Size(262, 21);
            this.txtCodeToName.TabIndex = 12;
            // 
            // txtCodeTo
            // 
            this.txtCodeTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodeTo.Location = new System.Drawing.Point(114, 81);
            this.txtCodeTo.Name = "txtCodeTo";
            this.txtCodeTo.Size = new System.Drawing.Size(97, 21);
            this.txtCodeTo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Record";
            // 
            // btnCusSearch
            // 
            this.btnCusSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCusSearch.BackgroundImage = global::Inventory.Properties.Resources.Search;
            this.btnCusSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCusSearch.Location = new System.Drawing.Point(480, 56);
            this.btnCusSearch.Name = "btnCusSearch";
            this.btnCusSearch.Size = new System.Drawing.Size(24, 19);
            this.btnCusSearch.TabIndex = 9;
            this.btnCusSearch.UseVisualStyleBackColor = true;
            this.btnCusSearch.Visible = false;
            this.btnCusSearch.Click += new System.EventHandler(this.btnCusSearch_Click);
            // 
            // chkWithMoreDetails
            // 
            this.chkWithMoreDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkWithMoreDetails.AutoSize = true;
            this.chkWithMoreDetails.Location = new System.Drawing.Point(378, 146);
            this.chkWithMoreDetails.Name = "chkWithMoreDetails";
            this.chkWithMoreDetails.Size = new System.Drawing.Size(126, 17);
            this.chkWithMoreDetails.TabIndex = 8;
            this.chkWithMoreDetails.Text = "With More Details";
            this.chkWithMoreDetails.UseVisualStyleBackColor = true;
            this.chkWithMoreDetails.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAll.AutoSize = true;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Location = new System.Drawing.Point(503, 81);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(40, 17);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtCodeFromName
            // 
            this.txtCodeFromName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodeFromName.Location = new System.Drawing.Point(214, 55);
            this.txtCodeFromName.Name = "txtCodeFromName";
            this.txtCodeFromName.Size = new System.Drawing.Size(262, 21);
            this.txtCodeFromName.TabIndex = 6;
            // 
            // txtCodeFrom
            // 
            this.txtCodeFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodeFrom.Location = new System.Drawing.Point(114, 55);
            this.txtCodeFrom.Name = "txtCodeFrom";
            this.txtCodeFrom.Size = new System.Drawing.Size(97, 21);
            this.txtCodeFrom.TabIndex = 5;
            this.txtCodeFrom.TextChanged += new System.EventHandler(this.txtCodeFrom_TextChanged);
            this.txtCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodeFrom_KeyDown);
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(17, 58);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(52, 13);
            this.lblRecord.TabIndex = 4;
            this.lblRecord.Text = "Record";
            // 
            // lblDateTo
            // 
            this.lblDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(217, 116);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(57, 13);
            this.lblDateTo.TabIndex = 3;
            this.lblDateTo.Text = "Date To";
            // 
            // lblDatefrom
            // 
            this.lblDatefrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatefrom.AutoSize = true;
            this.lblDatefrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatefrom.Location = new System.Drawing.Point(17, 116);
            this.lblDatefrom.Name = "lblDatefrom";
            this.lblDatefrom.Size = new System.Drawing.Size(75, 13);
            this.lblDatefrom.TabIndex = 2;
            this.lblDatefrom.Text = "Date From";
            // 
            // dtDateTo
            // 
            this.dtDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(287, 110);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(131, 21);
            this.dtDateTo.TabIndex = 1;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(114, 110);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(97, 21);
            this.dtDateFrom.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(305, 184);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(139, 31);
            this.btnExit.TabIndex = 41;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisplay.Location = new System.Drawing.Point(169, 184);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(130, 31);
            this.btnDisplay.TabIndex = 40;
            this.btnDisplay.Text = "&Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.chkInactive);
            this.panel1.Controls.Add(this.chkWithoutVen);
            this.panel1.Controls.Add(this.dtBirthDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkAddressLable);
            this.panel1.Controls.Add(this.chkInformation);
            this.panel1.Controls.Add(this.chkAbroad);
            this.panel1.Controls.Add(this.chkWorkShop);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 175);
            this.panel1.TabIndex = 39;
            // 
            // chkInactive
            // 
            this.chkInactive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkInactive.AutoSize = true;
            this.chkInactive.Location = new System.Drawing.Point(371, 8);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(72, 17);
            this.chkInactive.TabIndex = 5;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // chkWithoutVen
            // 
            this.chkWithoutVen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkWithoutVen.AutoSize = true;
            this.chkWithoutVen.Location = new System.Drawing.Point(216, 8);
            this.chkWithoutVen.Name = "chkWithoutVen";
            this.chkWithoutVen.Size = new System.Drawing.Size(130, 17);
            this.chkWithoutVen.TabIndex = 4;
            this.chkWithoutVen.Text = "Without Venerable";
            this.chkWithoutVen.UseVisualStyleBackColor = true;
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtBirthDate.CustomFormat = "dd/MM/.......";
            this.dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBirthDate.Location = new System.Drawing.Point(88, 6);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(119, 21);
            this.dtBirthDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birth Date";
            // 
            // chkAddressLable
            // 
            this.chkAddressLable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAddressLable.AutoSize = true;
            this.chkAddressLable.Location = new System.Drawing.Point(100, 66);
            this.chkAddressLable.Name = "chkAddressLable";
            this.chkAddressLable.Size = new System.Drawing.Size(106, 17);
            this.chkAddressLable.TabIndex = 6;
            this.chkAddressLable.Text = "Address Lable";
            this.chkAddressLable.UseVisualStyleBackColor = true;
            // 
            // chkInformation
            // 
            this.chkInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkInformation.AutoSize = true;
            this.chkInformation.Location = new System.Drawing.Point(287, 36);
            this.chkInformation.Name = "chkInformation";
            this.chkInformation.Size = new System.Drawing.Size(139, 17);
            this.chkInformation.TabIndex = 29;
            this.chkInformation.Text = "Don\'t send Birthday";
            this.chkInformation.UseVisualStyleBackColor = true;
            // 
            // chkAbroad
            // 
            this.chkAbroad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAbroad.AutoSize = true;
            this.chkAbroad.Location = new System.Drawing.Point(62, 37);
            this.chkAbroad.Name = "chkAbroad";
            this.chkAbroad.Size = new System.Drawing.Size(67, 17);
            this.chkAbroad.TabIndex = 26;
            this.chkAbroad.Text = "Abroad";
            this.chkAbroad.UseVisualStyleBackColor = true;
            // 
            // chkWorkShop
            // 
            this.chkWorkShop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkWorkShop.AutoSize = true;
            this.chkWorkShop.Location = new System.Drawing.Point(161, 36);
            this.chkWorkShop.Name = "chkWorkShop";
            this.chkWorkShop.Size = new System.Drawing.Size(88, 17);
            this.chkWorkShop.TabIndex = 27;
            this.chkWorkShop.Text = "Work Shop";
            this.chkWorkShop.UseVisualStyleBackColor = true;
            // 
            // frmReportOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(589, 219);
            this.Controls.Add(this.plOrderDetailsDoc);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReportOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patients Birthday";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportOption_FormClosing);
            this.Load += new System.EventHandler(this.frmReportOption_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportOption_KeyDown);
            this.plOrderDetailsDoc.ResumeLayout(false);
            this.plOrderDetailsDoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plOrderDetailsDoc;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.Label lblLoca;
        private System.Windows.Forms.Button btnCustToSearch;
        private System.Windows.Forms.TextBox txtCodeToName;
        private System.Windows.Forms.TextBox txtCodeTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCusSearch;
        private System.Windows.Forms.CheckBox chkWithMoreDetails;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TextBox txtCodeFromName;
        private System.Windows.Forms.TextBox txtCodeFrom;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDatefrom;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.CheckBox chkWithoutVen;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAddressLable;
        private System.Windows.Forms.CheckBox chkInformation;
        private System.Windows.Forms.CheckBox chkAbroad;
        private System.Windows.Forms.CheckBox chkWorkShop;
        private System.Windows.Forms.CheckBox chkAllLoca;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
    }
}