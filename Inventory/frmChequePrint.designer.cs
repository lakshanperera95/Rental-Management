namespace Inventory
{
    partial class frmChequePrint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChequePrint));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pnlCheque = new System.Windows.Forms.Panel();
            this.lblHolderSeal = new System.Windows.Forms.Panel();
            this.lblImgHolder = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblCut = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.lblAmountText = new System.Windows.Forms.Label();
            this.lblY4 = new System.Windows.Forms.Label();
            this.lblY3 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblM2 = new System.Windows.Forms.Label();
            this.lblM1 = new System.Windows.Forms.Label();
            this.lblD2 = new System.Windows.Forms.Label();
            this.lblD1 = new System.Windows.Forms.Label();
            this.lblPay = new System.Windows.Forms.Label();
            this.lblImgPO = new System.Windows.Forms.PictureBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.txtX = new System.Windows.Forms.NumericUpDown();
            this.txtY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chkPayeeOnly = new System.Windows.Forms.CheckBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadPrintedCheqDetails = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lblCheqAmt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCheqDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCheqNo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.dataGridViewPendingPayments = new System.Windows.Forms.DataGridView();
            this.payDocumentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsPendingChequePrintListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.btnSupplierSearch = new System.Windows.Forms.Button();
            this.btnSaveBankFormat = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPageY = new System.Windows.Forms.NumericUpDown();
            this.txtPageX = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.cmbNameProfile = new System.Windows.Forms.ComboBox();
            this.lblComType = new System.Windows.Forms.Label();
            this.pnlCheque.SuspendLayout();
            this.lblHolderSeal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblImgHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImgPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPendingChequePrintListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageX)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(168, 488);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 48);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // pnlCheque
            // 
            this.pnlCheque.BackColor = System.Drawing.SystemColors.Window;
            this.pnlCheque.Controls.Add(this.lblHolderSeal);
            this.pnlCheque.Controls.Add(this.lblCut);
            this.pnlCheque.Controls.Add(this.lblAmountValue);
            this.pnlCheque.Controls.Add(this.lblAmountText);
            this.pnlCheque.Controls.Add(this.lblY4);
            this.pnlCheque.Controls.Add(this.lblY3);
            this.pnlCheque.Controls.Add(this.lblY2);
            this.pnlCheque.Controls.Add(this.lblY1);
            this.pnlCheque.Controls.Add(this.lblM2);
            this.pnlCheque.Controls.Add(this.lblM1);
            this.pnlCheque.Controls.Add(this.lblD2);
            this.pnlCheque.Controls.Add(this.lblD1);
            this.pnlCheque.Controls.Add(this.lblPay);
            this.pnlCheque.Controls.Add(this.lblImgPO);
            this.pnlCheque.Location = new System.Drawing.Point(12, 24);
            this.pnlCheque.Name = "pnlCheque";
            this.pnlCheque.Size = new System.Drawing.Size(708, 337);
            this.pnlCheque.TabIndex = 2;
            // 
            // lblHolderSeal
            // 
            this.lblHolderSeal.Controls.Add(this.lblImgHolder);
            this.lblHolderSeal.Controls.Add(this.lblCompanyName);
            this.lblHolderSeal.Location = new System.Drawing.Point(448, 184);
            this.lblHolderSeal.Name = "lblHolderSeal";
            this.lblHolderSeal.Size = new System.Drawing.Size(256, 112);
            this.lblHolderSeal.TabIndex = 15;
            this.lblHolderSeal.Visible = false;
            // 
            // lblImgHolder
            // 
            this.lblImgHolder.Location = new System.Drawing.Point(8, 56);
            this.lblImgHolder.Name = "lblImgHolder";
            this.lblImgHolder.Size = new System.Drawing.Size(232, 48);
            this.lblImgHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblImgHolder.TabIndex = 14;
            this.lblImgHolder.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(8, 16);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(232, 16);
            this.lblCompanyName.TabIndex = 13;
            this.lblCompanyName.Text = "Company Name";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCut
            // 
            this.lblCut.BackColor = System.Drawing.Color.Transparent;
            this.lblCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCut.Location = new System.Drawing.Point(608, 96);
            this.lblCut.Name = "lblCut";
            this.lblCut.Size = new System.Drawing.Size(60, 20);
            this.lblCut.TabIndex = 12;
            this.lblCut.Text = "XXXX";
            this.lblCut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCut.Visible = false;
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountValue.Location = new System.Drawing.Point(475, 135);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(202, 28);
            this.lblAmountValue.TabIndex = 10;
            this.lblAmountValue.Text = "Amount Value";
            this.lblAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountText
            // 
            this.lblAmountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountText.Location = new System.Drawing.Point(75, 125);
            this.lblAmountText.Name = "lblAmountText";
            this.lblAmountText.Size = new System.Drawing.Size(340, 93);
            this.lblAmountText.TabIndex = 9;
            this.lblAmountText.Text = "Amount Text";
            // 
            // lblY4
            // 
            this.lblY4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY4.Location = new System.Drawing.Point(652, 27);
            this.lblY4.Name = "lblY4";
            this.lblY4.Size = new System.Drawing.Size(20, 20);
            this.lblY4.TabIndex = 7;
            this.lblY4.Text = "Y";
            this.lblY4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY3
            // 
            this.lblY3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY3.Location = new System.Drawing.Point(628, 27);
            this.lblY3.Name = "lblY3";
            this.lblY3.Size = new System.Drawing.Size(20, 20);
            this.lblY3.TabIndex = 6;
            this.lblY3.Text = "Y";
            this.lblY3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY2
            // 
            this.lblY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY2.Location = new System.Drawing.Point(604, 27);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(20, 20);
            this.lblY2.TabIndex = 5;
            this.lblY2.Text = "Y";
            this.lblY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY1
            // 
            this.lblY1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY1.Location = new System.Drawing.Point(580, 27);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(20, 20);
            this.lblY1.TabIndex = 4;
            this.lblY1.Text = "Y";
            this.lblY1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblM2
            // 
            this.lblM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblM2.Location = new System.Drawing.Point(556, 27);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(20, 20);
            this.lblM2.TabIndex = 3;
            this.lblM2.Text = "M";
            this.lblM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblM1
            // 
            this.lblM1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblM1.Location = new System.Drawing.Point(532, 27);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(20, 20);
            this.lblM1.TabIndex = 2;
            this.lblM1.Text = "M";
            this.lblM1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblD2
            // 
            this.lblD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD2.Location = new System.Drawing.Point(508, 27);
            this.lblD2.Name = "lblD2";
            this.lblD2.Size = new System.Drawing.Size(20, 20);
            this.lblD2.TabIndex = 1;
            this.lblD2.Text = "D";
            this.lblD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblD1
            // 
            this.lblD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD1.Location = new System.Drawing.Point(484, 27);
            this.lblD1.Name = "lblD1";
            this.lblD1.Size = new System.Drawing.Size(20, 20);
            this.lblD1.TabIndex = 0;
            this.lblD1.Text = "D";
            this.lblD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPay
            // 
            this.lblPay.BackColor = System.Drawing.Color.Transparent;
            this.lblPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPay.Location = new System.Drawing.Point(75, 87);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(401, 16);
            this.lblPay.TabIndex = 8;
            this.lblPay.Text = "Pay";
            // 
            // lblImgPO
            // 
            this.lblImgPO.Image = global::Inventory.Properties.Resources.Ac_payee_only1;
            this.lblImgPO.Location = new System.Drawing.Point(-16, -8);
            this.lblImgPO.Name = "lblImgPO";
            this.lblImgPO.Size = new System.Drawing.Size(160, 104);
            this.lblImgPO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblImgPO.TabIndex = 11;
            this.lblImgPO.TabStop = false;
            this.lblImgPO.Visible = false;
            // 
            // cmbField
            // 
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Items.AddRange(new object[] {
            "D1",
            "D2",
            "M1",
            "M2",
            "Y1",
            "Y2",
            "Y3",
            "Y4",
            "Pay",
            "AmountText",
            "AmountValue",
            "Cut",
            "ImgPO",
            "HolderSeal"});
            this.cmbField.Location = new System.Drawing.Point(514, 370);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(158, 21);
            this.cmbField.TabIndex = 3;
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(514, 397);
            this.txtX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(64, 20);
            this.txtX.TabIndex = 4;
            this.txtX.ValueChanged += new System.EventHandler(this.txtX_ValueChanged);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(627, 397);
            this.txtY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(64, 20);
            this.txtY.TabIndex = 5;
            this.txtY.ValueChanged += new System.EventHandler(this.txtY_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y";
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(50, 392);
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(399, 20);
            this.txtPay.TabIndex = 9;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(50, 366);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 10;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(323, 366);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(126, 20);
            this.txtAmount.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Pay";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(86, 488);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 48);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkPayeeOnly
            // 
            this.chkPayeeOnly.AutoSize = true;
            this.chkPayeeOnly.Location = new System.Drawing.Point(344, 416);
            this.chkPayeeOnly.Name = "chkPayeeOnly";
            this.chkPayeeOnly.Size = new System.Drawing.Size(104, 17);
            this.chkPayeeOnly.TabIndex = 16;
            this.chkPayeeOnly.Text = "Print Payee Only";
            this.chkPayeeOnly.UseVisualStyleBackColor = true;
            this.chkPayeeOnly.CheckedChanged += new System.EventHandler(this.chkPayeeOnly_CheckedChanged);
            // 
            // btnDefault
            // 
            this.btnDefault.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDefault.FlatAppearance.BorderSize = 0;
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.Location = new System.Drawing.Point(256, 513);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(132, 23);
            this.btnDefault.TabIndex = 17;
            this.btnDefault.Text = "Default Settings";
            this.btnDefault.UseVisualStyleBackColor = false;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(488, 479);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Bank Format";
            // 
            // cmbBankName
            // 
            this.cmbBankName.DisplayMember = "Bank_Name";
            this.cmbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(488, 495);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(228, 21);
            this.cmbBankName.TabIndex = 18;
            this.cmbBankName.SelectedIndexChanged += new System.EventHandler(this.cmbBankName_SelectedIndexChanged);
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(96, 40);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(304, 20);
            this.txtSuppName.TabIndex = 21;
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Location = new System.Drawing.Point(8, 40);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(87, 20);
            this.txtSuppCode.TabIndex = 20;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Enter += new System.EventHandler(this.txtSuppCode_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Supplier";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadPrintedCheqDetails);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblCheqAmt);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblCheqDate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblCheqNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblBank);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblDocNo);
            this.groupBox1.Controls.Add(this.dataGridViewPendingPayments);
            this.groupBox1.Controls.Add(this.btnSupplierSearch);
            this.groupBox1.Controls.Add(this.txtSuppName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSuppCode);
            this.groupBox1.Location = new System.Drawing.Point(728, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 536);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Details";
            // 
            // btnLoadPrintedCheqDetails
            // 
            this.btnLoadPrintedCheqDetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoadPrintedCheqDetails.FlatAppearance.BorderSize = 0;
            this.btnLoadPrintedCheqDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPrintedCheqDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPrintedCheqDetails.Location = new System.Drawing.Point(272, 16);
            this.btnLoadPrintedCheqDetails.Name = "btnLoadPrintedCheqDetails";
            this.btnLoadPrintedCheqDetails.Size = new System.Drawing.Size(128, 23);
            this.btnLoadPrintedCheqDetails.TabIndex = 27;
            this.btnLoadPrintedCheqDetails.Text = "Load Printed Cheques";
            this.btnLoadPrintedCheqDetails.UseVisualStyleBackColor = false;
            this.btnLoadPrintedCheqDetails.Visible = false;
            this.btnLoadPrintedCheqDetails.Click += new System.EventHandler(this.btnLoadPrintedCheqDetails_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 460);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Cheq.Amount";
            // 
            // lblCheqAmt
            // 
            this.lblCheqAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCheqAmt.Location = new System.Drawing.Point(112, 456);
            this.lblCheqAmt.Name = "lblCheqAmt";
            this.lblCheqAmt.Size = new System.Drawing.Size(320, 20);
            this.lblCheqAmt.TabIndex = 34;
            this.lblCheqAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 436);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Cheq.Date";
            // 
            // lblCheqDate
            // 
            this.lblCheqDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCheqDate.Location = new System.Drawing.Point(112, 432);
            this.lblCheqDate.Name = "lblCheqDate";
            this.lblCheqDate.Size = new System.Drawing.Size(320, 20);
            this.lblCheqDate.TabIndex = 32;
            this.lblCheqDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 412);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Cheq.No";
            // 
            // lblCheqNo
            // 
            this.lblCheqNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCheqNo.Location = new System.Drawing.Point(112, 408);
            this.lblCheqNo.Name = "lblCheqNo";
            this.lblCheqNo.Size = new System.Drawing.Size(320, 20);
            this.lblCheqNo.TabIndex = 30;
            this.lblCheqNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 388);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Bank";
            // 
            // lblBank
            // 
            this.lblBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBank.Location = new System.Drawing.Point(112, 384);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(320, 20);
            this.lblBank.TabIndex = 28;
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Doc.No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Selected Document Details";
            // 
            // lblDocNo
            // 
            this.lblDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocNo.Location = new System.Drawing.Point(112, 360);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(320, 20);
            this.lblDocNo.TabIndex = 26;
            this.lblDocNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewPendingPayments
            // 
            this.dataGridViewPendingPayments.AllowUserToAddRows = false;
            this.dataGridViewPendingPayments.AllowUserToDeleteRows = false;
            this.dataGridViewPendingPayments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPendingPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPendingPayments.AutoGenerateColumns = false;
            this.dataGridViewPendingPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPendingPayments.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridViewPendingPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPendingPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.payDocumentDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn,
            this.chequeNoDataGridViewTextBoxColumn,
            this.chequeDateDataGridViewTextBoxColumn,
            this.chequeAmountDataGridViewTextBoxColumn});
            this.dataGridViewPendingPayments.DataSource = this.dsPendingChequePrintListBindingSource;
            this.dataGridViewPendingPayments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPendingPayments.Location = new System.Drawing.Point(8, 64);
            this.dataGridViewPendingPayments.Name = "dataGridViewPendingPayments";
            this.dataGridViewPendingPayments.ReadOnly = true;
            this.dataGridViewPendingPayments.RowHeadersWidth = 20;
            this.dataGridViewPendingPayments.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPendingPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPendingPayments.Size = new System.Drawing.Size(424, 272);
            this.dataGridViewPendingPayments.TabIndex = 25;
            this.dataGridViewPendingPayments.DoubleClick += new System.EventHandler(this.dataGridViewPendingPayments_DoubleClick);
            // 
            // payDocumentDataGridViewTextBoxColumn
            // 
            this.payDocumentDataGridViewTextBoxColumn.DataPropertyName = "PayDocument";
            this.payDocumentDataGridViewTextBoxColumn.HeaderText = "Doc.No";
            this.payDocumentDataGridViewTextBoxColumn.Name = "payDocumentDataGridViewTextBoxColumn";
            this.payDocumentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "Bank";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chequeNoDataGridViewTextBoxColumn
            // 
            this.chequeNoDataGridViewTextBoxColumn.DataPropertyName = "ChequeNo";
            this.chequeNoDataGridViewTextBoxColumn.FillWeight = 80F;
            this.chequeNoDataGridViewTextBoxColumn.HeaderText = "Cheq.No";
            this.chequeNoDataGridViewTextBoxColumn.Name = "chequeNoDataGridViewTextBoxColumn";
            this.chequeNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chequeDateDataGridViewTextBoxColumn
            // 
            this.chequeDateDataGridViewTextBoxColumn.DataPropertyName = "ChequeDate";
            this.chequeDateDataGridViewTextBoxColumn.FillWeight = 80F;
            this.chequeDateDataGridViewTextBoxColumn.HeaderText = "Cheq.Date";
            this.chequeDateDataGridViewTextBoxColumn.Name = "chequeDateDataGridViewTextBoxColumn";
            this.chequeDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chequeAmountDataGridViewTextBoxColumn
            // 
            this.chequeAmountDataGridViewTextBoxColumn.DataPropertyName = "ChequeAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.chequeAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.chequeAmountDataGridViewTextBoxColumn.FillWeight = 80F;
            this.chequeAmountDataGridViewTextBoxColumn.HeaderText = "Cheq.Amt";
            this.chequeAmountDataGridViewTextBoxColumn.Name = "chequeAmountDataGridViewTextBoxColumn";
            this.chequeAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsPendingChequePrintListBindingSource
            // 
            this.dsPendingChequePrintListBindingSource.DataMember = "dsPendingChequePrintList";
            this.dsPendingChequePrintListBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSupplierSearch
            // 
            this.btnSupplierSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSupplierSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSupplierSearch.Location = new System.Drawing.Point(408, 39);
            this.btnSupplierSearch.Name = "btnSupplierSearch";
            this.btnSupplierSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSupplierSearch.TabIndex = 22;
            this.btnSupplierSearch.UseVisualStyleBackColor = true;
            this.btnSupplierSearch.Click += new System.EventHandler(this.btnSupplierSearch_Click);
            // 
            // btnSaveBankFormat
            // 
            this.btnSaveBankFormat.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSaveBankFormat.FlatAppearance.BorderSize = 0;
            this.btnSaveBankFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBankFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBankFormat.Location = new System.Drawing.Point(488, 520);
            this.btnSaveBankFormat.Name = "btnSaveBankFormat";
            this.btnSaveBankFormat.Size = new System.Drawing.Size(132, 23);
            this.btnSaveBankFormat.TabIndex = 25;
            this.btnSaveBankFormat.Text = "Save Format";
            this.btnSaveBankFormat.UseVisualStyleBackColor = false;
            this.btnSaveBankFormat.Click += new System.EventHandler(this.btnSaveBankFormat_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(4, 488);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 48);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(632, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(520, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "X";
            // 
            // txtPageY
            // 
            this.txtPageY.Location = new System.Drawing.Point(651, 3);
            this.txtPageY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtPageY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.txtPageY.Name = "txtPageY";
            this.txtPageY.Size = new System.Drawing.Size(64, 20);
            this.txtPageY.TabIndex = 28;
            this.txtPageY.ValueChanged += new System.EventHandler(this.txtPageY_ValueChanged);
            // 
            // txtPageX
            // 
            this.txtPageX.Location = new System.Drawing.Point(540, 3);
            this.txtPageX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtPageX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.txtPageX.Name = "txtPageX";
            this.txtPageX.Size = new System.Drawing.Size(64, 20);
            this.txtPageX.TabIndex = 27;
            this.txtPageX.ValueChanged += new System.EventHandler(this.txtPageX_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(480, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Page";
            // 
            // chkHide
            // 
            this.chkHide.AutoSize = true;
            this.chkHide.Location = new System.Drawing.Point(680, 372);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(48, 17);
            this.chkHide.TabIndex = 32;
            this.chkHide.Text = "Hide";
            this.chkHide.UseVisualStyleBackColor = true;
            this.chkHide.CheckedChanged += new System.EventHandler(this.chkShowHide_CheckedChanged);
            // 
            // cmbNameProfile
            // 
            this.cmbNameProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameProfile.FormattingEnabled = true;
            this.cmbNameProfile.Items.AddRange(new object[] {
            "D1",
            "D2",
            "M1",
            "M2",
            "Y1",
            "Y2",
            "Y3",
            "Y4",
            "Pay",
            "AmountText",
            "AmountValue",
            "Cut",
            "ImgPO"});
            this.cmbNameProfile.Location = new System.Drawing.Point(296, 3);
            this.cmbNameProfile.Name = "cmbNameProfile";
            this.cmbNameProfile.Size = new System.Drawing.Size(158, 21);
            this.cmbNameProfile.TabIndex = 33;
            this.cmbNameProfile.SelectedIndexChanged += new System.EventHandler(this.cmbNameProfile_SelectedIndexChanged);
            // 
            // lblComType
            // 
            this.lblComType.AutoSize = true;
            this.lblComType.Location = new System.Drawing.Point(212, 7);
            this.lblComType.Name = "lblComType";
            this.lblComType.Size = new System.Drawing.Size(78, 13);
            this.lblComType.TabIndex = 34;
            this.lblComType.Text = "Company Type";
            // 
            // frmChequePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(222)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1177, 548);
            this.Controls.Add(this.lblComType);
            this.Controls.Add(this.cmbNameProfile);
            this.Controls.Add(this.chkHide);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveBankFormat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPageY);
            this.Controls.Add(this.txtPageX);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.cmbBankName);
            this.Controls.Add(this.chkPayeeOnly);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.pnlCheque);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChequePrint";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cheque Print";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChequePrint_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChequePrint_FormClosing);
            this.pnlCheque.ResumeLayout(false);
            this.lblHolderSeal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblImgHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImgPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPendingChequePrintListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        public System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.PrintDialog printDialog1;
        public System.Windows.Forms.Panel pnlCheque;
        public System.Windows.Forms.Label lblD1;
        public System.Windows.Forms.Label lblY1;
        public System.Windows.Forms.Label lblM2;
        public System.Windows.Forms.Label lblM1;
        public System.Windows.Forms.Label lblD2;
        public System.Windows.Forms.Label lblY4;
        public System.Windows.Forms.Label lblY3;
        public System.Windows.Forms.Label lblY2;
        public System.Windows.Forms.Label lblAmountText;
        public System.Windows.Forms.Label lblPay;
        public System.Windows.Forms.ComboBox cmbField;
        public System.Windows.Forms.Label lblAmountValue;
        public System.Windows.Forms.NumericUpDown txtX;
        public System.Windows.Forms.NumericUpDown txtY;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPay;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.CheckBox chkPayeeOnly;
        public System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.Button btnSupplierSearch;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewPendingPayments;
        private System.Windows.Forms.BindingSource dsPendingChequePrintListBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn payDocumentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeAmountDataGridViewTextBoxColumn;
        public System.Windows.Forms.Button btnSaveBankFormat;
        public System.Windows.Forms.Label lblDocNo;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label lblCheqAmt;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label lblCheqDate;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblCheqNo;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblBank;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnLoadPrintedCheqDetails;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.NumericUpDown txtPageY;
        public System.Windows.Forms.NumericUpDown txtPageX;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox lblImgPO;
        public System.Windows.Forms.CheckBox chkHide;
        public System.Windows.Forms.Label lblCut;
        public System.Windows.Forms.Label lblCompanyName;
        public System.Windows.Forms.ComboBox cmbNameProfile;
        private System.Windows.Forms.PictureBox lblImgHolder;
        private System.Windows.Forms.Panel lblHolderSeal;
        public System.Windows.Forms.Label lblComType;

    }
}

