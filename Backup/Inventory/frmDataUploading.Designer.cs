namespace Inventory
{
    partial class frmDataUploading
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLocaSearch = new System.Windows.Forms.Button();
            this.txtLocaName = new System.Windows.Forms.TextBox();
            this.txtLocaCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkDepartment = new System.Windows.Forms.CheckBox();
            this.chkCategorys = new System.Windows.Forms.CheckBox();
            this.chkSuppliers = new System.Windows.Forms.CheckBox();
            this.chkBrands = new System.Windows.Forms.CheckBox();
            this.chkProducts = new System.Windows.Forms.CheckBox();
            this.opProductDate = new System.Windows.Forms.RadioButton();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.opProductAll = new System.Windows.Forms.RadioButton();
            this.dtDates = new System.Windows.Forms.DateTimePicker();
            this.chkCustomers = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(22, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Data Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(259, 226);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 44);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLocaSearch
            // 
            this.btnLocaSearch.Location = new System.Drawing.Point(400, 22);
            this.btnLocaSearch.Name = "btnLocaSearch";
            this.btnLocaSearch.Size = new System.Drawing.Size(36, 19);
            this.btnLocaSearch.TabIndex = 3;
            this.btnLocaSearch.Text = "....";
            this.btnLocaSearch.UseVisualStyleBackColor = true;
            this.btnLocaSearch.Click += new System.EventHandler(this.btnLocaSearch_Click);
            // 
            // txtLocaName
            // 
            this.txtLocaName.Location = new System.Drawing.Point(168, 22);
            this.txtLocaName.Name = "txtLocaName";
            this.txtLocaName.Size = new System.Drawing.Size(229, 20);
            this.txtLocaName.TabIndex = 2;
            // 
            // txtLocaCode
            // 
            this.txtLocaCode.Location = new System.Drawing.Point(99, 22);
            this.txtLocaCode.Name = "txtLocaCode";
            this.txtLocaCode.Size = new System.Drawing.Size(63, 20);
            this.txtLocaCode.TabIndex = 1;
            this.txtLocaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocaCode_KeyDown);
            this.txtLocaCode.Enter += new System.EventHandler(this.txtLocaCode_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Location To";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnLocaSearch);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtLocaCode);
            this.groupBox1.Controls.Add(this.txtLocaName);
            this.groupBox1.Location = new System.Drawing.Point(5, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkCustomers);
            this.groupBox2.Controls.Add(this.grpProduct);
            this.groupBox2.Controls.Add(this.chkBrands);
            this.groupBox2.Controls.Add(this.chkSuppliers);
            this.groupBox2.Controls.Add(this.chkCategorys);
            this.groupBox2.Controls.Add(this.chkDepartment);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Location = new System.Drawing.Point(22, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 163);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uploding Range     ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(97, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkDepartment
            // 
            this.chkDepartment.AutoSize = true;
            this.chkDepartment.Location = new System.Drawing.Point(31, 36);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(86, 17);
            this.chkDepartment.TabIndex = 1;
            this.chkDepartment.Text = "Departments";
            this.chkDepartment.UseVisualStyleBackColor = true;
            // 
            // chkCategorys
            // 
            this.chkCategorys.AutoSize = true;
            this.chkCategorys.Location = new System.Drawing.Point(176, 36);
            this.chkCategorys.Name = "chkCategorys";
            this.chkCategorys.Size = new System.Drawing.Size(73, 17);
            this.chkCategorys.TabIndex = 2;
            this.chkCategorys.Text = "Categorys";
            this.chkCategorys.UseVisualStyleBackColor = true;
            // 
            // chkSuppliers
            // 
            this.chkSuppliers.AutoSize = true;
            this.chkSuppliers.Location = new System.Drawing.Point(31, 64);
            this.chkSuppliers.Name = "chkSuppliers";
            this.chkSuppliers.Size = new System.Drawing.Size(69, 17);
            this.chkSuppliers.TabIndex = 4;
            this.chkSuppliers.Text = "Suppliers";
            this.chkSuppliers.UseVisualStyleBackColor = true;
            // 
            // chkBrands
            // 
            this.chkBrands.AutoSize = true;
            this.chkBrands.Location = new System.Drawing.Point(335, 36);
            this.chkBrands.Name = "chkBrands";
            this.chkBrands.Size = new System.Drawing.Size(59, 17);
            this.chkBrands.TabIndex = 3;
            this.chkBrands.Text = "Brands";
            this.chkBrands.UseVisualStyleBackColor = true;
            // 
            // chkProducts
            // 
            this.chkProducts.AutoSize = true;
            this.chkProducts.Location = new System.Drawing.Point(11, -1);
            this.chkProducts.Name = "chkProducts";
            this.chkProducts.Size = new System.Drawing.Size(68, 17);
            this.chkProducts.TabIndex = 0;
            this.chkProducts.Text = "Products";
            this.chkProducts.UseVisualStyleBackColor = true;
            this.chkProducts.CheckedChanged += new System.EventHandler(this.chkProducts_CheckedChanged);
            // 
            // opProductDate
            // 
            this.opProductDate.AutoSize = true;
            this.opProductDate.Enabled = false;
            this.opProductDate.Location = new System.Drawing.Point(79, 25);
            this.opProductDate.Name = "opProductDate";
            this.opProductDate.Size = new System.Drawing.Size(213, 17);
            this.opProductDate.TabIndex = 2;
            this.opProductDate.Text = "Create or modified date greater than this";
            this.opProductDate.UseVisualStyleBackColor = true;
            this.opProductDate.CheckedChanged += new System.EventHandler(this.opProductDate_CheckedChanged);
            // 
            // grpProduct
            // 
            this.grpProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProduct.Controls.Add(this.dtDates);
            this.grpProduct.Controls.Add(this.opProductAll);
            this.grpProduct.Controls.Add(this.chkProducts);
            this.grpProduct.Controls.Add(this.opProductDate);
            this.grpProduct.Location = new System.Drawing.Point(9, 99);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(399, 55);
            this.grpProduct.TabIndex = 6;
            this.grpProduct.TabStop = false;
            this.grpProduct.Text = "      ";
            // 
            // opProductAll
            // 
            this.opProductAll.AutoSize = true;
            this.opProductAll.Checked = true;
            this.opProductAll.Enabled = false;
            this.opProductAll.Location = new System.Drawing.Point(22, 25);
            this.opProductAll.Name = "opProductAll";
            this.opProductAll.Size = new System.Drawing.Size(36, 17);
            this.opProductAll.TabIndex = 1;
            this.opProductAll.TabStop = true;
            this.opProductAll.Text = "All";
            this.opProductAll.UseVisualStyleBackColor = true;
            // 
            // dtDates
            // 
            this.dtDates.Enabled = false;
            this.dtDates.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDates.Location = new System.Drawing.Point(297, 24);
            this.dtDates.Name = "dtDates";
            this.dtDates.Size = new System.Drawing.Size(91, 20);
            this.dtDates.TabIndex = 3;
            // 
            // chkCustomers
            // 
            this.chkCustomers.AutoSize = true;
            this.chkCustomers.Location = new System.Drawing.Point(176, 64);
            this.chkCustomers.Name = "chkCustomers";
            this.chkCustomers.Size = new System.Drawing.Size(70, 17);
            this.chkCustomers.TabIndex = 5;
            this.chkCustomers.Text = "Customer";
            this.chkCustomers.UseVisualStyleBackColor = true;
            // 
            // frmDataUploading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(468, 287);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataUploading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Uploading";
            this.Load += new System.EventHandler(this.frmDataUploading_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDataUploading_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLocaSearch;
        private System.Windows.Forms.TextBox txtLocaName;
        private System.Windows.Forms.TextBox txtLocaCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkCategorys;
        private System.Windows.Forms.CheckBox chkDepartment;
        private System.Windows.Forms.CheckBox chkBrands;
        private System.Windows.Forms.CheckBox chkSuppliers;
        private System.Windows.Forms.RadioButton opProductDate;
        private System.Windows.Forms.CheckBox chkProducts;
        private System.Windows.Forms.GroupBox grpProduct;
        private System.Windows.Forms.RadioButton opProductAll;
        private System.Windows.Forms.DateTimePicker dtDates;
        private System.Windows.Forms.CheckBox chkCustomers;
    }
}