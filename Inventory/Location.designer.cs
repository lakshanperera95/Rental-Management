namespace Inventory
{
    partial class frmLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocation));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.GrbHeader = new System.Windows.Forms.GroupBox();
            this.chkOgf = new System.Windows.Forms.CheckBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTaxReg = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtLocaName = new System.Windows.Forms.TextBox();
            this.CmdHlpLocation = new System.Windows.Forms.Button();
            this.Label9 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.TxtFax = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.TxtTelephone = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtAddress3 = new System.Windows.Forms.TextBox();
            this.TxtAddress1 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TxtAddress2 = new System.Windows.Forms.TextBox();
            this.errLocaCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errLocaName = new System.Windows.Forms.ErrorProvider(this.components);
            this.TxtLocaCode = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.GrbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLocaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLocaName)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnClear,
            this.btnDelete,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 303);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(517, 45);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.AutoSize = false;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 42);
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClear.AutoSize = false;
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 42);
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDelete.AutoSize = false;
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 42);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.AutoSize = false;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 42);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GrbHeader
            // 
            this.GrbHeader.BackColor = System.Drawing.Color.AliceBlue;
            this.GrbHeader.Controls.Add(this.chkOgf);
            this.GrbHeader.Controls.Add(this.txtWebsite);
            this.GrbHeader.Controls.Add(this.label1);
            this.GrbHeader.Controls.Add(this.TxtTaxReg);
            this.GrbHeader.Controls.Add(this.Label2);
            this.GrbHeader.Controls.Add(this.TxtLocaName);
            this.GrbHeader.Controls.Add(this.CmdHlpLocation);
            this.GrbHeader.Controls.Add(this.TxtLocaCode);
            this.GrbHeader.Controls.Add(this.Label9);
            this.GrbHeader.Controls.Add(this.TxtEmail);
            this.GrbHeader.Controls.Add(this.Label6);
            this.GrbHeader.Controls.Add(this.TxtFax);
            this.GrbHeader.Controls.Add(this.Label5);
            this.GrbHeader.Controls.Add(this.TxtTelephone);
            this.GrbHeader.Controls.Add(this.Label3);
            this.GrbHeader.Controls.Add(this.TxtAddress3);
            this.GrbHeader.Controls.Add(this.TxtAddress1);
            this.GrbHeader.Controls.Add(this.Label4);
            this.GrbHeader.Controls.Add(this.TxtAddress2);
            this.GrbHeader.Location = new System.Drawing.Point(-2, 4);
            this.GrbHeader.Name = "GrbHeader";
            this.GrbHeader.Size = new System.Drawing.Size(519, 296);
            this.GrbHeader.TabIndex = 10;
            this.GrbHeader.TabStop = false;
            // 
            // chkOgf
            // 
            this.chkOgf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkOgf.AutoSize = true;
            this.chkOgf.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.chkOgf.Location = new System.Drawing.Point(118, 270);
            this.chkOgf.Name = "chkOgf";
            this.chkOgf.Size = new System.Drawing.Size(50, 17);
            this.chkOgf.TabIndex = 214;
            this.chkOgf.Text = "OGF";
            this.chkOgf.UseVisualStyleBackColor = true;
            this.chkOgf.CheckedChanged += new System.EventHandler(this.chkOgf_CheckedChanged);
            // 
            // txtWebsite
            // 
            this.txtWebsite.AcceptsReturn = true;
            this.txtWebsite.BackColor = System.Drawing.Color.White;
            this.txtWebsite.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebsite.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWebsite.Location = new System.Drawing.Point(118, 215);
            this.txtWebsite.MaxLength = 0;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWebsite.Size = new System.Drawing.Size(387, 21);
            this.txtWebsite.TabIndex = 47;
            this.txtWebsite.Tag = "Email";
            this.txtWebsite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWebsite_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(8, 215);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "Website";
            // 
            // TxtTaxReg
            // 
            this.TxtTaxReg.AcceptsReturn = true;
            this.TxtTaxReg.BackColor = System.Drawing.Color.White;
            this.TxtTaxReg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtTaxReg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTaxReg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtTaxReg.Location = new System.Drawing.Point(118, 243);
            this.TxtTaxReg.MaxLength = 0;
            this.TxtTaxReg.Name = "TxtTaxReg";
            this.TxtTaxReg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtTaxReg.Size = new System.Drawing.Size(387, 21);
            this.TxtTaxReg.TabIndex = 10;
            this.TxtTaxReg.Tag = "";
            this.TxtTaxReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTaxReg_KeyDown);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label2.Location = new System.Drawing.Point(8, 243);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(101, 16);
            this.Label2.TabIndex = 44;
            this.Label2.Text = "Tax Reg. #";
            // 
            // TxtLocaName
            // 
            this.TxtLocaName.AcceptsReturn = true;
            this.TxtLocaName.BackColor = System.Drawing.Color.White;
            this.TxtLocaName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtLocaName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLocaName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtLocaName.Location = new System.Drawing.Point(234, 19);
            this.TxtLocaName.MaxLength = 0;
            this.TxtLocaName.Name = "TxtLocaName";
            this.TxtLocaName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtLocaName.Size = new System.Drawing.Size(241, 21);
            this.TxtLocaName.TabIndex = 2;
            this.TxtLocaName.TextChanged += new System.EventHandler(this.TxtLocaName_TextChanged);
            this.TxtLocaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocaName_KeyDown);
            // 
            // CmdHlpLocation
            // 
            this.CmdHlpLocation.BackColor = System.Drawing.Color.Transparent;
            this.CmdHlpLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdHlpLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdHlpLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdHlpLocation.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.CmdHlpLocation.Location = new System.Drawing.Point(479, 19);
            this.CmdHlpLocation.Name = "CmdHlpLocation";
            this.CmdHlpLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdHlpLocation.Size = new System.Drawing.Size(27, 22);
            this.CmdHlpLocation.TabIndex = 3;
            this.CmdHlpLocation.UseVisualStyleBackColor = false;
            this.CmdHlpLocation.Click += new System.EventHandler(this.CmdHlpLocation_Click);
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label9.Location = new System.Drawing.Point(8, 19);
            this.Label9.Name = "Label9";
            this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label9.Size = new System.Drawing.Size(101, 16);
            this.Label9.TabIndex = 39;
            this.Label9.Text = "Location";
            // 
            // TxtEmail
            // 
            this.TxtEmail.AcceptsReturn = true;
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtEmail.Location = new System.Drawing.Point(118, 188);
            this.TxtEmail.MaxLength = 0;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtEmail.Size = new System.Drawing.Size(387, 21);
            this.TxtEmail.TabIndex = 9;
            this.TxtEmail.Tag = "Email";
            this.TxtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEmail_KeyDown);
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label6.Location = new System.Drawing.Point(8, 188);
            this.Label6.Name = "Label6";
            this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label6.Size = new System.Drawing.Size(101, 16);
            this.Label6.TabIndex = 30;
            this.Label6.Text = "Email";
            // 
            // TxtFax
            // 
            this.TxtFax.AcceptsReturn = true;
            this.TxtFax.BackColor = System.Drawing.Color.White;
            this.TxtFax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtFax.Location = new System.Drawing.Point(118, 160);
            this.TxtFax.MaxLength = 0;
            this.TxtFax.Name = "TxtFax";
            this.TxtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtFax.Size = new System.Drawing.Size(387, 21);
            this.TxtFax.TabIndex = 8;
            this.TxtFax.Tag = "";
            this.TxtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFax_KeyDown);
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label5.Location = new System.Drawing.Point(8, 160);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(101, 16);
            this.Label5.TabIndex = 28;
            this.Label5.Text = "Fax #";
            // 
            // TxtTelephone
            // 
            this.TxtTelephone.AcceptsReturn = true;
            this.TxtTelephone.BackColor = System.Drawing.Color.White;
            this.TxtTelephone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtTelephone.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelephone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtTelephone.Location = new System.Drawing.Point(118, 132);
            this.TxtTelephone.MaxLength = 0;
            this.TxtTelephone.Name = "TxtTelephone";
            this.TxtTelephone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtTelephone.Size = new System.Drawing.Size(387, 21);
            this.TxtTelephone.TabIndex = 7;
            this.TxtTelephone.Tag = "Telephone";
            this.TxtTelephone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTelephone_KeyDown);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label3.Location = new System.Drawing.Point(8, 132);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(101, 16);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "Telephone #";
            // 
            // TxtAddress3
            // 
            this.TxtAddress3.AcceptsReturn = true;
            this.TxtAddress3.BackColor = System.Drawing.Color.White;
            this.TxtAddress3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtAddress3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtAddress3.Location = new System.Drawing.Point(118, 104);
            this.TxtAddress3.MaxLength = 0;
            this.TxtAddress3.Name = "TxtAddress3";
            this.TxtAddress3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtAddress3.Size = new System.Drawing.Size(387, 21);
            this.TxtAddress3.TabIndex = 6;
            this.TxtAddress3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddress3_KeyDown);
            // 
            // TxtAddress1
            // 
            this.TxtAddress1.AcceptsReturn = true;
            this.TxtAddress1.BackColor = System.Drawing.Color.White;
            this.TxtAddress1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtAddress1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtAddress1.Location = new System.Drawing.Point(118, 48);
            this.TxtAddress1.MaxLength = 0;
            this.TxtAddress1.Name = "TxtAddress1";
            this.TxtAddress1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtAddress1.Size = new System.Drawing.Size(387, 21);
            this.TxtAddress1.TabIndex = 4;
            this.TxtAddress1.Tag = "Address";
            this.TxtAddress1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddress1_KeyDown);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label4.Location = new System.Drawing.Point(8, 48);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(101, 16);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Address";
            // 
            // TxtAddress2
            // 
            this.TxtAddress2.AcceptsReturn = true;
            this.TxtAddress2.BackColor = System.Drawing.Color.White;
            this.TxtAddress2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtAddress2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtAddress2.Location = new System.Drawing.Point(118, 76);
            this.TxtAddress2.MaxLength = 0;
            this.TxtAddress2.Name = "TxtAddress2";
            this.TxtAddress2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtAddress2.Size = new System.Drawing.Size(387, 21);
            this.TxtAddress2.TabIndex = 5;
            this.TxtAddress2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddress2_KeyDown);
            // 
            // errLocaCode
            // 
            this.errLocaCode.ContainerControl = this;
            this.errLocaCode.Icon = ((System.Drawing.Icon)(resources.GetObject("errLocaCode.Icon")));
            this.errLocaCode.RightToLeft = true;
            // 
            // errLocaName
            // 
            this.errLocaName.ContainerControl = this;
            this.errLocaName.Icon = ((System.Drawing.Icon)(resources.GetObject("errLocaName.Icon")));
            this.errLocaName.RightToLeft = true;
            // 
            // TxtLocaCode
            // 
            this.TxtLocaCode.AcceptsReturn = true;
            this.TxtLocaCode.BackColor = System.Drawing.Color.White;
            this.TxtLocaCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtLocaCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLocaCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtLocaCode.Location = new System.Drawing.Point(118, 19);
            this.TxtLocaCode.MaxLength = 10;
            this.TxtLocaCode.Name = "TxtLocaCode";
            this.TxtLocaCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtLocaCode.Size = new System.Drawing.Size(113, 21);
            this.TxtLocaCode.TabIndex = 1;
            this.TxtLocaCode.Tag = "Location Code";
            this.TxtLocaCode.TextChanged += new System.EventHandler(this.TxtLocaCode_TextChanged);
            this.TxtLocaCode.Enter += new System.EventHandler(this.TxtLocaCode_Enter);
            this.TxtLocaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocaCode_KeyDown);
            // 
            // frmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(517, 348);
            this.Controls.Add(this.GrbHeader);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLocation_FormClosed);
            this.Load += new System.EventHandler(this.frmLocation_Load);
            this.Leave += new System.EventHandler(this.frmLocation_Leave);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GrbHeader.ResumeLayout(false);
            this.GrbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLocaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLocaName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.GroupBox GrbHeader;
        public System.Windows.Forms.TextBox TxtTaxReg;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox TxtLocaName;
        public System.Windows.Forms.Button CmdHlpLocation;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.TextBox TxtEmail;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.TextBox TxtFax;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.TextBox TxtTelephone;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.TextBox TxtAddress1;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.TextBox TxtAddress2;
        public System.Windows.Forms.TextBox TxtAddress3;
        private System.Windows.Forms.ErrorProvider errLocaCode;
        private System.Windows.Forms.ErrorProvider errLocaName;
        public System.Windows.Forms.TextBox txtWebsite;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOgf;
        public System.Windows.Forms.TextBox TxtLocaCode;
    }
}