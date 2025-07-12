namespace Inventory
{
    partial class frmCashOut
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
            this.lblTempDocNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbCashOUT = new System.Windows.Forms.RadioButton();
            this.rbCashIN = new System.Windows.Forms.RadioButton();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCashIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCashOut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTempDocNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rbCashOUT);
            this.groupBox1.Controls.Add(this.rbCashIN);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCashIn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCashOut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblTempDocNo
            // 
            this.lblTempDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTempDocNo.Location = new System.Drawing.Point(74, 22);
            this.lblTempDocNo.Name = "lblTempDocNo";
            this.lblTempDocNo.Size = new System.Drawing.Size(110, 20);
            this.lblTempDocNo.TabIndex = 11;
            this.lblTempDocNo.Text = "CIO01000001";
            this.lblTempDocNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Doc. No";
            // 
            // rbCashOUT
            // 
            this.rbCashOUT.AutoSize = true;
            this.rbCashOUT.Location = new System.Drawing.Point(160, 58);
            this.rbCashOUT.Name = "rbCashOUT";
            this.rbCashOUT.Size = new System.Drawing.Size(75, 17);
            this.rbCashOUT.TabIndex = 9;
            this.rbCashOUT.TabStop = true;
            this.rbCashOUT.Text = "Cash OUT";
            this.rbCashOUT.UseVisualStyleBackColor = true;
            this.rbCashOUT.CheckedChanged += new System.EventHandler(this.rbCashOUT_CheckedChanged);
            // 
            // rbCashIN
            // 
            this.rbCashIN.AutoSize = true;
            this.rbCashIN.Location = new System.Drawing.Point(77, 58);
            this.rbCashIN.Name = "rbCashIN";
            this.rbCashIN.Size = new System.Drawing.Size(63, 17);
            this.rbCashIN.TabIndex = 8;
            this.rbCashIN.TabStop = true;
            this.rbCashIN.Text = "Cash IN";
            this.rbCashIN.UseVisualStyleBackColor = true;
            this.rbCashIN.CheckedChanged += new System.EventHandler(this.rbCashIN_CheckedChanged);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(74, 154);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(311, 20);
            this.txtReason.TabIndex = 2;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReason_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Reason";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(286, 22);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date ";
            // 
            // txtCashIn
            // 
            this.txtCashIn.Location = new System.Drawing.Point(74, 90);
            this.txtCashIn.Name = "txtCashIn";
            this.txtCashIn.Size = new System.Drawing.Size(110, 20);
            this.txtCashIn.TabIndex = 1;
            this.txtCashIn.Text = "0.00";
            this.txtCashIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashIn_KeyDown);
            this.txtCashIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashIn_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cash IN ";
            // 
            // txtCashOut
            // 
            this.txtCashOut.Location = new System.Drawing.Point(74, 122);
            this.txtCashOut.Name = "txtCashOut";
            this.txtCashOut.Size = new System.Drawing.Size(110, 20);
            this.txtCashOut.TabIndex = 0;
            this.txtCashOut.Text = "0.00";
            this.txtCashOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashOut_KeyDown);
            this.txtCashOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashOut_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cash OUT";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(317, 203);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 29);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(229, 203);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 29);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(141, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(1, 194);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(401, 49);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmCashOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(401, 242);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashOut";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash IN/OUT Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCashOut_FormClosed);
            this.Load += new System.EventHandler(this.frmCashOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCashOut;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCashIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RadioButton rbCashOUT;
        private System.Windows.Forms.RadioButton rbCashIN;
        private System.Windows.Forms.Label lblTempDocNo;
        private System.Windows.Forms.Label label5;
    }
}