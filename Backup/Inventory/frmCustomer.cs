using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using clsLibrary;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;
using Inventory.Properties;
using Inventory.CRMReports;

namespace Inventory
{
    public partial class frmCustomer : Form
    {
        clsCRMCustomer ObCustomer = new clsCRMCustomer();
        clsReport report = new clsReport();
        clsShortCut cus = new clsShortCut();
        clsSMS2 Rep = new clsSMS2();
        frmSearch search = new frmSearch();
        clsLibrary.clsSMS2 Main = new clsLibrary.clsSMS2();
        bool prodSearching = true;

        MDI mdi = new MDI();
        //frmMobileSearchCustomer searchMobile = new frmMobileSearchCustomer();

        DataView DataViewProductSearch = new DataView();
        public frmCustomer()
        {
            InitializeComponent(); 
        }

        private static frmCustomer _Customer;

        public static frmCustomer GetCustomer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Customer = null;
        }

        void Inactivesupplier(bool _bool)
        {
            this.cmbCustomerName.Enabled = _bool;
            this.txtFirstName.Enabled = _bool;
            this.txtSecondName.Enabled = _bool;
            this.cmbCustomerType.Enabled = _bool;
            this.txtContactPerson.Enabled = _bool;
            this.txtE_Mail2.Enabled = _bool;
            this.txtE_mail.Enabled = _bool;
            this.txtFax.Enabled = _bool;
            this.txtPhoneNumber.Enabled = _bool;
            this.txtAddress1.Enabled = _bool;
            this.txtAddress2.Enabled = _bool;
            this.txtAddress3.Enabled = _bool;
            //this.txtAddress4.Enabled = _bool;
            this.txtTown.Enabled = _bool;
            this.txtDetails.Enabled = _bool;
            this.txtofficePhone.Enabled = _bool;
            this.txtMobile.Enabled = _bool;
            this.txtOther.Enabled = _bool;
            this.txtNICNumber.Enabled = _bool;
            this.dtBirthday.Enabled = _bool;
        }

        private void chkInactive_CheckedChanged(object sender, EventArgs e)
        {
            Inactivesupplier(!Convert.ToBoolean(chkInactive.Checked));
        }

        public void CustomerRetrieve(string find)
        {
            try
            {
                errorProvider.Clear();
                ObCustomer.Reader = ObCustomer.getReader("SELECT Status, NameOfSpouse, Cus_Code, Cus_Name, FirstName, SecondName, CRM.Address1, CRM.Address2, CRM.Address3, Address5, PhoneNo, CRM.Fax, OfficePhone, Other, Mobile,NoMobile, ContactPersion, E_mail, Web, NICNumber, Birthday, Cus_Type, Referance, CRM.InsertDate, CRM.Inactive, CONVERT(DATETIME,InactiveDate,103) [InactiveDate], CRM.Age, Workshop, Wesak, NewYear, DontBCard, Abrod, Festival, Card_No, CardIssuedDate, Occupation, MaritalStatus, SpouseBirthDay, Group_Code, Group_Name, Anniversary, Loca, LocaName, Cust_Category,Balance, Gender, Religion, RedeemStatus ,C.VAT,C.VatNo,C.Credit_Period,C.Credit_Limit,C.Discount,C.PaymentType FROM dbo.CRM_Customer CRM JOIN dbo.Customer C ON C.Cust_Code=CRM.Cus_Code WHERE " + find + "");
                if (ObCustomer.Reader.Read())
                {
                    cmbCustomerID.Text = ObCustomer.Reader["Cus_Code"].ToString();
                    lblCurrentPoints.Text = ObCustomer.Reader["Balance"].ToString();
                    cmbCustomerName.Text = ObCustomer.Reader["Cus_Name"].ToString();
                    txtFirstName.Text = ObCustomer.Reader["FirstName"].ToString();
                    txtSecondName.Text = ObCustomer.Reader["SecondName"].ToString();
                    txtAddress1.Text = ObCustomer.Reader["Address1"].ToString();
                    txtAddress2.Text = ObCustomer.Reader["Address2"].ToString();
                    txtAddress3.Text = ObCustomer.Reader["Address3"].ToString();
                   // txtAddress4.Text = ObCustomer.Reader["Address4"].ToString();
                    txtTown.Text = ObCustomer.Reader["Address5"].ToString();
                    txtCardNumber.Text = ObCustomer.Reader["Card_No"].ToString();
                    txtPhoneNumber.Text = ObCustomer.Reader["PhoneNo"].ToString();
                    txtFax.Text = ObCustomer.Reader["Fax"].ToString();
                    txtofficePhone.Text = ObCustomer.Reader["OfficePhone"].ToString();
                    txtOther.Text = ObCustomer.Reader["Other"].ToString();
                    txtMobile.Text = ObCustomer.Reader["Mobile"].ToString();
                    chkNoMobile.Checked = Convert.ToBoolean(ObCustomer.Reader["NoMobile"]); 

                    txtContactPerson.Text = ObCustomer.Reader["ContactPersion"].ToString();
                    txtE_mail.Text = ObCustomer.Reader["E_mail"].ToString();
                    txtE_Mail2.Text = ObCustomer.Reader["Web"].ToString();
                    txtNICNumber.Text = ObCustomer.Reader["NICNumber"].ToString();
                    dtBirthday.Text = ObCustomer.Reader["Birthday"].ToString();
                    if (ObCustomer.Reader["Birthday"].ToString() != "/  /")
                    {
                        dtpBirthday.Text = ObCustomer.Reader["Birthday"].ToString();
                    }
                    else
                    {
                        dtpBirthday.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    //dtpBirthday.Text = ObCustomer.Reader["Birthday"].ToString();
                    cmbCustomerType.Text = ObCustomer.Reader["Cus_Type"].ToString();
                    txtFirstRegDate.Text = ObCustomer.Reader["InsertDate"].ToString();
                    txtDetails.Text = ObCustomer.Reader["Referance"].ToString();
                    chkInactive.Checked = Convert.ToBoolean(ObCustomer.Reader["Inactive"]);
                    lblInactiveDate.Text = ObCustomer.Reader["InactiveDate"].ToString();
                    txtAge.Text = ObCustomer.Reader["Age"].ToString();
                    chkWorkShop.Checked = Convert.ToBoolean(ObCustomer.Reader["Workshop"]);
                    chkWesak.Checked = Convert.ToBoolean(ObCustomer.Reader["Wesak"]);
                    chkNewyear.Checked = Convert.ToBoolean(ObCustomer.Reader["NewYear"]);
                    chkInformation.Checked = Convert.ToBoolean(ObCustomer.Reader["DontBCard"]);
                    chkAbroad.Checked = Convert.ToBoolean(ObCustomer.Reader["Abrod"]);
                    ObCustomer.Festival = ObCustomer.Reader["Festival"].ToString();
                    cmbStatus.Text = ObCustomer.Reader["Status"].ToString().Trim();
                    txtNameOfSpouse.Text = ObCustomer.Reader["NameOfSpouse"].ToString().Trim();
                    dtpIssuedDate.Text = ObCustomer.Reader["CardIssuedDate"].ToString();
                    txtOccupation.Text = ObCustomer.Reader["Occupation"].ToString();
                    cmbMaritalStatus.Text = ObCustomer.Reader["MaritalStatus"].ToString();
                    mtxtSpouseBDay.Text = ObCustomer.Reader["SpouseBirthDay"].ToString();

                    if (ObCustomer.Reader["SpouseBirthDay"].ToString() != "/  /")
                    {
                        dtpSPBirthday.Text = ObCustomer.Reader["SpouseBirthDay"].ToString();
                        chkSpouseBirthday.Checked = true;
                    }
                    else
                    {
                        dtpSPBirthday.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        chkSpouseBirthday.Checked = false;
                    }

                    cmbCustGroupCode.Text = ObCustomer.Reader["Group_Code"].ToString();
                    cmbCustGroupName.Text = ObCustomer.Reader["Group_Name"].ToString();
                    mtxtAnniverssary.Text = ObCustomer.Reader["Anniversary"].ToString();
                    txtLocaCode.Text = ObCustomer.Reader["Loca"].ToString();
                    txtLocaName.Text = ObCustomer.Reader["LocaName"].ToString();
                    cmbCustCategory.Text = ObCustomer.Reader["Cust_Category"].ToString();

                    cmbGender.Text = ObCustomer.Reader["Gender"].ToString();
                    cmbReligion.Text = ObCustomer.Reader["Religion"].ToString();

                    chkVatCus.Checked = Boolean.Parse(ObCustomer.Reader["VAT"].ToString());
                    txtCusVatNo.Text = ObCustomer.Reader["VatNo"].ToString();
                    txtCusCreditPeriod.Text = ObCustomer.Reader["Credit_Period"].ToString();
                    txtCusCreditLimit.Text = ObCustomer.Reader["Credit_Limit"].ToString();
                    txtCusDiscount.Text = ObCustomer.Reader["Discount"].ToString();
                    cmbPayType.Text = ObCustomer.Reader["PaymentType"].ToString();

                    //string x = ObCustomer.Reader["RedeemStatus"].ToString();

                    if (ObCustomer.Reader["RedeemStatus"].ToString()=="T")
                    {
                        chkAllowRedeem.Checked = true;
                    }
                    else
                    {
                        chkAllowRedeem.Checked = false;
                    }

                    string[] festi = new string[ObCustomer.Festival.Length];
                    for (int i = 0; i < ObCustomer.Festival.Length; i++)
                    {
                        festi[i] = ObCustomer.Festival.Substring(i, 1);
                    }

                    for (int i = 0; i < chklisFestival.Items.Count; i++)
                    {
                        chklisFestival.SetItemChecked(Convert.ToInt16(i), false);
                    }

                    for (int i = 0; i < festi.Length; i++)
                    {
                        chklisFestival.SetItemChecked(Convert.ToInt16(festi[i]), true);
                    }

                    //if (Settings.Default.AutoGenCustCode == true)
                    //{
                    //    cmbCustomerID.ReadOnly = true;
                    //}
                    
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        #region KeyDowns

        private void cmbCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    CustomerRetrieve("(CRM.Cus_Code = '" + cmbCustomerID.Text.Trim() + "' OR CRM.Mobile = '" + cmbCustomerID.Text.Trim() + "' OR CRM.NICNumber = '" + cmbCustomerID.Text.Trim() + "' OR CRM.Card_No = '" + cmbCustomerID.Text.Trim().Replace("CFC", "") + "')");
                    cmbStatus.Focus();
                    //cmbCustomerName.Focus();
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
                finally
                {
                    ObCustomer.CloseReaderAndConnection();
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                btnCusSearch.PerformClick();
            }
        }

        private void cmbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    //CustomerRetrieve("Cus_Name = '" + cmbCustomerName.Text.Trim() + "'");
                    //txtAddress1.Focus();
                    //txtAddress1.SelectAll();
                    txtFirstName.Focus();
                    txtFirstName.SelectAll();

                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
                finally
                {
                    ObCustomer.CloseReaderAndConnection();
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                btnCusSearch.PerformClick();
            }
        }

        private void txtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 
                txtAddress2.Focus();
                txtAddress2.SelectAll();
            }
            else if (e.KeyCode == Keys.F1)
            {
                btnAddSearch.PerformClick();
            }
        }

        private void txtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress3.Focus();
                txtAddress3.SelectAll();
            }
        }

        private void txtAddress3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
            }
        }

        private void txtAddress4_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtCardNumber.Focus();
            //    txtCardNumber.SelectAll();
            //}
        }

        private void txtTown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhoneNumber.Focus();
                txtPhoneNumber.SelectAll();
            }
        }

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtofficePhone.Focus();
                txtofficePhone.SelectAll();
            }
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOther.Focus();
                txtOther.SelectAll();
            }
        }

        private void txtofficePhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkNoMobile.Checked)
                {
                    txtFax.Focus();

                }
                else
                {
                    txtMobile.Focus();

                }
            }
        }

        private void txtOther_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtE_mail.Focus();
                txtE_mail.SelectAll();
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            //txtMobile.Text = CleanPhone(txtMobile.Text.Trim());
          

            if (e.KeyCode == Keys.Enter)
            {
                if (txtMobile.Text.Trim().Length < 10)
                {
                    MessageBox.Show("Mobile Number not in correct length.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txtMobile.SelectAll();
                }
                else
                {
                    txtFax.Focus();
                    txtFax.SelectAll();
                }
            }

             
        }

        string CleanPhone(string phone)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(phone, "");
        }

        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhoneNumber.Focus();
                txtPhoneNumber.SelectAll();
            }
        }

        private void txtE_mail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayType.Focus();
                cmbPayType.SelectAll();
            }
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNICNumber.Focus();
                txtNICNumber.SelectAll();
            }
        }

        private void txtNICNumber_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cmbCustomerID.Text.Trim() == "")
                    {
                        CustomerRetrieve("CRM.NICNumber = '" + txtNICNumber.Text.Trim() + "'");
                    }
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                }
                finally
                {
                    ObCustomer.CloseReaderAndConnection();
                }
                dtBirthday.Focus();
            }
        }

        private void dtBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            try 
	        {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        if (dtBirthday.Text.Trim() != "/  /")
                        {
                            string timestamp_string = dtBirthday.Text.ToString();
                            DateTime timestamp = Convert.ToDateTime(timestamp_string);
                            if (timestamp_string.Length < 10)
                            {
                                MessageBox.Show("Date format of the birthday is incorrect.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtBirthday.Focus();
                                return;
                            }
                        }
                        //Convert.ToDateTime(dtBirthday.Text.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Date format of the birthday is incorrect.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtBirthday.Focus();
                        return;
                    }
                    txtNameOfSpouse.Focus();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    try
                    {
                        frmCustomerSearch search = new frmCustomerSearch();
                        clsSMS2.SearchDataset = ObCustomer.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE Birthday LIKE '" + dtBirthday.Text.Trim() + "%' ORDER BY CONVERT(DATETIME,Birthday,103)", "T");
                        search.ShowDialog();
                        if (clsSMS2.Cnt_Focus != null)
                        {
                            cmbCustomerID.Text = clsSMS2.Cnt_Focus.ToString();
                            cmbCustomerName.Text = clsSMS2.Cnt_Descrip.ToString();
                            clsSMS2.Cnt_Focus = null;
                            clsSMS2.Cnt_Descrip = null;
                        }
                        cmbCustomerID.Focus();
                    }
                    catch (Exception ex)
                    {
                        clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    dtBirthday.Clear();
                }
	        }
	        catch (Exception ex)
	        {
		        clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
	        }           
        }

        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCustCategory.Focus();
                //txtDetails.Focus();
               // txtDetails.SelectAll();
            }
        }

        #endregion

        private void ErrorFocus(ComboBox cmbbox)
        {
            if (string.IsNullOrEmpty(cmbbox.Text))
            {
                errorProvider.SetError(cmbbox, "Cannot text empty");
            }
        }

        private void ErrorFocus(TextBox txtbox)
        {
            if (txtbox.Text.Length == 0)
            {
                errorProvider.SetError(txtbox, "Cannot text empty");
            }
        }
              
        void IdAndNameRefresh()
        {
            //ObCustomer.dataset = ObCustomer.getDataSet("SELECT Cus_Code, Cus_Name FROM CRM_Customer", "Customer");
            //textBox1.DataSource = cmbCustomerID.DataSource = ObCustomer.dataset.Tables[0];
            //cmbCustomerID.DisplayMember = "Cus_Code";
            //textBox1.DisplayMember = "Cus_Name";
        }

        private DataSet getDataTable(int rows)
        {
            ObCustomer.dataset = ObCustomer.getDataSet("SELECT Cus_Code, Cus_Name FROM CRM_Customer ORDER BY Id_No", "R");
            return (ObCustomer.dataset);
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerID.Focus();
               
               // ObCustomer.CloseReaderAndConnection();
                //if (OnimtaOpticalSystem.Properties.Settings.Default.Searchtwooption == true)
                //{
                //    this.Text = this.Text + " - Loading customer... Please wait....";
                //    backgroundWorker1.RunWorkerAsync();
                //}
                ObCustomer.CloseReaderAndConnection();
                ObCustomer.dataset = ObCustomer.getDataSet("SELECT Type FROM CRM_CustomerType; SELECT FastName FROM CRM_Fastival ORDER BY Numbers; SELECT Ststus FROM CRM_Status");
                cmbCustomerType.DataSource = ObCustomer.dataset.Tables[0];
                cmbCustomerType.DisplayMember = "Type";

                cmbStatus.DataSource = ObCustomer.dataset.Tables[2];
                cmbStatus.DisplayMember = "Ststus";

                foreach (DataRow row in ObCustomer.dataset.Tables[1].Rows)
                {
                    chklisFestival.Items.Add(row[0].ToString());
                }


                ObCustomer.dataset = ObCustomer.getDataSet("SELECT Religion FROM CRM_Religion ORDER BY Religion");
                cmbReligion.DataSource = ObCustomer.dataset.Tables[0];
                cmbReligion.DisplayMember = "Religion";
                cmbReligion.Refresh();

                //string SqlStatement = "SELECT Cus_Code, Cus_Name FROM CRM_Customer";
                //ObCustomer.getDataReader(SqlStatement);
                //while (ObCustomer.Reader.Read())
                //{
                //    cmbCustomerID.Items.Add(ObCustomer.Reader["Cus_Code"].ToString());
                //    cmbCustomerName.Items.Add(ObCustomer.Reader["Cus_Name"].ToString());
                //}

                string SqlStatement = "SELECT Group_Code, Group_Name FROM CRM_CustomerGroup";
                ObCustomer.getDataReader(SqlStatement);
                while (ObCustomer.Reader.Read())
                {
                    cmbCustGroupCode.Items.Add(ObCustomer.Reader["Group_Code"].ToString());
                    cmbCustGroupName.Items.Add(ObCustomer.Reader["Group_Name"].ToString());
                }

                //if (Settings.Default.AutoGenCustCode ==  true)
                //{
                //    ObCustomer.dataset = ObCustomer.getDataSet("SELECT TOP 1 Cus_Code, Cus_Name FROM CRM_Customer ORDER BY Cus_Code DESC", "Duplicate");
                //    foreach (DataRow row in ObCustomer.dataset.Tables[0].Rows)
                //    {
                //        if (clsValidation.isNumeric(row["Cus_Code"].ToString(), System.Globalization.NumberStyles.Number) == true)
                //        {
                //            decimal newcustcode = decimal.Parse(row["Cus_Code"].ToString());
                //            newcustcode = newcustcode + 1;
                //            cmbCustomerID.Text = newcustcode.ToString().PadLeft(Settings.Default.CodeLength,'0');
                //        }
                //        else
                //        {
                //            MessageBox.Show("Cannot create the customer code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                        
                //    }  
                //}


                txtLocaCode.Text = LoginManager.LocaCode;
                txtLocaCode_KeyDown(new object(), new KeyEventArgs(Keys.Enter));

                DataSet dsCustCat = ObCustomer.getDataSet("SELECT Category FROM CRM_CustCategory");
                cmbCustCategory.DataSource = dsCustCat.Tables[0];
                cmbCustCategory.DisplayMember = "Category";

                dtBirthday.Text = dtpBirthday.Text.Trim();
                mtxtSpouseBDay.Text = dtpSPBirthday.Text.Trim();
                chkNameAuto.Checked = true;
                cmbGender.SelectedIndex = 0;
                CreateCustCode();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                ObCustomer.CloseReaderAndConnection();
            }
        }
        public void CreateCustCode()
        {
            if (Settings.Default.AutoGenCustCode == true)
            {
                DataSet Ds = ObCustomer.getDataSet("SELECT RCust FROM dbo.CodeGenarator");

                cmbCustomerID.Text ="C"+ string.Format("{0:0000}", Ds.Tables[0].Rows[0][0]);
                cmbCustomerID.Focus();

            }
            else
            {
                cmbCustomerID.Focus();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {                
                //DataSet dt;
                //dt = getDataTable(1);
                //e.Result = dt.Tables[0];
                //cmbCustomerID.DataSource = textBox1.DataSource = e.Result;
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                ObCustomer.CloseReaderAndConnection();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //cmbCustomerID.DisplayMember = "Cus_Code";
            //textBox1.DisplayMember = "Cus_Name";
            cmbCustomerID.Text = string.Empty;
            cmbCustomerName.Text = string.Empty;
            this.Text = "Customer";
        }

        private void btnCusSearch_Click(object sender, EventArgs e)
        {
            try
            {
              

               

                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (cmbCustomerID.Text != string.Empty && cmbCustomerName.Text == string.Empty)
                {
                    if (Settings.Default.AutoGenCustCode == true)
                    {
                        search.dgSearch.DataSource = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name], /*PhoneNo AS [Phone],*/ Mobile FROM CRM_Customer WHERE   (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code").Tables[0];

                    }
                    else
                    {
                        search.dgSearch.DataSource = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name], /*PhoneNo AS [Phone],*/ Mobile FROM CRM_Customer WHERE (Cus_Code LIKE '%" + cmbCustomerID.Text.Trim() + "%' OR NICNumber LIKE '%" + cmbCustomerID.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code").Tables[0];
                    
                    }
                }
                else if (cmbCustomerID.Text == string.Empty && cmbCustomerName.Text != string.Empty)
                {
                    search.dgSearch.DataSource = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name], /*PhoneNo AS [Phone],*/ Mobile FROM CRM_Customer WHERE (Cus_Name LIKE '%" + cmbCustomerName.Text.Trim() + "%') AND (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code").Tables[0];
                }
                else
                {
                    search.dgSearch.DataSource = Main.getDataSet("SELECT Cus_Code AS [Customer],Cus_Name AS [Name],  /*PhoneNo AS [Phone],*/ Mobile FROM CRM_Customer WHERE (Loca LIKE '%" + txtLocaCode.Text.Trim() + "%') ORDER BY Cus_Code").Tables[0];
                }
                search.prop_Focus = cmbCustomerID;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chklisFestival.Focus();
                chklisFestival.SetSelected(0, true);
            }

        }

        private void dtBirthday_Leave(object sender, EventArgs e)
        {
            if (dtBirthday.Text != "  /  /")
            {
                try
                {
                    Convert.ToDateTime(dtBirthday.Text);
                    txtAge.Text = string.Format("{0:00}", ((int.Parse(string.Format("{0:yyyy}", DateTime.Now)) - (int.Parse(string.Format("{0:yyyy}", Convert.ToDateTime(dtBirthday.Text)))))));
                }
                catch
                {
                    MessageBox.Show("Customer Birthday not valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtBirthday.Focus();
                    return;
                    //dtBirthday.Text = string.Empty;
                }
            }
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chklisFestival.Focus();
                chklisFestival.SetSelected(0, true);
                
                //txtDetails.SelectAll();
            }
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            try
            {
                clsSMS2.Cnt_Focus = null;
                clsSMS2.Cnt_Descrip = null;

                frmCustomerSearch search = new frmCustomerSearch();
                clsSMS2.SearchDataset = ObCustomer.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE Address1 LIKE '" + txtAddress1.Text.Trim() + "%' ORDER BY Cus_Code", "T");
                search.Show();

                if (clsSMS2.Cnt_Focus != null)
                {
                    cmbCustomerID.Text = clsSMS2.Cnt_Focus.ToString();
                    cmbCustomerName.Text = clsSMS2.Cnt_Descrip.ToString();
                    clsSMS2.Cnt_Focus = null;
                    clsSMS2.Cnt_Descrip = null;
                }
                cmbCustomerID.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnChildrenDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbCustomerID.Text.Trim()))
                {
                    MessageBox.Show("Customer Code Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCustomerID.Focus();
                    return;
                }
                if (frmChildrenDetails.GetChildrenDetails == null)
                {
                    frmChildrenDetails.GetChildrenDetails = new frmChildrenDetails();
                    frmChildrenDetails.GetChildrenDetails.MdiParent = MainClass.mdi;
                    frmChildrenDetails.GetChildrenDetails.lblCustCode.Text = cmbCustomerID.Text.Trim();
                    frmChildrenDetails.GetChildrenDetails.lblCustName.Text = cmbCustomerName.Text.Trim();
                    frmChildrenDetails.GetChildrenDetails.Show();
                }
                else 
                {
                    frmChildrenDetails.GetChildrenDetails.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbCustomerID.Text == string.Empty && txtCardNumber.Text != string.Empty)
                {
                    CustomerRetrieve("(CRM.Card_No = '" + txtCardNumber.Text.Trim() + "')");
                }
                dtpIssuedDate.Focus();              
            }
        }

        private void txtNameOfSpouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkSpouseBirthday.Focus();
               // mtxtSpouseBDay.SelectAll();
            }
        }

        private void frmCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.S)
                {
                    btnSave.PerformClick();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.D)
                {
                    btnChildrenDetails.PerformClick();
                }
                else if (e.KeyCode == Keys.L)
                {
                    btnClear.PerformClick();
                }
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbCustomerName.Enabled == false)
                {
                    txtFirstName.Focus();
                }
                else
                {
                    cmbCustomerName.Focus();
                }
            }
        }

        private void chklisFestival_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbReligion.Focus();
                //cmbCustomerType.Focus();
                
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                ObCustomer.Festival = "";
                for (int i = 0; i < chklisFestival.Items.Count; i++)
                {
                    if (chklisFestival.GetItemChecked(i))
                    {
                        ObCustomer.Festival += i;
                    }
                }


                if (txtContactPerson.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Contact persion not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtContactPerson.Focus();
                    //return;
                    txtContactPerson.Text = ".";
                }

                //if (txtWebsite .Text.Trim().ToString() == string.Empty)
                //{
                //    MessageBox.Show("Web site not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtWebsite.Focus();
                //    return;

                //}
                if (txtE_mail.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("E-mail not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtE_mail.Focus();
                    //return;
                    txtE_mail.Text = ".";

                }
                if (txtFax.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Fax No not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtFax.Focus();
                    //return;
                    txtFax.Text = ".";

                }
                if (txtPhoneNumber.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Phone Number not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtPhoneNumber.Focus();
                    //return;
                    txtPhoneNumber.Text = ".";

                }
                if (txtAddress1.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Address1 not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtAddress1.Focus();
                    txtAddress1.Text = ".";
                   // return;
                }
                if (txtAddress2.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Address2 not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtAddress2.Focus();
                    //return;
                    txtAddress1.Text = ".";
                }
                if (txtAddress3.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Address3 not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtAddress3.Focus();
                    //return;
                    txtAddress3.Text = ".";
                }
                if (txtofficePhone.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Office Phone not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtofficePhone.Focus();
                    //return;
                    txtofficePhone.Text = ".";

                }
                if (chkNoMobile.Checked == false)
                {
                    if (txtMobile.Text.Trim().ToString() == string.Empty)
                    {
                        MessageBox.Show("Mobile Number not valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMobile.Focus();
                        return;

                    }
                }
                if (txtOther.Text.Trim().ToString() == string.Empty)
                {
                    //MessageBox.Show("Other not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtOther.Focus();
                    //return;
                    txtOther.Text = ".";

                }
                if (txtNICNumber.Text.Trim().ToString() != string.Empty)
                {
                
                    if (txtNICNumber.Text.Trim().Length < 10 || txtNICNumber.Text.Trim().Length == 11 || txtNICNumber.Text.Trim().Length > 12)
                    {
                        MessageBox.Show("NIC Number is not in Correct Length.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNICNumber.Focus();
                        return;
                    }
                }

                if (cmbCustomerType.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Customer type not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCustomerType.Focus();
                    return;

                }
                if (cmbCustomerID.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Customer ID  not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCustomerID.Focus();
                    return;

                }
                if (cmbCustomerName.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Customer name not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCustomerName.Focus();
                    return;
                }

                if (cmbGender.Text.Trim() == "")
                {
                    MessageBox.Show("Gender is not entered.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbGender.Focus();
                    return;
                }              

                //if(Settings.Default.AutoGenCustCode)
                //{
                //    if (cmbCustomerID.Text.Trim().Length != Settings.Default.CodeLength)
                //    {
                //        MessageBox.Show("Invalid customer code length.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        cmbCustomerID.Focus();
                //        return;     
                //    }
                //}

                if (cmbPayType.SelectedIndex == -1)
                {
                    MessageBox.Show("Payment type not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbPayType.Focus();
                    return;  
                }
                if (txtCusCreditPeriod.Text.Trim() == string.Empty || clsValidation.isNumeric(txtCusCreditPeriod.Text, System.Globalization.NumberStyles.Number) == false)
                {
                    txtCusCreditPeriod.Text = "0";
                }

                if (txtCusCreditLimit.Text.Trim() == string.Empty || clsValidation.isNumeric(txtCusCreditLimit.Text,System.Globalization.NumberStyles.Number) == false)
                {
                    txtCusCreditLimit.Text = "0";
                }
                if (chkVatCus.Checked == true && txtCusVatNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Invalid Vat Registred Number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCusVatNo.Focus();
                    return; 
                }

                #region Duplicate

                ObCustomer.dataset = ObCustomer.getDataSet("SELECT Cus_Code FROM CRM_Customer WHERE Cus_Name = '" + cmbCustomerName.Text.Trim() + "' ", "Duplicate");
                foreach (DataRow row in ObCustomer.dataset.Tables[0].Rows)
                {
                    if (cmbCustomerID.Text.Trim() != row["Cus_Code"].ToString())
                    {
                        MessageBox.Show("This customer is already registered in the system.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbCustomerName.Focus();
                        errorProvider.SetError(cmbCustomerName, "This customer is already registered in the system.");
                        return;
                    }
                }
                ObCustomer.dataset = ObCustomer.getDataSet("SELECT Cus_Code FROM CRM_Customer WHERE Mobile = '" + txtMobile.Text.Trim() + "' AND Mobile !='' ", "Duplicate");
                foreach (DataRow row in ObCustomer.dataset.Tables[0].Rows)
                {
                    if (cmbCustomerID.Text.Trim() != row["Cus_Code"].ToString())
                    {
                        MessageBox.Show("This Mobile Number is already exists.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMobile.Focus();
                        txtMobile.SelectAll();
                        errorProvider.SetError(txtMobile, "This Mobile Number is already exists.");
                        return;
                    }
                }
                ObCustomer.dataset = ObCustomer.getDataSet("SELECT Cus_Code FROM CRM_Customer WHERE NICNumber = '" + txtNICNumber.Text.Trim() + "' AND NICNumber !='' ", "Duplicate");
                foreach (DataRow row in ObCustomer.dataset.Tables[0].Rows)
                {
                    if (cmbCustomerID.Text.Trim() != row["Cus_Code"].ToString())
                    {
                        MessageBox.Show("This NIC Number is already exists.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNICNumber.Focus();
                        txtNICNumber.SelectAll();
                        errorProvider.SetError(txtNICNumber, "This NIC Number is already exists.");
                        return;
                    }
                }



                #endregion

                #region check ' 
                if (cmbCustomerName.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCustomerName.SelectAll();
                    cmbCustomerName.Focus();
                    return;
                }
                if (txtFirstName.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirstName.SelectAll();
                    txtFirstName.Focus();
                    return;
                }
                if (txtSecondName.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSecondName.SelectAll();
                    txtSecondName.Focus();
                    return;
                }
                if (txtAddress1.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress1.SelectAll();
                    txtAddress1.Focus();
                    return;
                }
                if (txtAddress2.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress2.SelectAll();
                    txtAddress2.Focus();
                    return;
                }
                if (txtAddress3.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress3.SelectAll();
                    txtAddress3.Focus();
                    return;
                }
                if (txtOccupation.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOccupation.SelectAll();
                    txtOccupation.Focus();
                    return;
                }
                if (txtContactPerson.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtContactPerson.SelectAll();
                    txtContactPerson.Focus();
                    return;
                }
                if (txtDetails.Text.Contains("`"))
                {
                    MessageBox.Show("Please Remove the Single Quotation Marks", "incorrect Syntax found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDetails.SelectAll();
                    txtDetails.Focus();
                    return;
                }
                if (cmbCustCategory.Text == string.Empty || cmbCustCategory.Text == "")
                {
                    MessageBox.Show("Please Select the Customer Category", "Customer Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCustCategory.SelectAll();
                    cmbCustCategory.Focus();
                    return;
                }



                #endregion

                string sqlStatement = "SELECT Card_No FROM CRM_Customer WHERE Cus_Code='" + cmbCustomerID.Text.Trim() + "'";
                ObCustomer.getDataReader(sqlStatement);
                if(ObCustomer.Reader.Read())
                {
                    string Card_No = ObCustomer.Reader["Card_No"].ToString();

                    if(Card_No!=txtCardNumber.Text.Trim())
                    {
                        if(MessageBox.Show("Existing card number in the system for the selected customer is not match with current card number. \r\n Do you want to continue anyway? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.No)
                        {
                            if (MessageBox.Show("Do you want to replace the card number?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }

                    }
                }
                ObCustomer.CloseReaderAndConnection();

                sqlStatement = "SELECT Cus_Code FROM CRM_Customer WHERE Card_No='" + txtCardNumber.Text.Trim() + "'";
                ObCustomer.getDataReader(sqlStatement);
                if(ObCustomer.Reader.Read())
                {
                    string Cus_Code = ObCustomer.Reader["Cus_Code"].ToString();

                    if (Cus_Code != cmbCustomerID.Text.Trim())
                    {
                        MessageBox.Show("Entered card number already registered to customer: " + Cus_Code, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                ObCustomer.CloseReaderAndConnection();

                 sqlStatement = "SELECT Cus_Code FROM CRM_Customer WHERE Cus_Code='" + cmbCustomerID.Text.Trim() + "'";
                ObCustomer.getDataReader(sqlStatement);
                if (ObCustomer.Reader.Read() && MessageBox.Show("Customer Code allready available...Do you want to Update records..? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    SaveCust();
                    return;
                    
                }
                ObCustomer.CloseReaderAndConnection();

                if (MessageBox.Show("Do you want to Registre this Customer?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveCust();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        public void SaveCust()
        {
            try
            {
                    ObCustomer.CusCode = cmbCustomerID.Text.Trim();
                    ObCustomer.CusName = cmbCustomerName.Text.Trim();
                    ObCustomer.FirstName = txtFirstName.Text.Trim();
                    ObCustomer.SecondName = txtSecondName.Text.Trim();
                    ObCustomer.Address1 = txtAddress1.Text.Trim();
                    ObCustomer.Address2 = txtAddress2.Text.Trim();
                    ObCustomer.Address3 = txtAddress3.Text.Trim();
                    //ObCustomer.Address4 = txtAddress4.Text.Trim();
                    ObCustomer.Address5 = txtTown.Text.Trim();
                    ObCustomer.PhoneNumber = txtPhoneNumber.Text.Trim();
                    ObCustomer.Fax = txtFax.Text.Trim();
                    ObCustomer.OfficePhone = txtofficePhone.Text.Trim();
                    ObCustomer.Other = txtOther.Text.Trim();
                    ObCustomer.Mobile = txtMobile.Text.Trim();
                    ObCustomer.NoMobile = Convert.ToBoolean(chkNoMobile.Checked);
                    ObCustomer.ContactPersion = txtContactPerson.Text.Trim();
                    ObCustomer.Email = txtE_mail.Text.Trim();
                    ObCustomer.Web = txtE_Mail2.Text.Trim();
                    ObCustomer.NICNumber = txtNICNumber.Text.Trim();
                    ObCustomer.CustomerType = cmbCustomerType.Text.Trim();
                    ObCustomer.Birthday = dtBirthday.Text.Trim();
                    ObCustomer.Inactive = Convert.ToBoolean(chkInactive.Checked);
                    ObCustomer.Referance = txtDetails.Text.ToString().Trim();
                    ObCustomer.Age = txtAge.Text.Trim();
                    ObCustomer.InsertUser = LoginManager.UserName;
                    ObCustomer.ModUser = clsSMS2.LoginUser;
                    ObCustomer.Workshop = Convert.ToBoolean(chkWorkShop.Checked);
                    ObCustomer.Abroad = Convert.ToBoolean(chkAbroad.Checked);
                    ObCustomer.Wesak = Convert.ToBoolean(chkWesak.Checked);
                    ObCustomer.NewYear = Convert.ToBoolean(chkNewyear.Checked);
                    ObCustomer.SendBirthday = Convert.ToBoolean(chkInformation.Checked);
                    ObCustomer.Status = cmbStatus.Text.Trim();
                    ObCustomer.SpouseName = txtNameOfSpouse.Text.Trim();
                    ObCustomer.Card_No = txtCardNumber.Text.Trim();
                    ObCustomer.CardIssueDate = dtpIssuedDate.Text.Trim();
                    ObCustomer.Occupation = txtOccupation.Text.Trim();
                    ObCustomer.MaritalStatus = cmbMaritalStatus.Text.Trim();

                    if (cmbMaritalStatus.Text.Trim() == "Single")
                    {
                        ObCustomer.SpouseBDay = "/  /";
                    }
                    else
                    {
                        ObCustomer.SpouseBDay = mtxtSpouseBDay.Text.Trim();
                    }
                    ObCustomer.GroupCode = cmbCustGroupCode.Text.Trim();
                    ObCustomer.GroupName = cmbCustGroupName.Text.Trim();
                    ObCustomer.Anniversary = mtxtAnniverssary.Text.Trim();
                    ObCustomer.Loca = txtLocaCode.Text.Trim();
                    ObCustomer.LocaName = txtLocaName.Text.Trim();
                    ObCustomer.CustCategory = cmbCustCategory.Text.Trim();

                    ObCustomer.Gender = cmbGender.Text.Trim();
                    ObCustomer.Religion = cmbReligion.Text.Trim();

                    if (chkAllowRedeem.Checked)
                    {
                        ObCustomer.AllowRedeem = "T";
                    }
                    else
                    {
                        ObCustomer.AllowRedeem = "F";
                    }

                    ObCustomer.PayType = cmbPayType.Text.Trim();
                    ObCustomer.CusCredit_Limit = Convert.ToDecimal(txtCusCreditLimit.Text.Trim());
                    ObCustomer.CusCredit_Period = Convert.ToInt32(txtCusCreditPeriod.Text.Trim());
                    ObCustomer.CusDiscount = Convert.ToDecimal(txtCusDiscount.Text.Trim());
                    ObCustomer.IsVat = chkVatCus.Checked;
                    ObCustomer.VatNo = txtCusVatNo.Text.Trim();

                    ObCustomer.CustomerUpdate();

                  //  MessageBox.Show("Record saved successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCustomerID.Focus();

                    if (string.IsNullOrEmpty(ObCustomer.Focuseds))
                    {
                        btnClear.PerformClick();
                    }
                    else
                    {
                        this.Controls.Find(ObCustomer.Focuseds, true)[0].Focus();
                        return;
                    }
                    txtE_mail.Text = string.Empty;
                    txtOther.Text = string.Empty;
                    txtContactPerson.Text = string.Empty;
                    cmbCustGroupCode.Text = string.Empty;
                    cmbCustGroupName.Text = string.Empty;
                    mtxtAnniverssary.Text = string.Empty;
            }
            catch (Exception ex)
            {

                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (Control cont in this.Controls)
                {
                    if (cont is TextBox || cont is ComboBox)
                    {
                        cont.Text = string.Empty;
                    }
                }

                foreach (Control cont in groupBox2.Controls)
                {
                    if (cont is TextBox || cont is ComboBox)
                    {
                        cont.Text ="0";
                    }
                }
                chkVatCus.Checked = false;
                for (int i = 0; i < chklisFestival.Items.Count; i++)
                {
                    chklisFestival.SetItemChecked(i, false);
                }
                lblCurrentPoints.Text = "0";
                chkInactive.Checked = false;
                txtAge.Text = string.Empty;
                dtBirthday.Text = string.Empty; 
                txtFirstName.Text = string.Empty;
                txtSecondName.Text = string.Empty;
                txtOccupation.Text = string.Empty;
                cmbMaritalStatus.Text = string.Empty;
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                txtAddress3.Text = string.Empty;
                txtCardNumber.Text = string.Empty;
                txtNICNumber.Text = string.Empty;
                txtNameOfSpouse.Text = string.Empty;
                mtxtSpouseBDay.Text = string.Empty;
                cmbCustomerType.SelectedIndex = 0;
                txtContactPerson.Text = string.Empty;
                txtE_mail.Text = string.Empty;
                txtOther.Text = string.Empty;
                mtxtAnniverssary.Text = string.Empty;
                txtLocaCode.Text = string.Empty;
                txtLocaName.Text = string.Empty;
                chkNoMobile.Checked = false;
                cmbCustomerID.Text = string.Empty;
                cmbCustomerName.Text=txtMobile.Text = string.Empty;

                chkAllowRedeem.Checked = true;

                //if (Settings.Default.AutoGenCustCode == true)
                //{
                //    ObCustomer.dataset = ObCustomer.getDataSet("SELECT TOP 1 Cus_Code, Cus_Name FROM CRM_Customer ORDER BY Cus_Code DESC", "Duplicate");
                //    foreach (DataRow row in ObCustomer.dataset.Tables[0].Rows)
                //    {
                //        if (clsValidation.isNumeric(row["Cus_Code"].ToString(), System.Globalization.NumberStyles.Number) == true)
                //        {
                //            decimal newcustcode = decimal.Parse(row["Cus_Code"].ToString());
                //            newcustcode = newcustcode + 1;
                //            cmbCustomerID.Text = newcustcode.ToString().PadLeft(Settings.Default.CodeLength, '0');
                //        }
                //        else
                //        {
                //            MessageBox.Show("Cannot create the customer code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }

                //    }
                //}
                //else { cmbCustomerID.Text = string.Empty; cmbCustomerName.Text = string.Empty; }
               // cmbCustomerID.Focus();
                chkNameAuto.Checked = true;
                cmbGender.SelectedIndex = 0;
                txtLocaCode.Text = LoginManager.LocaCode;
                txtLocaCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                CreateCustCode();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSecondName.Focus();
                    txtSecondName.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void txtSecondName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress1.Focus();
                    txtAddress1.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void dtpIssuedDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtOccupation.Focus();
                    //txtOccupation.SelectAll();

                    txtFirstName.Focus();
                    txtFirstName.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void txtOccupation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMaritalStatus.Focus();
                    cmbMaritalStatus.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

       
        private void btnAdditionalInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbCustomerID.Text.Trim()))
                {
                    MessageBox.Show("Customer Code Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCustomerID.Focus();
                    return;
                }
                if (frmAdditionalInfomation.GetAdditionalInfo == null)
                {
                    frmAdditionalInfomation.GetAdditionalInfo = new frmAdditionalInfomation();
                    frmAdditionalInfomation.GetAdditionalInfo.MdiParent = this.MdiParent;
                    frmAdditionalInfomation.GetAdditionalInfo.txtAddCustCode.Text = cmbCustomerID.Text.Trim();
                    frmAdditionalInfomation.GetAdditionalInfo.txtAddCustName.Text = cmbCustomerName.Text.Trim();
                    frmAdditionalInfomation.GetAdditionalInfo.Show();
                }
                else
                {
                    frmAdditionalInfomation.GetAdditionalInfo.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void mtxtSpouseBDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chklisFestival.Focus();
                    chklisFestival.SetSelected(0, true);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNICNumber.Focus();
                    txtNICNumber.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void cmbCustGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDetails.Focus();
                    //cmbReligion.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                                
            }
        }

        private void cmbCustGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCustGroupCode.SelectedIndex = cmbCustGroupName.SelectedIndex;
        }

        private void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbCustomerName.SelectedIndex = cmbCustomerID.SelectedIndex;
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }
        
        private void mtxtAnniverssary_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCustomerType.Focus();
            }
        }

        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtLocaCode.Text.Trim() != string.Empty && txtLocaName.Text.Trim() == string.Empty)
                {
                    search.dgSearch.DataSource = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca LIKE '%" + txtLocaCode.Text.Trim() + "%' ORDER BY Loca");
                }
                else if (txtLocaCode.Text.Trim() == string.Empty && txtLocaName.Text.Trim() != string.Empty)
                {
                    search.dgSearch.DataSource = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location WHERE Loca_Descrip LIKE '%" + txtLocaName.Text.Trim() + "%' ORDER BY Loca");
                }
                else
                {
                    search.dgSearch.DataSource = Main.getDataSet("SELECT Loca [Code], Loca_Descrip [Location] FROM Location ORDER BY Loca");
                }
                search.prop_Focus = txtLocaCode;
                search.Show();

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string SqlStatement = "SELECT Loca, Loca_Descrip FROM Location WHERE Loca='" + txtLocaCode.Text.Trim() + "'";
                Main.getDataReader(SqlStatement);
                if (Main.Reader.Read())
                {
                    txtLocaCode.Text = Main.Reader["Loca"].ToString();
                    txtLocaName.Text = Main.Reader["Loca_Descrip"].ToString();
                }
                cmbCustomerID.Focus();
            }
        }

        private void chkNoMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoMobile.Checked == true) { txtMobile.Text = ""; txtMobile.Enabled = false; }
            else { txtMobile.Text = ""; txtMobile.Enabled = true; }
        }

        private void lnkPointStatement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerPointStatement();
        }

        private void CustomerPointStatement()
        {
            try
            {
                Rep.GetStoredProcedure("CRM_sp_CustomerPointStatement", new object[,] { { "@CustCode", "" + cmbCustomerID.Text.Trim().ToString() + "" }, { "@Loca", "" + LoginManager.LocaCode + "" }, { "@Cust_Category",""+cmbCustCategory.Text.Trim()+"" } }, "Statement");
                Rep.dataset.Tables[1].TableName = "Company";
                report.DisplayReport(new rptCustomerPontStatement(), Rep.dataset, "Customer Point Statement", "");
       
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            }

        private void btnSearchByMobile_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerSearch search = new frmCustomerSearch();
                clsSMS2.SearchDataset = ObCustomer.getDataSet("SELECT Cus_Code AS [Customer], Mobile , Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone] FROM CRM_Customer WHERE Mobile LIKE '%" + txtMobile.Text.Trim() + "%' ORDER BY Cus_Code", "T");
                search.Show();

                if (clsSMS2.Cnt_Focus != null)
                {
                    cmbCustomerID.Text = clsSMS2.Cnt_Focus.ToString();
                    txtMobile.Text = clsSMS2.Cnt_Descrip.ToString();
                    clsSMS2.Cnt_Focus = null;
                    clsSMS2.Cnt_Descrip = null;
                }
                cmbCustomerID.Focus();

                CustomerRetrieve("(CRM.Cus_Code = '" + cmbCustomerID.Text.Trim() + "' OR CRM.Mobile = '" + cmbCustomerID.Text.Trim() + "' OR CRM.NICNumber = '" + cmbCustomerID.Text.Trim() + "' OR CRM.Card_No = '" + cmbCustomerID.Text.Trim().Replace("CFC", "") + "')");
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            //if (dataGridViewProductMaster.Visible == true)
            //{
            //    DataViewProductSearch.Table = ObCustomer.dataset.Tables["T"];
            //    if (txtMobile.Text.Trim() != string.Empty)
            //    {
            //        DataViewProductSearch.RowFilter = "Mobile LIKE '%" + txtMobile.Text.Trim() + "%'";
            //    }
            //    dataGridViewProductMaster.DataSource = DataViewProductSearch;
            //    if (DataViewProductSearch.Count < 7)
            //    {
            //        dataGridViewProductMaster.Height = dataGridViewProductMaster.RowCount * 22;
            //    }
            //    else
            //    {
            //        if (DataViewProductSearch.Count > 1 && DataViewProductSearch.Count < 7)
            //        {
            //            dataGridViewProductMaster.Height = dataGridViewProductMaster.RowCount * 22;
            //        }
            //        else
            //        {
            //            dataGridViewProductMaster.Height = 7 * 22;
            //        }
            //    }
            //    dataGridViewProductMaster.Refresh();
            //}
        }

        private void txtMobile_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 )
            //{
            //    btnSearchByMobile_Click(sender, e);
            //    txtMobile.Focus();
            //}
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            //dtBirthday.Text = dtpBirthday.Text.Trim();
        }

        private void dtpSPBirthday_ValueChanged(object sender, EventArgs e)
        {
            mtxtSpouseBDay.Text = dtpSPBirthday.Text.Trim();
        }

        private void chkSpouseBirthday_Enter(object sender, EventArgs e)
        {
            chkSpouseBirthday.ForeColor = Color.Blue;
        }

        private void chkSpouseBirthday_Leave(object sender, EventArgs e)
        {
            chkSpouseBirthday.ForeColor = Color.Black;
        }

        private void chkSpouseBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkSpouseBirthday.Checked)
                {
                    dtpSPBirthday.Focus();

                }
                else
                {
                    mtxtAnniverssary.Focus();
                    
                }
                // mtxtSpouseBDay.SelectAll();
            }
        }

        private void dtpSPBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mtxtAnniverssary.Focus();
            }
            else if (e.KeyCode==Keys.F2)
            {
                dtBirthday.Visible = true;
                mtxtSpouseBDay.Visible = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                dtBirthday.Visible = false;
                mtxtSpouseBDay.Visible = false;
            }
        }

        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        /*
                        if (dtBirthday.Text.Trim() != "/  /")
                        {
                            string timestamp_string = dtBirthday.Text.ToString();
                            DateTime timestamp = Convert.ToDateTime(timestamp_string);
                            if (timestamp_string.Length < 10)
                            {
                                MessageBox.Show("Date format of the birthday is incorrect.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtBirthday.Focus();
                                return;
                            }
                        }
                        */
                        dtBirthday.Text = dtpBirthday.Text.Trim();
                        dtpBirthday.Visible = false;
                        dtBirthday.Focus();
                        //Convert.ToDateTime(dtBirthday.Text.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Date format of the birthday is incorrect.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtBirthday.Focus();
                        return;
                    }
                    //txtNameOfSpouse.Focus();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    try
                    {
                        frmCustomerSearch search = new frmCustomerSearch();
                        clsSMS2.SearchDataset = ObCustomer.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE Birthday LIKE '" + dtBirthday.Text.Trim() + "%' ORDER BY CONVERT(DATETIME,Birthday,103)", "T");
                        search.Show();
                        if (clsSMS2.Cnt_Focus != null)
                        {
                            cmbCustomerID.Text = clsSMS2.Cnt_Focus.ToString();
                            cmbCustomerName.Text = clsSMS2.Cnt_Descrip.ToString();
                            clsSMS2.Cnt_Focus = null;
                            clsSMS2.Cnt_Descrip = null;
                        }
                        cmbCustomerID.Focus();
                    }
                    catch (Exception ex)
                    {
                        clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void chkSpouseBirthday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpouseBirthday.Checked)
                dtpSPBirthday.Enabled = true;
            else
                dtpSPBirthday.Enabled = false;
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtCardNumber.Focus();
            //    txtCardNumber.SelectAll();
            //}

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOccupation.Focus();
                    txtOccupation.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dtpBirthday_Leave(object sender, EventArgs e)
        {
            dtpBirthday.Visible = false;
            /*
            if (dtBirthday.Text != "  /  /")
            {
                try
                {
                    Convert.ToDateTime(dtBirthday.Text);
                    txtAge.Text = string.Format("{0:00}", ((int.Parse(string.Format("{0:yyyy}", DateTime.Now)) - (int.Parse(string.Format("{0:yyyy}", Convert.ToDateTime(dtBirthday.Text)))))));
                }
                catch
                {
                    MessageBox.Show("Customer Birthday not valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtBirthday.Focus();
                    return;
                    //dtBirthday.Text = string.Empty;
                }
            }
            */
        }

        private void dtBirthday_Enter(object sender, EventArgs e)
        {
            
            
        }

        private void dtBirthday_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dtpBirthday.Visible = true;
            dtpBirthday.Focus();

            if(dtBirthday.Text!="  /  /")
            {
                dtpBirthday.Text = dtBirthday.Text.Trim();
            }
            else
            {
                dtpBirthday.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void cmbReligion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtContactPerson.Focus();
                    txtContactPerson.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void chkCardNo_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCardNo.Checked)
            {
                txtCardNumber.Enabled = true;
            }
            else
            {
                txtCardNumber.Enabled = false;
            }
        }

        private void chkExcelData_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkExcelData_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkExcelData.Checked == true)
            { 
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false; 
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "All Files|*.xls;*.xlsx;*.xlsm"; ;
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        // Insert code to read the stream here.
                        txtPath.Text = openFileDialog1.FileName;
                        myStream.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'FrmTemporaryInv 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPath.Text == string.Empty)
                {
                    MessageBox.Show("Please Selecet The Valied Path", "Unsuccessful Attempt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Focus();
                    return;
                }
                if (txtSheet.Text == string.Empty)
                {
                    MessageBox.Show("Please Selecet The Valied Sheet", "Unsuccessful Attempt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSheet.Focus();
                    return;
                }

                ObCustomer.Parth = txtPath.Text.Trim(); 
                string SheetD = txtSheet.Text.Trim();
                ObCustomer.SheetName = SheetD.Trim() + '$';
                ObCustomer.ExcelDataUpdate(); 

                ObCustomer.dataset = ObCustomer.getDataSet("SELECT Cus_Code,Card_No,Loca FROM CRM_Customer_ExcelData", "CustomerDetails");
                foreach (DataRow row in ObCustomer.dataset.Tables[0].Rows)
                {
                    string SqlStatement = "SELECT Cus_Code FROM CRM_Customer WHERE Cus_Code = '" + row["Cus_Code"].ToString() + "'";
                    Main.getDataReader(SqlStatement);
                    if (Main.Reader.Read()) 
                    {
                        DataTable table = new DataTable("OldCustomer");
                        table.Columns.Add("Cus_Code", typeof(int));
                        table.Rows.Add(row["Cus_Code"].ToString());

                        panel1.Size = new Size(456, 291);
                        ObCustomer.CusCode = row["Cus_Code"].ToString();                

                        SqlStatement = "SELECT Cus_Code,Cus_Name,Loca FROM CRM_Customer WHERE Cus_Code = '" + ObCustomer.CusCode + "'";
                        ObCustomer.getDataset(SqlStatement, "dsInCustomer");
                        dataGridView1.DataSource = ObCustomer.dataset.Tables["dsInCustomer"];
                        dataGridView1.Refresh();
                        return;
                    }

                    ObCustomer.CusCode = row["Cus_Code"].ToString();
                    ObCustomer.Card_No = row["Card_No"].ToString(); 
                    ObCustomer.ExcelDataRead();

                }

                MessageBox.Show("Record saved successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'FrmTemporaryInv 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
           /* Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = null;
            Microsoft.Office.Interop.Excel.Range xlRange = null;

            try
            {

                string sqlStatement = "";

                if (MessageBox.Show("Do you want to download excel template?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DownloadExcelTemplate();
                    return;
                }

                sqlStatement = "DELETE FROM CRM_Customer_ExcelData";
                ObCustomer.getDataReader(sqlStatement);


                string fname = "";
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Excel File Dialog";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    fname = fdlg.FileName;
                }
                else
                {
                    return;
                }



                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(fname);
                xlWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                Cursor.Current = Cursors.WaitCursor;
                for (int i = 2; i <= rowCount; i++)
                {

                    string Cus_Code = ((Microsoft.Office.Interop.Excel.Range)xlRange.Cells[i, 1]).Value2.ToString();
                    string Card_No = ((Microsoft.Office.Interop.Excel.Range)xlRange.Cells[i, 2]).Value2.ToString();
                    string Loca = ((Microsoft.Office.Interop.Excel.Range)xlRange.Cells[i, 3]).Value2.ToString();

                    sqlStatement = "INSERT INTO CRM_Customer_ExcelData (Cus_Code,Card_No,Loca) VALUES('" + Cus_Code + "','" + Card_No + "','" + Loca + "')";
                    ObCustomer.getDataReader(sqlStatement);
                }

                sqlStatement = "SELECT A.Cus_Code, A.Card_No FROM CRM_Customer_ExcelData A INNER JOIN CRM_Customer B ON A.Cus_Code=B.Cus_Code OR A.Card_No=B.Card_No";
                ObCustomer.getDataReader(sqlStatement);
                if (ObCustomer.Reader.Read())
                {
                    MessageBox.Show("Customer code " + ObCustomer.Reader["Cus_Code"].ToString() + " or Card Number " + ObCustomer.Reader["Card_No"].ToString() + " is already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ObCustomer.CustCategory = cmbCustCategory.Text.Trim();
                ObCustomer.ExcelDataRead();

                MessageBox.Show("Customer list added successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background 
                if (xlRange != null)
                    Marshal.ReleaseComObject(xlRange);

                if (xlWorksheet != null)
                    Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                if (xlWorkbook != null)
                {
                    //xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                }

                //quit and release  
                if (xlApp != null)
                {
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                }

                Cursor.Current = Cursors.Default;
            }*/
        }

        public void DownloadExcelTemplate()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;

            try
            {
                string fname = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save Excel File";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname = saveFileDialog1.FileName;
                }
                else
                {
                    return;
                }

                xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }



                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "Cus_Code";
                xlWorkSheet.Cells[1, 2] = "Card_No";
                xlWorkSheet.Cells[1, 3] = "Loca";

                xlWorkBook.SaveAs(fname, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();



                MessageBox.Show("Excel file created , you can find the file " + fname, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (xlWorkSheet != null)
                    Marshal.ReleaseComObject(xlWorkSheet);

                if (xlWorkBook != null)
                    Marshal.ReleaseComObject(xlWorkBook);

                if (xlApp != null)
                    Marshal.ReleaseComObject(xlApp);
            }

        }

        private void chkVatCus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVatCus.Checked == true)
            {
                txtCusVatNo.Enabled = true;
            }
            else
            {
                txtCusVatNo.Text = string.Empty;
                txtCusVatNo.Enabled = false;

            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCusCreditPeriod.Focus();
            }
        }

        private void txtCusCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCusCreditPeriod.Text.Trim() == string.Empty)
                { txtCusCreditPeriod.Text = "0"; }
                txtCusCreditLimit.Focus();
            }
        }

        private void txtCusCreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCusCreditLimit.Text.Trim() == string.Empty)
                { txtCusCreditLimit.Text = "0"; }
                txtCusDiscount.Focus();
            }
        }

        private void txtAddress2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkNameAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNameAuto.Checked)
            {
                cmbCustomerName.Enabled = false;
            }
            else
            {
                cmbCustomerName.Enabled = true;
            }
        }
        public void AddNames()
        {
            if (chkNameAuto.Checked)
            {
                cmbCustomerName.Text = txtFirstName.Text + " " + txtSecondName.Text;
            }
        }
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            AddNames();
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            AddNames();
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           
            if (txtMobile.Text.Length == 0 && e.KeyChar == '+')
            {
               
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 ||( e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '+' && txtMobile.Text.IndexOf('+') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtMobile_Validated(object sender, EventArgs e)
        {
            
        }

        private void cmbCustCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCustGroupName.Focus();
            }
        }

        private void txtCusDiscount_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

    }
}