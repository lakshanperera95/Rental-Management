namespace Inventory
{
    partial class frmPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.txtShiftAddress1 = new System.Windows.Forms.TextBox();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtCreditPeriod = new System.Windows.Forms.TextBox();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.dataGridTempPON = new System.Windows.Forms.DataGridView();
            this.prodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtShiftAddress2 = new System.Windows.Forms.TextBox();
            this.dtpExpectedOn = new System.Windows.Forms.DateTimePicker();
            this.btnSupplierSearch = new System.Windows.Forms.Button();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShiftToHeader = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.btnSaveDocSearch = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.purchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodReceivedNoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempPON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodReceivedNoteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(489, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 137;
            this.label13.Text = "Address :";
            // 
            // txtShiftAddress1
            // 
            this.txtShiftAddress1.Location = new System.Drawing.Point(559, 74);
            this.txtShiftAddress1.Name = "txtShiftAddress1";
            this.txtShiftAddress1.Size = new System.Drawing.Size(412, 20);
            this.txtShiftAddress1.TabIndex = 136;
            this.txtShiftAddress1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShiftAddress1_KeyDown);
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.Enabled = false;
            this.txtTaxAmount.Location = new System.Drawing.Point(837, 64);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.Size = new System.Drawing.Size(128, 20);
            this.txtTaxAmount.TabIndex = 174;
            this.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTaxAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaxAmount_KeyDown);
            this.txtTaxAmount.Leave += new System.EventHandler(this.txtTaxAmount_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Location = new System.Drawing.Point(5, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 78);
            this.groupBox2.TabIndex = 179;
            this.groupBox2.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(233, 17);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 50);
            this.btnPreview.TabIndex = 151;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(364, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 149;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(616, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.TabIndex = 148;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(490, 17);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 50);
            this.btnApply.TabIndex = 147;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(3, 9);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 66);
            this.toolStrip1.TabIndex = 133;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(755, 93);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 13);
            this.label23.TabIndex = 177;
            this.label23.Text = "Net Amount:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(755, 67);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(81, 13);
            this.label24.TabIndex = 175;
            this.label24.Text = "Tax Amount:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 135;
            this.label12.Text = "Credit Period:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(669, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 186;
            this.label14.Text = "Total";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalQty.Location = new System.Drawing.Point(733, 12);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTotalQty.Size = new System.Drawing.Size(91, 20);
            this.lblTotalQty.TabIndex = 185;
            this.lblTotalQty.Text = "0.00";
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 19);
            this.label10.TabIndex = 184;
            this.label10.Text = "Current Stock";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblTotalQty);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblCurrentQty);
            this.groupBox1.Controls.Add(this.lblNetAmount);
            this.groupBox1.Controls.Add(this.lblTotalAmount);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.txtTaxAmount);
            this.groupBox1.Location = new System.Drawing.Point(7, 446);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 119);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentQty.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentQty.Location = new System.Drawing.Point(139, 13);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(78, 19);
            this.lblCurrentQty.TabIndex = 183;
            this.lblCurrentQty.Text = ".";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(837, 92);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNetAmount.Size = new System.Drawing.Size(128, 18);
            this.lblNetAmount.TabIndex = 182;
            this.lblNetAmount.Text = "0.00";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Location = new System.Drawing.Point(829, 12);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTotalAmount.Size = new System.Drawing.Size(138, 20);
            this.lblTotalAmount.TabIndex = 180;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(107, 17);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTempDocNo.Size = new System.Drawing.Size(128, 20);
            this.lblTempDocNo.TabIndex = 149;
            this.lblTempDocNo.Text = "0000000001";
            this.lblTempDocNo.Enter += new System.EventHandler(this.lblTempDocNo_Enter);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(709, 416);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(102, 20);
            this.txtQty.TabIndex = 145;
            this.txtQty.Text = "0.00";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmount.Location = new System.Drawing.Point(812, 416);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblAmount.Size = new System.Drawing.Size(158, 20);
            this.lblAmount.TabIndex = 152;
            this.lblAmount.Text = "0.00";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Enabled = false;
            this.txtPurchasePrice.Location = new System.Drawing.Point(612, 416);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(96, 20);
            this.txtPurchasePrice.TabIndex = 143;
            this.txtPurchasePrice.Text = "0.00";
            this.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchasePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchasePrice_KeyDown);
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(559, 415);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(47, 21);
            this.btnItemSearch.TabIndex = 142;
            this.btnItemSearch.Text = "....";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(201, 416);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(353, 20);
            this.txtProductName.TabIndex = 141;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(50, 416);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(150, 20);
            this.txtProductCode.TabIndex = 140;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(469, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 133;
            this.label11.Text = "Expected on:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(106, 99);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(349, 20);
            this.txtRemarks.TabIndex = 126;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // txtCreditPeriod
            // 
            this.txtCreditPeriod.Location = new System.Drawing.Point(106, 72);
            this.txtCreditPeriod.Name = "txtCreditPeriod";
            this.txtCreditPeriod.Size = new System.Drawing.Size(129, 20);
            this.txtCreditPeriod.TabIndex = 134;
            this.txtCreditPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditPeriod_KeyDown);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.lblAmount);
            this.grpMain.Controls.Add(this.txtQty);
            this.grpMain.Controls.Add(this.txtPurchasePrice);
            this.grpMain.Controls.Add(this.btnItemSearch);
            this.grpMain.Controls.Add(this.txtProductName);
            this.grpMain.Controls.Add(this.txtProductCode);
            this.grpMain.Controls.Add(this.dataGridTempPON);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.txtContactPerson);
            this.grpMain.Controls.Add(this.txtShiftAddress2);
            this.grpMain.Controls.Add(this.dtpExpectedOn);
            this.grpMain.Controls.Add(this.lblTempDocNo);
            this.grpMain.Controls.Add(this.label13);
            this.grpMain.Controls.Add(this.txtShiftAddress1);
            this.grpMain.Controls.Add(this.label12);
            this.grpMain.Controls.Add(this.txtCreditPeriod);
            this.grpMain.Controls.Add(this.label11);
            this.grpMain.Controls.Add(this.label5);
            this.grpMain.Controls.Add(this.txtRemarks);
            this.grpMain.Controls.Add(this.btnSupplierSearch);
            this.grpMain.Controls.Add(this.txtSuppName);
            this.grpMain.Controls.Add(this.cmbPayment);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.dtpDate);
            this.grpMain.Controls.Add(this.label9);
            this.grpMain.Controls.Add(this.txtShiftToHeader);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.txtSuppCode);
            this.grpMain.Controls.Add(this.btnSaveDocSearch);
            this.grpMain.Controls.Add(this.pictureBox2);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Location = new System.Drawing.Point(6, -1);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(976, 444);
            this.grpMain.TabIndex = 2;
            this.grpMain.TabStop = false;
            // 
            // dataGridTempPON
            // 
            this.dataGridTempPON.AllowUserToAddRows = false;
            this.dataGridTempPON.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridTempPON.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTempPON.AutoGenerateColumns = false;
            this.dataGridTempPON.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTempPON.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridTempPON.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTempPON.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodCodeDataGridViewTextBoxColumn,
            this.prodNameDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.purchasePriceDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dataGridTempPON.DataSource = this.purchaseOrderBindingSource1;
            this.dataGridTempPON.Location = new System.Drawing.Point(9, 126);
            this.dataGridTempPON.Name = "dataGridTempPON";
            this.dataGridTempPON.Size = new System.Drawing.Size(962, 282);
            this.dataGridTempPON.TabIndex = 157;
            this.dataGridTempPON.DoubleClick += new System.EventHandler(this.dataGridTempPON_DoubleClick);
            this.dataGridTempPON.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridTempPON_RowPostPaint);
            this.dataGridTempPON.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridTempPON_KeyDown);
            // 
            // prodCodeDataGridViewTextBoxColumn
            // 
            this.prodCodeDataGridViewTextBoxColumn.DataPropertyName = "Prod_Code";
            this.prodCodeDataGridViewTextBoxColumn.FillWeight = 97.93253F;
            this.prodCodeDataGridViewTextBoxColumn.HeaderText = "Prod Code";
            this.prodCodeDataGridViewTextBoxColumn.Name = "prodCodeDataGridViewTextBoxColumn";
            this.prodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prodNameDataGridViewTextBoxColumn
            // 
            this.prodNameDataGridViewTextBoxColumn.DataPropertyName = "Prod_Name";
            this.prodNameDataGridViewTextBoxColumn.FillWeight = 231.215F;
            this.prodNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.prodNameDataGridViewTextBoxColumn.Name = "prodNameDataGridViewTextBoxColumn";
            this.prodNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.FillWeight = 37.97244F;
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "Purchase_Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.purchasePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.purchasePriceDataGridViewTextBoxColumn.FillWeight = 62.50133F;
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "Purch Price";
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            this.purchasePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyDataGridViewTextBoxColumn.FillWeight = 68.08724F;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.amountDataGridViewTextBoxColumn.FillWeight = 102.2914F;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchaseOrderBindingSource1
            // 
            this.purchaseOrderBindingSource1.DataMember = "PurchaseOrder";
            this.purchaseOrderBindingSource1.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(657, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 156;
            this.label2.Text = "Contact Person :";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(760, 17);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(210, 20);
            this.txtContactPerson.TabIndex = 155;
            this.txtContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPerson_KeyDown);
            // 
            // txtShiftAddress2
            // 
            this.txtShiftAddress2.Location = new System.Drawing.Point(559, 100);
            this.txtShiftAddress2.Name = "txtShiftAddress2";
            this.txtShiftAddress2.Size = new System.Drawing.Size(412, 20);
            this.txtShiftAddress2.TabIndex = 154;
            this.txtShiftAddress2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShiftAddress2_KeyDown);
            // 
            // dtpExpectedOn
            // 
            this.dtpExpectedOn.CustomFormat = "dd/MM/yyyy";
            this.dtpExpectedOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpectedOn.Location = new System.Drawing.Point(559, 17);
            this.dtpExpectedOn.Name = "dtpExpectedOn";
            this.dtpExpectedOn.Size = new System.Drawing.Size(96, 20);
            this.dtpExpectedOn.TabIndex = 153;
            // 
            // btnSupplierSearch
            // 
            this.btnSupplierSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSupplierSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSupplierSearch.Location = new System.Drawing.Point(458, 43);
            this.btnSupplierSearch.Name = "btnSupplierSearch";
            this.btnSupplierSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSupplierSearch.TabIndex = 125;
            this.btnSupplierSearch.UseVisualStyleBackColor = true;
            this.btnSupplierSearch.Click += new System.EventHandler(this.btnSupplierSearch_Click);
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(240, 45);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(216, 20);
            this.txtSuppName.TabIndex = 124;
            this.txtSuppName.Text = " ";
            this.txtSuppName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppName_KeyDown);
            // 
            // cmbPayment
            // 
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Location = new System.Drawing.Point(339, 71);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(116, 21);
            this.cmbPayment.TabIndex = 123;
            this.cmbPayment.SelectedIndexChanged += new System.EventHandler(this.cmbPayment_SelectedIndexChanged);
            this.cmbPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayment_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(271, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Payment:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(339, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(117, 20);
            this.dtpDate.TabIndex = 121;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(491, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 119;
            this.label9.Text = "Shift To :";
            // 
            // txtShiftToHeader
            // 
            this.txtShiftToHeader.Location = new System.Drawing.Point(559, 45);
            this.txtShiftToHeader.Name = "txtShiftToHeader";
            this.txtShiftToHeader.Size = new System.Drawing.Size(412, 20);
            this.txtShiftToHeader.TabIndex = 118;
            this.txtShiftToHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShiftToHeader_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 115;
            this.label7.Text = "Supplier:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(294, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Date:";
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Location = new System.Drawing.Point(107, 45);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(128, 20);
            this.txtSuppCode.TabIndex = 112;
            this.txtSuppCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppCode_KeyDown);
            this.txtSuppCode.Enter += new System.EventHandler(this.txtSuppCode_Enter);
            // 
            // btnSaveDocSearch
            // 
            this.btnSaveDocSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnSaveDocSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnSaveDocSearch.Location = new System.Drawing.Point(239, 16);
            this.btnSaveDocSearch.Name = "btnSaveDocSearch";
            this.btnSaveDocSearch.Size = new System.Drawing.Size(25, 22);
            this.btnSaveDocSearch.TabIndex = 103;
            this.btnSaveDocSearch.TabStop = false;
            this.btnSaveDocSearch.UseVisualStyleBackColor = true;
            this.btnSaveDocSearch.Click += new System.EventHandler(this.btnSaveDocSearch_Click);
            this.btnSaveDocSearch.Enter += new System.EventHandler(this.btnSaveDocSearch_Enter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Inventory.Properties.Resources.ic_asteric;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(92, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(12, 13);
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Document No:";
            // 
            // purchaseOrderBindingSource
            // 
            this.purchaseOrderBindingSource.DataMember = "PurchaseOrder";
            this.purchaseOrderBindingSource.DataSource = this.dsForReports;
            // 
            // goodReceivedNoteBindingSource
            // 
            this.goodReceivedNoteBindingSource.DataMember = "GoodReceivedNote";
            this.goodReceivedNoteBindingSource.DataSource = this.dsForReports;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(28, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 152;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(986, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPurchaseOrder_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseOrder_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTempPON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodReceivedNoteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtShiftAddress1;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.BindingSource goodReceivedNoteBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtCreditPeriod;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Button btnSupplierSearch;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSuppCode;
        private System.Windows.Forms.Button btnSaveDocSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtShiftToHeader;
        private System.Windows.Forms.DateTimePicker dtpExpectedOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtShiftAddress2;
        private System.Windows.Forms.BindingSource purchaseOrderBindingSource;
        private System.Windows.Forms.DataGridView dataGridTempPON;
        private System.Windows.Forms.BindingSource purchaseOrderBindingSource1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDelete;
    }
}