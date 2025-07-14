namespace Inventory
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocation = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdLoca = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dsLocaWiseProdOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.dsForReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkRemember = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLocaWiseProdOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReportsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 267);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 74);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.White;
            this.txtLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(432, 119);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(248, 21);
            this.txtLocation.TabIndex = 0;
            this.txtLocation.Enter += new System.EventHandler(this.txtLocation_Enter_1);
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocation_KeyDown);
            this.txtLocation.Leave += new System.EventHandler(this.txtLocation_Leave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(352, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Location";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(433, 185);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(247, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(433, 152);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(247, 21);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "User Name";
            // 
            // btnLocation
            // 
            this.btnLocation.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnLocation.Location = new System.Drawing.Point(648, 12);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(27, 23);
            this.btnLocation.TabIndex = 1;
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Visible = false;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // grdLoca
            // 
            this.grdLoca.AllowUserToAddRows = false;
            this.grdLoca.AllowUserToDeleteRows = false;
            this.grdLoca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLoca.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdLoca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoca.Location = new System.Drawing.Point(9, 41);
            this.grdLoca.Name = "grdLoca";
            this.grdLoca.ReadOnly = true;
            this.grdLoca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLoca.Size = new System.Drawing.Size(326, 198);
            this.grdLoca.TabIndex = 48;
            this.grdLoca.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLoca_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(352, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 47);
            this.label4.TabIndex = 49;
            this.label4.Text = "Sign In";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(108, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Copyright © 2025 All Rights Reserved";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(180, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 51;
            this.label7.Text = "Powered By : ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(182, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 52;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(473, 281);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(91, 39);
            this.btnLogin.TabIndex = 53;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(570, 281);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 39);
            this.btnExit.TabIndex = 54;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dsLocaWiseProdOrderBindingSource
            // 
            this.dsLocaWiseProdOrderBindingSource.DataMember = "dsLocaWiseProdOrder";
            this.dsLocaWiseProdOrderBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsForReportsBindingSource
            // 
            this.dsForReportsBindingSource.DataSource = this.dsForReports;
            this.dsForReportsBindingSource.Position = 0;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(566, 222);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(95, 17);
            this.chkRemember.TabIndex = 55;
            this.chkRemember.Text = "Remember Me";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(687, 341);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdLoca);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmlogin_FormClosed);
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmlogin_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLocaWiseProdOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReportsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource dsLocaWiseProdOrderBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.BindingSource dsForReportsBindingSource;
        private System.Windows.Forms.DataGridView grdLoca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkRemember;
    }
}