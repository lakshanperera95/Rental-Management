namespace Inventory
{
    partial class frmUserProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserProfile));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.chkUserMustChangePwd = new System.Windows.Forms.CheckBox();
            this.chkUserCannotchangepwd = new System.Windows.Forms.CheckBox();
            this.chkAccountDesable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMemberOf = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dtExpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearchCodeFrom = new System.Windows.Forms.Button();
            this.chkTransCancel = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(110, 25);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(293, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(110, 51);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(293, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Enabled = false;
            this.txtConfirmPassword.Location = new System.Drawing.Point(110, 77);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(293, 20);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            // 
            // chkUserMustChangePwd
            // 
            this.chkUserMustChangePwd.AutoSize = true;
            this.chkUserMustChangePwd.Location = new System.Drawing.Point(18, 112);
            this.chkUserMustChangePwd.Name = "chkUserMustChangePwd";
            this.chkUserMustChangePwd.Size = new System.Drawing.Size(230, 17);
            this.chkUserMustChangePwd.TabIndex = 7;
            this.chkUserMustChangePwd.Text = "User must Change Password at next Logon";
            this.chkUserMustChangePwd.UseVisualStyleBackColor = true;
            // 
            // chkUserCannotchangepwd
            // 
            this.chkUserCannotchangepwd.AutoSize = true;
            this.chkUserCannotchangepwd.Location = new System.Drawing.Point(18, 135);
            this.chkUserCannotchangepwd.Name = "chkUserCannotchangepwd";
            this.chkUserCannotchangepwd.Size = new System.Drawing.Size(174, 17);
            this.chkUserCannotchangepwd.TabIndex = 8;
            this.chkUserCannotchangepwd.Text = "User Cannot Change Password";
            this.chkUserCannotchangepwd.UseVisualStyleBackColor = true;
            // 
            // chkAccountDesable
            // 
            this.chkAccountDesable.AutoSize = true;
            this.chkAccountDesable.Location = new System.Drawing.Point(18, 158);
            this.chkAccountDesable.Name = "chkAccountDesable";
            this.chkAccountDesable.Size = new System.Drawing.Size(108, 17);
            this.chkAccountDesable.TabIndex = 9;
            this.chkAccountDesable.Text = "Account Desable";
            this.chkAccountDesable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdvance);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbMemberOf);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 97);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member Of";
            // 
            // btnAdvance
            // 
            this.btnAdvance.Enabled = false;
            this.btnAdvance.Image = global::Inventory.Properties.Resources.User_Role;
            this.btnAdvance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdvance.Location = new System.Drawing.Point(311, 22);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(114, 48);
            this.btnAdvance.TabIndex = 15;
            this.btnAdvance.Text = "       Advance";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Member Of";
            // 
            // cmbMemberOf
            // 
            this.cmbMemberOf.Enabled = false;
            this.cmbMemberOf.FormattingEnabled = true;
            this.cmbMemberOf.Location = new System.Drawing.Point(98, 29);
            this.cmbMemberOf.Name = "cmbMemberOf";
            this.cmbMemberOf.Size = new System.Drawing.Size(193, 21);
            this.cmbMemberOf.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(323, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 41);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(172, 297);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(114, 41);
            this.btnCreate.TabIndex = 16;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dtExpDate
            // 
            this.dtExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpDate.Location = new System.Drawing.Point(307, 155);
            this.dtExpDate.Name = "dtExpDate";
            this.dtExpDate.Size = new System.Drawing.Size(96, 20);
            this.dtExpDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Account Exp Date";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(21, 297);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 41);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearchCodeFrom
            // 
            this.btnSearchCodeFrom.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCodeFrom.Image")));
            this.btnSearchCodeFrom.Location = new System.Drawing.Point(409, 24);
            this.btnSearchCodeFrom.Name = "btnSearchCodeFrom";
            this.btnSearchCodeFrom.Size = new System.Drawing.Size(28, 21);
            this.btnSearchCodeFrom.TabIndex = 2;
            this.btnSearchCodeFrom.UseVisualStyleBackColor = true;
            this.btnSearchCodeFrom.Click += new System.EventHandler(this.btnSearchCodeFrom_Click);
            // 
            // chkTransCancel
            // 
            this.chkTransCancel.AutoSize = true;
            this.chkTransCancel.Location = new System.Drawing.Point(307, 112);
            this.chkTransCancel.Name = "chkTransCancel";
            this.chkTransCancel.Size = new System.Drawing.Size(82, 17);
            this.chkTransCancel.TabIndex = 19;
            this.chkTransCancel.Text = "Cancelation";
            this.chkTransCancel.UseVisualStyleBackColor = true;
            // 
            // frmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(457, 347);
            this.Controls.Add(this.chkTransCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtExpDate);
            this.Controls.Add(this.btnSearchCodeFrom);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAccountDesable);
            this.Controls.Add(this.chkUserCannotchangepwd);
            this.Controls.Add(this.chkUserMustChangePwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserProfile_FormClosed);
            this.Load += new System.EventHandler(this.frmUserProfile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.CheckBox chkUserMustChangePwd;
        private System.Windows.Forms.CheckBox chkUserCannotchangepwd;
        private System.Windows.Forms.CheckBox chkAccountDesable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMemberOf;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.Button btnSearchCodeFrom;
        private System.Windows.Forms.DateTimePicker dtExpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkTransCancel;
    }
}