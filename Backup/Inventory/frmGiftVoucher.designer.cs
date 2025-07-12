namespace Inventory
{
    partial class frmGiftVoucher
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCharacter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiftVoucherCode = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cmbGiftVoucherAmount = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtExpireDate = new System.Windows.Forms.DateTimePicker();
            this.chkNoExpire = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDi_Code = new System.Windows.Forms.TextBox();
            this.txtBookNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkUserDefine = new System.Windows.Forms.CheckBox();
            this.cmbQty = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbVoucherId = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblQty);
            this.groupBox2.Controls.Add(this.cmbVoucherId);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbQty);
            this.groupBox2.Controls.Add(this.chkUserDefine);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBookNumber);
            this.groupBox2.Controls.Add(this.txtDi_Code);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chkNoExpire);
            this.groupBox2.Controls.Add(this.dtExpireDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbLocation);
            this.groupBox2.Controls.Add(this.cmbGiftVoucherAmount);
            this.groupBox2.Controls.Add(this.txtLocation);
            this.groupBox2.Controls.Add(this.txtGiftVoucherCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCreateDate);
            this.groupBox2.Controls.Add(this.lblCreateUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCharacter);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 324);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtCharacter
            // 
            this.txtCharacter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCharacter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCharacter.BackColor = System.Drawing.Color.White;
            this.txtCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtCharacter.Enabled = false;
            this.txtCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharacter.ForeColor = System.Drawing.Color.Black;
            this.txtCharacter.FormattingEnabled = true;
            this.txtCharacter.Location = new System.Drawing.Point(308, 111);
            this.txtCharacter.Name = "txtCharacter";
            this.txtCharacter.Size = new System.Drawing.Size(74, 21);
            this.txtCharacter.TabIndex = 21;
            this.txtCharacter.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gift Voucher Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Location";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Location = new System.Drawing.Point(306, 231);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(0, 13);
            this.lblCreateUser.TabIndex = 6;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(125, 232);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreateDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gift Voucher Code Start";
            // 
            // txtGiftVoucherCode
            // 
            this.txtGiftVoucherCode.Location = new System.Drawing.Point(342, 237);
            this.txtGiftVoucherCode.Name = "txtGiftVoucherCode";
            this.txtGiftVoucherCode.Size = new System.Drawing.Size(25, 20);
            this.txtGiftVoucherCode.TabIndex = 16;
            this.txtGiftVoucherCode.Visible = false;
            this.txtGiftVoucherCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiftVoucherCode_KeyDown);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(141, 20);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(226, 20);
            this.txtLocation.TabIndex = 2;
            // 
            // cmbGiftVoucherAmount
            // 
            this.cmbGiftVoucherAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiftVoucherAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiftVoucherAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGiftVoucherAmount.FormattingEnabled = true;
            this.cmbGiftVoucherAmount.Location = new System.Drawing.Point(141, 111);
            this.cmbGiftVoucherAmount.Name = "cmbGiftVoucherAmount";
            this.cmbGiftVoucherAmount.Size = new System.Drawing.Size(161, 21);
            this.cmbGiftVoucherAmount.TabIndex = 2;
            this.cmbGiftVoucherAmount.SelectedIndexChanged += new System.EventHandler(this.cmbGiftVoucherAmount_SelectedIndexChanged);
            this.cmbGiftVoucherAmount.Leave += new System.EventHandler(this.cmbGiftVoucherAmount_Leave);
            this.cmbGiftVoucherAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGiftVoucherAmount_KeyDown);
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(141, 19);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(226, 21);
            this.cmbLocation.TabIndex = 5;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.cmbLocation_SelectedIndexChanged);
            this.cmbLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLocation_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Expire Date";
            // 
            // dtExpireDate
            // 
            this.dtExpireDate.Enabled = false;
            this.dtExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpireDate.Location = new System.Drawing.Point(141, 210);
            this.dtExpireDate.Name = "dtExpireDate";
            this.dtExpireDate.Size = new System.Drawing.Size(114, 20);
            this.dtExpireDate.TabIndex = 6;
            // 
            // chkNoExpire
            // 
            this.chkNoExpire.AutoSize = true;
            this.chkNoExpire.Checked = true;
            this.chkNoExpire.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoExpire.Location = new System.Drawing.Point(295, 214);
            this.chkNoExpire.Name = "chkNoExpire";
            this.chkNoExpire.Size = new System.Drawing.Size(72, 17);
            this.chkNoExpire.TabIndex = 14;
            this.chkNoExpire.Text = "No Expire";
            this.chkNoExpire.UseVisualStyleBackColor = true;
            this.chkNoExpire.CheckedChanged += new System.EventHandler(this.chkNoExpire_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 53);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(327, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(141, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(235, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "QTY ";
            // 
            // txtDi_Code
            // 
            this.txtDi_Code.Location = new System.Drawing.Point(141, 138);
            this.txtDi_Code.MaxLength = 6;
            this.txtDi_Code.Name = "txtDi_Code";
            this.txtDi_Code.Size = new System.Drawing.Size(83, 20);
            this.txtDi_Code.TabIndex = 3;
            this.txtDi_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDi_Code_KeyDown);
            // 
            // txtBookNumber
            // 
            this.txtBookNumber.Location = new System.Drawing.Point(141, 85);
            this.txtBookNumber.Name = "txtBookNumber";
            this.txtBookNumber.Size = new System.Drawing.Size(226, 20);
            this.txtBookNumber.TabIndex = 1;
            this.txtBookNumber.TextChanged += new System.EventHandler(this.txtBookNumber_TextChanged);
            this.txtBookNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBookNumber_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Book Number";
            // 
            // chkUserDefine
            // 
            this.chkUserDefine.AutoSize = true;
            this.chkUserDefine.BackColor = System.Drawing.Color.Transparent;
            this.chkUserDefine.Location = new System.Drawing.Point(285, 151);
            this.chkUserDefine.Name = "chkUserDefine";
            this.chkUserDefine.Size = new System.Drawing.Size(82, 17);
            this.chkUserDefine.TabIndex = 22;
            this.chkUserDefine.Text = "User Define";
            this.chkUserDefine.UseVisualStyleBackColor = false;
            this.chkUserDefine.CheckedChanged += new System.EventHandler(this.chkUserDefine_CheckedChanged);
            // 
            // cmbQty
            // 
            this.cmbQty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbQty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQty.FormattingEnabled = true;
            this.cmbQty.Items.AddRange(new object[] {
            "20",
            "25",
            "50"});
            this.cmbQty.Location = new System.Drawing.Point(282, 174);
            this.cmbQty.Name = "cmbQty";
            this.cmbQty.Size = new System.Drawing.Size(85, 21);
            this.cmbQty.TabIndex = 4;
            this.cmbQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbQty_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Voucher ID";
            // 
            // cmbVoucherId
            // 
            this.cmbVoucherId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVoucherId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVoucherId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoucherId.FormattingEnabled = true;
            this.cmbVoucherId.Items.AddRange(new object[] {
            "GVA",
            "GVB",
            "GVC",
            "GVD",
            "GVE",
            "GVF",
            "GVG",
            "GVP"});
            this.cmbVoucherId.Location = new System.Drawing.Point(141, 58);
            this.cmbVoucherId.Name = "cmbVoucherId";
            this.cmbVoucherId.Size = new System.Drawing.Size(85, 21);
            this.cmbVoucherId.TabIndex = 23;
            this.cmbVoucherId.SelectedIndexChanged += new System.EventHandler(this.cmbVoucherId_SelectedIndexChanged);
            this.cmbVoucherId.SelectedValueChanged += new System.EventHandler(this.cmbVoucherId_SelectedValueChanged);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(328, 63);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(0, 13);
            this.lblQty.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Book Qty";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // frmGiftVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(436, 343);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGiftVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Voucher";
            this.Load += new System.EventHandler(this.frmGiftVoucher_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGiftVoucher_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ComboBox cmbVoucherId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbQty;
        private System.Windows.Forms.CheckBox chkUserDefine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBookNumber;
        private System.Windows.Forms.TextBox txtDi_Code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkNoExpire;
        private System.Windows.Forms.DateTimePicker dtExpireDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.ComboBox cmbGiftVoucherAmount;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtGiftVoucherCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtCharacter;
        private System.Windows.Forms.GroupBox groupBox1;

        //   private ButtonClear buttonClear1;
        //   private ctrlClose ctrlClose1;
    }
}

