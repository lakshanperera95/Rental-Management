using clsLibrary;
using Inventory.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmJob : Form
    {
        public frmJob()
        {
            InitializeComponent();
        } 


        clsJob ObjJob = new clsJob();
        frmSearch search = new frmSearch();
        private frmProductSearch ProductSearch = new frmProductSearch();
        clsProduct prod = new clsProduct();
  
        public static frmJob GetJob { get; set; }
       
        private void frmJob_Load(object sender, EventArgs e)
        {
            try
            {
              

                ObjJob.SqlStatement = "SELECT Descr FROM tb_FormSettings WHERE FType = 'JOB' ORDER BY id DESC";
                ObjJob.DatasetName = "ds";
                //ObjJob.GetData();
                cmbType.DataSource = ObjJob.GetData().Tables[0];
                //cmbType.DataSource = ObjJob.GetTemDataset.Tables[0];

                cmbType.DisplayMember = "Descr";

                cmbType.Text = string.Empty;
                cmbType.SelectedIndex = -1;

                CmbJobStatue.Items.Add("Error Fixed");
                CmbJobStatue.Items.Add("Not Fixed");

                rdbWOWarr.Checked = true;

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
               

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }

        }

        private void btnCusSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                bool MultiCus = Settings.Default.MultiCus;
                string Loca = "";
                if (MultiCus == true)
                {
                    Loca = " and CLoca ='" + LoginManager.LocaCode + "' ";
                }

                if (txtCusCode.Text.Trim() != string.Empty && txtCusDescription.Text.Trim() == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile " +
                        "FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE (Cust_Code LIKE '%" + txtCusCode.Text.Trim() + "%' OR Mobile LIKE '%" + txtCusCode.Text.Trim() + "%'  ) " +
                        "AND dbo.CRM_Customer.Inactive=0  " + Loca + "   ORDER BY Cust_Code";
                }
                else
                {
                    if (txtCusCode.Text.Trim() == string.Empty && txtCusDescription.Text.Trim() != string.Empty)
                    {
                        ObjJob.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code " +
                            "WHERE  (Cust_Name LIKE '%" + txtCusDescription.Text.Trim() + "%'  Or Mobile LIKE '%" + txtCusDescription.Text.Trim() + "%' ) " +
                            "AND dbo.CRM_Customer.Inactive=0 " + Loca + "  ORDER BY Cust_Name";

                    }
                    else
                    {
                        ObjJob.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer  JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code " +
                            "WHERE  dbo.CRM_Customer.Inactive=0 " + Loca + " ORDER BY Cust_Code";
                    }
                }

                ObjJob.DatasetName = "dsCustomer";
                ObjJob.GetCustomer();
                search.dgSearch.DataSource = ObjJob.GetCustomerDataSet.Tables["dsCustomer"];
                search.prop_Focus = txtCusCode;
                search.Cont_Descript = txtCusDescription;
                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y + 100);


            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCusCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    txtCusDescription.Text = txtCusCode.Text = string.Empty;
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;

                    search.Focus();

                }
                if (search.dgSearch.Rows.Count > 0 && search.Visible)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        search.selectRow();

                    }
                    int select = search.dgSearch.SelectedRows[0].Index;
                    if (e.KeyCode == Keys.Down && search.dgSearch.SelectedRows[0].Index != search.dgSearch.Rows.Count - 1)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select + 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select + 1].Cells[0];

                    }
                    if (e.KeyCode == Keys.Up && search.dgSearch.SelectedRows[0].Index != 0)
                    {
                        search.dgSearch.SelectedRows[0].Selected = false;
                        search.dgSearch.Rows[select - 1].Selected = true;
                        search.dgSearch.CurrentCell = search.dgSearch.Rows[select - 1].Cells[0];

                    }
                }
                if (e.KeyCode == Keys.Enter && txtCusCode.Text != string.Empty)
                {
                    ObjJob.CustCode = txtCusCode.Text;
                    ObjJob.SqlStatement = "SELECT Cust_Code, Cust_Name,Tel FROM dbo.CRM_Customer CRM JOIN dbo.Customer C ON Cust_Code=Cus_Code WHERE(Mobile = '" + txtCusCode.Text.Trim() + "' OR Cus_Code = '" + txtCusCode.Text.Trim() + "') AND C.Inactive = 0";
                    ObjJob.ReadCustomerDetails();
                    if (ObjJob.RecordFound == true)
                    {
                        txtCusCode.Text = ObjJob.CustCode;
                        txtCusDescription.Text = ObjJob.CustName;
                        txtMobileNo.Text = ObjJob.Mobile;
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCusCode.Focus();
                        txtCusCode.SelectAll();
                    }
                }
               
                if(e.KeyCode== Keys.Enter)
                {
                    txtCusDescription.Focus();
                }
                        
                    

                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnNewCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAccounts.GetAccount != null)
                {
                    frmAccounts.GetAccount.Close();
                }

                frmAccounts.GetAccount = new frmAccounts();
                frmAccounts.GetAccount.CustCode = txtCusCode.Text;               
                frmAccounts.GetAccount.frmOpenFrom = "Customer";
                frmAccounts.GetAccount.ShowDialog();

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCusCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCusCode.Text = search.Code.Trim();
                    txtCusDescription.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtCusCode.Text = string.Empty;
                txtCusDescription.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                cmbType.SelectedIndex = -1;
                txtBrandCode.Text = string.Empty;
                txtBrandDescription.Text = string.Empty;
                txtProdCode.Text = string.Empty;
                txtProdDescription.Text = string.Empty;
                txtRemark.Text = string.Empty;
                txtReference.Text = string.Empty;
                

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCusDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCusDescription.Text != string.Empty)
                {
                    ObjJob.CustName = txtCusDescription.Text;
                    ObjJob.SqlStatement = "SELECT Cust_Code, Cust_Name, Tel FROM dbo.CRM_Customer CRM JOIN dbo.Customer C ON Cust_Code = Cus_Code WHERE(C.Cust_Name like '%" + txtCusDescription.Text + "%') AND C.Inactive = 0";
                    ObjJob.ReadCustomerDetails();
                    if (ObjJob.RecordFound == true)
                    {
                        txtCusCode.Text = ObjJob.CustCode;
                        txtCusDescription.Text = ObjJob.CustName;
                        txtMobileNo.Text = ObjJob.Mobile;
                    }
                    txtMobileNo.Focus();
                }
                if(e.KeyCode == Keys.Enter)
                {
                    txtMobileNo.Focus();
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btBrandSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (string.IsNullOrEmpty(txtBrandCode.Text) && string.IsNullOrEmpty(txtBrandDescription.Text))
                {
                    ObjJob.SqlStatement = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand Order by Brand_Code";
                }
                else if (!string.IsNullOrEmpty(txtBrandCode.Text) && string.IsNullOrEmpty(txtBrandDescription.Text))
                {
                    ObjJob.SqlStatement = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand WHERE Brand_Code LIKE '%" + txtBrandCode.Text.Trim() + "%' Order by Brand_Code";
                }
                else if (string.IsNullOrEmpty(txtBrandCode.Text) && !string.IsNullOrEmpty(txtBrandDescription.Text))
                {
                    ObjJob.SqlStatement = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand WHERE Brand_Name LIKE '%" + txtBrandDescription.Text.Trim() + "%' Order by Brand_Code";
                }
                else
                {
                    ObjJob.SqlStatement = "SELECT Brand_Code [Brand Code], Brand_Name [Brand Name] FROM Brand Order by Brand_Code";
                }
                ObjJob.RetrieveBrand();
                search.dgSearch.DataSource = ObjJob.GetDataset1.Tables["dsBrand"];
                search.prop_Focus = txtBrandCode;
                search.Cont_Descript = txtBrandDescription;
                search.Show();

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtBrandCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if(e.KeyCode == Keys.Enter && txtBrandCode.Text.Trim() != string.Empty)
                    {
                        txtBrandCode.Text = txtBrandCode.Text.ToUpper();
                        ObjJob.SqlStatement = "SELECT Brand_Code, Brand_Name FROM Brand WHERE  Brand_Code ='"+txtBrandCode.Text.Trim()+"' ";
                        ObjJob.BrandRead();
                        if (ObjJob.RecordFound == true)
                        {
                            txtBrandCode.Text = ObjJob.BrandCode;
                            txtBrandDescription.Text = ObjJob.BrandName;
                        }
                        else
                        {
                            MessageBox.Show("Brand Code Not Found", "Brand", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtBrandCode.Focus();
                        }
                    }
                   
                    txtBrandDescription.Focus();
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtBrandCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != string.Empty)
                {
                    txtBrandCode.Text = search.Code.Trim();
                    txtBrandDescription.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtBrandDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtProdCode.Focus();
            }
        }

        private void btnProdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();

                } 
                if(txtProdCode.Text != string.Empty && txtProdDescription.Text == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS[Product Code], P.Prod_Name AS[Product Name] FROM Product P WHERE  P.Prod_Code LIKE '%" + txtProdCode.Text.Trim() + "%' order by P.Prod_Code";
                }
                 else if(txtProdDescription.Text != string.Empty && txtProdCode.Text == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name] FROM Product P  WHERE  P.Prod_Name LIKE '%" + txtProdDescription.Text.Trim() + "%' order by P.Prod_Code ";
                }
                else if(txtProdCode.Text == string.Empty && txtProdDescription.Text == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name] FROM Product P order by P.Prod_Code ";
                }
                else
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name] FROM Product P  order by P.Prod_Code";
                }

                ObjJob.DatasetName = "dsProduct";
                ObjJob.GetData();
                search.dgSearch.DataSource = ObjJob.GetTemDataset.Tables["dsProduct"];
                search.prop_Focus = txtProdCode;
                search.Cont_Descript = txtProdDescription;
                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y + 100);

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtProdCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != string.Empty)
                {
                    txtProdCode.Text = search.Code.Trim();
                    txtProdDescription.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtProdCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {

                    if (e.KeyCode == Keys.Enter && txtProdCode.Text != string.Empty)
                    {
                        if (txtProdCode.Text != string.Empty)
                        {
                            ObjJob.SqlStatement = "SELECT P.Prod_Code[Product Code], P.Prod_Name[Product Name] FROM Product P  WHERE  P.Prod_Code='" + txtProdCode.Text.Trim() + "'";
                            ObjJob.ProdRead();
                            txtProdCode.Text = ObjJob.ProdCode;
                            txtProdDescription.Text = ObjJob.ProdName;
                        }
                        else
                        {
                            MessageBox.Show("Product Code Not Found", "Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtProdCode.Focus();
                        }                        

                    }
                    txtProdDescription.Focus();
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex); 
            }
        }

        private void txtProdDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtRemark.Focus();
            }
        }

        private void frmJob_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetJob = null;
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cmbType.Focus();
            }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtReference.Focus();
            }
        }

        private void txtReference_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnApply.Focus();
                btnApply.PerformClick();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsDataForReport = new DataSet();
                frmReportViewer objRepViewer = new frmReportViewer();

                if (txtCusCode.Text.ToString() == string.Empty || txtCusDescription.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Customer Code Not Found!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusCode.Focus();
                    return;
                }
                ObjJob.SqlStatement = "SELECT Cust_Code FROM Customer  WHERE Cust_Code = '"+txtCusCode.Text.Trim()+"'";
                ObjJob.GetDataReader();
                if (ObjJob.RecordFound == false)
                {
                    MessageBox.Show("Invalid Customer Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusCode.Focus();
                    return;
                } 
                if (txtMobileNo.Text == string.Empty)
                {
                    MessageBox.Show("Mobile Number Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMobileNo.Focus();
                    return;
                }

                if (clsValidation.isNumeric(txtMobileNo.Text) == false )
                {
                    MessageBox.Show("Mobile Number Not Valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMobileNo.Focus();
                    return;
                }
             
                if(cmbType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select the Appliance Type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbType.Focus();
                    return;
                }
                if(txtBrandCode.Text == string.Empty || txtBrandDescription.Text == string.Empty)
                {
                    MessageBox.Show("Brand Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrandCode.Focus();
                    return;
                }
                ObjJob.SqlStatement = "SELECT Brand_Code[Brand Code], Brand_Name[Brand Name] FROM Brand WHERE Brand_Code = '"+txtBrandCode.Text.Trim()+"'";
                ObjJob.GetDataReader();
                if(ObjJob.RecordFound == false)
                {
                    MessageBox.Show("Brand Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrandCode.Focus();
                    return;
                }
                if ( txtProdDescription.Text == string.Empty)
                {
                    MessageBox.Show("Product Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProdCode.Focus();
                    return;
                }
                if(txtRemark.Text == string.Empty)
                {
                    MessageBox.Show("Remark Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemark.Focus();
                    return;
                }
                if (txtReference.Text == string.Empty)
                {
                    MessageBox.Show("Reference Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReference.Focus();
                    return;
                }
                if (MessageBox.Show("Do you Want to Apply This Job Registration?", "Job Registration",MessageBoxButtons.YesNo,MessageBoxIcon.Question )== DialogResult.Yes)
                {
                    ObjJob.TempDocumentNo = txtDoc.Text.Trim();
                    ObjJob.CustCode = txtCusCode.Text.Trim();
                    ObjJob.Mobile= txtMobileNo.Text.Trim() ;
                    ObjJob.AppType = cmbType.Text.Trim();
                    ObjJob.BrandCode = txtBrandCode.Text.Trim();
                    ObjJob.ProdCode = txtProdCode.Text.Trim().ToString();
                    ObjJob.ProdName = txtProdDescription.Text.Trim().ToString();
                    ObjJob.Remark = txtRemark.Text.Trim();
                    ObjJob.Reference = txtReference.Text.Trim();
                    ObjJob.Date = dtDate.Text.Trim();

                    //if (rdbWOWarr.Checked == true)
                    //{
                    //    ObjJob.WarrntyAllow = false;
                    //}
                    //else
                    //{
                    //    ObjJob.WarrntyAllow = true;
                    //}
                       // ObjJob.Date = (rdbWOWarr.Checked==true) ? "T" :"F";
                    ObjJob.WarrntyAllow= (rdbWOWarr.Checked == true) ? false :true;
                    ObjJob.JobApply();
                    MessageBox.Show("Job Registration Succesful", "Job Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                    dsDataForReport = ObjJob.GetDataset;
                    objRepViewer.DirectPrintVerRep = new rptJobRegistrationRpt();
                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    objRepViewer.Show();
                    btnClear_Click(sender, e);
                    
                }
                else
                {
                    return;
                }
                


            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void btnDocSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                ObjJob.SqlStatement = "select  DocNo[Document No],Create_Date[Doc Date],C.Cust_Name[CusName] from Job_Header TH INNER JOIN Customer C ON C.Cust_Code = TH.CustCode WHERE Status = 'RECIEVED' AND Loca = '"+LoginManager.LocaCode+"'";
                ObjJob.DatasetName = "Table";
                ObjJob.GetData();               
                search.dgSearch.DataSource = ObjJob.GetTemDataset.Tables["Table"];                
                search.prop_Focus = txtDoc;            
                search.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtDoc_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDoc_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    if(txtDoc.Text.Trim() != string.Empty)
                    {
                       if(MessageBox.Show("Are you Sure you want to Load this Recieved Job","Job Registration",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            ObjJob.TempDocumentNo = search.Code.Trim();
                            ObjJob.SqlStatement = "SELECT CustCode,C.Cust_Name,Cont_No,ApplyType,BrandCode,b.Brand_Name,ProdCode,ProdName,Remark,Reference,WarrantyAllow FROM Job_Header TH INNER JOIN Customer C ON C.Cust_Code = TH.CustCode INNER JOIN Brand b ON B.Brand_Code = TH.BrandCode WHERE DocNo = '"+txtDoc.Text.Trim()+"' AND Status = 'RECIEVED'";
                            ObjJob.ReadJobDoc();
                            if(ObjJob.RecordFound == true)
                            {
                                txtCusCode.Text = ObjJob.CustCode.ToString();
                                txtCusDescription.Text = ObjJob.CustName.ToString();
                                cmbType.Text = ObjJob.AppType.ToString();
                                txtMobileNo.Text = ObjJob.Mobile.ToString();
                                txtBrandCode.Text = ObjJob.BrandCode.ToString();
                                txtBrandDescription.Text = ObjJob.BrandName.ToString();
                                txtProdCode.Text = ObjJob.ProdCode.ToString();
                                txtProdDescription.Text = ObjJob.ProdName.ToString();
                                txtRemark.Text = ObjJob.Remark.ToString();
                                txtReference.Text = ObjJob.Reference.ToString();
                                if(ObjJob.WarrntyAllow == true)
                                {
                                    rdbWithWarr.Checked = true;
                                }
                                if(ObjJob.WarrntyAllow == false)
                                {
                                    rdbWOWarr.Checked = true;
                                }
                                txtDoc.Enabled = false;
                                btnDocSearch.Enabled = false;
                                tabControl1.SelectedIndex = 1;
                                dtDate.Enabled = false;
                                btnApply.Enabled = false;
                                btnClear.Enabled = false;
                                btnExit.Enabled = false;
                            }
                        }
                    }
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                }

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFClear_Click(object sender, EventArgs e)
        {
            try
            {
                clsCommon objcommon = new clsCommon();
                string sqlStatement = @"DELETE FROM TransactionTemp_Details WHERE Doc_No ='" + ObjJob.TempDocumentNo + "'  And Loca='"+LoginManager.LocaCode+ "'; SELECT * FROM TransactionTemp_Details WHERE  Doc_No ='"+ObjJob.TempDocumentNo+"'";
                objcommon.getDataReader(sqlStatement);
                objcommon.closeConnection();               
                dthandOver.Text = string.Empty;
                dtfinishdate.Text = string.Empty;
                txtfinishby.Text = string.Empty;
                txthandby.Text = string.Empty;
                txtfinishremark.Text = string.Empty;
                CmbJobStatue.SelectedIndex = -1;
                txtserviceCharge.Text = string.Empty;
                txtFprodCode.Text = string.Empty;
                txtfprodName.Text = string.Empty;
                txtSellingPrice.Text = string.Empty;
                txtQty.Text = string.Empty;
                dtgadditem.DataSource = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txthandby_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    txtfinishby.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtfinishby_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    txtfinishremark.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtfinishremark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    CmbJobStatue.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CmbJobStatue_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if(CmbJobStatue.SelectedIndex == 1)
            //    {
            //        txtserviceCharge.Focus();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void btnProductSrch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();

                }
                if (txtFprodCode.Text != string.Empty && txtfprodName.Text == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS[Product Code], P.Prod_Name AS[Product Name] FROM Product P WHERE  P.Prod_Code LIKE '%" + txtFprodCode.Text.Trim() + "%' and lockedItem='F' order by P.Prod_Code";
                }
                else if (txtfprodName.Text != string.Empty && txtFprodCode.Text == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name] FROM Product P  WHERE  P.Prod_Name LIKE '%" + txtfprodName.Text.Trim() + "%' and lockedItem='F' order by P.Prod_Code ";
                }
                else if (txtFprodCode.Text == string.Empty && txtfprodName.Text == string.Empty)
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name] FROM Product P  where lockedItem='F' order by P.Prod_Code ";
                }
                else
                {
                    ObjJob.SqlStatement = "SELECT P.Prod_Code AS [Product Code], P.Prod_Name AS [Product Name] FROM Product P  where lockedItem='F' order by P.Prod_Code";
                }

                ObjJob.DatasetName = "dsProduct";
                ObjJob.GetData();
                search.dgSearch.DataSource = ObjJob.GetTemDataset.Tables["dsProduct"];
                search.prop_Focus = txtFprodCode;
                search.Cont_Descript = txtfprodName;
                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y + 100);

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void btnFExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void txtFprodCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (txtFprodCode.Text != String.Empty && e.KeyCode == Keys.Enter)
                    {
                        ObjJob.SqlStatement = "SELECT DISTINCT  P.Prod_Code,P.Prod_Name,P.Purchase_price,CAST(P.Selling_Price AS DECIMAL(18,2))[Selling_Price]  FROM dbo.Stock_Master SM INNER JOIN Product P on P.Prod_Code = SM.Prod_Code WHERE P.Prod_Code = '" + txtFprodCode.Text.Trim() + "' AND SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F'";
                        ObjJob.ReadProductDetail();
                        if (ObjJob.RecordFound == true)
                        {
                            txtProdCode.Text = ObjJob.ProdCode;
                            txtfprodName.Text = ObjJob.ProdName;
                            txtSellingPrice.Text = (string)ObjJob.SellingPrice.ToString();
                            txtQty.Focus();
                            txtQty.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product Code Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtProdCode.Focus();
                        return;
                    }
                    txtSellingPrice.Focus();
                }
              
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void txtFprodCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != string.Empty)
                {
                    txtFprodCode.Text = search.Code.Trim();
                    txtfprodName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if(e.KeyCode== Keys.Enter && txtQty.Text.Trim()!= string.Empty )
                {                                                         
                    
                    if(txtDoc.Text != string.Empty)
                    {
                        ObjJob.SqlStatement = "select DocNo,Create_Date from Job_Header TH WHERE Status = 'RECIEVED' AND Loca = '" + LoginManager.LocaCode + "'";
                        ObjJob.GetDataReader();
                        if (ObjJob.RecordFound == true)
                        {
                            ObjJob.TempDocumentNo = txtDoc.Text.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Job Number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Job Number Not Found", "Job Finished", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                   
                    ObjJob.SqlStatement = "SELECT DISTINCT SM.UnderCost, P.Prod_Code,P.Prod_Name,P.Purchase_price,CAST(P.Selling_Price AS DECIMAL(18,2))[Selling_Price]  FROM dbo.Stock_Master SM INNER JOIN Product P on P.Prod_Code = SM.Prod_Code WHERE P.Prod_Code = '" + txtFprodCode.Text.Trim()+"' AND SM.Loca = '"+LoginManager.LocaCode+"' AND P.LockedItem = 'F'";
                    ObjJob.ReadProductDetail();
                    if (ObjJob.RecordFound == true)
                    {
                        txtProdCode.Text = ObjJob.ProdCode;
                        txtfprodName.Text = ObjJob.ProdName;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (txtSellingPrice.Text == string.Empty || clsValidation.isNumeric(txtSellingPrice.Text) == false || Convert.ToDecimal(txtSellingPrice.Text) <= 0)
                    {
                        MessageBox.Show("Selling Price Not Valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSellingPrice.Focus();
                    }

                    //validation of under cost                
                     if(ObjJob.RecordFound == true)
                    {                     
                        
                        if (Convert.ToDecimal(txtSellingPrice.Text.Trim()) <= ObjJob.PurchasePrice)
                        {
                            if (ObjJob.UnderCost == false)
                            {
                                MessageBox.Show("UnderCost Allowed.Selling Price Should be greater than the Purchase Price", "Under Cost Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSellingPrice.Focus();
                                return;
                            }
                        }                       
                    }             
                    if (txtQty.Text == string.Empty || clsValidation.isNumeric(txtQty.Text) == false ||Convert.ToDecimal(txtQty.Text)<=0)
                    {
                        MessageBox.Show("Please enter valid Qnty", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtQty.Focus();
                    }                   
                    ObjJob.TempDocumentNo = txtDoc.Text.ToString();
                    ObjJob.Date = dtDate.Text.Trim();
                    ObjJob.Qty = decimal.Parse(txtQty.Text.Trim().ToString());
                    ObjJob.SellingPrice = decimal.Parse(txtSellingPrice.Text.ToString().Trim());
                    
                    ObjJob.AddItemTemp_Update();
                    dtgadditem.DataSource = ObjJob.TempAddItem.Tables["Product"];
                    dtgadditem.Refresh();


                    txtFprodCode.Text = string.Empty;
                    txtfprodName.Text = string.Empty;
                    txtSellingPrice.Text = string.Empty;
                    txtQty.Text = string.Empty;
                }
             

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnFApply_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsDataForReport = new DataSet();
                frmReportViewer objRepViewer = new frmReportViewer();
                if (txtDoc.Text != string.Empty)
                {
                    ObjJob.SqlStatement = "select DocNo,Create_Date from Job_Header TH WHERE Status = 'RECIEVED' AND Loca = '" + LoginManager.LocaCode + "'";
                    ObjJob.GetDataReader();
                    if (ObjJob.RecordFound == true)
                    {
                        ObjJob.TempDocumentNo = txtDoc.Text.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Job Number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Job Number Not Found", "Job Finished", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
               if(txthandby.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("HandOver by Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
               if(txtfinishby.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Finshed by Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtserviceCharge.Text == string.Empty || clsValidation.isNumeric(txtserviceCharge.Text) == false ||Convert.ToDecimal(txtserviceCharge.Text)<=0)
                {
                    MessageBox.Show("Enter the service charge", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }            
          
                if(CmbJobStatue.SelectedIndex == -1)
                {
                    MessageBox.Show("Select the Job Status", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if(MessageBox.Show("Are you sure you want to Apply this Job Finshed ?","Job Finished",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
               {
                    ObjJob.HandOverBy = txthandby.Text.Trim();
                    ObjJob.HandDate = dthandOver.Text.Trim();
                    ObjJob.FinishDate = dtfinishdate.Text.Trim();
                    ObjJob.FinishBy = txtfinishby.Text.Trim();
                    ObjJob.FinishRemark = txtfinishremark.Text.Trim();
                    ObjJob.JobState = CmbJobStatue.Text.Trim();
                    ObjJob.ServiceCharge = decimal.Parse(txtserviceCharge.Text.Trim());
                    ObjJob.JobFinshedApply();
                    MessageBox.Show("Job Finished Apply Succesful", "Job Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsDataForReport = ObjJob.GetDataset;
                    objRepViewer.DirectPrintVerRep = new rptJobRegistrationRpt();
                    objRepViewer.DirectPrintVerRep.SetDataSource(dsDataForReport);
                    objRepViewer.crystalReportViewer1.ReportSource = objRepViewer.DirectPrintVerRep;
                    objRepViewer.Show();

                    this.Close();
                    frmJob.GetJob = new frmJob();
                    frmJob.GetJob.MdiParent = MainClass.mdi;
                    frmJob.GetJob.Show();

                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void dtgadditem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtgadditem.SelectedRows.Count <= 0 || dtgadditem.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtFprodCode.Text = dtgadditem.SelectedRows[0].Cells[0].Value.ToString();
                    txtfprodName.Text = dtgadditem.SelectedRows[0].Cells[1].Value.ToString();
                    ObjJob.SqlStatement = "SELECT DISTINCT P.Prod_Code,P.Prod_Name,P.Purchase_price,CAST(P.Selling_Price AS DECIMAL(18,2))[Selling_Price] FROM dbo.Stock_Master SM INNER JOIN Product P on P.Prod_Code = SM.Prod_Code WHERE P.Prod_Code = '" + txtFprodCode.Text.Trim() + "' AND SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F'";
                    ObjJob.ReadProductDetail();
                    txtSellingPrice.Text = dtgadditem.SelectedRows[0].Cells[2].Value.ToString();
                    txtQty.Text = dtgadditem.SelectedRows[0].Cells[3].Value.ToString();
                    txtQty.Focus();
                    txtQty.SelectAll();
                }

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);              
            }
        }

        private void dtgadditem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
               if( e.KeyCode == Keys.F2 && dtgadditem.SelectedRows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    if(MessageBox.Show("Are you sure you want to Delete this product?","Job Finished",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        ObjJob.TempDocumentNo = txtDoc.Text.Trim();
                        ObjJob.ProdCode = dtgadditem.SelectedRows[0].Cells[0].Value.ToString();
                        ObjJob.ProdName = dtgadditem.SelectedRows[0].Cells[1].Value.ToString();
                        ObjJob.SellingPrice = decimal.Parse(dtgadditem.SelectedRows[0].Cells[2].Value.ToString());
                        ObjJob.Qty = decimal.Parse(dtgadditem.SelectedRows[0].Cells[3].Value.ToString());
                        //string sqlStatement =@"DELETE FROM TransactionTemp_Details WHERE Doc_No ='"+ObjJob.TempDocumentNo+"' AND Prod_Code ='"+ObjJob.ProdCode+"' AND Selling_Price='"+ObjJob.SellingPrice.ToString()+"' AND Qty ='"+ObjJob.Qty.ToString()+"';";
                        //objcommon.getDataReader(sqlStatement);
                        //objcommon.closeConnection();

                        ObjJob.DeleteAddItem();
                        dtgadditem.DataSource = ObjJob.TempAddItem.Tables["Product"];
                        dtgadditem.Refresh();
                    
                    }

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void dthandOver_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    dtfinishdate.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtfinishdate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txthandby.Focus();
                txthandby.SelectAll();
            }
        }

        private void CmbJobStatue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    txtserviceCharge.Focus();
                    txtserviceCharge.SelectAll();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtserviceCharge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
              if(e.KeyCode == Keys.Enter)
                {
                    txtFprodCode.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtfprodName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtSellingPrice.Focus();
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtserviceCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
              
                if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtserviceCharge.Text + e.KeyChar, out d);
                }
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex);
            }
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtSellingPrice.Text + e.KeyChar, out d);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    decimal d = 0;
                    e.Handled = !decimal.TryParse(txtQty.Text + e.KeyChar, out d);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }
    }
}
