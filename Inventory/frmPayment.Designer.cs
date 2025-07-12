namespace Inventory
{
    partial class frmPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.grdPaytypes = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInvPaytype = new MetroFramework.Controls.MetroLabel();
            this.lblCustCode = new MetroFramework.Controls.MetroLabel();
            this.btnCLear = new MetroFramework.Controls.MetroButton();
            this.lblDocNo = new MetroFramework.Controls.MetroLabel();
            this.btnFinish = new MetroFramework.Controls.MetroButton();
            this.btnMultipay = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnSinglePay = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLoyalBalance = new MetroFramework.Controls.MetroTextBox();
            this.txtLoyalityCard = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPayBalance = new MetroFramework.Controls.MetroLabel();
            this.lblPayType = new MetroFramework.Controls.MetroLabel();
            this.lblPayDiscount = new MetroFramework.Controls.MetroLabel();
            this.lblPayAmount = new MetroFramework.Controls.MetroLabel();
            this.lblTotPayed = new MetroFramework.Controls.MetroLabel();
            this.txtTotalPayed = new MetroFramework.Controls.MetroTextBox();
            this.BtnAdv = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtPayBalance = new MetroFramework.Controls.MetroTextBox();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.txtRecPayment = new MetroFramework.Controls.MetroTextBox();
            this.lblChequDate = new MetroFramework.Controls.MetroLabel();
            this.lblCheqNo = new MetroFramework.Controls.MetroLabel();
            this.lblBranch = new MetroFramework.Controls.MetroLabel();
            this.lblBank = new MetroFramework.Controls.MetroLabel();
            this.lblAdvNo = new System.Windows.Forms.Label();
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.paymentModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPaidPaymentModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.txtBranchName = new MetroFramework.Controls.MetroTextBox();
            this.dtpChequeDate = new MetroFramework.Controls.MetroDateTime();
            this.cmbCardTypes = new MetroFramework.Controls.MetroComboBox();
            this.cmbBankName = new MetroFramework.Controls.MetroComboBox();
            this.txtChequeNo = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaytypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPaidPaymentModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.grdPaytypes);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 478);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Mode";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel6.Location = new System.Drawing.Point(17, 449);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(171, 19);
            this.metroLabel6.TabIndex = 240;
            this.metroLabel6.Text = "Use  Up - Down Arrow Keys";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // grdPaytypes
            // 
            this.grdPaytypes.AllowUserToAddRows = false;
            this.grdPaytypes.AllowUserToDeleteRows = false;
            this.grdPaytypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPaytypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPaytypes.Location = new System.Drawing.Point(6, 19);
            this.grdPaytypes.Name = "grdPaytypes";
            this.grdPaytypes.ReadOnly = true;
            this.grdPaytypes.RowHeadersWidth = 10;
            this.grdPaytypes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPaytypes.RowTemplate.Height = 30;
            this.grdPaytypes.Size = new System.Drawing.Size(254, 417);
            this.grdPaytypes.TabIndex = 1;
            this.grdPaytypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPaytypes_CellClick);
            this.grdPaytypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPaytypes_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(294, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInvPaytype);
            this.groupBox2.Controls.Add(this.lblCustCode);
            this.groupBox2.Controls.Add(this.btnCLear);
            this.groupBox2.Controls.Add(this.lblDocNo);
            this.groupBox2.Controls.Add(this.btnFinish);
            this.groupBox2.Controls.Add(this.btnMultipay);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSinglePay);
            this.groupBox2.Location = new System.Drawing.Point(293, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 102);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblInvPaytype
            // 
            this.lblInvPaytype.AutoSize = true;
            this.lblInvPaytype.BackColor = System.Drawing.Color.Transparent;
            this.lblInvPaytype.Location = new System.Drawing.Point(421, 6);
            this.lblInvPaytype.Name = "lblInvPaytype";
            this.lblInvPaytype.Size = new System.Drawing.Size(37, 19);
            this.lblInvPaytype.TabIndex = 231;
            this.lblInvPaytype.Text = "Bank";
            this.lblInvPaytype.UseCustomBackColor = true;
            this.lblInvPaytype.Visible = false;
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCustCode.Location = new System.Drawing.Point(490, 6);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(37, 19);
            this.lblCustCode.TabIndex = 232;
            this.lblCustCode.Text = "Bank";
            this.lblCustCode.UseCustomBackColor = true;
            this.lblCustCode.Visible = false;
            // 
            // btnCLear
            // 
            this.btnCLear.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCLear.Highlight = true;
            this.btnCLear.Location = new System.Drawing.Point(386, 28);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(84, 54);
            this.btnCLear.TabIndex = 231;
            this.btnCLear.Text = "Clear\r\nctrl+z";
            this.btnCLear.UseSelectable = true;
            this.btnCLear.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.BackColor = System.Drawing.Color.Transparent;
            this.lblDocNo.Location = new System.Drawing.Point(537, 6);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(37, 19);
            this.lblDocNo.TabIndex = 230;
            this.lblDocNo.Text = "Bank";
            this.lblDocNo.UseCustomBackColor = true;
            this.lblDocNo.Visible = false;
            // 
            // btnFinish
            // 
            this.btnFinish.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnFinish.Highlight = true;
            this.btnFinish.Location = new System.Drawing.Point(279, 28);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(91, 54);
            this.btnFinish.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Finish Pay\r\n+";
            this.btnFinish.UseSelectable = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnMultipay
            // 
            this.btnMultipay.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMultipay.Highlight = true;
            this.btnMultipay.Location = new System.Drawing.Point(147, 28);
            this.btnMultipay.Name = "btnMultipay";
            this.btnMultipay.Size = new System.Drawing.Size(106, 54);
            this.btnMultipay.TabIndex = 1;
            this.btnMultipay.Text = "Multi Payment\r\n-->";
            this.btnMultipay.UseSelectable = true;
            this.btnMultipay.Click += new System.EventHandler(this.btnMultipay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancel.Highlight = true;
            this.btnCancel.Location = new System.Drawing.Point(490, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 54);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Red;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel\r\nesc";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSinglePay
            // 
            this.btnSinglePay.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSinglePay.Highlight = true;
            this.btnSinglePay.Location = new System.Drawing.Point(22, 28);
            this.btnSinglePay.Name = "btnSinglePay";
            this.btnSinglePay.Size = new System.Drawing.Size(101, 54);
            this.btnSinglePay.TabIndex = 0;
            this.btnSinglePay.Text = "Single Pay\r\n<--";
            this.btnSinglePay.UseSelectable = true;
            this.btnSinglePay.Click += new System.EventHandler(this.btnSinglePay_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.lblTotPayed);
            this.groupBox3.Controls.Add(this.txtTotalPayed);
            this.groupBox3.Controls.Add(this.BtnAdv);
            this.groupBox3.Controls.Add(this.metroLabel2);
            this.groupBox3.Controls.Add(this.metroLabel1);
            this.groupBox3.Controls.Add(this.txtPayBalance);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.txtRecPayment);
            this.groupBox3.Controls.Add(this.lblChequDate);
            this.groupBox3.Controls.Add(this.lblCheqNo);
            this.groupBox3.Controls.Add(this.lblBranch);
            this.groupBox3.Controls.Add(this.lblBank);
            this.groupBox3.Controls.Add(this.lblAdvNo);
            this.groupBox3.Controls.Add(this.dataGridViewPayments);
            this.groupBox3.Controls.Add(this.txtBranchName);
            this.groupBox3.Controls.Add(this.dtpChequeDate);
            this.groupBox3.Controls.Add(this.cmbCardTypes);
            this.groupBox3.Controls.Add(this.cmbBankName);
            this.groupBox3.Controls.Add(this.txtChequeNo);
            this.groupBox3.Location = new System.Drawing.Point(293, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(633, 370);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtLoyalBalance);
            this.panel2.Controls.Add(this.txtLoyalityCard);
            this.panel2.Controls.Add(this.metroLabel3);
            this.panel2.Location = new System.Drawing.Point(348, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 75);
            this.panel2.TabIndex = 236;
            // 
            // txtLoyalBalance
            // 
            // 
            // 
            // 
            this.txtLoyalBalance.CustomButton.Image = null;
            this.txtLoyalBalance.CustomButton.Location = new System.Drawing.Point(89, 2);
            this.txtLoyalBalance.CustomButton.Name = "";
            this.txtLoyalBalance.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLoyalBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLoyalBalance.CustomButton.TabIndex = 1;
            this.txtLoyalBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLoyalBalance.CustomButton.UseSelectable = true;
            this.txtLoyalBalance.CustomButton.Visible = false;
            this.txtLoyalBalance.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtLoyalBalance.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtLoyalBalance.Lines = new string[0];
            this.txtLoyalBalance.Location = new System.Drawing.Point(141, 36);
            this.txtLoyalBalance.MaxLength = 32767;
            this.txtLoyalBalance.Name = "txtLoyalBalance";
            this.txtLoyalBalance.PasswordChar = '\0';
            this.txtLoyalBalance.ReadOnly = true;
            this.txtLoyalBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLoyalBalance.SelectedText = "";
            this.txtLoyalBalance.SelectionLength = 0;
            this.txtLoyalBalance.SelectionStart = 0;
            this.txtLoyalBalance.ShortcutsEnabled = true;
            this.txtLoyalBalance.Size = new System.Drawing.Size(117, 30);
            this.txtLoyalBalance.TabIndex = 236;
            this.txtLoyalBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoyalBalance.UseCustomBackColor = true;
            this.txtLoyalBalance.UseSelectable = true;
            this.txtLoyalBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLoyalBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtLoyalityCard
            // 
            // 
            // 
            // 
            this.txtLoyalityCard.CustomButton.Image = null;
            this.txtLoyalityCard.CustomButton.Location = new System.Drawing.Point(89, 2);
            this.txtLoyalityCard.CustomButton.Name = "";
            this.txtLoyalityCard.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtLoyalityCard.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLoyalityCard.CustomButton.TabIndex = 1;
            this.txtLoyalityCard.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLoyalityCard.CustomButton.UseSelectable = true;
            this.txtLoyalityCard.CustomButton.Visible = false;
            this.txtLoyalityCard.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtLoyalityCard.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtLoyalityCard.Lines = new string[0];
            this.txtLoyalityCard.Location = new System.Drawing.Point(16, 36);
            this.txtLoyalityCard.MaxLength = 32767;
            this.txtLoyalityCard.Name = "txtLoyalityCard";
            this.txtLoyalityCard.PasswordChar = '\0';
            this.txtLoyalityCard.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLoyalityCard.SelectedText = "";
            this.txtLoyalityCard.SelectionLength = 0;
            this.txtLoyalityCard.SelectionStart = 0;
            this.txtLoyalityCard.ShortcutsEnabled = true;
            this.txtLoyalityCard.Size = new System.Drawing.Size(117, 30);
            this.txtLoyalityCard.TabIndex = 235;
            this.txtLoyalityCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoyalityCard.UseCustomBackColor = true;
            this.txtLoyalityCard.UseSelectable = true;
            this.txtLoyalityCard.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLoyalityCard.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtLoyalityCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoyalityCard_KeyDown);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.Location = new System.Drawing.Point(3, 7);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(133, 19);
            this.metroLabel3.TabIndex = 234;
            this.metroLabel3.Text = "Loyality Card (Ctrl+L)";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPayBalance);
            this.panel1.Controls.Add(this.lblPayType);
            this.panel1.Controls.Add(this.lblPayDiscount);
            this.panel1.Controls.Add(this.lblPayAmount);
            this.panel1.Location = new System.Drawing.Point(13, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 75);
            this.panel1.TabIndex = 233;
            // 
            // lblPayBalance
            // 
            this.lblPayBalance.AutoSize = true;
            this.lblPayBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblPayBalance.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPayBalance.Location = new System.Drawing.Point(208, 2);
            this.lblPayBalance.Name = "lblPayBalance";
            this.lblPayBalance.Size = new System.Drawing.Size(45, 19);
            this.lblPayBalance.TabIndex = 227;
            this.lblPayBalance.Text = "XXXX";
            this.lblPayBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayBalance.UseCustomBackColor = true;
            // 
            // lblPayType
            // 
            this.lblPayType.AutoSize = true;
            this.lblPayType.BackColor = System.Drawing.Color.Transparent;
            this.lblPayType.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPayType.Location = new System.Drawing.Point(4, 6);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(45, 19);
            this.lblPayType.TabIndex = 226;
            this.lblPayType.Text = "XXXX";
            this.lblPayType.UseCustomBackColor = true;
            this.lblPayType.TextChanged += new System.EventHandler(this.lblPayType_TextChanged);
            this.lblPayType.Click += new System.EventHandler(this.lblPayType_Click);
            // 
            // lblPayDiscount
            // 
            this.lblPayDiscount.AutoSize = true;
            this.lblPayDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblPayDiscount.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPayDiscount.Location = new System.Drawing.Point(207, 27);
            this.lblPayDiscount.Name = "lblPayDiscount";
            this.lblPayDiscount.Size = new System.Drawing.Size(45, 19);
            this.lblPayDiscount.TabIndex = 228;
            this.lblPayDiscount.Text = "XXXX";
            this.lblPayDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayDiscount.UseCustomBackColor = true;
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPayAmount.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPayAmount.Location = new System.Drawing.Point(208, 52);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(45, 19);
            this.lblPayAmount.TabIndex = 229;
            this.lblPayAmount.Text = "XXXX";
            this.lblPayAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayAmount.UseCustomBackColor = true;
            // 
            // lblTotPayed
            // 
            this.lblTotPayed.AutoSize = true;
            this.lblTotPayed.BackColor = System.Drawing.Color.Transparent;
            this.lblTotPayed.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotPayed.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotPayed.Location = new System.Drawing.Point(339, 335);
            this.lblTotPayed.Name = "lblTotPayed";
            this.lblTotPayed.Size = new System.Drawing.Size(138, 25);
            this.lblTotPayed.TabIndex = 232;
            this.lblTotPayed.Text = "Payed Amount";
            this.lblTotPayed.UseCustomBackColor = true;
            // 
            // txtTotalPayed
            // 
            this.txtTotalPayed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.txtTotalPayed.CustomButton.Image = null;
            this.txtTotalPayed.CustomButton.Location = new System.Drawing.Point(95, 2);
            this.txtTotalPayed.CustomButton.Name = "";
            this.txtTotalPayed.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtTotalPayed.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalPayed.CustomButton.TabIndex = 1;
            this.txtTotalPayed.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalPayed.CustomButton.UseSelectable = true;
            this.txtTotalPayed.CustomButton.Visible = false;
            this.txtTotalPayed.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtTotalPayed.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtTotalPayed.Lines = new string[] {
        " 0.00"};
            this.txtTotalPayed.Location = new System.Drawing.Point(483, 334);
            this.txtTotalPayed.MaxLength = 32767;
            this.txtTotalPayed.Name = "txtTotalPayed";
            this.txtTotalPayed.PasswordChar = '\0';
            this.txtTotalPayed.ReadOnly = true;
            this.txtTotalPayed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalPayed.SelectedText = "";
            this.txtTotalPayed.SelectionLength = 0;
            this.txtTotalPayed.SelectionStart = 0;
            this.txtTotalPayed.ShortcutsEnabled = true;
            this.txtTotalPayed.Size = new System.Drawing.Size(123, 30);
            this.txtTotalPayed.TabIndex = 231;
            this.txtTotalPayed.Text = " 0.00";
            this.txtTotalPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPayed.UseCustomBackColor = true;
            this.txtTotalPayed.UseSelectable = true;
            this.txtTotalPayed.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalPayed.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BtnAdv
            // 
            this.BtnAdv.Location = new System.Drawing.Point(292, 189);
            this.BtnAdv.Name = "BtnAdv";
            this.BtnAdv.Size = new System.Drawing.Size(47, 30);
            this.BtnAdv.TabIndex = 230;
            this.BtnAdv.Text = "ADV";
            this.BtnAdv.UseSelectable = true;
            this.BtnAdv.Visible = false;
            this.BtnAdv.Click += new System.EventHandler(this.BtnAdv_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(352, 159);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 25);
            this.metroLabel2.TabIndex = 226;
            this.metroLabel2.Text = "Balance";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(-1, 189);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 25);
            this.metroLabel1.TabIndex = 225;
            this.metroLabel1.Text = "Pay Amount";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // txtPayBalance
            // 
            // 
            // 
            // 
            this.txtPayBalance.CustomButton.Image = null;
            this.txtPayBalance.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.txtPayBalance.CustomButton.Name = "";
            this.txtPayBalance.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPayBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPayBalance.CustomButton.TabIndex = 1;
            this.txtPayBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPayBalance.CustomButton.UseSelectable = true;
            this.txtPayBalance.CustomButton.Visible = false;
            this.txtPayBalance.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtPayBalance.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtPayBalance.Lines = new string[] {
        " 0.00"};
            this.txtPayBalance.Location = new System.Drawing.Point(457, 159);
            this.txtPayBalance.MaxLength = 32767;
            this.txtPayBalance.Name = "txtPayBalance";
            this.txtPayBalance.PasswordChar = '\0';
            this.txtPayBalance.ReadOnly = true;
            this.txtPayBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPayBalance.SelectedText = "";
            this.txtPayBalance.SelectionLength = 0;
            this.txtPayBalance.SelectionStart = 0;
            this.txtPayBalance.ShortcutsEnabled = true;
            this.txtPayBalance.Size = new System.Drawing.Size(122, 30);
            this.txtPayBalance.TabIndex = 224;
            this.txtPayBalance.Text = " 0.00";
            this.txtPayBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayBalance.UseCustomBackColor = true;
            this.txtPayBalance.UseSelectable = true;
            this.txtPayBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPayBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnAdd
            // 
            this.btnAdd.Highlight = true;
            this.btnAdd.Location = new System.Drawing.Point(581, 159);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRecPayment
            // 
            this.txtRecPayment.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRecPayment.CustomButton.Image = null;
            this.txtRecPayment.CustomButton.Location = new System.Drawing.Point(133, 2);
            this.txtRecPayment.CustomButton.Name = "";
            this.txtRecPayment.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtRecPayment.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecPayment.CustomButton.TabIndex = 1;
            this.txtRecPayment.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecPayment.CustomButton.UseSelectable = true;
            this.txtRecPayment.CustomButton.Visible = false;
            this.txtRecPayment.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtRecPayment.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtRecPayment.Lines = new string[] {
        " 0.00"};
            this.txtRecPayment.Location = new System.Drawing.Point(127, 189);
            this.txtRecPayment.MaxLength = 32767;
            this.txtRecPayment.Name = "txtRecPayment";
            this.txtRecPayment.PasswordChar = '\0';
            this.txtRecPayment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecPayment.SelectedText = "";
            this.txtRecPayment.SelectionLength = 0;
            this.txtRecPayment.SelectionStart = 0;
            this.txtRecPayment.ShortcutsEnabled = true;
            this.txtRecPayment.Size = new System.Drawing.Size(161, 30);
            this.txtRecPayment.TabIndex = 223;
            this.txtRecPayment.Text = " 0.00";
            this.txtRecPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecPayment.UseCustomBackColor = true;
            this.txtRecPayment.UseSelectable = true;
            this.txtRecPayment.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecPayment.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRecPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecPayment_KeyDown);
            this.txtRecPayment.Leave += new System.EventHandler(this.txtRecPayment_Leave);
            // 
            // lblChequDate
            // 
            this.lblChequDate.AutoSize = true;
            this.lblChequDate.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblChequDate.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblChequDate.Location = new System.Drawing.Point(352, 129);
            this.lblChequDate.Name = "lblChequDate";
            this.lblChequDate.Size = new System.Drawing.Size(52, 25);
            this.lblChequDate.TabIndex = 222;
            this.lblChequDate.Text = "Date";
            this.lblChequDate.UseCustomBackColor = true;
            // 
            // lblCheqNo
            // 
            this.lblCheqNo.AutoSize = true;
            this.lblCheqNo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCheqNo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCheqNo.Location = new System.Drawing.Point(348, 97);
            this.lblCheqNo.Name = "lblCheqNo";
            this.lblCheqNo.Size = new System.Drawing.Size(106, 25);
            this.lblCheqNo.TabIndex = 221;
            this.lblCheqNo.Text = "Cheque No";
            this.lblCheqNo.UseCustomBackColor = true;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.BackColor = System.Drawing.Color.Transparent;
            this.lblBranch.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblBranch.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblBranch.Location = new System.Drawing.Point(-2, 147);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(72, 25);
            this.lblBranch.TabIndex = 220;
            this.lblBranch.Text = "Branch";
            this.lblBranch.UseCustomBackColor = true;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.BackColor = System.Drawing.Color.Transparent;
            this.lblBank.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblBank.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblBank.Location = new System.Drawing.Point(-2, 97);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(55, 25);
            this.lblBank.TabIndex = 219;
            this.lblBank.Text = "Bank";
            this.lblBank.UseCustomBackColor = true;
            // 
            // lblAdvNo
            // 
            this.lblAdvNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvNo.Location = new System.Drawing.Point(348, 195);
            this.lblAdvNo.Name = "lblAdvNo";
            this.lblAdvNo.Size = new System.Drawing.Size(34, 19);
            this.lblAdvNo.TabIndex = 218;
            this.lblAdvNo.Text = "0";
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.AllowUserToAddRows = false;
            this.dataGridViewPayments.AllowUserToDeleteRows = false;
            this.dataGridViewPayments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPayments.AutoGenerateColumns = false;
            this.dataGridViewPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPayments.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentModeDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn,
            this.branchDataGridViewTextBoxColumn,
            this.chequeNoDataGridViewTextBoxColumn,
            this.chequeDateDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dataGridViewPayments.DataSource = this.tbPaidPaymentModeBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPayments.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPayments.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridViewPayments.Location = new System.Drawing.Point(61, 229);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPayments.RowHeadersWidth = 10;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPayments.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPayments.Size = new System.Drawing.Size(545, 103);
            this.dataGridViewPayments.TabIndex = 217;
            this.dataGridViewPayments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewPayments_KeyDown);
            // 
            // paymentModeDataGridViewTextBoxColumn
            // 
            this.paymentModeDataGridViewTextBoxColumn.DataPropertyName = "Payment_Mode";
            this.paymentModeDataGridViewTextBoxColumn.HeaderText = "Mode";
            this.paymentModeDataGridViewTextBoxColumn.Name = "paymentModeDataGridViewTextBoxColumn";
            this.paymentModeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "Bank_Name";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "Bank";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchDataGridViewTextBoxColumn
            // 
            this.branchDataGridViewTextBoxColumn.DataPropertyName = "Branch";
            this.branchDataGridViewTextBoxColumn.HeaderText = "Branch";
            this.branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            this.branchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chequeNoDataGridViewTextBoxColumn
            // 
            this.chequeNoDataGridViewTextBoxColumn.DataPropertyName = "Cheque_No";
            this.chequeNoDataGridViewTextBoxColumn.HeaderText = "Ref No";
            this.chequeNoDataGridViewTextBoxColumn.Name = "chequeNoDataGridViewTextBoxColumn";
            this.chequeNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chequeDateDataGridViewTextBoxColumn
            // 
            this.chequeDateDataGridViewTextBoxColumn.DataPropertyName = "Cheque_Date";
            this.chequeDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.chequeDateDataGridViewTextBoxColumn.Name = "chequeDateDataGridViewTextBoxColumn";
            this.chequeDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tbPaidPaymentModeBindingSource
            // 
            this.tbPaidPaymentModeBindingSource.DataMember = "tbPaidPaymentMode";
            this.tbPaidPaymentModeBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtBranchName
            // 
            this.txtBranchName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBranchName.CustomButton.Image = null;
            this.txtBranchName.CustomButton.Location = new System.Drawing.Point(186, 2);
            this.txtBranchName.CustomButton.Name = "";
            this.txtBranchName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtBranchName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBranchName.CustomButton.TabIndex = 1;
            this.txtBranchName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBranchName.CustomButton.UseSelectable = true;
            this.txtBranchName.CustomButton.Visible = false;
            this.txtBranchName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtBranchName.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtBranchName.Lines = new string[] {
        " "};
            this.txtBranchName.Location = new System.Drawing.Point(126, 146);
            this.txtBranchName.MaxLength = 32767;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.PasswordChar = '\0';
            this.txtBranchName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBranchName.SelectedText = "";
            this.txtBranchName.SelectionLength = 0;
            this.txtBranchName.SelectionStart = 0;
            this.txtBranchName.ShortcutsEnabled = true;
            this.txtBranchName.Size = new System.Drawing.Size(214, 30);
            this.txtBranchName.TabIndex = 4;
            this.txtBranchName.Text = " ";
            this.txtBranchName.UseCustomBackColor = true;
            this.txtBranchName.UseSelectable = true;
            this.txtBranchName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBranchName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchName_KeyDown);
            // 
            // dtpChequeDate
            // 
            this.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate.Location = new System.Drawing.Point(456, 129);
            this.dtpChequeDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpChequeDate.Name = "dtpChequeDate";
            this.dtpChequeDate.Size = new System.Drawing.Size(122, 29);
            this.dtpChequeDate.TabIndex = 3;
            this.dtpChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpChequeDate_KeyDown);
            // 
            // cmbCardTypes
            // 
            this.cmbCardTypes.FormattingEnabled = true;
            this.cmbCardTypes.ItemHeight = 23;
            this.cmbCardTypes.Location = new System.Drawing.Point(126, 146);
            this.cmbCardTypes.Name = "cmbCardTypes";
            this.cmbCardTypes.Size = new System.Drawing.Size(213, 29);
            this.cmbCardTypes.TabIndex = 2;
            this.cmbCardTypes.UseSelectable = true;
            this.cmbCardTypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCardTypes_KeyDown);
            // 
            // cmbBankName
            // 
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.ItemHeight = 23;
            this.cmbBankName.Location = new System.Drawing.Point(127, 97);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(213, 29);
            this.cmbBankName.TabIndex = 1;
            this.cmbBankName.UseSelectable = true;
            this.cmbBankName.SelectedIndexChanged += new System.EventHandler(this.cmbBankName_SelectedIndexChanged);
            this.cmbBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBankName_KeyDown);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtChequeNo.CustomButton.Image = null;
            this.txtChequeNo.CustomButton.Location = new System.Drawing.Point(95, 2);
            this.txtChequeNo.CustomButton.Name = "";
            this.txtChequeNo.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtChequeNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChequeNo.CustomButton.TabIndex = 1;
            this.txtChequeNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChequeNo.CustomButton.UseSelectable = true;
            this.txtChequeNo.CustomButton.Visible = false;
            this.txtChequeNo.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtChequeNo.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtChequeNo.Lines = new string[] {
        " "};
            this.txtChequeNo.Location = new System.Drawing.Point(455, 96);
            this.txtChequeNo.MaxLength = 32767;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.PasswordChar = '\0';
            this.txtChequeNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChequeNo.SelectedText = "";
            this.txtChequeNo.SelectionLength = 0;
            this.txtChequeNo.SelectionStart = 0;
            this.txtChequeNo.ShortcutsEnabled = true;
            this.txtChequeNo.Size = new System.Drawing.Size(123, 30);
            this.txtChequeNo.TabIndex = 0;
            this.txtChequeNo.Text = " ";
            this.txtChequeNo.UseCustomBackColor = true;
            this.txtChequeNo.UseSelectable = true;
            this.txtChequeNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChequeNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeNo_KeyDown);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(939, 530);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPayment_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaytypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPaidPaymentModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView grdPaytypes;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton btnMultipay;
        private MetroFramework.Controls.MetroButton btnSinglePay;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroComboBox cmbBankName;
        private System.Windows.Forms.Label lblAdvNo;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private MetroFramework.Controls.MetroTextBox txtBranchName;
        private MetroFramework.Controls.MetroDateTime dtpChequeDate;
        private MetroFramework.Controls.MetroComboBox cmbCardTypes;
        private MetroFramework.Controls.MetroTextBox txtChequeNo;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnFinish;
        private MetroFramework.Controls.MetroLabel lblChequDate;
        private MetroFramework.Controls.MetroLabel lblCheqNo;
        private MetroFramework.Controls.MetroLabel lblBranch;
        private MetroFramework.Controls.MetroLabel lblBank;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtPayBalance;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroTextBox txtRecPayment;
        private MetroFramework.Controls.MetroLabel lblPayType;
        private MetroFramework.Controls.MetroLabel lblPayBalance;
        private MetroFramework.Controls.MetroLabel lblPayAmount;
        private MetroFramework.Controls.MetroLabel lblPayDiscount;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.BindingSource tbPaidPaymentModeBindingSource;
        private dsForReports dsForReports;
        private MetroFramework.Controls.MetroLabel lblDocNo;
        private MetroFramework.Controls.MetroButton btnCLear;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroButton BtnAdv;
        private MetroFramework.Controls.MetroLabel lblCustCode;
        private MetroFramework.Controls.MetroLabel lblInvPaytype;
        private MetroFramework.Controls.MetroLabel lblTotPayed;
        private MetroFramework.Controls.MetroTextBox txtTotalPayed;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTextBox txtLoyalityCard;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroTextBox txtLoyalBalance;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}