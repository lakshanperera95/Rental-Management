namespace Inventory
{
    partial class frmPosUpdate
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnCusExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.btnAddLinkServers = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.rbOutlet = new System.Windows.Forms.RadioButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Location = new System.Drawing.Point(0, 229);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(429, 65);
            this.toolStrip2.TabIndex = 135;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnCusExit
            // 
            this.btnCusExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCusExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCusExit.FlatAppearance.BorderSize = 0;
            this.btnCusExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCusExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCusExit.Location = new System.Drawing.Point(317, 233);
            this.btnCusExit.Name = "btnCusExit";
            this.btnCusExit.Size = new System.Drawing.Size(100, 50);
            this.btnCusExit.TabIndex = 160;
            this.btnCusExit.Text = "Exit";
            this.btnCusExit.UseVisualStyleBackColor = false;
            this.btnCusExit.Click += new System.EventHandler(this.btnCusExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(197, 233);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 50);
            this.btnUpdate.TabIndex = 161;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.Location = new System.Drawing.Point(12, 12);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(407, 160);
            this.listBoxMsgs.TabIndex = 162;
            this.listBoxMsgs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxMsgs_MouseDoubleClick);
            // 
            // btnRunScript
            // 
            this.btnRunScript.BackColor = System.Drawing.Color.Aqua;
            this.btnRunScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRunScript.Location = new System.Drawing.Point(12, 234);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(122, 23);
            this.btnRunScript.TabIndex = 163;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = false;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // btnAddLinkServers
            // 
            this.btnAddLinkServers.BackColor = System.Drawing.Color.Aqua;
            this.btnAddLinkServers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLinkServers.Location = new System.Drawing.Point(12, 263);
            this.btnAddLinkServers.Name = "btnAddLinkServers";
            this.btnAddLinkServers.Size = new System.Drawing.Size(122, 23);
            this.btnAddLinkServers.TabIndex = 164;
            this.btnAddLinkServers.Text = "Refresh Link Servers";
            this.btnAddLinkServers.UseVisualStyleBackColor = false;
            this.btnAddLinkServers.Click += new System.EventHandler(this.btnAddLinkServers_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 178);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(287, 48);
            this.txtQuery.TabIndex = 165;
            this.txtQuery.Text = "";
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Checked = true;
            this.rbMain.Location = new System.Drawing.Point(314, 179);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(82, 17);
            this.rbMain.TabIndex = 166;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "Main Server";
            this.rbMain.UseVisualStyleBackColor = true;
            this.rbMain.CheckedChanged += new System.EventHandler(this.rbMain_CheckedChanged);
            // 
            // rbOutlet
            // 
            this.rbOutlet.AutoSize = true;
            this.rbOutlet.Location = new System.Drawing.Point(314, 202);
            this.rbOutlet.Name = "rbOutlet";
            this.rbOutlet.Size = new System.Drawing.Size(87, 17);
            this.rbOutlet.TabIndex = 167;
            this.rbOutlet.Text = "Outlet Server";
            this.rbOutlet.UseVisualStyleBackColor = true;
            this.rbOutlet.CheckedChanged += new System.EventHandler(this.rbOutlet_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(504, 135);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 174;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 175;
            this.label8.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(504, 109);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(154, 20);
            this.txtUser.TabIndex = 172;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 173;
            this.label7.Text = "User";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(504, 83);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(154, 20);
            this.txtDataBase.TabIndex = 170;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 171;
            this.label6.Text = "DataBase";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(504, 57);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(154, 20);
            this.txtServer.TabIndex = 168;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 169;
            this.label5.Text = "Server";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aqua;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(536, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 177;
            this.button1.Text = "Refresh Link Servers";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aqua;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(536, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 176;
            this.button2.Text = "Run Script";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // frmPosUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(429, 294);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbOutlet);
            this.Controls.Add(this.rbMain);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnAddLinkServers);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.listBoxMsgs);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCusExit);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pos Terminal Product Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPosUpdate_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPosUpdate_FormClosed);
            this.Load += new System.EventHandler(this.frmPosUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Button btnCusExit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox listBoxMsgs;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnAddLinkServers;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.RadioButton rbOutlet;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}