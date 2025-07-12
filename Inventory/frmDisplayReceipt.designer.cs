namespace Inventory
{
    partial class frmDisplayReceipt
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
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.btnDisplaydayend = new System.Windows.Forms.Button();
            this.btnDisplayAll = new System.Windows.Forms.Button();
            this.btnDisplayReceipt = new System.Windows.Forms.Button();
            this.cmbReceiptNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbReportID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLocaDes = new System.Windows.Forms.ComboBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocaCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.btnPrintBill);
            this.groupBox1.Controls.Add(this.btnDisplaydayend);
            this.groupBox1.Controls.Add(this.btnDisplayAll);
            this.groupBox1.Controls.Add(this.btnDisplayReceipt);
            this.groupBox1.Controls.Add(this.cmbReceiptNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbReportID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbLocaDes);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbLocaCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpBillDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(5, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1150, 543);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.Location = new System.Drawing.Point(736, 505);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(99, 29);
            this.btnPrintBill.TabIndex = 30;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // btnDisplaydayend
            // 
            this.btnDisplaydayend.Location = new System.Drawing.Point(627, 50);
            this.btnDisplaydayend.Name = "btnDisplaydayend";
            this.btnDisplaydayend.Size = new System.Drawing.Size(99, 23);
            this.btnDisplaydayend.TabIndex = 30;
            this.btnDisplaydayend.Text = "Display Dayend ";
            this.btnDisplaydayend.UseVisualStyleBackColor = true;
            this.btnDisplaydayend.Visible = false;
            this.btnDisplaydayend.Click += new System.EventHandler(this.btnDisplaydayend_Click);
            // 
            // btnDisplayAll
            // 
            this.btnDisplayAll.Location = new System.Drawing.Point(520, 50);
            this.btnDisplayAll.Name = "btnDisplayAll";
            this.btnDisplayAll.Size = new System.Drawing.Size(99, 23);
            this.btnDisplayAll.TabIndex = 29;
            this.btnDisplayAll.Text = "Display All";
            this.btnDisplayAll.UseVisualStyleBackColor = true;
            this.btnDisplayAll.Click += new System.EventHandler(this.btnDisplayAll_Click);
            // 
            // btnDisplayReceipt
            // 
            this.btnDisplayReceipt.Location = new System.Drawing.Point(627, 23);
            this.btnDisplayReceipt.Name = "btnDisplayReceipt";
            this.btnDisplayReceipt.Size = new System.Drawing.Size(99, 23);
            this.btnDisplayReceipt.TabIndex = 28;
            this.btnDisplayReceipt.Text = "Display >>";
            this.btnDisplayReceipt.UseVisualStyleBackColor = true;
            this.btnDisplayReceipt.Visible = false;
            this.btnDisplayReceipt.Click += new System.EventHandler(this.btnDisplayReceipt_Click);
            // 
            // cmbReceiptNo
            // 
            this.cmbReceiptNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiptNo.FormattingEnabled = true;
            this.cmbReceiptNo.Location = new System.Drawing.Point(403, 51);
            this.cmbReceiptNo.Name = "cmbReceiptNo";
            this.cmbReceiptNo.Size = new System.Drawing.Size(108, 21);
            this.cmbReceiptNo.TabIndex = 27;
            this.cmbReceiptNo.SelectedIndexChanged += new System.EventHandler(this.cmbReceiptNo_SelectedIndexChanged);
            this.cmbReceiptNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReceiptNo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Receipt No";
            // 
            // cmbReportID
            // 
            this.cmbReportID.FormattingEnabled = true;
            this.cmbReportID.Location = new System.Drawing.Point(237, 53);
            this.cmbReportID.Name = "cmbReportID";
            this.cmbReportID.Size = new System.Drawing.Size(95, 21);
            this.cmbReportID.TabIndex = 25;
            this.cmbReportID.Text = "-select-";
            this.cmbReportID.SelectedIndexChanged += new System.EventHandler(this.cmbReportID_SelectedIndexChanged);
            this.cmbReportID.SelectedValueChanged += new System.EventHandler(this.cmbReportID_SelectedValueChanged);
            this.cmbReportID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReportID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Report ID";
            // 
            // cmbLocaDes
            // 
            this.cmbLocaDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocaDes.FormattingEnabled = true;
            this.cmbLocaDes.Location = new System.Drawing.Point(120, 22);
            this.cmbLocaDes.Name = "cmbLocaDes";
            this.cmbLocaDes.Size = new System.Drawing.Size(212, 21);
            this.cmbLocaDes.TabIndex = 23;
            this.cmbLocaDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLocaDes_KeyDown);
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(56, 53);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(100, 21);
            this.cmbUnit.TabIndex = 20;
            this.cmbUnit.Text = "-select-";
            this.cmbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUnit_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Unit";
            // 
            // cmbLocaCode
            // 
            this.cmbLocaCode.FormattingEnabled = true;
            this.cmbLocaCode.Location = new System.Drawing.Point(56, 22);
            this.cmbLocaCode.MaxDropDownItems = 50;
            this.cmbLocaCode.Name = "cmbLocaCode";
            this.cmbLocaCode.Size = new System.Drawing.Size(58, 21);
            this.cmbLocaCode.TabIndex = 17;
            this.cmbLocaCode.Text = "-select-";
            this.cmbLocaCode.SelectedValueChanged += new System.EventHandler(this.cmbLocaCode_SelectedValueChanged);
            this.cmbLocaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLocaCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Location";
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBillDate.Location = new System.Drawing.Point(403, 23);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(108, 20);
            this.dtpBillDate.TabIndex = 15;
            this.dtpBillDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBillDate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bill Date";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 87);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(718, 447);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Code";
            this.columnHeader1.Width = 71;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Description";
            this.columnHeader2.Width = 189;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Unit Price";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantity";
            this.columnHeader4.Width = 76;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Amount";
            this.columnHeader5.Width = 91;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Bill Time";
            this.columnHeader6.Width = 86;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "User Name";
            this.columnHeader7.Width = 151;
            // 
            // frmDisplayReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 540);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDisplayReceipt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display Receipt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDisplayReceipt_FormClosed);
            this.Load += new System.EventHandler(this.frmDisplayReceipt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox cmbLocaCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLocaDes;
        private System.Windows.Forms.ComboBox cmbReportID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbReceiptNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnDisplayReceipt;
        private System.Windows.Forms.Button btnDisplayAll;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Button btnDisplaydayend;
    }
}