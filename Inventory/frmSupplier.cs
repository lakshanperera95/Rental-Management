using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
          //  tabCustomer.e
        }
        bool supSearching = Settings.Default.Searching;
        private clsSupplier objCustomer = new clsSupplier();
        private clsSupplier ObjSupplier = new clsSupplier();
        private frmSearch search = new frmSearch();
        private static frmSupplier accounts;
        private int Err;
        private double value = 0;

        private string strSqlString;
        private string strDatasetName;

        public static frmSupplier GetAccount {
            get 
            {
                return accounts;
            }
            set
            {
                accounts = value;
            }     
        }

        #region Supplier functions here

        private void txtSupCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtSupCode.Text = search.Code.Trim();
                    txtSupDescript.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                
                {
                    if (txtSupDescript.Text.Trim() != string.Empty)
                    {
                        strSqlString = "SELECT Supp_Code [Supplier Code],Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtSupDescript.Text.Trim() + "%' or Supp_Code LIKE '%" + txtSupDescript.Text.Trim() + "%'  ORDER BY Supp_Name";
                    }
                    else
                    {
                        strSqlString = "SELECT Supp_Code [Supplier Code],Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                    }
                }

                strDatasetName = "dsSupplier";

                ObjSupplier.SqlStatement = strSqlString;
                ObjSupplier.DataSetName = strDatasetName;

                ObjSupplier.GetSupplierDetails();
                search.dgSearch.DataSource = ObjSupplier.GetSupplierDataset.Tables[strDatasetName];
                search.prop_Focus = txtSupCode;
                search.Cont_Descript = txtSupDescript;
                search.Show();
                search.Location = new Point(this.Location.X + 85, this.Location.Y + 125);
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #region toolstrip buttons
        private void btnSupSave_Click(object sender, EventArgs e)
        {
            try
            {
                Err = 0;
                if ((txtSupCode.Text == string.Empty) || (txtSupDescript.Text == string.Empty))
                {
                    Err++;
                }

                this.validator(tabSupplier);

                if (txtLinkedCusCode.Text != "")
                {
                    ObjSupplier.SqlStatement = "SELECT Cust_Code FROM Customer WHERE Cust_Code='" + txtLinkedCusCode.Text.Trim() + "' ";
                    ObjSupplier.ReadDetails();
                    if (ObjSupplier.RecordFound == false)
                    {
                        MessageBox.Show("Linked Customer Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLinkedCusCode.SelectAll();
                        return;
                    }
                }
                if (chkvatSup.Checked == true && txtSupvatNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Vat Registred Number not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupvatNo.Focus();
                    return;
                }
                if(txtSupCreditPeriod.Text.Trim()==string.Empty)
                {
                    txtSupCreditPeriod.Text = "0";
                }
                if (Err == 0)
                {
                    if((MessageBox.Show("Are you Sure You Want to Save the Supplier?",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes))
                    {
                        ObjSupplier.ErrorCode = 0;
                        ObjSupplier.Supp_Code = txtSupCode.Text.Trim().ToUpper();
                        ObjSupplier.Supp_Name = txtSupDescript.Text.Trim().ToUpper();
                        ObjSupplier.SuppAddress1 = txtSupAdd1.Text.Trim().ToUpper();
                        ObjSupplier.SuppAddress2 = txtSupAdd2.Text.Trim().ToUpper();
                        ObjSupplier.SuppAddress3 = txtSupAdd3.Text.Trim().ToUpper();
                        ObjSupplier.SuppAddress4 = txtSupCity.Text.Trim().ToUpper();
                        ObjSupplier.SuppTel = txtSupTelphone.Text.Trim().ToUpper();
                        ObjSupplier.SuppFax = txtSupFax.Text.Trim().ToUpper();
                        ObjSupplier.SuppEmail = txtSupEmail.Text.Trim();
                        ObjSupplier.SuppContact_Prsn = txtSupContPersn.Text;
                        ObjSupplier.SuppCredit_Period = int.Parse(txtSupCreditPeriod.Text);
                        ObjSupplier.AccountNumber = txtAccountNumber.Text.Trim();
                        ObjSupplier.Bank = cmbBank.Text.ToUpper().Trim();
                        ObjSupplier.Branch = cmbBranch.Text.ToUpper().Trim();
                        ObjSupplier.Disable = chkSupDisable.Checked;
                        ObjSupplier._strLinkCust = txtLinkedCusCode.Text.Trim();
                        ObjSupplier._blIsVat = chkvatSup.Checked;
                        ObjSupplier._strVatNo = txtSupvatNo.Text;
                        //clear all the properties used in search form
                        search.Code = string.Empty;
                        search.Descript = string.Empty;
                        search.prop_Focus = null;
                        search.prop_Name = txtSupvatNo.Text = string.Empty;
                        chkvatSup.Checked = false;
                        ObjSupplier.SupplierUpdate();
                        MessageBox.Show("Supplier Save Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsClear.getclear().clearfeilds(tabSupplier, txtSupCode);
                        cmbBank.SelectedIndex = -1;
                        cmbBranch.SelectedIndex = -1;


                        btnSupClear.PerformClick();

                    }
                    else
                    {
                        return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupCode.Text != string.Empty)
                {
                    if (MessageBox.Show("Do you really want to delete the record ?  " + txtSupCode.Text + "", "Supplier Details",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ObjSupplier.Supp_Code = txtSupCode.Text.Trim().ToUpper();
                        ObjSupplier.ReadSupplierRelatedDetails();
                        if (ObjSupplier.RecordFound == true)
                        {
                            MessageBox.Show("Product Found Under This Supplier. Can't Delete Supplier.", "Supplier Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            ObjSupplier.Supp_Code = txtSupCode.Text.Trim().ToUpper();
                            ObjSupplier.SupplierDelete();
                            clsClear.getclear().clearfeilds(tabSupplier, txtSupCode);
                        }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupClear_Click(object sender, EventArgs e)
        {
            try
            {
                clsClear.getclear().clearfeilds(tabSupplier, txtSupCode);
                enable(tabSupplier);
                txtSupCode.Enabled = true;
                btnSupSearch.Enabled = true;
                cmbBank.SelectedIndex = -1;
                GetSuppCode();
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                accounts = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
#endregion
        
#endregion

        #region Customer functions here

        private void tabCustomer_Enter(object sender, EventArgs e)
        {
            try
            {
                accounts.Text = "Customer Details";
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusCode_Enter(object sender, EventArgs e)
        {
            /*try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtCusCode.Text = search.Code.Trim();
                    txtCusDescript.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void btnCusSearch_Click(object sender, EventArgs e)
        {
          /*  try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }


                if (cmbCustomerType.Text.Trim() == "Wholesale Customer")
                {
                    if (txtCusCode.Text.Trim() != string.Empty && txtCusDescript.Text.Trim() == string.Empty)
                    {
                        strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Iid = 'WSL' AND Cust_Code LIKE '%" + txtCusCode.Text.Trim() + "%' ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCusCode.Text.Trim() == string.Empty && txtCusDescript.Text.Trim() != string.Empty)
                        {
                            strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Iid = 'WSL' AND Cust_Name LIKE '%" + txtCusDescript.Text.Trim() + "%' ORDER BY Cust_Name";
                        }
                        else
                        {
                            strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Iid = 'WSL' ORDER BY Cust_Code desc";
                        }
                    }
                }
                else if (cmbCustomerType.Text.Trim() == "Retail Customer")
                {
                    if (txtCusCode.Text.Trim() != string.Empty && txtCusDescript.Text.Trim() == string.Empty)
                    {
                        strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Iid = 'RGL' AND Cust_Code LIKE '%" + txtCusCode.Text.Trim() + "%' ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCusCode.Text.Trim() == string.Empty && txtCusDescript.Text.Trim() != string.Empty)
                        {
                            strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Iid = 'RGL' AND Cust_Name LIKE '%" + txtCusDescript.Text.Trim() + "%' ORDER BY Cust_Name";
                        }
                        else
                        {
                            strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Iid = 'RGL' ORDER BY Cust_Code desc";
                        }
                    }
                }
                else
                {
                    if (txtCusCode.Text.Trim() != string.Empty && txtCusDescript.Text.Trim() == string.Empty)
                    {
                        strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtCusCode.Text.Trim() + "%' ORDER BY Cust_Code";
                    }
                    else
                    {
                        if (txtCusCode.Text.Trim() == string.Empty && txtCusDescript.Text.Trim() != string.Empty)
                        {
                            strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtCusDescript.Text.Trim() + "%' ORDER BY Cust_Name";
                        }
                        else
                        {
                            strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer ORDER BY Cust_Code desc";
                        }
                    }
                }
                strDatasetName = "dsCustomer";

                objCustomer.SqlStatement = strSqlString;
                objCustomer.DataSetName = strDatasetName;
                objCustomer.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomer.GetCustomerDataset.Tables[strDatasetName];
                search.prop_Focus = txtCusCode;
                search.Cont_Descript = txtCusDescript;
                search.Show();
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        #region ToolStrip Buttons
        private void btnCusSave_Click(object sender, EventArgs e)
        {
            /*try
            {
                Err = 0;
                if ((txtCusCode.Text == string.Empty) || (txtCusDescript.Text == string.Empty))
                {
                    Err++;
                }
                if (!IsNumeric(txtCusCreditLimit.Text))
                {
                    Err++;
                }
                                
                if (clsValidation.isNumeric(txtCusDiscount.Text, System.Globalization.NumberStyles.Number) != true || decimal.Parse(txtCusDiscount.Text) > 100)
                {
                    MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22%)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusDiscount.Text = "0";
                    return;
                }

                if (clsValidation.isNumeric(txtCusCreditLimit.Text, System.Globalization.NumberStyles.Number) != true)
                {
                    MessageBox.Show("Invalid Credit Limit. Please Enter Valid Credit Limit", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusCreditLimit.Text = "0";
                    return;
                }

                if (clsValidation.isNumeric(txtCusCreditPeriod.Text, System.Globalization.NumberStyles.Number) != true)
                {
                    MessageBox.Show("Invalid Credit Period. Please Enter Valid Credit Period", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusCreditPeriod.Text = "0";
                    return;
                }
                if (chkVatCus.Checked==true && txtCusVatNo.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Vat Registred Number not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCusVatNo.Focus();
                    return;
                }
                objCustomer.SqlStatement = "SELECT NIC FROM Customer WHERE NIC = '" + txtcusNic.Text.Trim() + "'AND Cust_Code <> '" + txtCusCode.Text.Trim() + "'";
                objCustomer.DataSetName = "NICNumber";
                objCustomer.GetCustomerDetails();
                foreach (DataRow row in objCustomer.GetCustomerDataset.Tables["NICNumber"].Rows)
                {
                    string DuplicateNIC = row["NIC"].ToString();
                    if (txtcusNic.Text == DuplicateNIC)
                    {
                        MessageBox.Show("Invalid NIC Number. You have entered another Customer", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcusNic.SelectAll();
                        txtcusNic.Focus();
                        return;
                    }
                }

                if (txtLinkedSupCode.Text!="")
                {
                    objCustomer.SqlStatement = "SELECT Supp_Code FROM Supplier WHERE Supp_Code='" + txtLinkedSupCode.Text.Trim() + "' ";
                    objCustomer.ReadDetails();
                    if (objCustomer.RecordFound == false)
                    {
                        MessageBox.Show("Linked Supplier Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLinkedSupCode.SelectAll();
                        return;
                    }

                }
                
                this.validator(tabCustomer);

                if (Err == 0)
                {
                    if (cmbCustomerType.Text.Trim() == "Wholesale Customer")
                        objCustomer.CustIid = "WSL";
                    else if (cmbCustomerType.Text.Trim() == "Retail Customer")
                        objCustomer.CustIid = "RGL";
                    else
                        objCustomer.CustIid = "RGL";

                    objCustomer.ErrorCode = 0;
                    objCustomer.Cust_Code = txtCusCode.Text.Trim().ToUpper();
                    objCustomer.Cust_Name = txtCusDescript.Text.Trim().ToUpper();
                    objCustomer.CusAddress1 = txtCusAdd1.Text.Trim().ToUpper();
                    objCustomer.CusAddress2 = txtCusAdd2.Text.Trim().ToUpper();
                    objCustomer.CusAddress3 = txtcusAdd3.Text.Trim().ToUpper();
                    objCustomer.CusAddress4 = txtCusCity.Text.Trim().ToUpper();
                    objCustomer.CusCountry = txtCusCountry.Text.Trim().ToUpper();
                    objCustomer.CusContact_Prsn = "";//txtCusContPrsn.Text.Trim().ToUpper();
                    objCustomer.CusTel = txtCusTel.Text.Trim().ToUpper();
                    objCustomer.CusFax = txtCusFax.Text.Trim().ToUpper();
                    objCustomer.CusEmail = "";//txtCusEmail.Text.Trim();
                    objCustomer.CusCredit_Limit = decimal.Parse(txtCusCreditLimit.Text);
                    objCustomer.CusNIC = txtcusNic.Text.Trim().ToUpper();
                    objCustomer.CusCredit_Period = int.Parse(txtCusCreditPeriod.Text);
                    objCustomer.CusDiscount = decimal.Parse(txtCusDiscount.Text);
                    objCustomer.Disable = chkCusDisable.Checked;
                    objCustomer._PayType = cmbPayType.Text.Trim().ToUpper();
                    objCustomer._strLinkSupp = txtLinkedSupCode.Text.Trim();
                    objCustomer._blIsVat = chkVatCus.Checked;
                    objCustomer._strVatNo = txtCusVatNo.Text;
                    //clear all the properties used in search form
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                    search.prop_Focus = null;
                    search.prop_Name = string.Empty;

                    objCustomer.CustomerUpdate();

                    txtCusCode.Text = string.Empty;
                    txtCusDescript.Text = string.Empty;
                    txtCusAdd1.Text = string.Empty;
                    txtCusAdd2.Text = string.Empty;
                    txtcusAdd3.Text = string.Empty;
                    txtCusCity.Text=txtCusVatNo.Text = string.Empty;
                    txtCusCountry.Text = string.Empty;
                    //txtCusContPrsn.Text = string.Empty;
                    txtCusTel.Text = string.Empty;
                    txtCusFax.Text = string.Empty;
                    //txtCusEmail.Text = string.Empty;
                    txtCusCreditLimit.Text = string.Empty;
                    txtcusNic.Text = string.Empty;
                    chkCusDisable.Checked = false;
                    chkVatCus.Checked = false;
                    btnCusClear.PerformClick();
                    clsClear.getclear().clearfeilds(tabCustomer, txtCusCode);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void btnCusDelete_Click(object sender, EventArgs e)
        {
           /* try
            {
                if (txtCusCode.Text != string.Empty)
                {
                    if ((MessageBox.Show("Do you really want to delete the record ?  " + txtCusCode.Text + "", "Customer Details",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {

                        objCustomer.Cust_Code = txtCusCode.Text.Trim().ToUpper();
                        objCustomer.CustomerDelete();
                        clsClear.getclear().clearfeilds(tabCustomer, txtCusCode);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void btnCusClear_Click(object sender, EventArgs e)
        {
            /*try
            {
                txtCusCode.Enabled = true;
                search.Code = string.Empty;
                search.Descript = string.Empty;
                txtCusCode.Text = string.Empty;
                txtCusDescript.Text = string.Empty;
                txtCusAdd1.Text = string.Empty;
                txtCusAdd2.Text = string.Empty;
                txtcusAdd3.Text = string.Empty;
                txtCusCity.Text = string.Empty;
                txtCusCountry.Text = string.Empty;
                //txtCusContPrsn.Text = string.Empty;
                txtCusTel.Text = string.Empty;
                txtCusFax.Text = string.Empty;
                //txtCusEmail.Text = string.Empty;
                txtCusCreditLimit.Text = string.Empty;
                txtCusCreditPeriod.Text = string.Empty;
                txtCusDiscount.Text = string.Empty;
                txtcusNic.Text = string.Empty;
                enable(tabCustomer);
                btnCusSearch.Enabled = true;
                chkVatCus.Checked = false;
                cmbPayType.SelectedIndex = 0;
                clsClear.getclear().clearfeilds(tabCustomer, txtCusDescript);
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void btnCusExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                accounts = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        #endregion

#endregion

        #region Validate whether credit limit contains non numerical character
        internal static bool IsNumeric(string cnt)
        {
            double d;
            try
            {
                d = Double.Parse(cnt);
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Validate whether textfeilds contains ' character
        public void validator(Control cnt)
        {
            try
            {
                for (int i = 0; i < cnt.Controls.Count; i++)
                {
                    if ((cnt.Controls[i].GetType() == typeof(TextBox)) && (cnt.Controls[i].Text.Contains("'")))
                    {
                        MessageBox.Show("Invalid characters in Textfeilds Please check the characters entered.", "Invalid character (') found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cnt.Controls[i].Text = string.Empty;
                        cnt.Controls[i].Focus();

                        Err++;

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        #endregion 

        private void frmAccounts_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                accounts = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusCode_KeyDown(object sender, KeyEventArgs e)
        {
           /* try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCusCode.Text.Trim() != String.Empty)
                    {
                        objCustomer.SqlStatement = "SELECT Cust_Code, Cust_Name, Area_Code, Address1, Address2, Address3, Address4, Country, Tel, Fax, Email, DateOfBirth, NIC, Age, RemindDate, Credit_Period, Credit_Limit, Contact_Prsn, Discount, Iid, Inactive, paymentType,VAT,VatNo FROM customer where (Cust_Code = '" + txtCusCode.Text.Trim().ToUpper() + "' OR NIC = '" + txtCusCode.Text.Trim().ToUpper() + "')";
                        objCustomer.ReadCustomerDetails();
                        if (objCustomer.RecordFound == true)
                        {
                            txtCusCode.Text = objCustomer.Cust_Code;
                            txtCusDescript.Text = objCustomer.Cust_Name;
                            txtCusAdd1.Text = objCustomer.CusAddress1;
                            txtCusAdd2.Text = objCustomer.CusAddress2;
                            txtcusAdd3.Text = objCustomer.CusAddress3;
                            txtCusCity.Text = objCustomer.CusAddress4;
                            txtCusCountry.Text = objCustomer.CusCountry;
                            //txtCusContPrsn.Text = objCustomer.CusContact_Prsn;
                            txtCusTel.Text = objCustomer.CusTel;
                            txtCusFax.Text = objCustomer.CusFax;
                            //txtCusEmail.Text = objCustomer.CusEmail;
                            txtCusCreditLimit.Text = objCustomer.CusCredit_Limit.ToString();
                            txtcusNic.Text = objCustomer.CusNIC;
                            txtCusCreditPeriod.Text = objCustomer.CusCredit_Period.ToString();
                            txtCusDiscount.Text = objCustomer.CusDiscount.ToString();
                            chkCusDisable.Checked = objCustomer.Disable;
                            if (objCustomer.CustIid == "WSL")
                            {
                                cmbCustomerType.Text = "Wholesale Customer";
                            }
                            else if (objCustomer.CustIid == "RGL")
                            {
                                cmbCustomerType.Text = "Retail Customer";
                            }
                            else
                            {
                                cmbCustomerType.Text = "Wholesale Customer";
                            }

                            cmbPayType.Text = objCustomer._PayType;

                            chkVatCus.Checked = objCustomer._blIsVat;
                            txtCusVatNo.Text = objCustomer._strVatNo;
                            //------link customer
                            objCustomer.SqlStatement = "SELECT Supplier.Supp_Code, Supplier.Supp_Name FROM tb_LinkedCustSupp INNER JOIN Supplier ON Supplier.Supp_Code=tb_LinkedCustSupp.Supp_Code where Cust_Code = '" + txtCusCode.Text.Trim().ToUpper() + "'";
                            objCustomer.DataSetName = "LinkedSupplier";
                            objCustomer.GetSupplierDetails();
                            if (objCustomer.GetSupplierDataset.Tables["LinkedSupplier"].Rows.Count==1)
                            {
                                txtLinkedSupCode.Text = objCustomer.GetSupplierDataset.Tables["LinkedSupplier"].Rows[0]["Supp_Code"].ToString();
                                txtLinkedSuppName.Text = objCustomer.GetSupplierDataset.Tables["LinkedSupplier"].Rows[0]["Supp_Name"].ToString();
                            }
                            //===================


                            txtCusCode.Enabled = false;
                            txtCusDescript.Focus();
                        }
                        else
                        {
                            txtCusDescript.Focus();
                        }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 016A. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void txtCusDescript_KeyDown(object sender, KeyEventArgs e)
        {
         /*   try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCusAdd1.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 016B. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void txtCusAdd2_KeyDown(object sender, KeyEventArgs e)
        {
         /*   try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtcusAdd3.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void txtCusAdd1_KeyDown(object sender, KeyEventArgs e)
        {
          /* try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCusAdd2.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void txtcusAdd3_KeyDown(object sender, KeyEventArgs e)
        {
           /* try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCusCity.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 019. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void txtCusCity_KeyDown(object sender, KeyEventArgs e)
        {
            /*try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCusCountry.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 020. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void txtCusCountry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  ////  txtCusTel.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 021. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusContPrsn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  //  txtCusCreditPeriod.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 022. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusTel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                 //   txtCusFax.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 023. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusFax_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                //   txtcusNic.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 024. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                //    txtcusNic.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 025. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtcusNic_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  // cmbPayType.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtcusRemind_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  //  txtCusCreditLimit.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 027. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusCreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
              /*  if (e.KeyCode == Keys.Enter)
                {
                    if (clsValidation.isNumeric(txtCusCreditLimit.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtCusCreditLimit.Text) >= 0)
                    {
                        txtCusDiscount.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credit Limit. Please Enter Valid Credit Limit", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCusCreditLimit.Text = "0";
                        return;
                    }
                }*/
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 028. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSupCode.Text.Trim() != String.Empty)
                    {
                        ObjSupplier.SqlStatement = "SELECT Supp_Code, Supp_Name, Address1, Address2, Address3, Address4, Tel, Fax, Email, Status, Contact_Prsn, ISNULL(Credit_Period, 0) Credit_Period, AccountNo, Bank, Branch, Inactive,VAT,VatNo FROM SUPPLIER where Supp_Code = '" + txtSupCode.Text.Trim().ToUpper() + "'";
                        ObjSupplier.ReadSupplierDetails();
                        if (ObjSupplier.RecordFound == true)
                        {
                            txtSupCode.Text = ObjSupplier.Supp_Code;
                            txtSupDescript.Text = ObjSupplier.Supp_Name;
                            txtSupAdd1.Text = ObjSupplier.SuppAddress1;
                            txtSupAdd2.Text = ObjSupplier.SuppAddress2;
                            txtSupAdd3.Text = ObjSupplier.SuppAddress3;
                            txtSupCity.Text = ObjSupplier.SuppAddress4;
                            txtSupTelphone.Text = ObjSupplier.SuppTel;
                            txtSupFax.Text = ObjSupplier.SuppFax;
                            txtSupEmail.Text = ObjSupplier.SuppEmail;
                            txtSupContPersn.Text = ObjSupplier.SuppContact_Prsn;
                            txtSupCreditPeriod.Text = ObjSupplier.SuppCredit_Period.ToString();
                            txtAccountNumber.Text = ObjSupplier.AccountNumber.ToString();
                            cmbBank.Text = ObjSupplier.Bank.ToString();
                            cmbBranch.Text = ObjSupplier.Branch.ToString();
                            chkSupDisable.Checked = ObjSupplier.Disable;
                            chkvatSup.Checked = ObjSupplier._blIsVat;
                            txtSupvatNo.Text = ObjSupplier._strVatNo;


                            //------link customer
                            ObjSupplier.SqlStatement = "SELECT Customer.Cust_Code, Customer.Cust_Name FROM tb_LinkedCustSupp INNER JOIN Customer ON Customer.Cust_Code=tb_LinkedCustSupp.Cust_Code where Supp_Code = '" + txtSupCode.Text.Trim().ToUpper() + "'";
                            ObjSupplier.DataSetName = "LinkedCustomer";
                            ObjSupplier.GetCustomerDetails();
                            if (ObjSupplier.GetCustomerDataset.Tables["LinkedCustomer"].Rows.Count==1)
                            {
                                txtLinkedCusCode.Text = ObjSupplier.GetCustomerDataset.Tables["LinkedCustomer"].Rows[0]["Cust_Code"].ToString();
                                txtLinkedCustName.Text = ObjSupplier.GetCustomerDataset.Tables["LinkedCustomer"].Rows[0]["Cust_Name"].ToString();
                            }
                            //===================

                            txtSupCode.Enabled = false;
                            txtSupAdd1.Focus();
                        }
                        else
                        {
                            txtSupDescript.Focus();
                        }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 029. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        
        private void txtSupDescript_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupAdd1.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtSupCode.Text = txtSupDescript.Text = string.Empty;
                    search.Hide();
                    txtSupDescript.Focus();
                }
                if (e.KeyCode == Keys.F5)
                {
                    if (supSearching == true)
                    {
                        supSearching = false;
                        txtSupCode.BackColor = Color.Empty;
                        txtSupDescript.BackColor = Color.Empty;
                        search.Hide();
                        //ProductSearchImg.Hide();

                        Settings.Default.Searching = false;
                        Settings.Default.Save();
                    }
                    else
                    {
                        supSearching = true;
                        txtSupCode.BackColor = Color.MediumAquamarine;
                        txtSupDescript.BackColor = Color.MediumAquamarine;
                        Settings.Default.Searching = true;
                        Settings.Default.Save();
                    }
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
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 030. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupAdd1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupAdd2.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 031. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupContPersn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBank.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 032. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupContPersn.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 033. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupFax_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupEmail.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 034. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupTelphone_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupFax.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 035. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupTelphone.SelectAll();
                    txtSupTelphone.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 037. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupAdd3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupCity.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 038. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupAdd2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupAdd3.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 039. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSupExit_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                accounts = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 040. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   /* if (clsValidation.isNumeric(txtCusDiscount.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtCusDiscount.Text) >= 0 && decimal.Parse(txtCusDiscount.Text) < 100)
                    {
                        btnCusSave.Focus();
                        //cmbCustomerType.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Discount. Please Enter Valid Discount(Ex: 22%)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCusDiscount.Text = "0";
                        return;
                    }*/
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 041. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCusCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  /*  if (clsValidation.isNumeric(txtCusCreditPeriod.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtCusCreditPeriod.Text) >= 0)
                    {
                        txtCusCreditLimit.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credit Period. Please Enter Valid Credit Period", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCusCreditPeriod.Text = "0";
                        return;
                    }*/
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 042. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtSupCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (clsValidation.isNumeric(txtSupCreditPeriod.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtSupCreditPeriod.Text) >= 0)
                    {
                        btnSupSave.Select();
                    }
                    else
                    {
                        txtSupCreditPeriod.Text = "0";
                        MessageBox.Show("Invalid Credit Period. Please Enter Valid Credit Period", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 043. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (e.TabPageIndex == 0)
                {
                    this.Text = "Customer Details";
                }
                else
                {
                    this.Text = "Supplier Details";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 044. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    /*if (tabMain.SelectedIndex  == 0)
                    {
                        if (e.KeyCode == Keys.S)
                        {
                            this.btnCusSave.PerformClick();
                        }
                        else
                        {
                            if (e.KeyCode == Keys.D)
                            {
                                this.btnCusDelete.PerformClick();
                            }
                            else
                            {
                                if (e.KeyCode == Keys.L)
                                {
                                    this.btnCusClear.PerformClick();
                                }
                                else
                                {
                                    if (e.KeyCode == Keys.E)
                                    {
                                        this.btnCusExit.PerformClick();
                                    }
                                }
                            }
                        }
                    }*/
                    if (tabMain.SelectedIndex == 1)
                    {
                        if (e.KeyCode == Keys.S)
                        {
                            this.btnSupSave.PerformClick();
                        }
                        else
                        {
                            if (e.KeyCode == Keys.D)
                            {
                                this.btnSupDelete.PerformClick();
                            }
                            else
                            {
                                if (e.KeyCode == Keys.L)
                                {
                                    this.btnSupClear.PerformClick();
                                }
                                else
                                {
                                    if (e.KeyCode == Keys.E)
                                    {
                                        this.btnSupExit.PerformClick();
                                    }
                                }
                            }
                        }
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 045.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    /*if (cmbCustomerType.Text.Trim() != string.Empty )
                    {
                        txtCusCode.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Customer Type.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCustomerType.Text = "Wholesale Customer";
                        cmbCustomerType.Focus();
                        return;
                    }*/
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 041. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCustReg_Click(object sender, EventArgs e)
        {
           /* if (txtCusCode.Text != string.Empty && txtCusDescript.Text != string.Empty)
            {
                if (frmCustDetails.GetfrmCustDetail == null)
                {
                    frmCustDetails.GetfrmCustDetail = new frmCustDetails(txtCusCode.Text.Trim(), txtCusDescript.Text.Trim());
                    frmCustDetails.GetfrmCustDetail.MdiParent = MdiParent;
                    frmCustDetails.GetfrmCustDetail.Show();
                }
                else
                {
                    frmCustDetails.GetfrmCustDetail.Focus();
                }
            }
            else
            {
                txtCusCode.Focus();
            }*/
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                ObjSupplier.SqlStatement = "SELECT DISTINCT Branch FROM Supplier";
                ObjSupplier.DataSetName = "Branch";
                ObjSupplier.GetSupplierDetails();
               
                foreach (DataRow row in ObjSupplier.GetSupplierDataset.Tables["Branch"].Rows)
                {
                    cmbBranch.Items.Add(row["Branch"].ToString());
                }

                ObjSupplier.SqlStatement = "SELECT Bank_Name FROM BankDetails";
                ObjSupplier.DataSetName = "Bank";
                ObjSupplier.GetSupplierDetails();
                cmbBank.DataSource = ObjSupplier.GetSupplierDataset.Tables["Bank"];
                cmbBank.DisplayMember = "Bank_Name";
                cmbBank.SelectedIndex = -1;
              //  cmbPayType.SelectedIndex = 0;
               

                GetSuppCode();
                //// cmbCustomerType.SelectedIndex = -1;
                //// cmbCustomerType.Focus();
                if (supSearching == true)
                {
                    txtSupCode.BackColor = Color.MediumAquamarine;
                    txtSupDescript.BackColor = Color.MediumAquamarine;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void GetSuppCode()
        {
            try
            {
                objCustomer.GetSuppCode();
                txtSupCode.Text = objCustomer.CusCode;
                txtSupCode.ReadOnly = true;
               // txtCusDescript.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBranch.Focus();
            }
        }

        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtAccountNumber.SelectAll();
                txtAccountNumber.Focus();
            }
        }

        private void txtAccountNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupCreditPeriod.SelectAll();
                txtSupCreditPeriod.Focus();
            }
        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            //if (IsNumeric(txtAccountNumber.Text))
            //{
            //    if (txtAccountNumber.Text.Length==0)
            //    {
            //        value = 0;
            //    }
            //    else
            //    {
            //        value = double.Parse(txtAccountNumber.Text);
            //    }
                
            //}
            //else
            //{
            //    txtAccountNumber.Text = string.Format("{0:0}", value);
            //    txtAccountNumber.Select(txtAccountNumber.Text.Length, txtAccountNumber.Text.Length);
            //}
        }

        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void chkCusDisable_CheckedChanged(object sender, EventArgs e)
        {
           /* if (chkCusDisable.Checked==true)
            {
                disable(tabCustomer);
                btnCusSearch.Enabled = false;
            }
            else
            {
                enable(tabCustomer);
                btnCusSearch.Enabled = true;
            }*/
        }
        void enable(TabPage com)
        {
            foreach (Control con in com.Controls)
            {
                if (con is TextBox)
                {
                    con.Enabled = true;
                }
                else if (con is ComboBox)
                {
                    con.Enabled = true;
                }
               
            }
        }

        void disable(TabPage com)
        {
            foreach (Control con in com.Controls)
            {
                if (con is TextBox)
                {
                    con.Enabled = false;
                }
                else if (con is ComboBox)
                {
                    con.Enabled = false;
                }
               
               
            }
           
        }

        private void chkSupDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupDisable.Checked == true)
            {
                disable(tabSupplier);
                btnSupSearch.Enabled = false;
            }
            else
            {
                enable(tabSupplier);
                btnSupSearch.Enabled = true;
            }
        }

        private void chkCusDisable_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                 //   cmbPayType.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // txtCusCreditPeriod.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAccount 026. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnLinkedDebCredSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Link The Customer And Supplier",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    ObjSupplier.SqlStatement = "SELECT Supp_Code, Supp_Name, Address1, Address2, Address3, Address4, Tel, Fax, Email, Status, Contact_Prsn, ISNULL(Credit_Period, 0) Credit_Period, AccountNo, Bank, Branch, Inactive FROM SUPPLIER where Supp_Code = '" + txtSupCode.Text.Trim().ToUpper() + "'";
                    ObjSupplier.ReadSupplierDetails();
                    if (ObjSupplier.RecordFound == false)
                    {
                        MessageBox.Show("Supplier Not Found", this.Text);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnLinkedSupp_Click(object sender, EventArgs e)
        {
           /* try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtLinkedSupCode.Text.Trim() != string.Empty && txtLinkedSuppName.Text.Trim() == string.Empty)
                {
                    strSqlString = "SELECT Supp_Code [Supplier Code],Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Code LIKE '%" + txtLinkedSupCode.Text.Trim() + "%' ORDER BY Supp_Code";
                }
                else
                {
                    if (txtLinkedSupCode.Text.Trim() == string.Empty && txtLinkedSuppName.Text.Trim() != string.Empty)
                    {
                        strSqlString = "SELECT Supp_Code [Supplier Code],Supp_Name [Supplier Name] FROM Supplier WHERE Supp_Name LIKE '%" + txtLinkedSuppName.Text.Trim() + "%' ORDER BY Supp_Name";
                    }
                    else
                    {
                        strSqlString = "SELECT Supp_Code [Supplier Code],Supp_Name [Supplier Name] FROM Supplier ORDER BY Supp_Code";
                    }
                }

                strDatasetName = "dsLinkedSupplier";

                ObjSupplier.SqlStatement = strSqlString;
                ObjSupplier.DataSetName = strDatasetName;

                ObjSupplier.GetSupplierDetails();
                search.dgSearch.DataSource = ObjSupplier.GetSupplierDataset.Tables[strDatasetName];
                search.prop_Focus = txtLinkedSupCode;
                search.Cont_Descript = txtLinkedSuppName;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            */
        }

        private void btnLinkedCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                if (txtLinkedCusCode.Text.Trim() != string.Empty && txtLinkedCustName.Text.Trim() == string.Empty)
                {
                    strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Cust_Code LIKE '%" + txtLinkedCusCode.Text.Trim() + "%' ORDER BY Cust_Code";
                }
                else
                {
                    if (txtLinkedCusCode.Text.Trim() == string.Empty && txtLinkedCustName.Text.Trim() != string.Empty)
                    {
                        strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer WHERE Cust_Name LIKE '%" + txtLinkedCustName.Text.Trim() + "%' ORDER BY Cust_Name";
                    }
                    else
                    {
                        strSqlString = "SELECT Cust_Code As [Customer Code],Cust_Name As [Customer Name] FROM Customer ORDER BY Cust_Code desc";
                    }
                }
                strDatasetName = "dsLinkedCustomer";

                objCustomer.SqlStatement = strSqlString;
                objCustomer.DataSetName = strDatasetName;
                objCustomer.GetCustomerDetails();
                search.dgSearch.DataSource = objCustomer.GetCustomerDataset.Tables[strDatasetName];
                search.prop_Focus = txtLinkedCusCode;
                search.Cont_Descript = txtLinkedCustName;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtLinkedSupCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                 //   txtLinkedSupCode.Text = search.Code.Trim();
                 //   txtLinkedSuppName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
            
        }

        private void txtLinkedCusCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtLinkedCusCode.Text = search.Code.Trim();
                    txtLinkedCustName.Text = search.Descript.Trim();
                }
                search.Code = string.Empty;
                search.Descript = string.Empty;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void chkvatSup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkvatSup.Checked == true)
            {
                txtSupvatNo.Enabled = true;
            }
            else
            {
                txtSupvatNo.Text = string.Empty;
                txtSupvatNo.Enabled = false;
            
            }
        }

        private void chkVatCus_CheckedChanged(object sender, EventArgs e)
        {
           /* if (chkVatCus.Checked == true)
            {
                txtCusVatNo.Enabled = true;
            }
            else
            {
                txtCusVatNo.Text = string.Empty;
                txtCusVatNo.Enabled = false;

            }*/
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               /* if (cmbCustomerType.SelectedIndex == -1)
                { return; }
                string type = "";
                if (cmbCustomerType.Text == "Wholesale Customer")
                {
                    type = "WC";
                }
                else if (cmbCustomerType.Text == "Retail Customer")
                {
                    type = "RC";

                }

                objCustomer.GetCusCode(type);
                txtCusCode.Text = objCustomer.CusCode;*/
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtSupDescript_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSupDescript.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && supSearching == true)
            {
                btnSupSearch.PerformClick();
                txtSupDescript.Focus();
            }
        }
    }
}