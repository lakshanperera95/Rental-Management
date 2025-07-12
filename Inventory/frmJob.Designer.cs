
namespace Inventory
{
    partial class frmJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJob));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewCust = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblreference = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtCusDescription = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.rdbWOWarr = new System.Windows.Forms.RadioButton();
            this.txtCusCode = new System.Windows.Forms.TextBox();
            this.rdbWithWarr = new System.Windows.Forms.RadioButton();
            this.btnCusSearch = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblremark = new System.Windows.Forms.Label();
            this.lblmobile = new System.Windows.Forms.Label();
            this.txtProdDescription = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblproduct = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnProdSearch = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btBrandSearch = new System.Windows.Forms.Button();
            this.txtBrandCode = new System.Windows.Forms.TextBox();
            this.txtBrandDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDocSearch = new System.Windows.Forms.Button();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnFClear = new System.Windows.Forms.Button();
            this.btnFExit = new System.Windows.Forms.Button();
            this.btnFApply = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txtfinishby = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnProductSrch = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.txtfprodName = new System.Windows.Forms.TextBox();
            this.txtFprodCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgadditem = new System.Windows.Forms.DataGridView();
            this.Prod_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prod_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selling_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsForReports = new Inventory.dsForReports();
            this.txtserviceCharge = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfinishremark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbJobStatue = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txthandby = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dthandOver = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtfinishdate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgadditem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.btnNewCust);
            this.groupBox1.Controls.Add(this.txtReference);
            this.groupBox1.Controls.Add(this.lblreference);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtCusDescription);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.rdbWOWarr);
            this.groupBox1.Controls.Add(this.txtCusCode);
            this.groupBox1.Controls.Add(this.rdbWithWarr);
            this.groupBox1.Controls.Add(this.btnCusSearch);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.lblremark);
            this.groupBox1.Controls.Add(this.lblmobile);
            this.groupBox1.Controls.Add(this.txtProdDescription);
            this.groupBox1.Controls.Add(this.txtMobileNo);
            this.groupBox1.Controls.Add(this.txtProdCode);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblproduct);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.btnProdSearch);
            this.groupBox1.Controls.Add(this.lblBrand);
            this.groupBox1.Controls.Add(this.btBrandSearch);
            this.groupBox1.Controls.Add(this.txtBrandCode);
            this.groupBox1.Controls.Add(this.txtBrandDescription);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 418);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // btnNewCust
            // 
            this.btnNewCust.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCust.Location = new System.Drawing.Point(535, 30);
            this.btnNewCust.Name = "btnNewCust";
            this.btnNewCust.Size = new System.Drawing.Size(58, 23);
            this.btnNewCust.TabIndex = 3;
            this.btnNewCust.Text = "New ";
            this.btnNewCust.UseVisualStyleBackColor = true;
            this.btnNewCust.Click += new System.EventHandler(this.btnNewCust_Click);
            // 
            // txtReference
            // 
            this.txtReference.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReference.Location = new System.Drawing.Point(113, 215);
            this.txtReference.Multiline = true;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(387, 35);
            this.txtReference.TabIndex = 13;
            this.txtReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReference_KeyDown);
            // 
            // lblreference
            // 
            this.lblreference.AutoSize = true;
            this.lblreference.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreference.Location = new System.Drawing.Point(14, 225);
            this.lblreference.Name = "lblreference";
            this.lblreference.Size = new System.Drawing.Size(74, 13);
            this.lblreference.TabIndex = 151;
            this.lblreference.Text = "Reference :";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(356, 349);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 42);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(480, 349);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 42);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(232, 349);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(98, 42);
            this.btnApply.TabIndex = 16;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtCusDescription
            // 
            this.txtCusDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusDescription.Location = new System.Drawing.Point(243, 33);
            this.txtCusDescription.Name = "txtCusDescription";
            this.txtCusDescription.Size = new System.Drawing.Size(257, 21);
            this.txtCusDescription.TabIndex = 1;
            this.txtCusDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCusDescription_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(13, 35);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(72, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer :";
            // 
            // rdbWOWarr
            // 
            this.rdbWOWarr.AutoSize = true;
            this.rdbWOWarr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbWOWarr.Location = new System.Drawing.Point(372, 282);
            this.rdbWOWarr.Name = "rdbWOWarr";
            this.rdbWOWarr.Size = new System.Drawing.Size(126, 17);
            this.rdbWOWarr.TabIndex = 15;
            this.rdbWOWarr.TabStop = true;
            this.rdbWOWarr.Text = "WithOut Warranty";
            this.rdbWOWarr.UseVisualStyleBackColor = true;
            // 
            // txtCusCode
            // 
            this.txtCusCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusCode.Location = new System.Drawing.Point(114, 33);
            this.txtCusCode.Name = "txtCusCode";
            this.txtCusCode.Size = new System.Drawing.Size(126, 21);
            this.txtCusCode.TabIndex = 0;
            this.txtCusCode.Enter += new System.EventHandler(this.txtCusCode_Enter);
            this.txtCusCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCusCode_KeyDown);
            // 
            // rdbWithWarr
            // 
            this.rdbWithWarr.AutoSize = true;
            this.rdbWithWarr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbWithWarr.Location = new System.Drawing.Point(372, 259);
            this.rdbWithWarr.Name = "rdbWithWarr";
            this.rdbWithWarr.Size = new System.Drawing.Size(106, 17);
            this.rdbWithWarr.TabIndex = 14;
            this.rdbWithWarr.TabStop = true;
            this.rdbWithWarr.Text = "With Warranty";
            this.rdbWithWarr.UseVisualStyleBackColor = true;
            // 
            // btnCusSearch
            // 
            this.btnCusSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnCusSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCusSearch.Image")));
            this.btnCusSearch.Location = new System.Drawing.Point(504, 32);
            this.btnCusSearch.Name = "btnCusSearch";
            this.btnCusSearch.Size = new System.Drawing.Size(25, 22);
            this.btnCusSearch.TabIndex = 2;
            this.btnCusSearch.TabStop = false;
            this.btnCusSearch.UseVisualStyleBackColor = true;
            this.btnCusSearch.Click += new System.EventHandler(this.btnCusSearch_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(113, 174);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(387, 35);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemark_KeyDown);
            // 
            // lblremark
            // 
            this.lblremark.AutoSize = true;
            this.lblremark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblremark.Location = new System.Drawing.Point(12, 187);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(57, 13);
            this.lblremark.TabIndex = 140;
            this.lblremark.Text = "Remark:";
            // 
            // lblmobile
            // 
            this.lblmobile.AutoSize = true;
            this.lblmobile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmobile.Location = new System.Drawing.Point(12, 65);
            this.lblmobile.Name = "lblmobile";
            this.lblmobile.Size = new System.Drawing.Size(67, 13);
            this.lblmobile.TabIndex = 128;
            this.lblmobile.Text = "Mobile No:";
            // 
            // txtProdDescription
            // 
            this.txtProdDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdDescription.Location = new System.Drawing.Point(243, 147);
            this.txtProdDescription.Name = "txtProdDescription";
            this.txtProdDescription.Size = new System.Drawing.Size(257, 21);
            this.txtProdDescription.TabIndex = 10;
            this.txtProdDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProdDescription_KeyDown);
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(114, 62);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(198, 21);
            this.txtMobileNo.TabIndex = 4;
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            // 
            // txtProdCode
            // 
            this.txtProdCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdCode.Location = new System.Drawing.Point(113, 147);
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.Size = new System.Drawing.Size(127, 21);
            this.txtProdCode.TabIndex = 9;
            this.txtProdCode.Enter += new System.EventHandler(this.txtProdCode_Enter);
            this.txtProdCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProdCode_KeyDown);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(10, 91);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(98, 13);
            this.lblType.TabIndex = 130;
            this.lblType.Text = "Appliance Type:";
            // 
            // lblproduct
            // 
            this.lblproduct.AutoSize = true;
            this.lblproduct.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproduct.Location = new System.Drawing.Point(12, 155);
            this.lblproduct.Name = "lblproduct";
            this.lblproduct.Size = new System.Drawing.Size(55, 13);
            this.lblproduct.TabIndex = 137;
            this.lblproduct.Text = "Product:";
            // 
            // cmbType
            // 
            this.cmbType.DisplayMember = "Descr";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(114, 88);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(126, 21);
            this.cmbType.TabIndex = 5;
            // 
            // btnProdSearch
            // 
            this.btnProdSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnProdSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnProdSearch.Location = new System.Drawing.Point(501, 146);
            this.btnProdSearch.Name = "btnProdSearch";
            this.btnProdSearch.Size = new System.Drawing.Size(25, 23);
            this.btnProdSearch.TabIndex = 11;
            this.btnProdSearch.UseVisualStyleBackColor = true;
            this.btnProdSearch.Click += new System.EventHandler(this.btnProdSearch_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(14, 125);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(46, 13);
            this.lblBrand.TabIndex = 132;
            this.lblBrand.Text = "Brand:";
            // 
            // btBrandSearch
            // 
            this.btBrandSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btBrandSearch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btBrandSearch.Location = new System.Drawing.Point(501, 117);
            this.btBrandSearch.Name = "btBrandSearch";
            this.btBrandSearch.Size = new System.Drawing.Size(25, 22);
            this.btBrandSearch.TabIndex = 8;
            this.btBrandSearch.UseVisualStyleBackColor = true;
            this.btBrandSearch.Click += new System.EventHandler(this.btBrandSearch_Click);
            // 
            // txtBrandCode
            // 
            this.txtBrandCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandCode.Location = new System.Drawing.Point(114, 118);
            this.txtBrandCode.Name = "txtBrandCode";
            this.txtBrandCode.Size = new System.Drawing.Size(126, 21);
            this.txtBrandCode.TabIndex = 6;
            this.txtBrandCode.Enter += new System.EventHandler(this.txtBrandCode_Enter);
            this.txtBrandCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandCode_KeyDown);
            // 
            // txtBrandDescription
            // 
            this.txtBrandDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandDescription.Location = new System.Drawing.Point(243, 118);
            this.txtBrandDescription.Name = "txtBrandDescription";
            this.txtBrandDescription.Size = new System.Drawing.Size(257, 21);
            this.txtBrandDescription.TabIndex = 7;
            this.txtBrandDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandDescription_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(3, 340);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(605, 75);
            this.toolStrip1.TabIndex = 152;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDocSearch
            // 
            this.btnDocSearch.ForeColor = System.Drawing.Color.DimGray;
            this.btnDocSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnDocSearch.Image")));
            this.btnDocSearch.Location = new System.Drawing.Point(568, 7);
            this.btnDocSearch.Name = "btnDocSearch";
            this.btnDocSearch.Size = new System.Drawing.Size(25, 22);
            this.btnDocSearch.TabIndex = 146;
            this.btnDocSearch.TabStop = false;
            this.btnDocSearch.UseVisualStyleBackColor = true;
            this.btnDocSearch.Click += new System.EventHandler(this.btnDocSearch_Click);
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocNo.Location = new System.Drawing.Point(343, 12);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(89, 13);
            this.lblDocNo.TabIndex = 145;
            this.lblDocNo.Text = "Document No:";
            // 
            // txtDoc
            // 
            this.txtDoc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc.Location = new System.Drawing.Point(438, 7);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.ReadOnly = true;
            this.txtDoc.Size = new System.Drawing.Size(126, 21);
            this.txtDoc.TabIndex = 144;
            this.txtDoc.Enter += new System.EventHandler(this.txtDoc_Enter);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(195, 5);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(126, 21);
            this.dtDate.TabIndex = 122;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(150, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 13);
            this.lblDate.TabIndex = 127;
            this.lblDate.Text = "Date:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 434);
            this.tabControl1.TabIndex = 147;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Job Registration";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnFClear);
            this.tabPage2.Controls.Add(this.btnFExit);
            this.tabPage2.Controls.Add(this.btnFApply);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.txtfinishby);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnProductSrch);
            this.tabPage2.Controls.Add(this.txtQty);
            this.tabPage2.Controls.Add(this.txtSellingPrice);
            this.tabPage2.Controls.Add(this.txtfprodName);
            this.tabPage2.Controls.Add(this.txtFprodCode);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.dtgadditem);
            this.tabPage2.Controls.Add(this.txtserviceCharge);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtfinishremark);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.CmbJobStatue);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txthandby);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dthandOver);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dtfinishdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Job Finish";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnFClear
            // 
            this.btnFClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFClear.FlatAppearance.BorderSize = 0;
            this.btnFClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFClear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFClear.Location = new System.Drawing.Point(351, 351);
            this.btnFClear.Name = "btnFClear";
            this.btnFClear.Size = new System.Drawing.Size(98, 42);
            this.btnFClear.TabIndex = 13;
            this.btnFClear.Text = "Clear";
            this.btnFClear.UseVisualStyleBackColor = false;
            this.btnFClear.Click += new System.EventHandler(this.btnFClear_Click);
            // 
            // btnFExit
            // 
            this.btnFExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFExit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFExit.FlatAppearance.BorderSize = 0;
            this.btnFExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFExit.Location = new System.Drawing.Point(475, 351);
            this.btnFExit.Name = "btnFExit";
            this.btnFExit.Size = new System.Drawing.Size(98, 42);
            this.btnFExit.TabIndex = 14;
            this.btnFExit.Text = "Exit";
            this.btnFExit.UseVisualStyleBackColor = false;
            this.btnFExit.Click += new System.EventHandler(this.btnFExit_Click);
            // 
            // btnFApply
            // 
            this.btnFApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFApply.FlatAppearance.BorderSize = 0;
            this.btnFApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFApply.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFApply.Location = new System.Drawing.Point(227, 351);
            this.btnFApply.Name = "btnFApply";
            this.btnFApply.Size = new System.Drawing.Size(98, 42);
            this.btnFApply.TabIndex = 12;
            this.btnFApply.Text = "Apply";
            this.btnFApply.UseVisualStyleBackColor = false;
            this.btnFApply.Click += new System.EventHandler(this.btnFApply_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Location = new System.Drawing.Point(3, 336);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(591, 69);
            this.toolStrip2.TabIndex = 153;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // txtfinishby
            // 
            this.txtfinishby.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinishby.Location = new System.Drawing.Point(452, 41);
            this.txtfinishby.Name = "txtfinishby";
            this.txtfinishby.Size = new System.Drawing.Size(137, 21);
            this.txtfinishby.TabIndex = 3;
            this.txtfinishby.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfinishby_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(348, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Finished By:";
            // 
            // btnProductSrch
            // 
            this.btnProductSrch.ForeColor = System.Drawing.Color.DimGray;
            this.btnProductSrch.Image = global::Inventory.Properties.Resources.Finder_Toolbar_Search;
            this.btnProductSrch.Location = new System.Drawing.Point(331, 151);
            this.btnProductSrch.Name = "btnProductSrch";
            this.btnProductSrch.Size = new System.Drawing.Size(25, 23);
            this.btnProductSrch.TabIndex = 9;
            this.btnProductSrch.UseVisualStyleBackColor = true;
            this.btnProductSrch.Click += new System.EventHandler(this.btnProductSrch_Click);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(461, 151);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(97, 21);
            this.txtQty.TabIndex = 11;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingPrice.Location = new System.Drawing.Point(360, 152);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(97, 21);
            this.txtSellingPrice.TabIndex = 10;
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            this.txtSellingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingPrice_KeyPress);
            // 
            // txtfprodName
            // 
            this.txtfprodName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfprodName.Location = new System.Drawing.Point(136, 152);
            this.txtfprodName.Name = "txtfprodName";
            this.txtfprodName.Size = new System.Drawing.Size(193, 21);
            this.txtfprodName.TabIndex = 8;
            this.txtfprodName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfprodName_KeyDown);
            // 
            // txtFprodCode
            // 
            this.txtFprodCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFprodCode.Location = new System.Drawing.Point(56, 152);
            this.txtFprodCode.Name = "txtFprodCode";
            this.txtFprodCode.Size = new System.Drawing.Size(79, 21);
            this.txtFprodCode.TabIndex = 7;
            this.txtFprodCode.Enter += new System.EventHandler(this.txtFprodCode_Enter);
            this.txtFprodCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFprodCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Additional Item:";
            // 
            // dtgadditem
            // 
            this.dtgadditem.AllowUserToAddRows = false;
            this.dtgadditem.AllowUserToDeleteRows = false;
            this.dtgadditem.AutoGenerateColumns = false;
            this.dtgadditem.BackgroundColor = System.Drawing.Color.White;
            this.dtgadditem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgadditem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prod_Code,
            this.Prod_Name,
            this.Selling_Price,
            this.qtyDataGridViewTextBoxColumn});
            this.dtgadditem.DataSource = this.productBindingSource;
            this.dtgadditem.Location = new System.Drawing.Point(54, 176);
            this.dtgadditem.Name = "dtgadditem";
            this.dtgadditem.ReadOnly = true;
            this.dtgadditem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgadditem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgadditem.Size = new System.Drawing.Size(506, 157);
            this.dtgadditem.TabIndex = 12;
            this.dtgadditem.DoubleClick += new System.EventHandler(this.dtgadditem_DoubleClick);
            this.dtgadditem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgadditem_KeyDown);
            // 
            // Prod_Code
            // 
            this.Prod_Code.DataPropertyName = "Prod_Code";
            this.Prod_Code.HeaderText = "Prod Code";
            this.Prod_Code.Name = "Prod_Code";
            this.Prod_Code.ReadOnly = true;
            this.Prod_Code.Width = 80;
            // 
            // Prod_Name
            // 
            this.Prod_Name.DataPropertyName = "Prod_Name";
            this.Prod_Name.HeaderText = "Prod_Name";
            this.Prod_Name.Name = "Prod_Name";
            this.Prod_Name.ReadOnly = true;
            this.Prod_Name.Width = 180;
            // 
            // Selling_Price
            // 
            this.Selling_Price.DataPropertyName = "Selling_Price";
            this.Selling_Price.HeaderText = "Selling Price";
            this.Selling_Price.Name = "Selling_Price";
            this.Selling_Price.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.dsForReports;
            // 
            // dsForReports
            // 
            this.dsForReports.DataSetName = "dsForReports";
            this.dsForReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtserviceCharge
            // 
            this.txtserviceCharge.Location = new System.Drawing.Point(452, 99);
            this.txtserviceCharge.Name = "txtserviceCharge";
            this.txtserviceCharge.Size = new System.Drawing.Size(137, 20);
            this.txtserviceCharge.TabIndex = 6;
            this.txtserviceCharge.Text = "0.00";
            this.txtserviceCharge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtserviceCharge_KeyDown);
            this.txtserviceCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtserviceCharge_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(348, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Service Charge:";
            // 
            // txtfinishremark
            // 
            this.txtfinishremark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinishremark.Location = new System.Drawing.Point(106, 71);
            this.txtfinishremark.Multiline = true;
            this.txtfinishremark.Name = "txtfinishremark";
            this.txtfinishremark.Size = new System.Drawing.Size(211, 58);
            this.txtfinishremark.TabIndex = 4;
            this.txtfinishremark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfinishremark_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Remarks:";
            // 
            // CmbJobStatue
            // 
            this.CmbJobStatue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbJobStatue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbJobStatue.FormattingEnabled = true;
            this.CmbJobStatue.Location = new System.Drawing.Point(452, 71);
            this.CmbJobStatue.Name = "CmbJobStatue";
            this.CmbJobStatue.Size = new System.Drawing.Size(137, 21);
            this.CmbJobStatue.TabIndex = 5;
            this.CmbJobStatue.SelectedIndexChanged += new System.EventHandler(this.CmbJobStatue_SelectedIndexChanged);
            this.CmbJobStatue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbJobStatue_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(348, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Job Status:";
            // 
            // txthandby
            // 
            this.txthandby.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthandby.Location = new System.Drawing.Point(106, 41);
            this.txthandby.Name = "txthandby";
            this.txthandby.Size = new System.Drawing.Size(208, 21);
            this.txthandby.TabIndex = 2;
            this.txthandby.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthandby_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "HandOver By:";
            // 
            // dthandOver
            // 
            this.dthandOver.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dthandOver.Location = new System.Drawing.Point(106, 14);
            this.dthandOver.Name = "dthandOver";
            this.dthandOver.Size = new System.Drawing.Size(108, 20);
            this.dthandOver.TabIndex = 0;
            this.dthandOver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dthandOver_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "HandOver Date:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Finished Date:";
            // 
            // dtfinishdate
            // 
            this.dtfinishdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfinishdate.Location = new System.Drawing.Point(468, 14);
            this.dtfinishdate.Name = "dtfinishdate";
            this.dtfinishdate.Size = new System.Drawing.Size(121, 20);
            this.dtfinishdate.TabIndex = 1;
            this.dtfinishdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtfinishdate_KeyDown);
            // 
            // frmJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(605, 478);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDocSearch);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.lblDocNo);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmJob";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Apply";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmJob_FormClosed);
            this.Load += new System.EventHandler(this.frmJob_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgadditem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCusDescription;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.RadioButton rdbWOWarr;
        public System.Windows.Forms.TextBox txtCusCode;
        private System.Windows.Forms.RadioButton rdbWithWarr;
        private System.Windows.Forms.Button btnCusSearch;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblremark;
        private System.Windows.Forms.Label lblmobile;
        private System.Windows.Forms.TextBox txtProdDescription;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtProdCode;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblproduct;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnProdSearch;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btBrandSearch;
        private System.Windows.Forms.TextBox txtBrandCode;
        private System.Windows.Forms.TextBox txtBrandDescription;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDocSearch;
        private System.Windows.Forms.Label lblDocNo;
        public System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblreference;
        private System.Windows.Forms.Button btnNewCust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtfinishdate;
        private System.Windows.Forms.TextBox txthandby;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dthandOver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtfinishremark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbJobStatue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgadditem;
        private System.Windows.Forms.TextBox txtserviceCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.TextBox txtfprodName;
        private System.Windows.Forms.TextBox txtFprodCode;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsForReports dsForReports;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnProductSrch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prod_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prod_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Selling_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtfinishby;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFClear;
        private System.Windows.Forms.Button btnFExit;
        private System.Windows.Forms.Button btnFApply;
        private System.Windows.Forms.ToolStrip toolStrip2;
    }
}